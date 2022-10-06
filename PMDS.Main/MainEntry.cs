using System;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.GUI;
using System.Diagnostics;
using S2Extensions;

namespace PMDS
{
	public static class MainEntry
    {
        static bool ProcessStartup(Form frm, UserRights right, string RightsErrorText, bool bNoLoginRequired, bool testWindow, bool IsTouch  )
        {
            qs2.ui.RunFromPMDS RunFromPMDS1 = new qs2.ui.RunFromPMDS();
            RunFromPMDS1.LogIn(ENV.pathConfig, "qs2.config", "PMDS", RBU.DataBase.Srv, RBU.DataBase.m_Database, RBU.DataBase.m_sUser, RBU.DataBase.m_sPassword, RBU.DataBase.IsTrusted, PMDS.Global.ENV.LOGPATH);

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

            QS2.Desktop.ControlManagment.Settings.setRights(ENV.HasRight(UserRights.Layout));
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
                        ENV.MainCaption = "Lellissa (" + ENV.ActiveUser.Nachname + " " + ENV.ActiveUser.Vorname + ") ";
                    }
                    else
                    {
                        ENV.MainCaption = "Lellissa (" + ENV.ActiveUser.Benutzer1 + " - " + ENV.LoginInNameFrei + ") ";
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
                string LogPathPMDSFromLauncher = searchKeyArg("logPathPMDS", args);
                string sDoOrigPathConfig = searchKeyArg("DoOrigPathConfig", args);
                if (sDoOrigPathConfig.Trim() == "1")
                {
                    ENV.DoOrigPathConfig = true;
                }

                ENV.ConfigFileLauncher = searchKeyArg("ConfigFileLauncher", args);
                ENV.LauncherExe = searchKeyArg("LauncherExe", args);

                //<20120209> Pfad zum Config-Directory MUSS mitgegeben werden!!    /PMDS/<bindir>/Config wird automatisch angehängt!
                ENV.sConfigRootDir = searchKeyArg("ConfigPath", args);

                string typ = searchKeyArg("typ", args).ToLower();
                ENV.StartupTyp = typ;

                ENV.OrigConfigDir = ENV.sConfigRootDir;
                if (!String.IsNullOrWhiteSpace(ENV.sConfigRootDir))
                {
                    ENV.initClass(LogPathPMDSFromLauncher);
                }
                else
                {
                    if (Application.StartupPath.Trim().EndsWith(("Debug").Trim(), StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (String.IsNullOrWhiteSpace(ENV.sConfigRootDir))
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
                string configFileRead = searchKeyArg("ConfigFile", args);

                ENV.OrigConfigFile = configFileRead;
                if (!String.IsNullOrWhiteSpace(configFileRead))
                {
                    PMDS.Global.ENV.sConfigFile = System.IO.Path.Combine(ENV.pathConfig, configFileRead);
                }
                else
                {
                    if (!Application.StartupPath.Trim().EndsWith("Debug".Trim(), StringComparison.CurrentCultureIgnoreCase))
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

                ENV.initELGAFormatter();

                PMDS.GUI.VB.General.MainCallFcts = new GUI.VB.General.dMainCallFcts(ucSiteMapPMDS.MainCallDel);
                PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();

                if (typ == "pmds" || String.IsNullOrWhiteSpace(typ))                                                                                                                                                            // PMDS starten
                {
                    qs2.ui.RunFromPMDS RunFromPMDS1 = new qs2.ui.RunFromPMDS();
                    RunFromPMDS1.LogIn(ENV.pathConfig, "qs2.config", "PMDS", RBU.DataBase.Srv, RBU.DataBase.m_Database, RBU.DataBase.m_sUser, RBU.DataBase.m_sPassword, RBU.DataBase.IsTrusted, PMDS.Global.ENV.LOGPATH);

                    if (ENV.CheckLicense())
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
                                            ENV.MainCaption = "Lellissa (" + ENV.ActiveUser.Nachname + " " + ENV.ActiveUser.Vorname + ") ";
                                        }
                                        else
                                        {
                                            ENV.MainCaption = "Lellissa (" + ENV.ActiveUser.Benutzer1 + " - " + ENV.LoginInNameFrei + ") ";
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

                            QS2.Desktop.ControlManagment.Settings.setRights(ENV.HasRight(UserRights.Layout));

                            
                            PMDS.Global.ENV.setStyleInfrag(true);
                            qs2.core.ENV.IsHeadquarter = true;
                            PMDS.Global.db.ERSystem.EFEntities EFEntities1 = new Global.db.ERSystem.EFEntities();
                            EFEntities1.init2(true);
                            frm.Show();
                            Application.Run(frm);
                        }
                       
                    }
                }
                else if (typ.sEquals("touch"))
                {
                    if (infoStartMain != null)
                        infoStartMain.Close();

                    qs2.ui.RunFromPMDS RunFromPMDS1 = new qs2.ui.RunFromPMDS();
                    RunFromPMDS1.LogIn(ENV.pathConfig, "qs2.config", "PMDS", RBU.DataBase.Srv, RBU.DataBase.m_Database, RBU.DataBase.m_sUser, RBU.DataBase.m_sPassword, RBU.DataBase.IsTrusted, PMDS.Global.ENV.LOGPATH);
                    PMDS.Global.ENV.setStyleInfrag(true);
                    qs2.core.ENV.IsHeadquarter = true;
                    ProcessStartup(new frmQM(), UserRights.Rueckmelden, QS2.Desktop.ControlManagment.ControlManagment.getRes("Sie verfügen nicht über die notwendigen Rechte um Klientenrückmeldungen zu tätigen"), true, false, true);                    // Quickmeldung starten 
                }
                else if (typ.sEquals("abrech") || typ.sEquals("calc"))
                {
                    ENV.StartupMode = typ;
                    qs2.ui.RunFromPMDS RunFromPMDS1 = new qs2.ui.RunFromPMDS();
                    RunFromPMDS1.LogIn(ENV.pathConfig, "qs2.config", "PMDS", RBU.DataBase.Srv, RBU.DataBase.m_Database, RBU.DataBase.m_sUser, RBU.DataBase.m_sPassword, RBU.DataBase.IsTrusted, PMDS.Global.ENV.LOGPATH);
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
                else if (typ.sEquals("depotabrech"))
                {
                    ENV.StartupMode = typ;
                    if (infoStartMain != null)
                        infoStartMain.Close();
                    PMDS.Global.ENV.setStyleInfrag(true);
                    PMDS.Calc.UI.Admin.frmMainCalc frm = new PMDS.Calc.UI.Admin.frmMainCalc();
                    frm.nurDepot = true;

                    ProcessStartup(frm, UserRights.AbrechnungStarten, QS2.Desktop.ControlManagment.ControlManagment.getRes("Sie verfügen nicht über die notwendigen Rechte um die Abrechnung direkt zu starten"), false, false, false);            // Abrechnung starten 
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
                if (!typ.sEquals("schnellrückmeldung") && 
                    (Environment.MachineName.sEquals("styhl2") || Environment.MachineName.sEquals("sty041")) &&
                    !ENV.StartFromShare.sEquals("1"))
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

