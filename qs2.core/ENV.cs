using Chilkat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QS2.functions.vb;
using S2Extensions;




namespace qs2.core
{

    public class ENV
    {

        public static bool UseWatch = false;
        public static string ReferenceVersion = "";
        public static string AssemblyVersion = "";
        public static string DBVersionFromDatabase = "";
        public static string MinDBVersion = "";

        public static bool ConnectedOnDesignerDB_QS2_Dev = false;
        public static bool alwaysNewConnection = false;
        public static bool VisualStudioModus = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);

        public static Encryption Encryption1 = new Encryption();
        public static bool VSDesignerMode = false;

        public static bool SystemIsInitialized = false;
        public static bool UserHasLoggedIn = false;

        public static string UserNameFromEnvironment = "";
        public static string QS2DefaultProduct = "";

        public static string Product = "QS2";
        public static string UrlQS2Service = "";
        public static string path_rootBin = "";

        public static string path_bin = "";

        public static bool ResetControlsToDefaultValues = false;
        public static bool CheckValuesInDeactivatedChapters = false;
        public static bool ResetValuesOnCheck = false;

        public static string path_config = "";
        public static string ExeConfig = "QS2.exe.config";

        public static string path_reports = "";
        public static string path_log = "";
        public static string path_temp = "";

        public static string IDParticipant = "";
        public static bool IsHeadquarter = false;
        public static System.Collections.Generic.List<string> lstIDParticipantsEncrypted = new List<string>();

        public static System.Collections.Generic.List<string> path_AddInsDevelop = new System.Collections.Generic.List<string>();

        public static string fileConfig = "";
        public static string configFile = "";

        public static string connStr = "";
        public static System.Collections.Generic.List<string> lstConnStr = new System.Collections.Generic.List<string>();
        public static bool TrustedConnection = false;
        public static int LDAPPort = 389;
        public static bool WriteERConnectionString = false;

        public static string Server = "";
        public static string Database = "";
        public static string userDb = "";
        public static string pwdDbEncrypted = "";
        public static string pwdDbDecrypted = "";

        public static bool adminSecure = false;
        public static bool developModus = false;
        public static bool protocolAllTranslationErrors = false;
        public static string Domäne = "";
        public static string language = "";
        public static string TagForMonitoring = "";
        public static string EMailService = "ServiceCenter@s2-engineering.com";

        public static string developPath_config = "";
        public static string developConfigFile = "";

        public static string configFileDevelop = "";
        public static string developPath = "";
        public static string developApplication = "";
        public static string developParticipant = "develop";
        public static bool developSimulateControls = true;
        public static bool StaysAsExternProcess2 = true;

        public static string errorPathMsg = "Path {0} does not exist!";
        public static bool ExtendedUI = false;

        public static int ApplicationSelection = 1;
        public static string StandardFieldsQueries = "";
        public static bool ShowAllRowsQueryResult;
        public static string Encoding = "default";
        public static bool UseAppStylingDefault = true;
        public static int ColorSchema = 2;


        public static DateTime DemoExpiration = new DateTime(2020, 10, 31);
        public static DateTime NoExpiration = new DateTime(2999, 12, 31);
        public static DateTime Expired = new DateTime(1900, 01, 01);


        public static System.Collections.Generic.List<Form> lstOpendChildForms = new List<Form>();

        // 2017 new Config-Variables

        public static System.Drawing.Point LoactionMain;
        public static System.Drawing.Size LoactionSizeMain;
        public static System.Windows.Forms.Form MainForm;

        public static System.Drawing.Point LoactionStay;
        public static System.Drawing.Size LoactionSizeStay;

        public enum eTypApp
        {
            contQuerysRun = 60002,
            contReportsRun = 60003,
            contQuerysUser = 60006,
            contTexteditor = 60008,

            QS2PopUpContainerRessourcen = 60009,
            QS2PopUpContainerCriterias = 60010,
            QS2PopUpContainerSelLists = 600013,
            QS2PopUpContainerQuerysAdmin = 600014,
            QS2PopUpContainerSysDatabase = 60015,
            QS2PopUpContainerLayouts = 600017,
        }
        public enum ePath
        {
            log = 60051,
            reports = 60055,
        }


