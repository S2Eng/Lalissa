namespace PMDS.GUI.BaseControls
{
    partial class ucParameterAuswahlliste
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
            this.cbList = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            ((System.ComponentModel.ISupportInitialize)(this.cbList)).BeginInit();
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
            // cbList
            // 
            this.cbList.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbList.Group = "";
            this.cbList.ID = System.Guid.Empty;
            this.cbList.Location = new System.Drawing.Point(210, 3);
            this.cbList.Name = "cbList";
            this.cbList.ShowAddButton = false;
            this.cbList.Size = new System.Drawing.Size(222, 21);
            this.cbList.TabIndex = 2;
            this.cbList.SelectionChanged += new System.EventHandler(this.cbList_SelectionChanged);
            // 
            // ucParameterAuswahlliste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbList);
            this.Controls.Add(this.lblText);
            this.Name = "ucParameterAuswahlliste";
            this.Size = new System.Drawing.Size(524, 27);
            ((System.ComponentModel.ISupportInitialize)(this.cbList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseLableWin lblText;
        private AuswahlGruppeCombo cbList;
    }
}
