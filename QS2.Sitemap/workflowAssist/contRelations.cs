using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using qs2.core.vb;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;




namespace qs2.sitemap.manage.wizardsDevelop
{
    public partial class contRelations : UserControl 
    {
        
        public bool isInEditMode = false;
        public qs2.sitemap.manage.wizardsDevelop.frmRelations mainWindow;
        public qs2.core.license.doLicense doLicense1 = new qs2.core.license.doLicense();
        public string IDApplication = "";
        public string IDParticipant = "";
        //public qs2.sitemap.ownControls.multiControl.ownMultiControl ownMultiControl1;
        public cTranslate cTranslate1 = new cTranslate();

        public qs2.core.vb.funct funct1 = new funct();

        public DataSet dsGrid = new DataSet();

        public bool wasVisibled = false;








        public contRelations()
        {
            InitializeComponent();
        }

        public void initControl()
        {
            //DataColumn newColNewTranslation = new System.Data.DataColumn(qs2.core.generic.columnNewTranslation, typeof(string));
            //this.dsAdmin1.vSelListEntriesObj.Columns.Add(newColNewTranslation);

            this.loadRes();

            this.filterToolStripMenuItem.Checked = true;
            qs2.core.vb.funct.setFilterGrid(this.gridInfrag1, this.filterToolStripMenuItem.Checked);

            this.btnRefresh.initControl();
            this.edit(false);

            this.comboApplication1.initControlxy(false, false, true);
            this.comboApplication1.loadApplications(false);
            
            this.loadData();
        }
        public void loadRes()
        {
            this.sqlAdmin1.initControl();

            this.btnRefresh.initControl();
            this.btnSearch.initControl();
            this.btnClose.initControl();

            this.btnRefresh.Text = qs2.core.language.sqlLanguage.getRes("Refresh");
            this.btnClose.Text = qs2.core.language.sqlLanguage.getRes("Close");
            this.ultraTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;

            this.lblSearch.Text = qs2.core.language.sqlLanguage.getRes("Search");
            this.chkTranslateRessources.Text = qs2.core.language.sqlLanguage.getRes("TranslateRessources");

            this.gridInfrag1.DisplayLayout.GroupByBox.Prompt = qs2.core.language.sqlLanguage.getRes("DragAColumneTo") + " ...";

            //this.gridInfrag1.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNameText].Hidden = true;

            //this.gridInfrag1.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNewTranslation].Header.Caption = qs2.core.language.sqlLanguage.getRes("NewTranslation");
            
            //this.gridInfrag1.DisplayLayout.Bands[this.dsAdmin1.tblCriteriaOpt.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblCriteriaOpt.FldShortColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("FldShort");
            //this.gridInfrag1.DisplayLayout.Bands[this.dsAdmin1.tblCriteriaOpt.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblCriteriaOpt.IDApplicationColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Application");
            //this.gridInfrag1.DisplayLayout.Bands[this.dsAdmin1.tblCriteriaOpt.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblCriteriaOpt.ParameterColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Parameter");
            //this.gridInfrag1.DisplayLayout.Bands[this.dsAdmin1.tblCriteriaOpt.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblCriteriaOpt.ValueColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Value");
            //this.gridInfrag1.DisplayLayout.Bands[this.dsAdmin1.tblCriteriaOpt.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblCriteriaOpt.ReferenzeColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Referenze");
            //this.gridInfrag1.DisplayLayout.Bands[this.dsAdmin1.tblCriteriaOpt.ParentRelations[0].RelationName].Header.Caption = qs2.core.language.sqlLanguage.getRes("CriteriaOpt");
            //this.gridInfrag1.DisplayLayout.Bands[this.dsAdmin1.tblCriteriaOpt.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblCriteriaOpt.VersionNrFromColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("VersionFrom");
            //this.gridInfrag1.DisplayLayout.Bands[this.dsAdmin1.tblCriteriaOpt.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblCriteriaOpt.VersionNrToColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("VersionTo");

            //this.gridInfrag1.DisplayLayout.Bands[this.dsAdmin1.tblRelationship.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblRelationship.FldShortParentColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("FldShortParent");
            //this.gridInfrag1.DisplayLayout.Bands[this.dsAdmin1.tblRelationship.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblRelationship.IDApplicationParentColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Application") + "Parent";
            //this.gridInfrag1.DisplayLayout.Bands[this.dsAdmin1.tblRelationship.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblRelationship.IDApplicationChildColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Application") + " Child";
            //this.gridInfrag1.DisplayLayout.Bands[this.dsAdmin1.tblRelationship.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblRelationship.FldShortChildColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("FldShortChild");
            //this.gridInfrag1.DisplayLayout.Bands[this.dsAdmin1.tblRelationship.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblRelationship.ConditionsColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Condition");
            //this.gridInfrag1.DisplayLayout.Bands[this.dsAdmin1.tblRelationship.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblRelationship.TypeColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Type");
            //this.gridInfrag1.DisplayLayout.Bands[this.dsAdmin1.tblRelationship.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblRelationship.TypeSubColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("TypeSub");
            //this.gridInfrag1.DisplayLayout.Bands[this.dsAdmin1.tblRelationship.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblRelationship.IDKeyColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Group");
            //this.gridInfrag1.DisplayLayout.Bands[this.dsAdmin1.tblRelationship.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblRelationship.IDGuidColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Key");
            //this.gridInfrag1.DisplayLayout.Bands[this.dsAdmin1.tblRelationship.ParentRelations[0].RelationName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Relationsship");
            //this.gridInfrag1.DisplayLayout.Bands[this.dsAdmin1.tblRelationship.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblRelationship.SortColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Sort");
            //this.gridInfrag1.DisplayLayout.Bands[this.dsAdmin1.tblRelationship.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblRelationship.ConditionsSubColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("ConditionsSub");

            //this.gridInfrag1.DisplayLayout.Bands[this.dsAdmin1.tblSelListEntriesObj.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblSelListEntriesObj.FldShortColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("FldShort");
            //this.gridInfrag1.DisplayLayout.Bands[this.dsAdmin1.tblSelListEntriesObj.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblSelListEntriesObj.IDApplicationColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Application");
            //this.gridInfrag1.DisplayLayout.Bands[this.dsAdmin1.tblSelListEntriesObj.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Chapter");
            //this.gridInfrag1.DisplayLayout.Bands[this.dsAdmin1.tblSelListEntriesObj.ParentRelations[0].RelationName].Columns[this.dsAdmin1.tblSelListEntriesObj.DescriptionColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Description");
             
            this.exportAsExcelToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("ExportAsExcel");
            //this.exportAsExcelToolStripMenuItem.Image = getRes.getImage(qs2.Resources.getRes.ePicture.ico_excel, 32, 32 );

            this.filterToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("Filter");

        }

