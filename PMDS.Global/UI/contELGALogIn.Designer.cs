namespace PMDS.GUI.ELGA
{
    partial class contELGALogIn
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnELGALogIn = new QS2.Desktop.ControlManagment.BaseButton();
            this.txtELGAUser = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblELGAUser = new Infragistics.Win.Misc.UltraLabel();
            this.txtELGAPwd = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblELGAPwd = new Infragistics.Win.Misc.UltraLabel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblELGAValidDays = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtELGAUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtELGAPwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbort.Appearance = appearance1;
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(229, 99);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(99, 37);
            this.btnAbort.TabIndex = 100;
            this.btnAbort.Tag = "";
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnELGALogIn
            // 
            this.btnELGALogIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnELGALogIn.Appearance = appearance2;
            this.btnELGALogIn.AutoWorkLayout = false;
            this.btnELGALogIn.IsStandardControl = false;
            this.btnELGALogIn.Location = new System.Drawing.Point(329, 99);
            this.btnELGALogIn.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnELGALogIn.Name = "btnELGALogIn";
            this.btnELGALogIn.Size = new System.Drawing.Size(108, 37);
            this.btnELGALogIn.TabIndex = 101;
            this.btnELGALogIn.Tag = "";
            this.btnELGALogIn.Text = "LogIn ELGA";
            this.btnELGALogIn.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtELGAUser
            // 
            appearance3.BackColor = System.Drawing.Color.White;
            this.txtELGAUser.Appearance = appearance3;
            this.txtELGAUser.BackColor = System.Drawing.Color.White;
            this.txtELGAUser.Location = new System.Drawing.Point(128, 18);
            this.txtELGAUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtELGAUser.Name = "txtELGAUser";
            this.txtELGAUser.Size = new System.Drawing.Size(309, 26);
            this.txtELGAUser.TabIndex = 0;
            // 
            // lblELGAUser
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.lblELGAUser.Appearance = appearance4;
            this.lblELGAUser.Location = new System.Drawing.Point(22, 21);
            this.lblELGAUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblELGAUser.Name = "lblELGAUser";
            this.lblELGAUser.Size = new System.Drawing.Size(132, 21);
            this.lblELGAUser.TabIndex = 117;
            this.lblELGAUser.Text = "ELGA-Benutzer:";
            // 
            // txtELGAPwd
            // 
            appearance5.BackColor = System.Drawing.Color.White;
            this.txtELGAPwd.Appearance = appearance5;
            this.txtELGAPwd.BackColor = System.Drawing.Color.White;
            this.txtELGAPwd.Location = new System.Drawing.Point(128, 48);
            this.txtELGAPwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtELGAPwd.Name = "txtELGAPwd";
            this.txtELGAPwd.PasswordChar = '*';
            this.txtELGAPwd.Size = new System.Drawing.Size(309, 26);
            this.txtELGAPwd.TabIndex = 1;
            this.txtELGAPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtELGAPwd_KeyDown);
            // 
            // lblELGAPwd
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.lblELGAPwd.Appearance = appearance6;
            this.lblELGAPwd.Location = new System.Drawing.Point(22, 51);
            this.lblELGAPwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblELGAPwd.Name = "lblELGAPwd";
            this.lblELGAPwd.Size = new System.Drawing.Size(132, 21);
            this.lblELGAPwd.TabIndex = 119;
            this.lblELGAPwd.Text = "ELGA-Passwort:";
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblELGAValidDays
            // 
            appearance7.TextVAlignAsString = "Middle";
            this.lblELGAValidDays.Appearance = appearance7;
            this.lblELGAValidDays.Location = new System.Drawing.Point(22, 107);
            this.lblELGAValidDays.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblELGAValidDays.Name = "lblELGAValidDays";
            this.lblELGAValidDays.Size = new System.Drawing.Size(187, 21);
            this.lblELGAValidDays.TabIndex = 120;
            this.lblELGAValidDays.Click += new System.EventHandler(this.lblELGAValidDays_Click);
            // 
            // contELGALogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblELGAValidDays);
            this.Controls.Add(this.txtELGAPwd);
            this.Controls.Add(this.txtELGAUser);
            this.Controls.Add(this.lblELGAPwd);
            this.Controls.Add(this.lblELGAUser);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnELGALogIn);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "contELGALogIn";
            this.Size = new System.Drawing.Size(449, 141);
            this.Load += new System.EventHandler(this.contLogIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtELGAUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtELGAPwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
        public QS2.Desktop.ControlManagment.BaseButton btnELGALogIn;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtELGAUser;
        private Infragistics.Win.Misc.UltraLabel lblELGAUser;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtELGAPwd;
        private Infragistics.Win.Misc.UltraLabel lblELGAPwd;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Infragistics.Win.Misc.UltraLabel lblELGAValidDays;
    }
}
