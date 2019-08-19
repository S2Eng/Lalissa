using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Global;
using PMDS.GUI;
using PMDS.Data.Patient;
using PMDS.Global.db.Patient;



namespace PMDS.Calc.UI.Admin
{

    

    public partial class frmAbwÜbersp : QS2.Desktop.ControlManagment.baseForm 
    {

        private PMDS.Calc.Logic.calcBase calcBase = new PMDS.Calc.Logic.calcBase();
        private abwÜbersp.abwÜberspSitemap abwÜberspSitemap = new abwÜbersp.abwÜberspSitemap();
        public PMDS.GUI.VB.gridExport export = new PMDS.GUI.VB.gridExport();




        public frmAbwÜbersp()
        {
            InitializeComponent();
        }

        private void frmGetAbwesenheiten_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
            dsKlinik.KlinikRow rActuelKlinik = DBKlinik1.loadKlinik(PMDS.Global.ENV.IDKlinik, true);
            this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Abrechnung - Abwesenheiten übernehmen für ") + rActuelKlinik.Bezeichnung.Trim() + "";
            
            this.ucKlinikDropDown1.initControl();
            this.ucKlinikDropDown1.loadComboAllKliniken();
            
            this.setDateActMonth();;
            this.InitTimeContextMenu();
            this.abwÜberspSitemap.sitemap.alleKeineButtonGrid(this.butAlleKeine, false, (Infragistics.Win.UltraWinGrid.UltraGrid)this.uGridAbw, "", false);

            this.searchAbw();
        }
        private void InitTimeContextMenu()
        {
            this.abwÜberspSitemap.sitemap.initTimeContextMenu();
            foreach (MenuItem item in this.abwÜberspSitemap.sitemap.timemenu.MenuItems)
            {
                item.Click += new EventHandler(Timeitem_Click);
            }
        }

        public void searchAbw()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.checkUIDate();
                this.dsAbwÜbersp1.abw.Rows.Clear();
                this.abwÜberspSitemap.searchAbw(this.dtVon.DateTime, this.dtBis.DateTime, ref this.dsAbwÜbersp1, 
                                                (int)uOptÜbersp.Value, chkHändischJN.Checked, ENV.IDKlinik);
                this.uGridAbw.Refresh();

                this.uGridAbw.Selected.Rows.Clear();
                this.uGridAbw.ActiveRow = null;

