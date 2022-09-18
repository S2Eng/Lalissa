using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using QS2.Resources;

using System.Runtime.InteropServices;





namespace qs2.sitemap.workflowAssist.form
{



    public partial class frmAutoUI : Form
    {

        private string _IDResTitleForm = "Stay";

        public qs2.core.license.doLicense.eApp Application;
        public int numberForm = 0;

        public qs2.core.vb.dsObjects.tblStayRow rStay;
        public qs2.core.vb.dsObjects.tblObjectRow rPatient;
        public bool SaveWasClicked = false;
        public bool isInEditMode = false;

        public contAutoUI contAutoUI = null;
        public qs2.design.auto.workflowAssist.autoForm.tgWindowHandler tgWindowHandlerWindow = null;

        public bool evDoRefreshStayListIsInitialized = false;
        public event doRefreshStayList evDoRefreshStayList;
        public delegate void doRefreshStayList();

        public bool closeFormAuto = false;

        public bool WasVisibleFirst = false;
        public Timer TimerAppClosesbyuser = null;

        public bool FormSucessfulClosed = false;
        

        [DllImport("User32.dll")]
        static extern long SetForegroundWindow(int hwnd);


        //public System.Windows.Forms.Timer timerThreadDoEvents = null;
        public bool IsInitialized = false;

        public qs2.design.auto.workflowAssist.autoForm.dataStay dataStay = new design.auto.workflowAssist.autoForm.dataStay();

        //public static bool bMainFormIsInFront = false;
        public FormWindowState prevState;

        public bool doFctSetUI = true;
        public bool DoNotLoadData = false;

        private static qs2.design.auto.multiControl.frmMCHelp frmMCHelp1;

        //[System.Runtime.InteropServices.DllImport("user32.dll")]
        //private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        //[System.Runtime.InteropServices.DllImport("user32.dll")]
        //private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        //private enum KeyModifier
        //{
        //    None = 0,
        //    Alt = 1,
        //    Control = 2,
        //    Shift = 4,
        //    WinKey = 8
        //}









        public frmAutoUI()
        {
            InitializeComponent();
            if (!this.DesignMode)
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_QS2, 32, 32);

