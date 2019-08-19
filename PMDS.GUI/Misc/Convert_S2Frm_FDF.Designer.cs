namespace PMDS.GUI.Misc
{
    partial class Convert_S2Frm_FDF
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
            this.btnStart = new Infragistics.Win.Misc.UltraButton();
            this.folderBrowser2 = new Syncfusion.Windows.Forms.FolderBrowser(this.components);
            this.pdfViewer1 = new Patagames.Pdf.Net.Controls.WinForms.PdfViewer();
            this.pdfToolStripZoomEx1 = new Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripZoomEx();
            this.pdfToolStripMain1 = new Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripMain();
            this.btnFDFDaten = new Infragistics.Win.Misc.UltraButton();
            this.lblProgress = new Infragistics.Win.Misc.UltraLabel();
            this.lblCountFDF = new Infragistics.Win.Misc.UltraLabel();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(622, 21);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(227, 26);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "XML-Formular und Daten -> PDF/FDF";
            this.btnStart.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // folderBrowser2
            // 
            this.folderBrowser2.StartLocation = Syncfusion.Windows.Forms.FolderBrowserFolder.MyComputer;
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfViewer1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pdfViewer1.CurrentIndex = -1;
            this.pdfViewer1.CurrentPageHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.pdfViewer1.Document = null;
            this.pdfViewer1.FormHighlightColor = System.Drawing.Color.Transparent;
            this.pdfViewer1.FormsBlendMode = Patagames.Pdf.Enums.BlendTypes.FXDIB_BLEND_MULTIPLY;
            this.pdfViewer1.LoadingIconText = "Loading...";
            this.pdfViewer1.Location = new System.Drawing.Point(12, 85);
            this.pdfViewer1.MouseMode = Patagames.Pdf.Net.Controls.WinForms.MouseModes.Default;
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.Padding = new System.Windows.Forms.Padding(10);
            this.pdfViewer1.PageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pdfViewer1.PageAutoDispose = true;
            this.pdfViewer1.PageBackColor = System.Drawing.Color.White;
            this.pdfViewer1.PageBorderColor = System.Drawing.Color.Black;
            this.pdfViewer1.PageMargin = new System.Windows.Forms.Padding(10);
            this.pdfViewer1.PageSeparatorColor = System.Drawing.Color.Gray;
            this.pdfViewer1.RenderFlags = ((Patagames.Pdf.Enums.RenderFlags)((Patagames.Pdf.Enums.RenderFlags.FPDF_LCD_TEXT | Patagames.Pdf.Enums.RenderFlags.FPDF_NO_CATCH)));
            this.pdfViewer1.ShowCurrentPageHighlight = true;
            this.pdfViewer1.ShowLoadingIcon = true;
            this.pdfViewer1.ShowPageSeparator = true;
            this.pdfViewer1.Size = new System.Drawing.Size(837, 457);
            this.pdfViewer1.SizeMode = Patagames.Pdf.Net.Controls.WinForms.SizeModes.FitToWidth;
            this.pdfViewer1.TabIndex = 3;
            this.pdfViewer1.TextSelectColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.pdfViewer1.TilesCount = 2;
            this.pdfViewer1.UseProgressiveRender = true;
            this.pdfViewer1.ViewMode = Patagames.Pdf.Net.Controls.WinForms.ViewModes.Vertical;
            this.pdfViewer1.Zoom = 1F;
            // 
            // pdfToolStripZoomEx1
            // 
            this.pdfToolStripZoomEx1.Dock = System.Windows.Forms.DockStyle.None;
            this.pdfToolStripZoomEx1.Location = new System.Drawing.Point(148, 0);
            this.pdfToolStripZoomEx1.Name = "pdfToolStripZoomEx1";
            this.pdfToolStripZoomEx1.PdfViewer = this.pdfViewer1;
            this.pdfToolStripZoomEx1.Size = new System.Drawing.Size(214, 25);
            this.pdfToolStripZoomEx1.TabIndex = 9;
            this.pdfToolStripZoomEx1.Text = "pdfToolStripZoomEx1";
            this.pdfToolStripZoomEx1.ZoomLevel = new float[] {
        8.33F,
        12.5F,
        25F,
        33.33F,
        50F,
        66.67F,
        75F,
        100F,
        125F,
        150F,
        200F,
        300F,
        400F,
        600F,
        800F};
            // 
            // pdfToolStripMain1
            // 
            this.pdfToolStripMain1.Dock = System.Windows.Forms.DockStyle.None;
            this.pdfToolStripMain1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.pdfToolStripMain1.Location = new System.Drawing.Point(0, 0);
            this.pdfToolStripMain1.Name = "pdfToolStripMain1";
            this.pdfToolStripMain1.PdfViewer = this.pdfViewer1;
            this.pdfToolStripMain1.Size = new System.Drawing.Size(105, 58);
            this.pdfToolStripMain1.TabIndex = 10;
            this.pdfToolStripMain1.Text = "pdfToolStripMain1";
            // 
            // btnFDFDaten
            // 
            this.btnFDFDaten.Location = new System.Drawing.Point(622, 53);
            this.btnFDFDaten.Name = "btnFDFDaten";
            this.btnFDFDaten.Size = new System.Drawing.Size(227, 26);
            this.btnFDFDaten.TabIndex = 11;
            this.btnFDFDaten.Text = "FDF Daten extrahieren";
            this.btnFDFDaten.Click += new System.EventHandler(this.btnFDFDaten_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.Location = new System.Drawing.Point(218, 54);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(386, 24);
            this.lblProgress.TabIndex = 12;
            this.lblProgress.Text = "ultraLabel1";
            this.lblProgress.Visible = false;
            // 
            // lblCountFDF
            // 
            this.lblCountFDF.Location = new System.Drawing.Point(218, 23);
            this.lblCountFDF.Name = "lblCountFDF";
            this.lblCountFDF.Size = new System.Drawing.Size(386, 24);
            this.lblCountFDF.TabIndex = 13;
            // 
            // Convert_S2Frm_FDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 554);
            this.Controls.Add(this.lblCountFDF);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.btnFDFDaten);
            this.Controls.Add(this.pdfToolStripMain1);
            this.Controls.Add(this.pdfToolStripZoomEx1);
            this.Controls.Add(this.pdfViewer1);
            this.Controls.Add(this.btnStart);
            this.Name = "Convert_S2Frm_FDF";
            this.Text = "Convert_S2Frm_FDF";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton btnStart;
        private Syncfusion.Windows.Forms.FolderBrowser folderBrowser1;
        private Syncfusion.Windows.Forms.FolderBrowser folderBrowser2;
        private Patagames.Pdf.Net.Controls.WinForms.PdfViewer pdfViewer1;
        private Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripZoomEx pdfToolStripZoomEx1;
        private Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripMain pdfToolStripMain1;
        private Infragistics.Win.Misc.UltraButton btnFDFDaten;
        private Infragistics.Win.Misc.UltraLabel lblProgress;
        private Infragistics.Win.Misc.UltraLabel lblCountFDF;
    }
}