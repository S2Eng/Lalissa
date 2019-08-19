namespace PMDS.GUI.GUI.Main
{
    partial class frmSuchtgiftschrankSchlüssel
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
            this.ucSuchtgiftschrankSchlüssel1 = new PMDS.GUI.GUI.Main.ucSuchtgiftschrankSchlüssel();
            this.SuspendLayout();
            // 
            // ucSuchtgiftschrankSchlüssel1
            // 
            this.ucSuchtgiftschrankSchlüssel1.BackColor = System.Drawing.Color.Transparent;
            this.ucSuchtgiftschrankSchlüssel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSuchtgiftschrankSchlüssel1.Location = new System.Drawing.Point(0, 0);
            this.ucSuchtgiftschrankSchlüssel1.Name = "ucSuchtgiftschrankSchlüssel1";
            this.ucSuchtgiftschrankSchlüssel1.Size = new System.Drawing.Size(548, 370);
            this.ucSuchtgiftschrankSchlüssel1.TabIndex = 0;
            // 
            // frmSuchtgiftschrankSchlüssel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(548, 370);
            this.Controls.Add(this.ucSuchtgiftschrankSchlüssel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSuchtgiftschrankSchlüssel";
            this.Text = "Suchtgiftschrank-Schlüssel";
            this.Load += new System.EventHandler(this.frmSuchtgiftschrankSchlüssel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ucSuchtgiftschrankSchlüssel ucSuchtgiftschrankSchlüssel1;
    }
}