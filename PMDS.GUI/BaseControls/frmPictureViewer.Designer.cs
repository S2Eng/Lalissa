namespace PMDS.GUI.BaseControls
{
    partial class frmPictureViewer
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.picViewer = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.numWidthHeight = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lblWidth = new Infragistics.Win.Misc.UltraLabel();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnOK = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnScalePicture = new QS2.Desktop.ControlManagment.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.numWidthHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // picViewer
            // 
            this.picViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picViewer.BackColor = System.Drawing.Color.White;
            this.picViewer.BorderShadowColor = System.Drawing.Color.Empty;
            this.picViewer.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.picViewer.Location = new System.Drawing.Point(5, 32);
            this.picViewer.Name = "picViewer";
            this.picViewer.Size = new System.Drawing.Size(723, 473);
            this.picViewer.TabIndex = 0;
            // 
            // numWidthHeight
            // 
            this.numWidthHeight.Location = new System.Drawing.Point(72, 7);
            this.numWidthHeight.Name = "numWidthHeight";
            this.numWidthHeight.Size = new System.Drawing.Size(86, 21);
            this.numWidthHeight.TabIndex = 1;
            // 
            // lblWidth
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.lblWidth.Appearance = appearance1;
            this.lblWidth.Location = new System.Drawing.Point(8, 7);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(85, 21);
            this.lblWidth.TabIndex = 2;
            this.lblWidth.Text = "Breite/Höhe";
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbort.Appearance = appearance2;
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(288, 508);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(75, 28);
            this.btnAbort.TabIndex = 33;
            this.btnAbort.Tag = "";
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance3;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.IsStandardControl = false;
            this.btnOK.Location = new System.Drawing.Point(364, 508);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 28);
            this.btnOK.TabIndex = 32;
            this.btnOK.Tag = "";
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnScalePicture
            // 
            this.btnScalePicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnScalePicture.Appearance = appearance4;
            this.btnScalePicture.AutoWorkLayout = false;
            this.btnScalePicture.IsStandardControl = false;
            this.btnScalePicture.Location = new System.Drawing.Point(160, 6);
            this.btnScalePicture.Margin = new System.Windows.Forms.Padding(4);
            this.btnScalePicture.Name = "btnScalePicture";
            this.btnScalePicture.Size = new System.Drawing.Size(91, 23);
            this.btnScalePicture.TabIndex = 34;
            this.btnScalePicture.Tag = "";
            this.btnScalePicture.Text = "Bild berechnen";
            this.btnScalePicture.Click += new System.EventHandler(this.btnScalePicture_Click);
            // 
            // frmPictureViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 539);
            this.Controls.Add(this.btnScalePicture);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.numWidthHeight);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.picViewer);
            this.Name = "frmPictureViewer";
            this.Text = "Bildbetrachter";
            this.Load += new System.EventHandler(this.frmPictureViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numWidthHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor numWidthHeight;
        private Infragistics.Win.Misc.UltraLabel lblWidth;
        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
        public QS2.Desktop.ControlManagment.BaseButton btnOK;
        public Infragistics.Win.UltraWinEditors.UltraPictureBox picViewer;
        public QS2.Desktop.ControlManagment.BaseButton btnScalePicture;
    }
}