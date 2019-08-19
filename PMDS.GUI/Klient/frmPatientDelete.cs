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


    public partial class frmPatientDelete : Form
    {


        public frmPatientDelete()
        {
            InitializeComponent();
        }


        private void frmPatientDelete_Load(object sender, EventArgs e)
        {

        }

        public void initControl(Guid IDPatient)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32);

                this.contPatientDelete1.MainWindow = this;
                this.contPatientDelete1.initControl(IDPatient);

            }
            catch (Exception ex)
            {
                throw new Exception("frmPatientDelete.initControl: " + ex.ToString());
            }
        }

    }
}
