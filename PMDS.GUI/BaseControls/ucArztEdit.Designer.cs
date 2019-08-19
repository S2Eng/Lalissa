using PMDS.Global.db.Global;
namespace PMDS.GUI
{
    partial class ucArztEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucArztEdit));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Aerzte", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAdresse");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKontakt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Titel");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Nachname");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Vorname");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Fachrichtung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Auswahl", 0, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            this.btnUpdate = new QS2.Desktop.ControlManagment.BaseButton();
            this.grpArztEdit = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.lblFachrichtung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbFachrichtung = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.tbNachname = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.btnSearch = new PMDS.GUI.ucButton(this.components);
            this.lblNachname = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.gridAerzte = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsAerzte1 = new PMDS.Global.db.Global.dsAerzte();
            this.ultraPanel1 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraPanel2 = new Infragistics.Win.Misc.UltraPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grpArztEdit)).BeginInit();
            this.grpArztEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbFachrichtung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNachname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAerzte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAerzte1)).BeginInit();
            this.ultraPanel1.ClientArea.SuspendLayout();
            this.ultraPanel1.SuspendLayout();
            this.ultraPanel2.ClientArea.SuspendLayout();
            this.ultraPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.AutoWorkLayout = false;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.IsStandardControl = false;
            this.btnUpdate.Location = new System.Drawing.Point(763, 21);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(35, 32);
            this.btnUpdate.TabIndex = 33;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // grpArztEdit
            // 
            this.grpArztEdit.Controls.Add(this.lblFachrichtung);
            this.grpArztEdit.Controls.Add(this.cbFachrichtung);
            this.grpArztEdit.Controls.Add(this.tbNachname);
            this.grpArztEdit.Controls.Add(this.btnSearch);
            this.grpArztEdit.Controls.Add(this.lblNachname);
            this.grpArztEdit.Controls.Add(this.btnAdd);
            this.grpArztEdit.Controls.Add(this.btnUpdate);
            this.grpArztEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpArztEdit.Location = new System.Drawing.Point(0, 0);
            this.grpArztEdit.Margin = new System.Windows.Forms.Padding(4);
            this.grpArztEdit.Name = "grpArztEdit";
            this.grpArztEdit.Size = new System.Drawing.Size(812, 80);
            this.grpArztEdit.TabIndex = 121;
            this.grpArztEdit.Text = "Arzt suchen (Alt + U)";
            // 
            // lblFachrichtung
            // 
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.lblFachrichtung.Appearance = appearance1;
            this.lblFachrichtung.Location = new System.Drawing.Point(400, 23);
            this.lblFachrichtung.Margin = new System.Windows.Forms.Padding(4);
            this.lblFachrichtung.Name = "lblFachrichtung";
            this.lblFachrichtung.Size = new System.Drawing.Size(96, 26);
            this.lblFachrichtung.TabIndex = 39;
            this.lblFachrichtung.Text = "Fachrichtung";
            // 
            // cbFachrichtung
            // 
            this.cbFachrichtung.AddEmptyEntry = false;
            this.cbFachrichtung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFachrichtung.BerufsstandGruppeJNA = -1;
            this.cbFachrichtung.Group = "FAR";
            this.cbFachrichtung.ID_PEP = -1;
            this.cbFachrichtung.Location = new System.Drawing.Point(504, 23);
            this.cbFachrichtung.Margin = new System.Windows.Forms.Padding(4);
            this.cbFachrichtung.Name = "cbFachrichtung";
            this.cbFachrichtung.ShowAddButton = true;
            this.cbFachrichtung.Size = new System.Drawing.Size(211, 24);
            this.cbFachrichtung.TabIndex = 37;
            // 
            // tbNachname
            // 
            this.tbNachname.Location = new System.Drawing.Point(101, 23);
            this.tbNachname.Margin = new System.Windows.Forms.Padding(4);
            this.tbNachname.MaxLength = 50;
            this.tbNachname.Name = "tbNachname";
            this.tbNachname.Size = new System.Drawing.Size(224, 24);
            this.tbNachname.TabIndex = 35;
            // 
            // btnSearch
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSearch.Appearance = appearance2;
            this.btnSearch.AutoWorkLayout = false;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSearch.DoOnClick = true;
            this.btnSearch.IsStandardControl = true;
            this.btnSearch.Location = new System.Drawing.Point(343, 23);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(40, 30);
            this.btnSearch.TabIndex = 36;
            this.btnSearch.TabStop = false;
            this.btnSearch.TYPE = PMDS.GUI.ucButton.ButtonType.Search;
            this.btnSearch.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblNachname
            // 
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.lblNachname.Appearance = appearance3;
            this.lblNachname.Location = new System.Drawing.Point(8, 23);
            this.lblNachname.Margin = new System.Windows.Forms.Padding(4);
            this.lblNachname.Name = "lblNachname";
            this.lblNachname.Size = new System.Drawing.Size(85, 26);
            this.lblNachname.TabIndex = 38;
            this.lblNachname.Text = "Nachname";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance4;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(724, 21);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(35, 32);
            this.btnAdd.TabIndex = 32;
            this.btnAdd.TabStop = false;
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gridAerzte
            // 
            this.gridAerzte.AutoWork = true;
            this.gridAerzte.DataMember = "Aerzte";
            this.gridAerzte.DataSource = this.dsAerzte1;
            appearance5.BackColor = System.Drawing.Color.White;
            appearance5.BorderColor = System.Drawing.Color.Black;
            this.gridAerzte.DisplayLayout.Appearance = appearance5;
            this.gridAerzte.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(285, 0);
            ultraGridColumn5.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(203, 0);
            ultraGridColumn6.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn7.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn7.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn7.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.DataType = typeof(bool);
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn8.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn8.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(58, 0);
            ultraGridColumn8.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn8.RowLayoutColumnInfo.SpanY = 2;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.gridAerzte.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridAerzte.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridAerzte.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.gridAerzte.DisplayLayout.GroupByBox.Appearance = appearance6;
            appearance7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridAerzte.DisplayLayout.GroupByBox.BandLabelAppearance = appearance7;
            this.gridAerzte.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridAerzte.DisplayLayout.GroupByBox.Hidden = true;
            appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance8.BackColor2 = System.Drawing.SystemColors.Control;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridAerzte.DisplayLayout.GroupByBox.PromptAppearance = appearance8;
            this.gridAerzte.DisplayLayout.MaxColScrollRegions = 1;
            this.gridAerzte.DisplayLayout.MaxRowScrollRegions = 1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridAerzte.DisplayLayout.Override.ActiveCellAppearance = appearance9;
            appearance10.BackColor = System.Drawing.SystemColors.Highlight;
            appearance10.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridAerzte.DisplayLayout.Override.ActiveRowAppearance = appearance10;
            this.gridAerzte.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridAerzte.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            this.gridAerzte.DisplayLayout.Override.CardAreaAppearance = appearance11;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            appearance12.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridAerzte.DisplayLayout.Override.CellAppearance = appearance12;
            this.gridAerzte.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.gridAerzte.DisplayLayout.Override.CellPadding = 0;
            appearance13.BackColor = System.Drawing.SystemColors.Control;
            appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance13.BorderColor = System.Drawing.SystemColors.Window;
            this.gridAerzte.DisplayLayout.Override.GroupByRowAppearance = appearance13;
            appearance14.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance14.TextHAlignAsString = "Left";
            this.gridAerzte.DisplayLayout.Override.HeaderAppearance = appearance14;
            this.gridAerzte.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridAerzte.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance15.BackColor = System.Drawing.SystemColors.Window;
            appearance15.BorderColor = System.Drawing.Color.Silver;
            this.gridAerzte.DisplayLayout.Override.RowAppearance = appearance15;
            this.gridAerzte.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.gridAerzte.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance16.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridAerzte.DisplayLayout.Override.TemplateAddRowAppearance = appearance16;
            this.gridAerzte.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridAerzte.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridAerzte.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.gridAerzte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAerzte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gridAerzte.Location = new System.Drawing.Point(0, 0);
            this.gridAerzte.Margin = new System.Windows.Forms.Padding(4);
            this.gridAerzte.Name = "gridAerzte";
            this.gridAerzte.Size = new System.Drawing.Size(815, 227);
            this.gridAerzte.TabIndex = 3;
            this.gridAerzte.Text = "ultraGrid2";
            this.gridAerzte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridAerzte_KeyDown);
            // 
            // dsAerzte1
            // 
            this.dsAerzte1.DataSetName = "dsAerzte";
            this.dsAerzte1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ultraPanel1
            // 
            this.ultraPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // ultraPanel1.ClientArea
            // 
            this.ultraPanel1.ClientArea.Controls.Add(this.grpArztEdit);
            this.ultraPanel1.Location = new System.Drawing.Point(0, 3);
            this.ultraPanel1.Name = "ultraPanel1";
            this.ultraPanel1.Size = new System.Drawing.Size(812, 80);
            this.ultraPanel1.TabIndex = 122;
            // 
            // ultraPanel2
            // 
            this.ultraPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // ultraPanel2.ClientArea
            // 
            this.ultraPanel2.ClientArea.Controls.Add(this.gridAerzte);
            this.ultraPanel2.Location = new System.Drawing.Point(0, 85);
            this.ultraPanel2.Name = "ultraPanel2";
            this.ultraPanel2.Size = new System.Drawing.Size(815, 227);
            this.ultraPanel2.TabIndex = 123;
            // 
            // ucArztEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ultraPanel2);
            this.Controls.Add(this.ultraPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucArztEdit";
            this.Size = new System.Drawing.Size(815, 315);
            this.Load += new System.EventHandler(this.ucArztEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpArztEdit)).EndInit();
            this.grpArztEdit.ResumeLayout(false);
            this.grpArztEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbFachrichtung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNachname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAerzte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAerzte1)).EndInit();
            this.ultraPanel1.ClientArea.ResumeLayout(false);
            this.ultraPanel1.ResumeLayout(false);
            this.ultraPanel2.ClientArea.ResumeLayout(false);
            this.ultraPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseGrid gridAerzte;
        private dsAerzte dsAerzte1;
        private QS2.Desktop.ControlManagment.BaseButton btnUpdate;
        private ucButton btnAdd;
        private QS2.Desktop.ControlManagment.BaseGroupBox grpArztEdit;
        private QS2.Desktop.ControlManagment.BaseLabel lblFachrichtung;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cbFachrichtung;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbNachname;
        private ucButton btnSearch;
        private QS2.Desktop.ControlManagment.BaseLabel lblNachname;
        private Infragistics.Win.Misc.UltraPanel ultraPanel1;
        private Infragistics.Win.Misc.UltraPanel ultraPanel2;

    }
}
