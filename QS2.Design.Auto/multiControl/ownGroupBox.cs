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





namespace qs2.design.auto.multiControl
{

    //[Designer(typeof(qs2.sitemap.workflowAssist.wizardsDevelop.DesignerWizardCheck))]
    public class ownGroupBox : UltraGroupBox
    {

        public string _FldShort = "";
        public qs2.design.auto.ownMCCriteria ownControlCriteria1 = new qs2.design.auto.ownMCCriteria();
        public ownMCInfo ownControlInfo1 = new ownMCInfo();
        public ownMCUI ownControlUI1 = new ownMCUI();
        private IContainer components;

        public bool isLoaded = false;

        public System.Guid key = System.Guid.NewGuid();
        public qs2.sitemap.workflowAssist.form.contAutoUI parentAutoUI;
        //public int _tabIndex = 0;

        public bool _OwnFieldForALLProducts = false;

        public System.Guid ID = System.Guid.Empty;
        public System.Guid IDGroup = System.Guid.Empty;

        public int _OwnOrderLineNr = 1;
        public int _OwnOrderControlNr = 1;
        public int _OwnOrder = 1;

        public bool lockVisibleChanged = false;

        public qs2.core.vb.dsAdmin.dbAutoUIRow rAutoUI = null;

        public bool IsVisibleControlxy = false;
        public bool IsVisibleControlAssignmentChapters = false;
        public bool IsVisible_RelationsshipGroupsxy = true;
        public bool _OwnDoNotPrint = false;
        public qs2.design.auto.workflowAssist.autoForm.ColorSchemas ColorSchemas1 = new qs2.design.auto.workflowAssist.autoForm.ColorSchemas();

     



        public ownGroupBox()
        {
            this.InitializeComponent();
            if (!this.DesignMode) this.VisibleChanged += new System.EventHandler(this.ownGroupBox_VisibleChanged);
        }


