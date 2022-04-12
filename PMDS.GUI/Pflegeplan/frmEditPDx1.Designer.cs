namespace PMDS.GUI
{
    partial class frmEditPDx1
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("MedizinischeDaten", -1);
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditPDx1));
            this.tbDefinition = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.tbText = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblLokalisierung = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.osLokalisierung = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.cbGruppe = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.lblGruppe = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.lblPDxCode = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.lblDefinition = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.lblKlartext = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gridPflegemodelle = new QS2.Desktop.ControlManagment.BaseGrid();
            this.btnDelAntiko = new PMDS.GUI.ucButton(this.components);
            this.btnAddAntiko = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.cbWundeJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblPDxKürzel = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.chkEntferntJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cmbCode = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.cmbPDXKuerzel = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.lblPM_Zuordnung = new QS2.Desktop.ControlManagment.BaseLableWin();
            ((System.ComponentModel.ISupportInitialize)(this.tbDefinition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osLokalisierung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGruppe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPflegemodelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbWundeJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEntferntJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPDXKuerzel)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDefinition
            // 
            this.tbDefinition.Location = new System.Drawing.Point(127, 116);
            this.tbDefinition.Margin = new System.Windows.Forms.Padding(4);
            this.tbDefinition.MaxLength = 2048;
            this.tbDefinition.Multiline = true;
            this.tbDefinition.Name = "tbDefinition";
            this.tbDefinition.Size = new System.Drawing.Size(688, 109);
            this.tbDefinition.TabIndex = 3;
            this.tbDefinition.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // tbText
            // 
            this.tbText.Location = new System.Drawing.Point(127, 85);
            this.tbText.Margin = new System.Windows.Forms.Padding(4);
            this.tbText.MaxLength = 255;
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(688, 22);
            this.tbText.TabIndex = 2;
            this.tbText.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // lblLokalisierung
            // 
            this.lblLokalisierung.Location = new System.Drawing.Point(20, 271);
            this.lblLokalisierung.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLokalisierung.Name = "lblLokalisierung";
            this.lblLokalisierung.Size = new System.Drawing.Size(96, 20);
            this.lblLokalisierung.TabIndex = 72;
            this.lblLokalisierung.Text = "Lokalisierung";
            this.lblLokalisierung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // osLokalisierung
            // 
            this.osLokalisierung.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.osLokalisierung.CheckedIndex = 0;
            valueListItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            valueListItem1.DataValue = "Default Item";
            valueListItem1.DisplayText = "Kann lokalisiert werden";
            valueListItem2.DataValue = "ValueListItem1";
            valueListItem2.DisplayText = "Muss lokalisiert werden";
            valueListItem3.DataValue = "ValueListItem2";
            valueListItem3.DisplayText = "Keine Lokalisierung möglich";
            this.osLokalisierung.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.osLokalisierung.ItemSpacingHorizontal = 40;
            this.osLokalisierung.Location = new System.Drawing.Point(127, 266);
            this.osLokalisierung.Margin = new System.Windows.Forms.Padding(0);
            this.osLokalisierung.MaxColumnWidth = 1;
            this.osLokalisierung.MinColumnWidth = 150;
            this.osLokalisierung.Name = "osLokalisierung";
            this.osLokalisierung.Size = new System.Drawing.Size(690, 25);
            this.osLokalisierung.TabIndex = 6;
            this.osLokalisierung.Text = "Kann lokalisiert werden";
            this.osLokalisierung.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // cbGruppe
            // 
            this.cbGruppe.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbGruppe.Location = new System.Drawing.Point(127, 234);
            this.cbGruppe.Margin = new System.Windows.Forms.Padding(4);
            this.cbGruppe.Name = "cbGruppe";
            this.cbGruppe.Size = new System.Drawing.Size(264, 24);
            this.cbGruppe.TabIndex = 4;
            this.cbGruppe.ValueChanged += new System.EventHandler(this.cbGruppe_ValueChanged);
            // 
            // lblGruppe
            // 
            this.lblGruppe.Location = new System.Drawing.Point(20, 238);
            this.lblGruppe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGruppe.Name = "lblGruppe";
            this.lblGruppe.Size = new System.Drawing.Size(99, 20);
            this.lblGruppe.TabIndex = 71;
            this.lblGruppe.Text = "PD-Art";
            this.lblGruppe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPDxCode
            // 
            this.lblPDxCode.Location = new System.Drawing.Point(417, 236);
            this.lblPDxCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPDxCode.Name = "lblPDxCode";
            this.lblPDxCode.Size = new System.Drawing.Size(99, 20);
            this.lblPDxCode.TabIndex = 69;
            this.lblPDxCode.Text = "PD-Code";
            this.lblPDxCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDefinition
            // 
            this.lblDefinition.Location = new System.Drawing.Point(16, 114);
            this.lblDefinition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDefinition.Name = "lblDefinition";
            this.lblDefinition.Size = new System.Drawing.Size(128, 20);
            this.lblDefinition.TabIndex = 67;
            this.lblDefinition.Text = "Definition";
            this.lblDefinition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKlartext
            // 
            this.lblKlartext.Location = new System.Drawing.Point(16, 81);
            this.lblKlartext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKlartext.Name = "lblKlartext";
            this.lblKlartext.Size = new System.Drawing.Size(128, 30);
            this.lblKlartext.TabIndex = 65;
            this.lblKlartext.Text = "Klartext";
            this.lblKlartext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // gridPflegemodelle
            // 
            this.gridPflegemodelle.AutoWork = true;
            appearance4.BackColor = System.Drawing.Color.White;
            appearance4.BorderColor = System.Drawing.Color.Black;
            this.gridPflegemodelle.DisplayLayout.Appearance = appearance4;
            this.gridPflegemodelle.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.gridPflegemodelle.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridPflegemodelle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridPflegemodelle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.BorderColor = System.Drawing.SystemColors.Window;
            this.gridPflegemodelle.DisplayLayout.GroupByBox.Appearance = appearance5;
            appearance6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridPflegemodelle.DisplayLayout.GroupByBox.BandLabelAppearance = appearance6;
            this.gridPflegemodelle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridPflegemodelle.DisplayLayout.GroupByBox.Hidden = true;
            appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance7.BackColor2 = System.Drawing.SystemColors.Control;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridPflegemodelle.DisplayLayout.GroupByBox.PromptAppearance = appearance7;
            this.gridPflegemodelle.DisplayLayout.MaxColScrollRegions = 1;
            this.gridPflegemodelle.DisplayLayout.MaxRowScrollRegions = 1;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            appearance8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridPflegemodelle.DisplayLayout.Override.ActiveCellAppearance = appearance8;
            appearance9.BackColor = System.Drawing.SystemColors.Highlight;
            appearance9.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridPflegemodelle.DisplayLayout.Override.ActiveRowAppearance = appearance9;
            this.gridPflegemodelle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridPflegemodelle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            this.gridPflegemodelle.DisplayLayout.Override.CardAreaAppearance = appearance10;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            appearance11.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridPflegemodelle.DisplayLayout.Override.CellAppearance = appearance11;
            this.gridPflegemodelle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.gridPflegemodelle.DisplayLayout.Override.CellPadding = 0;
            appearance12.BackColor = System.Drawing.SystemColors.Control;
            appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance12.BorderColor = System.Drawing.SystemColors.Window;
            this.gridPflegemodelle.DisplayLayout.Override.GroupByRowAppearance = appearance12;
            appearance13.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance13.TextHAlignAsString = "Left";
            this.gridPflegemodelle.DisplayLayout.Override.HeaderAppearance = appearance13;
            this.gridPflegemodelle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridPflegemodelle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance14.BackColor = System.Drawing.SystemColors.Window;
            appearance14.BorderColor = System.Drawing.Color.Silver;
            this.gridPflegemodelle.DisplayLayout.Override.RowAppearance = appearance14;
            this.gridPflegemodelle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.gridPflegemodelle.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            appearance15.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridPflegemodelle.DisplayLayout.Override.TemplateAddRowAppearance = appearance15;
            this.gridPflegemodelle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridPflegemodelle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridPflegemodelle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.gridPflegemodelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridPflegemodelle.Location = new System.Drawing.Point(19, 351);
            this.gridPflegemodelle.Margin = new System.Windows.Forms.Padding(4);
            this.gridPflegemodelle.Name = "gridPflegemodelle";
            this.gridPflegemodelle.Size = new System.Drawing.Size(796, 118);
            this.gridPflegemodelle.TabIndex = 9;
            this.gridPflegemodelle.Text = "ultraGrid14";
            this.gridPflegemodelle.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.gridPflegemodelle_InitializeLayout);
            this.gridPflegemodelle.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.gridPflegemodelle_InitializeRow);
            this.gridPflegemodelle.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.gridPflegemodelle_CellChange);
            // 
            // btnDelAntiko
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDelAntiko.Appearance = appearance2;
            this.btnDelAntiko.AutoWorkLayout = false;
            this.btnDelAntiko.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelAntiko.DoOnClick = true;
            this.btnDelAntiko.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDelAntiko.IsStandardControl = true;
            this.btnDelAntiko.Location = new System.Drawing.Point(780, 313);
            this.btnDelAntiko.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelAntiko.Name = "btnDelAntiko";
            this.btnDelAntiko.Size = new System.Drawing.Size(35, 30);
            this.btnDelAntiko.TabIndex = 8;
            this.btnDelAntiko.TabStop = false;
            this.btnDelAntiko.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDelAntiko.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDelAntiko.Click += new System.EventHandler(this.btnDelAntiko_Click);
            // 
            // btnAddAntiko
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAddAntiko.Appearance = appearance3;
            this.btnAddAntiko.AutoWorkLayout = false;
            this.btnAddAntiko.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAddAntiko.DoOnClick = true;
            this.btnAddAntiko.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAddAntiko.IsStandardControl = true;
            this.btnAddAntiko.Location = new System.Drawing.Point(742, 313);
            this.btnAddAntiko.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddAntiko.Name = "btnAddAntiko";
            this.btnAddAntiko.Size = new System.Drawing.Size(35, 30);
            this.btnAddAntiko.TabIndex = 7;
            this.btnAddAntiko.TabStop = false;
            this.btnAddAntiko.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAddAntiko.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAddAntiko.Click += new System.EventHandler(this.btnAddAntiko_Click);
            // 
            // btnOK
            // 
            appearance16.Image = ((object)(resources.GetObject("appearance16.Image")));
            appearance16.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance16.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance16;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(698, 477);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(117, 30);
            this.btnOK.TabIndex = 11;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "Speichern";
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance1;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(573, 477);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 30);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbWundeJN
            // 
            this.cbWundeJN.Location = new System.Drawing.Point(19, 41);
            this.cbWundeJN.Margin = new System.Windows.Forms.Padding(4);
            this.cbWundeJN.Name = "cbWundeJN";
            this.cbWundeJN.Size = new System.Drawing.Size(264, 25);
            this.cbWundeJN.TabIndex = 1;
            this.cbWundeJN.Text = "Ist PD für Wunde";
            this.cbWundeJN.CheckedChanged += new System.EventHandler(this.cbWundeJN_CheckedChanged);
            // 
            // lblPDxKürzel
            // 
            this.lblPDxKürzel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPDxKürzel.Location = new System.Drawing.Point(316, 316);
            this.lblPDxKürzel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPDxKürzel.Name = "lblPDxKürzel";
            this.lblPDxKürzel.Size = new System.Drawing.Size(75, 20);
            this.lblPDxKürzel.TabIndex = 79;
            this.lblPDxKürzel.Text = "PDx Kürzel";
            this.lblPDxKürzel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPDxKürzel.Visible = false;
            // 
            // chkEntferntJN
            // 
            this.chkEntferntJN.Location = new System.Drawing.Point(19, 11);
            this.chkEntferntJN.Margin = new System.Windows.Forms.Padding(5);
            this.chkEntferntJN.Name = "chkEntferntJN";
            this.chkEntferntJN.Size = new System.Drawing.Size(395, 21);
            this.chkEntferntJN.TabIndex = 0;
            this.chkEntferntJN.Text = "PD darf nicht mehr verwendet werden.";
            this.chkEntferntJN.CheckedChanged += new System.EventHandler(this.chkEntferntJN_CheckedChanged);
            // 
            // cmbCode
            // 
            this.cmbCode.AddEmptyEntry = false;
            this.cmbCode.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbCode.AutoOpenCBO = true;
            this.cmbCode.BerufsstandGruppeJNA = -1;
            this.cmbCode.ExactMatch = false;
            this.cmbCode.Group = "PDC";
            this.cmbCode.ID_PEP = -1;
            this.cmbCode.IgnoreUnterdruecken = true;
            this.cmbCode.Location = new System.Drawing.Point(524, 234);
            this.cmbCode.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCode.MaxLength = 15;
            this.cmbCode.Name = "cmbCode";
            this.cmbCode.NullText = "<Code eintragen oder auswählen>";
            this.cmbCode.PflichtJN = false;
            this.cmbCode.SelectDistinct = false;
            this.cmbCode.ShowAddButton = true;
            this.cmbCode.Size = new System.Drawing.Size(291, 24);
            this.cmbCode.sys = false;
            this.cmbCode.TabIndex = 5;
            this.cmbCode.ValueChanged += new System.EventHandler(this.cmbCode_ValueChanged);
            // 
            // cmbPDXKuerzel
            // 
            this.cmbPDXKuerzel.AddEmptyEntry = false;
            this.cmbPDXKuerzel.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbPDXKuerzel.AutoOpenCBO = true;
            this.cmbPDXKuerzel.BerufsstandGruppeJNA = -1;
            this.cmbPDXKuerzel.ExactMatch = false;
            this.cmbPDXKuerzel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPDXKuerzel.Group = "PDK";
            this.cmbPDXKuerzel.ID_PEP = -1;
            this.cmbPDXKuerzel.IgnoreUnterdruecken = true;
            this.cmbPDXKuerzel.Location = new System.Drawing.Point(399, 313);
            this.cmbPDXKuerzel.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPDXKuerzel.MaxLength = 15;
            this.cmbPDXKuerzel.Name = "cmbPDXKuerzel";
            this.cmbPDXKuerzel.NullText = "<Kürzel eintragen oder auswählen>";
            this.cmbPDXKuerzel.PflichtJN = false;
            this.cmbPDXKuerzel.SelectDistinct = false;
            this.cmbPDXKuerzel.ShowAddButton = true;
            this.cmbPDXKuerzel.Size = new System.Drawing.Size(291, 24);
            this.cmbPDXKuerzel.sys = false;
            this.cmbPDXKuerzel.TabIndex = 82;
            this.cmbPDXKuerzel.Visible = false;
            // 
            // lblPM_Zuordnung
            // 
            this.lblPM_Zuordnung.Location = new System.Drawing.Point(16, 323);
            this.lblPM_Zuordnung.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPM_Zuordnung.Name = "lblPM_Zuordnung";
            this.lblPM_Zuordnung.Size = new System.Drawing.Size(252, 20);
            this.lblPM_Zuordnung.TabIndex = 83;
            this.lblPM_Zuordnung.Text = "Zuordnung zu Pflegemodell(en)";
            this.lblPM_Zuordnung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmEditPDx1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(830, 519);
            this.Controls.Add(this.lblPM_Zuordnung);
            this.Controls.Add(this.cmbPDXKuerzel);
            this.Controls.Add(this.cmbCode);
            this.Controls.Add(this.chkEntferntJN);
            this.Controls.Add(this.lblPDxKürzel);
            this.Controls.Add(this.cbWundeJN);
            this.Controls.Add(this.btnDelAntiko);
            this.Controls.Add(this.btnAddAntiko);
            this.Controls.Add(this.gridPflegemodelle);
            this.Controls.Add(this.tbDefinition);
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.lblLokalisierung);
            this.Controls.Add(this.osLokalisierung);
            this.Controls.Add(this.cbGruppe);
            this.Controls.Add(this.lblGruppe);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblPDxCode);
            this.Controls.Add(this.lblDefinition);
            this.Controls.Add(this.lblKlartext);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditPDx1";
            this.ShowInTaskbar = false;
            this.Text = "PD bearbeiten";
            ((System.ComponentModel.ISupportInitialize)(this.tbDefinition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osLokalisierung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGruppe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPflegemodelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbWundeJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEntferntJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPDXKuerzel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private QS2.Desktop.ControlManagment.BaseTextEditor tbDefinition;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbText;
        private QS2.Desktop.ControlManagment.BaseLableWin lblLokalisierung;
        private QS2.Desktop.ControlManagment.BaseOptionSet osLokalisierung;
        private QS2.Desktop.ControlManagment.BaseComboEditor cbGruppe;
        private QS2.Desktop.ControlManagment.BaseLableWin lblGruppe;
        private ucButton btnOK;
        private ucButton btnCancel;
        private QS2.Desktop.ControlManagment.BaseLableWin lblPDxCode;
        private QS2.Desktop.ControlManagment.BaseLableWin lblDefinition;
        private QS2.Desktop.ControlManagment.BaseLableWin lblKlartext;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ucButton btnDelAntiko;
        private ucButton btnAddAntiko;
        private QS2.Desktop.ControlManagment.BaseGrid gridPflegemodelle;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbWundeJN;
        private QS2.Desktop.ControlManagment.BaseLableWin lblPDxKürzel;
        protected QS2.Desktop.ControlManagment.BaseCheckBox chkEntferntJN;
        private BaseControls.AuswahlGruppeCombo cmbPDXKuerzel;
        private BaseControls.AuswahlGruppeCombo cmbCode;
        private QS2.Desktop.ControlManagment.BaseLableWin lblPM_Zuordnung;
    }
}