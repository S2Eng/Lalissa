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

    public partial class frmRezeptEintragMedDatenAdd2 : Form
    {



        public frmRezeptEintragMedDatenAdd2()
        {
            InitializeComponent();
        }

        private void frmRezeptEintragMedDatenAdd2_Load(object sender, EventArgs e)
        {

        }

        public void initControl(Guid IDRezeptEintragMedDaten, Guid IDPatient, ucRezeptEintragMedDaten.eTypeUI TypeUI)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

                this.ucRezeptEintragMedDatenAdd1.mainWindowFrm = this;
                this.ucRezeptEintragMedDatenAdd1.initControl(IDRezeptEintragMedDaten, IDPatient, TypeUI);
 
            }
            catch (Exception ex)
            {
                throw new Exception("frmRezeptEintragMedDatenAdd2.initControl: " + ex.ToString());
            }
        }

    }
}
