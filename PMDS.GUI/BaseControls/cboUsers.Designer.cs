namespace PMDS.GUI.BaseControls
{
    partial class cboUsers
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
            this.ultraLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbBenutzer = new QS2.Desktop.ControlManagment.BaseComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.cbBenutzer)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Location = new System.Drawing.Point(5, 7);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(50, 14);
            this.ultraLabel1.TabIndex = 2;
            this.ultraLabel1.Text = "Benutzer";
            // 
            // cbBenutzer
            // 
            this.cbBenutzer.Location = new System.Drawing.Point(72, 4);
            this.cbBenutzer.Name = "cbBenutzer";
            this.cbBenutzer.Size = new System.Drawing.Size(160, 21);
            this.cbBenutzer.TabIndex = 3;
            // 
            // cboUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.cbBenutzer);
            this.Name = "cboUsers";
            this.Size = new System.Drawing.Size(237, 29);
            this.Load += new System.EventHandler(this.cboUsers_Load);
            this.VisibleChanged += new System.EventHandler(this.cboUsers_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.cbBenutzer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel1;
        private QS2.Desktop.ControlManagment.BaseComboEditor cbBenutzer;
    }
}
