using PMDS.Global.db.Pflegeplan;

namespace PMDS.GUI
{
    partial class ucASZMTransfer2
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PflegePlanZeitpunkte", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDpflegePlan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Zeitpunkt");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDZeitbereich");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Anmerkung");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
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
            this.dtp = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.cbZeitbereich = new PMDS.GUI.BaseControls.ZeitbereichCombo();
            this.pnlStartDatum = new QS2.Desktop.ControlManagment.BasePanel();
            this.grbStartdatum = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.cbZeitbereichSerie = new PMDS.GUI.BaseControls.ZeitbereicheZeitbereichSerienCombo();
            this.cbMohneZeitbezug = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.pnlFixZeit = new QS2.Desktop.ControlManagment.BasePanel();
            this.pnlUhrzeit = new QS2.Desktop.ControlManagment.BasePanel();
            this.tbUhrzeit = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblUhrZeit = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ultraLabel14 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpStart = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.pnlStartZeitpunkte = new QS2.Desktop.ControlManagment.BasePanel();
            this.dgZP = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsPflegePlanZeitpunkte1 = new PMDS.Global.db.Pflegeplan.dsPflegePlanZeitpunkte();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ultraGridBagLayoutManager1 = new Infragistics.Win.Misc.UltraGridBagLayoutManager(this.components);
            this.ucPflegePlanSingleEdit21 = new PMDS.GUI.ucPflegePlanSingleEdit2();
            ((System.ComponentModel.ISupportInitialize)(this.dtp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbZeitbereich)).BeginInit();
            this.pnlStartDatum.SuspendLayout();
            this.grbStartdatum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbZeitbereichSerie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMohneZeitbezug)).BeginInit();
            this.pnlFixZeit.SuspendLayout();
            this.pnlUhrzeit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbUhrzeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).BeginInit();
            this.pnlStartZeitpunkte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgZP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegePlanZeitpunkte1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtp
            // 
            this.dtp.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.dtp.Location = new System.Drawing.Point(422, 3);
            this.dtp.MaskInput = "hh:mm";
            this.dtp.Name = "dtp";
            this.dtp.ownFormat = "";
            this.dtp.ownMaskInput = "";
            this.dtp.Size = new System.Drawing.Size(40, 21);
            this.dtp.TabIndex = 30;
            this.dtp.Value = null;
            this.dtp.Visible = false;
            // 
            // cbZeitbereich
            // 
            this.cbZeitbereich.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbZeitbereich.Location = new System.Drawing.Point(208, -4);
            this.cbZeitbereich.Name = "cbZeitbereich";
            this.cbZeitbereich.Size = new System.Drawing.Size(177, 21);
            this.cbZeitbereich.TabIndex = 5;
            this.cbZeitbereich.Visible = false;
            // 
            // pnlStartDatum
            // 
            this.pnlStartDatum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStartDatum.BackColor = System.Drawing.Color.White;
            this.pnlStartDatum.Controls.Add(this.grbStartdatum);
            this.pnlStartDatum.Location = new System.Drawing.Point(3, 3);
            this.pnlStartDatum.Name = "pnlStartDatum";
            this.pnlStartDatum.Size = new System.Drawing.Size(663, 262);
            this.pnlStartDatum.TabIndex = 45;
            this.pnlStartDatum.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlStartDatum_Paint);
            // 
            // grbStartdatum
            // 
            this.grbStartdatum.Controls.Add(this.cbZeitbereichSerie);
            this.grbStartdatum.Controls.Add(this.cbMohneZeitbezug);
            this.grbStartdatum.Controls.Add(this.pnlFixZeit);
            this.grbStartdatum.Controls.Add(this.ultraLabel14);
            this.grbStartdatum.Controls.Add(this.dtpStart);
            this.grbStartdatum.Controls.Add(this.pnlStartZeitpunkte);
            this.grbStartdatum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbStartdatum.Location = new System.Drawing.Point(0, 0);
            this.grbStartdatum.Name = "grbStartdatum";
            this.grbStartdatum.Size = new System.Drawing.Size(663, 262);
            this.grbStartdatum.TabIndex = 14;
            this.grbStartdatum.TabStop = false;
            // 
            // cbZeitbereichSerie
            // 
            appearance1.FontData.Name = "Microsoft Sans Serif";
            appearance1.FontData.SizeInPoints = 10F;
            this.cbZeitbereichSerie.Appearance = appearance1;
            this.cbZeitbereichSerie.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbZeitbereichSerie.Location = new System.Drawing.Point(366, 10);
            this.cbZeitbereichSerie.Name = "cbZeitbereichSerie";
            this.cbZeitbereichSerie.Size = new System.Drawing.Size(205, 24);
            this.cbZeitbereichSerie.TabIndex = 30;
            this.cbZeitbereichSerie.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cbZeitbereichSerie_BeforeDropDown);
            this.cbZeitbereichSerie.ValueChanged += new System.EventHandler(this.cbZeitbereichSerie_ValueChanged);
            // 
            // cbMohneZeitbezug
            // 
            appearance2.FontData.Name = "Microsoft Sans Serif";
            appearance2.FontData.SizeInPoints = 10F;
            this.cbMohneZeitbezug.Appearance = appearance2;
            this.cbMohneZeitbezug.Location = new System.Drawing.Point(189, 13);
            this.cbMohneZeitbezug.Name = "cbMohneZeitbezug";
            this.cbMohneZeitbezug.Size = new System.Drawing.Size(171, 19);
            this.cbMohneZeitbezug.TabIndex = 34;
            this.cbMohneZeitbezug.Text = "Zu geplanten Zeiten:";
            this.cbMohneZeitbezug.CheckedChanged += new System.EventHandler(this.cbMohneZeitbezug_CheckedChanged);
            // 
            // pnlFixZeit
            // 
            this.pnlFixZeit.Controls.Add(this.pnlUhrzeit);
            this.pnlFixZeit.Location = new System.Drawing.Point(182, 31);
            this.pnlFixZeit.Name = "pnlFixZeit";
            this.pnlFixZeit.Size = new System.Drawing.Size(240, 27);
            this.pnlFixZeit.TabIndex = 31;
            this.pnlFixZeit.Visible = false;
            // 
            // pnlUhrzeit
            // 
            this.pnlUhrzeit.Controls.Add(this.tbUhrzeit);
            this.pnlUhrzeit.Controls.Add(this.lblUhrZeit);
            this.pnlUhrzeit.Location = new System.Drawing.Point(3, 0);
            this.pnlUhrzeit.Name = "pnlUhrzeit";
            this.pnlUhrzeit.Size = new System.Drawing.Size(87, 24);
            this.pnlUhrzeit.TabIndex = 29;
            this.pnlUhrzeit.Visible = false;
            // 
            // tbUhrzeit
            // 
            this.tbUhrzeit.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.tbUhrzeit.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.tbUhrzeit.Location = new System.Drawing.Point(40, 2);
            this.tbUhrzeit.MaskInput = "hh:mm";
            this.tbUhrzeit.Name = "tbUhrzeit";
            this.tbUhrzeit.ownFormat = "";
            this.tbUhrzeit.ownMaskInput = "";
            this.tbUhrzeit.Size = new System.Drawing.Size(40, 21);
            this.tbUhrzeit.TabIndex = 3;
            this.tbUhrzeit.Value = null;
            this.tbUhrzeit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // lblUhrZeit
            // 
            this.lblUhrZeit.Location = new System.Drawing.Point(0, 6);
            this.lblUhrZeit.Name = "lblUhrZeit";
            this.lblUhrZeit.Size = new System.Drawing.Size(47, 16);
            this.lblUhrZeit.TabIndex = 28;
            this.lblUhrZeit.Text = "Uhrzeit";
            // 
            // ultraLabel14
            // 
            this.ultraLabel14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ultraLabel14.Location = new System.Drawing.Point(7, 12);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(74, 16);
            this.ultraLabel14.TabIndex = 27;
            this.ultraLabel14.Text = "Startdatum";
            // 
            // dtpStart
            // 
            this.dtpStart.DateTime = new System.DateTime(2007, 3, 13, 0, 0, 0, 0);
            this.dtpStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpStart.Location = new System.Drawing.Point(82, 9);
            this.dtpStart.MaskInput = "dd.mm.yyyy";
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.ownFormat = "";
            this.dtpStart.ownMaskInput = "";
            this.dtpStart.Size = new System.Drawing.Size(101, 24);
            this.dtpStart.TabIndex = 2;
            this.dtpStart.Value = new System.DateTime(2007, 3, 13, 0, 0, 0, 0);
            this.dtpStart.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.dtpStart.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.dtpStart_BeforeDropDown);
            // 
            // pnlStartZeitpunkte
            // 
            this.pnlStartZeitpunkte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStartZeitpunkte.Controls.Add(this.cbZeitbereich);
            this.pnlStartZeitpunkte.Controls.Add(this.dtp);
            this.pnlStartZeitpunkte.Controls.Add(this.dgZP);
            this.pnlStartZeitpunkte.Location = new System.Drawing.Point(6, 38);
            this.pnlStartZeitpunkte.Name = "pnlStartZeitpunkte";
            this.pnlStartZeitpunkte.Size = new System.Drawing.Size(654, 220);
            this.pnlStartZeitpunkte.TabIndex = 28;
            // 
            // dgZP
            // 
            this.dgZP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgZP.AutoWork = true;
            this.dgZP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgZP.DataMember = "PflegePlanZeitpunkte";
            this.dgZP.DataSource = this.dsPflegePlanZeitpunkte1;
            this.dgZP.DisplayLayout.AddNewBox.Prompt = "Add ...";
            appearance3.BackColor = System.Drawing.Color.White;
            this.dgZP.DisplayLayout.Appearance = appearance3;
            this.dgZP.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 0;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.EditorComponent = this.dtp;
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 1;
            ultraGridColumn6.MaskInput = "{LOC}hh:mm";
            ultraGridColumn6.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn6.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(57, 0);
            ultraGridColumn6.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn7.EditorComponent = this.cbZeitbereich;
            ultraGridColumn7.Header.Caption = "Zeitbereich";
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 3;
            ultraGridColumn7.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn7.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn7.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(184, 0);
            ultraGridColumn7.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn7.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn7.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 2;
            ultraGridColumn8.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn8.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn8.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(223, 0);
            ultraGridColumn8.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn8.RowLayoutColumnInfo.SpanY = 2;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgZP.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgZP.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgZP.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance4.FontData.BoldAsString = "True";
            this.dgZP.DisplayLayout.CaptionAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance5.BackColor2 = System.Drawing.Color.WhiteSmoke;
            this.dgZP.DisplayLayout.GroupByBox.Appearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgZP.DisplayLayout.GroupByBox.BandLabelAppearance = appearance6;
            this.dgZP.DisplayLayout.GroupByBox.Prompt = "Gruppieren Sie hier nach belieben";
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgZP.DisplayLayout.GroupByBox.PromptAppearance = appearance7;
            this.dgZP.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;
            this.dgZP.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            appearance8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgZP.DisplayLayout.Override.CellAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgZP.DisplayLayout.Override.GroupByColumnAppearance = appearance9;
            appearance10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgZP.DisplayLayout.Override.GroupByColumnHeaderAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgZP.DisplayLayout.Override.GroupByRowAppearance = appearance11;
            appearance12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgZP.DisplayLayout.Override.HeaderAppearance = appearance12;
            this.dgZP.DisplayLayout.Override.NullText = "";
            appearance13.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgZP.DisplayLayout.Override.RowAlternateAppearance = appearance13;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgZP.DisplayLayout.Override.RowSelectorAppearance = appearance14;
            appearance15.ForeColor = System.Drawing.Color.White;
            this.dgZP.DisplayLayout.Override.SelectedRowAppearance = appearance15;
            this.dgZP.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            this.dgZP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgZP.Location = new System.Drawing.Point(1, 2);
            this.dgZP.Name = "dgZP";
            this.dgZP.Size = new System.Drawing.Size(648, 217);
            this.dgZP.TabIndex = 6;
            this.dgZP.Tag = "Dontpatch";
            this.dgZP.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgZP_CellChange);
            this.dgZP.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.dgZP_BeforeCellActivate);
            this.dgZP.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.dgZP_BeforeRowsDeleted);
            // 
            // dsPflegePlanZeitpunkte1
            // 
            this.dsPflegePlanZeitpunkte1.DataSetName = "dsPflegePlanZeitpunkte";
            this.dsPflegePlanZeitpunkte1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucPflegePlanSingleEdit21
            // 
            this.ucPflegePlanSingleEdit21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPflegePlanSingleEdit21.BackColor = System.Drawing.Color.White;
            this.ucPflegePlanSingleEdit21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ucPflegePlanSingleEdit21.Location = new System.Drawing.Point(3, 269);
            this.ucPflegePlanSingleEdit21.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucPflegePlanSingleEdit21.Name = "ucPflegePlanSingleEdit21";
            this.ucPflegePlanSingleEdit21.ReadOnly = false;
            this.ucPflegePlanSingleEdit21.Size = new System.Drawing.Size(660, 372);
            this.ucPflegePlanSingleEdit21.TabIndex = 7;
            this.ucPflegePlanSingleEdit21.TransferMode = true;
            this.ucPflegePlanSingleEdit21.ASZMValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.ucPflegePlanSingleEdit21.Load += new System.EventHandler(this.ucPflegePlanSingleEdit21_Load);
            // 
            // ucASZMTransfer2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucPflegePlanSingleEdit21);
            this.Controls.Add(this.pnlStartDatum);
            this.Name = "ucASZMTransfer2";
            this.Size = new System.Drawing.Size(668, 645);
            this.Load += new System.EventHandler(this.ucASZMTransfer2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbZeitbereich)).EndInit();
            this.pnlStartDatum.ResumeLayout(false);
            this.grbStartdatum.ResumeLayout(false);
            this.grbStartdatum.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbZeitbereichSerie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMohneZeitbezug)).EndInit();
            this.pnlFixZeit.ResumeLayout(false);
            this.pnlUhrzeit.ResumeLayout(false);
            this.pnlUhrzeit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbUhrzeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).EndInit();
            this.pnlStartZeitpunkte.ResumeLayout(false);
            this.pnlStartZeitpunkte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgZP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegePlanZeitpunkte1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel pnlStartDatum;
        private QS2.Desktop.ControlManagment.BaseGroupBoxWin grbStartdatum;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel14;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpStart;
        private QS2.Desktop.ControlManagment.BasePanel pnlStartZeitpunkte;
        public ucPflegePlanSingleEdit2 ucPflegePlanSingleEdit21;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private QS2.Desktop.ControlManagment.BasePanel pnlUhrzeit;
        private QS2.Desktop.ControlManagment.BaseLabel lblUhrZeit;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor tbUhrzeit;
        private dsPflegePlanZeitpunkte dsPflegePlanZeitpunkte1;
        private QS2.Desktop.ControlManagment.BaseGrid dgZP;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtp;
        private QS2.Desktop.ControlManagment.BasePanel pnlFixZeit;
        private PMDS.GUI.BaseControls.ZeitbereichCombo cbZeitbereich;
        private PMDS.GUI.BaseControls.ZeitbereicheZeitbereichSerienCombo cbZeitbereichSerie;
        private Infragistics.Win.Misc.UltraGridBagLayoutManager ultraGridBagLayoutManager1;
        public QS2.Desktop.ControlManagment.BaseCheckBox cbMohneZeitbezug;
    }
}
