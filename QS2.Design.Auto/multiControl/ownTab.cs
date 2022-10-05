using Infragistics.Win.Misc;
using Infragistics.Win;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using qs2.sitemap.ownControls;

using Infragistics.Win.UltraWinTabs;

using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win;





namespace qs2.design.auto.multiControl
{


    //[Designer(typeof(qs2.design.auto.multiControl.DesignerWizardCheck))]
    public class ownTab : UltraTabControl
    {
        public qs2.design.auto.ownMCCriteria ownControlCriteria1 = new qs2.design.auto.ownMCCriteria();
        public ownMCInfo ownControlInfo1 = new ownMCInfo();
        public ownMCUI ownControlUI1 = new ownMCUI();
        public bool isLoaded = false;
        public System.Windows.Forms.ContextMenuStrip ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
        public System.Windows.Forms.ToolStripMenuItem criteriasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
       
        public string _FldShort = "";
        public System.Guid key = System.Guid.NewGuid();

        public bool _OwnFieldForALLProducts = false;

        public System.Guid ID = System.Guid.Empty;
        public System.Guid IDGroup = System.Guid.Empty;

        public int _OwnOrderLineNr = 1;
        public int _OwnOrderControlNr = 1;
        public int _OwnOrder = 1;

        public string FldShortTabPageParent = "";
        public string FldShortGroupBoxParent = "";
        public qs2.core.vb.dsAdmin.dbAutoUIRow rAutoUI = null;

        public bool IsVisibleControlAssignmentChapters = false;
        private UltraTabSharedControlsPage ultraTabSharedControlsPage5;

        public bool lockVisible = false;

        public ownTab()
        {
            this.InitializeComponent();

            this.criteriasToolStripMenuItem1.Text = "Criterias";
            this.criteriasToolStripMenuItem1.Click += new System.EventHandler(this.loadedDatToolStripMenuItem_Click);
            this.ContextMenuStrip1.Items.Add(this.criteriasToolStripMenuItem1);

            //if (!this.DesignMode) this.VisibleChanged += new System.EventHandler(this.ownTab_VisibleChanged);
        }


        public void doControlxy()
        {
            if (this.DesignMode)
                this.ownControlCriteria1.getLicenseDesignTime(this);
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

        public void doText()
        {
            if (this.DesignMode)
                this.ownControlCriteria1.getLicenseDesignTime(this);

            if (!this.DesignMode && qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
            {
                this.ContextMenuStrip = this.ContextMenuStrip1;
                this.criteriasToolStripMenuItem1.Text = qs2.core.language.sqlLanguage.getRes("Criterias") + " [" + qs2.core.Enums.eControlType.TabPage.ToString() + "]";
            }
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

        public string OwnFldShort
        {
            get
            {
                return this._FldShort;
            }
            set
            {
                this._FldShort = value;
                //if (this.DesignMode)
                //{
                //    this.Text = "[" + this._FldShort + "]";
                //    if (qs2.core.Settings.developSimulateControls)
                //    {
                //        this.doText();
                //    }
                //}
            }
        }

        public bool OwnFieldForALLProducts
        {
            get
            {
                return this._OwnFieldForALLProducts;
            }
            set
            {
                this._OwnFieldForALLProducts = value;
                //if (this.DesignMode) this.doControl();
            }
        }


        public int OwnOrderLineNr
        {
            get
            {
                return this._OwnOrderLineNr;
            }
            set
            {
                this._OwnOrderLineNr = value;
            }
        }
        public int OwnOrderControlNr
        {
            get
            {
                return this._OwnOrderControlNr;
            }
            set
            {
                this._OwnOrderControlNr = value;
            }
        }
        public int OwnOrder
        {
            get
            {
                return this._OwnOrder;
            }
            set
            {
                this._OwnOrder = value;
            }
        }

        private void ownTab_VisibleChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (!DesignMode)
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
                if (!DesignMode)
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
                    //if (!this.ownControlUI1.IsVisible_LicenseKey)
                    //{
                    //    string xy = "";
                    //}
                  bIsVisible = this.ownControlUI1.IsVisible_Criteriaxy && this.ownControlUI1.IsVisible_LicenseKey && this.ownControlUI1.IsVisible_RelationsshipMCParent && this.ownControlUI1.IsVisible_RelationsshipGroups;
                    this.Visible = bIsVisible;

                    //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(this.OwnFldShort, "tabOpAoDis", false))
                    //{
                    //    string xy = "";
                    //}
                    //this.Visible = (this.ownControlUI1.IsVisible_Criteriaxy && this.IsVisibleControlAssignmentChapters);
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
