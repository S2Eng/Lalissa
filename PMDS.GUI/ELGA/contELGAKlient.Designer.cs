﻿namespace PMDS.GUI.ELGA
{
    partial class contELGAKlient
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ultraTextEditor1 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnDoKontaktbestätigung = new QS2.Desktop.ControlManagment.BaseButton();
            this.grpKontaktbestätigung = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnKoontaktbestätigungStorno = new QS2.Desktop.ControlManagment.BaseButton();
            this.chkRechteBelehrt = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.grpSOO = new Infragistics.Win.Misc.UltraGroupBox();
            this.chkZustimmungSOO = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.btnSetSOO = new QS2.Desktop.ControlManagment.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpKontaktbestätigung)).BeginInit();
            this.grpKontaktbestätigung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkRechteBelehrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSOO)).BeginInit();
            this.grpSOO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkZustimmungSOO)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ultraTextEditor1
            // 
            this.ultraTextEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BackColor = System.Drawing.Color.White;
            this.ultraTextEditor1.Appearance = appearance4;
            this.ultraTextEditor1.BackColor = System.Drawing.Color.White;
            this.ultraTextEditor1.Location = new System.Drawing.Point(9, 19);
            this.ultraTextEditor1.Multiline = true;
            this.ultraTextEditor1.Name = "ultraTextEditor1";
            this.ultraTextEditor1.ReadOnly = true;
            this.ultraTextEditor1.Size = new System.Drawing.Size(706, 33);
            this.ultraTextEditor1.TabIndex = 0;
            // 
            // btnDoKontaktbestätigung
            // 
            this.btnDoKontaktbestätigung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDoKontaktbestätigung.Appearance = appearance3;
            this.btnDoKontaktbestätigung.AutoWorkLayout = false;
            this.btnDoKontaktbestätigung.IsStandardControl = false;
            this.btnDoKontaktbestätigung.Location = new System.Drawing.Point(9, 55);
            this.btnDoKontaktbestätigung.Margin = new System.Windows.Forms.Padding(4);
            this.btnDoKontaktbestätigung.Name = "btnDoKontaktbestätigung";
            this.btnDoKontaktbestätigung.Size = new System.Drawing.Size(131, 27);
            this.btnDoKontaktbestätigung.TabIndex = 125;
            this.btnDoKontaktbestätigung.Tag = "";
            this.btnDoKontaktbestätigung.Text = "Kontaktbestätigung";
            this.btnDoKontaktbestätigung.Click += new System.EventHandler(this.BtnDoKontaktbestätigung_Click);
            // 
            // grpKontaktbestätigung
            // 
            this.grpKontaktbestätigung.Controls.Add(this.btnKoontaktbestätigungStorno);
            this.grpKontaktbestätigung.Controls.Add(this.btnDoKontaktbestätigung);
            this.grpKontaktbestätigung.Controls.Add(this.ultraTextEditor1);
            this.grpKontaktbestätigung.Location = new System.Drawing.Point(8, 10);
            this.grpKontaktbestätigung.Name = "grpKontaktbestätigung";
            this.grpKontaktbestätigung.Size = new System.Drawing.Size(724, 88);
            this.grpKontaktbestätigung.TabIndex = 126;
            this.grpKontaktbestätigung.Text = "Kontaktbestätigung";
            // 
            // btnKoontaktbestätigungStorno
            // 
            this.btnKoontaktbestätigungStorno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnKoontaktbestätigungStorno.Appearance = appearance2;
            this.btnKoontaktbestätigungStorno.AutoWorkLayout = false;
            this.btnKoontaktbestätigungStorno.IsStandardControl = false;
            this.btnKoontaktbestätigungStorno.Location = new System.Drawing.Point(140, 55);
            this.btnKoontaktbestätigungStorno.Margin = new System.Windows.Forms.Padding(4);
            this.btnKoontaktbestätigungStorno.Name = "btnKoontaktbestätigungStorno";
            this.btnKoontaktbestätigungStorno.Size = new System.Drawing.Size(59, 27);
            this.btnKoontaktbestätigungStorno.TabIndex = 126;
            this.btnKoontaktbestätigungStorno.Tag = "";
            this.btnKoontaktbestätigungStorno.Text = "Storno";
            this.btnKoontaktbestätigungStorno.Click += new System.EventHandler(this.BtnKoontaktbestätigungStorno_Click);
            // 
            // chkRechteBelehrt
            // 
            this.chkRechteBelehrt.Location = new System.Drawing.Point(14, 21);
            this.chkRechteBelehrt.Name = "chkRechteBelehrt";
            this.chkRechteBelehrt.Size = new System.Drawing.Size(284, 16);
            this.chkRechteBelehrt.TabIndex = 127;
            this.chkRechteBelehrt.Text = "Patient wurde über seine Rechte belehrt";
            // 
            // grpSOO
            // 
            this.grpSOO.Controls.Add(this.btnSetSOO);
            this.grpSOO.Controls.Add(this.chkZustimmungSOO);
            this.grpSOO.Controls.Add(this.chkRechteBelehrt);
            this.grpSOO.Location = new System.Drawing.Point(8, 103);
            this.grpSOO.Name = "grpSOO";
            this.grpSOO.Size = new System.Drawing.Size(724, 94);
            this.grpSOO.TabIndex = 128;
            this.grpSOO.Text = "Situatives Opt-Out";
            // 
            // chkZustimmungSOO
            // 
            this.chkZustimmungSOO.Location = new System.Drawing.Point(14, 39);
            this.chkZustimmungSOO.Name = "chkZustimmungSOO";
            this.chkZustimmungSOO.Size = new System.Drawing.Size(284, 16);
            this.chkZustimmungSOO.TabIndex = 128;
            this.chkZustimmungSOO.Text = "Patient stimmt dem situativem Opt-Out zu";
            // 
            // btnSetSOO
            // 
            this.btnSetSOO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSetSOO.Appearance = appearance1;
            this.btnSetSOO.AutoWorkLayout = false;
            this.btnSetSOO.IsStandardControl = false;
            this.btnSetSOO.Location = new System.Drawing.Point(14, 61);
            this.btnSetSOO.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetSOO.Name = "btnSetSOO";
            this.btnSetSOO.Size = new System.Drawing.Size(153, 27);
            this.btnSetSOO.TabIndex = 129;
            this.btnSetSOO.Tag = "";
            this.btnSetSOO.Text = "Situatives Opt-Out setzen";
            this.btnSetSOO.Click += new System.EventHandler(this.BtnSetSOO_Click);
            // 
            // contELGAKlient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.grpSOO);
            this.Controls.Add(this.grpKontaktbestätigung);
            this.Name = "contELGAKlient";
            this.Size = new System.Drawing.Size(740, 424);
            this.Load += new System.EventHandler(this.contELGAKlient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpKontaktbestätigung)).EndInit();
            this.grpKontaktbestätigung.ResumeLayout(false);
            this.grpKontaktbestätigung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkRechteBelehrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSOO)).EndInit();
            this.grpSOO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkZustimmungSOO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor1;
        public QS2.Desktop.ControlManagment.BaseButton btnDoKontaktbestätigung;
        private Infragistics.Win.Misc.UltraGroupBox grpKontaktbestätigung;
        public QS2.Desktop.ControlManagment.BaseButton btnKoontaktbestätigungStorno;
        private Infragistics.Win.Misc.UltraGroupBox grpSOO;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkZustimmungSOO;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkRechteBelehrt;
        public QS2.Desktop.ControlManagment.BaseButton btnSetSOO;
    }
}
