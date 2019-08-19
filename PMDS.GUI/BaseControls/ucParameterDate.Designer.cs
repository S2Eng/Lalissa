namespace PMDS.GUI.BaseControls
{
    partial class ucParameterDate
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
            this.dtpDate = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate)).BeginInit();
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
            // dtpDate
            // 
            this.dtpDate.FormatString = "dd.MM.yyyy HH:mm";
            this.dtpDate.Location = new System.Drawing.Point(209, 4);
            this.dtpDate.MaskInput = "";
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(124, 19);
            this.dtpDate.TabIndex = 3;
            this.dtpDate.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate2_ValueChanged);
            this.dtpDate.Enter += new System.EventHandler(this.dtpDate2_Enter);
            // 
            // ucParameterDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblText);
            this.Name = "ucParameterDate";
            this.Size = new System.Drawing.Size(386, 27);
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseLableWin lblText;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpDate;
    }
}
