namespace qs2.design.auto.print
{
    partial class contSqlConsoleForAdmin
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
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            this.gridResult = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.txtSql = new Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor();
            this.lblSql = new Infragistics.Win.Misc.UltraLabel();
            this.btnClose = new qs2.sitemap.ownControls.inherit_Infrag.InfragButton();
            this.btnExceuteSql = new qs2.sitemap.ownControls.inherit_Infrag.InfragButton();
            this.contTable1 = new qs2.ui.print.contTable();
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).BeginInit();
            this.SuspendLayout();
            // 
            // gridResult
            // 
            this.gridResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.gridResult.DisplayLayout.Appearance = appearance1;
            this.gridResult.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.gridResult.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridResult.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.gridResult.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridResult.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.gridResult.DisplayLayout.MaxColScrollRegions = 1;
            this.gridResult.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridResult.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridResult.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.gridResult.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridResult.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.gridResult.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridResult.DisplayLayout.Override.CellAppearance = appearance8;
            this.gridResult.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
            this.gridResult.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.gridResult.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.gridResult.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.gridResult.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridResult.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.gridResult.DisplayLayout.Override.RowAppearance = appearance11;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridResult.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.gridResult.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridResult.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridResult.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.gridResult.Location = new System.Drawing.Point(148, 404);
            this.gridResult.Name = "gridResult";
            this.gridResult.Size = new System.Drawing.Size(202, 88);
            this.gridResult.TabIndex = 1;
            this.gridResult.Text = "Result";
            // 
            // txtSql
            // 
            this.txtSql.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSql.Location = new System.Drawing.Point(4, 15);
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(824, 241);
            this.txtSql.TabIndex = 3;
            this.txtSql.Value = "";
            // 
            // lblSql
            // 
            this.lblSql.Location = new System.Drawing.Point(4, 1);
            this.lblSql.Name = "lblSql";
            this.lblSql.Size = new System.Drawing.Size(84, 15);
            this.lblSql.TabIndex = 27;
            this.lblSql.Text = "Sql";
            // 
            // btnClose
            // 
            appearance13.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.btnClose.Appearance = appearance13;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(21, 135);
            this.btnClose.Name = "btnClose";
            this.btnClose.OwnAutoTextYN = false;
            this.btnClose.OwnPicture = QS2.Resources.getRes.ePicture.none;
            this.btnClose.OwnPictureTxt = "";
            this.btnClose.OwnSizeMode = qs2.core.Enums.eSize.small;
            this.btnClose.OwnTooltipText = "";
            this.btnClose.OwnTooltipTitle = null;
            this.btnClose.Size = new System.Drawing.Size(52, 23);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExceuteSql
            // 
            this.btnExceuteSql.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance14.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.btnExceuteSql.Appearance = appearance14;
            this.btnExceuteSql.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExceuteSql.Location = new System.Drawing.Point(743, 256);
            this.btnExceuteSql.Name = "btnExceuteSql";
            this.btnExceuteSql.OwnAutoTextYN = false;
            this.btnExceuteSql.OwnPicture = QS2.Resources.getRes.ePicture.none;
            this.btnExceuteSql.OwnPictureTxt = "";
            this.btnExceuteSql.OwnSizeMode = qs2.core.Enums.eSize.small;
            this.btnExceuteSql.OwnTooltipText = "";
            this.btnExceuteSql.OwnTooltipTitle = null;
            this.btnExceuteSql.Size = new System.Drawing.Size(85, 23);
            this.btnExceuteSql.TabIndex = 2;
            this.btnExceuteSql.Text = "Exceute Sql";
            this.btnExceuteSql.Click += new System.EventHandler(this.btnExceuteSql_Click);
            // 
            // contTable1
            // 
            this.contTable1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contTable1.BackColor = System.Drawing.Color.Transparent;
            this.contTable1.Location = new System.Drawing.Point(4, 274);
            this.contTable1.Name = "contTable1";
            this.contTable1.Size = new System.Drawing.Size(824, 397);
            this.contTable1.TabIndex = 29;
            // 
            // contSqlConsoleForAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnExceuteSql);
            this.Controls.Add(this.contTable1);
            this.Controls.Add(this.txtSql);
            this.Controls.Add(this.gridResult);
            this.Controls.Add(this.lblSql);
            this.Controls.Add(this.btnClose);
            this.Name = "contSqlConsoleForAdmin";
            this.Size = new System.Drawing.Size(832, 661);
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid gridResult;
        private sitemap.ownControls.inherit_Infrag.InfragButton btnExceuteSql;
        public Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor txtSql;
        private Infragistics.Win.Misc.UltraLabel lblSql;
        private sitemap.ownControls.inherit_Infrag.InfragButton btnClose;
        public qs2.ui.print.contTable contTable1;
    }
}
