namespace PMDS.GUI.GUI.Main
{
    partial class frmInfoSchnellrueckmeldungOpend
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
            this.btnOK = new Infragistics.Win.Misc.UltraButton();
            this.panelAll = new System.Windows.Forms.Panel();
            this.panelAll.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInfo
            // 
            this.txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.BackColor2 = System.Drawing.Color.Transparent;
            appearance1.BorderColor = System.Drawing.Color.Transparent;
            appearance1.BorderColor2 = System.Drawing.Color.Transparent;
            appearance1.FontData.SizeInPoints = 12F;
            appearance1.TextHAlignAsString = "Center";
            this.txtInfo.Appearance = appearance1;
            this.txtInfo.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.txtInfo.Location = new System.Drawing.Point(5, 7);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(236, 57);
            this.txtInfo.TabIndex = 1;
            this.txtInfo.Value = "";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance2;
            this.btnOK.Location = new System.Drawing.Point(188, 72);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(53, 27);
            this.btnOK.TabIndex = 2;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panelAll
            // 
            this.panelAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAll.Controls.Add(this.btnOK);
            this.panelAll.Controls.Add(this.txtInfo);
            this.panelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAll.Location = new System.Drawing.Point(0, 0);
            this.panelAll.Name = "panelAll";
            this.panelAll.Size = new System.Drawing.Size(248, 105);
            this.panelAll.TabIndex = 3;
            // 
            // frmInfoSchnellrueckmeldungOpend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 105);
            this.Controls.Add(this.panelAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInfoSchnellrueckmeldungOpend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PMDS Info";
            this.Load += new System.EventHandler(this.frmInfoSchnellrueckmeldungOpend_Load);
            this.panelAll.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor txtInfo;
        private Infragistics.Win.Misc.UltraButton btnOK;
        private System.Windows.Forms.Panel panelAll;
    }
}