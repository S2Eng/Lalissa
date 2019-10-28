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
    public partial class frmELGAKlient : Form
    {


        public frmELGAKlient()
        {
            InitializeComponent();
        }

        private void frmELGAKlient_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

                this.contELGAKlient1.mainWindowAufnahme = this;
                this.contELGAKlient1.initControl(true);

            }
            catch (Exception ex)
            {
                throw new Exception("frmELGAKlient.frmELGALogIn: " + ex.ToString());
            }
        }

    }

}

