namespace PMDS.GUI.Medikament
{
    partial class contSearchMedikamente
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Medikament", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EXT_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BARCODE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Zulassungsnummer");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LangText");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Einheit");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Gruppe");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Herrichten");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AerztlichevorbereitungJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Verabreichungsart");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Applikationsform");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Packungsgroesse");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Packungsanzahl");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Packungseinheit");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Gültigkeitsdatum");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Lagervorschrift");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ImportiertAm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Importiert");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Aktuell");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Erstattungscode");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Kassenzeichen");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Lieferant");
            this.txtMedikament = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblMedikament = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnSearch = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnOK = new QS2.Desktop.ControlManagment.BaseButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgMedikamente = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsMedikament1 = new PMDS.Global.db.Patient.dsMedikament();
            this.btnAddMedikament = new QS2.Desktop.ControlManagment.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtMedikament)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMedikamente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMedikament1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMedikament
            // 
            this.txtMedikament.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMedikament.Location = new System.Drawing.Point(91, 17);
            this.txtMedikament.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMedikament.MaxLength = 25;
            this.txtMedikament.Name = "txtMedikament";
            this.txtMedikament.Size = new System.Drawing.Size(362, 26);
            this.txtMedikament.TabIndex = 0;
            // 
            // lblMedikament
            // 
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.lblMedikament.Appearance = appearance1;
            this.lblMedikament.Location = new System.Drawing.Point(10, 12);
            this.lblMedikament.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblMedikament.Name = "lblMedikament";
            this.lblMedikament.Size = new System.Drawing.Size(94, 38);
            this.lblMedikament.TabIndex = 185;
            this.lblMedikament.Text = "Medikament";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.AutoWorkLayout = false;
            this.btnSearch.ImageSize = new System.Drawing.Size(12, 12);
            this.btnSearch.IsStandardControl = false;
            this.btnSearch.Location = new System.Drawing.Point(457, 10);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(78, 42);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Suchen";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(440, 519);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(104, 39);
            this.btnAbort.TabIndex = 201;
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.ImageSize = new System.Drawing.Size(12, 12);
            this.btnOK.IsStandardControl = false;
            this.btnOK.Location = new System.Drawing.Point(370, 519);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(69, 39);
            this.btnOK.TabIndex = 200;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dgMedikamente
            // 
            this.dgMedikamente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMedikamente.AutoWork = true;
            this.dgMedikamente.DataMember = "Medikament";
            this.dgMedikamente.DataSource = this.dsMedikament1;
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BorderColor = System.Drawing.Color.Black;
            this.dgMedikamente.DisplayLayout.Appearance = appearance2;
            this.dgMedikamente.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.Caption = "Externe ID";
            ultraGridColumn2.Header.VisiblePosition = 19;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn2.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn2.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(116, 0);
            ultraGridColumn2.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn2.Width = 150;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn3.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.Header.VisiblePosition = 2;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn4.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn4.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn4.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn4.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn5.Header.VisiblePosition = 3;
            ultraGridColumn5.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(289, 0);
            ultraGridColumn5.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn6.Header.Caption = "Langtext";
            ultraGridColumn6.Header.VisiblePosition = 4;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn6.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(242, 0);
            ultraGridColumn6.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn7.Header.VisiblePosition = 5;
            ultraGridColumn7.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn7.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn7.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(113, 0);
            ultraGridColumn7.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn7.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn8.Header.VisiblePosition = 6;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn8.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn8.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn8.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn8.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn9.Header.VisiblePosition = 7;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn10.Header.VisiblePosition = 8;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn11.Header.VisiblePosition = 9;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn12.Header.VisiblePosition = 10;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn13.Header.VisiblePosition = 11;
            ultraGridColumn13.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn13.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn13.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(99, 0);
            ultraGridColumn13.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn13.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn14.Header.VisiblePosition = 12;
            ultraGridColumn14.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn14.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn14.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(99, 0);
            ultraGridColumn14.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn14.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn15.Header.VisiblePosition = 13;
            ultraGridColumn15.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn15.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn15.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn15.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn16.Header.VisiblePosition = 14;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn16.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn16.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn16.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(109, 0);
            ultraGridColumn16.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn16.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn17.Header.VisiblePosition = 15;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn17.RowLayoutColumnInfo.OriginX = 20;
            ultraGridColumn17.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn17.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(225, 0);
            ultraGridColumn17.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn17.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn18.Header.Caption = "Importiert am";
            ultraGridColumn18.Header.VisiblePosition = 16;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn18.RowLayoutColumnInfo.OriginX = 18;
            ultraGridColumn18.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn18.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(123, 0);
            ultraGridColumn18.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn18.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn18.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
            ultraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn19.Header.VisiblePosition = 17;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn19.RowLayoutColumnInfo.OriginX = 16;
            ultraGridColumn19.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn19.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn19.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn20.Header.VisiblePosition = 18;
            ultraGridColumn20.Hidden = true;
            ultraGridColumn20.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn20.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn20.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(54, 0);
            ultraGridColumn20.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn20.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn21.Header.VisiblePosition = 20;
            ultraGridColumn22.Header.VisiblePosition = 21;
            ultraGridColumn23.Header.VisiblePosition = 22;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23});
            ultraGridBand1.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgMedikamente.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgMedikamente.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMedikamente.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.dgMedikamente.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.dgMedikamente.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.dgMedikamente.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgMedikamente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMedikamente.Location = new System.Drawing.Point(10, 58);
            this.dgMedikamente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgMedikamente.Name = "dgMedikamente";
            this.dgMedikamente.Size = new System.Drawing.Size(825, 455);
            this.dgMedikamente.TabIndex = 100;
            this.dgMedikamente.DoubleClick += new System.EventHandler(this.dgMedikamente_DoubleClick);
            // 
            // dsMedikament1
            // 
            this.dsMedikament1.DataSetName = "dsMedikament";
            this.dsMedikament1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsMedikament1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnAddMedikament
            // 
            this.btnAddMedikament.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMedikament.AutoWorkLayout = false;
            this.btnAddMedikament.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAddMedikament.IsStandardControl = false;
            this.btnAddMedikament.Location = new System.Drawing.Point(798, 22);
            this.btnAddMedikament.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddMedikament.Name = "btnAddMedikament";
            this.btnAddMedikament.Size = new System.Drawing.Size(30, 30);
            this.btnAddMedikament.TabIndex = 202;
            this.btnAddMedikament.Click += new System.EventHandler(this.btnAddMedikament_Click);
            // 
            // contSearchMedikamente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAddMedikament);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgMedikamente);
            this.Controls.Add(this.txtMedikament);
            this.Controls.Add(this.lblMedikament);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "contSearchMedikamente";
            this.Size = new System.Drawing.Size(845, 563);
            this.Load += new System.EventHandler(this.contSearchMedikamente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtMedikament)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMedikamente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMedikament1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseTextEditor txtMedikament;
        private QS2.Desktop.ControlManagment.BaseLabel lblMedikament;
        private QS2.Desktop.ControlManagment.BaseGrid dgMedikamente;
        private Global.db.Patient.dsMedikament dsMedikament1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
        public QS2.Desktop.ControlManagment.BaseButton btnOK;
        public QS2.Desktop.ControlManagment.BaseButton btnSearch;
        public QS2.Desktop.ControlManagment.BaseButton btnAddMedikament;
    }
}
