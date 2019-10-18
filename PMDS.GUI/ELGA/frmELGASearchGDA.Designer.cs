namespace PMDS.GUI.ELGA
{
    partial class frmELGASearchGDA
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
            this.contELGASearchGDA1 = new PMDS.GUI.ELGA.contELGASearchGDA();
            this.SuspendLayout();
            // 
            // contELGASearchGDA1
            // 
            this.contELGASearchGDA1.BackColor = System.Drawing.Color.White;
            this.contELGASearchGDA1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contELGASearchGDA1.Location = new System.Drawing.Point(0, 0);
            this.contELGASearchGDA1.Name = "contELGASearchGDA1";
            this.contELGASearchGDA1.Size = new System.Drawing.Size(827, 452);
            this.contELGASearchGDA1.TabIndex = 0;
            // 
            // frmELGASearchGDA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(827, 452);
            this.Controls.Add(this.contELGASearchGDA1);
            this.Name = "frmELGASearchGDA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ELGA - Suche GDA";
            this.Load += new System.EventHandler(this.FrmELGASearchGDA_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public contELGASearchGDA contELGASearchGDA1;
    }
}