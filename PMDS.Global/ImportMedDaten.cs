using System;

using System.Collections;
using System.Data;

using System.Collections.Generic;
using System.Text;
using PMDS.DB.Global;
using PMDS.Data.Global;
using System.Net;
using System.IO;
using System.Linq;

using PMDS.Global.db.Patient;
using PMDS.DB;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;


namespace PMDS.Global
{
    

    public class ImportMedDaten
    {
        private dsMedikament dsMedikamentUpdate = new dsMedikament();
        private DBMedikament DBMedikamentUpdate = new DBMedikament();

        private dsMedikament dsMedikamentUpdateExisting = new dsMedikament();
        private DBMedikament DBMedikamentUpdateExisting = new DBMedikament();

        private DataTable tKennzeichen, tEinheiten;

        private List<string> lRecordsToDelete = new List<string>();
        private string sFile = "";
        private string xmlFile = "";

        //private dsMedikament dsMedikamentImportGesamt = new dsMedikament();
        List<string> lstImport_ExtID = new List<string>();

        private Dictionary<string, string> dictMEH = new Dictionary<string, string>()
                                            {
                                                {"HB","Hub/Hübe"},
                                                {"CM", "Zentimeter"},
                                                {"PK","Packung(en)"},
                                                {"L","Liter"},
                                                {"ST","Stück"},
                                                {"FL","Flasche(n)"},
                                                {"G","Gramm"},
                                                {"KG","Kilogramm"},
                                                {"ML","Milliliter"},
                                                {"M","Meter"}
                                            };

        private Dictionary<string, string> dictMEHService = new Dictionary<string, string>()
                                            {
                                                {"Sprühstoß (Sprühstöße) [Hub (Hübe)]","Hub/Hübe"}
                                            };

        private class VariablesFile
        {
            public VariableFile EXT_ID = new VariableFile(2, 8);
            public VariableFile Zulassungsnummer = new VariableFile(9, 18);
            public VariableFile Veraenderungscode = new VariableFile(19, 19);
            public VariableFile Gültigkeitsdatum = new VariableFile(20, 23);
            public VariableFile Lagervorschrift = new VariableFile(62, 62);
            public VariableFile Bezeichnung = new VariableFile(67, 94);
            public VariableFile Packungsgroesse = new VariableFile(95, 99);
            public VariableFile Packungseinheit = new VariableFile(100, 101);
            public VariableFile LastVar = new VariableFile(128, 128);
            public VariableFile Kassenzeichen = new VariableFile(102, 104);     //Für Venerinärprodukte
            public VariableFile Druckunterdrückung = new VariableFile(113, 113);
            public VariableFile Erstattungscode = new VariableFile(56, 56);
        }

        public class VariableFile
        {
            public VariableFile(int iStart, int iEnd)
		    {
                this._iStart = iStart;
                this._iEnd = iEnd;
		    }
            public int _iStart = -1;
            public int _iEnd = -1;
        }

