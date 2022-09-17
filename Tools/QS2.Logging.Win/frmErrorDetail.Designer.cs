namespace QS2.Logging.Win
{
    partial class frmErrorDetail
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmErrorDetail));
            this.txtTime = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblTime = new Infragistics.Win.Misc.UltraLabel();
            this.txtMachineName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblMachineName = new Infragistics.Win.Misc.UltraLabel();
            this.txtUser = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblUser = new Infragistics.Win.Misc.UltraLabel();
            this.txtText = new Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor();
            this.lblText = new Infragistics.Win.Misc.UltraLabel();
            this.btnClose = new Infragistics.Win.Misc.UltraButton();
            this.txtType = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblType = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMachineName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtType)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTime
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColorDisabled = System.Drawing.Color.White;
            appearance1.BackColorDisabled2 = System.Drawing.Color.White;
            this.txtTime.Appearance = appearance1;
            this.txtTime.BackColor = System.Drawing.Color.White;
            this.txtTime.Location = new System.Drawing.Point(123, 16);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(166, 21);
            this.txtTime.TabIndex = 0;
            this.txtTime.UseAppStyling = false;
            // 
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(23, 19);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(117, 15);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "Time:";
            // 
            // txtMachineName
            // 
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BackColorDisabled = System.Drawing.Color.White;
            appearance2.BackColorDisabled2 = System.Drawing.Color.White;
            this.txtMachineName.Appearance = appearance2;
            this.txtMachineName.BackColor = System.Drawing.Color.White;
            this.txtMachineName.Location = new System.Drawing.Point(123, 41);
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.ReadOnly = true;
            this.txtMachineName.Size = new System.Drawing.Size(320, 21);
            this.txtMachineName.TabIndex = 2;
            this.txtMachineName.UseAppStyling = false;
            // 
            // lblMachineName
            // 
            this.lblMachineName.Location = new System.Drawing.Point(23, 44);
            this.lblMachineName.Name = "lblMachineName";
            this.lblMachineName.Size = new System.Drawing.Size(117, 15);
            this.lblMachineName.TabIndex = 3;
            this.lblMachineName.Text = "Maschine-Name";
            // 
            // txtUser
            // 
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BackColorDisabled = System.Drawing.Color.White;
            appearance3.BackColorDisabled2 = System.Drawing.Color.White;
            this.txtUser.Appearance = appearance3;
            this.txtUser.BackColor = System.Drawing.Color.White;
            this.txtUser.Location = new System.Drawing.Point(123, 66);
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(320, 21);
            this.txtUser.TabIndex = 4;
            this.txtUser.UseAppStyling = false;
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(23, 69);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(117, 15);
            this.lblUser.TabIndex = 5;
            this.lblUser.Text = "User:";
            // 
            // txtText
            // 
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BackColor = System.Drawing.Color.White;
            appearance4.BackColorDisabled = System.Drawing.Color.White;
            appearance4.BackColorDisabled2 = System.Drawing.Color.White;
            this.txtText.Appearance = appearance4;
            this.txtText.Location = new System.Drawing.Point(123, 91);
            this.txtText.Name = "txtText";
            this.txtText.ReadOnly = true;
            this.txtText.Size = new System.Drawing.Size(902, 522);
            this.txtText.TabIndex = 6;
            this.txtText.UseAppStyling = false;
            this.txtText.Value = "";
            // 
            // lblText
            // 
            this.lblText.Location = new System.Drawing.Point(23, 91);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(117, 15);
            this.lblText.TabIndex = 7;
            this.lblText.Text = "Text:";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(968, 618);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtType
            // 
            this.txtType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtType.Enabled = false;
            this.txtType.Location = new System.Drawing.Point(123, 619);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(166, 21);
            this.txtType.TabIndex = 9;
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(23, 622);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(117, 15);
            this.lblType.TabIndex = 10;
            this.lblType.Text = "Type:";
            // 
            // frmErrorDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 646);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtMachineName);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblMachineName);
            this.Controls.Add(this.lblTime);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmErrorDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Log Detail";
            this.Load += new System.EventHandler(this.frmErrorDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMachineName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Infragistics.Win.Misc.UltraLabel lblTime;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor txtTime;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor txtMachineName;
        private Infragistics.Win.Misc.UltraLabel lblMachineName;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor txtUser;
        private Infragistics.Win.Misc.UltraLabel lblUser;
        private Infragistics.Win.Misc.UltraLabel lblText;
        public Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor txtText;
        private Infragistics.Win.Misc.UltraButton btnClose;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor txtType;
        private Infragistics.Win.Misc.UltraLabel lblType;
    }
}