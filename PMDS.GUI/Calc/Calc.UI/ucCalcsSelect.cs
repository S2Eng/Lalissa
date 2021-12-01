using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;




namespace PMDS.Calc.UI
{
    public partial class ucCalcsSelect : QS2.Desktop.ControlManagment.BaseControl
    {

        private     PMDS.Calc.UI.ucCalcsSitemap _calcsSitemap;
        private    PMDS.UI.Sitemap.UIFct _sitemap;
        


        public ucCalcsSelect()
        {
            InitializeComponent();
        }
        public void  initControl()
        {
            this._calcsSitemap = new PMDS.Calc.UI.ucCalcsSitemap();
            this._sitemap = new PMDS.UI.Sitemap.UIFct ();
            this._calcsSitemap.initControl(this.ucCalcs1, true, ucCalcsSitemap.eTyp .calc, true  );
            this.ucKlienten1.typ = PMDS.Global.eSendMain.abrechnung;
            this.loadKlienten();
        }

        public void loadKlienten()
        {
            //PMDS.DB.DBPatient db = new PMDS.DB.DBPatient();
            //System.Guid[] arrAbt = null;
            //PMDS.Data.Patient.dsPatientStation.PatientDataTable tKlienten = db.GetPatienten("", false, arrAbt, System.Guid.Empty, new DateTime(1900, 1, 1), new DateTime(1900, 1, 1), new DateTime(1900, 1, 1), new DateTime(1900, 1, 1));
            this.ucKlienten1.loadComboAuswahl();
            this.ucKlienten1.checkVonBis(true, false);
            this.ucKlienten1.LoadListklienten(false);
        }

        private void ucCalcsSelect_Load(object sender, EventArgs e)
        {

        }

        private void klientenLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.loadKlienten();
        }
    }
}
