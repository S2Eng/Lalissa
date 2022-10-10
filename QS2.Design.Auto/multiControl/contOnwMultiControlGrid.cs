using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.Misc;



namespace qs2.design.auto.multiControl
{


    public partial class contOnwMultiControlGrid : UserControl
    {

        public bool IsInitialized = false;

        public string colSelection = "Select";
        public UltraDropDownButton _DropDown;
        public qs2.design.auto.multiControl.ownMultiControl ownMC = null;

        public eTypeUI _TypeUI;
        public enum eTypeUI
        {
            SelList = 0,
            Objects = 1,
        }

        public bool bLockUserInput = false;
        public bool AlwaysAllSelected = false;
        public bool _KeyIsIDOwnStr = false;








        public contOnwMultiControlGrid()
        {
            InitializeComponent();
        }

        private void contOnwMultiControlGrid_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {
                if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
                {
                    return;
                }

                if (!this.IsInitialized)
                {
                    this.btnSelectAll.Text = qs2.core.language.sqlLanguage.getRes("All4");
                    this.lblSelectNone.Text = qs2.core.language.sqlLanguage.getRes("None");

                    this.optTypeCombination.CheckedIndex = 0;
                    this.optTypeCombination.Items[0].DisplayText = qs2.core.language.sqlLanguage.getRes(qs2.core.sqlTxt.and.ToString().Trim());
                    this.optTypeCombination.Items[1].DisplayText = qs2.core.language.sqlLanguage.getRes(qs2.core.sqlTxt.or.ToString().Trim());

                    this.IsInitialized = true;
                }

            }
            catch(Exception ex)
            {
                throw new Exception("contOnwMultiControlGrid.initControl:" + ex.ToString());
            }
        }

