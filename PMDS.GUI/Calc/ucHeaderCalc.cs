using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.Global.db.Patient;




namespace PMDS.Calc.UI.Admin
{
    public partial class ucHeaderCalc : QS2.Desktop.ControlManagment.BaseControl
    {       
        public ucMainCalc mainWindow;
        System.Drawing.Color actColor = new System.Drawing.Color();

        public ucHeaderCalc()
        {
            InitializeComponent();
            actColor = System.Drawing.Color.Red;

        }

        public void setButtonsAktivDeaktiv(SiteEvents aktivButton)
        {
            PMDS.Global.UIGlobal.setUIButton(this.btnAbrechnungPatient, aktivButton == SiteEvents.abrech_patient);
            PMDS.Global.UIGlobal.setUIButton(this.btnSammelabrechnung2, aktivButton == SiteEvents.abrech_sammelabrechnung2);
            PMDS.Global.UIGlobal.setUIButton(this.btnDepot, aktivButton == SiteEvents.abrech_Depotgeld);
            PMDS.Global.UIGlobal.setUIButton(this.btnBuchhaltung, aktivButton == SiteEvents.abrech_buchhaltung);
            PMDS.Global.UIGlobal.setUIButton(this.btnStammdaten, aktivButton == SiteEvents.abrech_stammdten);
            PMDS.Global.UIGlobal.setUIButton(this.btnBerichte, aktivButton == SiteEvents.abrech_berichte);
        }

        private void btnAbrechnungPatient_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor ;

            this.ucKlinikCbo1.Visible = true;
            this.setButtonsAktivDeaktiv(SiteEvents.abrech_patient );
            this.mainWindow.tabMain.ActiveTab = this.mainWindow.tabMain.Tabs[0];
            this.mainWindow.tabMain.SelectedTab = this.mainWindow.tabMain.Tabs[0];
            this.mainWindow.tabMain.Tabs[0].Visible = true;
            this.mainWindow.selectTab();

            this.Cursor = Cursors.Default ;
        }
        private void btnSammelabrechnung2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.ucKlinikCbo1.Visible = true;
            this.setButtonsAktivDeaktiv(SiteEvents.abrech_sammelabrechnung2);
            this.mainWindow.tabMain.ActiveTab = this.mainWindow.tabMain.Tabs[1];
            this.mainWindow.tabMain.SelectedTab = this.mainWindow.tabMain.Tabs[1];
            this.mainWindow.selectTab();

            object  dt =  this.mainWindow.ucKlientÜbersicht1.ucKlientenverwaltung3.ucRechnungenKlient1.ucCalcs1.dtVon.Value;
            if (dt != null )
                this.mainWindow.ucSRSitemap.form.loadData((DateTime )dt);
            else
                this.mainWindow.ucSRSitemap.form.loadData(DateTime .Now);

            this.Cursor = Cursors.Default;
        }

        private void btnStammdaten_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.ucKlinikCbo1.Visible = false;
            this.setButtonsAktivDeaktiv(SiteEvents.abrech_stammdten );
            this.mainWindow.tabMain.ActiveTab = this.mainWindow.tabMain.Tabs[4];
            this.mainWindow.tabMain.SelectedTab = this.mainWindow.tabMain.Tabs[4];
            this.mainWindow.selectTab();

            this.Cursor = Cursors.Default;
        }
        private void btnBerichte_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.ucKlinikCbo1.Visible = false;
            this.setButtonsAktivDeaktiv(SiteEvents.abrech_berichte );
            this.mainWindow.tabMain.ActiveTab = this.mainWindow.tabMain.Tabs[5];
            this.mainWindow.tabMain.SelectedTab = this.mainWindow.tabMain.Tabs[5];
            this.mainWindow.selectTab();

            this.Cursor = Cursors.Default;
        }

        private void btnBuchhaltung_Click_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.ucKlinikCbo1.Visible = true;
            this.setButtonsAktivDeaktiv(SiteEvents.abrech_buchhaltung);
            this.mainWindow.tabMain.ActiveTab = this.mainWindow.tabMain.Tabs[2];
            this.mainWindow.tabMain.SelectedTab = this.mainWindow.tabMain.Tabs[2];
            this.mainWindow.selectTab();

            this.Cursor = Cursors.Default;
        }

        private void btnDepot_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.ucKlinikCbo1.Visible = true;
            this.setButtonsAktivDeaktiv(SiteEvents.abrech_Depotgeld);
            this.mainWindow.tabMain.ActiveTab = this.mainWindow.tabMain.Tabs[3];
            this.mainWindow.tabMain.SelectedTab = this.mainWindow.tabMain.Tabs[3];
            this.mainWindow.selectTab();

            this.Cursor = Cursors.Default;
        }

        public  void setUI(bool nurDepot )
        {
            if (nurDepot)
            {
                this.panelKlient.Visible = false;
                this.panelSr.Visible = false;
                this.panelBuchhaltung.Visible = false;
                this.setButtonsAktivDeaktiv(SiteEvents.abrech_Depotgeld );
            }
            else
                this.setButtonsAktivDeaktiv(SiteEvents.abrech_patient);

            if (!ENV.HasRight(UserRights.depotgeldAnzeigen))
                this.panelDepot.Visible = false;

        }

        private void ucKlinikCbo1_klinikHasChanged( dsKlinik.KlinikRow rKlinik)
        {
            try
            {
                this.mainWindow.KlinikHasChanged(rKlinik);
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void ucHeader_VisibleChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception exch)
            {
                ENV.HandleException(exch);
            }
        }


    }
}
