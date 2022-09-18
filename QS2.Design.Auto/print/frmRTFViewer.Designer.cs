namespace qs2.design.auto.print
{
    partial class frmRTFViewer
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
            this.contRTFViewer1 = new qs2.design.auto.print.contRTFViewer();
            this.SuspendLayout();
            // 
            // contRTFViewer1
            // 
            this.contRTFViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contRTFViewer1.Location = new System.Drawing.Point(0, 0);
            this.contRTFViewer1.Name = "contRTFViewer1";
            this.contRTFViewer1.Size = new System.Drawing.Size(952, 677);
            this.contRTFViewer1.TabIndex = 0;
            this.contRTFViewer1.Load += new System.EventHandler(this.contRTFViewer1_Load);
            // 
            // frmRTFViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 677);
            this.Controls.Add(this.contRTFViewer1);
            this.Name = "frmRTFViewer";
            this.Text = "frmRTFViewer";
            this.Shown += new System.EventHandler(this.frmRTFViewer_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private contRTFViewer contRTFViewer1;
    }
}