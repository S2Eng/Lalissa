namespace qs2.sitemap.workflowAssist.form
{
    partial class contAutoProtokoll
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("protokoll", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TextSub", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TextControl", -1, null, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TextMessage");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("rowAutoUI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("sys");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("admin");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("supress");
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
            this.gridProtocoll = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.dsAdminFields = new qs2.core.vb.dsAdmin();
            this.dsAdminSys = new qs2.core.vb.dsAdmin();
            this.panelTop = new Infragistics.Win.Misc.UltraPanel();
            this.panelBelow = new Infragistics.Win.Misc.UltraPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gridProtocoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAdminFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAdminSys)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelBelow.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridProtocoll
            // 
            this.gridProtocoll.DataMember = "protokoll";
            this.gridProtocoll.DataSource = this.dsAdminFields;
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.gridProtocoll.DisplayLayout.Appearance = appearance1;
            this.gridProtocoll.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn15.Header.Caption = "TextSub";
            ultraGridColumn15.Header.VisiblePosition = 0;
            ultraGridColumn15.Width = 118;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn16.Header.VisiblePosition = 1;
            ultraGridColumn16.Width = 195;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn17.Header.VisiblePosition = 2;
            ultraGridColumn17.Width = 348;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn18.Header.VisiblePosition = 3;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn18.Width = 104;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn19.Header.VisiblePosition = 4;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn19.Width = 337;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn20.Header.VisiblePosition = 5;
            ultraGridColumn20.Hidden = true;
            ultraGridColumn21.Header.VisiblePosition = 6;
            ultraGridColumn21.Width = 50;
            ultraGridColumn1.Header.VisiblePosition = 7;
            ultraGridColumn1.Width = 59;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn1});
            this.gridProtocoll.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridProtocoll.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.gridProtocoll.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridProtocoll.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.gridProtocoll.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridProtocoll.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.gridProtocoll.DisplayLayout.MaxColScrollRegions = 1;
            this.gridProtocoll.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridProtocoll.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridProtocoll.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.gridProtocoll.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridProtocoll.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.gridProtocoll.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridProtocoll.DisplayLayout.Override.CellAppearance = appearance8;
            this.gridProtocoll.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.gridProtocoll.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.gridProtocoll.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.gridProtocoll.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.gridProtocoll.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridProtocoll.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.gridProtocoll.DisplayLayout.Override.RowAppearance = appearance11;
            this.gridProtocoll.DisplayLayout.Override.RowSpacingAfter = 2;
            this.gridProtocoll.DisplayLayout.Override.RowSpacingBefore = 2;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridProtocoll.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.gridProtocoll.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridProtocoll.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridProtocoll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridProtocoll.Location = new System.Drawing.Point(0, 41);
            this.gridProtocoll.Name = "gridProtocoll";
            this.gridProtocoll.Size = new System.Drawing.Size(791, 392);
            this.gridProtocoll.TabIndex = 0;
            this.gridProtocoll.Text = "Protokoll";
            this.gridProtocoll.DoubleClick += new System.EventHandler(this.ultraGrid1_DoubleClick);
            // 
            // dsAdminFields
            // 
            this.dsAdminFields.DataSetName = "dsAdmin";
            this.dsAdminFields.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsAdminSys
            // 
            this.dsAdminSys.DataSetName = "dsAdmin";
            this.dsAdminSys.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(791, 41);
            this.panelTop.TabIndex = 35;
            this.panelTop.Visible = false;
            // 
            // panelBelow
            // 
            this.panelBelow.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBelow.Location = new System.Drawing.Point(0, 433);
            this.panelBelow.Name = "panelBelow";
            this.panelBelow.Size = new System.Drawing.Size(791, 34);
            this.panelBelow.TabIndex = 36;
            this.panelBelow.Visible = false;
            // 
            // contAutoProtokoll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.gridProtocoll);
            this.Controls.Add(this.panelBelow);
            this.Controls.Add(this.panelTop);
            this.DoubleBuffered = true;
            this.Name = "contAutoProtokoll";
            this.Size = new System.Drawing.Size(791, 467);
            this.Load += new System.EventHandler(this.contAutoProtokoll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridProtocoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAdminFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAdminSys)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelBelow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public core.vb.dsAdmin dsAdminFields;
        public core.vb.dsAdmin dsAdminSys;
        public Infragistics.Win.UltraWinGrid.UltraGrid gridProtocoll;
        internal Infragistics.Win.Misc.UltraPanel panelTop;
        internal Infragistics.Win.Misc.UltraPanel panelBelow;
    }
}
