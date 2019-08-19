using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace PMDS.GUI.Sturzprotokoll
{



    public partial class frmSturz : QS2.Desktop.ControlManagment.baseForm 
    {


        public frmSturz()
        {
            InitializeComponent();
        }


        private void frmSturz_Load(object sender, EventArgs e)
        {
            try
            {
                this.Visible = true;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void frmSturz_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Visible = false;
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }


    }
}
