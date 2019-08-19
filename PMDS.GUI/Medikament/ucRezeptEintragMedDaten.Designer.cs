namespace PMDS.GUI.Medikament
{
    partial class ucRezeptEintragMedDaten
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("UI", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Rezepteintrag");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Von");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Dosierung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Herrichten");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRezeptEintrag");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDVerordnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDMedDatenWundeKopf");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Beschreibung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bemerkung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Therapie");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MedizinischerTyp");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Beendigungsgrund");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("obj");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.btnSave = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.gridMedDatenRezepteintrag = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsKlientenliste1 = new PMDS.Global.db.ERSystem.dsKlientenliste();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.btnAddVerknüpfung = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDel = new QS2.Desktop.ControlManagment.BaseButton();
            this.chkAbgesetzteAnzeigen = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.btnOK = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAddMedikament = new QS2.Desktop.ControlManagment.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridMedDatenRezepteintrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAbgesetzteAnzeigen)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance1;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.IsStandardControl = false;
            this.btnSave.Location = new System.Drawing.Point(478, 369);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 29);
            this.btnSave.TabIndex = 1;
            this.btnSave.Tag = "";
            this.btnSave.Text = "Speichern";
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbort.Appearance = appearance2;
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(388, 369);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(90, 29);
            this.btnAbort.TabIndex = 2;
            this.btnAbort.Tag = "";
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.Visible = false;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // gridMedDatenRezepteintrag
            // 
            this.gridMedDatenRezepteintrag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMedDatenRezepteintrag.AutoWork = true;
            this.gridMedDatenRezepteintrag.DataMember = "UI";
            this.gridMedDatenRezepteintrag.DataSource = this.dsKlientenliste1;
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.FontData.SizeInPoints = 10F;
            this.gridMedDatenRezepteintrag.DisplayLayout.Appearance = appearance3;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            ultraGridColumn1.Width = 507;
            ultraGridColumn4.Header.VisiblePosition = 1;
            ultraGridColumn4.Width = 280;
            ultraGridColumn5.Header.VisiblePosition = 3;
            ultraGridColumn5.Width = 103;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Width = 97;
            ultraGridColumn8.Header.Caption = "Signatur";
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.Width = 220;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn2.Width = 243;
            ultraGridColumn3.Header.VisiblePosition = 4;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn3.Width = 417;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn9.Width = 152;
            ultraGridColumn17.Header.VisiblePosition = 9;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn10.Header.VisiblePosition = 10;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.Header.VisiblePosition = 11;
            ultraGridColumn12.Header.VisiblePosition = 12;
            ultraGridColumn13.Header.VisiblePosition = 13;
            ultraGridColumn14.Header.VisiblePosition = 14;
            ultraGridColumn15.Header.VisiblePosition = 15;
            ultraGridColumn16.Header.VisiblePosition = 16;
            ultraGridColumn16.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn8,
            ultraGridColumn7,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn9,
            ultraGridColumn17,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16});
            this.gridMedDatenRezepteintrag.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridMedDatenRezepteintrag.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridMedDatenRezepteintrag.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.gridMedDatenRezepteintrag.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            this.gridMedDatenRezepteintrag.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;
            this.gridMedDatenRezepteintrag.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.gridMedDatenRezepteintrag.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridMedDatenRezepteintrag.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.gridMedDatenRezepteintrag.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance4.BorderColor = System.Drawing.Color.White;
            this.gridMedDatenRezepteintrag.DisplayLayout.Override.SummaryFooterAppearance = appearance4;
            appearance5.BorderColor = System.Drawing.Color.White;
            this.gridMedDatenRezepteintrag.DisplayLayout.Override.SummaryFooterCaptionAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridMedDatenRezepteintrag.DisplayLayout.Override.SummaryValueAppearance = appearance6;
            this.gridMedDatenRezepteintrag.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            this.gridMedDatenRezepteintrag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridMedDatenRezepteintrag.Location = new System.Drawing.Point(5, 37);
            this.gridMedDatenRezepteintrag.Margin = new System.Windows.Forms.Padding(4);
            this.gridMedDatenRezepteintrag.Name = "gridMedDatenRezepteintrag";
            this.gridMedDatenRezepteintrag.Size = new System.Drawing.Size(1008, 330);
            this.gridMedDatenRezepteintrag.TabIndex = 101;
            this.gridMedDatenRezepteintrag.Text = "Dokumente";
            this.gridMedDatenRezepteintrag.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.gridMedDatenRezepteintrag_BeforeCellActivate);
            this.gridMedDatenRezepteintrag.Click += new System.EventHandler(this.gridMedDatenRezepteintrag_Click);
            this.gridMedDatenRezepteintrag.DoubleClick += new System.EventHandler(this.gridMedDatenRezepteintrag_DoubleClick);
            // 
            // dsKlientenliste1
            // 
            this.dsKlientenliste1.DataSetName = "dsKlientenliste";
            this.dsKlientenliste1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsKlientenliste1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 0;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // btnAddVerknüpfung
            // 
            this.btnAddVerknüpfung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance10.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance10.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAddVerknüpfung.Appearance = appearance10;
            this.btnAddVerknüpfung.AutoWorkLayout = false;
            this.btnAddVerknüpfung.IsStandardControl = false;
            this.btnAddVerknüpfung.Location = new System.Drawing.Point(909, 4);
            this.btnAddVerknüpfung.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddVerknüpfung.Name = "btnAddVerknüpfung";
            this.btnAddVerknüpfung.Size = new System.Drawing.Size(32, 30);
            this.btnAddVerknüpfung.TabIndex = 102;
            this.btnAddVerknüpfung.Tag = "";
            this.btnAddVerknüpfung.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance9.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance9.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance9;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.IsStandardControl = false;
            this.btnDel.Location = new System.Drawing.Point(973, 4);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(32, 30);
            this.btnDel.TabIndex = 103;
            this.btnDel.Tag = "";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // chkAbgesetzteAnzeigen
            // 
            this.chkAbgesetzteAnzeigen.Location = new System.Drawing.Point(9, 12);
            this.chkAbgesetzteAnzeigen.Name = "chkAbgesetzteAnzeigen";
            this.chkAbgesetzteAnzeigen.Size = new System.Drawing.Size(212, 17);
            this.chkAbgesetzteAnzeigen.TabIndex = 106;
            this.chkAbgesetzteAnzeigen.Text = "abgesetzte Medikamente anzeigen";
            this.chkAbgesetzteAnzeigen.CheckedChanged += new System.EventHandler(this.chkAbgesetzteAnzeigen_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance8.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance8.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance8;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.IsStandardControl = false;
            this.btnOK.Location = new System.Drawing.Point(970, 369);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(35, 29);
            this.btnOK.TabIndex = 107;
            this.btnOK.Tag = "";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnAddMedikament
            // 
            this.btnAddMedikament.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance7.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAddMedikament.Appearance = appearance7;
            this.btnAddMedikament.AutoWorkLayout = false;
            this.btnAddMedikament.IsStandardControl = false;
            this.btnAddMedikament.Location = new System.Drawing.Point(941, 4);
            this.btnAddMedikament.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddMedikament.Name = "btnAddMedikament";
            this.btnAddMedikament.Size = new System.Drawing.Size(32, 30);
            this.btnAddMedikament.TabIndex = 108;
            this.btnAddMedikament.Tag = "";
            this.btnAddMedikament.Click += new System.EventHandler(this.btnAddMedikament_Click);
            // 
            // ucRezeptEintragMedDaten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddMedikament);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkAbgesetzteAnzeigen);
            this.Controls.Add(this.gridMedDatenRezepteintrag);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAddVerknüpfung);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnSave);
            this.Name = "ucRezeptEintragMedDaten";
            this.Size = new System.Drawing.Size(1018, 401);
            this.Load += new System.EventHandler(this.ucRezeptEintragMedDaten_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridMedDatenRezepteintrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAbgesetzteAnzeigen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public QS2.Desktop.ControlManagment.BaseButton btnSave;
        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
        public QS2.Desktop.ControlManagment.BaseGrid gridMedDatenRezepteintrag;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        public QS2.Desktop.ControlManagment.BaseButton btnDel;
        public QS2.Desktop.ControlManagment.BaseButton btnAddVerknüpfung;
        private Global.db.ERSystem.dsKlientenliste dsKlientenliste1;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkAbgesetzteAnzeigen;
        public QS2.Desktop.ControlManagment.BaseButton btnOK;
        public QS2.Desktop.ControlManagment.BaseButton btnAddMedikament;
    }
}
