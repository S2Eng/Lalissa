using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using qs2.core.vb;
using Infragistics.Win.UltraWinGrid;
using S2Extensions;

namespace qs2.sitemap.manage.wizardsDevelop
{
    public partial class contCriterias : UserControl 
    {
        private bool isInEditMode;
        private cTranslate cTranslate1 = new cTranslate();
        private int LastNrAdd = 0;
        private System.Collections.Generic.List<cKey> lstAddedRows = new List<cKey>();
        private bool VisibleIsInitialized = false;
        private eTypeUI _TypeUI;
        private bool AutoResOn;
        private doUI doUI1 = new doUI();

        public qs2.sitemap.manage.wizardsDevelop.frmCriterias mainWindow;
        public string IDApplication = "";
        public string IDParticipant = "";

        public class cKey
        {

        }
        
        public enum eTypeUI
        {
            Admin = 0,
            EditDefaultValues = 1
        }
        
        public contCriterias()
        {
            InitializeComponent();
        }

        public void initControl(eTypeUI TypeUI)
        {
            this._TypeUI = TypeUI;
            DataColumn newColNewTranslation = new System.Data.DataColumn(qs2.core.generic.columnNewTranslation, typeof(string));
            this.dsAdmin1 .tblCriteria.Columns.Add(newColNewTranslation);

            this.gridInfrag1xyxy.UpdateMode = UpdateMode.OnUpdate;

            this.loadRes();
            this.loadLists(this.IDApplication);

            this.btnSave.initControl();
            this.btnCancel.initControl();

            if (this._TypeUI == eTypeUI.Admin)
            {
                this.edit(false);
            }
            else
            {
                this.edit(true);
            }

            qs2.core.generic.getResourceTypes(null , this.cboResTyp);
            this.cboResTyp.Value = core.Enums.eResourceType.Label;

            if (qs2.core.ENV.ConnectedOnDesignerDB_QS2_Dev)
            {
                this.lblAutoAddRessources.Visible = true;
            }
            else
            {
                this.lblAutoAddRessources.Visible = false;
            }

        }
        public void initControl(string typApplication, string searchString)
        {
            this.chkTranslateRessources.Checked = true;
            this.cboResTyp.Visible = true;

            this.comboApplication1.initControlxy(true);
            this.comboApplication1.setApplication(typApplication);

            this.cboResTyp.Value = core.Enums.eResourceType.Label;
            this.txtSearch.Text = searchString.Trim();
        }

        public void loadRes()
        {
            try
            {
                this.sqlAdmin1.initControl();
                this.btnCancel.initControl();
                this.btnSave.initControl();
                this.btnSearch.initControl();
                this.btnEdit.initControl();
                this.btnClose.initControl();

                this.btnEdit.Text = qs2.core.language.sqlLanguage.getRes("Edit");
                this.btnCancel.Text = qs2.core.language.sqlLanguage.getRes("Cancel");
                this.btnClose.Text = qs2.core.language.sqlLanguage.getRes("Close");

                this.lblSearch.Text = qs2.core.language.sqlLanguage.getRes("Search");
                this.chkTranslateRessources.Text = qs2.core.language.sqlLanguage.getRes("TranslateRessources");

                this.gridInfrag1xyxy.DisplayLayout.GroupByBox.Prompt = qs2.core.language.sqlLanguage.getRes("DragAColumneTo") + " ...";

                qs2.sitemap.ui.loadGridCriterias(this.gridInfrag1xyxy.DisplayLayout.Bands[0], this.dsAdmin1);
                this.gridInfrag1xyxy.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNameText].Hidden = true;
                this.gridInfrag1xyxy.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNewTranslation].Header.Caption = qs2.core.language.sqlLanguage.getRes("NewTranslation");

