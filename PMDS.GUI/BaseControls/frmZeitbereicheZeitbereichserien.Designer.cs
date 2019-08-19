namespace PMDS.GUI.BaseControls
{
    partial class frmZeitbereicheZeitbereichserien
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmZeitbereicheZeitbereichserien));
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.ucZeitbereicheZeitbereichserien1 = new PMDS.GUI.BaseControls.ucZeitbereicheZeitbereichserien();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance1;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(768, 528);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 32);
            this.btnOK.TabIndex = 48;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "&OK";
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ucZeitbereicheZeitbereichserien1
            // 
            this.ucZeitbereicheZeitbereichserien1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucZeitbereicheZeitbereichserien1.Location = new System.Drawing.Point(0, 0);
            this.ucZeitbereicheZeitbereichserien1.Name = "ucZeitbereicheZeitbereichserien1";
            this.ucZeitbereicheZeitbereichserien1.Size = new System.Drawing.Size(828, 522);
            this.ucZeitbereicheZeitbereichserien1.TabIndex = 50;
            // 
            // frmZeitbereicheZeitbereichserien
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(828, 564);
            this.Controls.Add(this.ucZeitbereicheZeitbereichserien1);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmZeitbereicheZeitbereichserien";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " Verwaltung von Zeitbereiche und Zeitbereichserien";
            this.ResumeLayout(false);

        }

        #endregion

        private ucButton btnOK;
        private ucZeitbereicheZeitbereichserien ucZeitbereicheZeitbereichserien1;
    }
}