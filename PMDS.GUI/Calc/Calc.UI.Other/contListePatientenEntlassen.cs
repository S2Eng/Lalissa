using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;


namespace PMDS.GUI.Calc.Calc.UI.Other
{
    

    public partial class contListePatientenEntlassen : UserControl
    {

        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
        public frmListePatientenEntlassen mainWindow = null;
        public UIGlobal UIGlobal1 = new UIGlobal();
        public PMDS.GUI.VB.gridExport export = new PMDS.GUI.VB.gridExport();





        public contListePatientenEntlassen()
        {
            InitializeComponent();
        }

        private void contListePatientenEntlassen_Load(object sender, EventArgs e)
        {

        }


        public void initControl()
        {
            try
            {
                this.mainWindow.CancelButton = this.btnClose;
                //this.mainWindow.AcceptButton = this.btnSearch;

                this.lblFound.Text = "";

                //this.btnClose.Appearance.Image = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Beenden, 32, 32);
                this.btnExportExcel.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Excel, 32, 32);
                this.btnSearch.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);

                DateTime datLastMonth = DateTime.Now.AddMonths(-1);
                var lastDayOfMonth = DateTime.DaysInMonth(datLastMonth.Year, datLastMonth.Month);
                this.dteVon.Value = new DateTime(datLastMonth.Year, datLastMonth.Month, 1, 0, 0, 0);
                this.dteBis.Value = new DateTime(datLastMonth.Year, datLastMonth.Month, lastDayOfMonth, 0, 0, 0);

                this.gridPatientenEntlassen.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.PatientenEntlassen.PatientColumn.ColumnName].Header.VisiblePosition = 0;
                this.gridPatientenEntlassen.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.PatientenEntlassen.PatientColumn.ColumnName].Width = 300;

                this.gridPatientenEntlassen.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.PatientenEntlassen.EntlassungszeitpunktColumn.ColumnName].Header.VisiblePosition = 2;
                this.gridPatientenEntlassen.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.PatientenEntlassen.EntlassungszeitpunktColumn.ColumnName].Width = 150;

                this.gridPatientenEntlassen.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.PatientenEntlassen.WohinColumn.ColumnName].Header.VisiblePosition = 3;
                this.gridPatientenEntlassen.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.PatientenEntlassen.WohinColumn.ColumnName].Width = 300;


            }
            catch (Exception ex)
            {
                throw new Exception("contListePatientenEntlassen.initControl: " + ex.ToString());
            }
        }

        public void loadData()
        {
            try
            {
                this.lblFound.Text = "";
                this.dsKlientenliste1.Clear();
                this.gridPatientenEntlassen.Refresh();

                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    Nullable<DateTime> dVon = null;
                    if (this.dteVon.Value != null)
                    {
                        dVon = this.dteVon.DateTime.Date;
                    }

                    Nullable<DateTime> dBis = null;
                    if (this.dteBis.Value != null)
                    {
                        dBis = this.dteBis.DateTime.Date;
                    }

                    this.b.getPatientenEntlassen(dVon, dBis, this.dsKlientenliste1, db, this.sqlManange1);
                    this.gridPatientenEntlassen.Refresh();

                    this.lblFound.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Gefunden: ") + this.dsKlientenliste1.PatientenEntlassen.Rows.Count.ToString() + "";
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contListePatientenEntlassen.loadData: " + ex.ToString());
            }
        }

        public void exportExcel()
        {
            try
            {
                this.export.exportGrid(this.gridPatientenEntlassen, PMDS.GUI.VB.gridExport.eTyp.excel, null, "", null, "", "");

            }
            catch (Exception ex)
            {
                throw new Exception("contListePatientenEntlassen.exportExcel: " + ex.ToString());
            }
        }

        


        private void gridArztabrechnung_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridArztabrechnung_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridPatientenEntlassen))
                {

                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridArztabrechnung_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridPatientenEntlassen))
                {

                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
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
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.exportExcel();

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
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
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

    }

}
