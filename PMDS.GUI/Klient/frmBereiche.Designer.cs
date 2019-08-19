namespace PMDS.GUI.Klient
{
    partial class frmBereiche
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
            this.ucBereiche1 = new PMDS.GUI.Klient.ucBereiche();
            this.SuspendLayout();
            // 
            // ucBereiche1
            // 
            this.ucBereiche1.BackColor = System.Drawing.Color.Transparent;
            this.ucBereiche1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBereiche1.Location = new System.Drawing.Point(0, 0);
            this.ucBereiche1.Name = "ucBereiche1";
            this.ucBereiche1.Size = new System.Drawing.Size(437, 273);
            this.ucBereiche1.TabIndex = 0;
            // 
            // frmBereiche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(437, 273);
            this.Controls.Add(this.ucBereiche1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBereiche";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bereiche";
            this.Load += new System.EventHandler(this.frmAbteilungen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ucBereiche ucBereiche1;
    }
}