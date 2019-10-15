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

    public partial class frmELGASearchGDA : Form
    {



        public frmELGASearchGDA()
        {
            InitializeComponent();
        }

        private void FrmELGASearchGDA_Load(object sender, EventArgs e)
        {

        }



        public void initControl()
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

                this.contELGASearchGDA1.mainWindow = this;
                this.contELGASearchGDA1.initControl();

            }
            catch (Exception ex)
            {
                throw new Exception("frmELGASearchGDA.contELGASettings: " + ex.ToString());
            }
        }

    }

}

