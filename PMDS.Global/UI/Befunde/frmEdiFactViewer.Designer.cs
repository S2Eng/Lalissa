namespace EDIFact
{
    partial class frmEdiFactViewer
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
            this.components = new System.ComponentModel.Container();
            this.contEdiFactViewer1 = new contEdiFactViewer();
            this.SuspendLayout();
            // 
            // contEdiFactViewer1
            // 
            this.contEdiFactViewer1.BackColor = System.Drawing.Color.White;
            this.contEdiFactViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contEdiFactViewer1.Location = new System.Drawing.Point(0, 0);
            this.contEdiFactViewer1.Name = "contEdiFactViewer1";
            this.contEdiFactViewer1.Size = new System.Drawing.Size(769, 633);
            this.contEdiFactViewer1.TabIndex = 0;
            // 
            // frmEdiFactViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(769, 633);
            this.Controls.Add(this.contEdiFactViewer1);
            this.Name = "frmEdiFactViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Befund";
            this.Load += new System.EventHandler(this.frmImportBefunde1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public contEdiFactViewer contEdiFactViewer1;
    }
}