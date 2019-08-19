namespace PMDS.GUI.Klient
{
    partial class frmVerwaltungKlinikenUser
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
            this.ucVerwaltungKlinikenUser1 = new PMDS.GUI.Klient.ucVerwaltungKlinikenUser();
            this.SuspendLayout();
            // 
            // ucVerwaltungKlinikenUser1
            // 
            this.ucVerwaltungKlinikenUser1.BackColor = System.Drawing.Color.Transparent;
            this.ucVerwaltungKlinikenUser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucVerwaltungKlinikenUser1.Location = new System.Drawing.Point(0, 0);
            this.ucVerwaltungKlinikenUser1.Name = "ucVerwaltungKlinikenUser1";
            this.ucVerwaltungKlinikenUser1.Size = new System.Drawing.Size(1062, 582);
            this.ucVerwaltungKlinikenUser1.TabIndex = 0;
            // 
            // frmVerwaltungKlinikenUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1062, 582);
            this.Controls.Add(this.ucVerwaltungKlinikenUser1);
            this.Name = "frmVerwaltungKlinikenUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Verwaltung Einrichtungen und Benutzer";
            this.Load += new System.EventHandler(this.frmVerwaltungKlinikenPatienten_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ucVerwaltungKlinikenUser ucVerwaltungKlinikenUser1;
    }
}