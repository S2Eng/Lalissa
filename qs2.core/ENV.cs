using Chilkat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QS2.functions.vb;

namespace qs2.core
{
    public class ENV
    {
        private static string errorPathMsg = "Path {0} does not exist!";
        private static Encryption Encryption1 = new Encryption();
        private static string path_rootBin = "";
        private static string path_bin = "";
        private static string ExeConfig = "QS2.exe.config";
        private static string IDParticipant = "";
        private static System.Collections.Generic.List<string> lstIDParticipantsEncrypted = new List<string>();
        private static System.Collections.Generic.List<string> lstConnStr = new System.Collections.Generic.List<string>();
        private static string TagForMonitoring = "";
        private static string developPath_config = "";
        private static string developConfigFile = "";
        private static string configFileDevelop = "";
        private static string developPath = "";

        public static bool UseWatch = false;
        public static string ReferenceVersion = "";
        public static string AssemblyVersion = "";
        public static string DBVersionFromDatabase = "";
        public static string MinDBVersion = "";
        public static bool ConnectedOnDesignerDB_QS2_Dev = false;
        public static bool SystemIsInitialized = false;
        public static string path_config = "";
        public static string path_reports = "";
        public static string path_log = "";
        public static string path_temp = "";
        public static bool IsHeadquarter = false;
        public static string fileConfig = "";
        public static string configFile = "";
        public static string connStr = "";
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
        public static string EMailService = "ServiceCenter@s2-engineering.com";
        public static string developParticipant = "develop";
        public static bool developSimulateControls = true;
        public static bool ExtendedUI = false;
        public static int ApplicationSelection = 1;
        public static string StandardFieldsQueries = "";
        public static bool ShowAllRowsQueryResult;
        public static string Encoding = "default";
        public static bool UseAppStylingDefault = true;
        public static int ColorSchema = 2;
        public static System.Collections.Generic.List<Form> lstOpendChildForms = new List<Form>();
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

                                else if (sVar.Equals(eVarIni.developPath_config.ToString(), sc))
                                    ENV.developPath_config = sValue;

                                else if (sVar.Equals(eVarIni.developConfigFile.ToString(), sc))
                                    ENV.developConfigFile = sValue;

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
    }
}
