namespace qs2.sitemap
{
    partial class export
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
            this.ultraGridDocumentExporter1 = new Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(this.components);
            this.ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            this.ultraGridWordWriter1 = new Infragistics.Win.UltraWinGrid.WordWriter.UltraGridWordWriter(this.components);
            this.SuspendLayout();
            // 
            // ultraGridWordWriter1
            // 
            this.ultraGridWordWriter1.ExportStarted += new System.EventHandler<Infragistics.Win.UltraWinGrid.WordWriter.ExportStartedEventArgs>(this.ultraGridWordWriter1_ExportStarted);
            // 
            // export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "export";
            this.Size = new System.Drawing.Size(422, 206);
            this.Load += new System.EventHandler(this.export_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter ultraGridDocumentExporter1;
        private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1;
        private Infragistics.Win.UltraWinGrid.WordWriter.UltraGridWordWriter ultraGridWordWriter1;

    }
}
