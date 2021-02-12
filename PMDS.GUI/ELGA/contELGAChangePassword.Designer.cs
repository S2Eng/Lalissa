namespace PMDS.GUI.ELGA
{
    partial class contELGAChangePassword
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
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            this.txtELGAPwdOld = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblELGAPwdOld = new Infragistics.Win.Misc.UltraLabel();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnSave = new QS2.Desktop.ControlManagment.BaseButton();
            this.txtELGAPwdNew = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblELGAPwdNew = new Infragistics.Win.Misc.UltraLabel();
            this.txtELGAPwdNewWdhlg = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblELGAPwdNewWdhlg = new Infragistics.Win.Misc.UltraLabel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtELGAPwdOld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtELGAPwdNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtELGAPwdNewWdhlg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtELGAPwdOld
            // 
            this.txtELGAPwdOld.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.White;
            this.txtELGAPwdOld.Appearance = appearance1;
            this.txtELGAPwdOld.BackColor = System.Drawing.Color.White;
            this.txtELGAPwdOld.Location = new System.Drawing.Point(141, 14);
            this.txtELGAPwdOld.Name = "txtELGAPwdOld";
            this.txtELGAPwdOld.PasswordChar = '*';
            this.txtELGAPwdOld.Size = new System.Drawing.Size(268, 21);
            this.txtELGAPwdOld.TabIndex = 0;
            // 
            // lblELGAPwdOld
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.lblELGAPwdOld.Appearance = appearance2;
            this.lblELGAPwdOld.Location = new System.Drawing.Point(17, 16);
            this.lblELGAPwdOld.Name = "lblELGAPwdOld";
            this.lblELGAPwdOld.Size = new System.Drawing.Size(113, 16);
            this.lblELGAPwdOld.TabIndex = 125;
            this.lblELGAPwdOld.Text = "Altes Passwort:";
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbort.Appearance = appearance3;
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(141, 96);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(85, 28);
            this.btnAbort.TabIndex = 122;
            this.btnAbort.Tag = "";
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.Click += new System.EventHandler(this.BtnAbort_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance4;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.IsStandardControl = false;
            this.btnSave.Location = new System.Drawing.Point(226, 96);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 28);
            this.btnSave.TabIndex = 123;
            this.btnSave.Tag = "";
            this.btnSave.Text = "Speichern";
            this.btnSave.Click += new System.EventHandler(this.BtnELGALogIn_Click);
            // 
            // txtELGAPwdNew
            // 
            this.txtELGAPwdNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance5.BackColor = System.Drawing.Color.White;
            this.txtELGAPwdNew.Appearance = appearance5;
            this.txtELGAPwdNew.BackColor = System.Drawing.Color.White;
            this.txtELGAPwdNew.Location = new System.Drawing.Point(141, 39);
            this.txtELGAPwdNew.Name = "txtELGAPwdNew";
            this.txtELGAPwdNew.PasswordChar = '*';
            this.txtELGAPwdNew.Size = new System.Drawing.Size(268, 21);
            this.txtELGAPwdNew.TabIndex = 1;
            this.txtELGAPwdNew.ValueChanged += new System.EventHandler(this.txtELGAPwdNew_ValueChanged);
            // 
            // lblELGAPwdNew
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.lblELGAPwdNew.Appearance = appearance6;
            this.lblELGAPwdNew.Location = new System.Drawing.Point(17, 41);
            this.lblELGAPwdNew.Name = "lblELGAPwdNew";
            this.lblELGAPwdNew.Size = new System.Drawing.Size(113, 16);
            this.lblELGAPwdNew.TabIndex = 127;
            this.lblELGAPwdNew.Text = "Neues Passwort:";
            // 
            // txtELGAPwdNewWdhlg
            // 
            this.txtELGAPwdNewWdhlg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance7.BackColor = System.Drawing.Color.White;
            this.txtELGAPwdNewWdhlg.Appearance = appearance7;
            this.txtELGAPwdNewWdhlg.BackColor = System.Drawing.Color.White;
            this.txtELGAPwdNewWdhlg.Location = new System.Drawing.Point(141, 62);
            this.txtELGAPwdNewWdhlg.Name = "txtELGAPwdNewWdhlg";
            this.txtELGAPwdNewWdhlg.PasswordChar = '*';
            this.txtELGAPwdNewWdhlg.Size = new System.Drawing.Size(268, 21);
            this.txtELGAPwdNewWdhlg.TabIndex = 2;
            this.txtELGAPwdNewWdhlg.ValueChanged += new System.EventHandler(this.txtELGAPwdNewWdhlg_ValueChanged);
            // 
            // lblELGAPwdNewWdhlg
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.lblELGAPwdNewWdhlg.Appearance = appearance8;
            this.lblELGAPwdNewWdhlg.Location = new System.Drawing.Point(17, 64);
            this.lblELGAPwdNewWdhlg.Name = "lblELGAPwdNewWdhlg";
            this.lblELGAPwdNewWdhlg.Size = new System.Drawing.Size(127, 16);
            this.lblELGAPwdNewWdhlg.TabIndex = 129;
            this.lblELGAPwdNewWdhlg.Text = "Neues Passwort Wdhlg:";
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // contELGAChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtELGAPwdNewWdhlg);
            this.Controls.Add(this.lblELGAPwdNewWdhlg);
            this.Controls.Add(this.txtELGAPwdNew);
            this.Controls.Add(this.lblELGAPwdNew);
            this.Controls.Add(this.txtELGAPwdOld);
            this.Controls.Add(this.lblELGAPwdOld);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnSave);
            this.Name = "contELGAChangePassword";
            this.Size = new System.Drawing.Size(423, 132);
            this.Load += new System.EventHandler(this.ContELGAChangePassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtELGAPwdOld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtELGAPwdNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtELGAPwdNewWdhlg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtELGAPwdOld;
        private Infragistics.Win.Misc.UltraLabel lblELGAPwdOld;
        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
        public QS2.Desktop.ControlManagment.BaseButton btnSave;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtELGAPwdNew;
        private Infragistics.Win.Misc.UltraLabel lblELGAPwdNew;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtELGAPwdNewWdhlg;
        private Infragistics.Win.Misc.UltraLabel lblELGAPwdNewWdhlg;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
