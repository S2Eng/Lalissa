namespace PMDS.GUI
{
    partial class frmBewerber
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnClose = new QS2.Desktop.ControlManagment.BaseButton();
            this.ucSiteMapBewerber1 = new PMDS.GUI.ucSiteMapBewerber();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoWorkLayout = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.IsStandardControl = false;
            this.btnClose.Location = new System.Drawing.Point(965, 570);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 28);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Schließen";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ucSiteMapBewerber1
            // 
            this.ucSiteMapBewerber1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSiteMapBewerber1.Location = new System.Drawing.Point(0, 0);
            this.ucSiteMapBewerber1.Name = "ucSiteMapBewerber1";
            this.ucSiteMapBewerber1.Size = new System.Drawing.Size(1045, 574);
            this.ucSiteMapBewerber1.TabIndex = 0;
            // 
            // frmBewerber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1046, 603);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucSiteMapBewerber1);
            this.MinimumSize = new System.Drawing.Size(877, 589);
            this.Name = "frmBewerber";
            this.ShowInTaskbar = false;
            this.Text = "PMDS- Bewerberverwaltung";
            this.Load += new System.EventHandler(this.frmBewerber_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucSiteMapBewerber ucSiteMapBewerber1;
        private QS2.Desktop.ControlManagment.BaseButton btnClose;
    }
}