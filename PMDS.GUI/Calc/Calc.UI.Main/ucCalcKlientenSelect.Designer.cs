namespace PMDS.Calc.UI.Admin
{
    partial class ucCalcKlientenSelect
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Liste Klienten ein- bzw. ausblenden", Infragistics.Win.ToolTipImage.Default, "Liste Klienten Ein/Aus", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint2 = new Infragistics.Win.Layout.GridBagConstraint();
            this.ultraGridBagLayoutManager1 = new Infragistics.Win.Misc.UltraGridBagLayoutManager(this.components);
            this.ucKlienten2 = new PMDS.GUI.ucKlienten();
            this.uGridBagLayoutPanelKlient = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.panelKlienten = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelKlienten2 = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.lblKlientenausahl = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.panelLinie = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelKlButtUnten = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnListKlientenEinAus = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.panelKlient = new QS2.Desktop.ControlManagment.BasePanel();
            this.ucKlientenverwaltung3 = new PMDS.Calc.UI.Admin.ucCalcKlienten();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGridBagLayoutPanelKlient)).BeginInit();
            this.uGridBagLayoutPanelKlient.SuspendLayout();
            this.panelKlienten.SuspendLayout();
            this.panelKlienten2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
            this.ultraGridBagLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientenausahl)).BeginInit();
            this.panelKlButtUnten.SuspendLayout();
            this.panelKlient.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucKlienten2
            // 
            this.ucKlienten2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucKlienten2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucKlienten2.Dock = System.Windows.Forms.DockStyle.Fill;
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.OriginX = 0;
            gridBagConstraint1.OriginY = 0;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.ucKlienten2, gridBagConstraint1);
            this.ucKlienten2.Location = new System.Drawing.Point(0, 0);
            this.ucKlienten2.Name = "ucKlienten2";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.ucKlienten2, new System.Drawing.Size(200, 508));
            this.ucKlienten2.Size = new System.Drawing.Size(200, 513);
            this.ucKlienten2.TabIndex = 21;
            // 
            // uGridBagLayoutPanelKlient
            // 
            this.uGridBagLayoutPanelKlient.Controls.Add(this.ucKlientenverwaltung3);
            this.uGridBagLayoutPanelKlient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGridBagLayoutPanelKlient.ExpandToFitHeight = true;
            this.uGridBagLayoutPanelKlient.ExpandToFitWidth = true;
            this.uGridBagLayoutPanelKlient.Location = new System.Drawing.Point(0, 0);
            this.uGridBagLayoutPanelKlient.Name = "uGridBagLayoutPanelKlient";
            this.uGridBagLayoutPanelKlient.Size = new System.Drawing.Size(703, 538);
            this.uGridBagLayoutPanelKlient.TabIndex = 23;
            // 
            // panelKlienten
            // 
            this.panelKlienten.Controls.Add(this.panelKlienten2);
            this.panelKlienten.Controls.Add(this.lblKlientenausahl);
            this.panelKlienten.Controls.Add(this.panelLinie);
            this.panelKlienten.Controls.Add(this.panelKlButtUnten);
            this.panelKlienten.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelKlienten.Location = new System.Drawing.Point(0, 0);
            this.panelKlienten.Name = "panelKlienten";
            this.panelKlienten.Size = new System.Drawing.Size(200, 538);
            this.panelKlienten.TabIndex = 24;
            // 
            // panelKlienten2
            // 
            this.panelKlienten2.Controls.Add(this.ultraGridBagLayoutPanel1);
            this.panelKlienten2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKlienten2.Location = new System.Drawing.Point(0, 0);
            this.panelKlienten2.Name = "panelKlienten2";
            this.panelKlienten2.Size = new System.Drawing.Size(200, 513);
            this.panelKlienten2.TabIndex = 68;
            // 
            // ultraGridBagLayoutPanel1
            // 
            this.ultraGridBagLayoutPanel1.Controls.Add(this.ucKlienten2);
            this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel1.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel1.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
            this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(200, 513);
            this.ultraGridBagLayoutPanel1.TabIndex = 23;
            // 
            // lblKlientenausahl
            // 
            appearance1.BackColor = System.Drawing.Color.Gainsboro;
            appearance1.FontData.SizeInPoints = 10F;
            this.lblKlientenausahl.Appearance = appearance1;
            this.lblKlientenausahl.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            this.lblKlientenausahl.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center;
            appearance2.BackColor = System.Drawing.Color.Gainsboro;
            this.lblKlientenausahl.ContentAreaAppearance = appearance2;
            this.lblKlientenausahl.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance3.BackColor = System.Drawing.Color.Gainsboro;
            this.lblKlientenausahl.HeaderAppearance = appearance3;
            this.lblKlientenausahl.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.LeftOnBorder;
            this.lblKlientenausahl.Location = new System.Drawing.Point(-1, 183);
            this.lblKlientenausahl.Name = "lblKlientenausahl";
            this.lblKlientenausahl.Size = new System.Drawing.Size(20, 117);
            this.lblKlientenausahl.TabIndex = 67;
            this.lblKlientenausahl.Text = "Klientenauswahl";
            this.lblKlientenausahl.Click += new System.EventHandler(this.lblKlientenausahl_Click);
            // 
            // panelLinie
            // 
            this.panelLinie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelLinie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLinie.Location = new System.Drawing.Point(1, 5);
            this.panelLinie.Name = "panelLinie";
            this.panelLinie.Size = new System.Drawing.Size(1, 501);
            this.panelLinie.TabIndex = 23;
            // 
            // panelKlButtUnten
            // 
            this.panelKlButtUnten.Controls.Add(this.btnListKlientenEinAus);
            this.panelKlButtUnten.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelKlButtUnten.Location = new System.Drawing.Point(0, 513);
            this.panelKlButtUnten.Name = "panelKlButtUnten";
            this.panelKlButtUnten.Size = new System.Drawing.Size(200, 25);
            this.panelKlButtUnten.TabIndex = 0;
            // 
            // btnListKlientenEinAus
            // 
            this.btnListKlientenEinAus.AcceptsFocus = false;
            this.btnListKlientenEinAus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BackColor = System.Drawing.Color.Gainsboro;
            appearance4.Image = "ICO_pfLinks.ico";
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnListKlientenEinAus.Appearance = appearance4;
            this.btnListKlientenEinAus.AutoWorkLayout = false;
            this.btnListKlientenEinAus.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnListKlientenEinAus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.btnListKlientenEinAus.ImageSize = new System.Drawing.Size(10, 10);
            this.btnListKlientenEinAus.IsStandardControl = false;
            this.btnListKlientenEinAus.Location = new System.Drawing.Point(181, 2);
            this.btnListKlientenEinAus.Name = "btnListKlientenEinAus";
            this.btnListKlientenEinAus.Size = new System.Drawing.Size(17, 20);
            this.btnListKlientenEinAus.TabIndex = 52;
            this.btnListKlientenEinAus.Tag = "0";
            ultraToolTipInfo1.ToolTipText = "Liste Klienten ein- bzw. ausblenden";
            ultraToolTipInfo1.ToolTipTitle = "Liste Klienten Ein/Aus";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnListKlientenEinAus, ultraToolTipInfo1);
            this.btnListKlientenEinAus.Click += new System.EventHandler(this.btnListKlientenEinAus_Click);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 0;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // panelKlient
            // 
            this.panelKlient.Controls.Add(this.uGridBagLayoutPanelKlient);
            this.panelKlient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKlient.Location = new System.Drawing.Point(200, 0);
            this.panelKlient.Name = "panelKlient";
            this.panelKlient.Size = new System.Drawing.Size(703, 538);
            this.panelKlient.TabIndex = 25;
            // 
            // ucKlientenverwaltung3
            // 
            this.ucKlientenverwaltung3.BackColor = System.Drawing.Color.Transparent;
            this.ucKlientenverwaltung3.Cursor = System.Windows.Forms.Cursors.Default;
            this.ucKlientenverwaltung3.Dock = System.Windows.Forms.DockStyle.Fill;
            gridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both;
            this.uGridBagLayoutPanelKlient.SetGridBagConstraint(this.ucKlientenverwaltung3, gridBagConstraint2);
            this.ucKlientenverwaltung3.Location = new System.Drawing.Point(0, 0);
            this.ucKlientenverwaltung3.Name = "ucKlientenverwaltung3";
            this.uGridBagLayoutPanelKlient.SetPreferredSize(this.ucKlientenverwaltung3, new System.Drawing.Size(698, 533));
            this.ucKlientenverwaltung3.Size = new System.Drawing.Size(703, 538);
            this.ucKlientenverwaltung3.TabIndex = 21;
            // 
            // ucCalcKlientenSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.panelKlient);
            this.Controls.Add(this.panelKlienten);
            this.Name = "ucCalcKlientenSelect";
            this.Size = new System.Drawing.Size(903, 538);
            this.VisibleChanged += new System.EventHandler(this.ucCalcKlientenSelect_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGridBagLayoutPanelKlient)).EndInit();
            this.uGridBagLayoutPanelKlient.ResumeLayout(false);
            this.panelKlienten.ResumeLayout(false);
            this.panelKlienten2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
            this.ultraGridBagLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientenausahl)).EndInit();
            this.panelKlButtUnten.ResumeLayout(false);
            this.panelKlient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Infragistics.Win.Misc.UltraGridBagLayoutManager ultraGridBagLayoutManager1;
        public PMDS.GUI.ucKlienten ucKlienten2;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel uGridBagLayoutPanelKlient;
        private QS2.Desktop.ControlManagment.BasePanel panelKlienten;
        private QS2.Desktop.ControlManagment.BasePanel panelKlButtUnten;
        private QS2.Desktop.ControlManagment.BaseButton btnListKlientenEinAus;
        private QS2.Desktop.ControlManagment.BasePanel panelLinie;
        public Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private QS2.Desktop.ControlManagment.BaseGroupBox lblKlientenausahl;
        private QS2.Desktop.ControlManagment.BasePanel panelKlient;
        private QS2.Desktop.ControlManagment.BasePanel panelKlienten2;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        public ucCalcKlienten ucKlientenverwaltung3;
    }
}
