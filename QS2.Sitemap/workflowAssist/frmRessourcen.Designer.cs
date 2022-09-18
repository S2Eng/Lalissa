namespace qs2.sitemap.manage.wizardsDevelop
{
    partial class frmRessourcen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.contRessourcen1 = new qs2.sitemap.manage.wizardsDevelop.contRessourcen();
            this.SuspendLayout();
            // 
            // contRessourcen1
            // 
            this.contRessourcen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contRessourcen1.Location = new System.Drawing.Point(0, 0);
            this.contRessourcen1.MinimumSize = new System.Drawing.Size(741, 454);
            this.contRessourcen1.Name = "contRessourcen1";
            this.contRessourcen1.Size = new System.Drawing.Size(854, 590);
            this.contRessourcen1.TabIndex = 0;
            // 
            // frmRessourcen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(854, 590);
            this.Controls.Add(this.contRessourcen1);
            this.Name = "frmRessourcen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ressourcen-Manager";
            this.Load += new System.EventHandler(this.frmRessourcencs_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public contRessourcen contRessourcen1;

    }
}