namespace PMDS.GUI.Arztabrechnung
{
    partial class frmArztabrechnungManage
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
            this.contArztabrechnungManage1 = new PMDS.GUI.Arztabrechnung.contArztabrechnungManage();
            this.SuspendLayout();
            // 
            // contArztabrechnungManage1
            // 
            this.contArztabrechnungManage1.BackColor = System.Drawing.Color.White;
            this.contArztabrechnungManage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contArztabrechnungManage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contArztabrechnungManage1.Location = new System.Drawing.Point(0, 0);
            this.contArztabrechnungManage1.Margin = new System.Windows.Forms.Padding(4);
            this.contArztabrechnungManage1.Name = "contArztabrechnungManage1";
            this.contArztabrechnungManage1.Size = new System.Drawing.Size(1209, 636);
            this.contArztabrechnungManage1.TabIndex = 0;
            // 
            // frmArztabrechnungManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 636);
            this.Controls.Add(this.contArztabrechnungManage1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmArztabrechnungManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Arztabrechnungen";
            this.Load += new System.EventHandler(this.frmArztabrechnungManage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public contArztabrechnungManage contArztabrechnungManage1;
    }
}