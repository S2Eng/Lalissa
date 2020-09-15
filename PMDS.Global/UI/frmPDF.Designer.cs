namespace PMDS.GUI.BaseControls
{
    partial class frmPDF
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
            this.pdfToolStripMain1 = new Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripMain();
            this.pdfViewer1 = new Patagames.Pdf.Net.Controls.WinForms.PdfViewer();
            this.pdfToolStripViewModes1 = new Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripViewModes();
            this.pdfToolStripZoom1 = new Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripZoom();
            this.pdfToolStripSearch1 = new Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripSearch();
            this.bookmarksViewer1 = new Patagames.Pdf.Net.Controls.WinForms.BookmarksViewer(this.components);
            this.SuspendLayout();
            // 
            // pdfToolStripMain1
            // 
            this.pdfToolStripMain1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfToolStripMain1.Dock = System.Windows.Forms.DockStyle.None;
            this.pdfToolStripMain1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.pdfToolStripMain1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.pdfToolStripMain1.Location = new System.Drawing.Point(893, 9);
            this.pdfToolStripMain1.Name = "pdfToolStripMain1";
            this.pdfToolStripMain1.PdfViewer = this.pdfViewer1;
            this.pdfToolStripMain1.Size = new System.Drawing.Size(105, 58);
            this.pdfToolStripMain1.TabIndex = 11;
            this.pdfToolStripMain1.Text = "pdfToolStripMain1";
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.AllowSetDocument = false;
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
            this.pdfViewer1.Location = new System.Drawing.Point(273, 70);
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
            this.pdfViewer1.Size = new System.Drawing.Size(756, 569);
            this.pdfViewer1.SizeMode = Patagames.Pdf.Net.Controls.WinForms.SizeModes.FitToWidth;
            this.pdfViewer1.TabIndex = 13;
            this.pdfViewer1.TextSelectColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.pdfViewer1.TilesCount = 2;
            this.pdfViewer1.UseProgressiveRender = true;
            this.pdfViewer1.ViewMode = Patagames.Pdf.Net.Controls.WinForms.ViewModes.Vertical;
            this.pdfViewer1.Zoom = 1F;
            // 
            // pdfToolStripViewModes1
            // 
            this.pdfToolStripViewModes1.Dock = System.Windows.Forms.DockStyle.None;
            this.pdfToolStripViewModes1.Location = new System.Drawing.Point(190, 9);
            this.pdfToolStripViewModes1.Name = "pdfToolStripViewModes1";
            this.pdfToolStripViewModes1.PdfViewer = this.pdfViewer1;
            this.pdfToolStripViewModes1.Size = new System.Drawing.Size(144, 27);
            this.pdfToolStripViewModes1.TabIndex = 15;
            this.pdfToolStripViewModes1.Text = "pdfToolStripViewModes1";
            // 
            // pdfToolStripZoom1
            // 
            this.pdfToolStripZoom1.Dock = System.Windows.Forms.DockStyle.None;
            this.pdfToolStripZoom1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.pdfToolStripZoom1.Location = new System.Drawing.Point(12, 9);
            this.pdfToolStripZoom1.Name = "pdfToolStripZoom1";
            this.pdfToolStripZoom1.PdfViewer = this.pdfViewer1;
            this.pdfToolStripZoom1.Size = new System.Drawing.Size(192, 73);
            this.pdfToolStripZoom1.TabIndex = 16;
            this.pdfToolStripZoom1.Text = "pdfToolStripZoom1";
            this.pdfToolStripZoom1.ZoomLevel = new float[] {
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
            // pdfToolStripSearch1
            // 
            this.pdfToolStripSearch1.CurrentRecord = 0;
            this.pdfToolStripSearch1.Dock = System.Windows.Forms.DockStyle.None;
            this.pdfToolStripSearch1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.pdfToolStripSearch1.Location = new System.Drawing.Point(334, 9);
            this.pdfToolStripSearch1.Name = "pdfToolStripSearch1";
            this.pdfToolStripSearch1.PdfViewer = this.pdfViewer1;
            this.pdfToolStripSearch1.SearchFlags = Patagames.Pdf.Enums.FindFlags.None;
            this.pdfToolStripSearch1.SearchText = "";
            this.pdfToolStripSearch1.Size = new System.Drawing.Size(232, 37);
            this.pdfToolStripSearch1.TabIndex = 17;
            this.pdfToolStripSearch1.Text = "pdfToolStripSearch1";
            // 
            // bookmarksViewer1
            // 
            this.bookmarksViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bookmarksViewer1.Location = new System.Drawing.Point(12, 70);
            this.bookmarksViewer1.Name = "bookmarksViewer1";
            this.bookmarksViewer1.PdfViewer = this.pdfViewer1;
            this.bookmarksViewer1.Size = new System.Drawing.Size(255, 569);
            this.bookmarksViewer1.TabIndex = 18;
            // 
            // frmPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 651);
            this.Controls.Add(this.bookmarksViewer1);
            this.Controls.Add(this.pdfToolStripSearch1);
            this.Controls.Add(this.pdfToolStripZoom1);
            this.Controls.Add(this.pdfToolStripViewModes1);
            this.Controls.Add(this.pdfViewer1);
            this.Controls.Add(this.pdfToolStripMain1);
            this.Name = "frmPDF";
            this.Text = "PDF";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Patagames.Pdf.Net.Controls.WinForms.PdfViewer pdfViewer1;
        private Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripViewModes pdfToolStripViewModes1;
        private Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripZoom pdfToolStripZoom1;
        private Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripSearch pdfToolStripSearch1;
        private Patagames.Pdf.Net.Controls.WinForms.BookmarksViewer bookmarksViewer1;
        public Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripMain pdfToolStripMain1;
    }
}