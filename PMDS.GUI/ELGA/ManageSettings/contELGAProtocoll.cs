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

    public partial class contELGAProtocoll : UserControl
    {

        public contELGAUser mainWindow = null;
        public bool IsInitialized = false;



        public contELGAProtocoll()
        {
            InitializeComponent();
        }

        private void ContELGAProtocoll_Load(object sender, EventArgs e)
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
                throw new Exception("contELGAProtocoll.initControl: " + ex.ToString());
            }
        }


        private void GridProtocoll_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {

        }
        private void GridProtocoll_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {

        }
        private void GridProtocoll_Click(object sender, EventArgs e)
        {

        }
        private void GridProtocoll_DoubleClick(object sender, EventArgs e)
        {

        }


    }
}
