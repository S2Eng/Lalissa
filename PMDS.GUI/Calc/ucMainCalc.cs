using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinTabControl;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Klient;
using PMDS.Global.db.Patient;

namespace PMDS.Calc.UI.Admin
{

    
    public partial class ucMainCalc : QS2.Desktop.ControlManagment.BaseControl
    {

        private AbrechnungsAktion _currentAction = AbrechnungsAktion.Klienten;

        public ucCalcKlientenSelect ucKlient‹bersicht1;
        public PMDS.Calc.UI.ucSR ucSR1;
        public ucDepotgeldCalc‹bersicht ucDepotgeld1;
        public ucBuchhaltung ucBuchhaltung1;
        public ucBerichte ucBerichte1;


        public PMDS.Calc.UI.ucSRSitemap ucSRSitemap;
        public PMDS.Calc.Logic.calculation calculation;
        public PMDS.UI.Sitemap.UIFct sitemap;
        public ucStammdaten ucStammdaten1;


        public enum AbrechnungsAktion
        {
            Klienten = 0,
            Sammelrechnung = 1,
            depotgeld = 2,
            Buchhaltung = 3,
            Stammdaten = 4,
            Berichte
        }




        public ucMainCalc()
        {
            InitializeComponent();
        }

        public void initControl(bool nurDepot)
        {
            try
            {
                this.ucHeader1.mainWindow = this;
                tabMain.Style = UltraTabControlStyle.Wizard;

                this.ucHeader1.ucKlinikCbo1.typ = GUI.BaseControls.ucKlinikCbo.eTyp.Calc;
                this.ucHeader1.ucKlinikCbo1.initControl();
                this.ucHeader1.setUI(nurDepot);
                if (nurDepot)
                {
                    //if (ENV.HasRight(UserRights.depotgeldAnzeigen))
                    this._currentAction = AbrechnungsAktion.depotgeld;
                    this.tabMain.ActiveTab = this.tabMain.Tabs[3];
                    this.tabMain.SelectedTab = this.tabMain.Tabs[3];
                }

                this.sitemap = new PMDS.UI.Sitemap.UIFct();
                this.calculation = new PMDS.Calc.Logic.calculation();
                this.sitemap.initCalc();
                this.selectTab();
            }
            catch (Exception exch)
            {
                ENV.HandleException(exch);
            }
            finally
            {
            }
        }

        public void selectTab()
        {
            if (!ENV.AppRunning)
                return;

            AbrechnungsAktion mode = (AbrechnungsAktion)Enum.Parse(typeof(AbrechnungsAktion), tabMain.SelectedTab.Key);
            SwitchTo(mode);
        }

        private void SwitchTo(AbrechnungsAktion mode)
        {
            try
            {
                _currentAction = mode;

                switch (mode)
                {
                    case AbrechnungsAktion.Klienten:
                        if (this.ucKlient‹bersicht1 == null)
                        {
                            this.ucKlient‹bersicht1 = new ucCalcKlientenSelect();
                            this.ucKlient‹bersicht1.Dock = DockStyle.Fill;
                            this.panelAbrechnungen2.Controls.Add(this.ucKlient‹bersicht1);
                            this.ucKlient‹bersicht1.mainWindow = this;
                            ucKlient‹bersicht1.initControl();
                        }
                        break;

                    case AbrechnungsAktion.Sammelrechnung:
                        if (this.ucSRSitemap == null)
                        {
                            this.ucSRSitemap = new PMDS.Calc.UI.ucSRSitemap();
                            this.ucSR1 = new PMDS.Calc.UI.ucSR();
                            this.ucSR1.Dock = DockStyle.Fill;
                            this.panelSR.Controls.Add(this.ucSR1);
                            this.ucSRSitemap.initControl(ref this.ucSR1);
                        }
                        break;

                    case AbrechnungsAktion.depotgeld :
                        if (this.ucDepotgeld1 == null)
                        {
                            dsKlinik.KlinikRow rKlinik = this.ucHeader1.ucKlinikCbo1.doSelectedKlinik(false);
                            if (rKlinik != null)
                            {
                                //this.ucKlienten2.loadProdBewerber(false, "Alle Klienten");
                            }
                            else
                            {
                                //QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Hinweis: Keine Kliniken vorhanden!");
                            }

                            this.ucDepotgeld1 = new ucDepotgeldCalc‹bersicht();
                            this.ucDepotgeld1.Dock = DockStyle.Fill;
                            this.panelDepotgeld.Controls.Add(this.ucDepotgeld1);
                            this.ucDepotgeld1.initControl();
                        }
                        break;

                    case AbrechnungsAktion.Buchhaltung:
                        if (this.ucBuchhaltung1 == null)
                        {
                            this.ucBuchhaltung1 = new ucBuchhaltung();
                            this.ucBuchhaltung1.Dock = DockStyle.Fill;
                            this.panelBuchhaltung.Controls.Add(this.ucBuchhaltung1);
                            this.ucBuchhaltung1.initControl();
                        }
                        break;

                    case AbrechnungsAktion.Stammdaten:
                        if (this.ucStammdaten1 == null)
                        {
                            this.ucStammdaten1 = new ucStammdaten();
                            this.ucStammdaten1.Dock = DockStyle.Fill;
                            this.panelStammdaten.Controls.Add(this.ucStammdaten1);
                            this.ucStammdaten1.initControl();
                        }
                        break;

                    case AbrechnungsAktion.Berichte:
                        if (this.ucBerichte1 == null)
                        {
                            this.ucBerichte1  = new ucBerichte();
                            this.ucBerichte1.Dock = DockStyle.Fill;
                            this.panelBerichte.Controls.Add(this.ucBerichte1);
                            this.ucBerichte1.initControl();
                        }
                        break;
                }

            }
            catch (Exception exch)
            {
                ENV.HandleException(exch);
            }
        }

        public void KlinikHasChanged(PMDS.Global.db.Patient.dsKlinik.KlinikRow rKlinik)
        {
            try
            {
         

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }


    }
}