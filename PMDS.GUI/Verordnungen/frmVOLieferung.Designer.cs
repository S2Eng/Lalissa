namespace PMDS.GUI.Verordnungen
{
    partial class frmVOLieferung
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
            this.ucVOLieferung1 = new PMDS.GUI.Verordnungen.ucVOLieferung();
            this.SuspendLayout();
            // 
            // ucVOLieferung1
            // 
            this.ucVOLieferung1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucVOLieferung1.Location = new System.Drawing.Point(0, 0);
            this.ucVOLieferung1.Name = "ucVOLieferung1";
            this.ucVOLieferung1.Size = new System.Drawing.Size(835, 531);
            this.ucVOLieferung1.TabIndex = 0;
            // 
            // frmVOLieferung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 531);
            this.Controls.Add(this.ucVOLieferung1);
            this.Name = "frmVOLieferung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Verordnungen Lieferungen";
            this.Load += new System.EventHandler(this.frmVOLieferung_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ucVOLieferung ucVOLieferung1;
    }
}