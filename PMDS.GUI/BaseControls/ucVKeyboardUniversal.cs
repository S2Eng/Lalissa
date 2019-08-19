using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PMDS.GUI.BaseControls
{

    

    public partial class ucVKeyboardUniversal : QS2.Desktop.ControlManagment.BaseControl
    {

        private bool _Alpha = true;

        public ucVKeyboardUniversal()
        {
            InitializeComponent();
            if (DesignMode)
                return;

            ShowHide();
        }

        private void ShowHide()
        {
            ucVKeyboard1.Visible        = false;
            ucVKeyboardAlpha1.Visible   = false;
            UserControl uc              = null;
            if (_Alpha)
                uc = ucVKeyboardAlpha1;
            else
                uc = ucVKeyboard1;

            uc.Top = 0;
            uc.Left = 0;
            uc.Visible = true;
            ChangeButtonText();
        }

        private void ChangeButtonText()
        {
            btnToogle.Text = _Alpha ? "QWERTZ" : "A->Z";
        }

        private void btnToogle_Click(object sender, EventArgs e)
        {
            _Alpha = !_Alpha;
            ShowHide();
        }

        private void ucVKeyboardUniversal_EnabledChanged(object sender, EventArgs e)
        {
        }
    }
}
