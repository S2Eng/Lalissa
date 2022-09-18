using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using qs2.core.vb;
using QS2.Resources;




namespace qs2.ui
{
    public partial class frmSys : Form 
    {

        public string key = "";
        public byte[] byt;

        public qs2.core.language.sqlLanguage sqlLanguage1 = new qs2.core.language.sqlLanguage();
        public qs2.design.auto.workflowAssist.autoForm.AutoControlsUI AutoControlsUI1 = new design.auto.workflowAssist.autoForm.AutoControlsUI();





        public frmSys()
        {
            InitializeComponent();
        }

        private void frmSys_Load(object sender, EventArgs e)
        {
            this.Icon = getRes.getIcon(QS2.Resources.getRes.ePicture.ico_sys, 32, 32);
            this.loadRes();
        }

        public void loadRes()
        {
            this.btnLoadAllAD2.initControl();
            this.btnValidUserAD.initControl();

            this.Text = qs2.core.language.sqlLanguage.getRes("QS2Sys");
            this.btnLoadAllAD2.Text = qs2.core.language.sqlLanguage.getRes("ReadAll");
            this.gridActiveDirextory.Text = qs2.core.language.sqlLanguage.getRes("ActiveDirectory");
            this.chkUserAcitveDirectory.Text = qs2.core.language.sqlLanguage.getRes("CheckUserInActiveDirectory");
            this.btnValidUserAD.Text = qs2.core.language.sqlLanguage.getRes("Check");
            this.lblUser.Text = qs2.core.language.sqlLanguage.getRes("User");
            this.lblPassword.Text = qs2.core.language.sqlLanguage.getRes("Password");
            this.chkWithPwd.Text = qs2.core.language.sqlLanguage.getRes("WithPassword");

            this.ultraTabControlSys.Tabs[0].Text = qs2.core.language.sqlLanguage.getRes("ActiveDirectory");
            this.ultraTabControlSys.Tabs[1].Text = qs2.core.language.sqlLanguage.getRes("Others");
        }
   
        private void btnValidUserAD_Click(object sender, EventArgs e)
        {
            bool ok = false;
            qs2.core.vb.actUsr actUsr1 = new qs2.core.vb.actUsr();
            if (this.chkWithPwd.Checked)
            {
                ok = actUsr1.ValidateActiveDirectoryLogin(this.txtUsr.Text.Trim(), this.txtPwd.Text);
            }
            else
            {
                ok = actUsr1.checkUserIsInActiveDirectory(this.txtUsr.Text.Trim());
            }
            qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("UserExists") + ": " + ok.ToString (), MessageBoxButtons.OK, "");
        }

        private void btnLoadAllAD2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                qs2.core.vb.actUsr actUsr1 = new qs2.core.vb.actUsr();
                System.Collections.ArrayList res = actUsr1.getAllUsersActiveDirectory("");
                this.gridActiveDirextory.DataSource = res;
                this.gridActiveDirextory.DataBind();
                this.gridActiveDirextory.Text = qs2.core.language.sqlLanguage.getRes("ActiveDirectory") + " (" + res.Count.ToString() + ")";
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

        private void frmSys_VisibleChanged(object sender, EventArgs e)
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

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            qs2.core.generic.TogglePassword(sender);
        }
    }
}
