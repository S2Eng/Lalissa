namespace PMDS.GUI.ELGA
{
    partial class frmELGAKlient
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
            this.contELGAKlient1 = new PMDS.GUI.ELGA.contELGAKlient();
            this.SuspendLayout();
            // 
            // contELGAKlient1
            // 
            this.contELGAKlient1.BackColor = System.Drawing.Color.White;
            this.contELGAKlient1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contELGAKlient1.Location = new System.Drawing.Point(0, 0);
            this.contELGAKlient1.Name = "contELGAKlient1";
            this.contELGAKlient1.Size = new System.Drawing.Size(743, 242);
            this.contELGAKlient1.TabIndex = 0;
            // 
            // frmELGAKlient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(743, 242);
            this.Controls.Add(this.contELGAKlient1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmELGAKlient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ELGA - Klient";
            this.Load += new System.EventHandler(this.frmELGAKlient_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public contELGAKlient contELGAKlient1;
    }
}