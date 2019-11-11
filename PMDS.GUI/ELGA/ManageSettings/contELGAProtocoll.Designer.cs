namespace PMDS.GUI.ELGA
{
    partial class contELGAProtocoll
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ELGAProtocoll", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Type", -1, null, 2, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Title", -1, null, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Protocoll");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ELGAFunctions");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ELGAErrors");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Characteristics");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CreatedAt", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CreatedUser");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPatient");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAufenthalt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBenutzer");
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
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gridRights = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.contextMenuStripGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.markierteZelleKopierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dsKlientenliste1 = new PMDS.Global.db.ERSystem.dsKlientenliste();
            this.sqlManange1 = new PMDS.Global.db.ERSystem.sqlManange(this.components);
            this.lblFrom = new Infragistics.Win.Misc.UltraLabel();
            this.lblTo = new Infragistics.Win.Misc.UltraLabel();
            this.udteFrom = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.udteTo = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.grpSearch = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnSearch = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRights)).BeginInit();
            this.contextMenuStripGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).BeginInit();
            this.grpSearch.SuspendLayout();
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
            // gridRights
            // 
            this.gridRights.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridRights.ContextMenuStrip = this.contextMenuStripGrid;
            this.gridRights.DataMember = "ELGAProtocoll";
            this.gridRights.DataSource = this.dsKlientenliste1;
            appearance3.BackColor = System.Drawing.SystemColors.Window;
            appearance3.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.gridRights.DisplayLayout.Appearance = appearance3;
            this.gridRights.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 0;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
            ultraGridColumn6.Header.Caption = "Typ";
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 7;
            ultraGridColumn6.Width = 105;
            ultraGridColumn7.Header.Caption = "Titel";
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 2;
            ultraGridColumn7.Width = 239;
            ultraGridColumn8.Header.Caption = "Protokoll";
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 8;
            ultraGridColumn9.Header.Editor = null;
            ultraGridColumn9.Header.VisiblePosition = 4;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.Header.Editor = null;
            ultraGridColumn10.Header.VisiblePosition = 5;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.Header.Editor = null;
            ultraGridColumn11.Header.VisiblePosition = 6;
            ultraGridColumn11.Hidden = true;
            appearance4.TextHAlignAsString = "Center";
            ultraGridColumn12.CellAppearance = appearance4;
            appearance5.TextHAlignAsString = "Center";
            ultraGridColumn12.Header.Appearance = appearance5;
            ultraGridColumn12.Header.Caption = "Erstellt am";
            ultraGridColumn12.Header.Editor = null;
            ultraGridColumn12.Header.VisiblePosition = 1;
            ultraGridColumn12.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
            ultraGridColumn12.Width = 126;
            ultraGridColumn13.Header.Caption = "Benutzer erstellt";
            ultraGridColumn13.Header.Editor = null;
            ultraGridColumn13.Header.VisiblePosition = 3;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 9;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 10;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 11;
            ultraGridColumn3.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3});
            this.gridRights.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridRights.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridRights.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.gridRights.DisplayLayout.GroupByBox.Appearance = appearance6;
            appearance7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridRights.DisplayLayout.GroupByBox.BandLabelAppearance = appearance7;
            this.gridRights.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance8.BackColor2 = System.Drawing.SystemColors.Control;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridRights.DisplayLayout.GroupByBox.PromptAppearance = appearance8;
            this.gridRights.DisplayLayout.MaxColScrollRegions = 1;
            this.gridRights.DisplayLayout.MaxRowScrollRegions = 1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridRights.DisplayLayout.Override.ActiveCellAppearance = appearance9;
            appearance10.BackColor = System.Drawing.SystemColors.Highlight;
            appearance10.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridRights.DisplayLayout.Override.ActiveRowAppearance = appearance10;
            this.gridRights.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridRights.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            this.gridRights.DisplayLayout.Override.CardAreaAppearance = appearance11;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            appearance12.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridRights.DisplayLayout.Override.CellAppearance = appearance12;
            this.gridRights.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridRights.DisplayLayout.Override.CellPadding = 0;
            appearance13.BackColor = System.Drawing.SystemColors.Control;
            appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance13.BorderColor = System.Drawing.SystemColors.Window;
            this.gridRights.DisplayLayout.Override.GroupByRowAppearance = appearance13;
            appearance14.TextHAlignAsString = "Left";
            this.gridRights.DisplayLayout.Override.HeaderAppearance = appearance14;
            this.gridRights.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridRights.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance15.BackColor = System.Drawing.SystemColors.Window;
            appearance15.BorderColor = System.Drawing.Color.Silver;
            this.gridRights.DisplayLayout.Override.RowAppearance = appearance15;
            this.gridRights.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance16.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridRights.DisplayLayout.Override.TemplateAddRowAppearance = appearance16;
            this.gridRights.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridRights.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridRights.Location = new System.Drawing.Point(3, 56);
            this.gridRights.Name = "gridRights";
            this.gridRights.Size = new System.Drawing.Size(683, 424);
            this.gridRights.TabIndex = 4;
            this.gridRights.Text = "ultraGrid1";
            this.gridRights.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.GridRights_BeforeCellActivate);
            this.gridRights.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.GridRights_BeforeRowsDeleted);
            this.gridRights.Click += new System.EventHandler(this.GridRights_Click);
            this.gridRights.DoubleClick += new System.EventHandler(this.GridRights_DoubleClick);
            // 
            // contextMenuStripGrid
            // 
            this.contextMenuStripGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.markierteZelleKopierenToolStripMenuItem});
            this.contextMenuStripGrid.Name = "contextMenuStripGrid";
            this.contextMenuStripGrid.Size = new System.Drawing.Size(172, 26);
            // 
            // markierteZelleKopierenToolStripMenuItem
            // 
            this.markierteZelleKopierenToolStripMenuItem.Name = "markierteZelleKopierenToolStripMenuItem";
            this.markierteZelleKopierenToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.markierteZelleKopierenToolStripMenuItem.Text = "Protokoll kopieren";
            this.markierteZelleKopierenToolStripMenuItem.Click += new System.EventHandler(this.MarkierteZelleKopierenToolStripMenuItem_Click);
            // 
            // dsKlientenliste1
            // 
            this.dsKlientenliste1.DataSetName = "dsKlientenliste";
            this.dsKlientenliste1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsKlientenliste1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblFrom
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.lblFrom.Appearance = appearance18;
            this.lblFrom.Location = new System.Drawing.Point(12, 19);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(79, 18);
            this.lblFrom.TabIndex = 6;
            this.lblFrom.Text = "Erstellt von:";
            // 
            // lblTo
            // 
            appearance17.TextHAlignAsString = "Center";
            appearance17.TextVAlignAsString = "Middle";
            this.lblTo.Appearance = appearance17;
            this.lblTo.Location = new System.Drawing.Point(164, 19);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(30, 18);
            this.lblTo.TabIndex = 7;
            this.lblTo.Text = "bis";
            // 
            // udteFrom
            // 
            this.udteFrom.Location = new System.Drawing.Point(78, 18);
            this.udteFrom.Name = "udteFrom";
            this.udteFrom.Size = new System.Drawing.Size(88, 21);
            this.udteFrom.TabIndex = 8;
            // 
            // udteTo
            // 
            this.udteTo.Location = new System.Drawing.Point(194, 18);
            this.udteTo.Name = "udteTo";
            this.udteTo.Size = new System.Drawing.Size(88, 21);
            this.udteTo.TabIndex = 9;
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.udteTo);
            this.grpSearch.Controls.Add(this.udteFrom);
            this.grpSearch.Controls.Add(this.lblTo);
            this.grpSearch.Controls.Add(this.lblFrom);
            this.grpSearch.Location = new System.Drawing.Point(3, 3);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(388, 48);
            this.grpSearch.TabIndex = 10;
            this.grpSearch.Text = "Suche";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(302, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(71, 28);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Suchen";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // contELGAProtocoll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.gridRights);
            this.Name = "contELGAProtocoll";
            this.Size = new System.Drawing.Size(689, 483);
            this.Load += new System.EventHandler(this.contELGAProtocoll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRights)).EndInit();
            this.contextMenuStripGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Global.db.ERSystem.dsKlientenliste dsKlientenliste1;
        private Global.db.ERSystem.sqlManange sqlManange1;
        private Infragistics.Win.UltraWinGrid.UltraGrid gridRights;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGrid;
        private System.Windows.Forms.ToolStripMenuItem markierteZelleKopierenToolStripMenuItem;
        private Infragistics.Win.Misc.UltraGroupBox grpSearch;
        private Infragistics.Win.Misc.UltraButton btnSearch;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udteTo;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udteFrom;
        public Infragistics.Win.Misc.UltraLabel lblTo;
        public Infragistics.Win.Misc.UltraLabel lblFrom;
    }
}
