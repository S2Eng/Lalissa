namespace PMDS.GUI
{
    partial class ucBewerberAufnahme
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Patient", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Name");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Geburtsdatum");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Abteilung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bereich");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Aufnahmezeitpunkt");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBewerberAufnahme));
            this.lblFamiliennameVorname = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtName = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.dgKlienten = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsPatientBereich1 = new PMDS.Data.Patient.dsPatientBereich();
            this.opsBewerber = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.pnlTop = new QS2.Desktop.ControlManagment.BasePanel();
            this.pnlKlienten = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnSearch = new PMDS.GUI.ucButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgKlienten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientBereich1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opsBewerber)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlKlienten.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFamiliennameVorname
            // 
            appearance1.FontData.SizeInPoints = 8F;
            this.lblFamiliennameVorname.Appearance = appearance1;
            this.lblFamiliennameVorname.AutoSize = true;
            this.lblFamiliennameVorname.Location = new System.Drawing.Point(8, 8);
            this.lblFamiliennameVorname.Name = "lblFamiliennameVorname";
            this.lblFamiliennameVorname.Size = new System.Drawing.Size(124, 14);
            this.lblFamiliennameVorname.TabIndex = 135;
            this.lblFamiliennameVorname.Text = "Familienname, Vorname";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(136, 5);
            this.txtName.MaxLength = 52;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(289, 21);
            this.txtName.TabIndex = 1;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // dgKlienten
            // 
            this.dgKlienten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgKlienten.AutoWork = true;
            this.dgKlienten.DataMember = "Patient";
            this.dgKlienten.DataSource = this.dsPatientBereich1;
            this.dgKlienten.DisplayLayout.AddNewBox.Prompt = "Add ...";
            appearance2.BackColor = System.Drawing.Color.White;
            this.dgKlienten.DisplayLayout.Appearance = appearance2;
            this.dgKlienten.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn2.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(343, 0);
            ultraGridColumn2.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn2.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(108, 0);
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(148, 0);
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn5.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(157, 0);
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.Header.Caption = "Letzte Aufnahme";
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgKlienten.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgKlienten.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgKlienten.DisplayLayout.GroupByBox.Hidden = true;
            this.dgKlienten.DisplayLayout.GroupByBox.Prompt = "Zu gruppierende Spalten hier herein ziehen.";
            this.dgKlienten.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.dgKlienten.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.dgKlienten.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgKlienten.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.dgKlienten.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgKlienten.DisplayLayout.Override.NullText = "";
            this.dgKlienten.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.dgKlienten.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.dgKlienten.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.dgKlienten.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.dgKlienten.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgKlienten.Location = new System.Drawing.Point(6, 31);
            this.dgKlienten.Name = "dgKlienten";
            this.dgKlienten.Size = new System.Drawing.Size(718, 280);
            this.dgKlienten.TabIndex = 3;
            this.dgKlienten.AfterRowActivate += new System.EventHandler(this.dgKlienten_AfterRowActivate);
            this.dgKlienten.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.dgKlienten_DoubleClickRow);
            // 
            // dsPatientBereich1
            // 
            this.dsPatientBereich1.DataSetName = "dsPatientBereich";
            this.dsPatientBereich1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // opsBewerber
            // 
            this.opsBewerber.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = " Neuen Bewerber aufnehmen";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = " Bestehenden Klienten als Bewerber aktivieren";
            this.opsBewerber.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.opsBewerber.ItemSpacingVertical = 5;
            this.opsBewerber.Location = new System.Drawing.Point(10, 5);
            this.opsBewerber.Name = "opsBewerber";
            this.opsBewerber.Size = new System.Drawing.Size(267, 37);
            this.opsBewerber.TabIndex = 0;
            this.opsBewerber.ValueChanged += new System.EventHandler(this.opsBewerber_ValueChanged);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.opsBewerber);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(735, 47);
            this.pnlTop.TabIndex = 139;
            // 
            // pnlKlienten
            // 
            this.pnlKlienten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlKlienten.Controls.Add(this.dgKlienten);
            this.pnlKlienten.Controls.Add(this.btnSearch);
            this.pnlKlienten.Controls.Add(this.lblFamiliennameVorname);
            this.pnlKlienten.Controls.Add(this.txtName);
            this.pnlKlienten.Location = new System.Drawing.Point(1, 47);
            this.pnlKlienten.Name = "pnlKlienten";
            this.pnlKlienten.Size = new System.Drawing.Size(731, 317);
            this.pnlKlienten.TabIndex = 140;
            // 
            // btnSearch
            // 
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSearch.Appearance = appearance4;
            this.btnSearch.AutoWorkLayout = false;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSearch.DoOnClick = true;
            this.btnSearch.IsStandardControl = true;
            this.btnSearch.Location = new System.Drawing.Point(427, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(28, 24);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.TabStop = false;
            this.btnSearch.TYPE = PMDS.GUI.ucButton.ButtonType.Search;
            this.btnSearch.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ucBewerberAufnahme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlKlienten);
            this.Controls.Add(this.pnlTop);
            this.Name = "ucBewerberAufnahme";
            this.Size = new System.Drawing.Size(735, 364);
            this.Load += new System.EventHandler(this.ucBewerberAufnahme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgKlienten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientBereich1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opsBewerber)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlKlienten.ResumeLayout(false);
            this.pnlKlienten.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseLabel lblFamiliennameVorname;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtName;
        private QS2.Desktop.ControlManagment.BaseGrid dgKlienten;
        private QS2.Desktop.ControlManagment.BaseOptionSet opsBewerber;
        private ucButton btnSearch;
        private QS2.Desktop.ControlManagment.BasePanel pnlTop;
        private QS2.Desktop.ControlManagment.BasePanel pnlKlienten;
        private PMDS.Data.Patient.dsPatientBereich dsPatientBereich1;
    }
}
