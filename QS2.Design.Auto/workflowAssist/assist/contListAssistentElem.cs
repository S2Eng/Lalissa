using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using qs2.core.vb;
using QS2.Resources;
using Infragistics.Win.Misc;
using static qs2.design.auto.multiControl.ownMCEvents;

namespace qs2.sitemap.workflowAssist
{


    public partial class contListAssistentElem : UserControl
    {
        public event EventHandler ownClick2;
        public event delDoActionEvaluation dDoActionEvaluation;
        public delegate void delDoActionEvaluation(string type, int IDSelListEntry, string Application, string QueryName);

        public bool isLoaded = false;
       
        public static qs2.core.vb.sqlAdmin sqlAdminWork = new qs2.core.vb.sqlAdmin();
        public static qs2.core.vb.dsAdmin dsAdminWork = new qs2.core.vb.dsAdmin();
        public static qs2.core.vb.dsObjects dsObjectsTemp = new qs2.core.vb.dsObjects();             
        
        public qs2.design.auto.workflowAssist.assist.cListAssistentElem cListAssistentElem = new design.auto.workflowAssist.assist.cListAssistentElem();
        private qs2.design.auto.multiControl.ownMCEvents mcEvent1 = new design.auto.multiControl.ownMCEvents();








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

            if (qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
            {
                this.ContextMenuStrip = this.contextMenuStrip1;
            }
            else
            {
                this.contextMenuStrip1 = null;
            }
            
            this.isLoaded = true;
        }

        private void contButtAssistentElem_Load(object sender, EventArgs e)
        {
            qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktivElement(this, core.ui.eButtonType.Main);
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
                    if (this.cListAssistentElem.ListMain.autoUI != null)
                    {
                        isInEditMode = false;
                    }
                    else
                    {
                        throw new Exception("this.autoUI = null");
                    }

                    if ((isInEditMode && this.cListAssistentElem._TypList == core.Enums.eTypList.PROCGRP))
                    {
                        if (this.cListAssistentElem.ListMain.autoUI.rStayRead.StayComplete)
                        {
                            if (!qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightSetCompleted, false))
                            {
                                isInEditMode = false;
                            }
                        }
                    }

                    if ((isInEditMode && this.cListAssistentElem._TypList == core.Enums.eTypList.PROCGRP) ||
                            this.cListAssistentElem._TypList == core.Enums.eTypList.CHAPTERS)
                    {
                        bOK = true;  
                    }
                }
                if (bOK)
                {
                    //if (!qs2.sitemap.workflowAssist.form.contAutoUI.LoadingStayData)
                    //{
                        string protocollForAdmin = "";
                        bool ProtocolWindow = false;
                        System.Collections.Generic.List<string> lstElementsActive = new System.Collections.Generic.List<string>();
                        qs2.design.auto.ownMCRelationship.eTypAssignments TypAssignmentToCheck = design.auto.ownMCRelationship.eTypAssignments.none;
                    
                        if (this.cListAssistentElem._TypList == core.Enums.eTypList.PROCGRP)
                        {
                            if (this.cListAssistentElem.isEditable)
                            {
                                this.Cursor = Cursors.WaitCursor;
                                this.btnElementClick(sender, e, !this.isOn, true, true, ref protocollForAdmin, ref ProtocolWindow, ref lstElementsActive, 
                                                    ref TypAssignmentToCheck, true, true);
                       
                                if (this.cListAssistentElem.assistent != null)
                                {
                                    this.cListAssistentElem.assistent.doAssignments(ref protocollForAdmin, ref ProtocolWindow, this.cListAssistentElem.IDSelEntry, this.isOn);
                                }

                                this.cListAssistentElem.ListMain.SetInfoAnyProcGroupIsOn();
                            }
                        }
                        else
                        {
                            this.btnElementClick(sender, e, !this.isOn, true, true, ref protocollForAdmin, ref ProtocolWindow, ref lstElementsActive, 
                                                ref TypAssignmentToCheck, true, true);
                            if (this.cListAssistentElem.assistent != null)
                            {
                                this.cListAssistentElem.assistent.doAssignments(ref protocollForAdmin, ref ProtocolWindow, this.cListAssistentElem.IDSelEntry, this.isOn);
                            }
                        }
                    
                        this.Cursor = Cursors.WaitCursor;
                        this.doRelationsship(true);
                    
                        if (protocollForAdmin.Trim() != "")
                        {
                            qs2.design.auto.multiControl.ownMCInfo.openProtocoll(ref protocollForAdmin);
                        }
                    //}
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
                    if (this.cListAssistentElem.ListMain.autoUI != null)
                    {
                        isInEditMode = false;
                    }
                    else
                    {
                        throw new Exception("this.autoUI = null");
                    }

                    if ((isInEditMode && this.cListAssistentElem._TypList == core.Enums.eTypList.PROCGRP))
                    {
                        if (this.cListAssistentElem.ListMain.autoUI.rStayRead.StayComplete)
                        {
                            if (!qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightSetCompleted, false))
                            {
                                isInEditMode = false;
                            }
                        }
                    }

