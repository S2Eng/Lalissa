using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime;
using System.Security.Permissions;
using PMDS.GUI;
using System.Threading;

namespace PMDS.Global.Remote
{

    public class remotingSrv
    {
        public static string IPCClientTestmodus = "0";
        public static bool showMsgBoxesTestmodus = false;

        public static bool LoggedIn2 = false;
        //public static string Server = "localhost";

        public static IpcServerChannel IpcServerChannel1 = null;
        public static bool IpcServerChannelIsRegistered = false;

        public static string UriMainPMDS = "PMDSMainUI";
        public static string PortMainPMDS = "1100";
        public static string URIGuidSrv = System.Guid.NewGuid().ToString();

        public static System.Collections.Generic.Dictionary<int, CommunicationStatusVars> lstCommunicationStatusVars = new Dictionary<int, CommunicationStatusVars>();
        public static int PortClientFrom = 1101;

        public static bool SrvIsInitialized = false;

        public static CommunicationStatusVars varsToCall = new CommunicationStatusVars();
        public static ucSiteMapTermine SiteMap = null;

        public class cParThread
        {
            public string sTypeToStart = "";
            public Guid UserID;
            public string IPCClientTestmodus = "";
            public Nullable<Guid> IDAnmeldungen = null;
            public bool LoggedInAsSuperUser = false;
            public string UsrPwdEnc = "";
            public string URIGuidClient = "";
            public string SrvNr = "";
        }

        public static CommunicationStatusVars varsToCallIPCServer = new CommunicationStatusVars();

        public static bool IsCheckingSchnellrückmeldungen = false;
        public static System.Windows.Forms.Timer timerCheckRefreshTermine = null;

        public static bool bLockCheckDeleteFile = false;









        public bool run(string Port, string objectURI, int SrvNr, bool IsIPCProcess, bool throwException = true)
        {
            try
            {
                if (!remotingSrv.IpcServerChannelIsRegistered || !throwException)
                {
                    bool doConnect = true;
                    if (remotingSrv.IpcServerChannel1 != null)
                    {
                        try
                        {
                            remotingClient remotingClient1 = new remotingClient();
                            cParComm cParComm1 = new cParComm();
                            remotingClient.cCallFctReturn CallFctReturn = null;
                            if (IsIPCProcess)
                            {
                                //System.Windows.Forms.MessageBox.Show("ipc start check: " + Port);
                                //remotingClient1.callFct(ICommunicationService.eTypeCallTo.MainPMDS, ICommunicationService.eTypeFct.LogInFinished, cParComm1, ref CallFctReturn);
                                //System.Windows.Forms.MessageBox.Show("ipc ok check: " + Port);
                                try
                                {
                                    ChannelServices.UnregisterChannel(remotingSrv.IpcServerChannel1);
                                }
                                catch (Exception ex565)
                                {

                                }
                                //System.Windows.Forms.MessageBox.Show("ipc unregisterd: " + Port);
                                doConnect = true;
                            }
                            else
                            {
                                remotingClient1.callFct(ICommunicationService.eTypeCallTo.ClientPMDS, ICommunicationService.eTypeFct.TestCallToClient, cParComm1, ref CallFctReturn);
                                ChannelServices.UnregisterChannel(remotingSrv.IpcServerChannel1);
                                doConnect = true;
                            }
                            //throw new Exception("No Connect");
                        }
                        catch (Exception ex77)
                        {
                            string sExcept = "remotingSrv.run: error testcall to pmds.main-process - " + ex77.ToString();
                            ChannelServices.UnregisterChannel(remotingSrv.IpcServerChannel1);
                            doConnect = true;
                        }
                    }

                    if (doConnect)
                    {
                        //if (IsIPCProcess)
                        //{
                        //    System.Windows.Forms.MessageBox.Show("IPC start" + Port);
                        //}
                        //else
                        //{
                        //    System.Windows.Forms.MessageBox.Show("PMDS.Main start" + Port);
                        //}
                        if (throwException)
                        {
                            remotingSrv.IpcServerChannel1 = new IpcServerChannel(Port);
                        }

                        ChannelServices.RegisterChannel(remotingSrv.IpcServerChannel1);
                        RemotingConfiguration.RegisterWellKnownServiceType(typeof(ICommunicationService), objectURI, WellKnownObjectMode.SingleCall);

                        //remotingSrv.IpcServerChannel1 = new IpcServerChannel(objectURI.Trim());
                        //ChannelServices.RegisterChannel(remotingSrv.IpcServerChannel1, true);
                        remotingSrv.IpcServerChannelIsRegistered = true;
                        if (!throwException)
                        {
                            string txtLog = "Info: IPC-channel reconnected (Port: " + Port.Trim() + "). Machine: " + System.Environment.MachineName.Trim() + "\r\n";
                            //PMDS.Global.ENV.WriteLog(txtLog);
                            //PMDS.Global.ENV.HandleException(new Exception(txtLog), "Exception reconnect IPC", false);
                            //PMDS.Global.ENV.HandleException(new Exception(txtLog));
                        }

                        //if (IsIPCProcess)
                        //{
                        //    System.Windows.Forms.MessageBox.Show("IPC registered" + Port);
                        //}
                        //else
                        //{
                        //    System.Windows.Forms.MessageBox.Show("PMDS.Main registered" + Port);
                        //}
                    }
                }

                WellKnownServiceTypeEntry[] regServTypes = RemotingConfiguration.GetRegisteredWellKnownServiceTypes();
                //foreach (WellKnownServiceTypeEntry regServType in regServTypes)
                //{
                //}


                //ICommunicationService remotObj = new ICommunicationService();
                //RemotingServices.Marshal(remotObj, Port.ToString().Trim(), typeof(ICommunicationService));
                //remotObj.SponsorYourself();

                //RemotingConfiguration.RegisterWellKnownServiceType(typeof(ICommunicationService), "ServerObject",System.Runtime.Remoting.WellKnownObjectMode.SingleCall);
                return true;
            }
            catch (Exception ex)
            {
                string sException = "remotingSrv.run: " + ex.ToString();
                if (throwException)
                {
                    //throw new Exception(sException);
                }
                throw new Exception(sException);
                return false;
            }
        }


