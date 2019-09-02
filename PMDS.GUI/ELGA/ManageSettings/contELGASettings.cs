using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PMDS.GUI.ELGA.ManageSettings
{

    public partial class contELGASettings : UserControl
    {

        public contELGAUser mainWindow = null;
        public bool IsInitialized = false;



        public contELGASettings()
        {
            InitializeComponent();
        }

        private void ContELGASettings_Load(object sender, EventArgs e)
        {

        }


        public void initControl()
        {
            try
            {
                if (!this.IsInitialized)
                {


                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contELGAUserAdmin.contELGASettings: " + ex.ToString());
            }
        }


    }
}
