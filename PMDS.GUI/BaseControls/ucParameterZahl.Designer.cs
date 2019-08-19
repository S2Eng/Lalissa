namespace PMDS.GUI.BaseControls
{
    partial class ucParameterZahl
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
            this.nupValue = new QS2.Desktop.ControlManagment.BaseNumericEditor();
            ((System.ComponentModel.ISupportInitialize)(this.nupValue)).BeginInit();
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
            // nupValue
            // 
            this.nupValue.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.nupValue.Location = new System.Drawing.Point(209, 3);
            this.nupValue.Name = "nupValue";
            this.nupValue.Size = new System.Drawing.Size(120, 21);
            this.nupValue.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.nupValue.TabIndex = 3;
            this.nupValue.Enter += new System.EventHandler(this.nupValue_Enter);
            // 
            // ucParameterZahl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nupValue);
            this.Controls.Add(this.lblText);
            this.Name = "ucParameterZahl";
            this.Size = new System.Drawing.Size(342, 27);
            this.Load += new System.EventHandler(this.ucParameterZahl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nupValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseLableWin lblText;
        private QS2.Desktop.ControlManagment.BaseNumericEditor nupValue;
    }
}
