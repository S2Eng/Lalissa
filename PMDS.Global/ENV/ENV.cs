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

namespace PMDS.Global
{

    public class ENV
    {
        public static bool VisualStudioMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
        public static Guid VersionNr = new Guid("10000000-1009-1000-0000-000000000001");

        public static System.Data.OleDb.OleDbConnection conGiboDat = null;
        public static string IDApplication = qs2.core.license.doLicense.eApp.PMDS.ToString();

        public static string pmdsRelease = "Release 4";
        public static int pmdsDBVersion = 41000;
        public static string StartupTyp = "";                       //Mit welchem Paramter ?typ wurde gestartet
        //public static string Bereich          = "";
        public static string typRechNr = "Standard";

        public static string MedikamenteImportType = "ftp";
        public static string ftpFileImportMedikamente = "";
        public static string ftpUserName = "";
        public static string ftpPassword = "";

        public static string ImportBefundeVerzeichnis = "";
        public static string ImportBefundeArchivOrdner = "";
        public static string BerufsstandArzt = "";
        public static string BerufsstandPflege = "";
        public static string BerufsstandTherapie = "";

        public static string StrgDefaults = "";     //StrgDefaults=DekursMVB=1|00000000-0000-0000-0000-000000000000,11111111-00000-0000-0000-000000000000;DekursIntervention=1| .....
                                                    //Objekt=Gegenzeichnen|WichtigFür,WichtigFür;Objekt=Gegenzeichnen|WichtigFür,WichtigFür, ....
        public static string PathDokumente = "";

        public static bool ProxyJN = false;
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
        public static bool DoOrigPathConfig = false;
        
        public static string ConfigFileLauncher = "";
        public static string LauncherExe = "";
        
        public static string path_bin = "";

        public static string OrigConfigDir = "";
        public static string OrigConfigFile = "";

        public static string TypeRessourcesRun = "";
        public static bool DoNotShowRessources = false;
        public static bool AutoAddNewRessources = false;
        public static bool IntDeactivated = true;

        public static bool adminSecure = false;
        public static bool LoggedInAsSuperUser = false;

        public static bool PMDSNew = false;
        

        public static bool SpellCheckerOn = false;
        public static bool FullEditMode = false;
        public static uint AssessmentModifyTime = 24;
        public static bool UseDekursKopieren = true;
        public static bool CheckScreenSize = false;
        public static string frmRechnung = "rechnung.rtf";

        public static PasswordScore PasswordStrength = PasswordScore.Blank;
        public static int MaxPasswordAge = 0;
        public static uint MaxIdleTime = 0;
        public static int ToleranzIntervall = 0;

        public static string LoginInNameFrei = "";
        public static bool APVDA = false;

        public static string HAG_Url = "https://edi2.bewohnervertretung.at/api/xmlmapper";
        public static string HAG_Zertifikat = "BIDS EDI Certificate - IK:ER - Id:25";
        public static string HAG_USER = "";
        public static string HAG_PASSWORD = "";
        public static string HAG_PASSWORD_TMP = "";         //Passwort, das der User für die HAG-Meldung eingegeben hat. Merken, damit es nicht mehrfach eingegeben werden muss

        public static string ZahlKondBankeinzug = "Wir haben uns erlaubt, obigen Rechnungsbetrag von Ihrem Konto {0} einzuziehen.";
        public static string ZahlKondErlagschein = "Wir ersuchen um Überweisung des Rechnungsbetrags mittels beiliegendem Erlagschein auf unser Konto.";
        public static string ZahlKondÜberweisung = "Wir ersuchen um Überweisung des Rechnungsbetrags auf unser Konto.";
        public static string ZahlKondBar = "Betrag dankend erhalten.";

        public static bool AbwesenheitenAnzeigen = true;

        public static bool CheckConnectionAndPassword = false;
        public static bool WundtherapieVidieren = false;
        public static uint WundbildModifyTime = 24;
        public static uint WundverlaufModifyTime = 24;
        public static uint WundtherapieModifyTime = 24;

        private static ResourceManager _resources = null;




    


    



        private static bool _AbteilungRMOptional = false;	            // Flag ob der Rückmeldetext für die Abteilung Optional ist oder nicht
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

        public static bool doPatientFromTermineBereich = false;

        private static bool _demoversion = false;			            // verspeichert ob es sich um eine Demoversion handelt oder nicht

        public static bool _InitInProgress = false;

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

        public static bool WCFServiceOnOff = false;
        public static string UrlWCFServicePMDS = "";
        public static bool WCFServicePMDSAsConsole = false;
        public static string WCFServicePMDSDebugPath = "";

        public static string SchnellrückmeldungAsProcess = "1";

        public static string DekursRegex = "";
        public static string DekursRegexBeschreibung = "";

        public static string License = "";

        public static EvaluierungsTypen EvaluierungsTyp = EvaluierungsTypen.Ziel;   // Legt den Evaluierungstyp für das gesamtsystem fest
        public static bool ShowAufnahmeButton = false;                              // Signalisiert ob der Aufnahmebutton gezeigt werden soll oder nicht
        public static int RezeptDruck = -1;
        public static int RezeptBestellModus = -1;

        public static bool OnlyOneFavoritenComboinPlanung = true;
        public static bool BezugspersonenJN = false;
        public static string MedikamenteAbgebenTabText = "Medikamente verabreichen";

