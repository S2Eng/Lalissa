namespace PMDS.GUI.ELGA.ManageSettings
{
    partial class contELGASettings
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.txtELGAPwd = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblELGAPwd = new Infragistics.Win.Misc.UltraLabel();
            this.txtELGAUser = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblELGAUser = new Infragistics.Win.Misc.UltraLabel();
            this.chkELGAAutostartSession = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtELGAPwdWdhlg = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblELGAPwdWdhlg = new Infragistics.Win.Misc.UltraLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtELGAPwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtELGAUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkELGAAutostartSession)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtELGAPwdWdhlg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtELGAPwd
            // 
            this.txtELGAPwd.Location = new System.Drawing.Point(146, 41);
            this.txtELGAPwd.Name = "txtELGAPwd";
            this.txtELGAPwd.PasswordChar = '*';
            this.txtELGAPwd.Size = new System.Drawing.Size(197, 21);
            this.txtELGAPwd.TabIndex = 1;
            this.txtELGAPwd.ValueChanged += new System.EventHandler(this.TxtELGAPwd_ValueChanged);
            this.txtELGAPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtELGAPwd_KeyDown);
            // 
            // lblELGAPwd
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.lblELGAPwd.Appearance = appearance4;
            this.lblELGAPwd.Location = new System.Drawing.Point(21, 42);
            this.lblELGAPwd.Name = "lblELGAPwd";
            this.lblELGAPwd.Size = new System.Drawing.Size(95, 18);
            this.lblELGAPwd.TabIndex = 1;
            this.lblELGAPwd.Text = "Passwort";
            // 
            // txtELGAUser
            // 
            this.txtELGAUser.Location = new System.Drawing.Point(146, 17);
            this.txtELGAUser.Name = "txtELGAUser";
            this.txtELGAUser.Size = new System.Drawing.Size(197, 21);
            this.txtELGAUser.TabIndex = 0;
            this.txtELGAUser.ValueChanged += new System.EventHandler(this.TxtELGAUser_ValueChanged);
            // 
            // lblELGAUser
            // 
            appearance5.TextVAlignAsString = "Middle";
            this.lblELGAUser.Appearance = appearance5;
            this.lblELGAUser.Location = new System.Drawing.Point(21, 18);
            this.lblELGAUser.Name = "lblELGAUser";
            this.lblELGAUser.Size = new System.Drawing.Size(95, 18);
            this.lblELGAUser.TabIndex = 3;
            this.lblELGAUser.Text = "Benutzer";
            // 
            // chkELGAAutostartSession
            // 
            this.chkELGAAutostartSession.Location = new System.Drawing.Point(146, 92);
            this.chkELGAAutostartSession.Name = "chkELGAAutostartSession";
            this.chkELGAAutostartSession.Size = new System.Drawing.Size(155, 21);
            this.chkELGAAutostartSession.TabIndex = 4;
            this.chkELGAAutostartSession.Text = "Autostart";
            this.chkELGAAutostartSession.CheckedChanged += new System.EventHandler(this.ChkELGAAutostartSession_CheckedChanged);
            // 
            // txtELGAPwdWdhlg
            // 
            this.txtELGAPwdWdhlg.Location = new System.Drawing.Point(146, 65);
            this.txtELGAPwdWdhlg.Name = "txtELGAPwdWdhlg";
            this.txtELGAPwdWdhlg.PasswordChar = '*';
            this.txtELGAPwdWdhlg.Size = new System.Drawing.Size(197, 21);
            this.txtELGAPwdWdhlg.TabIndex = 2;
            this.txtELGAPwdWdhlg.ValueChanged += new System.EventHandler(this.TxtELGAPwdWdhlg_ValueChanged);
            this.txtELGAPwdWdhlg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtELGAPwdWdhlg_KeyDown);
            // 
            // lblELGAPwdWdhlg
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.lblELGAPwdWdhlg.Appearance = appearance6;
            this.lblELGAPwdWdhlg.Location = new System.Drawing.Point(21, 66);
            this.lblELGAPwdWdhlg.Name = "lblELGAPwdWdhlg";
            this.lblELGAPwdWdhlg.Size = new System.Drawing.Size(124, 18);
            this.lblELGAPwdWdhlg.TabIndex = 5;
            this.lblELGAPwdWdhlg.Text = "Passwort Wiederholung";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // contELGASettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtELGAPwdWdhlg);
            this.Controls.Add(this.lblELGAPwdWdhlg);
            this.Controls.Add(this.txtELGAUser);
            this.Controls.Add(this.txtELGAPwd);
            this.Controls.Add(this.chkELGAAutostartSession);
            this.Controls.Add(this.lblELGAUser);
            this.Controls.Add(this.lblELGAPwd);
            this.Name = "contELGASettings";
            this.Size = new System.Drawing.Size(579, 479);
            this.Load += new System.EventHandler(this.ContELGASettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtELGAPwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtELGAUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkELGAAutostartSession)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtELGAPwdWdhlg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Infragistics.Win.UltraWinEditors.UltraTextEditor txtELGAPwd;
        public Infragistics.Win.Misc.UltraLabel lblELGAPwd;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor txtELGAUser;
        public Infragistics.Win.Misc.UltraLabel lblELGAUser;
        public Infragistics.Win.UltraWinEditors.UltraCheckEditor chkELGAAutostartSession;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor txtELGAPwdWdhlg;
        public Infragistics.Win.Misc.UltraLabel lblELGAPwdWdhlg;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
    }
}