        public enum eVarIni
        {
            db = 60100,
            adminSecure = 60101,
            DefaultDomain = 60104,
            language = 60105,
            developPath = 60106,
            CheckWindowsPassword = 60108,
            UseDomain = 60109,
            LDAPPort = 60123,
            developApplication = 60110,
            developSimulateControls = 60111,
            CountAutoForm = 60112,
            ExtendedUI = 60113,
            autoJoin = 60115,
            ApplicationSelection = 60116,
            StandardFieldsQueries = 60117,
            ShowAllRowsQueryResult = 60118,
            rightIsAdmin = 60119,
            developModus = 60120,
            autoLoadPatients = 60121,
            protocolAllTranslationErrors = 60122,

            monitoring = 60163,

            path_config = 60140,
            EMailService = 60146,
            LogPath = 60147,

            autoLogIn = 60160,
            autoLogInUser = 60161,
            autoLogInPwd = 60162,
            UrlQS2Service = 60166,

            ButtProcGrpWidth = 60266,
            ButtChapterHeigth = 60267,
            ButtProcGrpImageSizeWidth = 60268,
            ButtProcGrpImageSizeHeigth = 60269,

            ViewUserDefined = 60270,
            EasyFunctions = 60271,

            NoQS2LicenceNecessary = 60272,
            XMonthDeleteStaysStartUp = 60273,
            DeletePatientsNoStayStartUp = 60274,

            AutoNumberPatients = 60275,
            AutoNumberStays = 60276,

            developPath_config = 60277,
            developConfigFile = 60278,

            ShowTooltips = 60279,
            TypeSetDefaultDBValue = 60280,

            IDParticipant = 60282,
            IgnoreRoles = 60283,
            DefaultApplicationThread = 60284,
            UseStartupArgs = 60285,
            WriteERConnectionString = 60288,
            LockAfterMinutesInactivity = 60289,
            ResetControlsToDefaultValues = 60290,
            CheckValuesInDeactivatedChapters = 60291,
            ResetValuesOnCheck = 60292,
            dbVS = 60294,
            VisualStudioModus = 60296,
            ConnStrQTH = 60297
        }

        public enum eTypeFunction
        {
            loadManageQueryuser = 0,
        }

        public delegate void dCallFunctionMain(eTypeFunction TypeFunction, cParsCalMainFunction pars);


        public class cParsCalMainFunction
        {
        }

        public enum eTypeSetting
        {
            tString = 2,
        }

