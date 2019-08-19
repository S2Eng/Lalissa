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
    public partial class frmZeitbereich : QS2.Desktop.ControlManagment.baseForm 
    {
        public frmZeitbereich()
        {
            InitializeComponent();
            if (!ENV.AppRunning)
                return;

            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            ucZeitbereich1.Init();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ucZeitbereich1.Write();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
                return;
            }
            DialogResult = DialogResult.OK;
            //this.Close();
            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Zeitbereiche wurden gespeichert!", "Zeitbereiche", MessageBoxButtons.OK);
        }

        
    }
}