                this.abwÜberspSitemap.sitemap.alleKeineButtonGrid((Infragistics.Win.Misc.UltraButton) butAlleKeine, false, (Infragistics.Win.UltraWinGrid.UltraGrid)  this.uGridAbw, "", false);
                this.abwÜberspSitemap.sitemap.anz = this.dsAbwÜbersp1.abw.Rows.Count;
                lblCount.Text = this.abwÜberspSitemap.sitemap.setUIAnzahl(QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine Abwesenheiten gefunden!"));
                if (this.dsAbwÜbersp1.abw.Rows.Count > 0) { uGridAbw.DisplayLayout.Rows[0].ExpandAll(); }
                
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        public void checkUIDate()
        {
            if (this.dtVon.Value == null || this.dtBis.Value == null)
            {
                this.setDateActMonth();
            }
            if (this.dtBis.DateTime < this.dtVon.DateTime)
                this.dtBis.DateTime = this.dtVon.DateTime;
        }
        public void setDateActMonth()
        {
            this.uOptÜbersp.Value = -1;
            // wenn der aktuelle Tag vom 1-10 liegt -> Vormonat anzeigen
            // wenn der aktuelle Tage weniger als drei Tage vor Monatsende liegt, aktuelles Monat anzeigen
            // sonst aktuelles Datum - 1. des Vormats bis aktuelles datum anzeigen
            if (ENV.AbwesenheitenMinimalUI)
            {
                this.dtVon.Value = new DateTime(1900, 1, 1);
                this.dtBis.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                this.ultraGroupBoxSuche.Visible = false;
                this.chkEingepDelete.Visible = false;
            }
            else
            {
                if (DateTime.Now.Day <= 10)
                {
                    this.dtBis.Value = this.calcBase.monatsende(DateTime.Now.AddMonths(-1));
                    this.dtVon.Value = new DateTime(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month, 1);
                }
                else if (DateTime.Now.Day >= this.calcBase.monatsende(DateTime.Now).Day - 3)
                {
                    this.dtBis.Value = this.calcBase.monatsende(DateTime.Now);
                    this.dtVon.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                }
                else
                {
                    this.dtBis.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                    this.dtVon.Value = new DateTime(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month, 1);
                }
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.searchAbw();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnÜberspielen_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die gewählten Abwesenheiten ins Abrechnungssystem überspielen?", "Abwesenheiten überspielen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (!this.ValidateRows()) return;
                    int anz = this.abwÜberspSitemap.überspielen(ref this.dsAbwÜbersp1, this. chkEingepDelete.Checked);
                    if (anz > 0 ) this.searchAbw();
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurden " + anz.ToString()  + " Abwesenheiten überspielt!", "Abwesenheiten überspielen", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private bool ValidateRows()
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow r in PMDS.GUI.UltraGridTools.GetAllRowsFromGroupedUltraGrid(uGridAbw, false))
            {
                if (r.IsGroupByRow)  continue;

                PMDS.GUI.Calc.Calc.UI.Other.dsAbwÜbersp.abwRow rDS = (PMDS.GUI.Calc.Calc.UI.Other.dsAbwÜbersp.abwRow)((System.Data.DataRowView)r.ListObject).Row;
                rDS.SetColumnError(r.Cells[this.dsAbwÜbersp1.abw.GrundColumn.ColumnName].Column.Index, "");
                //rDS.SetColumnError(r.Cells[this.dsAbwÜbersp1.abw.VonColumn.ColumnName].Column.Index, "");

                if (rDS.Grund.Trim() == "")
                {
                    string txt = "Es wurde kein Grund angegeben!";
                    rDS.SetColumnError(r.Cells[this.dsAbwÜbersp1.abw.GrundColumn.ColumnName].Column.Index, txt);
                    this.uGridAbw.ActiveRow = r;
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txt, "Abwesenheiten überspielen", MessageBoxButtons.OK);
                    return false;
                }
                //if (rDS.Von  == null )
                //{
                //    string txt = "Es wurde kein Von-Datum angegeben!";
                //    rDS.SetColumnError(r.Cells[this.dsAbwÜbersp1.abw.VonColumn.ColumnName].Column.Index, txt);
                //    this.uGridAbw.ActiveRow = r;
                //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txt, "Abwesenheiten überspielen", MessageBoxButtons.OK);
                //    return false;
                //}
            }
            return true;
        }
        private void butAlleKeine_Click(object sender, EventArgs e)
        {
            this.abwÜberspSitemap.sitemap.alleKeineButtonGrid((Infragistics.Win.Misc.UltraButton)this.butAlleKeine, !(bool)this.butAlleKeine.Tag, (Infragistics.Win.UltraWinGrid.UltraGrid)this.uGridAbw, "Überspielen", true);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnTimes_MouseUp(object sender, MouseEventArgs e)
        {
            this.abwÜberspSitemap.sitemap.timemenu.Show(this, new Point(this.ultraGroupBoxSuche.Left + btnTimes.Left, this.ultraGroupBoxSuche.Top + btnTimes.Top + btnTimes.Height));
        }
        private void Timeitem_Click(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            PMDS.Global.timehelper h = (PMDS.Global.timehelper)item.Tag;
            this.dtVon.DateTime = h._from;
            this.dtBis.DateTime = h._to;
            this.searchAbw();
        }

        private void uGridAbw_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            if (e.Cell.Column.ToString() == "Überspielen" || e.Cell.Column.ToString() == "Grund" || e.Cell.Column.ToString() == "Von"
                         || e.Cell.Column.ToString() == "Bis")
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            else
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        }

        private void uOptÜbersp_ValueChanged(object sender, EventArgs e)
        {
            if (this.uOptÜbersp.Focused)
            {
                if ((int)this.uOptÜbersp.Value == 0 )
                {
                    this.chkEingepDelete.Visible = false;
                    this.chkEingepDelete.Checked = false;
                }

                else if ((int)this.uOptÜbersp.Value == 1 || (int)this.uOptÜbersp.Value == -1)
                {
                    this.chkEingepDelete.Visible = true;
                    this.chkEingepDelete.Checked = true;
                }

                this.searchAbw();
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            this.export.exportGrid(this.uGridAbw, PMDS.GUI.VB.gridExport.eTyp.excel, null, "", null, "");
        }

        private void chkHändischJN_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkHändischJN.Focused)
                this.searchAbw();
        }

        private void uGridAbw_DoubleClick(object sender, EventArgs e)
        {

        }
        private void uGridAbw_BeforeRowRegionScroll(object sender, Infragistics.Win.UltraWinGrid.BeforeRowRegionScrollEventArgs e)
        {

        }

     
    }
}
