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
            this.tbCode = new QS2.Desktop.ControlManagment.BaseTextEditor();
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
            this.tbPDXKuerzel = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.chkEntferntJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDefinition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osLokalisierung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGruppe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPflegemodelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbWundeJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPDXKuerzel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEntferntJN)).BeginInit();
            this.SuspendLayout();
            // 
            // tbCode
            // 
            this.tbCode.Location = new System.Drawing.Point(114, 159);
            this.tbCode.MaxLength = 255;
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(146, 19);
            this.tbCode.TabIndex = 3;
            this.tbCode.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // tbDefinition
            // 
            this.tbDefinition.Location = new System.Drawing.Point(114, 34);
            this.tbDefinition.MaxLength = 2048;
            this.tbDefinition.Multiline = true;
            this.tbDefinition.Name = "tbDefinition";
            this.tbDefinition.Size = new System.Drawing.Size(432, 122);
            this.tbDefinition.TabIndex = 2;
            this.tbDefinition.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // tbText
            // 
            this.tbText.Location = new System.Drawing.Point(114, 12);
            this.tbText.MaxLength = 255;
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(432, 19);
            this.tbText.TabIndex = 1;
            this.tbText.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // lblLokalisierung
            // 
            this.lblLokalisierung.Location = new System.Drawing.Point(12, 225);
            this.lblLokalisierung.Name = "lblLokalisierung";
            this.lblLokalisierung.Size = new System.Drawing.Size(96, 16);
            this.lblLokalisierung.TabIndex = 72;
            this.lblLokalisierung.Text = "Lokalisierung";
            this.lblLokalisierung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // osLokalisierung
            // 
            this.osLokalisierung.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.osLokalisierung.CheckedIndex = 0;
            valueListItem1.DataValue = "Default Item";
            valueListItem1.DisplayText = "kann lokalisiert werden";
            valueListItem2.DataValue = "ValueListItem1";
            valueListItem2.DisplayText = "muß lokalisiert werden";
            valueListItem3.DataValue = "ValueListItem2";
            valueListItem3.DisplayText = "keine Lokalisierung möglich";
            this.osLokalisierung.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.osLokalisierung.ItemSpacingVertical = 3;
            this.osLokalisierung.Location = new System.Drawing.Point(114, 226);
            this.osLokalisierung.Name = "osLokalisierung";
            this.osLokalisierung.Size = new System.Drawing.Size(245, 54);
            this.osLokalisierung.TabIndex = 6;
            this.osLokalisierung.Text = "kann lokalisiert werden";
            this.osLokalisierung.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // cbGruppe
            // 
            this.cbGruppe.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbGruppe.Location = new System.Drawing.Point(114, 181);
            this.cbGruppe.Name = "cbGruppe";
            this.cbGruppe.Size = new System.Drawing.Size(144, 21);
            this.cbGruppe.TabIndex = 4;
            // 
            // lblGruppe
            // 
            this.lblGruppe.Location = new System.Drawing.Point(12, 182);
            this.lblGruppe.Name = "lblGruppe";
            this.lblGruppe.Size = new System.Drawing.Size(96, 16);
            this.lblGruppe.TabIndex = 71;
            this.lblGruppe.Text = "Gruppe";
            this.lblGruppe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPDxCode
            // 
            this.lblPDxCode.Location = new System.Drawing.Point(12, 159);
            this.lblPDxCode.Name = "lblPDxCode";
            this.lblPDxCode.Size = new System.Drawing.Size(96, 16);
            this.lblPDxCode.TabIndex = 69;
            this.lblPDxCode.Text = "PDx Code";
            this.lblPDxCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDefinition
            // 
            this.lblDefinition.Location = new System.Drawing.Point(12, 33);
            this.lblDefinition.Name = "lblDefinition";
            this.lblDefinition.Size = new System.Drawing.Size(96, 16);
            this.lblDefinition.TabIndex = 67;
            this.lblDefinition.Text = "Definition";
            this.lblDefinition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKlartext
            // 
            this.lblKlartext.Location = new System.Drawing.Point(12, 9);
            this.lblKlartext.Name = "lblKlartext";
            this.lblKlartext.Size = new System.Drawing.Size(96, 24);
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
            this.gridPflegemodelle.Location = new System.Drawing.Point(15, 286);
            this.gridPflegemodelle.Name = "gridPflegemodelle";
            this.gridPflegemodelle.Size = new System.Drawing.Size(531, 165);
            this.gridPflegemodelle.TabIndex = 7;
            this.gridPflegemodelle.Text = "ultraGrid14";
            this.gridPflegemodelle.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.gridPflegemodelle_InitializeLayout);
            this.gridPflegemodelle.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.gridPflegemodelle_InitializeRow);
            this.gridPflegemodelle.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.gridPflegemodelle_CellChange);
            // 
            // btnDelAntiko
            // 
            this.btnDelAntiko.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnDelAntiko.Location = new System.Drawing.Point(516, 287);
            this.btnDelAntiko.Name = "btnDelAntiko";
            this.btnDelAntiko.Size = new System.Drawing.Size(26, 19);
            this.btnDelAntiko.TabIndex = 75;
            this.btnDelAntiko.TabStop = false;
            this.btnDelAntiko.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDelAntiko.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDelAntiko.Click += new System.EventHandler(this.btnDelAntiko_Click);
            // 
            // btnAddAntiko
            // 
            this.btnAddAntiko.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnAddAntiko.Location = new System.Drawing.Point(487, 287);
            this.btnAddAntiko.Name = "btnAddAntiko";
            this.btnAddAntiko.Size = new System.Drawing.Size(26, 19);
            this.btnAddAntiko.TabIndex = 74;
            this.btnAddAntiko.TabStop = false;
            this.btnAddAntiko.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAddAntiko.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAddAntiko.Click += new System.EventHandler(this.btnAddAntiko_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance16.Image = ((object)(resources.GetObject("appearance16.Image")));
            appearance16.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance16.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance16;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(454, 455);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 24);
            this.btnOK.TabIndex = 8;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "Speichern";
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance1;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(454, 482);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 24);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbWundeJN
            // 
            this.cbWundeJN.Location = new System.Drawing.Point(114, 205);
            this.cbWundeJN.Name = "cbWundeJN";
            this.cbWundeJN.Size = new System.Drawing.Size(120, 20);
            this.cbWundeJN.TabIndex = 5;
            this.cbWundeJN.Text = "Wunde";
            this.cbWundeJN.CheckedChanged += new System.EventHandler(this.cbWundeJN_CheckedChanged);
            // 
            // lblPDxKürzel
            // 
            this.lblPDxKürzel.Location = new System.Drawing.Point(314, 162);
            this.lblPDxKürzel.Name = "lblPDxKürzel";
            this.lblPDxKürzel.Size = new System.Drawing.Size(80, 16);
            this.lblPDxKürzel.TabIndex = 79;
            this.lblPDxKürzel.Text = "PDx Kürzel";
            this.lblPDxKürzel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbPDXKuerzel
            // 
            this.tbPDXKuerzel.Location = new System.Drawing.Point(400, 159);
            this.tbPDXKuerzel.MaxLength = 10;
            this.tbPDXKuerzel.Name = "tbPDXKuerzel";
            this.tbPDXKuerzel.Size = new System.Drawing.Size(146, 19);
            this.tbPDXKuerzel.TabIndex = 78;
            this.tbPDXKuerzel.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // chkEntferntJN
            // 
            this.chkEntferntJN.Location = new System.Drawing.Point(317, 179);
            this.chkEntferntJN.Margin = new System.Windows.Forms.Padding(4);
            this.chkEntferntJN.Name = "chkEntferntJN";
            this.chkEntferntJN.Size = new System.Drawing.Size(229, 25);
            this.chkEntferntJN.TabIndex = 80;
            this.chkEntferntJN.Text = "Entfernt (Nicht aktiv)";
            // 
            // frmEditPDx1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(566, 509);
            this.Controls.Add(this.chkEntferntJN);
            this.Controls.Add(this.lblPDxKürzel);
            this.Controls.Add(this.tbPDXKuerzel);
            this.Controls.Add(this.cbWundeJN);
            this.Controls.Add(this.btnDelAntiko);
            this.Controls.Add(this.btnAddAntiko);
            this.Controls.Add(this.gridPflegemodelle);
            this.Controls.Add(this.tbCode);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditPDx1";
            this.ShowInTaskbar = false;
            this.Text = "PDx bearbeiten";
            ((System.ComponentModel.ISupportInitialize)(this.tbCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDefinition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osLokalisierung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGruppe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPflegemodelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbWundeJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPDXKuerzel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEntferntJN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseTextEditor tbCode;
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
        private QS2.Desktop.ControlManagment.BaseTextEditor tbPDXKuerzel;
        protected QS2.Desktop.ControlManagment.BaseCheckBox chkEntferntJN;
    }
}