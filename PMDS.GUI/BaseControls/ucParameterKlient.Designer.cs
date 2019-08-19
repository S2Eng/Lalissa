namespace PMDS.GUI.BaseControls
{
    partial class ucParameterKlient
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
            this.contPatientUserPicker1 = new PMDS.GUI.PatientUserPicker.contPatientUserPicker();
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
            // contPatientUserPicker1
            // 
            this.contPatientUserPicker1.BackColor = System.Drawing.Color.White;
            this.contPatientUserPicker1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contPatientUserPicker1.Location = new System.Drawing.Point(209, 0);
            this.contPatientUserPicker1.Name = "contPatientUserPicker1";
            this.contPatientUserPicker1.Size = new System.Drawing.Size(286, 24);
            this.contPatientUserPicker1.TabIndex = 35;
            // 
            // ucParameterKlient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.contPatientUserPicker1);
            this.Name = "ucParameterKlient";
            this.Size = new System.Drawing.Size(510, 27);
            this.ResumeLayout(false);

        }

        #endregion
        private QS2.Desktop.ControlManagment.BaseLableWin lblText;
        private PatientUserPicker.contPatientUserPicker contPatientUserPicker1;
    }
}
