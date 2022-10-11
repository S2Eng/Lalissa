using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using qs2.core.vb;
using Infragistics.Win.UltraWinGrid;
using QS2.Resources;
using Infragistics.Win.UltraWinToolTip;
using qs2.design.auto.print;
using S2Extensions;

namespace qs2.ui.print
{
    public partial class contQueryDef : UserControl
    {
        private qs2.core.Enums.eTypQueryDef typQueryDef = new qs2.core.Enums.eTypQueryDef();
        private bool isInEditMode;
        private qs2.core.ui ui1 = new qs2.core.ui();
        private qs2.design.auto.multiControl.ownMCInfo ownControlInfo1 = new qs2.design.auto.multiControl.ownMCInfo();
        private drawMulticontrol drawMulticontrol1 = new drawMulticontrol();
        private dsAdmin dsAllCriteriasForQueries = new dsAdmin();
        private dsAdmin dsViewsQueries = new dsAdmin();
        private string colChaptersTransl = "ChaptersTransl";
        private string colChapterTransl = "ChapterTransl";
        private string colLineNr = "LineNr";
        private string colControlNr = "ControlNr";
        private string colSerialNr = "SerialNr";
        private qs2.core.vb.ui ui2 = new core.vb.ui();
        
        public dsAdmin.tblSelListEntriesRow rSelList;
        public string ApplicationLast = "";
        public contQryAdmin mainWindow;

        public contQueryDef()
        {
            InitializeComponent();
        }

        private void contQueryDef_Load(object sender, EventArgs e)
        {

        }

