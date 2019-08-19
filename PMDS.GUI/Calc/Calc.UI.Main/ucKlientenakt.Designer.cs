namespace PMDS.Calc.UI.Admin
{
    partial class ucKlientenakt
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
            this.ucKlientStammdaten1 = new PMDS.GUI.ucKlientStammdaten();
            this.SuspendLayout();
            // 
            // ucKlientStammdaten1
            // 
            this.ucKlientStammdaten1.BackColor = System.Drawing.Color.Transparent;
            this.ucKlientStammdaten1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucKlientStammdaten1.Location = new System.Drawing.Point(0, 0);
            this.ucKlientStammdaten1.Margin = new System.Windows.Forms.Padding(4);
            this.ucKlientStammdaten1.Name = "ucKlientStammdaten1";
            this.ucKlientStammdaten1.Size = new System.Drawing.Size(1108, 573);
            this.ucKlientStammdaten1.TabIndex = 0;
            // 
            // ucKlientenakt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucKlientStammdaten1);
            this.Name = "ucKlientenakt";
            this.Size = new System.Drawing.Size(1108, 573);
            this.Load += new System.EventHandler(this.ucKlientenakt_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private PMDS.GUI.ucKlientStammdaten ucKlientStammdaten1;

    }
}
