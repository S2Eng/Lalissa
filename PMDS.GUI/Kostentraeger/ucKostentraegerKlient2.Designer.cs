namespace PMDS.GUI.Kostentraeger
{
    partial class ucKostentraegerKlient2
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
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Klient als Zahler hinzufügen", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("FSW für Zahlungsaufforderung hinzufügen", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PatientKostentraeger", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPatient");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKostentraeger");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GueltigAb");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GueltigBis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("enumKostentraegerart");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BetragErrechnetJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Betrag");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ErfasstAm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBenutzer");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AbgerechnetBis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VorauszahlungJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RechnungJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RechnungTyp");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(961928108);
            this.panelButtonsKost = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelButtons = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnAddKlient = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAdd = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnUpdate = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDel = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAddFSW = new QS2.Desktop.ControlManagment.BaseButton();
            this.dgMain = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsPatientKostentraeger1 = new PMDS.Global.db.Global.ds_abrechnung.dsPatientKostentraeger();
            this.panelButtonsKost.SuspendLayout();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientKostentraeger1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelButtonsKost
            // 
            this.panelButtonsKost.BackColor = System.Drawing.Color.Transparent;
            this.panelButtonsKost.Controls.Add(this.panelButtons);
            this.panelButtonsKost.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtonsKost.Location = new System.Drawing.Point(0, 0);
            this.panelButtonsKost.Name = "panelButtonsKost";
            this.panelButtonsKost.Size = new System.Drawing.Size(754, 27);
            this.panelButtonsKost.TabIndex = 36;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnAddFSW);
            this.panelButtons.Controls.Add(this.btnAddKlient);
            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Controls.Add(this.btnUpdate);
            this.panelButtons.Controls.Add(this.btnDel);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtons.Location = new System.Drawing.Point(473, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(281, 27);
            this.panelButtons.TabIndex = 35;
            // 
            // btnAddKlient
            // 
            this.btnAddKlient.AutoWorkLayout = false;
            this.btnAddKlient.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAddKlient.IsStandardControl = false;
            this.btnAddKlient.Location = new System.Drawing.Point(111, 3);
            this.btnAddKlient.Name = "btnAddKlient";
            this.btnAddKlient.Size = new System.Drawing.Size(93, 21);
            this.btnAddKlient.TabIndex = 36;
            this.btnAddKlient.Text = "Klient=Zahler";
            ultraToolTipInfo2.ToolTipText = "Klient als Zahler hinzufügen";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnAddKlient, ultraToolTipInfo2);
            this.btnAddKlient.Click += new System.EventHandler(this.btnAddKlient_Click);
            // 
            // btnAdd
            // 
            appearance14.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance14.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance14;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = false;
            this.btnAdd.Location = new System.Drawing.Point(208, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(22, 21);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            appearance15.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance15.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUpdate.Appearance = appearance15;
            this.btnUpdate.AutoWorkLayout = false;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUpdate.IsStandardControl = false;
            this.btnUpdate.Location = new System.Drawing.Point(252, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(22, 21);
            this.btnUpdate.TabIndex = 34;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDel
            // 
            appearance16.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance16.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance16;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDel.IsStandardControl = false;
            this.btnDel.Location = new System.Drawing.Point(230, 3);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(22, 21);
            this.btnDel.TabIndex = 1;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 0;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnAddFSW
            // 
            this.btnAddFSW.AutoWorkLayout = false;
            this.btnAddFSW.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAddFSW.IsStandardControl = false;
            this.btnAddFSW.Location = new System.Drawing.Point(11, 3);
            this.btnAddFSW.Name = "btnAddFSW";
            this.btnAddFSW.Size = new System.Drawing.Size(93, 21);
            this.btnAddFSW.TabIndex = 37;
            this.btnAddFSW.Text = "FSW=Zahler";
            ultraToolTipInfo1.ToolTipText = "FSW für Zahlungsaufforderung hinzufügen";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnAddFSW, ultraToolTipInfo1);
            this.btnAddFSW.Click += new System.EventHandler(this.btnAddFSW_Click);
            // 
            // dgMain
            // 
            this.dgMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMain.AutoWork = true;
            this.dgMain.DataSource = this.dsPatientKostentraeger1.PatientKostentraeger;
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance1.BorderColor = System.Drawing.Color.Black;
            appearance1.FontData.SizeInPoints = 10F;
            this.dgMain.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.Caption = "Klient";
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn2.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn2.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn3.Header.Caption = "Kostenträger";
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(220, 0);
            ultraGridColumn3.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.Header.Caption = "Gültig ab";
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn4.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(78, 0);
            ultraGridColumn4.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn4.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn5.Header.Caption = "Gültig bis";
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(76, 0);
            ultraGridColumn5.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn6.Header.Caption = "Kostenträgerart";
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn6.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(124, 0);
            ultraGridColumn6.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn7.Header.Caption = "Restzahler";
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn7.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn7.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(83, 0);
            ultraGridColumn7.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn7.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            ultraGridColumn8.CellAppearance = appearance2;
            ultraGridColumn8.Format = "###,###,##0.00";
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.MaskInput = "{double:-9.2}";
            ultraGridColumn8.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn8.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn8.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(107, 0);
            ultraGridColumn8.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn8.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn8.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Currency;
            ultraGridColumn9.Header.Caption = "Erfasst am";
            ultraGridColumn9.Header.Editor = null;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn9.RowLayoutColumnInfo.OriginX = 20;
            ultraGridColumn9.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn9.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(113, 0);
            ultraGridColumn9.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn9.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn9.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
            ultraGridColumn10.Header.Caption = "Benutzer";
            ultraGridColumn10.Header.Editor = null;
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn10.RowLayoutColumnInfo.OriginX = 18;
            ultraGridColumn10.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn10.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(167, 0);
            ultraGridColumn10.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn10.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn11.Header.Caption = "Abgerechnet bis";
            ultraGridColumn11.Header.Editor = null;
            ultraGridColumn11.Header.VisiblePosition = 10;
            ultraGridColumn11.RowLayoutColumnInfo.OriginX = 22;
            ultraGridColumn11.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn11.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn11.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn12.Header.Caption = "Vorauszahlung";
            ultraGridColumn12.Header.Editor = null;
            ultraGridColumn12.Header.VisiblePosition = 11;
            ultraGridColumn12.RowLayoutColumnInfo.OriginX = 12;
            ultraGridColumn12.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn12.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn12.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn27.Header.Caption = "Rechnung J/N";
            ultraGridColumn27.Header.Editor = null;
            ultraGridColumn27.Header.VisiblePosition = 12;
            ultraGridColumn27.RowLayoutColumnInfo.OriginX = 14;
            ultraGridColumn27.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn27.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn27.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn28.Header.Caption = "Rechnungstyp";
            ultraGridColumn28.Header.Editor = null;
            ultraGridColumn28.Header.VisiblePosition = 13;
            ultraGridColumn28.RowLayoutColumnInfo.OriginX = 16;
            ultraGridColumn28.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn28.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(109, 0);
            ultraGridColumn28.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn28.RowLayoutColumnInfo.SpanY = 2;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn27,
            ultraGridColumn28});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgMain.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgMain.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMain.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgMain.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.dgMain.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMain.DisplayLayout.GroupByBox.Prompt = "Einen Spaltenkopf hier hereinziehen, um zu gruppieren.";
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgMain.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            this.dgMain.DisplayLayout.MaxColScrollRegions = 1;
            this.dgMain.DisplayLayout.MaxRowScrollRegions = 1;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMain.DisplayLayout.Override.ActiveCellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.SystemColors.Highlight;
            appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgMain.DisplayLayout.Override.ActiveRowAppearance = appearance7;
            this.dgMain.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMain.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.White;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgMain.DisplayLayout.Override.CellAppearance = appearance9;
            this.dgMain.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.dgMain.DisplayLayout.Override.CellPadding = 0;
            this.dgMain.DisplayLayout.Override.DefaultRowHeight = 20;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance11.TextHAlignAsString = "Left";
            this.dgMain.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.dgMain.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgMain.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            this.dgMain.DisplayLayout.Override.RowAppearance = appearance12;
            this.dgMain.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.dgMain.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgMain.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
            this.dgMain.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgMain.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgMain.DisplayLayout.ValueLists.AddRange(new Infragistics.Win.ValueList[] {
            valueList1});
            this.dgMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMain.Location = new System.Drawing.Point(3, 30);
            this.dgMain.Name = "dgMain";
            this.dgMain.Size = new System.Drawing.Size(747, 161);
            this.dgMain.TabIndex = 37;
            this.dgMain.Text = "ultraGrid1";
            this.dgMain.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.dgMain_BeforeRowsDeleted_1);
            this.dgMain.DoubleClick += new System.EventHandler(this.dgMain_DoubleClick_1);
            // 
            // dsPatientKostentraeger1
            // 
            this.dsPatientKostentraeger1.DataSetName = "dsPatientKostentraeger";
            this.dsPatientKostentraeger1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsPatientKostentraeger1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ucKostentraegerKlient2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelButtonsKost);
            this.Controls.Add(this.dgMain);
            this.Name = "ucKostentraegerKlient2";
            this.Size = new System.Drawing.Size(754, 194);
            this.panelButtonsKost.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientKostentraeger1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel panelButtonsKost;
        private QS2.Desktop.ControlManagment.BasePanel panelButtons;
        private QS2.Desktop.ControlManagment.BaseButton btnAdd;
        private QS2.Desktop.ControlManagment.BaseButton btnUpdate;
        private QS2.Desktop.ControlManagment.BaseButton btnDel;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private PMDS.Global.db.Global.ds_abrechnung.dsPatientKostentraeger dsPatientKostentraeger1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private QS2.Desktop.ControlManagment.BaseButton btnAddKlient;
        private QS2.Desktop.ControlManagment.BaseGrid dgMain;
        private QS2.Desktop.ControlManagment.BaseButton btnAddFSW;
    }
}
