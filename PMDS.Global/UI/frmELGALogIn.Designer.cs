namespace PMDS.GUI.ELGA
{
    partial class frmELGALogIn
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
            this.contELGALogIn1 = new PMDS.GUI.ELGA.contELGALogIn();
            this.SuspendLayout();
            // 
            // contELGALogIn1
            // 
            this.contELGALogIn1.BackColor = System.Drawing.Color.White;
            this.contELGALogIn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contELGALogIn1.Location = new System.Drawing.Point(0, 0);
            this.contELGALogIn1.Name = "contELGALogIn1";
            this.contELGALogIn1.Size = new System.Drawing.Size(383, 111);
            this.contELGALogIn1.TabIndex = 0;
            // 
            // frmELGALogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(383, 111);
            this.Controls.Add(this.contELGALogIn1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmELGALogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ELGA LogIn";
            this.Load += new System.EventHandler(this.frmELGALogIn_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public contELGALogIn contELGALogIn1;
    }
}