namespace PMDS.GUI.ELGA
{
    partial class contELGASearchGDA
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
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ELGASearchGDAs", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NachnameFirma", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Vorname", -1, null, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Strasse");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PLZ", -1, null, 2, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Ort", -1, null, 3, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Land", -1, null, 4, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Tel");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDElga");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
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
            this.txtNachname = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblNachname = new Infragistics.Win.Misc.UltraLabel();
            this.btnSearch = new Infragistics.Win.Misc.UltraButton();
            this.grpSearch = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtStrasse = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblStrasse = new Infragistics.Win.Misc.UltraLabel();
            this.txtStadt = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblStadt = new Infragistics.Win.Misc.UltraLabel();
            this.txtPLZ = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblPLZ = new Infragistics.Win.Misc.UltraLabel();
            this.txtVorname = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblVorname = new Infragistics.Win.Misc.UltraLabel();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnSave = new QS2.Desktop.ControlManagment.BaseButton();
            this.dsManage1 = new PMDS.Global.db.ERSystem.dsManage();
            this.sqlManange1 = new PMDS.Global.db.ERSystem.sqlManange(this.components);
            this.gridFound = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNachname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).BeginInit();
            this.grpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStadt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPLZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsManage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFound)).BeginInit();
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
            // txtNachname
            // 
            appearance23.BackColor = System.Drawing.Color.White;
            this.txtNachname.Appearance = appearance23;
            this.txtNachname.BackColor = System.Drawing.Color.White;
            this.txtNachname.Location = new System.Drawing.Point(111, 23);
            this.txtNachname.Name = "txtNachname";
            this.txtNachname.ReadOnly = true;
            this.txtNachname.Size = new System.Drawing.Size(193, 21);
            this.txtNachname.TabIndex = 0;
            // 
            // lblNachname
            // 
            appearance24.TextVAlignAsString = "Middle";
            this.lblNachname.Appearance = appearance24;
            this.lblNachname.Location = new System.Drawing.Point(13, 25);
            this.lblNachname.Name = "lblNachname";
            this.lblNachname.Size = new System.Drawing.Size(173, 16);
            this.lblNachname.TabIndex = 1;
            this.lblNachname.Text = "Nachname/Firma";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(617, 64);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(73, 32);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Suche";
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // grpSearch
            // 
            this.grpSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSearch.Controls.Add(this.txtStrasse);
            this.grpSearch.Controls.Add(this.lblStrasse);
            this.grpSearch.Controls.Add(this.txtStadt);
            this.grpSearch.Controls.Add(this.lblStadt);
            this.grpSearch.Controls.Add(this.txtPLZ);
            this.grpSearch.Controls.Add(this.lblPLZ);
            this.grpSearch.Controls.Add(this.txtVorname);
            this.grpSearch.Controls.Add(this.lblVorname);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.txtNachname);
            this.grpSearch.Controls.Add(this.lblNachname);
            this.grpSearch.Location = new System.Drawing.Point(10, 6);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(700, 105);
            this.grpSearch.TabIndex = 3;
            this.grpSearch.Text = "Suche";
            // 
            // txtStrasse
            // 
            appearance15.BackColor = System.Drawing.Color.White;
            this.txtStrasse.Appearance = appearance15;
            this.txtStrasse.BackColor = System.Drawing.Color.White;
            this.txtStrasse.Location = new System.Drawing.Point(379, 70);
            this.txtStrasse.Name = "txtStrasse";
            this.txtStrasse.ReadOnly = true;
            this.txtStrasse.Size = new System.Drawing.Size(225, 21);
            this.txtStrasse.TabIndex = 4;
            // 
            // lblStrasse
            // 
            appearance16.TextVAlignAsString = "Middle";
            this.lblStrasse.Appearance = appearance16;
            this.lblStrasse.Location = new System.Drawing.Point(324, 72);
            this.lblStrasse.Name = "lblStrasse";
            this.lblStrasse.Size = new System.Drawing.Size(79, 16);
            this.lblStrasse.TabIndex = 18;
            this.lblStrasse.Text = "Strasse";
            // 
            // txtStadt
            // 
            appearance17.BackColor = System.Drawing.Color.White;
            this.txtStadt.Appearance = appearance17;
            this.txtStadt.BackColor = System.Drawing.Color.White;
            this.txtStadt.Location = new System.Drawing.Point(379, 47);
            this.txtStadt.Name = "txtStadt";
            this.txtStadt.ReadOnly = true;
            this.txtStadt.Size = new System.Drawing.Size(125, 21);
            this.txtStadt.TabIndex = 3;
            // 
            // lblStadt
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.lblStadt.Appearance = appearance18;
            this.lblStadt.Location = new System.Drawing.Point(324, 49);
            this.lblStadt.Name = "lblStadt";
            this.lblStadt.Size = new System.Drawing.Size(79, 16);
            this.lblStadt.TabIndex = 16;
            this.lblStadt.Text = "Stadt";
            // 
            // txtPLZ
            // 
            appearance19.BackColor = System.Drawing.Color.White;
            this.txtPLZ.Appearance = appearance19;
            this.txtPLZ.BackColor = System.Drawing.Color.White;
            this.txtPLZ.Location = new System.Drawing.Point(379, 23);
            this.txtPLZ.Name = "txtPLZ";
            this.txtPLZ.ReadOnly = true;
            this.txtPLZ.Size = new System.Drawing.Size(75, 21);
            this.txtPLZ.TabIndex = 2;
            // 
            // lblPLZ
            // 
            appearance20.TextVAlignAsString = "Middle";
            this.lblPLZ.Appearance = appearance20;
            this.lblPLZ.Location = new System.Drawing.Point(324, 25);
            this.lblPLZ.Name = "lblPLZ";
            this.lblPLZ.Size = new System.Drawing.Size(79, 16);
            this.lblPLZ.TabIndex = 14;
            this.lblPLZ.Text = "PLZ";
            // 
            // txtVorname
            // 
            appearance21.BackColor = System.Drawing.Color.White;
            this.txtVorname.Appearance = appearance21;
            this.txtVorname.BackColor = System.Drawing.Color.White;
            this.txtVorname.Location = new System.Drawing.Point(111, 47);
            this.txtVorname.Name = "txtVorname";
            this.txtVorname.ReadOnly = true;
            this.txtVorname.Size = new System.Drawing.Size(193, 21);
            this.txtVorname.TabIndex = 1;
            // 
            // lblVorname
            // 
            appearance22.TextVAlignAsString = "Middle";
            this.lblVorname.Appearance = appearance22;
            this.lblVorname.Location = new System.Drawing.Point(13, 49);
            this.lblVorname.Name = "lblVorname";
            this.lblVorname.Size = new System.Drawing.Size(173, 16);
            this.lblVorname.TabIndex = 12;
            this.lblVorname.Text = "Vorname";
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance13.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance13.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbort.Appearance = appearance13;
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(265, 429);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(82, 30);
            this.btnAbort.TabIndex = 126;
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
            this.btnSave.Location = new System.Drawing.Point(347, 429);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 30);
            this.btnSave.TabIndex = 127;
            this.btnSave.Tag = "";
            this.btnSave.Text = "Speichern";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // dsManage1
            // 
            this.dsManage1.DataSetName = "dsManage";
            this.dsManage1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridFound
            // 
            this.gridFound.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFound.DataMember = "ELGASearchGDAs";
            this.gridFound.DataSource = this.dsManage1;
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.gridFound.DisplayLayout.Appearance = appearance1;
            this.gridFound.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn4.Header.Caption = "Nachname/Firma";
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 0;
            ultraGridColumn4.Width = 159;
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 1;
            ultraGridColumn5.Width = 116;
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Width = 203;
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 2;
            ultraGridColumn7.Width = 77;
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 3;
            ultraGridColumn8.Width = 175;
            ultraGridColumn9.Header.Editor = null;
            ultraGridColumn9.Header.VisiblePosition = 4;
            ultraGridColumn10.Header.Editor = null;
            ultraGridColumn10.Header.VisiblePosition = 6;
            ultraGridColumn11.Header.Editor = null;
            ultraGridColumn11.Header.VisiblePosition = 7;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.Header.Editor = null;
            ultraGridColumn12.Header.VisiblePosition = 8;
            ultraGridColumn12.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12});
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
            this.gridFound.Location = new System.Drawing.Point(3, 117);
            this.gridFound.Name = "gridFound";
            this.gridFound.Size = new System.Drawing.Size(700, 310);
            this.gridFound.TabIndex = 128;
            this.gridFound.Text = "ELGA GDA\'s";
            this.gridFound.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.GridFound_BeforeCellActivate);
            this.gridFound.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.GridFound_BeforeRowsDeleted);
            this.gridFound.Click += new System.EventHandler(this.GridFound_Click);
            this.gridFound.DoubleClick += new System.EventHandler(this.GridFound_DoubleClick);
            // 
            // contELGASearchGDA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gridFound);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpSearch);
            this.Name = "contELGASearchGDA";
            this.Size = new System.Drawing.Size(718, 464);
            this.Load += new System.EventHandler(this.ContELGASearchGDA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNachname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStadt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPLZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsManage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFound)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Infragistics.Win.Misc.UltraLabel lblNachname;
        private Infragistics.Win.Misc.UltraGroupBox grpSearch;
        private Infragistics.Win.Misc.UltraButton btnSearch;
        private Infragistics.Win.Misc.UltraLabel lblStadt;
        private Infragistics.Win.Misc.UltraLabel lblPLZ;
        private Infragistics.Win.Misc.UltraLabel lblVorname;
        private Infragistics.Win.Misc.UltraLabel lblStrasse;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor txtNachname;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor txtStadt;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor txtPLZ;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor txtVorname;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor txtStrasse;
        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
        public QS2.Desktop.ControlManagment.BaseButton btnSave;
        private Global.db.ERSystem.dsManage dsManage1;
        private Global.db.ERSystem.sqlManange sqlManange1;
        private Infragistics.Win.UltraWinGrid.UltraGrid gridFound;
    }
}
