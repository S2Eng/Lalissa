namespace PMDS.GUI.BaseControls
{
    partial class ucParameterBool
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
            this.cbValue = new QS2.Desktop.ControlManagment.BaseCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.cbValue)).BeginInit();
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
            // cbValue
            // 
            this.cbValue.Location = new System.Drawing.Point(209, 6);
            this.cbValue.Name = "cbValue";
            this.cbValue.Size = new System.Drawing.Size(15, 14);
            this.cbValue.TabIndex = 3;
            this.cbValue.Text = "ultraCheckEditor1";
            this.cbValue.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // ucParameterBool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbValue);
            this.Controls.Add(this.lblText);
            this.Name = "ucParameterBool";
            this.Size = new System.Drawing.Size(320, 27);
            this.Load += new System.EventHandler(this.ucParameterBool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseLableWin lblText;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbValue;
    }
}
