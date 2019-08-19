namespace PMDS.GUI.PMDSClient.SelList
{
    partial class cboAuswahlListe
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
            this.cbo = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.cbo)).BeginInit();
            this.SuspendLayout();
            // 
            // cbo
            // 
            this.cbo.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cbo.AutoSize = false;
            this.cbo.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cbo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbo.Location = new System.Drawing.Point(0, 0);
            this.cbo.Name = "cbo";
            this.cbo.Size = new System.Drawing.Size(217, 25);
            this.cbo.TabIndex = 0;
            this.cbo.Click += new System.EventHandler(this.Cbo_Click);
            this.cbo.DoubleClick += new System.EventHandler(this.Cbo_DoubleClick);
            // 
            // cboAuswahlListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbo);
            this.Name = "cboAuswahlListe";
            this.Size = new System.Drawing.Size(217, 25);
            this.VisibleChanged += new System.EventHandler(this.CboAuswahlListe_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.cbo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbo;
    }
}
