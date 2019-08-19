namespace PMDS.GUI.Calc.Calc.UI.Other
{
    partial class contListePatientenEntlassen
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PatientenEntlassen", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAufenthalt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPatient");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Patient", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Wohin");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Entlassungszeitpunkt", -1, null, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(955900011);
            Infragistics.Win.ValueList valueList2 = new Infragistics.Win.ValueList(955900292);
            Infragistics.Win.ValueList valueList3 = new Infragistics.Win.ValueList(957624478);
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueList valueList4 = new Infragistics.Win.ValueList(959010437);
            Infragistics.Win.ValueList valueList5 = new Infragistics.Win.ValueList(101230219);
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem15 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueList valueList6 = new Infragistics.Win.ValueList(101231296);
            this.grpSuche = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnSearch = new QS2.Desktop.ControlManagment.BaseButton();
            this.lblResetSearch = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblBis = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dteBis = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblVon = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dteVon = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblFound = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnExportExcel = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnClose = new QS2.Desktop.ControlManagment.BaseButton();
            this.gridPatientenEntlassen = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsKlientenliste1 = new PMDS.Global.db.ERSystem.dsKlientenliste();
            this.sqlManange1 = new PMDS.Global.db.ERSystem.sqlManange(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grpSuche)).BeginInit();
            this.grpSuche.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPatientenEntlassen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSuche
            // 
            this.grpSuche.Controls.Add(this.btnSearch);
            this.grpSuche.Controls.Add(this.lblResetSearch);
            this.grpSuche.Controls.Add(this.lblBis);
            this.grpSuche.Controls.Add(this.dteBis);
            this.grpSuche.Controls.Add(this.lblVon);
            this.grpSuche.Controls.Add(this.dteVon);
            this.grpSuche.Location = new System.Drawing.Point(7, 7);
            this.grpSuche.Margin = new System.Windows.Forms.Padding(4);
            this.grpSuche.Name = "grpSuche";
            this.grpSuche.Size = new System.Drawing.Size(407, 61);
            this.grpSuche.TabIndex = 202;
            this.grpSuche.Text = "Suche";
            // 
            // btnSearch
            // 
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSearch.Appearance = appearance1;
            this.btnSearch.AutoWorkLayout = false;
            this.btnSearch.IsStandardControl = false;
            this.btnSearch.Location = new System.Drawing.Point(341, 17);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(56, 37);
            this.btnSearch.TabIndex = 100;
            this.btnSearch.Tag = "";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblResetSearch
            // 
            appearance2.FontData.SizeInPoints = 7.5F;
            appearance2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblResetSearch.Appearance = appearance2;
            this.lblResetSearch.AutoSize = true;
            this.lblResetSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblResetSearch.Location = new System.Drawing.Point(915, 96);
            this.lblResetSearch.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblResetSearch.Name = "lblResetSearch";
            this.lblResetSearch.Size = new System.Drawing.Size(66, 13);
            this.lblResetSearch.TabIndex = 2153;
            this.lblResetSearch.Text = "Zurücksetzen";
            // 
            // lblBis
            // 
            this.lblBis.AutoSize = true;
            this.lblBis.Location = new System.Drawing.Point(197, 28);
            this.lblBis.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(19, 14);
            this.lblBis.TabIndex = 214;
            this.lblBis.Text = "bis";
            // 
            // dteBis
            // 
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BackColor2 = System.Drawing.Color.White;
            appearance3.BackColorDisabled = System.Drawing.Color.White;
            appearance3.BackColorDisabled2 = System.Drawing.Color.White;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            this.dteBis.Appearance = appearance3;
            this.dteBis.BackColor = System.Drawing.Color.White;
            this.dteBis.FormatString = "";
            this.dteBis.Location = new System.Drawing.Point(226, 24);
            this.dteBis.Margin = new System.Windows.Forms.Padding(5);
            this.dteBis.MaskInput = "dd.mm.yyyy";
            this.dteBis.Name = "dteBis";
            this.dteBis.Size = new System.Drawing.Size(97, 21);
            this.dteBis.TabIndex = 5;
            // 
            // lblVon
            // 
            this.lblVon.AutoSize = true;
            this.lblVon.Location = new System.Drawing.Point(10, 28);
            this.lblVon.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lblVon.Name = "lblVon";
            this.lblVon.Size = new System.Drawing.Size(75, 14);
            this.lblVon.TabIndex = 212;
            this.lblVon.Text = "Entlassen von";
            // 
            // dteVon
            // 
            appearance4.BackColor = System.Drawing.Color.White;
            appearance4.BackColor2 = System.Drawing.Color.White;
            appearance4.BackColorDisabled = System.Drawing.Color.White;
            appearance4.BackColorDisabled2 = System.Drawing.Color.White;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            this.dteVon.Appearance = appearance4;
            this.dteVon.BackColor = System.Drawing.Color.White;
            this.dteVon.FormatString = "";
            this.dteVon.Location = new System.Drawing.Point(91, 24);
            this.dteVon.Margin = new System.Windows.Forms.Padding(5);
            this.dteVon.MaskInput = "dd.mm.yyyy";
            this.dteVon.Name = "dteVon";
            this.dteVon.Size = new System.Drawing.Size(97, 21);
            this.dteVon.TabIndex = 4;
            // 
            // lblFound
            // 
            this.lblFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.FontData.SizeInPoints = 7.5F;
            this.lblFound.Appearance = appearance5;
            this.lblFound.AutoSize = true;
            this.lblFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblFound.Location = new System.Drawing.Point(12, 417);
            this.lblFound.Margin = new System.Windows.Forms.Padding(4);
            this.lblFound.Name = "lblFound";
            this.lblFound.Size = new System.Drawing.Size(66, 13);
            this.lblFound.TabIndex = 1002;
            this.lblFound.Text = "Gefunden: 10";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.AutoWorkLayout = false;
            this.btnExportExcel.IsStandardControl = false;
            this.btnExportExcel.Location = new System.Drawing.Point(620, 420);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(5);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(92, 31);
            this.btnExportExcel.TabIndex = 100;
            this.btnExportExcel.Tag = "";
            this.btnExportExcel.Text = "Export Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance6.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnClose.Appearance = appearance6;
            this.btnClose.AutoWorkLayout = false;
            this.btnClose.IsStandardControl = false;
            this.btnClose.Location = new System.Drawing.Point(731, 420);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 31);
            this.btnClose.TabIndex = 101;
            this.btnClose.Tag = "";
            this.btnClose.Text = "Schließen";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gridPatientenEntlassen
            // 
            this.gridPatientenEntlassen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPatientenEntlassen.AutoWork = true;
            this.gridPatientenEntlassen.DataMember = "PatientenEntlassen";
            this.gridPatientenEntlassen.DataSource = this.dsKlientenliste1;
            appearance7.BackColor = System.Drawing.Color.White;
            appearance7.FontData.SizeInPoints = 10F;
            this.gridPatientenEntlassen.DisplayLayout.Appearance = appearance7;
            this.gridPatientenEntlassen.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.Header.VisiblePosition = 4;
            ultraGridColumn3.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(266, 0);
            ultraGridColumn3.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.Header.VisiblePosition = 2;
            ultraGridColumn4.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn4.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(356, 0);
            ultraGridColumn4.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn4.RowLayoutColumnInfo.SpanY = 2;
            appearance8.TextHAlignAsString = "Center";
            ultraGridColumn5.CellButtonAppearance = appearance8;
            appearance9.TextHAlignAsString = "Center";
            ultraGridColumn5.Header.Appearance = appearance9;
            ultraGridColumn5.Header.VisiblePosition = 3;
            ultraGridColumn5.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(152, 0);
            ultraGridColumn5.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand1.SummaryFooterCaption = "";
            this.gridPatientenEntlassen.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridPatientenEntlassen.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridPatientenEntlassen.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.gridPatientenEntlassen.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            this.gridPatientenEntlassen.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;
            this.gridPatientenEntlassen.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.gridPatientenEntlassen.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridPatientenEntlassen.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.gridPatientenEntlassen.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance10.BorderColor = System.Drawing.Color.White;
            this.gridPatientenEntlassen.DisplayLayout.Override.SummaryFooterAppearance = appearance10;
            appearance11.BorderColor = System.Drawing.Color.White;
            this.gridPatientenEntlassen.DisplayLayout.Override.SummaryFooterCaptionAppearance = appearance11;
            appearance12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridPatientenEntlassen.DisplayLayout.Override.SummaryValueAppearance = appearance12;
            this.gridPatientenEntlassen.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            valueList1.Key = "Klienten";
            valueList2.Key = "Kostenträger";
            valueList3.Key = "MWSt";
            valueListItem1.DataValue = 10;
            valueListItem1.DisplayText = "10";
            valueListItem2.DataValue = 20;
            valueListItem2.DisplayText = "20";
            valueListItem3.DataValue = 30;
            valueListItem3.DisplayText = "30";
            valueList3.ValueListItems.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            valueList4.Key = "eKonto";
            valueList5.Key = "month";
            valueListItem4.DataValue = 1;
            valueListItem4.DisplayText = "1";
            valueListItem5.DataValue = 2;
            valueListItem5.DisplayText = "2";
            valueListItem6.DataValue = 3;
            valueListItem6.DisplayText = "3";
            valueListItem7.DataValue = 4;
            valueListItem7.DisplayText = "4";
            valueListItem8.DataValue = 5;
            valueListItem8.DisplayText = "5";
            valueListItem9.DataValue = 6;
            valueListItem9.DisplayText = "6";
            valueListItem10.DataValue = 7;
            valueListItem10.DisplayText = "7";
            valueListItem11.DataValue = 8;
            valueListItem11.DisplayText = "8";
            valueListItem12.DataValue = 9;
            valueListItem12.DisplayText = "9";
            valueListItem13.DataValue = 10;
            valueListItem13.DisplayText = "10";
            valueListItem14.DataValue = 11;
            valueListItem14.DisplayText = "11";
            valueListItem15.DataValue = 12;
            valueListItem15.DisplayText = "12";
            valueList5.ValueListItems.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem4,
            valueListItem5,
            valueListItem6,
            valueListItem7,
            valueListItem8,
            valueListItem9,
            valueListItem10,
            valueListItem11,
            valueListItem12,
            valueListItem13,
            valueListItem14,
            valueListItem15});
            valueList6.Key = "year";
            this.gridPatientenEntlassen.DisplayLayout.ValueLists.AddRange(new Infragistics.Win.ValueList[] {
            valueList1,
            valueList2,
            valueList3,
            valueList4,
            valueList5,
            valueList6});
            this.gridPatientenEntlassen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridPatientenEntlassen.Location = new System.Drawing.Point(7, 76);
            this.gridPatientenEntlassen.Margin = new System.Windows.Forms.Padding(5);
            this.gridPatientenEntlassen.Name = "gridPatientenEntlassen";
            this.gridPatientenEntlassen.Size = new System.Drawing.Size(800, 340);
            this.gridPatientenEntlassen.TabIndex = 201;
            this.gridPatientenEntlassen.Text = "Dokumente";
            this.gridPatientenEntlassen.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.gridArztabrechnung_BeforeCellActivate);
            this.gridPatientenEntlassen.Click += new System.EventHandler(this.gridArztabrechnung_Click);
            this.gridPatientenEntlassen.DoubleClick += new System.EventHandler(this.gridArztabrechnung_DoubleClick);
            // 
            // dsKlientenliste1
            // 
            this.dsKlientenliste1.DataSetName = "dsKlientenliste";
            this.dsKlientenliste1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // contListePatientenEntlassen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.lblFound);
            this.Controls.Add(this.grpSuche);
            this.Controls.Add(this.gridPatientenEntlassen);
            this.Name = "contListePatientenEntlassen";
            this.Size = new System.Drawing.Size(814, 457);
            this.Load += new System.EventHandler(this.contListePatientenEntlassen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpSuche)).EndInit();
            this.grpSuche.ResumeLayout(false);
            this.grpSuche.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPatientenEntlassen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public QS2.Desktop.ControlManagment.BaseGrid gridPatientenEntlassen;
        private Global.db.ERSystem.dsKlientenliste dsKlientenliste1;
        private Infragistics.Win.Misc.UltraGroupBox grpSuche;
        public QS2.Desktop.ControlManagment.BaseButton btnSearch;
        public QS2.Desktop.ControlManagment.BaseLabel lblResetSearch;
        public QS2.Desktop.ControlManagment.BaseLabel lblBis;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor dteBis;
        public QS2.Desktop.ControlManagment.BaseLabel lblVon;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor dteVon;
        private QS2.Desktop.ControlManagment.BaseLabel lblFound;
        public QS2.Desktop.ControlManagment.BaseButton btnExportExcel;
        public QS2.Desktop.ControlManagment.BaseButton btnClose;
        private Global.db.ERSystem.sqlManange sqlManange1;
    }
}
