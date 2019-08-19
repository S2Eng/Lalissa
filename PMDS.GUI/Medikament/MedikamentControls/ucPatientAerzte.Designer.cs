namespace PMDS.GUI
{
    partial class ucPatientAerzte
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
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton("Add");
            this.cmbArzt = new QS2.Desktop.ControlManagment.BaseComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.cmbArzt)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbArzt
            // 
            this.cmbArzt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            editorButton1.Key = "Add";
            editorButton1.Text = "+";
            this.cmbArzt.ButtonsRight.Add(editorButton1);
            this.cmbArzt.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbArzt.Location = new System.Drawing.Point(0, 0);
            this.cmbArzt.Name = "cmbArzt";
            this.cmbArzt.Size = new System.Drawing.Size(294, 21);
            this.cmbArzt.TabIndex = 2;
            this.cmbArzt.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.cmbArzt_EditorButtonClick);
            // 
            // ucPatientAerzte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbArzt);
            this.Name = "ucPatientAerzte";
            this.Size = new System.Drawing.Size(297, 24);
            ((System.ComponentModel.ISupportInitialize)(this.cmbArzt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public QS2.Desktop.ControlManagment.BaseComboEditor cmbArzt;
    }
}
