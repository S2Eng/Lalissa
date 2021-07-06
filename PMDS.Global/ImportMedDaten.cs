using System;
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

namespace PMDS.Global
{
    

    public class ImportMedDaten
    {
        public dsMedikament dsMedikamentUpdate = new dsMedikament();
        public DBMedikament DBMedikamentUpdate = new DBMedikament();

        public dsMedikament dsMedikamentUpdateExisting = new dsMedikament();
        public DBMedikament DBMedikamentUpdateExisting = new DBMedikament();

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

        public class VariablesFile
        {
            public VariableFile EXT_ID = new VariableFile(2, 8);
            public VariableFile Zulassungsnummer = new VariableFile(9, 18);
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

        public bool run(bool TranslateELGA, ref Infragistics.Win.Misc.UltraLabel lbl, ref DateTime datStart, ref DateTime datEnd, out int CountUpdated, out int CountDeactivated, 
                            ref string FileName, ref string FromNetworkDrive)
        {
            try
            { 
            
                this.DBMedikamentUpdate.initControl();
                this.dsMedikamentUpdate.Clear();
                this.DBMedikamentUpdate.getMedikament(System.Guid.NewGuid(), this.dsMedikamentUpdate, DBMedikament.eTypeSelMedikament.ID, "", "");

                this.DBMedikamentUpdateExisting.initControl();
                this.dsMedikamentUpdateExisting.Clear();
                this.DBMedikamentUpdateExisting.getMedikament(System.Guid.NewGuid(), this.dsMedikamentUpdateExisting, DBMedikament.eTypeSelMedikament.ID, "", "");

                datStart = DateTime.Now;
                string sFile = "";
                if (generic.sEquals(FromNetworkDrive,"file"))
                {
                    sFile = System.IO.File.ReadAllText(System.IO.Path.Combine( ENV.ftpFileImportMedikamente, FileName));
                }
                else
                {
                    if (!this.downloadFileFtp(ref sFile, ref FileName))
                    {
                        throw new Exception("ImportMedDaten.run: this.downloadFileFtp=false");
                    }
                }

                //sFile = System.IO.File.ReadAllText("C:\\TEMP\\APGDA.001");
                string[] aImport = sFile.Split(new char[] { '\n' });
                int lines = aImport.Count();
                
                CountUpdated = 0;
                CountDeactivated = 0;
                int LineNr = 0;

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

                                rNewMedikmant.ImportiertAm = datStart;
                                rNewMedikmant.Importiert = true;
                                rNewMedikmant.Aktuell = true;

                                this.DBMedikamentUpdate.daMedikament2.Update(this.dsMedikamentUpdate.Medikament);
                                if (this.dsMedikamentUpdateExisting.Medikament.Rows.Count > 0)
                                {
                                    this.DBMedikamentUpdateExisting.daMedikament2.Update(this.dsMedikamentUpdateExisting.Medikament);
                                }
                            }
                        }                        
                    }
                }

                //Leere Einträge löschen (Fehler in früherer Version beheben, wo irrtümlich leere Einträge erzeugt wurden)
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {                    
                    db.Database.ExecuteSqlCommand("DELETE FROM Medikament WHERE Bezeichnung = ''");
                    db.SaveChanges();
                }

                if (generic.sEquals(FileName, "APGDA.001"))
                {
                    //os: 30-09-2019: Bereits importierte, aber im aktuellen Katalog nicht mehr vorhandene Einträge auf inaktiv setzen
                    //für jedes Medikament (importiert = 1, Aktuell = 1) prüfen, ob das Medikament im File enthalten ist. Wenn nein -> Aktuell auf 0 setzen.
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        setStatus(-1, lbl, QS2.Desktop.ControlManagment.ControlManagment.getRes("Veraltete Datensätze werden gesucht. Dies kann eine Weile dauern..."),true);

                        var medToCheck = db.Medikament.Where(m => m.Importiert == true && m.Aktuell == true).ToList();

                        //Alle aktiven, importierten Rows, die in medToCheck sind, aber nicht im Importfile
                        var medUpdate = (from c in medToCheck
                                         where !(from o in lstImport_ExtID select o).Contains(c.EXT_ID)
                                         select c).ToList();

                        CountDeactivated += medUpdate.Count;   //Extra, damit die Anzahl der deaktivierten Rows zurückgegeben werden kann.
                        setStatus(CountDeactivated, lbl, QS2.Desktop.ControlManagment.ControlManagment.getRes("Datensätze werden deaktiviert. Dies kann eine Weile dauern..."), true);
                        medUpdate.ForEach(x => x.Aktuell = false);
                        db.SaveChanges();
                    }
                }

                setStatus(0, lbl, "", true);
                datEnd = DateTime.Now;
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ImportMedDaten.run: " + ex.ToString());
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
