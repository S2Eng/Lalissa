using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.Global.db.Patient;



namespace PMDS.Calc.UI.Admin
{


    public partial class frmDepotgeldKlient : QS2.Desktop.ControlManagment.baseForm 
    {

        public ucDepotgeldKlient ucDepotgeldKlient1;


        
        public frmDepotgeldKlient()
        {
            InitializeComponent();
        }

        private void frmDepotgeldKlient_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.PMDS_Abrechnung.ico_Depotgeld, 32, 32);
        }
        public  void initControl()
        {

            PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
             dsKlinik.KlinikRow rActuelKlinik = DBKlinik1.loadKlinik(PMDS.Global.ENV.IDKlinik, true);
            //this.Text = "Depotgeld für " + rActuelKlinik.Bezeichnung.Trim() + "";

            this.ucDepotgeldKlient1 = new ucDepotgeldKlient();
            this.ucDepotgeldKlient1.Dock = DockStyle.Fill;
            this.ucDepotgeldKlient1.mainForm = this;
            this.ucDepotgeldKlient1.initControl();
            this.panelDepot.Controls.Add(this.ucDepotgeldKlient1);
        }
    }
}
