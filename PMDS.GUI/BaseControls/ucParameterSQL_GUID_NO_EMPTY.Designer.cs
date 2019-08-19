namespace PMDS.GUI.BaseControls
{
    partial class ucParameterSQL_GUID_NO_EMPTY
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
            this.cbMain = new QS2.Desktop.ControlManagment.BaseComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.cbMain)).BeginInit();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.Location = new System.Drawing.Point(3, -2);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(200, 24);
            this.lblText.TabIndex = 4;
            this.lblText.Text = "**";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbMain
            // 
            this.cbMain.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbMain.Location = new System.Drawing.Point(209, 1);
            this.cbMain.Name = "cbMain";
            this.cbMain.Size = new System.Drawing.Size(279, 21);
            this.cbMain.TabIndex = 5;
            this.cbMain.ValueChanged += new System.EventHandler(this.cbMain_ValueChanged);
            // 
            // ucParameterSQL_GUID_NO_EMPTY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.cbMain);
            this.Name = "ucParameterSQL_GUID_NO_EMPTY";
            this.Size = new System.Drawing.Size(505, 24);
            ((System.ComponentModel.ISupportInitialize)(this.cbMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseLableWin lblText;
        private QS2.Desktop.ControlManagment.BaseComboEditor cbMain;
    }
}
