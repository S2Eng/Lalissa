using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using S2Extensions;


namespace qs2.core.license
{

    public class doLicense
    {
        private static license.dsLicense.ApplicationRow _rApplication;
        
        public enum eApp
        {
            PMDS = 4,
            TestProduct = 5,
            ALL = 0
        }

        public static string typFileCodedSel { get; set; } = "QS2 License Files (*.lic)|*.lic";
        public static string typFileCoded { get; set; } = ".lic";
        public static string sSecretKey { get; set; } = "passwordDR0wSS@P6660juht";         //"qs2_admSecret1234License"
        public static string IV { get; set; } = "password";                                 //"qs2_adm1"
        public static license.dsLicense.ParticipantRow rParticipant { get; set; }
        public static license.dsLicense.VariablesDataTable tVariables { get; set; } = new license.dsLicense.VariablesDataTable();
        public static dsLicense _dsLicenseAct { get; set; }

        public static license.dsLicense.ApplicationRow rApplication
        {
            get
            {
                return doLicense._rApplication;
            }
            set
            {
                doLicense._rApplication = value;
                if (rApplication != null)
                {
                    ENV.IDApplicationActiveFromUser = rApplication.IDApplication.Trim();
                }
                else
                {
                    ENV.IDApplicationActiveFromUser = "";
                }
            }
        }
        
        public System.Collections.Generic.List<string> getLicensFiles()
        {
            try
            {
                System.Collections.Generic.List<string> files = new System.Collections.Generic.List<string>();
                string LicenseFileFull = Path.Combine(qs2.core.ENV.path_config,  "QS2" + license.doLicense.typFileCoded);
                if (System.IO.File.Exists(LicenseFileFull))
                {
                    files.Add(LicenseFileFull);
                }
                else
                {
                    throw new Exception("getLicensFiles: License-File '" + LicenseFileFull.Trim() + "' not exists!");
                }
                return files;

            }
            catch(Exception ex)
            {
                throw new Exception("getLicensFiles: " + ex.ToString());
            }
        }
        public void checkParticipantsInLicenseFile(dsLicense dsLicenseAct, bool checkExpired, bool WithMsgBox)
        {
            try
            {
                DateTime dNow = DateTime.Now;
                string TxtIDParticipantsexpired = "";

                if (ENV.lstIDParticipantsEncrypted.Count == 0)
                {
                    throw new Exception("checkParticipantsInLicenseFile: No Participant found! (ENV.lstIDParticipantsEncrypted.Count == 0)");
                }
                System.Collections.Generic.List<dsLicense.ParticipantRow> lstParticipantsToDelete = new System.Collections.Generic.List<dsLicense.ParticipantRow>();
                foreach(dsLicense.ParticipantRow rParticipantAct in dsLicenseAct.Participant)
                {
                    bool HasRightFromEnv = false;
                    foreach(string IDParticipantENV in ENV.lstIDParticipantsEncrypted)
                    {
                         if (rParticipantAct.IDParticipant.sEquals(IDParticipantENV) || IDParticipantENV.sEquals("all"))
                         {
                            HasRightFromEnv = true;
                            if (checkExpired)
                            {
                                if (!rParticipantAct.IsGültigBisNull())
                                {
                                    if (rParticipantAct.GültigBis.Date < dNow.Date)
                                    {
                                        TxtIDParticipantsexpired += rParticipantAct.IDParticipant.Trim() + "\r\n";
                                        HasRightFromEnv = false;
                                    }
                                }
                            }
                         }
                    }
                    if (!HasRightFromEnv)
                    {
                        lstParticipantsToDelete.Add(rParticipantAct);
                    }
                }
                foreach (dsLicense.ParticipantRow rParticipantToDelete in lstParticipantsToDelete)
                {
                    rParticipantToDelete.Delete();
                }
                dsLicenseAct.AcceptChanges();
                doLicense._dsLicenseAct = dsLicenseAct;
            }
            catch (Exception ex)
            {
                throw new Exception("checkParticipantsInLicenseFile: " + ex.ToString());
            }
        }

