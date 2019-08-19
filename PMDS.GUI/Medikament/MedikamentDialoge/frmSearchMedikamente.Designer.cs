namespace PMDS.GUI.Medikament
{
    partial class frmSearchMedikamente
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
            this.contSearchMedikamente1 = new PMDS.GUI.Medikament.contSearchMedikamente();
            this.SuspendLayout();
            // 
            // contSearchMedikamente1
            // 
            this.contSearchMedikamente1.BackColor = System.Drawing.Color.Transparent;
            this.contSearchMedikamente1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contSearchMedikamente1.Location = new System.Drawing.Point(0, 0);
            this.contSearchMedikamente1.Name = "contSearchMedikamente1";
            this.contSearchMedikamente1.Size = new System.Drawing.Size(738, 474);
            this.contSearchMedikamente1.TabIndex = 0;
            // 
            // frmSearchMedikamente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(738, 474);
            this.Controls.Add(this.contSearchMedikamente1);
            this.Name = "frmSearchMedikamente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Suche Medikamente";
            this.Load += new System.EventHandler(this.frmSearchMedikamente_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public contSearchMedikamente contSearchMedikamente1;

    }
}