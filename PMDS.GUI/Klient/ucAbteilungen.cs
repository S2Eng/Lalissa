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
    

    public partial class ucAbteilungen : UserControl
    {
        public Guid _IDKlinik;
        public bool abort = true;
        public frmAbteilungen mainWindow = null;

        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
        public UIGlobal UIGlobal1 = new UIGlobal();








        public ucAbteilungen()
        {
            InitializeComponent();
        }



        private void ucAbteilungen_Load(object sender, EventArgs e)
        {

        }


        public void initControl(Guid IDKlinik)
        {
            try
            {
                this._IDKlinik = IDKlinik;

                this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);
                this.btnAdd.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32);
                this.btnDel.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Minus, 32, 32);

                this.loadData();
            }
            catch (Exception ex)
            {
                throw new Exception("ucAbteilungen.initControl: " + ex.ToString());
            }
        }
        public bool loadData()
        {
            try
            {
                this.dsAbteilung1.Clear();
                this.dbAbteilung1.getAbteilungenByKlinik2(this._IDKlinik, this.dsAbteilung1);
                this.gridAbteilungen.Refresh();

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("ucAbteilungen.loadData: " + ex.ToString());
            }
        }

        public bool validateData()
        {
            try
            {
                foreach (UltraGridRow r in this.gridAbteilungen.Rows)
                {
                    this.errorProvider1.SetError(this.gridAbteilungen, "");

                    dsAbteilung.Abteilung2Row rAbteilung = (dsAbteilung.Abteilung2Row)((System.Data.DataRowView)r.ListObject).Row;

                    if (rAbteilung.RowState != DataRowState.Deleted)
                    {
                        if (rAbteilung.Bezeichnung.Trim() == "")
                        {
                            this.errorProvider1.SetError(this.gridAbteilungen, "Error");
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Abteilung: Es wurde kein Text angegeben!", "", MessageBoxButtons.OK);
                            this.gridAbteilungen.ActiveRow = r;
                            return false;
                        }
                    }

                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucAbteilungen.validateData: " + ex.ToString());
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

                foreach (dsAbteilung.Abteilung2Row rAbteilung in this.dsAbteilung1.Abteilung2)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        if (rAbteilung.RowState != DataRowState.Deleted && rAbteilung.IsIDKontaktNull())
                        {
                            PMDS.db.Entities.Kontakt NewKontakt = new Kontakt();
                            this.b.fillNewKontakt(NewKontakt);
                            db.Kontakt.Add(NewKontakt);
                            db.SaveChanges();

                            rAbteilung.IDKontakt = NewKontakt.ID;
                        }
                    }
                }

                this.dbAbteilung1.daAbteilung2ByKlinik.Update(this.dsAbteilung1.Abteilung2);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucAbteilungen.saveData: " + ex.ToString());
            }
        }

        public dsAbteilung.Abteilung2Row getSelectedRow(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                if (this.gridAbteilungen.ActiveRow != null)
                {
                    if (this.gridAbteilungen.ActiveRow.IsGroupByRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.gridAbteilungen.ActiveRow.ListObject;
                        dsAbteilung.Abteilung2Row rSelRow = (dsAbteilung.Abteilung2Row)v.Row;
                        gridRow = this.gridAbteilungen.ActiveRow;
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
                throw new Exception("ucAbteilungen.getSelectedRow: " + ex.ToString());
            }
        }


        public bool addRow()
        {
            try
            {
                dsAbteilung.Abteilung2Row rAbteilung = this.dbAbteilung1.getNewRowAbteilung(this.dsAbteilung1);
                rAbteilung.IDKlinik = this._IDKlinik;

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("ucAbteilungen.addRow: " + ex.ToString());
            }
        }
        public bool deleteRow()
        {
            try
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                dsAbteilung.Abteilung2Row rAbteilung = this.getSelectedRow(true, ref gridRow);
                if (rAbteilung != null)
                {
                    rAbteilung.Delete();
                    this.gridAbteilungen.Refresh();
                }

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("ucAbteilungen.delRow: " + ex.ToString());
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

                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridAbteilungen))
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

                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridAbteilungen))
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