        public void startProcIPCClient(string sTypeToStart, Guid UserID, string IPCClientTestmodus, Nullable<Guid> IDAnmeldungen, bool LoggedInAsSuperUser, string UsrPwdEnc)
        {
            try
            {
                this.initSrv();
                CommunicationStatusVars vars1 = this.getVarsForCallIPCClient();
                this.run(remotingSrv.PortMainPMDS.Trim(), remotingSrv.UriMainPMDS.Trim(), vars1.SrvNr, false);

                cParThread ParThread = new cParThread();
                ParThread.sTypeToStart = sTypeToStart;
                ParThread.UserID = UserID;
                ParThread.IPCClientTestmodus = IPCClientTestmodus;
                ParThread.IDAnmeldungen = IDAnmeldungen;
                ParThread.LoggedInAsSuperUser = LoggedInAsSuperUser;
                ParThread.UsrPwdEnc = UsrPwdEnc;
                ParThread.URIGuidClient = vars1.URIGuidClient.Trim();
                ParThread.SrvNr = vars1.SrvNr.ToString();

                Thread t2 = new Thread(() => this.th_startProcIPCClient2(ParThread));
                t2.Start();

            }
            catch (Exception ex)
            {
                throw new Exception("remotingSrv.startProcIPCClient: " + ex.ToString());
            }
        }

