namespace QS2.Logging.Win
{
    partial class frmLogManager2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogManager2));
            this.contLogManager21 = new QS2.Logging.Win.contLogManager2();
            this.SuspendLayout();
            // 
            // contLogManager21
            // 
            this.contLogManager21.BackColor = System.Drawing.Color.White;
            this.contLogManager21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contLogManager21.Location = new System.Drawing.Point(0, 0);
            this.contLogManager21.Name = "contLogManager21";
            this.contLogManager21.Size = new System.Drawing.Size(900, 570);
            this.contLogManager21.TabIndex = 0;
            // 
            // frmLogManager2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 570);
            this.Controls.Add(this.contLogManager21);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogManager2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "QS2 Log-Manager";
            this.Load += new System.EventHandler(this.frmLogManager2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private contLogManager2 contLogManager21;
    }
}