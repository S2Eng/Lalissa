namespace PMDS.GUI
{
    partial class ucDynReportParameter
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
            this.pnlParameter = new QS2.Desktop.ControlManagment.BasePanel();
            this.contextMenuStripParReport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuShowParameter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.konfigurationBearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripParReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlParameter
            // 
            this.pnlParameter.AutoScroll = true;
            this.pnlParameter.ContextMenuStrip = this.contextMenuStripParReport;
            this.pnlParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlParameter.Location = new System.Drawing.Point(0, 0);
            this.pnlParameter.Name = "pnlParameter";
            this.pnlParameter.Size = new System.Drawing.Size(609, 388);
            this.pnlParameter.TabIndex = 0;
            this.pnlParameter.VisibleChanged += new System.EventHandler(this.pnlParameter_VisibleChanged);
            this.pnlParameter.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlParameter_Paint);
            // 
            // contextMenuStripParReport
            // 
            this.contextMenuStripParReport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShowParameter,
            this.toolStripMenuItem1,
            this.konfigurationBearbeitenToolStripMenuItem});
            this.contextMenuStripParReport.Name = "contextMenuStrip1";
            this.contextMenuStripParReport.Size = new System.Drawing.Size(258, 54);
            // 
            // mnuShowParameter
            // 
            this.mnuShowParameter.Name = "mnuShowParameter";
            this.mnuShowParameter.Size = new System.Drawing.Size(257, 22);
            this.mnuShowParameter.Text = "Parameter für den Report anzeigen";
            this.mnuShowParameter.Click += new System.EventHandler(this.mnuShowParameter_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(254, 6);
            // 
            // konfigurationBearbeitenToolStripMenuItem
            // 
            this.konfigurationBearbeitenToolStripMenuItem.Name = "konfigurationBearbeitenToolStripMenuItem";
            this.konfigurationBearbeitenToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.konfigurationBearbeitenToolStripMenuItem.Text = "Konfiguration bearbeiten";
            this.konfigurationBearbeitenToolStripMenuItem.Click += new System.EventHandler(this.konfigurationBearbeitenToolStripMenuItem_Click);
            // 
            // ucDynReportParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlParameter);
            this.Name = "ucDynReportParameter";
            this.Size = new System.Drawing.Size(609, 388);
            this.contextMenuStripParReport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel pnlParameter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripParReport;
        private System.Windows.Forms.ToolStripMenuItem mnuShowParameter;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem konfigurationBearbeitenToolStripMenuItem;
    }
}
