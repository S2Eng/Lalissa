using System;
using System.Collections.Generic;
using System.Text;
using PMDS.DB.Global;
using PMDS.Data.Global;
using System.Net;
using System.IO;

using PMDS.Global.db.Patient;
using PMDS.DB;



namespace PMDS.Global
{
    

    public class ImportMedDaten
    {
        public dsMedikament dsMedikamentUpdate = new dsMedikament();
        public DBMedikament DBMedikamentUpdate = new DBMedikament();

        public dsMedikament dsMedikamentUpdateExisting = new dsMedikament();
        public DBMedikament DBMedikamentUpdateExisting = new DBMedikament();

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






        public bool run(ref DateTime datStart, ref DateTime datEnd, ref int CountUpdated, ref string FileName, ref string FromNetworkDrive)
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
                if (FromNetworkDrive.Trim().Equals(("file").Trim(), StringComparison.CurrentCultureIgnoreCase))
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

                int LineNr = 0;
                string line = null;
                System.IO.TextReader readFile = new StringReader(sFile);
                bool doWhile = true;
                while (doWhile)
                {
                    line = readFile.ReadLine();
                    LineNr += 1;
                    if (line != null)
                    {
                        if (line.Trim() != "")
                        {
                            VariablesFile vars = new VariablesFile();

                            string val_EXT_ID = this.getVar(ref vars.EXT_ID, ref line);

                            string val_Gültigkeitsdatum = this.getVar(ref vars.Gültigkeitsdatum, ref line);
                            int iYear = System.Convert.ToInt32(val_Gültigkeitsdatum.Trim().Substring(2, 2)) + 2000;
                            int iMonth = System.Convert.ToInt32(val_Gültigkeitsdatum.Trim().Substring(0, 2));
                            DateTime datGültigkeitsdatum = new DateTime(iYear, iMonth, 1);

                            if (val_EXT_ID.Trim() != "")
                            { 
                                this.dsMedikamentUpdate.Clear();
                                this.dsMedikamentUpdateExisting.Clear();
                                this.DBMedikamentUpdateExisting.getMedikament(System.Guid.Empty, this.dsMedikamentUpdateExisting, DBMedikament.eTypeSelMedikament.ExternIDOrderByGültigkeitsdatumDesc, val_EXT_ID.Trim(), "");

                                bool IsOk = false;
                                dsMedikament.MedikamentRow rNewMedikmant = null;
                                if (this.dsMedikamentUpdateExisting.Medikament.Rows.Count > 0)
                                {
                                    int iAktuellMedikmaneteFound = 0;
                                    dsMedikament.MedikamentRow rExistingMedikmant = (dsMedikament.MedikamentRow)this.dsMedikamentUpdateExisting.Medikament.Rows[0];
                                    rNewMedikmant = this.DBMedikamentUpdate.New(this.dsMedikamentUpdate.Medikament);

                                    bool GültigkeitsdatumExistsInDbForMedikament = false;
                                    dsMedikament.MedikamentRow rExistingMedLastDate = null;

                                    if (this.dsMedikamentUpdateExisting.Medikament.Rows.Count > 1)
                                    {
                                        throw new Exception("ImportMedDaten.run: this.dsMedikamentUpdateExisting.Medikament.Rows.Count > 1 for IDExtern='" + val_EXT_ID.Trim() + "'!");
                                    }

                                    dsMedikament.MedikamentRow[] arrMedExisting = (dsMedikament.MedikamentRow[])this.dsMedikamentUpdateExisting.Medikament.Select("", this.dsMedikamentUpdateExisting.Medikament.GültigkeitsdatumColumn.ColumnName + " desc ");
                                    foreach (dsMedikament.MedikamentRow rExistingMed in arrMedExisting)
                                    {
                                        if (!rExistingMed.IsGültigkeitsdatumNull())
                                        {
                                            if (rExistingMed.Gültigkeitsdatum.Day != 1)
                                            {
                                                throw new Exception("ImportMedDaten.run: rExistingMed.Gültigkeitsdatum.Day != 1 for IDExtern='" + val_EXT_ID.Trim() + "'!");
                                            }
                                            if (rExistingMed.Gültigkeitsdatum >= datGültigkeitsdatum)
                                            {
                                                GültigkeitsdatumExistsInDbForMedikament = true;
                                            }
                                        }
                                    }
                                    if (!GültigkeitsdatumExistsInDbForMedikament)
                                    {

                                        rExistingMedLastDate = (dsMedikament.MedikamentRow)arrMedExisting[0];
                                        rNewMedikmant.ItemArray = rExistingMedLastDate.ItemArray;
                                        rNewMedikmant.ID = System.Guid.NewGuid();
                                        iAktuellMedikmaneteFound += 1;

                                        foreach (dsMedikament.MedikamentRow rExistingMed in arrMedExisting)
                                        {
                                            rExistingMed.Aktuell = false;
                                        }
                                        IsOk = true;
                                    }
                                    else
                                    {
                                        IsOk = false;
                                    }
                                    
                                    //foreach (dsMedikament.MedikamentRow rExistingMed in arrMedExisting)
                                    //{
                                    //    if (rExistingMed.Aktuell)
                                    //    {
                                    //        rNewMedikmant.ItemArray = rExistingMedikmant.ItemArray;
                                    //        rNewMedikmant.ID = System.Guid.NewGuid();
                                    //        iAktuellMedikmaneteFound += 1;
                                    //    }
                                    //    rExistingMed.Aktuell = false;
                                    //}
                                    if (iAktuellMedikmaneteFound != 1)
                                    {
                                        //throw new Exception("ImportMedDaten.run: iAktuellMedikmaneteFound > 1 for IDExtern='" + val_EXT_ID.Trim() + "'!");
                                    }
                                }
                                else if (this.dsMedikamentUpdateExisting.Medikament.Rows.Count == 0)
                                {
                                    rNewMedikmant = this.DBMedikamentUpdate.New(this.dsMedikamentUpdate.Medikament);
                                    IsOk = true;
                                }
                                //else if (this.dsMedikamentWork.Medikament.Rows.Count > 1)
                                //{
                                //    throw new Exception("ImportMedDaten.run: this.dsMedikamentUpdate.Medikament.Rows.Count > 1 for IDExtern='" + val_EXT_ID.Trim() + "'!");
                                //}

                                string val_Kassenzeichen = this.getVar(ref vars.Kassenzeichen, ref line).Trim();   
                                if (val_Kassenzeichen.Trim() == "VN" || val_Kassenzeichen.Trim() == "VNW" || val_Kassenzeichen.Trim() == "VT" ||
                                    val_Kassenzeichen.Trim() == "VTW")  // ==> Veterinärprodukt
                                {
                                    IsOk = false;
                                }
                                string val_Druckunterdrückung = this.getVar(ref vars.Druckunterdrückung, ref line).Trim();
                                if (val_Druckunterdrückung.Trim() == "D")
                                {
                                    IsOk = false;
                                }
                                
                                if (IsOk)
                                {
                                    rNewMedikmant.EXT_ID = val_EXT_ID.Trim();
                                    rNewMedikmant.Kassenzeichen = val_Kassenzeichen;

                                    string val_Zulassungsnummer = this.getVar(ref vars.Zulassungsnummer, ref line);
                                    rNewMedikmant.Zulassungsnummer = val_Zulassungsnummer.Trim();

                                    rNewMedikmant.Gültigkeitsdatum = datGültigkeitsdatum.Date;

                                    string val_Lagervorschrift = this.getVar(ref vars.Lagervorschrift, ref line);
                                    rNewMedikmant.Lagervorschrift = val_Lagervorschrift.Trim();

                                    string val_Bezeichnung = this.getVar(ref vars.Bezeichnung, ref line);
                                    rNewMedikmant.Bezeichnung = val_Bezeichnung.Trim();

                                    string val_Packungsgroesse = this.getVar(ref vars.Packungsgroesse, ref line);
                                    rNewMedikmant.Packungsgroesse = System.Convert.ToDouble(val_Packungsgroesse.Trim());

                                    string val_Packungseinheit = this.getVar(ref vars.Packungseinheit, ref line);
                                    rNewMedikmant.Packungseinheit = val_Packungseinheit.Trim();

                                    if (rNewMedikmant.Packungseinheit.Equals("ST", StringComparison.CurrentCultureIgnoreCase))
                                        rNewMedikmant.Herrichten = (int)medHerrichten.langfristig;               

                                    string val_Erstattungscode = this.getVar(ref vars.Erstattungscode, ref line);
                                    rNewMedikmant.Erstattungscode = val_Erstattungscode.Trim();
                                    if (rNewMedikmant.Erstattungscode.Trim() != "")
                                    {
                                        string xy = "";
                                    }

                                    string val_LastVar = this.getVar(ref vars.LastVar, ref line);

                                    rNewMedikmant.ImportiertAm = datStart;
                                    rNewMedikmant.Importiert = true;
                                    rNewMedikmant.Aktuell = true;

                                    this.DBMedikamentUpdate.daMedikament2.Update(this.dsMedikamentUpdate.Medikament);
                                    if (this.dsMedikamentUpdateExisting.Medikament.Rows.Count > 0)
                                    {
                                        this.DBMedikamentUpdateExisting.daMedikament2.Update(this.dsMedikamentUpdateExisting.Medikament);
                                    }

                                    CountUpdated += 1;
                                }
                            }
                        }
                        else
                        {
                            doWhile = false;
                        }
                    }
                    else
                    {
                        doWhile = false;
                    }
                }

                readFile.Close();
                readFile = null;
                datEnd = DateTime.Now;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ImportMedDaten.run: " + ex.ToString());
            }
        }

        public string getVar(ref VariableFile var, ref string line)
        {
            try
            {
                string sValue = "";
                //if (line.Length >= var._iEnd - 1)
                //{
                    sValue = line.Substring(var._iStart - 1, var._iEnd - var._iStart + 1);
                //}

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
                WebClient request = new WebClient();
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

                //byte[] fileData = request.DownloadData(this.ftpFilePath);
                sFile = request.DownloadString(ENV.ftpFileImportMedikamente + "//" + FileName);

                //FileStream file = File.Create(this.inputFilePath);
                //file.Write(fileData, 0, fileData.Length);
                //file.Close();
                //sFile = this.bytesToString(fileData);

                return true;
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
