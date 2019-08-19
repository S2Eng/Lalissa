namespace PMDS.GUI.Medikament
{
    partial class ucMedikamenteSuche
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("UI", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Rezepteintrag");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Von");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Dosierung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Herrichten");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRezeptEintrag");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDVerordnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDMedDatenWundeKopf");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Beschreibung", -1, null, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bemerkung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Therapie");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MedizinischerTyp");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Beendigungsgrund");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("obj");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.btnClose = new QS2.Desktop.ControlManagment.BaseButton();
            this.gridSearch = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsKlientenliste1 = new PMDS.Global.db.ERSystem.dsKlientenliste();
            this.btnSearch = new QS2.Desktop.ControlManagment.BaseButton();
            this.txtSearch = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblLeistungen = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblMedikament = new QS2.Desktop.ControlManagment.BaseLabel();
            this.sqlManange1 = new PMDS.Global.db.ERSystem.sqlManange(this.components);
            this.lblFound = new QS2.Desktop.ControlManagment.BaseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gridSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
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
            this.btnClose.Location = new System.Drawing.Point(625, 538);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 30);
            this.btnClose.TabIndex = 104;
            this.btnClose.Tag = "";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gridSearch
            // 
            this.gridSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSearch.AutoWork = true;
            this.gridSearch.DataMember = "UI";
            this.gridSearch.DataSource = this.dsKlientenliste1;
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.FontData.SizeInPoints = 10F;
            this.gridSearch.DisplayLayout.Appearance = appearance2;
            this.gridSearch.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.Header.Caption = "Klienten";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            ultraGridColumn1.Width = 295;
            ultraGridColumn5.Header.VisiblePosition = 1;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn5.Width = 244;
            ultraGridColumn6.Header.VisiblePosition = 2;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn6.Width = 103;
            ultraGridColumn7.Header.VisiblePosition = 4;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn7.Width = 102;
            ultraGridColumn9.Header.VisiblePosition = 7;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn9.Width = 190;
            ultraGridColumn8.Header.VisiblePosition = 5;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn2.Header.VisiblePosition = 3;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn2.Width = 192;
            ultraGridColumn3.Header.VisiblePosition = 6;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn3.Width = 417;
            ultraGridColumn10.Header.VisiblePosition = 8;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn10.Width = 212;
            ultraGridColumn17.Header.VisiblePosition = 9;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn17.Width = 178;
            ultraGridColumn4.Header.VisiblePosition = 10;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn4.Width = 179;
            ultraGridColumn12.Header.VisiblePosition = 11;
            ultraGridColumn12.Width = 339;
            ultraGridColumn13.Header.VisiblePosition = 12;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn14.Header.VisiblePosition = 13;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn15.Header.VisiblePosition = 14;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn16.Header.VisiblePosition = 15;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn11.Header.VisiblePosition = 16;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn11.Width = 33;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn9,
            ultraGridColumn8,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn10,
            ultraGridColumn17,
            ultraGridColumn4,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn11});
            this.gridSearch.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridSearch.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridSearch.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.gridSearch.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            this.gridSearch.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;
            this.gridSearch.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridSearch.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridSearch.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.gridSearch.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance3.BorderColor = System.Drawing.Color.White;
            this.gridSearch.DisplayLayout.Override.SummaryFooterAppearance = appearance3;
            appearance4.BorderColor = System.Drawing.Color.White;
            this.gridSearch.DisplayLayout.Override.SummaryFooterCaptionAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridSearch.DisplayLayout.Override.SummaryValueAppearance = appearance5;
            this.gridSearch.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            this.gridSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridSearch.Location = new System.Drawing.Point(4, 44);
            this.gridSearch.Margin = new System.Windows.Forms.Padding(4);
            this.gridSearch.Name = "gridSearch";
            this.gridSearch.Size = new System.Drawing.Size(655, 491);
            this.gridSearch.TabIndex = 105;
            this.gridSearch.Text = "Dokumente";
            this.gridSearch.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.gridPatients_BeforeCellActivate);
            this.gridSearch.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.gridPatients_BeforeRowsDeleted);
            this.gridSearch.Click += new System.EventHandler(this.gridPatients_Click);
            this.gridSearch.DoubleClick += new System.EventHandler(this.gridPatients_DoubleClick);
            // 
            // dsKlientenliste1
            // 
            this.dsKlientenliste1.DataSetName = "dsKlientenliste";
            this.dsKlientenliste1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsKlientenliste1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnSearch
            // 
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance6.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSearch.Appearance = appearance6;
            this.btnSearch.AutoWorkLayout = false;
            this.btnSearch.IsStandardControl = false;
            this.btnSearch.Location = new System.Drawing.Point(468, 9);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(44, 31);
            this.btnSearch.TabIndex = 134;
            this.btnSearch.Tag = "";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.AutoSize = false;
            this.txtSearch.Location = new System.Drawing.Point(80, 12);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(5);
            this.txtSearch.MaxLength = 200;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(381, 25);
            this.txtSearch.TabIndex = 133;
            // 
            // lblLeistungen
            // 
            this.lblLeistungen.AutoSize = true;
            this.lblLeistungen.Location = new System.Drawing.Point(-73, 8);
            this.lblLeistungen.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblLeistungen.Name = "lblLeistungen";
            this.lblLeistungen.Size = new System.Drawing.Size(60, 14);
            this.lblLeistungen.TabIndex = 135;
            this.lblLeistungen.Text = "Leistungen";
            // 
            // lblMedikament
            // 
            this.lblMedikament.AutoSize = true;
            this.lblMedikament.Location = new System.Drawing.Point(11, 17);
            this.lblMedikament.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblMedikament.Name = "lblMedikament";
            this.lblMedikament.Size = new System.Drawing.Size(66, 14);
            this.lblMedikament.TabIndex = 136;
            this.lblMedikament.Text = "Medikament";
            // 
            // lblFound
            // 
            this.lblFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance7.BackColor = System.Drawing.Color.Transparent;
            appearance7.FontData.SizeInPoints = 7.5F;
            this.lblFound.Appearance = appearance7;
            this.lblFound.AutoSize = true;
            this.lblFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblFound.Location = new System.Drawing.Point(6, 538);
            this.lblFound.Margin = new System.Windows.Forms.Padding(4);
            this.lblFound.Name = "lblFound";
            this.lblFound.Size = new System.Drawing.Size(66, 13);
            this.lblFound.TabIndex = 137;
            this.lblFound.Text = "Gefunden: 10";
            // 
            // ucMedikamenteSuche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblFound);
            this.Controls.Add(this.lblMedikament);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblLeistungen);
            this.Controls.Add(this.gridSearch);
            this.Controls.Add(this.btnClose);
            this.Name = "ucMedikamenteSuche";
            this.Size = new System.Drawing.Size(664, 571);
            this.Load += new System.EventHandler(this.ucMedikamenteSuche_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public QS2.Desktop.ControlManagment.BaseButton btnClose;
        public QS2.Desktop.ControlManagment.BaseGrid gridSearch;
        public QS2.Desktop.ControlManagment.BaseButton btnSearch;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtSearch;
        public QS2.Desktop.ControlManagment.BaseLabel lblLeistungen;
        public QS2.Desktop.ControlManagment.BaseLabel lblMedikament;
        private Global.db.ERSystem.dsKlientenliste dsKlientenliste1;
        private Global.db.ERSystem.sqlManange sqlManange1;
        private QS2.Desktop.ControlManagment.BaseLabel lblFound;
    }
}
