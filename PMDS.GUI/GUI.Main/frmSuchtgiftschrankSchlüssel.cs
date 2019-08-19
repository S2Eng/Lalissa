using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace PMDS.GUI.GUI.Main
{


    public partial class frmSuchtgiftschrankSchlüssel : Form
    {


        public frmSuchtgiftschrankSchlüssel()
        {
            InitializeComponent();
        }


        private void frmSuchtgiftschrankSchlüssel_Load(object sender, EventArgs e)
        {

        }

        


        public void initControl()
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein2.ico_Rechte, 32, 32);

                this.ucSuchtgiftschrankSchlüssel1.mainWindow = this;
                this.ucSuchtgiftschrankSchlüssel1.initControl();

            }
            catch (Exception ex)
            {
                throw new Exception("frmSuchtgiftschrankSchlüssel.initControl: " + ex.ToString());
            }
        }


    }

}
