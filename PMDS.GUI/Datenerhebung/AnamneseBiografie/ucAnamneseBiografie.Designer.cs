namespace PMDS.GUI
{
    partial class ucAnamneseBiografie
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
            this.panelBiographie = new QS2.Desktop.ControlManagment.BasePanel();
            ((System.ComponentModel.ISupportInitialize)(this.dtpErstelltAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbErstelltAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPfleger)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBiographie
            // 
            this.panelBiographie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBiographie.Location = new System.Drawing.Point(0, 0);
            this.panelBiographie.Name = "panelBiographie";
            this.panelBiographie.Size = new System.Drawing.Size(764, 540);
            this.panelBiographie.TabIndex = 123;
            this.panelBiographie.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBiografie_Paint);
            // 
            // ucAnamneseBiografie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelBiographie);
            this.Name = "ucAnamneseBiografie";
            this.Load += new System.EventHandler(this.ucAnamneseKrohwinkel2_Load);
            this.DataChanged += new PMDS.GUI.DataChangedDelegate(this.ucAnamneseBiografie_DataChanged);
            this.Resize += new System.EventHandler(this.ucAnamneseBiografie_Resize);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnUndo, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.cmbPfleger, 0);
            this.Controls.SetChildIndex(this.cmbErstelltAm, 0);
            this.Controls.SetChildIndex(this.dtpErstelltAm, 0);
            this.Controls.SetChildIndex(this.panelBiographie, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtpErstelltAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbErstelltAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPfleger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel panelBiographie;

    }
}
