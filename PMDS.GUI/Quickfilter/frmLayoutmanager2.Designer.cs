namespace PMDS.GUI.Quickfilter
{
    partial class frmLayoutmanager2
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
            this.contLayoutmanager21 = new PMDS.GUI.Quickfilter.contLayoutmanager2();
            this.SuspendLayout();
            // 
            // contLayoutmanager21
            // 
            this.contLayoutmanager21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contLayoutmanager21.Location = new System.Drawing.Point(0, 0);
            this.contLayoutmanager21.Name = "contLayoutmanager21";
            this.contLayoutmanager21.Size = new System.Drawing.Size(800, 450);
            this.contLayoutmanager21.TabIndex = 0;
            // 
            // frmLayoutmanager2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.contLayoutmanager21);
            this.Name = "frmLayoutmanager2";
            this.Text = "frmLayoutmanager2";
            this.Load += new System.EventHandler(this.frmLayoutmanager2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public contLayoutmanager2 contLayoutmanager21;
    }
}