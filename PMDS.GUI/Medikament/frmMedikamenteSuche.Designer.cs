namespace PMDS.GUI.Medikament
{
    partial class frmMedikamenteSuche
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
            this.ucMedikamenteSuche1 = new PMDS.GUI.Medikament.ucMedikamenteSuche();
            this.SuspendLayout();
            // 
            // ucMedikamenteSuche1
            // 
            this.ucMedikamenteSuche1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMedikamenteSuche1.Location = new System.Drawing.Point(0, 0);
            this.ucMedikamenteSuche1.Name = "ucMedikamenteSuche1";
            this.ucMedikamenteSuche1.Size = new System.Drawing.Size(660, 541);
            this.ucMedikamenteSuche1.TabIndex = 0;
            // 
            // frmMedikamenteSuche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 541);
            this.Controls.Add(this.ucMedikamenteSuche1);
            this.Name = "frmMedikamenteSuche";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Medikamente suchen";
            this.Load += new System.EventHandler(this.frmMedikamenteSuche_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ucMedikamenteSuche ucMedikamenteSuche1;
    }
}