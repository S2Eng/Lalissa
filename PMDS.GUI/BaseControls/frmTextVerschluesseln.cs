using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using PMDS.db.Entities;

namespace PMDS.GUI.BaseControls
{
    public partial class frmTextVerschluesseln : Form
    {

        private bool _bPrepareDBLizenz = false;

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
            _bPrepareDBLizenz = false;
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
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.L)
            {

                _bPrepareDBLizenz = true;
                this.txtPassword.Visible = true;
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.txtPassword.Text == "*s2eng_" + DateTime.Now.ToString("HH"))
            {
                if (_bPrepareDBLizenz)
                {
                    //Lizenzstring in DBLizenz schreiben
                    _bPrepareDBLizenz = false;
                    DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Neuen Lizenzstring in die Datenbank schreiben?", "Sind Sie sicher?", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                        {
                            PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                            if (PMDSBusiness1.UpdateDBLizenz(this.txtKlartext.Text, db))
                            {
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Neuer Lizenzstring wurde in die Datenbank geschrieben", "Hinweis", MessageBoxButtons.OK);
                            }
                            else
                            {
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Neuer Lizenzstring wurde NICHT in die Datenbank geschrieben", "Hinweis", MessageBoxButtons.OK);
                            }
                        }
                    }
                    hideLicenseControls();
                }
                else
                {
                    pnlControls.Visible = true;
                }
            }
            else
            {
                pnlControls.Visible = false;
            }
        }

        private void hideLicenseControls()
        {
            this.txtPassword.Visible = false;
            pnlControls.Visible = false;
            this.txtPassword.Text = "";
            this.txtKlartext.Text = "";
            this.txtVerschluesselterText.Text = "";
        }

        private void DtValidThrough_ValueChanged(object sender, EventArgs e)
        {

        }

        private void BaseLabel1_Click(object sender, EventArgs e)
        {

        }

        private void DtValidThrough_Leave(object sender, EventArgs e)
        {
            this.hideLicenseControls();
            this.txtKlartext.Text = PMDS.Global.ENV.MakeLicenseString(this.dtValidThrough.DateTime);
            this.txtVerschluesselterText.Text = PMDS.BusinessLogic.BUtil.EncryptString(this.txtKlartext.Text);
            _bPrepareDBLizenz = true;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            PMDS.Global.generic.TogglePassword(sender);
        }
    }
}
