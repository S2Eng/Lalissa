namespace PMDS.GUI.ELGA
{
    partial class contSearchGDA
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
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            this.txtGDAToSearch = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblGDAToSearch = new Infragistics.Win.Misc.UltraLabel();
            this.btnSearch = new QS2.Desktop.ControlManagment.BaseButton();
            this.gridProtocoll = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.btnOK = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtGDAToSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProtocoll)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGDAToSearch
            // 
            this.txtGDAToSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGDAToSearch.Location = new System.Drawing.Point(64, 21);
            this.txtGDAToSearch.Name = "txtGDAToSearch";
            this.txtGDAToSearch.Size = new System.Drawing.Size(548, 21);
            this.txtGDAToSearch.TabIndex = 4;
            // 
            // lblGDAToSearch
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.lblGDAToSearch.Appearance = appearance1;
            this.lblGDAToSearch.Location = new System.Drawing.Point(18, 22);
            this.lblGDAToSearch.Name = "lblGDAToSearch";
            this.lblGDAToSearch.Size = new System.Drawing.Size(95, 18);
            this.lblGDAToSearch.TabIndex = 5;
            this.lblGDAToSearch.Text = "Name";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSearch.Appearance = appearance2;
            this.btnSearch.AutoWorkLayout = false;
            this.btnSearch.IsStandardControl = false;
            this.btnSearch.Location = new System.Drawing.Point(64, 44);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(69, 34);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Tag = "";
            this.btnSearch.Text = "Suchen";
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // gridProtocoll
            // 
            this.gridProtocoll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.SystemColors.Window;
            appearance3.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.gridProtocoll.DisplayLayout.Appearance = appearance3;
            this.gridProtocoll.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridProtocoll.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.BorderColor = System.Drawing.SystemColors.Window;
            this.gridProtocoll.DisplayLayout.GroupByBox.Appearance = appearance4;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridProtocoll.DisplayLayout.GroupByBox.BandLabelAppearance = appearance5;
            this.gridProtocoll.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance6.BackColor2 = System.Drawing.SystemColors.Control;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridProtocoll.DisplayLayout.GroupByBox.PromptAppearance = appearance6;
            this.gridProtocoll.DisplayLayout.MaxColScrollRegions = 1;
            this.gridProtocoll.DisplayLayout.MaxRowScrollRegions = 1;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            appearance7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridProtocoll.DisplayLayout.Override.ActiveCellAppearance = appearance7;
            appearance8.BackColor = System.Drawing.SystemColors.Highlight;
            appearance8.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridProtocoll.DisplayLayout.Override.ActiveRowAppearance = appearance8;
            this.gridProtocoll.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridProtocoll.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            this.gridProtocoll.DisplayLayout.Override.CardAreaAppearance = appearance9;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridProtocoll.DisplayLayout.Override.CellAppearance = appearance10;
            this.gridProtocoll.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridProtocoll.DisplayLayout.Override.CellPadding = 0;
            appearance11.BackColor = System.Drawing.SystemColors.Control;
            appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance11.BorderColor = System.Drawing.SystemColors.Window;
            this.gridProtocoll.DisplayLayout.Override.GroupByRowAppearance = appearance11;
            appearance12.TextHAlignAsString = "Left";
            this.gridProtocoll.DisplayLayout.Override.HeaderAppearance = appearance12;
            this.gridProtocoll.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridProtocoll.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.BorderColor = System.Drawing.Color.Silver;
            this.gridProtocoll.DisplayLayout.Override.RowAppearance = appearance13;
            this.gridProtocoll.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance14.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridProtocoll.DisplayLayout.Override.TemplateAddRowAppearance = appearance14;
            this.gridProtocoll.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridProtocoll.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridProtocoll.Location = new System.Drawing.Point(64, 81);
            this.gridProtocoll.Name = "gridProtocoll";
            this.gridProtocoll.Size = new System.Drawing.Size(548, 420);
            this.gridProtocoll.TabIndex = 12;
            this.gridProtocoll.Text = "ultraGrid1";
            this.gridProtocoll.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.GridProtocoll_BeforeCellActivate);
            this.gridProtocoll.Click += new System.EventHandler(this.GridProtocoll_Click);
            this.gridProtocoll.DoubleClick += new System.EventHandler(this.GridProtocoll_DoubleClick);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance15.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance15.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance15;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.IsStandardControl = false;
            this.btnOK.Location = new System.Drawing.Point(326, 504);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(69, 29);
            this.btnOK.TabIndex = 13;
            this.btnOK.Tag = "";
            this.btnOK.Text = "OK";
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance16.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance16.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbort.Appearance = appearance16;
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(256, 504);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(69, 29);
            this.btnAbort.TabIndex = 14;
            this.btnAbort.Tag = "";
            this.btnAbort.Text = "Abbrechen";
            // 
            // contSearchGDA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gridProtocoll);
            this.Controls.Add(this.txtGDAToSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblGDAToSearch);
            this.Name = "contSearchGDA";
            this.Size = new System.Drawing.Size(623, 542);
            this.Load += new System.EventHandler(this.ContSearchGDA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtGDAToSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProtocoll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Infragistics.Win.UltraWinEditors.UltraTextEditor txtGDAToSearch;
        public Infragistics.Win.Misc.UltraLabel lblGDAToSearch;
        public QS2.Desktop.ControlManagment.BaseButton btnSearch;
        private Infragistics.Win.UltraWinGrid.UltraGrid gridProtocoll;
        public QS2.Desktop.ControlManagment.BaseButton btnOK;
        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
    }
}