        private static bool _RechFloskel = false;
        private static bool _KuerzungGrundleistungLetzterTag = false;
        private static string _ZAHLUNG_TAGE;
        private static bool _bookingJN = false;
        private static int _TageOhneKuerzungGrundleistung = 0;
        public static bool RechErwAbwesenheit = false;
        public static bool SrErwAbwesenheit = false;

        public static string GSBGTxt = "";
        public static string TransferTxt = "";
        public static string DepotgeldKontoTxt = "";
        public static string RechTitelDepotGeld = "Abrechnung für Barauslagen";

        public static string MailServiceCenter = "ServiceCenter@s2-engineering.com;";
        public static string eMailStammdaten = "";
        public static bool AbwesenheitenMinimalUI = false;

        public static bool DicomViewerFileOnly = true;
        private static bool _appRunning = false;


        // ---------- Lizenzschalter ------------------
        public static int lic_eMailBewerber = 0;
        public static bool lic_VO = false;
        public static bool lic_VOLager = false;
        public static bool lic_WundtherapieOffenWarnung = false;
        public static bool lic_ELGA = false;
        public static bool lic_RezepteintragStorno = false;

        //---------------------------------------------

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

        public static bool RechnungKopfzeileEin = false;


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
            PrintTermine = 3
        }
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
            return !ENV.SimpleInstall.Trim().Equals("1") ? "PMDS" : "";
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