        public void loadData()
        {
            try
            {
                this.isInEditMode = false;
                this.dsAdmin1.Clear();
                //string IDApplicationSelected = this.comboApplication1.getSelectedApplication().ToString();

                this.txtSearch.Text = "";
                this.comboApplication1.cboApplications.Value = "";
                this.comboApplication1.cboApplications.Text = "";

                //MessageBox.Show(enumTypResSearch.ToString());

                this.dsGrid = new DataSet();
                this.gridInfrag1.DataSource = null;
                this.gridInfrag1.DataMember = "";
                this.gridInfrag1.DataBind();

                this.sqlAdmin1.getvSelListEntriesObj(this.dsGrid, sqlAdmin.eTypeSelvSelListEntriesObj.All);
                this.gridInfrag1.DataSource = this.dsGrid;
                this.gridInfrag1.DataMember = this.dsGrid.Tables[0].TableName;
                this.gridInfrag1.DataBind();
                this.setCounterFound();
            

                //this.gridInfrag1.DisplayLayout.Bands[0].Columns[""].Hidden = false;
                
                //if (this.chkTranslateRessources.Checked)
                //{
                //    qs2.sitemap.ui.translateCriterias(this.gridInfrag1.Rows, this.IDParticipant, enumTypResSearch, false, true , qs2.core.generic.columnNewTranslation);
                //    this.gridInfrag1.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNameText].Hidden = false;
                //}
                //else
                //this.gridInfrag1.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNameText].Hidden = true;

                this.gridInfrag1.Selected.Rows.Clear();
                this.gridInfrag1.ActiveRow = null;

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void setCounterFound()
        {
            this.gridInfrag1.Text = qs2.core.language.sqlLanguage.getRes("Relations") + " (" + this.gridInfrag1.Rows.Count.ToString() + ")";
        }
        public void doSearch()
        {
            try
            {
                this.funct1.clearAllFilter(this.gridInfrag1);
                string txtToSearch = this.txtSearch.Text.Trim();
                //string IDApplicationSelected = "";      // this.comboApplication1.getSelectedApplication().ToString();

                //if (this.txtSearch.Text.Trim() != "" || IDApplicationSelected.Trim() != "")
                if (this.txtSearch.Text.Trim() != "" )
                {
                    this.funct1.setFilter(this.dsAdmin1.vSelListEntriesObj.IDSelListEntryIDResColumn.ColumnName,
                                            Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or,
                                            txtToSearch, Infragistics.Win.UltraWinGrid.FilterComparisionOperator.StartsWith,
                                            this.gridInfrag1, this.gridInfrag1.DisplayLayout.Bands[0].Index);

                    this.funct1.setFilter(this.dsAdmin1.vSelListEntriesObj.IDSelListEntrySublistIDResColumn.ColumnName,
                                            Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or,
                                            txtToSearch, Infragistics.Win.UltraWinGrid.FilterComparisionOperator.StartsWith,
                                            this.gridInfrag1, this.gridInfrag1.DisplayLayout.Bands[0].Index);

                    this.funct1.setFilter(this.dsAdmin1.vSelListEntriesObj.IDSelListEntryIDGroupStrColumn.ColumnName,
                                            Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or,
                                            txtToSearch, Infragistics.Win.UltraWinGrid.FilterComparisionOperator.StartsWith,
                                            this.gridInfrag1, this.gridInfrag1.DisplayLayout.Bands[0].Index);

                    this.funct1.setFilter(this.dsAdmin1.vSelListEntriesObj.IDSelListEntrySublistIDGroupStrColumn.ColumnName,
                                            Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or,
                                            txtToSearch, Infragistics.Win.UltraWinGrid.FilterComparisionOperator.StartsWith,
                                            this.gridInfrag1, this.gridInfrag1.DisplayLayout.Bands[0].Index);

                    this.funct1.setFilter(this.dsAdmin1.vSelListEntriesObj.CriteriaFldShortColumn.ColumnName,
                                            Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or,
                                            txtToSearch, Infragistics.Win.UltraWinGrid.FilterComparisionOperator.StartsWith,
                                            this.gridInfrag1, this.gridInfrag1.DisplayLayout.Bands[0].Index);

                    this.funct1.setFilter(this.dsAdmin1.vSelListEntriesObj.CriteriaControlTypeColumn.ColumnName,
                                            Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or,
                                            txtToSearch, Infragistics.Win.UltraWinGrid.FilterComparisionOperator.StartsWith,
                                            this.gridInfrag1, this.gridInfrag1.DisplayLayout.Bands[0].Index);

                    this.funct1.setFilter(this.dsAdmin1.vSelListEntriesObj.ObjectNameCombinationColumn.ColumnName,
                                            Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or,
                                            txtToSearch, Infragistics.Win.UltraWinGrid.FilterComparisionOperator.StartsWith,
                                            this.gridInfrag1, this.gridInfrag1.DisplayLayout.Bands[0].Index);

                    this.funct1.setFilter(this.dsAdmin1.vSelListEntriesObj.StayMedRecNColumn.ColumnName,
                                            Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or,
                                            txtToSearch, Infragistics.Win.UltraWinGrid.FilterComparisionOperator.StartsWith,
                                            this.gridInfrag1, this.gridInfrag1.DisplayLayout.Bands[0].Index);

                    this.funct1.setFilter(this.dsAdmin1.vSelListEntriesObj.ObjTypIDGroupColumn.ColumnName,
                                            Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or,
                                            txtToSearch, Infragistics.Win.UltraWinGrid.FilterComparisionOperator.StartsWith,
                                            this.gridInfrag1, this.gridInfrag1.DisplayLayout.Bands[0].Index);

                    //this.funct1.setFilter(this.dsAdmin1.vSelListEntriesObj.CriteriaIDApplicationColumn.ColumnName,
                    //                        Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or,
                    //                        IDApplicationSelected, Infragistics.Win.UltraWinGrid.FilterComparisionOperator.StartsWith,
                    //                        this.gridInfrag1, this.gridInfrag1.DisplayLayout.Bands[0].Index);

                    //this.funct1.setFilter(this.dsAdmin1.vSelListEntriesObj.IDSelListEntryIDApplicationColumn.ColumnName,
                    //                        Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or,
                    //                        IDApplicationSelected, Infragistics.Win.UltraWinGrid.FilterComparisionOperator.StartsWith,
                    //                        this.gridInfrag1, this.gridInfrag1.DisplayLayout.Bands[0].Index);

                    //this.funct1.setFilter(this.dsAdmin1.vSelListEntriesObj.IDSelListEntrySublistIDApplicationColumn.ColumnName,
                    //                        Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or,
                    //                        IDApplicationSelected, Infragistics.Win.UltraWinGrid.FilterComparisionOperator.StartsWith,
                    //                        this.gridInfrag1, this.gridInfrag1.DisplayLayout.Bands[0].Index);

                }

            }
            catch (Exception ex)
            {
                throw new Exception("doSearch: " + ex.ToString());
            }
        }

        public void edit(bool bEdit)
        {
           try
           {
               this.isInEditMode = false;

               this.btnRefresh.Enabled = true;
               this.btnAddCriteria.Visible = false;

               qs2.core.ui.editGrid(bEdit, this.gridInfrag1, true, Infragistics.Win.UltraWinGrid.AllowAddNew.Yes);
           }
           catch (Exception ex)
           {
               qs2.core.generic.getExep(ex.ToString(), ex.Message);
           }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.doSearch();

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
                    this.doSearch();
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

        private void gridInfrag1_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (e.Cell.Row.IsGroupByRow || e.Cell.IsFilterRowCell)
            {
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            }
            else
            {
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; 
            }   
        }
       private void gridInfrag1_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
       {
           e.Cancel = true;
       }

       private void btnCancel_Click(object sender, EventArgs e)
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
        
       private void btnClose_Click(object sender, EventArgs e)
       {
           this.mainWindow.Close();
       }

       private void exportAsExcelToolStripMenuItem_Click(object sender, EventArgs e)
       {
           try
           {
               this.Cursor = Cursors.WaitCursor;
               qs2.sitemap.export export1 = new qs2.sitemap.export();
               export1.doExport(this.gridInfrag1, Environment.SpecialFolder.Desktop, export.eTypExport.excel, null, "", "", null);
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
               qs2.core.vb.funct.setFilterGrid(this.gridInfrag1, this.filterToolStripMenuItem.Checked);

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
               this.gridInfrag1.Rows.ExpandAll(true);
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
               this.gridInfrag1.Rows.CollapseAll (true);
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

       private void comboApplication1_evOnChange(string selectedApplication)
       {
           try
           {
               this.Cursor = Cursors.WaitCursor;
                this.doSearch();
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

               //if (this.isInEditMode)
               //{
               //    if (e.Cell.Column.ToString().Equals(qs2.core.generic.columnNameText))
               //    {
               //        e.Cell.Row.Cells[qs2.core.generic.columnNewTranslation].Value = e.Cell.Row.Cells[qs2.core.generic.columnNameText].Value;
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

       private void btnAddCriteria_Click(object sender, EventArgs e)
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

       private void gridInfrag1_AfterRowActivate(object sender, EventArgs e)
       {

       }

       private void contRelations_VisibleChanged(object sender, EventArgs e)
       {
           try
           {
               if (this.Visible)
               {
                   if (!this.wasVisibled)
                   {
                       this.gridInfrag1.DisplayLayout.Bands[0].SortedColumns.Clear();
                       this.gridInfrag1.DisplayLayout.Bands[0].SortedColumns.Add(this.dsAdmin1.vSelListEntriesObj.ObjTypIDGroupColumn.ColumnName, false, true);
                       this.gridInfrag1.Refresh();

                       this.wasVisibled = true;
                   }
               }

           }
           catch (Exception ex)
           {
               qs2.core.generic.getExep(ex.ToString(), ex.Message);
           }
       }
        

    }
}
