namespace PMDS.GUI.GUI.Main
{
    partial class frmDekurseListe
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
            this.ucDekurseListe1 = new PMDS.GUI.GUI.Main.ucDekurseListe();
            this.SuspendLayout();
            // 
            // ucDekurseListe1
            // 
            this.ucDekurseListe1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDekurseListe1.Location = new System.Drawing.Point(0, 0);
            this.ucDekurseListe1.Name = "ucDekurseListe1";
            this.ucDekurseListe1.Size = new System.Drawing.Size(1037, 388);
            this.ucDekurseListe1.TabIndex = 0;
            // 
            // frmDekurseListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 388);
            this.Controls.Add(this.ucDekurseListe1);
            this.Name = "frmDekurseListe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Liste Dekurse Entwürfe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDekurseListe_FormClosing);
            this.Load += new System.EventHandler(this.frmDekurseListe_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ucDekurseListe ucDekurseListe1;
    }
}