        public void th_startProcIPCClient2(cParThread ParThread)
        {
            try
            {
                string argsRun = "";
                argsRun += " ?typ=" + ParThread.sTypeToStart.Trim() + "";
                argsRun += " ?IPCClientTestmodus=" + IPCClientTestmodus.Trim() + "";
                argsRun += " ?UserID=" + ParThread.UserID.ToString() + "";
                argsRun += " ?URIGuidClient=" + ParThread.URIGuidClient.Trim() + "";
                argsRun += " ?URIGuidSrv=" + remotingSrv.URIGuidSrv.Trim() + "";
                argsRun += " ?SrvNr=" + ParThread.SrvNr.Trim() + "";
                argsRun += " ?IPCClientTestmodus=" + IPCClientTestmodus.Trim() + "";
                argsRun += " ?showSplash=0";
                argsRun += " ?UsrPwdEnc=" + ParThread.UsrPwdEnc.Trim() + "";
                if (ParThread.IDAnmeldungen != null)
                {
                    argsRun += " ?IDAnmeldungen=" + ParThread.IDAnmeldungen.ToString() + "";
                }
                else
                {
                    argsRun += " ?IDAnmeldungen=";
                }
                if (ParThread.LoggedInAsSuperUser)
                {
                    argsRun += " ?LoggedInAsSuperUser=1";
                }
                else
                {
                    argsRun += " ?LoggedInAsSuperUser=0";
                }

                string sConfigFileOnlyNameTmp = System.IO.Path.GetFileName(ENV.sConfigFile.Trim());
                //string sConfigFileTmp = ENV.sConfigFile;
                if (sConfigFileOnlyNameTmp.Contains(" "))
                {
                    sConfigFileOnlyNameTmp = "\"" + sConfigFileOnlyNameTmp + "\"";
                }
                string sConfigPathTmp = ENV.pathConfig;
                if (sConfigPathTmp.Contains(" "))
                {
                    sConfigPathTmp = "\"" + sConfigPathTmp + "\"";
                }

                argsRun += " ?ConfigFile=" + sConfigFileOnlyNameTmp;
                argsRun += " ?ConfigPath=" + sConfigPathTmp + "";
                argsRun += " ?StartFromShare=" + ENV.StartFromShare.Trim() + "";
                argsRun += " ?DoOrigPathConfig=1";

                string sLogPath = ENV.LOGPATH;
                if (sLogPath.Contains(" "))
                {
                    sLogPath = "\"" + sLogPath + "\"";
                }
                argsRun += " ?logPathPMDS=" + sLogPath + "";

                string strExe = System.IO.Path.Combine(ENV.path_bin, "PMDS.Main.exe").ToString();
                System.Diagnostics.Process.Start(strExe, argsRun);

            }
            catch (Exception ex)
            {
                throw new Exception("remotingSrv.th_startProcIPCClient2: " + ex.ToString());
            }
        }

        public CommunicationStatusVars getVarsForCallIPCClient()
        {
            try
            {
                CommunicationStatusVars CommunicationStatusVars1 = new CommunicationStatusVars();

                CommunicationStatusVars1.SrvNr = 0;
                int PortClientTmp = remotingSrv.PortClientFrom + CommunicationStatusVars1.SrvNr;
                CommunicationStatusVars1.UriClientUIQS2 += "_" + CommunicationStatusVars1.URIGuidClient.Trim();
                CommunicationStatusVars1.PortClientUIQS2 = PortClientTmp.ToString() + "_" + CommunicationStatusVars1.URIGuidClient.Trim();

                remotingSrv.lstCommunicationStatusVars.Add(CommunicationStatusVars1.SrvNr, CommunicationStatusVars1);

                remotingSrv.varsToCall = CommunicationStatusVars1;
                return CommunicationStatusVars1;
            }
            catch (Exception ex)
            {
                throw new Exception("remotingSrv.getVarsForCallIPCClient: " + ex.ToString());
            }
        }

