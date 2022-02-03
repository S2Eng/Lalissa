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
using S2Extensions;

namespace PMDS.Global
{
    

    public class ImportMedDaten
    {
        private dsMedikament dsMedikamentUpdate = new dsMedikament();
        private DBMedikament DBMedikamentUpdate = new DBMedikament();

        private dsMedikament dsMedikamentUpdateExisting = new dsMedikament();
        private DBMedikament DBMedikamentUpdateExisting = new DBMedikament();

        private DataTable tKennzeichen, tEinheiten, tAppliationsarten, tMEH, tAPF;

        private List<string> lRecordsToDelete = new List<string>();
        private string sFile = "";
        private string xmlFile = "";

        //private dsMedikament dsMedikamentImportGesamt = new dsMedikament();
        List<string> lstImport_ExtID = new List<string>();

        //private List<object> lVorbereitenLangfristig = new List<object> { "Stück", "Packung(en)" };
        //private List<object> lVorbereitenKurzfristig = new List<object> { "Guttae (Tropfen)", "Liter", "Milliliter", "Beutel", "Flasche(n)", "Durchstechflasche(n)", "Ampulle(n)", "Meter", "Einheit(en)", "Internationale Einheit(en)", "Milligramm", "Mikrogramm" };
        //private List<object> lVorbereitenNein = new List<object> { "Sprühstoß (Sprühstöße) [Hub (Hübe)]", "Kilogramm", "Gramm", "Messlöffel" };

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

        //private Dictionary<string, string> dictMEHService = new Dictionary<string, string>()
        //                                    {
        //                                        {"Sprühstoß (Sprühstöße) [Hub (Hübe)]","Hub/Hübe"}
        //                                    };

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

                if (MedikamenteImportType.sEquals("file"))
                {

                    if (File.Exists(@"C:\temp\Medikament.txt"))     //Fürs entwickeln
                    {
                        sFile = System.IO.File.ReadAllText(@"C:\temp\Medikament.txt");
                    }
                    else
                        sFile = System.IO.File.ReadAllText(System.IO.Path.Combine(ENV.ftpFileImportMedikamente, FileName));
                }
                else if (MedikamenteImportType.sEquals("service"))
                {
                    setStatus(0, lbl, "Daten werden vom Apo-Verlag per Service heruntergeladen ....", true);
                    if (!this.GetXMLFromApoVerlag(out sFile, out string sMsgService, bImportGesamtdaten, iMonat))
                    {
                        sMsg = sMsgService;
                        return false;
                    }
                }
                else if (MedikamenteImportType.sEquals("ftp"))
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

                if (!MedikamenteImportType.sEquals("service"))
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

                                    if (rNewMedikmant.Packungseinheit.sEquals("ST") || rNewMedikmant.Packungseinheit.sEquals("Stück"))
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
                        if (!zip.UnlockComponent("S2ENGN.CB1022023_XfLzJ7t36L5K"))
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
                        //IEnumerable<XElement> xATCCodes = xelement.Elements("Katalogdaten").Elements("ATCCodes");     //Nicht im Veränderungsbestand enthalten                      
                        IEnumerable<XElement> xProduktdaten = xelement.Elements("Produktdaten");

                        string sGeltungsdatum = xelement.Elements("Ausgabe").First().Attributes("geltungsDatum").First().Value;
                        DateTime Geltungsdatum = new DateTime(Convert.ToInt32(sGeltungsdatum.Substring(0, 4)), Convert.ToInt32(sGeltungsdatum.Substring(sGeltungsdatum.Length - 2, 2)), 1);

                        LoadMEH();
                        LoadAPF();
                        ManageEinheiten(xelement);
                        ManageKennzeichen(xelement);
                        ManageDarreichungsarten(xelement);

