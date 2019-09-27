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

    public partial class frmELGAChangePassword : Form
    {


        public frmELGAChangePassword()
        {
            InitializeComponent();
        }

        private void FrmELGAChangePassword_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

                this.contELGAChangePassword1.mainWindow = this;
                this.contELGAChangePassword1.initControl();

            }
            catch (Exception ex)
            {
                throw new Exception("frmELGAChangePassword.frmELGALogIn: " + ex.ToString());
            }
        }

    }
}
