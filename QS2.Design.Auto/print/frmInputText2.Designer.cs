namespace qs2.design.auto.print
{
    partial class frmInputText2
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInputText2));
            this.txtText = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnAbort = new qs2.sitemap.ownControls.inherit_Infrag.InfragButton();
            this.btnOk = new qs2.sitemap.ownControls.inherit_Infrag.InfragButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtText)).BeginInit();
            this.SuspendLayout();
            // 
            // txtText
            // 
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtText.Location = new System.Drawing.Point(8, 7);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(391, 21);
            this.txtText.TabIndex = 12;
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnAbort.Appearance = appearance3;
            this.btnAbort.Location = new System.Drawing.Point(202, 34);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.OwnAutoTextYN = false;
            this.btnAbort.OwnPicture = QS2.Resources.getRes.ePicture.none;
            this.btnAbort.OwnPictureTxt = "";
            this.btnAbort.OwnSizeMode = qs2.core.Enums.eSize.big;
            this.btnAbort.OwnTooltipText = "";
            this.btnAbort.OwnTooltipTitle = null;
            this.btnAbort.Size = new System.Drawing.Size(64, 26);
            this.btnAbort.TabIndex = 14;
            this.btnAbort.Text = "Abort";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnOk.Appearance = appearance1;
            this.btnOk.Location = new System.Drawing.Point(141, 34);
            this.btnOk.Name = "btnOk";
            this.btnOk.OwnAutoTextYN = false;
            this.btnOk.OwnPicture = QS2.Resources.getRes.Allgemein.ico_OK;
            this.btnOk.OwnPictureTxt = "";
            this.btnOk.OwnSizeMode = qs2.core.Enums.eSize.big;
            this.btnOk.OwnTooltipText = "";
            this.btnOk.OwnTooltipTitle = null;
            this.btnOk.Size = new System.Drawing.Size(61, 26);
            this.btnOk.TabIndex = 13;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmInputText2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 64);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInputText2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Input Text";
            this.Load += new System.EventHandler(this.frmInputText_Load);
            this.VisibleChanged += new System.EventHandler(this.frmInputText_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.txtText)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private sitemap.ownControls.inherit_Infrag.InfragButton btnAbort;
        private sitemap.ownControls.inherit_Infrag.InfragButton btnOk;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor txtText;
    }
}