namespace PMDS.GUI.GUI.Main
{
    partial class contDocumentSelect
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Dokumente2", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DokumentenName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Abteilungen");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn43 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Benutzergruppen");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn44 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ErstelltAm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn45 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ErstelltVon");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.gridDocuments = new QS2.Desktop.ControlManagment.BaseGrid();
            this.sqlManange1 = new PMDS.Global.db.ERSystem.sqlManange(this.components);
            this.dsKlientenliste1 = new PMDS.Global.db.ERSystem.dsKlientenliste();
            this.btnClose = new QS2.Desktop.ControlManagment.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDocuments
            // 
            this.gridDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDocuments.AutoWork = true;
            this.gridDocuments.DataMember = "Dokumente2";
            appearance1.BackColor = System.Drawing.Color.White;
            this.gridDocuments.DisplayLayout.Appearance = appearance1;
            this.gridDocuments.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridBand1.ColHeadersVisible = false;
            ultraGridColumn39.Header.VisiblePosition = 6;
            ultraGridColumn39.Hidden = true;
            ultraGridColumn40.Header.VisiblePosition = 0;
            ultraGridColumn40.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(210, 0);
            ultraGridColumn41.Header.Caption = "Dokumenten-Name";
            ultraGridColumn41.Header.VisiblePosition = 1;
            ultraGridColumn41.Hidden = true;
            ultraGridColumn41.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(255, 0);
            ultraGridColumn42.Header.VisiblePosition = 2;
            ultraGridColumn42.Hidden = true;
            ultraGridColumn43.Header.VisiblePosition = 3;
            ultraGridColumn43.Hidden = true;
            ultraGridColumn44.Header.Caption = "Erstellt am";
            ultraGridColumn44.Header.VisiblePosition = 4;
            ultraGridColumn44.Hidden = true;
            ultraGridColumn45.Header.Caption = "Erstellt von";
            ultraGridColumn45.Header.VisiblePosition = 5;
            ultraGridColumn45.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn39,
            ultraGridColumn40,
            ultraGridColumn41,
            ultraGridColumn42,
            ultraGridColumn43,
            ultraGridColumn44,
            ultraGridColumn45});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand1.SummaryFooterCaption = "";
            this.gridDocuments.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridDocuments.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridDocuments.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.gridDocuments.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            this.gridDocuments.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;
            this.gridDocuments.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.gridDocuments.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridDocuments.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.gridDocuments.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance2.BorderColor = System.Drawing.Color.White;
            this.gridDocuments.DisplayLayout.Override.SummaryFooterAppearance = appearance2;
            appearance3.BorderColor = System.Drawing.Color.White;
            this.gridDocuments.DisplayLayout.Override.SummaryFooterCaptionAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridDocuments.DisplayLayout.Override.SummaryValueAppearance = appearance4;
            this.gridDocuments.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
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
            this.gridDocuments.DisplayLayout.ValueLists.AddRange(new Infragistics.Win.ValueList[] {
            valueList1,
            valueList2,
            valueList3,
            valueList4,
            valueList5,
            valueList6});
            this.gridDocuments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridDocuments.Location = new System.Drawing.Point(3, 4);
            this.gridDocuments.Name = "gridDocuments";
            this.gridDocuments.Size = new System.Drawing.Size(375, 264);
            this.gridDocuments.TabIndex = 112;
            this.gridDocuments.Text = "Dokumente";
            this.gridDocuments.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.gridDocuments_BeforeRowsDeleted);
            this.gridDocuments.Click += new System.EventHandler(this.gridDocuments_Click);
            this.gridDocuments.DoubleClick += new System.EventHandler(this.gridDocuments_DoubleClick);
            // 
            // dsKlientenliste1
            // 
            this.dsKlientenliste1.DataSetName = "dsKlientenliste";
            this.dsKlientenliste1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnClose.Appearance = appearance5;
            this.btnClose.AutoWorkLayout = false;
            this.btnClose.IsStandardControl = false;
            this.btnClose.Location = new System.Drawing.Point(337, 269);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(38, 29);
            this.btnClose.TabIndex = 113;
            this.btnClose.Tag = "";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // contDocumentSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gridDocuments);
            this.Name = "contDocumentSelect";
            this.Size = new System.Drawing.Size(381, 298);
            this.Load += new System.EventHandler(this.contDocumentSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public QS2.Desktop.ControlManagment.BaseGrid gridDocuments;
        private Global.db.ERSystem.sqlManange sqlManange1;
        private Global.db.ERSystem.dsKlientenliste dsKlientenliste1;
        public QS2.Desktop.ControlManagment.BaseButton btnClose;
    }
}
