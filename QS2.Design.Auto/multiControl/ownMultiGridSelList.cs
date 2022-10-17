using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

using qs2.core.vb;
using QS2.Resources;




namespace qs2.design.auto.multiControl
{

    public partial class ownMultiGridSelList : UserControl
    {
        public string[] _FldShort;
        public string _FldShortTitle = "";
        public int _HeigthAddPanel = 100;
        public bool isLoaded = false;
        public bool isInitialized = false;
        public bool _editable = false;
        
        //public int _tabIndex = 0;
        public int _OwnOrderLineNr = 1;
        public int _OwnOrderControlNr = 1;
        public int _OwnOrder = 1;

        public System.Guid key = System.Guid.NewGuid();

        public qs2.design.auto.ownMCCriteria ownMCCriteria1 = new qs2.design.auto.ownMCCriteria();
        public ownMCInfo ownControlInfo1 = new ownMCInfo();
        public ownMCUI ownControlUI1 = new ownMCUI();  

        public qs2.core.ui ui1 = new qs2.core.ui ();

        public qs2.core.vb.dsAdmin dsAdminWorker = new qs2.core.vb.dsAdmin();
        public qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListEntriesMainCbo;
        
        public qs2.core.vb.sqlAdmin.eTypStayAdditions _typMultiControl;

        public bool _OwnFieldForALLProducts = false;

        public System.Guid ID = System.Guid.Empty;
        public System.Guid IDGroup = System.Guid.Empty;

        public bool IsVisibleControl = false;
        public bool IsVisibleControlAssignmentChapters = false;

        public bool IsQueryControl = false;
        public qs2.core.vb.dsAdmin.tblQueriesDefRow rQry;
        public qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListQry;
        public System.Guid IDGroupReport = System.Guid.Empty;
        public bool IsInUseInparameterList = false;
        public bool isSubQuery = false;
        public qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListSelectedRole;

        public qs2.core.vb.dsObjects dsObjectsTmp = new dsObjects();
        public qs2.core.vb.sqlObjects sqlObjectsTmp = new sqlObjects();
                            
        public bool lockVisible = false;
        public dsAdmin dsAdminTmp = new dsAdmin();

        public delegate void eMCValueChanged();
        public ownMultiControl.eMCValueChanged MCValueChanged;








        public ownMultiGridSelList()
        {
            InitializeComponent();
        }
        

