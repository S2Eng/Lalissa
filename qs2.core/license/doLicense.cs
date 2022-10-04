using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using qs2.core.language;
using S2Extensions;

namespace qs2.core.license
{
    public class doLicense
    {
        public enum eApp
        {
            PMDS = 4,
            TestProduct = 5,
            ALL = 0
        }

        //private static dsLicense.ApplicationRow _rApplication;
        public static string typFileCodedSel { get; set; } = "QS2 License Files (*.lic)|*.lic";
        public static string typFileCoded { get; set; } = ".lic";
        public static string sSecretKey { get; set; } = "passwordDR0wSS@P6660juht"; //"qs2_admSecret1234License"
        public static string IV { get; set; } = "password"; //"qs2_adm1"
        public static dsLicense.ParticipantRow rParticipant { get; set; }
        public static dsLicense.VariablesDataTable tVariables { get; set; } = new dsLicense.VariablesDataTable();
        private static dsLicense _dsLicenseAct { get; set; }

        public static dsLicense.ApplicationRow rApplication { get; set; }

        public List<string> getLicensFiles()
        {
            try
            {
                var files = new List<string>();
                var LicenseFileFull = Path.Combine(ENV.path_config, "QS2" + typFileCoded);
                if (File.Exists(LicenseFileFull))
                    files.Add(LicenseFileFull);
                else
                    throw new Exception("getLicensFiles: License-File '" + LicenseFileFull.Trim() + "' not exists!");
                return files;
            }
            catch (Exception ex)
            {
                throw new Exception("getLicensFiles: " + ex);
            }
        }

        public void checkParticipantsInLicenseFile(dsLicense dsLicenseAct, bool checkExpired, bool WithMsgBox)
        {
            try
            {
                var dNow = DateTime.Now;
                var TxtIDParticipantsexpired = "";

                if (ENV.lstIDParticipantsEncrypted.Count == 0)
                    throw new Exception(
                        "checkParticipantsInLicenseFile: No Participant found! (ENV.lstIDParticipantsEncrypted.Count == 0)");
                var lstParticipantsToDelete = new List<dsLicense.ParticipantRow>();
                foreach (var rParticipantAct in dsLicenseAct.Participant)
                {
                    var HasRightFromEnv = false;
                    foreach (var IDParticipantENV in ENV.lstIDParticipantsEncrypted)
                        if (rParticipantAct.IDParticipant.sEquals(IDParticipantENV) || IDParticipantENV.sEquals("all"))
                        {
                            HasRightFromEnv = true;
                            if (checkExpired)
                                if (!rParticipantAct.IsGültigBisNull())
                                    if (rParticipantAct.GültigBis.Date < dNow.Date)
                                    {
                                        TxtIDParticipantsexpired += rParticipantAct.IDParticipant.Trim() + "\r\n";
                                        HasRightFromEnv = false;
                                    }
                        }

                    if (!HasRightFromEnv) lstParticipantsToDelete.Add(rParticipantAct);
                }

                foreach (var rParticipantToDelete in lstParticipantsToDelete) rParticipantToDelete.Delete();
                dsLicenseAct.AcceptChanges();
                _dsLicenseAct = dsLicenseAct;
            }
            catch (Exception ex)
            {
                throw new Exception("checkParticipantsInLicenseFile: " + ex);
            }
        }

