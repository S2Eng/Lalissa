namespace QS2.Logging
{
    partial class frmError
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
            this.ucError1 = new QS2.Logging.ucError();
            this.SuspendLayout();
            // 
            // ucError1
            // 
            this.ucError1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucError1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucError1.Location = new System.Drawing.Point(0, 0);
            this.ucError1.Name = "ucError1";
            this.ucError1.Size = new System.Drawing.Size(755, 516);
            this.ucError1.TabIndex = 0;
            // 
            // frmError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(755, 516);
            this.Controls.Add(this.ucError1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmError";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Information";
            this.Load += new System.EventHandler(this.frmError_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public QS2.Logging.ucError ucError1;

    }
}