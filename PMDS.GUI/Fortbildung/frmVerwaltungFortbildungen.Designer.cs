namespace PMDS.GUI.Fortbildung
{
    partial class frmVerwaltungFortbildungen
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
            this.ucVerwaltungFortbildungen1 = new PMDS.GUI.Fortbildung.ucVerwaltungFortbildungen();
            this.SuspendLayout();
            // 
            // ucVerwaltungFortbildungen1
            // 
            this.ucVerwaltungFortbildungen1.BackColor = System.Drawing.Color.Transparent;
            this.ucVerwaltungFortbildungen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucVerwaltungFortbildungen1.Location = new System.Drawing.Point(0, 0);
            this.ucVerwaltungFortbildungen1.Margin = new System.Windows.Forms.Padding(4);
            this.ucVerwaltungFortbildungen1.Name = "ucVerwaltungFortbildungen1";
            this.ucVerwaltungFortbildungen1.Size = new System.Drawing.Size(1084, 761);
            this.ucVerwaltungFortbildungen1.TabIndex = 0;
            // 
            // frmVerwaltungFortbildungen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1084, 761);
            this.Controls.Add(this.ucVerwaltungFortbildungen1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmVerwaltungFortbildungen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Verwaltung Fortbildungen";
            this.Load += new System.EventHandler(this.frmFortbildungen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucVerwaltungFortbildungen ucVerwaltungFortbildungen1;
    }
}