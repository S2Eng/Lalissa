using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;

namespace PMDS.GUI.BaseControls
{
    public partial class frmZeitbereicheZeitbereichserien : QS2.Desktop.ControlManagment.baseForm 
    {
        public frmZeitbereicheZeitbereichserien()
        {
            InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime|| !ENV.AppRunning) 
                return;
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            ucZeitbereicheZeitbereichserien1.Init();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                ucZeitbereicheZeitbereichserien1.Write();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
                return;
            }
            this.Close();
        }
    }
}