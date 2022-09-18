namespace qs2.design.auto
{
    partial class contPDFViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(contPDFViewer));
            this.bookmarksViewer1 = new Patagames.Pdf.Net.Controls.WinForms.BookmarksViewer(this.components);
            this.pdfViewer1 = new Patagames.Pdf.Net.Controls.WinForms.PdfViewer();
            this.pdfToolStripZoom1 = new Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripZoom();
            this.pdfToolStripViewModes1 = new Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripViewModes();
            this.pdfToolStripSearch1 = new Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripSearch();
            this.pdfToolStripMain1 = new Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripMain();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.lblCount = new Infragistics.Win.Misc.UltraLabel();
            this.pdfToolStripMain1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bookmarksViewer1
            // 
            this.bookmarksViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bookmarksViewer1.Location = new System.Drawing.Point(5, 76);
            this.bookmarksViewer1.Name = "bookmarksViewer1";
            this.bookmarksViewer1.PdfViewer = this.pdfViewer1;
            this.bookmarksViewer1.Size = new System.Drawing.Size(198, 519);
            this.bookmarksViewer1.TabIndex = 0;
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
            this.pdfViewer1.Location = new System.Drawing.Point(209, 76);
            this.pdfViewer1.MouseMode = Patagames.Pdf.Net.Controls.WinForms.MouseModes.Default;
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.OptimizedLoadThreshold = 1000;
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
            this.pdfViewer1.Size = new System.Drawing.Size(683, 519);
            this.pdfViewer1.SizeMode = Patagames.Pdf.Net.Controls.WinForms.SizeModes.FitToWidth;
            this.pdfViewer1.TabIndex = 1;
            this.pdfViewer1.TextSelectColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.pdfViewer1.TilesCount = 2;
            this.pdfViewer1.UseProgressiveRender = true;
            this.pdfViewer1.ViewMode = Patagames.Pdf.Net.Controls.WinForms.ViewModes.Vertical;
            this.pdfViewer1.Zoom = 1F;
            // 
            // pdfToolStripZoom1
            // 
            this.pdfToolStripZoom1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfToolStripZoom1.Dock = System.Windows.Forms.DockStyle.None;
            this.pdfToolStripZoom1.Location = new System.Drawing.Point(479, 0);
            this.pdfToolStripZoom1.Name = "pdfToolStripZoom1";
            this.pdfToolStripZoom1.PdfViewer = this.pdfViewer1;
            this.pdfToolStripZoom1.Size = new System.Drawing.Size(203, 73);
            this.pdfToolStripZoom1.TabIndex = 2;
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
            // pdfToolStripViewModes1
            // 
            this.pdfToolStripViewModes1.Dock = System.Windows.Forms.DockStyle.None;
            this.pdfToolStripViewModes1.Location = new System.Drawing.Point(5, 0);
            this.pdfToolStripViewModes1.Name = "pdfToolStripViewModes1";
            this.pdfToolStripViewModes1.PdfViewer = this.pdfViewer1;
            this.pdfToolStripViewModes1.Size = new System.Drawing.Size(177, 27);
            this.pdfToolStripViewModes1.TabIndex = 3;
            this.pdfToolStripViewModes1.Text = "pdfToolStripViewModes1";
            // 
            // pdfToolStripSearch1
            // 
            this.pdfToolStripSearch1.ActiveRecordColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.pdfToolStripSearch1.CurrentRecord = 0;
            this.pdfToolStripSearch1.Dock = System.Windows.Forms.DockStyle.None;
            this.pdfToolStripSearch1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.pdfToolStripSearch1.Location = new System.Drawing.Point(209, 0);
            this.pdfToolStripSearch1.Name = "pdfToolStripSearch1";
            this.pdfToolStripSearch1.PdfViewer = this.pdfViewer1;
            this.pdfToolStripSearch1.SearchFlags = Patagames.Pdf.Enums.FindFlags.None;
            this.pdfToolStripSearch1.SearchText = "";
            this.pdfToolStripSearch1.Size = new System.Drawing.Size(232, 37);
            this.pdfToolStripSearch1.TabIndex = 4;
            this.pdfToolStripSearch1.Text = "pdfToolStripSearch1";
            // 
            // pdfToolStripMain1
            // 
            this.pdfToolStripMain1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfToolStripMain1.Dock = System.Windows.Forms.DockStyle.None;
            this.pdfToolStripMain1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSave});
            this.pdfToolStripMain1.Location = new System.Drawing.Point(716, 0);
            this.pdfToolStripMain1.Name = "pdfToolStripMain1";
            this.pdfToolStripMain1.PdfViewer = this.pdfViewer1;
            this.pdfToolStripMain1.Size = new System.Drawing.Size(139, 58);
            this.pdfToolStripMain1.TabIndex = 5;
            this.pdfToolStripMain1.Text = "pdfToolStripMain1";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(23, 55);
            this.toolStripButtonSave.Text = "Save";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // lblCount
            // 
            this.lblCount.Location = new System.Drawing.Point(5, 49);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(436, 21);
            this.lblCount.TabIndex = 6;
            // 
            // contPDFViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.pdfToolStripMain1);
            this.Controls.Add(this.pdfToolStripSearch1);
            this.Controls.Add(this.pdfToolStripViewModes1);
            this.Controls.Add(this.pdfToolStripZoom1);
            this.Controls.Add(this.pdfViewer1);
            this.Controls.Add(this.bookmarksViewer1);
            this.Name = "contPDFViewer";
            this.Size = new System.Drawing.Size(897, 600);
            this.pdfToolStripMain1.ResumeLayout(false);
            this.pdfToolStripMain1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Patagames.Pdf.Net.Controls.WinForms.BookmarksViewer bookmarksViewer1;
        private Patagames.Pdf.Net.Controls.WinForms.PdfViewer pdfViewer1;
        private Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripZoom pdfToolStripZoom1;
        private Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripViewModes pdfToolStripViewModes1;
        private Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripSearch pdfToolStripSearch1;
        private Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripMain pdfToolStripMain1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private Infragistics.Win.Misc.UltraLabel lblCount;
    }
}
