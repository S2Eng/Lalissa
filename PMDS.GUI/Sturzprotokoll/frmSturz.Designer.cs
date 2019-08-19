namespace PMDS.GUI.Sturzprotokoll
{
    partial class frmSturz
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
            this.contSturz1 = new PMDS.GUI.Sturzprotokoll.contSturz();
            this.SuspendLayout();
            // 
            // contSturz1
            // 
            this.contSturz1.BackColor = System.Drawing.Color.Transparent;
            this.contSturz1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contSturz1.Location = new System.Drawing.Point(0, 0);
            this.contSturz1.Name = "contSturz1";
            this.contSturz1.Size = new System.Drawing.Size(985, 541);
            this.contSturz1.TabIndex = 0;
            // 
            // frmSturz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 541);
            this.Controls.Add(this.contSturz1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimumSize = new System.Drawing.Size(892, 393);
            this.Name = "frmSturz";
            this.Text = "Sturz";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSturz_FormClosing);
            this.Load += new System.EventHandler(this.frmSturz_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public contSturz contSturz1;

    }
}