                if (qs2.core.ENV.StaysAsExternProcess2)
                {
                    //int id = 0;
                    //RegisterHotKey(this.Handle, id, (int)KeyModifier.None, Keys.F1.GetHashCode());
                }
            }
            else
            {
                qs2.core.logIn.connectDesignMode(); 
            }
        }




        private void frmAutoUI_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.DoNotLoadData)
                    return;

                this.Visible = true;

                this.tgWindowHandlerWindow.IsOpend = true;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void frmAutoUI_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                try
                {
                    if (e.KeyCode == Keys.F1)               // && qs2.core.ENV.StaysAsExternProcess2
                    {
                        if (qs2.design.auto.multiControl.ownMCEvents.lLastMCFocused5.Count() > 0)
                        {
                            var rSel = qs2.design.auto.multiControl.ownMCEvents.lLastMCFocused5.First();
                            if (rSel.HasRes)
                            {
                                if (frmMCHelp1 == null) frmMCHelp1 = new design.auto.multiControl.frmMCHelp();
                                frmMCHelp1.initControl(rSel.FldHort, rSel.IDApplication);
                                frmMCHelp1.ShowDialog();
                                frmMCHelp1.TopMost = true;
                                frmMCHelp1.TopMost = false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    qs2.core.generic.getExep(ex.ToString(), ex.Message);
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void initControl()
        {
            try
            {
                this.IsInitialized = true;
            }
            catch (Exception ex)
            {
                throw new Exception("initControl: " + ex.ToString());
            }
        }

        public void setTitleWindow(qs2.design.auto.workflowAssist.autoForm.dataStay dataStay1)
        {
            try
            {
                this.Text = qs2.design.auto.workflowAssist.autoForm.autoUI.getTitleWindow(this._IDResTitleForm, this.rStay, this.Application.ToString(), ref dataStay1.rPatient);

            }
            catch (Exception ex)
            {
                throw new Exception("setTitleWindow: " + ex.ToString());
            }
        }

        public void ClearTitleWindow()
        {
            try
            {
                this.Text = "";

            }
            catch (Exception ex)
            {
                throw new Exception("ClearTitleWindow: " + ex.ToString());
            }
        }
        public string OwnIDResTitleForm
        {
            get
            {
                return this._IDResTitleForm;
            }
            set
            {
                this._IDResTitleForm = value;
            }
        }

        private void frmAutoUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!this.closeFormAuto)
                {
                    this.ClosingWindow(sender, e);
                }
                else
                {
                    //string xy = "";
                }

                //this.DisposeAllControls();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        public void refreshStayList()
        {
            try
            {
                if (this.evDoRefreshStayList != null)
                {
                    
                    //this.Invoke(this.evDoRefreshStayList.Invoke);
                    this.evDoRefreshStayList.Invoke();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmAutoUI.refreshStayList: " + ex.ToString());
            }
        }

        public void DisposeAllControls()
        {
            try
            {
                //this.DestroyHandle();
                //this.Dispose(false);

                qs2.design.auto.workflowAssist.autoForm.DestroyAllControls DestroyAllControls1 = new design.auto.workflowAssist.autoForm.DestroyAllControls();
                DestroyAllControls1.DisposeAllControls(this.Controls, this);

                this.DestroyHandle();
                //string xy = "";

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }

        }

        public void ClosingWindow(object sender, FormClosingEventArgs e)
        {
            try
            {
                System.Windows.Forms.Application.DoEvents();
                if (this.isInEditMode)
                {
                    if (this.FormSucessfulClosed)
                    {
                        this.FormSucessfulClosed = true;
                        this.tgWindowHandlerWindow.IsOpend = false;
                        this.Visible = false;
                        this.prevState = this.WindowState;
                        this.WindowState = FormWindowState.Minimized;   //lthxyxyxy
                        e.Cancel = true;
                        return;
                    }
                    this.FormSucessfulClosed = true;
                    this.tgWindowHandlerWindow.IsOpend = false;
                    this.Visible = false;
                    this.prevState = this.WindowState;
                    this.WindowState = FormWindowState.Minimized;   //lthxyxyxy
                    e.Cancel = true;
                    qs2.core.threadStayUI.StayIsClosed = true;
                    System.Windows.Forms.Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                //UnregisterHotKey(this.Handle, 0);
                e.Cancel = true;
                throw new Exception("ClosingWindow: Error ClosingWindow Stay!" + "\r\n" + ex.ToString());
            }
        }

        private void frmAutoUI_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.DoNotLoadData)
                {
                    this.setUIAfterVisible2();
                    return;
                }
                   

                if (this.Visible)
                {
                    if (this.prevState != null && this.prevState != FormWindowState.Minimized)
                    {
                        this.WindowState = this.prevState;
                    }
                    else
                    {
                        this.WindowState = FormWindowState.Normal;
                    }

                    this.SuspendLayout();

                    if (!this.WasVisibleFirst)
                    {
                        string protocollForAdmin = "";
                        bool ProtocolWindow = false;

                        if (this.TimerAppClosesbyuser == null)
                        {
                            this.TimerAppClosesbyuser = new Timer();
                            this.TimerAppClosesbyuser.Interval = 400;
                            this.TimerAppClosesbyuser.Tick += new EventHandler(this.AppClosedByUser);
                        }
                        this.contAutoUI.dropDownErrors.Appearance.ForeColor = Color.Red;
                        this.TimerAppClosesbyuser.Enabled = true;
                        this.TimerAppClosesbyuser.Start();
                        this.WasVisibleFirst = true;
                        contAutoUI._isNew2 = false;
                    }

                    object oOpenFormStayUI = qs2.core.vb.actUsr.adjustRead("", core.vb.sqlAdmin.eAdjust.StayUIOpenForm, core.vb.sqlAdmin.eTypSelAdjust.all, "");
                }
            }
            catch (Exception ex)
            {
                this.TopMost = false;
                this.contAutoUI.Visible = true;
                this.contAutoUI.tabPages.Visible = true;
                this.ResumeLayout();
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }

            finally
            {
                if (!this.DoNotLoadData)
                {
                    if (doFctSetUI)
                        setUIAfterVisible(true);
                }
            }
        }
        public void setUIAfterVisible(bool bOn)
        {
            try
            {
                if (this.Visible)
                {
                    this.panelAllWhite.Visible = !bOn;
                    this.contAutoUI.Visible = bOn;
                    this.contAutoUI.tabPages.Visible = bOn;
                    this.ResumeLayout();
                    this.panelAutoForm.Visible = bOn;
                    this.contAutoUI.PanelTop.Visible = bOn;
                    this.contAutoUI.contListChapters.Visible = bOn;
                    this.contAutoUI.contListProdGroups.Visible = bOn;
                    System.Windows.Forms.Application.DoEvents();

                    this.TopMost = true;
                    this.Show();
                    this.TopMost = false;                   
                }
                else
                {
                    this.TopMost = false;
                }

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void setUIAfterVisible2()
        {
            try
            {
                this.panelAllWhite.Visible = false;
                this.contAutoUI.Visible = true;
                this.contAutoUI.tabPages.Visible = true;
                this.ResumeLayout();
                this.panelAutoForm.Visible = true;
                this.contAutoUI.PanelTop.Visible = true;
                this.contAutoUI.contListChapters.Visible = true;
                this.contAutoUI.contListProdGroups.Visible = true;
                System.Windows.Forms.Application.DoEvents();

                //this.TopMost = true;
                //this.Show();
                //this.TopMost = false;

                this.WasVisibleFirst = true;
                this.contAutoUI.IsFirstLoad = false;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void AppClosedByUser(object sender, System.EventArgs e)
        {
            try
            {
                if (qs2.core.threadStayUI.QS2ClosedByUser)
                {
                    this.closeFormAuto = true;
                    this.Close();
                }
                if (qs2.core.threadStayUI.UserHasDoubleClickedOpenStay)
                {
                    this.closeFormAuto = true;
                    this.Close();
                }
                
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        private void frmAutoUI_Activated(object sender, EventArgs e)
        {
            try
            {
                qs2.core.Protocol.alwaysShowExceptionMulticontrol = false;
                qs2.core.vb.frmActivity.CloseSplashScreen();
                if (qs2.core.Protocol.nrOfError > 0 && !qs2.core.ENV.adminSecure && !qs2.core.Protocol.ErrorsShowedToUser)
                {
                    string sTranslated = qs2.core.language.sqlLanguage.getRes("ThereAreErrorPleaseSeeDetailedProtocol");
                    if (sTranslated.Trim() == "")
                    {
                        sTranslated = "There are Errors! \r\nPlease see detailed protocol and contact your administrator!" +
                                        " (" + qs2.core.Protocol.nrOfError.ToString() + " Errors)";
                    }
                    else
                    {
                        sTranslated += " (" + qs2.core.Protocol.nrOfError.ToString() + " Errors)";
                    }
                    qs2.core.Protocol.ErrorsShowedToUser = true;
                    qs2.core.generic.showMessageBox(sTranslated, MessageBoxButtons.OK, "Error");
                }

                //int hwnd = this.Handle.ToInt32();
                //SetForegroundWindow(hwnd);
                this.ShowInTaskbar = true;
                this.BringToFront();

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        private void frmAutoUI_Resize(object sender, EventArgs e)
        {
            try
            {
                qs2.core.ENV.LoactionStay = this.Location;
                qs2.core.ENV.LoactionSizeStay = this.Size;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
            }
        }
        private void frmAutoUI_Move(object sender, EventArgs e)
        {
            try
            {
                qs2.core.ENV.LoactionStay = this.Location;
                qs2.core.ENV.LoactionSizeStay = this.Size;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
            }
        }

        private static void doTimerThreadDoEventsxy(Object o, EventArgs evArgs)
        {
            //qs2.core.generic.WaitMilli(5000);
            //System.Windows.Forms.Application.DoEvents();
        }


    }
}
