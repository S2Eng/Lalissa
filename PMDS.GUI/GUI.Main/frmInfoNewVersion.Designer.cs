namespace PMDS.GUI.GUI.Main
{
    partial class frmInfoNewVersion
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
            this.txtInfo = new Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor();
            this.btnClose = new Infragistics.Win.Misc.UltraButton();
            this.SuspendLayout();
            // 
            // txtInfo
            // 
            this.txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColorDisabled = System.Drawing.Color.White;
            appearance1.BorderColor = System.Drawing.Color.White;
            appearance1.BorderColor2 = System.Drawing.Color.White;
            appearance1.FontData.SizeInPoints = 12F;
            appearance1.TextHAlignAsString = "Center";
            this.txtInfo.Appearance = appearance1;
            this.txtInfo.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.txtInfo.Location = new System.Drawing.Point(12, 16);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(349, 52);
            this.txtInfo.TabIndex = 0;
            this.txtInfo.Value = "Eine neuere PMDS Version steht bereit.<br/>Bitte beenden Sie PMDS und starten Sie" +
    " neu.";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnClose.Appearance = appearance2;
            this.btnClose.Location = new System.Drawing.Point(329, 66);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 27);
            this.btnClose.TabIndex = 1;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmInfoNewVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(373, 98);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInfoNewVersion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PMDS - Hinweis Update";
            this.Load += new System.EventHandler(this.frmInfoNewVersion_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor txtInfo;
        private Infragistics.Win.Misc.UltraButton btnClose;
    }
}