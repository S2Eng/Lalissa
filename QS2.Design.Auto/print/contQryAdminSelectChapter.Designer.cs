namespace qs2.design.auto.print
{
    partial class contQryAdminSelectChapter
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Chapters", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ChapterKey");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Chapter", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
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
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(contQryAdminSelectChapter));
            this.gridSelectChapter = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.dsHelper1 = new qs2.core.vb.dsHelper();
            this.btnAbort = new qs2.sitemap.ownControls.inherit_Infrag.InfragButton();
            this.btnOk = new qs2.sitemap.ownControls.inherit_Infrag.InfragButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridSelectChapter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsHelper1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSelectChapter
            // 
            this.gridSelectChapter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSelectChapter.DataMember = "Chapters";
            this.gridSelectChapter.DataSource = this.dsHelper1;
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.gridSelectChapter.DisplayLayout.Appearance = appearance1;
            this.gridSelectChapter.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridBand1.ColHeadersVisible = false;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 288;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3});
            this.gridSelectChapter.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridSelectChapter.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridSelectChapter.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.gridSelectChapter.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridSelectChapter.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.gridSelectChapter.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridSelectChapter.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.gridSelectChapter.DisplayLayout.MaxColScrollRegions = 1;
            this.gridSelectChapter.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridSelectChapter.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridSelectChapter.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.gridSelectChapter.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridSelectChapter.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.gridSelectChapter.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridSelectChapter.DisplayLayout.Override.CellAppearance = appearance8;
            this.gridSelectChapter.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridSelectChapter.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.gridSelectChapter.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.gridSelectChapter.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.gridSelectChapter.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridSelectChapter.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.gridSelectChapter.DisplayLayout.Override.RowAppearance = appearance11;
            this.gridSelectChapter.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridSelectChapter.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.gridSelectChapter.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridSelectChapter.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridSelectChapter.Location = new System.Drawing.Point(6, 6);
            this.gridSelectChapter.Name = "gridSelectChapter";
            this.gridSelectChapter.Size = new System.Drawing.Size(290, 149);
            this.gridSelectChapter.TabIndex = 19;
            this.gridSelectChapter.Text = "Select chapter";
            this.gridSelectChapter.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.gridSelectChapter_BeforeCellActivate);
            this.gridSelectChapter.Click += new System.EventHandler(this.gridSelectChapter_Click);
            this.gridSelectChapter.DoubleClick += new System.EventHandler(this.gridSelectChapter_DoubleClick);
            // 
            // dsHelper1
            // 
            this.dsHelper1.DataSetName = "dsHelper";
            this.dsHelper1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance13.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnAbort.Appearance = appearance13;
            this.btnAbort.Location = new System.Drawing.Point(149, 158);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.OwnAutoTextYN = false;
            this.btnAbort.OwnPicture = QS2.Resources.getRes.ePicture.none;
            this.btnAbort.OwnPictureTxt = "";
            this.btnAbort.OwnSizeMode = qs2.core.Enums.eSize.big;
            this.btnAbort.OwnTooltipText = "";
            this.btnAbort.OwnTooltipTitle = null;
            this.btnAbort.Size = new System.Drawing.Size(71, 26);
            this.btnAbort.TabIndex = 16;
            this.btnAbort.Text = "Abort";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance14.Image = ((object)(resources.GetObject("appearance14.Image")));
            appearance14.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.btnOk.Appearance = appearance14;
            this.btnOk.Location = new System.Drawing.Point(88, 158);
            this.btnOk.Name = "btnOk";
            this.btnOk.OwnAutoTextYN = false;
            this.btnOk.OwnPicture = QS2.Resources.getRes.Allgemein.ico_OK;
            this.btnOk.OwnPictureTxt = "";
            this.btnOk.OwnSizeMode = qs2.core.Enums.eSize.small;
            this.btnOk.OwnTooltipText = "";
            this.btnOk.OwnTooltipTitle = null;
            this.btnOk.Size = new System.Drawing.Size(61, 26);
            this.btnOk.TabIndex = 15;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // contQryAdminSelectChapter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gridSelectChapter);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnOk);
            this.Name = "contQryAdminSelectChapter";
            this.Size = new System.Drawing.Size(302, 187);
            this.Load += new System.EventHandler(this.contQryAdminSelectChapter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridSelectChapter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsHelper1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private sitemap.ownControls.inherit_Infrag.InfragButton btnAbort;
        private sitemap.ownControls.inherit_Infrag.InfragButton btnOk;
        private Infragistics.Win.UltraWinGrid.UltraGrid gridSelectChapter;
        private core.vb.dsHelper dsHelper1;
    }
}
