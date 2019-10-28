namespace PMDS.GUI.ELGA
{
    partial class frmELGASearchDocuments
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
            this.contELGASearchDocuments1 = new PMDS.GUI.ELGA.contELGASearchDocuments();
            this.SuspendLayout();
            // 
            // contELGASearchDocuments1
            // 
            this.contELGASearchDocuments1.BackColor = System.Drawing.Color.White;
            this.contELGASearchDocuments1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contELGASearchDocuments1.Location = new System.Drawing.Point(0, 0);
            this.contELGASearchDocuments1.Name = "contELGASearchDocuments1";
            this.contELGASearchDocuments1.Size = new System.Drawing.Size(871, 466);
            this.contELGASearchDocuments1.TabIndex = 0;
            // 
            // frmELGASearchDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(871, 466);
            this.Controls.Add(this.contELGASearchDocuments1);
            this.Name = "frmELGASearchDocuments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ELGA - Suche Dokumente";
            this.Load += new System.EventHandler(this.FrmELGASearchDocuments_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public contELGASearchDocuments contELGASearchDocuments1;
    }
}