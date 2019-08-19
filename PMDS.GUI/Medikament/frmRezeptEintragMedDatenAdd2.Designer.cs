namespace PMDS.GUI.Medikament
{
    partial class frmRezeptEintragMedDatenAdd2
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
            this.ucRezeptEintragMedDatenAdd1 = new PMDS.GUI.Medikament.ucRezeptEintragMedDatenAdd();
            this.SuspendLayout();
            // 
            // ucRezeptEintragMedDatenAdd1
            // 
            this.ucRezeptEintragMedDatenAdd1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRezeptEintragMedDatenAdd1.Location = new System.Drawing.Point(0, 0);
            this.ucRezeptEintragMedDatenAdd1.Name = "ucRezeptEintragMedDatenAdd1";
            this.ucRezeptEintragMedDatenAdd1.Size = new System.Drawing.Size(1373, 511);
            this.ucRezeptEintragMedDatenAdd1.TabIndex = 0;
            // 
            // frmRezeptEintragMedDatenAdd2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1373, 511);
            this.Controls.Add(this.ucRezeptEintragMedDatenAdd1);
            this.Name = "frmRezeptEintragMedDatenAdd2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Med. Daten - Medikamente zuordnen";
            this.Load += new System.EventHandler(this.frmRezeptEintragMedDatenAdd2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ucRezeptEintragMedDatenAdd ucRezeptEintragMedDatenAdd1;
    }
}