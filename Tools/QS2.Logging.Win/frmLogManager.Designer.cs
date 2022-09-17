namespace QS2.Logging
{
    partial class frmLogManager
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
            this.contLogViewer1 = new QS2.Logging.contLogViewer();
            this.SuspendLayout();
            // 
            // contLogViewer1
            // 
            this.contLogViewer1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.contLogViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contLogViewer1.Location = new System.Drawing.Point(0, 0);
            this.contLogViewer1.MinimumSize = new System.Drawing.Size(890, 500);
            this.contLogViewer1.Name = "contLogViewer1";
            this.contLogViewer1.Size = new System.Drawing.Size(924, 591);
            this.contLogViewer1.TabIndex = 0;
            // 
            // frmLogManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(924, 591);
            this.Controls.Add(this.contLogViewer1);
            this.DoubleBuffered = true;
            this.Name = "frmLogManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log-Manager";
            this.Load += new System.EventHandler(this.frmLogManag_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public QS2.Logging.contLogViewer contLogViewer1;
    }
}