namespace PMDS.GUI.Verordnungen
{
    partial class frmVOBestellungErfassenDetail
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
            this.ucVOBestellungErfassenDetail1 = new PMDS.GUI.Verordnungen.ucVOBestellungErfassenDetail();
            this.SuspendLayout();
            // 
            // ucVOBestellungErfassenDetail1
            // 
            this.ucVOBestellungErfassenDetail1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucVOBestellungErfassenDetail1.Location = new System.Drawing.Point(0, 0);
            this.ucVOBestellungErfassenDetail1.Name = "ucVOBestellungErfassenDetail1";
            this.ucVOBestellungErfassenDetail1.Size = new System.Drawing.Size(622, 615);
            this.ucVOBestellungErfassenDetail1.TabIndex = 0;
            // 
            // frmVOBestellungErfassenDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 615);
            this.Controls.Add(this.ucVOBestellungErfassenDetail1);
            this.Name = "frmVOBestellungErfassenDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bestelldaten erfassen";
            this.Load += new System.EventHandler(this.frmVOBestellungErfassen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ucVOBestellungErfassenDetail ucVOBestellungErfassenDetail1;
    }
}