namespace PMDS.GUI
{
    partial class frmKlientEdit
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
            this.ucKlientEdit1 = new PMDS.GUI.ucKlientEdit();
            this.SuspendLayout();
            // 
            // ucKlientEdit1
            // 
            this.ucKlientEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucKlientEdit1.Location = new System.Drawing.Point(0, 0);
            this.ucKlientEdit1.Name = "ucKlientEdit1";
            this.ucKlientEdit1.Size = new System.Drawing.Size(1008, 584);
            this.ucKlientEdit1.TabIndex = 1;
            // 
            // frmKlientEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1008, 584);
            this.Controls.Add(this.ucKlientEdit1);
            this.MinimumSize = new System.Drawing.Size(1024, 620);
            this.Name = "frmKlientEdit";
            this.Text = "Bewerberdaten";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKlientEdit_FormClosing);
            this.Load += new System.EventHandler(this.frmKlientEdit_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ucKlientEdit ucKlientEdit1;
    }
}