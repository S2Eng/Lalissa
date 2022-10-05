using Infragistics.Win.Misc;
using System;
using System.Windows.Forms;


namespace qs2.design.auto.multiControl
{
    //[Designer(typeof(qs2.sitemap.workflowAssist.wizardsDevelop.DesignerWizardCheck))]
    public class ownGroupBox : UltraGroupBox
    {
        private string _FldShort = "";
        private qs2.design.auto.ownMCCriteria ownControlCriteria1 = new qs2.design.auto.ownMCCriteria();
        private ownMCInfo ownControlInfo1 = new ownMCInfo();

        public bool OwnFieldForALLProducts { get; set; }

        private void doText()
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
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

        private string OwnFldShort
        {
            get
            {
                return this._FldShort;
            }
            set
            {
                this._FldShort = value;
                if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
                {
                    this.Text = "[" + this._FldShort + "]";
                    if (qs2.core.ENV.developSimulateControls)
                    {
                        this.doText();
                    }
                }
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
    }    
}