        public void SetUIGrid(eTypeUI TypeUI)
        {
            try
            {
                bool colSelExists = false;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this.grid.DisplayLayout.Bands[0].Columns)
                {
                    col.Hidden = true;
                    if (col.Key.Trim().ToLower().Equals(this.colSelection.Trim().ToLower()))
                    {
                        colSelExists = true;
                    }
                }
                if (!colSelExists)
                {
                    this.grid.DisplayLayout.Bands[0].Columns.Add(this.colSelection.Trim());
                }
                this.grid.DisplayLayout.Bands[0].Columns[this.colSelection].Hidden = false;
                this.grid.DisplayLayout.Bands[0].Columns[this.colSelection].DataType = typeof(bool);
                this.grid.DisplayLayout.Bands[0].Columns[this.colSelection].Header.Caption = qs2.core.language.sqlLanguage.getRes("Selection");
                this.grid.DisplayLayout.Bands[0].Columns[this.colSelection].Header.VisiblePosition = 1;
                this.grid.DisplayLayout.Bands[0].Columns[this.colSelection].Width = 60;
                this.grid.DisplayLayout.Bands[0].Columns[this.colSelection].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;

                if (TypeUI == eTypeUI.SelList)
                {
                    this.grid.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.DescriptionColumn.ColumnName].Hidden = false;
                    this.grid.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.DescriptionColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Text");
                    this.grid.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.DescriptionColumn.ColumnName].Header.VisiblePosition = 2;
                    this.grid.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.DescriptionColumn.ColumnName].Width = 400;

                    this.grid.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName].Hidden = false;
                    this.grid.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Nr");
                    this.grid.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName].Header.VisiblePosition = 3;
                    this.grid.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName].Width = 50;
                    this.grid.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                    this.grid.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else if (TypeUI == eTypeUI.Objects)
                {
                    this.grid.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblObject.NameCombinationColumn.ColumnName].Hidden = false;
                    this.grid.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblObject.NameCombinationColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("NameCombination");
                    this.grid.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblObject.NameCombinationColumn.ColumnName].Header.VisiblePosition = 2;
                    this.grid.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblObject.NameCombinationColumn.ColumnName].Width = 350;

                    //this.grid.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblObject.ActiveColumn.ColumnName].Hidden = false;
                    //this.grid.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblObject.ActiveColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Active");
                    //this.grid.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblObject.ActiveColumn.ColumnName].Header.VisiblePosition = 3;
                    //this.grid.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblObject.ActiveColumn.ColumnName].Width = 50;

                    //this.grid.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblObject.ExtIDColumn.ColumnName].Hidden = false;
                    //this.grid.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblObject.ExtIDColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Nr");
                    //this.grid.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblObject.ExtIDColumn.ColumnName].Header.VisiblePosition = 4;
                    //this.grid.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblObject.ExtIDColumn.ColumnName].Width = 50;
                }

                this.grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

            }
            catch (Exception ex)
            {
                throw new Exception("contOnwMultiControlGrid.SetUIGrid:" + ex.ToString());
            }
        }
        public void loadData(ref qs2.core.vb.dsAdmin dsAdminToShow, ref qs2.core.vb.dsObjects dsObjectsToShow, eTypeUI TypeUI,
                                string Combination, bool KeyIsIDOwnStr)
        {
            try
            {
                this._KeyIsIDOwnStr = KeyIsIDOwnStr;
                this._TypeUI = TypeUI;
                this.dsAdmin1.tblSelListEntries.Clear();
                this.dsObjects1.tblObject.Clear();
                if (Combination.Trim() != "")
                {
                    this.optTypeCombination.Value = Combination.Trim();
                }
                else
                {
                    this.optTypeCombination.Value = qs2.core.sqlTxt.and.ToString().Trim();
                }

                this.grid.DataSource = null;
                this.grid.DataMember = "";
                this.grid.DataBind();

                if (TypeUI == eTypeUI.SelList)
                {
                    this.dsAdmin1 = dsAdminToShow;
                    this.grid.DataSource = dsAdminToShow;
                    this.grid.DataMember = dsAdminToShow.tblSelListEntries.TableName;
                    this.grid.DataBind();
                    this.SetUIGrid(TypeUI);
                    this.selectAllNone(false, TypeUI);
                    this.setTextOnUI(TypeUI);

                    this.grid.DisplayLayout.Bands[0].SortedColumns.Clear();
                    this.grid.DisplayLayout.Bands[0].SortedColumns.Add(this.dsAdmin1.tblSelListEntries.DescriptionColumn.ColumnName, false);
                }
                else if (TypeUI == eTypeUI.Objects)
                {
                    this.dsObjects1 = dsObjectsToShow;
                    this.grid.DataSource = dsObjectsToShow;
                    this.grid.DataMember = dsObjectsToShow.tblObject.TableName;
                    this.grid.DataBind();
                    this.SetUIGrid(TypeUI);
                    this.selectAllNone(false, TypeUI);
                    this.setTextOnUI(TypeUI);

                    this.grid.DisplayLayout.Bands[0].SortedColumns.Clear();
                    this.grid.DisplayLayout.Bands[0].SortedColumns.Add(this.dsObjects1.tblObject.ActiveColumn.ColumnName, true);
                    this.grid.DisplayLayout.Bands[0].SortedColumns.Add(this.dsObjects1.tblObject.NameCombinationColumn.ColumnName, false);
                }

                this.grid.Rows.ExpandAll(true);

            }
            catch (Exception ex)
            {
                throw new Exception("contOnwMultiControlGrid.loadData:" + ex.ToString());
            }
        }
        public void clearData()
        {
            try
            {
                this.dsAdmin1.tblSelListEntries.Clear();
                this.dsObjects1.tblObject.Clear();

                if (this._TypeUI == eTypeUI.SelList)
                {
                    this.grid.DataSource = this.dsAdmin1;
                    this.grid.DataMember = this.dsAdmin1.tblSelListEntries.TableName;
                    this.grid.DataBind();
                }
                else if (this._TypeUI == eTypeUI.Objects)
                {
                    this.grid.DataSource = this.dsObjects1;
                    this.grid.DataMember = this.dsObjects1.tblObject.TableName;
                    this.grid.DataBind();
                }

                this.grid.Refresh();
                this.setTextOnUI(this._TypeUI);
            }
            catch (Exception ex)
            {
                throw new Exception("contOnwMultiControlGrid.clearData:" + ex.ToString());
            }
        }
        public void selectAllNone(bool bOn, eTypeUI TypeUI)
        {
            try
            {
                if (this.AlwaysAllSelected)
                {
                    bOn = true;
                }

                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rRowGrid in this.grid.Rows)
                {
                    DataRowView v = (DataRowView)rRowGrid.ListObject;
                    if (TypeUI == eTypeUI.SelList)
                    {
                        qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListAct = (qs2.core.vb.dsAdmin.tblSelListEntriesRow)v.Row;
                        rRowGrid.Cells[this.colSelection].Value = bOn;
                    }
                    else if (TypeUI == eTypeUI.Objects)
                    {
                        qs2.core.vb.dsObjects.tblObjectRow rObjAct = (qs2.core.vb.dsObjects.tblObjectRow)v.Row;
                        rRowGrid.Cells[this.colSelection].Value = bOn;
                    }
                }
                if (bOn)
                {
                }
                else
                {
                }
                this.setTextOnUI(TypeUI);
            }
            catch (Exception ex)
            {
                throw new Exception("contOnwMultiControlGrid.selectAllNone:" + ex.ToString());
            }
        }
        public string getValue()
        {
            try
            {
                string strValueTmp = "";
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rRowGrid in this.grid.Rows)
                {
                    DataRowView v = (DataRowView)rRowGrid.ListObject;
                    if (this._TypeUI == eTypeUI.SelList)
                    {
                        qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListAct = (qs2.core.vb.dsAdmin.tblSelListEntriesRow)v.Row;
                        if ((bool)rRowGrid.Cells[this.colSelection].Value == true)
                        {
                            if (this._KeyIsIDOwnStr)
                            {
                                strValueTmp += "'" + rSelListAct.IDOwnStr.Trim() + "'" + ";";
                            }
                            else
                            {
                                strValueTmp += rSelListAct.IDOwnInt.ToString() + ";";
                            }
                        }
                    }
                    else if (this._TypeUI == eTypeUI.Objects)
                    {
                        qs2.core.vb.dsObjects.tblObjectRow rObjAct = (qs2.core.vb.dsObjects.tblObjectRow)v.Row;
                        if ((bool)rRowGrid.Cells[this.colSelection].Value == true)
                        {
                            strValueTmp += rObjAct.ID.ToString() + ";";
                        }
                    }
                }
                return strValueTmp;
            }
            catch (Exception ex)
            {
                throw new Exception("contOnwMultiControlGrid.getValue:" + ex.ToString());
            }
        }
        public void setValue(ref string strValueToSet)
        {
            try
            {
                this.selectAllNone(false, this._TypeUI);

                if (strValueToSet.Trim() != "")
                {
                    System.Collections.Generic.List<string> lstValues = qs2.core.generic.readStrVariables(strValueToSet.Trim());
                    foreach (string sValue in lstValues)
                    {
                        int iValue = -999;
                        if (!this._KeyIsIDOwnStr)
                        {
                            iValue = System.Convert.ToInt32(sValue.Trim()); 
                        }
                        
                        if (this._TypeUI == eTypeUI.SelList)
                        {
                            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rRowGrid in this.grid.Rows)
                            {
                                DataRowView v = (DataRowView)rRowGrid.ListObject;
                                qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListAct = (qs2.core.vb.dsAdmin.tblSelListEntriesRow)v.Row;
                                if (this._KeyIsIDOwnStr)
                                {
                                    if (("'" + rSelListAct.IDOwnStr + "'").Equals(sValue))
                                    {
                                        rRowGrid.Cells[this.colSelection].Value = true;
                                    }
                                }
                                else
                                {
                                    if (rSelListAct.IDOwnInt.Equals(iValue))
                                    {
                                        rRowGrid.Cells[this.colSelection].Value = true;
                                    }
                                }
                            }
                        }
                        else if (this._TypeUI == eTypeUI.Objects)
                        {
                            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rRowGrid in this.grid.Rows)
                            {
                                DataRowView v = (DataRowView)rRowGrid.ListObject;
                                qs2.core.vb.dsObjects.tblObjectRow rObjAct = (qs2.core.vb.dsObjects.tblObjectRow)v.Row;
                                if (rObjAct.ID.Equals(iValue))
                                {
                                    rRowGrid.Cells[this.colSelection].Value = true;
                                }
                            }
                        }
                    } 
                }

                this.setTextOnUI(this._TypeUI);

            }
            catch (Exception ex)
            {
                throw new Exception("contOnwMultiControlGrid.setValue:" + ex.ToString());
            }
        }
        public void setTextOnUI(eTypeUI TypeUI)
        {
            try
            {
                this._DropDown.Text = "";
                int iSelected = 0;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rRowGrid in this.grid.Rows)
                {
                    DataRowView v = (DataRowView)rRowGrid.ListObject;
                    if (TypeUI == eTypeUI.SelList)
                    {
                        qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListAct = (qs2.core.vb.dsAdmin.tblSelListEntriesRow)v.Row;
                        if ((bool)rRowGrid.Cells[this.colSelection].Value == true)
                        {
                            iSelected += 1;
                            this._DropDown.Text += rRowGrid.Cells[this.dsAdmin1.tblSelListEntries.DescriptionColumn.ColumnName].Value.ToString().Trim() + " | ";
                        }
                    }
                    else if (TypeUI == eTypeUI.Objects)
                    {
                        qs2.core.vb.dsObjects.tblObjectRow rObjAct = (qs2.core.vb.dsObjects.tblObjectRow)v.Row;
                        if ((bool)rRowGrid.Cells[this.colSelection].Value == true)
                        {
                            iSelected += 1;
                            this._DropDown.Text += rRowGrid.Cells[this.dsObjects1.tblObject.NameCombinationColumn.ColumnName].Value.ToString().Trim() + " | ";
                        }
                    }
                }
                if (iSelected == 0)
                {
                    this._DropDown.Text = qs2.core.language.sqlLanguage.getRes("NoSelection2");  
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contOnwMultiControlGrid.setTextOnUI:" + ex.ToString());
            }
        }

        private void grid_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.Column.ToString().Trim().ToLower().Equals(this.colSelection.Trim().ToLower()))
                {
                    if (this.bLockUserInput)
                    {
                        e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    }
                    else
                    {
                        e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    }
                }
                else
                {
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contOnwMultiControlGrid.grid_BeforeCellActivate:" + ex.ToString());
            }
        }
        private void grid_AfterCellActivate(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception("contOnwMultiControlGrid.grid_AfterCellActivate:" + ex.ToString());
            }
        }
        private void grid_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            try
            {
                this.grid.UpdateData();
                this.setTextOnUI(this._TypeUI);
                this.ownMC.ownMCEvents1.ControlValueChanged(sender, e);
            }
            catch (Exception ex)
            {
                throw new Exception("contOnwMultiControlGrid.grid_CellChange:" + ex.ToString());
            }

        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.selectAllNone(true, this._TypeUI);
                this.ownMC.ownMCEvents1.ControlValueChangedDo(sender, e);
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
        private void lblSelectNone_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.selectAllNone(false, this._TypeUI);
                this.ownMC.ownMCEvents1.ControlValueChangedDo(sender, e);
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

        private void contOnwMultiControlGrid_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
                {
                     this.doVisible();
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
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        public void doVisible()
        {
            try
            {
                this.Visible = true;
            }
            catch (Exception ex)
            {
                throw new Exception("doVisible: " + ex.ToString());
            }
        }
  
    }
}
