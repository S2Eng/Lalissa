namespace PMDS.GUI.Verordnungen
{
    partial class frmVOBestellvorschlaegeDetail
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
            this.ucVOBestellvorschlaegeDetail1 = new PMDS.GUI.Verordnungen.ucVOBestellvorschlaegeDetail();
            this.SuspendLayout();
            // 
            // ucVOBestellvorschlaegeDetail1
            // 
            this.ucVOBestellvorschlaegeDetail1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucVOBestellvorschlaegeDetail1.Location = new System.Drawing.Point(0, 0);
            this.ucVOBestellvorschlaegeDetail1.Name = "ucVOBestellvorschlaegeDetail1";
            this.ucVOBestellvorschlaegeDetail1.Size = new System.Drawing.Size(602, 402);
            this.ucVOBestellvorschlaegeDetail1.TabIndex = 0;
            // 
            // frmVOBestellvorschlaegeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 402);
            this.Controls.Add(this.ucVOBestellvorschlaegeDetail1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVOBestellvorschlaegeDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bestellvorschlag Detail";
            this.Load += new System.EventHandler(this.frmVOBestelldatenDetail_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ucVOBestellvorschlaegeDetail ucVOBestellvorschlaegeDetail1;
    }
}