        public void getAppsLicensedForParticipant(license.dsLicense dsLic, string IDParticipantToCheck, bool translateAppname)
        {
            foreach (dsLicense.ParticipantRow rParticipantLicensed in doLicense._dsLicenseAct.Participant)
            {
                if (rParticipantLicensed.IDParticipant.sEquals(IDParticipantToCheck))
                {
                    dsLicense.ApplicationRow[] arrAppLicensed = (dsLicense.ApplicationRow[])doLicense._dsLicenseAct.Application.Select(doLicense._dsLicenseAct.Participant.IDParticipantColumn.ColumnName + "='" + rParticipantLicensed.IDParticipant.Trim() + "'", "");
                    foreach (dsLicense.ApplicationRow rApplicationLicensed in arrAppLicensed)
                    {
                        qs2.core.license.dsLicense.ApplicationsRow rNewApp = (qs2.core.license.dsLicense.ApplicationsRow)dsLic.Applications.NewRow();
                        rNewApp.ID = rApplicationLicensed.IDApplication;
                        string Translated = qs2.core.language.sqlLanguage.getRes(rApplicationLicensed.IDApplication);
                        if (translateAppname)
                        {
                            if (String.IsNullOrWhiteSpace(Translated))
                            {
                                Translated = rApplicationLicensed.IDApplication;
                            }
                            rNewApp.Name = Translated;
                        }
                        else
                        {
                            rNewApp.Name = rApplicationLicensed.IDApplication;
                        }
                        dsLic.Applications.Rows.Add(rNewApp);
                    }
                }
            }
        }

        public void fillTableApplicationsxy(license.dsLicense dsLic, bool OnlyLicensedProducts, bool ShowAll)
        {
            foreach (int val in Enum.GetValues(typeof(doLicense.eApp)))
            {
                string sApp = Enum.GetName(typeof(doLicense.eApp), val);
                if ( (qs2.core.ENV.adminSecure && sApp.sEquals(doLicense.eApp.TestProduct)) || !sApp.sEquals(doLicense.eApp.TestProduct) )
                {
                    bool hasRight = true;
                    if (OnlyLicensedProducts)
                    {
                        hasRight = this.HasRightForApp(sApp.Trim(), ShowAll);
                        if ( (!qs2.core.ENV.adminSecure && sApp.sEquals(doLicense.eApp.TestProduct)) || (!qs2.core.ENV.adminSecure && sApp.sEquals(doLicense.eApp.PMDS)) )
                        {
                            hasRight = false;
                        }

                        if ( !ShowAll && sApp.sEquals(doLicense.eApp.ALL.ToString()) )
                        {
                            hasRight = false;
                        }
                    }

                    if (hasRight)
                    {
                        qs2.core.license.dsLicense.ApplicationsRow rNewApp = (qs2.core.license.dsLicense.ApplicationsRow)dsLic.Applications.NewRow();
                        rNewApp.ID = sApp;
                        string Translated = qs2.core.language.sqlLanguage.getRes(sApp);
                        if (String.IsNullOrWhiteSpace(Translated))
                        {
                            Translated = sApp;
                        }
                        rNewApp.Name = Translated;
                        dsLic.Applications.Rows.Add(rNewApp);
                    }
                }
            }
        }

