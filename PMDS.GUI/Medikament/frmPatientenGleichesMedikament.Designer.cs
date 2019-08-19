namespace PMDS.GUI.Medikament
{
    partial class frmPatientenGleichesMedikament
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
            this.ucPatientenGleichesMedikament1 = new PMDS.GUI.Medikament.ucPatientenGleichesMedikament();
            this.SuspendLayout();
            // 
            // ucPatientenGleichesMedikament1
            // 
            this.ucPatientenGleichesMedikament1.BackColor = System.Drawing.Color.White;
            this.ucPatientenGleichesMedikament1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPatientenGleichesMedikament1.Location = new System.Drawing.Point(0, 0);
            this.ucPatientenGleichesMedikament1.Name = "ucPatientenGleichesMedikament1";
            this.ucPatientenGleichesMedikament1.Size = new System.Drawing.Size(359, 392);
            this.ucPatientenGleichesMedikament1.TabIndex = 0;
            // 
            // frmPatientenGleichesMedikament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 392);
            this.Controls.Add(this.ucPatientenGleichesMedikament1);
            this.Name = "frmPatientenGleichesMedikament";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Klient mit gleichem Medikament";
            this.Load += new System.EventHandler(this.frmPatientenGleichesMedikament_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucPatientenGleichesMedikament ucPatientenGleichesMedikament1;
    }
}