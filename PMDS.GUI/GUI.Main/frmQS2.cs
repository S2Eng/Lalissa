using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace PMDS.GUI
{


    public partial class frmQS2 : QS2.Desktop.ControlManagment.baseForm 
    {
        public bool UnvisibleOnClose = false;





        public frmQS2()
        {
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }

        private void frmQS2_Load(object sender, EventArgs e)
        {

        }

        private void frmQS2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.UnvisibleOnClose)
            {
                this.Visible = false;
                e.Cancel = true;
            }
            else
            {

            }
        }



    }
}
