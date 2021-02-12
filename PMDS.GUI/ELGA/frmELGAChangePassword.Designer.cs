namespace PMDS.GUI.ELGA
{
    partial class frmELGAChangePassword
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
            this.contELGAChangePassword1 = new PMDS.GUI.ELGA.contELGAChangePassword();
            this.SuspendLayout();
            // 
            // contELGAChangePassword1
            // 
            this.contELGAChangePassword1.BackColor = System.Drawing.Color.White;
            this.contELGAChangePassword1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contELGAChangePassword1.Location = new System.Drawing.Point(0, 0);
            this.contELGAChangePassword1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.contELGAChangePassword1.Name = "contELGAChangePassword1";
            this.contELGAChangePassword1.Size = new System.Drawing.Size(549, 164);
            this.contELGAChangePassword1.TabIndex = 0;
            this.contELGAChangePassword1.Load += new System.EventHandler(this.contELGAChangePassword1_Load);
            // 
            // frmELGAChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(549, 164);
            this.Controls.Add(this.contELGAChangePassword1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmELGAChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ELGA-Passwort ändern";
            this.Load += new System.EventHandler(this.FrmELGAChangePassword_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public contELGAChangePassword contELGAChangePassword1;
    }
}