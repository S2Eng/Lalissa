using System;
using System.Windows.Forms;
using Infragistics.Win.UltraWinTabControl;

namespace qs2.design.auto.multiControl
{
    //[Designer(typeof(qs2.design.auto.multiControl.DesignerWizardCheck))]
    public class ownTab : UltraTabControl
    {
        private qs2.design.auto.ownMCCriteria ownControlCriteria1 = new qs2.design.auto.ownMCCriteria();
        private ownMCInfo ownControlInfo1 = new ownMCInfo();
        private ownMCUI ownControlUI1 = new ownMCUI();
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
        private System.Windows.Forms.ToolStripMenuItem criteriasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        private bool _OwnFieldForALLProducts = false;
        private UltraTabSharedControlsPage ultraTabSharedControlsPage5;
        private bool lockVisible = false;

        public ownTab()
        {
            this.InitializeComponent();

            this.criteriasToolStripMenuItem1.Text = "Criterias";
            this.criteriasToolStripMenuItem1.Click += new System.EventHandler(this.loadedDatToolStripMenuItem_Click);
            this.ContextMenuStrip1.Items.Add(this.criteriasToolStripMenuItem1);
        }

        private void InitializeComponent()
        {
            this.ultraTabSharedControlsPage5 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraTabSharedControlsPage5
            // 
            this.ultraTabSharedControlsPage5.Location = new System.Drawing.Point(0, 0);
            this.ultraTabSharedControlsPage5.Name = "ultraTabSharedControlsPage5";
            this.ultraTabSharedControlsPage5.Size = new System.Drawing.Size(0, 0);
            // 
            // ownTab
            // 
            this.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Office2007Ribbon;
            this.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007;
            this.VisibleChanged += new System.EventHandler(this.ownTab_VisibleChanged_1);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void loadedDatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.ownControlInfo1.showInfoCriterias(this, (string)this.ActiveTab.Tag, this.ownControlCriteria1.Application, this.ownControlCriteria1.IDParticipant, this.OwnFieldForALLProducts);
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

        private bool OwnFieldForALLProducts
        {
            get => this._OwnFieldForALLProducts;
            set => this._OwnFieldForALLProducts = value;
        }

        private void ownTab_VisibleChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
                {
                    this.setTab();
                }
                else
                {
                    this.Visible = true;
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void setTab()
        {
            try
            {
                if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
                {
                    bool bIsVisible = false;
                    this.doVisible2(ref bIsVisible);
                    if (bIsVisible)
                    {
                        if (this.ActiveTab == null)
                        {
                            bool bTabSelectDone = false;
                            foreach (UltraTab TabePageFound in this.Tabs)
                            {
                                if (TabePageFound.Visible && !bTabSelectDone)
                                {
                                    this.ActiveTab = TabePageFound;
                                    this.SelectedTab = TabePageFound;
                                    bTabSelectDone = true;
                                    TabePageFound.Visible = true;
                                    Application.DoEvents();
                                }
                            }
                        }
                    }
                }
                else
                {
                    this.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("setTab: " + ex.ToString());
            }

        }

        public void doVisible2(ref bool bIsVisible)
        {
            try
            {
                if (!this.lockVisible)
                {
                    this.lockVisible = true;
                  bIsVisible = this.ownControlUI1.IsVisible_Criteriaxy && this.ownControlUI1.IsVisible_LicenseKey && this.ownControlUI1.IsVisible_RelationsshipMCParent && this.ownControlUI1.IsVisible_RelationsshipGroups;
                    this.Visible = bIsVisible;
                }
            }
            catch (Exception ex)
            {
                this.lockVisible = false;
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.lockVisible = false;
            }
        }
    }
}
