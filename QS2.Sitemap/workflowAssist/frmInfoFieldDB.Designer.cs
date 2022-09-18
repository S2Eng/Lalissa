namespace qs2.sitemap.workflowAssist
{
    partial class frmInfoFieldDB
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
            this.contInfoFieldDB1 = new qs2.sitemap.workflowAssist.contInfoFieldDB();
            this.SuspendLayout();
            // 
            // contInfoFieldDB1
            // 
            this.contInfoFieldDB1.BackColor = System.Drawing.Color.Transparent;
            this.contInfoFieldDB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contInfoFieldDB1.Location = new System.Drawing.Point(0, 0);
            this.contInfoFieldDB1.Name = "contInfoFieldDB1";
            this.contInfoFieldDB1.Size = new System.Drawing.Size(935, 365);
            this.contInfoFieldDB1.TabIndex = 0;
            // 
            // frmInfoFieldDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(935, 365);
            this.Controls.Add(this.contInfoFieldDB1);
            this.Name = "frmInfoFieldDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Info Fields-Database";
            this.Load += new System.EventHandler(this.frmInfoFieldDB2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public contInfoFieldDB contInfoFieldDB1;

    }
}