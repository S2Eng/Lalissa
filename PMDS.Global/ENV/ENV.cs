using System;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using System.Drawing;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Specialized;
using System.Data;
using System.Data.OleDb;

using RBU;
using System.Collections.Generic;
using PMDS.Global.db.Patient;

using System.Configuration;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Net;
using Infragistics.Win.UltraWinTree;
using System.Threading;
using System.Linq;
using PMDS.Global.db.ERSystem;
using System.Security.Permissions;
using System.Security;
using MARC.Everest.Formatters.XML.ITS1;
using MARC.Everest.Formatters.XML.Datatypes.R1;
using MARC.Everest.RMIM.UV.CDAr2.POCD_MT000040UV;
using MARC.Everest.DataTypes;
using MARC.Everest.Attributes;
using S2Extensions;

namespace PMDS.Global
{

    public class ENV
    {
        public enum pdfDruckTyp
        {
            einzelblatt = 0,
            massenblatt = 1,
            pdf = 2,
            vorschau = 3
        }

        public enum eKlientenberichtTyp
        {
            full = 0,
            blackoutprevention = 1
        }

        public enum eDatenexportTyp
        {
            entlassen = 0,
            aktiv = 1,
            alle = 2
        }

        private enum eDecrypt
        {
            QS2Mode = 2,
            PMDSMode = 1,
            no = 0
        }

        private enum eLengthType
        {
            between = 4,
            fix = 3,
            min = 2,
            max = 1,
            var = 0
        }

        private enum eTrim
        {
            yes = 1,
            no = 0
        }

        public enum TaskbarPosition
        {
            Ausgeblendet = 0,
            Unten = 1,
            Rechts = 2,
            Links = 3,
            Oben = 4
        }

        public enum RezeptdruckTyp
        {
            MedikamenteBestellen = 0,
            RezeptDruck = 1,
            Beides = 2
        }
        public enum eFctCallMainFctPlan
        {
            Dekurs = 0,
            DekursErstellen = 1,
            DekursErstellenAls = 2,
            PrintTermine = 3,
            PrintTermineBereich = 4

        }


        public static bool VisualStudioMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
        public static Guid VersionNr = new Guid("10000000-1009-1000-0000-000000000001");

        public static System.Data.OleDb.OleDbConnection conGiboDat;
        public static string IDApplication = qs2.core.license.doLicense.eApp.PMDS.ToString();

        public static string pmdsRelease = "Release 4";
        public static int pmdsDBVersion = 41000;
        public static string StartupTyp = "";                       //Mit welchem Paramter ?typ wurde gestartet
        public static string typRechNr = "Standard";
        public static string MainCaption = "PMDS";
        public static PMDS.db.Entities.Benutzer ActiveUser;

        public static string MedikamenteImportType = "ftp";         //oder file, oder service
        public static string ApoToken = "";                         //bei service
        public static bool ApoZusatzdaten;                             //oder file, oder service
        public static string ApoKHIX = "165664200";                   //"165663200" = Modul L, "165664200" = Modul L + A;;
        public static string ftpFileImportMedikamente = "";         //bei file
        public static string ftpUserName = "";                      //bei ftp
        public static string ftpPassword = "";                      //bei ftp

        public static string ImportBefundeVerzeichnis = "";
        public static string ImportBefundeArchivOrdner = "";
        public static string BerufsstandArzt = "";
        public static string BerufsstandPflege = "";
        public static string BerufsstandTherapie = "";

        public static string StrgDefaults = "";     //StrgDefaults=DekursMVB=1|00000000-0000-0000-0000-000000000000,11111111-00000-0000-0000-000000000000;DekursIntervention=1| .....
                                                    //Objekt=Gegenzeichnen|WichtigFür,WichtigFür;Objekt=Gegenzeichnen|WichtigFür,WichtigFür, ....
        public static string PathDokumente = "";

        public static bool ProxyJN;
        public static string ProxyDomain = "";
        public static string ProxyHost = "";
        public static int ProxyPort = 0;
        public static string ProxyAuthentication = "";
        public static string ProxyUserName = "";
        public static string ProxyPassword = "";

        public static int AsynCommCheckMessagesSeconds = 300;

        private static ConfigFile _ConfigFile;
        private static ConfigFile _ConfigFileUser;
        private static Log _Log;
        public static string sConfigFile = "";
        public static string sRootDir = "";
        public static string sConfigRootDir = "";                //<20120118>, beschreibbare Pfade ins %ALLUSERPROFILES% 
        public static string SimpleInstall = "";
        public static string StartFromShare = "";
        public static bool DoOrigPathConfig;

        public static string ConfigFileLauncher = "";
        public static string LauncherExe = "";

        public static string path_bin = "";

        public static string OrigConfigDir = "";
        public static string OrigConfigFile = "";

        public static string TypeRessourcesRun = "";
        public static bool DoNotShowRessources;
        public static bool AutoAddNewRessources;
        public static bool IntDeactivated = true;

        public static bool adminSecure;
        public static bool LoggedInAsSuperUser;

        public static bool SpellCheckerOn;
        public static bool FullEditMode;
        public static uint AssessmentModifyTime = 24;
        public static bool UseDekursKopieren = true;
        public static bool CheckScreenSize;
        public static string frmRechnung = "rechnung.rtf";

        public static PasswordScore PasswordStrength = PasswordScore.Blank;
        public static int MaxPasswordAge;
        public static uint MaxIdleTime;
        public static bool IgnoreMaxIdleTime;
        public static int AutoCloseTime = 120;  //min = 10, max = 720)
        public static int ToleranzIntervall;

        public static string LoginInNameFrei = "";
        public static bool APVDA;

        public static string HAG_Url = "https://edi2.bewohnervertretung.at/api/xmlmapper";
        public static string HAG_Zertifikat = "BIDS EDI Certificate - IK:ER - Id:25";
        public static string HAG_USER = "";
        public static string HAG_PASSWORD = "";
        public static string HAG_PASSWORD_TMP = "";         //Passwort, das der User für die HAG-Meldung eingegeben hat. Merken, damit es nicht mehrfach eingegeben werden muss

        public static string ZahlKondBankeinzug = "Wir haben uns erlaubt, obigen Rechnungsbetrag von Ihrem Konto {0} einzuziehen.";
        public static string ZahlKondErlagschein = "Wir ersuchen um Überweisung des Rechnungsbetrags mittels beiliegendem Erlagschein auf unser Konto.";
        public static string ZahlKondÜberweisung = "Wir ersuchen um Überweisung des Rechnungsbetrags auf unser Konto.";
        public static string ZahlKondBar = "Betrag dankend erhalten.";
        public static string ZahlKondFSW = "Bitte nicht einzahlen, Überweisung erfolgt durch den FSW.";
        public static string TextKlientenInfo = "Information zu Kosten für erbrachte Leistungen";
        public static int BMDExportTyp = 2;
        public static string BMDExportPath = Path.GetTempPath();    //Default-Pfad für BMD-Excel-Export
        public static bool CalcAutoLoadKlienten = true;

        public static string FSW_FiBuKonto = "";
        public static string FSW_FTPUser = "";
        public static string FSW_FTPIP = "";
        public static int FSW_FTPPort = 22;
        public static string FSW_FTPZertifikat = "";
        public static string FSW_FTPMode = "Test";

        public static bool AbwesenheitenAnzeigen = true;

        public static bool CheckConnectionAndPassword;
        public static bool WundtherapieVidieren;
        public static uint WundbildModifyTime = 24;
        public static uint WundverlaufModifyTime = 24;
        public static uint WundtherapieModifyTime = 24;

        public static bool ActivateKliententermine;
        public static bool ActivateBereichstermine;
        public static bool AcceptNoPBS;              //Abweseneheiten ohne PBS/PSB beginnen erlauben. Standard = nein.

        private static ResourceManager _resources;

        public static int ELGAStatusGreen = 240;
        public static int ELGAStatusYellow = 30;
        public static int ELGAStatusRed = 10;
        public static string ELGAUser = "s2-engineering";
        public static string ELGAPwd = "KLqHC0hznj91OH0PiCIWBw==";
        public static string ELGACommunityDomain = "1.3.6.1.4.1.48288.2.990.2";     //Tiany CPID (Domäne der Tiany in ELGA)

        //tian -Spielwiese
        //public static System.ServiceModel.EndpointAddress ELGAUrl = new System.ServiceModel.EndpointAddress(new Uri("http://hnelga01.tiani-spirit.com:8181/SpiritEhrWsRemoting/EhrWSRemoting"));

        //Migrationsumgebung ohne Proxy
        //public static System.ServiceModel.EndpointAddress ELGAUrl = new System.ServiceModel.EndpointAddress(new Uri("http://10.2.13.91:8181/SpiritEhrWsRemoting/EhrWSRemoting"));

        //Migrationsumgebung mit Proxy
        public static System.ServiceModel.EndpointAddress ELGAUrl = new System.ServiceModel.EndpointAddress(new Uri("http://10.2.13.90:80/SpiritEhrWsRemoting/EhrWSRemoting"));

        public static string ELGAUrlGDAIndex = "http://10.2.13.90:80/GdaIndexWs";


        public static int MedVerabreichenDefault = -1;
        public static bool UseEinzelverordnungMax24;
        public static bool UseMediaktionVidieren;

        public static bool SavePflegebegleitschreibenToArchiv = true;

        private static bool _AbteilungRMOptional;	            // Flag ob der Rückmeldetext für die Abteilung Optional ist oder nicht
        private static string _dbUser = "";
        private static string _dbPassword = "";
        private static string _dbPassword_Encrpyted = "";

        private static string _dbServer = "";
        private static string _dbDatabase = "";
        private static string _IntegratedSecurity = "";

        private static string _dbUser_PEP = "";                           //Peps-Berichte
        private static string _dbPassword_PEP = "";
        private static string _dbServer_PEP = "";
        private static string _dbDatabase_PEP = "";
        private static string _IntegratedSecurity_PEP = "";

        public static string DSNGiboDat = "";

        public static bool doPatientFromTermineBereich;

        private static bool _demoversion;			            // verspeichert ob es sich um eine Demoversion handelt oder nicht

        public static bool _InitInProgress;

        private static readonly string[] _WeekDaysMoStart = { "Mo", "Di", "Mi", "Do", "Fr", "Sa", "So" }; // Wochentage als Text

        private static string _ReportPath = "";                           // Der basispfad für die Reports
        private static string _ReportConfigPath = "";                     // Pfad für die Config-Dateien der Reports. Beschreibbar, daher ins %ALLUSERSPROFILE%
        private static string _DynReportPath = "";                        // Der basispfad für Dynamische Reports (Berichte aus der Klientenansicht)
        private static string _LOGPATH = "";                              // Der basispfad für Dynamische Reports (Berichte aus der Klientenansicht)
        private static string _DynReportNotfallBasePath = "";             // Der basispfad für Dynamische Reports der Standardprozeduren
        private static string _DynReportExtrasPath = "";                  // Der basispfad für Dynamische Reports (Berichte aus dem Menü Extras heraus)
        private static string _DynReportPEP = "";
        private static string _ReportPathDatenerhebung = "";


        private static string _DynReportWundePath = "";                   // Der basispfad für Dynamische Reports (Wunde - aus Wunddoku heraus)
        public static string Image_Path = "";
        public static string DYNREPORTABRECHNUNGPATH = "";
        public static string DYNREPORTMEDIKAMENTEPATH = "";

        private static string _ArchivPath = "";
        private static string _RptConfigPath = "";

        public static string pathConfig = "";
        public static string pathForms = "";
        public static string exeConfig = "";

        public static string path_BiografieVorlagen = "";
        public static string path_Temp = "";

        public static bool WCFServiceOnOff;
        public static bool WCFServiceDebugMode;
        public static bool WCFServiceOnlyLocal;
        public static string WCFHostManager = "WCFHostManager";
        public static string WCFServicePMDSDebugPath = "";

        public static string SchnellrückmeldungAsProcess = "0";

        public static string DekursRegex = "";
        public static string DekursRegexBeschreibung = "";

        public static string License = "";

        public static EvaluierungsTypen EvaluierungsTyp = EvaluierungsTypen.Ziel;   // Legt den Evaluierungstyp für das gesamtsystem fest
        public static bool InterventionenEvaluieren = false;
        public static bool ShowAufnahmeButton;                              // Signalisiert ob der Aufnahmebutton gezeigt werden soll oder nicht
        public static uint RezeptModifyTime;
        public static bool RezeptUseTimeOfDay;
        public static bool RezeptUseErstattungscode = true;
        public static int RezeptanforderungZeitraum = -7;

        public static bool OnlyOneFavoritenComboinPlanung = true;
        public static bool BezugspersonenJN;
        public static string MedikamenteAbgebenTabText = "Medikamente verabreichen";

        private static bool _RechFloskel;
        private static bool _KuerzungGrundleistungLetzterTag;
        private static string _ZAHLUNG_TAGE;
        private static bool _bookingJN;
        private static int _TageOhneKuerzungGrundleistung;
        public static bool RechErwAbwesenheit;
        public static bool SrErwAbwesenheit;

        public static string GSBGTxt = "";
        public static string TransferTxt = "";
        public static string DepotgeldKontoTxt = "";
        public static string RechTitelDepotGeld = "Abrechnung für Barauslagen";

        public static string MailServiceCenter = "ServiceCenter@s2-engineering.com;";
        public static string eMailStammdaten = "";
        public static bool AbwesenheitenMinimalUI;