        public void initSrv()
        {
            try
            {
                if (!remotingSrv.SrvIsInitialized)
                {
                    remotingSrv.UriMainPMDS += "_" + remotingSrv.URIGuidSrv.Trim();
                    remotingSrv.PortMainPMDS += "_" + remotingSrv.URIGuidSrv.Trim();

                    remotingSrv.SrvIsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("remotingSrv.initSrv: " + ex.ToString());
            }
        }

        public static void showMsgBoxTestmodus(string txt)
        {
            if (remotingSrv.showMsgBoxesTestmodus)
            {
                System.Windows.Forms.MessageBox.Show(txt, "PMDS Testmodus");
            }
        }

        public static void killProcessIPCClient()
        {
            try
            {
                //if (ENV.SchnellrückmeldungAsProcess.Trim() == "1")
                //{
                //    remotingClient remotingClient1 = new remotingClient();
                //    cParComm cParComm1 = new cParComm();
                //    remotingClient.cCallFctReturn CallFctReturn = null;

                //    remotingSrv.SiteMap = SiteMap;
                //    remotingClient1.callFct(ICommunicationService.eTypeCallTo.ClientPMDS, ICommunicationService.eTypeFct.CloseIPCClient, cParComm1, ref CallFctReturn);
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("remotingSrv.killProcessIPCClient: " + ex.ToString());
            }
        }


        public static void openSchnellrückmeldungSave(List<Guid> lstIDPP, int mainWindowLeft, int mainWindowTop, int MainWindowWidth, int MainWindowHeight)
        {
            try
            {
                string txtPP = "";
                foreach (Guid IDPP in lstIDPP)
                {
                    txtPP += IDPP.ToString() + ";";
                }

                string pathIPC = System.IO.Path.GetTempPath() + "\\ipc";
                if (!System.IO.Directory.Exists(pathIPC))
                {
                    System.IO.Directory.CreateDirectory(pathIPC);
                }

                remotingSrv remotingSrv1 = new remotingSrv();
                remotingSrv1.startTimerCheckRefreshTermine();

                string IPCFileTemp = pathIPC + "\\sr_" + remotingSrv.varsToCall.UriClientUIQS2 + ".ipctemp";
                string IPCFile = pathIPC + "\\sr_" + remotingSrv.varsToCall.UriClientUIQS2 + ".ipc";
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(IPCFileTemp, false))
                {
                    file.WriteLine(txtPP);
                    file.WriteLine(mainWindowLeft.ToString() + ";" +  mainWindowTop.ToString() + ";" + MainWindowWidth.ToString() + ";" + MainWindowHeight.ToString() + ";");
                }
                System.IO.File.Move(IPCFileTemp, IPCFile);      //Umbenennen nach dem Schreiben
                                                                //remotingSrv.checkSchnellrückmeldung();
                GuiAction.SchnellrückmeldungOpend = true;

            }
            catch (Exception ex)
            {
                //GuiAction.SchnellrückmeldungOpend = false;
                throw new Exception("remotingSrv.openSchnellrückmeldungSave: " + ex.ToString());
            }
        }
        public static bool checkSchnellrückmeldung()
        {
            try
            {
                string pathIPC = System.IO.Path.GetTempPath() + "\\ipc";
                if (!System.IO.Directory.Exists(pathIPC))
                {
                    System.IO.Directory.CreateDirectory(pathIPC);
                }

                string IPCFile = pathIPC + "\\sr_" + remotingSrv.varsToCallIPCServer.UriClientUIQS2 + ".ipc";
                if (System.IO.File.Exists(IPCFile))
                {
                    int iLeft = remotingClient.frmRueckmedlungLine.Left + (remotingClient.frmRueckmedlungLine.Width / 2);
                    int iTop = remotingClient.frmRueckmedlungLine.Top + (remotingClient.frmRueckmedlungLine.Height / 2);

                    remotingSrv.IsCheckingSchnellrückmeldungen = true;
                    remotingClient.frmLoadingWait1.Show();
                    remotingClient.frmLoadingWait1.Left = iLeft - (remotingClient.frmLoadingWait1.Width / 2);
                    remotingClient.frmLoadingWait1.Top = iTop - (remotingClient.frmLoadingWait1.Height / 2);
                    remotingClient.frmLoadingWait1.Visible = true;
                    System.Windows.Forms.Application.DoEvents();

                    //System.Windows.Forms.MessageBox.Show("File found " + IPCFile);

                    string IPCData = "";
                    string MainWindowPos = "";
                    List<Guid> lstPPOpen = new List<Guid>();
                    int iCounterCalled = 0;
                    remotingSrv.readFile_rek(IPCFile, iCounterCalled, ref IPCData, ref MainWindowPos);
                    System.Collections.Generic.List<string> lstMainWindowPos = qs2.core.generic.readStrVariables(MainWindowPos.Trim());
                    int MainWindowLeft = System.Convert.ToInt32(lstMainWindowPos[0]);
                    int MainWindowTop = System.Convert.ToInt32(lstMainWindowPos[1]);
                    int MainWindowWidth = System.Convert.ToInt32(lstMainWindowPos[2]);
                    int MainWindowHeight = System.Convert.ToInt32(lstMainWindowPos[3]);

                    //int iLeft = MainWindowLeft + (MainWindowWidth / 2);
                    //int iTop = MainWindowWidth + (MainWindowHeight / 2);

                    //remotingSrv.IsCheckingSchnellrückmeldungen = true;
                    //remotingClient.frmLoadingWait1.Show();
                    //remotingClient.frmLoadingWait1.Left = iLeft - (MainWindowWidth / 2);
                    //remotingClient.frmLoadingWait1.Top = iTop - (MainWindowHeight / 2);
                    //remotingClient.frmLoadingWait1.Visible = true;
                    //remotingClient.frmLoadingWait1.TopMost = true;
                    //System.Windows.Forms.Application.DoEvents();

                    //System.Windows.Forms.MessageBox.Show("IPCData: " + IPCData);
                    //System.Windows.Forms.MessageBox.Show("Left: " + MainWindowLeft.ToString() + ", Top: " + MainWindowTop.ToString() + ", Width: " + MainWindowWidth.ToString() + ", Height: " + MainWindowHeight.ToString());

                    //using (StreamReader sr = File.OpenText(IPCFile))
                    //{
                    //    IPCData = sr.ReadToEnd();
                    //}
                    System.IO.File.Delete(IPCFile);

                    //using (System.IO.StreamWriter file = new System.IO.StreamWriter(IPCFile, false))
                    //{
                    //    file.Write("");
                    //}

                    System.Collections.Generic.List<string> lstPP = qs2.core.generic.readStrVariables(IPCData.Trim());
                    foreach (string IDPP in lstPP)
                    {
                        lstPPOpen.Add(new Guid(IDPP.ToString()));
                    }

                    //System.Windows.Forms.MessageBox.Show("File found " + IPCFile);
                    ICommunicationService ICommunicationService1 = new ICommunicationService();
                    bool bOK = ICommunicationService1.StartSchnellrückmeldung(ref lstPPOpen, MainWindowLeft, MainWindowTop, MainWindowWidth, MainWindowHeight);
                    remotingSrv.IsCheckingSchnellrückmeldungen = false;
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                remotingClient.frmLoadingWait1.Visible = false;
                remotingSrv.IsCheckingSchnellrückmeldungen = false;
                throw new Exception("remotingSrv.checkSchnellrückmeldung: " + ex.ToString());
            }
        }

        public static bool readFile_rek(string file, int iCounterCalled, ref string IPCData, ref string MainWindowPos)
        {
            try
            {
                qs2.core.generic.WaitMilli(100);
                using (StreamReader sr = File.OpenText(file))
                {
                    IPCData = sr.ReadLine();
                    MainWindowPos = sr.ReadLine();
                }
                return true;
            }
            catch (IOException ex5)
            {
                if (iCounterCalled <= 5)
                {
                    qs2.core.generic.WaitMilli(150);
                    iCounterCalled += 1;
                    return readFile_rek(file, iCounterCalled, ref IPCData, ref MainWindowPos);
                }
                else
                {
                    throw new Exception("remotingSrv.readFile_rek: " + ex5.ToString());
                }
            }
        }

        public static void writeClosedSchnellrückmeldung(bool savedData)
        {
            try
            {
                //if (ENV.SchnellrückmeldungAsProcess.Trim() == "1")
                //{
                //    string pathIPC = System.IO.Path.GetTempPath() + "\\ipc";
                //    string IPCFileTemp = pathIPC + "\\closed_" + remotingSrv.UriMainPMDS + ".ipctemp";
                //    string IPCFile = pathIPC + "\\closed_" + remotingSrv.UriMainPMDS + ".ipc";
                //    using (System.IO.StreamWriter file = new System.IO.StreamWriter(IPCFileTemp, true))
                //    {
                //        file.Write((savedData ? "S" : "C"));
                //    }
                //    System.IO.File.Move(IPCFileTemp, IPCFile);
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("remotingSrv.writeClosedSchnellrückmeldung: " + ex.ToString());
            }
        }

        public void startTimerCheckRefreshTermine()
        {
            try
            {
                if (remotingSrv.timerCheckRefreshTermine == null)
                {
                    remotingSrv.timerCheckRefreshTermine = new System.Windows.Forms.Timer();
                    remotingSrv.timerCheckRefreshTermine.Tick += new System.EventHandler(this.checkRefreshTermine);
                    timerCheckRefreshTermine.Interval = 10;
                    timerCheckRefreshTermine.Enabled = true;
                    timerCheckRefreshTermine.Start();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("remotingSrv.startTimerCheckRefreshTermine: " + ex.ToString());
            }
        }

        public void checkRefreshTermine(object sender, EventArgs e)
        {
            try
            {
                if (!remotingSrv.bLockCheckDeleteFile)
                {
                    remotingSrv.bLockCheckDeleteFile = true;

                    string pathIPC = System.IO.Path.GetTempPath() + "\\ipc";
                    if (!System.IO.Directory.Exists(pathIPC))
                    {
                        System.IO.Directory.CreateDirectory(pathIPC);
                    }

                    string IPCFile = pathIPC + "\\closed_" + remotingSrv.UriMainPMDS + ".ipc";
                    if (System.IO.File.Exists(IPCFile))
                    {
                        qs2.core.generic.WaitMilli(10);
                        string sActionClicked = "";
                        using (StreamReader sr = File.OpenText(IPCFile))
                        {
                            sActionClicked = sr.ReadLine();
                        }
                        qs2.core.generic.WaitMilli(10);
                        this.rek_chekRefreshFileDelete(IPCFile, 0);                        
                        if (sActionClicked.Trim().ToLower().Equals(("S").Trim().ToLower()))
                        {
                            //GuiWorkflow._guiworkflow.initInterventionenBereich(eUITypeTermine.Interventionen, TerminlisteAnsichtsmodi.Bereichsansicht);
                            if (ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Klientanansicht)
                            {
                                GuiWorkflow._guiworkflow._SitemapTermineInterventionen.RefreshTermin(false);
                            }
                            else
                            {
                                GuiWorkflow._guiworkflow._SitemapTermineInterventionenBereich.RefreshTermin(false);
                            }
                            //GuiWorkflow._LastBereichsansicht = eUITypeTermine.Interventionen;
                        }

                        GuiAction.SchnellrückmeldungOpend = false;
                    }

                    remotingSrv.bLockCheckDeleteFile = false;
                }

            }
            catch (Exception ex)
            {
                GuiAction.SchnellrückmeldungOpend = false;
                remotingSrv.bLockCheckDeleteFile = false;
                throw new Exception("remotingSrv.checkRefreshTermine: " + ex.ToString());
            }
        }

        public void rek_chekRefreshFileDelete(string IPCFile, int iCounterCalled)
        {
            try
            {
                qs2.core.generic.WaitMilli(100);
                System.IO.File.Delete(IPCFile);
            }
            catch (Exception ex)
            {
                if (iCounterCalled >= 5)
                {
                    iCounterCalled += 1;
                    rek_chekRefreshFileDelete(IPCFile, iCounterCalled);
                }
                else
                {
                    throw new Exception("remotingSrv.rek_chekRefreshFileDelete: " + ex.ToString());
                }
            }
 
        }

    }




    public class CommunicationStatusVars
    {
        public int SrvNr = 0;

        public string UriClientUIQS2 = "PMDSClientUI";
        public string PortClientUIQS2 = "1001";

        public bool IsRunning = false;
        public bool processClientIsLoggedIn2 = false;

        public string URIGuidClient = System.Guid.NewGuid().ToString();
    }


}