        public bool run(bool bImportGesamtdaten, bool TranslateELGA, ref Infragistics.Win.Misc.UltraLabel lbl, 
                            out int CountUpdated, out int CountDeactivated, 
                            string FileName, string MedikamenteImportType, out string sMsg,
                            int iMonat)
        {
            try
            {
                sMsg = "";
                this.DBMedikamentUpdate.initControl();
                this.dsMedikamentUpdate.Clear();
                this.DBMedikamentUpdate.getMedikament(System.Guid.NewGuid(), this.dsMedikamentUpdate, DBMedikament.eTypeSelMedikament.ID, "", "");

                this.DBMedikamentUpdateExisting.initControl();
                this.dsMedikamentUpdateExisting.Clear();
                this.DBMedikamentUpdateExisting.getMedikament(System.Guid.NewGuid(), this.dsMedikamentUpdateExisting, DBMedikament.eTypeSelMedikament.ID, "", "");

                CountUpdated = 0;
                CountDeactivated = 0;

                if (generic.sEquals(MedikamenteImportType, "file"))
                {

                    if (File.Exists(@"C:\temp\Medikament.txt"))     //Fürs entwickeln
                    {
                        sFile = System.IO.File.ReadAllText(@"C:\temp\Medikament.txt");
                    }
                    else
                        sFile = System.IO.File.ReadAllText(System.IO.Path.Combine(ENV.ftpFileImportMedikamente, FileName));
                }
                else if (generic.sEquals(MedikamenteImportType, "service"))
                {
                    
                    if (!this.GetXMLFromApoVerlag(out sFile, out string sMsgService, bImportGesamtdaten, iMonat))
                    {
                        sMsg = sMsgService;
                        return false;
                    }
                }
                else if (generic.sEquals(MedikamenteImportType, "ftp"))
                {
                    if (!this.downloadFileFtp(ref sFile, ref FileName))
                    {
                        throw new Exception("ImportMedDaten.run: Fehler beim Laden der Datei vom S2-FTP-Server!");
                    }
                }
                else
                {
                    sMsg = "Der angegebene Wert " + MedikamenteImportType + " ist für den Parameter MedikamenteImportType nicht erlaubt.";
                    return false;
                }

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    db.Database.ExecuteSqlCommand("DELETE FROM Medikament WHERE Bezeichnung = ''"); //Leere Einträge löschen (Fehler in früherer Version beheben, wo irrtümlich leere Einträge erzeugt wurden)
                    db.SaveChanges();

                    if (bImportGesamtdaten)
                    {
                        db.Database.ExecuteSqlCommand("UPDATE Medikament SET Aktuell = 0 WHERE Importiert = 1");  
                        db.SaveChanges();

                        PMDSBusiness b = new PMDSBusiness();
                        int iCounterDeletedBack = 0;
                        b.deleteNotUsedMedikamente(ref iCounterDeletedBack, db, ref lbl);
                    }
                }

                string[] aImport = sFile.Split(new char[] { '\n' });
                int lines = aImport.Length;
                
                CountUpdated = 0;
                CountDeactivated = 0;
                int LineNr = 0;

                if (!generic.sEquals(MedikamenteImportType, "service"))
                {
                    VariablesFile vars = new VariablesFile();
                    foreach (string line in aImport)
                    {
                        setStatus(LineNr++, lbl, QS2.Desktop.ControlManagment.ControlManagment.getRes("Datensätze verarbeitet." + " (" + lines.ToString() + ")"), false);

                        if (!String.IsNullOrEmpty(line))
                        {
                            //Veterinärprodukt oder Druckunterdrückung nicht bearbeiten
                            string val_Kassenzeichen = this.getVar(ref vars.Kassenzeichen, line).Trim();
                            string val_Druckunterdrückung = this.getVar(ref vars.Druckunterdrückung, line).Trim();
                            if (val_Kassenzeichen.Trim() == "VN" || val_Kassenzeichen.Trim() == "VNW" || val_Kassenzeichen.Trim() == "VT" ||
                                val_Kassenzeichen.Trim() == "VTW" || val_Druckunterdrückung.Trim() == "D")
                            {
                                continue;
                            }

                            CountUpdated += 1;
                            string val_EXT_ID = this.getVar(ref vars.EXT_ID, line);
                            string val_Gültigkeitsdatum = this.getVar(ref vars.Gültigkeitsdatum, line).Trim();
                            int iYear = System.Convert.ToInt32(val_Gültigkeitsdatum.Substring(2, 2)) + 2000;
                            int iMonth = System.Convert.ToInt32(val_Gültigkeitsdatum.Substring(0, 2));
                            DateTime datGültigkeitsdatum = new DateTime(iYear, iMonth, 1);

                            if (!string.IsNullOrWhiteSpace(val_EXT_ID))
                            {
                                this.dsMedikamentUpdate.Clear();
                                this.dsMedikamentUpdateExisting.Clear();
                                this.DBMedikamentUpdateExisting.getMedikament(System.Guid.Empty, this.dsMedikamentUpdateExisting, DBMedikament.eTypeSelMedikament.ExternIDOrderByGültigkeitsdatumDesc, val_EXT_ID, "");

                                lstImport_ExtID.Add(val_EXT_ID); //alle EXT_IDs aus ImportFile sammeln (fürs Deaktivieren von nicht mehr vorhandenen Medikamenten in der DB) bei Gesamtimport

                                bool bAddNewMedikament = false;
                                int AnzahlAlteMedikamente = 0;
                                dsMedikament.MedikamentRow rNewMedikmant = null;
                                if (this.dsMedikamentUpdateExisting.Medikament.Rows.Count >= 1) //Update bestehendes Medikament
                                {
                                    dsMedikament.MedikamentRow rExistingMedikmant = (dsMedikament.MedikamentRow)this.dsMedikamentUpdateExisting.Medikament.Rows[0];
                                    rNewMedikmant = this.DBMedikamentUpdate.New(this.dsMedikamentUpdate.Medikament);

                                    foreach (dsMedikament.MedikamentRow rAktuell in dsMedikamentUpdateExisting.Medikament.Rows)
                                    {
                                        if (rAktuell.Aktuell)
                                        {
                                            if (rAktuell.IsGültigkeitsdatumNull() || rAktuell.Gültigkeitsdatum < datGültigkeitsdatum) //Aktuelle mit älterem Gültigkeitsdatum gefunden -> nicht aktuell setzen
                                            {
                                                rAktuell.Aktuell = false;
                                                CountDeactivated++;
                                                AnzahlAlteMedikamente++;
                                            }
                                        }
                                    }
                                    if (AnzahlAlteMedikamente == dsMedikamentUpdateExisting.Medikament.Rows.Count)  //Es gibt kein aktuelles Medikament, alle (bisher) aktuellen Einträge sind älter
                                    {
                                        bAddNewMedikament = true;
                                    }
                                }
                                else   // Neues Medikament
                                {
                                    bAddNewMedikament = true;
                                }

                                if (bAddNewMedikament)
                                {
                                    if (this.dsMedikamentUpdate.Medikament.Count == 1)
                                        rNewMedikmant = this.dsMedikamentUpdate.Medikament.First();
                                    else
                                    {
                                        dsMedikamentUpdate.Medikament.Clear();
                                        rNewMedikmant = this.DBMedikamentUpdate.New(this.dsMedikamentUpdate.Medikament);
                                    }
                                    rNewMedikmant.EXT_ID = val_EXT_ID.Trim();
                                    rNewMedikmant.Kassenzeichen = val_Kassenzeichen;
                                    rNewMedikmant.Zulassungsnummer = this.getVar(ref vars.Zulassungsnummer, line);
                                    rNewMedikmant.Gültigkeitsdatum = datGültigkeitsdatum.Date;
                                    rNewMedikmant.Lagervorschrift = this.getVar(ref vars.Lagervorschrift, line);
                                    rNewMedikmant.Bezeichnung = this.getVar(ref vars.Bezeichnung, line);
                                    rNewMedikmant.Packungsgroesse = System.Convert.ToDouble(this.getVar(ref vars.Packungsgroesse, line));
                                    rNewMedikmant.Erstattungscode = this.getVar(ref vars.Erstattungscode, line);
                                    rNewMedikmant.Packungsanzahl = 1;

                                    if (TranslateELGA)
                                        rNewMedikmant.Packungseinheit = dictMEH[this.getVar(ref vars.Packungseinheit, line)];
                                    else
                                        rNewMedikmant.Packungseinheit = this.getVar(ref vars.Packungseinheit, line);

                                    if (generic.sEquals(rNewMedikmant.Packungseinheit, "ST") || generic.sEquals(rNewMedikmant.Packungseinheit, "Stück"))
                                        rNewMedikmant.Herrichten = (int)medHerrichten.langfristig;

                                    rNewMedikmant.ImportiertAm = DateTime.Now;
                                    rNewMedikmant.Importiert = true;
                                    rNewMedikmant.Aktuell = this.getVar(ref vars.Veraenderungscode, line) != "S";  //S=Streichung

                                    this.DBMedikamentUpdate.daMedikament2.Update(this.dsMedikamentUpdate.Medikament);
                                    if (this.dsMedikamentUpdateExisting.Medikament.Rows.Count > 0)
                                    {
                                        this.DBMedikamentUpdateExisting.daMedikament2.Update(this.dsMedikamentUpdateExisting.Medikament);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    using (Chilkat.Zip zip = new Chilkat.Zip())
                    {
                        if (!zip.UnlockComponent("S2ENG.CB1032020_S4CwQSty6L2t"))
                        {
                            throw new Exception("Interner Fehler: Chilkat-Zip-Komponente kann nicht lizenzisert werden: \n" + zip.LastErrorText);
                        }

                        if (!File.Exists(sFile))
                        {
                            throw new Exception("Zip-Datei " + sFile + " kann nicht gefunden werden.");
                        }

                        if (!zip.OpenZip(sFile))
                        {
                            throw new Exception("Interner Fehler: Zip-Datei " + sFile + " kann nicht geöffnet werden: \n" + zip.LastErrorText);
                        }

                        Chilkat.ZipEntry entry = zip.GetEntryByIndex(0);
                        if (!zip.LastMethodSuccess)
                        {
                            throw new Exception("Interner Fehler: Struktur der Zip-Datei " + sFile + " kann nicht gelesen werden: \n" + zip.LastErrorText);
                        }

                        xmlFile = Path.Combine(Path.GetDirectoryName(sFile), entry.FileName);
                        if (zip.Unzip(xmlFile) != 1)
                        {
                            throw new Exception("Zip-Datei " + sFile + " kann nicht als " + xmlFile + " entpackt werden: \n" + zip.LastErrorText);
                        }

                        XElement xelement = XElement.Load(Path.Combine(xmlFile, entry.FileName));

                        //sFile = @"c:\temp\oeav_ACKHIX2-L_Test_GDB.xml";
                        //XElement xelement = XElement.Load(sFile);

                        IEnumerable<XElement> xKennzeichen = xelement.Elements("Katalogdaten").Elements("Kennzeichen");
                        IEnumerable<XElement> xEinheiten = xelement.Elements("Katalogdaten").Elements("Einheiten");
                        IEnumerable<XElement> xIndikationsgruppen = xelement.Elements("Katalogdaten").Elements("Indikationsgruppen");
                        IEnumerable<XElement> xProduktdaten = xelement.Elements("Produktdaten");

                        tKennzeichen = new DataTable();
                        tKennzeichen.Columns.Add("ID", typeof(string));
                        tKennzeichen.Columns.Add("Bezeichnung", typeof(string));
                        tKennzeichen.Columns.Add("Synonym", typeof(string));
                        tKennzeichen.Columns.Add("Beschreibung", typeof(string));
                        tKennzeichen.PrimaryKey = new DataColumn[] { tKennzeichen.Columns["ID"] };

                        tEinheiten = new DataTable();
                        tEinheiten.Columns.Add("ID", typeof(string));
                        tEinheiten.Columns.Add("Bezeichnung", typeof(string));
                        tEinheiten.Columns.Add("Synonym", typeof(string));
                        tEinheiten.Columns.Add("Beschreibung", typeof(string));
                        tEinheiten.PrimaryKey = new DataColumn[] { tEinheiten.Columns["ID"] };

                        using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                        {
                            var PEH = (from al in db.AuswahlListe
                                       where al.IDAuswahlListeGruppe == "PEH"
                                       select al);

                            foreach (var a in PEH)
                            {
                                tEinheiten.Rows.Add(a.GehörtzuGruppe, "", "", a.Bezeichnung);
                            }
                        }


                        var vKennzeichen = from kennZ in xKennzeichen.Elements("Zeichen") select kennZ;
                        foreach (var Zeichen in vKennzeichen)
                        {
                            tKennzeichen.Rows.Add(Zeichen.Attribute("zeichenID").Value,
                                Zeichen.Element("Bezeichnung").Value,
                                Zeichen.Element("Synonym").Value,
                                Zeichen.Element("Beschreibung").Value);
                        }

                        //Im Veränderungsdatenbestand sind keine Packungseinheiten enthalten
                        //var vEinheiten = from einheit in xEinheiten.Elements("Einheit") select einheit;
                        //foreach (var Einheit in vEinheiten)
                        //{
                        //    tEinheiten.Rows.Add(Einheit.Attribute("einheitID").Value,
                        //        Einheit.Element("Bezeichnung").Value,
                        //        Einheit.Element("Synonym") == null ? "" : Einheit.Element("Synonym").Value,
                        //        Einheit.Element("Beschreibung").Value);
                        //}

                        var vProdukte = from produkt in xProduktdaten.Elements("Produkt") select produkt;
                        int iNew = 0;
                        DateTime dNow = DateTime.Now;
                        foreach (var prod in vProdukte)
                        {
                            IEnumerable<XElement> xArtikeldaten = prod.Elements("Artikeldaten");
                            IEnumerable<XElement> xArtikel = prod.Elements("Artikel");
                            var vArtikel = (from artikel in xArtikeldaten.Elements("Artikel") select artikel).First();

                            string Aenderungskennzeichen = prod.Attribute("aendKennzeichen").Value;                         //0 = unverändert (wird nicht verarbeitet), 1 = neu, 2 = Änderung (streichen und neu hinzufügen), 3 = Streichung
                            string Zulassungnummer = vArtikel.Attribute("artikelID").Value;

                            if (Aenderungskennzeichen == "2" || Aenderungskennzeichen == "3")
                            {
                                lRecordsToDelete.Add(Zulassungnummer);
                            }

                            if (Aenderungskennzeichen == "1" || Aenderungskennzeichen == "2")
                            {
                                dsMedikament.MedikamentRow NewRow = null;
                                NewRow = this.DBMedikamentUpdate.New(this.dsMedikamentUpdate.Medikament);

                                NewRow.EXT_ID = vArtikel.Element("PharmazentralNr").Value;
                                NewRow.BARCODE = "";
                                if (vArtikel.Element("Barcodes") != null)                                                   //Kombinationsprodukt <Produkt produktID="31917" prüfen....
                                {
                                    NewRow.BARCODE = vArtikel.Element("Barcodes").Elements("Barcode").First().Value;
                                }

                                NewRow.Zulassungsnummer = Zulassungnummer;
                                NewRow.Bezeichnung = vArtikel.Element("Kurztext").Value;
                                NewRow.LangText = "";
                                if (vArtikel.Element("Abgabe") != null && vArtikel.Element("Abgabe").Elements("Zeichen").Any())
                                {
                                    NewRow.LangText = (from kennzeichen in tKennzeichen.AsEnumerable()
                                                       where kennzeichen.Field<string>("ID") == vArtikel.Element("Abgabe").Elements("Zeichen").First().Attribute("zeichenID").Value
                                                       select kennzeichen.Field<string>("Beschreibung")).FirstOrDefault() ?? "";
                                }

                                NewRow.Einheit = "";
                                NewRow.Gruppe = "";

                                NewRow.Herrichten = (int)medHerrichten.langfristig;
                                if (generic.sEquals(NewRow.Packungseinheit, new List<object> { "Stück", "Packung(en)", "Flasche(n)" }))
                                {
                                    NewRow.Herrichten = (int)medHerrichten.langfristig;
                                }
                                else if (generic.sEquals(NewRow.Packungseinheit, new List<object> { "Guttae (Tropfen)", "Liter", "Milliliter", "Beutel", "Durchstechflasche(n)", "Ampulle(n)", "Kilogramm", "Meter", "Einheit(en)", "Internationale Einheit(en)", "Milligramm", "Mikrogramm" }))
                                {
                                    NewRow.Herrichten = (int)medHerrichten.kurzfristig;
                                }
                                else if (generic.sEquals(NewRow.Packungseinheit, new List<object> { "Sprühstoß (Sprühstöße) [Hub (Hübe)]", "Gramm", "Messlöffel" }))
                                {
                                    NewRow.Herrichten = (int)medHerrichten.nein;
                                }

                                NewRow.AerztlichevorbereitungJN = false;
                                NewRow.Verabreichungsart = (int)medVerabreichung.einzeln;
                                NewRow.Applikationsform = "";

                                NewRow.Packungsgroesse = Convert.ToDouble(vArtikel.Element("Packung").Elements("Gebinde").First().Value);
                                NewRow.Packungsanzahl = 1;

                                NewRow.Packungseinheit = (from einheit in tEinheiten.AsEnumerable()
                                                          where einheit.Field<string>("ID") == vArtikel.Element("Packung").Elements("Gebinde").First().Attribute("einheitID").Value
                                                          select einheit.Field<string>("Beschreibung")).FirstOrDefault() ?? "";

                                if (TranslateELGA)
                                {                                    
                                    bool hasValue = dictMEHService.TryGetValue(NewRow.Packungseinheit, out string value);
                                    if (hasValue)
                                    {
                                        NewRow.Packungseinheit = value;
                                    }
                                }
                                if (prod.Attribute("letzteAenderung") != null)
                                {
                                    NewRow.Gültigkeitsdatum = Convert.ToDateTime(prod.Attribute("letzteAenderung").Value);
                                }
                                else
                                {
                                    NewRow.Gültigkeitsdatum = new DateTime(dNow.Year, dNow.Month, 1).AddMonths(iMonat);
                                }
                                NewRow.Lagervorschrift = "";
                                if (prod.Elements("Lagerung") != null && prod.Elements("Lagerung").Any())
                                {
                                    NewRow.Lagervorschrift = (from lager in tKennzeichen.AsEnumerable()
                                                              where lager.Field<string>("ID") == prod.Elements("Lagerung").First().Element("Zeichen").Value
                                                              select lager.Field<string>("Beschreibung")).FirstOrDefault() ?? "";
                                }

                                NewRow.ImportiertAm = dNow;
                                NewRow.Importiert = true;
                                NewRow.Aktuell = true;

                                NewRow.Erstattungscode = "";
                                if (vArtikel.Element("Abgabe") != null && vArtikel.Element("Abgabe").Attribute("ekoBox") != null)
                                {
                                    NewRow.Erstattungscode = vArtikel.Element("Abgabe").Attribute("ekoBox").Value;
                                }

                                NewRow.Kassenzeichen = "";
                                if (vArtikel.Element("Abgabe") != null && vArtikel.Element("Abgabe").Elements("Zeichen").Any())
                                {
                                    NewRow.Kassenzeichen = (from kennzeichen in tKennzeichen.AsEnumerable()
                                                            where kennzeichen.Field<string>("ID") == vArtikel.Element("Abgabe").Elements("Zeichen").First().Attribute("zeichenID").Value
                                                            select kennzeichen.Field<string>("Synonym")).FirstOrDefault() ?? "";
                                }

                                NewRow.Lieferant = "";
                                iNew++;
                                setStatus(iNew, lbl, " Datensätze wurden eingelesen", false);
                            }
                        }

                        //Gelöschte, geänderte und unveränderte per SQL auf nicht aktiv setzen
                        StringBuilder sb = new StringBuilder();
                        sb.Append("UPDATE Medikament SET Aktuell = 0 WHERE Zulassungsnummer IN (");
                        int iDelete = 0;
                        foreach (string rDelete in lRecordsToDelete)
                        {
                            sb.Append(iDelete == 0 ? "" : ",");
                            sb.Append("'" + rDelete + "'");
                            iDelete++;
                        }
                        sb.Append(')');

                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            if (lRecordsToDelete.Count > 0)
                            {                                
                                setStatus(iDelete, lbl, " veraltete Datensätze wurden auf nicht aktiv gesetzt.", true);
                                db.Database.ExecuteSqlCommand(sb.ToString());
                                db.SaveChanges();
                            }

                            //Neue Medikamente eintragen
                            if (this.dsMedikamentUpdate.Medikament.Count > 0)
                            {
                                CountUpdated = this.dsMedikamentUpdate.Medikament.Count;
                                setStatus(this.dsMedikamentUpdate.Medikament.Count, lbl, " neue Datensätze werden in die Datenbank eingetragen. Bitte warten ...", true);
                                this.DBMedikamentUpdate.daMedikament2.Update(this.dsMedikamentUpdate.Medikament);
                            }

                            //Nicht aktive, nicht verwendete löschen
                            if (lRecordsToDelete.Count > 0)
                            {
                                CountDeactivated = lRecordsToDelete.Count;
                                setStatus(lRecordsToDelete.Count, lbl, " gestrichene, nicht verwendete Datensätze werden aus Datenbank gelöscht.", true);
                                PMDSBusiness b = new PMDSBusiness();
                                int iCounterDeletedBack = 0;
                                b.deleteNotUsedMedikamente(ref iCounterDeletedBack, db, ref lbl);
                            }
                        }
                    }
                }

                setStatus(0, lbl, "", true);
                return true;
            }
            catch (Exception ex)
            {
                CountDeactivated = 0;
                CountUpdated = 0;
                sMsg = ex.ToString();
                return false;
            }
            finally
            {
                if (tEinheiten != null) tEinheiten.Dispose();
                if (tKennzeichen != null) tKennzeichen.Dispose();

                if (File.Exists(sFile))
                {
                    File.Delete(sFile);
                }

                if (Directory.Exists(xmlFile))
                {
                    Directory.Delete(xmlFile, true);
                }
            }
        }

        public void setStatus(int i, Infragistics.Win.Misc.UltraLabel lbl, string txt, bool bForceMsg)
        {
            if (i % 100 == 0 || string.IsNullOrWhiteSpace(txt) || i < 0 || bForceMsg)
            {
                if (lbl != null)
                {
                    string sText = (string.IsNullOrWhiteSpace(txt) ? "" :  ((i >= 0 ? i.ToString() : "") + " " + txt).Trim());
                    lbl.Invoke((MethodInvoker)delegate { lbl.Text = sText; });
                }
                Application.DoEvents();
            }
        }

        public string getVar(ref VariableFile var, string line)
        {
            try
            {
                string sValue = "";
                sValue = line.Substring(var._iStart - 1, var._iEnd - var._iStart + 1);
                return sValue.Trim();
            }
            catch (Exception ex)
            {
                throw new Exception("ImportMedDaten.getVar: " + ex.ToString());
            }
        }

        public bool downloadFileFtp(ref string sFile, ref string FileName)
        {
            try
            {
                using (WebClient request = new WebClient())
                {
                    request.Credentials = new NetworkCredential(ENV.ftpUserName.Trim(), ENV.ftpPassword.Trim());

                    if (ENV.ProxyJN)
                    {
                        WebProxy wProxy = new WebProxy();
                        CredentialCache cc = new CredentialCache();
                        NetworkCredential nc = new NetworkCredential(ENV.ProxyUserName.Trim(), ENV.ProxyPassword.Trim(), ENV.ProxyDomain.Trim());
                        cc.Add(ENV.ProxyHost.Trim(), ENV.ProxyPort, ENV.ProxyAuthentication.Trim(), nc);
                        //cc.Add("http://myProxy.domain.local", 8080, "Basic", nc);
                        wProxy.Credentials = cc;
                        request.Proxy = wProxy;
                    }
                    else
                        request.Proxy = null;

                    sFile = request.DownloadString(ENV.ftpFileImportMedikamente + "//" + FileName);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ImportMedDaten.downloadFileFtp: " + ex.ToString());
            }
        }

        public bool GetXMLFromApoVerlag(out string XMLFile, out string sMsg, bool bImportGesamtDaten, int iMonat)
        {
            try
            {
                XMLFile = "";
                sMsg = "";
                using (WebClient client = new WebClient())
                {
                    string token = ENV.ApoToken;

                    if (String.IsNullOrWhiteSpace(token))
                    {
                        token = Microsoft.VisualBasic.Interaction.InputBox("Geben Sie Ihr Passwort ein", "Passworteingabe für Medikamenten-Download");
                    }
                    //string produktnummer = "165663200";     //Austria-Codex KHIX2 Modul L, Version 2.1

                    string result_allowedDLs = client.DownloadString(String.Format(@"https://services.apoverlag.at/download_svc/1.0/myalloweddownloads?tk={0}", token));

                    if (!String.IsNullOrEmpty(result_allowedDLs))
                    {
                        XmlDocument myDownloads = new XmlDocument();
                        myDownloads.LoadXml(result_allowedDLs);
                        XmlNodeList myProdukt = myDownloads.SelectNodes(@"*/*");

                        var myDL = client.DownloadData(String.Format(@"https://services.apoverlag.at/download_svc/1.0/downloadoeavdata?tk={0}&prdid={1}&date={2}&vgda={3}", token, "165663200", DateTime.Now.AddMonths(iMonat).ToString("yyMM"), bImportGesamtDaten.ToString().ToLower()));
                        string filename = client.ResponseHeaders["Content-Disposition"];
                        XMLFile = Path.Combine(ENV.ftpFileImportMedikamente, filename.Substring(filename.IndexOf('=') + 1));
                        if (!generic.CheckDirWritable(XMLFile))
                        {
                            throw new Exception("Datei " + XMLFile + " kann nicht gespeichert werden.");
                        }
                        File.WriteAllBytes(XMLFile, myDL);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                XMLFile = "";
                sMsg = "\n" + ex.Message + "\n\nSystem-Info: " + ex.StackTrace;
                return false;
            }
        }

        public string bytesToString(byte[] bytes)
        {
            try
            {
                string s = string.Empty;
                for (int i = 0; i < bytes.Length; ++i)
                    s += (char)bytes[i];
                return s;
            }
            catch (Exception ex)
            {
                throw new Exception("ImportMedDaten.bytesToString: " + ex.ToString());
            }
        }

    }
    

}
