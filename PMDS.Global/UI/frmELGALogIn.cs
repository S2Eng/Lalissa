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

    public partial class frmELGALogIn : Form
    {



        public frmELGALogIn()
        {
            InitializeComponent();
        }

        private void frmELGALogIn_Load(object sender, EventArgs e)
        {

        }


        public void initControl()
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

                this.contELGALogIn1.mainWindow = this;
                this.contELGALogIn1.initControl();

            }
            catch (Exception ex)
            {
                throw new Exception("frmELGALogIn.frmELGALogIn: " + ex.ToString());
            }
        }

    }

}