        public static bool DicomViewerFileOnly = true;

        public static Guid FSW_IDIntern = Guid.Empty;           //Guid des Kostenträgers FSW
        public static string FSW_SenderAdresse = "000000000";   //9-stellige Senderadresse
        public static string FSW_EZAUF = Path.GetTempPath();    //Default-Pfad für FSW-EZAUF-XML-Datei
        public static decimal FSW_Prozent = 4M;
        public static bool FSW_SaveXLSX = false;
        public static bool FSW_SupressSubKostentraeger = true;
        public static bool ForceUniqueFiBu = true;

        public static string ELDA_Pfad = Path.GetTempPath();    //Default-Pfad für FSW-EZAUF-XML-Datei

        // ---------- Lizenzschalter ------------------
        public static int lic_eMailBewerber;
        public static bool lic_VO;
        public static bool lic_VOLager;
        public static bool lic_WundtherapieOffenWarnung;
        public static bool lic_ELGA;
        public static bool lic_ELGA_PSB;
        public static bool lic_RezepteintragStorno;
        public static bool lic_ELDA;
        public static bool lic_PflegestufenEinschätzung;
        //---------------------------------------------

        // ------------- ELGA - Formatter für override  ---------------------
        public static XmlIts1Formatter ELGAFormatter { get; set; } = new XmlIts1Formatter();


        public static bool RechnungKopfzeileEin;
        public static bool RechnungBankdaten = true;

        private static bool _ShowPPToolTip = true;                 // Ob der Tooltip im Pflegeplanbutton angezeigt werden soll oder nicht
        public static int _PPToolTipDelay = 1000;                 // Verzögerung zum aufklappen
        public static int _PPToolTipDuration = 50000;                // Anzeigedauer

        private static PflegeModelle[] _aPflegeModell = new PflegeModelle[] { };         // PflegeModelle.Orem,  PflegeModelle.Krohwinkel



        public delegate void dMainWindowResizedDelegate(Size sMainWindow);
        public static event dMainWindowResizedDelegate dMainWindowResized;
        public static Size LastSizeMainWindow;
        public static event EventHandler UserLoggedOn;
        public static event EventHandler QuickFilterChanged;
        public static event ENVPatientIDChangedDelegate ENVPatientIDChanged;
        public static event EventHandler MedizinDatenChanged;
        public static event MedizinischeDatenStateChangedDelegate MedizinischerStateChanged;  // Wird aufgerufen wenn sich irgendwo der Status eines Medizinischen Typen ändert
        public static event PflegePlanChangedDelegate PflegePlanChanged;          // Änderung des PflegePlanes signalisieren
        public static event EventHandler NotfallChanged;             // Signalisiert dass sich in der Konfiguraton des Notfalls was geändert hat
        public static event ENVNeuerPatientDelegate NeuerPatient;               // Signalisiert dass ein neuer Klient hinzugefügt wurde
        public static event EventHandler KlientChanged;              // Signalisiert das speicher der Klientnenifos
        public static event CurrentQuickFilterChangedDelegate CurrentQuickFilterChanged;  // Signalisiert dass ein Quickfilter in der Oberfläche gedrückt wurde

        public static string COMMANDLINE_USER = "";                                             // Wenn über die Commandozeile ein Benutzer übergeben wird wird er hier verspeichert
        public static string COMMANDLINE_PWD = "";
        public static bool COMMANDLINE_bshowSplash = true;

        public static event MedizinischeDatenLayoutChangedDelegate MedizinischeDatenLayoutChanged;
        public static event ENVPatientDatenChangedDelegate ENVPatientDatenChanged;
        public static event AuswahlGruppeListChangedDelegate AuswahlGruppeListChanged;

        public delegate void BezugsPflegerChangedDelegate();
        public static event BezugsPflegerChangedDelegate BezugsPflegerChanged;

        public delegate void benutzerSMTPDatenSpeichernDelegate(System.Guid IDBenutzer);
        public static benutzerSMTPDatenSpeichernDelegate evBenutzerSMTPDatenSpeichern;

        public static System.Guid idManBuch = new System.Guid("00000000-0000-0000-0020-000000000000");

        public static event ZusatzeintragChangedDelegate ZusatzeintragChanged;

        public static event sendMainChangedDelegate sendMainChanged;
        public static event selKlientenDelegate selKlienten;
        public static event dAbtBereichPickerValueChanged deldAbtBereichPickerValueChanged;
        public static event dPatientenUersPickerValueChanged delPatientenUersPickerValueChanged;

        public static event klinikChanged evklinikChanged;


        public class eCallMainFctPlan
        {
            public DataSet ds = null;
            public string DekursTxt = "";
            public System.Collections.Generic.List<cDekursinfo> lstDekursInfo = new List<cDekursinfo>();

            public string ViewMode = "";
            public string Title = "";
            public Guid IDKlinik = System.Guid.Empty;
            public Guid IDAbteilung = System.Guid.Empty;
            public Guid IDBereich = System.Guid.Empty;
            public Nullable<DateTime> dFrom = null;
            public Nullable<DateTime> dTo = null;
            public string UserLoggedOn = "";
            public string lstKlients = "";
            public string lstUsers = "";
            public string lstCategories = "";
            public string Quickbutton = "";
        }
        public class cDekursinfo
        {
            public Guid ID;
            public string Txt = "";
        }






        private static Guid _CurrentIDPatient = Guid.Empty;
        private static Guid _SelectedAufenthalt;
        private static Guid _CurrentIDAbteilung = Guid.Empty;
        private static Guid _CurrentIDBereich = Guid.Empty;
        private static Guid _IDBereich = System.Guid.Empty;
        private static Ansichtinfo _Ansichtinfo = new Ansichtinfo();


        public static Guid _IDKlinikNoKlinikSelected = new System.Guid("094b644b-92e5-4711-aad8-912bf4660909");
        public static Guid _IDKlinik = _IDKlinikNoKlinikSelected;

        private static Guid _userid;
        public static Nullable<Guid> IDAnmeldungen = null;
        private static Guid _abteilung;
        private static Guid _berufID;
        private static PMDS.Global.db.Patient.dsGruppe _rights = null;
        public static string UsrPwdEnc;


        private static Guid _CurrentIDBezugsPfleger = Guid.Empty;
        private static Guid _CurrentIDEvaluierung = Guid.Empty;
        private static List<Guid> _CurrentUserAbteilungen = new List<Guid>(); // Speichert die Abteilungen welche für den gerade angemeldeten Benutzer gültig sind 	           

        public class cParsSendException
        {
            public string sException = "";
            public string client = "";
            public string user = "";
            public string haus = "";
            public DateTime At;

        }











        public static Guid CurrentIDPatient
        {
            get { return ENV._CurrentIDPatient; }

        }
        public static Guid setCurrentIDPatient
        {
            set
            {
                ENV._CurrentIDPatient = value;
                if (_InitInProgress)
                    return;
            }
        }

        public static Guid IDAUFENTHALT
        {
            get { return ENV._SelectedAufenthalt; }
        }
        public static Guid setIDAUFENTHALT
        {
            set { ENV._SelectedAufenthalt = value; }
        }

        public static Guid CurrentIDBereich
        {
            get { return ENV._CurrentIDBereich; }
        }
        public static Guid setCurrentIDBereich
        {
            set { ENV._CurrentIDBereich = value; }
        }

        public static Guid IDBereich
        {
            get { return ENV._IDBereich; }
         
        }
        public static Guid setIDBereich
        {
            set { ENV._IDBereich = value; }
        }

        public static Guid CurrentIDAbteilung
        {
            get { return ENV._CurrentIDAbteilung; }
        }
        public static Guid setCurrentIDAbteilung
        {
            set { ENV._CurrentIDAbteilung = value; }
        }


        public static TerminlisteAnsichtsmodi AnsichtsModus
        {
            get { return ENV.CurrentAnsichtinfo.Ansichtsmodus; }
            set { ENV.CurrentAnsichtinfo.Ansichtsmodus = value; }
        }
        public static Ansichtinfo CurrentAnsichtinfo
        {
            get { return ENV._Ansichtinfo; }
        }




        public static Guid USERID
        {
            get { return ENV._userid; }
        }
        public static Guid setUSERID
        {
            set { ENV._userid = value; }
        }

        public static Guid ABTEILUNG
        {
            get { return ENV._abteilung; }
            set { ENV._abteilung = value; }
        }
        public static Guid BERUFID
        {
            get { return ENV._berufID; }
        }
        public static Guid IDKlinik
        {
            get
            {
                if (ENV._IDKlinik == _IDKlinikNoKlinikSelected)
                {
                    throw new NotSupportedException("ENV.IDKlinik: No Klinik selected!");
                }
                return ENV._IDKlinik;
            }
            set { ENV._IDKlinik = value; }
        }
        public static Guid IDKlinikNoKlinikSelected
        {
            get { return ENV._IDKlinikNoKlinikSelected; }
        }

        
                     














        public static string getAdditionalFolder()
        {
            return !ENV.SimpleInstall.sEquals("1") ? "PMDS" : "";
        }

