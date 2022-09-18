
namespace qs2.ui.ManageDeathStatus
{
    partial class contManageDeathStatusSelect
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
            this.btnStartService = new Infragistics.Win.Misc.UltraButton();
            this.btnStartXlsX = new Infragistics.Win.Misc.UltraButton();
            this.SuspendLayout();
            // 
            // btnStartService
            // 
            this.btnStartService.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartService.Location = new System.Drawing.Point(57, 112);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(317, 96);
            this.btnStartService.TabIndex = 2;
            this.btnStartService.Text = "Sterbestatus mit GÖG-Service abgleichen";
            // 
            // btnStartXlsX
            // 
            this.btnStartXlsX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartXlsX.Location = new System.Drawing.Point(380, 112);
            this.btnStartXlsX.Name = "btnStartXlsX";
            this.btnStartXlsX.Size = new System.Drawing.Size(317, 96);
            this.btnStartXlsX.TabIndex = 3;
            this.btnStartXlsX.Text = "Sterbestatus aus XLSX-Datei übernehmen";
            this.btnStartXlsX.Click += new System.EventHandler(this.btnStartXlsX_Click);
            // 
            // contManageDeathStatusSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnStartXlsX);
            this.Controls.Add(this.btnStartService);
            this.Name = "contManageDeathStatusSelect";
            this.Size = new System.Drawing.Size(765, 333);
            this.ResumeLayout(false);

        }

        #endregion
        private Infragistics.Win.Misc.UltraButton btnStartService;
        private Infragistics.Win.Misc.UltraButton btnStartXlsX;
    }
}
