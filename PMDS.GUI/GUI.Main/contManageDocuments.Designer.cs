namespace PMDS.GUI.GUI.Main
{
    partial class contManageDocuments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(contManageDocuments));
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Dokumente2", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DokumentenName", -1, 1193550704);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Abteilungen");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Benutzergruppen");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ErstelltAm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ErstelltVon");
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(1193550704);
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.btnClose = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnSave = new QS2.Desktop.ControlManagment.BaseButton();
            this.lblWichtigFürCC = new QS2.Desktop.ControlManagment.BaseLabel();
            this.baseLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lvAbteilungen = new Infragistics.Win.UltraWinListView.UltraListView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.auswahlGruppeComboMulti1 = new PMDS.GUI.BaseControls.AuswahlGruppeComboMulti();
            this.gridDocuments = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsKlientenliste1 = new PMDS.Global.db.ERSystem.dsKlientenliste();
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.btnDelete = new PMDS.GUI.ucButton(this.components);
            this.sqlManange1 = new PMDS.Global.db.ERSystem.sqlManange(this.components);
            this.dsDokumente2Abteilungen1 = new PMDS.Global.db.ERSystem.dsDokumente2Abteilungen();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.neuLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoeschen = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnCopy = new QS2.Desktop.ControlManagment.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.lvAbteilungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDokumente2Abteilungen1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnClose.Appearance = appearance1;
            this.btnClose.AutoWorkLayout = false;
            this.btnClose.IsStandardControl = false;
            this.btnClose.Location = new System.Drawing.Point(1054, 478);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(51, 36);
            this.btnClose.TabIndex = 110;
            this.btnClose.Tag = "";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance2;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.IsStandardControl = false;
            this.btnSave.Location = new System.Drawing.Point(933, 478);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 36);
            this.btnSave.TabIndex = 107;
            this.btnSave.Tag = "";
            this.btnSave.Text = "Speichern";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblWichtigFürCC
            // 
            this.lblWichtigFürCC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWichtigFürCC.AutoSize = true;
            this.lblWichtigFürCC.Location = new System.Drawing.Point(218, 315);
            this.lblWichtigFürCC.Margin = new System.Windows.Forms.Padding(5);
            this.lblWichtigFürCC.Name = "lblWichtigFürCC";
            this.lblWichtigFürCC.Size = new System.Drawing.Size(93, 17);
            this.lblWichtigFürCC.TabIndex = 118;
            this.lblWichtigFürCC.Text = "Berufsgruppen";
            // 
            // baseLabel1
            // 
            this.baseLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Location = new System.Drawing.Point(8, 315);
            this.baseLabel1.Margin = new System.Windows.Forms.Padding(5);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(76, 17);
            this.baseLabel1.TabIndex = 119;
            this.baseLabel1.Text = "Abteilungen";
            // 
            // lvAbteilungen
            // 
            this.lvAbteilungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance3.FontData.SizeInPoints = 10F;
            this.lvAbteilungen.Appearance = appearance3;
            this.lvAbteilungen.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lvAbteilungen.GroupHeadersVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance4.BackColor = System.Drawing.SystemColors.Highlight;
            this.lvAbteilungen.ItemSettings.ActiveAppearance = appearance4;
            appearance5.Image = ((object)(resources.GetObject("appearance5.Image")));
            this.lvAbteilungen.ItemSettings.Appearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            this.lvAbteilungen.ItemSettings.SelectedAppearance = appearance6;
            this.lvAbteilungen.ItemSettings.SelectionType = Infragistics.Win.UltraWinListView.SelectionType.Single;
            this.lvAbteilungen.Location = new System.Drawing.Point(5, 341);
            this.lvAbteilungen.Margin = new System.Windows.Forms.Padding(4);
            this.lvAbteilungen.Name = "lvAbteilungen";
            this.lvAbteilungen.Size = new System.Drawing.Size(204, 174);
            this.lvAbteilungen.TabIndex = 120;
            this.lvAbteilungen.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.Details;
            this.lvAbteilungen.ViewSettingsList.CheckBoxStyle = Infragistics.Win.UltraWinListView.CheckBoxStyle.CheckBox;
            this.lvAbteilungen.ViewSettingsList.ImageSize = new System.Drawing.Size(0, 0);
            this.lvAbteilungen.ItemActivated += new Infragistics.Win.UltraWinListView.ItemActivatedEventHandler(this.lvAbteilungen_ItemActivated);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // auswahlGruppeComboMulti1
            // 
            this.auswahlGruppeComboMulti1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.auswahlGruppeComboMulti1.BackColor = System.Drawing.Color.Transparent;
            this.auswahlGruppeComboMulti1.Location = new System.Drawing.Point(218, 342);
            this.auswahlGruppeComboMulti1.Margin = new System.Windows.Forms.Padding(5);
            this.auswahlGruppeComboMulti1.Name = "auswahlGruppeComboMulti1";
            this.auswahlGruppeComboMulti1.Size = new System.Drawing.Size(887, 34);
            this.auswahlGruppeComboMulti1.TabIndex = 117;
            this.auswahlGruppeComboMulti1.TypeMulti = PMDS.GUI.BaseControls.AuswahlGruppeComboMulti.eTypeMulti.Berufsgruppe;
            // 
            // gridDocuments
            // 
            this.gridDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDocuments.AutoWork = true;
            this.gridDocuments.DataMember = "Dokumente2";
            this.gridDocuments.DataSource = this.dsKlientenliste1;
            appearance9.BackColor = System.Drawing.Color.White;
            this.gridDocuments.DisplayLayout.Appearance = appearance9;
            this.gridDocuments.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.Header.VisiblePosition = 6;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.VisiblePosition = 0;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(266, 0);
            ultraGridColumn3.Header.Caption = "Dokumenten-Name";
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(336, 0);
            ultraGridColumn3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            ultraGridColumn4.Header.VisiblePosition = 2;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.Header.VisiblePosition = 3;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.Header.Caption = "Erstellt am";
            ultraGridColumn6.Header.VisiblePosition = 4;
            ultraGridColumn7.Header.Caption = "Erstellt von";
            ultraGridColumn7.Header.VisiblePosition = 5;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand1.SummaryFooterCaption = "";
            this.gridDocuments.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridDocuments.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridDocuments.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.gridDocuments.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            this.gridDocuments.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;
            this.gridDocuments.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridDocuments.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridDocuments.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.gridDocuments.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance10.BorderColor = System.Drawing.Color.White;
            this.gridDocuments.DisplayLayout.Override.SummaryFooterAppearance = appearance10;
            appearance11.BorderColor = System.Drawing.Color.White;
            this.gridDocuments.DisplayLayout.Override.SummaryFooterCaptionAppearance = appearance11;
            appearance12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridDocuments.DisplayLayout.Override.SummaryValueAppearance = appearance12;
            this.gridDocuments.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            valueList1.Key = "Documents";
            this.gridDocuments.DisplayLayout.ValueLists.AddRange(new Infragistics.Win.ValueList[] {
            valueList1});
            this.gridDocuments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridDocuments.Location = new System.Drawing.Point(8, 34);
            this.gridDocuments.Margin = new System.Windows.Forms.Padding(4);
            this.gridDocuments.Name = "gridDocuments";
            this.gridDocuments.Size = new System.Drawing.Size(1097, 270);
            this.gridDocuments.TabIndex = 111;
            this.gridDocuments.Text = "Dokumente";
            this.gridDocuments.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.gridDocuments_BeforeCellActivate);
            this.gridDocuments.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.gridDocuments_BeforeRowsDeleted);
            this.gridDocuments.Click += new System.EventHandler(this.gridDocuments_Click);
            this.gridDocuments.DoubleClick += new System.EventHandler(this.gridDocuments_DoubleClick);
            // 
            // dsKlientenliste1
            // 
            this.dsKlientenliste1.DataSetName = "dsKlientenliste";
            this.dsKlientenliste1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance13.BackColor = System.Drawing.Color.Transparent;
            appearance13.Image = ((object)(resources.GetObject("appearance13.Image")));
            appearance13.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance13.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance13.TextVAlignAsString = "Middle";
            this.btnAdd.Appearance = appearance13;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(1039, 2);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(33, 27);
            this.btnAdd.TabIndex = 109;
            this.btnAdd.TabStop = false;
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance14.BackColor = System.Drawing.Color.Transparent;
            appearance14.Image = ((object)(resources.GetObject("appearance14.Image")));
            appearance14.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance14.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance14.TextVAlignAsString = "Middle";
            this.btnDelete.Appearance = appearance14;
            this.btnDelete.AutoWorkLayout = false;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelete.DoOnClick = true;
            this.btnDelete.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDelete.IsStandardControl = true;
            this.btnDelete.Location = new System.Drawing.Point(1072, 2);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(33, 27);
            this.btnDelete.TabIndex = 108;
            this.btnDelete.TabStop = false;
            this.btnDelete.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDelete.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dsDokumente2Abteilungen1
            // 
            this.dsDokumente2Abteilungen1.DataSetName = "dsDokumente2Abteilungen";
            this.dsDokumente2Abteilungen1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuLadenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(129, 26);
            // 
            // neuLadenToolStripMenuItem
            // 
            this.neuLadenToolStripMenuItem.Name = "neuLadenToolStripMenuItem";
            this.neuLadenToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.neuLadenToolStripMenuItem.Text = "Neu laden";
            this.neuLadenToolStripMenuItem.Click += new System.EventHandler(this.neuLadenToolStripMenuItem_Click);
            // 
            // btnLoeschen
            // 
            this.btnLoeschen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance8.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance8.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnLoeschen.Appearance = appearance8;
            this.btnLoeschen.AutoWorkLayout = false;
            this.btnLoeschen.IsStandardControl = false;
            this.btnLoeschen.Location = new System.Drawing.Point(218, 478);
            this.btnLoeschen.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoeschen.Name = "btnLoeschen";
            this.btnLoeschen.Size = new System.Drawing.Size(174, 36);
            this.btnLoeschen.TabIndex = 121;
            this.btnLoeschen.Tag = "";
            this.btnLoeschen.Text = "Alle Zuordnungen löschen";
            this.btnLoeschen.Click += new System.EventHandler(this.btnLoeschen_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance7.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCopy.Appearance = appearance7;
            this.btnCopy.AutoWorkLayout = false;
            this.btnCopy.IsStandardControl = false;
            this.btnCopy.Location = new System.Drawing.Point(400, 478);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(4);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(258, 36);
            this.btnCopy.TabIndex = 122;
            this.btnCopy.Tag = "";
            this.btnCopy.Text = "Zuordnung für alle Abteilungen kopieren";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // contManageDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnLoeschen);
            this.Controls.Add(this.lvAbteilungen);
            this.Controls.Add(this.auswahlGruppeComboMulti1);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.lblWichtigFürCC);
            this.Controls.Add(this.gridDocuments);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "contManageDocuments";
            this.Size = new System.Drawing.Size(1117, 518);
            this.Load += new System.EventHandler(this.contManageDocuments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lvAbteilungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDokumente2Abteilungen1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public QS2.Desktop.ControlManagment.BaseGrid gridDocuments;
        public QS2.Desktop.ControlManagment.BaseButton btnClose;
        public ucButton btnAdd;
        public ucButton btnDelete;
        public QS2.Desktop.ControlManagment.BaseButton btnSave;
        private Global.db.ERSystem.dsKlientenliste dsKlientenliste1;
        private Global.db.ERSystem.sqlManange sqlManange1;
        public BaseControls.AuswahlGruppeComboMulti auswahlGruppeComboMulti1;
        public QS2.Desktop.ControlManagment.BaseLabel lblWichtigFürCC;
        public QS2.Desktop.ControlManagment.BaseLabel baseLabel1;
        protected Infragistics.Win.UltraWinListView.UltraListView lvAbteilungen;
        protected System.Windows.Forms.ErrorProvider errorProvider1;
        private Global.db.ERSystem.dsDokumente2Abteilungen dsDokumente2Abteilungen1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem neuLadenToolStripMenuItem;
        public QS2.Desktop.ControlManagment.BaseButton btnLoeschen;
        public QS2.Desktop.ControlManagment.BaseButton btnCopy;
    }
}
