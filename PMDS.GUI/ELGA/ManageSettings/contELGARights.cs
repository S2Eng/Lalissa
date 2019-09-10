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

    public partial class contELGARights : UserControl
    {

        public contELGAUser mainWindow = null;
        public bool IsInitialized = false;




        public contELGARights()
        {
            InitializeComponent();
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
                throw new Exception("contELGAUserAdmin.contELGARights: " + ex.ToString());
            }
        }


        private void ContELGARights_Load(object sender, EventArgs e)
        {

        }


        private void GridRights_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {

        }
        private void GridRights_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {

        }
        private void GridRights_Click(object sender, EventArgs e)
        {

        }
        private void GridRights_DoubleClick(object sender, EventArgs e)
        {

        }




    }
}
