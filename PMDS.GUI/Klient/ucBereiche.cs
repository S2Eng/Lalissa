using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PMDS.Global;
using PMDS.Global.db.Global;
using PMDS.db.Entities;
using PMDS.DB;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinListView;
using PMDS.Global.db.Patient;



namespace PMDS.GUI.Klient
{
    

    public partial class ucBereiche : UserControl
    {
        public Guid _IDAbteilung;
        public bool abort = true;
        public frmBereiche mainWindow = null;

        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
        public UIGlobal UIGlobal1 = new UIGlobal();








        public ucBereiche()
        {
            InitializeComponent();
        }



        private void ucAbteilungen_Load(object sender, EventArgs e)
        {

        }


        public void initControl(Guid IDAbteilung)
        {
            try
            {
                this._IDAbteilung = IDAbteilung;

                this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);
                this.btnAdd.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32);
                this.btnDel.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Minus, 32, 32);

                this.loadData();
            }
            catch (Exception ex)
            {
                throw new Exception("ucBereiche.initControl: " + ex.ToString());
            }
        }
        public bool loadData()
        {
            try
            {
                this.dsAbteilung1.Clear();
                this.dbAbteilung1.getBereicheByAbteilung(this._IDAbteilung, this.dsAbteilung1);
                this.gridBereiche.Refresh();

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("ucBereiche.loadData: " + ex.ToString());
            }
        }

        public bool validateData()
        {
            try
            {
                foreach (UltraGridRow r in this.gridBereiche.Rows)
                {
                    this.errorProvider1.SetError(this.gridBereiche, "");

                    dsAbteilung.BereichRow rBereich = (dsAbteilung.BereichRow)((System.Data.DataRowView)r.ListObject).Row;

                    if (rBereich.RowState != DataRowState.Deleted)
                    {
                        if (rBereich.Bezeichnung.Trim() == "")
                        {
                            this.errorProvider1.SetError(this.gridBereiche, "Error");
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bereich: Es wurde kein Text angegeben!", "", MessageBoxButtons.OK);
                            this.gridBereiche.ActiveRow = r;
                            return false;
                        }
                    }

                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucBereiche.validateData: " + ex.ToString());
            }
        }
        public bool saveData()
        {
            try
            {
                if (!this.validateData())
                {
                    return false;
                }

                this.dbAbteilung1.daBereicheByIDAbteilung.Update(this.dsAbteilung1.Bereich);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucBereiche.saveData: " + ex.ToString());
            }
        }

        public dsAbteilung.BereichRow getSelectedRow(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                if (this.gridBereiche.ActiveRow != null)
                {
                    if (this.gridBereiche.ActiveRow.IsGroupByRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.gridBereiche.ActiveRow.ListObject;
                        dsAbteilung.BereichRow rSelRow = (dsAbteilung.BereichRow)v.Row;
                        gridRow = this.gridBereiche.ActiveRow;
                        return rSelRow;
                    }
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucBereiche.getSelectedRow: " + ex.ToString());
            }
        }


        public bool addRow()
        {
            try
            {
                dsAbteilung.BereichRow rBereich = this.dbAbteilung1.getNewRowBereich(this.dsAbteilung1);
                rBereich.IDAbteilung = this._IDAbteilung;

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("ucBereiche.addRow: " + ex.ToString());
            }
        }
        public bool deleteRow()
        {
            try
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                dsAbteilung.BereichRow rBereich = this.getSelectedRow(true, ref gridRow);
                if (rBereich != null)
                {
                    rBereich.Delete();
                    this.gridBereiche.Refresh();
                }

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("ucBereiche.delRow: " + ex.ToString());
            }
        }

        private void gridAbteilungen_AfterCellActivate(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridAbteilungen_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.Column.ToString().Trim().Equals(("xyxy").Trim().ToLower()))
                {
                    e.Cell.Activation = Activation.NoEdit;
                }
                else
                {
                    e.Cell.Activation = Activation.AllowEdit;
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void gridAbteilungen_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridBereiche))
                {

                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void gridAbteilungen_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridBereiche))
                {

                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.saveData())
                {
                    this.abort = false;
                    this.mainWindow.Close();
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.abort = true;
                this.mainWindow.Close();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
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
                this.addRow();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
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
                this.deleteRow();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
