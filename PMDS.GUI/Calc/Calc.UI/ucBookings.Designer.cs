namespace PMDS.Calc.UI
{
    partial class ucBookings
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
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBookings));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("bookings", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Buchungsdatum");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Text");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Sollkonto", -1, 959010437);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Habenkonto", -1, 959010437);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Betrag");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MWStSatz", -1, 957624478);
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RechNr");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlient", -1, 955900011);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKostenträger", -1, 955900292);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Erstellt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ErstellAm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik", -1, "dropDownKliniken");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Soll");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Haben");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings1 = new Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, null, "Soll", 13, true, "bookings", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "Soll", 13, true);
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings2 = new Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, null, "Haben", 14, true, "bookings", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "Haben", 14, true);
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(955900011);
            Infragistics.Win.ValueList valueList2 = new Infragistics.Win.ValueList(955900292);
            Infragistics.Win.ValueList valueList3 = new Infragistics.Win.ValueList(957624478);
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueList valueList4 = new Infragistics.Win.ValueList(959010437);
            Infragistics.Win.ValueList valueList5 = new Infragistics.Win.ValueList(101230219);
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem15 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueList valueList6 = new Infragistics.Win.ValueList(101231296);
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Tabelle nach Excel exportieren", Infragistics.Win.ToolTipImage.Default, "ExportE xcel", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.cboBezeichnungstexte = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panelGrid = new QS2.Desktop.ControlManagment.BasePanel();
            this.uGridBookings = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dbPMDS1 = new PMDS.Calc.Logic.dbCalc();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panelPrint = new QS2.Desktop.ControlManagment.BasePanel();
            this.uGridBagLayoutPanelBooking = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.ucprint1 = new PMDS.Calc.Logic.ucprint();
            this.panelTop = new QS2.Desktop.ControlManagment.BasePanel();
            this.contextMenuStripBooking = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.auswahlNeuLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportExcel = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelButtonsAddDel = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.btnDelete = new PMDS.GUI.ucButton(this.components);
            this.btnPrint = new QS2.Desktop.ControlManagment.BaseButton();
            this.grpSuche = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.ucKlinikDropDown1 = new PMDS.GUI.BaseControls.ucKlinikDropDown();
            this.lblZurücksetzen = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtBis = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.dtVon = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.cboKonto = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.cboKlienten = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.cboKostenträger = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.txtText = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblText = new QS2.Desktop.ControlManagment.BaseLabel();
            this.butSearch = new PMDS.GUI.ucButton(this.components);
            this.lblKonto = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblKostenträger = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnTimes = new Infragistics.Win.Misc.UltraDropDownButton();
            this.lblBis = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblVon = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblKlienten = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelBottom = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblCount = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelButtonSpeichern = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblSaldo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnReload = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnSave = new PMDS.GUI.ucButton(this.components);
            this.btnReset = new PMDS.GUI.ucButton(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.panelAll = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelBookings = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraTabControl1 = new QS2.Desktop.ControlManagment.BaseTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.ultraGridBagLayoutManager1 = new Infragistics.Win.Misc.UltraGridBagLayoutManager(this.components);
            this.ultraGridBagLayoutPanel2 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cboBezeichnungstexte)).BeginInit();
            this.ultraTabPageControl1.SuspendLayout();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGridBookings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPMDS1)).BeginInit();
            this.ultraTabPageControl2.SuspendLayout();
            this.panelPrint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGridBagLayoutPanelBooking)).BeginInit();
            this.uGridBagLayoutPanelBooking.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.contextMenuStripBooking.SuspendLayout();
            this.panelButtonsAddDel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSuche)).BeginInit();
            this.grpSuche.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKlienten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKostenträger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtText)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.panelButtonSpeichern.SuspendLayout();
            this.panelAll.SuspendLayout();
            this.panelBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboBezeichnungstexte
            // 
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            editorButton1.Appearance = appearance1;
            this.cboBezeichnungstexte.ButtonsRight.Add(editorButton1);
            this.cboBezeichnungstexte.Location = new System.Drawing.Point(53, 77);
            this.cboBezeichnungstexte.Name = "cboBezeichnungstexte";
            this.cboBezeichnungstexte.Size = new System.Drawing.Size(108, 21);
            this.cboBezeichnungstexte.TabIndex = 158;
            this.cboBezeichnungstexte.Visible = false;
            this.cboBezeichnungstexte.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.cboBezeichnung_EditorButtonClick);
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.panelGrid);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(1155, 256);
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.uGridBookings);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 0);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(1155, 256);
            this.panelGrid.TabIndex = 100;
            // 
            // uGridBookings
            // 
            this.uGridBookings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uGridBookings.AutoWork = true;
            this.uGridBookings.DataMember = "bookings";
            this.uGridBookings.DataSource = this.dbPMDS1;
            appearance2.BackColor = System.Drawing.Color.White;
            this.uGridBookings.DisplayLayout.Appearance = appearance2;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn16.Header.Editor = null;
            ultraGridColumn16.Header.VisiblePosition = 0;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn16.Width = 108;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn17.Header.Editor = null;
            ultraGridColumn17.Header.VisiblePosition = 1;
            ultraGridColumn17.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn17.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn17.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(84, 0);
            ultraGridColumn17.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn17.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn17.Width = 42;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn18.EditorComponent = this.cboBezeichnungstexte;
            ultraGridColumn18.Header.Caption = "Buchungstext";
            ultraGridColumn18.Header.Editor = null;
            ultraGridColumn18.Header.VisiblePosition = 2;
            ultraGridColumn18.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn18.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn18.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(224, 0);
            ultraGridColumn18.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn18.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn18.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            ultraGridColumn18.Width = 52;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn19.Header.Caption = "Gegenkonto";
            ultraGridColumn19.Header.Editor = null;
            ultraGridColumn19.Header.VisiblePosition = 14;
            ultraGridColumn19.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn19.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn19.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn19.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn19.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn20.Header.Caption = "Gegenkonto";
            ultraGridColumn20.Header.Editor = null;
            ultraGridColumn20.Header.VisiblePosition = 3;
            ultraGridColumn20.Hidden = true;
            ultraGridColumn20.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn20.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn20.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn20.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn20.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance3.TextHAlignAsString = "Right";
            ultraGridColumn21.CellAppearance = appearance3;
            ultraGridColumn21.Format = "###,###,##0.00";
            ultraGridColumn21.Header.Caption = " Betrag";
            ultraGridColumn21.Header.Editor = null;
            ultraGridColumn21.Header.VisiblePosition = 5;
            ultraGridColumn21.Hidden = true;
            ultraGridColumn21.RowLayoutColumnInfo.OriginX = 12;
            ultraGridColumn21.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn21.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(76, 0);
            ultraGridColumn21.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn21.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn21.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Currency;
            ultraGridColumn21.Width = 42;
            ultraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance4.TextHAlignAsString = "Right";
            ultraGridColumn22.CellAppearance = appearance4;
            ultraGridColumn22.Format = "##0";
            ultraGridColumn22.Header.Editor = null;
            ultraGridColumn22.Header.VisiblePosition = 6;
            ultraGridColumn22.Hidden = true;
            ultraGridColumn22.RowLayoutColumnInfo.OriginX = 14;
            ultraGridColumn22.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn22.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(48, 0);
            ultraGridColumn22.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn22.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn22.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn22.Width = 36;
            ultraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn23.Header.Caption = "Rech.Nr";
            ultraGridColumn23.Header.Editor = null;
            ultraGridColumn23.Header.VisiblePosition = 8;
            ultraGridColumn23.RowLayoutColumnInfo.OriginX = 16;
            ultraGridColumn23.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn23.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(117, 0);
            ultraGridColumn23.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn23.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn23.Width = 52;
            ultraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn24.Header.Caption = "Klient";
            ultraGridColumn24.Header.Editor = null;
            ultraGridColumn24.Header.VisiblePosition = 4;
            ultraGridColumn24.RowLayoutColumnInfo.OriginX = 14;
            ultraGridColumn24.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn24.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(161, 0);
            ultraGridColumn24.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn24.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn24.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn24.Width = 106;
            ultraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn25.Header.Caption = "Kostenträger";
            ultraGridColumn25.Header.Editor = null;
            ultraGridColumn25.Header.VisiblePosition = 7;
            ultraGridColumn25.RowLayoutColumnInfo.OriginX = 12;
            ultraGridColumn25.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn25.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(206, 0);
            ultraGridColumn25.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn25.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn25.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn25.Width = 130;
            ultraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn26.Header.Editor = null;
            ultraGridColumn26.Header.VisiblePosition = 9;
            ultraGridColumn26.RowLayoutColumnInfo.OriginX = 18;
            ultraGridColumn26.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn26.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn26.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn27.Header.Caption = "Erstell am";
            ultraGridColumn27.Header.Editor = null;
            ultraGridColumn27.Header.VisiblePosition = 10;
            ultraGridColumn27.RowLayoutColumnInfo.OriginX = 20;
            ultraGridColumn27.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn27.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn27.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn28.Header.Caption = "Einrichtung";
            ultraGridColumn28.Header.Editor = null;
            ultraGridColumn28.Header.VisiblePosition = 13;
            ultraGridColumn28.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn28.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn28.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(160, 0);
            ultraGridColumn28.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn28.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn28.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            ultraGridColumn28.Width = 201;
            ultraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance5.TextHAlignAsString = "Right";
            ultraGridColumn29.CellAppearance = appearance5;
            ultraGridColumn29.Format = "###,###,##0.00";
            ultraGridColumn29.Header.Editor = null;
            ultraGridColumn29.Header.VisiblePosition = 11;
            ultraGridColumn29.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn29.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn29.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(83, 0);
            ultraGridColumn29.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn29.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn29.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Currency;
            ultraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance6.TextHAlignAsString = "Right";
            ultraGridColumn30.CellAppearance = appearance6;
            ultraGridColumn30.Format = "###,###,##0.00";
            ultraGridColumn30.Header.Editor = null;
            ultraGridColumn30.Header.VisiblePosition = 12;
            ultraGridColumn30.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn30.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn30.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(76, 0);
            ultraGridColumn30.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn30.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn30.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Currency;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            appearance7.TextHAlignAsString = "Right";
            summarySettings1.Appearance = appearance7;
            summarySettings1.DisplayFormat = "{0:C}";
            appearance8.TextHAlignAsString = "Right";
            summarySettings2.Appearance = appearance8;
            summarySettings2.DisplayFormat = "{0:C}";
            ultraGridBand1.Summaries.AddRange(new Infragistics.Win.UltraWinGrid.SummarySettings[] {
            summarySettings1,
            summarySettings2});
            ultraGridBand1.SummaryFooterCaption = "";
            this.uGridBookings.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.uGridBookings.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uGridBookings.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.uGridBookings.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            this.uGridBookings.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;
            this.uGridBookings.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.uGridBookings.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.uGridBookings.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            appearance9.BorderColor = System.Drawing.Color.White;
            this.uGridBookings.DisplayLayout.Override.SummaryFooterAppearance = appearance9;
            appearance10.BorderColor = System.Drawing.Color.White;
            this.uGridBookings.DisplayLayout.Override.SummaryFooterCaptionAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.uGridBookings.DisplayLayout.Override.SummaryValueAppearance = appearance11;
            this.uGridBookings.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            valueList1.Key = "Klienten";
            valueList2.Key = "Kostenträger";
            valueList3.Key = "MWSt";
            valueListItem1.DataValue = 10;
            valueListItem1.DisplayText = "10";
            valueListItem2.DataValue = 20;
            valueListItem2.DisplayText = "20";
            valueListItem3.DataValue = 30;
            valueListItem3.DisplayText = "30";
            valueList3.ValueListItems.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            valueList4.Key = "eKonto";
            valueList5.Key = "month";
            valueListItem4.DataValue = 1;
            valueListItem4.DisplayText = "1";
            valueListItem5.DataValue = 2;
            valueListItem5.DisplayText = "2";
            valueListItem6.DataValue = 3;
            valueListItem6.DisplayText = "3";
            valueListItem7.DataValue = 4;
            valueListItem7.DisplayText = "4";
            valueListItem8.DataValue = 5;
            valueListItem8.DisplayText = "5";
            valueListItem9.DataValue = 6;
            valueListItem9.DisplayText = "6";
            valueListItem10.DataValue = 7;
            valueListItem10.DisplayText = "7";
            valueListItem11.DataValue = 8;
            valueListItem11.DisplayText = "8";
            valueListItem12.DataValue = 9;
            valueListItem12.DisplayText = "9";
            valueListItem13.DataValue = 10;
            valueListItem13.DisplayText = "10";
            valueListItem14.DataValue = 11;
            valueListItem14.DisplayText = "11";
            valueListItem15.DataValue = 12;
            valueListItem15.DisplayText = "12";
            valueList5.ValueListItems.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem4,
            valueListItem5,
            valueListItem6,
            valueListItem7,
            valueListItem8,
            valueListItem9,
            valueListItem10,
            valueListItem11,
            valueListItem12,
            valueListItem13,
            valueListItem14,
            valueListItem15});
            valueList6.Key = "year";
            this.uGridBookings.DisplayLayout.ValueLists.AddRange(new Infragistics.Win.ValueList[] {
            valueList1,
            valueList2,
            valueList3,
            valueList4,
            valueList5,
            valueList6});
            this.uGridBookings.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.uGridBookings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uGridBookings.Location = new System.Drawing.Point(7, 3);
            this.uGridBookings.Name = "uGridBookings";
            this.uGridBookings.Size = new System.Drawing.Size(1143, 250);
            this.uGridBookings.TabIndex = 0;
            this.uGridBookings.Text = "Abrechnungen";
            this.uGridBookings.AfterRowActivate += new System.EventHandler(this.uGridBookings_AfterRowActivate);
            this.uGridBookings.AfterRowInsert += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.uGridBookings_AfterRowInsert);
            this.uGridBookings.BeforeRowActivate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.uGridBookings_BeforeRowActivate);
            this.uGridBookings.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGridBookings_CellChange);
            this.uGridBookings.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.uGridBookings_AfterSelectChange);
            this.uGridBookings.BeforeSelectChange += new Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventHandler(this.uGridBookings_BeforeSelectChange);
            this.uGridBookings.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.uGridAbrech_BeforeCellActivate);
            this.uGridBookings.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.uGridBookings_BeforeRowsDeleted);
            this.uGridBookings.BeforeRowRegionScroll += new Infragistics.Win.UltraWinGrid.BeforeRowRegionScrollEventHandler(this.uGridBookings_BeforeRowRegionScroll);
            this.uGridBookings.DoubleClick += new System.EventHandler(this.uGridBookings_DoubleClick);
            // 
            // dbPMDS1
            // 
            this.dbPMDS1.DataSetName = "dbPMDS";
            this.dbPMDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.panelPrint);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(1155, 256);
            // 
            // panelPrint
            // 
            this.panelPrint.Controls.Add(this.uGridBagLayoutPanelBooking);
            this.panelPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrint.Location = new System.Drawing.Point(0, 0);
            this.panelPrint.Name = "panelPrint";
            this.panelPrint.Size = new System.Drawing.Size(1155, 256);
            this.panelPrint.TabIndex = 1;
            // 
            // uGridBagLayoutPanelBooking
            // 
            this.uGridBagLayoutPanelBooking.Controls.Add(this.ucprint1);
            this.uGridBagLayoutPanelBooking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGridBagLayoutPanelBooking.ExpandToFitHeight = true;
            this.uGridBagLayoutPanelBooking.ExpandToFitWidth = true;
            this.uGridBagLayoutPanelBooking.Location = new System.Drawing.Point(0, 0);
            this.uGridBagLayoutPanelBooking.Name = "uGridBagLayoutPanelBooking";
            this.uGridBagLayoutPanelBooking.Size = new System.Drawing.Size(1155, 256);
            this.uGridBagLayoutPanelBooking.TabIndex = 1;
            // 
            // ucprint1
            // 
            this.ucprint1.BackColor = System.Drawing.Color.White;
            this.ucprint1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 5;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            gridBagConstraint1.Insets.Top = 5;
            this.uGridBagLayoutPanelBooking.SetGridBagConstraint(this.ucprint1, gridBagConstraint1);
            this.ucprint1.Location = new System.Drawing.Point(5, 5);
            this.ucprint1.Name = "ucprint1";
            this.uGridBagLayoutPanelBooking.SetPreferredSize(this.ucprint1, new System.Drawing.Size(579, 156));
            this.ucprint1.Size = new System.Drawing.Size(1145, 246);
            this.ucprint1.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.ContextMenuStrip = this.contextMenuStripBooking;
            this.panelTop.Controls.Add(this.btnExportExcel);
            this.panelTop.Controls.Add(this.panelButtonsAddDel);
            this.panelTop.Controls.Add(this.btnPrint);
            this.panelTop.Controls.Add(this.grpSuche);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1159, 144);
            this.panelTop.TabIndex = 0;
            // 
            // contextMenuStripBooking
            // 
            this.contextMenuStripBooking.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.auswahlNeuLadenToolStripMenuItem});
            this.contextMenuStripBooking.Name = "contextMenuStrip1";
            this.contextMenuStripBooking.Size = new System.Drawing.Size(175, 26);
            // 
            // auswahlNeuLadenToolStripMenuItem
            // 
            this.auswahlNeuLadenToolStripMenuItem.Name = "auswahlNeuLadenToolStripMenuItem";
            this.auswahlNeuLadenToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.auswahlNeuLadenToolStripMenuItem.Text = "Auswahl neu laden";
            this.auswahlNeuLadenToolStripMenuItem.Click += new System.EventHandler(this.auswahlNeuLadenToolStripMenuItem_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance12.Image = ((object)(resources.GetObject("appearance12.Image")));
            appearance12.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance12.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnExportExcel.Appearance = appearance12;
            this.btnExportExcel.AutoWorkLayout = false;
            this.btnExportExcel.IsStandardControl = false;
            this.btnExportExcel.Location = new System.Drawing.Point(1122, 122);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(29, 22);
            this.btnExportExcel.TabIndex = 104;
            this.btnExportExcel.Tag = "P";
            ultraToolTipInfo1.ToolTipText = "Tabelle nach Excel exportieren";
            ultraToolTipInfo1.ToolTipTitle = "ExportE xcel";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnExportExcel, ultraToolTipInfo1);
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // panelButtonsAddDel
            // 
            this.panelButtonsAddDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtonsAddDel.Controls.Add(this.btnAdd);
            this.panelButtonsAddDel.Controls.Add(this.btnDelete);
            this.panelButtonsAddDel.Location = new System.Drawing.Point(932, 123);
            this.panelButtonsAddDel.Name = "panelButtonsAddDel";
            this.panelButtonsAddDel.Size = new System.Drawing.Size(55, 20);
            this.panelButtonsAddDel.TabIndex = 103;
            // 
            // btnAdd
            // 
            appearance18.BackColor = System.Drawing.Color.Transparent;
            appearance18.Image = ((object)(resources.GetObject("appearance18.Image")));
            appearance18.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance18.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance18.TextVAlignAsString = "Middle";
            this.btnAdd.Appearance = appearance18;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(0, -1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 22);
            this.btnAdd.TabIndex = 102;
            this.btnAdd.TabStop = false;
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            appearance19.BackColor = System.Drawing.Color.Transparent;
            appearance19.Image = ((object)(resources.GetObject("appearance19.Image")));
            appearance19.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance19.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance19.TextVAlignAsString = "Middle";
            this.btnDelete.Appearance = appearance19;
            this.btnDelete.AutoWorkLayout = false;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelete.DoOnClick = true;
            this.btnDelete.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDelete.IsStandardControl = true;
            this.btnDelete.Location = new System.Drawing.Point(25, -1);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 22);
            this.btnDelete.TabIndex = 99;
            this.btnDelete.TabStop = false;
            this.btnDelete.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDelete.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance20.Image = ((object)(resources.GetObject("appearance20.Image")));
            appearance20.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance20.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnPrint.Appearance = appearance20;
            this.btnPrint.AutoWorkLayout = false;
            this.btnPrint.IsStandardControl = false;
            this.btnPrint.Location = new System.Drawing.Point(988, 122);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(134, 22);
            this.btnPrint.TabIndex = 101;
            this.btnPrint.Tag = "P";
            this.btnPrint.Text = "Buchungen drucken";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // grpSuche
            // 
            this.grpSuche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance21.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpSuche.Appearance = appearance21;
            this.grpSuche.Controls.Add(this.ucKlinikDropDown1);
            this.grpSuche.Controls.Add(this.lblZurücksetzen);
            this.grpSuche.Controls.Add(this.cboBezeichnungstexte);
            this.grpSuche.Controls.Add(this.dtBis);
            this.grpSuche.Controls.Add(this.dtVon);
            this.grpSuche.Controls.Add(this.cboKonto);
            this.grpSuche.Controls.Add(this.cboKlienten);
            this.grpSuche.Controls.Add(this.cboKostenträger);
            this.grpSuche.Controls.Add(this.txtText);
            this.grpSuche.Controls.Add(this.lblText);
            this.grpSuche.Controls.Add(this.butSearch);
            this.grpSuche.Controls.Add(this.lblKonto);
            this.grpSuche.Controls.Add(this.lblKostenträger);
            this.grpSuche.Controls.Add(this.btnTimes);
            this.grpSuche.Controls.Add(this.lblBis);
            this.grpSuche.Controls.Add(this.lblVon);
            this.grpSuche.Controls.Add(this.lblKlienten);
            this.grpSuche.Location = new System.Drawing.Point(7, 7);
            this.grpSuche.Name = "grpSuche";
            this.grpSuche.Size = new System.Drawing.Size(1144, 109);
            this.grpSuche.TabIndex = 0;
            this.grpSuche.Text = "Kontobuchungen filtern";
            // 
            // ucKlinikDropDown1
            // 
            this.ucKlinikDropDown1.BackColor = System.Drawing.Color.Silver;
            this.ucKlinikDropDown1.Location = new System.Drawing.Point(53, 51);
            this.ucKlinikDropDown1.Name = "ucKlinikDropDown1";
            this.ucKlinikDropDown1.Size = new System.Drawing.Size(33, 20);
            this.ucKlinikDropDown1.TabIndex = 164;
            this.ucKlinikDropDown1.Visible = false;
            // 
            // lblZurücksetzen
            // 
            appearance22.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance22.FontData.SizeInPoints = 7F;
            appearance22.ForeColor = System.Drawing.Color.Black;
            this.lblZurücksetzen.Appearance = appearance22;
            this.lblZurücksetzen.AutoSize = true;
            appearance23.FontData.UnderlineAsString = "True";
            appearance23.ForeColor = System.Drawing.Color.Black;
            this.lblZurücksetzen.HotTrackAppearance = appearance23;
            this.lblZurücksetzen.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblZurücksetzen.Location = new System.Drawing.Point(814, 60);
            this.lblZurücksetzen.Name = "lblZurücksetzen";
            this.lblZurücksetzen.Size = new System.Drawing.Size(72, 12);
            this.lblZurücksetzen.TabIndex = 159;
            this.lblZurücksetzen.Text = "Filter anwenden";
            this.lblZurücksetzen.UseAppStyling = false;
            this.lblZurücksetzen.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.lblZurücksetzen.Click += new System.EventHandler(this.lblZurücksetzen_Click);
            // 
            // dtBis
            // 
            this.dtBis.Location = new System.Drawing.Point(164, 24);
            this.dtBis.MaskInput = "{LOC}mm.yyyy";
            this.dtBis.Name = "dtBis";
            this.dtBis.ownFormat = "";
            this.dtBis.ownMaskInput = "";
            this.dtBis.Size = new System.Drawing.Size(79, 21);
            this.dtBis.TabIndex = 1;
            this.dtBis.Enter += new System.EventHandler(this.dtBis_Enter);
            this.dtBis.Leave += new System.EventHandler(this.dtBis_Leave);
            // 
            // dtVon
            // 
            this.dtVon.Location = new System.Drawing.Point(53, 24);
            this.dtVon.MaskInput = "{LOC}mm.yyyy";
            this.dtVon.Name = "dtVon";
            this.dtVon.ownFormat = "";
            this.dtVon.ownMaskInput = "";
            this.dtVon.Size = new System.Drawing.Size(79, 21);
            this.dtVon.TabIndex = 0;
            this.dtVon.Enter += new System.EventHandler(this.dtVon_Enter);
            this.dtVon.Leave += new System.EventHandler(this.dtVon_Leave);
            // 
            // cboKonto
            // 
            this.cboKonto.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cboKonto.Location = new System.Drawing.Point(400, 23);
            this.cboKonto.Name = "cboKonto";
            this.cboKonto.Size = new System.Drawing.Size(279, 21);
            this.cboKonto.TabIndex = 3;
            this.cboKonto.Enter += new System.EventHandler(this.cboKonto_Enter);
            this.cboKonto.Leave += new System.EventHandler(this.cboKonto_Leave);
            // 
            // cboKlienten
            // 
            this.cboKlienten.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cboKlienten.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cboKlienten.Location = new System.Drawing.Point(400, 77);
            this.cboKlienten.Name = "cboKlienten";
            this.cboKlienten.Size = new System.Drawing.Size(279, 21);
            this.cboKlienten.TabIndex = 5;
            this.cboKlienten.Enter += new System.EventHandler(this.cboKlienten_Enter);
            this.cboKlienten.Leave += new System.EventHandler(this.cboKlienten_Leave);
            // 
            // cboKostenträger
            // 
            this.cboKostenträger.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cboKostenträger.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cboKostenträger.Location = new System.Drawing.Point(400, 50);
            this.cboKostenträger.Name = "cboKostenträger";
            this.cboKostenträger.Size = new System.Drawing.Size(279, 21);
            this.cboKostenträger.TabIndex = 4;
            this.cboKostenträger.Enter += new System.EventHandler(this.cboKostenträger_Enter);
            this.cboKostenträger.Leave += new System.EventHandler(this.cboKostenträger_Leave);
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(772, 23);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(263, 21);
            this.txtText.TabIndex = 2;
            // 
            // lblText
            // 
            this.lblText.Location = new System.Drawing.Point(722, 27);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(44, 15);
            this.lblText.TabIndex = 112;
            this.lblText.Text = "Text";
            // 
            // butSearch
            // 
            appearance24.BackColor = System.Drawing.Color.Transparent;
            appearance24.Image = ((object)(resources.GetObject("appearance24.Image")));
            appearance24.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance24.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance24.TextVAlignAsString = "Middle";
            this.butSearch.Appearance = appearance24;
            this.butSearch.AutoWorkLayout = false;
            this.butSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.butSearch.DoOnClick = true;
            this.butSearch.IsStandardControl = true;
            this.butSearch.Location = new System.Drawing.Point(772, 53);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(36, 30);
            this.butSearch.TabIndex = 6;
            this.butSearch.TabStop = false;
            this.butSearch.TYPE = PMDS.GUI.ucButton.ButtonType.Search;
            this.butSearch.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // lblKonto
            // 
            this.lblKonto.Location = new System.Drawing.Point(298, 28);
            this.lblKonto.Name = "lblKonto";
            this.lblKonto.Size = new System.Drawing.Size(98, 15);
            this.lblKonto.TabIndex = 108;
            this.lblKonto.Text = "Konto";
            // 
            // lblKostenträger
            // 
            this.lblKostenträger.Location = new System.Drawing.Point(298, 54);
            this.lblKostenträger.Name = "lblKostenträger";
            this.lblKostenträger.Size = new System.Drawing.Size(99, 19);
            this.lblKostenträger.TabIndex = 106;
            this.lblKostenträger.Text = "Kostenträger";
            // 
            // btnTimes
            // 
            this.btnTimes.Location = new System.Drawing.Point(249, 23);
            this.btnTimes.Name = "btnTimes";
            this.btnTimes.ShowFocusRect = false;
            this.btnTimes.Size = new System.Drawing.Size(21, 24);
            this.btnTimes.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.btnTimes.TabIndex = 100;
            this.btnTimes.Click += new System.EventHandler(this.btnTimes_Click);
            this.btnTimes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnTimes_MouseUp);
            // 
            // lblBis
            // 
            this.lblBis.Location = new System.Drawing.Point(139, 27);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(27, 15);
            this.lblBis.TabIndex = 4;
            this.lblBis.Text = "bis";
            // 
            // lblVon
            // 
            this.lblVon.Location = new System.Drawing.Point(10, 27);
            this.lblVon.Name = "lblVon";
            this.lblVon.Size = new System.Drawing.Size(39, 15);
            this.lblVon.TabIndex = 3;
            this.lblVon.Text = "Von";
            // 
            // lblKlienten
            // 
            this.lblKlienten.Location = new System.Drawing.Point(298, 81);
            this.lblKlienten.Name = "lblKlienten";
            this.lblKlienten.Size = new System.Drawing.Size(98, 15);
            this.lblKlienten.TabIndex = 104;
            this.lblKlienten.Text = "Klienten";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lblCount);
            this.panelBottom.Controls.Add(this.panelButtonSpeichern);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 426);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1159, 32);
            this.panelBottom.TabIndex = 1;
            // 
            // lblCount
            // 
            appearance13.FontData.SizeInPoints = 7.5F;
            this.lblCount.Appearance = appearance13;
            this.lblCount.Location = new System.Drawing.Point(8, 3);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(292, 15);
            this.lblCount.TabIndex = 8;
            // 
            // panelButtonSpeichern
            // 
            this.panelButtonSpeichern.Controls.Add(this.lblSaldo);
            this.panelButtonSpeichern.Controls.Add(this.btnReload);
            this.panelButtonSpeichern.Controls.Add(this.btnSave);
            this.panelButtonSpeichern.Controls.Add(this.btnReset);
            this.panelButtonSpeichern.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtonSpeichern.Location = new System.Drawing.Point(540, 0);
            this.panelButtonSpeichern.Name = "panelButtonSpeichern";
            this.panelButtonSpeichern.Size = new System.Drawing.Size(619, 32);
            this.panelButtonSpeichern.TabIndex = 106;
            // 
            // lblSaldo
            // 
            appearance14.FontData.SizeInPoints = 7.5F;
            appearance14.TextHAlignAsString = "Right";
            this.lblSaldo.Appearance = appearance14;
            this.lblSaldo.Location = new System.Drawing.Point(32, 3);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(292, 15);
            this.lblSaldo.TabIndex = 106;
            // 
            // btnReload
            // 
            this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance15.Image = ((object)(resources.GetObject("appearance15.Image")));
            appearance15.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnReload.Appearance = appearance15;
            this.btnReload.AutoWorkLayout = false;
            this.btnReload.IsStandardControl = false;
            this.btnReload.Location = new System.Drawing.Point(342, 1);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(88, 28);
            this.btnReload.TabIndex = 105;
            this.btnReload.Text = "Neu laden";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnSave
            // 
            appearance16.BackColor = System.Drawing.Color.Transparent;
            appearance16.Image = ((object)(resources.GetObject("appearance16.Image")));
            appearance16.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance16.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance16.TextVAlignAsString = "Middle";
            this.btnSave.Appearance = appearance16;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.DoOnClick = true;
            this.btnSave.IsStandardControl = true;
            this.btnSave.Location = new System.Drawing.Point(524, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 28);
            this.btnSave.TabIndex = 103;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Speichern";
            this.btnSave.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnSave.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnSave.Click += new System.EventHandler(this.ucSave_Click);
            // 
            // btnReset
            // 
            appearance17.BackColor = System.Drawing.Color.Transparent;
            appearance17.Image = ((object)(resources.GetObject("appearance17.Image")));
            appearance17.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance17.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance17.TextVAlignAsString = "Middle";
            this.btnReset.Appearance = appearance17;
            this.btnReset.AutoWorkLayout = false;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnReset.DoOnClick = true;
            this.btnReset.IsStandardControl = true;
            this.btnReset.Location = new System.Drawing.Point(431, 1);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(92, 28);
            this.btnReset.TabIndex = 104;
            this.btnReset.TabStop = false;
            this.btnReset.Text = "Rückgängig";
            this.btnReset.TYPE = PMDS.GUI.ucButton.ButtonType.Undo;
            this.btnReset.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 0;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.WindowsVista;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // panelAll
            // 
            this.panelAll.Controls.Add(this.panelBookings);
            this.panelAll.Controls.Add(this.panelBottom);
            this.panelAll.Controls.Add(this.panelTop);
            this.panelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAll.Location = new System.Drawing.Point(0, 0);
            this.panelAll.Name = "panelAll";
            this.panelAll.Size = new System.Drawing.Size(1159, 458);
            this.panelAll.TabIndex = 4;
            // 
            // panelBookings
            // 
            this.panelBookings.Controls.Add(this.ultraTabControl1);
            this.panelBookings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBookings.Location = new System.Drawing.Point(0, 144);
            this.panelBookings.Name = "panelBookings";
            this.panelBookings.Size = new System.Drawing.Size(1159, 282);
            this.panelBookings.TabIndex = 102;
            // 
            // ultraTabControl1
            // 
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl2);
            this.ultraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.Size = new System.Drawing.Size(1159, 282);
            this.ultraTabControl1.TabIndex = 101;
            ultraTab1.Key = "Buchungen";
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "Buchungen";
            ultraTab2.Key = "Drucken";
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "Drucken";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2});
            this.ultraTabControl1.UseAppStyling = false;
            this.ultraTabControl1.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.ultraTabControl1_SelectedTabChanged);
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(1155, 256);
            // 
            // ultraGridBagLayoutPanel1
            // 
            this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel1.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel1.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
            this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(694, 364);
            this.ultraGridBagLayoutPanel1.TabIndex = 0;
            // 
            // ultraGridBagLayoutPanel2
            // 
            this.ultraGridBagLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.ultraGridBagLayoutPanel2.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel2.Location = new System.Drawing.Point(169, 16);
            this.ultraGridBagLayoutPanel2.Name = "ultraGridBagLayoutPanel2";
            this.ultraGridBagLayoutPanel2.Size = new System.Drawing.Size(207, 50);
            this.ultraGridBagLayoutPanel2.TabIndex = 105;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // ucBookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelAll);
            this.Name = "ucBookings";
            this.Size = new System.Drawing.Size(1159, 458);
            this.Resize += new System.EventHandler(this.ucCalcs_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.cboBezeichnungstexte)).EndInit();
            this.ultraTabPageControl1.ResumeLayout(false);
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uGridBookings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPMDS1)).EndInit();
            this.ultraTabPageControl2.ResumeLayout(false);
            this.panelPrint.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uGridBagLayoutPanelBooking)).EndInit();
            this.uGridBagLayoutPanelBooking.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.contextMenuStripBooking.ResumeLayout(false);
            this.panelButtonsAddDel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpSuche)).EndInit();
            this.grpSuche.ResumeLayout(false);
            this.grpSuche.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKlienten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKostenträger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtText)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelButtonSpeichern.ResumeLayout(false);
            this.panelAll.ResumeLayout(false);
            this.panelBookings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel panelTop;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtVon;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtBis;
        private QS2.Desktop.ControlManagment.BaseLabel lblBis;
        private QS2.Desktop.ControlManagment.BaseLabel lblVon;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private QS2.Desktop.ControlManagment.BaseGroupBox grpSuche;
        private QS2.Desktop.ControlManagment.BasePanel panelAll;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private QS2.Desktop.ControlManagment.BasePanel panelGrid;
        private Infragistics.Win.Misc.UltraDropDownButton btnTimes;
        private Infragistics.Win.Misc.UltraGridBagLayoutManager ultraGridBagLayoutManager1;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel2;
        private QS2.Desktop.ControlManagment.BaseLabel lblKostenträger;
        private QS2.Desktop.ControlManagment.BaseLabel lblKlienten;
        private QS2.Desktop.ControlManagment.BaseLabel lblKonto;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripBooking;
        private System.Windows.Forms.ToolStripMenuItem auswahlNeuLadenToolStripMenuItem;
        public PMDS.GUI.ucButton btnSave;
        public PMDS.GUI.ucButton btnReset;
        public PMDS.GUI.ucButton butSearch;
        public PMDS.GUI.ucButton btnDelete;
        public PMDS.GUI.ucButton btnAdd;
        public QS2.Desktop.ControlManagment.BaseButton btnPrint;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private QS2.Desktop.ControlManagment.BaseLabel lblText;
        public PMDS.Calc.Logic.dbCalc dbPMDS1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private QS2.Desktop.ControlManagment.BasePanel panelBookings;
        public PMDS.Calc.Logic.ucprint ucprint1;
        private QS2.Desktop.ControlManagment.BasePanel panelPrint;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel uGridBagLayoutPanelBooking;
        public QS2.Desktop.ControlManagment.BasePanel panelButtonSpeichern;
        public QS2.Desktop.ControlManagment.BasePanel panelButtonsAddDel;
        public QS2.Desktop.ControlManagment.BasePanel panelBottom;
        private QS2.Desktop.ControlManagment.BaseButton btnReload;
        public QS2.Desktop.ControlManagment.BaseButton btnExportExcel;
        private QS2.Desktop.ControlManagment.BaseComboEditor cboBezeichnungstexte;
        public GUI.BaseControls.ucKlinikDropDown ucKlinikDropDown1;
        public QS2.Desktop.ControlManagment.BaseGrid uGridBookings;
        public QS2.Desktop.ControlManagment.BaseComboEditor cboKlienten;
        public QS2.Desktop.ControlManagment.BaseComboEditor cboKostenträger;
        public QS2.Desktop.ControlManagment.BaseComboEditor cboKonto;
        public QS2.Desktop.ControlManagment.BaseTextEditor txtText;
        public QS2.Desktop.ControlManagment.BaseLabel lblCount;
        public QS2.Desktop.ControlManagment.BaseTabControl ultraTabControl1;
        public QS2.Desktop.ControlManagment.BaseLabel lblSaldo;
        internal QS2.Desktop.ControlManagment.BaseLabel lblZurücksetzen;
    }
}
