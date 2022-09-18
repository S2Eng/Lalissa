namespace qs2.design.auto.print
{
    partial class frmPDFViewer
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
            this.contPDFViewer1 = new qs2.design.auto.contPDFViewer();
            this.SuspendLayout();
            // 
            // contPDFViewer1
            // 
            this.contPDFViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contPDFViewer1.Location = new System.Drawing.Point(0, 0);
            this.contPDFViewer1.Name = "contPDFViewer1";
            this.contPDFViewer1.Size = new System.Drawing.Size(1103, 776);
            this.contPDFViewer1.TabIndex = 0;
            // 
            // frmPDFViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 776);
            this.Controls.Add(this.contPDFViewer1);
            this.Name = "frmPDFViewer";
            this.Text = "frmPDFViewer";
            this.Load += new System.EventHandler(this.frmPDFViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private contPDFViewer contPDFViewer1;
    }
}