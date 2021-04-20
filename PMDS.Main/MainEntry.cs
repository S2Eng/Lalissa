using System;
using System.Windows.Forms;

using PMDS.Global;
using PMDS.GUI;
using PMDS.BusinessLogic;

using System.Configuration;
using PMDS.Global.Remote;
using System.Linq;
using System.Diagnostics;

namespace PMDS
{

	public class MainEntry
    {



        static bool ProcessStartup(Form frm, UserRights right, string RightsErrorText, bool bNoLoginRequired, bool testWindow, bool IsTouch  )
        {
            if (!bNoLoginRequired)  
            {
                if (!frmLogin.ProcessLogin())
                    return false;

                if (!ENV.HasRight(right))
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(RightsErrorText, QS2.Desktop.ControlManagment.ControlManagment.getRes("Unzureichende Rechte"), MessageBoxButtons.OK, MessageBoxIcon.Stop, true);
                    return false;
                }
            }       

            if (right == UserRights.AbrechnungStarten)
            {
                if (!testWindow)
                {
                    PMDS.Global.UIGlobal.infoStart.TopMost = true;
                    PMDS.Global.UIGlobal.infoStart.ShowInTaskbar = false;
                    PMDS.Global.UIGlobal.infoStart.StartPosition = FormStartPosition.CenterScreen;
                    if (ENV.COMMANDLINE_bshowSplash)
                        PMDS.Global.UIGlobal.infoStart.Start();
                    //((PMDS.Calc.UI.Admin.frmAbrechnung)frm).initControl();
                }
            } 

            QS2.Desktop.ControlManagment.ENV.setRights(ENV.HasRight(UserRights.Layout));
            qs2.ui.RunFromOhterSystem RunFromOhterSystem1 = new qs2.ui.RunFromOhterSystem();
            RunFromOhterSystem1.LogIn(ENV.pathConfig, "qs2.config", "PMDS", RBU.DataBase.Srv, RBU.DataBase.m_Database, RBU.DataBase.m_sUser, RBU.DataBase.m_sPassword, RBU.DataBase.IsTrusted, PMDS.Global.ENV.LOGPATH);
            qs2.core.ENV.IsHeadquarter = true;

            if (!IsTouch)
            {
                bool PwdNotSucessfullChanged = false;
                PMDS.GUI.ucSiteMapPMDS ucSiteMapPMDS1 = new PMDS.GUI.ucSiteMapPMDS();
                if (!ucSiteMapPMDS1.checkAnonymLogIn(ref PwdNotSucessfullChanged))
                {
                    return false; 
                }

                PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                b.initUserCanSign();
            }

            PMDS.DB.PMDSBusiness bLog = new DB.PMDSBusiness();
            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
            {
                PMDS.db.Entities.Benutzer rUserLoggedIn = bLog.LogggedOnUserWithCheck(db);
                if (rUserLoggedIn != null)
                {
                    ENV.ActiveUser = rUserLoggedIn;
                    if (String.IsNullOrWhiteSpace(ENV.LoginInNameFrei))
                    {
                        ENV.MainCaption = "PMDS (" + ENV.ActiveUser.Nachname + " " + ENV.ActiveUser.Vorname + ") ";
                    }
                    else
                    {
                        ENV.MainCaption = "PMDS (" + ENV.ActiveUser.Benutzer1 + " - " + ENV.LoginInNameFrei + ") ";
                    }
                }
            }

            Application.Run(frm);
            return true;
        }