        public static bool readPathes(bool designMode, bool createPatReports, bool IsOhterLogin)
        {
            try
            {
                string strExceptionText = "readPathes: Root directory of QS2 may not be in first level of directory tree! ";
                if (!designMode)
                {
                    ENV.path_bin = System.Windows.Forms.Application.StartupPath;
                    ENV.path_rootBin = Directory.GetParent(System.Windows.Forms.Application.StartupPath).ToString();
                    if (ENV.path_rootBin == null)
                        throw new Exception(strExceptionText + System.Windows.Forms.Application.StartupPath.ToString());
                }
                else
                {
                    ENV.configFileDevelop = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + Path.DirectorySeparatorChar.ToString() + "qs2VS.config";    //Kann niemals erste Ebene sein!!
                    ENV.readConfig(ENV.configFileDevelop, designMode);

                    ENV.path_config = ENV.developPath_config;
                    ENV.configFile = ENV.developConfigFile;

                    ENV.path_bin = ENV.developPath;
                    ENV.path_rootBin = Directory.GetParent(ENV.path_bin).ToString();
                    if (ENV.path_rootBin == null)
                        throw new Exception(strExceptionText + ENV.path_bin.ToString());

                    ENV.fileConfig = Path.Combine(ENV.path_config, ENV.configFile);
                    ENV.readConfig(ENV.fileConfig, designMode);
                }

                if (!System.IO.Directory.Exists(ENV.path_config))
                    throw new Exception(string.Format(ENV.errorPathMsg, ENV.path_config));

                if (!IsOhterLogin)
                {
                    if (ENV.path_log.Trim() == "")
                        ENV.path_log = Path.Combine(ENV.path_config, ENV.ePath.log.ToString());

                    if (!System.IO.Directory.Exists(ENV.path_log))
                        System.IO.Directory.CreateDirectory(ENV.path_log);
                }

                ENV.path_temp = Path.Combine(Path.GetTempPath(), "QS2");
                if (!System.IO.Directory.Exists(ENV.path_temp))
                {
                    System.IO.Directory.CreateDirectory(ENV.path_temp);
                }

                if (!System.IO.Directory.Exists(ENV.path_temp))
                    System.IO.Directory.CreateDirectory(ENV.path_temp);

                ENV.path_reports = Path.Combine(ENV.path_bin, ENV.ePath.reports.ToString());
                if (createPatReports)
                {
                    ENV.checkPathReports(designMode);
                }

                ENV.ExeConfig = Path.Combine(ENV.path_config, ENV.ExeConfig);
                if (!System.IO.File.Exists(ENV.ExeConfig))
                    throw new Exception("readPathes: File '" + ENV.ExeConfig + "' does not exist!");

                qs2.core.language.sqlLanguage sqlLanguage1 = new qs2.core.language.sqlLanguage();
                sqlLanguage1.initControl();

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("readPathes: " + ex.ToString());
            }
        }

        public static void checkPathReports(bool designMode)
        {
            if (!System.IO.Directory.Exists(ENV.path_reports))
                System.IO.Directory.CreateDirectory(ENV.path_reports);

            foreach (int val in Enum.GetValues(typeof(license.doLicense.eApp)))
            {
                string sApp = Enum.GetName(typeof(license.doLicense.eApp), val);
                string reportPathApp = Path.Combine(ENV.path_reports,sApp);
                if (!System.IO.Directory.Exists(reportPathApp))
                    System.IO.Directory.CreateDirectory(reportPathApp);
            }
        }
        public static bool readConfig(string configFile, bool DesignMode)
        {
            try
            {
                bool dbDone = false;
                System.IO.StreamReader str = new System.IO.StreamReader(configFile);
                StringComparison sc = StringComparison.OrdinalIgnoreCase;

                while (str.Peek() >= 0)
                {
                    string line = str.ReadLine().Trim();
                    if (line.Length > 2)
                    {
                        if (!line.Substring(0, 2).Equals("//") && !line.Substring(0,1).Equals("["))
                        {
                            string[] aParam = line.Split(new char[] { '=' }, 2, StringSplitOptions.RemoveEmptyEntries);                            
                            if (aParam.Count() == 2)                            
                            {
                                string sVar = aParam[0].Trim().ToLower();
                                string sValue = aParam[1].Trim();

                                if (sVar == eVarIni.db.ToString() && !DesignMode)
                                {
                                    if (!dbDone)
                                    {
                                        ENV.connStr = sValue;
                                        dbDone = true;
                                    }
                                    ENV.lstConnStr.Add(sValue);
                                }

                                else if (sVar.Equals(eVarIni.dbVS.ToString(), sc) && DesignMode)
                                {
                                    ENV.connStr = sValue;
                                    ENV.lstConnStr.Clear();
                                }

                                else if (sVar.Equals(eVarIni.LogPath.ToString(), sc))
                                    ENV.path_log = sValue;

                                else if (sVar.Equals(eVarIni.adminSecure.ToString(), sc))
                                    ENV.adminSecure = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.developModus.ToString(), sc))
                                    ENV.developModus = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.protocolAllTranslationErrors.ToString(), sc))
                                    ENV.protocolAllTranslationErrors = GetBoolValue(sValue);

                                else if (sVar.Equals(TagForMonitoring.ToString(), sc))
                                    ENV.TagForMonitoring = sValue;

                                else if (sVar.Equals(eVarIni.DefaultDomain.ToString(), sc))
                                    ENV.Domäne = sValue;

                                else if (sVar.Equals(eVarIni.language.ToString(), sc))
                                    ENV.language = sValue;

                                else if (sVar.Equals(eVarIni.EMailService.ToString(), sc))
                                    ENV.EMailService = sValue;

                                else if (sVar.Equals(eVarIni.developPath.ToString(), sc))
                                    ENV.developPath = sValue;

                                else if (sVar.Equals(eVarIni.WriteERConnectionString.ToString(), sc))
                                    ENV.WriteERConnectionString = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.LDAPPort.ToString().Trim(), sc))
                                    ENV.LDAPPort = GetIntValue(sValue);

