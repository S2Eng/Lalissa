using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PMDS.GUI.Verordnungen
{
    
    public partial class frmVOBestellung : Form
    {
        
        public frmVOBestellung()
        {
            InitializeComponent();
        }

        private void frmVOBestelldaten_Load(object sender, EventArgs e)
        {

        }

        public void initControl(ucVOBestellung.eTypeUI TypeUI, Nullable<Guid> IDAufenthalt)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

                this.ucVOBestellung1.mainWindow = this;
                this.ucVOBestellung1.initControl(TypeUI, IDAufenthalt);

            }
            catch (Exception ex)
            {
                throw new Exception("frmVOBestellung.initControl: " + ex.ToString());
            }
        }

    }
}
