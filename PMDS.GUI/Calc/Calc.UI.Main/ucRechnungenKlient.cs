using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic.Abrechnung;
using PMDS.BusinessLogic;
using PMDS.Print;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Win.Misc;
using PMDS.Data.Global;
using PMDS.Abrechnung.Global;
using PMDS.Global;
using PMDS.GUI;




namespace PMDS.Calc.UI.Admin
{

    
    public partial class ucRechnungenKlient : QS2.Desktop.ControlManagment.BaseControl 
    {
        private List<Guid> _lIDKlienten = new List<Guid>();
        private   PMDS.Calc.UI.ucCalcsSitemap  calcsSitemap;
        private bool isLoaded = false;
        



        public ucRechnungenKlient()
        {
            InitializeComponent();
        }

        public void  initControl()
        {
            if (this.isLoaded) return;

            this.tabMain.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
            this.calcsSitemap = new PMDS.Calc.UI.ucCalcsSitemap();
            this.calcsSitemap.initControl(this.ucCalcs1, false, PMDS.Calc.UI.ucCalcsSitemap.eTyp.calc,false  );
           
            this.isLoaded = true;
        }

        public List<Guid> Klienten
        {
            get { return _lIDKlienten; }
            set
            {
                _lIDKlienten = value;
                this.calcsSitemap.sitemap.listID.Clear();
                foreach (System.Guid ID in   Klienten )
                    this.calcsSitemap.sitemap.listID.Add(ID.ToString());

                this.ucCalcs1.loadCalcs();
            }
        }
        public void RedrawConrol()
        {
           



        }

    }


}
