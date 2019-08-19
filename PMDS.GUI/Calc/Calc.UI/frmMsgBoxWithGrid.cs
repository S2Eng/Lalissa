using Infragistics.Win.UltraWinGrid;
using PMDS.Calc.Logic;
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
using System.Linq;


namespace PMDS.GUI.Calc.Calc.UI
{

    public partial class frmMsgBoxWithGrid : Form
    {
        public eTypeUI _TypeUI;
        public bool abort = true;
        public System.Collections.Generic.List<calculation.cBill> _listBills = new List<calculation.cBill>();
        public System.Collections.Generic.List<calculation.cBill> _listBillsSelected = new List<calculation.cBill>();

        public string colSelect = "Select";

        public enum eTypeUI
        {
            CalcCheckDoStorno = 0
        }

        public UIGlobal UIGlobal1 = new UIGlobal();
        public PMDSBusiness b = new PMDSBusiness();

        public string colKostenteilung = "Kostenteilung";
        public doBill doBill1 = new doBill();








        public frmMsgBoxWithGrid()
        {
            InitializeComponent();
        }

        private void frmMsgBoxWithGrid_Load(object sender, EventArgs e)
        {

        }


        public void initControl(eTypeUI TypeUI, ref System.Collections.Generic.List<calculation.cBill> listBills)
        {
            try
            {
                this._TypeUI = TypeUI;
                this._listBills = listBills;

                this.CancelButton = this.btnAbort;
                this.AcceptButton = this.btnOK;

                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
                this.btnOK.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);

                this.AcceptButton = this.btnOK;
                this.CancelButton = this.btnAbort;
                
                if (this._TypeUI == eTypeUI.CalcCheckDoStorno)
                {
                    this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Prüfung bestehende freigegebene Rechnungen auf Storno bzw. Korrektur Beilagen");
                    this.lblTitle.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Für folgende Klienten existieren bereits freigegeben Rechnungen bzw. Beilagen" + "\r\n" + "Sollen diese storniert bzw. korrigiert werden?");
                }

                this.loadData();

            }
            catch (Exception ex)
            {
                throw new Exception("frmMsgBoxWithGrid.initControl: " + ex.ToString());
            }
        }

        public void clearUI()
        {
            try
            {
                this.dsKlientenliste1.UI.Clear();
                this.gridMsgBox.Refresh();

            }
            catch (Exception ex)
            {
                throw new Exception("frmMsgBoxWithGrid.clearUI: " + ex.ToString());
            }
        }