        public bool HasRightForApp(string ApplicationToCheck, bool ShowAll)
        {
            foreach (dsLicense.ParticipantRow rParticipantLicensed in doLicense._dsLicenseAct.Participant)
            {
                if (ShowAll || rParticipantLicensed.IDParticipant.sEquals((qs2.core.license.doLicense.rParticipant.IDParticipant)))
                {
                    dsLicense.ApplicationRow[] arrAppLicensed = (dsLicense.ApplicationRow[])doLicense._dsLicenseAct.Application.Select(doLicense._dsLicenseAct.Participant.IDParticipantColumn.ColumnName + "='" + rParticipantLicensed.IDParticipant.Trim() + "'", "");
                    foreach (dsLicense.ApplicationRow rApplicationLicensed in arrAppLicensed)
                    {
                        if (rApplicationLicensed.IDApplication.sEquals(ApplicationToCheck))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool EncryptStringAndSaveFile(string sTextDecrypted, string sOutputFilename)
        {
            try
            {
                System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
                FileStream fsEncrypted = new FileStream(sOutputFilename, FileMode.Create, FileAccess.Write);

                TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
                DES.Key = ASCIIEncoding.ASCII.GetBytes(qs2.core.license.doLicense.sSecretKey);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(qs2.core.license.doLicense.IV);
                ICryptoTransform DES_Encrypt = DES.CreateEncryptor();
                CryptoStream cryptostream = new CryptoStream(fsEncrypted, DES_Encrypt, CryptoStreamMode.Write);

                byte[] bytearrayinput = new byte[enc.GetByteCount(sTextDecrypted)];
                bytearrayinput = enc.GetBytes(sTextDecrypted);
                cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
                cryptostream.Close();
                fsEncrypted.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("doLicense.EncryptStringAndSaveFile:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + e.ToString());
            }

        }


        public bool SaveAndEncryptFile(string sInputFilename, string sOutputFilename )
        {
            try
            {
                FileStream fsInput = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);

                FileStream fsEncrypted = new FileStream(sOutputFilename, FileMode.Create, FileAccess.Write);

                TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
                DES.Key = ASCIIEncoding.ASCII.GetBytes(qs2.core.license.doLicense.sSecretKey);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(qs2.core.license.doLicense.IV);
                ICryptoTransform DES_Encrypt = DES.CreateEncryptor();
                CryptoStream cryptostream = new CryptoStream(fsEncrypted, DES_Encrypt, CryptoStreamMode.Write);

                byte[] bytearrayinput = new byte[fsInput.Length];
                fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
                cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
                cryptostream.Close();
                fsInput.Close();
                fsEncrypted.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("doLicense.SaveAndEncryptFile:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + e.ToString());
            }
        }

        public string  OpenFileAndDecrypt(String FileName)
        {
            try
            {
                byte[] Key = ASCIIEncoding.ASCII.GetBytes(qs2.core.license.doLicense.sSecretKey);
                byte[] IV = ASCIIEncoding.ASCII.GetBytes(qs2.core.license.doLicense.IV);
                //FileStream fStream = File.Open(FileName, FileMode.Open  );    //Standard ohne weitere Angaben = Lelsen und Schreiben -> daher benötigt man Schreibrechte.
                FileStream fStream = File.OpenRead(FileName);   //osxy 140522- das öffnet das File nur zum Lesen und shared. Äquvivalent = FileStream fStreamx = File.OpenRead(FileName, FileMode.Open, FileAccess.Read, FileShare.Read);  

                // Create a CryptoStream using the FileStream and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(fStream, new TripleDESCryptoServiceProvider().CreateDecryptor(Key, IV), CryptoStreamMode.Read);

                StreamReader sReader = new StreamReader(cStream);
                string val = sReader.ReadToEnd();

                sReader.Close();
                cStream.Close();
                fStream.Close();

                return val;
            }
            catch (CryptographicException e)
            {
                qs2.core.generic.getExep(e.ToString(), e.Message);
                return null;
            }
            catch ( Exception e)
            {
                throw new Exception("doLicense.OpenFileAndDecrypt:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + e.ToString());
            }
        }

        public static void doLicenseAutoxyxy(string IDParticipantToSearch, string IDApplicationToSearch,
                                            ref dsLicense.ParticipantRow rPartReturn, ref dsLicense.ApplicationRow rAppReturn)
        {
            try
            {
                qs2.core.license.doLicense doLicense1 = new core.license.doLicense();
                System.Collections.Generic.List<string> files = doLicense1.getLicensFiles();

                core.license.dsLicense dsLicenseParticipant = new core.license.dsLicense();
                foreach (string LicenseFileFound in files)
                {
                    string xmlString = doLicense1.OpenFileAndDecrypt(LicenseFileFound);
                    System.IO.StringReader strReader = new System.IO.StringReader(xmlString);
                    dsLicenseParticipant.ReadXml(strReader, System.Data.XmlReadMode.ReadSchema);
                    doLicense1.checkParticipantsInLicenseFile(dsLicenseParticipant, true, true);
                    foreach (core.license.dsLicense.ParticipantRow rPart in dsLicenseParticipant.Participant)
                    {
                        if (rPart.IDParticipant.Trim().ToLower().Equals(IDParticipantToSearch.Trim().ToLower()))
                        {
                            core.license.dsLicense.ApplicationRow[] arrAppl = (core.license.dsLicense.ApplicationRow[])dsLicenseParticipant.Application.Select(dsLicenseParticipant.Application.IDParticipantColumn.ColumnName + "='" + IDParticipantToSearch.Trim() + "' and " +
                                                                                                                            dsLicenseParticipant.Application.IDApplicationColumn.ColumnName + "='" + IDApplicationToSearch.Trim() + "'", "");

                            foreach (core.license.dsLicense.ApplicationRow rApp in arrAppl)
                            {
                                if (rApp.IDApplication.Trim().ToLower().Equals(IDApplicationToSearch.Trim().ToLower()))
                                {
                                    qs2.core.license.doLicense.tVariables.Clear();
                                    core.license.dsLicense.VariablesRow[] arrVariables = (core.license.dsLicense.VariablesRow[])dsLicenseParticipant.Variables.Select(dsLicenseParticipant.Variables.IDParticipantColumn.ColumnName + "='" + IDParticipantToSearch.Trim() + "' and " +
                                                                                                dsLicenseParticipant.Variables.IDApplicationColumn.ColumnName + "='" + IDApplicationToSearch.Trim() + "'", "");

                                    foreach (qs2.core.license.dsLicense.VariablesRow rVariable in arrVariables)
                                    {
                                        qs2.core.license.dsLicense.VariablesRow rNewVar = (qs2.core.license.dsLicense.VariablesRow)qs2.core.license.doLicense.tVariables.NewRow();
                                        rNewVar.ItemArray = rVariable.ItemArray;
                                        qs2.core.license.doLicense.tVariables.Rows.Add(rNewVar);
                                    }

                                    qs2.core.license.doLicense.rParticipant = rParticipant;
                                    qs2.core.license.doLicense.rApplication = rApp;
                                    rPartReturn = rPart;
                                    rAppReturn = rApp;

                                    return;
                                }
                            }
                        }
                    }
                }

                throw new Exception("doLicense.doLicenseAuto: No Participant '" + IDParticipantToSearch.Trim() + "' and Application '" + IDApplicationToSearch.Trim() + 
                                    "' found in Licensfiles into license-folder for auto-license!");
            }
            catch(Exception ex)
            {
                throw new Exception("doLicense.doLicenseAuto:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        
        public static void selApplication(string Application, ref System.Collections.Generic.List<string> lstApplicationsLicensed,
                                            ref bool ApplicationFound)
        {
            try
            {
                qs2.core.license.doLicense.tVariables.Clear();
                foreach (dsLicense.ParticipantRow rParticipantFromLicense in doLicense._dsLicenseAct.Participant)
                {
                    if (rParticipantFromLicense.IDParticipant.Trim().ToLower().Equals(doLicense.rParticipant.IDParticipant.Trim().ToLower()))
                    {
                        string sWhereApplication = doLicense._dsLicenseAct.Application.IDParticipantColumn.ColumnName + "='" + rParticipantFromLicense.IDParticipant.Trim() + "'";
                        dsLicense.ApplicationRow[] arrApplicationsFromParticipant = (dsLicense.ApplicationRow[])doLicense._dsLicenseAct.Application.Select(sWhereApplication, "");
                        foreach (dsLicense.ApplicationRow rApplicationsFromLicense in arrApplicationsFromParticipant)
                        {
                            if (rApplicationsFromLicense.IDApplication.Trim().ToLower().Equals(Application.Trim().ToLower()))
                            {
                                qs2.core.license.doLicense.rApplication = rApplicationsFromLicense;
                                lstApplicationsLicensed.Add(rApplicationsFromLicense.IDApplication);

                                string sWhereVariables = doLicense._dsLicenseAct.Variables.IDParticipantColumn.ColumnName + "='" + rParticipantFromLicense.IDParticipant.Trim() + "' and " + doLicense._dsLicenseAct.Variables.IDApplicationColumn.ColumnName + "='" + rApplicationsFromLicense.IDApplication.Trim() + "'";
                                dsLicense.VariablesRow[] arrVariablesFromLicense = (dsLicense.VariablesRow[])doLicense._dsLicenseAct.Variables.Select(sWhereVariables, "");
                                foreach (dsLicense.VariablesRow rVariablesFromLicense in arrVariablesFromLicense)
                                {
                                    qs2.core.license.dsLicense.VariablesRow rNewVar = (qs2.core.license.dsLicense.VariablesRow)qs2.core.license.doLicense.tVariables.NewRow();
                                    rNewVar.ItemArray = rVariablesFromLicense.ItemArray;
                                    qs2.core.license.doLicense.tVariables.Rows.Add(rNewVar);
                                }

                                ApplicationFound = true;
                            }
                        }
                    }
                }

                qs2.core.license.doLicense.UpdateLicenseList();

            }
            catch (Exception ex)
            {
                throw new Exception("doLicense.selApplication:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public static void setParticipantAndApplication(ref string IDParticipant, ref string Application)
        {
            try
            {
                string licensfile = qs2.core.ENV.path_config + "\\" + "QS2.lic";

                core.license.dsLicense dsLicenseParticipant = new core.license.dsLicense();
                core.license.dsLicense dsLicenseApplication = new core.license.dsLicense();
                qs2.core.license.doLicense doLicense1 = new qs2.core.license.doLicense();
                string xmlString = doLicense1.OpenFileAndDecrypt(licensfile);
                System.IO.StringReader strReader = new System.IO.StringReader(xmlString);
                dsLicenseParticipant.ReadXml(strReader, System.Data.XmlReadMode.ReadSchema);
                doLicense1.checkParticipantsInLicenseFile(dsLicenseParticipant, true, false);
             
                qs2.core.license.doLicense.rParticipant = null;
                qs2.core.license.doLicense.rApplication = null;
                qs2.core.license.dsLicense.ParticipantRow[] arrParticipant = (qs2.core.license.dsLicense.ParticipantRow[])dsLicenseParticipant.Participant.Select(dsLicenseParticipant.Participant.IDParticipantColumn.ColumnName + "='" + IDParticipant + "'");
                qs2.core.license.doLicense.rParticipant = (qs2.core.license.dsLicense.ParticipantRow)arrParticipant[0];
                qs2.core.license.dsLicense.ApplicationRow[] rApplications = (qs2.core.license.dsLicense.ApplicationRow[])dsLicenseParticipant.Application.Select(dsLicenseParticipant.Participant.IDParticipantColumn.ColumnName + "='" + IDParticipant + "'");
                foreach (qs2.core.license.dsLicense.ApplicationRow rApplication in rApplications)
                {
                    if (rApplication.IDApplication.Trim().ToLower().Equals(Application.Trim().ToLower()))
                    {
                        qs2.core.license.doLicense.rApplication = rApplication;
                    }
                }

                if (qs2.core.license.doLicense.rParticipant == null)
                {
                    throw new Exception("main: qs2.core.license.doLicense.rParticipant=null not allowed!");
                }
                if (qs2.core.license.doLicense.rApplication == null)
                {
                    throw new Exception("main: qs2.core.license.doLicense.rApplication=null not allowed!");
                }

                System.Collections.Generic.List<string> lstApplicationsLicensed = new System.Collections.Generic.List<string>();
                bool ApplicationFound = false;
                qs2.core.license.doLicense.selApplication(Application.Trim(), ref lstApplicationsLicensed, ref ApplicationFound);
                if (!ApplicationFound)
                {
                    throw new Exception("setParticipantAndApplication: ApplicationFound '" + Application.Trim()  + "' not found in License-File!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("doLicense.setParticipantAndApplication:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public static void UpdateLicenseList()
        {
            try
            {
                foreach (qs2.core.license.dsLicense.VariablesRow licRow in qs2.core.license.doLicense.tVariables.Rows)
                {
                    foreach (qs2.core.Enums.cLicense lic in ENV.listLicenses)
                    {
                        if (licRow.VarName == lic.Name)
                        {
                            if (lic.LicenseType == qs2.core.Enums.eLicenseType.typeBool)
                            {
                                lic.bValue =    licRow.VarValue.Trim() == "1" ? true : false;
                            }
                            else if (lic.LicenseType == qs2.core.Enums.eLicenseType.typeInt)
                            {
                                lic.iValue = System.Convert.ToInt32(licRow.VarValue.Trim());
                            }
                            else if (lic.LicenseType == qs2.core.Enums.eLicenseType.typeString)
                            {
                                lic.sValue = licRow.VarValue.Trim();
                            }
                            else if (lic.LicenseType == qs2.core.Enums.eLicenseType.TypeDateTime)
                            {
                                lic.dValue = System.Convert.ToDateTime(licRow.VarValue.Trim()); //yyyy-MM-dd
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("doLicense.UpdateLicenseList:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public static bool CheckIfRigthLicense(qs2.core.Enums.eLicense eLicense)
        {
            try
            {
                foreach( qs2.core.license.dsLicense.VariablesRow rVarFoundInLicense in qs2.core.license.doLicense.tVariables)
                {
                    if (eLicense.ToString().Trim().ToLower().Equals(rVarFoundInLicense.VarName.Trim().ToLower()))
                    {
                        qs2.core.Enums.cLicense LicDefFound = doLicense.GetLicense(eLicense);
                        if (LicDefFound != null)
                        {
                            if (LicDefFound.LicenseType == Enums.eLicenseType.typeBool)
                            {
                                if (rVarFoundInLicense.VarValue.Trim().Equals(("1").Trim ()))
                                {
                                    return true;
                                }
                            }
                            else if (LicDefFound.LicenseType == Enums.eLicenseType.typeInt)
                            {
                            }
                            else if (LicDefFound.LicenseType == Enums.eLicenseType.typeInt)
                            {
                            }
                            else if (LicDefFound.LicenseType == Enums.eLicenseType.typeInt)
                            {
                            }
                        } 
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("doLicense.CheckIfRigthLicense:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public static qs2.core.Enums.cLicense GetLicense(qs2.core.Enums.eLicense eLicense)
        {
            try
            {
                foreach (qs2.core.Enums.cLicense lic in ENV.listLicenses)     //Search by license.enum (e.g. core.qs2.Enums.eLicense.USE_CONGENITAL)
                {
                    if (eLicense == lic.License)
                    {
                        return lic;
                    }
                }

                return new qs2.core.Enums.cLicense();
            }
            catch (Exception ex)
            {
                throw new Exception("doLicense.GetLicense (by Enum):" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public static qs2.core.Enums.cLicense GetLicense(string licName)        //Search by Name (e.g. USE_CONGENITAL)
        {
            try
            {
                foreach (qs2.core.Enums.cLicense lic in ENV.listLicenses)
                {
                    if (licName.Trim().ToLower() == lic.Name.Trim().ToLower())
                    {
                        return lic;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("doLicense.GetLicense (by Name):" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public static bool autoLoadParticipantAndApplication(string Application)
        {
            try
            {
                qs2.core.license.dsLicense dsParticipant = new core.license.dsLicense();
                qs2.core.license.dsLicense dsApplication = new core.license.dsLicense();
                qs2.core.license.doLicense doLicense1 = new core.license.doLicense();

                System.Collections.Generic.List<string> files = doLicense1.getLicensFiles();
                foreach (string file in files)
                {
                    dsParticipant.Clear();
                    dsApplication.Clear();
                    string xmlString = doLicense1.OpenFileAndDecrypt(file);
                    System.IO.StringReader strReader = new System.IO.StringReader(xmlString);
                    dsParticipant.ReadXml(strReader, System.Data.XmlReadMode.ReadSchema);
                    doLicense1.checkParticipantsInLicenseFile(dsParticipant, false, true);
                    
                    if (dsParticipant.Participant.Rows.Count == 1)
                    {
                        qs2.core.license.doLicense.rParticipant = (qs2.core.license.dsLicense.ParticipantRow)dsParticipant.Participant.Rows[0];
                        qs2.core.license.dsLicense.ApplicationRow[] rApplications = (qs2.core.license.dsLicense.ApplicationRow[])dsParticipant.Application.Select(dsParticipant.Participant.IDParticipantColumn.ColumnName + "='" + qs2.core.license.doLicense.rParticipant.IDParticipant + "'");
                        foreach (qs2.core.license.dsLicense.ApplicationRow rApplication in rApplications)
                        {
                            if (rApplication.IDApplication.Trim().ToLower().Equals(Application.Trim().ToLower()))
                            {
                                qs2.core.license.doLicense.rApplication = rApplication;
                                return true;
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("doLicense.loadParticipantApp: dsParticipant.Participant.Rows.Count != 1!");
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("doLicense.autoLoadParticipantAndApplication: " + ex.ToString());
            }
        }
    }
}