                                else if (sVar.Equals(eVarIni.IDParticipant.ToString(), sc))
                                {
                                    if (String.IsNullOrWhiteSpace(sValue))
                                    {
                                        throw new Exception("readConfig: ENV.IDParticipant=='' not allowed!");
                                    }
                                    ENV.IDParticipant = sValue;
                                    ENV.readParticipants();
                                }
                                else if (sVar.Equals(eVarIni.UrlQS2Service.ToString(), sc))
                                    ENV.UrlQS2Service = sValue;

                                else if (sVar.Equals(eVarIni.path_config.ToString(), sc))
                                {
                                    if (sValue == ("programdata"))
                                    {
                                        ENV.path_config = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "qs2", "config");
                                        if (!Directory.Exists(ENV.path_config))
                                            Directory.CreateDirectory(ENV.path_config);
                                    }
                                    else
                                    {
                                        ENV.path_config = sValue;
                                        if (!Directory.Exists(ENV.path_config))
                                            Directory.CreateDirectory(ENV.path_config);
                                    }
                                }

                                else if (sVar.Equals(eVarIni.developApplication.ToString(), sc))
                                    ENV.developApplication = sValue;

                                else if (sVar.Equals(eVarIni.developPath_config.ToString(), sc))
                                    ENV.developPath_config = sValue;

                                else if (sVar.Equals(eVarIni.developConfigFile.ToString(), sc))
                                    ENV.developConfigFile = sValue;

                                else if (sVar.Equals(eVarIni.developSimulateControls.ToString(), sc))
                                    ENV.developSimulateControls = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.ExtendedUI.ToString(), sc))
                                    ENV.ExtendedUI = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.ResetControlsToDefaultValues.ToString(), sc))
                                    ENV.ResetControlsToDefaultValues = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.CheckValuesInDeactivatedChapters.ToString(), sc))
                                    ENV.CheckValuesInDeactivatedChapters = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.ResetValuesOnCheck.ToString(), sc))
                                    ENV.ResetValuesOnCheck = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.ApplicationSelection.ToString(), sc))
                                    ENV.ApplicationSelection = GetIntValue(sValue);

                                else if (sVar.Equals(eVarIni.StandardFieldsQueries.ToString(), sc))
                                    ENV.StandardFieldsQueries = sValue;

                                else if (sVar.Equals(eVarIni.ShowAllRowsQueryResult.ToString(), sc))
                                    ENV.ShowAllRowsQueryResult = GetBoolValue(sValue);

                                else if (sVar.Equals("QS2DefaultProduct", sc))
                                    ENV.QS2DefaultProduct = sValue;

                                else if (sVar.Equals("Encoding", sc))
                                    ENV.Encoding = sValue.ToLower();

                                else if (sVar.Equals("ReferenceVersion", sc))
                                    ENV.ReferenceVersion = sValue;

                                else if (sVar.Equals("MinDBVersion", sc))
                                    ENV.MinDBVersion = sValue;

                                else if (sVar.Equals("UseAppStylingDefault", sc))
                                    ENV.UseAppStylingDefault = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.VisualStudioModus.ToString(), sc))
                                    ENV.VisualStudioModus = GetBoolValue(sValue);

                                else if (sVar.Equals("ColorSchema", sc))
                                {
                                    if (sValue == "1")
                                    {
                                        ENV.ColorSchema = 1;
                                    }
                                    else if (sValue == "2")
                                    {
                                        ENV.ColorSchema = 2;
                                    }
                                }
                            }
                        }
                    }
                }
                str.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("readConfig: " + ex.ToString());
            }
        }

        private static string[] SplitMultiValues(string ENVValue)
        {
            try
            {
                int iParticipants = ENV.lstIDParticipantsEncrypted.Count();
                string[] RetValue = new string[iParticipants];
                string[] Delimiters = new string[] { "};" };
                //ENVValue {Wert für 91090};{Wert für 91091}; 
                string[] Values = ENVValue.Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);

                if (iParticipants < Values.Length)  //es wurden mehr Variablen angegeben als Participants
                {
                    string val = Values[0].Replace("{", "").Replace("}", "");
                    qs2.core.generic.showMessageBoxNoTranslate("Configuration error found at " + ENVValue + ".\nUsing first value (" + val + ")", MessageBoxButtons.OK, "");
                    RetValue[0] = val;
                    return RetValue;
                }

                int i = -1;
                if (Values.Length > 1)
                {
                    foreach (string Value in Values)
                    {
                        if (Value.StartsWith("{"))
                        {
                            i++;
                            RetValue[i] = Value.Replace("{", "").Replace("}", "");
                        }
                    }
                    if (i == Values.Count() - 1)
                    {
                        return RetValue;
                    }
                    else
                    {
                        return new string[] { ENVValue };
                    }
                }
                return new string[] { ENVValue };
            }
            catch (Exception ex)
            {
                throw new Exception("SplitMultiValues: " + ex.ToString());
            }
        }

        private static bool GetBoolValue(string sValue)
        {
            try
            {
                switch (GetIntValue(sValue))
                {
                    case 0:
                        return false;
                    case 1:
                        return true;
                    default:
                        throw new Exception("ENV.GetBoolValue: not able to convert value + '" + sValue + "' to boolean.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ENV.GetBoolValue: " + ex.ToString());
            }
        }

        private static int GetIntValue(string sValue)
        {
            try
            {
                if (int.TryParse(sValue, out int val))
                    return val;
                else
                    throw new Exception("ENV.GetIntValue: not able to convert value + '" + sValue + "' to integer.");
            }
            catch (Exception ex)
            {
                throw new Exception("ENV.GetIntValue: " + ex.ToString());
            }

        }

        public static void readParticipants()
        {
            try
            {
                System.Collections.Generic.List<string> lstIDParticipantsDecrypted = new List<string>();
                lstIDParticipantsDecrypted = qs2.core.generic.readStrVariables(ENV.IDParticipant.Trim());
                foreach (string IDParticipant in lstIDParticipantsDecrypted)
                {
                    string IDParticipantDecrypted = Encryption1.StringDecrypt(IDParticipant.Trim(), Encryption.keyForEncryptingStrings);
                    if (IDParticipantDecrypted.Trim() != "")
                    {
                        ENV.lstIDParticipantsEncrypted.Add(IDParticipantDecrypted);
                    }
                }

                if (ENV.lstIDParticipantsEncrypted.Count == 0)
                {
                    throw new Exception("ENV.readParticipants: No Participant found in ENV.IDParticipant!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ENV.readParticipants:" + ex.ToString());
            }
        }

        public static void ReadConnInfoDb()
        {
            SqlConnectionStringBuilder SqlBuilder = new SqlConnectionStringBuilder(ENV.connStr);

            ENV.Server = SqlBuilder.DataSource;
            ENV.Database = SqlBuilder.InitialCatalog;
            ENV.TrustedConnection = SqlBuilder.IntegratedSecurity;

            if (SqlBuilder.IntegratedSecurity) 
                return;

            ENV.userDb = SqlBuilder.UserID;
            ENV.pwdDbEncrypted = SqlBuilder.Password;
        }

        public static void CallFunctionMain(eTypeFunction TypeFunction, cParsCalMainFunction pars)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                throw new Exception("ENV.CallFunctionMain:" + ex.ToString());
            }
        }
    }
}
