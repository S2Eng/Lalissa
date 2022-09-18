namespace qs2.ui.print
{
    partial class frmCryCrystRepViewer
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
            this.contQryCrystRepViewer1 = new qs2.ui.print.contQryCrystRepViewer();
            this.SuspendLayout();
            // 
            // contQryCrystRepViewer1
            // 
            this.contQryCrystRepViewer1.BackColor = System.Drawing.Color.Transparent;
            this.contQryCrystRepViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contQryCrystRepViewer1.Location = new System.Drawing.Point(0, 0);
            this.contQryCrystRepViewer1.Name = "contQryCrystRepViewer1";
            this.contQryCrystRepViewer1.Size = new System.Drawing.Size(993, 596);
            this.contQryCrystRepViewer1.TabIndex = 0;
            // 
            // frmCryCrystRepViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(993, 596);
            this.Controls.Add(this.contQryCrystRepViewer1);
            this.Name = "frmCryCrystRepViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Report";
            this.Load += new System.EventHandler(this.frmCryCrystRepViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public contQryCrystRepViewer contQryCrystRepViewer1;

    }
}