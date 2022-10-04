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
        public static bool CheckWindowsPassword = true;
        public static bool UseDomain = false;
        public static int LDAPPort = 389;
        public static int rightIsAdmin = 1;
        public static bool WriteERConnectionString = false;


        public static bool NoQS2LicenceNecessary = false;
        public static int XMonthDeleteStaysStartUp = -1;
        public static bool DeletePatientsNoStayStartUp = false;

        public static int NumberFieldsInAStayReportLine = 3;

        public static bool AutoNumberPatients = true;
        public static bool AutoNumberStays = true;
        public static bool ShowTooltips = true;
        public static int TypeSetDefaultDBValue = 0;

        public static string ViewUserDefined = "";
        public static string EasyFunctions = "";

        public static int ButtProcGrpWidth = 135;
        public static int ButtChapterHeigth = 38;

        public static int ButtProcGrpImageSizeWidth = 32;
        public static int ButtProcGrpImageSizeHeigth = 32;

        public static bool autoLogIn = false;
        public static string autoLogInUser = "";
        public static string autoLogInPwdEncrypted = "";
        public static string autoLogInPwdDecrypted = "";

        public static int LockAfterMinutesInactivity = -1;

        public static string Server = "";
        public static string Database = "";
        public static string dbVS = "";
        public static string userDb = "";
        public static string pwdDbEncrypted = "";
        public static string pwdDbDecrypted = "";

        public static bool adminSecure = false;
        public static bool developModus = false;
        public static bool protocolAllTranslationErrors = false;
        public static string Domäne = "";
        public static string language = "";
        public static int autoJoin = 1;

        public static bool monitoring = false;
        public static string TagForMonitoring = "";

        public static license.dsLicense license;
        public static string countryDefault = "AT";

        public static bool UseStartupArgs = false;

        public static string EMailService = "ServiceCenter@s2-engineering.com";

        public static string developPath_config = "";
        public static string developConfigFile = "";

        public static string configFileDevelop = "";
        public static string developPath = "";
        public static string developApplication = "";
        public static string developParticipant = "develop";
        public static bool developSimulateControls = true;
        public static bool developCopnnected = false;

        public static bool LoggedInAsDomainUser = false;
        public static string ConnStrQTH = "";

        public static string DefaultApplicationThreadxy = qs2.core.license.doLicense.eApp.PMDS.ToString();
        public static bool StaysAsExternProcess2 = true;
        public static bool IsExternProcess = false;
        public static bool SendSetForgroundToMainStayUI = true;
        public static bool PreloadStayUI = true;

        public static string fileNameConfig = "qs2.config";
        public static string errorPathMsg = "Path {0} does not exist!";
        public static string errorFileMsg = "File {0} does not exist!";

        public static int CountAutoForm = 1;
        public static bool ExtendedUI = false;

        public static int typeLoading = 2;
        public static bool autoLoadPatients = false;

        public static int ApplicationSelection = 1;
        public static string StandardFieldsQueries = "";
        public static bool ShowAllRowsQueryResult;

        public static string Encoding = "default";
        public static bool IgnoreRoles = false;
        public static int ControlOpenStayType = 0;
        public static string ControlOpenStayTypeRoles = "";

        public static bool UseAppStylingDefault = true;
        public static int ColorSchema = 2;

        public static bool ESII_AcceptNoCreat = true;

        public static bool IsDevelopmentMachine = Environment.MachineName.sEquals( new List<object> { "styhl2", "sty040", "sty041" });
        public static string PdfiumKey = "EEF63308-0101E307-06060B50-44464955-4D5F434F-52501500-6F734073-322D656E-67696E65-6572696E-672E636F-6D40006E-50A02F72-7589BDC9-FA775FFE-E4C11070-8AECCB91-AA05BDDC-9064397A-0128DB07-08CA4E9D-1701E8DB-F0CAEA1E-386F13D9-6F207B8F-4FFCD647-D4BDA0FC-669139";


        public static DateTime DemoExpiration = new DateTime(2020, 10, 31);
        public static DateTime NoExpiration = new DateTime(2999, 12, 31);
        public static DateTime Expired = new DateTime(1900, 01, 01);

        public static bool OLAP_UseDBMenu = false;

        public static List<string> ResWorkaround = new List<string>();      //Liste der Stings, die temporär mit { und } eingefügt werden müssen wegen Programmfehler

        public static List<Enums.cLicense> listLicenses = new List<Enums.cLicense>
        {
            new Enums.cLicense { License = Enums.eLicense.LIC_STS,   Name = "LIC_STS", LicenseType = Enums.eLicenseType.typeBool, bValue = false },
            new Enums.cLicense { License = Enums.eLicense.LIC_CONGENITAL, Name = "LIC_CONGENITAL", LicenseType = Enums.eLicenseType.typeBool, bValue = false },
            new Enums.cLicense { License = Enums.eLicense.LIC_TAVI,   Name = "LIC_TAVI", LicenseType = Enums.eLicenseType.typeBool, bValue = false },
            new Enums.cLicense { License = Enums.eLicense.LIC_ARTAP,   Name = "LIC_ARTAP", LicenseType = Enums.eLicenseType.typeBool, bValue = false },
            new Enums.cLicense { License = Enums.eLicense.LIC_FRAILTY_INDEX,   Name = "LIC_FRAILTY_INDEX", LicenseType = Enums.eLicenseType.typeBool, bValue = false },
            new Enums.cLicense { License = Enums.eLicense.LIC_VALVES_EXTENSION,   Name = "LIC_VALVES_EXTENSION", LicenseType = Enums.eLicenseType.typeBool, bValue = false },
            new Enums.cLicense { License = Enums.eLicense.LIC_CARDIO_TECH,   Name = "LIC_CARDIO_TECH", LicenseType = Enums.eLicenseType.typeBool, bValue = false },
            new Enums.cLicense { License = Enums.eLicense.LIC_VAC,   Name = "LIC_VAC", LicenseType = Enums.eLicenseType.typeBool, bValue = false },
            new Enums.cLicense { License = Enums.eLicense.LIC_AMBLER_SCORE,   Name = "LIC_AMBLER_SCORE", LicenseType = Enums.eLicenseType.typeBool, bValue = false },
            new Enums.cLicense { License = Enums.eLicense.LIC_FOLLOW_UPS,   Name = "LIC_FOLLOW_UPS", LicenseType = Enums.eLicenseType.typeBool, bValue = false },
            new Enums.cLicense { License = Enums.eLicense.LIC_AKH_INTERFACE,   Name = "LIC_AKH_INTERFACE", LicenseType = Enums.eLicenseType.typeBool, bValue = false },
            new Enums.cLicense { License = Enums.eLicense.LIC_KAV_INTERFACE,   Name = "LIC_KAV_INTERFACE", LicenseType = Enums.eLicenseType.typeBool, bValue = false },
            new Enums.cLicense { License = Enums.eLicense.LIC_KAV_PATAUSKUNFT,   Name = "LIC_KAV_PATAUSKUNFT", LicenseType = Enums.eLicenseType.typeBool, bValue = false },
            new Enums.cLicense { License = Enums.eLicense.LIC_KAV_MEDARCHIV,   Name = "LIC_KAV_MEDARCHIV", LicenseType = Enums.eLicenseType.typeBool, bValue = false },
            new Enums.cLicense { License = Enums.eLicense.LIC_HL7_BULK,   Name = "LIC_HL7_BULK", LicenseType = Enums.eLicenseType.typeBool, bValue = false },
            new Enums.cLicense { License = Enums.eLicense.LIC_HL7_SOCKET,   Name = "LIC_HL7_SOCKET", LicenseType = Enums.eLicenseType.typeBool, bValue = false },
            new Enums.cLicense { License = Enums.eLicense.LIC_IsMasterVersion,   Name = "LIC_IsMasterVersion", LicenseType = Enums.eLicenseType.typeBool, bValue = false },
            new Enums.cLicense { License = Enums.eLicense.LIC_VALID_DATE,   Name = "LIC_VALID_DATE", LicenseType = Enums.eLicenseType.TypeDateTime, dValue = NoExpiration },
            new Enums.cLicense { License = Enums.eLicense.LIC_VASCULAR,   Name = "LIC_VASCULAR", LicenseType = Enums.eLicenseType.typeBool, bValue = false },
            new Enums.cLicense { License = Enums.eLicense.LIC_QUERYFROMMASTER,   Name = "LIC_QUERYFROMMASTER", LicenseType = Enums.eLicenseType.typeBool, bValue = false },
            new Enums.cLicense { License = Enums.eLicense.LIC_QUERYFROMMASTER_DATE,   Name = "LIC_QUERYFROMMASTER_DATE", LicenseType = Enums.eLicenseType.TypeDateTime, dValue = Expired },
            new Enums.cLicense { License = Enums.eLicense.LIC_VASCULAR2,   Name = "LIC_VASCULAR2", LicenseType = Enums.eLicenseType.typeBool, bValue = false },
            new Enums.cLicense { License = Enums.eLicense.LIC_OLAP,   Name = "LIC_OLAP", LicenseType = Enums.eLicenseType.typeBool, bValue = false },
            new Enums.cLicense { License = Enums.eLicense.LIC_OLAP_VALID_DATE,   Name = "LIC_OLAP_VALID_DATE", LicenseType = Enums.eLicenseType.TypeDateTime, dValue = DemoExpiration },
            new Enums.cLicense { License = Enums.eLicense.LIC_DOCUMENTS,   Name = "LIC_DOCUMENTS", LicenseType = Enums.eLicenseType.typeBool, bValue = false },
            new Enums.cLicense { License = Enums.eLicense.LIC_DOCUMENTS_VALID_DATE,   Name = "LIC_DOCUMENTS_VALID_DATE", LicenseType = Enums.eLicenseType.TypeDateTime, dValue = DemoExpiration },
            new Enums.cLicense { License = Enums.eLicense.LIC_DEATH_STATUS_MODE_XLSX,   Name = "LIC_DEATH_STATUS_MODE_XLSX", LicenseType = Enums.eLicenseType.typeBool, bValue = false },
        };

        //KAV-MedArchiv und KAV-Upload
        public static string KAVApplikationsID_IDKey = "Cardiac";
        public static string KAVKostenstelle_IDText = "Herzchirurgie";
        public static string KAVKostenstelle_IDKey = "91639998";
        public static string KAVDokumentVerwahrer_IDKey = "9163";
        public static string KAVApplikationsName = "Cardiac";
        public static string KAVApplikationsKennung = "0a3699de-80f9-47db-a56a-5f84ec42bdf0";
        public static string KAVKategorieKuerzelID = "CHI-HTBEF";
        public static string KAVDokumentname = "Aufenthaltsdatenblatt.pdf";
        public static string KAVURL_MedArchiv = "http://datagate.wienkav.at/MedArchiv/MedArchiv.asmx";
        public static string KAVURL_PatAuskunft = "http://datagate.wienkav.at/PatAuskunft/PatAuskunft.asmx";
        public static string KAVUser = @"wienkav\SrvAccCardiac";
        public static string KAVPassword = @"fZ6ajqfnIsV4DL3FBKnzKQ==";  //cardiac68
        public static string KAVAuthentificationMode = @"ntlm";  //basic

        





        public class cAKHParams
        {
            public  bool AKHUse_Upload { get; set; } = false;
            public  string AKHDokumentName_CARDIAC { get; set; }
            public  string AKHDokumentCode_CARDIAC { get; set; }
            public  string AKHI_SYSTEM { get; set; }
            public  string AKHI_OID_ID { get; set; }
            public  string AKHI_OID_SID { get; set; }
            public  string AKHI_OID_AUFTRAG { get; set; }
            public  string AKHI_DOCID { get; set; }
            public  string AKHI_DOCTITEL { get; set; }
            public  string AKHI_ERBORGID { get; set; }
            public  string AKHI_ANFORGID { get; set; }
            public  string AKHI_DOCKLASSE { get; set; }
            public  string AKHI_DOCKLASSE_DISPLAY { get; set; }
            public  string AKHI_OID_DOCKLASSE { get; set; }
            public  string AKHI_DOCKLASSE_SYSTEM { get; set; }
            public  string AKHI_AUTHOR { get; set; }
            public  string AKHCDAService_URL { get; set; }
            public  string AKHCDA_User { get; set; }
            public  string AKHCDA_Password { get; set; }
            public  string AKHDokMonFileShare { get; set; }
            public  string AKHQuellanwendung { get; set; }
            public  string AKHQuellProzess { get; set; }
            public  string AKHTemplateID { get; set; }
            public  string AKHDokMonURL { get; set; }
            public  string AKHQuellShortcut { get; set; }
            public  string AKHDokumentklasse { get; set; }

            public  string AKHUpload_User { get; set; }
            public  string AKHUpload_Password { get; set; }
            public  string AKHHL7_User { get; set; }
            public  string AKHHL7_Password { get; set; }

            public  string HL7_AKHKostenstelle_ID { get; set; }
        }

        public static List<KeyValuePair<string, cAKHParams>> AKHParams = new List<KeyValuePair<string, cAKHParams>>();

        //HL7-Allgemein
        public static string HL7_FilesPath = "";            //Pfad, aus dem der HL7-Service die Dateien liest
        public static string HL7_User = @"s2e\sysuser";
        public static string HL7_Password = @"Süßtem!";
        public static string HL7_Version = "2.32";
        public static string HL7_URL = "";
        public static int HL7_Port = 0;
        public static bool HL7_SSL = false;
        public static bool HL7_Asynchron = false;
        public static string HL7_SocketServer_URL = "";
        public static int HL7_SocketServer_Port = 0;

        public static bool HL7_WriteQryToFile = false;
        public static string HL7_QryFilesPath = "";            //Pfad, in den die Qry-Dateien geschrieben werden

        public static char HL7_cSegmentStart = (char)0;
        public static char HL7_cDataStart = (char)0;

        public static char HL7_cMsgStart = (char)11;
        public static char HL7_cSegmentEnd = (char)13;
        public static char HL7_cDataEnd = (char)28;
        public static char HL7_cMsgEnd = (char)13;

        public static string HL7FileExtension = ".dat";

        //HL7-Graz
        public static string HL7_RemoveString = "";

        //Congenital
        public static string Congenital_HospitalCode = "AAA";
        public static string Congenital_HospitalCountry = "Austria";
        public static string Congenital_Version = "7.0.13";

        public static System.Collections.Generic.List<Form> lstOpendChildForms = new List<Form>();

        // 2017 new Config-Variables
        public static bool bPrintDbTypes = false;
        public static string PrintDbTypesSearchForLicType = "";

        public static bool autoOpenStayPerThread = true;
        public static bool UploadPrintAllChapters = false;

        public static System.Drawing.Point LoactionMain;
        public static System.Drawing.Size LoactionSizeMain;
        public static System.Windows.Forms.Form MainForm;

        public static System.Drawing.Point LoactionStay;
        public static System.Drawing.Size LoactionSizeStay;
        public static string IDApplicationActiveFromUser = "";

        public enum eTypApp
        {
            contSearch = 60000,
            contQuerysRun = 60002,
            contReportsRun = 60003,
            contDocumentsRun = 60007,

            contAbout = 60004,
            contInfoUsers = 60032,
            contInfoLicense = 60005,
            contQuerysUser = 60006,
            contTexteditor = 60008,
            btnProtocoll = 60046,

            QS2PopUpContainerRessourcen = 60009,
            QS2PopUpContainerCriterias = 60010,
            QS2PopUpContainerRelations = 60022,
            QS2PopUpContainerAdjustments = 60011,
            QS2PopUpContainerAddIns = 60012,
            QS2PopUpContainerSelLists = 600013,
            QS2PopUpContainerQuerysAdmin = 600014,
            QS2PopUpContainerSysDatabase = 60015,
            QS2PopUpContainerLogManager = 600016,
            QS2PopUpContainerLayouts = 600017,
            QS2PopUpContainerManagementProducts = 600021,
            contManageUserQueries = 600022,

            fctNewLogOn = 60018,
            fctChangePassword = 60020,
            fctLock = 60019,
            fktClose = 60017,

            poUpOthers = 600024,
            btnMergingPatients = 600025,
            btnMergeUserAccounts = 600026,
            btnInsertSelListFromClipboard = 600027,
            btnProtocolStays = 600028,
            btnEditCriteriaDefaultValues = 600029,
            btnCopyStays = 600030,
            btnDeletePatients = 600031,
            btnDeleteStays = 600032,
            btnManageDeathStatus = 600033,
            btnImportStays = 600034,
            btnExportCriteriasToExcel = 600035,
            btnSys = 600037,
            btnAdjustmentQTHDb = 600038,
            btnCopyStaysParticipant = 600039,
            btnImportHelpFromExcel = 600040,
            btnNewProduct = 600041,
            btnRunQueryFromClipboard = 600042,

            None = -1
        }
        public enum ePath
        {
            config = 60050,
            log = 60051,
            license = 60052,
            sys = 60053,
            temp = 60054,
            reports = 60055,
            AddIns = 60056,
            documents = 60057
        }


        public enum eVarIni
        {
            db = 60100,
            adminSecure = 60101,
            logInAuto = 60102,
            logInAutoUsr = 60103,
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
            typeLoading = 60114,
            autoJoin = 60115,
            ApplicationSelection = 60116,
            StandardFieldsQueries = 60117,
            ShowAllRowsQueryResult = 60118,
            rightIsAdmin = 60119,
            developModus = 60120,
            autoLoadPatients = 60121,
            protocolAllTranslationErrors = 60122,

            monitoring = 60163,
            TagForMonitoring = 60164,

            path_config = 60140,
            path_reports = 60142,
            EMailService = 60146,
            LogPath = 60147,

            autoLogIn = 60160,
            autoLogInUser = 60161,
            autoLogInPwd = 60162,
            UrlQS2Service = 60166,

            NumberFieldsInAStayReportLine = 60165,

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

            //StaysAsExternProcess = 60281,

            IDParticipant = 60282,
            IgnoreRoles = 60283,
            DefaultApplicationThread = 60284,

            UseStartupArgs = 60285,

            ControlOpenStayType = 60286,
            ControlOpenStayTypeRoles = 60287,
            WriteERConnectionString = 60288,
            LockAfterMinutesInactivity = 60289,

            ResetControlsToDefaultValues = 60290,
            CheckValuesInDeactivatedChapters = 60291,
            ResetValuesOnCheck = 60292,

            //StaysAsExternProcess2 = 60293

            dbVS = 60294,
            UseAppStylingDefault = 60295,
            VisualStudioModus = 60296,
            ColorSchema = 60293,
            ConnStrQTH = 60297
        }

        public enum eTypeFunction
        {
            loadManageQueryuser = 0,
            loadStay = 1,
            CloseApp = 2,
            loadUser = 3,
            refreshStay = 4,
            doColorManagment = 5,
            loadPatient = 6
        }

        public static event dCallFunctionMain eCallFunctionMain;
        public delegate void dCallFunctionMain(eTypeFunction TypeFunction, cParsCalMainFunction pars);


        public class cParsCalMainFunction
        {
            public System.Guid IDGuidStay = System.Guid.Empty;
            public string IDApplication = "";
            public bool newStay = false;
            public qs2.core.Enums.eStayTyp StayTyp;
            public bool OpenFromEvaluation = false;

            public object UICoontrol = null;
            public object UIComponents = null;
        }

        public class cVarsSettings
        {
            public string VarDef = "";
            public string VarDescription = "";
            public string defaultValue = "";
            public eTypeSetting TypeSetting = eTypeSetting.tString;
        }
        public enum eTypeSetting
        {
            tInt = 0,
            tDouble = 1,
            tString = 2,
            tDateTime = 3
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

        public static void PrepareAKHParams()
        {
            try
            {
                //in ENV.lstIDParticipantsEncrypted sind die IDParticipants angegeben (91090, 91091) (Stand 2.6.2020)
                //Alle Mandanten werden mit den selben Defaults vorbelegt

                if (ENV.lstIDParticipantsEncrypted == null)
                {
                    throw new Exception("ENV.PrepareAKHParams: IDParticipants not read. Please change Config-File.");
                }

                for (int i = 0; i < ENV.lstIDParticipantsEncrypted.Count(); i++)
                {
                    cAKHParams ParamAKH = new ENV.cAKHParams();
                    //Chirurgie-Defaults
                    ParamAKH.AKHUse_Upload = false;
                    ParamAKH.AKHDokumentName_CARDIAC = "Aufenthaltsdatenblatt";
                    ParamAKH.AKHDokumentCode_CARDIAC = "CAR";
                    ParamAKH.AKHI_SYSTEM = "Cardiac";
                    ParamAKH.AKHI_OID_ID = "2.16.840.1.113883.2.16.3.1.5.0.1.14.1";
                    ParamAKH.AKHI_OID_SID = "2.16.840.1.113883.2.16.3.1.5.0.1.14.0";
                    ParamAKH.AKHI_OID_AUFTRAG = "2.16.840.1.113883.2.16.3.1.5.0.8.14";
                    ParamAKH.AKHI_DOCID = "c001";
                    ParamAKH.AKHI_DOCTITEL = "Aufenthaltsdatenblatt";
                    ParamAKH.AKHI_ERBORGID = "901CH801";
                    ParamAKH.AKHI_ANFORGID = "901CH801";
                    ParamAKH.AKHI_DOCKLASSE = "CARDIAC";
                    ParamAKH.AKHI_DOCKLASSE_DISPLAY = "Aufenthaltsdatenblatt";
                    ParamAKH.AKHI_OID_DOCKLASSE = "2.16.840.1.113883.2.16.3.1.5.0.1.14.3";
                    ParamAKH.AKHI_DOCKLASSE_SYSTEM = "CARDIAC-Dokumentenklasse";
                    ParamAKH.AKHI_AUTHOR = "AKHEDVOBM";
                    ParamAKH.AKHCDAService_URL = @"http://akhsap71.routine.akhwien.at:8021/sap/bc/srt/rfc/sap/zws_s_cda_header/100/zws_s_cda_header/zws_s_cda_header";
                    ParamAKH.AKHCDA_User = "AKHCDAQSS";
                    ParamAKH.AKHCDA_Password = "9o1NnaSwDwhYtFd369vM9A==";
                    ParamAKH.AKHDokMonFileShare = @"\\V01www11.routine.akhwien.at\jcapsdata-test-cardiac$";
                    ParamAKH.AKHQuellanwendung = "Cardiac";
                    ParamAKH.AKHQuellProzess = "Upload";
                    ParamAKH.AKHTemplateID = "2.16.840.1.113883.2.16.3.1.5.0.11.0.0.1.4";
                    ParamAKH.AKHDokMonURL = @"https://jcapsdata.routine.akhwien.at/cardiac/";
                    ParamAKH.AKHQuellShortcut = "CAR";
                    ParamAKH.AKHDokumentklasse = "Herzchirurgie";
                    ParamAKH.AKHUpload_User = @"AKHWIEN\ZCardiac";
                    ParamAKH.AKHUpload_Password = @"o6TcFyaje01ar78CAIFcUA==";
                    ParamAKH.AKHHL7_User = @"AKHWIEN\ZCardiac";
                    ParamAKH.AKHHL7_Password = @"o6TcFyaje01ar78CAIFcUA==";
                    ParamAKH.HL7_AKHKostenstelle_ID = "90120311";   //Prefix
                    AKHParams.Add(new KeyValuePair<string, cAKHParams>(ENV.lstIDParticipantsEncrypted[i], ParamAKH));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PrepareAKHParams: " + ex.ToString());
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

                                else if (sVar.Equals(eVarIni.monitoring.ToString(), sc))
                                    ENV.monitoring = GetBoolValue(sValue);

                                else if (sVar.Equals(TagForMonitoring.ToString(), sc))
                                    ENV.TagForMonitoring = sValue;

                                else if (sVar.Equals(eVarIni.autoLoadPatients.ToString(), sc))
                                    ENV.autoLoadPatients = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.DefaultDomain.ToString(), sc))
                                    ENV.Domäne = sValue;

                                else if (sVar.Equals(eVarIni.language.ToString(), sc))
                                    ENV.language = sValue;

                                else if (sVar.Equals(eVarIni.EMailService.ToString(), sc))
                                    ENV.EMailService = sValue;

                                else if (sVar.Equals(eVarIni.developPath.ToString(), sc))
                                    ENV.developPath = sValue;

                                else if (sVar.Equals(eVarIni.CheckWindowsPassword.ToString(), sc))
                                    ENV.CheckWindowsPassword = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.WriteERConnectionString.ToString(), sc))
                                    ENV.WriteERConnectionString = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.UseDomain.ToString(), sc))
                                    ENV.UseDomain = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.LDAPPort.ToString().Trim(), sc))
                                    ENV.LDAPPort = GetIntValue(sValue);

                                else if (sVar.Equals(eVarIni.autoLogIn.ToString(), sc))
                                    ENV.autoLogIn = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.autoLogInUser.ToString(), sc))
                                    ENV.autoLogInUser = sValue;

                                else if (sVar.Equals(eVarIni.autoLogInPwd.ToString(), sc))
                                    ENV.autoLogInPwdEncrypted = sValue;

                                else if (sVar.Equals(eVarIni.IDParticipant.ToString(), sc))
                                {
                                    if (String.IsNullOrWhiteSpace(sValue))
                                    {
                                        throw new Exception("readConfig: ENV.IDParticipant=='' not allowed!");
                                    }
                                    ENV.IDParticipant = sValue;
                                    ENV.readParticipants();

                                    foreach (string IDPart in ENV.lstIDParticipantsEncrypted)
                                    {
                                        if (IDPart == "91090" || IDPart == "91091" && AKHParams.Count == 0)
                                            PrepareAKHParams();     
                                    }
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

                                else if (sVar.Equals(eVarIni.ViewUserDefined.ToString(), sc))
                                    ENV.ViewUserDefined = sValue;

                                else if (sVar.Equals(eVarIni.EasyFunctions.ToString(), sc))
                                    ENV.EasyFunctions = sValue;

                                else if (sVar.Equals(eVarIni.NoQS2LicenceNecessary.ToString(), sc))
                                    ENV.NoQS2LicenceNecessary = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.CountAutoForm.ToString(), sc))
                                    ENV.CountAutoForm = GetIntValue(sValue);

                                else if (sVar.Equals(eVarIni.AutoNumberPatients.ToString(), sc))
                                    ENV.AutoNumberPatients = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.UseStartupArgs.ToString(), sc))
                                    ENV.UseStartupArgs = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.DefaultApplicationThread.ToString(), sc))
                                    ENV.DefaultApplicationThreadxy = sValue;

                                else if (sVar.Equals(eVarIni.AutoNumberStays.ToString(), sc))
                                    ENV.AutoNumberStays = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.ShowTooltips.ToString(), sc))
                                    ENV.ShowTooltips = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.TypeSetDefaultDBValue.ToString(), sc))
                                    ENV.TypeSetDefaultDBValue = GetIntValue(sValue);

                                else if (sVar.Equals(eVarIni.IgnoreRoles.ToString(), sc))
                                    ENV.IgnoreRoles = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.ResetControlsToDefaultValues.ToString(), sc))
                                    ENV.ResetControlsToDefaultValues = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.CheckValuesInDeactivatedChapters.ToString(), sc))
                                    ENV.CheckValuesInDeactivatedChapters = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.ResetValuesOnCheck.ToString(), sc))
                                    ENV.ResetValuesOnCheck = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.XMonthDeleteStaysStartUp.ToString(), sc))
                                    ENV.XMonthDeleteStaysStartUp = GetIntValue(sValue);

                                else if (sVar.Equals(eVarIni.DeletePatientsNoStayStartUp.ToString(), sc))
                                    ENV.DeletePatientsNoStayStartUp = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.ButtProcGrpWidth.ToString(), sc))
                                    ENV.ButtProcGrpWidth = GetIntValue(sValue);

                                else if (sVar.Equals(eVarIni.ButtChapterHeigth.ToString(), sc))
                                    ENV.ButtChapterHeigth = GetIntValue(sValue);

                                else if (sVar.Equals(eVarIni.ButtProcGrpImageSizeWidth.ToString(), sc))
                                    ENV.ButtProcGrpImageSizeWidth = GetIntValue(sValue);

                                else if (sVar.Equals(eVarIni.ButtProcGrpImageSizeHeigth.ToString(), sc))
                                    ENV.ButtProcGrpImageSizeHeigth = GetIntValue(sValue);

                                else if (sVar.Equals(eVarIni.rightIsAdmin.ToString(), sc))
                                    ENV.rightIsAdmin = GetIntValue(sValue);

                                else if (sVar.Equals(eVarIni.autoJoin.ToString(), sc))
                                    ENV.autoJoin = GetIntValue(sValue);

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

                                else if (sVar.Equals("KAVApplikationsID_IDKey", sc))
                                    ENV.KAVApplikationsID_IDKey = sValue;

                                else if (sVar.Equals("KAVKostenstelle_IDText", sc))
                                    ENV.KAVKostenstelle_IDText = sValue;

                                else if (sVar.Equals("KAVKostenstelle_IDKey", sc))
                                    ENV.KAVKostenstelle_IDKey = sValue;

                                else if (sVar.Equals("KAVApplikationsName", sc))
                                    ENV.KAVApplikationsName = sValue;

                                else if (sVar.Equals("KAVApplikationsKennung", sc))
                                    ENV.KAVApplikationsKennung = sValue;

                                else if (sVar.Equals("KAVKategorieKuerzelID", sc))
                                    ENV.KAVKategorieKuerzelID = sValue;

                                else if (sVar.Equals("KAVUrl_MedArchiv", sc))
                                    ENV.KAVURL_MedArchiv = sValue;

                                else if (sVar.Equals("KAVUrl_PatAuskunft", sc))
                                    ENV.KAVURL_PatAuskunft = sValue;

                                else if (sVar.Equals("KAVUser", sc))
                                    ENV.KAVUser = sValue;

                                else if (sVar.Equals("KAVPassword", sc))
                                    ENV.KAVPassword = ENV.Encryption1.StringDecrypt(sValue, Encryption.keyForEncryptingStrings);

                                else if (sVar.Equals("KAVAuthentificationMode", sc))
                                    ENV.KAVAuthentificationMode = sValue;

                                else if (sVar.Equals("HL7_FilesPath", sc))
                                    ENV.HL7_FilesPath = sValue.EndsWith(Path.DirectorySeparatorChar.ToString()) ? sValue : sValue + Path.DirectorySeparatorChar.ToString();

                                else if (sVar.Equals("HL7_User", sc))
                                    ENV.HL7_User = sValue;

                                else if (sVar.Equals("HL7_Password", sc))
                                    ENV.HL7_Password = ENV.Encryption1.StringDecrypt(sValue, Encryption.keyForEncryptingStrings);

                                else if (sVar.Equals("HL7_Version", sc))
                                    ENV.HL7_Version = sValue;

                                else if (sVar.Equals("HL7_URL", sc))
                                    ENV.HL7_URL = sValue;

                                else if (sVar.Equals("HL7_Port", sc))
                                    ENV.HL7_Port = GetIntValue(sValue);

                                else if (sVar.Equals("HL7_SSL", sc))
                                    ENV.HL7_SSL = GetBoolValue(sValue);

                                else if (sVar.Equals("HL7_Asynchron", sc))
                                    ENV.HL7_Asynchron = GetBoolValue(sValue);

                                else if (sVar.Equals("HL7FileExtension", sc))
                                    ENV.HL7FileExtension = sValue;

                                else if (sVar.Equals("HL7_FileExtension", sc))
                                    ENV.HL7FileExtension = sValue;

                                else if (sVar.Equals("HL7_RemoveString", sc))
                                    ENV.HL7_RemoveString = sValue;

                                else if (sVar.Equals("HL7_SocketServer_URL", sc))
                                    ENV.HL7_SocketServer_URL = sValue;

                                else if (sVar.Equals("HL7_SocketServer_Port", sc))
                                    ENV.HL7_SocketServer_Port = GetIntValue(sValue);

                                else if (sVar.Equals("HL7_WriteQryToFile", sc))
                                    ENV.HL7_WriteQryToFile = GetBoolValue(sValue);

                                else if (sVar.Equals("HL7_QryFilesPath", sc))
                                    ENV.HL7_QryFilesPath = sValue.EndsWith(Path.DirectorySeparatorChar.ToString()) ? sValue : sValue + Path.DirectorySeparatorChar.ToString();

                                else if (sVar.Equals("Congenital_HospitalCode", sc))
                                    ENV.Congenital_HospitalCode = sValue;

                                else if (sVar.Equals("Congenital_HospitalCountry", sc))
                                    ENV.Congenital_HospitalCountry = sValue;

                                else if (sVar.Equals("Congenital_Version", sc))
                                    ENV.Congenital_Version = sValue;

                                else if (sVar.Equals(eVarIni.LockAfterMinutesInactivity.ToString(), sc))
                                    ENV.LockAfterMinutesInactivity = GetIntValue(sValue);

                                //--------------------- AKH / Alle Mandanten
                                else if (sVar.Equals("HL7_AKHKostenstelle_ID", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.HL7_AKHKostenstelle_ID = Val;
                                    }
                                }

                                else if (sVar.Equals("AKHUse_Upload", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHUse_Upload = GetBoolValue(Val);
                                    }
                                }

                                else if (sVar.Equals("AKHDokumentName_CARDIAC", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHDokumentName_CARDIAC = Val;
                                    }
                                }

                                else if (sVar.Equals("AKHDokumentCode_CARDIAC", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHDokumentCode_CARDIAC = Val;
                                    }
                                }

                                else if (sVar.Equals("AKHI_SYSTEM", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHI_SYSTEM = Val;
                                    }
                                }

                                else if (sVar.Equals("AKHI_OID_ID", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHI_OID_ID = Val;
                                    }
                                }

                                else if (sVar.Equals("AKHI_OID_SID", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHI_OID_SID = Val;
                                    }
                                }

                                else if (sVar.Equals("AKHI_DOCID", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHI_DOCID = Val;
                                    }
                                }

                                else if (sVar.Equals("AKHI_DOCTITEL", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHI_DOCTITEL = Val;
                                    }
                                }

                                else if (sVar.Equals("AKHI_ERBORGID", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHI_ERBORGID = Val;
                                    }
                                }

                                else if (sVar.Equals("AKHI_ANFORGID", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHI_ANFORGID = Val;
                                    }
                                }

                                else if (sVar.Equals("AKHI_DOCKLASSE", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHI_DOCKLASSE = Val;
                                    }
                                }

                                else if (sVar.Equals("AKHI_DOCKLASSE_DISPLAY", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHI_DOCKLASSE_DISPLAY = Val;
                                    }
                                }

                                else if (sVar.Equals("AKHI_OID_DOCKLASSE", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHI_OID_DOCKLASSE = Val;
                                    }
                                }

                                else if (sVar.Equals("AKHI_DOCKLASSE_SYSTEM", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHI_DOCKLASSE_SYSTEM = Val;
                                    }
                                }

                                else if (sVar.Equals("AKHI_AUTHOR", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHI_AUTHOR = Val;
                                    }
                                }

                                else if (sVar.Equals("AKHI_OID_AUFTRAG", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHI_OID_AUFTRAG = Val;
                                    }
                                }

                                else if (sVar.Equals("AKHCDAService_URL", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHCDAService_URL = Val;
                                    }
                                }

                                else if (sVar.Equals("AKHCDA_User", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHCDA_User = Val;
                                    }
                                }

                                else if (sVar.Equals("AKHCDA_Password", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHCDA_Password = ENV.Encryption1.StringDecrypt(Val, Encryption.keyForEncryptingStrings);
                                    }
                                }

                                else if (sVar.Equals("AKHDokMonFileShare", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHDokMonFileShare = Values[i].EndsWith(Path.DirectorySeparatorChar.ToString()) ? Val : Val + Path.DirectorySeparatorChar.ToString();
                                    }
                                }

                                else if (sVar.Equals("AKHQuellanwendung", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHQuellanwendung = Val;
                                    }
                                }

                                else if (sVar.Equals("AKHQuellProzess", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHQuellProzess = Val;
                                    }
                                }

                                else if (sVar.Equals("AKHTemplateID", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHTemplateID = Val;
                                    }
                                }

                                else if (sVar.Equals("AKHDokMonURL", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < AKHParams.Count(); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHDokMonURL = Val;
                                    }
                                }

                                else if (sVar.Equals("AKHQuellShortcut", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHQuellShortcut = Val;
                                    }
                                }

                                else if (sVar.Equals("AKHDokumentklasse", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHDokumentklasse = Val;
                                    }
                                }

                                else if (sVar.Equals("AKHUpload_User", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHUpload_User = Val;
                                    }
                                }

                                else if (sVar.Equals("AKHUpload_Password", sc))
                                {
                                    string[] Values = SplitMultiValues(sValue);
                                    for (int i = 0; i < Math.Min(AKHParams.Count(), Values.Count()); i++)
                                    {
                                        string Val = Values.Count() <= i ? Values[0] : Values[i];
                                        AKHParams[i].Value.AKHUpload_Password = ENV.Encryption1.StringDecrypt(Val, Encryption.keyForEncryptingStrings);
                                    }
                                }
                                //--------------------------------------------------------------------

                                else if (sVar.Equals("ReferenceVersion", sc))
                                    ENV.ReferenceVersion = sValue;

                                else if (sVar.Equals("MinDBVersion", sc))
                                    ENV.MinDBVersion = sValue;

                                else if (sVar.Equals("ControlOpenStayType", sc))
                                    ENV.ControlOpenStayType = GetIntValue(sValue);

                                else if (sVar.Equals("ControlOpenStayTypeRoles", sc))
                                    ENV.ControlOpenStayTypeRoles = sValue;

                                else if (sVar.Equals("bPrintDbTypes", sc))
                                    ENV.bPrintDbTypes = GetBoolValue(sValue);

                                else if (sVar.Equals("PrintDbTypesSearchForLicType", sc))
                                    ENV.PrintDbTypesSearchForLicType = sValue;

                                else if (sVar.Equals("autoOpenStayPerThread", sc))
                                    ENV.autoOpenStayPerThread = GetBoolValue(sValue);

                                else if (sVar.Equals("UploadPrintAllChapters", sc))
                                    ENV.UploadPrintAllChapters = GetBoolValue(sValue);

                                else if (sVar.Equals("SendSetForgroundToMainStayUI", sc))
                                    ENV.SendSetForgroundToMainStayUI = GetBoolValue(sValue);

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

                                else if (sVar.Equals("ESII_AcceptNoCreat", sc))
                                    ENV.ESII_AcceptNoCreat = GetBoolValue(sValue);

                                else if (sVar.Equals(eVarIni.ConnStrQTH.ToString(), sc))
                                    ENV.ConnStrQTH = sValue;

                                else if (sVar.Equals("OLAP_UseDBMenu", sc))
                                    ENV.OLAP_UseDBMenu = GetBoolValue(sValue);
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
                if (ENV.eCallFunctionMain != null)
                {
                    ENV.eCallFunctionMain.Invoke(TypeFunction, pars);  
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("ENV.CallFunctionMain:" + ex.ToString());
            }
        }

        public static void clearTmpDir()
        {
            try
            {
                string[] filesInPaths = Directory.GetFiles(ENV.path_temp.Trim());
                foreach (string fileFound in filesInPaths)
                {
                    try
                    {
                        System.IO.File.Delete(fileFound);
                    }
                    catch (Exception ex)
                    {
                        string xy = "";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ENV.clearTmpDir:" + ex.ToString());
            }
        }


    }

}
