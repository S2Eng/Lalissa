namespace PMDS.GUI.Verordnungen
{
    partial class frmVOErfassen
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
            this.ucVOErfassen1 = new PMDS.GUI.Verordnungen.ucVOErfassen();
            this.SuspendLayout();
            // 
            // ucVOErfassen1
            // 
            this.ucVOErfassen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucVOErfassen1.Location = new System.Drawing.Point(0, 0);
            this.ucVOErfassen1.Name = "ucVOErfassen1";
            this.ucVOErfassen1.Size = new System.Drawing.Size(1219, 686);
            this.ucVOErfassen1.TabIndex = 0;
            // 
            // frmVOErfassen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 686);
            this.Controls.Add(this.ucVOErfassen1);
            this.Name = "frmVOErfassen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Verordnungen erfassen";
            this.Load += new System.EventHandler(this.frmVOErfassen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ucVOErfassen ucVOErfassen1;
    }
}