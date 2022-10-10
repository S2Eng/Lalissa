using System;
using System.Windows.Forms;
using QS2.Resources;
using Infragistics.Win.Misc;

namespace qs2.sitemap.workflowAssist
{
    public partial class contListAssistentElem : UserControl
    {
        private bool isLoaded;
        private qs2.design.auto.multiControl.ownMCEvents mcEvent1 = new design.auto.multiControl.ownMCEvents();

        public event EventHandler ownClick2;
        public event delDoActionEvaluation dDoActionEvaluation;
        public delegate void delDoActionEvaluation(string type, int IDSelListEntry, string Application, string QueryName);
        public qs2.design.auto.workflowAssist.assist.cListAssistentElem cListAssistentElem { get; set; }= new design.auto.workflowAssist.assist.cListAssistentElem();

        public contListAssistentElem()
        {
            InitializeComponent();
        }

        public void InitControl(qs2.core.Enums.eTypList TypList, string Application, string Participant,
                                int IDSelListEntrySublist, bool useDropDownControl, string GroupToLoad)
        {
            if (this.isLoaded)
                return;
            
            this.cListAssistentElem.ID = System.Guid.NewGuid();
            this.assignRightsUsersToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("AssignRightsUsers");

            this.cListAssistentElem._TypList = TypList;
            this.btnOK.Tag = false;

            if (useDropDownControl)
            {
                this.contListElementDropDown1.mainControl = this;
                this.contListElementDropDown1.InitControl(TypList, Application, Participant, IDSelListEntrySublist, GroupToLoad);
            }

            this.ContextMenuStrip = this.contextMenuStrip1;
            this.isLoaded = true;
        }

        private void contButtAssistentElem_Load(object sender, EventArgs e)
        {
        }
        
        private void btnElement_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                bool bOK = false;
                if (this.cListAssistentElem.IsQuerySystem)
                {
                    bOK = true;
                }
                else
                {
                    bool isInEditMode = false;
                }

                if (bOK)
                {
                    string protocollForAdmin = "";
                    bool ProtocolWindow = false;
                    System.Collections.Generic.List<string> lstElementsActive = new System.Collections.Generic.List<string>();
                    qs2.design.auto.ownMCRelationship.eTypAssignments TypAssignmentToCheck = design.auto.ownMCRelationship.eTypAssignments.none;
                    
                    this.btnElementClick(sender, e, !this.isOn, true, true, ref protocollForAdmin, ref ProtocolWindow, ref lstElementsActive, 
                                        ref TypAssignmentToCheck, true, true);
                    this.cListAssistentElem.assistent?.doAssignments(ref protocollForAdmin, ref ProtocolWindow, this.cListAssistentElem.IDSelEntry, this.isOn);
                    
                    this.Cursor = Cursors.WaitCursor;
                
                    if (!string.IsNullOrWhiteSpace(protocollForAdmin))
                    {
                        qs2.design.auto.multiControl.ownMCInfo.openProtocoll(ref protocollForAdmin);
                    }
                }
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

        public void btnElement_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                bool bOK = false;
                if (this.cListAssistentElem.IsQuerySystem)
                {
                    bOK = true;
                }
                else
                {
                    bool isInEditMode = false;
                }

                if (bOK)
                {
                    string protocollForAdmin = "";
                    bool ProtocolWindow = false;
                    System.Collections.Generic.List<string> lstElementsActive = new System.Collections.Generic.List<string>();
                    qs2.design.auto.ownMCRelationship.eTypAssignments TypAssignmentToCheck = design.auto.ownMCRelationship.eTypAssignments.none;

                    this.btnElementClick(sender, e, !this.isOn, true, true, ref protocollForAdmin, ref ProtocolWindow, ref lstElementsActive, 
                                        ref TypAssignmentToCheck, true, true);
                    if (this.cListAssistentElem.assistent != null)
                    {
                        this.cListAssistentElem.assistent.doAssignments(ref protocollForAdmin, ref ProtocolWindow, this.cListAssistentElem.IDSelEntry, this.isOn);
                    }

                    this.Cursor = Cursors.WaitCursor;

                    if (!string.IsNullOrWhiteSpace(protocollForAdmin))
                    {
                        qs2.design.auto.multiControl.ownMCInfo.openProtocoll(ref protocollForAdmin);
                    }
                }
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

        public bool isOn
        {
            get
            {
                return this.cListAssistentElem._isOn;
            }
            set
            {
                this.cListAssistentElem._isOn = value;
                this.setPicture();
            }
        }

