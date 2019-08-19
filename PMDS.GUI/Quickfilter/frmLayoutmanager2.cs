using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace PMDS.GUI.Quickfilter
{

    public partial class frmLayoutmanager2 : Form
    {



        public frmLayoutmanager2()
        {
            InitializeComponent();
        }

        private void frmLayoutmanager2_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

                this.contLayoutmanager21.mainWindow = this;
                this.contLayoutmanager21.initControl();

            }
            catch (Exception ex)
            {
                throw new Exception("frmLayoutmanager2.initControl: " + ex.ToString());
            }
        }


    }

}
