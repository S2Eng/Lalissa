namespace PMDS.GUI.BaseControls
{
    partial class ucParameterAbteilung
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
            this.cbAbteilung = new PMDS.GUI.BaseControls.AbteilungsCombo();
            ((System.ComponentModel.ISupportInitialize)(this.cbAbteilung)).BeginInit();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.Location = new System.Drawing.Point(3, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(200, 24);
            this.lblText.TabIndex = 1;
            this.lblText.Text = "**";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbAbteilung
            // 
            this.cbAbteilung.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbAbteilung.ENVAbteilung = true;
            this.cbAbteilung.Location = new System.Drawing.Point(209, 3);
            this.cbAbteilung.Name = "cbAbteilung";
            this.cbAbteilung.Size = new System.Drawing.Size(246, 21);
            this.cbAbteilung.TabIndex = 2;
            this.cbAbteilung.SelectionChanged += new System.EventHandler(this.cbAbteilung_SelectionChanged);
            // 
            // ucParameterAbteilung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbAbteilung);
            this.Controls.Add(this.lblText);
            this.Name = "ucParameterAbteilung";
            this.Size = new System.Drawing.Size(524, 27);
            ((System.ComponentModel.ISupportInitialize)(this.cbAbteilung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseLableWin lblText;
        private AbteilungsCombo cbAbteilung;
    }
}