        public static bool CallFctMainSystem(PMDS.Calc.Logic.calculation.eTypeMainFct TypeMainFct, ref PMDS.Calc.Logic.calculation.retMainSystem retMainSystem1)
        {
            try
            {
                if (TypeMainFct == Calc.Logic.calculation.eTypeMainFct.getIDKlinik)
                {
                    retMainSystem1.ID = ENV.IDKlinik;
                }
                else if (TypeMainFct == Calc.Logic.calculation.eTypeMainFct.NewRowBillEF)
                {
                    retMainSystem1.rBill = PMDS.Global.db.ERSystem.EFEntities.newbills(retMainSystem1.db);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ENV.CallFctMainSystem: " + ex.ToString());
            }
        }

        // ------ ELGA-Formatters müssen in der ENV static sein (Threading)
        [Structure(Name = "ObservationMedia", StructureType = StructureAttribute.StructureAttributeType.MessageType, IsEntryPoint = false, Model = "POCD_MT000040UV", Publisher = "Copyright (C)2011, Health Level Seven")]
        public class ELGAObservationMedia : ObservationMedia
        {
            [Property(Name = "ID", Conformance = PropertyAttribute.AttributeConformanceType.Populated, PropertyType = PropertyAttribute.AttributeAttributeType.Structural)]
            public ST ID { get; set; }
        }

        public static void initELGAFormatter()
        {
            ELGAFormatter.ValidateConformance = false;
            ELGAFormatter.GraphAides.Add(new DatatypeFormatter() { CompatibilityMode = DatatypeFormatterCompatibilityMode.ClinicalDocumentArchitecture });
            ELGAFormatter.ValidateConformance = false;
            ELGAFormatter.RegisterXSITypeName("POCD_MT000040UV.ObservationMedia", typeof(ELGAObservationMedia));
            ELGAFormatter.Settings |= SettingsType.AlwaysCheckForOverrides;
        }

        public static void initClass(string LogPathPMDSFromLauncher)
        {
            ENV.sRootDir = System.IO.Directory.GetParent(Application.StartupPath).ToString();    //Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\"));
            ENV.path_bin = Application.StartupPath;

            if (System.String.IsNullOrWhiteSpace(LogPathPMDSFromLauncher.Trim()))
            {
                if (ENV.StartFromShare.Trim() == "0")
                {
                    ENV.LOGPATH = LogPathPMDSFromLauncher;
                }
                else
                {
                    ENV.LOGPATH = System.IO.Path.Combine(ENV.sConfigRootDir, ENV.getAdditionalFolder(), "Log");
                }
            }
            else
            {
                ENV.LOGPATH = LogPathPMDSFromLauncher;
            }
            ENV.check_Path(ENV.LOGPATH, true);

            if (ENV.StartFromShare.Trim() == "0" || ENV.DoOrigPathConfig)
            {
                ENV.pathConfig = ENV.sConfigRootDir;
            }
            else
            {
                ENV.pathConfig = System.IO.Path.Combine(ENV.sConfigRootDir, ENV.getAdditionalFolder(), System.IO.Path.GetFileName(ENV.sRootDir), "Config");
            }
            ENV.check_Path(ENV.pathConfig, true);

            ENV.sConfigFile = System.IO.Path.Combine(ENV.pathConfig, "PMDS.Config");

            ENV.exeConfig = System.IO.Path.Combine(ENV.path_bin, "PMDS.Main.exe.config");
            ENV.check_File(ENV.exeConfig);
        }

        private static void SignalBezugsPflegerChanged()
        {
            if (BezugsPflegerChanged != null)
                BezugsPflegerChanged();
        }

        public static void SignalNotfallChanged(object sender, EventArgs args)
        {
            NotfallChanged?.Invoke(sender, args);
        }

        public static void SignalZusatzeintragChanged(bool changed)
        {
            if (ZusatzeintragChanged != null)
                ZusatzeintragChanged(changed);
        }

        public static void SignalMainChanged(eSendMain typ, cParDelegSendMain ParDelegSendMain)
        {
            if (sendMainChanged != null)
                sendMainChanged(typ, ParDelegSendMain);
        }
        public static bool selKlientenChanged(eSendMain typ, System.Collections.Generic.List<string> filterString, bool suche, object obj)
        {
            if (selKlienten != null)
                return selKlienten(typ, filterString, suche, obj);
            return false;
        }

        public static void SignalNeuerPatient(Guid IDPatient)
        {
            if (NeuerPatient != null)
                NeuerPatient(IDPatient);
        }
        public static void SignalKlientChanged()
        {
            if (KlientChanged != null)
                KlientChanged(null, EventArgs.Empty);
        }

        public static void fireEventKlinikChanged(dsKlinik.KlinikRow rSelectedKlinik, bool allKliniken)
        {
            if (evklinikChanged != null)
                evklinikChanged.Invoke(rSelectedKlinik, allKliniken);
        }

        public static void AbtBereichPickerValueChanged(Nullable<Guid> IDKlinik, Nullable<Guid> IDAbteilung, Nullable<Guid> IDBereich, UltraTreeNode treeNode)
        {
            if (deldAbtBereichPickerValueChanged != null)
                deldAbtBereichPickerValueChanged.Invoke(IDKlinik, IDAbteilung, IDBereich, treeNode);
        }

        public static void PatientenUersPickerValueChanged(Nullable<Guid> IDKlinik, Nullable<Guid> IDAbteilung, Nullable<Guid> IDBereich, System.Collections.Generic.List<Guid> lstSelectedUsersPatients, UltraTreeNode treeNode,
                                                             PMDS.Global.eTypePatientenUserPickerChanged TypePatientenUserPickerChanged)
        {
            if (delPatientenUersPickerValueChanged != null)
                delPatientenUersPickerValueChanged.Invoke(IDKlinik, IDAbteilung, IDBereich, lstSelectedUsersPatients, treeNode, TypePatientenUserPickerChanged);
        }

        public static Guid CurrentIDBezugsPfleger
        {
            get { return ENV._CurrentIDBezugsPfleger; }
            set
            {
                if (ENV._CurrentIDBezugsPfleger != value)
                {
                    ENV._CurrentIDBezugsPfleger = value;
                    SignalBezugsPflegerChanged();
                }
            }
        }

        public static string[] WochentagekurzMoBeginnend
        {
            get {return _WeekDaysMoStart; }
        }

        public static List<Guid> CurrentUserAbteilungen
        {
            get { return ENV._CurrentUserAbteilungen; }
        }
        
        public static PflegeModelle[] PflegeModell
        {
            get { return ENV._aPflegeModell; }
            set { ENV._aPflegeModell = value; }
        }

        //------------------------------ Signale ----------------------------
        public static void SignalMedizinDatenChanged()
        {
            if (MedizinDatenChanged != null)
                MedizinDatenChanged(null, EventArgs.Empty);
        }

        public static void SignalPflegePlanChanged(Guid IDAufenthalt)
        {
            if (PflegePlanChanged != null)
                PflegePlanChanged(IDAufenthalt);
        }

        public static void SignalMedizinischerStateChanged(int iMedizinischerTyp)
        {
            if (MedizinischerStateChanged != null)
                MedizinischerStateChanged(iMedizinischerTyp);
        }

        public static void SignalMedizinischeDatenLayoutChanged()
        {
            if (MedizinischeDatenLayoutChanged != null)
                MedizinischeDatenLayoutChanged();
        }

        public static void fMainWindowResized(Size sMainWindow)
        {
            ENV.LastSizeMainWindow = sMainWindow;
            dMainWindowResized?.Invoke(sMainWindow);
        }

        public static void SignalPatientDatenChanged(Guid IDPatient)
        {
            if (ENVPatientDatenChanged != null)
                ENVPatientDatenChanged(IDPatient);
        }

        public static void SignalAuswahlGruppeListChanged(string Grop)
        {
            if (AuswahlGruppeListChanged != null)
                AuswahlGruppeListChanged(Grop);
        }

        public static void setStyleInfrag(bool bOn)
        {

            Infragistics.Win.AppStyling.StyleManager.Reset();

            if (bOn && System.IO.File.Exists(System.IO.Path.Combine(ENV.pathConfig, "PMDS.isl")))
                    Infragistics.Win.AppStyling.StyleManager.Load(System.IO.Path.Combine(ENV.pathConfig, "pmds.isl")); 
        }

        //-------------------------------- Properties -------------------------------------

        public static Guid CurrentIDEvaluierung
        {
            get { return ENV._CurrentIDEvaluierung; }
            set { ENV._CurrentIDEvaluierung = value; }
        }

        public static bool ShowPPToolTip
        {
            get { return ENV._ShowPPToolTip; }
            set { ENV._ShowPPToolTip = value; }
        }


        public static string DynReportPath
        {
            get { return ENV._DynReportPath;  }
            set { ENV._DynReportPath = value; }
        }

        public static string LOGPATH
        {
            get
            {
                if (_LOGPATH.Length == 0)
                {
                    string sPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "pmdsLog");
                    if (!System.IO.Directory.Exists(sPath)) 
                        System.IO.Directory.CreateDirectory(sPath);
                    return sPath;
                }
                else
                    return ENV._LOGPATH;
            }
            set { ENV._LOGPATH = value; }
        }

        public static string DynReportExtrasPath
        {
            get { return (_DynReportExtrasPath.Length == 0 ? DynReportPath : ENV._DynReportExtrasPath); }
            set { ENV._DynReportExtrasPath = value; }
        }

        public static string DynReportsPEP
        {
            get { return (_DynReportPEP.Length == 0 ? _DynReportPEP : ENV._DynReportPEP); }
            set { ENV._DynReportPEP = value; }
        }

        public static string DynReportWundePath
        {
            get { return (_DynReportWundePath.Length == 0 ? DynReportPath : ENV._DynReportWundePath); }
            set { ENV._DynReportWundePath = value; }
        }

        public static string DynReportNotfallBasePath
        {
            get { return ENV._DynReportNotfallBasePath;  }
            set { ENV._DynReportNotfallBasePath = value; }
        }

        public static string ReportPath
        {
            get { return ENV._ReportPath;  }
            set { ENV._ReportPath = value; }
        }
        public static string ReportPathDatenerhebung
        {
            get { return ENV._ReportPathDatenerhebung; }
            set { ENV._ReportPathDatenerhebung = value; }
        }

        public static string ReportConfigPath
        {
            get { return ENV._ReportConfigPath;  }
            set { ENV._ReportConfigPath = value; }
        }

        public static string ArchivPath
        {
            get { return ENV._ArchivPath; }
            set { ENV._ArchivPath = value; }
        }

        public static string RptConfigPath
        {
            get { return ENV._RptConfigPath; }
            set { ENV._RptConfigPath = value; }
        }

        public static bool RechFloskel
        {
            get { return ENV._RechFloskel; }
            set { ENV._RechFloskel = value; }
        }

        public static bool KuerzungGrundleistungLetzterTag
        {
            get { return ENV._KuerzungGrundleistungLetzterTag; }
            set { ENV._KuerzungGrundleistungLetzterTag = value; }
        }

        public static string ZAHLUNG_TAGE
        {
            get { return ENV._ZAHLUNG_TAGE; }
            set { ENV._ZAHLUNG_TAGE = value; }
        }

        public static int TageOhneKuerzungGrundleistung
        {
            get { return ENV._TageOhneKuerzungGrundleistung; }
            set { ENV._TageOhneKuerzungGrundleistung = value; }
        }

        public static bool bookingJN
        {
            get { return ENV._bookingJN; }
            set { ENV._bookingJN = value; }
        }


        static ENV()
        {
            Res r = new Res();
            _resources = new ResourceManager("PMDS.Global.PMDSResource", Assembly.GetAssembly(typeof(Res)));
        }

        public static void sendPatientChanged(eCurrentPatientChange typ, bool refreshPicker, bool clickGridTermine)
        {
            if (ENVPatientIDChanged != null)
                ENVPatientIDChanged(ENV.CurrentIDPatient, typ, refreshPicker, clickGridTermine);
        }

        public static bool DEMO
        {
            get { return _demoversion; }
        }

        public static DialogResult AskForSave()
        {
            DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"),
                                                                                        ENV.String("VERWALTUNG.DIALOGTITLE_SAVECHANGES"),
                                                                                        MessageBoxButtons.YesNo,
                                                                                        MessageBoxIcon.Question, true);    
            return res;
        }

        public static string SpenderTypText(SpenderTyp s)
        {
            switch (s)
            {
                case SpenderTyp.Einzelspender:
                    return ENV.String("EINZELSPENDER");
                case SpenderTyp.Wochenspender:
                    return ENV.String("WOCHENSPENDER");
                case SpenderTyp.Tagesspender:
                    return ENV.String("TAGESSPENDER");
            }
            return "*** Spendertyp ****  " + s.ToString() + " not defined - ENV.SpenderTypText";
        }

        public static void UserWithAbteilungLoggedOn(
            Guid idUser,
            Guid idBeruf,
            PMDS.Global.db.Patient.dsGruppe rights,
            bool isPfleger)
        {
            ENV.setUSERID = idUser;
            _berufID = idBeruf;
            _rights = rights;

            OnUserLoggedOn(null);
        }

        public static bool ABTEILUNG_RMOPTIONAL
        {
            get { return _AbteilungRMOptional; }
            set { _AbteilungRMOptional = value; }
        }

        public static string DB_USER
        {
            get { return _dbUser; }
        }

        public static string DB_PASSWORD
        {
            get { return _dbPassword; }
        }

        public static string DB_SERVER
        {
            get { return _dbServer; }
        }

        public static string DB_DATABASE
        {
            get { return _dbDatabase; }
        }

        public static string INTEGRATED_SECURITY
        {
            get { return _IntegratedSecurity; }
        }

        public static string DB_USER_PEP
        {
            get { return _dbUser_PEP; }
        }

        public static string DB_PASSWORD_PEP
        {
            get { return _dbPassword_PEP; }
        }

        public static string DB_SERVER_PEP
        {
            get { return _dbServer_PEP; }
        }

        public static string DB_DATABASE_PEP
        {
            get { return _dbDatabase_PEP; }
        }

        public static string INTEGRATED_SECURITY_PEP
        {
            get { return _IntegratedSecurity_PEP; }
        }

        public static string getPmdsVersion()
        {
            try
            {
                return "PMDS Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + " " + PMDS.Global.ENV.pmdsRelease; ;
            }
            catch (Exception exch)
            {
                return "";
            }
        }

        public static string getPmdsDBVersion()
        {
            try
            {
                return "Datenbank Version: " + PMDS.Global.ENV.pmdsDBVersion.ToString();
            }
            catch (Exception exch)
            {
                return "";
            }
        }

        public static string getPmdsDB
        {
            get {
                string DBInfo = "PMDS Database: " + DataBase.CONNECTION.DataSource + ":" + DataBase.CONNECTION.Database + "\r\n";
                DBInfo += "QS2 Database: " + qs2.core.dbBase.Server.Trim() + ":" + qs2.core.dbBase.Database.Trim() + "\r\n";
                if (ENV.DB_SERVER_PEP != null)
                    DBInfo += "PEP Database: " + ENV._dbServer_PEP.Trim() + "." + ENV._dbDatabase_PEP.Trim() + "\r\n";
                if (ENV.conGiboDat != null)
                {
                    DBInfo += "GiboDat Database: " + ENV.conGiboDat.DataSource.Trim() + "." + ENV.conGiboDat.Database.Trim() + "";
                }
                
                return DBInfo;
            }
        }

        public static void SignalQuickfilterChanged(object sender)
        {
            if (QuickFilterChanged != null)
                QuickFilterChanged(sender, null);
        }

        public static void OnUserLoggedOn(object sender)
        {
            if (UserLoggedOn != null)
                UserLoggedOn(sender, null);
        }

        public static bool HasRight(UserRights right)
        {
            if (ENV.adminSecure)
            {
                return true;
            }
            else
            {
                if (ENV._rights == null)
                {
                    return true;
                }
                else
                {
                    bool bHasRigth = false;
                    foreach (PMDS.Global.db.Patient.dsGruppe.GruppenRechtRow rRight in ENV._rights.GruppenRecht)
                    {
                        if (rRight.IDRecht == (int)right)
                        {
                            bHasRigth = true;
                            return true;
                        }
                    }

                    if (!bHasRigth && ENV.USERID != null && ENV.USERID != Guid.Empty)
                    {
                        int iRight = (int)right;
                        PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                        {
                            PMDS.db.Entities.BenutzerRechte rBenutzerRechteExists = PMDSBusiness1.getBenutzerRecht(db, ENV.USERID, iRight);
                            if (rBenutzerRechteExists != null)
                            {
                                return true;
                            }
                        }
                    }

                    return false;
                }
            }
        }
        public static bool HasRightUser(UserRights right, Guid IDUser)
        {
            int iRight = (int)right;
            PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
            {
                PMDS.db.Entities.BenutzerRechte rBenutzerRechteExists = PMDSBusiness1.getBenutzerRecht(db, IDUser, iRight);
                if (rBenutzerRechteExists != null)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool AppRunning { get; set; }

        private static bool CompareVersion(int iDBVersion, int iAppVersion)
        {
            if (iDBVersion == iAppVersion)
            {
                return true;
            }
            else
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("ERROR_MISSMATCH_DBVERSION", iDBVersion, iAppVersion), "", MessageBoxButtons.OK, MessageBoxIcon.Stop, true);
                return false;
            }
        }

        private static bool CkeckDBVersion()
        {
            try
            {
                return CompareVersion(PMDS.DB.DBUtil.GetDBVersion().Version, ENV.pmdsDBVersion);
            }
            catch (OleDbException ex)
            {
                ENV.HandleException(ex);
                return CompareVersion(0, ENV.pmdsDBVersion);
            }
        }

