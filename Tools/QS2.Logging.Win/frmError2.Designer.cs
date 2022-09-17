namespace QS2.Logging
{
    partial class frmError2
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
            this.ucError21 = new QS2.Logging.ucError2();
            this.SuspendLayout();
            // 
            // ucError21
            // 
            this.ucError21.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucError21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucError21.Location = new System.Drawing.Point(0, 0);
            this.ucError21.Name = "ucError21";
            this.ucError21.Size = new System.Drawing.Size(755, 516);
            this.ucError21.TabIndex = 0;
            // 
            // frmError2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(755, 516);
            this.Controls.Add(this.ucError21);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmError2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Information";
            this.Load += new System.EventHandler(this.frmError_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ucError2 ucError21;
    }
}