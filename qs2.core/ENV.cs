using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QS2.functions.vb;

namespace qs2.core
{
    public class ENV
    {
        private static string _errorPathMsg = "Path {0} does not exist!";
        private static Encryption _encryption1 = new Encryption();
        private static string _pathRootBin = "";
        private static string _pathBin = "";
        private static string _exeConfig = "QS2.exe.config";
        private static string _idParticipant = "";
        private static List<string> _lstIdParticipantsEncrypted = new List<string>();
        private static List<string> _lstConnStr = new List<string>();
        private static string _tagForMonitoring = "";
        private static string _developPathConfig = "";
        private static string _developConfigFile = "";
        private static string _configFileDevelop = "";
        private static string _developPath = "";

        public static bool UseWatch = false;
        public static string ReferenceVersion = "";
        public static string AssemblyVersion = "";
        public static string DBVersionFromDatabase = "";
        public static string MinDBVersion = "";
        public static bool ConnectedOnDesignerDB_QS2_Dev = false;
        public static bool SystemIsInitialized = false;
        public static string PathConfig = "";
        public static string PathReports = "";
        public static string PathLog = "";
        public static string PathTemp = "";
        public static bool IsHeadquarter = false;
        public static string fileConfig = "";
        public static string configFile = "";
        public static string connStr = "";
        public static bool TrustedConnection;
        public static int LDAPPort = 389;
        public static bool WriteERConnectionString;
        public static string Server = "";
        public static string Database = "";
        public static string UserDb = "";
        public static string PwdDbEncrypted = "";
        public static string PwdDbDecrypted = "";
        public static bool AdminSecure;
        public static bool protocolAllTranslationErrors;
        public static string Domain = "";
        public static string Language = "";
        public static string EMailService = "ServiceCenter@s2-engineering.com";
        public static string developParticipant = "develop";
        public static bool developSimulateControls = true;
        public static bool ExtendedUI;
        public static int ApplicationSelection = 1;
        public static string StandardFieldsQueries = "";
        public static bool ShowAllRowsQueryResult;
        public static string Encoding = "default";
        public static bool UseAppStylingDefault = true;
        //public static int ColorSchema = 2;
        public static List<Form> lstOpendChildForms = new List<Form>();
        public static System.Drawing.Point LoactionMain;
        public static System.Drawing.Size LoactionSizeMain;
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
            LDAPPort = 60123,
            developApplication = 60110,
            developSimulateControls = 60111,
            ExtendedUI = 60113,
            ApplicationSelection = 60116,
            StandardFieldsQueries = 60117,
            ShowAllRowsQueryResult = 60118,
            developModus = 60120,
            protocolAllTranslationErrors = 60122,
            path_config = 60140,
            EMailService = 60146,
            LogPath = 60147,
            developPath_config = 60277,
            developConfigFile = 60278,
            IDParticipant = 60282,
            WriteERConnectionString = 60288,
            dbVS = 60294
        }

        public static bool readPathes(bool designMode, bool createPatReports, bool IsOhterLogin)
        {
            try
            {
                string strExceptionText = "readPathes: Root directory of QS2 may not be in first level of directory tree! ";
                if (!designMode)
                {
                    ENV._pathBin = System.Windows.Forms.Application.StartupPath;
                    ENV._pathRootBin = Directory.GetParent(System.Windows.Forms.Application.StartupPath).ToString();
                    if (ENV._pathRootBin == null)
                        throw new Exception(strExceptionText + System.Windows.Forms.Application.StartupPath.ToString());
                }
                else
                {
                    ENV._configFileDevelop = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + Path.DirectorySeparatorChar.ToString() + "qs2VS.config";    //Kann niemals erste Ebene sein!!
                    ENV.readConfig(ENV._configFileDevelop, designMode);

                    ENV.PathConfig = ENV._developPathConfig;
                    ENV.configFile = ENV._developConfigFile;

                    ENV._pathBin = ENV._developPath;
                    ENV._pathRootBin = Directory.GetParent(ENV._pathBin).ToString();
                    if (ENV._pathRootBin == null)
                        throw new Exception(strExceptionText + ENV._pathBin.ToString());

                    ENV.fileConfig = Path.Combine(ENV.PathConfig, ENV.configFile);
                    ENV.readConfig(ENV.fileConfig, designMode);
                }

                if (!System.IO.Directory.Exists(ENV.PathConfig))
                    throw new Exception(string.Format(ENV._errorPathMsg, ENV.PathConfig));

                if (!IsOhterLogin)
                {
                    if (ENV.PathLog.Trim() == "")
                        ENV.PathLog = Path.Combine(ENV.PathConfig, ENV.ePath.log.ToString());

                    if (!System.IO.Directory.Exists(ENV.PathLog))
                        System.IO.Directory.CreateDirectory(ENV.PathLog);
                }

                ENV.PathTemp = Path.Combine(Path.GetTempPath(), "QS2");
                if (!System.IO.Directory.Exists(ENV.PathTemp))
                {
                    System.IO.Directory.CreateDirectory(ENV.PathTemp);
                }

                if (!System.IO.Directory.Exists(ENV.PathTemp))
                    System.IO.Directory.CreateDirectory(ENV.PathTemp);

                ENV.PathReports = Path.Combine(ENV._pathBin, ENV.ePath.reports.ToString());
                if (createPatReports)
                {
                    ENV.checkPathReports(designMode);
                }

                ENV._exeConfig = Path.Combine(ENV.PathConfig, ENV._exeConfig);
                if (!System.IO.File.Exists(ENV._exeConfig))
                    throw new Exception("readPathes: File '" + ENV._exeConfig + "' does not exist!");

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
            if (!System.IO.Directory.Exists(ENV.PathReports))
                System.IO.Directory.CreateDirectory(ENV.PathReports);

            foreach (int val in Enum.GetValues(typeof(license.doLicense.eApp)))
            {
                string sApp = Enum.GetName(typeof(license.doLicense.eApp), val);
                string reportPathApp = Path.Combine(ENV.PathReports,sApp);
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
                                    ENV._lstConnStr.Add(sValue);
                                }

                                else if (sVar.Equals(eVarIni.dbVS.ToString(), sc) && DesignMode)
                                {
                                    ENV.connStr = sValue;
                                    ENV._lstConnStr.Clear();
                                }

                                else if (sVar.Equals(eVarIni.LogPath.ToString(), sc))
                                    ENV.PathLog = sValue;

                                else if (sVar.Equals(eVarIni.adminSecure.ToString(), sc))
                                    ENV.AdminSecure = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.protocolAllTranslationErrors.ToString(), sc))
                                    ENV.protocolAllTranslationErrors = GetBoolValue(sValue);

