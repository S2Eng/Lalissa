namespace PMDS.GUI.GUI.Main
{
    partial class frmÄrzteMergen
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
            this.ucÄrzteMergen1 = new PMDS.GUI.GUI.Main.ucÄrzteMergen();
            this.SuspendLayout();
            // 
            // ucÄrzteMergen1
            // 
            this.ucÄrzteMergen1.BackColor = System.Drawing.Color.Transparent;
            this.ucÄrzteMergen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucÄrzteMergen1.Location = new System.Drawing.Point(0, 0);
            this.ucÄrzteMergen1.Name = "ucÄrzteMergen1";
            this.ucÄrzteMergen1.Size = new System.Drawing.Size(1036, 594);
            this.ucÄrzteMergen1.TabIndex = 0;
            // 
            // frmÄrzteMergen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1036, 594);
            this.Controls.Add(this.ucÄrzteMergen1);
            this.Name = "frmÄrzteMergen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ärzte zusammenführen";
            this.Load += new System.EventHandler(this.frmÄrzteMergen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucÄrzteMergen ucÄrzteMergen1;
    }
}