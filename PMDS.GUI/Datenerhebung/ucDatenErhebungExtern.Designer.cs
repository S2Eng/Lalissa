namespace PMDS.GUI.Datenerhebung
{
    partial class ucDatenErhebungExtern
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
            this.panelDatenerhebnung = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelDatenerhebnung
            // 
            this.panelDatenerhebnung.BackColor = System.Drawing.Color.Transparent;
            this.panelDatenerhebnung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDatenerhebnung.Location = new System.Drawing.Point(0, 0);
            this.panelDatenerhebnung.Name = "panelDatenerhebnung";
            this.panelDatenerhebnung.Size = new System.Drawing.Size(983, 672);
            this.panelDatenerhebnung.TabIndex = 0;
            // 
            // ucDatenErhebungExtern
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelDatenerhebnung);
            this.Name = "ucDatenErhebungExtern";
            this.Size = new System.Drawing.Size(983, 672);
            this.Load += new System.EventHandler(this.ucDatenErhebungExtern_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDatenerhebnung;
    }
}
