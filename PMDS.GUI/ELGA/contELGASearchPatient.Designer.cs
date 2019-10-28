namespace PMDS.GUI.ELGA
{
    partial class contELGASearchPatient
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
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ELGASearchPatients", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NachnameFirma", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Vorname", -1, null, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Strasse");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PLZ", -1, null, 2, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Ort", -1, null, 3, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Land");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Tel");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SozVersNr");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PatientLocalID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
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
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpSearch = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnSearch = new Infragistics.Win.Misc.UltraButton();
            this.txtSozVersNr = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblSozVersNr = new Infragistics.Win.Misc.UltraLabel();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnSave = new QS2.Desktop.ControlManagment.BaseButton();
            this.gridFound = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.dsManage1 = new PMDS.Global.db.ERSystem.dsManage();
            this.sqlManange1 = new PMDS.Global.db.ERSystem.sqlManange(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).BeginInit();
            this.grpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSozVersNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsManage1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.txtSozVersNr);
            this.grpSearch.Controls.Add(this.lblSozVersNr);
            this.grpSearch.Location = new System.Drawing.Point(11, 9);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(423, 60);
            this.grpSearch.TabIndex = 4;
            this.grpSearch.Text = "Suche";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(330, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(77, 36);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Suche";
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // txtSozVersNr
            // 
            appearance15.BackColor = System.Drawing.Color.White;
            this.txtSozVersNr.Appearance = appearance15;
            this.txtSozVersNr.BackColor = System.Drawing.Color.White;
            this.txtSozVersNr.Location = new System.Drawing.Point(86, 24);
            this.txtSozVersNr.Name = "txtSozVersNr";
            this.txtSozVersNr.Size = new System.Drawing.Size(225, 21);
            this.txtSozVersNr.TabIndex = 0;
            // 
            // lblSozVersNr
            // 
            appearance16.TextVAlignAsString = "Middle";
            this.lblSozVersNr.Appearance = appearance16;
            this.lblSozVersNr.Location = new System.Drawing.Point(13, 26);
            this.lblSozVersNr.Name = "lblSozVersNr";
            this.lblSozVersNr.Size = new System.Drawing.Size(173, 16);
            this.lblSozVersNr.TabIndex = 1;
            this.lblSozVersNr.Text = "Soz.Vers.Nr";
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance13.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance13.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbort.Appearance = appearance13;
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(362, 456);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(82, 30);
            this.btnAbort.TabIndex = 124;
            this.btnAbort.Tag = "";
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.Click += new System.EventHandler(this.BtnAbort_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance14.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance14.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance14;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.IsStandardControl = false;
            this.btnSave.Location = new System.Drawing.Point(444, 456);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 30);
            this.btnSave.TabIndex = 125;
            this.btnSave.Tag = "";
            this.btnSave.Text = "Speichern";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // gridFound
            // 
            this.gridFound.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFound.DataMember = "ELGASearchPatients";
            this.gridFound.DataSource = this.dsManage1;
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.gridFound.DisplayLayout.Appearance = appearance1;
            this.gridFound.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn4.Header.Caption = "Nachname/Firma";
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 1;
            ultraGridColumn4.Width = 159;
            ultraGridColumn12.Header.Editor = null;
            ultraGridColumn12.Header.VisiblePosition = 2;
            ultraGridColumn12.Width = 126;
            ultraGridColumn13.Header.Editor = null;
            ultraGridColumn13.Header.VisiblePosition = 5;
            ultraGridColumn13.Width = 199;
            ultraGridColumn14.Header.Editor = null;
            ultraGridColumn14.Header.VisiblePosition = 3;
            ultraGridColumn14.Width = 76;
            ultraGridColumn15.Header.Editor = null;
            ultraGridColumn15.Header.VisiblePosition = 4;
            ultraGridColumn15.Width = 138;
            ultraGridColumn16.Header.Editor = null;
            ultraGridColumn16.Header.VisiblePosition = 6;
            ultraGridColumn17.Header.Editor = null;
            ultraGridColumn17.Header.VisiblePosition = 7;
            ultraGridColumn17.Width = 125;
            ultraGridColumn18.Header.Caption = "Soz.Vers.Nr";
            ultraGridColumn18.Header.Editor = null;
            ultraGridColumn18.Header.VisiblePosition = 0;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 8;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn20.Header.Editor = null;
            ultraGridColumn20.Header.VisiblePosition = 9;
            ultraGridColumn20.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn4,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn1,
            ultraGridColumn20});
            this.gridFound.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridFound.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.gridFound.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridFound.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.gridFound.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridFound.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.gridFound.DisplayLayout.MaxColScrollRegions = 1;
            this.gridFound.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridFound.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridFound.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.gridFound.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridFound.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.gridFound.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridFound.DisplayLayout.Override.CellAppearance = appearance8;
            this.gridFound.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridFound.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.gridFound.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.gridFound.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.gridFound.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridFound.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.gridFound.DisplayLayout.Override.RowAppearance = appearance11;
            this.gridFound.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridFound.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.gridFound.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridFound.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridFound.Location = new System.Drawing.Point(7, 76);
            this.gridFound.Name = "gridFound";
            this.gridFound.Size = new System.Drawing.Size(894, 377);
            this.gridFound.TabIndex = 126;
            this.gridFound.Text = "ELGA Patienten";
            this.gridFound.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.GridFound_BeforeCellActivate);
            this.gridFound.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.GridFound_BeforeRowsDeleted);
            this.gridFound.Click += new System.EventHandler(this.GridFound_Click);
            this.gridFound.DoubleClick += new System.EventHandler(this.GridFound_DoubleClick);
            // 
            // dsManage1
            // 
            this.dsManage1.DataSetName = "dsManage";
            this.dsManage1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // contELGASearchPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gridFound);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpSearch);
            this.Name = "contELGASearchPatient";
            this.Size = new System.Drawing.Size(908, 492);
            this.Load += new System.EventHandler(this.ContELGASearchPatient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSozVersNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsManage1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Infragistics.Win.Misc.UltraGroupBox grpSearch;
        private Infragistics.Win.Misc.UltraButton btnSearch;
        private Infragistics.Win.Misc.UltraLabel lblSozVersNr;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor txtSozVersNr;
        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
        public QS2.Desktop.ControlManagment.BaseButton btnSave;
        private Infragistics.Win.UltraWinGrid.UltraGrid gridFound;
        private Global.db.ERSystem.dsManage dsManage1;
        private Global.db.ERSystem.sqlManange sqlManange1;
    }
}