        public static void initClass(string LogPathPMDSFromLauncher)
        {
            ENV.sRootDir = Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\"));
            ENV.path_bin = Application.StartupPath;

            if (LogPathPMDSFromLauncher.Trim() == "")
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
            if (NotfallChanged != null)
                NotfallChanged(sender, args);
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
            if (dMainWindowResized != null)
                dMainWindowResized(sMainWindow);
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

        public static bool AppRunning
        {
            get { return _appRunning; }
            set { _appRunning = value; }
        }
       


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
                        string test1 = RBUSF.Encrypt(false, DateTime.Now, "12345678");

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
    //            ConfigFile cfgUser;

                Log.RegisterStandardLog(LogDestinations.EventLog, "PMDS");					// Standard zum Eventlog

                cfg = new RBU.ConfigFile(PMDS.Global.ENV.sConfigFile);						// Konfigurationsdatei 
                _ConfigFile = cfg;

                //StreamWriter myWriter = File.CreateText(userConfig);
                //myWriter.WriteLine("");
                //myWriter.Close();

                //cfgUser = new RBU.ConfigFile(userConfig, true);
                //_ConfigFileUser = cfgUser;

                _Log = Log.LOG;
                _Log.ConfigFile = _ConfigFile;

                //_Log.ConfigFileUser = _ConfigFileUser;
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

                //if (CkeckDBVersion() == false)												// Datenbankversion prüfen
                //    return false;

    //            if (CkeckLicense() == false)													// Lizenz prüfen
    //                return false;


                string stemp = "";

                ReadPPTipConfig();
                readIniCalc();
                readIniSMTP();
                ReadPflegemodelle();                                          

                ENV.RezeptDruck = RBUSF.ConvertStringToInt(_Log.ConfigFile.GetStringValue("RezeptDruck"));
                ENV.RezeptBestellModus = RBUSF.ConvertStringToInt(_Log.ConfigFile.GetStringValue("RezeptBestellModus"));

                ShowAufnahmeButton = _Log.ConfigFile.GetStringValue("SHOW_AUFNAHMEBUTTON") == "ON" ? true : false;

                stemp = _Log.ConfigFile.GetStringValue("PMDSNew");
                if (stemp.Length > 0)
                {
                    if (stemp.Trim().Equals(("1")))
                    {
                        ENV.PMDSNew = true;
                    }
                }

                stemp = _Log.ConfigFile.GetStringValue("OnlyOneFavoritenComboinPlanung");
                if (stemp.Length > 0 && stemp == "0")
                    PMDS.Global.ENV.OnlyOneFavoritenComboinPlanung = false;
                        
                stemp = _Log.ConfigFile.GetStringValue("BezugspersonenJN");
                if (stemp.Length > 0 && stemp == "1")
                    PMDS.Global.ENV.BezugspersonenJN = true;

                stemp = _Log.ConfigFile.GetStringValue("TypeRessourcesRun");
                if (stemp.Length > 0)
                    PMDS.Global.ENV.TypeRessourcesRun = stemp;

                stemp = _Log.ConfigFile.GetStringValue("DoNotShowRessources");
                if (stemp.Length > 0)
                {
                    if (stemp.Trim() == "1")
                    {
                        PMDS.Global.ENV.DoNotShowRessources = true;
                    }
                }
                qs2.core.vb.compLayout.DoNotShowRessources = PMDS.Global.ENV.DoNotShowRessources;

                string sAsynCommCheckMessagesSeconds = _Log.ConfigFile.GetStringValue("AsynCommCheckMessagesSeconds");
                if (sAsynCommCheckMessagesSeconds.Trim() != "")
                {
                    ENV.AsynCommCheckMessagesSeconds = System.Convert.ToInt32(sAsynCommCheckMessagesSeconds.Trim());
                }

                stemp = _Log.ConfigFile.GetStringValue("AutoAddNewRessources");
                if (stemp.Length > 0)
                {
                    if (stemp.Trim() == "1")
                    {
                        PMDS.Global.ENV.AutoAddNewRessources = true;               
                    }
                }

                stemp = _Log.ConfigFile.GetStringValue("IntDeactivated");
                if (stemp.Length > 0)
                {
                    if (stemp.Trim() == "0")
                    {
                        PMDS.Global.ENV.IntDeactivated = false;
                    }
                }

                stemp = _Log.ConfigFile.GetStringValue("MedikamenteAbgebenTabText");
                if (stemp.Length > 0)
                    PMDS.Global.ENV.MedikamenteAbgebenTabText = stemp;

                stemp = _Log.ConfigFile.GetStringValue("ArchivPath");
                if (stemp.Length > 0)
                {
                    PMDS.Global.ENV.ArchivPath = stemp;
                    PMDS.Global.ENV.check_Path(ENV.ArchivPath, true);
                }

                stemp = _Log.ConfigFile.GetStringValue("RptConfigPath");
                if (stemp.Length > 0)
                {
                    PMDS.Global.ENV.ReportConfigPath = stemp;
                    PMDS.Global.ENV.check_Path(ENV.ReportConfigPath, true);
                }
                else
                    throw new Exception("Der Wert RptConfigPath in der Config-Datei darf nicht leer sein!");

                stemp = _Log.ConfigFile.GetStringValue("DSNGiboDat");
                if (stemp.Length > 0)
                {
                    ENV.conGiboDat = new System.Data.OleDb.OleDbConnection(stemp);
                    ENV.conGiboDat.Open();
                }

                stemp = _Log.ConfigFile.GetStringValue("SpellCheckerOn");
                if (stemp.Length > 0 && stemp.Trim().Equals("1"))
                    PMDS.Global.ENV.SpellCheckerOn = true;

                stemp = _Log.ConfigFile.GetStringValue("frmRechnung");
                if (stemp.Length > 0)
                    PMDS.Global.ENV.frmRechnung = stemp;

                stemp = _Log.ConfigFile.GetStringValue("FullEditMode");
                if (stemp.Length > 0 && stemp.Trim().Equals("1"))
                    PMDS.Global.ENV.FullEditMode = true;

                stemp = _Log.ConfigFile.GetStringValue("AssessmentModifyTime");
                if (stemp.Length > 0)
                    uint.TryParse(stemp.Trim(), out PMDS.Global.ENV.AssessmentModifyTime);

                stemp = _Log.ConfigFile.GetStringValue("UseDekursKopieren");
                if (stemp.Length > 0 && stemp.Trim().Equals("0"))
                    PMDS.Global.ENV.UseDekursKopieren = false;

                stemp = _Log.ConfigFile.GetStringValue("PasswordStrength");
                if (stemp.Length > 0)
                {
                    int pwStrength = (int)PMDS.Global.ENV.PasswordStrength;
                    int.TryParse(stemp.Trim(), out pwStrength);
                    PMDS.Global.ENV.PasswordStrength = (PasswordScore)pwStrength;
                }

                stemp = _Log.ConfigFile.GetStringValue("MaxPasswordAge");
                if (stemp.Length > 0)
                    int.TryParse(stemp.Trim(), out PMDS.Global.ENV.MaxPasswordAge);

                stemp = _Log.ConfigFile.GetStringValue("MaxIdleTime");
                if (stemp.Length > 0)
                    uint.TryParse(stemp.Trim(), out PMDS.Global.ENV.MaxIdleTime);

                stemp = _Log.ConfigFile.GetStringValue("ToleranzIntervall");
                if (stemp.Length > 0)
                    int.TryParse(stemp.Trim(), out PMDS.Global.ENV.ToleranzIntervall);

                stemp = _Log.ConfigFile.GetStringValue("CheckScreenSize");
                if (stemp.Length > 0 && stemp.Trim().Equals("1"))
                    PMDS.Global.ENV.CheckScreenSize = true;

                stemp = _Log.ConfigFile.GetStringValue("ImportBefundeVerzeichnis");
                if (stemp.Length > 0)
                    ENV.ImportBefundeVerzeichnis = stemp.Trim();

                stemp = _Log.ConfigFile.GetStringValue("ImportBefundeArchivOrdner");
                if (stemp.Length > 0)
                    ENV.ImportBefundeArchivOrdner = stemp.Trim();

                stemp = _Log.ConfigFile.GetStringValue("BerufsstandArzt");
                if (stemp.Length > 0)
                    ENV.BerufsstandArzt = stemp.Trim();

                stemp = _Log.ConfigFile.GetStringValue("BerufsstandPflege");
                if (stemp.Length > 0)
                    ENV.BerufsstandPflege = stemp.Trim();

                stemp = _Log.ConfigFile.GetStringValue("StrgDefaults");
                if (stemp.Length > 0)
                    ENV.StrgDefaults = stemp.Trim() + ",";

                stemp = _Log.ConfigFile.GetStringValue("BerufsstandTherapie");
                if (stemp.Length > 0)
                    ENV.BerufsstandTherapie = stemp.Trim();

                stemp = _Log.ConfigFile.GetStringValue("eMailStammdaten");
                if (stemp.Length > 0)
                    ENV.eMailStammdaten = stemp.Trim();

                stemp = _Log.ConfigFile.GetStringValue("AbwesenheitenMinimalUI");
                if (stemp.Length > 0 && stemp.Trim().Equals("1"))
                    PMDS.Global.ENV.AbwesenheitenMinimalUI = true;

                stemp = _Log.ConfigFile.GetStringValue("DicomViewerFileOnly");
                if (stemp.Length > 0 && stemp.Trim().Equals("0"))
                    PMDS.Global.ENV.DicomViewerFileOnly = false;

                stemp = _Log.ConfigFile.GetStringValue("PathDokumente");
                if (stemp.Length > 0)
                    ENV.PathDokumente = stemp.Trim();

                stemp = _Log.ConfigFile.GetStringValue("HAG_Url");
                if (stemp.Length > 0)
                    ENV.HAG_Url = stemp.Trim();

                stemp = _Log.ConfigFile.GetStringValue("HAG_Zertifikat");
                if (stemp.Length > 0)
                    ENV.HAG_Zertifikat = stemp.Trim();

                stemp = _Log.ConfigFile.GetStringValue("HAG_User");
                if (stemp.Length > 0)
                    ENV.HAG_USER = stemp.Trim();

                stemp = _Log.ConfigFile.GetStringValue("HAG_Password");
                if (stemp.Length > 0)
                    ENV.HAG_PASSWORD = PMDS.BusinessLogic.BUtil.DecryptString(stemp.Trim());

                stemp = _Log.ConfigFile.GetStringValue("CheckConnectionAndPassword");
                if (stemp.Length > 0)
                {
                    if (stemp.Trim().Equals(("1")))
                    {
                        ENV.CheckConnectionAndPassword = true;
                    }
                }

                stemp = _Log.ConfigFile.GetStringValue("DekursRegex");
                if (stemp.Length > 0)
                    ENV.DekursRegex = stemp.Trim();

                stemp = _Log.ConfigFile.GetStringValue("DekursRegexBeschreibung");
                if (stemp.Length > 0)
                    ENV.DekursRegexBeschreibung = stemp.Trim();

                stemp = _Log.ConfigFile.GetStringValue("License");
                if (stemp.Length > 0)
                    ENV.License = BusinessLogic.BUtil.DecryptString(stemp.Trim());

                stemp = _Log.ConfigFile.GetStringValue("ZahlKondBankeinzug");
                if (stemp.Length > 0)
                    ENV.ZahlKondBankeinzug = stemp.Trim();
                stemp = _Log.ConfigFile.GetStringValue("ZahlKondErlagschein");
                if (stemp.Length > 0)
                    ENV.ZahlKondErlagschein = stemp.Trim();
                stemp = _Log.ConfigFile.GetStringValue("ZahlKondÜberweisung");
                if (stemp.Length > 0)
                    ENV.ZahlKondÜberweisung = stemp.Trim();
                stemp = _Log.ConfigFile.GetStringValue("ZahlKondBar");
                if (stemp.Length > 0)
                    ENV.ZahlKondBar = stemp.Trim();

                stemp = _Log.ConfigFile.GetStringValue("AbwesenheitenAnzeigen");
                if (stemp.Length > 0)
                {
                    if (stemp.Trim().Equals(("1")))
                    {
                        ENV.AbwesenheitenAnzeigen = true;
                    }
                    else if (stemp.Trim().Equals(("0")))
                    {
                        ENV.AbwesenheitenAnzeigen = false;
                    }
                }

                stemp = _Log.ConfigFile.GetStringValue("WundtherapieVidieren");
                if (stemp.Length > 0)
                {
                    if (stemp.Trim().Equals(("1")))
                    {
                        ENV.WundtherapieVidieren = true;
                    }
                }

                stemp = _Log.ConfigFile.GetStringValue("WundbildModifyTime");
                if (stemp.Length > 0)
                    uint.TryParse(stemp.Trim(), out PMDS.Global.ENV.WundbildModifyTime);

                stemp = _Log.ConfigFile.GetStringValue("WundtherapieModifyTime");
                if (stemp.Length > 0)
                    uint.TryParse(stemp.Trim(), out PMDS.Global.ENV.WundtherapieModifyTime);

                stemp = _Log.ConfigFile.GetStringValue("WundverlaufModifyTime");
                if (stemp.Length > 0)
                    uint.TryParse(stemp.Trim(), out PMDS.Global.ENV.WundverlaufModifyTime);


                string WCFServiceOnOffTmp = _Log.ConfigFile.GetStringValue("WCFServiceOnOff");
                if (WCFServiceOnOffTmp.Trim() != "")
                {
                    if (WCFServiceOnOffTmp.Trim().Equals(("1")))
                    {
                        ENV.WCFServiceOnOff = true;
                    }
                }

                string UrlWCFServicePMDSTmp = _Log.ConfigFile.GetStringValue("UrlWCFServicePMDS");
                if (UrlWCFServicePMDSTmp.Trim() != "")
                {
                    ENV.UrlWCFServicePMDS = UrlWCFServicePMDSTmp.Trim();
                }
                string WCFServicePMDSAsConsoleTmp = _Log.ConfigFile.GetStringValue("WCFServicePMDSAsConsole");
                if (WCFServicePMDSAsConsoleTmp.Trim() != "")
                {
                    if (WCFServicePMDSAsConsoleTmp.Trim().Equals(("1")))
                    {
                        ENV.WCFServicePMDSAsConsole = true;
                    }
                }
                string WCFServicePMDSDebugPathTmp = _Log.ConfigFile.GetStringValue("WCFServicePMDSDebugPath");
                if (WCFServicePMDSDebugPathTmp.Trim() != "")
                {
                    ENV.WCFServicePMDSDebugPath = WCFServicePMDSDebugPathTmp.Trim();
                }

                string SchnellrückmeldungAsProcessTmp = _Log.ConfigFile.GetStringValue("SchnellrueckmeldungAsProcess");
                if (SchnellrückmeldungAsProcessTmp.Trim() != "")
                {
                    ENV.SchnellrückmeldungAsProcess = SchnellrückmeldungAsProcessTmp.Trim();
                }

                QS2.Logging.ENV.init(ENV._LOGPATH, true, ENV.adminSecure);
                QS2.Desktop.ControlManagment.ENV.init(ref PMDS.Global.ENV.IDApplication, ref PMDS.Global.ENV.TypeRessourcesRun, ENV.adminSecure, 
                                                        ENV.DoNotShowRessources, ENV.AutoAddNewRessources, ENV.IntDeactivated, DataBase.CONNECTIONSqlClient);  
                QS2.Desktop.Txteditor.ENV.init(ENV.path_Temp, ENV._LOGPATH, true, ENV.adminSecure);

                PMDSClient.PMDSClientWrapper.init();

                //Lizenzschalter setzen
                ENV.lic_eMailBewerber = setLicValue("lic_eMailBewerber", ENV.lic_eMailBewerber, 2);
                ENV.lic_VO = setLicValue("lic_VO");
                ENV.lic_VOLager = setLicValue("lic_VOLager");
                ENV.lic_ELGA = setLicValue("lic_ELGA");
                ENV.lic_WundtherapieOffenWarnung = setLicValue("lic_WundtherapieOffenWarnung");
                ENV.lic_RezepteintragStorno = setLicValue("lic_RezepteintragStorno");

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("ENV.Init: " + ex.ToString());
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
                    sqlBuilder.Password = Pwd == null ? "" : Pwd;
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

        public static bool readIniCalc()
        {
            string stemp = _Log.ConfigFile.GetStringValue("adminSecure");
            if (stemp.Length > 0 && stemp == "1")
                PMDS.Global.ENV.adminSecure = true; 

            stemp = _Log.ConfigFile.GetStringValue("bookingJN");
            if (stemp.Length > 0 && stemp == "1")
                bookingJN = true;

            stemp = _Log.ConfigFile.GetStringValue("APVDA");
            if (stemp.Length > 0)
            {
                if (stemp.Trim() != "")
                {
                    qs2.license.core.Encryption Encryption1 = new qs2.license.core.Encryption();
                    string tmpStr = Encryption1.StringDecrypt(stemp.Trim(), qs2.license.core.Encryption.keyForEncryptingStrings);
                    if (tmpStr.Trim() == "1")
                    {
                        ENV.APVDA = true;  
                    }
                }
            }

            stemp = _Log.ConfigFile.GetStringValue("MedikamenteImportType");
            if (stemp.Length > 0)
                ENV.MedikamenteImportType = stemp.Trim();

            stemp = _Log.ConfigFile.GetStringValue("ftpFileImportMedikamente");
            if (stemp.Length > 0)
                ENV.ftpFileImportMedikamente = stemp.Trim();


            stemp = _Log.ConfigFile.GetStringValue("ftpUserName");
            if (stemp.Length > 0)
                ENV.ftpUserName = stemp.Trim();


            stemp = _Log.ConfigFile.GetStringValue("ftpPassword");
            if (stemp.Length > 0)
            {
                ENV.ftpPassword = stemp.Trim();
                qs2.license.core.Encryption Encryption1 = new qs2.license.core.Encryption();
                ENV.ftpPassword = Encryption1.StringDecrypt(stemp.Trim(),  qs2.license.core.Encryption.keyForEncryptingStrings);
            }

            stemp = _Log.ConfigFile.GetStringValue("ProxyJN");
            if (stemp.Length > 0 && stemp.Trim().Equals("1"))
                ENV.ProxyJN = true;

            stemp = _Log.ConfigFile.GetStringValue("ProxyUserName");
            if (stemp.Length > 0)
                ENV.ProxyUserName = stemp.Trim();

            stemp = _Log.ConfigFile.GetStringValue("ProxyPassword");
            if (stemp.Length > 0)
            {
                qs2.license.core.Encryption Encryption1 = new qs2.license.core.Encryption();
                ENV.ProxyPassword = Encryption1.StringDecrypt(stemp.Trim(), qs2.license.core.Encryption.keyForEncryptingStrings);
            }

            stemp = _Log.ConfigFile.GetStringValue("ProxyDomain");
            if (stemp.Length > 0)
                ENV.ProxyDomain = stemp.Trim();

            stemp = _Log.ConfigFile.GetStringValue("ProxyHost");
            if (stemp.Length > 0)
                ENV.ProxyHost = stemp.Trim();

            stemp = _Log.ConfigFile.GetStringValue("ProxyPort");
            if (stemp.Length > 0)
                ENV.ProxyPort = System.Convert.ToInt32(stemp.Trim());

            stemp = _Log.ConfigFile.GetStringValue("ProxyAuthentication");
            if (stemp.Length > 0)
                ENV.ProxyAuthentication = stemp.Trim();
            

            //stemp = _Log.ConfigFile.GetStringValue("Bereich");
            //if (stemp.Length > 0)
            //{
            //    Bereich = stemp.Trim();
            //}

            stemp = _Log.ConfigFile.GetStringValue("typRechNr");
            if (stemp.Length > 0)
                typRechNr = stemp.Trim();

            stemp = _Log.ConfigFile.GetStringValue("RechnungKopfzeileEin");
            if (stemp.Length > 0 && stemp == "1")
                RechnungKopfzeileEin = true;

            stemp = _Log.ConfigFile.GetStringValue("RechFloskel");
            if (stemp.Length > 0 && stemp == "1")
                RechFloskel = true;

            stemp = _Log.ConfigFile.GetStringValue("KuerzungGrundleistungLetzterTag");
            if (stemp.Length > 0 && stemp == "1")
                KuerzungGrundleistungLetzterTag = true;

            stemp = _Log.ConfigFile.GetStringValue("TageOhneKuerzungGrundleistung");
            if (stemp.Length > 0)
                TageOhneKuerzungGrundleistung = System.Convert.ToInt32(stemp); 

            stemp = _Log.ConfigFile.GetStringValue("RechErwAbwesenheit");
            if (stemp.Length > 0 && stemp == "1")
                RechErwAbwesenheit = true;

            stemp = _Log.ConfigFile.GetStringValue("SrErwAbwesenheit");
            if (stemp.Length > 0 && stemp == "1")
                SrErwAbwesenheit = true;

            stemp = _Log.ConfigFile.GetStringValue("ZAHLUNG_TAGE");
            if (stemp.Length > 0)
                ZAHLUNG_TAGE = stemp;

            stemp = _Log.ConfigFile.GetStringValue("GSBGTxt");
            if (stemp.Length > 0)
                PMDS.Global.ENV.GSBGTxt = stemp;

            stemp = _Log.ConfigFile.GetStringValue("TransferTxt");
            if (stemp.Length > 0)
                PMDS.Global.ENV.TransferTxt = stemp;

            stemp = _Log.ConfigFile.GetStringValue("DepotgeldKontoTxt");
            if (stemp.Length > 0)
                PMDS.Global.ENV.DepotgeldKontoTxt = stemp;

            stemp = _Log.ConfigFile.GetStringValue("RechTitelDepotGeld");
            if (stemp.Length > 0)
                PMDS.Global.ENV.RechTitelDepotGeld = stemp;

            return true;
        }
        public static bool readIniSMTP()
        {
            string stemp = _Log.ConfigFile.GetStringValue("SMTPFrom");
            if (stemp.Length > 0)
                PMDS.Global.clSMTP.SMTPFrom = stemp;

            stemp = _Log.ConfigFile.GetStringValue("SMTPTo");
            if (stemp.Length > 0)
                PMDS.Global.clSMTP.SMTPTo = stemp;

            stemp = _Log.ConfigFile.GetStringValue("SMTPServer");
            if (stemp.Length > 0)
                PMDS.Global.clSMTP.SMTPServer = stemp;

            stemp = _Log.ConfigFile.GetStringValue("SMTPLoginUsr");
            if (stemp.Length > 0)
                PMDS.Global.clSMTP.SMTPLoginUsr = stemp;

            stemp = _Log.ConfigFile.GetStringValue("SMTPLoginPwd");
            if (stemp.Length > 0)
                PMDS.Global.clSMTP.SMTPLoginPwd = stemp;

            stemp = _Log.ConfigFile.GetStringValue("SMTPPort");
            if (stemp.Length > 0)
                PMDS.Global.clSMTP.SMTPPort = System.Convert.ToInt32(stemp);

            return true;
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
        private static void ReadPPTipConfig()
        {
            string stemp = _Log.ConfigFile.GetStringValue("SHOW_PP_TOOLTIP"); // Syntax: OFF | ON;Delay[ms];Duration[ms]
            if (stemp.Length == 0)      // Defaultwerte
                return;

            string[] sa = stemp.Split(';');
            if (sa.Length > 0)
                _ShowPPToolTip = sa[0] == "OFF" ? false : true;

            if (sa.Length == 3)
            {
                _PPToolTipDelay = RBUSF.ConvertStringToInt(sa[1]);
                _PPToolTipDuration = RBUSF.ConvertStringToInt(sa[2]);

                if (_PPToolTipDelay == 0 || _PPToolTipDelay < 50) _PPToolTipDelay = 1000;
                if (_PPToolTipDuration == 0 || _PPToolTipDuration < 1000) _PPToolTipDuration = 50000;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// PflegeModelle aus der Config lesen
        /// </summary>
        //----------------------------------------------------------------------------
        private static void ReadPflegemodelle()
        {
            List<PflegeModelle> sl = new List<PflegeModelle>();
            string stemp = _Log.ConfigFile.GetStringValue("PFLEGEMODELLE");
            if (stemp.Trim().Length == 0)
            {
                //QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bei der Verarbeitung der Konfigurationsdatei ist ein Fehler aufgetreten.\r\nPrüfen Sie den Eintrag PFLEGEMODELLE\r\nEs ist nur Orem, POP und Krohwinkel erlaubt\r\n");
                //return;
            }

            string[] sa = stemp.Split(',');
            bool bError = false;

            if (sa[0].ToString() != "")
            {
                foreach (string s in sa)
                {
                    try
                    {
                        sl.Add((PflegeModelle)Enum.Parse(typeof(PflegeModelle), s, true));
                    }
                    catch
                    {
                        bError = true;
                    }
                }

                if (bError)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bei der Verarbeitung der Konfigurationsdatei ist ein Fehler aufgetreten.\r\nPrüfen Sie den Eintrag PFLEGEMODELLE\r\nEs sind nur Orem, Krohwinkel und POP erlaubt\r\n");
                    return;
                }

                PflegeModelle[] sa2 = sl.ToArray();
                if (sa2.Length == 0)
                    return;
                PflegeModell = sa2;

            }

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








        public static void HandleException(Exception e, string sType = "Exception", bool ShowMsgBox = true, bool checkOutOfMemory = true)
        {
            QS2.Logging.ENV.init(ENV.LOGPATH, true, qs2.core.ENV.adminSecure);
            string sHostName = System.Net.Dns.GetHostName();

            string IPAdress = "";
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
                    string sExcept6 = "Host: " + sHostName.Trim() + ", IPAdress: " + IPAdress.Trim() + ", User: " + sUsrLoggedIn.Trim() + ", Type:" + sType.Trim() + "\r\n" + "\r\n" + e.ToString();
                    
                    PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                    b.saveProtocol(db, "ExceptionPMDS", sExcept6.Trim());
                }
            }
            catch (Exception ex8)
            {
                string sExcept = ex8.ToString();
            }

            DateTime dNow = DateTime.Now;
            if (ENV.WCFServiceOnOff)
            {
                //if (!PMDS.Global.db.ERSystem.PMDSBusinessUI.checkClientsS2())
                //{
                    ENV ENV1 = new ENV();
                    cParsSendException ParsSendException = new cParsSendException();
                    ParsSendException.sException = e.ToString();
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
                QS2.Logging.ENV.doLog2(sExceptNr + e.ToString(), dNow, sHostName.Trim(), IPAdress.Trim(), sUsrLoggedIn.Trim(), sType.Trim(), true, ShowMsgBox);
                //QS2.Logging.ENV.doLog(sExceptNr + e.ToString(), "", "PMDS-System", true);
                if (checkOutOfMemory)
                    ENV.checkExceptionOutOfMemory(e.ToString(), sType, ShowMsgBox);
            }
            else
            {
                QS2.Logging.ENV.doLog2(e.ToString(), dNow, sHostName.Trim(), IPAdress.Trim(), sUsrLoggedIn.Trim(), sType.Trim(), true, ShowMsgBox);
                if (checkOutOfMemory)
                    ENV.checkExceptionOutOfMemory(e.ToString(), sType, ShowMsgBox);
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
        public static void checkExceptionOutOfMemory(string except, string sType, bool ShowMsgBox)
        {
            if (except.Trim().ToLower().Contains(("OutOfMemoryException").Trim().ToLower()))                //System.OutOfMemoryException
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der max. Speicherverbrauch für PMDS wurde überschritten! (32 Bit Version)" + "\r\n" +
                                                                            "PMDS muss neu gestartet werden!", "PMDS", MessageBoxButtons.OK);

                //Exception exTmp = new Exception(DateTime.Now.ToString() + "User has verifyed the message RAM is too high for App PMDS!");
                //ENV.HandleException(exTmp, "ExceptionRAM", false, false);         //lthxy
                //ENV.killApp();
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










        public static string GetReportFileName(string sKey)
        {
            switch (sKey)
            {
                case "AUFGABENLISTE": return "rptAufgabenListe.rpt";
                case "PFLEGERKARTE": return "rptPflegerKarte.rpt";
                case "PFLEGPLAN": return "PflegePlan.rpt";
                case "MEDIKAMENTVORBEREITUNG": return "MedikamentVorbereitung.rpt";
                case "MEDIKAMENTENAUSGABE": return "MedikamentenAusgabe.rpt";
                case "MEDIKAMENTENBLATT": return "MedikamentenBlatt.rpt";
                case "MEDIKAMENTEBESTELLUNG": return "MedikamenteBestellung.rpt";
                case "REZEPTDRUCK": return "RezeptDruck.rpt";
                case "UNTERBRINGUNG": return "Unterbringung.rpt";
                case "UNTERBRINGUNG2010": return "Unterbringung2010.rpt";
                case "NOTFALLBLATT": return "Notfall.rpt";
                case "BEWERBERSTAMMDATENBLATT": return "BewerberstammdatenBlatt.rpt";
                case "KLIENTENSTAMMDATENBLATT": return "Klientenstammdatenblatt.rpt";
                case "HEIMVERTRAG": return "HeimVertrag.rpt";
                case "BEWERBERLISTE": return "Bewerberliste.rpt";
                case "TASCHENGELD": return "Taschengeld.rpt";
                case "RECHNUNG": return "rptRechnung.rpt";
                case "manBuchungen": return "manBuchungen.rpt";
                case "BestellungMedikamente": return "BestellungMedikamente.rpt";
                case "AnforderungRezepte": return "AnforderungRezepte.rpt";
                case "DruckRezepte": return "DruckRezepte.rpt";
                case "Arztbrief": return "Arztbrief.rpt";                       //lthArztabrechnung   
                case "Diagnoseliste": return "Diagnoseliste.rpt";

                default: return "Report " + sKey.Trim() + " not found";
            }
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

        public static string GetReportFileNameFromConfig(string sKey)
        {
            string sPath = ReportPath;
            if (sPath.Length == 0)
                sPath = ".\\";
            if (!sPath.EndsWith("\\"))
                sPath += "\\";
            sPath += GetReportFileName(sKey);
         
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
        [Description("Pflegeplan ändern")]
        BerichteParameterBearbeiten = 9,		            // Pflegeplan ändern
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
        DNR_Palliativ = 109


            

        //,
        //[Description("EDIFACT Import")]
        //EDIFACT_Import = 75

        //-------------------------------------------------------------------
        // NICHT MEHR VERWENDET !!!
        //-------------------------------------------------------------------
        //ManageStationPDx		= 2,		// ??? Abteilungsabhängige Pflegedefinitionen verwalten
        //ManageTimePlan			= 4,		// ??? Zeitliche Planung durchführen (Rückmeldungen)
        //CreateStatistics		= 8,		// ??? Statistik erstellen
        //PrintEvaluationList		= 9,		// ??? Evaluierungsliste drucken
        //PrintPlan				= 13,		// ??? Pflegeplan drucken
        //ChangeStation			= 5,		// Station wechseln
        //PatDelete				= 45,		// Patienten löschen
        //ASZM_Add				= 46,		// ASZM hinzufügen
        //ASZM_Del				= 47,		// ASZM löschen
        //ASZM_EintragZusatz_Edit	= 48,		// ASZM EintragZusatz bearbeiten
        //PatRemark				= 33,		// Patienten Bemerkungen
        //ReportUnexpMeasure		= 35,		// unerwartetet Maßnahmen rückmelden
        //PatVermerk				= 36,		// Patienten Vermerk
        //FullKlinik				= 16,		// gesamte Klinik verwalten (sonst nur aktuelle Abteilung)
        //ReportBackEvaluation	= 11,		// Evaluierung rückmelden
        //ReportBackBulk			= 37,		// Stapelrückmeldungen
        //ChangeImportantGroup	= 38,		// Zuordnung der Wichtigkeit (Berufsgruppe)
        //PrintTimePlan			= 15,		// Zeitlichen Ablauf drucken
        //PrintLetter				= 14,		// Pflegebrief drucken
        //PrintAufgaben			= 40,		// Aufgaben drucken
        //PatBereichVersetzung	= 42,		// Patienten Bereich versetzen
        //ManageDatabase			= 17,		// Sämtliche Datenbankverwatungsaufgaben erledigen (Backup)
        //ManageKlinik			= 18,		// Klinik verwalten
        //ManageEinrichtung		= 19,		// Einrichtungen verwalten
        //ManageDefExtensionItems	= 24,		// Definieren der Zusatzeinträge
        //ManageSetExtensionItems	= 25,		// Zuordnen der Zusatzeinträge
        //ManageASZM				= 26,		// ASZM verwalten
        //ManagePDx				= 1,		// Pflegedefinitionen verwalten
        //ManageTop10				= 27,		// Top 10 Liste verwalten
        //ManageMedikamente		= 51,		// Medikamente verwalten
        //ManageFormulare			= 55,		// Formulare verwalten
        //CreateNewFormulare		= 56,		// Formulare erzeugen
        //ReadFormulare			= 57,		// Formulare anzeigen
        //PrintFormulare			= 58,		// Formulare drucken
        //ManageQuickFilter		= 59,		// Quickfilter verwalten
        //ManageQuickMeldung		= 60,		// Quickmeldung verwalten
        //ShowStartTerminListe	= 61,		// Am startbildschirm Terminliste (Tagesliste) anzeigen
        //ShowStartTerminPlan		= 62,		// Am startbildschirm Terminplan (Planliste) anzeigen 
        //ShowStartUebergabe		= 63,		// Am startbildschirm Übergabe anzeigen
        //ShowStartAufnahme		= 64,		// Am startbildschirm Aufnahme anzeigen
        //ShowStartStapelRM		= 65,		// Am startbildschirm anzeigen
        //PrintBarcodeTerminListe	= 67,		// Barcodeliste drucken
        //DeleteFormulare			= 70		// Formulare löschen
        //KlientenAktSonstigeAendern = 45,      //Button für Klientenakt im Hauptmenü
        //KlientenAktSonstigeAnzeigen = 31,
        //ArchivTerminMailSucheGesamtxy = 52,
        //AnmeldenOhneAbteilung = 3,		                    // Anmeldung ohne Abteilung zulassen
        //CreateClassification = 7,		                        // Einstufung nach Orem erstellen
        //DeleteClassification = 8,		                        // Einstufung nach Orem löschen
        //ManageGroupRightsxy = 16,		                        // Gruppenrechte verwalten
        //ManageUserRightsxy = 17,		                        // Benutzerrechte verwalten
        //ManageColors = 19,		                            // Farben konfigurieren, laden, speichern
        //LayoutKonfigurierenxy = 20,		                    // Termin Spalten konfigurieren
        //ManageTerminLoadxy = 21,		                        // Termin Spalten laden
        //ManageTerminSave = 22,		                        // Termin Spalten speichern
        //BarcodeVerarbeitungxy = 25,		                    // Barcodes in BarcodeQ verarbeiten
        //ManageDienstzeitenxyxy = 28,		                    // Dienstzeiten verwalten
        //KlickOnGroupPickerRootNode = 59,
        //[Description("Pep Stammdaten verwalten")]
        //ManagePEPBaseData = 50,		                        // Verwalten der Peps Stammdaten
        //[Description("Pep Pläne erstellen")]
        //PepPlanen = 51		                                // Dienstpläne Planen

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

    }

    public enum eCurrentPatientChange
    {
        Picker_linksOben = 0,
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