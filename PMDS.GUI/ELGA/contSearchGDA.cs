using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PMDS.GUI.ELGA
{

    public partial class contSearchGDA : UserControl
    {
        public frmSearchGDA mainWindow = null;
        public bool IsInitialized = false;



        public contSearchGDA()
        {
            InitializeComponent();
        }

        private void ContSearchGDA_Load(object sender, EventArgs e)
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
                throw new Exception("contSearchGDA.contELGARights: " + ex.ToString());
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;



            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }



        private void GridProtocoll_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
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
