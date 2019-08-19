using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.GUI;
using PMDS.Data.Global;
using Infragistics.Win.UltraWinGrid;
using PMDS.Calc.Logic;

namespace PMDS.Calc.UI
{
    public partial class ucSR : QS2.Desktop.ControlManagment.BaseControl
    {

        public PMDS.Calc.UI.ucSRSitemap  uiSiteMapForm;
        public PMDS.Calc.Logic.dbPMDS  dbKostSelect;

        public PMDS.Calc.UI.ucCalcs ucCalcs2;
        private List<PMDS.UI.Sitemap.cButt> listButt = new List<PMDS.UI.Sitemap.cButt>();

        public string colSelect = "Select";







        public ucSR()
        {
            InitializeComponent();
        }

        public void initControl()
        {
            this.ucCalcs2 = new PMDS.Calc.UI.ucCalcs();
            this.ucCalcs2.Dock = DockStyle.Fill;
            this.panelCalcsLoad.Controls.Add(this.ucCalcs2);
            this.ucCalcs2.ucSR = this;

            this.setUIButtons();
            //this.setUICalcSearch(System.Convert.ToInt32(this.btnCalc.Tag));

            this.dtMonat.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this.dtRechDatum.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            this.dbKostSelect = new PMDS.Calc.Logic.dbPMDS();
        }

        private void ucSR_Load(object sender, EventArgs e)
        {

        }

        public void loadData( )
        {
            this.loadData(this.dtMonat.DateTime );
        }
        public void loadData(DateTime monat )
        {
            this.Cursor = Cursors.WaitCursor;
            if (monat != null ) this.dtMonat.Value = monat;
            this.validateMonat();
            this.uiSiteMapForm.loadData(this.uGridKostKlienten, ref this.cbKostenträger, ref this.dbKostSelect, ref this.dbPMDS1, this.dtMonat.DateTime);
            this.SelectAllNonePatients(true);
            //this.ucCalcs2.loadCalcs();
            this.Cursor = Cursors.Default ;
        }

        public void SelectAllNonePatients(bool bOn)
        {
            foreach (UltraGridRow rGridBand1 in this.uGridKostKlienten.Rows)
            {
                DataRowView v1 = (DataRowView)rGridBand1.ListObject;
                dbPMDS.KostentraegerRow rSelRowBand1 = (dbPMDS.KostentraegerRow)v1.Row;

                foreach (UltraGridChildBand childBands in rGridBand1.ChildBands)
                {
                    foreach (UltraGridRow rGridBand2 in childBands.Rows)
                    {
                        DataRowView v2 = (DataRowView)rGridBand2.ListObject;
                        dbPMDS.PatientRow rSelRowBand2 = (dbPMDS.PatientRow)v2.Row;

                        rGridBand2.Cells[this.colSelect.Trim()].Value = bOn;
                    }
                }
            }
        }

        public void validateMonat()
        {
            if (this.dtMonat.Value == null) this.dtMonat.Value = DateTime.Now;
        }

        public Guid IDKostentraeger
        {
            get
            {
                if (this.cbKostenträger.SelectedItem == null)
                    return Guid.Empty;
                else
                    return (Guid)cbKostenträger.SelectedItem.DataValue;
            }
            set
            {
                cbKostenträger.Value = value;
            }
        }

        private void selectionValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbKostenträger.SelectedItem != null)
                {
                    this.validateMonat();
                    this.uiSiteMapForm.fillGrid((Infragistics.Win.UltraWinGrid.UltraGrid) this.uGridKostKlienten, ref this.dbPMDS1, this.dtMonat.DateTime,
                                                (string)this.cbKostenträger.SelectedItem.DataValue.ToString());

                    this.SelectAllNonePatients(true);
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.loadData((DateTime)this.dtMonat.Value);
        }

        private void butAbrechnen_Click(object sender, EventArgs e)
        {
           try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!this.ucCalcs2.uiSiteMapForm.sitemap.checkUIDateAbrech(this.dtMonat,  this.dtRechDatum)) return;

