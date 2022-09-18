using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;




namespace qs2.ui
{


    public partial class frmChangePwd : Form
    {

        public bool abort = true;
        public qs2.license.core.Encryption Encryption1 = new qs2.license.core.Encryption();
        public qs2.design.auto.workflowAssist.autoForm.AutoControlsUI AutoControlsUI1 = new design.auto.workflowAssist.autoForm.AutoControlsUI();




        public frmChangePwd()
        {
            InitializeComponent();
        }

        private void frmChangePwd_Load(object sender, EventArgs e)
        {
        }

        public void initControl()
        {
            try
            {
                this.AcceptButton = this.btnOk;
                this.CancelButton = this.btnAbort;

                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.ePicture.ico_lock, 32, 32);
                this.Text = qs2.core.language.sqlLanguage.getRes("ChangePassword");

                this.btnOk.Text = qs2.core.language.sqlLanguage.getRes("OK");

                this.loadData();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void loadData()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception("frmChangePwd.loadData: " + ex.ToString());
            }
        }

        public bool validateData()
        {
            try
            {
                this.errorProvider1.SetError(this.txtOldPwd, "");
                this.errorProvider1.SetError(this.txtNewPwd, "");
                this.errorProvider1.SetError(this.txtNewPwd2, "");

                if (this.txtOldPwd.Text.Trim() == "")
                {
                    this.errorProvider1.SetError(this.txtOldPwd, qs2.core.generic.incorrSel);
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("PasswordCheck"), MessageBoxButtons.OK, "");
                    this.txtOldPwd.Focus();
                    return false;
                }
                else if (this.txtNewPwd.Text.Trim() == "")
                {
                    this.errorProvider1.SetError(this.txtNewPwd, qs2.core.generic.incorrSel);
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("PasswordCheck"), MessageBoxButtons.OK, "");
                    this.txtNewPwd.Focus();
                    return false;
                }

                qs2.core.vb.dsObjects dsObjectsCheck = new qs2.core.vb.dsObjects();
                string PasswordDBDecrypted = (qs2.core.vb.actUsr.rUsr.Password.Trim() == "" ? "" : this.Encryption1.StringDecrypt(qs2.core.vb.actUsr.rUsr.Password.Trim(), qs2.license.core.Encryption.keyForEncryptingStrings));
                if (this.txtOldPwd.Text.Trim() != PasswordDBDecrypted)
                {
                    this.errorProvider1.SetError(this.txtOldPwd, qs2.core.generic.incorrSel);
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("PasswordWrong") + "!", MessageBoxButtons.OK, "");
                    this.txtOldPwd.Focus();
                    return false;
                }
                else if (this.txtNewPwd.Text.Trim() != this.txtNewPwd2.Text.Trim())
                {
                    this.errorProvider1.SetError(this.txtNewPwd, qs2.core.generic.incorrSel);
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("RepeatPasswordNotTheSame") + "!", MessageBoxButtons.OK, "");
                    this.txtNewPwd.Focus();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("frmChangePwd.saveData: " + ex.ToString());
                //return false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.validateData())
                {
                    string PwdDecrypted = this.Encryption1.StringEncrypt(this.txtNewPwd.Text.Trim() , qs2.license.core.Encryption.keyForEncryptingStrings);
                    qs2.core.vb.sqlObjects sqlObjectsUpdate = new qs2.core.vb.sqlObjects();
                    sqlObjectsUpdate.initControl();
                    sqlObjectsUpdate.UpdatePwd(qs2.core.vb.actUsr.rUsr.IDGuid, PwdDecrypted.Trim());
                    qs2.core.vb.actUsr.rUsr.Password = PwdDecrypted;
                    this.abort = false;
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("DataSaved") + "!", MessageBoxButtons.OK, "");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.Close();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void txtOldPwd_Enter(object sender, EventArgs e)
        {
            this.txtOldPwd.SelectAll();
        }
        private void txtNewPwd_Enter(object sender, EventArgs e)
        {
            this.txtNewPwd.SelectAll();
        }
        private void txtNewPwd2_Enter(object sender, EventArgs e)
        {
            this.txtNewPwd2.SelectAll();
        }

        private void frmChangePwd_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                }

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        private void txtOldPwd_KeyDown(object sender, KeyEventArgs e)
        {
            qs2.core.generic.TogglePassword(sender);
        }

        private void txtNewPwd_KeyDown(object sender, KeyEventArgs e)
        {
            qs2.core.generic.TogglePassword(sender);
        }

        private void txtNewPwd2_KeyDown(object sender, KeyEventArgs e)
        {
            qs2.core.generic.TogglePassword(sender);
        }
    }
}
