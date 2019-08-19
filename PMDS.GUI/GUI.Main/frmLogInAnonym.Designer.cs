namespace PMDS.GUI.GUI.Main
{
    partial class frmLogInAnonym
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
            this.ucLogInAnonym1 = new PMDS.GUI.GUI.Main.ucLogInAnonym();
            this.SuspendLayout();
            // 
            // ucLogInAnonym1
            // 
            this.ucLogInAnonym1.BackColor = System.Drawing.Color.Transparent;
            this.ucLogInAnonym1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLogInAnonym1.Location = new System.Drawing.Point(0, 0);
            this.ucLogInAnonym1.Name = "ucLogInAnonym1";
            this.ucLogInAnonym1.Size = new System.Drawing.Size(349, 78);
            this.ucLogInAnonym1.TabIndex = 0;
            // 
            // frmLogInAnonym
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(349, 78);
            this.Controls.Add(this.ucLogInAnonym1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogInAnonym";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gruppenanmeldung";
            this.Load += new System.EventHandler(this.frmLogInAnonym_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ucLogInAnonym ucLogInAnonym1;

    }
}