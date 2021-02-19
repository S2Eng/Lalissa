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
    public partial class frmZeitbereichSerien : QS2.Desktop.ControlManagment.baseForm 
    {
        public frmZeitbereichSerien()
        {
            InitializeComponent();
            if (!ENV.AppRunning)
                return;

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            ucZeitbereichSerien1.Init();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ucZeitbereichSerien1.Write();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
                return;
            }
            DialogResult = DialogResult.OK;
            //this.Close();
            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Zeitbereichserien wurden gespeichert!", "Zeitbereichserien", MessageBoxButtons.OK);

        }

        
    }
}