		[STAThread]
		public static void Main(string[] args) 
		{
			Application.ThreadException+=new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            frmInfo infoStartMain = null;
            try
            {
#if DEMO
#warning DEMO defined
					if(DateTime.Now > new DateTime(2006,8,1))
                {
						QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Diese Version ist abgelaufen,\r\nbitte setzten Sie sich mit ihrem lokalen Administrator in Verbindung");
						return;
					}
#endif

                //qs2.core.generic.evdoLog += new qs2.core.generic.doLog(ENV.errorLogging);


                //if (qs2.core.generic.evdoLog != null)
                //    qs2.core.generic.evdoLog.Invoke(exep, "");
                //else
                //{
                //    string infoExceptTmp = "The following error occured: " + qs2.core.generic.lineBreak + "(This error can influence the quality of the application!)" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + "Please contact your administrator." + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak;
                //    System.Windows.Forms.QS2.Desktop.ControlManagment.ControlManagment.MessageBox(infoExceptTmp + exep.ToString(), "Info Error");
                //}

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                ENV.LOGPATH = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "PMDS");
                if (!System.IO.Directory.Exists(ENV.LOGPATH))
                {
                    System.IO.Directory.CreateDirectory(ENV.LOGPATH);
                }

                ENV.COMMANDLINE_bshowSplash = searchKeyArg("showSplash", args) == "1";
                if (ENV.COMMANDLINE_bshowSplash)
                {
                    infoStartMain = new frmInfo();
                    infoStartMain.TopMost = false;
                    infoStartMain.ShowInTaskbar = true;
                    infoStartMain.StartPosition = FormStartPosition.CenterScreen;
                    infoStartMain.Start();
                }

                PMDS.DB.PMDSBusinessComm.setUniqueIDMachine();
                //<20130212> Simple Install-Parameter integriert, für Einfache direkte installation -> siehe 
                ENV.SimpleInstall = searchKeyArg("SimpleInstall", args);
                ENV.StartFromShare = searchKeyArg("StartFromShare", args);
                remotingSrv.showMsgBoxTestmodus("StartFromShare: " + ENV.StartFromShare);
                string LogPathPMDSFromLauncher = searchKeyArg("logPathPMDS", args);

                string sDoOrigPathConfig = searchKeyArg("DoOrigPathConfig", args);
                if (sDoOrigPathConfig.Trim() == "1")
                {
                    ENV.DoOrigPathConfig = true;
                    remotingSrv.showMsgBoxTestmodus("DoOrigPathConfig: true");
                }

                ENV.ConfigFileLauncher = searchKeyArg("ConfigFileLauncher", args);
                ENV.LauncherExe = searchKeyArg("LauncherExe", args);

                //<20120209> Pfad zum Config-Directory MUSS mitgegeben werden!!    /PMDS/<bindir>/Config wird automatisch angehängt!
                ENV.sConfigRootDir = searchKeyArg("ConfigPath", args);
                remotingSrv.showMsgBoxTestmodus("ConfigPath: " +  ENV.sConfigRootDir);

                string typ = searchKeyArg("typ", args);
                typ = typ.ToLower();
                ENV.StartupTyp = typ;

                ENV.OrigConfigDir = ENV.sConfigRootDir;
                if (ENV.sConfigRootDir != "")
                {
                    ENV.initClass(LogPathPMDSFromLauncher);
                }
                else
                {
                    if (Application.StartupPath.Trim().EndsWith(("Debug").Trim(), StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (ENV.sConfigRootDir.Trim().Equals("", StringComparison.CurrentCultureIgnoreCase))
                        {
                            System.IO.DirectoryInfo dirInfo = System.IO.Directory.GetParent(Application.StartupPath);
                            dirInfo = System.IO.Directory.GetParent(dirInfo.FullName);
                            ENV.sConfigRootDir = dirInfo.FullName;
                            PMDS.Global.ENV.sConfigFile = "PMDS.config";
                            ENV.SimpleInstall = "1";
                            ENV.initClass(LogPathPMDSFromLauncher);
                        }
                    }
                    else
                    {
                        throw new Exception("Kommandozeilenparameter ?ConfigPath fehlt.");
                    }
                }

                //PMDS.Global.Other.AppConfig.Change(ENV.exeConfig);
                //AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", ENV.exeConfig);

                //<20120209> Name des Config-Files MUSS mitgegeben werden!!
                string configFileRead = searchKeyArg("ConfigFile", args);
                remotingSrv.showMsgBoxTestmodus("ConfigFile: " + configFileRead);

                ENV.OrigConfigFile = configFileRead;
                if (configFileRead != "")
                {
                    PMDS.Global.ENV.sConfigFile = System.IO.Path.Combine(ENV.pathConfig, configFileRead);
                }
                else
                {
                    if (!Application.StartupPath.Trim().EndsWith(("Debug").Trim(), StringComparison.CurrentCultureIgnoreCase))
                    {
                        throw new Exception("Kommandozeilenparameter ?ConfigFile fehlt.");
                    }
                }

                string sConfigFileOnlyFileNameTmp = System.IO.Path.GetFileName(PMDS.Global.ENV.sConfigFile.Trim());
                Global.db.ERSystem.PMDSBusinessUI.cItmTg ItmTgSel = MainEntry.checkSelectConfigs(ENV.StartupTyp, ENV.pathConfig, sConfigFileOnlyFileNameTmp, ref infoStartMain, false);
                if (ItmTgSel != null)
                {
                    PMDS.Global.ENV.sConfigFile = System.IO.Path.Combine(ENV.pathConfig, ItmTgSel.fileNameOnly.Trim());
                }

                ENV.COMMANDLINE_USER = searchKeyArg("usr", args);
                ENV.COMMANDLINE_PWD = searchKeyArg("pwd", args);

                if (ENV.Init(false) == false)   
                    return;

                anycpu_deployment.DLLDispatcher.BinPath = PMDS.Global.ENV.path_bin;
                anycpu_deployment.DLLDispatcher.HookOnCurrentAppDomain();
                /*<runtime><loadFromRemoteSources enabled="true"/></runtime>  -- Nicht vergessen in Config!  */

                ENV.initELGAFormatter();

                PMDS.GUI.VB.General.MainCallFcts = new GUI.VB.General.dMainCallFcts(ucSiteMapPMDS.MainCallDel);

                PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();

                if (typ == "abrech")
                {
                    qs2.ui.RunFromOhterSystem RunFromOhterSystem1 = new qs2.ui.RunFromOhterSystem();
                    RunFromOhterSystem1.LogIn(ENV.pathConfig, "qs2.config", "PMDS", RBU.DataBase.Srv, RBU.DataBase.m_Database, RBU.DataBase.m_sUser, RBU.DataBase.m_sPassword, RBU.DataBase.IsTrusted, PMDS.Global.ENV.LOGPATH);
                    PMDS.Global.ENV.setStyleInfrag(true);
                    qs2.core.ENV.IsHeadquarter = true;
                    PMDS.Calc.Logic.calculation.delgetDBContext += new Calc.Logic.calculation.getDBContext(PMDS.DB.PMDSBusiness.getDBContext2);
                    PMDS.Calc.Logic.calculation.delCallFctMainSystem += new Calc.Logic.calculation.CallFctMainSystem(ENV.CallFctMainSystem);
                
                    PMDS.Global.db.ERSystem.EFEntities EFEntities1 = new Global.db.ERSystem.EFEntities();
                    EFEntities1.init2(true);
                    if (infoStartMain != null)
                        infoStartMain.Close();
                    ProcessStartup(new PMDS.Calc.UI.Admin.frmMainCalc(), UserRights.AbrechnungStarten, QS2.Desktop.ControlManagment.ControlManagment.getRes("Sie verfügen nicht über die notwendigen Rechte um die Abrechnung direkt zu starten"), false, false, false);            // Abrechnung starten 
                }
                else if (typ == "depotabrech")
                {
                    if (infoStartMain != null)
                        infoStartMain.Close();
                    PMDS.Global.ENV.setStyleInfrag(true);
                    PMDS.Calc.UI.Admin.frmMainCalc frm = new PMDS.Calc.UI.Admin.frmMainCalc();
                    frm.nurDepot = true;

                    ProcessStartup(frm, UserRights.AbrechnungStarten, QS2.Desktop.ControlManagment.ControlManagment.getRes("Sie verfügen nicht über die notwendigen Rechte um die Abrechnung direkt zu starten"), false, false, false);            // Abrechnung starten 
                }
                else if (typ == "log")
                {
                    if (infoStartMain != null)
                        infoStartMain.Close();
                    //PMDS.Global.ENV.setStyleInfrag(true);
                    QS2.Logging.Win.frmLogManager2 frmLog = new QS2.Logging.Win.frmLogManager2();
                    frmLog.initControl();
                    frmLog.Show();
                }
                //else if (typ == "bew")
                //{
                //    ProcessStartup(new frmBewerber(), UserRights.BewerberStarten, "Sie verfügen nicht über die notwendigen Rechte um die Bewerberverwaltung direkt zu starten", false, false);        // Bewerber starten 
                //}
                //else if (typ == "stammdat")
                //{
                //    ProcessStartup(new frmStammdaten(), UserRights.StammdatenStarten, "Sie verfügen nicht über die notwendigen Rechte um die Stammdatenverwaltung direkt zu starten", false, false);  // Stammdaten starten 
                //}
                else if (typ == "auswpep")
                {
                    if (infoStartMain != null)
                        infoStartMain.Close();
                    if (!GuiWorkflow.Init())
                        return;

                    QS2.Desktop.ControlManagment.ENV.setRights(ENV.HasRight(UserRights.Layout));
                    qs2.ui.RunFromOhterSystem RunFromOhterSystem1 = new qs2.ui.RunFromOhterSystem();
                    RunFromOhterSystem1.LogIn(ENV.pathConfig, "qs2.config", "PMDS", RBU.DataBase.Srv, RBU.DataBase.m_Database, RBU.DataBase.m_sUser, RBU.DataBase.m_sPassword, RBU.DataBase.IsTrusted, PMDS.Global.ENV.LOGPATH);
                    PMDS.Global.ENV.setStyleInfrag(true);
                    qs2.core.ENV.IsHeadquarter = true;

                    PMDS.GUI.frmDynReports frm = new PMDS.GUI.frmDynReports(ENV.DynReportsPEP);
                    frm.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Berichte PEP");
                    Application.Run(frm);
                }
                else if (typ == "touch")
                {
                    if (infoStartMain != null)
                        infoStartMain.Close();
                    qs2.ui.RunFromOhterSystem RunFromOhterSystem1 = new qs2.ui.RunFromOhterSystem();
                    RunFromOhterSystem1.LogIn(ENV.pathConfig, "qs2.config", "PMDS", RBU.DataBase.Srv, RBU.DataBase.m_Database, RBU.DataBase.m_sUser, RBU.DataBase.m_sPassword, RBU.DataBase.IsTrusted, PMDS.Global.ENV.LOGPATH);
                    PMDS.Global.ENV.setStyleInfrag(true);
                    qs2.core.ENV.IsHeadquarter = true;

                    ProcessStartup(new frmQM(), UserRights.Rueckmelden, QS2.Desktop.ControlManagment.ControlManagment.getRes("Sie verfügen nicht über die notwendigen Rechte um Klientenrückmeldungen zu tätigen"), true, false, true);                    // Quickmeldung starten 
                }
                else if (typ == "peps")
                {
                    System.Diagnostics.Process.Start(System.IO.Path.Combine(Application.StartupPath, "PMDS_PEP.exe") + " ", "?ConfigFile=" + System.IO.Path.GetFileName(ENV.sConfigFile) + " ?ConfigPath=" + ENV.sConfigRootDir);
                }
                else if (typ == "pmds" || String.IsNullOrWhiteSpace(typ))                                                                                                                                                            // PMDS starten
                {

                    if (ENV.CheckLicense())
                    {
                        if (ENV.PMDSNew)
                        {
                            throw new Exception("ENV.PMDSNew: ENV-Var not activated!");
                            //infoStartMain.Close();
                            //infoStartMain = null;
                            //PMDS.GUI.PMDSClient.startPMDSMain start = new GUI.PMDSClient.startPMDSMain();
                            //start.run();
                        }
                        else
                        {
                            using (frmMain frm = new frmMain())
                            {
                                frm.initControl();
                                if (infoStartMain != null)
                                {
                                    infoStartMain.Close();
                                    infoStartMain = null;
                                }

                                bool IsInit = GuiWorkflow.Init(frm);

                                //PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                                if (ENV.ActiveUser == null)
                                {
                                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                                    {
                                        PMDS.db.Entities.Benutzer rUserLoggedIn = b.LogggedOnUserWithCheck(db);
                                        if (rUserLoggedIn != null)
                                        {
                                            ENV.ActiveUser = rUserLoggedIn;
                                            if (String.IsNullOrWhiteSpace(ENV.LoginInNameFrei))
                                            {
                                                ENV.MainCaption = "PMDS (" + ENV.ActiveUser.Nachname + " " + ENV.ActiveUser.Vorname + ") ";
                                            }
                                            else
                                            {
                                                ENV.MainCaption = "PMDS (" + ENV.ActiveUser.Benutzer1 + " - " + ENV.LoginInNameFrei + ") ";
                                            }
                                        }
                                    }
                                }

                                if (!IsInit)
                                    return;

                                b.initUserCanSign();

                                bool PwdNotSucessfullChanged = false;
                                PMDS.GUI.ucSiteMapPMDS ucSiteMapPMDS1 = new PMDS.GUI.ucSiteMapPMDS();
                                if (!ucSiteMapPMDS1.checkAnonymLogIn(ref PwdNotSucessfullChanged))
                                {
                                    return;
                                }

                                if (ENV.SchnellrückmeldungAsProcess.Trim() == "1")
                                {
                                    PMDS.Global.Remote.remotingSrv remotingSrv1 = new Global.Remote.remotingSrv();
                                    remotingSrv1.startProcIPCClient("Schnellrückmeldung", ENV.USERID, "0", ENV.IDAnmeldungen, ENV.LoggedInAsSuperUser, ENV.UsrPwdEnc);
                                }

                                QS2.Desktop.ControlManagment.ENV.setRights(ENV.HasRight(UserRights.Layout));
                                qs2.ui.RunFromOhterSystem RunFromOhterSystem1 = new qs2.ui.RunFromOhterSystem();
                                RunFromOhterSystem1.LogIn(ENV.pathConfig, "qs2.config", "PMDS", RBU.DataBase.Srv, RBU.DataBase.m_Database, RBU.DataBase.m_sUser, RBU.DataBase.m_sPassword, RBU.DataBase.IsTrusted, PMDS.Global.ENV.LOGPATH);
                                PMDS.Global.ENV.setStyleInfrag(true);
                                qs2.core.ENV.IsHeadquarter = true;
                                PMDS.Global.db.ERSystem.EFEntities EFEntities1 = new Global.db.ERSystem.EFEntities();
                                EFEntities1.init2(true);

                                Application.Run(frm);
                            }
                        }
                    }
                }
                else if (typ == "schnellrückmeldung")                                                                                                                                                         
                {
                    remotingSrv.showMsgBoxTestmodus("start schnellrückmeldung");

                    remotingSrv.varsToCallIPCServer = new CommunicationStatusVars();
                    remotingSrv.varsToCallIPCServer.URIGuidClient = searchKeyArg("URIGuidClient", args);
                    remotingSrv.URIGuidSrv = searchKeyArg("URIGuidSrv", args);
                    string sSrvNr = searchKeyArg("SrvNr", args);
                    string sUserID = searchKeyArg("UserID", args);
                    Guid gUserID = new Guid(sUserID.Trim());
                    string sLoggedInAsSuperUser = searchKeyArg("LoggedInAsSuperUser", args);
                    if (sLoggedInAsSuperUser.Trim() == "1")
                    {
                        ENV.LoggedInAsSuperUser = true;
                    }
                    ENV.UsrPwdEnc = searchKeyArg("UsrPwdEnc", args);
                    string sIDAnmeldungen = searchKeyArg("IDAnmeldungen", args);
                    if (!String.IsNullOrWhiteSpace(sIDAnmeldungen.Trim()))
                    {
                        ENV.IDAnmeldungen = new Guid(sIDAnmeldungen.Trim());
                    }
                    remotingSrv.IPCClientTestmodus = searchKeyArg("IPCClientTestmodus", args);

                    remotingSrv.varsToCallIPCServer.SrvNr = System.Convert.ToInt32(sSrvNr.Trim());
                    remotingSrv.UriMainPMDS += "_" + remotingSrv.URIGuidSrv.Trim();
                    remotingSrv.PortMainPMDS += "_" + remotingSrv.URIGuidSrv.Trim();
                    remotingSrv.varsToCallIPCServer.UriClientUIQS2 += "_" + remotingSrv.varsToCallIPCServer.URIGuidClient.Trim();
                    int PortClientTmp = remotingSrv.PortClientFrom + remotingSrv.varsToCallIPCServer.SrvNr;
                    remotingSrv.varsToCallIPCServer.PortClientUIQS2 = PortClientTmp.ToString() + "_" + remotingSrv.varsToCallIPCServer.URIGuidClient.Trim();

                    remotingSrv.showMsgBoxTestmodus("vars initialized");

                    using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                    {
                        IQueryable<PMDS.db.Entities.Benutzer> tBenutzer = db.Benutzer.Where(b1 => b1.ID == gUserID);
                        if (tBenutzer.Count() != 1)
                        {
                            throw new Exception("MainEntry: typ=Schnellrückmeldung - tBenutzer.Count()!=1 not allowed for IDBenutzer '" + gUserID.ToString() + "'!");
                        }
                        PMDS.db.Entities.Benutzer rBenutzer = tBenutzer.First();

                        if (!ENV.LoggedInAsSuperUser)
                        {
                            if (String.IsNullOrWhiteSpace(ENV.UsrPwdEnc))
                            {
                                throw new Exception("MainEntry: typ=Schnellrückmeldung - ENV.UsrPwdEnc='' not allowed!");
                            }
                            if (ENV.UsrPwdEnc.Trim() != rBenutzer.Passwort.Trim())
                            {
                                throw new Exception("MainEntry: typ=Schnellrückmeldung - ENV.UsrPwdEnc<>rBenutzer.Passwort not allowed!");
                            }
                        }
                        ENV.setUSERID = rBenutzer.ID;
                        remotingSrv.showMsgBoxTestmodus("User Logged in");

                        ENV.SignalQuickfilterChanged(null);
                        QS2.Desktop.ControlManagment.ENV.initRigth(ENV.HasRight(UserRights.Layout), ENV.adminSecure);

                        b.initUserCanSign();

                        var tBenAbt = from ba in db.BenutzerAbteilung
                                               where ba.IDBenutzer == rBenutzer.ID
                                               select new 
                                               { 
                                                   ba.ID,
                                                   ba.IDBenutzer,
                                                   ba.IDAbteilung
                                               };

                        ENV.CurrentUserAbteilungen.Clear();
                        foreach (var rbenAbt in tBenAbt)
                            ENV.CurrentUserAbteilungen.Add(rbenAbt.IDAbteilung);

                        ENV.UserWithAbteilungLoggedOn(rBenutzer.ID, rBenutzer.IDBerufsstand.Value, Gruppe.ByBenutzer(rBenutzer.ID), rBenutzer.PflegerJN.Value);

                        ENV.COMMANDLINE_USER = "";
                        ENV.COMMANDLINE_PWD = "";


                        QS2.Desktop.ControlManagment.ENV.setRights(ENV.HasRight(UserRights.Layout));
                        qs2.ui.RunFromOhterSystem RunFromOhterSystem1 = new qs2.ui.RunFromOhterSystem();
                        RunFromOhterSystem1.LogIn(ENV.pathConfig, "qs2.config", "PMDS", RBU.DataBase.Srv, RBU.DataBase.m_Database, RBU.DataBase.m_sUser, RBU.DataBase.m_sPassword, RBU.DataBase.IsTrusted, PMDS.Global.ENV.LOGPATH);
                        PMDS.Global.ENV.setStyleInfrag(true);
                        qs2.core.ENV.IsHeadquarter = true;
                        PMDS.Global.db.ERSystem.EFEntities EFEntities1 = new Global.db.ERSystem.EFEntities();
                        EFEntities1.init2(true);
                        remotingSrv.showMsgBoxTestmodus("environment initialized");

                        remotingSrv remotingSrv1 = new remotingSrv();
                        remotingSrv1.run(remotingSrv.varsToCallIPCServer.PortClientUIQS2.Trim(), remotingSrv.varsToCallIPCServer.UriClientUIQS2.Trim(), remotingSrv.varsToCallIPCServer.SrvNr, true);
                        remotingSrv.showMsgBoxTestmodus("ipc channel registerd");


                        PMDS.Global.Remote.remotingClient.frmMainFormIPCClient1 = new GUI.Remote.frmMainFormIPCClient();
                        System.Drawing.Point p = new System.Drawing.Point(-300, -300);
                        PMDS.Global.Remote.remotingClient.frmMainFormIPCClient1.TopMost = false;
                        PMDS.Global.Remote.remotingClient.frmMainFormIPCClient1.Location = p;
                        PMDS.Global.Remote.remotingClient.frmMainFormIPCClient1.FormBorderStyle = FormBorderStyle.None;
                        PMDS.Global.Remote.remotingClient.frmMainFormIPCClient1.MaximizeBox = false;
                        PMDS.Global.Remote.remotingClient.frmMainFormIPCClient1.MinimizeBox = false;
                        PMDS.Global.Remote.remotingClient.frmMainFormIPCClient1.Height = 200;
                        PMDS.Global.Remote.remotingClient.frmMainFormIPCClient1.Width = 200;
                        PMDS.Global.Remote.remotingClient.frmMainFormIPCClient1.ShowInTaskbar = false;

                        remotingClient remotingClient1 = new remotingClient();
                        cParComm cParComm1 = new cParComm();
                        remotingClient.cCallFctReturn CallFctReturn = null;
                        remotingClient1.callFct(ICommunicationService.eTypeCallTo.MainPMDS, ICommunicationService.eTypeFct.LogInFinished, cParComm1, ref CallFctReturn);
                        remotingSrv.showMsgBoxTestmodus("logged in ready sended to Main-Pmds");

                        //remotingSrv.showMsgBoxTestmodus("starting schnellrückmeldung finisehd");
                        Application.Run(PMDS.Global.Remote.remotingClient.frmMainFormIPCClient1);
                    }
                }
                else
                {
                    throw new Exception("Main: Start-Type '" + typ + "' not definied in CommandLine!");
                }
            }
            catch (Exception ex)
            {
                if (infoStartMain != null)
                {
                    infoStartMain.Close();
                    infoStartMain = null;
                }
                PMDS.DB.PMDSBusinessComm.closeAllThreads = true;
                PMDS.DB.PMDSBusinessComm.threadLoadData = null;
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                if (infoStartMain != null)
                {
                    infoStartMain.Close();
                    infoStartMain = null;
                }
                PMDS.DB.PMDSBusinessComm.closeAllThreads = true;
                PMDS.DB.PMDSBusinessComm.threadLoadData = null;
            }
		}


        

