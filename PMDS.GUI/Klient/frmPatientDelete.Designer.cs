namespace PMDS.GUI.Klient
{
    partial class frmPatientDelete
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
            this.contPatientDelete1 = new PMDS.GUI.Klient.contPatientDelete();
            this.SuspendLayout();
            // 
            // contPatientDelete1
            // 
            this.contPatientDelete1.BackColor = System.Drawing.Color.Transparent;
            this.contPatientDelete1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contPatientDelete1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contPatientDelete1.Location = new System.Drawing.Point(0, 0);
            this.contPatientDelete1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.contPatientDelete1.Name = "contPatientDelete1";
            this.contPatientDelete1.Size = new System.Drawing.Size(784, 225);
            this.contPatientDelete1.TabIndex = 0;
            // 
            // frmPatientDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 225);
            this.Controls.Add(this.contPatientDelete1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPatientDelete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Patient und Aufenthalte löschen";
            this.Load += new System.EventHandler(this.frmPatientDelete_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public contPatientDelete contPatientDelete1;
    }
}