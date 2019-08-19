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

    public partial class frmBereiche : Form
    {



        public frmBereiche()
        {
            InitializeComponent();
        }


        private void frmAbteilungen_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }

        public void initControl(Guid IDKlinik)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.PMDS_Klientenakt.ico_Klientenliste, 32, 32);

                this.ucBereiche1.mainWindow = this;
                this.ucBereiche1.initControl(IDKlinik);

            }
            catch (Exception ex)
            {
                throw new Exception("frmAbteilungen.initControl: " + ex.ToString());
            }
        }

    }
}
