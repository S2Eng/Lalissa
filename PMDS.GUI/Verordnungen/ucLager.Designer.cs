namespace PMDS.GUI.Verordnungen
{
    partial class ucLager
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton("Add");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("VO_Lager", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDVO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Seriennummer", -1, null, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Zustand", -1, 337493844);
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DatumErstellt", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBenutzerErstellt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LoginNameFreiErstellt");
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DatumGeaendert");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBenutzerGeaendert");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LoginNameFreiGeaendert");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Klient", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Anmerkung", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bereich", 2);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Abteilung", 3);
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(337493844);
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnAddVO = new QS2.Desktop.ControlManagment.BaseButton();
            this.grpSearch = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtSeriennummer = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblSeriennummer = new Infragistics.Win.Misc.UltraLabel();
            this.cboZustand = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblZustand = new Infragistics.Win.Misc.UltraLabel();
            this.udteTo = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.udteFrom = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.lblVerordnetBis = new Infragistics.Win.Misc.UltraLabel();
            this.lblVerordnetAb = new Infragistics.Win.Misc.UltraLabel();
            this.btnSearch = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDel = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblFound = new Infragistics.Win.Misc.UltraLabel();
            this.btnSave = new QS2.Desktop.ControlManagment.BaseButton();
            this.gridVOLager = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsVO1 = new PMDS.Global.db.ERSystem.dsVO();
            this.sqlVO1 = new PMDS.Global.db.ERSystem.sqlVO(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelGrid = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).BeginInit();
            this.grpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeriennummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboZustand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteFrom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVOLager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsVO1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panelGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.btnAddVO);
            this.panelTop.Controls.Add(this.grpSearch);
            this.panelTop.Controls.Add(this.btnDel);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1184, 79);
            this.panelTop.TabIndex = 1;
            // 
            // btnAddVO
            // 
            this.btnAddVO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAddVO.Appearance = appearance1;
            this.btnAddVO.AutoWorkLayout = false;
            this.btnAddVO.IsStandardControl = false;
            this.btnAddVO.Location = new System.Drawing.Point(1120, 50);
            this.btnAddVO.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddVO.Name = "btnAddVO";
            this.btnAddVO.Size = new System.Drawing.Size(28, 27);
            this.btnAddVO.TabIndex = 11;
            this.btnAddVO.Tag = "16";
            this.btnAddVO.Click += new System.EventHandler(this.btnAddVO_Click);
            // 
            // grpSearch
            // 
            this.grpSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpSearch.Controls.Add(this.txtSeriennummer);
            this.grpSearch.Controls.Add(this.lblSeriennummer);
            this.grpSearch.Controls.Add(this.cboZustand);
            this.grpSearch.Controls.Add(this.lblZustand);
            this.grpSearch.Controls.Add(this.udteTo);
            this.grpSearch.Controls.Add(this.udteFrom);
            this.grpSearch.Controls.Add(this.lblVerordnetBis);
            this.grpSearch.Controls.Add(this.lblVerordnetAb);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Location = new System.Drawing.Point(8, 1);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(713, 74);
            this.grpSearch.TabIndex = 0;
            this.grpSearch.Text = "Suche";
            // 
            // txtSeriennummer
            // 
            appearance2.BackColor = System.Drawing.Color.White;
            this.txtSeriennummer.Appearance = appearance2;
            this.txtSeriennummer.BackColor = System.Drawing.Color.White;
            this.txtSeriennummer.Location = new System.Drawing.Point(97, 19);
            this.txtSeriennummer.Name = "txtSeriennummer";
            this.txtSeriennummer.Size = new System.Drawing.Size(213, 21);
            this.txtSeriennummer.TabIndex = 0;
            // 
            // lblSeriennummer
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.lblSeriennummer.Appearance = appearance3;
            this.lblSeriennummer.Location = new System.Drawing.Point(13, 21);
            this.lblSeriennummer.Name = "lblSeriennummer";
            this.lblSeriennummer.Size = new System.Drawing.Size(113, 16);
            this.lblSeriennummer.TabIndex = 117;
            this.lblSeriennummer.Text = "Seriennummer";
            // 
            // cboZustand
            // 
            appearance4.BackColor = System.Drawing.Color.White;
            this.cboZustand.Appearance = appearance4;
            this.cboZustand.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cboZustand.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cboZustand.BackColor = System.Drawing.Color.White;
            appearance5.Image = global::PMDS.GUI.Properties.Resources.ico_Plus;
            editorButton1.Appearance = appearance5;
            editorButton1.Key = "Add";
            this.cboZustand.ButtonsRight.Add(editorButton1);
            this.cboZustand.Location = new System.Drawing.Point(376, 19);
            this.cboZustand.Name = "cboZustand";
            this.cboZustand.Size = new System.Drawing.Size(225, 21);
            this.cboZustand.TabIndex = 3;
            this.cboZustand.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.cboZustand_EditorButtonClick);
            // 
            // lblZustand
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.lblZustand.Appearance = appearance6;
            this.lblZustand.Location = new System.Drawing.Point(325, 21);
            this.lblZustand.Name = "lblZustand";
            this.lblZustand.Size = new System.Drawing.Size(83, 17);
            this.lblZustand.TabIndex = 41;
            this.lblZustand.Text = "Zustand";
            // 
            // udteTo
            // 
            this.udteTo.Location = new System.Drawing.Point(218, 43);
            this.udteTo.Name = "udteTo";
            this.udteTo.Size = new System.Drawing.Size(92, 21);
            this.udteTo.TabIndex = 2;
            // 
            // udteFrom
            // 
            this.udteFrom.Location = new System.Drawing.Point(97, 43);
            this.udteFrom.Name = "udteFrom";
            this.udteFrom.Size = new System.Drawing.Size(92, 21);
            this.udteFrom.TabIndex = 1;
            // 
            // lblVerordnetBis
            // 
            appearance7.TextVAlignAsString = "Middle";
            this.lblVerordnetBis.Appearance = appearance7;
            this.lblVerordnetBis.Location = new System.Drawing.Point(195, 45);
            this.lblVerordnetBis.Name = "lblVerordnetBis";
            this.lblVerordnetBis.Size = new System.Drawing.Size(41, 16);
            this.lblVerordnetBis.TabIndex = 18;
            this.lblVerordnetBis.Text = "bis";
            // 
            // lblVerordnetAb
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.lblVerordnetAb.Appearance = appearance8;
            this.lblVerordnetAb.Location = new System.Drawing.Point(13, 45);
            this.lblVerordnetAb.Name = "lblVerordnetAb";
            this.lblVerordnetAb.Size = new System.Drawing.Size(83, 16);
            this.lblVerordnetAb.TabIndex = 17;
            this.lblVerordnetAb.Text = "Erstellt von";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance9.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance9.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSearch.Appearance = appearance9;
            this.btnSearch.AutoWorkLayout = false;
            this.btnSearch.IsStandardControl = false;
            this.btnSearch.Location = new System.Drawing.Point(632, 26);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(69, 34);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Tag = "";
            this.btnSearch.Text = "Suchen";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance10.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance10.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance10;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.IsStandardControl = false;
            this.btnDel.Location = new System.Drawing.Point(1148, 50);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(28, 27);
            this.btnDel.TabIndex = 12;
            this.btnDel.Tag = "17";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelBottom.Controls.Add(this.lblFound);
            this.panelBottom.Controls.Add(this.btnSave);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 541);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1184, 36);
            this.panelBottom.TabIndex = 2;
            // 
            // lblFound
            // 
            this.lblFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance11.TextVAlignAsString = "Middle";
            this.lblFound.Appearance = appearance11;
            this.lblFound.Location = new System.Drawing.Point(7, 2);
            this.lblFound.Name = "lblFound";
            this.lblFound.Size = new System.Drawing.Size(137, 16);
            this.lblFound.TabIndex = 23;
            this.lblFound.Text = "Gefunden: 12";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance12.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance12;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.IsStandardControl = false;
            this.btnSave.Location = new System.Drawing.Point(1081, 2);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 30);
            this.btnSave.TabIndex = 12;
            this.btnSave.Tag = "";
            this.btnSave.Text = "Speichern";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gridVOLager
            // 
            this.gridVOLager.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridVOLager.AutoWork = true;
            this.gridVOLager.DataMember = "VO_Lager";
            this.gridVOLager.DataSource = this.dsVO1;
            appearance13.BackColor = System.Drawing.Color.White;
            appearance13.FontData.SizeInPoints = 10F;
            this.gridVOLager.DisplayLayout.Appearance = appearance13;
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 6;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn6.Width = 417;
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 0;
            ultraGridColumn2.Hidden = true;
            appearance14.TextHAlignAsString = "Left";
            ultraGridColumn3.Header.Appearance = appearance14;
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 5;
            ultraGridColumn3.Width = 378;
            appearance15.TextHAlignAsString = "Left";
            ultraGridColumn4.Header.Appearance = appearance15;
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 8;
            ultraGridColumn4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn4.Width = 204;
            appearance16.TextHAlignAsString = "Center";
            ultraGridColumn16.CellAppearance = appearance16;
            appearance17.TextHAlignAsString = "Center";
            ultraGridColumn16.Header.Appearance = appearance17;
            ultraGridColumn16.Header.Caption = "Erstellt am";
            ultraGridColumn16.Header.Editor = null;
            ultraGridColumn16.Header.VisiblePosition = 1;
            ultraGridColumn16.Width = 117;
            ultraGridColumn17.Header.Editor = null;
            ultraGridColumn17.Header.VisiblePosition = 7;
            ultraGridColumn17.Hidden = true;
            appearance18.TextHAlignAsString = "Left";
            ultraGridColumn18.Header.Appearance = appearance18;
            ultraGridColumn18.Header.Caption = "Benutzer erstellt";
            ultraGridColumn18.Header.Editor = null;
            ultraGridColumn18.Header.VisiblePosition = 9;
            ultraGridColumn18.Width = 149;
            ultraGridColumn19.Header.Caption = "Datum geändert";
            ultraGridColumn19.Header.Editor = null;
            ultraGridColumn19.Header.VisiblePosition = 10;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn20.Header.Editor = null;
            ultraGridColumn20.Header.VisiblePosition = 11;
            ultraGridColumn20.Hidden = true;
            ultraGridColumn21.Header.Caption = "Login-Name frei geändert";
            ultraGridColumn21.Header.Editor = null;
            ultraGridColumn21.Header.VisiblePosition = 12;
            ultraGridColumn21.Hidden = true;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 2;
            ultraGridColumn1.Width = 154;
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 13;
            ultraGridColumn5.Width = 245;
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 4;
            ultraGridColumn7.Width = 179;
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 3;
            ultraGridColumn8.Width = 179;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn6,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn1,
            ultraGridColumn5,
            ultraGridColumn7,
            ultraGridColumn8});
            this.gridVOLager.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridVOLager.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridVOLager.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.gridVOLager.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            this.gridVOLager.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;
            this.gridVOLager.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.gridVOLager.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridVOLager.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridVOLager.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.gridVOLager.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            appearance19.BorderColor = System.Drawing.Color.White;
            this.gridVOLager.DisplayLayout.Override.SummaryFooterAppearance = appearance19;
            appearance20.BorderColor = System.Drawing.Color.White;
            this.gridVOLager.DisplayLayout.Override.SummaryFooterCaptionAppearance = appearance20;
            appearance21.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridVOLager.DisplayLayout.Override.SummaryValueAppearance = appearance21;
            this.gridVOLager.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            valueList1.Key = "Zustand";
            this.gridVOLager.DisplayLayout.ValueLists.AddRange(new Infragistics.Win.ValueList[] {
            valueList1});
            this.gridVOLager.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.gridVOLager.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridVOLager.Location = new System.Drawing.Point(4, 3);
            this.gridVOLager.Margin = new System.Windows.Forms.Padding(4);
            this.gridVOLager.Name = "gridVOLager";
            this.gridVOLager.Size = new System.Drawing.Size(1176, 455);
            this.gridVOLager.TabIndex = 3;
            this.gridVOLager.Text = "Dokumente";
            this.gridVOLager.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.gridVOLager_BeforeCellActivate);
            this.gridVOLager.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.gridVOLager_BeforeRowsDeleted);
            this.gridVOLager.Click += new System.EventHandler(this.gridVOLager_Click);
            this.gridVOLager.DoubleClick += new System.EventHandler(this.gridVOLager_DoubleClick);
            // 
            // dsVO1
            // 
            this.dsVO1.DataSetName = "dsVO";
            this.dsVO1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panelGrid
            // 
            this.panelGrid.BackColor = System.Drawing.Color.Transparent;
            this.panelGrid.Controls.Add(this.gridVOLager);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 79);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(1184, 462);
            this.panelGrid.TabIndex = 4;
            // 
            // ucLager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "ucLager";
            this.Size = new System.Drawing.Size(1184, 577);
            this.Load += new System.EventHandler(this.ucLager_Load);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeriennummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboZustand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteFrom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridVOLager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsVO1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panelGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        public QS2.Desktop.ControlManagment.BaseButton btnAddVO;
        private Infragistics.Win.Misc.UltraGroupBox grpSearch;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udteTo;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udteFrom;
        private Infragistics.Win.Misc.UltraLabel lblVerordnetAb;
        public QS2.Desktop.ControlManagment.BaseButton btnSearch;
        public QS2.Desktop.ControlManagment.BaseButton btnDel;
        private System.Windows.Forms.Panel panelBottom;
        public QS2.Desktop.ControlManagment.BaseButton btnSave;
        public QS2.Desktop.ControlManagment.BaseGrid gridVOLager;
        private Infragistics.Win.Misc.UltraLabel lblVerordnetBis;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Infragistics.Win.Misc.UltraLabel lblFound;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboZustand;
        private Infragistics.Win.Misc.UltraLabel lblZustand;
        public Global.db.ERSystem.dsVO dsVO1;
        public Global.db.ERSystem.sqlVO sqlVO1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtSeriennummer;
        private Infragistics.Win.Misc.UltraLabel lblSeriennummer;
        private System.Windows.Forms.Panel panelGrid;
    }
}
