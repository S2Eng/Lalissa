namespace PMDS.GUI.ELGA
{
    partial class contELGASearchDocuments
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
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ELGASearchDocuments", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Dokument", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ErstelltAm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UUID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UniqueID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LocigalID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Author", -1, null, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Description");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DocStatus");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Version");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Stylesheet");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CreationTime");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TypeFile");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Size");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ELGAPatientLocalID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPatient");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAufenthalt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Select", 0);
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
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnOK = new QS2.Desktop.ControlManagment.BaseButton();
            this.grpSearch = new Infragistics.Win.Misc.UltraGroupBox();
            this.udteCreatedTo = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.lblCreatedTo = new Infragistics.Win.Misc.UltraLabel();
            this.udteCreatedFrom = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.btnSearch = new Infragistics.Win.Misc.UltraButton();
            this.lblCreatedFom = new Infragistics.Win.Misc.UltraLabel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gridFound = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.contextMenuStripGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cDADokumentÖffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dsManage1 = new PMDS.Global.db.ERSystem.dsManage();
            this.sqlManange1 = new PMDS.Global.db.ERSystem.sqlManange(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).BeginInit();
            this.grpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udteCreatedTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteCreatedFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFound)).BeginInit();
            this.contextMenuStripGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsManage1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbort.Appearance = appearance1;
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(360, 435);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(82, 30);
            this.btnAbort.TabIndex = 128;
            this.btnAbort.Tag = "";
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.Click += new System.EventHandler(this.BtnAbort_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance2;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.IsStandardControl = false;
            this.btnOK.Location = new System.Drawing.Point(442, 435);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(82, 30);
            this.btnOK.TabIndex = 129;
            this.btnOK.Tag = "";
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.udteCreatedTo);
            this.grpSearch.Controls.Add(this.lblCreatedTo);
            this.grpSearch.Controls.Add(this.udteCreatedFrom);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.lblCreatedFom);
            this.grpSearch.Location = new System.Drawing.Point(7, 5);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(444, 60);
            this.grpSearch.TabIndex = 127;
            this.grpSearch.Text = "Suche";
            // 
            // udteCreatedTo
            // 
            this.udteCreatedTo.Location = new System.Drawing.Point(209, 23);
            this.udteCreatedTo.Name = "udteCreatedTo";
            this.udteCreatedTo.Size = new System.Drawing.Size(98, 21);
            this.udteCreatedTo.TabIndex = 1;
            // 
            // lblCreatedTo
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.lblCreatedTo.Appearance = appearance3;
            this.lblCreatedTo.Location = new System.Drawing.Point(185, 25);
            this.lblCreatedTo.Name = "lblCreatedTo";
            this.lblCreatedTo.Size = new System.Drawing.Size(78, 16);
            this.lblCreatedTo.TabIndex = 12;
            this.lblCreatedTo.Text = "bis";
            // 
            // udteCreatedFrom
            // 
            this.udteCreatedFrom.Location = new System.Drawing.Point(81, 23);
            this.udteCreatedFrom.Name = "udteCreatedFrom";
            this.udteCreatedFrom.Size = new System.Drawing.Size(98, 21);
            this.udteCreatedFrom.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(354, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(77, 36);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Suche";
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // lblCreatedFom
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.lblCreatedFom.Appearance = appearance4;
            this.lblCreatedFom.Location = new System.Drawing.Point(11, 25);
            this.lblCreatedFom.Name = "lblCreatedFom";
            this.lblCreatedFom.Size = new System.Drawing.Size(78, 16);
            this.lblCreatedFom.TabIndex = 1;
            this.lblCreatedFom.Text = "Erstellt von";
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // gridFound
            // 
            this.gridFound.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFound.ContextMenuStrip = this.contextMenuStripGrid;
            this.gridFound.DataMember = "ELGASearchDocuments";
            this.gridFound.DataSource = this.dsManage1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.gridFound.DisplayLayout.Appearance = appearance5;
            this.gridFound.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn3.Width = 328;
            ultraGridColumn4.Header.Caption = "Erstellt am";
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
            ultraGridColumn4.Width = 114;
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 8;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn5.Width = 111;
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 10;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn6.Width = 121;
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 13;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 4;
            ultraGridColumn8.Width = 132;
            ultraGridColumn9.Header.Caption = "Beschreibung";
            ultraGridColumn9.Header.Editor = null;
            ultraGridColumn9.Header.VisiblePosition = 15;
            ultraGridColumn9.Width = 327;
            ultraGridColumn10.Header.Caption = "Status";
            ultraGridColumn10.Header.Editor = null;
            ultraGridColumn10.Header.VisiblePosition = 5;
            ultraGridColumn10.Width = 108;
            ultraGridColumn11.Header.Editor = null;
            ultraGridColumn11.Header.VisiblePosition = 6;
            ultraGridColumn11.Width = 70;
            ultraGridColumn16.Header.Editor = null;
            ultraGridColumn16.Header.VisiblePosition = 9;
            ultraGridColumn12.Header.Caption = "Erstellt am";
            ultraGridColumn12.Header.Editor = null;
            ultraGridColumn12.Header.VisiblePosition = 2;
            ultraGridColumn12.Width = 113;
            ultraGridColumn18.Header.Caption = "Dateityp";
            ultraGridColumn18.Header.Editor = null;
            ultraGridColumn18.Header.VisiblePosition = 11;
            ultraGridColumn13.Header.Caption = "Grösse";
            ultraGridColumn13.Header.Editor = null;
            ultraGridColumn13.Header.VisiblePosition = 7;
            ultraGridColumn17.Header.Editor = null;
            ultraGridColumn17.Header.VisiblePosition = 14;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn14.Header.Editor = null;
            ultraGridColumn14.Header.VisiblePosition = 12;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 16;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn15.Header.Editor = null;
            ultraGridColumn15.Header.VisiblePosition = 17;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn1.DataType = typeof(bool);
            ultraGridColumn1.Header.Caption = "Auswahl";
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 60;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn16,
            ultraGridColumn12,
            ultraGridColumn18,
            ultraGridColumn13,
            ultraGridColumn17,
            ultraGridColumn14,
            ultraGridColumn2,
            ultraGridColumn15,
            ultraGridColumn1});
            this.gridFound.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridFound.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.gridFound.DisplayLayout.GroupByBox.Appearance = appearance6;
            appearance7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridFound.DisplayLayout.GroupByBox.BandLabelAppearance = appearance7;
            this.gridFound.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance8.BackColor2 = System.Drawing.SystemColors.Control;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridFound.DisplayLayout.GroupByBox.PromptAppearance = appearance8;
            this.gridFound.DisplayLayout.MaxColScrollRegions = 1;
            this.gridFound.DisplayLayout.MaxRowScrollRegions = 1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridFound.DisplayLayout.Override.ActiveCellAppearance = appearance9;
            appearance10.BackColor = System.Drawing.SystemColors.Highlight;
            appearance10.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridFound.DisplayLayout.Override.ActiveRowAppearance = appearance10;
            this.gridFound.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridFound.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            this.gridFound.DisplayLayout.Override.CardAreaAppearance = appearance11;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            appearance12.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridFound.DisplayLayout.Override.CellAppearance = appearance12;
            this.gridFound.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridFound.DisplayLayout.Override.CellPadding = 0;
            appearance13.BackColor = System.Drawing.SystemColors.Control;
            appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance13.BorderColor = System.Drawing.SystemColors.Window;
            this.gridFound.DisplayLayout.Override.GroupByRowAppearance = appearance13;
            appearance14.TextHAlignAsString = "Left";
            this.gridFound.DisplayLayout.Override.HeaderAppearance = appearance14;
            this.gridFound.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridFound.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance15.BackColor = System.Drawing.SystemColors.Window;
            appearance15.BorderColor = System.Drawing.Color.Silver;
            this.gridFound.DisplayLayout.Override.RowAppearance = appearance15;
            this.gridFound.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance16.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridFound.DisplayLayout.Override.TemplateAddRowAppearance = appearance16;
            this.gridFound.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridFound.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridFound.Location = new System.Drawing.Point(3, 71);
            this.gridFound.Name = "gridFound";
            this.gridFound.Size = new System.Drawing.Size(881, 362);
            this.gridFound.TabIndex = 130;
            this.gridFound.Text = "ELGA Dokumente";
            this.gridFound.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.GridFound_BeforeCellActivate);
            this.gridFound.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.GridFound_BeforeRowsDeleted);
            this.gridFound.Click += new System.EventHandler(this.GridFound_Click);
            this.gridFound.DoubleClick += new System.EventHandler(this.GridFound_DoubleClick);
            // 
            // contextMenuStripGrid
            // 
            this.contextMenuStripGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cDADokumentÖffnenToolStripMenuItem});
            this.contextMenuStripGrid.Name = "contextMenuStripGrid";
            this.contextMenuStripGrid.Size = new System.Drawing.Size(198, 26);
            // 
            // cDADokumentÖffnenToolStripMenuItem
            // 
            this.cDADokumentÖffnenToolStripMenuItem.Name = "cDADokumentÖffnenToolStripMenuItem";
            this.cDADokumentÖffnenToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.cDADokumentÖffnenToolStripMenuItem.Text = "CDA-Dokument öffnen";
            this.cDADokumentÖffnenToolStripMenuItem.Click += new System.EventHandler(this.cDADokumentÖffnenToolStripMenuItem_Click);
            // 
            // dsManage1
            // 
            this.dsManage1.DataSetName = "dsManage";
            this.dsManage1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // contELGASearchDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gridFound);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpSearch);
            this.Name = "contELGASearchDocuments";
            this.Size = new System.Drawing.Size(887, 469);
            this.Load += new System.EventHandler(this.ContELGASearchDocuments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udteCreatedTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteCreatedFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFound)).EndInit();
            this.contextMenuStripGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsManage1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid gridFound;
        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
        public QS2.Desktop.ControlManagment.BaseButton btnOK;
        private Infragistics.Win.Misc.UltraGroupBox grpSearch;
        private Infragistics.Win.Misc.UltraButton btnSearch;
        private Infragistics.Win.Misc.UltraLabel lblCreatedFom;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Global.db.ERSystem.dsManage dsManage1;
        private Global.db.ERSystem.sqlManange sqlManange1;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udteCreatedFrom;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udteCreatedTo;
        private Infragistics.Win.Misc.UltraLabel lblCreatedTo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGrid;
        private System.Windows.Forms.ToolStripMenuItem cDADokumentÖffnenToolStripMenuItem;
    }
}