                        var vProdukte = from produkt in xProduktdaten.Elements("Produkt") select produkt;
                        int iNew = 0;
                        DateTime dNow = DateTime.Now;
                        foreach (var prod in vProdukte)
                        {
                            IEnumerable<XElement> xArtikeldaten = prod.Elements("Artikeldaten");
                            //IEnumerable<XElement> xArtikel = prod.Elements("Artikel");
                            var vArtikeldaten = (from artikelDaten in xArtikeldaten.Elements("Artikel") select artikelDaten);

                            foreach (var vArtikel in vArtikeldaten) 
                            {
                                string Aenderungskennzeichen = vArtikel.Attribute("aendKennzeichen").Value;                         //0 = unverändert (wird nicht verarbeitet), 1 = neu, 2 = Änderung (streichen und neu hinzufügen), 3 = Streichung
                                string Zulassungnummer = vArtikel.Attribute("artikelID").Value;

                                if (Zulassungnummer == "0308005300")
                                {
                                    string x = "x";
                                }

                                if (Aenderungskennzeichen == "2" || Aenderungskennzeichen == "3")
                                {
                                    lRecordsToDelete.Add(Zulassungnummer);
                                }

                                if (Aenderungskennzeichen == "1" || Aenderungskennzeichen == "2")
                                {
                                    dsMedikament.MedikamentRow NewRow = null;
                                    NewRow = this.DBMedikamentUpdate.New(this.dsMedikamentUpdate.Medikament);

                                    NewRow.EXT_ID = vArtikel.Element("PharmazentralNr").Value;

                                    NewRow.BARCODE = vArtikel.Element("Barcodes") != null ?
                                                        vArtikel.Element("Barcodes").Elements("Barcode").First().Value :
                                                        "";

                                    NewRow.Zulassungsnummer = Zulassungnummer;
                                    NewRow.Bezeichnung = vArtikel.Element("Kurztext").Value;            

                                    if (vArtikel.Elements("Referenzartikel").Any())
                                    {
                                        NewRow.Bezeichnung += " " + vArtikel.Element("Referenzartikel").Element("Bezeichnungssuffix").Value;
                                    }

                                    NewRow.Einheit = "";
                                    NewRow.Gruppe = "";
                                    NewRow.Herrichten = (int)medHerrichten.langfristig;
                                    NewRow.AerztlichevorbereitungJN = false;
                                    NewRow.Verabreichungsart = ENV.MedVerabreichenDefault;  //(int)medVerabreichung.einzeln;

                                    XElement Applikationsarten = prod.Element("Klassifikation").Element("Applikationsarten");
                                    if (Applikationsarten != null && Applikationsarten.HasElements)
                                    {
                                        foreach (XElement element in Applikationsarten.Elements())
                                        {
                                            if (element.Name == "Applikationsart")
                                            {
                                                NewRow.Applikationsform = LookupInTable(tAppliationsarten, "ID", element.Value, "Bezeichnung");
                                                if (TranslateELGA)
                                                {
                                                    NewRow.Applikationsform = LookupInTable(tAPF, "ELGA_DisplayName", NewRow.Applikationsform, "Bezeichnung");
                                                }
                                                    break;
                                            }
                                        }
                                    }
                                    
                                    NewRow.Packungsanzahl = 1;
                                    if (vArtikel.Element("Packung").Elements("Fuellmenge").Any())
                                    {
                                        NewRow.Packungsgroesse = Convert.ToDouble(vArtikel.Element("Packung").Elements("Fuellmenge").First().Value);
                                        NewRow.Packungseinheit = LookupInTable(tEinheiten, "ID", vArtikel.Element("Packung").Elements("Fuellmenge").First().Attribute("einheitID").Value, "Beschreibung");
                                    }
                                    else if (vArtikel.Element("Packung").Elements("Gebinde").Any())
                                    {
                                        NewRow.Packungsgroesse = Convert.ToDouble(vArtikel.Element("Packung").Elements("Gebinde").First().Value);
                                        NewRow.Packungseinheit = LookupInTable(tEinheiten, "ID", vArtikel.Element("Packung").Elements("Gebinde").First().Attribute("einheitID").Value, "Beschreibung");
                                    }

                                    if (TranslateELGA)
                                    {
                                        string PEH = "";
                                        PEH = LookupInTable(tMEH, "ELGA_DisplayName", NewRow.Packungseinheit.ToLower(), "Bezeichnung");
                                        if (String.IsNullOrWhiteSpace(PEH))
                                        {
                                            PEH = LookupInTable(tMEH, "Bezeichnung", NewRow.Packungseinheit, "Bezeichnung", false);
                                        }
                                        if (!String.IsNullOrWhiteSpace(PEH))
                                        {
                                            NewRow.Packungseinheit = PEH;
                                        }
                                    }

                                    NewRow.Gültigkeitsdatum = prod.Attribute("letzteAenderung") != null ? Convert.ToDateTime(prod.Attribute("letzteAenderung").Value) : Geltungsdatum;
                                    
                                    NewRow.Kassenzeichen = "";
                                    if (vArtikel.Elements("Abgabe").Any())
                                    {
                                        if (vArtikel.Element("Abgabe").Elements("Zeichen").Any())
                                        {
                                            NewRow.Kassenzeichen = LookupInTable(tKennzeichen, "ID", vArtikel.Element("Abgabe").Elements("Zeichen").First().Attribute("zeichenID").Value, "Synonym");
                                        }
                                    }

                                    string Lagervorschrift = "";
                                    if (prod.Elements("Lagerung").Elements("Haltbarkeit").Any())
                                    {
                                        //Lagervorschrift = "";       //Daten aus Zeichen zurücksetzen
                                        Lagervorschrift += "Haltbarkeit: " + prod.Element("Lagerung").Element("Haltbarkeit").Attribute("dauerWert").Value + " ";
                                        Lagervorschrift += LookupInTable(tEinheiten, "ID", prod.Element("Lagerung").Element("Haltbarkeit").Attribute("dauerEinheit").Value, "Beschreibung") + " ";
                                    }

                                    if (prod.Elements("Lagerung").Elements("Lagerungsbedingung").Any())
                                    {
                                        Lagervorschrift += String.IsNullOrWhiteSpace(Lagervorschrift) ? "" : "\n" + "Lagerungsbedingungen: ";
                                        if (prod.Elements("Lagerung").Elements("Lagerungsbedingung").First().Attributes("tempMin").Any())
                                        {
                                            if (prod.Elements("Lagerung").Elements("Lagerungsbedingung").First().Attribute("tempMin") != null)
                                            {
                                                Lagervorschrift += "tempMin=" + prod.Elements("Lagerung").Elements("Lagerungsbedingung").First().Attribute("tempMin").Value + " ";
                                            }
                                            if (prod.Elements("Lagerung").Elements("Lagerungsbedingung").First().Attribute("tempMax") != null)
                                            {
                                                Lagervorschrift += "tempMax=" + prod.Elements("Lagerung").Elements("Lagerungsbedingung").First().Attribute("tempMax").Value + " ";
                                            }
                                            if (prod.Elements("Lagerung").Elements("Lagerungsbedingung").First().Attribute("tempEinheit") != null)
                                            {
                                                Lagervorschrift += LookupInTable(tEinheiten, "ID", prod.Elements("Lagerung").Elements("Lagerungsbedingung").First().Attribute("tempEinheit").Value, "Beschreibung");
                                            }
                                        }
                                    }
                                    NewRow.Lagervorschrift = Lagervorschrift;
                
                                    //Langtext (nur bei Modul A)
                                    string LangText = "";
                                    if (vArtikel.Elements("Langtext").Any())
                                    {
                                        LangText = vArtikel.Element("Langtext").Value;            //Modul A
                                    }

                                    if (vArtikel.Elements("Abgabe").Any() && vArtikel.Element("Abgabe").Elements("Zeichen").Any())
                                    {
                                        foreach (XElement abg in vArtikel.Element("Abgabe").Elements("Zeichen"))
                                        {
                                            LangText += String.IsNullOrWhiteSpace(LangText) ? "" : "\n" +  LookupInTable(tKennzeichen, "ID", abg.Attribute("zeichenID").Value, "BeschreibungKurz");
                                            LangText += String.IsNullOrWhiteSpace(LangText) ? "" : "\n" + abg.Value;
                                        }                                            
                                    }                                        
                                    NewRow.LangText = LangText;

                                    NewRow.ImportiertAm = dNow;
                                    NewRow.Importiert = true;
                                    NewRow.Aktuell = true;
                                    NewRow.Erstattungscode = vArtikel.Element("Abgabe") != null && vArtikel.Element("Abgabe").Attribute("ekoBox") != null ?
                                                                vArtikel.Element("Abgabe").Attribute("ekoBox").Value :
                                                                "";                                        
                                    NewRow.Lieferant = "";
                                    iNew++;
                                    setStatus(iNew, lbl, " Datensätze wurden eingelesen", false);
                                }
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
                if (tMEH != null) tMEH.Dispose();
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

        private string LookupInTable(DataTable table, string LookupIndex, string LookupValue, string returnFieldName, bool bCaseSensitive = true)
        {
            try
            {
                if (!bCaseSensitive)
                {
                    return (from row in table.AsEnumerable()
                            where row.Field<string>(LookupIndex) == LookupValue
                            select row.Field<string>(returnFieldName)).FirstOrDefault() ?? "";
                }
                else
                {
                    return (from row in table.AsEnumerable()
                            where row.Field<string>(LookupIndex).ToLower() == LookupValue.ToLower()
                            select row.Field<string>(returnFieldName)).FirstOrDefault() ?? "";
                }
            }
            catch (Exception ex)
            {
                return "";
                throw new Exception("ImportMedDaten.LookupInTable: " + ex.ToString());
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
                    //string produktnummer = "165664200";     //Austria-Codex KHIX2 Modul L + A, Version 2.1

                    string result_allowedDLs = client.DownloadString(String.Format(@"https://services.apoverlag.at/download_svc/1.0/myalloweddownloads?tk={0}", token));

                    if (!String.IsNullOrEmpty(result_allowedDLs))
                    {
                        XmlDocument myDownloads = new XmlDocument();
                        myDownloads.LoadXml(result_allowedDLs);
                        XmlNodeList myProdukt = myDownloads.SelectNodes(@"*/*");
                        //ENV.ApoKHIX = "165664900";
                        var myDL = client.DownloadData(String.Format(@"https://services.apoverlag.at/download_svc/1.0/downloadoeavdata?tk={0}&prdid={1}&date={2}&vgda={3}", token, ENV.ApoKHIX, DateTime.Now.AddMonths(iMonat).ToString("yyMM"), bImportGesamtDaten.ToString().ToLower()));
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

        //public string bytesToString(byte[] bytes)
        //{
        //    try
        //    {
        //        string s = string.Empty;
        //        for (int i = 0; i < bytes.Length; ++i)
        //            s += (char)bytes[i];
        //        return s;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("ImportMedDaten.bytesToString: " + ex.ToString());
        //    }
        //}

        private void LoadMEH()
        {
            try
            {
                //Auswahlliste Mengeneinheiten laden (für Umsetzung ELGA-Mengeneinheiten über 
                tMEH = new DataTable();
                tMEH.Columns.Add("ELGA_DisplayName", typeof(string));
                tMEH.Columns.Add("Bezeichnung", typeof(string));
                tMEH.PrimaryKey = new DataColumn[] { tMEH.Columns["ELGA_DisplayName"] };
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var MEHs = (from al in db.AuswahlListe
                                where al.IDAuswahlListeGruppe == "MEH"
                                orderby al.Reihenfolge
                                select al);

                    foreach (var MEH in MEHs)
                    {
                        tMEH.Rows.Add(MEH.ELGA_DisplayName.ToLower(),
                                      MEH.Bezeichnung);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ImportMedDaten.ManageMEH: " + ex.ToString());
            }
        }

        private void LoadAPF()
        {
            try
            {
                //Auswahlliste Mengeneinheiten laden (für Umsetzung ELGA-Mengeneinheiten über 
                tAPF = new DataTable();
                tAPF.Columns.Add("ELGA_DisplayName", typeof(string));
                tAPF.Columns.Add("Bezeichnung", typeof(string));
                tAPF.PrimaryKey = new DataColumn[] { tAPF.Columns["ELGA_DiplayName"] };
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var APFs = (from al in db.AuswahlListe
                                where al.IDAuswahlListeGruppe == "APF"
                                orderby al.Reihenfolge
                                select al);

                    foreach (var APF in APFs)
                    {
                        tAPF.Rows.Add(APF.ELGA_DisplayName.ToLower(),
                                      APF.Bezeichnung);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ImportMedDaten.ManageMEH: " + ex.ToString());
            }
        }

        private void ManageEinheiten(XElement xelement )
        {
            //Achtung: tBezeichnung = Auswahlliste.Beschreibung
            //Achtung: tBeschriebung = Auswahlliste.Bezeichnung
            try
            {
                IEnumerable<XElement> xEinheiten = xelement.Elements("Katalogdaten").Elements("Einheiten");
                tEinheiten = new DataTable();
                tEinheiten.Columns.Add("ID", typeof(string));                                     //AEH->GehörtZuGruppe
                tEinheiten.Columns.Add("Bezeichnung", typeof(string));                            //AEH->Beschreibung!!!!!!
                tEinheiten.Columns.Add("Synonym", typeof(string));                                //AEH->ELGA_Code
                tEinheiten.Columns.Add("Beschreibung", typeof(string));                           //AEH->Bezeichnung!!!!!
                tEinheiten.Columns.Add("Term", typeof(string));                                   //AEH->ELGA_DisplayName   
                tEinheiten.PrimaryKey = new DataColumn[] { tEinheiten.Columns["ID"] };

                //Aktuelle Werte einlesen und in interne Tabelle tEinheiten speichern
                var vEinheiten = from einheit in xEinheiten.Elements("Einheit") select einheit;
                foreach (var Einheit in vEinheiten)
                {
                    string Synonym = "";
                    if (Einheit.Elements("Synonym").Any())
                    {
                        Synonym = Einheit.Element("Synonym").Value;
                    }

                    string Bezeichnung = Einheit.Element("Bezeichnung").Value;

                    string Term = Bezeichnung;
                    if (Einheit.Elements("Zuordnungen").Elements("Term").Any())
                    {
                        Term = Einheit.Elements("Zuordnungen").First().Elements("Term").First().Value;
                    }

                    tEinheiten.Rows.Add(Einheit.Attribute("einheitID").Value,
                        Bezeichnung,
                        Synonym,
                        Einheit.Element("Beschreibung").Value,
                        Term);
                }

                //Mit aktueller Auswahlliste AEH abgleichen
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var AEHs = (from al in db.AuswahlListe
                                where al.IDAuswahlListeGruppe == "AEH"
                                orderby al.Reihenfolge
                                select al);

                    int iReihenfolge = 0;
                    if (AEHs.Any())
                    {
                        iReihenfolge = (int)(from x in AEHs orderby x.Reihenfolge descending select x.Reihenfolge).FirstOrDefault();
                    }

                    //Neue Kennzeichen aus Apo-Import -> Auswahlliste übertragen
                    string sqlCmd = "";
                    foreach (var einheit in tEinheiten.AsEnumerable())
                    {
                        string ID = einheit.Field<string>("ID");

                        if ((from ap in AEHs
                             where ap.GehörtzuGruppe == ID
                             select ap).Any())                                                      //Schon enthalten -> Update
                        {
                            sqlCmd += "UPDATE Auswahlliste SET Bezeichnung = '{0}', ELGA_Code = '{1}', Beschreibung = '{2}', ELGA_DisplayName = '{3}' ";
                            sqlCmd += "WHERE IDAuswahllisteGruppe = 'AEH' AND GehörtZuGruppe = '{4}'\n";

                            sqlCmd = String.Format(sqlCmd,
                                                einheit.Field<string>("Beschreibung").Replace("'", "").PadRight(255, ' ').Substring(0,255).Trim(),
                                                einheit.Field<string>("Synonym"),
                                                einheit.Field<string>("Bezeichnung"),
                                                einheit.Field<string>("Term").Replace("'", ""),
                                                einheit.Field<string>("ID")
                                                );
                        }
                        else                                                                            //Insert
                        {
                            iReihenfolge++;
                            sqlCmd += "INSERT INTO Auswahlliste (ID, IDAuswahllisteGruppe, Reihenfolge, Bezeichnung, IstGruppe, GehörtzuGruppe, Hierarche, Beschreibung, Unterdruecken, ELGA_ID, ELGA_Code, ELGA_CodeSystem, ELGA_Displayname, ELGA_Version) ";
                            sqlCmd += "SELECT '{0}', 'AEH', {1}, '{2}', 0, '{3}', 0, '{4}', 0, 0, '{5}', '', '{6}', ''\n";

                            sqlCmd = String.Format(sqlCmd,
                                    "00000000-0000-0000-0051-" + iReihenfolge.ToString().PadLeft(12, '0'),                                  //ID {0}
                                    iReihenfolge,                                                                                           //Reichenfolge {1}
                                    einheit.Field<string>("Beschreibung").Replace("'", "").PadRight(255, ' ').Substring(0, 255).Trim(),     //Beschreibung {2}
                                    einheit.Field<string>("ID"),                                                                            //GehörtZuGruppe {3}
                                    einheit.Field<string>("Bezeichnung"),                                                                   //Bezeichnung {4}
                                    einheit.Field<string>("Synonym"),                                                                       //ELGA_Code {5}
                                    einheit.Field<string>("Term").Replace("'", "")                                                          //ELGA_DisplayName {6}
                                    );
                        }
                    }

                    if (!String.IsNullOrWhiteSpace(sqlCmd))
                    {
                        db.Database.ExecuteSqlCommand(sqlCmd);
                        db.SaveChanges();
                    }

                    //interne Einheitentabelle aus PMDS-Auswahlliste aktualisieren
                    tEinheiten.Clear();
                    foreach (var einheit in AEHs)
                    {
                        tEinheiten.Rows.Add(einheit.GehörtzuGruppe,
                                                einheit.Beschreibung,
                                                einheit.ELGA_Code,
                                                einheit.Bezeichnung,
                                                einheit.ELGA_DisplayName);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ImportMedDaten.ManageMengeneinheiten: " + ex.ToString());
            }
        }

        private void ManageDarreichungsarten(XElement xelement)
        {
            try
            {
                IEnumerable<XElement> xApplikationsarten = xelement.Elements("Katalogdaten").Elements("Applikationsarten");
                tAppliationsarten = new DataTable();
                tAppliationsarten.Columns.Add("ID", typeof(string));                                     //GehörtZuGruppe  : XML Applikationsarten->Appliktionsart.appCode
                tAppliationsarten.Columns.Add("Bezeichnung", typeof(string));                            //Bezeichnung     : XML Applikationsarten->Appliktionsart->Zuordnungen->Term  
                tAppliationsarten.PrimaryKey = new DataColumn[] { tAppliationsarten.Columns["ID"] };

                //Aktuelle Werte einlesen und in interne Tabelle tDarreichungsarten speichern
                var vAppliationsarten = from applikationsart in xApplikationsarten.Elements("Applikationsart") select applikationsart;
                foreach (var Applikationsart in vAppliationsarten)
                {
                    if (Applikationsart.Attribute("appNiveau").Value == "5")
                    {
                        string Bezeichnung = "";
                        if (Applikationsart.Elements("Zuordnungen").Any())
                        {
                            Bezeichnung = Applikationsart.Elements("Zuordnungen").First().Elements("Term").First().Value;
                        }
                        else
                        {
                            Bezeichnung = Applikationsart.Element("Methode").Value.ToLower();
                        }

                        tAppliationsarten.Rows.Add(Applikationsart.Attribute("appCode").Value,
                            Bezeichnung
                            );
                    }
                }

                //Mit aktueller Auswahlliste AEH abgleichen
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var AAFs = (from al in db.AuswahlListe
                                where al.IDAuswahlListeGruppe == "AAF"
                                orderby al.Reihenfolge
                                select al);

                    int iReihenfolge = 0;
                    if (AAFs.Any())
                    {
                        iReihenfolge = (int)(from x in AAFs orderby x.Reihenfolge descending select x.Reihenfolge).FirstOrDefault();
                    }

                    //Neue Kennzeichen aus Apo-Import -> Auswahlliste übertragen
                    string sqlCmd = "";
                    foreach (var applikationsart in tAppliationsarten.AsEnumerable())
                    {
                        string ID = applikationsart.Field<string>("ID");

                        if ((from ap in AAFs
                             where ap.GehörtzuGruppe == ID
                             select ap).Any())                                                      //Schon enthalten -> Update
                        {
                            sqlCmd += "UPDATE Auswahlliste SET Bezeichnung = '{0}' ";
                            sqlCmd += "WHERE IDAuswahllisteGruppe = 'AAF' AND GehörtZuGruppe = '{1}'\n";

                            sqlCmd = String.Format(sqlCmd,
                                                applikationsart.Field<string>("Bezeichnung"),
                                                applikationsart.Field<string>("ID")
                                                );
                        }
                        else                                                                            //Insert
                        {
                            iReihenfolge++;
                            sqlCmd += "INSERT INTO Auswahlliste (ID, IDAuswahllisteGruppe, Reihenfolge, Bezeichnung, IstGruppe, GehörtzuGruppe, Hierarche, Beschreibung, Unterdruecken, ELGA_ID, ELGA_Code, ELGA_CodeSystem, ELGA_Displayname, ELGA_Version) ";
                            sqlCmd += "SELECT '{0}', 'AAF', {1}, '{2}', 0, '{3}', 0, '', 0, 0, '', '', '', ''\n";

                            sqlCmd = String.Format(sqlCmd,
                                    "00000000-0000-0000-0049-" + iReihenfolge.ToString().PadLeft(12, '0'),  //ID {0}
                                    iReihenfolge,                                                           //Reichenfolge {1}
                                    applikationsart.Field<string>("Bezeichnung"),                           //Beschreibung {2}
                                    applikationsart.Field<string>("ID")                                     //GehörtZuGruppe {3}
                                    );
                        }
                    }

                    if (!String.IsNullOrWhiteSpace(sqlCmd))
                    {
                        db.Database.ExecuteSqlCommand(sqlCmd);
                        db.SaveChanges();
                    }

                    //interne Einheitentabelle aus PMDS-Auswahlliste aktualisieren
                    tAppliationsarten.Clear();
                    foreach (var einheit in AAFs)
                    {
                        tAppliationsarten.Rows.Add(einheit.GehörtzuGruppe,
                                                einheit.Bezeichnung);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ImportMedDaten.ManageMengeneinheiten: " + ex.ToString());
            }
        }

        private void ManageKennzeichen(XElement xelement)
        {
            try
            {
                IEnumerable<XElement> xKennzeichen = xelement.Elements("Katalogdaten").Elements("Kennzeichen");
                //------------------- Kennzeichen ------------------
                tKennzeichen = new DataTable();                                                     //Feld in Auswahl-Tabelle
                tKennzeichen.Columns.Add("ID", typeof(string));                                     //APO->GehörtZuGruppe
                tKennzeichen.Columns.Add("Bezeichnung", typeof(string));                            //APO->Bezeichnung
                tKennzeichen.Columns.Add("Synonym", typeof(string));                                //APO->ELGA_Code
                tKennzeichen.Columns.Add("BeschreibungKurz", typeof(string));                       //APO->Beschreibung
                tKennzeichen.Columns.Add("zeichenKategorie", typeof(string));                       //APO->Hierarchie    (int)!
                tKennzeichen.PrimaryKey = new DataColumn[] { tKennzeichen.Columns["ID"] };

                //Aktuelle Werte einlesen und in interne Tabelle tKennzeichen speichern
                var vKennzeichen = from kennZ in xKennzeichen.Elements("Zeichen") select kennZ;
                foreach (var Zeichen in vKennzeichen)
                {
                    tKennzeichen.Rows.Add(Zeichen.Attribute("zeichenID").Value,
                        Zeichen.Element("Bezeichnung").Value,
                        Zeichen.Element("Synonym").Value,
                        Zeichen.Element("BeschreibungKurz").Value,
                        Zeichen.Attribute("zeichenKategorie").Value);
                }

                //Mit aktueller Auswahlliste APO abgleichen
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var APOs = (from al in db.AuswahlListe
                                where al.IDAuswahlListeGruppe == "APO"
                                orderby al.Reihenfolge
                                select al);

                    int iReihenfolge = 0;
                    if (APOs.Any())
                    {
                        iReihenfolge = (int)(from x in APOs orderby x.Reihenfolge descending select x.Reihenfolge).FirstOrDefault();
                    }

                    //Neue Kennzeichen aus Apo-Import -> Auswahlliste übertragen
                    string sqlCmd = "";
                    foreach (var kennz in tKennzeichen.AsEnumerable())
                    {
                        string ID = kennz.Field<string>("ID");

                        if ((from ap in APOs
                             where ap.GehörtzuGruppe == ID
                             select ap).Any())                                                      //Schon enthalten -> Update
                        {
                            sqlCmd += "UPDATE Auswahlliste SET Bezeichnung = '{0}', ELGA_Code = '{1}', Beschreibung = '{2}', Hierarche = {3} ";
                            sqlCmd += "WHERE IDAuswahllisteGruppe = 'APO' AND GehörtZuGruppe = '{4}'\n";

                            sqlCmd = String.Format(sqlCmd,
                                                kennz.Field<string>("Bezeichnung"),
                                                kennz.Field<string>("Synonym"),
                                                kennz.Field<string>("BeschreibungKurz").Replace("'", ""),
                                                Convert.ToInt32(kennz.Field<string>("zeichenKategorie")),
                                                kennz.Field<string>("ID")
                                                );
                        }
                        else                                                                            //Insert
                        {
                            iReihenfolge++;
                            sqlCmd += "INSERT INTO Auswahlliste (ID, IDAuswahllisteGruppe, Reihenfolge, Bezeichnung, IstGruppe, GehörtzuGruppe, Hierarche, Beschreibung, Unterdruecken, ELGA_ID, ELGA_Code, ELGA_CodeSystem, ELGA_Displayname, ELGA_Version) ";
                            sqlCmd += "SELECT '{0}', 'APO', {1}, '{2}', 0, '{3}', {4}, '{5}', 0, 0, '{6}', '', '', ''";

                            sqlCmd = String.Format(sqlCmd,
                                    "00000000-0000-0000-0050-" + iReihenfolge.ToString().PadLeft(12, '0'),
                                    iReihenfolge,
                                    kennz.Field<string>("Bezeichnung"),
                                    kennz.Field<string>("ID"),
                                    Convert.ToInt32(kennz.Field<string>("zeichenKategorie")),
                                    kennz.Field<string>("BeschreibungKurz").Replace("'", ""),
                                    kennz.Field<string>("Synonym")
                                    );
                        }
                    }

                    if (!String.IsNullOrWhiteSpace(sqlCmd))
                    {
                        db.Database.ExecuteSqlCommand(sqlCmd);
                        db.SaveChanges();
                    }

                    //interne Kennzeichentabelle aktualisieren
                    tKennzeichen.Clear();
                    foreach (var apo in APOs)
                    {
                        tKennzeichen.Rows.Add(apo.GehörtzuGruppe,
                                                apo.Bezeichnung,
                                                apo.ELGA_Code,
                                                apo.Beschreibung,
                                                apo.Hierarche.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                string x = "";
                return;
                throw new Exception("ImportMedDaten.ManageKennzeichen: " + ex.ToString());
            }
        }

    }
}
