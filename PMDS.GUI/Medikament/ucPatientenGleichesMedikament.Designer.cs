namespace PMDS.GUI.Medikament
{
    partial class ucPatientenGleichesMedikament
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("UI", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Rezepteintrag");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Von");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Dosierung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Herrichten");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRezeptEintrag");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDVerordnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDMedDatenWundeKopf");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Beschreibung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bemerkung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Therapie");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MedizinischerTyp");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Beendigungsgrund");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("obj");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(686348204);
            Infragistics.Win.ValueList valueList2 = new Infragistics.Win.ValueList(407222969);
            Infragistics.Win.ValueList valueList3 = new Infragistics.Win.ValueList(413543016);
            Infragistics.Win.ValueList valueList4 = new Infragistics.Win.ValueList(69876844);
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.gridPatientsSameMedicament = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsKlientenliste1 = new PMDS.Global.db.ERSystem.dsKlientenliste();
            this.lblMedikament = new Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor();
            this.sqlManange1 = new PMDS.Global.db.ERSystem.sqlManange(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridPatientsSameMedicament)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPatientsSameMedicament
            // 
            this.gridPatientsSameMedicament.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPatientsSameMedicament.AutoWork = true;
            this.gridPatientsSameMedicament.DataMember = "UI";
            this.gridPatientsSameMedicament.DataSource = this.dsKlientenliste1;
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.FontData.SizeInPoints = 10F;
            this.gridPatientsSameMedicament.DisplayLayout.Appearance = appearance1;
            this.gridPatientsSameMedicament.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn9.Header.Caption = "Klient";
            ultraGridColumn9.Header.Editor = null;
            ultraGridColumn9.Header.VisiblePosition = 0;
            ultraGridColumn9.Width = 307;
            ultraGridColumn10.Header.Editor = null;
            ultraGridColumn10.Header.VisiblePosition = 1;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.Header.Editor = null;
            ultraGridColumn11.Header.VisiblePosition = 2;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.Header.Editor = null;
            ultraGridColumn12.Header.VisiblePosition = 3;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.Header.Editor = null;
            ultraGridColumn13.Header.VisiblePosition = 4;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn14.Header.Editor = null;
            ultraGridColumn14.Header.VisiblePosition = 5;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn15.Header.Editor = null;
            ultraGridColumn15.Header.VisiblePosition = 6;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn16.Header.Editor = null;
            ultraGridColumn16.Header.VisiblePosition = 7;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn17.Header.Editor = null;
            ultraGridColumn17.Header.VisiblePosition = 8;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn18.Header.Editor = null;
            ultraGridColumn18.Header.VisiblePosition = 9;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn19.Header.Editor = null;
            ultraGridColumn19.Header.VisiblePosition = 10;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn20.Header.Editor = null;
            ultraGridColumn20.Header.VisiblePosition = 11;
            ultraGridColumn20.Hidden = true;
            ultraGridColumn21.Header.Editor = null;
            ultraGridColumn21.Header.VisiblePosition = 12;
            ultraGridColumn21.Hidden = true;
            ultraGridColumn21.Width = 307;
            ultraGridColumn22.Header.Editor = null;
            ultraGridColumn22.Header.VisiblePosition = 13;
            ultraGridColumn22.Hidden = true;
            ultraGridColumn23.Header.Editor = null;
            ultraGridColumn23.Header.VisiblePosition = 14;
            ultraGridColumn23.Hidden = true;
            ultraGridColumn24.Header.Editor = null;
            ultraGridColumn24.Header.VisiblePosition = 15;
            ultraGridColumn24.Hidden = true;
            ultraGridColumn25.Header.Editor = null;
            ultraGridColumn25.Header.VisiblePosition = 16;
            ultraGridColumn25.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
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
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25});
            this.gridPatientsSameMedicament.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridPatientsSameMedicament.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridPatientsSameMedicament.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.gridPatientsSameMedicament.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            this.gridPatientsSameMedicament.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;
            this.gridPatientsSameMedicament.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.gridPatientsSameMedicament.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridPatientsSameMedicament.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridPatientsSameMedicament.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            this.gridPatientsSameMedicament.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            appearance2.BorderColor = System.Drawing.Color.White;
            this.gridPatientsSameMedicament.DisplayLayout.Override.SummaryFooterAppearance = appearance2;
            appearance3.BorderColor = System.Drawing.Color.White;
            this.gridPatientsSameMedicament.DisplayLayout.Override.SummaryFooterCaptionAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridPatientsSameMedicament.DisplayLayout.Override.SummaryValueAppearance = appearance4;
            this.gridPatientsSameMedicament.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            valueList1.Key = "Typ";
            valueList2.Key = "Lieferant";
            valueList3.Key = "Status";
            valueList4.Key = "Einheit";
            this.gridPatientsSameMedicament.DisplayLayout.ValueLists.AddRange(new Infragistics.Win.ValueList[] {
            valueList1,
            valueList2,
            valueList3,
            valueList4});
            this.gridPatientsSameMedicament.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridPatientsSameMedicament.Location = new System.Drawing.Point(4, 43);
            this.gridPatientsSameMedicament.Margin = new System.Windows.Forms.Padding(4);
            this.gridPatientsSameMedicament.Name = "gridPatientsSameMedicament";
            this.gridPatientsSameMedicament.Size = new System.Drawing.Size(328, 333);
            this.gridPatientsSameMedicament.TabIndex = 44;
            this.gridPatientsSameMedicament.Text = "Dokumente";
            this.gridPatientsSameMedicament.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.gridPatientsSameMedicament_BeforeCellActivate);
            this.gridPatientsSameMedicament.Click += new System.EventHandler(this.gridPatientsSameMedicament_Click);
            // 
            // dsKlientenliste1
            // 
            this.dsKlientenliste1.DataSetName = "dsKlientenliste";
            this.dsKlientenliste1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsKlientenliste1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblMedikament
            // 
            this.lblMedikament.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance5.BackColor = System.Drawing.Color.White;
            appearance5.BackColorDisabled = System.Drawing.Color.White;
            appearance5.BackColorDisabled2 = System.Drawing.Color.White;
            appearance5.FontData.SizeInPoints = 10F;
            this.lblMedikament.Appearance = appearance5;
            this.lblMedikament.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.lblMedikament.Location = new System.Drawing.Point(4, 5);
            this.lblMedikament.Name = "lblMedikament";
            this.lblMedikament.ReadOnly = true;
            this.lblMedikament.Size = new System.Drawing.Size(328, 35);
            this.lblMedikament.TabIndex = 46;
            this.lblMedikament.Value = "Medikament:";
            // 
            // ucPatientenGleichesMedikament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblMedikament);
            this.Controls.Add(this.gridPatientsSameMedicament);
            this.Name = "ucPatientenGleichesMedikament";
            this.Size = new System.Drawing.Size(336, 380);
            this.Load += new System.EventHandler(this.ucPatientenGleichesMedikament_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridPatientsSameMedicament)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public QS2.Desktop.ControlManagment.BaseGrid gridPatientsSameMedicament;
        private Global.db.ERSystem.dsKlientenliste dsKlientenliste1;
        private Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor lblMedikament;
        private Global.db.ERSystem.sqlManange sqlManange1;
    }
}
