namespace PMDS.Calc.UI.Admin
{
    partial class ucHeaderCalc
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucHeaderCalc));
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            this.uGroupBoxHeader = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.ucKlinikCbo1 = new PMDS.GUI.BaseControls.ucKlinikCbo();
            this.panelStmmdatenBerichte = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnStammdaten = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnBerichte = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraLabel5 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelBuchhaltung = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnBuchhaltung = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelLine = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelDepot = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnDepot = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelSr = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnSammelabrechnung2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelKlient = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnAbrechnungPatient = new QS2.Desktop.ControlManagment.BaseButton();
            this.uGridBagLayPanelMedizinDaten = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.ucMedizinDaten1 = new PMDS.GUI.BaseControls.ucMedizinDaten();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.uGroupBoxHeader)).BeginInit();
            this.uGroupBoxHeader.SuspendLayout();
            this.panelStmmdatenBerichte.SuspendLayout();
            this.panelBuchhaltung.SuspendLayout();
            this.panelLine.SuspendLayout();
            this.panelDepot.SuspendLayout();
            this.panelSr.SuspendLayout();
            this.panelKlient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGridBagLayPanelMedizinDaten)).BeginInit();
            this.uGridBagLayPanelMedizinDaten.SuspendLayout();
            this.SuspendLayout();
            // 
            // uGroupBoxHeader
            // 
            appearance1.BackColor = System.Drawing.Color.Gray;
            this.uGroupBoxHeader.Appearance = appearance1;
            this.uGroupBoxHeader.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BackColor2 = System.Drawing.Color.Silver;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.GlassTop37Bright;
            appearance2.BackHatchStyle = Infragistics.Win.BackHatchStyle.Horizontal;
            this.uGroupBoxHeader.ContentAreaAppearance = appearance2;
            this.uGroupBoxHeader.Controls.Add(this.ucKlinikCbo1);
            this.uGroupBoxHeader.Controls.Add(this.panelStmmdatenBerichte);
            this.uGroupBoxHeader.Controls.Add(this.panelBuchhaltung);
            this.uGroupBoxHeader.Controls.Add(this.panelLine);
            this.uGroupBoxHeader.Controls.Add(this.panelDepot);
            this.uGroupBoxHeader.Controls.Add(this.panelSr);
            this.uGroupBoxHeader.Controls.Add(this.panelKlient);
            this.uGroupBoxHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGroupBoxHeader.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uGroupBoxHeader.Location = new System.Drawing.Point(0, 0);
            this.uGroupBoxHeader.Name = "uGroupBoxHeader";
            this.uGroupBoxHeader.Size = new System.Drawing.Size(945, 65);
            this.uGroupBoxHeader.TabIndex = 28;
            this.uGroupBoxHeader.UseAppStyling = false;
            this.uGroupBoxHeader.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005;
            // 
            // ucKlinikCbo1
            // 
            this.ucKlinikCbo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucKlinikCbo1.BackColor = System.Drawing.Color.Transparent;
            this.ucKlinikCbo1.Location = new System.Drawing.Point(660, 9);
            this.ucKlinikCbo1.Name = "ucKlinikCbo1";
            this.ucKlinikCbo1.Size = new System.Drawing.Size(283, 44);
            this.ucKlinikCbo1.TabIndex = 103;
            this.ucKlinikCbo1.typUI = PMDS.GUI.BaseControls.ucKlinikCbo.eTypUI.main;
            // 
            // panelStmmdatenBerichte
            // 
            this.panelStmmdatenBerichte.BackColor = System.Drawing.Color.Transparent;
            this.panelStmmdatenBerichte.Controls.Add(this.btnStammdaten);
            this.panelStmmdatenBerichte.Controls.Add(this.btnBerichte);
            this.panelStmmdatenBerichte.Controls.Add(this.ultraLabel5);
            this.panelStmmdatenBerichte.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelStmmdatenBerichte.Location = new System.Drawing.Point(453, 0);
            this.panelStmmdatenBerichte.Name = "panelStmmdatenBerichte";
            this.panelStmmdatenBerichte.Size = new System.Drawing.Size(203, 65);
            this.panelStmmdatenBerichte.TabIndex = 102;
            // 
            // btnStammdaten
            // 
            this.btnStammdaten.AcceptsFocus = false;
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.FontData.SizeInPoints = 8F;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Tiled;
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance3.TextVAlignAsString = "Middle";
            this.btnStammdaten.Appearance = appearance3;
            this.btnStammdaten.AutoWorkLayout = false;
            this.btnStammdaten.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnStammdaten.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStammdaten.ImageSize = new System.Drawing.Size(35, 35);
            this.btnStammdaten.IsStandardControl = false;
            this.btnStammdaten.Location = new System.Drawing.Point(3, 5);
            this.btnStammdaten.Name = "btnStammdaten";
            this.btnStammdaten.ShowFocusRect = false;
            this.btnStammdaten.ShowOutline = false;
            this.btnStammdaten.Size = new System.Drawing.Size(108, 54);
            this.btnStammdaten.TabIndex = 31;
            this.btnStammdaten.Text = "Stammdaten";
            this.btnStammdaten.UseAppStyling = false;
            this.btnStammdaten.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnStammdaten.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnStammdaten.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnStammdaten.Click += new System.EventHandler(this.btnStammdaten_Click);
            // 
            // btnBerichte
            // 
            this.btnBerichte.AcceptsFocus = false;
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.FontData.SizeInPoints = 8F;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Tiled;
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance4.TextVAlignAsString = "Middle";
            this.btnBerichte.Appearance = appearance4;
            this.btnBerichte.AutoWorkLayout = false;
            this.btnBerichte.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnBerichte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBerichte.ImageSize = new System.Drawing.Size(35, 35);
            this.btnBerichte.IsStandardControl = false;
            this.btnBerichte.Location = new System.Drawing.Point(122, 5);
            this.btnBerichte.Name = "btnBerichte";
            this.btnBerichte.ShowFocusRect = false;
            this.btnBerichte.ShowOutline = false;
            this.btnBerichte.Size = new System.Drawing.Size(80, 54);
            this.btnBerichte.TabIndex = 32;
            this.btnBerichte.Text = "Berichte";
            this.btnBerichte.UseAppStyling = false;
            this.btnBerichte.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnBerichte.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnBerichte.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnBerichte.Click += new System.EventHandler(this.btnBerichte_Click);
            // 
            // ultraLabel5
            // 
            appearance5.BorderColor = System.Drawing.Color.DarkGray;
            this.ultraLabel5.Appearance = appearance5;
            this.ultraLabel5.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel5.Location = new System.Drawing.Point(116, 8);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(1, 50);
            this.ultraLabel5.TabIndex = 96;
            // 
            // panelBuchhaltung
            // 
            this.panelBuchhaltung.BackColor = System.Drawing.Color.Transparent;
            this.panelBuchhaltung.Controls.Add(this.btnBuchhaltung);
            this.panelBuchhaltung.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBuchhaltung.Location = new System.Drawing.Point(336, 0);
            this.panelBuchhaltung.Name = "panelBuchhaltung";
            this.panelBuchhaltung.Size = new System.Drawing.Size(117, 65);
            this.panelBuchhaltung.TabIndex = 101;
            // 
            // btnBuchhaltung
            // 
            this.btnBuchhaltung.AcceptsFocus = false;
            appearance6.BackColor = System.Drawing.Color.Transparent;
            appearance6.FontData.SizeInPoints = 8F;
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.Image = ((object)(resources.GetObject("appearance6.Image")));
            appearance6.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Tiled;
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance6.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance6.TextVAlignAsString = "Middle";
            this.btnBuchhaltung.Appearance = appearance6;
            this.btnBuchhaltung.AutoWorkLayout = false;
            this.btnBuchhaltung.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnBuchhaltung.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuchhaltung.ImageSize = new System.Drawing.Size(35, 35);
            this.btnBuchhaltung.IsStandardControl = false;
            this.btnBuchhaltung.Location = new System.Drawing.Point(3, 5);
            this.btnBuchhaltung.Name = "btnBuchhaltung";
            this.btnBuchhaltung.ShowFocusRect = false;
            this.btnBuchhaltung.ShowOutline = false;
            this.btnBuchhaltung.Size = new System.Drawing.Size(108, 54);
            this.btnBuchhaltung.TabIndex = 34;
            this.btnBuchhaltung.Text = "Buchhaltung";
            this.btnBuchhaltung.UseAppStyling = false;
            this.btnBuchhaltung.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnBuchhaltung.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnBuchhaltung.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnBuchhaltung.Click += new System.EventHandler(this.btnBuchhaltung_Click_1);
            // 
            // panelLine
            // 
            this.panelLine.BackColor = System.Drawing.Color.Transparent;
            this.panelLine.Controls.Add(this.ultraLabel1);
            this.panelLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLine.Location = new System.Drawing.Point(329, 0);
            this.panelLine.Name = "panelLine";
            this.panelLine.Size = new System.Drawing.Size(7, 65);
            this.panelLine.TabIndex = 100;
            // 
            // ultraLabel1
            // 
            appearance7.BorderColor = System.Drawing.Color.DarkGray;
            this.ultraLabel1.Appearance = appearance7;
            this.ultraLabel1.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel1.Location = new System.Drawing.Point(3, 7);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(1, 50);
            this.ultraLabel1.TabIndex = 97;
            // 
            // panelDepot
            // 
            this.panelDepot.BackColor = System.Drawing.Color.Transparent;
            this.panelDepot.Controls.Add(this.btnDepot);
            this.panelDepot.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelDepot.Location = new System.Drawing.Point(232, 0);
            this.panelDepot.Name = "panelDepot";
            this.panelDepot.Size = new System.Drawing.Size(97, 65);
            this.panelDepot.TabIndex = 99;
            // 
            // btnDepot
            // 
            this.btnDepot.AcceptsFocus = false;
            appearance8.BackColor = System.Drawing.Color.Transparent;
            appearance8.FontData.SizeInPoints = 8F;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.Image = ((object)(resources.GetObject("appearance8.Image")));
            appearance8.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Tiled;
            appearance8.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance8.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance8.TextVAlignAsString = "Middle";
            this.btnDepot.Appearance = appearance8;
            this.btnDepot.AutoWorkLayout = false;
            this.btnDepot.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnDepot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDepot.ImageSize = new System.Drawing.Size(35, 35);
            this.btnDepot.IsStandardControl = false;
            this.btnDepot.Location = new System.Drawing.Point(7, 5);
            this.btnDepot.Name = "btnDepot";
            this.btnDepot.ShowFocusRect = false;
            this.btnDepot.ShowOutline = false;
            this.btnDepot.Size = new System.Drawing.Size(86, 54);
            this.btnDepot.TabIndex = 30;
            this.btnDepot.Text = "Depotgeld";
            this.btnDepot.UseAppStyling = false;
            this.btnDepot.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnDepot.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnDepot.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnDepot.Click += new System.EventHandler(this.btnDepot_Click);
            // 
            // panelSr
            // 
            this.panelSr.BackColor = System.Drawing.Color.Transparent;
            this.panelSr.Controls.Add(this.btnSammelabrechnung2);
            this.panelSr.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSr.Location = new System.Drawing.Point(115, 0);
            this.panelSr.Name = "panelSr";
            this.panelSr.Size = new System.Drawing.Size(117, 65);
            this.panelSr.TabIndex = 98;
            // 
            // btnSammelabrechnung2
            // 
            this.btnSammelabrechnung2.AcceptsFocus = false;
            appearance9.BackColor = System.Drawing.Color.Transparent;
            appearance9.FontData.SizeInPoints = 8F;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.Image = ((object)(resources.GetObject("appearance9.Image")));
            appearance9.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Tiled;
            appearance9.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance9.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance9.TextVAlignAsString = "Middle";
            this.btnSammelabrechnung2.Appearance = appearance9;
            this.btnSammelabrechnung2.AutoWorkLayout = false;
            this.btnSammelabrechnung2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnSammelabrechnung2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSammelabrechnung2.ImageSize = new System.Drawing.Size(35, 35);
            this.btnSammelabrechnung2.IsStandardControl = false;
            this.btnSammelabrechnung2.Location = new System.Drawing.Point(4, 5);
            this.btnSammelabrechnung2.Name = "btnSammelabrechnung2";
            this.btnSammelabrechnung2.ShowFocusRect = false;
            this.btnSammelabrechnung2.ShowOutline = false;
            this.btnSammelabrechnung2.Size = new System.Drawing.Size(109, 54);
            this.btnSammelabrechnung2.TabIndex = 33;
            this.btnSammelabrechnung2.Text = "Sammelabrechnung";
            this.btnSammelabrechnung2.UseAppStyling = false;
            this.btnSammelabrechnung2.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnSammelabrechnung2.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnSammelabrechnung2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnSammelabrechnung2.Click += new System.EventHandler(this.btnSammelabrechnung2_Click);
            // 
            // panelKlient
            // 
            this.panelKlient.BackColor = System.Drawing.Color.Transparent;
            this.panelKlient.Controls.Add(this.btnAbrechnungPatient);
            this.panelKlient.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelKlient.Location = new System.Drawing.Point(0, 0);
            this.panelKlient.Name = "panelKlient";
            this.panelKlient.Size = new System.Drawing.Size(115, 65);
            this.panelKlient.TabIndex = 30;
            // 
            // btnAbrechnungPatient
            // 
            this.btnAbrechnungPatient.AcceptsFocus = false;
            appearance10.BackColor = System.Drawing.Color.Transparent;
            appearance10.FontData.SizeInPoints = 8F;
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.Image = ((object)(resources.GetObject("appearance10.Image")));
            appearance10.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Tiled;
            appearance10.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance10.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance10.TextVAlignAsString = "Middle";
            this.btnAbrechnungPatient.Appearance = appearance10;
            this.btnAbrechnungPatient.AutoWorkLayout = false;
            this.btnAbrechnungPatient.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnAbrechnungPatient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrechnungPatient.ImageSize = new System.Drawing.Size(35, 35);
            this.btnAbrechnungPatient.IsStandardControl = false;
            this.btnAbrechnungPatient.Location = new System.Drawing.Point(7, 5);
            this.btnAbrechnungPatient.Name = "btnAbrechnungPatient";
            this.btnAbrechnungPatient.ShowFocusRect = false;
            this.btnAbrechnungPatient.ShowOutline = false;
            this.btnAbrechnungPatient.Size = new System.Drawing.Size(102, 54);
            this.btnAbrechnungPatient.TabIndex = 28;
            this.btnAbrechnungPatient.Text = "Klienten";
            this.btnAbrechnungPatient.UseAppStyling = false;
            this.btnAbrechnungPatient.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnAbrechnungPatient.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnAbrechnungPatient.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnAbrechnungPatient.Click += new System.EventHandler(this.btnAbrechnungPatient_Click);
            // 
            // uGridBagLayPanelMedizinDaten
            // 
            this.uGridBagLayPanelMedizinDaten.Controls.Add(this.ucMedizinDaten1);
            this.uGridBagLayPanelMedizinDaten.ExpandToFitHeight = true;
            this.uGridBagLayPanelMedizinDaten.ExpandToFitWidth = true;
            this.uGridBagLayPanelMedizinDaten.Location = new System.Drawing.Point(3, 13);
            this.uGridBagLayPanelMedizinDaten.Name = "uGridBagLayPanelMedizinDaten";
            this.uGridBagLayPanelMedizinDaten.Size = new System.Drawing.Size(258, 10);
            this.uGridBagLayPanelMedizinDaten.TabIndex = 29;
            // 
            // ucMedizinDaten1
            // 
            this.ucMedizinDaten1.BackColor = System.Drawing.Color.White;
            this.ucMedizinDaten1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 1;
            gridBagConstraint1.Insets.Left = 1;
            gridBagConstraint1.Insets.Right = 1;
            gridBagConstraint1.Insets.Top = 1;
            gridBagConstraint1.OriginX = 0;
            gridBagConstraint1.OriginY = 0;
            this.uGridBagLayPanelMedizinDaten.SetGridBagConstraint(this.ucMedizinDaten1, gridBagConstraint1);
            this.ucMedizinDaten1.Location = new System.Drawing.Point(1, 1);
            this.ucMedizinDaten1.Name = "ucMedizinDaten1";
            this.uGridBagLayPanelMedizinDaten.SetPreferredSize(this.ucMedizinDaten1, new System.Drawing.Size(265, 21));
            this.ucMedizinDaten1.Size = new System.Drawing.Size(256, 8);
            this.ucMedizinDaten1.TabIndex = 26;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 0;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // ucHeaderCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.uGroupBoxHeader);
            this.Controls.Add(this.uGridBagLayPanelMedizinDaten);
            this.Name = "ucHeaderCalc";
            this.Size = new System.Drawing.Size(945, 65);
            this.VisibleChanged += new System.EventHandler(this.ucHeader_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.uGroupBoxHeader)).EndInit();
            this.uGroupBoxHeader.ResumeLayout(false);
            this.panelStmmdatenBerichte.ResumeLayout(false);
            this.panelBuchhaltung.ResumeLayout(false);
            this.panelLine.ResumeLayout(false);
            this.panelDepot.ResumeLayout(false);
            this.panelSr.ResumeLayout(false);
            this.panelKlient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uGridBagLayPanelMedizinDaten)).EndInit();
            this.uGridBagLayPanelMedizinDaten.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseGroupBox uGroupBoxHeader;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel uGridBagLayPanelMedizinDaten;
        private PMDS.GUI.BaseControls.ucMedizinDaten ucMedizinDaten1;
        private QS2.Desktop.ControlManagment.BaseButton btnAbrechnungPatient;
        private QS2.Desktop.ControlManagment.BaseButton btnBerichte;
        private QS2.Desktop.ControlManagment.BaseButton btnStammdaten;
        private QS2.Desktop.ControlManagment.BaseButton btnDepot;
        private QS2.Desktop.ControlManagment.BaseButton btnSammelabrechnung2;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private QS2.Desktop.ControlManagment.BaseButton btnBuchhaltung;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel1;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel5;
        private QS2.Desktop.ControlManagment.BasePanel panelStmmdatenBerichte;
        private QS2.Desktop.ControlManagment.BasePanel panelBuchhaltung;
        private QS2.Desktop.ControlManagment.BasePanel panelLine;
        private QS2.Desktop.ControlManagment.BasePanel panelDepot;
        private QS2.Desktop.ControlManagment.BasePanel panelSr;
        private QS2.Desktop.ControlManagment.BasePanel panelKlient;
        public GUI.BaseControls.ucKlinikCbo ucKlinikCbo1;

    }
}