        public void doControl()
        {
            this.HeaderAppearance.FontData.SizeInPoints = ownMultiControl.fontsize;
            this.doText();
            if (!this.DesignMode)
            {
                //if (this.DesignMode )
                //    this.controlData1.getLicense(this.DesignMode, this);
                //this.controlData1.getData(this, this._FldShort, core.Enums.eControlType.GroupBox, null);
            }
            if (this.DesignMode)
                this.ownControlCriteria1.getLicenseDesignTime(this);

        }
        private void doText()
        {
            if (this.DesignMode)
                this.ownControlCriteria1.getLicenseDesignTime(this);

            if (this.OwnFldShort.Trim() != "")
            {
                qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;
                this.Text = qs2.core.language.sqlLanguage.getRes(this.OwnFldShort.Trim(), core.Enums.eResourceType.Label, ownControlCriteria1.IDParticipant, ownControlCriteria1.Application, ref  rLangFoundReturn).Trim();

                if (qs2.core.ENV.ExtendedUI)
                {
                    System.Windows.Forms.ContextMenuStrip contextMenuStripGroupBox;
                    contextMenuStripGroupBox = new System.Windows.Forms.ContextMenuStrip();

                    System.Windows.Forms.ToolStripMenuItem criteriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                    criteriasToolStripMenuItem.Name = "toolStripMenuItem1";
                    criteriasToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
                    criteriasToolStripMenuItem.Text = "criterias";
                    criteriasToolStripMenuItem.Click += new System.EventHandler(this.loadedDatToolStripMenuItem_Click);

                    System.Windows.Forms.ToolStripMenuItem ressourcenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                    ressourcenToolStripMenuItem.Name = "ressourcenToolStripMenuItem_Click";
                    ressourcenToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
                    ressourcenToolStripMenuItem.Text = "ressourcen";
                    ressourcenToolStripMenuItem.Click += new System.EventHandler(this.loadedRessourcenToolStripMenuItem_Click);

                    contextMenuStripGroupBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                                            criteriasToolStripMenuItem,
                                                            ressourcenToolStripMenuItem});
                    this.ContextMenuStrip = contextMenuStripGroupBox;
                    
                    criteriasToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("Criterias") + " [" + qs2.core.Enums.eControlType.GroupBox.ToString() + "]";
                    ressourcenToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("Ressourcen") + " [" + qs2.core.Enums.eControlType.GroupBox.ToString() + "]";

                }
                else
                {
                    qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn2 = null;
                    string txtToolTip = qs2.core.language.sqlLanguage.getRes(this._FldShort.Trim(), core.Enums.eResourceType.ToolTip, this.ownControlCriteria1.IDParticipant, this.ownControlCriteria1.Application.ToString(), ref  rLangFoundReturn2).Trim();
                    if (txtToolTip != "")
                        this.ownControlInfo1.doToolTipxy(this, qs2.core.language.sqlLanguage.getRes("Info"), txtToolTip, this, false, this.ownControlCriteria1.Application, this.OwnFieldForALLProducts);
                }
            }
        }
        public void showTabOrder()
        {
            //this.ownControlInfo1.doToolTip(this, "TabIndex", this._tabIndex.ToString(), this, true, this.ownControlCriteria1.IDApplication.ToString(), this.OwnFieldForALLProducts);
     
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
                if (this.DesignMode)
                {
                    this.Text = "[" + this._FldShort + "]";
                    if (qs2.core.ENV.developSimulateControls)
                    {
                        this.doText();
                    }
                }
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
        public bool OwnDoNotPrint
        {
            get
            {
                return this._OwnDoNotPrint;
            }
            set
            {
                this._OwnDoNotPrint = value;
            }
        }

        public void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
 
        private void loadedDatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.ownControlInfo1.showInfoCriterias(this, this.ownControlCriteria1.rCriteria.FldShort, this.ownControlCriteria1.Application, this.ownControlCriteria1.IDParticipant, this.OwnFieldForALLProducts);
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
        private void loadedRessourcenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.ownControlInfo1.showInfoRessourcen(this, this.ownControlCriteria1.rCriteria.FldShort, this.ownControlCriteria1.Application, this.ownControlCriteria1.IDParticipant, this.OwnFieldForALLProducts);
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
        private void ownGroupBox_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                //this.SuspendLayout();

                if (this.lockVisibleChanged)
                {
                    return;
                }
                //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(this._FldShort, "GroupBoxNotExists", false))
                //{
                //    string xy = "";
                //}

                //if (!this.ownControlUI1.IsVisible_Criteriaxy)
                //{
                //    string xy = "";
                //}
                if (!DesignMode)
                {
                    this.lockVisibleChanged = true;
                    this.doVisible2();
                    this.TabIndex = this.OwnOrderLineNr * 10 + this.OwnOrderControlNr;
                    this.lockVisibleChanged = false;
                }
                else
                {
                    this.Visible = true;
                }
            }
            catch (Exception ex)
            {
                this.lockVisibleChanged = false;
                //this.ResumeLayout();
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                //this.ResumeLayout();
            }
        }
  
        public void doVisible2()
        {
            try
            {
                this.lockVisibleChanged = true;
                this.Visible = (this.ownControlUI1.IsVisible_Criteriaxy && this.ownControlUI1.IsVisible_LicenseKey && this.IsVisibleControlAssignmentChapters && this.ownControlUI1.IsVisible_RelationsshipGroups);
                this.ColorSchemas1.setAppearanceMC(null, this, null, core.Enums.eControlType.GroupBox);
                this.lockVisibleChanged = false;
            }
            catch (Exception ex)
            {
                this.lockVisibleChanged = false;
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void doVisible()
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv" && this.parentAutoUI != null)
            {
                if (!this.isLoaded)
                {
                    this.ownControlCriteria1._ControlIsFormatted = true;
                    if (qs2.core.ENV.ExtendedUI && qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
                    {
                        this.showTabOrder();
                    }
                    this.isLoaded = true;
                }
            }
        }
    }    
}
