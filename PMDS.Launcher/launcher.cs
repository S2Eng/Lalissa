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
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;


using QS2.Resources;

namespace Launcher
{


    public partial class launcher : Form
    {
        private config config;
        private ui cUi = new ui();
        private int heightButt = 42;
        private string sConfigPath = "";
        private string sConfigFile = "";
        private string sProgramPath = "";
        private string sProgramFile = "";

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

        public launcher()
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
               launcher.debugmode = this.config.getKey("debugmode");

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
                MessageBox.Show(ex.ToString());
            }
        }


        public void ThrowMessage(string txt)
        {
            if (launcher.debugmode.Trim() == "1" )
            {
                MessageBox.Show(txt);
            }

        }



        private void regForm()
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
            this.ShowInTaskbar = true;
            notifyIcon1.BalloonTipTitle = "PMDS Starter";
            if (start)
            {
                notifyIcon1.BalloonTipText = "PMDS Anwendung wird gestartet\r\n\r\n";
                notifyIcon1.BalloonTipText += "Sie können hier den Starter wiederherstellen\r\noder nutzen Sie die rechte Maustaste um den Startmanager zu beenden";

                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(5000);
            }
            if (!onlyInfo) this.WindowState = FormWindowState.Minimized;
        }
        


        private void buttClick(object sender, EventArgs e)
        {
           string tgButt = (string)((Button)sender).Tag;
           this.startProg(tgButt, true, tgButt == "BUTTON_FORMS" ? true : false);
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

        private void startProg(string tg, bool  uiIsOn, bool onlineForm)
        {

            CfgFile ConfigFile = new CfgFile(Launcher.config.configFile);

            string typ = "";
            if (!uiIsOn)
            {
                typ = this.config.searchKeyArg("start", Environment.CommandLine);
                if (typ == "") typ = ConfigFile.getValue("main", "start", false);
                //if (typ == "") this.showMessageBox("Keine Defintion für 'start' in Launcher.config.[Main] oder als Parameter vorhanden!");   //Default (PMDS) starten
            }
            else
            {
                if (typ == "") typ = ConfigFile.getValue("main", tg, false);
                //if (typ == "") this.showMessageBox("Keine Defintion für " + tg + " in Launcher.config.[Main] oder als Parameter vorhanden!");   //Default (PMDS) starten
            }



            //Commandline-Parameter einlesen
            this.sProgramFile = this.config.searchKeyArg("ProgramFile", Environment.CommandLine);
            this.sProgramPath = this.config.searchKeyArg("ProgramPath", Environment.CommandLine);
            this.sConfigFile = this.config.searchKeyArg("ConfigFile", Environment.CommandLine);
            this.sConfigPath = this.config.searchKeyArg("ConfigPath", Environment.CommandLine);


            //Commandline-Parameter übersteuern Default in Config
            if (this.sProgramFile == "") this.sProgramFile = ConfigFile.getValue("Main", "ProgramFile", false);
            if (this.sProgramPath == "") this.sProgramPath = ConfigFile.getValue("Main", "ProgramPath", false);
            if (this.sConfigFile == "") this.sConfigFile = ConfigFile.getValue("Main", "ConfigFile", false);
            if (this.sConfigPath == "") this.sConfigPath = ConfigFile.getValue("Main", "ConfigPath", false);

            if (this.sProgramFile == "") throw new Exception("Definition für ProgramFile fehlt");
            if (this.sProgramPath == "") throw new Exception("Definition für ProgramPath fehlt");
            if (this.sConfigFile == "") throw new Exception("Definition für ConfigFile fehlt");
            if (this.sConfigPath == "") throw new Exception("Definition für ConfigPath fehlt");


            if (this.sProgramPath != "")
            {
                if (onlineForm)
                {
                    Process.Start(System.IO.Path.Combine(this.config.getProgramRootRoot(this.sProgramPath), "OnlineFormulare", "OnlineForms.exe"));
                }
                else
                {
                    if (!this.checkFile(System.IO.Path.Combine(this.sProgramPath, this.sProgramFile)))
                        if (!uiIsOn)
                        {
                            this.ThrowMessage("startProg.checkfile");
                            this.Close();
                            return;
                        }
                        else
                            return;

                    string Version = "";
                    Version = this.config.getProgramRoot(this.sProgramPath);
                    Version = Version.Substring(Version.LastIndexOf("\\") + 1);



                    //Prüfen, ob Config-File vorhanden ist
                    string tstConfigPath = this.sConfigPath.ToString();
                    tstConfigPath = System.IO.Path.Combine(tstConfigPath, "PMDS", Version, "Config");
                    tstConfigPath = System.IO.Path.Combine(tstConfigPath, this.sConfigFile);
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
                    if (!this.checkFile(System.IO.Path.Combine(this.sProgramPath, this.sProgramFile)))
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
                    if (this.tbUser.Text.Trim() != "")
                    {
                        if (!this.tbUser.Text.Trim().Contains(" "))
                            argsRun += " ?usr=" + this.tbUser.Text.Trim() + " ";
                        else
                            argsRun += " ?usr=\"" + this.tbUser.Text.Trim() + "\" ";
                    }

                    if (this.tbPasswort.Text.Trim() != "")
                    {
                        if (!this.tbPasswort.Text.Trim().Contains(" "))
                            argsRun += " ?pwd=" + this.tbPasswort.Text.Trim() + " ";
                        else
                            argsRun += " ?pwd=\"" + this.tbPasswort.Text.Trim() + "\" ";
                    }

                    if (this.sConfigFile.Contains(" "))
                        this.sConfigFile = "\"" + this.sConfigFile + "\"";

                    if (this.sConfigPath.Contains(" "))
                        this.sConfigPath = "\"" + this.sConfigPath + "\"";

                    argsRun += " ?ConfigFile=" + this.sConfigFile + " " + " ?ConfigPath=" + this.sConfigPath + " ";

                    string strExe = System.IO.Path.Combine(this.sProgramPath, this.sProgramFile).ToString();
                    if (strExe.Contains(" "))
                        strExe = "\"" + strExe + "\"";

                    System.Diagnostics.Process.Start(strExe, argsRun);
                    this.tbPasswort.Text = "";
                }

                if (!uiIsOn)
                {
                    this.ThrowMessage("startProg.if (!uiIsOn).3");
                    this.Close();

                }
                else
                {
                    this.ProcessMinimize(true, false);
                }
            }

        }

        private string checkKey(string KeyName)
        {
            string ret = this.config.getKey(KeyName);
            if (ret == "")
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
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ProcessMinimize(false, false );
                this.ShowInTaskbar = true;
            }
            else
            {
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
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

        private void logViewerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.startProg("BUTTON_LOG", true, false);
        }



        private void launcher_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (this.uiONOff != "0")
            //{
            //    if ((MessageBox.Show("Wollen Sie den PMDS Starter wirklich beenden?", "PMDS Startmanager beenden", MessageBoxButtons.YesNo) != DialogResult.Yes))
            //        e.Cancel = true;
            //}
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

         
    }

}