        private static void ShowLicenseMessage()
        {
            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("ERROR_MISSING_LICENCE"), "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }


        public static string MakeLicenseString(DateTime ValidThrough)
        {
            return RBUSF.MakeLicenseString(ValidThrough);
        }

        public static bool CheckLicense()
        {
            try
            {
                string sLizenz = PMDS.DB.DBUtil.GetDBLizenz().Lizenz;
                    if (sLizenz != "")
                    {
                   
                        sLizenz = RBUSF.Decrypt(sLizenz.Trim(), "12345678");
                        
                        string[] sa = sLizenz.Split(';');
                        if (sa.Length != 2)
                        {
                            ShowLicenseMessage();
                            return false;
                        }

                        _demoversion = sa[0] == "Y" ? true : false;
                        DateTime dt = new DateTime((long)Convert.ToInt64(sa[1]));
                        if (dt < DateTime.Now)
                        {
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Diese Version ist abgelaufen,\r\nbitte setzten Sie sich mit ihrem lokalen Administrator in Verbindung");
                            return false;
                        }

                        if (_demoversion)
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Diese Demoversion läuft am {0} ab"), dt.ToShortDateString()), true);

                        return true;
                    }
                    else
                    {
                        ShowLicenseMessage();
                        return false;
                    }
            }
            catch (OleDbException ex)
            {
                ENV.HandleException(ex);
                ShowLicenseMessage();
                return false;
            }
        }
        
        public static bool Init()
        {
            return Init(false);
        }

        public static bool Init(bool bOpenDatabaseOnly)
        {
            try
            {
                AppRunning = true;

                ENV.intSetupDirs();

                ConfigFile cfg;

                Log.RegisterStandardLog(LogDestinations.EventLog, "PMDS");					// Standard zum Eventlog

                cfg = new RBU.ConfigFile(PMDS.Global.ENV.sConfigFile);						// Konfigurationsdatei 
                _ConfigFile = cfg;

                _Log = Log.LOG;
                _Log.ConfigFile = _ConfigFile;

                _Log.ROLLOVERLIMIT = 5000000;												// Grenze auf 5MB heben

                _Log.Level = (LogLevels)0;
                _Log.Destination = (LogDestinations)2;
                _Log.LogFile = _ConfigFile.GetStringValue("LogFile");

                // DBUser und DBPassword verspeichern (Kommt entweder direkt aus dem OledbString oder wird {{{HIDDEN...}}} ersetzt durch PMSOwner
                NameValueCollection c = new NameValueCollection();

                //os: Änderung: Anmeldung mit DSNMain statt Connection-String-Eigenschaft
                string[] sa = _Log.ConfigFile.GetStringValue("DSNMain").Split(';');

                foreach (string s in sa)
                {
                    string[] sa1 = s.Split(new[] { "=" }, 2, StringSplitOptions.RemoveEmptyEntries);
                    if (sa1.Length > 1)
                        c.Add(sa1[0].ToLower().Trim(), sa1[1].Trim());
                }
                _dbUser = c["user id"];
                _dbPassword = c["password"];
                if (_dbPassword != null && (_dbPassword.EndsWith("=") || (_dbPassword.StartsWith("[[[") &&_dbPassword.EndsWith("]]]"))))      //os: Verschlüsseltes Passwort berücksichtigen
                {
                    if (_dbPassword.StartsWith("[[[") && _dbPassword.EndsWith("]]]"))
                    {
                        _dbPassword = _dbPassword.Substring(3, _dbPassword.Length - 3);
                    }
                    _dbPassword_Encrpyted = _dbPassword;
                    _dbPassword = PMDS.BusinessLogic.BUtil.DecryptString(_dbPassword.Trim());
                }
                _dbServer = c["data source"];
                _dbDatabase = c["initial catalog"];
                _IntegratedSecurity = c["integrated security"];

                DataBase.COMMANDTIMEOUT = 150;
                DataBase.SetUserAndPassword(_dbUser, _dbPassword, _dbPassword_Encrpyted);
                DataBase.Open();															// Generelles DB Objekt initialisieren

                //Connection-Settings aktualisieren (app.config)
                InsertERConnections();
            
                bool ERConnectOK = false;
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    ERConnectOK = true;
                }

                if (!ERConnectOK)
                    throw new Exception("Can not connect to ER-System!");

                //<20120229> Connection-Parameter für Pep-Berichte
                c = new NameValueCollection();
                sa = _Log.ConfigFile.GetStringValue("DSNMainPeps").Split(';');
                foreach (string s in sa)
                {
                    string[] sa1 = s.Split(new[] { "=" }, 2, StringSplitOptions.RemoveEmptyEntries);
                    if (sa1.Length > 1)
                        c.Add(sa1[0].ToLower(), sa1[1]);
                }

                _dbUser_PEP = c["user id"];
                _dbPassword_PEP = c["password"];
                if (_dbPassword != null && (_dbPassword.EndsWith("=") || (_dbPassword.StartsWith("[[[") && _dbPassword.EndsWith("]]]"))))      //os: Verschlüsseltes Passwort berücksichtigen
                {
                    if (_dbPassword.StartsWith("[[[") && _dbPassword.EndsWith("]]]"))
                    {
                        _dbPassword = _dbPassword.Substring(3, _dbPassword.Length - 3);
                    }
                    _dbPassword_Encrpyted = _dbPassword;
                    _dbPassword = PMDS.BusinessLogic.BUtil.DecryptString(_dbPassword.Trim());
                }
                _dbServer_PEP = c["data source"];
                _dbDatabase_PEP = c["initial catalog"];
                _IntegratedSecurity_PEP = c["integrated security"];

                if (ENV.StartupTyp == "auswpep")
                {
                    PMDS.Global.DBPep.ConnPep = new System.Data.OleDb.OleDbConnection();
                    PMDS.Global.DBPep.ConnPep.ConnectionString = _Log.ConfigFile.GetStringValue("DSNMainPeps");
                    PMDS.Global.DBPep.ConnPep.ConnectionString = PMDS.Global.DBPep.ConnPep.ConnectionString.Replace(_dbPassword_Encrpyted, _dbPassword);
                    PMDS.Global.DBPep.ConnPep.Open();
                }

                //------------------------------------------------------- ENV-Variablen aus Config lesen -------------------
                SetENVValue("adminSecure", ref ENV.adminSecure);
                SetENVValue("License", ref ENV.License, eTrim.yes, eDecrypt.PMDSMode);
                SetENVValue("TypeRessourcesRun", ref ENV.TypeRessourcesRun);
                SetENVValue("SchnellrueckmeldungAsProcess", ref ENV.SchnellrückmeldungAsProcess);

                SetENVValue("bookingJN", ref ENV._bookingJN);
                SetENVValue("typRechNr", ref ENV.typRechNr);
                SetENVValue("RechnungKopfzeileEin", ref ENV.RechnungKopfzeileEin);
                SetENVValue("RechnungBankdaten", ref ENV.RechnungBankdaten, "0");
                SetENVValue("RechFloskel", ref ENV._RechFloskel);
                SetENVValue("KuerzungGrundleistungLetzterTag", ref ENV._KuerzungGrundleistungLetzterTag);
                SetENVValue("TageOhneKuerzungGrundleistung", ref ENV._TageOhneKuerzungGrundleistung);
                SetENVValue("RechErwAbwesenheit", ref ENV.RechErwAbwesenheit);
                SetENVValue("SrErwAbwesenheit", ref ENV.SrErwAbwesenheit);
                SetENVValue("ZAHLUNG_TAGE", ref ENV._ZAHLUNG_TAGE);
                SetENVValue("GSBGTxt", ref ENV.GSBGTxt);
                SetENVValue("TransferTxt", ref ENV.TransferTxt);
                SetENVValue("DepotgeldKontoTxt", ref ENV.DepotgeldKontoTxt);
                SetENVValue("RechTitelDepotGeld", ref ENV.RechTitelDepotGeld);
                SetENVValue("ZahlKondBankeinzug", ref ENV.ZahlKondBankeinzug);
                SetENVValue("ZahlKondErlagschein", ref ENV.ZahlKondErlagschein);
                SetENVValue("ZahlKondÜberweisung", ref ENV.ZahlKondÜberweisung);
                SetENVValue("ZahlKondBar", ref ENV.ZahlKondBar);
                SetENVValue("ZahlKondFSW", ref ENV.ZahlKondFSW);
                SetENVValue("TextKlientenInfo", ref ENV.TextKlientenInfo);
                SetENVValue("BMDExportTyp", ref ENV.BMDExportTyp);
                SetENVValue("BMDExportPath", ref ENV.BMDExportPath);
                SetENVValue("CalcAutoLoadKlienten", ref ENV.CalcAutoLoadKlienten, "0");

                SetENVValue("FSW_FiBuKonto", ref ENV.FSW_FiBuKonto);
                SetENVValue("FSW_FTPUser", ref ENV.FSW_FTPUser);
                SetENVValue("FSW_FTPIP", ref ENV.FSW_FTPIP);
                SetENVValue("FSW_FTPPort", ref ENV.FSW_FTPPort);
                SetENVValue("FSW_FTPZertifikat", ref ENV.FSW_FTPZertifikat);
                SetENVValue("FSW_FTPMode", ref ENV.FSW_FTPMode);

                SetENVValue("AbwesenheitenAnzeigen", ref ENV.AbwesenheitenAnzeigen, "0");

                ENV.PflegeModell = ReadPflegemodelle();
                if (ENV.PflegeModell.Length == 0)
                {
                    System.Windows.Forms.MessageBox.Show("Kritischer Fehler beim Einlesen der Pflegemodelle!");
                    return false;
                }
                string stemp = "";
                SetENVValue("APVDA", ref stemp, eTrim.yes, eDecrypt.PMDSMode);
                ENV.APVDA = stemp == "1" ? true : false;

                SetENVValue("MedikamenteImportType", ref ENV.MedikamenteImportType);
                SetENVValue("ftpFileImportMedikamente", ref ENV.ftpFileImportMedikamente);
                SetENVValue("ftpUserName", ref ENV.ftpUserName);
                SetENVValue("ftpPassword", ref ENV.ftpPassword, eTrim.no, eDecrypt.PMDSMode);
                SetENVValue("ApoToken", ref ENV.ApoToken);
                SetENVValue("ApoZusatzdaten", ref ENV.ApoZusatzdaten);
                SetENVValue("ApoKHIX", ref ENV.ApoKHIX);

                SetENVValue("ProxyJN", ref ENV.ProxyJN);
                SetENVValue("ProxyUserName", ref ENV.ProxyUserName);
                SetENVValue("ProxyPassword", ref ENV.ProxyPassword, eTrim.no, eDecrypt.PMDSMode);
                SetENVValue("ProxyDomain", ref ENV.ProxyDomain);
                SetENVValue("ProxyHost", ref ENV.ProxyHost);
                SetENVValue("ProxyPort", ref ENV.ProxyPort);
                SetENVValue("ProxyAuthentication", ref ENV.ProxyAuthentication);

                SetENVValue("SMTPFrom", ref PMDS.Global.clSMTP.SMTPFrom);
                SetENVValue("SMTPTo", ref PMDS.Global.clSMTP.SMTPTo);
                SetENVValue("SMTPServer", ref PMDS.Global.clSMTP.SMTPServer);
                SetENVValue("SMTPLoginUsr", ref PMDS.Global.clSMTP.SMTPLoginUsr);
                SetENVValue("SMTPLoginPwd", ref PMDS.Global.clSMTP.SMTPLoginPwd, eTrim.no, eDecrypt.PMDSMode);
                SetENVValue("SMTPPort", ref PMDS.Global.clSMTP.SMTPPort);

                SetENVValue("RezeptanforderungZeitraum", ref ENV.RezeptanforderungZeitraum);
                SetENVValue("SHOW_AUFNAHMEBUTTON", ref ENV.ShowAufnahmeButton);     //In Config von ON|OFF auf 1|0 umstellen!!!  //ENV.ShowAufnahmeButton = _Log.ConfigFile.GetStringValue("SHOW_AUFNAHMEBUTTON") == "ON" ? true : false;

                SetENVValue("ELGAStatusGreen", ref ENV.ELGAStatusGreen);
                SetENVValue("ELGAStatusYellow", ref ENV.ELGAStatusYellow);
                SetENVValue("ELGAStatusRed", ref ENV.ELGAStatusRed);
                SetENVValue("ELGAUser", ref ENV.ELGAUser);
                SetENVValue("ELGAPwd", ref ENV.ELGAPwd, eTrim.no, eDecrypt.QS2Mode);
                SetENVValue("ELGAUrl", ref ELGAUrl);
                SetENVValue("ELGAUrlGDAIndex", ref ELGAUrlGDAIndex);

                SetENVValue("OnlyOneFavoritenComboinPlanung", ref ENV.OnlyOneFavoritenComboinPlanung, "0");
                SetENVValue("BezugspersonenJN", ref ENV.BezugspersonenJN);

                SetENVValue("DoNotShowRessources", ref ENV.DoNotShowRessources);
                qs2.core.vb.compLayout.DoNotShowRessources = ENV.DoNotShowRessources;

                SetENVValue("AsynCommCheckMessagesSeconds", ref ENV.AsynCommCheckMessagesSeconds);

                SetENVValue("AutoAddNewRessources", ref ENV.AutoAddNewRessources);
                SetENVValue("IntDeactivated", ref ENV.IntDeactivated, "0");

                SetENVValue("MedikamenteAbgebenTabText", ref ENV.MedikamenteAbgebenTabText);

                SetENVValue("ArchivPath", ref ENV._ArchivPath);
                if (!System.String.IsNullOrWhiteSpace(ENV.ArchivPath))
                {
                    PMDS.Global.ENV.check_Path(ENV.ArchivPath, true);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Der Wert ArchivPath in der Config-Datei muss angegeben werden!");
                    return false;
                }

                SetENVValue("RptConfigPath", ref ENV._ReportConfigPath);
                if (!System.String.IsNullOrWhiteSpace(ENV._ReportConfigPath))
                {
                    PMDS.Global.ENV.check_Path(ENV.ReportConfigPath, true);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Der Wert RptConfigPath in der Config-Datei muss angegeben werden!");
                    return false;                
                }

                SetENVValue("PathDokumente", ref ENV.PathDokumente);

                SetENVValue("DSNGiboDat", ref ENV.DSNGiboDat);
                if (!System.String.IsNullOrWhiteSpace(ENV.DSNGiboDat))
                {
                    ENV.conGiboDat = new System.Data.OleDb.OleDbConnection(ENV.DSNGiboDat);
                    ENV.conGiboDat.Open();
                }

                SetENVValue("SpellCheckerOn", ref ENV.SpellCheckerOn);
                SetENVValue("frmRechnung", ref ENV.frmRechnung);
                SetENVValue("FullEditMode", ref ENV.FullEditMode);
                SetENVValue("AssessmentModifyTime", ref ENV.AssessmentModifyTime);
                SetENVValue("UseDekursKopieren", ref ENV.UseDekursKopieren, "0");

                SetENVValue("PasswordStrength", ref ENV.PasswordStrength);
                SetENVValue("MaxPasswordAge", ref ENV.MaxPasswordAge);
                SetENVValue("MaxIdleTime", ref ENV.MaxIdleTime);

                SetENVValue("AutoCloseTime", ref ENV.AutoCloseTime);
                if (ENV.AutoCloseTime < 10 || ENV.AutoCloseTime > 720)
                {
                    ENV.AutoCloseTime = 120;
                }

                SetENVValue("ToleranzIntervall", ref ENV.ToleranzIntervall);
                SetENVValue("CheckScreenSize", ref ENV.CheckScreenSize);
                SetENVValue("ImportBefundeVerzeichnis", ref ENV.ImportBefundeVerzeichnis);
                SetENVValue("ImportBefundeArchivOrdner", ref ENV.ImportBefundeArchivOrdner);
                SetENVValue("BerufsstandArzt", ref ENV.BerufsstandArzt);
                SetENVValue("BerufsstandPflege", ref ENV.BerufsstandPflege);
                SetENVValue("BerufsstandTherapie", ref ENV.BerufsstandTherapie);
                SetENVValue("StrgDefaults", ref ENV.StrgDefaults);
                SetENVValue("eMailStammdaten", ref ENV.eMailStammdaten);
                SetENVValue("AbwesenheitenMinimalUI", ref ENV.AbwesenheitenMinimalUI);
                SetENVValue("DicomViewerFileOnly", ref ENV.DicomViewerFileOnly, "0");

                SetENVValue("FSW_IDIntern", ref ENV.FSW_IDIntern);                                                          
                SetENVValue("FSW_SenderAdresse", ref ENV.FSW_SenderAdresse, eTrim.yes, eDecrypt.no, eLengthType.fix, 9);    
                SetENVValue("FSW_EZAUF", ref ENV.FSW_EZAUF);
                SetENVValue("FSW_Prozent", ref ENV.FSW_Prozent);
                SetENVValue("FSW_SaveXLSX", ref ENV.FSW_SaveXLSX);
                SetENVValue("FSW_SupressSubKostentraeger", ref ENV.FSW_SupressSubKostentraeger);
                SetENVValue("ForceUniqueFiBu", ref ENV.ForceUniqueFiBu, "0");

                SetENVValue("ELDA_Pfad", ref ENV.ELDA_Pfad);

                SetENVValue("HAG_Url", ref ENV.HAG_Url);
                SetENVValue("HAG_Zertifikat", ref ENV.HAG_Zertifikat);
                SetENVValue("HAG_User", ref ENV.HAG_USER);
                SetENVValue("HAG_Password", ref ENV.HAG_PASSWORD, eTrim.no, eDecrypt.PMDSMode);

                SetENVValue("CheckConnectionAndPassword", ref ENV.CheckConnectionAndPassword);
                SetENVValue("DekursRegex", ref ENV.DekursRegex);
                SetENVValue("DekursRegexBeschreibung", ref ENV.DekursRegexBeschreibung);

                SetENVValue("WundtherapieVidieren", ref ENV.WundtherapieVidieren);
                SetENVValue("WundbildModifyTime", ref ENV.WundtherapieVidieren);
                SetENVValue("WundtherapieModifyTime", ref ENV.WundtherapieModifyTime);
                SetENVValue("WundverlaufModifyTime", ref ENV.WundverlaufModifyTime);
                SetENVValue("RezeptModifyTime", ref ENV.RezeptModifyTime);
                SetENVValue("RezeptUseTimeOfDay", ref ENV.RezeptUseTimeOfDay);
                SetENVValue("RezeptUseErstattungscode", ref ENV.RezeptUseErstattungscode, "0");
                SetENVValue("MedVerabreichenDefault", ref ENV.MedVerabreichenDefault);
                SetENVValue("UseEinzelverordnungMax24", ref ENV.UseEinzelverordnungMax24);
                SetENVValue("UseMedikationVidieren", ref ENV.UseMediaktionVidieren);

                SetENVValue("SavePflegebegleitschreibenToArchiv", ref ENV.SavePflegebegleitschreibenToArchiv, "0");
                SetENVValue("InterventionenEvaluieren", ref ENV.InterventionenEvaluieren);

                SetENVValue("ActivateKliententermine", ref ENV.ActivateKliententermine);
                SetENVValue("ActivateBereichstermine", ref ENV.ActivateBereichstermine);
                SetENVValue("AcceptNoPBS", ref ENV.AcceptNoPBS);

                SetENVValue("WCFServiceOnOff", ref ENV.WCFServiceOnOff);
                SetENVValue("WCFServiceDebugMode", ref ENV.WCFServiceDebugMode);
                SetENVValue("WCFServiceOnlyLocal", ref ENV.WCFServiceOnlyLocal);
                SetENVValue("WCFServicePMDSDebugPath", ref ENV.WCFServicePMDSDebugPath);

                //Lizenzschalter setzen
                ENV.lic_eMailBewerber = setLicValue("lic_eMailBewerber", ENV.lic_eMailBewerber, 2);
                ENV.lic_VO = setLicValue("lic_VO");
                ENV.lic_VOLager = setLicValue("lic_VOLager");
                ENV.lic_ELGA = setLicValue("lic_ELGA");
                ENV.lic_ELGA_PSB = setLicValue("lic_ELGA_PSB");
                ENV.lic_WundtherapieOffenWarnung = setLicValue("lic_WundtherapieOffenWarnung");
                ENV.lic_RezepteintragStorno = setLicValue("lic_RezepteintragStorno");
                ENV.lic_ELDA = setLicValue("lic_ELDA");
                ENV.lic_PflegestufenEinschätzung = setLicValue("lic_PflegestufenEinschätzung");

                QS2.Logging.ENV.init(ENV._LOGPATH, true, ENV.adminSecure);
                QS2.Desktop.ControlManagment.ENV.init(ref PMDS.Global.ENV.IDApplication, ref PMDS.Global.ENV.TypeRessourcesRun, ENV.adminSecure, ENV.DoNotShowRessources, ENV.AutoAddNewRessources, ENV.IntDeactivated, DataBase.CONNECTIONSqlClient);  
                QS2.Desktop.Txteditor.ENV.init(ENV.path_Temp, ENV._LOGPATH, true, ENV.adminSecure);
                PMDSClient.PMDSClientWrapper.init();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ENV.Init: " + ex.ToString());
            }
        }

