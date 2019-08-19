using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PMDS.GUI.BaseControls
{
    public partial class frmTextVerschluesseln : Form
    {
        public frmTextVerschluesseln()
        {
            InitializeComponent();
        }

        private void txtKlartext_KeyUp(object sender, KeyEventArgs e)
        {
            this.txtVerschluesselterText.Text = PMDS.BusinessLogic.BUtil.EncryptString(this.txtKlartext.Text);
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {          
            if (this.txtVerschluesselterText.Text != null && this.txtVerschluesselterText.Text != "")
                Clipboard.SetText(this.txtVerschluesselterText.Text);
        }

        private void txtKlartext_ValueChanged(object sender, EventArgs e)
        {

        }

        private void frmTextVerschluesseln_Load(object sender, EventArgs e)
        {
            QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
            ControlManagment1.autoTranslateForm(this);
        }

        private void btnLoadLicense_Click(object sender, EventArgs e)
        {
            this.hideLicenseControls();
            this.txtKlartext.Text = PMDS.Global.ENV.License;
            this.txtVerschluesselterText.Text = PMDS.BusinessLogic.BUtil.EncryptString(this.txtKlartext.Text);
        }
       
        private void ultraButton1_Click(object sender, EventArgs e)
        {

        }

        private void lblKlartext_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCopyToClipboard_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.E)
            {
                hideLicenseControls();
                this.txtPassword.Visible = true;
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
            {
                hideLicenseControls();
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.txtPassword.Text == "*s2eng_" + DateTime.Now.ToString("HH"))
                this.btnLoadLicense.Visible = true;
            else
                this.btnLoadLicense.Visible = false;
        }

        private void hideLicenseControls()
        {
            this.txtPassword.Visible = false;
            this.btnLoadLicense.Visible = false;
            this.txtPassword.Text = "";
            this.txtKlartext.Text = "";
            this.txtVerschluesselterText.Text = "";
        }
    }
}
