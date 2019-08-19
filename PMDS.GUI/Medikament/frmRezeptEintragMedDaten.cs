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

    public partial class frmRezeptEintragMedDaten : Form
    {




        public frmRezeptEintragMedDaten()
        {
            InitializeComponent();
        }

        private void frmRezeptEintragMedDaten_Load(object sender, EventArgs e)
        {

        }

        public void initControl(Guid IDRezeptEintragMedDatenWundePos, ucRezeptEintragMedDaten.eTypeUI TypeUI)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

                this.ucRezeptEintragMedDaten1.mainWindow = this;
                this.ucRezeptEintragMedDaten1.initControl(IDRezeptEintragMedDatenWundePos, TypeUI);

            }
            catch (Exception ex)
            {
                throw new Exception("frmRezeptEintragMedDaten.initControl: " + ex.ToString());
            }
        }


    }
}
