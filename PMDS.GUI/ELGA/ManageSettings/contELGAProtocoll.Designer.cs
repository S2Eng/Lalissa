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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ELGAProtocoll", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Type", -1, null, 2, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Title", -1, null, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Protocoll");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ELGAFunctions");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ELGAErrors");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Characteristics");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CreatedAt", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CreatedUser");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPatient");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAufenthalt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBenutzer");
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
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gridRights = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.contextMenuStripGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.markierteZelleKopierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dsKlientenliste1 = new PMDS.Global.db.ERSystem.dsKlientenliste();
            this.sqlManange1 = new PMDS.Global.db.ERSystem.sqlManange(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRights)).BeginInit();
            this.contextMenuStripGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).BeginInit();
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
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.gridRights.DisplayLayout.Appearance = appearance1;
            this.gridRights.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 0;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
            ultraGridColumn6.Header.Caption = "Typ";
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 3;
            ultraGridColumn6.Width = 105;
            ultraGridColumn7.Header.Caption = "Titel";
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 2;
            ultraGridColumn7.Width = 239;
            ultraGridColumn8.Header.Caption = "Protokoll";
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 8;
            ultraGridColumn9.Header.Editor = null;
            ultraGridColumn9.Header.VisiblePosition = 5;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.Header.Editor = null;
            ultraGridColumn10.Header.VisiblePosition = 6;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.Header.Editor = null;
            ultraGridColumn11.Header.VisiblePosition = 7;
            ultraGridColumn11.Hidden = true;
            appearance2.TextHAlignAsString = "Center";
            ultraGridColumn12.CellAppearance = appearance2;
            appearance3.TextHAlignAsString = "Center";
            ultraGridColumn12.Header.Appearance = appearance3;
            ultraGridColumn12.Header.Caption = "Erstellt am";
            ultraGridColumn12.Header.Editor = null;
            ultraGridColumn12.Header.VisiblePosition = 1;
            ultraGridColumn12.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
            ultraGridColumn12.Width = 126;
            ultraGridColumn13.Header.Caption = "Benutzer erstellt";
            ultraGridColumn13.Header.Editor = null;
            ultraGridColumn13.Header.VisiblePosition = 4;
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
            appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.BorderColor = System.Drawing.SystemColors.Window;
            this.gridRights.DisplayLayout.GroupByBox.Appearance = appearance4;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridRights.DisplayLayout.GroupByBox.BandLabelAppearance = appearance5;
            this.gridRights.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance6.BackColor2 = System.Drawing.SystemColors.Control;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridRights.DisplayLayout.GroupByBox.PromptAppearance = appearance6;
            this.gridRights.DisplayLayout.MaxColScrollRegions = 1;
            this.gridRights.DisplayLayout.MaxRowScrollRegions = 1;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            appearance7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridRights.DisplayLayout.Override.ActiveCellAppearance = appearance7;
            appearance8.BackColor = System.Drawing.SystemColors.Highlight;
            appearance8.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridRights.DisplayLayout.Override.ActiveRowAppearance = appearance8;
            this.gridRights.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridRights.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            this.gridRights.DisplayLayout.Override.CardAreaAppearance = appearance9;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridRights.DisplayLayout.Override.CellAppearance = appearance10;
            this.gridRights.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridRights.DisplayLayout.Override.CellPadding = 0;
            appearance11.BackColor = System.Drawing.SystemColors.Control;
            appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance11.BorderColor = System.Drawing.SystemColors.Window;
            this.gridRights.DisplayLayout.Override.GroupByRowAppearance = appearance11;
            appearance12.TextHAlignAsString = "Left";
            this.gridRights.DisplayLayout.Override.HeaderAppearance = appearance12;
            this.gridRights.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridRights.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.BorderColor = System.Drawing.Color.Silver;
            this.gridRights.DisplayLayout.Override.RowAppearance = appearance13;
            this.gridRights.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance14.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridRights.DisplayLayout.Override.TemplateAddRowAppearance = appearance14;
            this.gridRights.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridRights.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridRights.Location = new System.Drawing.Point(3, 3);
            this.gridRights.Name = "gridRights";
            this.gridRights.Size = new System.Drawing.Size(683, 477);
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
            // contELGAProtocoll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridRights);
            this.Name = "contELGAProtocoll";
            this.Size = new System.Drawing.Size(689, 483);
            this.Load += new System.EventHandler(this.contELGAProtocoll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRights)).EndInit();
            this.contextMenuStripGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).EndInit();
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
    }
}
