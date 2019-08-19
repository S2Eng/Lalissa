namespace PMDS.GUI.Medikament
{
    partial class frmRezeptEintragMedDaten
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
            this.ucRezeptEintragMedDaten1 = new PMDS.GUI.Medikament.ucRezeptEintragMedDaten();
            this.SuspendLayout();
            // 
            // ucRezeptEintragMedDaten1
            // 
            this.ucRezeptEintragMedDaten1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRezeptEintragMedDaten1.Location = new System.Drawing.Point(0, 0);
            this.ucRezeptEintragMedDaten1.Name = "ucRezeptEintragMedDaten1";
            this.ucRezeptEintragMedDaten1.Size = new System.Drawing.Size(1393, 545);
            this.ucRezeptEintragMedDaten1.TabIndex = 0;
            // 
            // frmRezeptEintragMedDaten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1393, 545);
            this.Controls.Add(this.ucRezeptEintragMedDaten1);
            this.Name = "frmRezeptEintragMedDaten";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zuordnung Med.Daten - Medikamente";
            this.Load += new System.EventHandler(this.frmRezeptEintragMedDaten_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ucRezeptEintragMedDaten ucRezeptEintragMedDaten1;
    }
}