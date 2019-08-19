namespace PMDS.GUI.PatientUserPicker
{
    partial class contPatientUserPicker
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.dropDownPatienten = new Infragistics.Win.Misc.UltraDropDownButton();
            this.uPopUpContPatienten = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.SuspendLayout();
            // 
            // dropDownPatienten
            // 
            appearance1.BorderColor = System.Drawing.Color.Black;
            appearance1.FontData.BoldAsString = "True";
            appearance1.FontData.SizeInPoints = 10F;
            appearance1.ForeColor = System.Drawing.Color.Red;
            appearance1.TextHAlignAsString = "Left";
            this.dropDownPatienten.Appearance = appearance1;
            this.dropDownPatienten.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.dropDownPatienten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dropDownPatienten.Location = new System.Drawing.Point(0, 0);
            this.dropDownPatienten.Name = "dropDownPatienten";
            this.dropDownPatienten.Size = new System.Drawing.Size(193, 26);
            this.dropDownPatienten.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.dropDownPatienten.TabIndex = 5;
            this.dropDownPatienten.Tag = "ResID.Patienten";
            this.dropDownPatienten.Text = "Patienten";
            // 
            // contPatientUserPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dropDownPatienten);
            this.Name = "contPatientUserPicker";
            this.Size = new System.Drawing.Size(193, 26);
            this.Load += new System.EventHandler(this.contPatientUserPicker_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal Infragistics.Win.Misc.UltraDropDownButton dropDownPatienten;
        private Infragistics.Win.Misc.UltraPopupControlContainer uPopUpContPatienten;
    }
}