                System.Collections.Generic.List<doSr.cPatients> lstSelPatients = new List<doSr.cPatients>();
                this.getSelectedPatient(ref lstSelPatients);


                this.ucCalcs2.doCalcSR(this.dtMonat.DateTime, this.dtRechDatum.DateTime, ref lstSelPatients);
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

        public void getSelectedPatient(ref System.Collections.Generic.List<doSr.cPatients> lstSelPatients)
        {
            foreach (UltraGridRow rGridBand1 in this.uGridKostKlienten.Rows)
            {
                DataRowView v1 = (DataRowView)rGridBand1.ListObject;
                dbPMDS.KostentraegerRow rSelRowBand1 = (dbPMDS.KostentraegerRow)v1.Row;

                foreach (UltraGridChildBand childBands in rGridBand1.ChildBands)
                {
                    foreach (UltraGridRow rGridBand2 in childBands.Rows)
                    {
                        DataRowView v2 = (DataRowView)rGridBand2.ListObject;
                        dbPMDS.PatientRow rSelRowBand2 = (dbPMDS.PatientRow)v2.Row;

                        if ((bool)rGridBand2.Cells[this.colSelect.Trim()].Value == true)
                        {
                            doSr.cPatients Patients = new doSr.cPatients();
                            Patients.IDPatient = rSelRowBand2.ID;
                            Patients.IDKost = rSelRowBand2.IDKost;
                            Patients.IDBill = rSelRowBand2.KrankenKasse;
                            lstSelPatients.Add(Patients);
                        }
                    }
                }
            }
        }

        public  void setUICalcSearchxy(int  mode)
        {
            //if (mode == 1)
            //    this.uiSiteMapForm.searchMode = true;
            //else
            //    this.uiSiteMapForm.searchMode = false ;

            //this.uiSiteMapForm.sitemap.aktivateButton(this.listButt, mode);
            //this.panelGrid.Visible = !this.uiSiteMapForm.searchMode;
            //this.grpCalcSR.Visible = !this.uiSiteMapForm.searchMode;
            //this.lblKost.Text = !this.uiSiteMapForm.searchMode ? "Abzurechnende Kostenträger" : "Allgemeine Kostenträger";
        }

        private void setUIButtons()
        {
            PMDS.UI.Sitemap.cButt itm = new PMDS.UI.Sitemap.cButt();
            itm.butt = this.btnSearch;
            itm.nr = Convert.ToInt32(this.btnSearch.Tag);
            this.listButt.Add(itm);

             itm = new PMDS.UI.Sitemap.cButt();
             itm.butt = this.btnCalc;
            itm.nr = Convert.ToInt32(this.btnCalc .Tag);
            this.listButt.Add(itm);

            this.uiSiteMapForm.sitemap.aktivateButton(this.listButt, System.Convert.ToInt32 (this.btnCalc.Tag));
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            //this.setUICalcSearch(System.Convert.ToInt32(this.btnCalc.Tag));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //this.setUICalcSearch(System.Convert.ToInt32(this.btnSearch.Tag));
        }

        private void cbKostenträger_SelectionChanged(object sender, EventArgs e)
        {
            if (this.cbKostenträger.Focused)
                this.selectionValueChanged(sender, e);
        }

        private void uGridKostKlienten_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            if (e.Cell.Column.ToString().Trim().ToLower().Equals((this.colSelect.Trim()).Trim().ToLower()))
            {
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            }
            else
            {
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
        }

        private void dtMonat_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dtMonat.Focused)
                {
                    if (this.dtMonat.Value != null)
                    {
                        this.ucCalcs2.dtVon.DateTime = this.dtMonat.DateTime;
                        this.ucCalcs2.dtBis.DateTime = this.dtMonat.DateTime;
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void dtMonat_AfterCloseUp(object sender, EventArgs e)
        {
            try
            {
                if (this.dtMonat.Value != null)
                {
                    this.ucCalcs2.dtVon.DateTime = this.dtMonat.DateTime;
                    this.ucCalcs2.dtBis.DateTime = this.dtMonat.DateTime;
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

    }

}