                    if ((isInEditMode && this.cListAssistentElem._TypList == core.Enums.eTypList.PROCGRP) ||
                            this.cListAssistentElem._TypList == core.Enums.eTypList.CHAPTERS)
                    {
                        bOK = true;
                    }
                }
                if (bOK)
                {
                    //if (!qs2.sitemap.workflowAssist.form.contAutoUI.LoadingStayData)
                    //{
                    string protocollForAdmin = "";
                    bool ProtocolWindow = false;
                    System.Collections.Generic.List<string> lstElementsActive = new System.Collections.Generic.List<string>();
                    qs2.design.auto.ownMCRelationship.eTypAssignments TypAssignmentToCheck = design.auto.ownMCRelationship.eTypAssignments.none;

                    if (this.cListAssistentElem._TypList == core.Enums.eTypList.PROCGRP)
                    {
                        if (this.cListAssistentElem.isEditable)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            this.btnElementClick(sender, e, !this.isOn, true, true, ref protocollForAdmin, ref ProtocolWindow, ref lstElementsActive, 
                                                ref TypAssignmentToCheck, true, true);

                            if (this.cListAssistentElem.assistent != null)
                            {
                                this.cListAssistentElem.assistent.doAssignments(ref protocollForAdmin, ref ProtocolWindow, this.cListAssistentElem.IDSelEntry, this.isOn);
                            }
                        }
                    }
                    else
                    {
                        this.btnElementClick(sender, e, !this.isOn, true, true, ref protocollForAdmin, ref ProtocolWindow, ref lstElementsActive, 
                                            ref TypAssignmentToCheck, true, true);
                        if (this.cListAssistentElem.assistent != null)
                        {
                            this.cListAssistentElem.assistent.doAssignments(ref protocollForAdmin, ref ProtocolWindow, this.cListAssistentElem.IDSelEntry, this.isOn);
                        }
                    }

                    this.Cursor = Cursors.WaitCursor;
                    this.doRelationsship(true);

                    if (protocollForAdmin.Trim() != "")
                    {
                        qs2.design.auto.multiControl.ownMCInfo.openProtocoll(ref protocollForAdmin);
                    }
                    //}
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


        public void doRelationsship(bool ButtonClickedByUser)
        {
            try
            {
                if (this.cListAssistentElem.rCriteria != null)
                {
                    design.auto.ownMCRelationship.eTypAssignments TypActionRelation = design.auto.ownMCRelationship.eTypAssignments.MCParent;
                    core.generic.retValue retValue1 = new core.generic.retValue();
                    retValue1.valueObj = this.cListAssistentElem._isOn;
                    retValue1.valueStr = (this.cListAssistentElem._isOn == true ? "1" : "0");
                    retValue1.valueSql = retValue1.valueStr;
                    int SubRelation = 0;
                    //bool isInEditMode = false;
                    if (this.cListAssistentElem.ListMain.autoUI != null)
                    {
                        bool ProcGroupDeactivated = false;
                        this.cListAssistentElem.ownMCRelationship.doRelationship(this.cListAssistentElem.rCriteria.FldShort.Trim(), "", ref retValue1, false, SubRelation, this.cListAssistentElem.rCriteria.IDApplication,
                                    qs2.core.license.doLicense.eApp.ALL.ToString(),
                                    ref this.cListAssistentElem.ListMain.autoUI.dataStay, ref this.cListAssistentElem.ListMain.autoUI, 
                                    ref TypActionRelation, ProcGroupDeactivated);
                    }
                    else
                    {
                        throw new Exception("this.autoUI = null");
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("contListAssistentElem.doRelationsship:" + ex.ToString());
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
        public void setPicture2()
        {
            try
            {
                if (this.cListAssistentElem._isOn)
                {
                    if (this.cListAssistentElem.assistent.ImgListEnabled.Images.Count > 0)
                    {
                        this.btnElement.ImageList = this.cListAssistentElem.assistent.ImgListEnabled;
                        this.btnElement.Appearance.Image = this.cListAssistentElem.assistent.ImgListEnabled.Images[0];
                    }
                }
                else
                {
                    if (this.cListAssistentElem.assistent.ImgListDisabled.Images.Count > 0)
                    {
                        this.btnElement.ImageList = this.cListAssistentElem.assistent.ImgListDisabled;
                        this.btnElement.Appearance.Image = this.cListAssistentElem.assistent.ImgListDisabled.Images[0];
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
        public void SetUIxyxy(bool IsEvaluation)
        {
            try
            {
                this.btnElement.Dock = DockStyle.None;
                this.panelBottom.Dock = DockStyle.None;
                this.contListElementDropDown1.Dock = DockStyle.None;
                this.btnOK.Dock = DockStyle.None;
                this.panelElement.Dock = DockStyle.None;

                bool PanelBottomVisible = false;
                if (this.cListAssistentElem._TypList == core.Enums.eTypList.CHAPTERS)
                {
                    PanelBottomVisible = false;
                }
                else
                {
                    if (this.cListAssistentElem.IDApplication.ToString().Trim().Equals(qs2.core.license.doLicense.eApp.VASCULAR.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        PanelBottomVisible = true;
                    }
                    else
                    {
                        PanelBottomVisible = false;
                    }
                }
                if (IsEvaluation)
                {
                    PanelBottomVisible = false;
                }

                this.btnElement.Top = 0;
                this.btnOK.Top = 0;
                this.contListElementDropDown1.Top = 0;
                this.panelBottom.Left = 0;

                if (this.cListAssistentElem._TypList == core.Enums.eTypList.PROCGRP)
                {
                    this.panelElement.Top = 0;
                    this.panelElement.Left = 0;

                    if (PanelBottomVisible)
                    {
                        int heigthButtonBottom = 16;

                        this.panelBottom.Visible = true;
                        this.panelBottom.Height = heigthButtonBottom;
                        this.panelBottom.Top = this.Height - heigthButtonBottom;
                        this.panelBottom.Width = this.Width;

                        this.panelElement.Width = this.Width;
                        this.panelElement.Height = this.Height - heigthButtonBottom;

                        this.contListElementDropDown1.Width = 45;
                        this.contListElementDropDown1.Left = this.panelBottom.Width - 45;
                        this.contListElementDropDown1.Height = this.panelBottom.Height;

                    }
                    else
                    {
                        this.panelBottom.Visible = false;
                        this.panelBottom.Height = 0;
                        this.panelElement.Width = this.Width;
                        this.panelElement.Height = this.Height;

                        this.contListElementDropDown1.Width = 0;
                        this.contListElementDropDown1.Height = 0;
                        this.contListElementDropDown1.Visible = false;
                    }

                    this.btnElement.Left = 0;
                    this.btnElement.Width = this.panelElement.Width;
                    this.btnElement.Height = this.panelElement.Height;

                    this.btnOK.Visible = false;
                    this.btnOK.Width = 0;
                    this.btnOK.Height = 0;

                }
                else if (this.cListAssistentElem._TypList == core.Enums.eTypList.CHAPTERS)
                {
                    this.panelElement.Top = 0;
                    this.panelElement.Left = 0;
                    this.panelElement.Width = this.Width;
                    this.panelElement.Height = this.Height;

                    this.panelBottom.Height = 0;
                    this.panelBottom.Visible = false;

                    if (this.cListAssistentElem.ListMain.ButtonOKVisible)
                    {
                        this.btnOK.Visible = true;
                        this.btnOK.Width = 25;
                        this.btnOK.Height = this.panelElement.Height;

                        this.btnElement.Left = this.btnOK.Width;
                        this.btnElement.Width = this.panelElement.Width - this.btnOK.Width;
                        this.btnElement.Height = this.panelElement.Height;
                    }
                    else
                    {
                        this.btnOK.Visible = false;
                        this.btnOK.Width = 0;
                        this.btnOK.Height = 0;

                        this.btnElement.Left = 0;
                        this.btnElement.Width = this.panelElement.Width;
                        this.btnElement.Height = this.panelElement.Height;
                    }

                    this.contListElementDropDown1.Width = 0;
                    this.contListElementDropDown1.Height = 0;
                    this.contListElementDropDown1.Visible = false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("setButtonOK: " + ex.ToString());
            }
        }

        public void doLayout(bool bOn)
        {
            try
            {
                if (!bOn)
                {
                    this.SuspendLayout();
                    this.btnElement.SuspendLayout();
                    this.panelBottom.SuspendLayout();
                    this.contListElementDropDown1.SuspendLayout();
                    this.btnOK.SuspendLayout();
                    this.panelElement.SuspendLayout();
                }
                else
                {
                    this.PerformLayout();
                    this.btnElement.PerformLayout();
                    this.panelBottom.PerformLayout();
                    this.contListElementDropDown1.PerformLayout();
                    this.btnOK.PerformLayout();
                    this.panelElement.PerformLayout();
                    
                }

            }
            catch (Exception ex)
            {
                throw new Exception("setButtonOK: " + ex.ToString());
            }
        }     

        public void btnElementClick(object sender, EventArgs e, bool isOn, bool doChapters, bool reduceCounterForChapter,
                                            ref string protocollForAdmin, ref bool ProtocolWindow,
                                            ref System.Collections.Generic.List<string> lstElementsActive,
                                            ref qs2.design.auto.ownMCRelationship.eTypAssignments TypAssignmentToCheck, bool loadSelectProcGroups,
                                            bool callReposition)
        {
            if (this.cListAssistentElem.assistent != null)
            {
                if (this.cListAssistentElem.ListMain.autoUI != null)
                {
                    this.cListAssistentElem.assistent.elementClick2(this, isOn, doChapters, reduceCounterForChapter, ref protocollForAdmin, ref ProtocolWindow,
                                                                ref lstElementsActive, ref TypAssignmentToCheck, true, this.cListAssistentElem.ListMain.autoUI._runAsSystemuser,
                                                                this.cListAssistentElem.ListMain.autoUI._runAsUser, true, loadSelectProcGroups, callReposition);
                }
                else
                {
                    throw new Exception("this.autoUI = null");
                }
            }

            if (this.ownClick2 != null)
                this.ownClick2(this, e);
        }

        private void btnMultiSelect_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!qs2.sitemap.workflowAssist.form.contAutoUI.LoadingStayData)
                {
                    if (this.cListAssistentElem.isEditable)
                    {
                        if (this.cListAssistentElem.ListMain.autoUI.rStayRead.StayComplete)
                        {
                            if (qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightSetCompleted, false))
                            {
                                this.setButtonOK(!this.cListAssistentElem.isOKOn);
                            }
                        }
                        else
                        {
                            this.setButtonOK(!this.cListAssistentElem.isOKOn);
                        }
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

        public void lockUnlock(bool bEdit)
        {
            this.cListAssistentElem.isEditable = bEdit;
            this.contListElementDropDown1.lockUnlock(bEdit);
        }
        
        public void loadDropDownProcGroups(qs2.core.vb.dsObjects.tblStayRow rStay, string Application)
        {
            int counterProceduresFoundForChapter = 0;
            this.contListElementDropDown1.loadDropDownProcGroups(rStay, this.cListAssistentElem.IDSelEntry, Application, ref counterProceduresFoundForChapter);
            if (counterProceduresFoundForChapter > 0)
            {
                this.contListElementDropDown1.Visible = true;
            }
            else
            {
                this.contListElementDropDown1.Visible = false;
            }
        }
        public void saveDropDownProcGroups(qs2.core.vb.dsObjects.tblStayRow rStay, string Application)
        {
            this.contListElementDropDown1.saveDropDownProcGroups(rStay, this.cListAssistentElem.IDSelEntry, Application); 
        }
        public void resetDropDownProcGroupsMain(System.Guid IDElementClicked, ref string ColumnNameClicked)
        {
            if (!this.cListAssistentElem.ID.Equals(IDElementClicked))
            {
                this.contListElementDropDown1.resetDropDownProcGroupsMain(IDElementClicked, this.cListAssistentElem.IDSelEntry, ref ColumnNameClicked);  
            }
        }
 
        public void doAllAssignmentsDropDown(qs2.core.vb.dsObjects.tblStayRow rStay, string Application,
                                            ref string protocollForAdmin, ref bool ProtocolWindow)
        {
            this.contListElementDropDown1.loadRelationsDropDown(rStay, Application, ref protocollForAdmin, ref ProtocolWindow);
        }

        public void loadSelectedProcGroup(qs2.core.vb.dsObjects.tblStayRow rStay, ref string protocollForAdmin, ref bool ProtocolWindow,
                                            ref System.Collections.Generic.List<string> lstElementsActive,
                                            ref qs2.design.auto.ownMCRelationship.eTypAssignments TypAssignmentToCheck, 
                                            bool AddSchemaAuto, bool callReposition)
        {
            if (this.cListAssistentElem.sqlColumn.ToString().Equals("IsFUP", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
              
            System.Collections.Generic.List<qs2.core.generic.retValue> columnsSelect = new System.Collections.Generic.List<qs2.core.generic.retValue>();
            qs2.core.generic.retValue Column = new qs2.core.generic.retValue();
            Column.fieldInfo = this.cListAssistentElem.sqlColumn;
            columnsSelect.Add(Column);

            System.Collections.Generic.List<qs2.core.generic.retValue> columnsWhere = new System.Collections.Generic.List<qs2.core.generic.retValue>();
            Column = new qs2.core.generic.retValue();
            Column.fieldInfo = dsObjectsTemp.tblStay.IDColumn.ColumnName;
            Column.valueStr = rStay.ID.ToString();
            columnsWhere.Add(Column);

            Column = new qs2.core.generic.retValue();
            Column.fieldInfo = dsObjectsTemp.tblStay.IDParticipantColumn.ColumnName;
            Column.valueStr = "'" + rStay.IDParticipant.ToString() + "'";
            columnsWhere.Add(Column);
            try
            {
                //lthxyxy
                System.Data.DataTable dt = qs2.core.dbBase.buildSelectCommand(this.cListAssistentElem.sqlTable, columnsSelect, columnsWhere, AddSchemaAuto);
                if (dt.Rows.Count == 1)
                {
                    if (System.Convert.ToInt32(dt.Rows[0][this.cListAssistentElem.sqlColumn]) == 1)
                    {
                        object sender = (object)this;
                        EventArgs evArg = new EventArgs();
                        this.btnElementClick(sender, evArg, true, true, false, ref protocollForAdmin, ref ProtocolWindow, ref lstElementsActive, 
                                                ref TypAssignmentToCheck, false, callReposition);
                    }
                    else if (System.Convert.ToInt32(dt.Rows[0][this.cListAssistentElem.sqlColumn]) == 0)
                    {
                        object sender = (object)this;
                        EventArgs evArg = new EventArgs();
                        this.btnElementClick(sender, evArg, false, true, false, ref protocollForAdmin, ref ProtocolWindow, ref lstElementsActive, 
                                                ref TypAssignmentToCheck, false, callReposition);
                    }
                    else
                    {
                        //throw new Exception("contListAssistentElem.loadSelectedProcGroup: Error Select for Field '" + this.sqlColumn + "', MedRecNr='" + rStay.MedRecN + "'!");
                        //lthxy
                    }
                }
                else
                {
                    throw new Exception("contListAssistentElem.loadSelectedProcGroup: Error Select for Field '" + this.cListAssistentElem.sqlColumn + "', MedRecNr='" + rStay.MedRecN + "'!");
                }

            }
            catch (Exception ex2)
            {
                string err = "contListAssistentElem.loadSelectedProcGroup: Error Build Select-Command for ProcGrp0/1 for Sql-Column '" + this.cListAssistentElem.sqlColumn + "' in Table '" + this.cListAssistentElem.sqlTable + "', MedRecNr='" + rStay.MedRecN + "'!" + "\r\n" + ex2.ToString();
                throw new Exception(err);
                //qs2.sitemap.workflowAssist.form.contAutoUI.LoadingStayData = false;
                //qs2.core.Protocol.doExcept(ex.ToString(), "contListAssistentElem.loadSelectedProcGroup", "", false, true, this.OwnLicense.OwnApplication.ToString(),
                //                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                //qs2.design.auto.multiControl.ownMCInfo.checkForProtocol(false);
            }
        }
        public void setButtonOK(bool bOk)
        {
            if (!bOk)
            {
                this.btnOK.Appearance.Image = null;
                this.cListAssistentElem.isOKOn = false;
            }
            else
            {
                this.btnOK.Appearance.Image = getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32 );
                this.cListAssistentElem.isOKOn = true;
            }
            Application.DoEvents();
        }
        public void loadIsOk(qs2.core.vb.dsObjects.tblStayRow rStay)
        {
            contListAssistentElem.sqlAdminWork = new sqlAdmin();
            contListAssistentElem.sqlAdminWork.initControl();
            contListAssistentElem.dsAdminWork.Clear();
            contListAssistentElem.sqlAdminWork.getSelListEntrysObj(-999, qs2.core.vb.sqlAdmin.eDbTypAuswObj.SubSelList,
                                                 qs2.core.vb.sqlAdmin.typIDGroup_CompletedChapters,
                                                contListAssistentElem.dsAdminWork, qs2.core.vb.sqlAdmin.eTypAuswahlObj.IDSelListEntryIDStayTypIDGroup,
                                                 rStay.IDApplication, cListAssistentElem.IDSelEntry,  "", rStay.ID, rStay.IDParticipant);

            if (contListAssistentElem.dsAdminWork.tblSelListEntriesObj.Rows.Count > 1)
            {
                throw new Exception("contListAssistentElem.loadIsOk: this.dsAdminWork.tblSelListEntriesObj.Rows.Count > 1 for MedRecNr '" + rStay.MedRecN.ToString() + "'!");
            }
            else if (contListAssistentElem.dsAdminWork.tblSelListEntriesObj.Rows.Count == 1)
            {
                this.cListAssistentElem.isOKOn = true;
                this.setButtonOK(true);
            }
            if (contListAssistentElem.dsAdminWork.tblSelListEntriesObj.Rows.Count == 0)
            {
                this.cListAssistentElem.isOKOn = false;
                this.setButtonOK(false);
            }
        }

        public void saveIsOk(qs2.core.vb.dsObjects.tblStayRow rStay)
        {
            //this.dsAdminWork.Clear();
            //this.sqlAdminWork.getSelListEntrysObj(-99, sqlAdmin.eDbTypAuswObj.SubSelList, qs2.core.vb.sqlAdmin.typIDGroup_CompletedChapters.ToString(), this.dsAdminWork, sqlAdmin.eTypAuswahlObj.IDSelListEntryIDStayTypIDGroup, rStay.IDApplication.Trim(),
            //                                    this.IDSelEntry, "", rStay.ID, rStay.IDParticipant.Trim(), -999, "", "");
            //if (this.dsAdminWork.tblSelListEntriesObj.Rows.Count > 0)
            //{
            //    if (!this.isOKOn)
            //    {
            //        this.sqlAdminWork.deleteSelListEntryObj(rStay.ID, rStay.IDParticipant, rStay.IDApplication, qs2.core.vb.sqlAdmin.typIDGroup_CompletedChapters, this.IDSelEntry);
            //    }
            //}
            //else
            //{
            //    if (this.isOKOn)
            //    {
            //        this.dsAdminWork.Clear();
            //        qs2.core.vb.dsAdmin.tblSelListEntriesObjRow rNewObj = (qs2.core.vb.dsAdmin.tblSelListEntriesObjRow)this.sqlAdminWork.getNewRowSelListObj(this.dsAdminWork);
            //        rNewObj.IDSelListEntry = this.IDSelEntry;
            //        rNewObj.IDStay = rStay.ID;
            //        rNewObj.IDParticipantStay = rStay.IDParticipant;
            //        rNewObj.IDApplicationStay = rStay.IDApplication;
            //        rNewObj.typIDGroup = qs2.core.vb.sqlAdmin.typIDGroup_CompletedChapters;

            //        this.sqlAdminWork.daSelListEntrysObj.Update(this.dsAdminWork.tblSelListEntriesObj);
            //    }
            //}

            contListAssistentElem.dsAdminWork.Clear();
            contListAssistentElem.sqlAdminWork = new sqlAdmin();
            contListAssistentElem.sqlAdminWork.initControl();
            contListAssistentElem.sqlAdminWork.deleteSelListEntryObj(rStay.ID, rStay.IDParticipant, rStay.IDApplication, qs2.core.vb.sqlAdmin.typIDGroup_CompletedChapters, this.cListAssistentElem.IDSelEntry);
            if (this.cListAssistentElem.isOKOn)
            {
                contListAssistentElem.sqlAdminWork.getSelListEntrysObj(-999, sqlAdmin.eDbTypAuswObj.SubSelList, System.Guid.NewGuid().ToString(), contListAssistentElem.dsAdminWork, sqlAdmin.eTypAuswahlObj.IDSelListEntry, "");

                qs2.core.vb.dsAdmin.tblSelListEntriesObjRow rNewObj = (qs2.core.vb.dsAdmin.tblSelListEntriesObjRow)contListAssistentElem.sqlAdminWork.getNewRowSelListObj(contListAssistentElem.dsAdminWork);
                rNewObj.IDSelListEntry = this.cListAssistentElem.IDSelEntry;
                rNewObj.IDStay = rStay.ID;
                rNewObj.IDParticipantStay = rStay.IDParticipant;
                rNewObj.IDApplicationStay = rStay.IDApplication;
                rNewObj.typIDGroup = qs2.core.vb.sqlAdmin.typIDGroup_CompletedChapters;

                contListAssistentElem.sqlAdminWork.daSelListEntrysObj.Update(contListAssistentElem.dsAdminWork.tblSelListEntriesObj);
            }

        }

        public void valueChanged(int IDSelListCkicked, bool bOn, ref string ColumnNameClicked)
        {
            if (this.cListAssistentElem.assistent != null)
            {
                string protocollForAdmin = "";
                bool ProtocolWindow = false;

                this.cListAssistentElem.assistent.resetDropDownProcGroupsMain(this.cListAssistentElem.ID, ref ColumnNameClicked);
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
                //if (this.IsVisibleForStayType)
                //{
                //    //this.doVisible();
                //}

             
            }
            catch (Exception ex)
            {
                throw new Exception("contListAssistentElem.contListAssistentElem_VisibleChanged: " + "\r\n" + ex.ToString());
            }
        }

        public void doVisiblexyxyxy()
        {
            try
            {
                //this.Visible = this.IsVisibleForStayType;

            }
            catch (Exception ex)
            {
                throw new Exception("contListAssistentElem.doVisible: " + "\r\n" + ex.ToString());
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

                    //if (enter)
                    //{
                    //    var rRes = (from r in qs2.core.language.sqlLanguage.dsLanguageAll.Ressourcen
                    //                where r.IDRes == IDResTmp && r.IDApplication == cListAssistentElem.IDApplication && r.Type == "Help" && r.IDLanguageUser == "ALL" && r.IDParticipant == "ALL"
                    //                select new { r.IDRes, r.German, r.English }).FirstOrDefault();

                    //    var rLastSelected = (from l in qs2.design.auto.multiControl.ownMCEvents.lLastMCFocused
                    //                            where l.IDApplication == cListAssistentElem.IDApplication
                    //                            select new { l.FldHort, l.IDApplication }).FirstOrDefault();
                    //    if (rLastSelected == null)
                    //        qs2.design.auto.multiControl.ownMCEvents.lLastMCFocused.Add(new cHelpData() { FldHort = IDResTmp, IDApplication = cListAssistentElem.IDApplication, HasRes = (rRes != null ? true : false) });
                    //    else
                    //    {
                    //        qs2.design.auto.multiControl.ownMCEvents.lLastMCFocused.First().FldHort = IDResTmp;
                    //        qs2.design.auto.multiControl.ownMCEvents.lLastMCFocused.First().HasRes = (rRes != null ? true : false);
                    //    } 
                    //}
                    //else
                    //{
                    //    var rLastSelected = (from l in qs2.design.auto.multiControl.ownMCEvents.lLastMCFocused
                    //                            where l.IDApplication == cListAssistentElem.IDApplication
                    //                            select new { l.FldHort, l.IDApplication }).FirstOrDefault();
                    //    if (rLastSelected != null)
                    //        qs2.design.auto.multiControl.ownMCEvents.lLastMCFocused.Clear();
                    //}
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
