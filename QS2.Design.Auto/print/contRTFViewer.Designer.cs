namespace qs2.design.auto.print
{
    partial class contRTFViewer
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
            this.ContTxtEditor1 = new QS2.Desktop.Txteditor.contTxtEditor();
            this.ultraPanel1 = new Infragistics.Win.Misc.UltraPanel();
            this.ContTxtEditor2 = new QS2.Desktop.Txteditor2.contTxtEditor2();
            this.ultraPanel2 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraProgressBar1 = new Infragistics.Win.UltraWinProgressBar.UltraProgressBar();
            this.ultraPanel1.ClientArea.SuspendLayout();
            this.ultraPanel1.SuspendLayout();
            this.ultraPanel2.ClientArea.SuspendLayout();
            this.ultraPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContTxtEditor1
            // 
            this.ContTxtEditor1.AllowDrop = true;
            this.ContTxtEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContTxtEditor1.ISTOSAVE = false;
            this.ContTxtEditor1.Location = new System.Drawing.Point(352, 19);
            this.ContTxtEditor1.Name = "ContTxtEditor1";
            this.ContTxtEditor1.Size = new System.Drawing.Size(304, 163);
            this.ContTxtEditor1.TabIndex = 114;
            this.ContTxtEditor1.typUI = QS2.Desktop.Txteditor.etyp.all;
            this.ContTxtEditor1.Visible = false;
            // 
            // ultraPanel1
            // 
            // 
            // ultraPanel1.ClientArea
            // 
            this.ultraPanel1.ClientArea.Controls.Add(this.ContTxtEditor2);
            this.ultraPanel1.ClientArea.Controls.Add(this.ContTxtEditor1);
            this.ultraPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraPanel1.Name = "ultraPanel1";
            this.ultraPanel1.Size = new System.Drawing.Size(1007, 784);
            this.ultraPanel1.TabIndex = 115;
            // 
            // ContTxtEditor2
            // 
            this.ContTxtEditor2.AllowDrop = true;
            this.ContTxtEditor2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContTxtEditor2.Location = new System.Drawing.Point(18, 19);
            this.ContTxtEditor2.Name = "ContTxtEditor2";
            this.ContTxtEditor2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ContTxtEditor2.Size = new System.Drawing.Size(308, 167);
            this.ContTxtEditor2.TabIndex = 115;
            this.ContTxtEditor2.Visible = false;
            // 
            // ultraPanel2
            // 
            // 
            // ultraPanel2.ClientArea
            // 
            this.ultraPanel2.ClientArea.Controls.Add(this.ultraProgressBar1);
            this.ultraPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ultraPanel2.Location = new System.Drawing.Point(0, 756);
            this.ultraPanel2.Name = "ultraPanel2";
            this.ultraPanel2.Size = new System.Drawing.Size(1007, 28);
            this.ultraPanel2.TabIndex = 116;
            this.ultraPanel2.Visible = false;
            // 
            // ultraProgressBar1
            // 
            this.ultraProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraProgressBar1.Location = new System.Drawing.Point(0, 0);
            this.ultraProgressBar1.Name = "ultraProgressBar1";
            this.ultraProgressBar1.Size = new System.Drawing.Size(1007, 28);
            this.ultraProgressBar1.TabIndex = 0;
            this.ultraProgressBar1.Text = "[Formatted]";
            // 
            // contRTFViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ultraPanel2);
            this.Controls.Add(this.ultraPanel1);
            this.Name = "contRTFViewer";
            this.Size = new System.Drawing.Size(1007, 784);
            this.ultraPanel1.ClientArea.ResumeLayout(false);
            this.ultraPanel1.ResumeLayout(false);
            this.ultraPanel2.ClientArea.ResumeLayout(false);
            this.ultraPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal QS2.Desktop.Txteditor.contTxtEditor ContTxtEditor1;
        private Infragistics.Win.Misc.UltraPanel ultraPanel1;
        private Infragistics.Win.Misc.UltraPanel ultraPanel2;
        private Infragistics.Win.UltraWinProgressBar.UltraProgressBar ultraProgressBar1;
        private QS2.Desktop.Txteditor2.contTxtEditor2 ContTxtEditor2;
    }
}
