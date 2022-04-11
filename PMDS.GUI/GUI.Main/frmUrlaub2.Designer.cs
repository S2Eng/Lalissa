namespace PMDS.GUI.GUI.Main
{
    partial class frmUrlaub2
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
            this.ucUrlaub21 = new PMDS.GUI.GUI.Main.ucUrlaub2();
            this.SuspendLayout();
            // 
            // ucUrlaub21
            // 
            this.ucUrlaub21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucUrlaub21.Location = new System.Drawing.Point(0, 0);
            this.ucUrlaub21.Name = "ucUrlaub21";
            this.ucUrlaub21.Size = new System.Drawing.Size(499, 228);
            this.ucUrlaub21.TabIndex = 0;
            // 
            // frmUrlaub2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 228);
            this.Controls.Add(this.ucUrlaub21);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUrlaub2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Urlaub";
            this.Load += new System.EventHandler(this.frmUrlaub2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ucUrlaub2 ucUrlaub21;
    }
}