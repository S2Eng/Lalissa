using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global.db.Patient;




namespace PMDS.Calc.UI.Admin
{

    public partial class ucDepotgeldCalcÜbersicht : QS2.Desktop.ControlManagment.BaseControl
    {

        private PMDS.Calc.UI.ucCalcsSitemap ucCalcsSitemap;

        private PMDS.UI.Sitemap.UIFct _sitemap = new PMDS.UI.Sitemap.UIFct();
        private List<PMDS.UI.Sitemap.cButt> listButt = new List<PMDS.UI.Sitemap.cButt>();




        public ucDepotgeldCalcÜbersicht()
        {
            InitializeComponent();
        }

        public void initControl()
        {
            this.tbMain.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
            this.ucCalcsSitemap = new PMDS.Calc.UI.ucCalcsSitemap();
            this.setUIButtons();

            this.ucCalcDepotgeld1.initControl();
            this.ucCalcsSitemap.initControl(this.ucCalcs1, false, PMDS.Calc.UI.ucCalcsSitemap.eTyp.depotgeld, false );

            PMDS.Global.ENV.evklinikChanged += new PMDS.Global.klinikChanged(this.klinikChanged);
        }

        public void klinikChanged( dsKlinik.KlinikRow rSelectedKlinik, bool allKliniken)
        {

        }

        private void setUIButtons()
        {
            PMDS.UI.Sitemap.cButt itm = new PMDS.UI.Sitemap.cButt();
            itm.butt = this.btnAbrechnen ;
            itm.nr = Convert.ToInt32(this.btnAbrechnen.Tag);
            this.listButt.Add(itm);

            itm = new PMDS.UI.Sitemap.cButt();
            itm.butt = this.btnRechnungen;
            itm.nr = Convert.ToInt32(this.btnRechnungen.Tag);
            this.listButt.Add(itm);

            this._sitemap.aktivateButton(this.listButt, Convert.ToInt32(this.btnAbrechnen.Tag));
        }

        private void buttonHeader(object sender, EventArgs e)
        {

        }

        private void ucDepotgeldCalc_Load(object sender, EventArgs e)
        {

        }

        private void btnClick(object sender, EventArgs e)
        {

        }

        private void btnAbrechnen_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._sitemap.aktivateButton(this.listButt, Convert.ToInt32(((Infragistics.Win.Misc.UltraButton)sender).Tag));
                this.tbMain.SelectedTab = this.tbMain.Tabs[0];
                this.tbMain.Tabs[0].Visible = true;
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

        private void btnRechnungen_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._sitemap.aktivateButton(this.listButt, Convert.ToInt32(((Infragistics.Win.Misc.UltraButton)sender).Tag));
                this.tbMain.SelectedTab = this.tbMain.Tabs[1];
                this.tbMain.Tabs[1].Visible = true;
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
