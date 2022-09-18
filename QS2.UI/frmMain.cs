using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;



namespace qs2.ui
{



    public partial class frmMain : Form
    {

        public bool LockToolbar = false;
        public bool UnvisibleOnClose = false;
        public static int minHeightMain = 800;
        public static qs2.design.auto.workflowAssist.autoForm.AutoControlsUI AutoControlsUI1 = new qs2.design.auto.workflowAssist.autoForm.AutoControlsUI();
        private static qs2.design.auto.multiControl.frmMCHelp frmMCHelp1;


        public frmMain()
        {
            InitializeComponent();
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            //Check, if VCRedist 2013 64Bit is installed
            //string keyName = qs2.core.generic.getResEx("TxtControl_VC_Runtime", @"HKEY_LOCAL_MACHINE\SOFTWARE\Classes\Installer\Dependencies\{050d4fc8-5d48-4b8f-8972-47c82c46020f}");
            //string keyName2 = qs2.core.generic.getResEx("TxtControl_VC_Runtime2", @"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\VisualStudio\12.0\VC\Runtimes\x64");

            //if (!String.IsNullOrWhiteSpace(keyName) && 
            //    (Microsoft.Win32.Registry.GetValue(keyName, "Version", null) == null && 
            //        Microsoft.Win32.Registry.GetValue(keyName2, "Version", null) == null)
            //    )
            //{
            //    //Key Not Exist                
            //    qs2.core.generic.showMessageBox(qs2.core.generic.TranslateEx("Missing_TxtControl_VC_Runtime"), MessageBoxButtons.OK, "");
            //    this.contMain1.AskForCloseApp = false;
            //    this.Close();
            //}

            this.ultraToolbarsManagerMain.Toolbars[0].Tools[0].SharedProps.Caption = qs2.core.language.sqlLanguage.getRes("File");
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    if (qs2.core.ui.lLastMCFocused.Count() > 0)
                    {
                        var rFoc = qs2.core.ui.lLastMCFocused.First();
                        if (rFoc.HasRes)
                        {
                            if (frmMCHelp1 == null) frmMCHelp1 = new design.auto.multiControl.frmMCHelp();
                            frmMCHelp1.initControl(rFoc.FldHort, rFoc.IDApplication);
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

        private void ultraToolbarsManagerMain_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!this.LockToolbar)
                {
                    this.LockToolbar = true;
                    this.contMain1.ultraToolbarsManagerMainToolClick(sender, e);
                    this.LockToolbar = false;
                }
            }
            catch (Exception ex)
            {
                this.LockToolbar = false;
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.LockToolbar = false;
                this.Cursor = Cursors.Default;
            }
        }

        private void ultraToolbarsManagerMain_AfterToolDropdown(object sender, Infragistics.Win.UltraWinToolbars.ToolDropdownEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
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

        private void frmMain_Resize(object sender, EventArgs e)
        {
            try
            {
                if (this.Height < frmMain.minHeightMain)
                {
                    this.Height = frmMain.minHeightMain;
                }

                qs2.core.ENV.LoactionMain = this.Location;
                qs2.core.ENV.LoactionSizeMain = this.Size;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
            }
        }

        private void frmMain_Move(object sender, EventArgs e)
        {
            try
            {
                qs2.core.ENV.LoactionMain = this.Location;
                qs2.core.ENV.LoactionSizeMain = this.Size;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
            }
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            try
            {
                qs2.core.Protocol.alwaysShowExceptionMulticontrol = true;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
            }
        }

        private void frmMain_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    qs2.core.ui.doForegroundWindow(this);
                    AutoControlsUI1.run2(this, this.components);

                    this.timerCheckUpdateNews1.Interval = 4000;
                    this.timerCheckUpdateNews1.Enabled = true;
                    this.timerCheckUpdateNews1.Start();
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
    }

}

