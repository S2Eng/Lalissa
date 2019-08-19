namespace PMDS.GUI
{
    partial class ucBigRMMain
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
            this.btnKorrektur = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAbzeichnen = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnMorgen = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnCancel = new QS2.Desktop.ControlManagment.BaseButton();
            this.ucVKeyboardUniversal1 = new PMDS.GUI.BaseControls.ucVKeyboardUniversal();
            this.ucBigRM1 = new PMDS.GUI.BaseControls.ucBigRM();
            this.SuspendLayout();
            // 
            // btnKorrektur
            // 
            this.btnKorrektur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnKorrektur.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnKorrektur.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKorrektur.Location = new System.Drawing.Point(761, 737);
            this.btnKorrektur.Name = "btnKorrektur";
            this.btnKorrektur.Size = new System.Drawing.Size(164, 51);
            this.btnKorrektur.TabIndex = 8;
            this.btnKorrektur.Text = "Korrektur";
            this.btnKorrektur.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // btnAbzeichnen
            // 
            this.btnAbzeichnen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbzeichnen.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnAbzeichnen.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbzeichnen.Location = new System.Drawing.Point(941, 514);
            this.btnAbzeichnen.Name = "btnAbzeichnen";
            this.btnAbzeichnen.Size = new System.Drawing.Size(220, 51);
            this.btnAbzeichnen.TabIndex = 7;
            this.btnAbzeichnen.Text = "Abzeichnen";
            this.btnAbzeichnen.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnAbzeichnen.Click += new System.EventHandler(this.btnAbzeichnen_Click);
            // 
            // btnMorgen
            // 
            this.btnMorgen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMorgen.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnMorgen.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMorgen.Location = new System.Drawing.Point(941, 571);
            this.btnMorgen.Name = "btnMorgen";
            this.btnMorgen.Size = new System.Drawing.Size(220, 51);
            this.btnMorgen.TabIndex = 9;
            this.btnMorgen.Text = "Abzeichnen und morgen wieder";
            this.btnMorgen.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnMorgen.Visible = false;
            this.btnMorgen.Click += new System.EventHandler(this.btnMorgen_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ImageSize = new System.Drawing.Size(40, 40);
            this.btnCancel.Location = new System.Drawing.Point(941, 737);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(220, 51);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ucVKeyboardUniversal1
            // 
            this.ucVKeyboardUniversal1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucVKeyboardUniversal1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucVKeyboardUniversal1.Location = new System.Drawing.Point(12, 512);
            this.ucVKeyboardUniversal1.Name = "ucVKeyboardUniversal1";
            this.ucVKeyboardUniversal1.Size = new System.Drawing.Size(923, 286);
            this.ucVKeyboardUniversal1.TabIndex = 1;
            // 
            // ucBigRM1
            // 
            this.ucBigRM1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucBigRM1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucBigRM1.Location = new System.Drawing.Point(1, 2);
            this.ucBigRM1.Name = "ucBigRM1";
            this.ucBigRM1.Size = new System.Drawing.Size(1170, 502);
            this.ucBigRM1.TabIndex = 0;
            this.ucBigRM1.Load += new System.EventHandler(this.ucBigRM1_Load);
            // 
            // ucBigRMMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnMorgen);
            this.Controls.Add(this.btnKorrektur);
            this.Controls.Add(this.btnAbzeichnen);
            this.Controls.Add(this.ucVKeyboardUniversal1);
            this.Controls.Add(this.ucBigRM1);
            this.Name = "ucBigRMMain";
            this.Size = new System.Drawing.Size(1168, 796);
            this.Load += new System.EventHandler(this.frmBigRM_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private PMDS.GUI.BaseControls.ucBigRM ucBigRM1;
        private PMDS.GUI.BaseControls.ucVKeyboardUniversal ucVKeyboardUniversal1;
        private QS2.Desktop.ControlManagment.BaseButton btnKorrektur;
        private QS2.Desktop.ControlManagment.BaseButton btnAbzeichnen;
        private QS2.Desktop.ControlManagment.BaseButton btnMorgen;
        private QS2.Desktop.ControlManagment.BaseButton btnCancel;
    }
}