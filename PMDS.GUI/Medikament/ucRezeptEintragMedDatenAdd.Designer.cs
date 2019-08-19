namespace PMDS.GUI.Medikament
{
    partial class ucRezeptEintragMedDatenAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("UI", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Rezepteintrag", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Von");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Dosierung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Herrichten");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRezeptEintrag");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDVerordnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDMedDatenWundeKopf");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Beschreibung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bemerkung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Therapie");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MedizinischerTyp");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Beendigungsgrund");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("obj");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Select", 0);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.gridMedDatenRezepteintrag = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsKlientenliste1 = new PMDS.Global.db.ERSystem.dsKlientenliste();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnOK = new QS2.Desktop.ControlManagment.BaseButton();
            this.chkAbgesetzteAnzeigen = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            ((System.ComponentModel.ISupportInitialize)(this.gridMedDatenRezepteintrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAbgesetzteAnzeigen)).BeginInit();
            this.SuspendLayout();
            // 
            // gridMedDatenRezepteintrag
            // 
            this.gridMedDatenRezepteintrag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMedDatenRezepteintrag.AutoWork = true;
            this.gridMedDatenRezepteintrag.DataMember = "UI";
            this.gridMedDatenRezepteintrag.DataSource = this.dsKlientenliste1;
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.FontData.SizeInPoints = 10F;
            this.gridMedDatenRezepteintrag.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            ultraGridColumn1.Width = 307;
            ultraGridColumn5.Header.VisiblePosition = 2;
            ultraGridColumn5.Width = 244;
            ultraGridColumn6.Header.VisiblePosition = 3;
            ultraGridColumn6.Width = 103;
            ultraGridColumn7.Header.VisiblePosition = 5;
            ultraGridColumn7.Width = 102;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn9.Width = 190;
            ultraGridColumn8.Header.VisiblePosition = 6;
            ultraGridColumn2.Header.VisiblePosition = 4;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn2.Width = 192;
            ultraGridColumn3.Header.VisiblePosition = 7;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn3.Width = 417;
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn10.Width = 212;
            ultraGridColumn17.Header.VisiblePosition = 10;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn18.Header.VisiblePosition = 11;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn12.Header.VisiblePosition = 12;
            ultraGridColumn13.Header.VisiblePosition = 13;
            ultraGridColumn14.Header.VisiblePosition = 14;
            ultraGridColumn15.Header.VisiblePosition = 15;
            ultraGridColumn16.Header.VisiblePosition = 16;
            ultraGridColumn19.Header.VisiblePosition = 17;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn4.DataType = typeof(bool);
            ultraGridColumn4.Header.Caption = "Auswahl";
            ultraGridColumn4.Header.VisiblePosition = 0;
            ultraGridColumn4.Width = 63;
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
            ultraGridColumn18,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn19,
            ultraGridColumn4});
            this.gridMedDatenRezepteintrag.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridMedDatenRezepteintrag.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridMedDatenRezepteintrag.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.gridMedDatenRezepteintrag.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            this.gridMedDatenRezepteintrag.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;
            this.gridMedDatenRezepteintrag.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridMedDatenRezepteintrag.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridMedDatenRezepteintrag.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.gridMedDatenRezepteintrag.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance2.BorderColor = System.Drawing.Color.White;
            this.gridMedDatenRezepteintrag.DisplayLayout.Override.SummaryFooterAppearance = appearance2;
            appearance3.BorderColor = System.Drawing.Color.White;
            this.gridMedDatenRezepteintrag.DisplayLayout.Override.SummaryFooterCaptionAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridMedDatenRezepteintrag.DisplayLayout.Override.SummaryValueAppearance = appearance4;
            this.gridMedDatenRezepteintrag.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            this.gridMedDatenRezepteintrag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridMedDatenRezepteintrag.Location = new System.Drawing.Point(6, 29);
            this.gridMedDatenRezepteintrag.Margin = new System.Windows.Forms.Padding(4);
            this.gridMedDatenRezepteintrag.Name = "gridMedDatenRezepteintrag";
            this.gridMedDatenRezepteintrag.Size = new System.Drawing.Size(1369, 461);
            this.gridMedDatenRezepteintrag.TabIndex = 104;
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
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbort.Appearance = appearance5;
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(1191, 494);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(81, 30);
            this.btnAbort.TabIndex = 103;
            this.btnAbort.Tag = "";
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance6.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance6;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.IsStandardControl = false;
            this.btnOK.Location = new System.Drawing.Point(1272, 494);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(91, 30);
            this.btnOK.TabIndex = 102;
            this.btnOK.Tag = "";
            this.btnOK.Text = "Speichern";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkAbgesetzteAnzeigen
            // 
            this.chkAbgesetzteAnzeigen.Location = new System.Drawing.Point(12, 6);
            this.chkAbgesetzteAnzeigen.Name = "chkAbgesetzteAnzeigen";
            this.chkAbgesetzteAnzeigen.Size = new System.Drawing.Size(212, 17);
            this.chkAbgesetzteAnzeigen.TabIndex = 105;
            this.chkAbgesetzteAnzeigen.Text = "abgesetzte Medikamente anzeigen";
            this.chkAbgesetzteAnzeigen.CheckedChanged += new System.EventHandler(this.chkAbgesetzteAnzeigen_CheckedChanged);
            // 
            // ucRezeptEintragMedDatenAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkAbgesetzteAnzeigen);
            this.Controls.Add(this.gridMedDatenRezepteintrag);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnOK);
            this.Name = "ucRezeptEintragMedDatenAdd";
            this.Size = new System.Drawing.Size(1380, 527);
            this.Load += new System.EventHandler(this.frmRezeptEintragMedDatenAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridMedDatenRezepteintrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAbgesetzteAnzeigen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public QS2.Desktop.ControlManagment.BaseGrid gridMedDatenRezepteintrag;
        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
        public QS2.Desktop.ControlManagment.BaseButton btnOK;
        private Global.db.ERSystem.dsKlientenliste dsKlientenliste1;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkAbgesetzteAnzeigen;
    }
}