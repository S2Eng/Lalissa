namespace PMDS.GUI.Klient
{
    partial class ucKlientStammdatenDokumente
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
            this.pdfViewer = new Patagames.Pdf.Net.Controls.WinForms.PdfViewer();
            this.pdfToolStripZoom = new Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripZoomEx();
            this.ucKlientStammdatenDokument1 = new PMDS.GUI.Klient.ucKlientStammdatenDokument();
            this.SuspendLayout();
            // 
            // pdfViewer
            // 
            this.pdfViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfViewer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pdfViewer.CurrentIndex = -1;
            this.pdfViewer.CurrentPageHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.pdfViewer.Document = null;
            this.pdfViewer.FormHighlightColor = System.Drawing.Color.Transparent;
            this.pdfViewer.FormsBlendMode = Patagames.Pdf.Enums.BlendTypes.FXDIB_BLEND_MULTIPLY;
            this.pdfViewer.LoadingIconText = "Loading...";
            this.pdfViewer.Location = new System.Drawing.Point(514, 56);
            this.pdfViewer.MouseMode = Patagames.Pdf.Net.Controls.WinForms.MouseModes.Default;
            this.pdfViewer.Name = "pdfViewer";
            this.pdfViewer.Padding = new System.Windows.Forms.Padding(10);
            this.pdfViewer.PageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.pdfViewer.PageAutoDispose = true;
            this.pdfViewer.PageBackColor = System.Drawing.Color.White;
            this.pdfViewer.PageBorderColor = System.Drawing.Color.Black;
            this.pdfViewer.PageMargin = new System.Windows.Forms.Padding(10);
            this.pdfViewer.PageSeparatorColor = System.Drawing.Color.Gray;
            this.pdfViewer.RenderFlags = ((Patagames.Pdf.Enums.RenderFlags)((Patagames.Pdf.Enums.RenderFlags.FPDF_LCD_TEXT | Patagames.Pdf.Enums.RenderFlags.FPDF_NO_CATCH)));
            this.pdfViewer.ShowCurrentPageHighlight = true;
            this.pdfViewer.ShowLoadingIcon = true;
            this.pdfViewer.ShowPageSeparator = true;
            this.pdfViewer.Size = new System.Drawing.Size(261, 439);
            this.pdfViewer.SizeMode = Patagames.Pdf.Net.Controls.WinForms.SizeModes.FitToWidth;
            this.pdfViewer.TabIndex = 4;
            this.pdfViewer.TextSelectColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.pdfViewer.TilesCount = 2;
            this.pdfViewer.UseProgressiveRender = true;
            this.pdfViewer.ViewMode = Patagames.Pdf.Net.Controls.WinForms.ViewModes.Vertical;
            this.pdfViewer.Visible = false;
            this.pdfViewer.Zoom = 1F;
            // 
            // pdfToolStripZoom
            // 
            this.pdfToolStripZoom.Dock = System.Windows.Forms.DockStyle.None;
            this.pdfToolStripZoom.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.pdfToolStripZoom.Location = new System.Drawing.Point(514, 30);
            this.pdfToolStripZoom.Name = "pdfToolStripZoom";
            this.pdfToolStripZoom.PdfViewer = this.pdfViewer;
            this.pdfToolStripZoom.Size = new System.Drawing.Size(234, 23);
            this.pdfToolStripZoom.TabIndex = 10;
            this.pdfToolStripZoom.Text = "pdfToolStripZoomEx1";
            this.pdfToolStripZoom.Visible = false;
            this.pdfToolStripZoom.ZoomLevel = new float[] {
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
            // ucKlientStammdatenDokument1
            // 
            this.ucKlientStammdatenDokument1.BackColor = System.Drawing.Color.LightGray;
            this.ucKlientStammdatenDokument1.docuDocumentFileTypePrefered = "pdf-Files (*.pdf)|*.pdf";
            this.ucKlientStammdatenDokument1.docuIDKey = "ID";
            this.ucKlientStammdatenDokument1.docuNameDocument = "Einverständniserklärung";
            this.ucKlientStammdatenDokument1.docuSqlColumnBlob = "blob_Einverständniserklärung";
            this.ucKlientStammdatenDokument1.docuSqlColumnFileType = "EinverständniserklärungFileType";
            this.ucKlientStammdatenDokument1.docuSSqlTable = "Patient";
            this.ucKlientStammdatenDokument1.Location = new System.Drawing.Point(13, 16);
            this.ucKlientStammdatenDokument1.Name = "ucKlientStammdatenDokument1";
            this.ucKlientStammdatenDokument1.Size = new System.Drawing.Size(495, 42);
            this.ucKlientStammdatenDokument1.TabIndex = 11;
            // 
            // ucKlientStammdatenDokumente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.ucKlientStammdatenDokument1);
            this.Controls.Add(this.pdfToolStripZoom);
            this.Controls.Add(this.pdfViewer);
            this.Name = "ucKlientStammdatenDokumente";
            this.Size = new System.Drawing.Size(773, 504);
            this.Load += new System.EventHandler(this.ucKlientStammdatenDokumente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Patagames.Pdf.Net.Controls.WinForms.PdfViewer pdfViewer;
        private Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripZoomEx pdfToolStripZoom;
        private ucKlientStammdatenDokument ucKlientStammdatenDokument1;
    }
}
