namespace PMDS.GUI.Quickfilter
{
    partial class frmQuickfilter2
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
            this.contQuickfilter21 = new PMDS.GUI.Quickfilter.contQuickfilter2();
            this.SuspendLayout();
            // 
            // contQuickfilter21
            // 
            this.contQuickfilter21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contQuickfilter21.Location = new System.Drawing.Point(0, 0);
            this.contQuickfilter21.Name = "contQuickfilter21";
            this.contQuickfilter21.Size = new System.Drawing.Size(800, 450);
            this.contQuickfilter21.TabIndex = 0;
            // 
            // frmQuickfilter2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.contQuickfilter21);
            this.Name = "frmQuickfilter2";
            this.Text = "frmQuickfilter2";
            this.Load += new System.EventHandler(this.frmQuickfilter2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public contQuickfilter2 contQuickfilter21;
    }
}