        public void initControl(qs2.core.Enums.eTypQueryDef typQueryDef1)
        {
            try
            {
                this.btnAdd.initControl();
                this.btnDel.initControl();
                this.btnUp.initControl();
                this.btnDown.initControl();

                this.typQueryDef = typQueryDef1;
                this.sqlAdmin1.initControl();

                this.loadRes();
                this.loadValueLists();
                this.sortByChapterToolStripMenuItem.Visible = false;

                if (this.typQueryDef == core.Enums.eTypQueryDef.SelectFields)
                {
                    this.panelDetails.Visible = false;
                    this.sortByChapterToolStripMenuItem.Visible = true;
                }
                else if (this.typQueryDef == core.Enums.eTypQueryDef.InputParameters)
                {
                    this.panelDetails.Visible = true;
                }
                else if (this.typQueryDef == core.Enums.eTypQueryDef.WhereConditions)
                {
                    this.panelDetails.Visible = true;
                }
                else if (this.typQueryDef == core.Enums.eTypQueryDef.Joins)
                {
                    this.panelDetails.Visible = false;
                }

                this.panelGrid.ContextMenuStrip = this.contextMenuStrip1;
                this.deleteFieldToolStripMenuItem.Visible = true;
                this.sortByChapterToolStripMenuItem.Visible = true;

                if (qs2.core.ENV.AdminSecure)
                {
                    this.criteriasToolStripMenuItem.Visible = true;
                    this.tooltippsAnzeigenToolStripMenuItem.Visible = true;
                    this.infoFieldSQLServerToolStripMenuItem.Visible = true;
                }
                else
                {
                    this.criteriasToolStripMenuItem.Visible = false;
                    this.tooltippsAnzeigenToolStripMenuItem.Visible = false;
                    this.infoFieldSQLServerToolStripMenuItem.Visible = false;
                }

                this.criteriasToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("Criterias");
                this.infoFieldSQLServerToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("infoFieldSQLServer");
                this.sortByChapterToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("SortFieldsByChapter");
                this.selectChapterToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("SelectChapter");
                this.checkChaptersToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("CheckChapters");
                this.showColumnChaptersToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("showColumnChapters");
                this.tooltippsAnzeigenToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("showTooltips");

                this.btnClampRight.Tag = qs2.core.sqlTxt.ClampRight;
                this.btnClampLeft.Tag = qs2.core.sqlTxt.ClampLeft;
                this.btnAnd.Tag = qs2.core.sqlTxt.and;
                this.btnOr.Tag = qs2.core.sqlTxt.or;

                this.drawMulticontrol1.initControl();

                if (this.typQueryDef == core.Enums.eTypQueryDef.WhereConditions)
                {
                    this.initMultiControls(ref this.multiValueMin, 100, "ValueMin");
                    this.initMultiControls(ref this.multiMax, 101, "Max");
                }
                else if (this.typQueryDef == core.Enums.eTypQueryDef.InputParameters)
                {
                    this.initMultiControls(ref this.multiValueMin, 100, "DefaultValue");
                }

                this.dsAllCriteriasForQueries.Clear();
                qs2.core.vb.sqlAdmin.getSelList(null, null, "AllCriteriasForQueries", qs2.core.vb.sqlAdmin.eTypSelListID.IDOwnStr, this.dsAllCriteriasForQueries, sqlAdmin.eTypAuswahlList.group);

                this.dsViewsQueries.Clear();
                qs2.core.vb.sqlAdmin.getSelList(null, null, "ViewsQueries", qs2.core.vb.sqlAdmin.eTypSelListID.IDOwnStr, this.dsViewsQueries, sqlAdmin.eTypAuswahlList.group);

                this.initMultiControls(ref this.ownMultiControlParent, 100, "ValueMin");
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void loadValueLists()
        {
            try
            {
                qs2.core.generic.getConditions(this.gridQueryDef.DisplayLayout.ValueLists[this.dsAdmin1.tblQueriesDef.ConditionColumn.ColumnName], null);
                qs2.core.generic.getTypQueryDefs(this.gridQueryDef.DisplayLayout.ValueLists[this.dsAdmin1.tblQueriesDef.TypColumn.ColumnName], null);

                this.gridQueryDef.DisplayLayout.ValueLists[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].ValueListItems.Add(qs2.core.Enums.eControlType.Textfield, qs2.core.Enums.eControlType.Textfield.ToString());
                this.gridQueryDef.DisplayLayout.ValueLists[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].ValueListItems.Add(qs2.core.Enums.eControlType.Numeric, qs2.core.Enums.eControlType.Numeric.ToString());
                this.gridQueryDef.DisplayLayout.ValueLists[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].ValueListItems.Add(qs2.core.Enums.eControlType.Integer, qs2.core.Enums.eControlType.Integer.ToString());
                this.gridQueryDef.DisplayLayout.ValueLists[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].ValueListItems.Add(qs2.core.Enums.eControlType.ComboBox, qs2.core.Enums.eControlType.ComboBox.ToString());
                this.gridQueryDef.DisplayLayout.ValueLists[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].ValueListItems.Add(qs2.core.Enums.eControlType.DateTime, qs2.core.Enums.eControlType.DateTime.ToString());
                this.gridQueryDef.DisplayLayout.ValueLists[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].ValueListItems.Add(qs2.core.Enums.eControlType.Date, qs2.core.Enums.eControlType.Date.ToString());
                this.gridQueryDef.DisplayLayout.ValueLists[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].ValueListItems.Add(qs2.core.Enums.eControlType.Time, qs2.core.Enums.eControlType.Time.ToString());
                this.gridQueryDef.DisplayLayout.ValueLists[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].ValueListItems.Add(qs2.core.Enums.eControlType.CheckBox, qs2.core.Enums.eControlType.CheckBox.ToString());
                this.gridQueryDef.DisplayLayout.ValueLists[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].ValueListItems.Add(qs2.core.Enums.eControlType.ThreeStateCheckBox, qs2.core.Enums.eControlType.ThreeStateCheckBox.ToString());
                this.gridQueryDef.DisplayLayout.ValueLists[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].ValueListItems.Add(qs2.core.Enums.eControlType.ComboBoxCheckThreeStateBox, qs2.core.Enums.eControlType.ComboBoxCheckThreeStateBox.ToString());
                this.gridQueryDef.DisplayLayout.ValueLists[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].ValueListItems.Add(qs2.core.Enums.eControlType.ComboBoxAsDropDown, qs2.core.Enums.eControlType.ComboBoxAsDropDown.ToString());

                this.gridQueryDef.DisplayLayout.ValueLists[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].ValueListItems.Add(qs2.core.Enums.eControlType.TextfieldNoDb, qs2.core.Enums.eControlType.TextfieldNoDb.ToString());
                this.gridQueryDef.DisplayLayout.ValueLists[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].ValueListItems.Add(qs2.core.Enums.eControlType.TextfieldMultiNoDb, qs2.core.Enums.eControlType.TextfieldMultiNoDb.ToString());
                this.gridQueryDef.DisplayLayout.ValueLists[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].ValueListItems.Add(qs2.core.Enums.eControlType.NumericNoDb, qs2.core.Enums.eControlType.NumericNoDb.ToString());
                this.gridQueryDef.DisplayLayout.ValueLists[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].ValueListItems.Add(qs2.core.Enums.eControlType.IntegerNoDb, qs2.core.Enums.eControlType.IntegerNoDb.ToString());
                this.gridQueryDef.DisplayLayout.ValueLists[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].ValueListItems.Add(qs2.core.Enums.eControlType.ComboBoxNoDb, qs2.core.Enums.eControlType.ComboBoxNoDb.ToString());
                this.gridQueryDef.DisplayLayout.ValueLists[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].ValueListItems.Add(qs2.core.Enums.eControlType.DateTimeNoDb, qs2.core.Enums.eControlType.DateTimeNoDb.ToString());
                this.gridQueryDef.DisplayLayout.ValueLists[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].ValueListItems.Add(qs2.core.Enums.eControlType.DateNoDb, qs2.core.Enums.eControlType.DateNoDb.ToString());
                this.gridQueryDef.DisplayLayout.ValueLists[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].ValueListItems.Add(qs2.core.Enums.eControlType.TimeNoDb, qs2.core.Enums.eControlType.TimeNoDb.ToString());
                this.gridQueryDef.DisplayLayout.ValueLists[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].ValueListItems.Add(qs2.core.Enums.eControlType.CheckBoxNoDb, qs2.core.Enums.eControlType.CheckBoxNoDb.ToString());
                this.gridQueryDef.DisplayLayout.ValueLists[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].ValueListItems.Add(qs2.core.Enums.eControlType.ThreeStateCheckBoxNoDb, qs2.core.Enums.eControlType.ThreeStateCheckBoxNoDb.ToString());

                qs2.core.generic.getSpecialDefinitionsMinValue(this.gridQueryDef.DisplayLayout.ValueLists["SpecialDefinitionsMinValue"], null);
                qs2.core.generic.getSpecialDefinitionsMaxValue(this.gridQueryDef.DisplayLayout.ValueLists["SpecialDefinitionsMaxValue"], null);

                this.gridQueryDef.DisplayLayout.ValueLists["ComboAsDropDownCondition"].ValueListItems.Clear();
                this.gridQueryDef.DisplayLayout.ValueLists["ComboAsDropDownCondition"].ValueListItems.Add(qs2.core.sqlTxt.and.ToString().Trim(), qs2.core.language.sqlLanguage.getRes(qs2.core.sqlTxt.and.ToString().Trim()));
                this.gridQueryDef.DisplayLayout.ValueLists["ComboAsDropDownCondition"].ValueListItems.Add(qs2.core.sqlTxt.or.ToString().Trim(), qs2.core.language.sqlLanguage.getRes(qs2.core.sqlTxt.or.ToString().Trim()));

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void initMultiControls(ref qs2.design.auto.multiControl.ownMultiControl multiControl, int tabIndex, string IDRes)
        {
            try
            {
                string translatedRes = qs2.core.language.sqlLanguage.getRes(IDRes);
                multiControl.placeFix = true;
                multiControl.Visible = false;
                multiControl.OwnOrderLineNr = 1;
                multiControl.OwnOrderControlNr = tabIndex;

                multiControl.ownMCCriteria1.initControl();
                multiControl.setControl(true);
                multiControl.infragLabelLeft.Text = translatedRes;

                multiControl.ownMCEvents1.valueChanged += new System.EventHandler(this.ValueChanged);
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void loadMulticontrols(ref dsAdmin.tblQueriesDefRow rQry, ref string protocollForAdmin, ref bool protocolWindow)
        {
            try
            {
                if (this.typQueryDef != core.Enums.eTypQueryDef.SelectFields && this.typQueryDef != core.Enums.eTypQueryDef.Joins)
                {
                    this.drawMulticontrol1.clearMCControls(this.ownMultiControlParent);

                    this.drawMulticontrol1.setMultiControl(this.multiValueMin, rQry, this.mainWindow.contSelListQueries.getSelectedQuery(false),
                                                            this.typQueryDef, this.mainWindow.getSelectedApplication(), this.mainWindow.IDParticipant,
                                                            false, this.isInEditMode, "", false, "", this, ref protocollForAdmin, ref protocolWindow);

                    if (this.typQueryDef == core.Enums.eTypQueryDef.WhereConditions)
                    {
                        this.drawMulticontrol1.setMultiControl(this.multiMax, rQry, this.mainWindow.contSelListQueries.getSelectedQuery(false),
                                                                this.typQueryDef, this.mainWindow.getSelectedApplication(), this.mainWindow.IDParticipant,
                                                                false, this.isInEditMode, "", false, "", this, ref protocollForAdmin, ref protocolWindow);
                    }

                    if (this.multiValueMin._controlType == core.Enums.eControlType.ComboBox)
                    {
                        //this.multiValueMin.controlData1.getSelListEntries(this.multiValueMin, rQry.QueryFldShort, core.Enums.eControlType.ComboBox, this.multiValueMin.ComboBox);
                        //if (this.typQueryDef == core.Enums.eTypQueryDef.WhereConditions)
                        //    this.multiValueMin.controlData1.getSelListEntries(this.multiMax, rQry.QueryFldShort, core.Enums.eControlType.ComboBox, this.multiValueMin.ComboBox);
                    }
                    this.multiValueMin.ownMCValue1.setValue(this.multiValueMin, rQry.ValueMin);
                    if (this.typQueryDef == core.Enums.eTypQueryDef.WhereConditions)
                    {
                        this.multiMax.ownMCValue1.setValue(this.multiMax, rQry.Max);
                    }

                    this.checkMCForParent(ref rQry, ref protocollForAdmin, ref protocolWindow);
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void checkMCForParent(ref dsAdmin.tblQueriesDefRow rQry, ref string protocollForAdmin, ref bool protocolWindow)
        {
            try
            {
                bool prevFound = false;
                UltraGridRow rQryPevGrid = null;
                dsAdmin.tblQueriesDefRow rQryPev = null;
                foreach (UltraGridRow rowGridQuery in this.gridQueryDef.Rows)
                {
                    DataRowView v = (DataRowView)rowGridQuery.ListObject;
                    dsAdmin.tblQueriesDefRow rSelQuery = (dsAdmin.tblQueriesDefRow)v.Row;

                    if (rSelQuery.IDGuid.Equals(rQry.IDGuid))
                    {
                        prevFound = true;
                    }
                    if (!prevFound)
                    {
                        rQryPev = rSelQuery;
                        rQryPevGrid = rowGridQuery;
                    }
                }

                if (rQryPev != null)
                {
                    this.drawMulticontrol1.setMultiControl(this.ownMultiControlParent, rQryPev, null,
                                                             this.typQueryDef, this.mainWindow.getSelectedApplication(), this.mainWindow.IDParticipant,
                                                             false, this.isInEditMode, "", false, "", this, ref protocollForAdmin, ref protocolWindow);

                    qs2.design.auto.print.doRelationshipEvaluation doRelationshipEvaluation1 = new qs2.design.auto.print.doRelationshipEvaluation();
                    doRelationshipEvaluation1.run(this.ownMultiControlParent.OwnFldShort.Trim(), ref this.ownMultiControlParent, this.multiValueMin, rQry);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contQueryDef.checkMCForParent: " + ex.ToString());
            }
        }

        public void saveMulticontrols(ref dsAdmin.tblQueriesDefRow rQry)
        {
            try
            {
                if (this.typQueryDef != core.Enums.eTypQueryDef.SelectFields)
                {
                    qs2.core.generic.retValue retValue1 = new qs2.core.generic.retValue();
                    retValue1 = this.multiValueMin.ownMCValue1.getValue(this.multiValueMin, false);
                    rQry.ValueMin = retValue1.valueStr;
                    rQry.ValueMinIDRes = this.multiValueMin.ownMCValue1.getValueTextCombo(this.multiValueMin);
                    if (this.typQueryDef == core.Enums.eTypQueryDef.WhereConditions)
                    {
                        retValue1 = new qs2.core.generic.retValue();
                        retValue1 = this.multiMax.ownMCValue1.getValue(this.multiMax, false);
                        rQry.Max = retValue1.valueStr;
                        rQry.MaxIDRes = this.multiMax.ownMCValue1.getValueTextCombo(this.multiMax);
                    }
                }

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void loadRes()
        {
            try
            {
                this.btnUp.Appearance.Image = getRes.getImage(QS2.Resources.getRes.ePicture.ico_up, 32, 32);
                this.btnDown.Appearance.Image = getRes.getImage(QS2.Resources.getRes.ePicture.ico_down, 32, 32);
                this.btnSearch2.Appearance.Image = getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);

                this.btnAnd.Text = qs2.core.language.sqlLanguage.getRes("And");
                this.btnOr.Text = qs2.core.language.sqlLanguage.getRes("Or");
                this.grpDetails.Text = qs2.core.language.sqlLanguage.getRes("DetailsForSelectedRow");
                this.lblSearch.Text = qs2.core.language.sqlLanguage.getRes("Search");

                UltraToolTipInfo info = new UltraToolTipInfo();
                info.ToolTipText = qs2.core.language.sqlLanguage.getRes("SearchField");
                info.ToolTipTitle = "";
                this.ultraToolTipManager1.SetUltraToolTip(this.btnSearch2, info);

                this.gridQueryDef.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNameText].Header.Caption = qs2.core.language.sqlLanguage.getRes("Field");
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.TypColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Typ");
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.SortColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Sort");

                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ChapterColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Chapter") + " (Key)";
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ChaptersColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Chapters2") + " (Keys)";
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.colChapterTransl].Header.Caption = qs2.core.language.sqlLanguage.getRes("Chapter");
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.colChaptersTransl].Header.Caption = qs2.core.language.sqlLanguage.getRes("Chapters2");

                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ConditionColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Condition");
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ValueMinColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("ValueMin");
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.MaxColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Max");
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.CombinationColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Combination");
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.CombinationEndColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Combination");
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("ControlType");
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.UserInputColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("UserInput");
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.LabelColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("OwnLabel");
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.QryTableColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Table");
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.IsSQLServerFieldColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("IsSQLServerField");
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.FunctionParColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("FunctionParameter");
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.freeSqlColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("freeSql");
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.QryColumnColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Column");
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ComboAsDropDownColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("ComboAsDropDown");
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ComboAsDropDownConditionColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("ComboAsDropDownCondition");
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.SpecialDefinitionColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("SpecialDefinitionMinValue");
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.SpecialDefinitionMaxColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("SpecialDefinitionMaxValue");
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.PlaceholderColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Placeholder");

                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.SortColumn.ColumnName].Hidden = true;

                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.UserInputColumn.ColumnName].Width = 90;
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.LabelColumn.ColumnName].Width = 135;
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.colChaptersTransl].Hidden = true;
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.colChapterTransl].Hidden = true;
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.colLineNr].Hidden = true;
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.colControlNr].Hidden = true;
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ChapterColumn.ColumnName].Hidden = true;
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ChaptersColumn.ColumnName].Hidden = true;
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ChaptersDoneColumn.ColumnName].Hidden = true;
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.colSerialNr].Hidden = true;
                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.PlaceholderColumn.ColumnName].Hidden = true;

                if (this.typQueryDef == core.Enums.eTypQueryDef.SelectFields)
                {
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.QryColumnColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.QryTableColumn.ColumnName].Hidden = true;

                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.freeSqlColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ConditionColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ValueMinColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.MaxColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.CombinationColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.CombinationEndColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.TypColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.UserInputColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.LabelColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.FunctionParColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.SpecialDefinitionColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.SpecialDefinitionMaxColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ComboAsDropDownColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ComboAsDropDownConditionColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.SortColumn.ColumnName].Hidden = false;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.SortColumn.ColumnName].Width = 46;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.colChaptersTransl].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.colChaptersTransl].Width = 200;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.colChapterTransl].Hidden = false;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.colChapterTransl].Width = 200;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.PlaceholderColumn.ColumnName].Hidden = false;

                    if (qs2.core.ENV.AdminSecure)
                    {
                        this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.colChaptersTransl].Hidden = false;
                        this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.colChaptersTransl].Width = 200;

                        this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ChapterColumn.ColumnName].Hidden = false;
                        this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ChaptersColumn.ColumnName].Hidden = false;
                        this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ChaptersDoneColumn.ColumnName].Hidden = false;


                        this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.colLineNr].Hidden = false;
                        this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.colLineNr].Width = 60;

                        this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.colControlNr].Hidden = false;
                        this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.colControlNr].Width = 65;

                        this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.colSerialNr].Hidden = false;

                        this.gridQueryDef.DisplayLayout.AutoFitStyle = AutoFitStyle.None;

                        //this.gridQueryDef.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
                    }
                    else
                    {
                        this.gridQueryDef.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
                    }

                    this.panelCombinations.Visible = false;
                    this.gridQueryDef.DisplayLayout.Bands[0].ColHeadersVisible = true;
                    //this.gridQueryDef.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNameText].Header.Caption = qs2.core.language.sqlLanguage.getRes("Fields");
                }
                else if (this.typQueryDef == core.Enums.eTypQueryDef.InputParameters)
                {
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.QryColumnColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.QryTableColumn.ColumnName].Hidden = false;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.QryTableColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.QryTableColumn.ColumnName].CellButtonAppearance.Image = getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);

                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.freeSqlColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ValueMinColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("DefaultValue");
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ConditionColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.MaxColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.CombinationColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.CombinationEndColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.TypColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].Hidden = false;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.UserInputColumn.ColumnName].Hidden = false;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.FunctionParColumn.ColumnName].Hidden = false;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.SpecialDefinitionColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.SpecialDefinitionMaxColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ComboAsDropDownColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ComboAsDropDownConditionColumn.ColumnName].Hidden = true;
                    this.panelCombinations.Visible = false;

                    //this.btnAdd.OwnTooltipText = qs2.core.language.sqlLanguage.getRes("AddParameter");
                    //this.btnAddFctPar.OwnTooltipText = qs2.core.language.sqlLanguage.getRes("AddFunctionParameter");
                }
                else if (this.typQueryDef == core.Enums.eTypQueryDef.WhereConditions)
                {
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.freeSqlColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.TypColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].Hidden = true;

                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.QryColumnColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.QryTableColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.FunctionParColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.SpecialDefinitionColumn.ColumnName].Hidden = false;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.SpecialDefinitionMaxColumn.ColumnName].Hidden = false;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ComboAsDropDownColumn.ColumnName].Hidden = false;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ComboAsDropDownConditionColumn.ColumnName].Hidden = false;
                    this.panelCombinations.Visible = true;
                }
                else if (this.typQueryDef == core.Enums.eTypQueryDef.Joins)
                {
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.freeSqlColumn.ColumnName].Hidden = false;

                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.UserInputColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.LabelColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ValueMinColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.MaxColumn.ColumnName].Hidden = true;
                    //this.gridQueryDef.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNameText].Hidden = true;

                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.TypColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.FunctionParColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.SpecialDefinitionColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.SpecialDefinitionMaxColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ComboAsDropDownColumn.ColumnName].Hidden = true;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ComboAsDropDownConditionColumn.ColumnName].Hidden = true;
                    this.panelCombinations.Visible = true;

                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNameText].Header.Caption = qs2.core.language.sqlLanguage.getRes("Translation");
                }

                this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.IsSQLServerFieldColumn.ColumnName].Hidden = true;

                this.gridQueryDef.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNameText].CellButtonAppearance.Image = getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);

                this.deleteFieldToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("DeleteFieldSelection");
                this.deleteFieldToolStripMenuItem.Image = getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32);
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void loadData(dsAdmin.tblSelListEntriesRow rSelectedSelList)
        {
            try
            {
                this.rSelList = rSelectedSelList;
                this.dsAdmin1.tblQueriesDef.Rows.Clear();
                this.sqlAdmin1.getQueriesDef(rSelList.ID, this.dsAdmin1, core.vb.sqlAdmin.eTypSelQueryDef.typ, this.typQueryDef, qs2.core.license.doLicense.eApp.ALL.ToString(), this.mainWindow.getSelectedApplication());
                this.gridQueryDef.Refresh();
                this.translateGrid();

                this.multiValueMin.Visible = false;
                this.multiMax.Visible = false;

                this.gridQueryDef.DisplayLayout.Bands[0].SortedColumns.Clear();
                this.gridQueryDef.DisplayLayout.Bands[0].SortedColumns.Add(this.dsAdmin1.tblQueriesDef.SortColumn.ColumnName, false);
                this.gridQueryDef.Selected.Rows.Clear();
                this.gridQueryDef.ActiveRow = null;

                this.mainWindow.setNumberForSelectedControl(this.typQueryDef, (this.typQueryDef == core.Enums.eTypQueryDef.Joins ? this.dsAdmin1.tblQueriesDef.Rows.Count / 2 : this.dsAdmin1.tblQueriesDef.Rows.Count));
                this.setRigths(this.rSelList);

                this.txtSearch.Text = "";

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void setRigths(dsAdmin.tblSelListEntriesRow rSelectedSelList)
        {
            try
            {
                this.btnAdd.Visible = true;
                this.btnDel.Visible = true;
            }
            catch (Exception ex)
            {
                throw new Exception("setRigths: " + ex.ToString());
            }
        }

        public void translateGrid()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = qs2.core.db.ERSystem.businessFramework.getDBContext())
                {
                    foreach (UltraGridRow rowGridQuery in this.gridQueryDef.Rows)
                    {
                        db.Configuration.LazyLoadingEnabled = false;

                        DataRowView v = (DataRowView)rowGridQuery.ListObject;
                        dsAdmin.tblQueriesDefRow rSelQuery = (dsAdmin.tblQueriesDefRow)v.Row;

                        rowGridQuery.CellAppearance.BackColor = System.Drawing.Color.White;
                        rowGridQuery.CellAppearance.ForeColor = System.Drawing.Color.Black;

                        qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;
                        string resFoundLevel = qs2.core.language.sqlLanguage.getRes(rSelQuery.QryColumn, core.Enums.eResourceType.Label, this.mainWindow.IDParticipant, rSelQuery.ApplicationOwn, ref rLangFoundReturn, true, true, core.language.sqlLanguage.eLanguage.NoText, true);
                        if (resFoundLevel.Trim() == "")
                            rowGridQuery.Cells[qs2.core.generic.columnNameText].Value = rSelQuery.QryColumn;
                        else
                            rowGridQuery.Cells[qs2.core.generic.columnNameText].Value = resFoundLevel;

                        rowGridQuery.Cells[this.colSerialNr].Value = -1;
                        rowGridQuery.Cells[this.colLineNr].Value = -1;
                        rowGridQuery.Cells[this.colControlNr].Value = -1;

                        if (typQueryDef == core.Enums.eTypQueryDef.SelectFields && !rSelQuery.ChaptersDone)
                        {
                            rowGridQuery.Cells[this.colChaptersTransl].Value = "";
                            rowGridQuery.Cells[this.colChapterTransl].Value = "";
                            rSelQuery.Chapter = "";
                            rSelQuery.Chapters = "";

                            if (!rSelQuery.IsCriteriaFldShortNull())
                            {
                                var tChapters = (from o in db.tblSelListEntriesObj
                                                 join sl in db.tblSelListEntries on o.IDSelListEntry equals sl.ID
                                                 join slg in db.tblSelListGroup on sl.IDGroup equals slg.ID
                                                 join c in db.tblCriteria on o.FldShort equals c.FldShort
                                                 where c.FldShort == o.FldShort && c.IDApplication == o.IDApplication &&
                                                        slg.IDApplication == rSelQuery.ApplicationOwn && o.typIDGroup == "Criterias" && o.FldShort == rSelQuery.CriteriaFldShort && o.IDApplication == rSelQuery.CriteriaApplication
                                                 select new { sl.IDRessource, sl.IDOwnStr, sl.ID, o.IDGuid }).ToList();

                                foreach (var rChapt in tChapters)
                                {
                                    string resChaptFound = qs2.core.language.sqlLanguage.getRes(rChapt.IDRessource);
                                    rSelQuery.Chapters += rChapt.IDOwnStr + ";";
                                    if (String.IsNullOrEmpty(resChaptFound))
                                        rowGridQuery.Cells[this.colChaptersTransl].Value += rChapt.IDOwnStr + ";";
                                    else
                                        rowGridQuery.Cells[this.colChaptersTransl].Value += resChaptFound + ";";
                                    if (string.IsNullOrEmpty(rSelQuery.Chapter))
                                    {
                                        rSelQuery.Chapter = rChapt.IDOwnStr;
                                        if (String.IsNullOrEmpty(resChaptFound))
                                            rowGridQuery.Cells[this.colChapterTransl].Value = rChapt.IDOwnStr;
                                        else
                                            rowGridQuery.Cells[this.colChapterTransl].Value = resChaptFound;
                                    }
                                }
                            }
                            else
                            {
                                var tChapters = (from o in db.tblSelListEntriesObj
                                                 join sl in db.tblSelListEntries on o.IDSelListEntry equals sl.ID
                                                 join slg in db.tblSelListGroup on sl.IDGroup equals slg.ID
                                                 join c in db.tblCriteria on o.FldShort equals c.FldShort
                                                 where c.FldShort == o.FldShort && c.IDApplication == o.IDApplication &&
                                                        slg.IDApplication == rSelQuery.ApplicationOwn && o.typIDGroup == "Criterias" && o.FldShort == rSelQuery.QryColumn &&
                                                 (o.IDApplication == qs2.core.license.doLicense.rApplication.IDApplication || o.IDApplication == "ALL")
                                                 select new { sl.IDRessource, sl.IDOwnStr, sl.ID, o.IDGuid }).ToList();

                                foreach (var rChapt in tChapters)
                                {
                                    string resChaptFound = qs2.core.language.sqlLanguage.getRes(rChapt.IDRessource);
                                    rSelQuery.Chapters += rChapt.IDOwnStr + ";";
                                    if (String.IsNullOrEmpty(resChaptFound))
                                        rowGridQuery.Cells[this.colChaptersTransl].Value += rChapt.IDOwnStr + ";";
                                    else
                                        rowGridQuery.Cells[this.colChaptersTransl].Value += resChaptFound + ";";
                                    if (string.IsNullOrEmpty(rSelQuery.Chapter))
                                    {
                                        rSelQuery.Chapter = rChapt.IDOwnStr;
                                        if (String.IsNullOrEmpty(resChaptFound))
                                            rowGridQuery.Cells[this.colChapterTransl].Value = rChapt.IDOwnStr;
                                        else
                                            rowGridQuery.Cells[this.colChapterTransl].Value = resChaptFound;
                                    }
                                }
                            }
                        }
                        else if (typQueryDef == core.Enums.eTypQueryDef.SelectFields && rSelQuery.ChaptersDone)
                        {
                            rowGridQuery.Cells[this.colChaptersTransl].Value = "";
                            rowGridQuery.Cells[this.colChapterTransl].Value = "";

                            this.translateChapter(db, rowGridQuery, rSelQuery.Chapter, rSelQuery.ApplicationOwn, false);

                            System.Collections.Generic.List<string> lChapters = qs2.core.generic.readStrVariables(rSelQuery.Chapters);
                            foreach (string chapt in lChapters)
                                this.translateChapter(db, rowGridQuery, chapt, rSelQuery.ApplicationOwn, true);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contQueryDef.translateGrid: " + ex.ToString());
            }
        }
        public void translateChapter(PMDS.db.Entities.ERModellPMDSEntities db, UltraGridRow rGrid, string Chapter, string Application, bool doChapters)
        {
            try
            {
                var rSelListEntryChapter = (from o in db.tblSelListEntries
                                            join slg in db.tblSelListGroup on o.IDGroup equals slg.ID
                                            where slg.IDApplication == Application && (slg.IDGroupStr == "Chapters0" || slg.IDGroupStr == "Chapters1") &&
                                            o.IDOwnStr == Chapter
                                            select new { o.IDRessource, o.IDOwnStr, o.ID, o.IDGuid }).ToList().FirstOrDefault();

                if (rSelListEntryChapter != null)
                {
                    string resChaptFound = qs2.core.language.sqlLanguage.getRes(rSelListEntryChapter.IDRessource);
                    if (!doChapters)
                    {
                        if (string.IsNullOrEmpty(resChaptFound))
                            rGrid.Cells[this.colChapterTransl].Value = Chapter;
                        else
                            rGrid.Cells[this.colChapterTransl].Value = resChaptFound;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(resChaptFound))
                            rGrid.Cells[this.colChaptersTransl].Value += Chapter + ";";
                        else
                            rGrid.Cells[this.colChaptersTransl].Value += resChaptFound + ";";
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contQueryDef.translateChapter: " + ex.ToString());
            }
        }

        public void selectChapter()
        {
            try
            {
                UltraGridRow selRowGrid = null;
                qs2.core.vb.dsAdmin.tblQueriesDefRow rSelRow = this.getSelectedRow(true, ref selRowGrid);
                if (rSelRow != null)
                {
                    frmQryAdminSelectChapter frmQryAdminSelectChapter1 = new frmQryAdminSelectChapter();
                    frmQryAdminSelectChapter1.initControl(rSelRow.Chapters, rSelRow.Chapter, rSelRow.ApplicationOwn);
                    frmQryAdminSelectChapter1.ShowDialog(this);
                    if (!frmQryAdminSelectChapter1.contQryAdminSelectChapter1.abort)
                    {
                        rSelRow.Chapter = frmQryAdminSelectChapter1.contQryAdminSelectChapter1.SelChapterKey;
                        selRowGrid.Cells[this.colChapterTransl].Value = frmQryAdminSelectChapter1.contQryAdminSelectChapter1.SelChapterTransl;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contQueryDef.selectChapter: " + ex.ToString());
            }
        }

        public void doToolTipRow(UltraGridRow rowGridQuery, dsAdmin.tblQueriesDefRow rSelQuery)
        {
            try
            {
                if (rSelQuery.Placeholder)
                {
                    rowGridQuery.ToolTipText += qs2.core.language.sqlLanguage.getRes("Placeholder");
                }
                else
                {
                    string txtValueMinMax = rowGridQuery.Cells[this.dsAdmin1.tblQueriesDef.ValueMinIDResColumn.ColumnName].Value.ToString();
                    if (txtValueMinMax.Trim() != "")
                        rowGridQuery.ToolTipText += qs2.core.language.sqlLanguage.getRes("TranslationValueMin", true, true) + ": " + txtValueMinMax.Trim();

                    txtValueMinMax = rowGridQuery.Cells[this.dsAdmin1.tblQueriesDef.MaxIDResColumn.ColumnName].Value.ToString();
                    if (txtValueMinMax.Trim() != "")
                        rowGridQuery.ToolTipText += qs2.core.generic.lineBreak + qs2.core.language.sqlLanguage.getRes("TranslationMax", true, true) + ": " + txtValueMinMax.Trim();

                    rowGridQuery.ToolTipText += qs2.core.generic.lineBreak + qs2.core.language.sqlLanguage.getRes("IsSQLServerField", true, true) + ": " + (rSelQuery.IsSQLServerField ? "1" : "0");

                    this.dsAdmin1.tblCriteria.Rows.Clear();
                    if (!rSelQuery.QryColumn.Trim().Equals(""))
                    {
                        rowGridQuery.ToolTipText += qs2.core.generic.lineBreak + qs2.core.language.sqlLanguage.getRes("Table", true, true) + ": " + rSelQuery.QryTable;
                        rowGridQuery.ToolTipText += qs2.core.generic.lineBreak + qs2.core.language.sqlLanguage.getRes("Field", true, true) + ": " + rSelQuery.QryColumn;
                        if (!rSelQuery.IsControlTypeNull())
                            rowGridQuery.ToolTipText += qs2.core.generic.lineBreak + qs2.core.language.sqlLanguage.getRes("ControlType", true, true) + ": " + rSelQuery.ControlType;

                        if (!rSelQuery.IsCriteriaFldShortNull())
                        {
                            dsAdmin.tblCriteriaRow[] arrCriterias = this.sqlAdmin1.getCriterias(this.dsAdmin1, sqlAdmin.eTypSelCriteria.idRam, rSelQuery.CriteriaFldShort, rSelQuery.CriteriaApplication, false, false, false, "", "", false);
                            //rowGridQuery.ToolTipText += qs2.core.language.sqlLanguage.getRes("Table") + ": " + arrCriterias[0].SourceTable;
                            //rowGridQuery.ToolTipText += qs2.core.generic.lineBreak + qs2.core.language.sqlLanguage.getRes("FldShort") + ": " + arrCriterias[0].FldShort;
                            rowGridQuery.ToolTipText += qs2.core.generic.lineBreak + qs2.core.language.sqlLanguage.getRes("ControlType", true, true) + ": " + arrCriterias[0].ControlType;

                            rowGridQuery.ToolTipText += qs2.core.generic.lineBreak + qs2.core.language.sqlLanguage.getRes("Chapters", true, true) + ":" + qs2.core.generic.lineBreak;
                            this.dsAdmin1.tblSelListEntriesObj.Rows.Clear();
                            this.dsAdmin1.tblSelListEntries.Rows.Clear();
                            this.sqlAdmin1.getSelListEntrysObj(0, core.vb.sqlAdmin.eDbTypAuswObj.Criterias, "", this.dsAdmin1, core.vb.sqlAdmin.eTypAuswahlObj.allCriterias, rSelQuery.CriteriaApplication, 0, rSelQuery.CriteriaFldShort);
                            foreach (dsAdmin.tblSelListEntriesObjRow rObj in this.dsAdmin1.tblSelListEntriesObj)
                            {
                                dsAdmin.tblSelListEntriesRow rSelListEntryFound = this.sqlAdmin1.getSelListEntrysRow("", sqlAdmin.eTypAuswahlList.id, qs2.core.license.doLicense.eApp.ALL.ToString(), rSelQuery.CriteriaApplication, "", 0, "", rObj.IDSelListEntry);
                                qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;
                                string resFoundLevel = qs2.core.language.sqlLanguage.getRes(rSelListEntryFound.IDRessource, core.Enums.eResourceType.Label, this.mainWindow.IDParticipant, rSelQuery.CriteriaApplication, ref rLangFoundReturn);
                                rowGridQuery.ToolTipText += "       ";
                                if (rSelListEntryFound.IDRessource.Trim() == "")
                                    rowGridQuery.ToolTipText += rSelListEntryFound.IDRessource;
                                else
                                    rowGridQuery.ToolTipText += resFoundLevel;
                                rowGridQuery.ToolTipText += qs2.core.generic.lineBreak;
                            }

                            rowGridQuery.ToolTipText += qs2.core.generic.lineBreak + qs2.core.language.sqlLanguage.getRes("FldShort", true, true) + ": " + arrCriterias[0].FldShort;
                            rowGridQuery.ToolTipText += qs2.core.generic.lineBreak + qs2.core.language.sqlLanguage.getRes("Application", true, true) + ": " + arrCriterias[0].IDApplication;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contQueryDef.doToolTipRow: " + ex.ToString());
            }
        }
        public void clear()
        {
            try
            {
                this.dsAdmin1.tblQueriesDef.Rows.Clear();
                this.gridQueryDef.Refresh();
            }
            catch (Exception ex)
            {
                throw new Exception("contQueryDef.clear: " + ex.ToString());
            }
        }
        public bool save(qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListQuery)
        {
            try
            {
                this.gridQueryDef.UpdateData();

                string protocoll = "";
                this.clearErrorProviderOnRowHeader();
                bool bOkValidateData = this.validateData();

                bool bOkCheckSysColumnsInDb = true;                     //this.checkSysColumnsInDb(rSelListQuery, ref protocoll);
                if (rSelList.TypeQry.Trim().Equals(qs2.core.print.print.eQueryType.SimpleView.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    if (this.typQueryDef == core.Enums.eTypQueryDef.SelectFields || this.typQueryDef == core.Enums.eTypQueryDef.WhereConditions)
                    {
                        this.checkSysColumnsInDb(rSelListQuery, ref protocoll, true);
                        //bOkCheckSysColumnsInDb = this.checkSysColumnsInDb(rSelListQuery, ref protocoll, true);
                    }
                }
                else if (rSelList.TypeQry.Trim().Equals(qs2.core.print.print.eQueryType.SimpleFunction.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    if (this.typQueryDef == core.Enums.eTypQueryDef.SelectFields)
                    {
                        this.checkSysColumnsInDb(rSelListQuery, ref protocoll, false);
                        //bOkCheckSysColumnsInDb = this.checkSysColumnsInDb(rSelListQuery, ref protocoll, false);
                    }
                }

                bool bOkCheckForDoubleFields = true;
                if (rSelList.TypeQry.Trim().Equals(qs2.core.print.print.eQueryType.SimpleView.ToString(), StringComparison.OrdinalIgnoreCase) ||
                    rSelList.TypeQry.Trim().Equals(qs2.core.print.print.eQueryType.SimpleFunction.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    if (this.typQueryDef == core.Enums.eTypQueryDef.SelectFields)
                    {
                        this.checkForDoubleFields(rSelListQuery, ref protocoll, core.Enums.eTypQueryDef.SelectFields);
                        //bOkCheckForDoubleFields = this.checkForDoubleFields(rSelListQuery, ref protocoll, core.Enums.eTypQueryDef.SelectFields);
                    }
                }

                if (protocoll.Trim() != "")
                {
                    string txt = qs2.core.language.sqlLanguage.getRes("InfoAddFieldsToQuery") + "\r\n" + "\r\n" +
                            protocoll.Trim() + "!";
                    //qs2.core.generic.showMessageBox(txt, MessageBoxButtons.OK, "");
                    frmProtocol frmProtocol1 = new frmProtocol();
                    frmProtocol1.initControl();
                    frmProtocol1.Text = qs2.core.language.sqlLanguage.getRes("ProtocollAddFieldsToQuery");
                    qs2.core.ENV.lstOpendChildForms.Add(frmProtocol1);
                    frmProtocol1.Show();
                    frmProtocol1.ContProtocol1.setText(txt);
                }

                if (!bOkValidateData || !bOkCheckSysColumnsInDb || !bOkCheckForDoubleFields)
                {
                    return false;
                }

                this.sqlAdmin1.daQueriesDef.Update(this.dsAdmin1.tblQueriesDef);
                this.mainWindow.setNumberForSelectedControl(this.typQueryDef, this.dsAdmin1.tblQueriesDef.Rows.Count);

                this.multiValueMin.Visible = false;
                this.multiMax.Visible = false;

                return true;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return false;
            }
        }
        public bool validateData()
        {
            try
            {
                foreach (UltraGridRow rowQuery in this.gridQueryDef.Rows)
                {
                    DataRowView v = (DataRowView)rowQuery.ListObject;
                    dsAdmin.tblQueriesDefRow rSelQuery = (dsAdmin.tblQueriesDefRow)v.Row;

                    rSelQuery.SetColumnError(rowQuery.Cells[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].Column.Index, "");
                    if (rSelQuery.RowState != DataRowState.Deleted)
                    {
                        if (this.typQueryDef == core.Enums.eTypQueryDef.SelectFields)
                        {
                            rSelQuery.ValueMin = "";
                            rSelQuery.ValueMinIDRes = "";
                            rSelQuery.Max = "";
                            rSelQuery.MaxIDRes = "";
                        }
                        else if (this.typQueryDef == core.Enums.eTypQueryDef.InputParameters)
                        {
                            if (rSelQuery.QryColumn.Trim().Equals("") && rSelQuery.IsControlTypeNull())
                            {
                                string txt = qs2.core.language.sqlLanguage.getRes("NoControlType") + "!";
                                this.setTabVisible();
                                rSelQuery.SetColumnError(rowQuery.Cells[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].Column.Index, txt);
                                qs2.core.generic.showMessageBox(txt, MessageBoxButtons.OK, "");
                                rowQuery.Selected = true;
                                return false;
                            }

                            if (!rSelQuery.QryColumn.Trim().Equals(""))
                            {
                                //rSelQuery.SetControlTypeNull();
                            }

                            rSelQuery.Max = "";
                            rSelQuery.MaxIDRes = "";

                            //if (rowQuery.Cells[qs2.core.generic.columnNameText].Value == "")
                            //{
                            //    string txt = qs2.core.language.sqlLanguage.getRes("NoFieldSelected") + "!";
                            //    this.setTabVisible();
                            //    rSelQuery.SetColumnError(rowQuery.Cells[qs2.core.generic.columnNameText].Column.Index, txt);
                            //    qs2.core.generic.showMessageBox(txt, MessageBoxButtons.OK, "");
                            //    rowQuery.Selected = true;
                            //    return false;
                            //}
                        }
                        else if (this.typQueryDef == core.Enums.eTypQueryDef.WhereConditions)
                        {
                            if (rSelQuery.Condition.Trim() != qs2.core.sqlTxt.between.Trim() && rSelQuery.Condition.Trim() != qs2.core.sqlTxt.notBetween.Trim())
                            {
                                rSelQuery.Max = "";
                                rSelQuery.MaxIDRes = "";
                            }
                            if (rSelQuery.Condition.Trim() == qs2.core.sqlTxt.isNull.Trim() || rSelQuery.Condition.Trim() == qs2.core.sqlTxt.isNotNull.Trim())
                            {
                                rSelQuery.ValueMin = "";
                                rSelQuery.ValueMinIDRes = "";
                                rSelQuery.Max = "";
                                rSelQuery.MaxIDRes = "";
                                rSelQuery.UserInput = false;
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return false;
            }
        }
        public bool checkSysColumnsInDb(dsAdmin.tblSelListEntriesRow rSelListQuery, ref string protocoll, bool StripSchema)
        {
            try
            {
                bool bOK = true;
                foreach (UltraGridRow rowQuery in this.gridQueryDef.Rows)
                {
                    DataRowView v = (DataRowView)rowQuery.ListObject;
                    dsAdmin.tblQueriesDefRow rSelQuery = (dsAdmin.tblQueriesDefRow)v.Row;

                    rSelQuery.SetColumnError(rowQuery.Cells[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].Column.Index, "");
                    if (rSelQuery.RowState != DataRowState.Deleted)
                    {
                        if (this.typQueryDef == core.Enums.eTypQueryDef.SelectFields || this.typQueryDef == core.Enums.eTypQueryDef.WhereConditions)
                        {
                            if (!rSelQuery.Placeholder)
                            {
                                if (rSelQuery.QryTable.Trim() == "")
                                {
                                    bOK = false;
                                    this.doErrorProviderGridForColumn(rSelQuery, rowQuery, false, ref protocoll, "ColumnCouldNotUsedNotExistsInDb", false);
                                }
                                else
                                {
                                    bool colExistsInSysCatalog = this.checkSysColumnExists(rSelQuery.QryColumn, rSelQuery.QryTable, ref this.typQueryDef, rSelListQuery.TypeQry.Trim(), StripSchema);
                                    if (!colExistsInSysCatalog)
                                    {
                                        bOK = false;
                                        //this.doErrorProviderGridForColumn(rSelQuery, rowQuery, false, ref protocoll, "ColumnCouldNotUsedNotExistsInDb", false);
                                    }
                                }
                            }
                        }
                    }
                }
                return bOK;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return false;
            }
        }
        public bool checkForDoubleFields(dsAdmin.tblSelListEntriesRow rSelListQuery, ref string protocoll, core.Enums.eTypQueryDef TypQueryDefToCheck)
        {
            try
            {
                bool bOK = true;
                if (this.typQueryDef == core.Enums.eTypQueryDef.SelectFields || this.typQueryDef == core.Enums.eTypQueryDef.WhereConditions)
                {
                    foreach (UltraGridRow rowQuery in this.gridQueryDef.Rows)
                    {
                        DataRowView v = (DataRowView)rowQuery.ListObject;
                        dsAdmin.tblQueriesDefRow rSelQuery = (dsAdmin.tblQueriesDefRow)v.Row;

                        rSelQuery.SetColumnError(rowQuery.Cells[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].Column.Index, "");
                        if (rSelQuery.RowState != DataRowState.Deleted)
                        {
                            foreach (UltraGridRow rowQuery2nd in this.gridQueryDef.Rows)
                            {
                                DataRowView v2nd = (DataRowView)rowQuery2nd.ListObject;
                                dsAdmin.tblQueriesDefRow rSelQuery2nd = (dsAdmin.tblQueriesDefRow)v2nd.Row;

                                rSelQuery.SetColumnError(rowQuery.Cells[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].Column.Index, "");
                                if (rSelQuery.RowState != DataRowState.Deleted)
                                {
                                    if (this.typQueryDef == TypQueryDefToCheck)
                                    {
                                        if (!rSelQuery.IDGuid.Equals(rSelQuery2nd.IDGuid))
                                        {
                                            if (rSelQuery.QryColumn.Trim().ToLower().Equals((rSelQuery2nd.QryColumn).Trim().ToLower()) &&
                                                rSelQuery.QryTable.Trim().ToLower().Equals((rSelQuery2nd.QryTable).Trim().ToLower()))
                                            {
                                                bOK = false;
                                                this.doErrorProviderGridForColumn(rSelQuery, rowQuery, false, ref protocoll, "ColumnCouldNotUsedExistsDoubledInQuery", false);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return bOK;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return false;
            }
        }
        public void clearErrorProviderOnRowHeader()
        {
            try
            {
                foreach (UltraGridRow rowQuery in this.gridQueryDef.Rows)
                {
                    rowQuery.RowSelectorAppearance.Image = null;
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void doErrorProviderGridForColumn(dsAdmin.tblQueriesDefRow rSelQuery, UltraGridRow rowQuery, bool withMsgBox, ref string protocoll,
                                                    string IDRessourceMsg, bool addToProtocol)
        {
            try
            {
                string NameField = "";
                if (rowQuery.Cells[qs2.core.generic.columnNameText].Value != null)
                {
                    NameField = rowQuery.Cells[qs2.core.generic.columnNameText].Value.ToString();
                }
                else
                {
                    NameField = rSelQuery.QryColumn.Trim();
                }

                string ProtocollEntry = qs2.core.language.sqlLanguage.getRes("Field") + " " + NameField + ": " +
                             qs2.core.language.sqlLanguage.getRes(IDRessourceMsg) + "";
                if (addToProtocol)
                {
                    protocoll += ProtocollEntry + "\r\n";
                }

                //this.setTabVisible();
                rowQuery.RowSelectorAppearance.Image = QS2.Resources.getRes.getImage(getRes.Allgemein2.ico_Wichtig, 32, 32);
                //rSelQuery.SetColumnError(rowQuery.Cells[this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName].Column.Index, txt);
                if (withMsgBox)
                {
                    qs2.core.generic.showMessageBox(ProtocollEntry, MessageBoxButtons.OK, "");
                }
                rowQuery.Selected = true;
            }
            catch (Exception ex)
            {
                throw new Exception("doErrorProviderGridForColumn: " + ex.ToString());
            }
        }
        public void setTabVisible()
        {
            try
            {
                this.mainWindow.ultraTabControlFields.SelectedTab = this.mainWindow.ultraTabControlFields.Tabs[this.typQueryDef.ToString()];
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void edit(bool bEdit)
        {
            try
            {
                this.isInEditMode = bEdit;

                //if (this.typQueryDef == core.Enums.eTypQueryDef.SelectFields)
                //{
                //}
                //else if (this.typQueryDef == core.Enums.eTypQueryDef.InputParameters)
                //{
                //}
                //else if (this.typQueryDef == core.Enums.eTypQueryDef.WhereConditions)
                //{
                //}

                this.btnAdd.Enabled = bEdit;

                this.btnDel.Enabled = bEdit;
                this.btnDown.Enabled = bEdit;
                this.btnUp.Enabled = bEdit;

                if (!bEdit)
                    this.panelCombinations.Visible = bEdit;

                if (this.isInEditMode)
                {
                    this.gridQueryDef.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ConditionColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNameText].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
                }
                else
                {
                    this.gridQueryDef.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblQueriesDef.ConditionColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNameText].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Default;

                }

                if (this.typQueryDef == core.Enums.eTypQueryDef.InputParameters)
                    deleteFieldToolStripMenuItem.Visible = this.isInEditMode;
                else
                    deleteFieldToolStripMenuItem.Visible = false;

                this.multiValueMin.setEditable(bEdit, false);
                this.multiMax.setEditable(bEdit, false);
                this.ownMultiControlParent.setEditable(bEdit, false);

                if (this.typQueryDef == core.Enums.eTypQueryDef.SelectFields)
                {
                    this.selectChapterToolStripMenuItem.Visible = this.isInEditMode;
                    this.checkChaptersToolStripMenuItem.Visible = this.isInEditMode;
                    this.sortByChapterToolStripMenuItem.Visible = this.isInEditMode;
                }
                else
                {
                    this.selectChapterToolStripMenuItem.Visible = false;
                    this.checkChaptersToolStripMenuItem.Visible = false;
                    this.sortByChapterToolStripMenuItem.Visible = false;
                }

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void add(bool add, bool searchCriterias, ref string protocollForAdmin, ref bool protocolWindow, bool SelectionWithoutClosing)
        {
            try
            {
                if (this.rSelList != null)
                {
                    string protocoll = "";
                    bool abort = false;
                    if (searchCriterias)
                    {
                        qs2.sitemap.vb.frmSelectField frmSelect = new qs2.sitemap.vb.frmSelectField();
                        frmSelect.typpUI = sitemap.workflowAssist.contInfoFieldDB.eTypUI.selectionColumns;

                        frmSelect.ContSelectField1.SelectionWithoutClosing = SelectionWithoutClosing;
                        frmSelect.ContSelectField1.ContSelChaptFldShort1.SelectionWithoutClosing = SelectionWithoutClosing;
                        frmSelect.ContSelectField1.ContInfoFieldDB1.SelectionWithoutClosing = SelectionWithoutClosing;
                        frmSelect.ContSelectField1.add = add;
                        frmSelect.ContSelectField1.ContInfoFieldDB1.add = add;
                        frmSelect.ContSelectField1.ContSelChaptFldShort1.add = add;

                        if (SelectionWithoutClosing)
                        {
                            frmSelect.ContSelectField1.ContInfoFieldDB1.delOnAddWithoutClosing += new sitemap.workflowAssist.contInfoFieldDB.onAddWithoutClosing(this.addDblClick);
                            frmSelect.ContSelectField1.ContSelChaptFldShort1.delOnAddWithoutClosing += new sitemap.vb.contSelChaptFldShort.onAddWithoutClosing(this.addDblClick);
                        }
                        else
                        {

                        }

                        frmSelect.ContSelectField1.modeQueryUI = this.mainWindow.typeQuery;
                        frmSelect.ContSelectField1.rSelQuery = rSelList;
                        frmSelect.ContSelectField1.SelectedTypQueryDef = this.typQueryDef.ToString();

                        if (rSelList.TypeQry.Trim().Equals(qs2.core.print.print.eQueryType.SimpleView.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            frmSelect.ContSelectField1.lstTablesToShow = new System.Collections.ArrayList();
                            frmSelect.ContSelectField1.lstTablesToShow.Add(rSelList._Table);
                        }
                        else if (rSelList.TypeQry.Trim().Equals(qs2.core.print.print.eQueryType.SimpleFunction.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            frmSelect.ContSelectField1.lstTablesToShow = new System.Collections.ArrayList();
                            string tableTmp = rSelList._Table;
                            tableTmp = tableTmp.Substring(0, 4) + "v" + tableTmp.Substring(4, tableTmp.Length - 4);
                            frmSelect.ContSelectField1.lstTablesToShow.Add(tableTmp);
                            if (this.mainWindow.typeQuery == core.Enums.eTypeQuery.User)
                            {
                                frmSelect.ContSelectField1.doUnvisibleAllOtherTables = true;
                            }
                            else
                            {
                                frmSelect.ContSelectField1.doUnvisibleAllOtherTables = true;
                            }
                        }

                        frmSelect.ContSelectField1.ContSelChaptFldShort1.modeQueryUI = this.mainWindow.typeQuery;
                        frmSelect.ContSelectField1.ContSelChaptFldShort1.rSelQuery = rSelList;
                        frmSelect.ContSelectField1.ContSelChaptFldShort1.SelectedTypQueryDef = this.typQueryDef.ToString();

                        frmSelect.ContSelectField1.ContInfoFieldDB1.modeQueryUI = this.mainWindow.typeQuery;
                        frmSelect.ContSelectField1.ContInfoFieldDB1.rSelQuery = rSelList;
                        frmSelect.ContSelectField1.ContInfoFieldDB1.SelectedTypQueryDef = this.typQueryDef.ToString();

                        frmSelect.ContSelectField1.IDApplication = this.mainWindow.getSelectedApplication();
                        frmSelect.ContSelectField1.IDParticipant = qs2.core.license.doLicense.eApp.ALL.ToString();
                        frmSelect.ShowDialog(this);
                        abort = frmSelect.ContSelectField1.abort;
                        // Sel0

                        if (!abort)
                        {
                            if (!SelectionWithoutClosing)
                            {
                                if (frmSelect.ContSelectField1.selectedTab == sitemap.vb.contSelectField.eTab.Chapter)
                                {
                                    qs2.core.vb.dsAdmin.tblQueriesDefRow rAddedEditedLast = null;
                                    foreach (UltraGridRow selRowGridCriteria in frmSelect.ContSelectField1.ContSelChaptFldShort1.selRowsGrid)
                                    {
                                        DataRowView v = (DataRowView)selRowGridCriteria.ListObject;
                                        qs2.core.vb.dsAdmin.tblCriteriaRow rSelectedCriteria = (qs2.core.vb.dsAdmin.tblCriteriaRow)v.Row;
                                        UltraGridRow selRowGrid = null;
                                        rAddedEditedLast = this.add(add, rSelectedCriteria.FldShort, rSelectedCriteria.SourceTable,
                                                                rSelectedCriteria.IDApplication,
                                                                selRowGridCriteria.Cells[qs2.core.generic.columnNameText].Value.ToString(), true,
                                                                false, "", ref selRowGrid, rSelectedCriteria, ref protocoll, "", null, false);
                                    }
                                    this.translateGrid();
                                    if (rAddedEditedLast != null)
                                    {
                                        this.loadMulticontrols(ref rAddedEditedLast, ref protocollForAdmin, ref protocolWindow);
                                    }
                                }
                                else if (frmSelect.ContSelectField1.selectedTab == sitemap.vb.contSelectField.eTab.Database)
                                {
                                    qs2.core.vb.dsAdmin.tblQueriesDefRow rAddedEditedLast = null;
                                    foreach (UltraGridRow selRowGridSysDB in frmSelect.ContSelectField1.ContInfoFieldDB1.selRowsGrid)
                                    {
                                        DataRowView v = (DataRowView)selRowGridSysDB.ListObject;
                                        qs2.core.SysDB.dsSysDB.COLUMNSRow rSelectedSysDB = (qs2.core.SysDB.dsSysDB.COLUMNSRow)v.Row;
                                        UltraGridRow selRowGrid = null;
                                        string SchemaSysDB = "";
                                        if (!rSelectedSysDB.IsTABLE_SCHEMANull())
                                        {
                                            SchemaSysDB = rSelectedSysDB.TABLE_SCHEMA.Trim();
                                        }
                                        rAddedEditedLast = this.add(add, rSelectedSysDB.COLUMN_NAME, rSelectedSysDB.TABLE_NAME, "",
                                                                    selRowGridSysDB.Cells[qs2.core.generic.columnNameText].Value.ToString(),
                                                                    false, true, rSelectedSysDB.DATA_TYPE, ref selRowGrid, null, ref protocoll,
                                                                    SchemaSysDB, null, false);
                                    }
                                    this.translateGrid();
                                    if (rAddedEditedLast != null)
                                    {
                                        this.loadMulticontrols(ref rAddedEditedLast, ref protocollForAdmin, ref protocolWindow);
                                    }
                                }

                            }
                        }
                    }
                    else
                    {
                        if (this.typQueryDef == core.Enums.eTypQueryDef.Joins)
                        {
                            this.addJoins(add, sitemap.workflowAssist.contInfoFieldDB.eTypUI.selectionColumns, add, ref protocollForAdmin, ref protocolWindow);
                            this.translateGrid();
                        }
                        else
                        {
                            UltraGridRow selRowGrid = null;
                            qs2.core.vb.dsAdmin.tblQueriesDefRow rAddedEdited = this.add(add, "", "", "", "", false, true, "", ref selRowGrid, null, ref protocoll, "", null, false);
                            this.translateGrid();
                            if (rAddedEdited != null)
                            {
                                this.loadMulticontrols(ref rAddedEdited, ref protocollForAdmin, ref protocolWindow);
                            }
                        }
                    }

                    if (protocoll.Trim() != "")
                    {
                        string txt = qs2.core.language.sqlLanguage.getRes("InfoAddFieldsToQuery") + "\r\n" + "\r\n" +
                                protocoll.Trim() + "!";
                        //qs2.core.generic.showMessageBox(txt, MessageBoxButtons.OK, "");
                        frmProtocol frmProtocol1 = new frmProtocol();
                        frmProtocol1.initControl();
                        frmProtocol1.Text = qs2.core.language.sqlLanguage.getRes("ProtocollAddFieldsToQuery");
                        qs2.core.ENV.lstOpendChildForms.Add(frmProtocol1);
                        frmProtocol1.ShowDialog(this);
                        frmProtocol1.ContProtocol1.setText(txt);
                    }
                }
                else
                {
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoQuerySelected") + "!", MessageBoxButtons.OK, "");
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void addDblClick(int selectedTab, System.Collections.Generic.List<UltraGridRow> selRowsGrid,
                                    ref string protocoll, bool add, qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListSelChapter,
                                    bool addPlaceholder)
        {
            try
            {
                if (addPlaceholder)
                {
                    this.addPlaceholder();
                }
                else
                {
                    //sitemap.vb.contSelectField.eTab
                    if (selectedTab == 0)               //sitemap.vb.contSelectField.eTab.Chapter
                    {
                        qs2.core.vb.dsAdmin.tblQueriesDefRow rAddedEditedLast = null;
                        foreach (UltraGridRow selRowGridCriteria in selRowsGrid)
                        {
                            DataRowView v = (DataRowView)selRowGridCriteria.ListObject;
                            qs2.core.vb.dsAdmin.tblCriteriaRow rSelectedCriteria = (qs2.core.vb.dsAdmin.tblCriteriaRow)v.Row;
                            UltraGridRow selRowGrid = null;
                            rAddedEditedLast = this.add(add, rSelectedCriteria.FldShort, rSelectedCriteria.SourceTable,
                                                    rSelectedCriteria.IDApplication,
                                                    selRowGridCriteria.Cells[qs2.core.generic.columnNameText].Value.ToString(), true,
                                                    false, "", ref selRowGrid, rSelectedCriteria, ref protocoll,
                                                    "", rSelListSelChapter, addPlaceholder);
                        }
                        this.translateGrid();
                    }
                    else if (selectedTab == 1)          //sitemap.vb.contSelectField.eTab.Database
                    {
                        qs2.core.vb.dsAdmin.tblQueriesDefRow rAddedEditedLast = null;
                        foreach (UltraGridRow selRowGridSysDB in selRowsGrid)
                        {
                            DataRowView v = (DataRowView)selRowGridSysDB.ListObject;
                            qs2.core.SysDB.dsSysDB.COLUMNSRow rSelectedSysDB = (qs2.core.SysDB.dsSysDB.COLUMNSRow)v.Row;
                            UltraGridRow selRowGrid = null;
                            string SchemaSysDB = "";
                            if (!rSelectedSysDB.IsTABLE_SCHEMANull())
                            {
                                SchemaSysDB = rSelectedSysDB.TABLE_SCHEMA.Trim();
                            }
                            rAddedEditedLast = this.add(add, rSelectedSysDB.COLUMN_NAME, rSelectedSysDB.TABLE_NAME, "",
                                                        selRowGridSysDB.Cells[qs2.core.generic.columnNameText].Value.ToString(),
                                                        false, true, rSelectedSysDB.DATA_TYPE, ref selRowGrid, null, ref protocoll,
                                                        SchemaSysDB, rSelListSelChapter, addPlaceholder);
                        }
                        this.translateGrid();
                        //if (rAddedEditedLast != null)
                        //{
                        //    this.loadMulticontrols(ref rAddedEditedLast, ref protocollForAdmin, ref protocolWindow);
                        //}
                    }
                }

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void addPlaceholder()
        {
            try
            {
                frmInputText2 frmInput1 = new frmInputText2();
                frmInput1.initControl();
                frmInput1.Text = qs2.core.language.sqlLanguage.getRes("NamePlaceholder");
                frmInput1.ShowDialog();
                if (!frmInput1.abort)
                {
                    qs2.core.vb.dsAdmin.tblQueriesDefRow rNewEdit =  this.sqlAdmin1.addRowQueriesDef(this.dsAdmin1.tblQueriesDef);
                    rNewEdit.UserInput = false;
                    rNewEdit.ControlType = qs2.core.Enums.eControlType.Textfield.ToString();
                    rNewEdit.Placeholder = true;
                    rNewEdit.ApplicationOwn = this.mainWindow.getSelectedApplication();
                    rNewEdit.ParticipantOwn = qs2.core.license.doLicense.eApp.ALL.ToString();
                    rNewEdit.IDSelList = this.rSelList.ID;
                    rNewEdit.QryColumn = frmInput1.txtText.Text.Trim();
                    rNewEdit.Typ = this.typQueryDef.ToString();
                    rNewEdit.Sort = this.getLastSortNumber(rNewEdit);
                    
                    UltraGridRow newRowGrid = this.gridQueryDef.Rows.GetRowWithListIndex(this.dsAdmin1.tblQueriesDef.Rows.IndexOf(rNewEdit));
                    newRowGrid.Cells[qs2.core.generic.columnNameText].Value = rNewEdit.QryColumn;

                    UltraGridRow selRowGrid = null;
                    qs2.core.vb.dsAdmin.tblQueriesDefRow rSelQryDef = this.getSelectedRow(false, ref selRowGrid);
                    if (rSelQryDef != null)
                    {
                        rNewEdit.Sort = rSelQryDef.Sort;
                        this.gridQueryDef.UpdateData();
                        this.doSortAll(rSelQryDef.Sort, rNewEdit.QryColumn);
                    }

                    this.gridQueryDef.Refresh();
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("contQueryDef.addPlaceholder: " + ex.ToString());
            }
        }

        public void addAutoFields()
        {
            if (qs2.core.ENV.StandardFieldsQueries.Trim() != "")
            {
                string protocoll = "";
                string StandardFieldsQueriesTemp = qs2.core.ENV.StandardFieldsQueries.Trim();
                if (!StandardFieldsQueriesTemp.Contains(";"))
                {
                    StandardFieldsQueriesTemp += ";";
                }
                System.Collections.Generic.List<string> lstAutoFields = qs2.core.generic.readStrVariables(StandardFieldsQueriesTemp);
                foreach (string autoFieldReaded in lstAutoFields)
                {
                    string tableNameAuto = "";
                    string columnNameAuto = "";
                    qs2.core.generic.getVarsByPoint(autoFieldReaded, ref tableNameAuto, ref columnNameAuto);
                    qs2.core.SysDB.dsSysDB.COLUMNSRow rSysDB = qs2.core.SysDB.sqlSysDB.getSysColumnRow(tableNameAuto, columnNameAuto, qs2.core.SysDB.sqlSysDB.dsSysDBAll, true);
                    string ColumnTranslated = qs2.core.language.sqlLanguage.getRes(rSysDB.COLUMN_NAME, true, true);
                    if (ColumnTranslated.Trim() == "")
                        ColumnTranslated = rSysDB.COLUMN_NAME;

                    UltraGridRow selRowGrid = null;
                    string SchemaSysDB = "";
                    if (!rSysDB.IsTABLE_SCHEMANull())
                    {
                        SchemaSysDB = rSysDB.TABLE_SCHEMA.Trim();
                    }
                    qs2.core.vb.dsAdmin.tblQueriesDefRow rNewQuery = this.add(true, rSysDB.COLUMN_NAME, rSysDB.TABLE_NAME, "", ColumnTranslated,
                                                                                false, true, rSysDB.DATA_TYPE, ref selRowGrid,
                                                                                null, ref protocoll,
                                                                                SchemaSysDB, null, false);
                    rNewQuery.Label = ColumnTranslated;
                    selRowGrid.Cells[qs2.core.generic.columnNameText].Value = ColumnTranslated;
                }
            }
        }
        public void addTables(bool add, sitemap.workflowAssist.contInfoFieldDB.eTypUI typUI, bool doLstTables,
                                ref string protocollForAdmin, ref bool protocolWindow)
        {
            try
            {
                if (this.rSelList != null)
                {
                    this.addJoins(add, typUI, doLstTables, ref protocollForAdmin, ref protocolWindow);
                }
                else
                {
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoQuerySelected") + "!", MessageBoxButtons.OK, "");
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void addJoins(bool add, sitemap.workflowAssist.contInfoFieldDB.eTypUI typUI, bool doLstTables,
                                ref string protocollForAdmin, ref bool protocolWindow)
        {
            try
            {
                bool abort = false;
                qs2.sitemap.vb.frmSelectField frmSelect = new qs2.sitemap.vb.frmSelectField();
                frmSelect.typpUI = typUI;
                frmSelect.ContSelectField1.onlyDBFields = true;

                if (!doLstTables)
                {
                    UltraGridRow selRowGrid = null;
                    qs2.core.vb.dsAdmin.tblQueriesDefRow rQrySelected = this.getSelectedRow(false, ref selRowGrid);
                    System.Collections.ArrayList lstTablesToShow = new System.Collections.ArrayList();

                    foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rQry in this.dsAdmin1.tblQueriesDef)
                    {
                        lstTablesToShow.Add(rQry.QryTable);
                    }

                    frmSelect.ContSelectField1.lstTablesToShow = lstTablesToShow;
                    if (rQrySelected != null)
                    {
                        frmSelect.ContSelectField1.lstTablesToShow = new System.Collections.ArrayList();
                        frmSelect.ContSelectField1.lstTablesToShow.Add(rQrySelected.QryTable);
                    }
                }

                frmSelect.ContSelectField1.IDApplication = this.mainWindow.getSelectedApplication();
                frmSelect.ContSelectField1.IDParticipant = qs2.core.license.doLicense.eApp.ALL.ToString();
                frmSelect.ShowDialog(this);
                abort = frmSelect.ContSelectField1.abort;

                if (!abort)
                {
                    string protocoll = "";
                    if (frmSelect.ContSelectField1.selectedTab == sitemap.vb.contSelectField.eTab.Database)
                    {
                        if (typUI == sitemap.workflowAssist.contInfoFieldDB.eTypUI.selectionColumns)
                        {
                            qs2.core.vb.dsAdmin.tblQueriesDefRow rAddedEditedLast = null;
                            foreach (UltraGridRow selRowGridSysDB in frmSelect.ContSelectField1.ContInfoFieldDB1.selRowsGrid)
                            {
                                DataRowView v = (DataRowView)selRowGridSysDB.ListObject;
                                qs2.core.SysDB.dsSysDB.COLUMNSRow rSelectedSysDB = (qs2.core.SysDB.dsSysDB.COLUMNSRow)v.Row;
                                UltraGridRow selRowGrid = null;
                                string SchemaSysDB = "";
                                if (!rSelectedSysDB.IsTABLE_SCHEMANull())
                                {
                                    SchemaSysDB = rSelectedSysDB.TABLE_SCHEMA.Trim();
                                }
                                rAddedEditedLast = this.add(add, rSelectedSysDB.COLUMN_NAME, rSelectedSysDB.TABLE_NAME, "",
                                                            selRowGridSysDB.Cells[qs2.core.generic.columnNameText].Value.ToString(),
                                                            false, true, rSelectedSysDB.DATA_TYPE, ref selRowGrid, null, ref protocoll,
                                                            SchemaSysDB, null, false);
                            }
                            if (rAddedEditedLast != null)
                            {
                                this.loadMulticontrols(ref rAddedEditedLast, ref protocollForAdmin, ref protocolWindow);
                            }
                        }
                        else if (typUI == sitemap.workflowAssist.contInfoFieldDB.eTypUI.selectionTables)
                        {
                            //qs2.core.vb.dsAdmin.tblQueriesDefRow rAddedEditedLast = null;
                            foreach (UltraGridRow selRowGridSysDB in frmSelect.ContSelectField1.ContInfoFieldDB1.selRowsGrid)
                            {
                                DataRowView v = (DataRowView)selRowGridSysDB.ListObject;
                                qs2.core.SysDB.dsSysDB.TablesCatalogRow rSelectedTable = (qs2.core.SysDB.dsSysDB.TablesCatalogRow)v.Row;
                                UltraGridRow selRowGrid = null;
                                dsAdmin.tblQueriesDefRow rSelectedQry = this.getSelectedRow(false, ref selRowGrid);
                                rSelectedQry.QryTable = rSelectedTable.TABLE_NAME;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public qs2.core.vb.dsAdmin.tblQueriesDefRow add(bool add, string Column, string table, string ApplicationCriteria,
                                                        string translationColumn, bool criteria, bool IsSQLServerField, string typeSQLServer,
                                                        ref UltraGridRow selRowGrid,
                                                        qs2.core.vb.dsAdmin.tblCriteriaRow rSelectedCriteria, ref string protocoll,
                                                        string SchemaSysDb, qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListSelChapter, 
                                                        bool AddPlaceholder)
        {
            try
            {
                qs2.core.vb.dsAdmin.tblQueriesDefRow rNewEdit = null;
                if (add)
                    rNewEdit = this.sqlAdmin1.addRowQueriesDef(this.dsAdmin1.tblQueriesDef);
                else
                {
                    UltraGridRow selRowGrid2 = null;
                    rNewEdit = this.getSelectedRow(true, ref selRowGrid2);
                    if (rNewEdit == null) return null;
                }
                if (this.typQueryDef == core.Enums.eTypQueryDef.SelectFields)
                {
                    rNewEdit.UserInput = false;
                }
                else if (this.typQueryDef == core.Enums.eTypQueryDef.WhereConditions)
                {
                    rNewEdit.Combination = qs2.core.sqlTxt.and;
                    rNewEdit.Condition = qs2.core.sqlTxt.equals;
                }
                else if (this.typQueryDef == core.Enums.eTypQueryDef.InputParameters)
                {
                    rNewEdit.UserInput = true;
                    rNewEdit.ControlType = qs2.core.Enums.eControlType.Textfield.ToString();
                }

                rNewEdit.Typ = this.typQueryDef.ToString();
                rNewEdit.ApplicationOwn = this.mainWindow.getSelectedApplication();
                rNewEdit.ParticipantOwn = qs2.core.license.doLicense.eApp.ALL.ToString();
                rNewEdit.IDSelList = this.rSelList.ID;

                rNewEdit.QryColumn = qs2.core.language.sqlLanguage.checkComma(Column);
                if (rSelList.TypeQry.Trim().Equals(qs2.core.print.print.eQueryType.SimpleView.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    bool colExistsInSysCatalog = this.checkSysColumnExists(rNewEdit.QryColumn, rSelList._Table.Trim(), ref this.typQueryDef, rSelList.TypeQry.Trim(), true);
                    if (!colExistsInSysCatalog)
                    {
                        bool ViewFound = false;
                        foreach (dsAdmin.tblSelListEntriesRow rViewsQueries in this.dsViewsQueries.tblSelListEntries)
                        {
                            bool colExistsInSysCatalogEnvVar = this.checkSysColumnExists(rNewEdit.QryColumn, rViewsQueries.IDRessource.Trim(), ref this.typQueryDef, rSelList.TypeQry.Trim(), false);
                            if (colExistsInSysCatalogEnvVar)
                            {
                                rNewEdit.QryTable = "qs2." + rViewsQueries.IDRessource.Trim();
                                ViewFound = true;
                            }
                        }

                        if (!ViewFound)
                        {
                            rNewEdit.QryTable = rSelList._Table.Trim();
                        }

                        //if (criteria)
                        //{
                        //    qs2.core.vb.businessFramework b = new businessFramework();
                        //    qs2.core.vb.dsAdmin dsAdminTmp2 = new core.vb.dsAdmin();
                        //    qs2.core.vb.dsAdmin.tblCriteriaRow rCriteriaFound = null;
                        //    string FldShortTmp = rNewEdit.QryColumn.Trim();
                        //    string IDApplicationTmp = rNewEdit.ApplicationOwn.Trim();
                        //    bool HasCriteria = false;
                        //    b.checkCriteria(ref FldShortTmp, ref IDApplicationTmp, ref HasCriteria, ref rCriteriaFound, ref dsAdminTmp2);
                        //    if (HasCriteria)
                        //    {
                        //        rNewEdit.QryTable = rCriteriaFound.SourceTable.Trim();
                        //    }
                        //    else
                        //    {
                        //        rNewEdit.QryTable = rSelList._Table.Trim();
                        //    }
                        //}
                        //else
                        //{
                        //    rNewEdit.QryTable = rSelList._Table.Trim();
                        //}
                    }
                    else
                    {
                        rNewEdit.QryTable = rSelList._Table.Trim();
                    }
                }
                else if (rSelList.TypeQry.Trim().Equals(qs2.core.print.print.eQueryType.SimpleFunction.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    //rNewEdit.QryTable = rSelList._Table.Trim().Substring(1, rSelList._Table.Trim().Length - 1);
                    rNewEdit.QryTable = rSelList._Table.Trim();
                }
                else if (rSelList.TypeQry.Trim().Equals(qs2.core.print.print.eQueryType.FullMode.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    rNewEdit.QryTable = "" + SchemaSysDb.Trim() + "." + table;
                }
                else
                {
                    throw new Exception("contQueryDef.loadTableSelection: itmValList.add '" + rSelList.TypeQry + "' not exists in Enum QueryType!");
                }

                if (criteria)
                {
                    rNewEdit.CriteriaFldShort = Column;
                    rNewEdit.CriteriaApplication = ApplicationCriteria;
                    rNewEdit.SetControlTypeNull();
                }
                else
                {
                    rNewEdit.SetCriteriaFldShortNull();
                    rNewEdit.SetCriteriaApplicationNull();
                }
                rNewEdit.IsSQLServerField = IsSQLServerField;
                if (rNewEdit.IsSQLServerField)
                {
                    string IDApplicationTmp = rNewEdit.ApplicationOwn;
                    foreach (dsAdmin.tblSelListEntriesRow rAllCriteriasForQueries in this.dsAllCriteriasForQueries.tblSelListEntries)
                    {
                        if (Column.Trim().ToLower().Equals(rAllCriteriasForQueries.IDRessource.Trim().ToLower()))
                        {
                            IDApplicationTmp = qs2.core.license.doLicense.eApp.ALL.ToString();
                            //rNewEdit.CriteriaApplication = IDApplicationTmp;
                        }
                    }
                    string typeFound = "";
                    dsAdmin.tblCriteriaRow rCriteria3 = null;
                    typeFound = this.drawMulticontrol1.getControlTypeFromSQLServer(typeSQLServer, IDApplicationTmp, rNewEdit.ParticipantOwn, Column, table, ref rCriteria3).ToString();
                    rNewEdit.ControlType = typeFound;
                    if (rCriteria3 != null)
                    {
                        rNewEdit.CriteriaFldShort = rCriteria3.FldShort.Trim();
                        rNewEdit.CriteriaApplication = rCriteria3.IDApplication.Trim();
                        rNewEdit.IsSQLServerField = false;
                    }
                }

                //if (this.typQueryDef == core.Enums.eTypQueryDef.InputParameters)
                //{
                if (criteria)
                {
                    if (rSelectedCriteria != null)
                    {
                        rNewEdit.ControlType = rSelectedCriteria.ControlType;
                    }
                }
                //}

                rNewEdit.ValueMin = "";
                rNewEdit.Max = "";
                //rNewEdit.SetControlTypeNull();
                if (add)
                {
                    rNewEdit.Sort = this.getLastSortNumber(rNewEdit);
                }

                //this.gridQueryDef.UpdateData();
                this.gridQueryDef.Refresh();
                selRowGrid = this.gridQueryDef.Rows.GetRowWithListIndex(this.dsAdmin1.tblQueriesDef.Rows.IndexOf(rNewEdit));
                //if (selRowGrid != null)
                //    selRowGrid.Cells[qs2.core.generic.columnNameText].Value = translationColumn;

                if (!qs2.core.license.doLicense.rApplication.IDApplication.Trim().Equals(qs2.core.license.doLicense.eApp.PMDS.ToString().Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    if (rSelList.TypeQry.Trim().Equals(qs2.core.print.print.eQueryType.SimpleView.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        if (this.typQueryDef == core.Enums.eTypQueryDef.SelectFields || this.typQueryDef == core.Enums.eTypQueryDef.WhereConditions)
                        {
                            if (string.IsNullOrWhiteSpace(rNewEdit.QryTable))
                            {
                                rNewEdit.QryTable = "qs2." + this.mainWindow.getSelectedApplication().Trim() + "_STAYS";
                                //this.doErrorProviderGridForColumn(rNewEdit, selRowGrid, false, ref protocoll, "ColumnCouldNotUsedNotExistsInDb", false);
                            }
                            else
                            {
                                bool StripSchema = true;        //!rNewEdit.IsSQLServerField;
                                bool colExistsInSysCatalog = this.checkSysColumnExists(rNewEdit.QryColumn, rNewEdit.QryTable, ref this.typQueryDef, rSelList.TypeQry.Trim(), StripSchema);
                                if (!colExistsInSysCatalog)
                                {
                                    rNewEdit.QryTable = "qs2." + this.mainWindow.getSelectedApplication().Trim() + "_STAYS";
                                    //this.doErrorProviderGridForColumn(rNewEdit, selRowGrid, false, ref protocoll, "ColumnCouldNotUsedNotExistsInDb", false);
                                }
                            }
                        }
                    }
                    else if (rSelList.TypeQry.Trim().Equals(qs2.core.print.print.eQueryType.SimpleFunction.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        if (this.typQueryDef == core.Enums.eTypQueryDef.SelectFields)
                        {
                            if (string.IsNullOrWhiteSpace(rNewEdit.QryTable))
                            {
                                rNewEdit.QryTable = "qs2." + this.mainWindow.getSelectedApplication().Trim() + "_STAYS";
                                //this.doErrorProviderGridForColumn(rNewEdit, selRowGrid, false, ref protocoll, "ColumnCouldNotUsedNotExistsInDb", false);
                            }
                            else
                            {
                                bool colExistsInSysCatalog = this.checkSysColumnExists(rNewEdit.QryColumn, rNewEdit.QryTable, ref this.typQueryDef, rSelList.TypeQry.Trim(), false);
                                if (!colExistsInSysCatalog)
                                {
                                    rNewEdit.QryTable = "qs2." + this.mainWindow.getSelectedApplication().Trim() + "_STAYS";
                                    //this.doErrorProviderGridForColumn(rNewEdit, selRowGrid, false, ref protocoll, "ColumnCouldNotUsedNotExistsInDb", false);
                                }
                            }
                        }
                    }
                }

                this.gridQueryDef.Selected.Rows.Clear();
                this.gridQueryDef.ActiveRow = selRowGrid;
                // Sel2
                if (rSelListSelChapter != null)
                {
                    rNewEdit.Chapter = rSelListSelChapter.IDOwnStr;
                }

                rNewEdit.ChaptersDone = true;

                return rNewEdit;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return null;
            }
        }

        public bool checkSysColumnExists(string columnName, string tableName, ref core.Enums.eTypQueryDef TypQueryDef, string TypeQry, bool StripSchema)
        {
            string TableNameToCheck = tableName.Trim();
            if (rSelList.TypeQry.Trim().Equals(qs2.core.print.print.eQueryType.SimpleFunction.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                string tableTmp = tableName.Trim();
                tableTmp = "v" + tableTmp.Substring(4, tableTmp.Length - 4);
                //tableTmp = tableTmp.Substring(0, 4) + "v" + tableTmp.Substring(4, tableTmp.Length - 4);
                TableNameToCheck = tableTmp.Trim();
            }
            string TableNameTmp = "";
            if (StripSchema)
            {
                TableNameTmp = TableNameToCheck.Substring(4, TableNameToCheck.Length - 4);
            }
            else
            {
                TableNameTmp = TableNameToCheck;
            }

            qs2.core.SysDB.dsSysDB.COLUMNSRow rColSys = qs2.core.SysDB.sqlSysDB.getSysColumnRow(TableNameTmp, columnName.Trim(),
                                                        qs2.core.SysDB.sqlSysDB.dsSysDBAll, false);
            if (rColSys != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void searchFields(string TxtToSearch)
        {
            try
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in this.gridQueryDef.Rows)
                {
                    DataRowView v = (DataRowView)row.ListObject;
                    qs2.core.vb.dsAdmin.tblQueriesDefRow rQry = (qs2.core.vb.dsAdmin.tblQueriesDefRow)v.Row;

                    if (!string.IsNullOrEmpty(TxtToSearch) && row.Cells[qs2.core.generic.columnNameText].Value.ToString().Trim().IndexOf(TxtToSearch, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                    {
                        row.CellAppearance.BackColor = System.Drawing.Color.LightGreen;
                        row.CellAppearance.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        row.CellAppearance.BackColor = System.Drawing.Color.White;
                        row.CellAppearance.ForeColor = System.Drawing.Color.Black;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contQueryDef.searchFields: " + ex.ToString());
            }
        }

        public void deleteRows()
        {
            try
            {
                System.Collections.Generic.List<Infragistics.Win.UltraWinGrid.UltraGridRow> rSelected = new System.Collections.Generic.List<Infragistics.Win.UltraWinGrid.UltraGridRow>();
                qs2.core.ui.getSelectedGridRows(this.gridQueryDef, rSelected, true);
                //if (rSelected.Count > 0)
                //{
                    //if (qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("DeleteRecords") + "?", System.Windows.Forms.MessageBoxButtons.YesNo, "") == System.Windows.Forms.DialogResult.Yes)
                    //{
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in rSelected)
                        {
                            row.Delete(false);
                        }

                        this.gridQueryDef.UpdateData();
                        this.gridQueryDef.Refresh();

                        //this.mainWindow.SaveClicked();
                    //}
                //}
                //else
                //{
                //    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), MessageBoxButtons.OK, "");
                //}              

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void doSort(bool toTop)
        {
            try
            {
                UltraGridRow selRowGrid = null;
                qs2.core.vb.dsAdmin.tblQueriesDefRow rSelQuery = this.getSelectedRow(true, ref selRowGrid);
                if (rSelQuery != null)
                {
                    int newNr = 0;
                    bool reached = false;
                    string orderBy = "";
                    if (toTop)
                        orderBy = " desc ";
                    else
                        orderBy = " asc ";

                    string colNewOrder = "NewOrder";
                    this.dsAdmin1.tblQueriesDef.Columns.Add(colNewOrder, typeof(System.Int32));
                    qs2.core.vb.dsAdmin.tblQueriesDefRow[] arrActuellQuery = (qs2.core.vb.dsAdmin.tblQueriesDefRow[])this.dsAdmin1.tblQueriesDef.Select("", this.dsAdmin1.tblQueriesDef.SortColumn.ColumnName + orderBy);
                    foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rActuellQuery in arrActuellQuery)
                    {
                        newNr += 1;
                        if (!reached && (rActuellQuery.IDGuid.ToString() == rSelQuery.IDGuid.ToString()))
                        {
                            reached = true;
                            rActuellQuery[colNewOrder] = (newNr + 1);
                        }
                        else if (reached && (rActuellQuery.IDGuid.ToString() != rSelQuery.IDGuid.ToString()))
                        {
                            rActuellQuery[colNewOrder] = (newNr - 1);
                            reached = false;
                        }
                        else if (!reached && (rActuellQuery.IDGuid.ToString() != rSelQuery.IDGuid.ToString()))
                            rActuellQuery[colNewOrder] = newNr;
                    }
                    newNr = 0;
                    qs2.core.vb.dsAdmin.tblQueriesDefRow[] arrQueryWrite = (qs2.core.vb.dsAdmin.tblQueriesDefRow[])this.dsAdmin1.tblQueriesDef.Select("", this.dsAdmin1.tblQueriesDef.Columns[colNewOrder].ColumnName + orderBy);
                    foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rActuellQuery in arrQueryWrite)
                    {
                        newNr += 1;
                        rActuellQuery.Sort = newNr;
                    }

                    this.dsAdmin1.tblQueriesDef.Columns.Remove(colNewOrder);
                    this.gridQueryDef.DisplayLayout.Bands[0].SortedColumns.Clear();
                    this.gridQueryDef.DisplayLayout.Bands[0].SortedColumns.Add(this.dsAdmin1.tblStayAdditions.SortColumn.ColumnName, false);
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void doSortAll(int NewNr, string QryColumn)
        {
            try
            {
                UltraGridRow selRowGrid = null;
                qs2.core.vb.dsAdmin.tblQueriesDefRow rSelQuery = this.getSelectedRow(true, ref selRowGrid);
                if (rSelQuery != null)
                {
                    string orderBy = " asc ";

                    qs2.core.vb.dsAdmin.tblQueriesDefRow[] arrActuellQuery = (qs2.core.vb.dsAdmin.tblQueriesDefRow[])this.dsAdmin1.tblQueriesDef.Select("QryColumn='" + QryColumn.Trim() + "'", this.dsAdmin1.tblQueriesDef.SortColumn.ColumnName + orderBy);
                    string sWhere = "Sort>=" + arrActuellQuery[0].Sort.ToString() + " and QryColumn<>'" + arrActuellQuery[0].QryColumn + "'";
                    arrActuellQuery = (qs2.core.vb.dsAdmin.tblQueriesDefRow[])this.dsAdmin1.tblQueriesDef.Select(sWhere, this.dsAdmin1.tblQueriesDef.SortColumn.ColumnName + orderBy);
                    foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rActuellQuery in arrActuellQuery)
                    {
                        rActuellQuery.Sort = rActuellQuery.Sort + 1;
                    }

                    int ActNr = 0;
                    arrActuellQuery = (qs2.core.vb.dsAdmin.tblQueriesDefRow[])this.dsAdmin1.tblQueriesDef.Select("", this.dsAdmin1.tblQueriesDef.SortColumn.ColumnName + orderBy);
                    foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rActuellQuery in arrActuellQuery)
                    {
                        ActNr += 1;
                        rActuellQuery.Sort = ActNr;
                    }

                    this.gridQueryDef.DisplayLayout.Bands[0].SortedColumns.Clear();
                    this.gridQueryDef.DisplayLayout.Bands[0].SortedColumns.Add(this.dsAdmin1.tblQueriesDef.SortColumn.ColumnName, false);
                    this.gridQueryDef.Selected.Rows.Clear();
                    this.gridQueryDef.Refresh();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contQueryDef.doSortAll: " + ex.ToString());
            }
        }

        public int getLastSortNumber(qs2.core.vb.dsAdmin.tblQueriesDefRow rSelQuery)
        {
            try
            {
                int lastNr = 0;
                foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rActuellQuery in this.dsAdmin1.tblQueriesDef)
                    if (rActuellQuery.RowState != DataRowState.Deleted)
                    {
                        lastNr = (lastNr < rActuellQuery.Sort ? rActuellQuery.Sort : lastNr);
                    }
                return (lastNr + 1);
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return 5000;
            }
        }


        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.doSort(true);
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

        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.doSort(false);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string protocollForAdmin = "";
                bool ProtocolWindow = false;

                this.add(true, (this.typQueryDef == core.Enums.eTypQueryDef.InputParameters || this.typQueryDef == core.Enums.eTypQueryDef.Joins ? false : true),
                                ref protocollForAdmin, ref ProtocolWindow, true);

                if (protocollForAdmin.Trim() != "")
                {
                    qs2.design.auto.multiControl.ownMCInfo.openProtocoll(ref protocollForAdmin);
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
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.deleteRows();
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

        private void gridQueryDef_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;

            if (!this.isInEditMode)
                e.Cancel = true;
            //qs2.core.ui.delGridRowYN(e);
        }
        private void gridQueryDef_BeforeRowActivate(object sender, RowEventArgs e)
        {
            try
            {
                this.panelCombinations.Visible = false;

                if (!e.Row.IsFilterRow && !e.Row.IsGroupByRow)
                {
                    if (this.isInEditMode)
                    {
                    }
                    else
                    {
                    }

                    DataRowView v = (DataRowView)e.Row.ListObject;
                    qs2.core.vb.dsAdmin.tblQueriesDefRow rQry = (qs2.core.vb.dsAdmin.tblQueriesDefRow)v.Row;
                    if (qs2.core.ENV.AdminSecure)
                    {
                        if (rQry.IsSQLServerField)
                        {
                            this.criteriasToolStripMenuItem.Visible = false;
                        }
                        else
                        {
                            this.criteriasToolStripMenuItem.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        private void gridQueryDef_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                if (this.isInEditMode)
                {
                    if (e.Cell.Column.ToString().Equals(qs2.core.generic.columnNameText) ||
                        e.Cell.Column.ToString().Equals(this.dsAdmin1.tblQueriesDef.QryColumnColumn.ColumnName) ||
                        //e.Cell.Column.ToString().Equals(this.dsAdmin1.tblQueriesDef.QryTableColumn.ColumnName) ||
                        e.Cell.Column.ToString().Equals(this.dsAdmin1.tblQueriesDef.ValueMinColumn.ColumnName) ||
                        e.Cell.Column.ToString().Equals(this.dsAdmin1.tblQueriesDef.CombinationColumn.ColumnName) ||
                        e.Cell.Column.ToString().Equals(this.dsAdmin1.tblQueriesDef.CombinationEndColumn.ColumnName) ||
                        e.Cell.Column.ToString().Equals(this.dsAdmin1.tblQueriesDef.MaxColumn.ColumnName) ||
                        e.Cell.Column.ToString().Equals(this.dsAdmin1.tblQueriesDef.ChapterColumn.ColumnName) ||
                        e.Cell.Column.ToString().Equals(this.dsAdmin1.tblQueriesDef.ChaptersColumn.ColumnName) ||
                        e.Cell.Column.ToString().Equals(this.dsAdmin1.tblQueriesDef.PlaceholderColumn.ColumnName) ||
                        e.Cell.Column.ToString().Equals(this.colChaptersTransl) || e.Cell.Column.ToString().Equals(this.colChapterTransl) ||
                        e.Cell.Column.ToString().Equals(this.colControlNr) || e.Cell.Column.ToString().Equals(this.colLineNr) ||
                        e.Cell.Column.ToString().Equals(this.dsAdmin1.tblQueriesDef.ApplicationOwnColumn.ColumnName))
                    {
                        e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    }
                    else
                    {
                        e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    }

                    if (e.Cell.Column.ToString().Equals(this.dsAdmin1.tblQueriesDef.CombinationColumn.ColumnName) || e.Cell.Column.ToString().Equals(this.dsAdmin1.tblQueriesDef.CombinationEndColumn.ColumnName))
                        this.panelCombinations.Visible = true;
                    else
                        this.panelCombinations.Visible = false;
                }
                else
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void openSublistEntriesxy(string IDGroupStr, string CellName, UltraGridRow activeRow)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //qs2.sitemap.vb.frmSelLists frmSelListAdd = new qs2.sitemap.vb.frmSelLists();
                //frmSelListAdd.ContSelList1.defaultApplication = this.mainWindow.getSelectedApplication();
                //frmSelListAdd.ContSelList1.Username = qs2.core.vb.actUsr.rUsr.UserName;
                //frmSelListAdd.ContSelList1.IDParticipant = qs2.core.license.doLicense.eApp.ALL.ToString();
                //frmSelListAdd.ContSelList1.doExecptIfGroupNotFound = false;
                //frmSelListAdd.ContSelList1.IDGruppeStr = IDGroupStr;
                //frmSelListAdd.TypeStr = qs2.core.Enums.eTypeQuery.Admin.ToString();
                //frmSelListAdd.typeUI = sitemap.vb.frmSelLists.eTypeUI.selectRow;
                //frmSelListAdd._Private = false;
                //frmSelListAdd.ShowDialog(this);
                //if (!frmSelListAdd.ContSelList1.abort)
                //{
                //    if (frmSelListAdd.ContSelList1.rSelectedSelList != null)
                //    {
                //        activeRow.Cells[cellName].Value = frmSelListAdd.ContSelList1.rSelectedSelList.IDOwnInt.ToString();
                //        if (cellName == this.dsAdmin1.tblQueriesDef.ValueMinColumn.ColumnName)
                //        {
                //            activeRow.Cells[this.dsAdmin1.tblQueriesDef.ValueMinIDResColumn.ColumnName].Value = frmSelListAdd.ContSelList1.SelectedRowGridSelList.Cells[qs2.core.generic.columnNameText].Value;
                //        }
                //        else if (cellName == this.dsAdmin1.tblQueriesDef.MaxColumn.ColumnName)
                //        {
                //            activeRow.Cells[this.dsAdmin1.tblQueriesDef.MaxIDResColumn.ColumnName].Value = frmSelListAdd.ContSelList1.SelectedRowGridSelList.Cells[qs2.core.generic.columnNameText].Value;
                //        }
                //    } 
                //}
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

        private void btnCombination_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Infragistics.Win.Misc.UltraButton butt = (Infragistics.Win.Misc.UltraButton)sender;

                UltraGridRow selRowGrid2 = null;
                qs2.core.vb.dsAdmin.tblQueriesDefRow rSelQuery = this.getSelectedRow(true, ref selRowGrid2);
                if (rSelQuery != null)
                {
                    UltraGridRow selRowGrid = this.gridQueryDef.ActiveRow;
                    string selCell = this.getSelectedCell();
                    string txtToAdd = (string)butt.Tag;
                    if (txtToAdd == null)
                        selRowGrid.Cells[selCell].Value = "";
                    else
                        selRowGrid.Cells[selCell].Value += " " + (string)butt.Tag;
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

        private void gridQueryDef_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.ui1.evDoubleClickOK(ref sender, ref e, ref this.gridQueryDef))
                {
                    //if (this.isInEditMode)
                    //    this.add(false);         
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
        public qs2.core.vb.dsAdmin.tblQueriesDefRow getSelectedRow(bool msgBox, ref UltraGridRow selRowGrid)
        {
            try
            {
                if (this.gridQueryDef.ActiveRow != null)
                {
                    DataRowView v = (DataRowView)this.gridQueryDef.ActiveRow.ListObject;
                    dsAdmin.tblQueriesDefRow rSelQuery = (dsAdmin.tblQueriesDefRow)v.Row;
                    selRowGrid = this.gridQueryDef.ActiveRow;
                    return rSelQuery;
                }
                else
                {
                    if (msgBox) qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), MessageBoxButtons.OK, "");
                    return null;
                }

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return null;
            }
        }
        public string getSelectedCell()
        {
            try
            {
                if (this.gridQueryDef.ActiveCell != null)
                {
                    return this.gridQueryDef.ActiveCell.Column.ToString();
                }
                else
                    return "";

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return "";
            }
        }

        private void criteriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UltraGridRow selRowGrid = null;
                qs2.core.vb.dsAdmin.tblQueriesDefRow rSelQuery = this.getSelectedRow(true, ref selRowGrid);
                if (rSelQuery != null)
                    if (!rSelQuery.IsSQLServerField)
                        this.ownControlInfo1.showInfoCriterias(this, rSelQuery.QryColumn, rSelQuery.ApplicationOwn, this.mainWindow.IDParticipant, false);  //OMC.IDApplication.Check
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
                UltraGridRow selRowGrid = null;
                qs2.core.vb.dsAdmin.tblQueriesDefRow rSelQuery = this.getSelectedRow(true, ref selRowGrid);
                if (rSelQuery != null)
                    this.ownControlInfo1.infoFieldDB(this, rSelQuery.QryColumn, rSelQuery.ApplicationOwn, this.mainWindow.IDParticipant, false);    //OMC.IDApplication.Check
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
        private void ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Control cont = (Control)sender;

                if (this.isInEditMode)
                {
                    UltraGridRow selRowGrid = null;
                    qs2.core.vb.dsAdmin.tblQueriesDefRow rSelQuery = this.getSelectedRow(false, ref selRowGrid);
                    if (rSelQuery != null)
                    {
                        this.saveMulticontrols(ref rSelQuery);
                    }
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        private void ButtonClickxy(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //Infragistics.Win.Misc.UltraButton button = (Infragistics.Win.Misc.UltraButton)sender;
                //this.searchValuesMinMax();
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
        private void searchValuesMinMaxxy()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.typQueryDef == core.Enums.eTypQueryDef.WhereConditions || this.typQueryDef == core.Enums.eTypQueryDef.InputParameters)
                {
                    UltraGridRow selRowGrid = null;
                    qs2.core.vb.dsAdmin.tblQueriesDefRow rSelected = this.getSelectedRow(false, ref selRowGrid);
                    if (rSelected != null)
                    {
                        dsAdmin.tblCriteriaRow rCriteria = (dsAdmin.tblCriteriaRow)this.gridQueryDef.ActiveRow.Tag;
                        //if (rCriteria.ControlType == core.Enums.eControlType.ComboBox.ToString())
                        //{
                        string cellName = this.getSelectedCell();
                        if (cellName != "")
                        {
                            this.openSublistEntriesxy(rSelected.QryColumn, cellName, this.gridQueryDef.ActiveRow);
                        }
                        //}
                        //else
                        //    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoControlTypComboBox"), MessageBoxButtons.OK , "");
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

        private void gridQueryDef_ClickCellButton(object sender, CellEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.isInEditMode)
                {
                    string selectedCell = this.getSelectedCell();
                    if (selectedCell != "")
                    {
                        string protocollForAdmin = "";
                        bool ProtocolWindow = false;

                        if (selectedCell.Equals(qs2.core.generic.columnNameText))
                        {
                            this.add(false, (this.typQueryDef == core.Enums.eTypQueryDef.Joins ? false : true), ref protocollForAdmin, ref ProtocolWindow, true);
                        }
                        else if (selectedCell.Equals(this.dsAdmin1.tblQueriesDef.QryTableColumn.ColumnName))
                        {
                            this.addTables(false, sitemap.workflowAssist.contInfoFieldDB.eTypUI.selectionTables, true, ref protocollForAdmin, ref ProtocolWindow);
                        }

                        if (protocollForAdmin.Trim() != "")
                        {
                            qs2.design.auto.multiControl.ownMCInfo.openProtocoll(ref protocollForAdmin);
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

        private void deleteFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UltraGridRow selRowGrid2 = null;
                qs2.core.vb.dsAdmin.tblQueriesDefRow rSelQuery = this.getSelectedRow(true, ref selRowGrid2);
                if (rSelQuery != null)
                {
                    UltraGridRow selRowGrid = this.gridQueryDef.ActiveRow;
                    rSelQuery.QryTable = "";
                    rSelQuery.QryColumn = "";
                    rSelQuery.SetCriteriaFldShortNull();
                    rSelQuery.SetCriteriaApplicationNull();
                    rSelQuery.IsSQLServerField = true;
                    selRowGrid.Cells[qs2.core.generic.columnNameText].Value = "";
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

        private void gridQueryDef_AfterRowActivate(object sender, EventArgs e)
        {
            try
            {
                ////if (this.isInEditMode)
                ////{
                //    qs2.core.vb.dsAdmin.tblQueriesDefRow rSelQuery = this.getSelectedRow(false);
                //    if (rSelQuery != null)
                //    {
                //        string protocollForAdmin = "";
                //        bool ProtocolWindow = false;

                //        this.loadMulticontrols(ref rSelQuery, ref protocollForAdmin, ref ProtocolWindow);

                //        if (protocollForAdmin.Trim() != "")
                //        {
                //            qs2.design.auto.multiControl.ownMCInfo.openProtocoll(ref protocollForAdmin);
                //        }
                //    }
                ////}
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        private void gridQueryDef_CellChange(object sender, CellEventArgs e)
        {
            try
            {
                if (this.isInEditMode)
                {
                    //if (e.Cell.Column.ToString().Equals(qs2.core.generic.columnNameText) ||
                    //    e.Cell.Column.ToString().Equals(this.dsAdmin1.tblQueriesDef.QueryApplicationColumn.ColumnName) ||
                    //    e.Cell.Column.ToString().Equals(this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName))

                    if (e.Cell.Column.ToString().Equals(this.dsAdmin1.tblQueriesDef.ControlTypeColumn.ColumnName))
                    {
                        //qs2.core.vb.dsAdmin.tblQueriesDefRow rSelQuery = this.getSelectedRow(false);
                        //if (rSelQuery != null)
                        //{
                        DataRowView v = (DataRowView)e.Cell.Row.ListObject;
                        dsAdmin.tblQueriesDefRow rSelQuery = (dsAdmin.tblQueriesDefRow)v.Row;

                        rSelQuery.ValueMin = "";
                        rSelQuery.Max = "";
                        this.gridQueryDef.UpdateData();

                        string protocollForAdmin = "";
                        bool ProtocolWindow = false;

                        this.loadMulticontrols(ref rSelQuery, ref protocollForAdmin, ref ProtocolWindow);

                        if (protocollForAdmin.Trim() != "")
                        {
                            qs2.design.auto.multiControl.ownMCInfo.openProtocoll(ref protocollForAdmin);
                        }
                        //}
                    }
                    else if (e.Cell.Column.ToString().Equals(this.dsAdmin1.tblQueriesDef.ComboAsDropDownColumn.ColumnName))
                    {
                        DataRowView v = (DataRowView)e.Cell.Row.ListObject;
                        dsAdmin.tblQueriesDefRow rSelQuery = (dsAdmin.tblQueriesDefRow)v.Row;

                        rSelQuery.ValueMin = "";
                        rSelQuery.Max = "";
                        this.gridQueryDef.Refresh();
                        this.gridQueryDef.UpdateData();

                        string protocollForAdmin = "";
                        bool protocolWindow = false;
                        //bool SelectionWithoutClosing = false;
                        this.loadMulticontrols(ref rSelQuery, ref protocollForAdmin, ref protocolWindow);
                    }
                    else if (e.Cell.Column.sEquals( this.dsAdmin1.tblQueriesDef.ConditionColumn.ColumnName))
                    {
                        DataRowView v = (DataRowView)e.Cell.Row.ListObject;
                        dsAdmin.tblQueriesDefRow rSelQuery = (dsAdmin.tblQueriesDefRow)v.Row;

                        rSelQuery.ValueMin = "";
                        rSelQuery.Max = "";


                        if (qs2.core.generic.TranslateEx(e.Cell.Text.ToString()).sEquals(
                                new List<object> { qs2.core.generic.TranslateEx(qs2.core.sqlTxt.between),
                                                   qs2.core.generic.TranslateEx(qs2.core.sqlTxt.notBetween),
                                                   qs2.core.generic.TranslateEx(qs2.core.sqlTxt.like),
                                                   qs2.core.generic.TranslateEx(qs2.core.sqlTxt.In),
                                                   qs2.core.generic.TranslateEx(qs2.core.sqlTxt.NotIn),
                                                   qs2.core.generic.TranslateEx(qs2.core.sqlTxt.isNull),
                                                   qs2.core.generic.TranslateEx(qs2.core.sqlTxt.isNotNull) }
                            ))
                        {
                            rSelQuery.ComboAsDropDown = false;
                            rSelQuery.ComboAsDropDownCondition = "";
                        }

                        this.gridQueryDef.Refresh();
                        this.gridQueryDef.UpdateData();

                        string protocollForAdmin = "";
                        bool protocolWindow = false;
                        //bool SelectionWithoutClosing = false;
                        this.loadMulticontrols(ref rSelQuery, ref protocollForAdmin, ref protocolWindow);
                    }
                    else if (e.Cell.Column.ToString().Equals(this.dsAdmin1.tblQueriesDef.SortColumn.ColumnName))
                    {
                        DataRowView v = (DataRowView)e.Cell.Row.ListObject;
                        dsAdmin.tblQueriesDefRow rSelQuery = (dsAdmin.tblQueriesDefRow)v.Row;
                        try
                        {
                            this.gridQueryDef.UpdateData();
                            this.doSortAll(rSelQuery.Sort, rSelQuery.QryColumn);
                        }
                        catch (Exception ex)
                        {
                            string except = ex.ToString();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        private void gridQueryDef_Click(object sender, EventArgs e)
        {
            try
            {
                //if (this.isInEditMode)
                //{
                UltraGridRow selRowGrid = null;
                qs2.core.vb.dsAdmin.tblQueriesDefRow rSelQuery = this.getSelectedRow(false, ref selRowGrid);
                if (rSelQuery != null)
                {
                    string protocollForAdmin = "";
                    bool ProtocolWindow = false;

                    this.loadMulticontrols(ref rSelQuery, ref protocollForAdmin, ref ProtocolWindow);

                    if (protocollForAdmin.Trim() != "")
                    {
                        qs2.design.auto.multiControl.ownMCInfo.openProtocoll(ref protocollForAdmin);
                    }
                }
                //}
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void doAutoJoins(dsAdmin dsAutoJoinsFounded, DialogResult deleteOldJoins)
        {
            try
            {
                if (deleteOldJoins == DialogResult.Yes)
                {
                    System.Collections.ArrayList lstToDelete = new System.Collections.ArrayList();
                    foreach (dsAdmin.tblQueriesDefRow rQryFounded in this.dsAdmin1.tblQueriesDef)
                    {
                        lstToDelete.Add(rQryFounded);
                    }
                    foreach (dsAdmin.tblQueriesDefRow rQryFounded in lstToDelete)
                    {
                        rQryFounded.Delete();
                    }
                }

                if (dsAutoJoinsFounded.tblQueriesDef.Rows.Count > 0)
                {
                    foreach (dsAdmin.tblQueriesDefRow rQryFounded in dsAutoJoinsFounded.tblQueriesDef)
                    {
                        rQryFounded.ApplicationOwn = this.mainWindow.getSelectedApplication();
                        rQryFounded.ParticipantOwn = qs2.core.license.doLicense.eApp.ALL.ToString();        //this.mainWindow.IDParticipant;
                        dsAdmin.tblQueriesDefRow rNewQry = (dsAdmin.tblQueriesDefRow)this.dsAdmin1.tblQueriesDef.NewRow();
                        rNewQry.ItemArray = rQryFounded.ItemArray;
                        rNewQry.IDSelList = this.rSelList.ID;

                        this.dsAdmin1.tblQueriesDef.Rows.Add(rNewQry);

                        //this.dsAdmin1.tblQueriesDef.CopyToDataTable(this.dsAdmin1.tblQueriesDef, LoadOption.Upsert);
                    }
                }

                this.gridQueryDef.Refresh();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        private void txtSearch_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (txtSearch.Focused)
                {
                    this.searchFields(this.txtSearch.Text.Trim());
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

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.searchFields(this.txtSearch.Text.Trim());

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

        private void selectChapterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.selectChapter();

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
        private void showColumnChaptersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.showColumnChaptersToolStripMenuItem.Checked)
                {
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.colChaptersTransl].Hidden = false;
                    this.gridQueryDef.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
                }
                else
                {
                    this.gridQueryDef.DisplayLayout.Bands[0].Columns[this.colChaptersTransl].Hidden = true;
                    this.gridQueryDef.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
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
        private void tooltippsAnzeigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                foreach (UltraGridRow rowGridQuery in this.gridQueryDef.Rows)
                {
                    DataRowView v = (DataRowView)rowGridQuery.ListObject;
                    dsAdmin.tblQueriesDefRow rSelQuery = (dsAdmin.tblQueriesDefRow)v.Row;

                    this.doToolTipRow(rowGridQuery, rSelQuery);
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

    }

}