        public void getAppsLicensedForParticipant(dsLicense dsLic, string IDParticipantToCheck, bool translateAppname)
        {
            foreach (var rParticipantLicensed in _dsLicenseAct.Participant)
                if (rParticipantLicensed.IDParticipant.sEquals(IDParticipantToCheck))
                {
                    var arrAppLicensed = (dsLicense.ApplicationRow[]) _dsLicenseAct.Application.Select(
                        _dsLicenseAct.Participant.IDParticipantColumn.ColumnName + "='" +
                        rParticipantLicensed.IDParticipant.Trim() + "'", "");
                    foreach (var rApplicationLicensed in arrAppLicensed)
                    {
                        var rNewApp = (dsLicense.ApplicationsRow) dsLic.Applications.NewRow();
                        rNewApp.ID = rApplicationLicensed.IDApplication;
                        var Translated = sqlLanguage.getRes(rApplicationLicensed.IDApplication);
                        if (translateAppname)
                        {
                            if (string.IsNullOrWhiteSpace(Translated)) Translated = rApplicationLicensed.IDApplication;
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

        public void fillTableApplicationsxy(dsLicense dsLic, bool OnlyLicensedProducts, bool ShowAll)
        {
            foreach (int val in Enum.GetValues(typeof(eApp)))
            {
                var sApp = Enum.GetName(typeof(eApp), val);
                if ((ENV.adminSecure && sApp.sEquals(eApp.TestProduct)) || !sApp.sEquals(eApp.TestProduct))
                {
                    var hasRight = true;
                    if (OnlyLicensedProducts)
                    {
                        hasRight = HasRightForApp(sApp.Trim(), ShowAll);
                        if ((!ENV.adminSecure && sApp.sEquals(eApp.TestProduct)) ||
                            (!ENV.adminSecure && sApp.sEquals(eApp.PMDS))) hasRight = false;

                        if (!ShowAll && sApp.sEquals(eApp.ALL.ToString())) hasRight = false;
                    }

                    if (hasRight)
                    {
                        var rNewApp = (dsLicense.ApplicationsRow) dsLic.Applications.NewRow();
                        rNewApp.ID = sApp;
                        var Translated = sqlLanguage.getRes(sApp);
                        if (string.IsNullOrWhiteSpace(Translated)) Translated = sApp;
                        rNewApp.Name = Translated;
                        dsLic.Applications.Rows.Add(rNewApp);
                    }
                }
            }
        }

        public bool HasRightForApp(string ApplicationToCheck, bool ShowAll)
        {
            foreach (var rParticipantLicensed in _dsLicenseAct.Participant)
                if (ShowAll || rParticipantLicensed.IDParticipant.sEquals(rParticipant.IDParticipant))
                {
                    var arrAppLicensed = (dsLicense.ApplicationRow[]) _dsLicenseAct.Application.Select(
                        _dsLicenseAct.Participant.IDParticipantColumn.ColumnName + "='" +
                        rParticipantLicensed.IDParticipant.Trim() + "'", "");
                    foreach (var rApplicationLicensed in arrAppLicensed)
                        if (rApplicationLicensed.IDApplication.sEquals(ApplicationToCheck))
                            return true;
                }

            return false;
        }

        public bool EncryptStringAndSaveFile(string sTextDecrypted, string sOutputFilename)
        {
            try
            {
                var enc = new UTF8Encoding();
                var fsEncrypted = new FileStream(sOutputFilename, FileMode.Create, FileAccess.Write);

                var DES = new TripleDESCryptoServiceProvider();
                DES.Key = Encoding.ASCII.GetBytes(sSecretKey);
                DES.IV = Encoding.ASCII.GetBytes(IV);
                var DES_Encrypt = DES.CreateEncryptor();
                var cryptostream = new CryptoStream(fsEncrypted, DES_Encrypt, CryptoStreamMode.Write);

                var bytearrayinput = new byte[enc.GetByteCount(sTextDecrypted)];
                bytearrayinput = enc.GetBytes(sTextDecrypted);
                cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
                cryptostream.Close();
                fsEncrypted.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("doLicense.EncryptStringAndSaveFile:" + generic.lineBreak + generic.lineBreak + e);
            }
        }


        public bool SaveAndEncryptFile(string sInputFilename, string sOutputFilename)
        {
            try
            {
                var fsInput = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);

                var fsEncrypted = new FileStream(sOutputFilename, FileMode.Create, FileAccess.Write);

                var DES = new TripleDESCryptoServiceProvider();
                DES.Key = Encoding.ASCII.GetBytes(sSecretKey);
                DES.IV = Encoding.ASCII.GetBytes(IV);
                var DES_Encrypt = DES.CreateEncryptor();
                var cryptostream = new CryptoStream(fsEncrypted, DES_Encrypt, CryptoStreamMode.Write);

                var bytearrayinput = new byte[fsInput.Length];
                fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
                cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
                cryptostream.Close();
                fsInput.Close();
                fsEncrypted.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("doLicense.SaveAndEncryptFile:" + generic.lineBreak + generic.lineBreak + e);
            }
        }

        public string OpenFileAndDecrypt(string FileName)
        {
            try
            {
                var Key = Encoding.ASCII.GetBytes(sSecretKey);
                var IV = Encoding.ASCII.GetBytes(doLicense.IV);
                //FileStream fStream = File.Open(FileName, FileMode.Open  );    //Standard ohne weitere Angaben = Lelsen und Schreiben -> daher benötigt man Schreibrechte.
                var
                    fStream = File
                        .OpenRead(FileName); //osxy 140522- das öffnet das File nur zum Lesen und shared. Äquvivalent = FileStream fStreamx = File.OpenRead(FileName, FileMode.Open, FileAccess.Read, FileShare.Read);  

                // Create a CryptoStream using the FileStream and the passed key and initialization vector (IV).
                var cStream = new CryptoStream(fStream, new TripleDESCryptoServiceProvider().CreateDecryptor(Key, IV),
                    CryptoStreamMode.Read);

                var sReader = new StreamReader(cStream);
                var val = sReader.ReadToEnd();

                sReader.Close();
                cStream.Close();
                fStream.Close();

                return val;
            }
            catch (CryptographicException e)
            {
                generic.getExep(e.ToString(), e.Message);
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("doLicense.OpenFileAndDecrypt:" + generic.lineBreak + generic.lineBreak + e);
            }
        }

        public static void doLicenseAutoxyxy(string IDParticipantToSearch, string IDApplicationToSearch,
            ref dsLicense.ParticipantRow rPartReturn, ref dsLicense.ApplicationRow rAppReturn)
        {
            try
            {
                var doLicense1 = new doLicense();
                var files = doLicense1.getLicensFiles();

                var dsLicenseParticipant = new dsLicense();
                foreach (var LicenseFileFound in files)
                {
                    var xmlString = doLicense1.OpenFileAndDecrypt(LicenseFileFound);
                    var strReader = new StringReader(xmlString);
                    dsLicenseParticipant.ReadXml(strReader, XmlReadMode.ReadSchema);
                    doLicense1.checkParticipantsInLicenseFile(dsLicenseParticipant, true, true);
                    foreach (var rPart in dsLicenseParticipant.Participant)
                        if (rPart.IDParticipant.Trim().ToLower().Equals(IDParticipantToSearch.Trim().ToLower()))
                        {
                            var arrAppl = (dsLicense.ApplicationRow[]) dsLicenseParticipant.Application.Select(
                                dsLicenseParticipant.Application.IDParticipantColumn.ColumnName + "='" +
                                IDParticipantToSearch.Trim() + "' and " +
                                dsLicenseParticipant.Application.IDApplicationColumn.ColumnName + "='" +
                                IDApplicationToSearch.Trim() + "'", "");

                            foreach (var rApp in arrAppl)
                                if (rApp.IDApplication.Trim().ToLower().Equals(IDApplicationToSearch.Trim().ToLower()))
                                {
                                    tVariables.Clear();
                                    var arrVariables = (dsLicense.VariablesRow[]) dsLicenseParticipant.Variables.Select(
                                        dsLicenseParticipant.Variables.IDParticipantColumn.ColumnName + "='" +
                                        IDParticipantToSearch.Trim() + "' and " +
                                        dsLicenseParticipant.Variables.IDApplicationColumn.ColumnName + "='" +
                                        IDApplicationToSearch.Trim() + "'", "");

                                    foreach (var rVariable in arrVariables)
                                    {
                                        var rNewVar = (dsLicense.VariablesRow) tVariables.NewRow();
                                        rNewVar.ItemArray = rVariable.ItemArray;
                                        tVariables.Rows.Add(rNewVar);
                                    }

                                    rParticipant = rParticipant;
                                    rApplication = rApp;
                                    rPartReturn = rPart;
                                    rAppReturn = rApp;

                                    return;
                                }
                        }
                }

                throw new Exception("doLicense.doLicenseAuto: No Participant '" + IDParticipantToSearch.Trim() +
                                    "' and Application '" + IDApplicationToSearch.Trim() +
                                    "' found in Licensfiles into license-folder for auto-license!");
            }
            catch (Exception ex)
            {
                throw new Exception("doLicense.doLicenseAuto:" + generic.lineBreak + generic.lineBreak + ex);
            }
        }

        public static void selApplication(string Application, ref List<string> lstApplicationsLicensed,
            ref bool ApplicationFound)
        {
            try
            {
                tVariables.Clear();
                foreach (var rParticipantFromLicense in _dsLicenseAct.Participant)
                    if (rParticipantFromLicense.IDParticipant.Trim().ToLower()
                        .Equals(rParticipant.IDParticipant.Trim().ToLower()))
                    {
                        var sWhereApplication = _dsLicenseAct.Application.IDParticipantColumn.ColumnName + "='" +
                                                rParticipantFromLicense.IDParticipant.Trim() + "'";
                        var arrApplicationsFromParticipant =
                            (dsLicense.ApplicationRow[]) _dsLicenseAct.Application.Select(sWhereApplication, "");
                        foreach (var rApplicationsFromLicense in arrApplicationsFromParticipant)
                            if (rApplicationsFromLicense.IDApplication.Trim().ToLower()
                                .Equals(Application.Trim().ToLower()))
                            {
                                rApplication = rApplicationsFromLicense;
                                lstApplicationsLicensed.Add(rApplicationsFromLicense.IDApplication);

                                var sWhereVariables = _dsLicenseAct.Variables.IDParticipantColumn.ColumnName + "='" +
                                                      rParticipantFromLicense.IDParticipant.Trim() + "' and " +
                                                      _dsLicenseAct.Variables.IDApplicationColumn.ColumnName + "='" +
                                                      rApplicationsFromLicense.IDApplication.Trim() + "'";
                                var arrVariablesFromLicense =
                                    (dsLicense.VariablesRow[]) _dsLicenseAct.Variables.Select(sWhereVariables, "");
                                foreach (var rVariablesFromLicense in arrVariablesFromLicense)
                                {
                                    var rNewVar = (dsLicense.VariablesRow) tVariables.NewRow();
                                    rNewVar.ItemArray = rVariablesFromLicense.ItemArray;
                                    tVariables.Rows.Add(rNewVar);
                                }

                                ApplicationFound = true;
                            }
                    }

                UpdateLicenseList();
            }
            catch (Exception ex)
            {
                throw new Exception("doLicense.selApplication:" + generic.lineBreak + generic.lineBreak + ex);
            }
        }

        public static void setParticipantAndApplication(ref string IDParticipant, ref string Application)
        {
            try
            {
                var licensfile = ENV.path_config + "\\" + "QS2.lic";

                var dsLicenseParticipant = new dsLicense();
                var dsLicenseApplication = new dsLicense();
                var doLicense1 = new doLicense();
                var xmlString = doLicense1.OpenFileAndDecrypt(licensfile);
                var strReader = new StringReader(xmlString);
                dsLicenseParticipant.ReadXml(strReader, XmlReadMode.ReadSchema);
                doLicense1.checkParticipantsInLicenseFile(dsLicenseParticipant, true, false);

                rParticipant = null;
                rApplication = null;
                var arrParticipant = (dsLicense.ParticipantRow[]) dsLicenseParticipant.Participant.Select(
                    dsLicenseParticipant.Participant.IDParticipantColumn.ColumnName + "='" + IDParticipant + "'");
                rParticipant = arrParticipant[0];
                var rApplications = (dsLicense.ApplicationRow[]) dsLicenseParticipant.Application.Select(
                    dsLicenseParticipant.Participant.IDParticipantColumn.ColumnName + "='" + IDParticipant + "'");
                foreach (var rApplication in rApplications)
                    if (rApplication.IDApplication.Trim().ToLower().Equals(Application.Trim().ToLower()))
                        doLicense.rApplication = rApplication;

                if (rParticipant == null)
                    throw new Exception("main: qs2.core.license.doLicense.rParticipant=null not allowed!");
                if (rApplication == null)
                    throw new Exception("main: qs2.core.license.doLicense.rApplication=null not allowed!");

                var lstApplicationsLicensed = new List<string>();
                var ApplicationFound = false;
                selApplication(Application.Trim(), ref lstApplicationsLicensed, ref ApplicationFound);
                if (!ApplicationFound)
                    throw new Exception("setParticipantAndApplication: ApplicationFound '" + Application.Trim() +
                                        "' not found in License-File!");
            }
            catch (Exception ex)
            {
                throw new Exception("doLicense.setParticipantAndApplication:" + generic.lineBreak + generic.lineBreak +
                                    ex);
            }
        }

        public static void UpdateLicenseList()
        {
            try
            {
                foreach (dsLicense.VariablesRow licRow in tVariables.Rows)
                foreach (var lic in ENV.listLicenses)
                    if (licRow.VarName == lic.Name)
                    {
                        if (lic.LicenseType == Enums.eLicenseType.typeBool)
                            lic.bValue = licRow.VarValue.Trim() == "1" ? true : false;
                        else if (lic.LicenseType == Enums.eLicenseType.typeInt)
                            lic.iValue = Convert.ToInt32(licRow.VarValue.Trim());
                        else if (lic.LicenseType == Enums.eLicenseType.typeString)
                            lic.sValue = licRow.VarValue.Trim();
                        else if (lic.LicenseType == Enums.eLicenseType.TypeDateTime)
                            lic.dValue = Convert.ToDateTime(licRow.VarValue.Trim()); //yyyy-MM-dd
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("doLicense.UpdateLicenseList:" + generic.lineBreak + generic.lineBreak + ex);
            }
        }

        public static bool CheckIfRigthLicense(Enums.eLicense eLicense)
        {
            try
            {
                foreach (var rVarFoundInLicense in tVariables)
                    if (eLicense.ToString().Trim().ToLower().Equals(rVarFoundInLicense.VarName.Trim().ToLower()))
                    {
                        var LicDefFound = GetLicense(eLicense);
                        if (LicDefFound != null)
                        {
                            if (LicDefFound.LicenseType == Enums.eLicenseType.typeBool)
                            {
                                if (rVarFoundInLicense.VarValue.Trim().Equals("1".Trim())) return true;
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

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("doLicense.CheckIfRigthLicense:" + generic.lineBreak + generic.lineBreak + ex);
            }
        }

        public static Enums.cLicense GetLicense(Enums.eLicense eLicense)
        {
            try
            {
                foreach (var lic in
                         ENV.listLicenses) //Search by license.enum (e.g. core.qs2.Enums.eLicense.USE_CONGENITAL)
                    if (eLicense == lic.License)
                        return lic;

                return new Enums.cLicense();
            }
            catch (Exception ex)
            {
                throw new Exception("doLicense.GetLicense (by Enum):" + generic.lineBreak + generic.lineBreak + ex);
            }
        }

        public static Enums.cLicense GetLicense(string licName) //Search by Name (e.g. USE_CONGENITAL)
        {
            try
            {
                foreach (var lic in ENV.listLicenses)
                    if (licName.Trim().ToLower() == lic.Name.Trim().ToLower())
                        return lic;
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("doLicense.GetLicense (by Name):" + generic.lineBreak + generic.lineBreak + ex);
            }
        }

        public static bool autoLoadParticipantAndApplication(string Application)
        {
            try
            {
                qs2.core.license.dsLicense dsParticipant = new core.license.dsLicense();
                qs2.core.license.dsLicense dsApplication = new core.license.dsLicense();

                qs2.core.license.doLicense.rParticipant = dsParticipant.Participant.NewParticipantRow();
                rParticipant.IDParticipant = "PMDS";
                rParticipant.LicCustomer = "PMDS";

                qs2.core.license.doLicense.rApplication = dsApplication.Application.NewApplicationRow();
                rApplication.IDApplication = "PMDS";
                rApplication.IDParticipant = "ALL";

                dsLicense lic = new dsLicense();
                var r = lic.Participant.NewParticipantRow();
                r.IDParticipant = "PMDS";
                r.LicCustomer = "PMDS";
                lic.Participant.AddParticipantRow(r);
                doLicense._dsLicenseAct = lic;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("doLicense.autoLoadParticipantAndApplication: " + ex);
            }
        }
    }
}