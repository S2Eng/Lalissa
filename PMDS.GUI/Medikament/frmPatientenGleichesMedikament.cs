using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PMDS.GUI.Medikament
{

    public partial class frmPatientenGleichesMedikament : Form
    {



        public frmPatientenGleichesMedikament()
        {
            InitializeComponent();
        }

        private void frmPatientenGleichesMedikament_Load(object sender, EventArgs e)
        {

        }


        public void initControl(Guid IDMedikament, Guid IDAufenthalt)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

                this.ucPatientenGleichesMedikament1.mainWindow = this;
                this.ucPatientenGleichesMedikament1.initControl(IDMedikament, IDAufenthalt);

            }
            catch (Exception ex)
            {
                throw new Exception("frmPatientenGleichesMedikament.initControl: " + ex.ToString());
            }
        }

    }
}
