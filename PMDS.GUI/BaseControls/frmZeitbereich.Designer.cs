namespace PMDS.GUI.BaseControls
{
    partial class frmZeitbereich
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmZeitbereich));
            this.btnSave = new PMDS.GUI.ucButton(this.components);
            this.ucZeitbereich1 = new PMDS.GUI.BaseControls.ucZeitbereich();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance1;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.Location = new System.Drawing.Point(326, 392);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 32);
            this.btnSave.TabIndex = 28;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "&Speichern";
            this.btnSave.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnSave.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ucZeitbereich1
            // 
            this.ucZeitbereich1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucZeitbereich1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucZeitbereich1.Location = new System.Drawing.Point(-3, 0);
            this.ucZeitbereich1.Name = "ucZeitbereich1";
            this.ucZeitbereich1.Size = new System.Drawing.Size(430, 380);
            this.ucZeitbereich1.TabIndex = 2;
            // 
            // frmZeitbereich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(427, 430);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ucZeitbereich1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmZeitbereich";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Zeitbereiche";
            this.ResumeLayout(false);

        }

        #endregion

        private ucZeitbereich ucZeitbereich1;
        private ucButton btnSave;
    }
}