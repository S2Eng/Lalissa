using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;




namespace PMDS.GUI.Klient
{


    public partial class frmVerwaltungKlinikenUser : Form
    {


        public frmVerwaltungKlinikenUser()
        {
            InitializeComponent();
        }


        private void frmVerwaltungKlinikenPatienten_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }

        public void initControl()
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.PMDS_Klientenakt.ico_Patient, 32, 32);

                this.ucVerwaltungKlinikenUser1.mainWindow = this;
                this.ucVerwaltungKlinikenUser1.initControl();

            }
            catch (Exception ex)
            {
                throw new Exception("frmVerwaltungKlinikenPatienten.initControl: " + ex.ToString());
            }
        }

    }
}
