using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;

using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.IO;


using QS2.Resources;

namespace Launcher
{
    public partial class frmLauncher2 : Form
    {
        private config config;
        private ui cUi = new ui();
        private int heightButt = 42;

        private System.Collections.ArrayList arrProc = new System.Collections.ArrayList();
        private bool uiONOff = true;

        private string subKeyReg = @"SOFTWARE\pmds\launcherPmds";

        public static string debugmode = ""; 

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint RegisterWindowMessage(string lpString);

        [DllImport("shell32.dll")]
        public static extern Int32 SHGetMalloc(out IntPtr hObject);

        [DllImport("user32")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("User32", EntryPoint = "BringWindowToTop")]
        private static extern bool BringWindowToTop(IntPtr wHandle);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string strClassName, string strWindowName);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);

        private const int SW_HIDE = 0;
        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;
        private const int SW_SHOWNOACTIVATE = 4;
        private const int SW_RESTORE = 9;
        private const int SW_SHOWDEFAULT = 10;

        
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern IntPtr SendMessageTimeout(IntPtr hWnd, uint Msg, UIntPtr wParam, UIntPtr lParam, SendMessageTimeoutFlags fuFlags, uint
                                                uTimeout, out UIntPtr lpdwResult);

        IntPtr HWND_BROADCAST = new IntPtr(0xffff);
        IntPtr WM_SETTINGCHANGE = new IntPtr(0x001A);

        public enum SendMessageTimeoutFlags : uint
        {
            SMTO_NORMAL = 0x0000,
            SMTO_BLOCK = 0x0001,
            SMTO_ABORTIFHUNG = 0x0002,
            SMTO_NOTIMEOUTIFNOTHUNG = 0x0008
        }

        public frmLauncher2()
        {
            InitializeComponent();

            //Icons laden
            this.Icon = getRes.getIcon(getRes.Launcher.ico_PMDS, 32, 32);
            this.btn_PMDS.Image = getRes.getImage(getRes.Launcher.ico_PMDS,32,32);
            this.btn_Abrechnung.Image = getRes.getImage(getRes.Launcher.ico_Abrechnung, 32, 32);
            this.btn_QM.Image = getRes.getImage(getRes.Launcher.ico_Touchdoku, 32, 32);
            this.btn_Peps.Image = getRes.getImage(getRes.Launcher.ico_PEPS, 32, 32);
            this.btn_OF.Image = getRes.getImage(getRes.Launcher.ico_Onlineformulare, 32, 32);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                //this.regForm();
                this.infoRuntime();
                this.config = new config();
                if (!this.config.readAll())
                {
                    //this.ThrowMessage("frmMain_Load.if (!this.config.readAll())");
                    this.Close();
                    return;
                }
               frmLauncher2.debugmode = this.config.getKey("debugmode");

               //Im ENV-Parameter suchen, ob ui=0 enthalten ist
               if (this.config.searchKeyArg("ui", Environment.CommandLine) == "0")
                   this.uiONOff = false;

                //Im Config-File suchen, ob ui=0 enthalten ist
                CfgFile ConfigFile = new CfgFile(Launcher.config.configFile);
            
                if (ConfigFile.getValue("main", "ui", false) == "0")
                    this.uiONOff = false;

                if (this.uiONOff == false)
                {
                    this.Visible = false;
                    Application.DoEvents();
                    this.startProg("", false, false);
                }
                else
                {
                    this.checkRunning();
                    this.activateButtonsConfig();
                    this.tbUser.Focus();
                    this.ProcessMinimize(false, true);
                }              
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error frmLauncher2.frmMain_Load: " + ex.ToString(), "PMDS - Launcher");
            }
        }

        public void ThrowMessage(string txt)
        {
            if (frmLauncher2.debugmode.Trim() == "1" )
            {
                MessageBox.Show(txt);
            }
        }

        private void regForm()
        {
            try
            {
                IntPtr hWndActive = FindWindow(null, "PMDS Starter");

                int anzLauncher = 0;
                foreach (Process proc in Process.GetProcesses())
                {
                    if (proc.ProcessName == "Launcher" || proc.ProcessName == "Launcherxy.vshost")
                    {
                        anzLauncher += 1;
                    }
                }
                MessageBox.Show("anzLauncher " + anzLauncher.ToString());
                if (anzLauncher == 1)
                {

                    if (SubKeyExist(this.subKeyReg))
                        Registry.LocalMachine.DeleteSubKeyTree(this.subKeyReg);

                    RegistryKey newKey = Registry.LocalMachine.CreateSubKey(this.subKeyReg);
                    newKey.SetValue(hWndActive.ToString(), hWndActive.ToString());

                    MessageBox.Show("handle " + hWndActive.ToString());
                }
                
                if (SubKeyExist(this.subKeyReg) && anzLauncher > 1)
                {
                    RegistryKey myKey = Registry.LocalMachine.OpenSubKey(this.subKeyReg);
                    string[] valNames = (String[])myKey.GetValueNames();
                    foreach (string valName in valNames)
                    {
                        //string handle = (string)myKey.GetValue(valName);
                        if (valName != hWndActive.ToString())
                        {
                            int iWnd = System.Convert.ToInt32(valName);
                            IntPtr hWndBringTop = (IntPtr)iWnd;
                            SetForegroundWindow(hWndBringTop);
                            BringWindowToTop(hWndBringTop);
                            MessageBox.Show("BringWindowToTop " + hWndBringTop.ToString());
                        }
                    }
                    this.ThrowMessage("regForm.BringWindowToTop");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("frmLauncher2.regForm: " + ex.ToString());
            }
        }

        private void toTop()
        {
            IntPtr hWndActive = FindWindow(null, "PMDS Starter");
           bool b1 =  SetForegroundWindow(hWndActive);
           bool b2 = BringWindowToTop(hWndActive);
        }

        private bool SubKeyExist(string Subkey)
        {
            RegistryKey myKey = Registry.LocalMachine.OpenSubKey(Subkey);
            if (myKey == null)
                return false;
            else
                return true;
        }

        private void ProcessMinimize(bool start, bool  onlyInfo)
        {
            try
            {
                this.ShowInTaskbar = true;
                notifyIcon1.BalloonTipTitle = "PMDS Starter";
                if (start)
                {
                    notifyIcon1.BalloonTipText = "PMDS Anwendung wird gestartet\r\n\r\n";
                    notifyIcon1.BalloonTipText += "Sie können hier den Starter wiederherstellen.\nNutzen Sie die rechte Maustaste, um den Startmanager zu beenden.";
                    notifyIcon1.Visible = true;
                    notifyIcon1.ShowBalloonTip(3000);
                }
                if (!onlyInfo) 
                    this.WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                throw new Exception("frmLauncher2.ProcessMinimize: " + ex.ToString());
            }
        }


        private void buttClick(object sender, EventArgs e)
        {
            try
            {
                string tgButt = (string)((Button)sender).Tag;
                this.startProg(tgButt, true, tgButt == "BUTTON_FORMS" ? true : false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error - frmLauncher2.buttClick: " + ex.ToString(), "PMDS - Launcher");
            }
        }

        
        private void activateButtonsConfig()
        {
            int anzButtVis = 0;
            foreach (System.Windows.Forms.Button butt in this.panelButtons.Controls)
            {
                foreach (dsConfig.configRow rConfig in Launcher.config.dsconfigAll.config)
                {
                    if (butt.Tag.ToString() == rConfig.key.ToString())
                    {
                        butt.Visible = true;
                        anzButtVis += 1;
                    }
                }
            }

            float dx, dy;
            Graphics g = this.CreateGraphics();
            dx = g.DpiX / 100;
            dy = g.DpiY / 100;

            this.Height = (int) (this.heightButt * anzButtVis * dy) + (int) (160 * dy);
        }

        public void checkUpdate(ref bool StartFromShare, bool WithMsgBox, ref bool abort)
        {
            try
            {
                bool FirstInstallation = false;

                update update1 = new update();
                update1.run(Environment.CommandLine, ref StartFromShare, WithMsgBox, ref abort, ref FirstInstallation);
                if (FirstInstallation)
                {
                    this.waitUntilUpdateThreadsReady();

                    FirstInstallation = false;
                    update1.run(Environment.CommandLine, ref StartFromShare, WithMsgBox, ref abort, ref FirstInstallation);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("frmLauncher2.checkUpdate: " + ex.ToString());
            }
        }

        private void startProg(string tg, bool  uiIsOn, bool onlineForm)
        {
            try
            {
                CfgFile ConfigFile = new CfgFile(Launcher.config.configFile);

                string typ = "";
                if (!uiIsOn)
                {
                    typ = this.config.searchKeyArg("start", Environment.CommandLine);
                    if (String.IsNullOrWhiteSpace(typ)) typ = ConfigFile.getValue("main", "start", false);
                    //if (typ == "") this.showMessageBox("Keine Defintion für 'start' in Launcher.config.[Main] oder als Parameter vorhanden!");   //Default (PMDS) starten
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(typ)) typ = ConfigFile.getValue("main", tg, false);
                    //if (typ == "") this.showMessageBox("Keine Defintion für " + tg + " in Launcher.config.[Main] oder als Parameter vorhanden!");   //Default (PMDS) starten
                }

                //Commandline-Parameter einlesen
                update.sProgramFile = this.config.searchKeyArg("ProgramFile", Environment.CommandLine);
                update.sProgramPath = this.config.searchKeyArg("ProgramPath", Environment.CommandLine);
                update.sConfigFile = this.config.searchKeyArg("ConfigFile", Environment.CommandLine);
                update.sConfigPath = this.config.searchKeyArg("ConfigPath", Environment.CommandLine);
                update.sDomain = this.config.searchKeyArg("Domain", Environment.CommandLine);
                update.sUsername = this.config.searchKeyArg("Username", Environment.CommandLine);
                update.sPasswordEnc = this.config.searchKeyArg("Password", Environment.CommandLine);

                //Commandline-Parameter übersteuern Default in Config
                if (String.IsNullOrWhiteSpace(update.sProgramFile)) update.sProgramFile = ConfigFile.getValue("Main", "ProgramFile", false);
                if (String.IsNullOrWhiteSpace(update.sProgramPath)) update.sProgramPath = ConfigFile.getValue("Main", "ProgramPath", false);
                if (String.IsNullOrWhiteSpace(update.sConfigFile)) update.sConfigFile = ConfigFile.getValue("Main", "ConfigFile", false);
                if (String.IsNullOrWhiteSpace(update.sConfigPath)) update.sConfigPath = ConfigFile.getValue("Main", "ConfigPath", false);

                if (String.IsNullOrWhiteSpace(update.sDomain)) update.sDomain = ConfigFile.getValue("Main", "Domain", false);
                if (String.IsNullOrWhiteSpace(update.sUsername)) update.sUsername = ConfigFile.getValue("Main", "Username", false);
                if (String.IsNullOrWhiteSpace(update.sPasswordEnc)) update.sPasswordEnc = ConfigFile.getValue("Main", "Password", false);

                if (String.IsNullOrWhiteSpace(update.sProgramFile)) throw new Exception("Definition für ProgramFile fehlt");
                if (String.IsNullOrWhiteSpace(update.sProgramPath)) throw new Exception("Definition für ProgramPath fehlt");
                if (String.IsNullOrWhiteSpace(update.sConfigFile)) throw new Exception("Definition für ConfigFile fehlt");
                if (String.IsNullOrWhiteSpace(update.sConfigPath)) throw new Exception("Definition für ConfigPath fehlt");

                bool StartFromShare = false;
                bool abort = false;
                this.checkUpdate(ref StartFromShare, true, ref abort);
                if (abort)
                {
                    if (!uiIsOn)
                    {
                        Process.GetCurrentProcess().Kill();
                    }
                    else
                    {
                        return;
                    }
                }

                if (!String.IsNullOrWhiteSpace(update.sProgramPath))
                {
                    if (onlineForm)
                    {
                        Process.Start(System.IO.Path.Combine(this.config.getProgramRootRoot(update.sProgramPath), "OnlineFormulare", "OnlineForms.exe"));
                    }
                    else
                    {
                        if (!this.checkFile(System.IO.Path.Combine(update.sProgramPath, update.sProgramFile)))
                            if (!uiIsOn)
                            {
                                this.ThrowMessage("startProg.checkfile");
                                this.Close();
                                return;
                            }
                            else
                                return;

                        string Version = new DirectoryInfo(this.config.getProgramRoot(update.sProgramPath)).Name;

                        //Prüfen, ob Config-File vorhanden ist
                        string tstConfigPath = update.sConfigPath.ToString();
                        if (StartFromShare)
                        {
                            tstConfigPath = System.IO.Path.Combine(tstConfigPath, "PMDS", Version, "Config");
                        }
                        tstConfigPath = System.IO.Path.Combine(tstConfigPath, update.sConfigFile);
                        if (!this.checkFile(tstConfigPath))
                            if (!uiIsOn)
                            {
                                this.ThrowMessage("startProg.if (!uiIsOn).1");
                                this.Close();
                                return;
                            }
                            else
                                return;

                        //Prüfen, ob zu startendes Programm vorhanden ist
                        if (!this.checkFile(System.IO.Path.Combine(update.sProgramPath, update.sProgramFile)))
                            if (!uiIsOn)
                            {
                                this.ThrowMessage("startProg.if (!uiIsOn).2.");
                                this.Close();
                                return;
                            }
                            else
                                return;

                        //Programm starten
                        string argsRun = typ + " ";
                        if (!String.IsNullOrWhiteSpace(this.tbUser.Text))
                        {
                            if (!this.tbUser.Text.Trim().Contains(" "))
                                argsRun += " ?usr=" + this.tbUser.Text.Trim() + " ";
                            else
                                argsRun += " ?usr=\"" + this.tbUser.Text.Trim() + "\" ";
                        }

                        if (!String.IsNullOrWhiteSpace(this.tbPasswort.Text))
                        {
                            if (!this.tbPasswort.Text.Trim().Contains(" "))
                                argsRun += " ?pwd=" + this.tbPasswort.Text.Trim() + " ";
                            else
                                argsRun += " ?pwd=\"" + this.tbPasswort.Text.Trim() + "\" ";
                        }

                        if (update.sConfigFile.Contains(" "))
                            update.sConfigFile = "\"" + update.sConfigFile + "\"";

                        if (update.sConfigPath.Contains(" "))
                            update.sConfigPath = "\"" + update.sConfigPath + "\"";

                        argsRun += " ?StartFromShare=\"" + (StartFromShare ? "1":"0") + "\" ";
                        argsRun += " ?ConfigFile=" + update.sConfigFile + " " + " ?ConfigPath=" + update.sConfigPath + " ";
                        argsRun += " ?ConfigFileLauncher=" + ConfigFile.fileName.Trim() + " ";
                        string LauncherExeTmp = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                        argsRun += " ?LauncherExe=" + LauncherExeTmp.Trim() + " ";

                        string LogPathPMDSTmp = update.logPathPMDS.Trim();
                        if (LogPathPMDSTmp.Contains(" "))
                            LogPathPMDSTmp = "\"" + LogPathPMDSTmp + "\"";
                        argsRun += " ?LogPathPMDS=" + LogPathPMDSTmp + " ";

                        argsRun += (String.IsNullOrWhiteSpace(update.sshowSplash) ? "" : " ?showSplash=" + update.sshowSplash);

                        string strExe = System.IO.Path.Combine(update.sProgramPath, update.sProgramFile).ToString();
                        if (strExe.Contains(" "))
                            strExe = "\"" + strExe + "\"";

                        //MessageBox.Show(argsRun);
                        using (Process p = new Process())
                        {
                            if (!String.IsNullOrWhiteSpace(update.sDomain) && !String.IsNullOrWhiteSpace(update.sUsername) && !String.IsNullOrWhiteSpace(update.sPasswordEnc))
                            {
                                p.StartInfo.Domain = update.sDomain;
                                p.StartInfo.UserName = update.sUsername;
                                p.StartInfo.Password = new System.Security.SecureString();

                                qs2.license.core.Encryption Encryption1 = new qs2.license.core.Encryption();
                                foreach (char c in Encryption1.StringDecrypt(update.sPasswordEnc, "*engineering_"))  //nicht ändern!! Texte in der DB und Config sind damit verschlüsselt
                                {
                                    p.StartInfo.Password.AppendChar(c);
                                }
                                p.StartInfo.UseShellExecute = false;
                            }

                            p.StartInfo.FileName = strExe;
                            p.StartInfo.Arguments = argsRun;
                            p.Start();

                            //System.Diagnostics.Process.Start(strExe, argsRun);
                            this.tbPasswort.Text = "";
                            Environment.Exit(0);
                        }
                    }

                    if (!uiIsOn)
                    {
                        this.ThrowMessage("startProg.if (!uiIsOn).3");
                        this.waitUntilUpdateThreadsReady();
                        this.Close();
                    }
                    else
                    {
                        this.ProcessMinimize(true, false);
                    }
                }
            }
            catch (Win32Exception w)
            {
                MessageBox.Show("Folgender Fehler wurde gemeldet: " + w.Message.ToString() + "\nBitte korrigieren Sie das Problem und starten Sie neu.");
            }
            catch (Exception ex)
            {
                throw new Exception("frmLauncher2.startProg: " + ex.ToString());
            }
        }

        public void waitUntilUpdateThreadsReady()
        {
            bool bRun = true;
            while (bRun)
            {
                update.WaitMilli(10);
                if (update.thread_RemoveOldInst && update.thread_CopyNextInstReady)
                {
                    bRun = false;
                }
            }
        }

        private string checkKey(string KeyName)
        {
            string ret = this.config.getKey(KeyName);
            if (String.IsNullOrWhiteSpace(ret))
            {
                this.showMessageBox("Definition für Variable " + KeyName + " fehlt in launcher.config!");
                return "";
            }
            else
                return ret;
        }

        private bool checkFile(string file)
        {
            if (!System.IO.File.Exists(file))
            {
                this.showMessageBox("Datei '" + file + "' nicht gefunden!");
                return false;
            }
            else
                return true;
        }
        private void showMessageBox(string msg)
        {
            MessageBox.Show(msg, "PMDS - Launcher");
        }

        private void logViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.startProg("BUTTON_LOG", true, false);
        }

        private void beendenToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.ThrowMessage("beendenToolStripMenuItem2_Click");
            this.Close();
        }

        private void wiederherstellenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Wiederherstellen();
        }

        private void Wiederherstellen()
        {
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void launcher_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.ProcessMinimize(false, false);
                    this.ShowInTaskbar = true;
                }
                else
                {
                    this.ShowInTaskbar = true;
                    this.WindowState = FormWindowState.Normal;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error - frmLauncher2.launcher_SizeChanged: " + ex.ToString(), "PMDS - Launcher");
            }
        }

        private void mnuNotify_DoubleClick(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Wiederherstellen();
            this.WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            //Wiederherstellen();
            //this.WindowState = FormWindowState.Normal;

            //mnuNotify.Show();
        }

        private void toTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toTop();
        }

        private void checkRunning()
        {
            try
            {
                string proc = Process.GetCurrentProcess().ProcessName;
                Process[] processes = Process.GetProcessesByName(proc);

                // if there is more than one process...
                if (processes.Length > 1)
                {
                    // Assume there is our process, which we will terminate, 
                    // and the other process, which we want to bring to the 
                    // foreground. This assumes there are only two processes 
                    // in the processes array, and we need to find out which 
                    // one is NOT us.

                    // get our process
                    Process p = Process.GetCurrentProcess();
                    int n = 0;        // assume the other process is at index 0
                    // if this process id is OUR process ID...
                    if (processes[0].Id == p.Id)
                    {
                        // then the other process is at index 1
                        n = 1;
                    }
                    IntPtr hWnd = processes[n].MainWindowHandle;
                    // if iconic, we need to restore the window
                    if (IsIconic(hWnd))
                    {
                        ShowWindowAsync(hWnd, SW_SHOWNORMAL);       //SW_RESTORE
                    }
                    SetForegroundWindow(hWnd);
                    this.ThrowMessage("checkRunning=true");
                
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("frmLauncher2.checkRunning: " + ex.ToString());
            }
        }
        private void logViewerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.startProg("BUTTON_LOG", true, false);
        }

        private void launcher_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //if (this.uiONOff != "0")
                //{
                //    if ((MessageBox.Show("Wollen Sie den PMDS Starter wirklich beenden?", "PMDS Startmanager beenden", MessageBoxButtons.YesNo) != DialogResult.Yes))
                //        e.Cancel = true;
                //}

                //this.waitUntilUpdateThreadsReady();
                if (!update.thread_RemoveOldInst || !update.thread_CopyNextInstReady)
                {
                    this.ProcessMinimize(true, false);
                    e.Cancel = true;
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error frmLauncher2.launcher_FormClosing: " + ex.ToString(), "PMDS - Launcher");
            }
        }

        private void infoRuntime()
        {
            //this.statusStrip1.Items[0].ToolTipText =  "Installationsordner: " + Application.StartupPath;     // + "\r\n"
        }

        private void beendenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.ThrowMessage("beendenToolStripMenuItem1_Click");
            this.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panelButtons_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbPasswort_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys.HasFlag(Keys.Control))
            {
                //if (sender.GetType().Equals(typeof(QS2.Desktop.ControlManagment.BaseTextEditor)))
                //{
                //    QS2.Desktop.ControlManagment.BaseTextEditor ed = (QS2.Desktop.ControlManagment.BaseTextEditor)sender;
                //    if (ed.PasswordChar == '\0')
                //        ed.PasswordChar = '*';
                //    else
                //        ed.PasswordChar = '\0';
                //}
                //else if (sender.GetType().Equals(typeof(Infragistics.Win.UltraWinEditors.UltraTextEditor)))
                //{
                //    Infragistics.Win.UltraWinEditors.UltraTextEditor ed = (Infragistics.Win.UltraWinEditors.UltraTextEditor)sender;
                //    if (ed.PasswordChar == '\0')
                //        ed.PasswordChar = '*';
                //    else
                //        ed.PasswordChar = '\0';
                //}

                //Application.DoEvents();
            }

        }
    }

}

