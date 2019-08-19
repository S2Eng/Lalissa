using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace PMDS.GUI.Medikament
{
    public partial class frmMedikamenteSuche : Form
    {



        public frmMedikamenteSuche()
        {
            InitializeComponent();
        }

        private void frmMedikamenteSuche_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
                this.ucMedikamenteSuche1.mainWindow = this;
                this.ucMedikamenteSuche1.initControl();

            }
            catch (Exception ex)
            {
                throw new Exception("frmMedikamenteSuche.initControl: " + ex.ToString());
            }
        }

    }
}
