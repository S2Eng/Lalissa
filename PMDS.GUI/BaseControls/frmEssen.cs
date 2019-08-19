using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PMDS.GUI.BaseControls
{
    public partial class frmEssen : QS2.Desktop.ControlManagment.baseForm 
    {
        public frmEssen()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ucEssen1.Write();
            this.Close();
        }

        private void frmEssen_Load(object sender, EventArgs e)
        {
            QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
            ControlManagment1.autoTranslateForm(this);
        }

        
    }
}