                                else if (sVar.Equals(_tagForMonitoring.ToString(), sc))
                                    ENV._tagForMonitoring = sValue;

                                else if (sVar.Equals(eVarIni.DefaultDomain.ToString(), sc))
                                    ENV.Domain = sValue;

                                else if (sVar.Equals(eVarIni.language.ToString(), sc))
                                    ENV.Language = sValue;

                                else if (sVar.Equals(eVarIni.EMailService.ToString(), sc))
                                    ENV.EMailService = sValue;

                                else if (sVar.Equals(eVarIni.developPath.ToString(), sc))
                                    ENV._developPath = sValue;

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
                                    ENV._idParticipant = sValue;
                                    ENV.readParticipants();
                                }

                                else if (sVar.Equals(eVarIni.path_config.ToString(), sc))
                                {
                                    if (sValue == ("programdata"))
                                    {
                                        ENV.PathConfig = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "qs2", "config");
                                        if (!Directory.Exists(ENV.PathConfig))
                                            Directory.CreateDirectory(ENV.PathConfig);
                                    }
                                    else
                                    {
                                        ENV.PathConfig = sValue;
                                        if (!Directory.Exists(ENV.PathConfig))
                                            Directory.CreateDirectory(ENV.PathConfig);
                                    }
                                }

                                else if (sVar.Equals(eVarIni.developPath_config.ToString(), sc))
                                    ENV._developPathConfig = sValue;

                                else if (sVar.Equals(eVarIni.developConfigFile.ToString(), sc))
                                    ENV._developConfigFile = sValue;

                                else if (sVar.Equals(eVarIni.developSimulateControls.ToString(), sc))
                                    ENV.developSimulateControls = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.ExtendedUI.ToString(), sc))
                                    ENV.ExtendedUI = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.ApplicationSelection.ToString(), sc))
                                    ENV.ApplicationSelection = GetIntValue(sValue);

                                else if (sVar.Equals(eVarIni.StandardFieldsQueries.ToString(), sc))
                                    ENV.StandardFieldsQueries = sValue;

                                else if (sVar.Equals(eVarIni.ShowAllRowsQueryResult.ToString(), sc))
                                    ENV.ShowAllRowsQueryResult = GetBoolValue(sValue);

                                else if (sVar.Equals("Encoding", sc))
                                    ENV.Encoding = sValue.ToLower();

                                else if (sVar.Equals("ReferenceVersion", sc))
                                    ENV.ReferenceVersion = sValue;

                                else if (sVar.Equals("MinDBVersion", sc))
                                    ENV.MinDBVersion = sValue;

                                else if (sVar.Equals("UseAppStylingDefault", sc))
                                    ENV.UseAppStylingDefault = GetBoolValue(sValue);
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
                lstIDParticipantsDecrypted = qs2.core.generic.readStrVariables(ENV._idParticipant.Trim());
                foreach (string IDParticipant in lstIDParticipantsDecrypted)
                {
                    string IDParticipantDecrypted = _encryption1.StringDecrypt(IDParticipant.Trim(), Encryption.keyForEncryptingStrings);
                    if (IDParticipantDecrypted.Trim() != "")
                    {
                        ENV._lstIdParticipantsEncrypted.Add(IDParticipantDecrypted);
                    }
                }

                if (ENV._lstIdParticipantsEncrypted.Count == 0)
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

            ENV.UserDb = SqlBuilder.UserID;
            ENV.PwdDbEncrypted = SqlBuilder.Password;
        }
    }
}
