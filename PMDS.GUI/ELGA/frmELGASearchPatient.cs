using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMDS.GUI.ELGA
{

    public partial class frmELGASearchPatient : Form
    {


        public frmELGASearchPatient()
        {
            InitializeComponent();
        }

        private void FrmELGASearchPatient_Load(object sender, EventArgs e)
        {

        }



        public void initControl(Guid IDPatient, Guid IDAufenthalt, bool SozVersNrEditable, string AuthUniversalID)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

                this.contELGASearchPatient1.mainWindow = this;
                this.contELGASearchPatient1.initControl(IDPatient, IDAufenthalt, SozVersNrEditable, AuthUniversalID);

            }
            catch (Exception ex)
            {
                throw new Exception("frmELGASearchPatient.contELGASettings: " + ex.ToString());
            }
        }

    }
}
