using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Text;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using PMDS.BusinessLogic.Abrechnung;
using PMDS.Abrechnung.Global;
using PMDS.Global;
using PMDS.GUI.BaseControls;
using PMDS.GUI;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Data.Patient;
using PMDS.Global.db.Global.ds_abrechnung;



namespace PMDS.Calc.UI.Admin
{
    public class ucTransferzahlKlientGrid : QS2.Desktop.ControlManagment.BaseControl, ISave, IPatient, IRefresh
	{

        private PMDS.Abrechnung.Global.dsPatientEinkommen.PatientEinkommenDataTable _dt = new dsPatientEinkommen.PatientEinkommenDataTable();
        private PatientEinkommen _einkommen = new PatientEinkommen();

        public event EventHandler ValueChanged;
              
        private Guid  _IDPatient = Guid.Empty;
        private bool _Transferleistung = false;
        private bool _DataChenged = false;
        private Patient _patient;
        

        private QS2.Desktop.ControlManagment.BaseGrid dgMain;
        private dsPatientEinkommen dsPatientEinkommen1;
        private ErrorProvider errorProvider1;
        private ucButton btnDel;
        private ucButton btnAdd;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private QS2.Desktop.ControlManagment.BasePanel panelOben;
        private IContainer components;





        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PatientEinkommen", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPatient");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BetragVerwendbar");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GueltigAb", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GueltigBis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TransferleistungJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SelbstzahlerJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ErfasstAm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBenutzer");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AbgerechnetBis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKostentraeger");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBankliste");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Zahlart");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RechnungJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTransferzahlKlientGrid));
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgMain = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsPatientEinkommen1 = new PMDS.Abrechnung.Global.dsPatientEinkommen();
            this.btnDel = new PMDS.GUI.ucButton(this.components);
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.panelOben = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientEinkommen1)).BeginInit();
            this.panelOben.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
            this.ultraGridBagLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dgMain
            // 
            this.dgMain.AutoWork = true;
            this.dgMain.DataSource = this.dsPatientEinkommen1.PatientEinkommen;
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance1.BorderColor = System.Drawing.Color.Black;
            this.dgMain.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(152, 0);
            ultraGridColumn3.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance2.TextHAlignAsString = "Right";
            ultraGridColumn4.CellAppearance = appearance2;
            ultraGridColumn4.Format = "###,###,##0.00";
            ultraGridColumn4.Header.Caption = "Betrag";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.MaskInput = "{double:-9.2}";
            ultraGridColumn4.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn4.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(70, 0);
            ultraGridColumn4.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn4.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Currency;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.Header.Caption = "Gültig ab";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.MaskInput = "";
            ultraGridColumn5.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(85, 0);
            ultraGridColumn5.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.Header.Caption = "Gültig bis";
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(84, 0);
            ultraGridColumn6.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.Header.Caption = "Selbstzahler";
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn8.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn8.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(69, 0);
            ultraGridColumn8.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn8.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn9.Header.Caption = "Erfasst am";
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn9.RowLayoutColumnInfo.OriginX = 14;
            ultraGridColumn9.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn9.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(77, 0);
            ultraGridColumn9.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn9.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn10.Header.Caption = "Benutzer";
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn10.RowLayoutColumnInfo.OriginX = 16;
            ultraGridColumn10.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn10.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(92, 0);
            ultraGridColumn10.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn10.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn11.Header.Caption = "Abgerechnet bis";
            ultraGridColumn11.Header.VisiblePosition = 10;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn11.RowLayoutColumnInfo.OriginX = 18;
            ultraGridColumn11.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn11.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(88, 0);
            ultraGridColumn11.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn11.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn12.Header.Caption = "Kostenträger";
            ultraGridColumn12.Header.VisiblePosition = 11;
            ultraGridColumn12.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn12.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn12.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(157, 0);
            ultraGridColumn12.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn12.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn13.Header.VisiblePosition = 12;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn14.Header.VisiblePosition = 13;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn14.RowLayoutColumnInfo.OriginX = 12;
            ultraGridColumn14.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn14.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(104, 0);
            ultraGridColumn14.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn14.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn15.Header.Caption = "Rechnung";
            ultraGridColumn15.Header.VisiblePosition = 14;
            ultraGridColumn15.RowLayoutColumnInfo.OriginX = 20;
            ultraGridColumn15.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn15.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn15.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn16.Header.Caption = "Einrichtung";
            ultraGridColumn16.Header.VisiblePosition = 15;
            ultraGridColumn16.Hidden = true;
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
            ultraGridColumn16});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgMain.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgMain.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMain.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgMain.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.dgMain.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgMain.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            this.dgMain.DisplayLayout.MaxColScrollRegions = 1;
            this.dgMain.DisplayLayout.MaxRowScrollRegions = 1;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMain.DisplayLayout.Override.ActiveCellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.SystemColors.Highlight;
            appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgMain.DisplayLayout.Override.ActiveRowAppearance = appearance7;
            this.dgMain.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMain.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgMain.DisplayLayout.Override.CellAppearance = appearance9;
            this.dgMain.DisplayLayout.Override.CellPadding = 0;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance11.TextHAlignAsString = "Left";
            this.dgMain.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.dgMain.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgMain.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            this.dgMain.DisplayLayout.Override.RowAppearance = appearance12;
            this.dgMain.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.dgMain.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgMain.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
            this.dgMain.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgMain.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 5;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.dgMain, gridBagConstraint1);
            this.dgMain.Location = new System.Drawing.Point(5, 0);
            this.dgMain.Name = "dgMain";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.dgMain, new System.Drawing.Size(309, 141));
            this.dgMain.Size = new System.Drawing.Size(630, 276);
            this.dgMain.TabIndex = 2;
            this.dgMain.Text = "ultraGrid1";
            this.dgMain.AfterRowActivate += new System.EventHandler(this.dgMain_AfterRowActivate);
            this.dgMain.AfterRowUpdate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.dgMain_AfterRowUpdate);
            this.dgMain.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgMain_CellChange);
            this.dgMain.BeforeExitEditMode += new Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventHandler(this.dgMain_BeforeExitEditMode);
            this.dgMain.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.dgMain_BeforeRowsDeleted);
            this.dgMain.Error += new Infragistics.Win.UltraWinGrid.ErrorEventHandler(this.dgMain_Error);
            // 
            // dsPatientEinkommen1
            // 
            this.dsPatientEinkommen1.DataSetName = "dsPatientEinkommen";
            this.dsPatientEinkommen1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsPatientEinkommen1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance14.BackColor = System.Drawing.Color.Transparent;
            appearance14.Image = ((object)(resources.GetObject("appearance14.Image")));
            appearance14.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance14.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance14;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDel.DoOnClick = true;
            this.btnDel.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDel.IsStandardControl = true;
            this.btnDel.Location = new System.Drawing.Point(610, 4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(23, 21);
            this.btnDel.TabIndex = 129;
            this.btnDel.TabStop = false;
            this.btnDel.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance15.BackColor = System.Drawing.Color.Transparent;
            appearance15.Image = ((object)(resources.GetObject("appearance15.Image")));
            appearance15.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance15.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance15;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(587, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 21);
            this.btnAdd.TabIndex = 128;
            this.btnAdd.TabStop = false;
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // panelOben
            // 
            this.panelOben.Controls.Add(this.btnDel);
            this.panelOben.Controls.Add(this.btnAdd);
            this.panelOben.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOben.Location = new System.Drawing.Point(0, 0);
            this.panelOben.Name = "panelOben";
            this.panelOben.Size = new System.Drawing.Size(640, 27);
            this.panelOben.TabIndex = 130;
            // 
            // ultraGridBagLayoutPanel1
            // 
            this.ultraGridBagLayoutPanel1.Controls.Add(this.dgMain);
            this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel1.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel1.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 27);
            this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
            this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(640, 281);
            this.ultraGridBagLayoutPanel1.TabIndex = 131;
            // 
            // ucTransferzahlKlientGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ultraGridBagLayoutPanel1);
            this.Controls.Add(this.panelOben);
            this.Name = "ucTransferzahlKlientGrid";
            this.Size = new System.Drawing.Size(640, 308);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientEinkommen1)).EndInit();
            this.panelOben.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
            this.ultraGridBagLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        public ucTransferzahlKlientGrid()
		{
			InitializeComponent();
		}
        public void initControl()
        {
            RefreshLists();
        }

        public bool Transferleistung
        {
            get { return _Transferleistung; }
            set
            {
                _Transferleistung = value;
                InitializeDgMain();
            }
        }

        public bool Save()
        {
            try
            {
                if (!ValidateFields())
                    return false;

                PMDS.GUI.UltraGridTools.EndCurrentEdit(dgMain);
                
                dsPatientEinkommen.PatientEinkommenRow[] peRows = (dsPatientEinkommen.PatientEinkommenRow[])_dt.Select("TransferleistungJN = 1", "", DataViewRowState.Deleted);

                foreach (dsPatientEinkommen.PatientEinkommenRow r in peRows)
                    r.RejectChanges();

                _einkommen.Update(_dt);

                foreach (dsPatientEinkommen.PatientEinkommenRow r in peRows)
                    r.Delete();
                _einkommen.Update(_dt);
                
                _DataChenged = false;
                return true;
            }
            catch (Exception e)
            {
                PMDS.Global.ENV.HandleException(e);
                return false;
            }
        }
        public void Undo()
        {
            RefreshControl();
        }

        public bool IsChanged { get { return _DataChenged; } }
        public bool ValidateFields()
        {
            bool bError = false;
            foreach (UltraGridRow row in dgMain.Rows)
            {
                if (row.IsGroupByRow || row.IsDeleted) continue;
                foreach (UltraGridCell cell in row.Cells)
                {
                    if (cell.Column.Key == "GueltigBis" && cell.Column.Hidden)
                    {
                        if (cell.Row.Cells["GueltigBis"].Value == System.DBNull.Value || (DateTime)cell.Value != (DateTime)cell.Row.Cells["GueltigAb"].Value)
                        {
                            cell.Value = cell.Row.Cells["GueltigAb"].Value;
                            if ((DateTime)cell.Value != (DateTime)cell.Row.Cells["GueltigAb"].Value)
                                throw new Exception("Gültig bis-Datum bei einmaliger Transferzahlung kann nicht gesetzt werden.");
                        }
                    }

                    if (!ValidateField(cell))
                    {
                        bError = true;
                        break;
                    }
                }

                if (bError) break;
            }

            return !bError;
        }

        public void RefreshControl()
        {
            _DataChenged = false;
            
            if (Transferleistung)
                _dt = _einkommen.ReadOnlyTransferKostentraeger(_IDPatient, ENV.IDKlinik);
            else
                _dt = _einkommen.ReadOnlyNotTransferEinkommen(_IDPatient, ENV.IDKlinik);

            _dt.BezeichnungColumn.AllowDBNull = true;
            _dt.GueltigAbColumn.AllowDBNull = true;
            _dt.BetragVerwendbarColumn.AllowDBNull = true;
            
            dgMain.DataSource = _dt;
            dgMain.Refresh();
            RefreshEinkommenList();

            RefreshKostentraegerLists();
            HideORShowKostentraeger();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDPatient
        {
            get { return _IDPatient; }
            set
            {
                _IDPatient = value;
                RefreshControl();
            }
        }
        		
        private bool ValidateField(UltraGridCell cell)
        {
            bool bError = false;

            if (cell == null || cell.Row.ListObject == null)
                return !bError;

            DataRowView v = (DataRowView)cell.Row.ListObject;
            dsPatientEinkommen.PatientEinkommenRow r = (dsPatientEinkommen.PatientEinkommenRow)v.Row;
            dsPatientEinkommen.PatientEinkommenDataTable dt = (dsPatientEinkommen.PatientEinkommenDataTable)r.Table;

            r.SetColumnError(cell.Column.Index, "");

            if (cell.Column.Key == dt.GueltigAbColumn.ColumnName)
            {
                DateTime t = new DateTime(1900, 1, 1);
                GuiUtil.ValidateField(dgMain, (DateTime.TryParse(cell.Text.Trim(), out t)),
                                     ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);
                if (bError)
                    r.SetColumnError(cell.Column.Index, ENV.String("GUI.E_NO_TEXT"));

            }
            else if (cell.Column.Key == dt.GueltigBisColumn.ColumnName &&
                     (bool)cell.Row.Cells[dt.TransferleistungJNColumn.ColumnName].Value == false
                    )
            {
                DateTime t = new DateTime(1900, 1, 1);
                //GuiUtil.ValidateField(dgMain, (DateTime.TryParse(cell.Text.Trim(), out t)),
                //                     ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);
                //if (bError)
                //    r.SetColumnError(cell.Column.Index, ENV.String("GUI.E_NO_TEXT"));

                if (cell.Value != null && cell.Value != DBNull.Value)
                    DateTime.TryParse(cell.Text.Trim(), out t);
                t = t == new DateTime(1900, 1, 1) ? abrech.GueltigBis : t;

                DateTime tGueltAb = new DateTime(1900, 1, 1);
                DateTime.TryParse(cell.Row.Cells[dt.GueltigAbColumn.ColumnName].Value.ToString(), out tGueltAb);

                if (!bError && tGueltAb != new DateTime(1900, 1, 1))
                {
                    string txt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Datum Gültig bis darf nicht vor dem ") + tGueltAb.ToString("dd.MM.yyyy") + QS2.Desktop.ControlManagment.ControlManagment.getRes(" liegen.");
                    GuiUtil.ValidateField(dgMain, tGueltAb < t, txt, ref bError, false, null);

                    if (bError)
                        r.SetColumnError(cell.Column.Index, txt);
                }
                
                //if (!bError && cell.Row.Cells[dt.AbgerechnetBisColumn.ColumnName].Value != DBNull.Value)
                //{
                //    DateTime dtAbgBis = (DateTime)cell.Row.Cells[dt.AbgerechnetBisColumn.ColumnName].Value;
                //    string txt = "Es wurde bereits bis " + dtAbgBis.ToString("dd.MM.yyyy") +
                //                 ". Das Datum Gültig bis darf nicht kleiner als " + dtAbgBis.ToString("dd.MM.yyyy");
                //    GuiUtil.ValidateField(dgMain, t >= dtAbgBis, txt, ref bError, false, null);

                //    if (bError)
                //        r.SetColumnError(cell.Column.Index, txt);
                //}
            }
            else if (cell.Column.Key == dt.BezeichnungColumn.ColumnName)
            {
                GuiUtil.ValidateField(dgMain, (cell.Text.Trim() != ""),
                                     ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);
                if (bError)
                    r.SetColumnError(cell.Column.Index, ENV.String("GUI.E_NO_TEXT"));
            }
            else if (cell.Column.Key == dt.BetragVerwendbarColumn.ColumnName)
            {
                bool valid;

                try
                {
                    if (cell.IsInEditMode)
                        valid = cell.EditorResolved.IsValid;
                    else
                        valid = !String.IsNullOrWhiteSpace(cell.Value.ToString());
                }
                catch
                {
                    valid = !String.IsNullOrWhiteSpace(cell.Value.ToString());
                }

                GuiUtil.ValidateField(dgMain, valid,
                        ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);

                if (bError)
                {
                    r.SetColumnError(cell.Column.Index, ENV.String("GUI.E_NO_TEXT"));
                }
            }
            else if (cell.Column.Key == dt.IDKostentraegerColumn.ColumnName &&
                ((bool)cell.Row.Cells[dt.TransferleistungJNColumn.ColumnName].Value == true ||
                 (bool)cell.Row.Cells[dt.SelbstzahlerJNColumn.ColumnName].Value == false
                )
               )
            {
                if (cell.ValueListResolved != null)
                {
                    GuiUtil.ValidateField(dgMain, (cell.ValueListResolved.SelectedItemIndex > 0 || (cell.ValueListResolved.SelectedItemIndex == -1 && (Guid)cell.Value != Guid.Empty)),
                                     ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);
                }
                else
                {
                    GuiUtil.ValidateField(dgMain, ((Guid)cell.Value != Guid.Empty),
                                     ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);
                }
                

                if (bError)
                    r.SetColumnError(cell.Column.Index, ENV.String("GUI.E_NO_TEXT"));
            }
            else if (cell.Column.Key == dt.ErfasstAmColumn.ColumnName)
            {
                DateTime t = new DateTime(1900, 1, 1);
                GuiUtil.ValidateField(dgMain, (DateTime.TryParse(cell.Text.Trim(), out t)),
                                     ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);
                if (bError)
                    r.SetColumnError(cell.Column.Index, ENV.String("GUI.E_NO_TEXT"));
            }

            if (bError)
            {
                dgMain.ActiveCell = cell;
                dgMain.PerformAction(UltraGridAction.EnterEditMode);
            }
            return !bError;
        }

        private void RefreshLists()
        {
            dgMain.DisplayLayout.ValueLists.Clear();
            RefreshEinkommenList();
            PMDS.GUI.UltraGridTools.AddBenutzerValueList(dgMain, "IDBenutzer");
        }

        private void RefreshEinkommenList()
        {
            if(dgMain.DisplayLayout.ValueLists.Exists("ENK"))
                dgMain.DisplayLayout.ValueLists.Remove("ENK");
            PMDS.GUI.UltraGridTools.AddTextTextValuListFromAuswahlGruppe("ENK", dgMain, "Bezeichnung");
        }

        private void RefreshKostentraegerLists()
        {
            foreach (UltraGridRow r in dgMain.Rows)
                UltraGridTools.RefreshPatientKostentraegerList(dgMain, r, _dt.IDKostentraegerColumn.ColumnName, true, true, ENV.IDKlinik);
        }

        private void HideORShowKostentraeger()
        {
            if(Transferleistung) return;

            bool hidden = true;
            foreach (UltraGridRow r in dgMain.Rows)
            {
                if (r.ListObject == null) continue;

                if ((bool)r.Cells["SelbstzahlerJN"].Value == false)
                {
                    hidden = false;
                    break;
                }
            }

            dgMain.DisplayLayout.Bands[0].Columns["IDKostentraeger"].Hidden = hidden;
        }

        private void InitializeDgMain()
        {
            dgMain.BeginUpdate();
            
            string caption = _Transferleistung ? "Für Monat" : "Gültig ab";
            string format = _Transferleistung ? "MM.yyyy" : "dd.MM.yyyy";
            string MaskInput = _Transferleistung ? "{LOC}mm/yyyy" : "{LOC}dd/mm/yyyy";

            dgMain.DisplayLayout.Bands[0].Columns["GueltigAb"].Header.Caption = caption;
            dgMain.DisplayLayout.Bands[0].Columns["GueltigAb"].EditorComponent = null;

            dgMain.DisplayLayout.Bands[0].Columns["GueltigAb"].Format = format;
            dgMain.DisplayLayout.Bands[0].Columns["GueltigAb"].MaskInput = MaskInput;

            dgMain.DisplayLayout.Bands[0].Columns["GueltigBis"].Hidden = _Transferleistung;
            dgMain.DisplayLayout.Bands[0].Columns["Bezeichnung"].Hidden = false;
            dgMain.DisplayLayout.Bands[0].Columns["BetragVerwendbar"].Hidden = false;
            dgMain.DisplayLayout.Bands[0].Columns["SelbstzahlerJN"].Hidden = true;
            dgMain.DisplayLayout.Bands[0].Columns["IDKostentraeger"].Hidden = !_Transferleistung;
            dgMain.DisplayLayout.Bands[0].Columns["RechnungJN"].Hidden = _Transferleistung;
            dgMain.Rows.ColumnFilters["TransferleistungJN"].ClearFilterConditions();
            dgMain.Rows.ColumnFilters["TransferleistungJN"].FilterConditions.Add(FilterComparisionOperator.Equals, _Transferleistung);
            dgMain.EndUpdate();
        }

        private void RemoveSelected()
        {
            ArrayList al = new ArrayList();
            foreach (UltraGridRow r in dgMain.Selected.Rows)
            {
                if(!r.Hidden)
                    al.Add(r);
            }

            if (al.Count == 0 && dgMain.ActiveRow != null && !dgMain.ActiveRow.IsFilteredOut && !dgMain.ActiveRow.Hidden)
                al.Add(dgMain.ActiveRow);

            UltraGridRow[] ra = (UltraGridRow[])al.ToArray(typeof(UltraGridRow));
            if (ra.Length == 0)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Zeilen ausgewählt.\r\nBitte markieren sie die zu löschenden Zeilen am linken Rand der Tabelle", "Keine Zeilen ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (PMDS.GUI.UltraGridTools.AskRowDelete() != DialogResult.Yes)
                return;

            dsPatientEinkommen.PatientEinkommenDataTable dt = new dsPatientEinkommen.PatientEinkommenDataTable();
            
            ArrayList al2 = new ArrayList();
            bool del = false;
            foreach (UltraGridRow r in ra)
            {
                    r.Delete(false);
                    del = true;
            }

            if (del && ValueChanged != null)
            {
                _DataChenged = true;
                ValueChanged(this, null);
            }

            ra = (UltraGridRow[])al2.ToArray(typeof(UltraGridRow));

            StringBuilder sb = new StringBuilder();
            sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Für folgende Datensätze sind Abrechnungen erstellt worden, daher können sie nicht gelöscht werden.\n\t"));

            foreach (UltraGridRow r in ra)
            {
                sb.Append("- " + r.Cells[dt.GueltigAbColumn.ColumnName].Text);
                if(!_Transferleistung && r.Cells[dt.GueltigBisColumn.ColumnName].Value != DBNull.Value)
                    sb.Append(" - " + r.Cells[dt.GueltigBisColumn.ColumnName].Text);

                sb.Append("- " + r.Cells[dt.BezeichnungColumn.ColumnName].Text);
                sb.Append(" - " + r.Cells[dt.BetragVerwendbarColumn.ColumnName].Text + " €\n\t");
            }
            if (ra.Length > 0)
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sb.ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Löschen"), MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (dgMain.Rows.Count > 0)
            {
                dgMain.ActiveRow = dgMain.Rows[0];
                dgMain.ActiveRow.Selected = true;
            }
            else
                dgMain.ActiveRow = null;

            //Spalte Kostenträger anzeigen oder verstecken
            HideORShowKostentraeger();
        }

        private void dgMain_AfterRowUpdate(object sender, RowEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.SortIndicator sort = dgMain.DisplayLayout.Bands[0].Columns["GueltigAb"].SortIndicator;
            dgMain.DisplayLayout.Bands[0].Columns["GueltigAb"].SortIndicator = sort; 
        }

        private void dgMain_CellChange(object sender, CellEventArgs e)
        {
            _DataChenged = true;
            if (ValueChanged != null)
                ValueChanged(this, e);

            if (e.Cell.Column.Key == _dt.SelbstzahlerJNColumn.ColumnName)
            {
                if(!Transferleistung)
                {
                    bool hidden = true;
                    foreach (UltraGridRow r in dgMain.Rows)
                    {
                        if (r.ListObject == null) continue;

                        if (r.Cells["SelbstzahlerJN"] != e.Cell && (bool)r.Cells["SelbstzahlerJN"].Value == false)
                        {
                            hidden = false;
                            break;
                        }
                    }

                    bool hide = (e.Cell.EditorResolved.IsInEditMode) ? (bool)e.Cell.EditorResolved.Value : (bool)e.Cell.Value;

                    if (hide)
                        e.Cell.Row.Cells[_dt.IDKostentraegerColumn.ColumnName].Value = DBNull.Value;
                    else
                    {
                        UltraGridTools.RefreshPatientKostentraegerList(dgMain, e.Cell.Row, _dt.IDKostentraegerColumn.ColumnName, true, true, ENV.IDKlinik);
                        e.Cell.Row.Cells[_dt.IDKostentraegerColumn.ColumnName].Value = Guid.Empty;
                    }
                    
                    e.Cell.Row.Cells[_dt.IDKostentraegerColumn.ColumnName].Activation = hide ? Activation.NoEdit : Activation.AllowEdit;
                    if (!hidden) return;
                    dgMain.DisplayLayout.Bands[0].Columns[_dt.IDKostentraegerColumn.ColumnName].Hidden = hide;
                }
            }
        }

        private void dgMain_BeforeExitEditMode(object sender, Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs e)
        {
            try
            {
                if (dgMain.ActiveCell != null &&
                    (dgMain.ActiveCell.Column.Key == _dt.GueltigAbColumn.ColumnName ||
                     dgMain.ActiveCell.Column.Key == _dt.GueltigBisColumn.ColumnName ||
                     dgMain.ActiveCell.Column.Key == _dt.ErfasstAmColumn.ColumnName) && !dgMain.ActiveCell.EditorResolved.IsValid)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bitte ein gültiges Datum eingeben.");
                    dgMain.ActiveCell.Value = DBNull.Value;
                    e.Cancel = true;
                    dgMain.Select();
                    dgMain.ActiveCell.Selected = true;
                    dgMain.ActiveCell.Activate();
                    dgMain.Focus();
                    dgMain.PerformAction(UltraGridAction.EnterEditMode);
                    return;
                }
    
                DataRowView v = (DataRowView)dgMain.ActiveCell.Row.ListObject;
                dsPatientEinkommen.PatientEinkommenRow r = (dsPatientEinkommen.PatientEinkommenRow)v.Row;
                r.SetColumnError(dgMain.ActiveCell.Column.Index, "");

                if (dgMain.ActiveCell.Column.Key == _dt.GueltigAbColumn.ColumnName || dgMain.ActiveCell.Column.Key == _dt.GueltigBisColumn.ColumnName)
                {
                    UltraGridTools.RefreshPatientKostentraegerList(dgMain, dgMain.ActiveRow, _dt.IDKostentraegerColumn.ColumnName, true, true, ENV.IDKlinik);

                    bool SelbstzahlerJN = dgMain.ActiveRow.Cells["SelbstzahlerJN"].EditorResolved.IsInEditMode ? (bool)dgMain.ActiveRow.Cells["SelbstzahlerJN"].EditorResolved.Value : (bool)dgMain.ActiveRow.Cells["SelbstzahlerJN"].Value;
                    if (!SelbstzahlerJN && dgMain.DisplayLayout.ValueLists.Exists("KST_" + dgMain.ActiveRow.Cells["ID"].Value.ToString()) && dgMain.DisplayLayout.ValueLists["KST_" + dgMain.ActiveRow.Cells["ID"].Value.ToString()].ValueListItems.Count == 1)
                    {
                        DateTime gueltigAb = (dgMain.ActiveCell.EditorResolved.IsInEditMode) ? (DateTime)dgMain.ActiveCell.EditorResolved.Value : (DateTime)dgMain.ActiveCell.Value;
                        string txt = "Für den Zeitraum {0} sind keine Transfer Kostenträger zugeordnet. Bitte TransferKostenträger zuordnen oder Zeitraum ändern.";
                        txt = QS2.Desktop.ControlManagment.ControlManagment.getRes(txt, gueltigAb.ToString("dd.MM.yyyy"));

                        r.SetColumnError(dgMain.ActiveCell.Column.Index, txt);
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txt, true);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void dgMain_AfterRowActivate(object sender, EventArgs e)
        {
            foreach (UltraGridCell cell in dgMain.ActiveRow.Cells)
            {
                cell.Activation = Activation.AllowEdit;
                if (cell.Column.Key == _dt.RechnungJNColumn.ColumnName || (!Transferleistung && cell.Column.Key == _dt.GueltigBisColumn.ColumnName))
                    cell.Activation = Activation.AllowEdit;
            }
        }


        private void dgMain_Error(object sender, ErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            RemoveSelected();
        }
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            _einkommen.New(_dt, _IDPatient, _Transferleistung, ENV.IDKlinik);
            PMDS.GUI.UltraGridTools.SelectFieldInLastRowForEdit(dgMain, _dt.GueltigAbColumn.ColumnName);

            UltraGridTools.RefreshPatientKostentraegerList(dgMain, dgMain.ActiveRow, _dt.IDKostentraegerColumn.ColumnName, true, true, ENV.IDKlinik);
            if (_Transferleistung && dgMain.ActiveCell.Column.Key == _dt.GueltigAbColumn.ColumnName)
            {
                DateTime t = (DateTime)dgMain.ActiveCell.Value;
                if (dgMain.ActiveCell.EditorComponentResolved != null)
                    dgMain.ActiveCell.EditorControlResolved.Text = t.ToString("MM.yyyy");
            }

            if (!Transferleistung)
            {
                dgMain.DisplayLayout.Bands[0].Columns[_dt.IDKostentraegerColumn.ColumnName].Hidden = (bool)dgMain.ActiveRow.Cells[_dt.SelbstzahlerJNColumn.ColumnName].Value;
            }

            _DataChenged = true;
            if (ValueChanged != null)
                ValueChanged(this, e);
        }

        private void dgMain_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            if (dgMain.Focused)
                e.Cancel = true;
        }
 	}
}
