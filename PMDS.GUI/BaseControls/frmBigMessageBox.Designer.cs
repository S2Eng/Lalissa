namespace PMDS.GUI.BaseControls
{
    partial class frmBigMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBigMessageBox));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.btnCancel = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnJa = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnOK = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnNein = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblHeader = new QS2.Desktop.ControlManagment.BaseLabel();
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
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ImageSize = new System.Drawing.Size(40, 40);
            this.btnCancel.IsStandardControl = false;
            this.btnCancel.Location = new System.Drawing.Point(15, 301);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(257, 51);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Tag = "Abbrechen";
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCancel.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnJa
            // 
            this.btnJa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnJa.AutoWorkLayout = false;
            this.btnJa.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnJa.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJa.ImageSize = new System.Drawing.Size(40, 40);
            this.btnJa.ImageTransparentColor = System.Drawing.Color.White;
            this.btnJa.IsStandardControl = false;
            this.btnJa.Location = new System.Drawing.Point(276, 246);
            this.btnJa.Name = "btnJa";
            this.btnJa.Size = new System.Drawing.Size(257, 51);
            this.btnJa.TabIndex = 12;
            this.btnJa.Tag = "Ja";
            this.btnJa.Text = "Ja";
            this.btnJa.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnJa.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            this.btnOK.Appearance = appearance2;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ImageSize = new System.Drawing.Size(40, 40);
            this.btnOK.ImageTransparentColor = System.Drawing.Color.White;
            this.btnOK.IsStandardControl = false;
            this.btnOK.Location = new System.Drawing.Point(276, 301);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(257, 51);
            this.btnOK.TabIndex = 11;
            this.btnOK.Tag = "OK";
            this.btnOK.Text = "OK";
            this.btnOK.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnOK.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnNein
            // 
            this.btnNein.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNein.AutoWorkLayout = false;
            this.btnNein.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnNein.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNein.ImageSize = new System.Drawing.Size(40, 40);
            this.btnNein.ImageTransparentColor = System.Drawing.Color.White;
            this.btnNein.IsStandardControl = false;
            this.btnNein.Location = new System.Drawing.Point(15, 246);
            this.btnNein.Name = "btnNein";
            this.btnNein.Size = new System.Drawing.Size(257, 51);
            this.btnNein.TabIndex = 14;
            this.btnNein.Tag = "Nein";
            this.btnNein.Text = "Nein";
            this.btnNein.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnNein.Click += new System.EventHandler(this.btn_Click);
            // 
            // ultraLabel1
            // 
            appearance3.BorderColor = System.Drawing.Color.Gray;
            this.ultraLabel1.Appearance = appearance3;
            this.ultraLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel1.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraLabel1.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(545, 364);
            this.ultraLabel1.TabIndex = 15;
            // 
            // lblHeader
            // 
            appearance4.BackColor = System.Drawing.Color.Silver;
            appearance4.BackColor2 = System.Drawing.Color.Silver;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.lblHeader.Appearance = appearance4;
            this.lblHeader.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblHeader.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ImageSize = new System.Drawing.Size(50, 50);
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(545, 63);
            this.lblHeader.TabIndex = 16;
            this.lblHeader.Text = "****";
            // 
            // lblText
            // 
            appearance5.TextHAlignAsString = "Center";
            appearance5.TextVAlignAsString = "Middle";
            this.lblText.Appearance = appearance5;
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(13, 70);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(520, 151);
            this.lblText.TabIndex = 18;
            // 
            // frmBigMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(545, 364);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.btnJa);
            this.Controls.Add(this.btnNein);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.ultraLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBigMessageBox";
            this.ShowInTaskbar = false;
            this.Text = "Abzeichnen";
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseButton btnCancel;
        private QS2.Desktop.ControlManagment.BaseButton btnJa;
        private QS2.Desktop.ControlManagment.BaseButton btnOK;
        private QS2.Desktop.ControlManagment.BaseButton btnNein;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel1;
        private QS2.Desktop.ControlManagment.BaseLabel lblHeader;
        private QS2.Desktop.ControlManagment.BaseLabel lblText;
    }
}