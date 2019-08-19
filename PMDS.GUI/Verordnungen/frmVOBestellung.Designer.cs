namespace PMDS.GUI.Verordnungen
{
    partial class frmVOBestellung
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
            this.ucVOBestellung1 = new PMDS.GUI.Verordnungen.ucVOBestellung();
            this.SuspendLayout();
            // 
            // ucVOBestellung1
            // 
            this.ucVOBestellung1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucVOBestellung1.Location = new System.Drawing.Point(0, 0);
            this.ucVOBestellung1.Name = "ucVOBestellung1";
            this.ucVOBestellung1.Size = new System.Drawing.Size(780, 569);
            this.ucVOBestellung1.TabIndex = 0;
            // 
            // frmVOBestellung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 569);
            this.Controls.Add(this.ucVOBestellung1);
            this.Name = "frmVOBestellung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Verordnungen Bestelldaten";
            this.Load += new System.EventHandler(this.frmVOBestelldaten_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ucVOBestellung ucVOBestellung1;
    }
}