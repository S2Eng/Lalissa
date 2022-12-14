using System;
using System.Data;
using System.Windows.Forms;
using S2Extensions;

//Used in Lellissa: do not remove

namespace qs2.sitemap.workflowAssist
{
    public partial class contInfoFieldDB : UserControl
    {
        private bool _doUnvisibleAllOtherTables;
        private qs2.core.SysDB.sqlSysDB sqlSysDB1 = new qs2.core.SysDB.sqlSysDB();
        private qs2.core.vb.funct funct1 = new qs2.core.vb.funct();
        private qs2.core.ui ui1 = new qs2.core.ui();
        private Infragistics.Win.UltraWinGrid.UltraGridRow gridRowToSelect;

        public string searchColumnText= "";
        public string IDApplication = "";
        public string IDParticipant = "";
        public qs2.sitemap.workflowAssist.frmInfoFieldDB mainWindow;
        public bool withTranslation;
        public onSelection delOnSelection;
        public delegate void onSelection(bool close);
        public onAddWithoutClosing delOnAddWithoutClosing;
        public delegate void onAddWithoutClosing(int selectedTab, System.Collections.Generic.List<Infragistics.Win.UltraWinGrid.UltraGridRow> selRowsGrid, ref string protocoll, bool add, qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelList, bool addPlaceholder);
        public System.Collections.Generic.List<Infragistics.Win.UltraWinGrid.UltraGridRow> selRowsGrid = new System.Collections.Generic.List<Infragistics.Win.UltraWinGrid.UltraGridRow>();
        public onTranslate delDoTranslate;
        public delegate bool onTranslate(string IDRes, string  IDApplication, string defaultText);
        public string protocoll = "";
        public eTypUI typUI = new eTypUI();

        public enum eTypUI
        {
            selectionColumns = 0,
            selectionTables = 1,
            showOnly = 2
        }

        public contInfoFieldDB()
        {
            InitializeComponent();
        }

