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

    public partial class frmELGASearchDocuments : Form
    {


        public frmELGASearchDocuments()
        {
            InitializeComponent();
        }

        private void FrmELGASearchDocuments_Load(object sender, EventArgs e)
        {

        }


        public void initControl(Guid IDPatient)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

                this.contELGASearchDocuments1.mainWindow = this;
                this.contELGASearchDocuments1.initControl(IDPatient);

            }
            catch (Exception ex)
            {
                throw new Exception("frmELGASearchDocuments.contELGASettings: " + ex.ToString());
            }
        }

    }

}

