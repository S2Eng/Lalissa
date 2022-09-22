namespace qs2.sitemap.workflowAssist.form
{
    partial class frmAutoUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutoUI));
            this.panelAutoForm = new System.Windows.Forms.Panel();
            this.panelAllWhite = new System.Windows.Forms.Panel();
            this.ultraPictureBox1 = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.panelAllWhite.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAutoForm
            // 
            this.panelAutoForm.BackColor = System.Drawing.Color.Transparent;
            this.panelAutoForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAutoForm.Location = new System.Drawing.Point(0, 0);
            this.panelAutoForm.Name = "panelAutoForm";
            this.panelAutoForm.Size = new System.Drawing.Size(1114, 861);
            this.panelAutoForm.TabIndex = 0;
            // 
            // panelAllWhite
            // 
            this.panelAllWhite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAllWhite.BackColor = System.Drawing.Color.Transparent;
            this.panelAllWhite.Controls.Add(this.ultraPictureBox1);
            this.panelAllWhite.Location = new System.Drawing.Point(1, 1);
            this.panelAllWhite.Name = "panelAllWhite";
            this.panelAllWhite.Size = new System.Drawing.Size(1113, 860);
            this.panelAllWhite.TabIndex = 1;
            // 
            // ultraPictureBox1
            // 
            this.ultraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty;
            this.ultraPictureBox1.Image = ((object)(resources.GetObject("ultraPictureBox1.Image")));
            this.ultraPictureBox1.Location = new System.Drawing.Point(438, 286);
            this.ultraPictureBox1.Name = "ultraPictureBox1";
            this.ultraPictureBox1.Size = new System.Drawing.Size(218, 194);
            this.ultraPictureBox1.TabIndex = 0;
            // 
            // frmAutoUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1114, 861);
            this.Controls.Add(this.panelAllWhite);
            this.Controls.Add(this.panelAutoForm);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "frmAutoUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.panelAllWhite.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        public System.Windows.Forms.Panel panelAutoForm;
        public System.Windows.Forms.Panel panelAllWhite;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox ultraPictureBox1;
    }
}