        public void initControl(System.Collections.ArrayList lstTablesToShow, bool doUnvisibleAllOtherTables)
        {
            try
            {
                this._doUnvisibleAllOtherTables = doUnvisibleAllOtherTables;
                sqlSysDB1.initControl();
                this.btnClose.initControl();
                
                this.loadRes();

                if (this.typUI == eTypUI.selectionColumns)
                {
                    this.loadTables(lstTablesToShow, doUnvisibleAllOtherTables);
                }
                else if (this.typUI == eTypUI.selectionTables)
                {
                    this.loadTables(lstTablesToShow, doUnvisibleAllOtherTables);
                    this.gridBagLayoutPanelColumnes.Visible = false;
                    this.gridBagLayoutPanelTables.Dock = DockStyle.Fill;
                    this.txtSearchTextColumn.Visible = false;
                    this.lblSearch.Visible = false;
                }
                else if (this.typUI == eTypUI.showOnly)
                {
                    this.loadColumns("");
                }

                this.translateEntryToolStripMenuItem.Visible = true;
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
                this.lblSearch.Text = qs2.core.language.sqlLanguage.getRes("Search");
                this.btnRefreshTables.OwnTooltipText = qs2.core.language.sqlLanguage.getRes("LoadAllTables");
                                
                this.translateEntryToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("TranslateEntry");
                this.translateEntryToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.ePicture.ico_Ressourcen, 32, 32 );

                this.getTitleGridColumns();

                this.ultraGridTables.DisplayLayout.Bands[0].Columns[this.dsSysDB1.TablesCatalog.TABLE_NAMEColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Table");
                
                this.ultraGridColumnes.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNameText].Header.Caption = qs2.core.language.sqlLanguage.getRes("Translation");
                this.ultraGridColumnes.DisplayLayout.Bands[0].Columns[this.dsSysDB1.COLUMNS.COLUMN_NAMEColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Column");
                this.ultraGridColumnes.DisplayLayout.Bands[0].Columns[this.dsSysDB1.COLUMNS.TABLE_NAMEColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Table");
                this.ultraGridColumnes.DisplayLayout.Bands[0].Columns[this.dsSysDB1.COLUMNS.DATA_TYPEColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Typ");

                if (!withTranslation)
                    this.ultraGridColumnes.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNameText].Hidden = true;

                if (this.typUI == eTypUI.selectionColumns || this.typUI == eTypUI.selectionTables)
                {
                    this.panelBottom.Visible = false;

                    this.ultraGridColumnes.DisplayLayout.Bands[0].Columns[this.dsSysDB1.COLUMNS.TABLE_NAMEColumn.ColumnName].Hidden = true;
                    this.ultraGridColumnes.DisplayLayout.Bands[0].Columns[this.dsSysDB1.COLUMNS.TABLE_CATALOGColumn.ColumnName].Hidden = true;
                    this.ultraGridColumnes.DisplayLayout.Bands[0].Columns[this.dsSysDB1.COLUMNS.TABLE_SCHEMAColumn.ColumnName].Hidden = true;

                    if (qs2.core.ENV.AdminSecure)
                    {
                        this.ultraGridColumnes.DisplayLayout.Bands[0].Columns[this.dsSysDB1.COLUMNS.ORDINAL_POSITIONColumn.ColumnName].Hidden = false;
                    }
                    else
                    {
                        this.ultraGridColumnes.DisplayLayout.Bands[0].Columns[this.dsSysDB1.COLUMNS.ORDINAL_POSITIONColumn.ColumnName].Hidden = true;
                    }
                  
                    this.ultraGridColumnes.DisplayLayout.Bands[0].Columns[this.dsSysDB1.COLUMNS.COLUMN_DEFAULTColumn.ColumnName].Hidden = true;
                    this.ultraGridColumnes.DisplayLayout.Bands[0].Columns[this.dsSysDB1.COLUMNS.IS_NULLABLEColumn.ColumnName].Hidden = true;
                    this.ultraGridColumnes.DisplayLayout.Bands[0].Columns[this.dsSysDB1.COLUMNS.CHARACTER_MAXIMUM_LENGTHColumn.ColumnName].Hidden = true;
                    this.ultraGridColumnes.DisplayLayout.Bands[0].Columns[this.dsSysDB1.COLUMNS.CHARACTER_OCTET_LENGTHColumn.ColumnName].Hidden = true;
                    this.ultraGridColumnes.DisplayLayout.Bands[0].Columns[this.dsSysDB1.COLUMNS.NUMERIC_PRECISIONColumn.ColumnName].Hidden = true;
                    this.ultraGridColumnes.DisplayLayout.Bands[0].Columns[this.dsSysDB1.COLUMNS.NUMERIC_PRECISION_RADIXColumn.ColumnName].Hidden = true;
                    this.ultraGridColumnes.DisplayLayout.Bands[0].Columns[this.dsSysDB1.COLUMNS.NUMERIC_SCALEColumn.ColumnName].Hidden = true;
                    this.ultraGridColumnes.DisplayLayout.Bands[0].Columns[this.dsSysDB1.COLUMNS.DATETIME_PRECISIONColumn.ColumnName].Hidden = true;
                    this.ultraGridColumnes.DisplayLayout.Bands[0].Columns[this.dsSysDB1.COLUMNS.CHARACTER_SET_CATALOGColumn.ColumnName].Hidden = true;
                    this.ultraGridColumnes.DisplayLayout.Bands[0].Columns[this.dsSysDB1.COLUMNS.CHARACTER_SET_SCHEMAColumn.ColumnName].Hidden = true;
                    this.ultraGridColumnes.DisplayLayout.Bands[0].Columns[this.dsSysDB1.COLUMNS.CHARACTER_SET_NAMEColumn.ColumnName].Hidden = true;
                    this.ultraGridColumnes.DisplayLayout.Bands[0].Columns[this.dsSysDB1.COLUMNS.COLLATION_CATALOGColumn.ColumnName].Hidden = true;
                    this.ultraGridColumnes.DisplayLayout.Bands[0].Columns[this.dsSysDB1.COLUMNS.COLLATION_SCHEMAColumn.ColumnName].Hidden = true;
                }
                else if (this.typUI == eTypUI.showOnly)
                {
                    this.gridBagLayoutPanelTables.Visible = false;
                    this.panelBottom.Visible = true;
                    this.txtSearchTextTable.Visible = false;
                    this.btnRefreshTables.Visible = false;
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void getTitleGridColumns()
        {
            try
            {
                this.ultraGridColumnes.Text = qs2.core.language.sqlLanguage.getRes("Columns") + (this.dsSysDB1.COLUMNS.Rows.Count > 0 ? " [" + qs2.core.language.sqlLanguage.getRes("Found") + this.dsSysDB1.COLUMNS.Rows.Count.ToString() + "]" : "");
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void loadTables(System.Collections.ArrayList lstTablesToShow, bool doUnvisibleAllOtherTables)
        {
            try
            {
                this.dsSysDB1.COLUMNS.Clear();
                this.ultraGridColumnes.Refresh();

                this.dsSysDB1.TablesCatalog.Clear();
                sqlSysDB1.getTables(this.dsSysDB1, core.SysDB.sqlSysDB.eTypSelColumns.all, "");
                this.ultraGridTables.Refresh();

                this.ultraGridTables.Selected.Rows.Clear();
                this.ultraGridTables.ActiveRow = null;

                string firstTableToSelect = "";
                if (lstTablesToShow != null)
                {
                    if (lstTablesToShow.Count > 0)
                    {
                        if (doUnvisibleAllOtherTables)
                        {
                            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rowGrid in this.ultraGridTables.Rows)
                            {
                                rowGrid.Hidden = true;
                            }
                        }
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rowGrid in this.ultraGridTables.Rows)
                        {
                            DataRowView v = (DataRowView)rowGrid.ListObject;
                            qs2.core.SysDB.dsSysDB.TablesCatalogRow rTable = (qs2.core.SysDB.dsSysDB.TablesCatalogRow)v.Row;
                            foreach (string tableToShow in lstTablesToShow)
                            {
                                if ((qs2.core.dbBase.dbSchema + rTable.TABLE_NAME).sEquals(tableToShow))
                                {
                                    rowGrid.Hidden = false;
                                    if (string.IsNullOrWhiteSpace(firstTableToSelect))
                                    {
                                        firstTableToSelect = rTable.TABLE_NAME.Trim();
                                        this.gridRowToSelect = rowGrid;
                                    }
                                }
                            }
                        }  
                    }
                }
                
                qs2.core.SysDB.dsSysDB.TablesCatalogRow[] arrTables = (qs2.core.SysDB.dsSysDB.TablesCatalogRow[])this.dsSysDB1.TablesCatalog.Select(this.dsSysDB1.TablesCatalog.TABLE_NAMEColumn.ColumnName + "='" + firstTableToSelect.Trim() + "'");
                if (arrTables.Length > 0)
                {
                    this.loadColumns(arrTables[0].TABLE_NAME);
                }

                this.ultraGridColumnes.Selected.Rows.Clear();
                this.ultraGridColumnes.ActiveRow = null;
                if (gridRowToSelect != null)
                {
                    this.ultraGridTables.ActiveRow = this.gridRowToSelect;
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
       
        public void loadColumns(string tableName)
        {
            try
            {
                this.dsSysDB1.COLUMNS.Clear();
                sqlSysDB1.getSysColumns(tableName, this.dsSysDB1, core.SysDB.sqlSysDB.eTypSelColumns.table);
                this.ultraGridColumnes.Refresh();

                this.ultraGridColumnes.Selected.Rows.Clear();
                this.ultraGridColumnes.ActiveRow = null;

                if (withTranslation)
                {
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rowGrod in this.ultraGridColumnes.Rows)
                    {
                        DataRowView v = (DataRowView)rowGrod.ListObject;
                        qs2.core.SysDB.dsSysDB.COLUMNSRow rColumn = (qs2.core.SysDB.dsSysDB.COLUMNSRow)v.Row;
                        rowGrod.Cells[qs2.core.generic.columnNameText].Value = qs2.core.language.sqlLanguage.getResAllProdukts(rColumn.COLUMN_NAME, this.IDParticipant, this.IDApplication, false);
                    }
                }

                this.getTitleGridColumns();

                if (!string.IsNullOrWhiteSpace(this.txtSearchTextColumn.Text))
                {
                    this.searchColumn(this.txtSearchTextColumn.Text);
                }

                if (!string.IsNullOrWhiteSpace(this.searchColumnText))
                {
                    this.txtSearchTextColumn.Text = this.searchColumnText.Trim();
                    this.searchColumn(this.txtSearchTextColumn.Text);
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        
        private void txtSearchText_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.searchColumn(this.txtSearchTextColumn.Text.Trim());
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void searchColumn(string txt)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.funct1.clearAllFilter(this.ultraGridColumnes);
                if (!string.IsNullOrWhiteSpace(txt))
                {
                    this.funct1.setFilter(this.dsSysDB1.COLUMNS.TABLE_NAMEColumn.ColumnName,
                                            Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or,
                                            txt, Infragistics.Win.UltraWinGrid.FilterComparisionOperator.StartsWith,
                                            this.ultraGridColumnes, this.ultraGridColumnes.DisplayLayout.Bands[0].Index);

                    this.funct1.setFilter(this.dsSysDB1.COLUMNS.COLUMN_NAMEColumn.ColumnName,
                                            Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or,
                                            txt, Infragistics.Win.UltraWinGrid.FilterComparisionOperator.StartsWith,
                                            this.ultraGridColumnes, this.ultraGridColumnes.DisplayLayout.Bands[0].Index);

                    this.funct1.setFilter(qs2.core.generic.columnNameText,
                        Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or,
                        txt, Infragistics.Win.UltraWinGrid.FilterComparisionOperator.StartsWith,
                        this.ultraGridColumnes, this.ultraGridColumnes.DisplayLayout.Bands[0].Index);
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
        
        public void searchTable(string txt)
        {
            try
            {
                this.funct1.clearAllFilter(this.ultraGridTables);
                if (!string.IsNullOrWhiteSpace(txt))
                {
                    this.funct1.setFilter(this.dsSysDB1.TablesCatalog.TABLE_NAMEColumn.ColumnName,
                                            Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or,
                                            txt, Infragistics.Win.UltraWinGrid.FilterComparisionOperator.StartsWith,
                                            this.ultraGridTables, this.ultraGridTables.DisplayLayout.Bands[0].Index);
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.mainWindow.Close();

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        
        private void ultraGridTables_BeforeRowActivate(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            try
            {
                if (this.ultraGridTables.Focused && !e.Row.IsGroupByRow && !e.Row.IsFilterRow && !e.Row.IsFilteredOut)
                {
                    e.Row.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    DataRowView v = (DataRowView)e.Row.ListObject;
                    qs2.core.SysDB.dsSysDB.TablesCatalogRow rTable = (qs2.core.SysDB.dsSysDB.TablesCatalogRow)v.Row;
                    this.loadColumnsForTable(rTable);
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void loadColumnsForTable(qs2.core.SysDB.dsSysDB.TablesCatalogRow rTable)
        {
            try
            {
                if (this.typUI == eTypUI.selectionColumns)
                {
                    this.loadColumns(rTable.TABLE_NAME);
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        private void ultraGridColumnes_BeforeRowActivate(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            try
            {
                e.Row.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        private void txtSearchTextTable_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.searchTable(this.txtSearchTextTable.Text.Trim());
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

        public bool doSelectRows (bool msgBox)
        {
            try
            {
                if (this.typUI == eTypUI.selectionColumns)
                {
                    this.selRowsGrid.Clear();
                    this.selRowsGrid = this.getSelectedRowsColumns(msgBox);
                    if (this.selRowsGrid.Count > 0)
                        return true;
                    else
                        return false;
                }
                else if (this.typUI == eTypUI.selectionTables)
                {
                    this.selRowsGrid.Clear();
                    this.selRowsGrid = this.getSelectedRowsTables(msgBox);
                    return this.selRowsGrid.Count > 0;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return false;
            }
        }

        public System.Collections.Generic.List<Infragistics.Win.UltraWinGrid.UltraGridRow> getSelectedRowsColumns(bool withMsgBox)
        {
            try
            {
                System.Collections.Generic.List< Infragistics.Win.UltraWinGrid.UltraGridRow> rSelected = new  System.Collections.Generic.List< Infragistics.Win.UltraWinGrid.UltraGridRow>();
                qs2.core.ui.getSelectedGridRows(this.ultraGridColumnes, rSelected, true);
                return rSelected;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return null;
            }
        }

        private System.Collections.Generic.List<Infragistics.Win.UltraWinGrid.UltraGridRow> getSelectedRowsTables(bool withMsgBox)
        {
            try
            {
                System.Collections.Generic.List<Infragistics.Win.UltraWinGrid.UltraGridRow> rSelected = new System.Collections.Generic.List<Infragistics.Win.UltraWinGrid.UltraGridRow>();
                qs2.core.ui.getSelectedGridRows(this.ultraGridTables, rSelected, true);
                return rSelected;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return null;
            }
        }

        private void ultraGridColumnes_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ui1.evDoubleClickOK(ref sender,ref e, ref this.ultraGridColumnes))
                {
                    this.delOnSelection?.Invoke(true);
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        private void btnRefreshTables_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.loadTables(null, this._doUnvisibleAllOtherTables);
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

        private void ultraGridTables_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.typUI == eTypUI.selectionTables)
                {
                    if (this.ui1.evDoubleClickOK(ref sender, ref e, ref this.ultraGridTables))
                    {
                        this.delOnSelection?.Invoke(true);
                    } 
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public core.SysDB.dsSysDB.COLUMNSRow getSelectedColumn(bool msgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow actRow)
        {
            try
            {
                if (this.ultraGridColumnes.ActiveRow != null)
                {
                    DataRowView v = (DataRowView)this.ultraGridColumnes.ActiveRow.ListObject;
                    core.SysDB.dsSysDB.COLUMNSRow rSelCol = (core.SysDB.dsSysDB.COLUMNSRow)v.Row;
                    actRow = this.ultraGridColumnes.ActiveRow;
                    return rSelCol;
                }
                else
                {
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoEntrySelected"), MessageBoxButtons.OK, "");
                    return null;
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return null;
            }
        }

        public core.SysDB.dsSysDB.TablesCatalogRow getSelectedTable(bool msgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow actRow)
        {
            try
            {
                if (this.ultraGridTables.ActiveRow != null)
                {
                    DataRowView v = (DataRowView)this.ultraGridTables.ActiveRow.ListObject;
                    core.SysDB.dsSysDB.TablesCatalogRow rSelTable = (core.SysDB.dsSysDB.TablesCatalogRow)v.Row;
                    actRow = this.ultraGridTables.ActiveRow;
                    return rSelTable;
                }
                else
                {
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoEntrySelected"), MessageBoxButtons.OK, "");
                    return null;
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return null;
            }
        }

        private void translateEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow actGridRow = null;
                core.SysDB.dsSysDB.COLUMNSRow rSelCol = this.getSelectedColumn(true, ref actGridRow);
                if (rSelCol != null && this.delDoTranslate.Invoke(rSelCol.COLUMN_NAME, this.IDApplication, actGridRow.Cells[qs2.core.generic.columnNameText].Value.ToString().Trim()))
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow actGridRowTable = null;
                    core.SysDB.dsSysDB.TablesCatalogRow rSelTable = this.getSelectedTable(true, ref actGridRowTable);
                    if (rSelTable != null)
                    {
                        this.loadColumnsForTable(rSelTable);
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