        public static Global.db.ERSystem.PMDSBusinessUI.cItmTg checkSelectConfigs(string typ, string ConfigPathToCheck, string ConfigFileDefault, ref frmInfo infoStartMain, bool HideButtonOK)
        {
            try
            {
                if (!generic.sEquals(typ,"schnellrückmeldung") && 
                    (generic.sEquals(Environment.MachineName, "styhl2") || generic.sEquals(Environment.MachineName,"sty041")) &&
                    !generic.sEquals(ENV.StartFromShare, "1"))
                {
                    PMDS.Global.db.ERSystem.PMDSBusinessUI bUI = new PMDS.Global.db.ERSystem.PMDSBusinessUI();
                    bool runWithDefaultConfigFile = false;
                    string lastSelectedFile = "";
                    int iCounterConfigsFound = 0;
                    Infragistics.Win.ValueListItem itmSel = null;
                    bUI.searchConfigDirForConfigs(true, ConfigPathToCheck, null, ConfigFileDefault, ref runWithDefaultConfigFile, ref lastSelectedFile, ref iCounterConfigsFound, ref itmSel);
                    if (iCounterConfigsFound == 1)
                    {
                        return null;
                    }

                    if (infoStartMain != null)
                    {
                        infoStartMain.Visible = false;
                    }

                    using (frmSelectConfig frmSelectConfig1 = new frmSelectConfig())
                    {
                        frmSelectConfig1.initControl(ConfigPathToCheck, ConfigFileDefault, HideButtonOK);
                        frmSelectConfig1.ShowDialog();

                        if (infoStartMain != null)
                        {
                            infoStartMain.StartPosition = FormStartPosition.CenterScreen;
                            infoStartMain.Visible = true;
                        }

                        if (!frmSelectConfig1.abort)
                        {
                            return frmSelectConfig1.cItmTg_SelectedConfig;
                        }
                        else
                        {
                            if (frmSelectConfig1._runWithDefaultConfigFile)
                            {
                                return null;
                            }
                            else
                            {
                                //remotingSrv.killProcessIPCClient();
                                Process currentProcess = Process.GetCurrentProcess();
                                currentProcess.Kill();

                                throw new Exception("MainEntry.checkSelectConfigs: PMDS.Main.exe stopped by remotingSrv.killProcessIPCClient()!");
                            }
                        }
                    }
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("MainEntry.checkSelectConfigs: " + ex.ToString());
            }
        }

        private static bool initPlanArchivxy( )
        {
            //PMDS.plan.archivWork.clArchivsystem clArchiv = new PMDS.plan.archivWork.clArchivsystem();
            ////cl.setArchivpfadToDefaultPfadIfKeineAngabe();
            //clArchiv.checkPathArchiv();
            return true;
        }

		private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
            PMDS.Global.ENV.HandleException(e.Exception);
		}

        private static string searchKeyArg(string keySearch, string[] args)
        {

            foreach (string sParam in args)
            {
                string[] aParam = sParam.Split(new char[] { '=' }, 2);
                if (aParam[0].Replace("?", "").Trim().Equals(keySearch, StringComparison.CurrentCultureIgnoreCase))
                    return aParam.Length > 1 ? aParam[1] : "";
            }
            return "";
        }

    }

}

