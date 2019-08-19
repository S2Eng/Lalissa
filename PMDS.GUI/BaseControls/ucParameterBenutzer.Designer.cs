namespace PMDS.GUI.BaseControls
{
    partial class ucParameterBenutzer
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
            this.cbUser = new PMDS.GUI.BaseControls.UserCombo();
            ((System.ComponentModel.ISupportInitialize)(this.cbUser)).BeginInit();
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
            // cbUser
            // 
            this.cbUser.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbUser.Location = new System.Drawing.Point(210, 4);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(192, 21);
            this.cbUser.TabIndex = 2;
            this.cbUser.SelectionChanged += new System.EventHandler(this.cbUser_SelectionChanged);
            // 
            // ucParameterBenutzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbUser);
            this.Controls.Add(this.lblText);
            this.Name = "ucParameterBenutzer";
            this.Size = new System.Drawing.Size(510, 27);
            ((System.ComponentModel.ISupportInitialize)(this.cbUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseLableWin lblText;
        private UserCombo cbUser;
    }
}
