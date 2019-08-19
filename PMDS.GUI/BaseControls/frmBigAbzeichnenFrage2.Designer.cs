namespace PMDS.GUI.BaseControls
{
    partial class frmBigAbzeichnenFrage2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBigAbzeichnenFrage2));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.btnCancel = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnMorgen = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAbzeichnen = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDialog = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblAbzeichnen = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblText = new QS2.Desktop.ControlManagment.BaseLabel();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            this.btnCancel.Appearance = appearance1;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ImageSize = new System.Drawing.Size(40, 40);
            this.btnCancel.IsStandardControl = false;
            this.btnCancel.Location = new System.Drawing.Point(276, 304);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(257, 51);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Tag = "Abbrechen";
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCancel.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnMorgen
            // 
            this.btnMorgen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            this.btnMorgen.Appearance = appearance2;
            this.btnMorgen.AutoWorkLayout = false;
            this.btnMorgen.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnMorgen.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMorgen.ImageSize = new System.Drawing.Size(40, 40);
            this.btnMorgen.ImageTransparentColor = System.Drawing.Color.White;
            this.btnMorgen.IsStandardControl = false;
            this.btnMorgen.Location = new System.Drawing.Point(276, 246);
            this.btnMorgen.Name = "btnMorgen";
            this.btnMorgen.Size = new System.Drawing.Size(257, 51);
            this.btnMorgen.TabIndex = 12;
            this.btnMorgen.Tag = "Morgen";
            this.btnMorgen.Text = "Abzeichnen und morgen wieder";
            this.btnMorgen.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnMorgen.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnAbzeichnen
            // 
            this.btnAbzeichnen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            this.btnAbzeichnen.Appearance = appearance3;
            this.btnAbzeichnen.AutoWorkLayout = false;
            this.btnAbzeichnen.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnAbzeichnen.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbzeichnen.ImageSize = new System.Drawing.Size(40, 40);
            this.btnAbzeichnen.ImageTransparentColor = System.Drawing.Color.White;
            this.btnAbzeichnen.IsStandardControl = false;
            this.btnAbzeichnen.Location = new System.Drawing.Point(13, 246);
            this.btnAbzeichnen.Name = "btnAbzeichnen";
            this.btnAbzeichnen.Size = new System.Drawing.Size(257, 51);
            this.btnAbzeichnen.TabIndex = 11;
            this.btnAbzeichnen.Tag = "Abzeichnen";
            this.btnAbzeichnen.Text = "Abzeichnen";
            this.btnAbzeichnen.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnAbzeichnen.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnDialog
            // 
            this.btnDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            this.btnDialog.Appearance = appearance4;
            this.btnDialog.AutoWorkLayout = false;
            this.btnDialog.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnDialog.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDialog.ImageSize = new System.Drawing.Size(40, 40);
            this.btnDialog.ImageTransparentColor = System.Drawing.Color.White;
            this.btnDialog.IsStandardControl = false;
            this.btnDialog.Location = new System.Drawing.Point(11, 304);
            this.btnDialog.Name = "btnDialog";
            this.btnDialog.Size = new System.Drawing.Size(257, 51);
            this.btnDialog.TabIndex = 14;
            this.btnDialog.Tag = "Dialog";
            this.btnDialog.Text = "Dialog";
            this.btnDialog.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnDialog.Click += new System.EventHandler(this.btn_Click);
            // 
            // ultraLabel1
            // 
            appearance5.BorderColor = System.Drawing.Color.Gray;
            this.ultraLabel1.Appearance = appearance5;
            this.ultraLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel1.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraLabel1.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(545, 364);
            this.ultraLabel1.TabIndex = 15;
            // 
            // lblAbzeichnen
            // 
            appearance6.BackColor = System.Drawing.Color.Silver;
            appearance6.BackColor2 = System.Drawing.Color.Silver;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance6.TextHAlignAsString = "Left";
            appearance6.TextVAlignAsString = "Middle";
            this.lblAbzeichnen.Appearance = appearance6;
            this.lblAbzeichnen.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblAbzeichnen.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblAbzeichnen.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAbzeichnen.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbzeichnen.ImageSize = new System.Drawing.Size(50, 50);
            this.lblAbzeichnen.Location = new System.Drawing.Point(0, 0);
            this.lblAbzeichnen.Name = "lblAbzeichnen";
            this.lblAbzeichnen.Size = new System.Drawing.Size(545, 63);
            this.lblAbzeichnen.TabIndex = 16;
            this.lblAbzeichnen.Text = " Abzeichnen";
            // 
            // lblText
            // 
            appearance7.TextHAlignAsString = "Center";
            appearance7.TextVAlignAsString = "Middle";
            this.lblText.Appearance = appearance7;
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(13, 70);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(520, 151);
            this.lblText.TabIndex = 18;
            // 
            // frmBigAbzeichnenFrage2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(545, 364);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblAbzeichnen);
            this.Controls.Add(this.btnMorgen);
            this.Controls.Add(this.btnDialog);
            this.Controls.Add(this.btnAbzeichnen);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.ultraLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBigAbzeichnenFrage2";
            this.ShowInTaskbar = false;
            this.Text = "Abzeichnen";
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseButton btnCancel;
        private QS2.Desktop.ControlManagment.BaseButton btnMorgen;
        private QS2.Desktop.ControlManagment.BaseButton btnAbzeichnen;
        private QS2.Desktop.ControlManagment.BaseButton btnDialog;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel1;
        private QS2.Desktop.ControlManagment.BaseLabel lblAbzeichnen;
        private QS2.Desktop.ControlManagment.BaseLabel lblText;
    }
}