        private static void SetENVValue(string sVar, ref bool ENVVar, string sValue = "1")
        {
            try
            {
                string stemp = _Log.ConfigFile.GetStringValue(sVar).Trim();
                ENVVar = stemp.Equals(sValue, StringComparison.OrdinalIgnoreCase) ? (sValue.Equals("1", StringComparison.OrdinalIgnoreCase) ? true : false) : ENVVar;
            }
            catch (Exception ex)
            {
                throw new Exception("ENV.SetENVValue (bool): " + ex.ToString());
            }
        }

        private static void SetENVValue(string sVar, ref string ENVVar, eTrim trim = eTrim.yes, eDecrypt decr = eDecrypt.no, eLengthType lengthType = eLengthType.var, int length1 = 0, int length2 = 0)
        {
            try
            {
                string stemp = _Log.ConfigFile.GetStringValue(sVar);
                if (decr == eDecrypt.no)
                {
                    ENVVar = System.String.IsNullOrEmpty(stemp) ? ENVVar : (trim == eTrim.yes ? stemp.Trim() : stemp);
                }
                else if (decr == eDecrypt.PMDSMode)
                {
                    ENVVar = System.String.IsNullOrEmpty(stemp) ? ENVVar : PMDS.BusinessLogic.BUtil.DecryptString(stemp.Trim()).Trim();
                }
                else if (decr == eDecrypt.QS2Mode)
                {
                    qs2.license.core.Encryption Encryption1 = new qs2.license.core.Encryption();
                    string PwdDecrypted = Encryption1.StringDecrypt(stemp.Trim(), qs2.license.core.Encryption.keyForEncryptingStrings);
                    ENVVar = PwdDecrypted.Trim();
                }

                if (lengthType == eLengthType.min && ENVVar.Length < length1)
                    throw new Exception("Variable " + sVar + " ist zu kurz: " + ENVVar.Length + " Zeichen. Minimale Länge = " + length1.ToString());
                else if (lengthType == eLengthType.max && ENVVar.Length > length1)
                    throw new Exception("Variable " + sVar + " ist zu lang: " + ENVVar.Length + " Zeichen. Maximale Länge = " + length1.ToString());
                else if (lengthType == eLengthType.fix && ENVVar.Length != length1)
                    throw new Exception("Variable " + sVar + " hat die falsche Länge: " + ENVVar.Length + " Zeichen. Erwartete Länge = " + length1.ToString());
                else if (lengthType == eLengthType.between && (ENVVar.Length < length1 || ENVVar.Length > length2))
                    throw new Exception("Variable " + sVar + " hat die falsche Länge: " + ENVVar.Length + " Zeichen. Erwartete Länge ist zwischen " + length1.ToString() + " und " + length2.ToString());

            }
            catch (Exception ex)
            {
                throw new Exception("ENV.SetENVValue (string/password): " + ex.ToString());
            }
        }

        private static void SetENVValue(string sVar, ref int ENVVar)
        {
            try
            {
                bool isNumeric = int.TryParse(_Log.ConfigFile.GetStringValue(sVar).Trim(), out int n);
                ENVVar = !isNumeric ? ENVVar : n;
            }
            catch (Exception ex)
            {
                throw new Exception("ENV.SetENVValue (int): " + ex.ToString());
            }
        }

        private static void SetENVValue(string sVar, ref decimal ENVVar)
        {
            try
            {
                bool isDecimal = decimal.TryParse(_Log.ConfigFile.GetStringValue(sVar).Trim(), out decimal n);
                ENVVar = !isDecimal ? ENVVar : n;
            }
            catch (Exception ex)
            {
                throw new Exception("ENV.SetENVValue (int): " + ex.ToString());
            }
        }

        private static void SetENVValue(string sVar, ref Guid ENVVar)
        {
            try
            {
                bool isGuid = Guid.TryParse(_Log.ConfigFile.GetStringValue(sVar).Trim(), out Guid g);
                ENVVar = !isGuid ? ENVVar : g;
            }
            catch (Exception ex)
            {
                throw new Exception("ENV.SetENVValue (Guid): " + ex.Message);
            }
        }

        private static void SetENVValue(string sVar, ref uint ENVVar)
        {
            try
            {
                bool isNumeric = uint.TryParse(_Log.ConfigFile.GetStringValue(sVar).Trim(), out uint n);
                ENVVar = !isNumeric ? ENVVar : n;
            }
            catch (Exception ex)
            {
                throw new Exception("ENV.SetENVValue (uint): " + ex.ToString());
            }
        }

        private static void SetENVValue(string sVar, ref PasswordScore ENVVar)
        {
            try
            {
                bool isNumeric = int.TryParse(_Log.ConfigFile.GetStringValue(sVar).Trim(), out int n);
                ENVVar = !isNumeric ? ENVVar : (PasswordScore)n;
            }
            catch (Exception ex)
            {
                throw new Exception("ENV.SetENVValue (Password): " + ex.ToString());
            }
        }

