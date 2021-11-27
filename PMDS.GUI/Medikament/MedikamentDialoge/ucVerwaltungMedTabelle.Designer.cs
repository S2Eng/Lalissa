namespace PMDS.GUI
{
    partial class ucVerwaltungMedTabelle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucVerwaltungMedTabelle));
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Editieren", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint2 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Medikament", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EXT_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BARCODE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Zulassungsnummer");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LangText");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Einheit");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Gruppe");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Herrichten");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AerztlichevorbereitungJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Verabreichungsart");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Applikationsform");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Packungsgroesse");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Packungsanzahl");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Packungseinheit");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Gültigkeitsdatum");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Lagervorschrift");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ImportiertAm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Importiert");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn43 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Aktuell");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn44 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Erstattungscode");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn45 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Kassenzeichen");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn46 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Lieferant");
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            this.pnlFilter = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnUpdate = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraGridBagLayoutPanel2 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.grpSuche = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.lblReset = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnSearch2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.optAktuellYN = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.lblBezeichnung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbBezeichnung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblLangtext = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblDareichungsform = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbLangText = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblGruppe = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblFound = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelGrid = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraGridBagLayoutPanelGrid = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dgMain = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsMedikament1 = new PMDS.Global.db.Patient.dsMedikament();
            this.cbEinheit = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.cbGroup = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.btnDel = new PMDS.GUI.ucButton(this.components);
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel2)).BeginInit();
            this.ultraGridBagLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSuche)).BeginInit();
            this.grpSuche.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optAktuellYN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBezeichnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLangText)).BeginInit();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanelGrid)).BeginInit();
            this.ultraGridBagLayoutPanelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMedikament1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEinheit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.btnUpdate);
            this.pnlFilter.Controls.Add(this.ultraGridBagLayoutPanel2);
            this.pnlFilter.Controls.Add(this.btnDel);
            this.pnlFilter.Controls.Add(this.btnAdd);
            this.pnlFilter.Controls.Add(this.lblFound);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(789, 129);
            this.pnlFilter.TabIndex = 1;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUpdate.Appearance = appearance1;
            this.btnUpdate.AutoWorkLayout = false;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUpdate.IsStandardControl = false;
            this.btnUpdate.Location = new System.Drawing.Point(729, 106);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(25, 22);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.TabStop = false;
            ultraToolTipInfo1.ToolTipText = "Editieren";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnUpdate, ultraToolTipInfo1);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // ultraGridBagLayoutPanel2
            // 
            this.ultraGridBagLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraGridBagLayoutPanel2.Controls.Add(this.grpSuche);
            this.ultraGridBagLayoutPanel2.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel2.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanel2.Name = "ultraGridBagLayoutPanel2";
            this.ultraGridBagLayoutPanel2.Size = new System.Drawing.Size(789, 105);
            this.ultraGridBagLayoutPanel2.TabIndex = 2;
            // 
            // grpSuche
            // 
            appearance3.BackColor = System.Drawing.Color.White;
            this.grpSuche.Appearance = appearance3;
            this.grpSuche.Controls.Add(this.lblReset);
            this.grpSuche.Controls.Add(this.btnSearch2);
            this.grpSuche.Controls.Add(this.optAktuellYN);
            this.grpSuche.Controls.Add(this.lblBezeichnung);
            this.grpSuche.Controls.Add(this.tbBezeichnung);
            this.grpSuche.Controls.Add(this.cbEinheit);
            this.grpSuche.Controls.Add(this.lblLangtext);
            this.grpSuche.Controls.Add(this.lblDareichungsform);
            this.grpSuche.Controls.Add(this.tbLangText);
            this.grpSuche.Controls.Add(this.lblGruppe);
            this.grpSuche.Controls.Add(this.cbGroup);
            gridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint2.Insets.Bottom = 5;
            gridBagConstraint2.Insets.Left = 5;
            gridBagConstraint2.Insets.Right = 5;
            gridBagConstraint2.Insets.Top = 5;
            gridBagConstraint2.OriginX = 0;
            gridBagConstraint2.OriginY = 0;
            this.ultraGridBagLayoutPanel2.SetGridBagConstraint(this.grpSuche, gridBagConstraint2);
            this.grpSuche.Location = new System.Drawing.Point(5, 5);
            this.grpSuche.Name = "grpSuche";
            this.ultraGridBagLayoutPanel2.SetPreferredSize(this.grpSuche, new System.Drawing.Size(758, 0));
            this.grpSuche.Size = new System.Drawing.Size(779, 95);
            this.grpSuche.TabIndex = 0;
            this.grpSuche.Text = "Medikament suchen";
            // 
            // lblReset
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance4.FontData.SizeInPoints = 7F;
            appearance4.ForeColor = System.Drawing.Color.Black;
            this.lblReset.Appearance = appearance4;
            this.lblReset.AutoSize = true;
            appearance5.FontData.UnderlineAsString = "True";
            appearance5.ForeColor = System.Drawing.Color.Black;
            this.lblReset.HotTrackAppearance = appearance5;
            this.lblReset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblReset.Location = new System.Drawing.Point(727, 75);
            this.lblReset.Name = "lblReset";
            this.lblReset.Size = new System.Drawing.Size(36, 12);
            this.lblReset.TabIndex = 160;
            this.lblReset.Text = "Suchen";
            this.lblReset.UseAppStyling = false;
            this.lblReset.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.lblReset.Click += new System.EventHandler(this.lblReset_Click);
            // 
            // btnSearch2
            // 
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.btnSearch2.Appearance = appearance6;
            this.btnSearch2.AutoWorkLayout = false;
            this.btnSearch2.IsStandardControl = false;
            this.btnSearch2.Location = new System.Drawing.Point(725, 40);
            this.btnSearch2.Name = "btnSearch2";
            this.btnSearch2.Size = new System.Drawing.Size(40, 32);
            this.btnSearch2.TabIndex = 14;
            this.btnSearch2.TabStop = false;
            this.btnSearch2.Click += new System.EventHandler(this.btnSearch2_Click);
            // 
            // optAktuellYN
            // 
            appearance7.BackColor = System.Drawing.Color.Transparent;
            this.optAktuellYN.Appearance = appearance7;
            this.optAktuellYN.BackColor = System.Drawing.Color.Transparent;
            this.optAktuellYN.BackColorInternal = System.Drawing.Color.Transparent;
            this.optAktuellYN.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.optAktuellYN.CheckedIndex = 0;
            valueListItem1.DataValue = 1;
            valueListItem1.DisplayText = "Aktuelle Medikamente";
            valueListItem2.DataValue = 0;
            valueListItem2.DisplayText = "Nicht aktuelle Medikamente";
            valueListItem3.DataValue = -1;
            valueListItem3.DisplayText = "Alle";
            this.optAktuellYN.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.optAktuellYN.Location = new System.Drawing.Point(90, 74);
            this.optAktuellYN.Name = "optAktuellYN";
            this.optAktuellYN.Size = new System.Drawing.Size(387, 15);
            this.optAktuellYN.TabIndex = 4;
            this.optAktuellYN.Text = "Aktuelle Medikamente";
            // 
            // lblBezeichnung
            // 
            appearance8.BackColor = System.Drawing.Color.Transparent;
            appearance8.TextHAlignAsString = "Right";
            appearance8.TextVAlignAsString = "Middle";
            this.lblBezeichnung.Appearance = appearance8;
            this.lblBezeichnung.Location = new System.Drawing.Point(-14, 22);
            this.lblBezeichnung.Name = "lblBezeichnung";
            this.lblBezeichnung.Size = new System.Drawing.Size(96, 21);
            this.lblBezeichnung.TabIndex = 6;
            this.lblBezeichnung.Text = "Bezeichnung";
            // 
            // tbBezeichnung
            // 
            this.tbBezeichnung.Location = new System.Drawing.Point(90, 22);
            this.tbBezeichnung.MaxLength = 50;
            this.tbBezeichnung.Name = "tbBezeichnung";
            this.tbBezeichnung.Size = new System.Drawing.Size(275, 21);
            this.tbBezeichnung.TabIndex = 0;
            this.tbBezeichnung.ValueChanged += new System.EventHandler(this.tbBezeichnung_ValueChanged);
            this.tbBezeichnung.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbBezeichnung_KeyUp);
            // 
            // lblLangtext
            // 
            appearance9.BackColor = System.Drawing.Color.Transparent;
            appearance9.TextHAlignAsString = "Left";
            appearance9.TextVAlignAsString = "Middle";
            this.lblLangtext.Appearance = appearance9;
            this.lblLangtext.Location = new System.Drawing.Point(381, 22);
            this.lblLangtext.Name = "lblLangtext";
            this.lblLangtext.Size = new System.Drawing.Size(64, 21);
            this.lblLangtext.TabIndex = 8;
            this.lblLangtext.Text = "Langtext";
            this.lblLangtext.Visible = false;
            // 
            // lblDareichungsform
            // 
            appearance10.BackColor = System.Drawing.Color.Transparent;
            appearance10.TextHAlignAsString = "Left";
            appearance10.TextVAlignAsString = "Middle";
            this.lblDareichungsform.Appearance = appearance10;
            this.lblDareichungsform.Location = new System.Drawing.Point(381, 46);
            this.lblDareichungsform.Name = "lblDareichungsform";
            this.lblDareichungsform.Size = new System.Drawing.Size(96, 21);
            this.lblDareichungsform.TabIndex = 9;
            this.lblDareichungsform.Text = "Darreichungsform";
            // 
            // tbLangText
            // 
            this.tbLangText.Location = new System.Drawing.Point(481, 22);
            this.tbLangText.MaxLength = 50;
            this.tbLangText.Name = "tbLangText";
            this.tbLangText.Size = new System.Drawing.Size(220, 21);
            this.tbLangText.TabIndex = 1;
            this.tbLangText.Visible = false;
            // 
            // lblGruppe
            // 
            appearance11.BackColor = System.Drawing.Color.Transparent;
            appearance11.TextHAlignAsString = "Right";
            appearance11.TextVAlignAsString = "Middle";
            this.lblGruppe.Appearance = appearance11;
            this.lblGruppe.Location = new System.Drawing.Point(-14, 46);
            this.lblGruppe.Name = "lblGruppe";
            this.lblGruppe.Size = new System.Drawing.Size(96, 21);
            this.lblGruppe.TabIndex = 7;
            this.lblGruppe.Text = "Gruppe";
            // 
            // lblFound
            // 
            this.lblFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance14.FontData.SizeInPoints = 7.5F;
            appearance14.TextHAlignAsString = "Right";
            appearance14.TextVAlignAsString = "Middle";
            this.lblFound.Appearance = appearance14;
            this.lblFound.Location = new System.Drawing.Point(535, 111);
            this.lblFound.Name = "lblFound";
            this.lblFound.Size = new System.Drawing.Size(163, 13);
            this.lblFound.TabIndex = 7;
            this.lblFound.Text = "Gefunden: 34";
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.ultraGridBagLayoutPanelGrid);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 129);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(789, 303);
            this.panelGrid.TabIndex = 10;
            // 
            // ultraGridBagLayoutPanelGrid
            // 
            this.ultraGridBagLayoutPanelGrid.Controls.Add(this.dgMain);
            this.ultraGridBagLayoutPanelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanelGrid.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanelGrid.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanelGrid.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanelGrid.Name = "ultraGridBagLayoutPanelGrid";
            this.ultraGridBagLayoutPanelGrid.Size = new System.Drawing.Size(789, 303);
            this.ultraGridBagLayoutPanelGrid.TabIndex = 10;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 0;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dgMain
            // 
            this.dgMain.AutoWork = true;
            this.dgMain.DataSource = this.dsMedikament1;
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BorderColor = System.Drawing.Color.Black;
            this.dgMain.DisplayLayout.Appearance = appearance2;
            this.dgMain.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 0;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn5.Header.Caption = "Externe ID";
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 19;
            ultraGridColumn5.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(116, 0);
            ultraGridColumn5.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn5.Width = 150;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 1;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn6.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn6.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn6.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 2;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn7.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn7.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn7.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn7.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 3;
            ultraGridColumn8.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn8.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn8.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(278, 0);
            ultraGridColumn8.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn8.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn9.Header.Caption = "Langtext";
            ultraGridColumn9.Header.Editor = null;
            ultraGridColumn9.Header.VisiblePosition = 4;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn9.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn9.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn9.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(242, 0);
            ultraGridColumn9.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn9.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn10.Header.Editor = null;
            ultraGridColumn10.Header.VisiblePosition = 5;
            ultraGridColumn10.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn10.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn10.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(257, 0);
            ultraGridColumn10.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn10.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn11.Header.Editor = null;
            ultraGridColumn11.Header.VisiblePosition = 6;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn11.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn11.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn11.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn11.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn12.Header.Editor = null;
            ultraGridColumn12.Header.VisiblePosition = 7;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn13.Header.Editor = null;
            ultraGridColumn13.Header.VisiblePosition = 8;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn14.Header.Editor = null;
            ultraGridColumn14.Header.VisiblePosition = 9;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn15.Header.Editor = null;
            ultraGridColumn15.Header.VisiblePosition = 10;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn16.Header.Editor = null;
            ultraGridColumn16.Header.VisiblePosition = 11;
            ultraGridColumn16.RowLayoutColumnInfo.OriginX = 12;
            ultraGridColumn16.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn16.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn16.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn17.Header.Editor = null;
            ultraGridColumn17.Header.VisiblePosition = 12;
            ultraGridColumn17.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn17.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn17.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn17.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn18.Header.Editor = null;
            ultraGridColumn18.Header.VisiblePosition = 13;
            ultraGridColumn18.RowLayoutColumnInfo.OriginX = 14;
            ultraGridColumn18.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn18.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn18.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn19.Header.Editor = null;
            ultraGridColumn19.Header.VisiblePosition = 14;
            ultraGridColumn19.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn19.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn19.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(109, 0);
            ultraGridColumn19.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn19.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn20.Header.Editor = null;
            ultraGridColumn20.Header.VisiblePosition = 15;
            ultraGridColumn20.RowLayoutColumnInfo.OriginX = 20;
            ultraGridColumn20.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn20.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(225, 0);
            ultraGridColumn20.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn20.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn41.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn41.Header.Caption = "Importiert am";
            ultraGridColumn41.Header.Editor = null;
            ultraGridColumn41.Header.VisiblePosition = 16;
            ultraGridColumn41.RowLayoutColumnInfo.OriginX = 18;
            ultraGridColumn41.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn41.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(123, 0);
            ultraGridColumn41.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn41.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn41.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
            ultraGridColumn42.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn42.Header.Editor = null;
            ultraGridColumn42.Header.VisiblePosition = 17;
            ultraGridColumn42.RowLayoutColumnInfo.OriginX = 16;
            ultraGridColumn42.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn42.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn42.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn43.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn43.Header.Editor = null;
            ultraGridColumn43.Header.VisiblePosition = 18;
            ultraGridColumn43.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn43.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn43.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(54, 0);
            ultraGridColumn43.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn43.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn44.Header.Editor = null;
            ultraGridColumn44.Header.VisiblePosition = 20;
            ultraGridColumn45.Header.Editor = null;
            ultraGridColumn45.Header.VisiblePosition = 21;
            ultraGridColumn46.Header.Editor = null;
            ultraGridColumn46.Header.VisiblePosition = 22;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn41,
            ultraGridColumn42,
            ultraGridColumn43,
            ultraGridColumn44,
            ultraGridColumn45,
            ultraGridColumn46});
            ultraGridBand1.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgMain.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgMain.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMain.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.dgMain.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.dgMain.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgMain.DisplayLayout.Override.RowSpacingAfter = 2;
            this.dgMain.DisplayLayout.Override.RowSpacingBefore = 2;
            this.dgMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 5;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            gridBagConstraint1.Insets.Top = 2;
            gridBagConstraint1.OriginX = 0;
            gridBagConstraint1.OriginY = 0;
            this.ultraGridBagLayoutPanelGrid.SetGridBagConstraint(this.dgMain, gridBagConstraint1);
            this.dgMain.Location = new System.Drawing.Point(5, 2);
            this.dgMain.Name = "dgMain";
            this.ultraGridBagLayoutPanelGrid.SetPreferredSize(this.dgMain, new System.Drawing.Size(300, 123));
            this.dgMain.Size = new System.Drawing.Size(779, 296);
            this.dgMain.TabIndex = 9;
            this.dgMain.DoubleClick += new System.EventHandler(this.dgMain_DoubleClick);
            // 
            // dsMedikament1
            // 
            this.dsMedikament1.DataSetName = "dsMedikament";
            this.dsMedikament1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsMedikament1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbEinheit
            // 
            this.cbEinheit.AddEmptyEntry = false;
            this.cbEinheit.AutoOpenCBO = false;
            this.cbEinheit.BerufsstandGruppeJNA = -1;
            this.cbEinheit.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbEinheit.ExactMatch = false;
            this.cbEinheit.Group = "MEH";
            this.cbEinheit.ID_PEP = -1;
            this.cbEinheit.Location = new System.Drawing.Point(481, 46);
            this.cbEinheit.Name = "cbEinheit";
            this.cbEinheit.PflichtJN = false;
            this.cbEinheit.ShowAddButton = true;
            this.cbEinheit.Size = new System.Drawing.Size(220, 21);
            this.cbEinheit.sys = false;
            this.cbEinheit.TabIndex = 3;
            // 
            // cbGroup
            // 
            this.cbGroup.AddEmptyEntry = false;
            this.cbGroup.AutoOpenCBO = false;
            this.cbGroup.BerufsstandGruppeJNA = -1;
            this.cbGroup.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbGroup.ExactMatch = false;
            this.cbGroup.Group = "MGR";
            this.cbGroup.ID_PEP = -1;
            this.cbGroup.Location = new System.Drawing.Point(90, 46);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.PflichtJN = false;
            this.cbGroup.ShowAddButton = true;
            this.cbGroup.Size = new System.Drawing.Size(275, 21);
            this.cbGroup.sys = false;
            this.cbGroup.TabIndex = 2;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance12.BackColor = System.Drawing.Color.Transparent;
            appearance12.Image = ((object)(resources.GetObject("appearance12.Image")));
            appearance12.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance12.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance12;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDel.DoOnClick = true;
            this.btnDel.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDel.IsStandardControl = true;
            this.btnDel.Location = new System.Drawing.Point(754, 106);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(25, 22);
            this.btnDel.TabIndex = 7;
            this.btnDel.TabStop = false;
            this.btnDel.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance13.BackColor = System.Drawing.Color.Transparent;
            appearance13.Image = ((object)(resources.GetObject("appearance13.Image")));
            appearance13.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance13.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance13;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(704, 106);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 22);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.TabStop = false;
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ucVerwaltungMedTabelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.pnlFilter);
            this.Name = "ucVerwaltungMedTabelle";
            this.Size = new System.Drawing.Size(789, 432);
            this.Load += new System.EventHandler(this.ucMedikamentTabelle_Load);
            this.pnlFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel2)).EndInit();
            this.ultraGridBagLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpSuche)).EndInit();
            this.grpSuche.ResumeLayout(false);
            this.grpSuche.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optAktuellYN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBezeichnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLangText)).EndInit();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanelGrid)).EndInit();
            this.ultraGridBagLayoutPanelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMedikament1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEinheit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel pnlFilter;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cbEinheit;
        private QS2.Desktop.ControlManagment.BaseLabel lblDareichungsform;
        private QS2.Desktop.ControlManagment.BaseLabel lblGruppe;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cbGroup;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbLangText;
        private QS2.Desktop.ControlManagment.BaseLabel lblLangtext;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbBezeichnung;
        private QS2.Desktop.ControlManagment.BaseLabel lblBezeichnung;
        private QS2.Desktop.ControlManagment.BaseGrid dgMain;
        private QS2.Desktop.ControlManagment.BaseButton btnUpdate;
        private ucButton btnDel;
        private ucButton btnAdd;
        private PMDS.Global.db.Patient.dsMedikament dsMedikament1;
        private QS2.Desktop.ControlManagment.BasePanel panelGrid;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel2;
        private QS2.Desktop.ControlManagment.BaseGroupBox grpSuche;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanelGrid;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private QS2.Desktop.ControlManagment.BaseLabel lblFound;
        private QS2.Desktop.ControlManagment.BaseOptionSet optAktuellYN;
        private QS2.Desktop.ControlManagment.BaseButton btnSearch2;
        internal QS2.Desktop.ControlManagment.BaseLabel lblReset;
        private System.Windows.Forms.Timer timer1;
    }
}
