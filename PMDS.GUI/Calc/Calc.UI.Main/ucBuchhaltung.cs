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
using PMDS.Abrechnung.Global;
using PMDS.BusinessLogic.Abrechnung;
using PMDS.GUI;
using PMDS.Data.Global;
using PMDS.GUI.BaseControls;
using PMDS.Global.db.Patient;



namespace PMDS.Calc.UI.Admin
{

       

    public partial class ucBuchhaltung : QS2.Desktop.ControlManagment.BaseControl
    {


        private PMDS.UI.Sitemap.UIFct _sitemap = new PMDS.UI.Sitemap.UIFct();
        private List<PMDS.UI.Sitemap.cButt> listButt = new List<PMDS.UI.Sitemap.cButt>();

        private bool loaded = false;
        

        private PMDS.Calc.UI.ucBookings ucBookings1;
        private PMDS.Calc.UI.ucBookingsSitemap ucBookingsSitemap;

        private PMDS.Calc.UI.ucCalcs ucCalcs1;
        private PMDS.Calc.UI.ucCalcsSitemap ucCalcsSitemap;

        private PMDS.Calc.UI.ucDaylist ucDaylist1;




        public enum BuchhaltungsAktion
        {
            Buchungen = 0,
            Rechnungen = 1,
            Tagsatzliste = 2
        }
        


        public ucBuchhaltung()
        {
            InitializeComponent();
        }

        public void initControl()
        {

            if (this.loaded) return;
 
            this.tabMain.Style = UltraTabControlStyle.Wizard;
            this.setUIButtons();

            SwitchTo(BuchhaltungsAktion.Buchungen);

            this.loaded = true;
        }

        public void SwitchTo(BuchhaltungsAktion mode)
        {
            tabMain.SelectedTab = tabMain.Tabs[mode.ToString()];
            this.InitControl(mode);

            PMDS.Global.ENV.evklinikChanged += new PMDS.Global.klinikChanged(this.klinikChanged);
        }

        public void klinikChanged( dsKlinik.KlinikRow rSelectedKlinik, bool allKliniken)
        {

        }
        private void InitControl(BuchhaltungsAktion mode)
        {
            switch (mode)
            {
                case BuchhaltungsAktion.Buchungen :
                    if (this.ucBookingsSitemap == null) this.initBookings();
                    break;
                case BuchhaltungsAktion.Rechnungen:
                    if (this.ucCalcsSitemap == null) this.initCalcs();
                    break;
                case BuchhaltungsAktion.Tagsatzliste:
                    if (this.ucDaylist1 == null) this.initTagsatzliste();
                    break;
            }
        }
        
        public void initBookings() 
        {
            this.ucBookings1 = new PMDS.Calc.UI.ucBookings();
            this.ucBookings1.Dock = DockStyle.Fill;
            this.panelBuchungen.Controls.Add(this.ucBookings1);

            this.ucBookingsSitemap = new PMDS.Calc.UI.ucBookingsSitemap();
            this.ucBookingsSitemap.initControl(ref this.ucBookings1);
        }
 
        public void initCalcs()
        {
            this.ucCalcs1 = new PMDS.Calc.UI.ucCalcs();
            this.ucCalcs1.Dock = DockStyle.Fill;
            this.panelRechnungen.Controls.Add(this.ucCalcs1);

            this.ucCalcsSitemap = new PMDS.Calc.UI.ucCalcsSitemap();
            this.ucCalcsSitemap.initControl(this.ucCalcs1, false, PMDS.Calc.UI.ucCalcsSitemap.eTyp .buchhaltung,false  );
        }
        public void initTagsatzliste()
        {
            this.ucDaylist1 = new PMDS.Calc.UI.ucDaylist();
            this.ucDaylist1.Dock = DockStyle.Fill;
            this.panelTagsatzliste.Controls.Add(this.ucDaylist1);

            this.ucDaylist1.initControl();
        }

        private void buttonHeader(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor ;

                this._sitemap.aktivateButton(this.listButt, Convert.ToInt32(((Infragistics.Win.Misc.UltraButton)sender).Tag));
                BuchhaltungsAktion modus = new BuchhaltungsAktion();
                modus = (BuchhaltungsAktion)Convert.ToInt32(((Infragistics.Win.Misc.UltraButton)sender).Tag);
                Application.DoEvents();
                this.SwitchTo(modus);
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
        private void setUIButtons( )
        {
            PMDS.UI.Sitemap.cButt itm = new PMDS.UI.Sitemap.cButt();
            itm.butt = this.btnBuchungen;
            itm.nr = Convert .ToInt32 ( this.btnBuchungen.Tag);
            this.listButt.Add(itm);
           
            itm = new PMDS.UI.Sitemap.cButt();
            itm.butt = this.btnRechnungen‹bersicht;
            itm.nr = Convert.ToInt32(this.btnRechnungen‹bersicht.Tag);
            this.listButt.Add(itm);

            itm = new PMDS.UI.Sitemap.cButt();
            itm.butt = this.btnTagsatzliste ;
            itm.nr = Convert.ToInt32(this.btnTagsatzliste.Tag);
            this.listButt.Add(itm);

            this._sitemap.aktivateButton(this.listButt, Convert.ToInt32(this.btnBuchungen.Tag));
        }

        private void ultraTabControl1_SelectedTabChanged(object sender, SelectedTabChangedEventArgs e)
        {
            //if (e.Tab.Key == "Rechnungen")
        }


    }
}
