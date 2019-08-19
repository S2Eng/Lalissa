namespace PMDS.GUI.BaseControls
{
    partial class ucBigTextEditor
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.txtMain = new QS2.Desktop.ControlManagment.BaseTextEditor();
            ((System.ComponentModel.ISupportInitialize)(this.txtMain)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMain
            // 
            this.txtMain.AcceptsReturn = true;
            appearance1.BorderColor = System.Drawing.Color.LightGray;
            appearance1.FontData.SizeInPoints = 14.25F;
            this.txtMain.Appearance = appearance1;
            this.txtMain.AutoSize = false;
            this.txtMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMain.Location = new System.Drawing.Point(0, 0);
            this.txtMain.MaxLength = 2048;
            this.txtMain.Multiline = true;
            this.txtMain.Name = "txtMain";
            this.txtMain.Size = new System.Drawing.Size(443, 54);
            this.txtMain.TabIndex = 26;
            this.txtMain.TextChanged += new System.EventHandler(this.txtMain_TextChanged);
            this.txtMain.Enter += new System.EventHandler(this.txtMain_Enter);
            // 
            // ucBigTextEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtMain);
            this.Name = "ucBigTextEditor";
            this.Size = new System.Drawing.Size(443, 54);
            ((System.ComponentModel.ISupportInitialize)(this.txtMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseTextEditor txtMain;

    }
}