        public void setPicture()
        {
            try
            {
                if (this.cListAssistentElem._isOn)
                {
                    if (this.cListAssistentElem.picEnabled != null)
                    {
                        this.btnElement.Appearance.Image = this.cListAssistentElem.picEnabled;
                    }
                    else
                    {
                        this.btnElement.Appearance.Image = null;  
                    }
                }
                else
                {
                    if (this.cListAssistentElem.picDisabled != null)
                    {
                        this.btnElement.Appearance.Image = this.cListAssistentElem.picDisabled;
                    }
                    else
                    {
                        this.btnElement.Appearance.Image = null;
                    }
                }

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

        public void btnElementClick(object sender, EventArgs e, bool isOn, bool doChapters, bool reduceCounterForChapter,
                                            ref string protocollForAdmin, ref bool ProtocolWindow,
                                            ref System.Collections.Generic.List<string> lstElementsActive,
                                            ref qs2.design.auto.ownMCRelationship.eTypAssignments TypAssignmentToCheck, bool loadSelectProcGroups,
                                            bool callReposition)
        {
            this.ownClick2?.Invoke(this, e);
        }

        private void btnMultiSelect_Click_1(object sender, EventArgs e)
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

        public void resetDropDownProcGroupsMain(System.Guid IDElementClicked, ref string ColumnNameClicked)
        {
            if (!this.cListAssistentElem.ID.Equals(IDElementClicked))
            {
                this.contListElementDropDown1.resetDropDownProcGroupsMain(IDElementClicked, this.cListAssistentElem.IDSelEntry, ref ColumnNameClicked);  
            }
        }
 
        public void setButtonOK(bool bOk)
        {
            if (!bOk)
            {
                this.btnOK.Appearance.Image = null;
            }
            else
            {
                this.btnOK.Appearance.Image = getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32 );
            }
            Application.DoEvents();
        }

        public void valueChanged(int IDSelListCkicked, bool bOn, ref string ColumnNameClicked)
        {
            if (this.cListAssistentElem.assistent != null)
            {
                string protocollForAdmin = "";
                bool ProtocolWindow = false;

                this.cListAssistentElem.assistent.doAssignmentsDropDown(ref protocollForAdmin, ref ProtocolWindow, IDSelListCkicked, bOn);

                if (protocollForAdmin.Trim() != "")
                {
                    qs2.design.auto.multiControl.ownMCInfo.openProtocoll(ref protocollForAdmin);
                }
            }
        }

        public void contListAssistentElem_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception("contListAssistentElem.contListAssistentElem_VisibleChanged: " + "\r\n" + ex.ToString());
            }
        }

        private void criteriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.cListAssistentElem.rCriteria != null)
                {
                    this.cListAssistentElem.ownMCInfo1.showInfoCriterias(this, this.cListAssistentElem.rCriteria.FldShort.Trim(), this.cListAssistentElem.rCriteria.IDApplication.Trim(), qs2.core.license.doLicense.eApp.ALL.ToString(), false);
                }
                else
                {
                    qs2.core.generic.showMessageBox("No criteria exists for '" + this.cListAssistentElem.rSelEntries.FldShortColumn.Trim()  + "'!", MessageBoxButtons.OK, "");
                }

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

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                qs2.core.generic.showMessageBox("FldShort='" + this.cListAssistentElem.rSelEntries.FldShortColumn.Trim() + "'", MessageBoxButtons.OK, "");

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

        private void ressourcenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.cListAssistentElem.ownMCInfo1.showInfoRessourcen(this, this.cListAssistentElem.rSelEntries.FldShortColumn.Trim(), this.cListAssistentElem.IDApplication.Trim(), qs2.core.license.doLicense.eApp.ALL.ToString(), false);
            
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

        private void selListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.cListAssistentElem.ownMCInfo1.showInfoSelList(this, this.cListAssistentElem.rSelEntries.FldShortColumn.Trim(), this.cListAssistentElem.IDApplication.Trim(),
                                                                    qs2.core.license.doLicense.eApp.ALL.ToString(), false, null, false, true, false);

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

        private void infoFieldSQLServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.cListAssistentElem.ownMCInfo1.infoFieldDB(this, this.cListAssistentElem.rSelEntries.FldShortColumn.Trim(), this.cListAssistentElem.IDApplication.Trim(),
                                            qs2.core.license.doLicense.eApp.ALL.ToString(), false);

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

        private void assignRightsUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.dDoActionEvaluation != null)
                {
                    this.dDoActionEvaluation.Invoke("", this.cListAssistentElem.IDSelEntry, this.cListAssistentElem.IDApplication.Trim(), this.btnElement.Text);
                }

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

        private void contListAssistentElem_MouseEnter(object sender, EventArgs e)
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

        private void contListAssistentElem_MouseLeave(object sender, EventArgs e)
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

        public void CheckMouseHoverLeaveContr(object sender, EventArgs e, bool enter)
        {
            try
            {
                if (sender is UltraButton && cListAssistentElem.rSelEntries != null)
                {
                    string IDResTmp = cListAssistentElem.rSelEntries.FldShortColumn;
                    if (this.cListAssistentElem._TypList == core.Enums.eTypList.CHAPTERS)
                        IDResTmp = "Chapter_" + cListAssistentElem.rSelEntries.IDOwnStr;

                    mcEvent1.CheckMouseHoverLeaveContr(sender, e, enter, IDResTmp, cListAssistentElem.IDApplication, true);
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        private void btnElement_MouseEnterElement(object sender, Infragistics.Win.UIElementEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.CheckMouseHoverLeaveContr(sender, e, true);

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

        private void btnElement_MouseLeaveElement(object sender, Infragistics.Win.UIElementEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.CheckMouseHoverLeaveContr(sender, e, false);

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
