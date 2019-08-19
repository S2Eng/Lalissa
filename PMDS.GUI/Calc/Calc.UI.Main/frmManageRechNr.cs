using Infragistics.Win.UltraWinGrid;
using PMDS.DB;
using PMDS.Global;
using PMDS.Global.db.ERSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PMDS.GUI.Calc.Calc.UI.Main
{

    public partial class frmManageRechNr : Form
    {
        public bool abort = true;
        public PMDS.db.Entities.ERModellPMDSEntities _db = null;

        public PMDSBusiness b = new PMDSBusiness();
        public PMDSBusinessUI b2 = new PMDSBusinessUI();
        public PMDS.GUI.PMDSBusinessUI PMDSBusinessUI2 = new PMDSBusinessUI();
        public PMDS.Global.db.ERSystem.PMDSBusinessUI b3 = new PMDS.Global.db.ERSystem.PMDSBusinessUI();
        public UIGlobal UIGlobal1 = new UIGlobal();







        public frmManageRechNr()
        {
            InitializeComponent();
        }

        private void frmManageRechNr_Load(object sender, EventArgs e)
        {

        }



        public void initControl()
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
                this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);
                this.btnAdd.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32);
                this.btnDel.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32);

                this.AcceptButton = this.btnSave;
                this.CancelButton = this.btnAbort;

                this.sqlManange2.initControl();
                this._db = PMDSBusiness.getDBContext();

                this.loadData();

            }
            catch (Exception ex)
            {
                throw new Exception("frmManageRechNr.initControl: " + ex.ToString());
            }
        }

        public void clearUI()
        {
            try
            {
                this.dsManage1.Clear();
                this.gridRechNr.Refresh();

            }
            catch (Exception ex)
            {
                throw new Exception("frmManageRechNr.clearUI: " + ex.ToString());
            }
        }

        public void loadData()
        {
            try
            {
                this.clearUI();

                this.sqlManange2.getRechNr(this.dsManage1);
                this.gridRechNr.Refresh();

                //IQueryable<PMDS.db.Entities.rechNr> tRechNr = this._db.rechNr.OrderBy(x => new { x.typ, x.year });
                //BindingList<PMDS.db.Entities.rechNr> tRechNrbindingList = new BindingList<PMDS.db.Entities.rechNr>();
                //foreach (PMDS.db.Entities.rechNr rrechNr in tRechNr)
                //{
                //    tRechNrbindingList.Add(rrechNr);
                //}
                
                //using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                //{
                //    foreach (dbPMDS.billsRow rBill in this._listBills)
                //    {
                //        PMDS.Global.db.ERSystem.dsKlientenliste.UIRow rNewUI = this.sqlManange1.getNewUI(ref this.dsKlientenliste1);
                //        rNewUI.obj = rBill;
                //        rNewUI.ID2 = new Guid(rBill.ID.ToString());
                //        string sMessage = "";
                //        if (rBill.Typ == (int)eBillTyp.Sammelrechnung)
                //        {
                //            sMessage = QS2.Desktop.ControlManagment.ControlManagment.getRes("SR Rechnung von") + " " + rBill.datum.Year.ToString() + "-" + rBill.datum.Month.ToString() + " " +
                //                          QS2.Desktop.ControlManagment.ControlManagment.getRes("gefunden");
                //        }
                //        else
                //        {
                //            PMDS.db.Entities.Patient rPatient = this.b.getPatient(new Guid(rBill.IDKlient.ToString()), db);
                //            rNewUI.ID2 = rPatient.ID;
                //            sMessage = QS2.Desktop.ControlManagment.ControlManagment.getRes("Rechnung von") + " " + rBill.datum.Year.ToString() + "-" + rBill.datum.Month.ToString() + " " +
                //                            QS2.Desktop.ControlManagment.ControlManagment.getRes("für Patient") + " " + rPatient.Nachname.Trim() + " " + rPatient.Vorname.Trim() + " " +
                //                            QS2.Desktop.ControlManagment.ControlManagment.getRes("gefunden");
                //        }

                //        rNewUI.Bezeichnung = sMessage.Trim();
                //    }
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("frmManageRechNr.loadData: " + ex.ToString());
            }
        }

        public void clearErrorProvider()
        {
            try
            {
                //this.errorProvider1.SetError(this.dropDownPatienten, "");

            }
            catch (Exception ex)
            {
                throw new Exception("frmManageRechNr.clearErrorProvider: " + ex.ToString());
            }
        }
        public bool validateData()
        {
            try
            {
                this.clearErrorProvider();

                //if (this.txtMedikament.Tag == null)
                //{
                //    this.errorProvider1.SetError(this.txtMedikament, "Error");
                //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde keine Verordnung ausgewählt!", "", MessageBoxButtons.OK);
                //    return false;
                //}

                //foreach (UltraGridRow rGridRow in this.gridRechNr.Rows)
                //{
                //    var v = (DataRowView)rGridRow.ListObject;
                //    //dsKlientenliste.UIRow rSelRow = (dsKlientenliste.UIRow)v.Row;
                //}

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("frmManageRechNr.validateData: " + ex.ToString());
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

                //this._db.SaveChanges();
                this.sqlManange2.daRechNr.Update(this.dsManage1.rechNr);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("frmManageRechNr.saveData: " + ex.ToString());
            }
        }


        public void addRow()
        {
            try
            {
                PMDS.Global.db.ERSystem.dsManage.rechNrRow rNewRechNr = this.sqlManange2.getNewRechNr(ref this.dsManage1);
                this.gridRechNr.Refresh();
            }
            catch (Exception ex)
            {
                throw new Exception("frmManageRechNr.addRow: " + ex.ToString());
            }
        }


        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.abort = true;
                this.Close();

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
                    this.Close();
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
        private void btnAddVO_Click(object sender, EventArgs e)
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



        private void gridMsgBox_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.IsFilterRowCell || e.Cell.Row.IsGroupByRow)
                {
                    e.Cell.Activation = Activation.AllowEdit;
                }
                else
                {
                    e.Cell.Activation = Activation.AllowEdit;
                    e.Cell.Row.Selected = true;

                    //if (e.Cell.Column.ToString().Trim().ToLower().Equals((this.colSelect.Trim()).Trim().ToLower()))
                    //{
                    //    e.Cell.Activation = Activation.AllowEdit;
                    //}
                    //else
                    //{
                    //    e.Cell.Activation = Activation.NoEdit;
                    //    e.Cell.Row.Selected = true;
                    //}
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridMsgBox_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            try
            {
                e.DisplayPromptMsg = false;
                e.Cancel = false;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridMsgBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridRechNr))
                {
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridMsgBox_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridRechNr))
                {
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }




    }

}
