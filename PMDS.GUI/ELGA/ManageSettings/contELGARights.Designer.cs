namespace PMDS.GUI.ELGA.ManageSettings
{
    partial class contELGARights
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Recht", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn81 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn82 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn83 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ELGA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Select", 0);
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.gridRights = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.dsKlientenliste1 = new PMDS.Global.db.ERSystem.dsKlientenliste();
            this.sqlManange1 = new PMDS.Global.db.ERSystem.sqlManange(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // gridRights
            // 
            this.gridRights.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridRights.DataMember = "Recht";
            this.gridRights.DataSource = this.dsKlientenliste1;
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.gridRights.DisplayLayout.Appearance = appearance1;
            this.gridRights.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn81.Header.Editor = null;
            ultraGridColumn81.Header.VisiblePosition = 0;
            ultraGridColumn81.Hidden = true;
            ultraGridColumn82.Header.Editor = null;
            ultraGridColumn82.Header.VisiblePosition = 2;
            ultraGridColumn82.Width = 298;
            ultraGridColumn83.Header.Editor = null;
            ultraGridColumn83.Header.VisiblePosition = 3;
            ultraGridColumn83.Hidden = true;
            ultraGridColumn41.DataType = typeof(bool);
            ultraGridColumn41.Header.Caption = "Auswahl";
            ultraGridColumn41.Header.Editor = null;
            ultraGridColumn41.Header.VisiblePosition = 1;
            ultraGridColumn41.Width = 75;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn81,
            ultraGridColumn82,
            ultraGridColumn83,
            ultraGridColumn41});
            this.gridRights.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridRights.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridRights.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.gridRights.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridRights.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.gridRights.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridRights.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.gridRights.DisplayLayout.MaxColScrollRegions = 1;
            this.gridRights.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridRights.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridRights.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.gridRights.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridRights.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.gridRights.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridRights.DisplayLayout.Override.CellAppearance = appearance8;
            this.gridRights.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridRights.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.gridRights.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.gridRights.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.gridRights.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridRights.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.gridRights.DisplayLayout.Override.RowAppearance = appearance11;
            this.gridRights.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridRights.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.gridRights.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridRights.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridRights.Location = new System.Drawing.Point(3, 3);
            this.gridRights.Name = "gridRights";
            this.gridRights.Size = new System.Drawing.Size(624, 473);
            this.gridRights.TabIndex = 3;
            this.gridRights.Text = "ultraGrid1";
            this.gridRights.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.GridRights_CellChange);
            this.gridRights.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.GridRights_BeforeCellActivate);
            this.gridRights.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.GridRights_BeforeRowsDeleted);
            this.gridRights.Click += new System.EventHandler(this.GridRights_Click);
            this.gridRights.DoubleClick += new System.EventHandler(this.GridRights_DoubleClick);
            // 
            // dsKlientenliste1
            // 
            this.dsKlientenliste1.DataSetName = "dsKlientenliste";
            this.dsKlientenliste1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsKlientenliste1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // contELGARights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gridRights);
            this.Name = "contELGARights";
            this.Size = new System.Drawing.Size(630, 479);
            this.Load += new System.EventHandler(this.ContELGARights_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid gridRights;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Global.db.ERSystem.dsKlientenliste dsKlientenliste1;
        private Global.db.ERSystem.sqlManange sqlManange1;
    }
}
