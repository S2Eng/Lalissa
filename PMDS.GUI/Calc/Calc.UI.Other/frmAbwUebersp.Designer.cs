namespace PMDS.Calc.UI.Admin
{
    partial class frmAbwÜbersp
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint2 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbwÜbersp));
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Nach Abrechnung/Abwesenheiten überspielen", Infragistics.Win.ToolTipImage.Default, "Überspielen", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Tabelle nach Excel exportieren", Infragistics.Win.ToolTipImage.Default, "ExportE xcel", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Klienten mit der Einstellung \'Abwesenheiten händisch übernehmen\' ebenfalls anzeig" +
        "en", Infragistics.Win.ToolTipImage.Default, "Händisch", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("abw", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Überspielen");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KlientName");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Grund", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Von");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bis");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("bereitsÜbersp");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Händisch");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDUrlaubVerlauf");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlient");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik", -1, "dropDownKliniken");
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            this.ultraGridBagLayoutPanelAll = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.panelGesamt = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelGrid = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraGridBagLayoutPanel2 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.panelUnten = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblCount = new QS2.Desktop.ControlManagment.BaseLabel();
            this.butAlleKeine = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnClose = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelOben = new QS2.Desktop.ControlManagment.BasePanel();
            this.chkEingepDelete = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.btnÜberspielen = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnExportExcel = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraGroupBoxSuche = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.chkHändischJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.uOptÜbersp = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.dtBis = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.dtVon = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblBis = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnTimes = new Infragistics.Win.Misc.UltraDropDownButton();
            this.lblVon = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.numMinTageAbwesenheit = new QS2.Desktop.ControlManagment.BaseNumericEditor();
            this.lblMinTageAbwesenheit = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblMinTageAbwesenheitTage = new QS2.Desktop.ControlManagment.BaseLabel();
            this.uGridAbw = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsAbwÜbersp1 = new PMDS.GUI.Calc.Calc.UI.Other.dsAbwÜbersp();
            this.ucKlinikDropDown1 = new PMDS.GUI.BaseControls.ucKlinikDropDown();
            this.btnSearch = new PMDS.GUI.ucButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanelAll)).BeginInit();
            this.ultraGridBagLayoutPanelAll.SuspendLayout();
            this.panelGesamt.SuspendLayout();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel2)).BeginInit();
            this.ultraGridBagLayoutPanel2.SuspendLayout();
            this.panelUnten.SuspendLayout();
            this.panelOben.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEingepDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxSuche)).BeginInit();
            this.ultraGroupBoxSuche.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkHändischJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uOptÜbersp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinTageAbwesenheit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGridAbw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAbwÜbersp1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGridBagLayoutPanelAll
            // 
            this.ultraGridBagLayoutPanelAll.Controls.Add(this.panelGesamt);
            this.ultraGridBagLayoutPanelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanelAll.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanelAll.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanelAll.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanelAll.Margin = new System.Windows.Forms.Padding(4);
            this.ultraGridBagLayoutPanelAll.Name = "ultraGridBagLayoutPanelAll";
            this.ultraGridBagLayoutPanelAll.Size = new System.Drawing.Size(1185, 585);
            this.ultraGridBagLayoutPanelAll.TabIndex = 0;
            // 
            // panelGesamt
            // 
            this.panelGesamt.BackColor = System.Drawing.Color.Gainsboro;
            this.panelGesamt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGesamt.Controls.Add(this.panelGrid);
            this.panelGesamt.Controls.Add(this.panelUnten);
            this.panelGesamt.Controls.Add(this.panelOben);
            gridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint2.Insets.Bottom = 5;
            gridBagConstraint2.Insets.Left = 5;
            gridBagConstraint2.Insets.Right = 5;
            gridBagConstraint2.Insets.Top = 5;
            gridBagConstraint2.OriginX = 0;
            gridBagConstraint2.OriginY = 0;
            this.ultraGridBagLayoutPanelAll.SetGridBagConstraint(this.panelGesamt, gridBagConstraint2);
            this.panelGesamt.Location = new System.Drawing.Point(5, 5);
            this.panelGesamt.Margin = new System.Windows.Forms.Padding(4);
            this.panelGesamt.Name = "panelGesamt";
            this.ultraGridBagLayoutPanelAll.SetPreferredSize(this.panelGesamt, new System.Drawing.Size(266, 123));
            this.panelGesamt.Size = new System.Drawing.Size(1175, 575);
            this.panelGesamt.TabIndex = 0;
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.ultraGridBagLayoutPanel2);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 100);
            this.panelGrid.Margin = new System.Windows.Forms.Padding(4);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(1173, 429);
            this.panelGrid.TabIndex = 159;
            // 
            // ultraGridBagLayoutPanel2
            // 
            this.ultraGridBagLayoutPanel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ultraGridBagLayoutPanel2.Controls.Add(this.uGridAbw);
            this.ultraGridBagLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel2.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel2.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.ultraGridBagLayoutPanel2.Name = "ultraGridBagLayoutPanel2";
            this.ultraGridBagLayoutPanel2.Size = new System.Drawing.Size(1173, 429);
            this.ultraGridBagLayoutPanel2.TabIndex = 0;
            // 
            // panelUnten
            // 
            this.panelUnten.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelUnten.Controls.Add(this.lblCount);
            this.panelUnten.Controls.Add(this.butAlleKeine);
            this.panelUnten.Controls.Add(this.btnClose);
            this.panelUnten.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelUnten.Location = new System.Drawing.Point(0, 529);
            this.panelUnten.Margin = new System.Windows.Forms.Padding(4);
            this.panelUnten.Name = "panelUnten";
            this.panelUnten.Size = new System.Drawing.Size(1173, 44);
            this.panelUnten.TabIndex = 158;
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance6.FontData.SizeInPoints = 7.5F;
            appearance6.TextHAlignAsString = "Right";
            this.lblCount.Appearance = appearance6;
            this.lblCount.Location = new System.Drawing.Point(783, 11);
            this.lblCount.Margin = new System.Windows.Forms.Padding(4);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(260, 20);
            this.lblCount.TabIndex = 10;
            // 
            // butAlleKeine
            // 
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance7.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.butAlleKeine.Appearance = appearance7;
            this.butAlleKeine.AutoWorkLayout = false;
            this.butAlleKeine.IsStandardControl = false;
            this.butAlleKeine.Location = new System.Drawing.Point(7, 5);
            this.butAlleKeine.Margin = new System.Windows.Forms.Padding(4);
            this.butAlleKeine.Name = "butAlleKeine";
            this.butAlleKeine.Size = new System.Drawing.Size(65, 25);
            this.butAlleKeine.TabIndex = 7;
            this.butAlleKeine.Tag = "A";
            this.butAlleKeine.Text = "Alle";
            this.butAlleKeine.Click += new System.EventHandler(this.butAlleKeine_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance8.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnClose.Appearance = appearance8;
            this.btnClose.AutoWorkLayout = false;
            this.btnClose.IsStandardControl = false;
            this.btnClose.Location = new System.Drawing.Point(1069, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 33);
            this.btnClose.TabIndex = 2;
            this.btnClose.Tag = "ImageNormal=.ico;";
            this.btnClose.Text = "Schließen";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelOben
            // 
            this.panelOben.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelOben.Controls.Add(this.ucKlinikDropDown1);
            this.panelOben.Controls.Add(this.chkEingepDelete);
            this.panelOben.Controls.Add(this.btnÜberspielen);
            this.panelOben.Controls.Add(this.btnExportExcel);
            this.panelOben.Controls.Add(this.ultraGroupBoxSuche);
            this.panelOben.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOben.Location = new System.Drawing.Point(0, 0);
            this.panelOben.Margin = new System.Windows.Forms.Padding(4);
            this.panelOben.Name = "panelOben";
            this.panelOben.Size = new System.Drawing.Size(1173, 100);
            this.panelOben.TabIndex = 157;
            // 
            // chkEingepDelete
            // 
            this.chkEingepDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEingepDelete.Checked = true;
            this.chkEingepDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEingepDelete.Location = new System.Drawing.Point(941, 54);
            this.chkEingepDelete.Margin = new System.Windows.Forms.Padding(4);
            this.chkEingepDelete.Name = "chkEingepDelete";
            this.chkEingepDelete.Size = new System.Drawing.Size(221, 42);
            this.chkEingepDelete.TabIndex = 8;
            this.chkEingepDelete.Text = "Bereits eingespielte löschen";
            this.chkEingepDelete.Visible = false;
            // 
            // btnÜberspielen
            // 
            this.btnÜberspielen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance9.Image = ((object)(resources.GetObject("appearance9.Image")));
            appearance9.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnÜberspielen.Appearance = appearance9;
            this.btnÜberspielen.AutoWorkLayout = false;
            this.btnÜberspielen.IsStandardControl = false;
            this.btnÜberspielen.Location = new System.Drawing.Point(941, 9);
            this.btnÜberspielen.Margin = new System.Windows.Forms.Padding(4);
            this.btnÜberspielen.Name = "btnÜberspielen";
            this.btnÜberspielen.Size = new System.Drawing.Size(156, 39);
            this.btnÜberspielen.TabIndex = 6;
            this.btnÜberspielen.Text = "Überspielen";
            ultraToolTipInfo1.ToolTipText = "Nach Abrechnung/Abwesenheiten überspielen";
            ultraToolTipInfo1.ToolTipTitle = "Überspielen";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnÜberspielen, ultraToolTipInfo1);
            this.btnÜberspielen.Click += new System.EventHandler(this.btnÜberspielen_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance10.Image = ((object)(resources.GetObject("appearance10.Image")));
            appearance10.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance10.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnExportExcel.Appearance = appearance10;
            this.btnExportExcel.AutoWorkLayout = false;
            this.btnExportExcel.IsStandardControl = false;
            this.btnExportExcel.Location = new System.Drawing.Point(1105, 9);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(57, 39);
            this.btnExportExcel.TabIndex = 7;
            this.btnExportExcel.Tag = "P";
            ultraToolTipInfo2.ToolTipText = "Tabelle nach Excel exportieren";
            ultraToolTipInfo2.ToolTipTitle = "ExportE xcel";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnExportExcel, ultraToolTipInfo2);
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // ultraGroupBoxSuche
            // 
            appearance11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ultraGroupBoxSuche.Appearance = appearance11;
            this.ultraGroupBoxSuche.Controls.Add(this.numMinTageAbwesenheit);
            this.ultraGroupBoxSuche.Controls.Add(this.lblMinTageAbwesenheitTage);
            this.ultraGroupBoxSuche.Controls.Add(this.lblMinTageAbwesenheit);
            this.ultraGroupBoxSuche.Controls.Add(this.chkHändischJN);
            this.ultraGroupBoxSuche.Controls.Add(this.btnSearch);
            this.ultraGroupBoxSuche.Controls.Add(this.uOptÜbersp);
            this.ultraGroupBoxSuche.Controls.Add(this.dtBis);
            this.ultraGroupBoxSuche.Controls.Add(this.dtVon);
            this.ultraGroupBoxSuche.Controls.Add(this.lblBis);
            this.ultraGroupBoxSuche.Controls.Add(this.btnTimes);
            this.ultraGroupBoxSuche.Controls.Add(this.lblVon);
            this.ultraGroupBoxSuche.Location = new System.Drawing.Point(7, 9);
            this.ultraGroupBoxSuche.Margin = new System.Windows.Forms.Padding(4);
            this.ultraGroupBoxSuche.Name = "ultraGroupBoxSuche";
            this.ultraGroupBoxSuche.Size = new System.Drawing.Size(841, 82);
            this.ultraGroupBoxSuche.TabIndex = 157;
            this.ultraGroupBoxSuche.Text = "Suche nach Abwesenheiten im PMDS (Beginn oder Ende im Zeitraum)";
            // 
            // chkHändischJN
            // 
            this.chkHändischJN.Location = new System.Drawing.Point(593, 22);
            this.chkHändischJN.Margin = new System.Windows.Forms.Padding(4);
            this.chkHändischJN.Name = "chkHändischJN";
            this.chkHändischJN.Size = new System.Drawing.Size(103, 17);
            this.chkHändischJN.TabIndex = 4;
            this.chkHändischJN.Text = "Händisch";
            ultraToolTipInfo3.ToolTipText = "Klienten mit der Einstellung \'Abwesenheiten händisch übernehmen\' ebenfalls anzeig" +
    "en";
            ultraToolTipInfo3.ToolTipTitle = "Händisch";
            this.ultraToolTipManager1.SetUltraToolTip(this.chkHändischJN, ultraToolTipInfo3);
            this.chkHändischJN.CheckedChanged += new System.EventHandler(this.chkHändischJN_CheckedChanged);
            // 
            // uOptÜbersp
            // 
            appearance13.BackColor = System.Drawing.Color.Transparent;
            this.uOptÜbersp.Appearance = appearance13;
            this.uOptÜbersp.BackColor = System.Drawing.Color.Transparent;
            this.uOptÜbersp.BackColorInternal = System.Drawing.Color.Transparent;
            this.uOptÜbersp.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            valueListItem2.DataValue = 0;
            valueListItem2.DisplayText = "Nicht überspielt oder geändert";
            valueListItem3.DataValue = 1;
            valueListItem3.DisplayText = "Bereits überspielt";
            valueListItem1.DataValue = -1;
            valueListItem1.DisplayText = "Alle";
            this.uOptÜbersp.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem2,
            valueListItem3,
            valueListItem1});
            this.uOptÜbersp.Location = new System.Drawing.Point(376, 23);
            this.uOptÜbersp.Margin = new System.Windows.Forms.Padding(4);
            this.uOptÜbersp.Name = "uOptÜbersp";
            this.uOptÜbersp.Size = new System.Drawing.Size(209, 55);
            this.uOptÜbersp.TabIndex = 3;
            this.uOptÜbersp.ValueChanged += new System.EventHandler(this.uOptÜbersp_ValueChanged);
            // 
            // dtBis
            // 
            appearance14.TextHAlignAsString = "Center";
            this.dtBis.Appearance = appearance14;
            this.dtBis.DateTime = new System.DateTime(2009, 11, 2, 0, 0, 0, 0);
            this.dtBis.Location = new System.Drawing.Point(199, 26);
            this.dtBis.Margin = new System.Windows.Forms.Padding(4);
            this.dtBis.Name = "dtBis";
            this.dtBis.ownFormat = "";
            this.dtBis.ownMaskInput = "";
            this.dtBis.Size = new System.Drawing.Size(120, 24);
            this.dtBis.TabIndex = 1;
            this.dtBis.Value = new System.DateTime(2009, 11, 2, 0, 0, 0, 0);
            this.dtBis.ValueChanged += new System.EventHandler(this.dtBis_ValueChanged);
            // 
            // dtVon
            // 
            appearance15.TextHAlignAsString = "Center";
            this.dtVon.Appearance = appearance15;
            this.dtVon.DateTime = new System.DateTime(2009, 11, 2, 0, 0, 0, 0);
            this.dtVon.Location = new System.Drawing.Point(44, 26);
            this.dtVon.Margin = new System.Windows.Forms.Padding(4);
            this.dtVon.Name = "dtVon";
            this.dtVon.ownFormat = "";
            this.dtVon.ownMaskInput = "";
            this.dtVon.Size = new System.Drawing.Size(120, 24);
            this.dtVon.TabIndex = 0;
            this.dtVon.Value = new System.DateTime(2009, 11, 2, 0, 0, 0, 0);
            this.dtVon.ValueChanged += new System.EventHandler(this.dtVon_ValueChanged);
            // 
            // lblBis
            // 
            this.lblBis.Location = new System.Drawing.Point(169, 29);
            this.lblBis.Margin = new System.Windows.Forms.Padding(4);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(36, 18);
            this.lblBis.TabIndex = 4;
            this.lblBis.Text = "bis";
            // 
            // btnTimes
            // 
            this.btnTimes.Location = new System.Drawing.Point(325, 27);
            this.btnTimes.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimes.Name = "btnTimes";
            this.btnTimes.ShowFocusRect = false;
            this.btnTimes.Size = new System.Drawing.Size(20, 23);
            this.btnTimes.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.btnTimes.TabIndex = 100;
            this.btnTimes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnTimes_MouseUp);
            // 
            // lblVon
            // 
            this.lblVon.Location = new System.Drawing.Point(8, 29);
            this.lblVon.Margin = new System.Windows.Forms.Padding(4);
            this.lblVon.Name = "lblVon";
            this.lblVon.Size = new System.Drawing.Size(36, 18);
            this.lblVon.TabIndex = 3;
            this.lblVon.Text = "Von";
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 0;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // numMinTageAbwesenheit
            // 
            this.numMinTageAbwesenheit.Location = new System.Drawing.Point(199, 57);
            this.numMinTageAbwesenheit.MaxValue = 1000;
            this.numMinTageAbwesenheit.MinValue = 0;
            this.numMinTageAbwesenheit.Name = "numMinTageAbwesenheit";
            this.numMinTageAbwesenheit.NullText = "0";
            this.numMinTageAbwesenheit.Size = new System.Drawing.Size(92, 24);
            this.numMinTageAbwesenheit.TabIndex = 2;
            this.numMinTageAbwesenheit.ValueChanged += new System.EventHandler(this.numMinTageAbwesenheit_ValueChanged);
            // 
            // lblMinTageAbwesenheit
            // 
            this.lblMinTageAbwesenheit.Location = new System.Drawing.Point(8, 61);
            this.lblMinTageAbwesenheit.Margin = new System.Windows.Forms.Padding(4);
            this.lblMinTageAbwesenheit.Name = "lblMinTageAbwesenheit";
            this.lblMinTageAbwesenheit.Size = new System.Drawing.Size(197, 18);
            this.lblMinTageAbwesenheit.TabIndex = 165;
            this.lblMinTageAbwesenheit.Text = "Nur Abwesenheiten länger  als ";
            // 
            // lblMinTageAbwesenheitTage
            // 
            this.lblMinTageAbwesenheitTage.Location = new System.Drawing.Point(298, 61);
            this.lblMinTageAbwesenheitTage.Margin = new System.Windows.Forms.Padding(4);
            this.lblMinTageAbwesenheitTage.Name = "lblMinTageAbwesenheitTage";
            this.lblMinTageAbwesenheitTage.Size = new System.Drawing.Size(56, 18);
            this.lblMinTageAbwesenheitTage.TabIndex = 166;
            this.lblMinTageAbwesenheitTage.Text = "Tag(e)";
            // 
            // uGridAbw
            // 
            this.uGridAbw.AutoWork = true;
            this.uGridAbw.DataSource = this.dsAbwÜbersp1;
            appearance1.BackColor = System.Drawing.Color.White;
            this.uGridAbw.DisplayLayout.Appearance = appearance1;
            this.uGridAbw.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn12.Header.Editor = null;
            ultraGridColumn12.Header.VisiblePosition = 0;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn13.Header.Editor = null;
            ultraGridColumn13.Header.VisiblePosition = 1;
            ultraGridColumn13.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn13.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn13.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(56, 0);
            ultraGridColumn13.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn13.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance2.TextHAlignAsString = "Left";
            ultraGridColumn14.Header.Appearance = appearance2;
            ultraGridColumn14.Header.Caption = "Klient";
            ultraGridColumn14.Header.Editor = null;
            ultraGridColumn14.Header.VisiblePosition = 2;
            ultraGridColumn14.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn14.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn14.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(122, 0);
            ultraGridColumn14.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn14.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn14.Width = 200;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance3.TextHAlignAsString = "Left";
            ultraGridColumn15.Header.Appearance = appearance3;
            ultraGridColumn15.Header.Editor = null;
            ultraGridColumn15.Header.VisiblePosition = 3;
            ultraGridColumn15.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn15.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn15.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(207, 0);
            ultraGridColumn15.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn15.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance4.TextHAlignAsString = "Center";
            ultraGridColumn16.CellAppearance = appearance4;
            ultraGridColumn16.Header.Caption = "Von";
            ultraGridColumn16.Header.Editor = null;
            ultraGridColumn16.Header.VisiblePosition = 4;
            ultraGridColumn16.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn16.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn16.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(91, 0);
            ultraGridColumn16.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn16.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance5.TextHAlignAsString = "Center";
            ultraGridColumn17.CellAppearance = appearance5;
            ultraGridColumn17.Header.Editor = null;
            ultraGridColumn17.Header.VisiblePosition = 5;
            ultraGridColumn17.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn17.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn17.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(88, 0);
            ultraGridColumn17.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn17.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn18.Header.Caption = "Bereits überspielt";
            ultraGridColumn18.Header.Editor = null;
            ultraGridColumn18.Header.VisiblePosition = 6;
            ultraGridColumn18.RowLayoutColumnInfo.OriginX = 12;
            ultraGridColumn18.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn18.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn18.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn19.Header.Editor = null;
            ultraGridColumn19.Header.VisiblePosition = 7;
            ultraGridColumn19.RowLayoutColumnInfo.OriginX = 14;
            ultraGridColumn19.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn19.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn19.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn20.Header.Editor = null;
            ultraGridColumn20.Header.VisiblePosition = 8;
            ultraGridColumn20.Hidden = true;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn21.Header.Editor = null;
            ultraGridColumn21.Header.VisiblePosition = 9;
            ultraGridColumn21.Hidden = true;
            ultraGridColumn22.Header.Caption = "Einrichtung";
            ultraGridColumn22.Header.Editor = null;
            ultraGridColumn22.Header.VisiblePosition = 10;
            ultraGridColumn22.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn22.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn22.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(152, 0);
            ultraGridColumn22.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn22.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn22.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.uGridAbw.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.uGridAbw.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uGridAbw.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.uGridAbw.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            this.uGridAbw.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.uGridAbw.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.uGridAbw.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            this.uGridAbw.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            gridBagConstraint1.OriginX = 1;
            gridBagConstraint1.OriginY = 0;
            this.ultraGridBagLayoutPanel2.SetGridBagConstraint(this.uGridAbw, gridBagConstraint1);
            this.uGridAbw.Location = new System.Drawing.Point(5, 0);
            this.uGridAbw.Margin = new System.Windows.Forms.Padding(4);
            this.uGridAbw.Name = "uGridAbw";
            this.ultraGridBagLayoutPanel2.SetPreferredSize(this.uGridAbw, new System.Drawing.Size(733, 98));
            this.uGridAbw.Size = new System.Drawing.Size(1163, 429);
            this.uGridAbw.TabIndex = 0;
            this.uGridAbw.Text = "ultraGrid1";
            this.uGridAbw.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.uGridAbw_BeforeCellActivate);
            this.uGridAbw.BeforeRowRegionScroll += new Infragistics.Win.UltraWinGrid.BeforeRowRegionScrollEventHandler(this.uGridAbw_BeforeRowRegionScroll);
            this.uGridAbw.DoubleClick += new System.EventHandler(this.uGridAbw_DoubleClick);
            // 
            // dsAbwÜbersp1
            // 
            this.dsAbwÜbersp1.DataSetName = "dsAbwÜbersp";
            this.dsAbwÜbersp1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ucKlinikDropDown1
            // 
            this.ucKlinikDropDown1.BackColor = System.Drawing.Color.Silver;
            this.ucKlinikDropDown1.Location = new System.Drawing.Point(879, 9);
            this.ucKlinikDropDown1.Margin = new System.Windows.Forms.Padding(4);
            this.ucKlinikDropDown1.Name = "ucKlinikDropDown1";
            this.ucKlinikDropDown1.Size = new System.Drawing.Size(44, 25);
            this.ucKlinikDropDown1.TabIndex = 166;
            this.ucKlinikDropDown1.Visible = false;
            // 
            // btnSearch
            // 
            appearance12.BackColor = System.Drawing.Color.Transparent;
            appearance12.Image = ((object)(resources.GetObject("appearance12.Image")));
            appearance12.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance12.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSearch.Appearance = appearance12;
            this.btnSearch.AutoWorkLayout = false;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSearch.DoOnClick = true;
            this.btnSearch.IsStandardControl = true;
            this.btnSearch.Location = new System.Drawing.Point(776, 30);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(43, 33);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.TabStop = false;
            this.btnSearch.TYPE = PMDS.GUI.ucButton.ButtonType.Search;
            this.btnSearch.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmAbwÜbersp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1185, 585);
            this.Controls.Add(this.ultraGridBagLayoutPanelAll);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(997, 478);
            this.Name = "frmAbwÜbersp";
            this.Text = "Abrechnung - Abwesenheiten übernehmen";
            this.Load += new System.EventHandler(this.frmGetAbwesenheiten_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanelAll)).EndInit();
            this.ultraGridBagLayoutPanelAll.ResumeLayout(false);
            this.panelGesamt.ResumeLayout(false);
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel2)).EndInit();
            this.ultraGridBagLayoutPanel2.ResumeLayout(false);
            this.panelUnten.ResumeLayout(false);
            this.panelOben.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkEingepDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBoxSuche)).EndInit();
            this.ultraGroupBoxSuche.ResumeLayout(false);
            this.ultraGroupBoxSuche.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkHändischJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uOptÜbersp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinTageAbwesenheit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGridAbw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAbwÜbersp1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanelAll;
        private QS2.Desktop.ControlManagment.BasePanel panelGesamt;
        private QS2.Desktop.ControlManagment.BaseButton btnÜberspielen;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private QS2.Desktop.ControlManagment.BasePanel panelUnten;
        private QS2.Desktop.ControlManagment.BasePanel panelOben;
        private QS2.Desktop.ControlManagment.BasePanel panelGrid;
        private QS2.Desktop.ControlManagment.BaseButton btnClose;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel2;
        private QS2.Desktop.ControlManagment.BaseGrid uGridAbw;
        private QS2.Desktop.ControlManagment.BaseButton butAlleKeine;
        private QS2.Desktop.ControlManagment.BaseGroupBox ultraGroupBoxSuche;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtBis;
        private QS2.Desktop.ControlManagment.BaseLabel lblBis;
        private PMDS.GUI.ucButton btnSearch;
        private Infragistics.Win.Misc.UltraDropDownButton btnTimes;
        private QS2.Desktop.ControlManagment.BaseLabel lblVon;
        private PMDS.GUI.Calc.Calc.UI.Other.dsAbwÜbersp dsAbwÜbersp1;
        private QS2.Desktop.ControlManagment.BaseOptionSet uOptÜbersp;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public QS2.Desktop.ControlManagment.BaseButton btnExportExcel;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkEingepDelete;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkHändischJN;
        public GUI.BaseControls.ucKlinikDropDown ucKlinikDropDown1;
        public QS2.Desktop.ControlManagment.BaseLabel lblCount;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor dtVon;
        private QS2.Desktop.ControlManagment.BaseLabel lblMinTageAbwesenheit;
        private QS2.Desktop.ControlManagment.BaseNumericEditor numMinTageAbwesenheit;
        private QS2.Desktop.ControlManagment.BaseLabel lblMinTageAbwesenheitTage;
    }
}