namespace PMDS.GUI.Arztabrechnung
{
    partial class frmArztabrechnungDetail
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
            this.contArztabrechnung1 = new PMDS.GUI.Arztabrechnung.contArztabrechnungDetail();
            this.SuspendLayout();
            // 
            // contArztabrechnung1
            // 
            this.contArztabrechnung1.BackColor = System.Drawing.Color.White;
            this.contArztabrechnung1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contArztabrechnung1.Location = new System.Drawing.Point(0, 0);
            this.contArztabrechnung1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.contArztabrechnung1.Name = "contArztabrechnung1";
            this.contArztabrechnung1.Size = new System.Drawing.Size(1044, 706);
            this.contArztabrechnung1.TabIndex = 0;
            // 
            // frmArztabrechnungDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 706);
            this.Controls.Add(this.contArztabrechnung1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmArztabrechnungDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Arztabrechnung";
            this.Load += new System.EventHandler(this.frmArztabrechnungcs_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public contArztabrechnungDetail contArztabrechnung1;
    }
}