        public void loadData()
        {
            try
            {
                this.clearUI();

                System.Collections.Generic.List<string> lstBillsDistinct = new List<string>();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;

                    foreach (calculation.cBill cBill in this._listBills)
                    {
                        //if (!lstBillsDistinct.Contains(cBill.rBillToStorno.ID))
                        //{
                            PMDS.Global.db.ERSystem.dsKlientenliste.UIRow rNewUI = this.sqlManange1.getNewUI(ref this.dsKlientenliste1);
                            rNewUI.obj = cBill;
                            rNewUI.ID2 = new Guid(cBill.rBillToStorno.ID.ToString());
                            string sMessage = "";
                            if (cBill.rBillToStorno.Typ == (int)eBillTyp.Sammelrechnung)
                            {
                                sMessage = QS2.Desktop.ControlManagment.ControlManagment.getRes("SR Rechnung von") + " " + cBill.rBillToStorno.datum.Year.ToString() + "-" + cBill.rBillToStorno.datum.Month.ToString() + " " +
                                              QS2.Desktop.ControlManagment.ControlManagment.getRes("gefunden");
                            }
                            else
                            {
                                PMDS.db.Entities.Patient rPatient = this.b.getPatient(new Guid(cBill.rBillToStorno.IDKlient.ToString()), db);
                                rNewUI.ID2 = rPatient.ID;
                                string sTxtTmp = "";
                                if (cBill.rBillToStorno.Typ == (int)eBillTyp.Rechnung)
                                {
                                    sTxtTmp = QS2.Desktop.ControlManagment.ControlManagment.getRes("Rechnung von");
                                }
                                else if (cBill.rBillToStorno.Typ == (int)eBillTyp.Beilage)
                                {
                                    sTxtTmp = QS2.Desktop.ControlManagment.ControlManagment.getRes("Beilage von");
                                }
                                
                                sMessage = sTxtTmp + " " + cBill.rBillToStorno.datum.Year.ToString() + "-" + cBill.rBillToStorno.datum.Month.ToString() + " " +
                                                QS2.Desktop.ControlManagment.ControlManagment.getRes("für Patient") + " " + rPatient.Nachname.Trim() + " " + rPatient.Vorname.Trim() + " " +
                                                QS2.Desktop.ControlManagment.ControlManagment.getRes("gefunden");
                            }

                            rNewUI.Bezeichnung = sMessage.Trim();
                            lstBillsDistinct.Add(cBill.rBillToStorno.ID);
                        //}
                    }
                    this.gridMsgBox.Refresh();

                    foreach(UltraGridRow rGrid in this.gridMsgBox.Rows)
                    {
                        var v = (DataRowView)rGrid.ListObject;
                        PMDS.Global.db.ERSystem.dsKlientenliste.UIRow rUI = (PMDS.Global.db.ERSystem.dsKlientenliste.UIRow)v.Row;

                        calculation.cBill cbill1 = (calculation.cBill)rUI.obj;

                        //PMDS.db.Entities.billHeader rBillHeader = db.billHeader.Where(b => b.ID == cbill1.rBillToStorno.IDAbrechnung).First();
                        //dbCalc dbCalcFound = this.doBill1.getDBCalc(rBillHeader.dbCalc);

                        //dbCalc.KostenträgerRow[] arrKostenträger = (dbCalc.KostenträgerRow[])dbCalcFound.Kostenträger.Select("", "FamName asc");
                        //if (arrKostenträger.Length > 1)
                        //{
                        //    rGrid.Cells[this.colKostenteilung.Trim()].Value = true;
                        //}

                        var tBills = (from b in db.bills
                                   join bh in db.billHeader on b.IDAbrechnung equals bh.ID
                                   where bh.ID == cbill1.rBillToStorno.IDAbrechnung && b.Typ != (int)eBillTyp.Beilage
                                   select new
                                   {
                                       IDBill = b.ID,
                                       IDBillHeader = bh.ID,
                                       KostenträgerName = b.KostenträgerName,
                                       Betrag = b.betrag
                                   });
                        
                        if (tBills.Count() > 1)
                        {
                            rGrid.Cells[this.colKostenteilung.Trim()].Value = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmMsgBoxWithGrid.loadData: " + ex.ToString());
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
                throw new Exception("frmMsgBoxWithGrid.clearErrorProvider: " + ex.ToString());
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


                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("frmMsgBoxWithGrid.validateData: " + ex.ToString());
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

                this._listBillsSelected = new List<calculation.cBill>();
                foreach (UltraGridRow rGridRow in this.gridMsgBox.Rows)
                {
                    DataRowView v = (DataRowView)rGridRow.ListObject;
                    dsKlientenliste.UIRow rSelRow = (dsKlientenliste.UIRow)v.Row;
                    
                    if ((bool)rGridRow.Cells[this.colSelect.Trim()].Value == true)
                    {
                        calculation.cBill newBillToStorno = new calculation.cBill();
                        calculation.cBill cBill = (calculation.cBill)rSelRow.obj;
                        newBillToStorno.rBillToStorno = cBill.rBillToStorno;
                        newBillToStorno.IDBillNew = cBill.IDBillNew;
                        this._listBillsSelected.Add(newBillToStorno);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("frmMsgBoxWithGrid.saveData: " + ex.ToString());
            }
        }

        public void selectAllnone(bool bOn)
        {
            try
            {
                foreach (UltraGridRow rGridRow in this.gridMsgBox.Rows)
                {
                    DataRowView v = (DataRowView)rGridRow.ListObject;
                    dsKlientenliste.UIRow rSelRow = (dsKlientenliste.UIRow)v.Row;

                    if ((bool)rGridRow.Cells[this.colKostenteilung.Trim()].Value == false)
                    {
                        rGridRow.Cells[this.colSelect.Trim()].Value = bOn;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmMsgBoxWithGrid.selectAllnone: " + ex.ToString());
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

        private void btnOK_Click(object sender, EventArgs e)
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
        private void alleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.selectAllnone(true);

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
        private void keineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.selectAllnone(false);

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




        private void gridVO_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.IsFilterRowCell || e.Cell.Row.IsGroupByRow)
                {
                    e.Cell.Activation = Activation.AllowEdit;
                }
                else
                {
                    if (e.Cell.Column.ToString().Trim().ToLower().Equals((this.colSelect.Trim()).Trim().ToLower()))
                    {
                        if ((bool)e.Cell.Row.Cells[this.colKostenteilung.Trim()].Value == true)
                        {
                            e.Cell.Activation = Activation.NoEdit;
                        }
                        else
                        {
                            e.Cell.Activation = Activation.AllowEdit;
                        }
                    }
                    else
                    {
                        e.Cell.Activation = Activation.NoEdit;
                        e.Cell.Row.Selected = true;
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridVO_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            try
            {
                e.DisplayPromptMsg = false;
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void gridMsgBox_CellChange(object sender, CellEventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void gridVO_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridMsgBox))
                {
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void gridVO_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridMsgBox))
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
