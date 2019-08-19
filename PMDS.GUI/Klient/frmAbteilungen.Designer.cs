namespace PMDS.GUI.Klient
{
    partial class frmAbteilungen
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
            this.ucAbteilungen2 = new PMDS.GUI.Klient.ucAbteilungen();
            this.SuspendLayout();
            // 
            // ucAbteilungen2
            // 
            this.ucAbteilungen2.BackColor = System.Drawing.Color.Transparent;
            this.ucAbteilungen2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAbteilungen2.Location = new System.Drawing.Point(0, 0);
            this.ucAbteilungen2.Name = "ucAbteilungen2";
            this.ucAbteilungen2.Size = new System.Drawing.Size(437, 273);
            this.ucAbteilungen2.TabIndex = 1;
            // 
            // frmAbteilungen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(437, 273);
            this.Controls.Add(this.ucAbteilungen2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbteilungen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Abteilungen";
            this.Load += new System.EventHandler(this.frmAbteilungen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ucAbteilungen ucAbteilungen2;
    }
}