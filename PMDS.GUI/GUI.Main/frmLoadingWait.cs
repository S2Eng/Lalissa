using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PMDS.GUI.GUI.Main
{

    public partial class frmLoadingWait : Form
    {

        public bool isInitialized = false;
        


        public frmLoadingWait()
        {
            InitializeComponent();
        }

        private void frmLoadingWait_Load(object sender, EventArgs e)
        {

        }



        public void initControl()
        {
            try
            {
                if (!this.isInitialized)
                {


                    this.isInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("initControl: " + ex.ToString());
            }
        }

        private void frmLoadingWait_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void frmLoadingWait_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }
    }

}
