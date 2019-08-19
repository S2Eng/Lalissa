namespace PMDS.GUI.Calc.Calc.UI.Other
{
    partial class frmListePatientenEntlassen
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
            this.contListePatientenEntlassen1 = new PMDS.GUI.Calc.Calc.UI.Other.contListePatientenEntlassen();
            this.SuspendLayout();
            // 
            // contListePatientenEntlassen1
            // 
            this.contListePatientenEntlassen1.BackColor = System.Drawing.Color.Transparent;
            this.contListePatientenEntlassen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contListePatientenEntlassen1.Location = new System.Drawing.Point(0, 0);
            this.contListePatientenEntlassen1.Name = "contListePatientenEntlassen1";
            this.contListePatientenEntlassen1.Size = new System.Drawing.Size(782, 458);
            this.contListePatientenEntlassen1.TabIndex = 0;
            // 
            // frmListePatientenEntlassen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(782, 458);
            this.Controls.Add(this.contListePatientenEntlassen1);
            this.Name = "frmListePatientenEntlassen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Liste Patienten entlassen";
            this.Load += new System.EventHandler(this.frmListePatientenEntlassen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private contListePatientenEntlassen contListePatientenEntlassen1;
    }
}