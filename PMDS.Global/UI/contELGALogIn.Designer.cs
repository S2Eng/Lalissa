﻿namespace PMDS.GUI.ELGA
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
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnELGALogIn = new QS2.Desktop.ControlManagment.BaseButton();
            this.txtELGAUser = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblELGAUser = new Infragistics.Win.Misc.UltraLabel();
            this.txtELGAPwd = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblELGAPwd = new Infragistics.Win.Misc.UltraLabel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
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
            this.btnAbort.Location = new System.Drawing.Point(110, 75);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(85, 28);
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
            this.btnELGALogIn.Location = new System.Drawing.Point(196, 75);
            this.btnELGALogIn.Margin = new System.Windows.Forms.Padding(4);
            this.btnELGALogIn.Name = "btnELGALogIn";
            this.btnELGALogIn.Size = new System.Drawing.Size(93, 28);
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
            this.txtELGAUser.Location = new System.Drawing.Point(110, 14);
            this.txtELGAUser.Name = "txtELGAUser";
            this.txtELGAUser.Size = new System.Drawing.Size(265, 21);
            this.txtELGAUser.TabIndex = 0;
            // 
            // lblELGAUser
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.lblELGAUser.Appearance = appearance4;
            this.lblELGAUser.Location = new System.Drawing.Point(19, 16);
            this.lblELGAUser.Name = "lblELGAUser";
            this.lblELGAUser.Size = new System.Drawing.Size(113, 16);
            this.lblELGAUser.TabIndex = 117;
            this.lblELGAUser.Text = "ELGA-Benutzer:";
            // 
            // txtELGAPwd
            // 
            appearance5.BackColor = System.Drawing.Color.White;
            this.txtELGAPwd.Appearance = appearance5;
            this.txtELGAPwd.BackColor = System.Drawing.Color.White;
            this.txtELGAPwd.Location = new System.Drawing.Point(110, 37);
            this.txtELGAPwd.Name = "txtELGAPwd";
            this.txtELGAPwd.PasswordChar = '*';
            this.txtELGAPwd.Size = new System.Drawing.Size(265, 21);
            this.txtELGAPwd.TabIndex = 1;
            // 
            // lblELGAPwd
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.lblELGAPwd.Appearance = appearance6;
            this.lblELGAPwd.Location = new System.Drawing.Point(19, 39);
            this.lblELGAPwd.Name = "lblELGAPwd";
            this.lblELGAPwd.Size = new System.Drawing.Size(113, 16);
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
            // contELGALogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtELGAPwd);
            this.Controls.Add(this.txtELGAUser);
            this.Controls.Add(this.lblELGAPwd);
            this.Controls.Add(this.lblELGAUser);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnELGALogIn);
            this.Name = "contELGALogIn";
            this.Size = new System.Drawing.Size(385, 108);
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
    }
}