        private void ownMultiGridSelList_Load(object sender, EventArgs e)
        {

        }
        public void initControl()
        {
            try
            {
                if (this.DesignMode)
                {
                    return;
                }

                if (this.isInitialized) return;
                this.sqlAdmin1.initControl();
                this.sqlObjectsTmp.initControl();

                this.btnAdd.initControl();
                this.btnDel.initControl();
                this.btnCancel.initControl();

                this.dsAdminShow.tblSelListEntries.Clear();
                qs2.core.vb.sqlAdmin.ParametersSelListEntries Parameters = new qs2.core.vb.sqlAdmin.ParametersSelListEntries();

                this.sqlAdmin1.getSelListEntrys(ref Parameters, this._FldShort[0], this.ownMCCriteria1.IDParticipant, 
                                                this.ownMCCriteria1.Application,
                                                ref this.dsAdminShow, core.vb.sqlAdmin.eTypAuswahlList.group);
                
                if (this._typMultiControl == qs2.core.vb.sqlAdmin.eTypStayAdditions.multiSelLists)
                {
                    this.gridData.DisplayLayout.Bands[0].Hidden = false;

                    this.dropDownSelListAndGroup1.initControl(false, false, false, true, false, true);
                    this.dropDownSelListAndGroup1.IDParticipant = this.ownMCCriteria1.IDParticipant;
                    this.dropDownSelListAndGroup1.loadData(this._FldShort[0], this.ownMCCriteria1.Application, true);
                    this.gridData.DisplayLayout.Bands[0].Columns[this.dsAdminShow.tblSelListEntries.IDRessourceColumn.ColumnName].ValueList = this.dropDownSelListAndGroup1.ultraDropDownSelListsWithGroup;
                    this.gridData.DisplayLayout.Bands[0].Columns[this.dsAdminShow.tblSelListEntries.IDRessourceColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                    this.dsAdminShow.tblStayAdditions.Columns.Add(qs2.core.generic.columnNameText, typeof(string));
                    this.dsAdminShow.tblStayAdditions.Columns[qs2.core.generic.columnNameText].SetOrdinal(0);

                    this.panelBottom.Visible = true;
                }
                else if (this._typMultiControl == qs2.core.vb.sqlAdmin.eTypStayAdditions.assignStay)
                {
                    this.dsAdminShow.tblStayAdditions.Columns.Add(qs2.core.generic.columnNameText, typeof(string));
                    this.dsAdminShow.tblStayAdditions.Columns[qs2.core.generic.columnNameText].SetOrdinal(0);

                    this.gridData.DataSource = this.dsAdminShow;
                    this.gridData.DataMember = this.dsAdminShow.tblStayAdditions.TableName;
                    this.gridData.DataBind();

                    this.gridData.DisplayLayout.Bands[0].Hidden = false;

                    this.dropDownSelListAndGroup1.initControl(true, false, false, true, true, false);
                    this.dropDownSelListAndGroup1.IDParticipant = this.ownMCCriteria1.IDParticipant;
                    this.dropDownSelListAndGroup1.loadData(this._FldShort[0], this.ownMCCriteria1.Application, true);
                    this.gridData.DisplayLayout.Bands[0].Columns[this.dsAdminShow.tblStayAdditions.IDSelListColumn.ColumnName].ValueList = this.dropDownSelListAndGroup1.ultraDropDownSelListsWithGroup;
                    this.gridData.DisplayLayout.Bands[0].Columns[this.dsAdminShow.tblStayAdditions.IDSelListColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                    this.gridData.DisplayLayout.Bands[0].Columns[this.dsAdminShow.tblStayAdditions.IDStayChildColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                    this.panelBottom.Visible = false;
                }

                this.loadRes();

                if (this._typMultiControl == qs2.core.vb.sqlAdmin.eTypStayAdditions.multiSelLists)
                {
                    this.gridData.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
                }
                else if (this._typMultiControl == qs2.core.vb.sqlAdmin.eTypStayAdditions.assignStay)
                {
                    //this.gridData.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
                    //this.dropDownSelListAndGroup1.setWidthDropDown(this.gridData.DisplayLayout.Bands[0].Columns[this.dsAdminShow.tblStayAdditions.IDSelListColumn.ColumnName].Width);
                  
                    //this.gridData.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
                    //this.gridData.Refresh();

                }

 


                this.isInitialized = true;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiGridSelList.initControl", "", false, true,
                                                                    this.ownMCCriteria1.Application,
                                                                    qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void setGridUI(bool CollapseAll)
        {
            try
            {
                foreach (UltraGridRow row in this.gridData.Rows)
                {
                    if (row.HasChild())
                    {
                        if (CollapseAll)
                            row.CollapseAll();
                        row.ExpansionIndicator = ShowExpansionIndicator.CheckOnExpand;
                    }
                    else
                    {
                        //row.ExpandAll();
                        row.ExpansionIndicator = ShowExpansionIndicator.Never;
                    }
                    //row.Hidden = false;
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiGridSelList.setGridUI", "", false, true,
                                                                this.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void loadRes()
        {
            try
            {
                if (this._typMultiControl == qs2.core.vb.sqlAdmin.eTypStayAdditions.multiSelLists)
                {
                    foreach(UltraGridColumn col in this.gridData.DisplayLayout.Bands[0].Columns)
                    {
                        col.Hidden = true;
                    }
                    foreach (UltraGridColumn col in this.gridData.DisplayLayout.Bands[1].Columns)
                    {
                        col.Hidden = true;
                    }

                    this.gridData.DisplayLayout.Bands[0].Columns[this.dsAdminShow.tblSelListEntries.IDRessourceColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Description");
                    //this.gridData.DisplayLayout.Bands[1].Columns[this.dsAdminShow.tblStayAdditions.IDRessourceColumn.ColumnName].Width = this.gridData.Width - 120;
                    this.gridData.DisplayLayout.Bands[1].Columns[this.dsAdminShow.tblStayAdditions.SortColumn.ColumnName].Width = 40;

                    this.gridData.DisplayLayout.Bands[1].Columns[qs2.core.generic.columnNameText].Hidden = false;

                    this.gridData.DisplayLayout.Bands[0].Columns[this.dsAdminShow.tblSelListEntries.IDRessourceColumn.ColumnName].Hidden = false;
                    this.gridData.DisplayLayout.Bands[1].Columns[this.dsAdminShow.tblStayAdditions.SortColumn.ColumnName].Hidden = false;
                    this.gridData.DisplayLayout.Bands[1].Columns[this.dsAdminShow.tblStayAdditions.SortColumn.ColumnName].Hidden = false;
                    //this.gridData.DisplayLayout.Bands[1].Columns[this.dsAdminShow.tblStayAdditions.IDRessourceColumn.ColumnName].Hidden = false;

                    this.gridData.DisplayLayout.Bands[0].ColHeadersVisible = false;
                    this.gridData.DisplayLayout.Bands[1].ColHeadersVisible = false;

                    this.gridData.DisplayLayout.Bands[1].Hidden = false;

                }
                else if (this._typMultiControl == qs2.core.vb.sqlAdmin.eTypStayAdditions.assignStay)
                {
                    foreach (UltraGridColumn col in this.gridData.DisplayLayout.Bands[0].Columns)
                    {
                        col.Hidden = true;
                    }

                    //this.gridData.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNameText].Width = 160;
                    this.gridData.DisplayLayout.Bands[0].Columns[this.dsAdminShow.tblStayAdditions.IDSelListColumn.ColumnName].Hidden = false;

                    this.gridData.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNameText].Hidden = true;
                    this.gridData.DisplayLayout.Bands[0].Columns[this.dsAdminShow.tblStayAdditions.IDStayChildColumn .ColumnName].Hidden = false;

                    this.gridData.DisplayLayout.Bands[0].Columns[this.dsAdminShow.tblStayAdditions.IDStayChildColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Stays");
                    this.gridData.DisplayLayout.Bands[0].Columns[this.dsAdminShow.tblStayAdditions.IDSelListColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Selection");

                    this.gridData.DisplayLayout.Bands[0].Columns[this.dsAdminShow.tblStayAdditions.IDSelListColumn.ColumnName].Header.VisiblePosition = 0;
                    this.gridData.DisplayLayout.Bands[0].Columns[this.dsAdminShow.tblStayAdditions.IDStayChildColumn.ColumnName].Header.VisiblePosition = 1;

                    this.gridData.DisplayLayout.Bands[0].Columns[this.dsAdminShow.tblStayAdditions.IDSelListColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Default;

                    this.gridData.DisplayLayout.Bands[0].Columns[this.dsAdminShow.tblStayAdditions.IDSelListColumn.ColumnName].Width = 100;     //this.gridData.Width / 2) - 50;

                    this.gridData.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
                }

                this.btnCancel.Text = qs2.core.language.sqlLanguage.getRes("Cancel");
                this.btnUp.Appearance.Image = getRes.getImage(QS2.Resources.getRes.ePicture.ico_up, 32, 32);
                this.btnDown.Appearance.Image = getRes.getImage(QS2.Resources.getRes.ePicture.ico_down, 32, 32);

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiGridSelList.loadRes", "", false, true,
                                                                this.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void doControl()
        {
            try
            {
                this.panelAdd.Height = this._HeigthAddPanel;
                this.doText();
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiGridSelList.doControl", "", false, true,
                                                                this.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void translateRowStayAddition()
        {
            string sExceptionMarker = "";
            string sExceptionMarkerID = "";
            try
            {
                sExceptionMarker += "1.";
                this.dsAdminTmp.Clear();
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rowGrid in this.gridData.Rows)
                {
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rowGridChild in rowGrid.ChildBands[0].Rows)
                    {
                        DataRowView v = (DataRowView)rowGridChild.ListObject;
                        qs2.core.vb.dsAdmin.tblStayAdditionsRow rStayAdd = (qs2.core.vb.dsAdmin.tblStayAdditionsRow)v.Row;
                        sExceptionMarker += "2.";
                        sExceptionMarkerID = "";

                        //get Row Group
                        this.dsAdminShow.tblSelListGroup.Clear();
                        //this.sqlAdmin1.getSelListGroup(ref this.dsAdminShow, core.vb.sqlAdmin.eTypSelGruppen.IDGruppeStr, this._FldShort[0],
                        //                               this.ownMCCriteria1.IDParticipant, this.ownMCCriteria1.Application);  // OMC.IDApplication.Check
                        //qs2.core.vb.dsAdmin.tblSelListGroupRow rSelSelListEntryGroup = (qs2.core.vb.dsAdmin.tblSelListGroupRow)this.dsAdminShow.tblSelListGroup.Rows[0];

                        //qs2.core.vb.dsAdmin.tblSelListGroupRow rSelSelListEntryGroup = null;
                        //qs2.core.vb.dsAdmin.tblSelListGroupRow[] arrGrp = null;
                        //arrGrp = this.sqlAdmin1.getSelListGroup(ref qs2.design.auto.ownMCCriteria.dsAdminWork, qs2.core.vb.sqlAdmin.eTypSelGruppen.IDGruppeRam, this._FldShort[0],
                        //                                        this.ownMCCriteria1.IDParticipant, this.ownMCCriteria1.Application);
                        //rSelSelListEntryGroup = arrGrp[0];

                            //Get Row SelListEntry
                            this.dsAdminWorker.tblSelListEntries.Clear();
                        //qs2.core.vb.dsAdmin.tblSelListEntriesRow SelSelListEntry = this.sqlAdmin1.getSelListEntrysRow("", core.vb.sqlAdmin.eTypAuswahlList.id, this.ownMCCriteria1.IDParticipant,
                        //                                                                            "", "", -999, "", rStayAdd.IDSelList);
                        sExceptionMarker += "3.";

                        this.dsAdminTmp.Clear();
                        qs2.core.vb.dsAdmin.tblSelListEntriesRow SelSelListEntry = null;
                        qs2.core.vb.sqlAdmin.ParametersSelListEntries Parameters = new qs2.core.vb.sqlAdmin.ParametersSelListEntries();
                        qs2.core.vb.dsAdmin.tblSelListEntriesRow[] arrSellistEntries = this.sqlAdmin1.getSelListEntrys(ref Parameters, "", "", "", ref this.dsAdminTmp, core.vb.sqlAdmin.eTypAuswahlList.IDRam, "", -999, "", rStayAdd.IDSelList, "", "");
                        sExceptionMarker += "4.";
                        if (arrSellistEntries.Length == 0)
                        {

                        }
                        else if (arrSellistEntries.Length == 1)
                        {
                            SelSelListEntry = arrSellistEntries[0];
                            sExceptionMarker += "5.";
                            sExceptionMarkerID += arrSellistEntries[0].ID.ToString();
                        }
                        else if (arrSellistEntries.Length > 1)
                        {
                            sExceptionMarker += "6.";
                            throw new Exception("arrSellistEntries.Length != 1 for IDSelListEntry '" + rStayAdd.IDSelList.ToString() + "'!");
                        }
                        // Do Translation
                        if (SelSelListEntry != null)
                        {
                            sExceptionMarkerID += SelSelListEntry.IDRessource;
                            qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;
                            string IDResLabelFound = qs2.core.language.sqlLanguage.getRes(SelSelListEntry.IDRessource, core.Enums.eResourceType.Label, this.ownMCCriteria1.IDParticipant, this.ownMCCriteria1.Application, ref rLangFoundReturn);
                            if (IDResLabelFound.Trim() != "")
                                rowGridChild.Cells[qs2.core.generic.columnNameText].Value = IDResLabelFound;
                            else
                                rowGridChild.Cells[qs2.core.generic.columnNameText].Value = SelSelListEntry.IDRessource;

                            sExceptionMarker += "7.";
                        }
                        else
                        {
                            rowGridChild.Cells[qs2.core.generic.columnNameText].Value = qs2.core.language.sqlLanguage.getRes("Error.SelSelListEntry.NotFound");
                            sExceptionMarker += "8.";
                        }

                        if (!rStayAdd.IsIDObjectNull())
                        {
                            sExceptionMarker += "9.";
                            qs2.core.vb.dsObjects.tblObjectRow rObj = sqlObjectsTmp.getObjectRow(-999, sqlObjects.eTypSelObj.IDGuid, sqlObjects.eTypObj.none, "", "", rStayAdd.IDObject);
                            if (rObj != null)
                            {
                                rowGridChild.Cells[qs2.core.generic.columnNameText].Value = rObj.NameCombination.Trim();
                            }
                            else
                            {
                                rowGridChild.Cells[qs2.core.generic.columnNameText].Value = "[Object not found (IDObject='" + rStayAdd .IDObject .ToString()  + "')]";
                            }
                            sExceptionMarker += "10.";
                        }
                    }
                }

                this.gridData.Refresh();
                sExceptionMarker += "11.";
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(sExceptionMarker.Trim() + ", IDMarker=" + sExceptionMarkerID.Trim() + "\r\n" + ex.ToString(), "ownMultiGridSelList.translateRowStayAddition", "", false, true,
                                                                this.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void clearUI()
        {
            try
            {
                this.dsAdminShow.tblStayAdditions.Clear();
                this.gridData.Refresh();
                this.gridData.Selected.Rows.Clear();
                this.gridData.ActiveRow = null;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiGridSelList.clearUI", "", false, true,
                                                                this.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
   

        public bool saveData()
        {
            try
            {
                this.sqlAdmin1.daStayAdditions.Update(this.dsAdminShow.tblStayAdditions);
                foreach (qs2.core.vb.dsAdmin.tblStayAdditionsRow rStayAdditionsRow in this.dsAdminShow.tblStayAdditions)
                {
                    this.sqlAdmin1.updateSortStayAddition(rStayAdditionsRow.IDGuid, rStayAdditionsRow.Sort);
                }
                
                return true;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiGridSelList.saveData", "", false, true,
                                                                this.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return false;
            }
        }
        public void getTableAdditions(ref dsAdmin.tblStayAdditionsDataTable tStayAdditionsCopy)
        {
            try
            {
                if (!tStayAdditionsCopy.Columns.Contains(qs2.core.generic.columnNameText))
                {
                    tStayAdditionsCopy.Columns.Add(qs2.core.generic.columnNameText, typeof(string));
                    tStayAdditionsCopy.Columns[qs2.core.generic.columnNameText].SetOrdinal(0);
                    tStayAdditionsCopy.PrimaryKey = null;
                }
                
                foreach (dsAdmin.tblStayAdditionsRow rStayAdditionToCopy in this.dsAdminShow.tblStayAdditions)
                {
                    if (rStayAdditionToCopy.RowState != DataRowState.Deleted)
                    {
                        dsAdmin.tblStayAdditionsRow rNewStayAddition = (dsAdmin.tblStayAdditionsRow)tStayAdditionsCopy.NewRow();
                        rNewStayAddition.ItemArray = rStayAdditionToCopy.ItemArray;
                        tStayAdditionsCopy.Rows.Add(rNewStayAddition);
                    }
                }
                
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiGridSelList.getTableAdditions", "", false, true,
                                                                this.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void getSelListsAdded(System.Collections.Generic.List<qs2.core.generic.retValue> lstUserInput)
        {
            try
            {
                foreach (UltraGridRow actRowGrid in this.gridData.Rows)
                {
                    DataRowView v = (DataRowView)actRowGrid.ListObject;
                    qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListMain = (qs2.core.vb.dsAdmin.tblSelListEntriesRow)v.Row;
                    foreach (UltraGridRow actRowGridSelList in actRowGrid.ChildBands[0].Rows)
                    {
                        DataRowView v2 = (DataRowView)actRowGridSelList.ListObject;
                        qs2.core.vb.dsAdmin.tblStayAdditionsRow rSelStayAdditionsRow = (qs2.core.vb.dsAdmin.tblStayAdditionsRow)v2.Row;
                        qs2.core.generic.retValue retValue = new core.generic.retValue();
                        retValue.fieldInfo = "qs2.tblStay.CongenitalData";
                        retValue.sType = rSelStayAdditionsRow.typ.Trim();
                        if (rSelStayAdditionsRow.typ.Trim().ToLower().Equals(core.vb.sqlAdmin.eTypStayAdditions.multiSelListsRoles.ToString().Trim().ToLower()))
                        {
                            retValue.valueObj = rSelStayAdditionsRow.IDObject.ToString();
                            retValue.valueStr = rSelStayAdditionsRow.IDObject.ToString();
                        }
                        else
                        {
                            retValue.valueObj = rSelStayAdditionsRow.IDSelList;
                            retValue.valueStr = rSelStayAdditionsRow.IDSelList.ToString();
                        }
                        lstUserInput.Add(retValue);
                    }
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiGridSelList.saveData", "", false, true,
                                                                this.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void setEditable(bool editable)
        {
            try
            {
                bool ParentStayIsNotNull = false;
                ParentStayIsNotNull = true;

                this._editable = editable;
                this.panelTop.Visible  = editable;

                if (editable && this.ownMCCriteria1.rCriteria != null)
                {
                    this._editable = this.ownMCCriteria1.rCriteria.Editable;
                }

                if (this._editable)
                {
                    this.gridData.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
                    if (this._typMultiControl == qs2.core.vb.sqlAdmin.eTypStayAdditions.multiSelLists)
                    {

                    }
                    else if (this._typMultiControl == qs2.core.vb.sqlAdmin.eTypStayAdditions.assignStay)
                    {
                        this.gridData.DisplayLayout.Bands[0].Columns[this.dsAdminShow.tblStayAdditions.IDSelListColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                        this.gridData.DisplayLayout.Bands[0].Columns[this.dsAdminShow.tblStayAdditions.IDStayChildColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                    }
                }
                else
                {
                    this.gridData.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                    this.setUIAddElement(false);

                    if (this._typMultiControl == qs2.core.vb.sqlAdmin.eTypStayAdditions.assignStay)
                    {
                        this.gridData.DisplayLayout.Bands[0].Columns[this.dsAdminShow.tblStayAdditions.IDSelListColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                        this.gridData.DisplayLayout.Bands[0].Columns[this.dsAdminShow.tblStayAdditions.IDStayChildColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                    }
                }
                
                if (this._typMultiControl == sqlAdmin.eTypStayAdditions.multiSelLists)
                    this.panelBottom.Visible = editable;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiGridSelList.setEditable", "", false, true,
                                                                this.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void doText()
        {
            try
            {
                if (this._FldShortTitle.Trim() != "")
                {
                    qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;
                    this.grpMultiGrid.Text = qs2.core.language.sqlLanguage.getRes(this._FldShortTitle.Trim(), core.Enums.eResourceType.Label, this.ownMCCriteria1.IDParticipant, this.ownMCCriteria1.Application, ref rLangFoundReturn).Trim() + " ";
                  
                    qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn2 = null;
                    string txtToolTip = qs2.core.language.sqlLanguage.getRes(this._FldShortTitle.Trim(), core.Enums.eResourceType.ToolTip, this.ownMCCriteria1.IDParticipant, this.ownMCCriteria1.Application, ref  rLangFoundReturn2).Trim();
                    if (!qs2.core.ENV.ExtendedUI)
                    {
                        if (txtToolTip != "")
                            this.ownControlInfo1.doToolTipxy(this.grpMultiGrid, qs2.core.language.sqlLanguage.getRes("Info"), txtToolTip, this, false, this.ownMCCriteria1.Application, this.OwnFieldForALLProducts);
                    }

                    qs2.core.language.dsLanguage.RessourcenRow rResHelp = qs2.core.language.sqlLanguage.getResRow(this._FldShortTitle.Trim(), core.Enums.eResourceType.Help, this.ownMCCriteria1.IDParticipant,
                                                                                                        this.ownMCCriteria1.Application);
                    if (!this.DesignMode)
                    {
                        this.ContextMenuStrip = this.contextMenuStrip1;
                        this.criteriasToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("Criterias") + " [" + qs2.core.Enums.eControlType.GridMultiSelect.ToString() + "]";
                        this.ressourcenToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("Ressourcen") + " [" + qs2.core.Enums.eControlType.GridMultiSelect.ToString() + "]";
                        this.ressourcenSellistsToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("SelLists") + " [" + qs2.core.Enums.eControlType.GridMultiSelect.ToString() + "]";

                    }
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiGridSelList.doText", "", false, true,
                                                        this.ownMCCriteria1.Application,
                                                        qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void showTabOrder()
        {
            //this.ownControlInfo1.doToolTip(this, "TabIndex", this._tabIndex.ToString(), this, true, this.ownMCCriteria1.IDApplication.ToString(), this.OwnFieldForALLProducts);
      
        }

        public void addNewSelListElement(qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelectedSelListEntry, int groupNrToLoad)
        {
            try
            {
                //if (groupNrToLoad == this._FldShort.Count())
                //    return;

                qs2.design.auto.multiControl.contMultiGridSelListElement newElement;
                if ((this.panelAdd.Controls.Count - 1) >= (groupNrToLoad - 1))
                    newElement = (qs2.design.auto.multiControl.contMultiGridSelListElement)this.panelAdd.Controls[groupNrToLoad - 1];
                else
                {
                    newElement = new qs2.design.auto.multiControl.contMultiGridSelListElement();
                    newElement.mainControl = this;
                    newElement.groupNrToLoad = groupNrToLoad;
                    newElement.initControl();
                    
                    newElement.Left = 0;
                    Control lastCont = null;
                    if (this.panelAdd.Controls.Count > 0)
                    {
                        lastCont = this.panelAdd.Controls[this.panelAdd.Controls.Count - 1];
                        newElement.Top = lastCont.Top + lastCont.Height;
                    }
                    else
                        newElement.Top = 0;

                    newElement.Left = 0;
                    newElement.Width = this.panelAdd.Width - 5;
                    //newElement.Dock = DockStyle.Top;
                    this.panelAdd.Controls.Add(newElement);
                }

                newElement.Visible = true;

                this.panelAdd.AutoScroll = true;
                System.Drawing.Size sizeScroll = new System.Drawing.Size(0, newElement.Top + newElement.Height + 5);
                this.panelAdd.AutoScrollMinSize = sizeScroll;
                //this.panelAdd.SetAutoScrollMargin(sizeScroll.Width, sizeScroll.Height );

                bool IsTypeRole = this.CheckIfDoRolesAndUsers();
                if (IsTypeRole)
                {
                    if (groupNrToLoad == 1)
                    {
                        newElement.loadDataUsersForRole(rSelectedSelListEntry, "Roles",
                                                        this.ownMCCriteria1.Application, this.ownMCCriteria1.IDParticipant, true);   // OMC.IDApplication.Check
                    }
                    else if (groupNrToLoad == 2)
                    {
                        newElement.loadDataUsersForRole(rSelectedSelListEntry, "Users",
                                                        this.ownMCCriteria1.Application, this.ownMCCriteria1.IDParticipant, false);   // OMC.IDApplication.Check
                    }
                    else
                    {
                        throw new Exception("addNewSelListElement: roupNrToLoad > 2 not possible for participates!");
                    }
                }
                else
                {
                    newElement.loadData(rSelectedSelListEntry, this._FldShort[groupNrToLoad],
                                        this.ownMCCriteria1.Application, this.ownMCCriteria1.IDParticipant);   // OMC.IDApplication.Check
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiGridSelList.addNewSelListElement", "", false, true,
                                                                this.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public bool CheckIfDoRolesAndUsers()
        {
            try
            {
                if (this._typMultiControl == core.vb.sqlAdmin.eTypStayAdditions.multiSelLists)
                {
                    if (this.rSelListEntriesMainCbo.Classification.Trim().ToLower().Contains(("participates").Trim().ToLower()))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (this._typMultiControl == core.vb.sqlAdmin.eTypStayAdditions.assignStay)
                {
                    return false;
                }
                else
                {
                    throw new Exception("CheckIfDoRolesAndUsers: this._typMultiControl '" + this._typMultiControl.ToString() + "' not allowed!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("CheckIfDoRolesAndUsers:" + ex.ToString());
            }
        }
        public bool CheckIfTypeObject()
        {
            try
            {
                if (this._typMultiControl == core.vb.sqlAdmin.eTypStayAdditions.multiSelLists)
                {
                    if (this.rSelListEntriesMainCbo.Classification.Trim().ToLower().Contains(("Object").Trim().ToLower()))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (this._typMultiControl == core.vb.sqlAdmin.eTypStayAdditions.assignStay)
                {
                    return false;
                }
                else
                {
                    throw new Exception("CheckIfTypeObject: this._typMultiControl '" + this._typMultiControl.ToString() + "' not allowed!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("CheckIfTypeObject:" + ex.ToString());
            }
        }

        public string OwnFldShortTitle
        {
            get
            {
                return this._FldShortTitle;
            }
            set
            {
                this._FldShortTitle = value;
                if (this.DesignMode)
                {
                    this.doControl();
                }
            }
        }

        public string[] OwnFldShort
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

                }
            }
        }
        public int OwnHeigthAddPanel
        {
            get
            {
                return this._HeigthAddPanel;
            }
            set
            {
                this._HeigthAddPanel = value;
                this.panelAdd.Height = this._HeigthAddPanel;
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

        public qs2.core.vb.sqlAdmin.eTypStayAdditions OwnTypMultiControl 
        {
            get
            {
                return this._typMultiControl;
            }
            set
            {
                this._typMultiControl = value;
                if (this._typMultiControl == core.vb.sqlAdmin.eTypStayAdditions.multiSelLists)
                {
                    this.panelAdd.Visible = true;
                }
                else if (this._typMultiControl == core.vb.sqlAdmin.eTypStayAdditions.assignStay)
                {
                    this.panelAdd.Visible = false;
                    this.panelBottom.Visible = false; 
                }
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this._typMultiControl == core.vb.sqlAdmin.eTypStayAdditions.multiSelLists)
                {
                    foreach (qs2.design.auto.multiControl.contMultiGridSelListElement element in this.panelAdd.Controls)
                        element.Visible = false;
                    
                    this.rSelListEntriesMainCbo = null;
                    qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListEntry = this.getSelectedRowSelList();
                    if (rSelListEntry != null)
                    {
                        this.setUIAddElement(true);
                        this.rSelListEntriesMainCbo = rSelListEntry;
                        this.addNewSelListElement(rSelListEntry, 1);

                        if (this.MCValueChanged != null)
                            this.MCValueChanged.Invoke();
                    }
                }
                else if (this._typMultiControl == core.vb.sqlAdmin.eTypStayAdditions.assignStay)
                {
                    this.addNewRowToMainGroup(null);

                    if (this.MCValueChanged != null)
                        this.MCValueChanged.Invoke();
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep("Field " + this._FldShortTitle + ":" + qs2.core.generic.lineBreak + ex.ToString(), "");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        public bool addNewRowToMainGroup(qs2.core.vb.dsAdmin.tblSelListEntriesRow rLastSelSelListEntry)
        {
            try
            {
                bool IsTypeRole = this.CheckIfDoRolesAndUsers();
                bool IsTypeObject = this.CheckIfTypeObject();

                this.gridData.Refresh();
                if (this._typMultiControl == core.vb.sqlAdmin.eTypStayAdditions.multiSelLists)
                {
                    this.setUIAddElement(false);
                    this.translateRowStayAddition();
                    this.setGridUI(false);
                }
                Application.DoEvents();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiGridSelList.addNewRowToMainGroup: " + ex.ToString());
            }
        }
        public int getNextListNrToAdd()
        {
            int nextNr = 1;
            foreach (qs2.design.auto.multiControl.contMultiGridSelListElement element in this.panelAdd.Controls)
                if (element.Visible)
                    nextNr += 1;

            return (nextNr);
        }
        public void unvisibleAllElementsHigher(int nrControlValueChanged)
        {
            foreach (qs2.design.auto.multiControl.contMultiGridSelListElement element in this.panelAdd.Controls)
                if (element.groupNrToLoad > nrControlValueChanged)
                    element.Visible = false;
        }
        public bool ListNrIsLast(int nextNr)
        {
            if (nextNr == this._FldShort.Count() )
                return true;
            else
                return false;
        }

        public qs2.core.vb.dsAdmin.tblSelListEntriesRow getSelectedRowSelList()
        {
            if (this.gridData.ActiveRow != null)
            {
                if (this.gridData.ActiveRow.Band.Index == 0)
                {
                    DataRowView v = (DataRowView)this.gridData.ActiveRow.ListObject;
                    qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelStayAdditionsRow = (qs2.core.vb.dsAdmin.tblSelListEntriesRow)v.Row;
                    return rSelStayAdditionsRow;
                }
            }

            qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), MessageBoxButtons.OK, "");
            return null;
        }
        public qs2.core.vb.dsAdmin.tblStayAdditionsRow getSelectedRowStayAddition()
        {
            int indexBand = 0;
            if (this._typMultiControl == core.vb.sqlAdmin.eTypStayAdditions.multiSelLists)
                indexBand = 1;
            else if (this._typMultiControl == core.vb.sqlAdmin.eTypStayAdditions.assignStay)
                indexBand = 0;

            if (this.gridData.ActiveRow != null)
            {
                if (this.gridData.ActiveRow.Band.Index == indexBand)
                {
                    DataRowView v = (DataRowView)this.gridData.ActiveRow.ListObject;
                    qs2.core.vb.dsAdmin.tblStayAdditionsRow rSelStayAdditionsRow = (qs2.core.vb.dsAdmin.tblStayAdditionsRow)v.Row;
                    return rSelStayAdditionsRow;
                }
            }

            qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), MessageBoxButtons.OK, "");
            return null;
        }
        private void setUIAddElement(bool yes)
        {
            try
            {
                //this.panelGridAll.Visible = !yes;
                this.btnCancel.Visible = yes;
                this.btnUp.Visible = !yes;
                this.btnDown.Visible = !yes;
                this.panelAdd.Visible  = (!yes ? false : true);
                this.panelAdd.Height =  this._HeigthAddPanel;
                //this.panelAdd.Dock = (yes ? DockStyle.Fill : DockStyle.Bottom);
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiGridSelList.setUIAddElement", "", false, true,
                                                                this.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //UltraGridRow rowSelStayAdditionsRow = this.getSelectedRowStayAddition();
                //if (rowSelStayAdditionsRow != null)
                //    rowSelStayAdditionsRow.Delete(false);
                
                System.Collections.Generic.List<Infragistics.Win.UltraWinGrid.UltraGridRow> rSelected = new System.Collections.Generic.List<Infragistics.Win.UltraWinGrid.UltraGridRow>();
                qs2.core.ui.getSelectedGridRows(this.gridData , rSelected, true );
                if (rSelected.Count > 0)
                {
                    foreach (UltraGridRow row in rSelected)
                    {
                        DataRowView v = (DataRowView)row.ListObject;
                        dsAdmin.tblStayAdditionsRow rStayAdditions = (dsAdmin.tblStayAdditionsRow)v.Row;
                        rStayAdditions.Delete();
                        //row.Delete(false);
                    }
                }
                else
                {
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), MessageBoxButtons.OK, "");
                }
                this.gridData.Refresh();

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep("Field " + this._FldShortTitle + ":" + qs2.core.generic.lineBreak + ex.ToString(), "");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ownMultiGridSelList_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!this.lockVisible)
                {
                    this.lockVisible = true;
                    
                    if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
                    {
                        this.doVisible();
                    }

                }
                
            }
            catch (Exception ex)
            {
                this.lockVisible = false;
                qs2.core.Protocol.doExcept(ex.ToString(), "contAutoUI.loadAllControls", "", false, true,
                                                                this.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
            finally
            {
                this.lockVisible = false;
                this.Cursor = Cursors.Default;
            }
        }
        public bool doVisible()
        {
            bool ParentStayIsNotNull = false;
            bool ParentFormIsVisible = false;
            ParentStayIsNotNull = true;

            if (this.IsQueryControl)
            {
                if (!this.isLoaded)
                {
                    if (!this.ownMCCriteria1._ControlIsFormatted)
                    {
                        this.doText();
                        this.setEditable(this._editable);
                    }
                    this.ownMCCriteria1._ControlIsFormatted = true;
                    this.doVisible2();
                    this.TabIndex = this.OwnOrder;
                    if (qs2.core.ENV.ExtendedUI)
                    {
                        this.showTabOrder();
                    }
                    this.isLoaded = true;
                }
            }
            return true;
        }

        public void doVisible2()
        {
            bool ParentStayIsNotNull = false;
            bool ParentFormIsInEditMode = false;
            ParentStayIsNotNull = true;

            if (ParentStayIsNotNull)
            {
                this.setEditable(ParentFormIsInEditMode); 
            }
            this.ownControlUI1.IsVisible_LicenseKey = true;
            this.Visible = (this.ownControlUI1.IsVisible_Criteriaxy && this.ownControlUI1.IsVisible_LicenseKey && this.IsVisibleControlAssignmentChapters);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.setUIAddElement(false);
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep("Field " + this._FldShortTitle + ":" + qs2.core.generic.lineBreak + ex.ToString(), "");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void gridData_DoubleClick(object sender, EventArgs e)
        {
            qs2.core.ui.expandCollapseGridRow(this.gridData.ActiveRow, 0);
        }

        private void gridData_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            if (this._typMultiControl == core.vb.sqlAdmin.eTypStayAdditions.multiSelLists)
            {
                if (e.Cell.Column.ToString() == this.dsAdminShow.tblStayAdditions.SortColumn.ColumnName)
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                else
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
            else if (this._typMultiControl == core.vb.sqlAdmin.eTypStayAdditions.assignStay)
            {
                if (e.Cell.Column.ToString() == this.dsAdminShow.tblStayAdditions.IDSelListColumn.ColumnName || (e.Cell.Column.ToString() == this.dsAdminShow.tblStayAdditions.IDStayChildColumn.ColumnName))
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                else
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }

            //e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
        }

        private void gridData_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            int indexBand = 0;
            if (this._typMultiControl == core.vb.sqlAdmin.eTypStayAdditions.multiSelLists)
                indexBand = 2;
            else if (this._typMultiControl == core.vb.sqlAdmin.eTypStayAdditions.assignStay)
                indexBand = 0;

            if (e.Rows[0].Band.Index != indexBand)
                e.Cancel = true;

            //if (e.Rows[0].Band.Index == indexBand)
            //    qs2.core.ui.delGridRowYN(e);
            //else
            //    e.Cancel = true;

            if (this.MCValueChanged != null)
                this.MCValueChanged.Invoke();
        }



        private void criteriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.ownControlInfo1.showInfoCriterias(this, this.ownMCCriteria1.rCriteria.FldShort, this.ownMCCriteria1.Application, this.ownMCCriteria1.IDParticipant, this.OwnFieldForALLProducts);
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep("Field " + this._FldShortTitle + ":" + qs2.core.generic.lineBreak + ex.ToString(), "");
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
                this.ownControlInfo1.showInfoRessourcen(this, this.ownMCCriteria1.rCriteria.FldShort, this.ownMCCriteria1.Application, this.ownMCCriteria1.IDParticipant, this.OwnFieldForALLProducts);
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep("Field " + this._FldShortTitle + ":" + qs2.core.generic.lineBreak + ex.ToString(), "");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ressourcenSellistsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.ownControlInfo1.showInfoFldShorts(this, this._FldShort, qs2.core.language.sqlLanguage.getRes("SelLists"), this.ownMCCriteria1.Application, this.OwnFieldForALLProducts);
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep("Field " + this._FldShortTitle + ":" + qs2.core.generic.lineBreak + ex.ToString(), "");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                qs2.core.vb.dsAdmin.tblStayAdditionsRow rNewStayAdd = null;
                this.doSortOrder(true, ref rNewStayAdd);
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep("Field " + this._FldShortTitle + ":" + qs2.core.generic.lineBreak + ex.ToString(), "");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                qs2.core.vb.dsAdmin.tblStayAdditionsRow rNewStayAdd = null;
                this.doSortOrder(false, ref rNewStayAdd);
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep("Field " + this._FldShortTitle + ":" + qs2.core.generic.lineBreak + ex.ToString(), "");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public void doSortOrder(bool toTop, ref qs2.core.vb.dsAdmin.tblStayAdditionsRow rSelStayAddition)
        {
            try
            {
                //qs2.core.vb.dsAdmin.tblStayAdditionsRow rSelStayAddition = this.getSelectedRowStayAddition();
                //if (rSelStayAddition != null)
                //{
                //    UltraGridRow gridSelStayAddition = this.gridData.Rows.GetRowWithListIndex(this.dsAdminShow.tblStayAdditions.Rows.IndexOf(rSelStayAddition));
                //    foreach( UltraGridRow row in gridSelStayAddition.ParentRow.ChildBands[0].Rows) 
                //    {
                //        DataRowView v = (DataRowView)row.ListObject;
                //        qs2.core.vb.dsAdmin.tblStayAdditionsRow rActuellStayAddistion = (qs2.core.vb.dsAdmin.tblStayAdditionsRow)v.Row;
                //        if (rActuellStayAddistion.Sort == rSelStayAddition.Sort)
                //        {
                //            if (toTop)
                //            {
                //                rSelStayAddition.Sort = rActuellStayAddistion.Sort;
                //                rActuellStayAddistion.Sort += 1;
                //            }
                //            else
                //            {
                //                rSelStayAddition.Sort = rActuellStayAddistion.Sort;
                //                rActuellStayAddistion.Sort -= 1;
                //            }
                //        }
                //    }
                //}

                if (rSelStayAddition == null)
                {
                    rSelStayAddition = this.getSelectedRowStayAddition();  
                }
                if (rSelStayAddition != null)
                {
                    //int actuellSort = rSelStayAddition.Sort;
                    //if (toTop)
                    //{
                    //    rSelStayAddition.Sort -= 1;
                    //}
                    //else
                    //{
                    //    rSelStayAddition.Sort += 1;
                    //}

                    //this.gridData.DisplayLayout.Bands[1].SortedColumns.Clear();
                    //this.gridData.DisplayLayout.Bands[1].SortedColumns.Add(this.dsAdminShow.tblStayAdditions.SortColumn.ColumnName, false);
                    //this.gridData.DisplayLayout.Bands[1].SortedColumns.Add(this.dsAdminShow.tblStayAdditions.IDOwnIntMainColumn.ColumnName, false);
                    
                    int newNr = 0;
                    bool reached = false;
                    qs2.core.vb.dsAdmin.tblSelListEntriesRow rParentStayAddition = (qs2.core.vb.dsAdmin.tblSelListEntriesRow)rSelStayAddition.GetParentRow(this.dsAdminShow.tblStayAdditions.ParentRelations[0]);
                    //qs2.core.vb.dsAdmin.tblStayAdditionsRow[] arrActuellStayAddition = (qs2.core.vb.dsAdmin.tblStayAdditionsRow[])rParentStayAddition.GetChildRows(this.dsAdminShow.tblSelListEntries.ChildRelations[1]);
                    string orderBy = "";
                    if (toTop)
                    {
                        orderBy = " desc ";
                    }
                    else
                    {
                        orderBy = " asc ";
                    }
                    string colNewOrder = "NewOrder";

                    string sWhere = this.dsAdminShow.tblStayAdditions.IDSelListFirstColumn.ColumnName + "=" + rParentStayAddition.ID + "";
                    this.dsAdminShow.tblStayAdditions.Columns.Add(colNewOrder, typeof(System.Int32));
                    qs2.core.vb.dsAdmin.tblStayAdditionsRow[] arrActuellStayAddition = (qs2.core.vb.dsAdmin.tblStayAdditionsRow[])this.dsAdminShow.tblStayAdditions.Select(sWhere, this.dsAdminShow.tblStayAdditions.SortColumn.ColumnName + orderBy);
                    foreach (qs2.core.vb.dsAdmin.tblStayAdditionsRow rActuellStayAddition in arrActuellStayAddition)
                    {
                        newNr += 1;
                        if (!reached && (rActuellStayAddition.IDGuid == rSelStayAddition.IDGuid))
                        {
                            reached = true;
                            rActuellStayAddition[colNewOrder] = (newNr + 1);
                        }
                        else if (reached && (rActuellStayAddition.IDGuid != rSelStayAddition.IDGuid))
                        {
                            rActuellStayAddition[colNewOrder] = (newNr - 1);
                            reached = false;
                        }
                        else if (!reached && (rActuellStayAddition.IDGuid != rSelStayAddition.IDGuid))
                        {
                            rActuellStayAddition[colNewOrder] = newNr;
                        }
                    }
                    newNr = 0;
                    qs2.core.vb.dsAdmin.tblStayAdditionsRow[] arrActuellStayAdditionWrite = (qs2.core.vb.dsAdmin.tblStayAdditionsRow[])this.dsAdminShow.tblStayAdditions.Select(sWhere, colNewOrder + orderBy);
                    foreach (qs2.core.vb.dsAdmin.tblStayAdditionsRow rActuellStayAddition in arrActuellStayAdditionWrite)
                    {
                        newNr += 1;
                        rActuellStayAddition.Sort = newNr;
                        //rActuellStayAddition.Description = System.Guid.NewGuid().ToString();
                    }
                    this.gridData.Refresh();

                    this.dsAdminShow.tblStayAdditions.Columns.Remove(colNewOrder);

                    this.gridData.DisplayLayout.Bands[1].SortedColumns.Clear();
                    this.gridData.DisplayLayout.Bands[1].SortedColumns.Add(this.dsAdminShow.tblStayAdditions.SortColumn.ColumnName, false);
                    this.gridData.Refresh();
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiGridSelList.doSortOrder", "", false, true,
                                                                    this.ownMCCriteria1.Application,
                                                                    qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public int getLastSortNumber(qs2.core.vb.dsAdmin.tblStayAdditionsRow rSelStayAddition)
        {
            try
            {
                int lastNr = 0;
                qs2.core.vb.dsAdmin.tblSelListEntriesRow rParentStayAddition = (qs2.core.vb.dsAdmin.tblSelListEntriesRow)rSelStayAddition.GetParentRow(this.dsAdminShow.tblStayAdditions.ParentRelations[0]);
                foreach (qs2.core.vb.dsAdmin.tblStayAdditionsRow rActuellStayAddition in rParentStayAddition.GetChildRows(this.dsAdminShow.tblSelListEntries .ChildRelations[1]))
                {
                    lastNr = (lastNr < rActuellStayAddition.Sort ? rActuellStayAddition.Sort: lastNr);
                }
                return (lastNr + 1);
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiGridSelList.getLastSortNumber", "", false, true,
                                                                this.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return 5000;
            }
        }

        public void unloadControl()
        {
            try
            {
                try
                {
                    this.dsAdminShow.Clear();
                    this.dsAdminWorker.Clear();

                    this.gridData.DataSource = null;
                    this.gridData.DataMember = null;
                    this.gridData.DataBind();
                    Application.DoEvents();
                    this.ownMCCriteria1.ownMCCombo1 = null;

                    this.gridData.Dispose();
                    this.gridData = null;

                    this.dsAdminShow = null;
                    this.dsAdminWorker = null;
                }
                catch (Exception ex2)
                {
                    string xy = ex2.ToString();
                    //throw new Exception(ex2.ToString());
                }

                this.ownControlInfo1 = null;
                this.ownControlUI1 = null;
                this.ui1 = null;

                if (this.ownMCCriteria1 != null)
                {
                    this.ownMCCriteria1.rCriteria = null;
                    this.ownMCCriteria1.rColSys = null;
                }

                foreach (qs2.design.auto.multiControl.contMultiGridSelListElement element in this.panelAdd.Controls)
                {
                    element.cboSelListEntrySelection.DataSource = null;
                    element.cboSelListEntrySelection.DataMember = null;
                    element.cboSelListEntrySelection.DataBind();

                    element.mainControl = null;
                }

                this.ownMCCriteria1 = null;

            }
            catch (Exception ex)
            {
                string xy = ex.ToString();
            }
        }

    }
}
