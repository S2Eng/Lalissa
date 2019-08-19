namespace PMDS.GUI.BaseControls
{
    partial class ucParameterText
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
            this.lblText = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.tbValue = new Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.Location = new System.Drawing.Point(3, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(200, 24);
            this.lblText.TabIndex = 1;
            this.lblText.Text = "Familienname beginnt mit (leer ist alle)";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(209, 3);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(289, 20);
            this.tbValue.TabIndex = 3;
            this.tbValue.Value = "";
            this.tbValue.Enter += new System.EventHandler(this.tbValue_Enter);
            // 
            // ucParameterText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.lblText);
            this.Name = "ucParameterText";
            this.Size = new System.Drawing.Size(524, 27);
            this.Load += new System.EventHandler(this.ucParameterText_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseLableWin lblText;
        private Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor tbValue;
    }
}
