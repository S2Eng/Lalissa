namespace PMDS.GUI
{
    partial class frmQM
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.btnExit = new QS2.Desktop.ControlManagment.BaseButton();
            this.ucQM1 = new PMDS.GUI.ucQM();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnExit.Appearance = appearance1;
            this.btnExit.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ImageSize = new System.Drawing.Size(60, 60);
            this.btnExit.Location = new System.Drawing.Point(659, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(211, 94);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Beenden";
            this.btnExit.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ucQM1
            // 
            this.ucQM1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucQM1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucQM1.Location = new System.Drawing.Point(0, 0);
            this.ucQM1.Name = "ucQM1";
            this.ucQM1.Size = new System.Drawing.Size(875, 686);
            this.ucQM1.TabIndex = 0;
            this.ucQM1.Load += new System.EventHandler(this.ucQM1_Load);
            // 
            // frmQM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 686);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.ucQM1);
            this.Name = "frmQM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Klientenmeldungen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmQM_Load);
            this.LocationChanged += new System.EventHandler(this.frmQM_LocationChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private ucQM ucQM1;
        private QS2.Desktop.ControlManagment.BaseButton btnExit;
    }
}