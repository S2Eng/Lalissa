using PMDS.Global.db.Patient;

namespace PMDS.GUI.Klient
{
    partial class ucAbteilungen
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung2", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKontakt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RMOptionalJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Reihenfolge");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Basisabteilung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Ziel", 0);
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
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
            this.btnSave = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAdd = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDel = new QS2.Desktop.ControlManagment.BaseButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gridAbteilungen = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsAbteilung1 = new PMDS.Global.db.Patient.dsAbteilung();
            this.dbAbteilung1 = new PMDS.DB.DBAbteilung(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAbteilungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAbteilung1)).BeginInit();
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
            this.btnSave.Location = new System.Drawing.Point(121, 263);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 27);
            this.btnSave.TabIndex = 101;
            this.btnSave.Tag = "";
            this.btnSave.Text = "Speichern";
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
            this.btnAbort.Location = new System.Drawing.Point(206, 263);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(80, 27);
            this.btnAbort.TabIndex = 102;
            this.btnAbort.Tag = "";
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance3;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.IsStandardControl = false;
            this.btnAdd.Location = new System.Drawing.Point(354, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(29, 24);
            this.btnAdd.TabIndex = 104;
            this.btnAdd.Tag = "";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance4;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.IsStandardControl = false;
            this.btnDel.Location = new System.Drawing.Point(383, 1);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(29, 24);
            this.btnDel.TabIndex = 105;
            this.btnDel.Tag = "";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // gridAbteilungen
            // 
            this.gridAbteilungen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridAbteilungen.AutoWork = true;
            this.gridAbteilungen.DataMember = "Abteilung2";
            this.gridAbteilungen.DataSource = this.dsAbteilung1;
            appearance5.BackColor = System.Drawing.Color.White;
            this.gridAbteilungen.DisplayLayout.Appearance = appearance5;
            this.gridAbteilungen.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn10.Header.VisiblePosition = 0;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.Header.VisiblePosition = 2;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.Header.Caption = "Abteilung";
            ultraGridColumn12.Header.VisiblePosition = 1;
            ultraGridColumn12.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn12.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn12.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(245, 0);
            ultraGridColumn12.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn12.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn13.Header.VisiblePosition = 3;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn24.Header.VisiblePosition = 4;
            ultraGridColumn24.Hidden = true;
            ultraGridColumn29.Header.VisiblePosition = 5;
            ultraGridColumn29.Hidden = true;
            ultraGridColumn29.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn29.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn29.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn29.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn1.Header.VisiblePosition = 6;
            ultraGridColumn30.DataType = typeof(bool);
            ultraGridColumn30.Header.VisiblePosition = 7;
            ultraGridColumn30.Hidden = true;
            ultraGridColumn30.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn30.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn30.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(41, 0);
            ultraGridColumn30.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn30.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn30.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn24,
            ultraGridColumn29,
            ultraGridColumn1,
            ultraGridColumn30});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand1.SummaryFooterCaption = "";
            this.gridAbteilungen.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridAbteilungen.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridAbteilungen.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.gridAbteilungen.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            this.gridAbteilungen.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;
            this.gridAbteilungen.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridAbteilungen.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridAbteilungen.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.gridAbteilungen.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance6.BorderColor = System.Drawing.Color.White;
            this.gridAbteilungen.DisplayLayout.Override.SummaryFooterAppearance = appearance6;
            appearance7.BorderColor = System.Drawing.Color.White;
            this.gridAbteilungen.DisplayLayout.Override.SummaryFooterCaptionAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridAbteilungen.DisplayLayout.Override.SummaryValueAppearance = appearance8;
            this.gridAbteilungen.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
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
            this.gridAbteilungen.DisplayLayout.ValueLists.AddRange(new Infragistics.Win.ValueList[] {
            valueList1,
            valueList2,
            valueList3,
            valueList4,
            valueList5,
            valueList6});
            this.gridAbteilungen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridAbteilungen.Location = new System.Drawing.Point(4, 27);
            this.gridAbteilungen.Name = "gridAbteilungen";
            this.gridAbteilungen.Size = new System.Drawing.Size(418, 233);
            this.gridAbteilungen.TabIndex = 103;
            this.gridAbteilungen.Text = "Abteilungen";
            this.gridAbteilungen.AfterCellActivate += new System.EventHandler(this.gridAbteilungen_AfterCellActivate);
            this.gridAbteilungen.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.gridAbteilungen_BeforeCellActivate);
            this.gridAbteilungen.Click += new System.EventHandler(this.gridAbteilungen_Click);
            this.gridAbteilungen.DoubleClick += new System.EventHandler(this.gridAbteilungen_DoubleClick);
            // 
            // dsAbteilung1
            // 
            this.dsAbteilung1.DataSetName = "dsAbteilung";
            this.dsAbteilung1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsAbteilung1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ucAbteilungen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gridAbteilungen);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnSave);
            this.Name = "ucAbteilungen";
            this.Size = new System.Drawing.Size(425, 293);
            this.Load += new System.EventHandler(this.ucAbteilungen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAbteilungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAbteilung1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public QS2.Desktop.ControlManagment.BaseButton btnSave;
        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
        public QS2.Desktop.ControlManagment.BaseGrid gridAbteilungen;
        private dsAbteilung dsAbteilung1;
        public QS2.Desktop.ControlManagment.BaseButton btnAdd;
        public QS2.Desktop.ControlManagment.BaseButton btnDel;
        private DB.DBAbteilung dbAbteilung1;
        protected System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
