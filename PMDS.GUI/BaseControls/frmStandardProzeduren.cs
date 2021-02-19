using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PMDS.GUI
{
    public partial class frmStandardProzeduren : QS2.Desktop.ControlManagment.baseForm 
    {
        private bool _bCanclose = false;

        public frmStandardProzeduren()
        {
            InitializeComponent();

            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ucStandardProzeduren1.Save())
                return;

            _bCanclose = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _bCanclose = true;
        }

        private void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_bCanclose;
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            ucStandardProzeduren1.RefreshControl();
        }
    }
}