        private static void SetENVValue(string sVar, ref System.ServiceModel.EndpointAddress ENVVar)
        {
            try
            {
                string uriName = _Log.ConfigFile.GetStringValue(sVar);
                Uri uriResult;
                bool result = Uri.TryCreate(uriName, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                if (result)
                {
                    ENVVar = new System.ServiceModel.EndpointAddress(new Uri(uriName));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ENV.SetENVValue (EndpointAdress): " + ex.ToString());
            }
        }


        private static int setLicValue(string strCheck, int intDefault, int intAdminSecure)
        {
            try
            {
                if (ENV.adminSecure)
                    return intAdminSecure;   

                int num;
                string candidate = PMDS.BusinessLogic.BUtil.GetLicenseValues(strCheck);
                if (int.TryParse(candidate, out num))
                    return System.Convert.ToInt32(candidate);
                else
                    return intDefault;
            }
            catch (Exception ex)
            {
                throw new Exception("ENV.setLicValue (numeric): " + ex.ToString());
            }
        }

        private static bool setLicValue(string strCheck)
        {
            try
            {
                return PMDS.BusinessLogic.BUtil.CheckLicense(strCheck) || ENV.adminSecure;
            }
            catch (Exception ex)
            {
                throw new Exception("ENV.setLicValue (bool): " + ex.ToString());
            }
        }

        private static void InsertERConnections()
        {
            try
            {
                Boolean MustSavePMDS = false;
                Boolean MustSaveQS2 = false;

                MustSavePMDS = WriteERConnection("ERModellPMDSEntities");
                MustSaveQS2 = WriteERConnection("ERModellQS2Entities");

                //if (MustSavePMDS || MustSaveQS2)
                //    System.Windows.Forms.QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Konfigurationsdatei wurde aktualisiert.");

                return;

            }
            catch (Exception ex)
            {
                throw new Exception("MainEntry.InsertERConnection: " + ex.ToString());
            }
        }

        private static bool WriteERConnection(string ConnectionName)
        {
            try
            {
                string providerName = "System.Data.SqlClient";
                string serverName = PMDS.Global.ENV.DB_SERVER;
                string databaseName = PMDS.Global.ENV.DB_DATABASE;
                string User = PMDS.Global.ENV.DB_USER;
                string Pwd = PMDS.Global.ENV.DB_PASSWORD;
                string ERproviderName = "System.Data.EntityClient";
                string ERMetaData = @"res://*/ERModellPMDS.csdl|res://*/ERModellPMDS.ssdl|res://*/ERModellPMDS.msl";

                SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
                sqlBuilder.DataSource = serverName;
                sqlBuilder.InitialCatalog = databaseName;
                sqlBuilder.ApplicationName = "EntityFramework";
                sqlBuilder.MultipleActiveResultSets = true;
                sqlBuilder.IntegratedSecurity = true;

                //Für SQL-User
                if (User != null)
                {
                    sqlBuilder.UserID = User;
                    sqlBuilder.Password = Pwd ?? "";
                    sqlBuilder.IntegratedSecurity = false;
                }
                string providerString = sqlBuilder.ToString();


                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                var connection = config.ConnectionStrings.ConnectionStrings[ConnectionName];

                string chkdataBaseName = "=" + databaseName.ToUpper() + ";";
                string chkServerName = "=" + serverName.ToUpper() + ";";

                //Wenn es die Connection schon gibt, prüfen, ob die richtige DB und der richte Server eingetragen sind
                if (connection != null && connection.ConnectionString.ToUpper().Contains(chkServerName) && connection.ConnectionString.ToUpper().Contains(chkdataBaseName))
                {
                    return true;
                }
                else
                {
                    if (connection != null)
                        config.ConnectionStrings.ConnectionStrings.Remove(ConnectionName);

                    EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
                    entityBuilder.Provider = providerName;
                    entityBuilder.ProviderConnectionString = providerString;
                    entityBuilder.Name = ConnectionName;
                    entityBuilder.Metadata = ERMetaData;

                    config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings
                    {
                        Name = entityBuilder.Name,
                        ConnectionString = entityBuilder.ConnectionString.Replace("name=" + entityBuilder.Name + ";", ""),
                        ProviderName = ERproviderName
                    });
                    config.Save(ConfigurationSaveMode.Modified, false);
                    ConfigurationManager.RefreshSection("connectionStrings");
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("MainEntry.WriteERConnection: " + ex.ToString());

            }
        }


        public static bool intSetupDirs()
        {

            ENV.DynReportPath = System.IO.Path.Combine(ENV.sRootDir, "DynReports");                         // Klientenreports Hauptsystem
            ENV.check_Path(ENV.DynReportPath, false);

            ENV.DynReportExtrasPath = System.IO.Path.Combine(ENV.sRootDir, "DynReportsExtras");              // Hauptmenü Programm
            ENV.check_Path(ENV.DynReportExtrasPath, false);

            ENV.DynReportsPEP = System.IO.Path.Combine(ENV.sRootDir, "DynReportsPEP");                       // Hauptmenü Programm
            ENV.check_Path(ENV.DynReportsPEP, false);

            ENV.DynReportNotfallBasePath = System.IO.Path.Combine(ENV.sRootDir, "DynReportsProzeduren");     // Standard-Notfallprozeduren
            ENV.check_Path(ENV.DynReportNotfallBasePath, false);

            ENV.DynReportWundePath = System.IO.Path.Combine(ENV.sRootDir, "DynReportsWunde");                // Wunddoku
            ENV.check_Path(ENV.DynReportWundePath, false);

            ENV.DYNREPORTABRECHNUNGPATH = System.IO.Path.Combine(ENV.sRootDir, "DynReportsAbrechnung");       // Abrechnungsystem
            ENV.check_Path(ENV.DYNREPORTABRECHNUNGPATH, false);

            ENV.DYNREPORTMEDIKAMENTEPATH = System.IO.Path.Combine(ENV.sRootDir, "DynReportsMedikamente");
            ENV.check_Path(ENV.DYNREPORTMEDIKAMENTEPATH, false);

            ENV.ReportPath = System.IO.Path.Combine(ENV.sRootDir, "Reports");
            ENV.check_Path(ENV.ReportPath, false);

            //os 2013.02.12 Config-Pfad für Reports dynamisch ermitteln (wenn Entwicklungsumgebung, dann Report.config)
            string localRptConfigPath = "reports";
            string checkPath = System.IO.Path.Combine(ENV.sConfigRootDir, ENV.getAdditionalFolder(), System.IO.Path.GetFileName(ENV.sRootDir));
            if (System.IO.Directory.Exists(System.IO.Path.Combine(checkPath, "Reports.config")))
            {
                localRptConfigPath += ".config";
            }



            //if (ENV.StartFromShare.Trim() == "0" || ENV.DoOrigPathConfig)
            //{
            //    //ENV.ReportConfigPath = System.IO.Directory.GetParent(ENV.pathConfig) + "\\reports";
            //    //ENV.ReportConfigPath = System.IO.Path.Combine(System.IO.Directory.GetParent(ENV.pathConfig).ToString(), "reports");
            //    ENV.ReportConfigPath = ENV.RptConfigPath;
            //}
            //else
            //{
            //    ENV.ReportConfigPath = System.IO.Path.Combine(ENV.sConfigRootDir, ENV.getAdditionalFolder(), System.IO.Path.GetFileName(ENV.sRootDir), localRptConfigPath);                           //<120118> neu für Configdateien der DynReports in pathConfig
            //}
            //ENV.check_Path(ENV.ReportConfigPath, true);

            ENV.ReportPathDatenerhebung = System.IO.Path.Combine(ENV.sRootDir, "DynReportsDatenerhebung");
            ENV.check_Path(ENV.ReportPathDatenerhebung, false);

            ENV.pathForms = System.IO.Path.Combine(ENV.sRootDir, "Forms");
            ENV.check_Path(ENV.pathForms, false);
            ENV.Image_Path = ENV.pathForms;

            //ENV.path_Temp = System.IO.Path.GetTempPath() + "\\PMDS";
            ENV.path_Temp = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "PMDS");
            ENV.check_Path(ENV.path_Temp, true);
            QS2.functions.vb.functOld.path_temp = PMDS.Global.ENV.path_Temp;

            ENV.path_BiografieVorlagen = ENV.pathForms;
            ENV.check_Path(ENV.path_BiografieVorlagen, true);

            return true;
        }

        public static void check_Path(string dir, bool checkWriteable)
        {
            try
            {
                if (!System.IO.Directory.Exists(dir))
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(dir);
                        if (!System.IO.Directory.Exists(dir))
                        {
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Der Pfad '") + dir + QS2.Desktop.ControlManagment.ControlManagment.getRes("' kann nicht erstellt werden! Bitte dem Administrator melden!"), QS2.Desktop.ControlManagment.ControlManagment.getRes("PMDS - Pfade"), true);
                        }

                        if (checkWriteable)
                        {
                            PermissionSet permissionSet = new PermissionSet(PermissionState.None);
                            FileIOPermission writePermission = new FileIOPermission(FileIOPermissionAccess.Write, dir);
                            permissionSet.AddPermission(writePermission);

                            if (!permissionSet.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet))
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Im Pfad {0} besteht kein Schreibrecht! Bitte dem Administrator melden!"), dir), QS2.Desktop.ControlManagment.ControlManagment.getRes("PMDS - Pfade"), true);
                        }
                    }
                    catch (Exception ex)
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Der Pfad '") + dir + QS2.Desktop.ControlManagment.ControlManagment.getRes("' kann nicht erstellt werden! Bitte dem Administrator melden!"), QS2.Desktop.ControlManagment.ControlManagment.getRes("PMDS - Pfade"), true);
                        ENV.HandleException(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        public static void check_File(string file)
        {
            try
            {
                if (!System.IO.File.Exists(file))
                    throw new Exception("File " + file + " can not found! Please contact the Administrator!");
            }

            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        public static cAdminFile checkAutoLogIn()
        {
            cAdminFile ret = new cAdminFile();
            string autoFile = System.IO.Path.Combine(ENV.pathConfig, "autoLogIn.config");
            if (System.IO.File.Exists(autoFile))
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(autoFile);
                ret.usr = reader.ReadLine();
                ret.pwd = reader.ReadLine();
                reader.Close();
                ret.exists = true;
            }
            return ret;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liest die PP Tooltip Konfiguration
        /// </summary>
        //----------------------------------------------------------------------------
        //private static void ReadPPTipConfig()
        //{
        //    string stemp = _Log.ConfigFile.GetStringValue("SHOW_PP_TOOLTIP"); // Syntax: OFF | ON;Delay[ms];Duration[ms]
        //    if (stemp.Length == 0)      // Defaultwerte
        //        return;

        //    string[] sa = stemp.Split(';');
        //    if (sa.Length > 0)
        //        _ShowPPToolTip = sa[0] == "OFF" ? false : true;

        //    if (sa.Length == 3)
        //    {
        //        _PPToolTipDelay = RBUSF.ConvertStringToInt(sa[1]);
        //        _PPToolTipDuration = RBUSF.ConvertStringToInt(sa[2]);

        //        if (_PPToolTipDelay == 0 || _PPToolTipDelay < 50) _PPToolTipDelay = 1000;
        //        if (_PPToolTipDuration == 0 || _PPToolTipDuration < 1000) _PPToolTipDuration = 50000;
        //    }
        //}

        //----------------------------------------------------------------------------
        /// <summary>
        /// PflegeModelle aus der Config lesen
        /// </summary>
        //----------------------------------------------------------------------------
        private static PflegeModelle[] ReadPflegemodelle()
        {
            List<PflegeModelle> lPM = new List<PflegeModelle>();
            string sPflegemodelle = "";
            PflegeModelle[] PM = new PflegeModelle[] { };
            SetENVValue("PFLEGEMODELLE", ref sPflegemodelle);

            string[] sa = sPflegemodelle.Split(',');
            if (!System.String.IsNullOrWhiteSpace(sa[0]))
            {
                foreach (string s in sa)
                {
                    try
                    {
                        lPM.Add((PflegeModelle)Enum.Parse(typeof(PflegeModelle), s, true));                        
                    }
                    catch (Exception ex)
                    {
                        PM = new PflegeModelle[] { };
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bei der Verarbeitung der Konfigurationsdatei ist ein Fehler aufgetreten.\r\nPrüfen Sie den Eintrag PFLEGEMODELLE\r\nEs sind nur Orem, Krohwinkel und POP erlaubt\r\n");
                        return PM;
                    }
                }
            }
            return lPM.ToArray();
        }

         //----------------------------------------------------------------------------
        /// <summary>
        /// Farben aus der Config Datei auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        public static Color GetColor(string name, Color defColor)
        {
            //Wird nicht mehr benützt
            string cfgColorName = "";
            Color cfgColor = defColor;

            // ColorName mit dazugehörigem Wert ermitteln
            cfgColorName = string.Format("COLOR_{0}", name);
            string strColor = _ConfigFile.GetStringValue(cfgColorName);
            if (strColor != "")
                cfgColor = Color.FromArgb(Convert.ToInt32(strColor, 16));

            return cfgColor;
        }


        /// <summary>
        /// Liefert einen Resource String
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static string String(string Name)
        {
            string sResult = null;

            try
            {

                ////Sonderbehandlung für Risikofaktoren
                //switch (Name)
                //{
                //    case "RF":
                //        sResult = "Risikofaktoren";
                //        break;
                //    case "RF_select":
                //        sResult = "Risikofaktorwahl:";
                //        break;
                //    case "RF_single":
                //        sResult = "Risikofaktor";
                //        break;
                //    case "RFSingle":
                //        sResult = "Ätiologie / Risikofaktor";
                //        break;
                //    case "END_RFSZ":
                //        sResult = "Risikofaktor / Ziel";
                //        break;
                //    case "HIDE_RFM_Maßnahmen":
                //        sResult = "Risikofaktorbezogene Maßnahmen nicht anzeigen";
                //        break;
                //    case "SHOW_RFM_Maßnahmen":
                //        sResult = "Risikofaktorbezogene Maßnahmen anzeigen";
                //        break;

                //    default:
                //        sResult = _resources.GetString(Name);
                //        break;
                //}
                sResult = _resources.GetString(Name);

            }
            catch
            {
            }

            if (sResult == null)
            {
                try
                {
                    sResult = _resources.GetString("ResNotFound");
                }
                catch
                {
                }

                if (sResult == null)
                    sResult = string.Format("RESOURCE '<{0}>' NOT FOUND !", Name);
                else
                    sResult = string.Format(sResult, Name);
            }

            return sResult;
        }

        /// <summary>
        /// Liefert einen Resource String mit Parametern
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string String(string Name, params object[] args)
        {
            string sResult = String(Name);
            return string.Format(sResult, args);
        }








        public static string getTitleExcept(string Title)
        {
            string sTitleTmp = "?Title=" + QS2.Desktop.ControlManagment.ControlManagment.getRes(Title) + ";";
            return sTitleTmp.Trim();
        }

        public static void HandleException(Exception e, string sType = "Exception", bool ShowMsgBox = true, bool checkOutOfMemory = true, string TitleAlternative = null, bool sendEMail = true)
        {
            QS2.Logging.ENV.init(ENV.LOGPATH, true, qs2.core.ENV.adminSecure);
            string sHostName = System.Net.Dns.GetHostName();
            string IPAdress = "";

            if (e.ToString().Contains("?Title="))
            {
                int pFrom = e.ToString().Trim().IndexOf("?Title=");
                int pTo = -1;
                if (pFrom != -1)
                    pTo = e.ToString().Trim().IndexOf(";", pFrom);

                if (pFrom != -1 && pTo != -1)
                {
                    string sTitleTmp = e.ToString().Trim().Substring(pFrom + 7, pTo - pFrom - 7);
                    TitleAlternative += (string.IsNullOrEmpty(TitleAlternative) ? "" : ", ") + sTitleTmp;
                }
                else if (pFrom != -1 && pTo == -1)
                {
                    string sTitleTmp = e.ToString().Trim().Substring(pFrom + 7, e.ToString().Trim().Length - pFrom - 7);
                    TitleAlternative += (string.IsNullOrEmpty(TitleAlternative) ? "" : ", ") + sTitleTmp;
                }
            }

            try
            {
                System.Net.IPAddress[] localIPs = System.Net.Dns.GetHostAddresses(sHostName.Trim());
                if (localIPs.Length > 1)
                {
                    IPAdress = localIPs[2].ToString();
                }
            }
            catch (Exception ex2)
            {
                string sExcept = ex2.ToString();
            }
           
            string sUsrLoggedIn = "";
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                    PMDS.db.Entities.Benutzer rUserLoggedIn = b.LogggedOnUserWithCheck(db);
                    if (rUserLoggedIn != null)
                        sUsrLoggedIn = rUserLoggedIn.Benutzer1.Trim() + "";
                }
            }
            catch (Exception ex2)
            {
                string sExcept = ex2.ToString();
            }

            string KlinikBezeichnung = "";
            try
            {
                if (ENV._IDKlinik != _IDKlinikNoKlinikSelected && !ENV._IDKlinik.Equals(System.Guid.Empty))
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                    {
                        var rKlinik = (from k in db.Klinik
                                       where k.ID == ENV.IDKlinik
                                       select new
                                       {
                                           ID = k.ID,
                                           Bezeichnung = k.Bezeichnung
                                       }).First();
                        KlinikBezeichnung = rKlinik.Bezeichnung.Trim();
                    }
                }
            }
            catch (Exception ex8)
            {
                string sExcept88 = ex8.ToString();
            }

            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    string sExcept6 = "Host: " + sHostName.Trim() + ", IPAdress: " + IPAdress.Trim() + ", User: " + sUsrLoggedIn.Trim() + ", Type:" + sType.Trim() + "\r\n" + "\r\n" + e.ToString() + 
                                        "\r\n" + "\r\n" + (string.IsNullOrEmpty(TitleAlternative) ? "" : TitleAlternative.Trim());
                    
                    PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                    b.saveProtocol(db, "ExceptionPMDS", sExcept6.Trim());
                }
            }
            catch (Exception ex8)
            {
                string sExcept = ex8.ToString();
            }

            DateTime dNow = DateTime.Now;
            if (sendEMail && ENV.WCFServiceOnOff)
            {
                //if (!PMDS.Global.db.ERSystem.PMDSBusinessUI.checkClientsS2())
                //{
                    ENV ENV1 = new ENV();
                    cParsSendException ParsSendException = new cParsSendException();
                    ParsSendException.sException = e.ToString() + "\r\n" + "\r\n" + (string.IsNullOrEmpty(TitleAlternative) ? "" : TitleAlternative.Trim());
                    ParsSendException.client = sHostName + "::" + IPAdress;
                    ParsSendException.user = sUsrLoggedIn;
                    ParsSendException.haus = KlinikBezeichnung;
                    ParsSendException.At = dNow;
                    Thread threadSendExcept = new Thread(ENV1.thread_sendExceptionAsSMTPEMail);
                    threadSendExcept.IsBackground = true;
                    threadSendExcept.Start(ParsSendException);
                //}
            }
            if (e.GetType().Equals(typeof(AppException)))
            {
                string NewLine = "<br/>";
                AppException AppEx = (AppException)e;
                string sExceptNr = "";
                if (AppEx.lstExceptNrs.Count > 0)
                {
                    foreach (AppException.AppExceptionDetails excepDetails in AppEx.lstExceptNrs)
                    {
                        string sTargetSite = "";
                        if (excepDetails.TargetSite.Trim() != "")
                        {
                            sTargetSite = ", Fct:" + excepDetails.TargetSite.Trim();
                        }
                        sExceptNr += "Message-Nr:" + excepDetails.ExcepNr.ToString() + sTargetSite + NewLine;
                    }
                    sExceptNr += NewLine + NewLine;
                }
                QS2.Logging.ENV.doLog2(sExceptNr + e.ToString(), dNow, sHostName.Trim(), IPAdress.Trim(), sUsrLoggedIn.Trim(), sType.Trim(), true, ShowMsgBox,
                                        (string.IsNullOrEmpty(TitleAlternative) ? "" : TitleAlternative.Trim()));
                //QS2.Logging.ENV.doLog(sExceptNr + e.ToString(), "", "PMDS-System", true);
                if (checkOutOfMemory)
                    ENV.checkExceptionOutOfMemory(e.ToString());
            }
            else
            {
                QS2.Logging.ENV.doLog2(e.ToString(), dNow, sHostName.Trim(), IPAdress.Trim(), sUsrLoggedIn.Trim(), sType.Trim(), true, ShowMsgBox,
                                        (string.IsNullOrEmpty(TitleAlternative) ? "" : TitleAlternative.Trim()));
                if (checkOutOfMemory)
                    ENV.checkExceptionOutOfMemory(e.ToString());
            }
        }

        public void thread_sendExceptionAsSMTPEMail(object pars)
        {
            try
            {
                cParsSendException ParsSendException = (cParsSendException)pars;
                PMDSClient.PMDSClientWrapper.sendExceptionAsSMTPEMail(ParsSendException.sException, ParsSendException.client, ParsSendException.user, ParsSendException.haus, ParsSendException.At);

            }
            catch (Exception ex)
            {
                string sExcept = "ENV.thread_sendExceptionAsSMTPEMail: " + ex.ToString();
                PMDS.Global.ENV.HandleException(new Exception(sExcept), "Exception", false);
                //throw new Exception(sExcept);
            }
        }


        public static void checkExceptionDBNetLib(string except)
        {
            if (except.Trim().ToLower().Contains(("DBNETLIB").Trim().ToLower()))
            {
                if (RBU.DataBase.Srv.Trim() != "")
                {
                    string DatabaseServerTmp = "";
                    string IPAdress = "";
                    try
                    {
                        DatabaseServerTmp = RBU.DataBase.Srv.Trim();
                        if (RBU.DataBase.Srv.Trim().Contains(("\\")))
                        {
                            int iPosTmp = RBU.DataBase.Srv.Trim().IndexOf("\\");
                            if (iPosTmp != -1)
                            {
                                DatabaseServerTmp = DatabaseServerTmp.Trim().Substring(0, DatabaseServerTmp.Trim().Length - iPosTmp - 1);
                            }
                        }

                        //IPHostEntry host;
                        //string localIP = "?";
                        //host = Dns.GetHostEntry(Dns.GetHostName());
                        //foreach (IPAddress ip in host.AddressList)
                        //{
                        //    if (ip.AddressFamily.ToString() == "InterNetwork")
                        //    {
                        //        localIP = ip.ToString();
                        //    }
                        //}

                        //IPHostEntry ip = System.Net.Dns.GetHostByName(DatabaseServerTmp.Trim());
                        //IPAddress[] IPaddr = ip.AddressList;
                        //for (int i = 0; i < IPaddr.Length; i++)
                        //{
                        //    Console.WriteLine("IP Address {0}: {1} ", i, IPaddr[i].ToString());
                        //}

                        //System.Net.IPAddress[] localIPs = System.Net.Dns.GetHostAddresses("s2e\\" + DatabaseServerTmp.Trim() + "");
                        //if (localIPs.Length > 1)
                        //{
                        //    IPAdress = localIPs[1].ToString();
                        //}

                    }
                    catch (Exception ex2)
                    {
                        Exception exTmp = new Exception("Error - Error to get Servername from ConnectionString '" + RBU.DataBase.Srv.Trim() + "'" + ex2);
                        ENV.HandleException(exTmp, "checkExceptionDBNetLib", true);
                    }

                    //if (IPAdress.Trim() == "")
                    //{
                    //    Exception exTmp = new Exception("Error (DBNETLIB) - IPAdress for Server '" + RBU.DataBase.Srv.Trim() + "' = empty!");
                    //    ENV.HandleException(exTmp, "ExceptionGetIPAdress", true);
                    //}
                    //else
                    //{

                    bool ServerIsAailable = false;
                    try
                    {
                        System.Net.NetworkInformation.PingReply pingReply;
                        using (var ping = new System.Net.NetworkInformation.Ping())
                            pingReply = ping.Send(DatabaseServerTmp.Trim());
                        ServerIsAailable = pingReply.Status == System.Net.NetworkInformation.IPStatus.Success;
                    }
                    catch (Exception ex2)
                    {
                        Exception exTmp = new Exception("Error - Error to get Servername from ConnectionString '" + RBU.DataBase.Srv.Trim() + "'" + ex2);
                        ENV.HandleException(exTmp, "checkExceptionDBNetLib", true);
                    }

                    if (!ServerIsAailable)
                    {
                        Exception exTmp2 = new Exception("Error - Ping to server '" + DatabaseServerTmp.Trim() + "' failed!");
                        ENV.HandleException(exTmp2, "checkExceptionDBNetLib", false);
                    }
                    else
                    {
                        bool bSelectOK = false;
                        System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                        System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter();
                        System.Data.DataTable dt = new System.Data.DataTable();
                        da.SelectCommand = cmd;
                        OleDbConnection conn = new OleDbConnection(RBU.DataBase.CONNECTION.ConnectionString);
                        da.SelectCommand.Connection = conn;
                        cmd.CommandText = "SELECT Top 1 Bezeichnung from Recht";
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            System.Data.DataRow r = dt.Rows[0];
                            if (r[0] != null)
                            {
                                string retValue = r[0].ToString().Trim();
                                bSelectOK = true;
                            }
                        }

                        if (bSelectOK)
                        {
                            Exception exTmp2 = new Exception("Info - Ping and select to server '" + DatabaseServerTmp.Trim() + "' OK!");
                            ENV.HandleException(exTmp2, "checkExceptionDBNetLib", false);
                        }
                        else
                        {
                            Exception exTmp2 = new Exception("Info - Ping or select to server '" + DatabaseServerTmp.Trim() + "' failed!");
                            ENV.HandleException(exTmp2, "checkExceptionDBNetLib", false);
                        }
                    }
                    //}
                }
            }
        }

        public static bool checkExceptionServerNotReachable(string except)
        {
            if (ENV.checkExceptionDBNetLib2(except) || ENV.checkExceptionDBNetLib5(except) || ENV.checkExceptionDBNetLib3(except) || ENV.checkExceptionDBNetLib4(except) || ENV.checkExceptionDBNetLib2(except) || ENV.checkExceptionAbfragetimeout(except) || ENV.checkExceptionPhysischeVerbindung(except))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool checkExceptionDBNetLib4(string except)
        {
            if (except.Trim().ToLower().Contains(("Server antwortet nicht").Trim().ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool checkExceptionDBNetLib2(string except)
        {
            if (except.Trim().ToLower().Contains(("DBNETLIB").Trim().ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool checkExceptionDBNetLib3(string except)
        {
            if (except.Trim().ToLower().Contains(("bereits ein geöffneter DataReader zugeordnet").Trim().ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool checkExceptionDBNetLib5(string except)
        {
            if (except.Trim().ToLower().Contains(("Status der Verbindung ist 'Geschlossen'").Trim().ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool checkExceptionAbfragetimeout(string except)
        {
            if (except.Trim().ToLower().Contains(("Abfragetimeout").Trim().ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool checkExceptionPhysischeVerbindung(string except)
        {
            if (except.Trim().ToLower().Contains(("Physische Verbindung nicht einsatzbereit").Trim().ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void checkExceptionOutOfMemory(string except)
        {
            if (except.sEquals("OutOfMemoryException", S2Extensions.Enums.eCompareMode.Contains))             
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der max. Speicherverbrauch für PMDS wurde überschritten! (32 Bit Version)" + "\r\n" +
                                                                            "PMDS muss neu gestartet werden!", "PMDS", MessageBoxButtons.OK);
            }
        }

        public static void WriteLog(string txt)
        {
            if (!System.IO.Directory.Exists(PMDS.Global.ENV.LOGPATH.Trim()))
            {
                System.IO.Directory.CreateDirectory(PMDS.Global.ENV.LOGPATH.Trim());
            }

            string txtLog = DateTime.Now.ToString() + txt + "\r\n";
            using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(PMDS.Global.ENV.LOGPATH, "Log_" + System.Environment.MachineName.Trim() + "_2" + ".log"), true))
            {
                outputFile.WriteLine(txtLog);
            }
        }
        public static void killApp()
        {
            System.Diagnostics.Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();
            currentProcess.Kill();
        }

        public static string BefundTypText(eBefundTyp FileExtension)
        {
            switch (FileExtension)
            {
                case eBefundTyp.BEFUND:
                    return ".bef";
                case eBefundTyp.PDF:
                    return ".pdf";
                case eBefundTyp.DICOM:
                    return ".dcm";
                case eBefundTyp.ZIP:
                    return ".zip";
                case eBefundTyp.LABOR:
                    return ".lab";
                case eBefundTyp.DICOMDIR:
                    return ".dicomdir";
            }
            return ".NOTDEFINED";
        }

        public static string CheckReportExists(string sKey)
        {
            string sPath = System.IO.Path.Combine(ReportPath, sKey);         

            if (!System.IO.File.Exists(sPath))
                throw new Exception(string.Format("Report File <{0}> ({1}) not found!", sPath, sKey));

            return sPath;
        }
    }

    public class cParDelegSendMain
    {
        public int foundUnreadedMessages = 0;
    }

    public delegate void ENVNeuerPatientDelegate(Guid IDPatient);
    public delegate void ENVPatientIDChangedDelegate(Guid IDPatient, eCurrentPatientChange typ, bool refreshPicker, bool clickGridTermine);
    public delegate void MedizinischeDatenStateChangedDelegate(int iMedizinischerTyp);
    public delegate void PflegePlanChangedDelegate(Guid IDAufenthalt);
    public delegate void NotfallSelectedDelegate(Guid IDSP);
    public delegate void MedizinischeDatenLayoutChangedDelegate();
    public delegate void ENVPatientDatenChangedDelegate(Guid IDPatient);
    public delegate void AuswahlGruppeListChangedDelegate(string Grop);
    public delegate void CurrentQuickFilterChangedDelegate(Guid IDQuickFilter);
    public delegate void ZusatzeintragChangedDelegate(bool changed);
    public delegate void sendMainChangedDelegate(eSendMain typ, cParDelegSendMain ParDelegSendMain);
    public delegate bool selKlientenDelegate(eSendMain typ, System.Collections.Generic.List<string> filterString, bool suche, object obj);
    public delegate void klinikChanged(dsKlinik.KlinikRow rKlinikSelected, bool allKliniken);
    public delegate void dPatientenUersPickerValueChanged(Nullable<Guid> IDKlinik, Nullable<Guid> IDAbteilung, Nullable<Guid> IDBereich, System.Collections.Generic.List<Guid> lstSelectedUsersPatients, UltraTreeNode treeNode, eTypePatientenUserPickerChanged TypePatientenUserPickerChanged);
    public delegate void dAbtBereichPickerValueChanged(Nullable<Guid> IDKlinik, Nullable<Guid> IDAbteilung, Nullable<Guid> IDBereich,  UltraTreeNode treeNode);

    public enum UserRights      
    {
        //-IntVers=NoTranslation

        [Description("Verwalten der Stammdaten")]
        Stammdatenverwaltung = 1,		                    // Verwalten der Stammdaten
        [Description("Kienten neu aufnehmen")]
        Neuaufnahme = 2,		                            // Patienten neu Aufnehmen
        [Description("Passwort ändern")]
        PasswordAendern = 4,		                        // Passwort ändern
        [Description("Klienten aufnehmen")]
        Aufnahme = 5,		                                // Patienten aufnehmen
        [Description("Klienten beurlauben")]
        Urlaube = 6,                                        // Patienten beurlauben (Abwesenheit)
        [Description("Berichtsparameter ändern")]
        BerichteParameterBearbeiten = 9,		            // Berichtsparameter ändern
        [Description("Maßnahmen abzeichnen")]
        Rueckmelden = 10,		                            // Maßnahmen rückmelden
        [Description("Bezugspersonen ändern")]
        BezugspersonAendern = 11,		                    // Bezugspersonen ändern
        [Description("Klienten versetzen")]
        Versetzung = 12,		                            // Patienten versetzen
        [Description("Klienten enlassen")]
        Entlassung = 13,		                            // Patienten enlassen
        [Description("Benutzer verwalten")]
        ManageUserxyxy = 14,		                        // Benutzer verwalten
        [Description("Klienten verwalten")]
        PatientenVerwalten = 15,		                    // Patienten verwalten
        [Description("Auswahl-Listen verwalten")]
        AuswahllistenVerwalten = 18,		                // Auswahl-Listen verwalten
        [Description("Rezepte verwalten")]
        RezepteVerwalten = 23,		                        // Rezepte verwalten
        [Description("Medikamente vorbereiten")]
        MedikamenteVorbereiten = 24,		                // Medikamente vorbereiten
        [Description("Übergabe aufrufen")]
        Uebergabe = 26,		                                // Übergabe aufrufen
        [Description("Sondertermine verwalten")]
        TermineVerwalten = 27,		                        // Sondertermine verwalten
        [Description("Klienten Stammdaten anzeigen")]
        KlientenAktStammdatenAnzeigen = 29,
        [Description("Klienten Stammdaten verwalten")]
        KlientenAktStammdatenAendern = 30,
        [Description("Datenerhebung anzeigen")]
        DatenerhebungAnzeigen = 32,
        [Description("Datenerhebung verwalten")]
        DatenerhebungAendern = 33,
        [Description("Datenerhebung löschen")]
        DatenerhebungLoeschen = 34,
        [Description("Datenerhebung drucken")]
        DatenerhebungDrucken = 35,
        [Description("Pflegeplanung anzeigen")]
        PflegePlanungAnzeigen = 36,
        [Description("Pflegeplanung durchführen")]
        PflegePlanungAendern = 37,
        [Description("Evaluierung anzeigen")]
        EvaluierungAnzeigen = 38,
        [Description("Evaluierung durchführen")]
        EvaluierungDurchfuehren = 39,
        [Description("Archiv, Termine, E-Mail")]
        ArchivTerminMail = 40,
        [Description("Interne Berichte drucken")]
        DruckenInterneBerichte = 43,
        [Description("Historie anzeigen")]
        Historie = 44,
        [Description("Berichte korrigieren")]
        RueckmeldungAendern = 46,
        [Description("Abrechnung starten")]
        AbrechnungStarten = 47,
        [Description("Stammdaten starten")]
        StammdatenStarten = 48,
        [Description("Bewerber starten")]
        BewerberStarten = 49,
        [Description("Abrechnungsdaten anzeigen")]
        abrechnungsdatenAnzeigen = 53,
        [Description("Depotgeld anzeigen")]
        depotgeldAnzeigen = 54,
        [Description("Klient Leistungen")]
        klientLeistungen = 55,
        [Description("Klient Transferzahlungen")]
        klientTransferzahlungen = 56,
        [Description("Klient Historie")]
        historie = 57,
        [Description("Schnellabzeichnung Intervention")]
        schnellrückmeldungIntervention = 58,
        [Description("Abwesende Klienten bearbeiten")]
        AbwesendeKlientenVerwalten = 60,
        [Description("Wunde und Wundverlauf ändern")]
        WundeÄndern = 61,
        [Description("Klientenbericht drucken")]
        KlientenberichtDrucken = 62,
        [Description("Abrechnungen überspielen")]
        AbrechnungenÜberspielen = 63,
        [Description("Abrechnungen exportieren")]
        AbrechnungenExportieren = 64,
        [Description("Import Gibodat")]
        ImportGibodat = 65,
        [Description("Alle Einrichtungen")]
        AlleEinrichtungen = 66,                                     //Rechte Maustaste Laden alle Kliniken
        [Description("Menü Standardpflegepäne")]
        MenüStandardpflegepäne = 67,
        [Description("Menü Stammdaten")]
        MenüStammdaten = 68,
        [Description("Menü Hilfstabellen")]
        MenüHilfstabellen = 69,
        [Description("Layoutmanager")]
        Layout = 70,
        [Description("Menü Rechte Abteilungen und Bereiche")]
        RechteAbteilungenBereiche = 71,
        [Description("Medikamentenbestelliste drucken")]
        MedikamentenbestellisteDrucken = 72,
        [Description("Berichte korrigieren (nur eigene)")]
        RueckmeldungEigeneAendern = 73,    
        [Description("HAG-Meldungen")]
        HAGMeldungen = 74,
        [Description("Ärzte zusammenführen")]
        ÄrzteZusammenführen = 75,
        [Description("Dienstübergabe")]
        Dienstübergabe = 76,

        [Description("Arztbrief drucken")]
        ArztbriefDrucken = 77,
        [Description("Automatische Arztabrechnungseinträge")]
        AutomatischeArztabrechungseinträge = 78,
        [Description("Arztabrechnung Erfassung")]
        ArztabrechnungErfassung = 79,
        [Description("Historische Daten ändern")]
        HistorischeDatenÄndern = 80,
        [Description("Pep planen")]
        PepPlanen = 81,
        [Description("Abwesenheit beendet änderbar")]
        AbwesenheitBeendetÄnderbar = 82,
        [Description("VO löschen")]
        VOLöschen = 83,
        [Description("Abwesenheit erfassen")]
        AbwesenheitErfassen = 84,
        [Description("Klient entlassen")]
        KlientEntlassen = 85,
        [Description("VO-Bestellung")]
        VOBestellung = 86,
        [Description("VO-Einmalige Bestellung")]
        VOBestellungEinmalig = 87,
        [Description("VO hinzufügen")]
        VOHinzufügen = 88,
        [Description("Abrechnung erweiterte Funktionen")]
        AbrechnungErweiterteFunktionen = 89,
        [Description("Anamnesen-Vorlagen verwenden")]
        AnamnesenVorlagenVerwenden = 90,
        [Description("Klient Entlassungszeitpunkt ändern")]
        KlientEntlassungszeitpunktÄndern = 91,
        [Description("Wundtherapie vidieren")]
        WundtherapieVidieren = 92,
        [Description("Wundtherapie ändern")]
        WundtherapieÄndern = 93,
        [Description("Nur Bezugspflege")]
        NurBezugspflege = 94,
        [Description("Klient löschen")]
        deleteKlient = 96,
        [Description("Suchtgiftschrank-Schlüssel")]
        SuchtgiftschrankSchluessel = 97,

        [Description("Rezepteintrag löschen")]
        RezepteintragLöschen = 98,
        [Description("QS2")]
        QS2 = 99,
        [Description("Benutzerdaten-ELGA verwalten")]
        BenutzerdatenELGAVerwalten = 100,
        [Description("DNR/Palliativ")]
        DNR_Palliativ = 109,
        [Description("Rezepte bestellen")]
        RezepteBestellen = 110,
        [Description("Abrechnung Inko-Produkt-Pauschale")]
        AbrechnungInkoProdukte = 117,
    }

    public enum UserRightsELGA
    {
        [Description("ELGA Patienten suchen")]
        ELGAPatientenSuchen = 101,
        [Description("ELGA Medikamente")]
        ELGAMedikamente = 102,
        [Description("ELGA pflegerischer Entlassungsbrief")]
        ELGAPflegerischerEntlassungsbrief = 103,
        [Description("ELGA Pflegezustandsbericht")]
        ELGAPflegezustandsbericht = 104,
        [Description("ELGA Aktionen")]
        ELGAAktionen = 105,

        [Description("ELGA-Dokumente erstellen")]
        ELGADokumenteErstellen = 106,
        [Description("ELGA-Dokumente vidieren")]
        ELGADokumenteVidieren = 107,
        [Description("ELGA-Dokumente senden")]
        ELGADokumenteSenden = 108,

        [Description("ELGA-Kontaktbestätigung")]
        ELGAKontaktbestätigung = 111,
        [Description("ELGA-Dokumente stornieren")]
        ELGADokumenteStornieren = 112,
        [Description("ELGA-Situatives OptOut")]
        ELGASituativesOptOut = 113,
        [Description("ELGA-Suche Ärzte")]
        ELGASucheÄrzte = 114,
        [Description("ELGA-Suche externe Einrichtungen")]
        ELGASucheExterneEinrichtungen = 115,
        [Description("ELGA-Kontake delegieren")]
        ELGAKontakDelegaton = 116,
    }

    public enum eCurrentPatientChange
    {
        PickerLinksOben = 0,
        keiner = 1
    }

    public enum eTextTyp
    {
        txt = 0,
        überschrift1 = 1,
        überschrift2 = 2,
        überschrift3 = 3,
        link = 4,
        line = 10
    }
    public class cAdminFile
    {
        public bool exists = false;
        public string usr = "";
        public string pwd = "";
    }
    
}