                this.gridInfrag1xyxy.DisplayLayout.Bands[this.dsAdmin1.tblRelationship.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblRelationship.FldShortParentColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("FldShortParent");
                this.gridInfrag1xyxy.DisplayLayout.Bands[this.dsAdmin1.tblRelationship.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblRelationship.IDApplicationParentColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Application") + "Parent";
                this.gridInfrag1xyxy.DisplayLayout.Bands[this.dsAdmin1.tblRelationship.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblRelationship.IDApplicationChildColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Application") + " Child";
                this.gridInfrag1xyxy.DisplayLayout.Bands[this.dsAdmin1.tblRelationship.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblRelationship.FldShortChildColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("FldShortChild");
                this.gridInfrag1xyxy.DisplayLayout.Bands[this.dsAdmin1.tblRelationship.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblRelationship.ConditionsColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Condition");
                this.gridInfrag1xyxy.DisplayLayout.Bands[this.dsAdmin1.tblRelationship.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblRelationship.TypeColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Type");
                this.gridInfrag1xyxy.DisplayLayout.Bands[this.dsAdmin1.tblRelationship.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblRelationship.TypeSubColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("TypeSub");
                this.gridInfrag1xyxy.DisplayLayout.Bands[this.dsAdmin1.tblRelationship.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblRelationship.IDKeyColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Group");
                this.gridInfrag1xyxy.DisplayLayout.Bands[this.dsAdmin1.tblRelationship.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblRelationship.IDGuidColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Key");
                this.gridInfrag1xyxy.DisplayLayout.Bands[this.dsAdmin1.tblRelationship.ParentRelations[0].RelationName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Relationsship");
                this.gridInfrag1xyxy.DisplayLayout.Bands[this.dsAdmin1.tblRelationship.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblRelationship.SortColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Sort");
                this.gridInfrag1xyxy.DisplayLayout.Bands[this.dsAdmin1.tblRelationship.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblRelationship.ConditionsSubColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("ConditionsSub");

                this.gridInfrag1xyxy.DisplayLayout.Bands[this.dsAdmin1.tblSelListEntriesObj.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblSelListEntriesObj.FldShortColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("FldShort");
                this.gridInfrag1xyxy.DisplayLayout.Bands[this.dsAdmin1.tblSelListEntriesObj.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblSelListEntriesObj.IDApplicationColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Application");
                this.gridInfrag1xyxy.DisplayLayout.Bands[this.dsAdmin1.tblSelListEntriesObj.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Chapter");
                this.gridInfrag1xyxy.DisplayLayout.Bands[this.dsAdmin1.tblSelListEntriesObj.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblSelListEntriesObj.DescriptionColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Description");

                this.setUIAddNewBox();

                this.exportAsExcelToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("ExportAsExcel");
                this.filterToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("Filter");

                this.btnExpandAll.Text = qs2.core.language.sqlLanguage.getRes("ExpandAll");
                this.btnCollapsAll.Text = qs2.core.language.sqlLanguage.getRes("CollapsAll");

                if (this._TypeUI == eTypeUI.EditDefaultValues)
                {
                    this.mainWindow.Text = qs2.core.language.sqlLanguage.getRes("btnEditCriteriaDefaultValues");

                    foreach (UltraGridColumn col in this.gridInfrag1xyxy.DisplayLayout.Bands[0].Columns)
                    {
                        col.Hidden = true;
                    }

                    this.gridInfrag1xyxy.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblCriteria.DefaultValuesColumn.ColumnName].Hidden = false;
                    this.gridInfrag1xyxy.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblCriteria.FldShortColumn.ColumnName].Hidden = false;
                    this.gridInfrag1xyxy.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblCriteria.DefaultValuesCustomerColumn.ColumnName].Hidden = false;
                    this.gridInfrag1xyxy.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblCriteria.UsedColumn.ColumnName].Hidden = false;
                    this.gridInfrag1xyxy.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblCriteria.UsedCustomerColumn.ColumnName].Hidden = false;
                    this.chkTranslateRessources.Checked = true;
                    this.chkTranslateRessources.Visible = false;
                    this.cboResTyp.Visible = false;
                    this.btnAddCriteria.Visible = false;

                    this.gridInfrag1xyxy.DisplayLayout.ViewStyleBand = ViewStyleBand.Vertical;

                    this.btnExpandAll.Visible = false;
                    this.btnCollapsAll.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("loadRes: " + ex.ToString());
            }
        }
        
        public void setUIAddNewBox()
        {
            this.gridInfrag1xyxy.DisplayLayout.AddNewBox.Prompt = qs2.core.language.sqlLanguage.getRes("Add");
            this.gridInfrag1xyxy.DisplayLayout.Bands[0].AddButtonCaption = qs2.core.language.sqlLanguage.getRes("Criteria"); ;
            this.gridInfrag1xyxy.DisplayLayout.Bands[this.dsAdmin1.tblRelationship.ParentRelations[0].RelationName].AddButtonCaption = qs2.core.language.sqlLanguage.getRes("Relationship"); ;
            this.gridInfrag1xyxy.DisplayLayout.Bands[this.dsAdmin1.tblSelListEntriesObj.ParentRelations[0].RelationName].AddButtonCaption = qs2.core.language.sqlLanguage.getRes("Chapter"); ;
        }

        public void loadLists(string IDApplication)
        {
            this.dropDownApplications1.initControl(false);
            this.dropDownApplications1.loadData();
            System.Collections.Generic.List<string> ControlTypes = qs2.core.vb.funct.getEnumAsList(typeof(qs2.core.Enums.eControlType), this.gridInfrag1xyxy.DisplayLayout.ValueLists["ControlTypes"]);

            this.comboApplication1.initControlxy(true);
            this.comboApplication1.setApplication(IDApplication);

            this.dropDownSelListAndGroup1.initControl(true,false,  false,false, false, false);
            this.dropDownSelListAndGroup1.IDParticipant = this.IDParticipant;
        }

        public void loadData()
        {
            try
            {
                this.isInEditMode = false;

                this.dsAdmin1.tblCriteria.Clear();
                this.dsAdmin1.tblRelationship.Clear();
                this.dsAdmin1.tblSelListEntriesObj.Clear();
                
                core.license.doLicense.eApp enumAppFound = this.comboApplication1.getSelectedApplication();

                core.Enums.eResourceType enumTypResSearch = core.Enums.eResourceType.Label;
                if (this.cboResTyp.Value != null)
                    enumTypResSearch = qs2.core.generic.searchEnumRessourcenTyp((String)this.cboResTyp.Value);

                this.sqlAdmin1.getCriterias(this.dsAdmin1, sqlAdmin.eTypSelCriteria.search, this.txtSearch.Text.Trim(), enumAppFound.ToString(), false, false, false, "", "", false);

                this.gridInfrag1xyxy.Text = qs2.core.language.sqlLanguage.getRes("Criterias") + " (" + this.dsAdmin1.tblCriteria.Rows.Count.ToString() + ")";
                
                if (this.chkTranslateRessources.Checked)
                {
                    qs2.sitemap.ui.translateCriterias(this.gridInfrag1xyxy.Rows, this.IDParticipant, enumTypResSearch, false, true , qs2.core.generic.columnNewTranslation, false);
                    this.gridInfrag1xyxy.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNameText].Hidden = false;
                }
                else
                    this.gridInfrag1xyxy.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNameText].Hidden = true;

                this.gridInfrag1xyxy.Selected.Rows.Clear();
                this.gridInfrag1xyxy.ActiveRow = null;

                this.lstAddedRows.Clear();
                this.gridInfrag1xyxy.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblCriteria.UsedColumn.ColumnName].Width = 100;
                this.gridInfrag1xyxy.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblCriteria.UsedCustomerColumn.ColumnName].Width = 140;
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

                this.btnSave.Enabled = bEdit;
                this.btnCancel.Enabled = bEdit;
                this.btnEdit.Enabled = !bEdit;
                this.PanelDoAutoRes.Visible = true;     //bEdit;

                if (this._TypeUI == eTypeUI.EditDefaultValues)
                {
                    this.btnAddCriteria.Visible = false;
                }
                else
                {
                    this.btnAddCriteria.Visible = bEdit;
                }

                qs2.core.ui.editGrid(bEdit, this.gridInfrag1xyxy, true, Infragistics.Win.UltraWinGrid.AllowAddNew.Yes);
                if (this._TypeUI == eTypeUI.EditDefaultValues)
                {
                    this.gridInfrag1xyxy.DisplayLayout.AddNewBox.Hidden = true;
                }

           }
           catch (Exception ex)
           {
               qs2.core.generic.getExep(ex.ToString(), ex.Message);
           }
        }

        public bool save()
        {
            try            
            {
                if (this._TypeUI == eTypeUI.Admin)
                {
                    this.gridInfrag1xyxy.UpdateData();

                    qs2.core.dbBase.setConnection2(this.sqlAdmin1.daCriteria);
                    qs2.core.dbBase.setConnection2(this.sqlAdmin1.daCriteriaOpt);
                    qs2.core.dbBase.setConnection2(this.sqlAdmin1.daRelationship);
                    qs2.core.dbBase.setConnection2(this.sqlAdmin1.daSelListEntrysObj);

                    this.sqlAdmin1.daCriteria.Update(this.dsAdmin1.tblCriteria);

                    System.Data.DataRow[] arrNewTranslation = (System.Data.DataRow[])this.dsAdmin1.tblCriteria.Select(qs2.core.generic.columnNewTranslation + "<>''", "");
                    foreach (DataRow rCriteriaFound in arrNewTranslation)
                    {
                        this.cTranslate1.saveTranslation((string)rCriteriaFound[this.dsAdmin1.tblCriteria.FldShortColumn.ColumnName],
                                                            (string)rCriteriaFound[qs2.core.generic.columnNewTranslation],
                                                            (string)rCriteriaFound[qs2.core.generic.columnNewTranslation],
                                                            "",
                                                            (string)rCriteriaFound[this.dsAdmin1.tblCriteria.IDApplicationColumn.ColumnName], true);
                        rCriteriaFound[qs2.core.generic.columnNewTranslation] = "";
                    }

                    this.lstAddedRows.Clear();
                }
                else
                {
                    foreach (qs2.core.vb.dsAdmin.tblCriteriaRow rCriteria in this.dsAdmin1.tblCriteria)
                    {
                        string DefaultValuesCustomerTmp = "";
                        bool IsDefaultValuesCustomerTmp = false;
                        if (rCriteria.IsDefaultValuesCustomerNull())
                        {
                            IsDefaultValuesCustomerTmp = true;
                        }
                        else
                        {
                            DefaultValuesCustomerTmp = rCriteria.DefaultValuesCustomer.Trim();
                        }
                        this.sqlAdmin1.updateDefaultValuesCustomer(rCriteria.FldShort .Trim(), rCriteria.IDApplication.Trim(), DefaultValuesCustomerTmp, 
                                                                    IsDefaultValuesCustomerTmp, rCriteria.UsedCustomer);
                    }
                }

                this.saveAutoRessources();
                return true;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return false;
            }
        }

        public bool saveAutoRessources()
        {
            try
            {
                if (this.AutoResOn)
                {
                    string sProt = "";
                    int iCounterInserted = 0;
                    int iCounterUpdated = 0;
                    this.doUI1.addAutoRessources(ref this.gridInfrag1xyxy, ref this.lblAutoAddRessources, ref sProt, 
                                                    ref iCounterInserted, ref iCounterUpdated, this.chkAutoResOnlyAddRes.Checked);

                    if (sProt.Trim() != "")
                    {
                        frmProtocol frmProt = new frmProtocol();
                        frmProt.initControl();
                        frmProt.Text = "Auto-Insert-Update Ressources";
                        string sProtAll = iCounterInserted.ToString() + " Ressources inserted" + "\r\n" +
                                                                    iCounterUpdated.ToString() + " Ressources updated" + "\r\n" +
                                                                    "\r\n" + "\r\n" + sProt.Trim();
                        qs2.core.ENV.lstOpendChildForms.Add(frmProt);
                        frmProt.Show();
                        frmProt.ContProtocol1.setText(sProtAll);
                    }

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("saveAutoRessources: " + ex.ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.loadData();
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

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            this.txtSearch.Focus();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (System.Convert.ToInt32(e.KeyChar) == 13)
                    this.loadData();
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

        private void gridInfrag1_AfterRowInsert(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            core.license.doLicense.eApp enumAppFound = this.comboApplication1.getSelectedApplication();
            core.Enums.eResourceType enumTypResSearch = qs2.core.generic.searchEnumRessourcenTyp((String)this.cboResTyp.Value);

            if (e.Row.Band.Index == 0)
            {
                e.Row.Cells[this.dsAdmin1.tblCriteria.FldShortColumn.ColumnName].Value = "";
                e.Row.Cells[this.dsAdmin1.tblCriteria.IDApplicationColumn.ColumnName].Value = enumAppFound.ToString();
                e.Row.Cells[this.dsAdmin1.tblCriteria.ControlTypeColumn.ColumnName].Value = enumTypResSearch.ToString();
                e.Row.Cells[this.dsAdmin1.tblCriteria.SQLValueListSelectColumn.ColumnName].Value = "";
                e.Row.Cells[this.dsAdmin1.tblCriteria.SourceTableColumn.ColumnName].Value = "";
                e.Row.Cells[this.dsAdmin1.tblCriteria.ControlPatternColumn.ColumnName].Value = "";
                e.Row.Cells[this.dsAdmin1.tblCriteria.MaskInputColumn.ColumnName].Value = "";
                e.Row.Cells[this.dsAdmin1.tblCriteria.ControlMinValColumn.ColumnName].Value = "";
                e.Row.Cells[this.dsAdmin1.tblCriteria.ControlMaxValColumn.ColumnName].Value = "";
                e.Row.Cells[this.dsAdmin1.tblCriteria.UsedColumn.ColumnName].Value = 0;
                e.Row.Cells[this.dsAdmin1.tblCriteria.ValidateColumn.ColumnName].Value = 0;
                e.Row.Cells[this.dsAdmin1.tblCriteria.EditableColumn.ColumnName].Value = 1;
                e.Row.Cells[this.dsAdmin1.tblCriteria.UseInQueriesColumn.ColumnName].Value = 0;
                e.Row.Cells[this.dsAdmin1.tblCriteria.LicenseKeyColumn.ColumnName].Value = "";
                e.Row.Cells[this.dsAdmin1.tblCriteria.DescriptionColumn.ColumnName].Value = "";
                e.Row.Cells[this.dsAdmin1.tblCriteria.AliasFldShortColumn.ColumnName].Value = "";
                e.Row.Cells[this.dsAdmin1.tblCriteria.ShowAtColumn.ColumnName].Value = "";
                e.Row.Cells[this.dsAdmin1.tblCriteria.preferedColumn.ColumnName].Value = true;
                e.Row.Cells[this.dsAdmin1.tblCriteria.UsedCustomerColumn.ColumnName].Value = true;
            }
            else if (e.Row.Band.Index == 2 )
            {
                e.Row.Cells[this.dsAdmin1.tblRelationship.IDApplicationParentColumn.ColumnName].Value = enumAppFound.ToString();
                e.Row.Cells[this.dsAdmin1.tblRelationship.IDApplicationChildColumn.ColumnName].Value = enumAppFound.ToString();
                e.Row.Cells[this.dsAdmin1.tblRelationship.IDGuidColumn.ColumnName].Value = System.Guid.NewGuid();

                e.Row.Cells[this.dsAdmin1.tblRelationship.ConditionsColumn.ColumnName].Value = "";
                e.Row.Cells[this.dsAdmin1.tblRelationship.TypeColumn.ColumnName].Value = "";
                e.Row.Cells[this.dsAdmin1.tblRelationship.TypeSubColumn.ColumnName].Value = "";
                e.Row.Cells[this.dsAdmin1.tblRelationship.IDKeyColumn.ColumnName].Value = "";
                e.Row.Cells[this.dsAdmin1.tblRelationship.ConditionsSubColumn.ColumnName].Value = "";
                e.Row.Cells[this.dsAdmin1.tblRelationship.SortColumn.ColumnName].Value = -1;

            }
            else if (e.Row.Band.Index == 1)
            {
                e.Row.Cells[this.dsAdmin1.tblSelListEntriesObj.typIDGroupColumn .ColumnName].Value = sqlAdmin.eDbTypAuswObj.Criterias.ToString();
                e.Row.Cells[this.dsAdmin1.tblSelListEntriesObj.IDApplicationColumn.ColumnName].Value = enumAppFound.ToString();
                e.Row.Cells[this.dsAdmin1.tblSelListEntriesObj.DescriptionColumn .ColumnName].Value = "";
                e.Row.Cells[this.dsAdmin1.tblSelListEntriesObj.IDGuidColumn.ColumnName].Value = System.Guid.NewGuid();
                e.Row.Cells[this.dsAdmin1.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName].Value = System.DBNull.Value;
                e.Row.Cells[this.dsAdmin1.tblSelListEntriesObj.IDSelListEntrySublistColumn.ColumnName].Value = System.DBNull.Value;
                e.Row.Cells[this.dsAdmin1.tblSelListEntriesObj.IDClassificationColumn.ColumnName].Value = "";
                e.Row.Cells[this.dsAdmin1.tblSelListEntriesObj.SortColumn.ColumnName].Value = -1;
            }
        }

        private void gridInfrag1_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (this._TypeUI == eTypeUI.EditDefaultValues)
            {
                if (e.Cell.Column.sEquals(this.dsAdmin1.tblCriteria.DefaultValuesCustomerColumn.ColumnName) ||
                    e.Cell.Column.sEquals(this.dsAdmin1.tblCriteria.UsedCustomerColumn.ColumnName))
                {
                    e.Cell.Activation = Activation.AllowEdit;
                }
                else
                {
                    e.Cell.Activation = Activation.NoEdit;
                }
            }
            else
            {
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            }
        }

        private void gridInfrag1xyxy_CellChange(object sender, CellEventArgs e)
        {
            try
            {
                if (e.Cell.Column.sEquals(this.dsAdmin1.tblCriteria.UsedCustomerColumn.ColumnName) ||
                    e.Cell.Column.sEquals(this.dsAdmin1.tblCriteria.UsedColumn.ColumnName))
                {
                    this.gridInfrag1xyxy.UpdateData();
                    if ((bool)e.Cell.Row.Cells[this.dsAdmin1.tblCriteria.UsedColumn.ColumnName].Value == false)
                    {
                        e.Cell.Row.Cells[this.dsAdmin1.tblCriteria.UsedCustomerColumn.ColumnName].Value = true;
                        this.gridInfrag1xyxy.UpdateData();
                    }
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        private void gridInfrag1_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
       {
            qs2.core.ui.delGridRowYN(e);
       }
       
       private void chkTranslateRessources_CheckedChanged(object sender, EventArgs e)
       {
           try
           {
               this.Cursor = Cursors.WaitCursor;
               if (this.chkTranslateRessources.Focused)
               {
                   this.cboResTyp.Visible = this.chkTranslateRessources.Checked;
                   this.loadData();
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

       private void exportAsExcelToolStripMenuItem_Click(object sender, EventArgs e)
       {
           try
           {
               this.Cursor = Cursors.WaitCursor;
               qs2.sitemap.export export1 = new qs2.sitemap.export();
               export1.doExport(this.gridInfrag1xyxy, Environment.SpecialFolder.Desktop, export.eTypExport.excel, null, "", "", null);
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

       private void filterToolStripMenuItem_Click(object sender, EventArgs e)
       {
           try
           {
               this.Cursor = Cursors.WaitCursor;
               qs2.core.vb.funct.setFilterGrid(this.gridInfrag1xyxy, this.filterToolStripMenuItem.Checked);

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

       private void btnExpandAll_Click(object sender, EventArgs e)
       {
           try
           {
               this.Cursor = Cursors.WaitCursor;
               this.gridInfrag1xyxy.Rows.ExpandAll(true);
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

       private void btnCollapsAll_Click(object sender, EventArgs e)
       {
           try
           {
               this.Cursor = Cursors.WaitCursor;
               this.gridInfrag1xyxy.Rows.CollapseAll (true);
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

       private void cboResTyp_ValueChanged(object sender, EventArgs e)
       {
           try
           {
               this.Cursor = Cursors.WaitCursor;
               if (this.cboResTyp.Focused)
               {
                   this.loadData();
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

       private void comboApplication1_Load(object sender, EventArgs e)
       {

       }

       private void comboApplication1_evOnChange(string selectedApplication)
       {
           try
           {
               this.Cursor = Cursors.WaitCursor;
               if (this.cboResTyp.Focused)
               {
                   this.loadData();
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

       private void gridInfrag1_AfterCellUpdate(object sender, CellEventArgs e)
       {
           try
           {
               this.Cursor = Cursors.WaitCursor;

               if (this.isInEditMode)
               {
                   if (e.Cell.Column.ToString().Equals(qs2.core.generic.columnNameText))
                   {
                       e.Cell.Row.Cells[qs2.core.generic.columnNewTranslation].Value = e.Cell.Row.Cells[qs2.core.generic.columnNameText].Value;
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

       private void btnAddCriteria_Click(object sender, EventArgs e)
       {
           try
           {
               this.Cursor = Cursors.WaitCursor;
               this.addCriteria();
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
        
       public void addCriteria()
       {
           dsAdmin.tblCriteriaRow rNewCriteria = this.sqlAdmin1.addRowCriteria(this.dsAdmin1);
           this.LastNrAdd += 1;
           rNewCriteria.FldShort = "New Field " + this.LastNrAdd.ToString();
           this.gridInfrag1xyxy.Refresh();
           UltraGridRow gridRow = this.gridInfrag1xyxy.Rows.GetRowWithListIndex(this.dsAdmin1.tblCriteria.Rows.IndexOf(rNewCriteria));
           this.gridInfrag1xyxy.ActiveRow = gridRow;
       }

       private void contCriterias_VisibleChanged(object sender, EventArgs e)
       {
           try
           {
               this.Cursor = Cursors.WaitCursor;
               if (this.Visible && !this.VisibleIsInitialized)
               {
                   this.loadData();
                   this.VisibleIsInitialized = true;
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

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.edit(true);
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

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.loadData();
                this.edit(false);
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

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.save();
                this.edit(false);
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

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.mainWindow.Close();
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

        private void lblAutoAddRessources_LinkClicked(object sender, Infragistics.Win.FormattedLinkLabel.LinkClickedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.doUI1.autoAddResInGrid(ref this.gridInfrag1xyxy, ref this.lblAutoAddRessources, ref this.AutoResOn, ref this.chkAutoResOnlyAddRes, false);

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
