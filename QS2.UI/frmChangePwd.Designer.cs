namespace qs2.ui
{
    partial class frmChangePwd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePwd));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            this.btnAbort = new qs2.sitemap.ownControls.inherit_Infrag.InfragButton();
            this.btnOk = new qs2.sitemap.ownControls.inherit_Infrag.InfragButton();
            this.txtOldPwd = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblOldPassword = new Infragistics.Win.Misc.UltraLabel();
            this.txtNewPwd = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblNewPassword = new Infragistics.Win.Misc.UltraLabel();
            this.txtNewPwd2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblNewPassword2 = new Infragistics.Win.Misc.UltraLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPwd2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance9.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnAbort.Appearance = appearance9;
            this.btnAbort.Location = new System.Drawing.Point(244, 130);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.OwnAutoTextYN = false;
            this.btnAbort.OwnPicture = QS2.Resources.getRes.ePicture.none;
            this.btnAbort.OwnPictureTxt = "";
            this.btnAbort.OwnSizeMode = qs2.core.Enums.eSize.big;
            this.btnAbort.OwnTooltipText = "";
            this.btnAbort.OwnTooltipTitle = null;
            this.btnAbort.Size = new System.Drawing.Size(84, 30);
            this.btnAbort.TabIndex = 11;
            this.btnAbort.Text = "Abort";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance6.Image = ((object)(resources.GetObject("appearance6.Image")));
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnOk.Appearance = appearance6;
            this.btnOk.Location = new System.Drawing.Point(164, 130);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.OwnAutoTextYN = false;
            this.btnOk.OwnPicture = QS2.Resources.getRes.Allgemein.ico_OK;
            this.btnOk.OwnPictureTxt = "";
            this.btnOk.OwnSizeMode = qs2.core.Enums.eSize.big;
            this.btnOk.OwnTooltipText = "";
            this.btnOk.OwnTooltipTitle = null;
            this.btnOk.Size = new System.Drawing.Size(80, 30);
            this.btnOk.TabIndex = 10;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOldPwd.Location = new System.Drawing.Point(144, 22);
            this.txtOldPwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.PasswordChar = '*';
            this.txtOldPwd.Size = new System.Drawing.Size(275, 24);
            this.txtOldPwd.TabIndex = 0;
            this.txtOldPwd.Enter += new System.EventHandler(this.txtOldPwd_Enter);
            this.txtOldPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOldPwd_KeyDown);
            // 
            // lblOldPassword
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            this.lblOldPassword.Appearance = appearance1;
            this.lblOldPassword.Location = new System.Drawing.Point(16, 26);
            this.lblOldPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(135, 17);
            this.lblOldPassword.TabIndex = 8;
            this.lblOldPassword.Text = "Old Password";
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewPwd.Location = new System.Drawing.Point(144, 59);
            this.txtNewPwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.PasswordChar = '*';
            this.txtNewPwd.Size = new System.Drawing.Size(275, 24);
            this.txtNewPwd.TabIndex = 1;
            this.txtNewPwd.Enter += new System.EventHandler(this.txtNewPwd_Enter);
            this.txtNewPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewPwd_KeyDown);
            // 
            // lblNewPassword
            // 
            appearance10.BackColor = System.Drawing.Color.White;
            this.lblNewPassword.Appearance = appearance10;
            this.lblNewPassword.Location = new System.Drawing.Point(16, 63);
            this.lblNewPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(135, 17);
            this.lblNewPassword.TabIndex = 12;
            this.lblNewPassword.Text = "New Password";
            // 
            // txtNewPwd2
            // 
            this.txtNewPwd2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewPwd2.Location = new System.Drawing.Point(144, 87);
            this.txtNewPwd2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNewPwd2.Name = "txtNewPwd2";
            this.txtNewPwd2.PasswordChar = '*';
            this.txtNewPwd2.Size = new System.Drawing.Size(275, 24);
            this.txtNewPwd2.TabIndex = 2;
            this.txtNewPwd2.Enter += new System.EventHandler(this.txtNewPwd2_Enter);
            this.txtNewPwd2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewPwd2_KeyDown);
            // 
            // lblNewPassword2
            // 
            appearance11.BackColor = System.Drawing.Color.White;
            this.lblNewPassword2.Appearance = appearance11;
            this.lblNewPassword2.Location = new System.Drawing.Point(16, 91);
            this.lblNewPassword2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblNewPassword2.Name = "lblNewPassword2";
            this.lblNewPassword2.Size = new System.Drawing.Size(135, 17);
            this.lblNewPassword2.TabIndex = 14;
            this.lblNewPassword2.Text = "New Password";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmChangePwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(435, 167);
            this.Controls.Add(this.txtNewPwd2);
            this.Controls.Add(this.txtNewPwd);
            this.Controls.Add(this.txtOldPwd);
            this.Controls.Add(this.lblNewPassword2);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblOldPassword);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangePwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.frmChangePwd_Load);
            this.VisibleChanged += new System.EventHandler(this.frmChangePwd_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPwd2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private sitemap.ownControls.inherit_Infrag.InfragButton btnAbort;
        private sitemap.ownControls.inherit_Infrag.InfragButton btnOk;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtOldPwd;
        private Infragistics.Win.Misc.UltraLabel lblOldPassword;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtNewPwd;
        private Infragistics.Win.Misc.UltraLabel lblNewPassword;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtNewPwd2;
        private Infragistics.Win.Misc.UltraLabel lblNewPassword2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}