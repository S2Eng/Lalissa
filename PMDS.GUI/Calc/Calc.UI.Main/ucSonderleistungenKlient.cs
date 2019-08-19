using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using PMDS.BusinessLogic.Abrechnung;
using PMDS.Abrechnung.Global;
using PMDS.Global;
using PMDS.GUI;
using PMDS.BusinessLogic;
using PMDS.Data.Patient;





namespace PMDS.Calc.UI.Admin
{


    public class ucSonderleistungenKlient : QS2.Desktop.ControlManagment.BaseControl, ISave, IPatient, IRefresh
	{
             
		
        private  PatientSonderleistung									_sonderleistungen = new PatientSonderleistung();
		private dsPatientSonderleistung.PatientSonderleistungDataTable	_dt = new dsPatientSonderleistung.PatientSonderleistungDataTable();


        public event EventHandler ValueChanged;
        private Guid _IDPatient = Guid.Empty;
        private bool _DataChenged = false;

        private Patient _patient;
        

        private QS2.Desktop.ControlManagment.BaseGrid dgMain;
        private PMDS.Abrechnung.Global.dsPatientSonderleistung dsPatientSonderleistung1;
        private ErrorProvider errorProvider1;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private QS2.Desktop.ControlManagment.BasePanel panelTop;
        private ucButton btnDel;
        private ucButton btnAdd;
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PatientSonderleistung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPatient");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Anzahl");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Betrag");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MWST");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Datum");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AbgerechnetJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSonderleistungskatalog");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Belegnummer");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("JahrAbrechnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MonatAbrechnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EinzelPreis");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("datumVerrech");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
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
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSonderleistungenKlient));
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            this.dgMain = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsPatientSonderleistung1 = new PMDS.Abrechnung.Global.dsPatientSonderleistung();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelTop = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnDel = new PMDS.GUI.ucButton(this.components);
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientSonderleistung1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
            this.ultraGridBagLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgMain
            // 
            this.dgMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMain.AutoWork = true;
            this.dgMain.DataSource = this.dsPatientSonderleistung1.PatientSonderleistung;
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance1.BorderColor = System.Drawing.Color.Black;
            this.dgMain.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn3.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(183, 0);
            ultraGridColumn3.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.Header.Caption = "Menge";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn4.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(74, 0);
            ultraGridColumn4.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn4.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer;
            ultraGridColumn4.Width = 50;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance2.TextHAlignAsString = "Right";
            ultraGridColumn5.CellAppearance = appearance2;
            ultraGridColumn5.Format = "###,###,##0.00";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.MaskInput = "{double:-9.2}";
            ultraGridColumn5.MinValue = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            ultraGridColumn5.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(95, 0);
            ultraGridColumn5.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Currency;
            ultraGridColumn5.Width = 70;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn6.Header.Caption = "MWSt";
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.RowLayoutColumnInfo.OriginX = 12;
            ultraGridColumn6.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(69, 0);
            ultraGridColumn6.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer;
            ultraGridColumn6.Width = 60;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn7.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn7.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(86, 0);
            ultraGridColumn7.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn7.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn8.Header.Caption = "Abgerechnet";
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn8.RowLayoutColumnInfo.OriginX = 15;
            ultraGridColumn8.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn8.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(74, 0);
            ultraGridColumn8.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn8.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn9.Header.Caption = "Bezeichnung";
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn9.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn9.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn9.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(213, 0);
            ultraGridColumn9.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn9.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn10.RowLayoutColumnInfo.OriginX = 14;
            ultraGridColumn10.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn10.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(93, 0);
            ultraGridColumn10.RowLayoutColumnInfo.SpanX = 3;
            ultraGridColumn10.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn11.Header.VisiblePosition = 10;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn12.Header.VisiblePosition = 11;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            appearance3.TextHAlignAsString = "Right";
            ultraGridColumn13.CellAppearance = appearance3;
            ultraGridColumn13.Format = "###,###,##0.00";
            ultraGridColumn13.Header.Caption = "Einzelpreis";
            ultraGridColumn13.Header.VisiblePosition = 12;
            ultraGridColumn13.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn13.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn13.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(94, 0);
            ultraGridColumn13.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn13.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn13.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Currency;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn14.Format = "MM.yyyy";
            ultraGridColumn14.Header.Caption = "Abrechnungsmonat";
            ultraGridColumn14.Header.VisiblePosition = 13;
            ultraGridColumn14.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn14.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn14.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(106, 0);
            ultraGridColumn14.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn14.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn15.Header.VisiblePosition = 14;
            ultraGridColumn15.Hidden = true;
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
            ultraGridColumn15});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgMain.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgMain.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMain.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.BorderColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.GroupByBox.Appearance = appearance4;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgMain.DisplayLayout.GroupByBox.BandLabelAppearance = appearance5;
            this.dgMain.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance6.BackColor2 = System.Drawing.SystemColors.Control;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgMain.DisplayLayout.GroupByBox.PromptAppearance = appearance6;
            this.dgMain.DisplayLayout.MaxColScrollRegions = 1;
            this.dgMain.DisplayLayout.MaxRowScrollRegions = 1;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            appearance7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMain.DisplayLayout.Override.ActiveCellAppearance = appearance7;
            appearance8.BackColor = System.Drawing.SystemColors.Highlight;
            appearance8.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgMain.DisplayLayout.Override.ActiveRowAppearance = appearance8;
            this.dgMain.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMain.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.Override.CardAreaAppearance = appearance9;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgMain.DisplayLayout.Override.CellAppearance = appearance10;
            this.dgMain.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.dgMain.DisplayLayout.Override.CellPadding = 0;
            appearance11.BackColor = System.Drawing.SystemColors.Control;
            appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance11.BorderColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.Override.GroupByRowAppearance = appearance11;
            appearance12.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance12.TextHAlignAsString = "Left";
            this.dgMain.DisplayLayout.Override.HeaderAppearance = appearance12;
            this.dgMain.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgMain.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.BorderColor = System.Drawing.Color.Silver;
            this.dgMain.DisplayLayout.Override.RowAppearance = appearance13;
            this.dgMain.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.dgMain.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            appearance14.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgMain.DisplayLayout.Override.TemplateAddRowAppearance = appearance14;
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
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.dgMain, new System.Drawing.Size(295, 150));
            this.dgMain.Size = new System.Drawing.Size(778, 285);
            this.dgMain.TabIndex = 2;
            this.dgMain.Text = "ultraGrid1";
            this.dgMain.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgMain_AfterCellUpdate);
            this.dgMain.AfterRowActivate += new System.EventHandler(this.dgMain_AfterRowActivate);
            this.dgMain.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgMain_CellChange);
            this.dgMain.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.dgMain_BeforeCellActivate);
            this.dgMain.BeforeExitEditMode += new Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventHandler(this.dgMain_BeforeExitEditMode);
            this.dgMain.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.dgMain_BeforeRowsDeleted);
            this.dgMain.Error += new Infragistics.Win.UltraWinGrid.ErrorEventHandler(this.dgMain_Error);
            // 
            // dsPatientSonderleistung1
            // 
            this.dsPatientSonderleistung1.DataSetName = "dsPatientSonderleistung";
            this.dsPatientSonderleistung1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsPatientSonderleistung1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnDel);
            this.panelTop.Controls.Add(this.btnAdd);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(788, 28);
            this.panelTop.TabIndex = 7;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance15.BackColor = System.Drawing.Color.Transparent;
            appearance15.Image = ((object)(resources.GetObject("appearance15.Image")));
            appearance15.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance15.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance15;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDel.DoOnClick = true;
            this.btnDel.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDel.IsStandardControl = true;
            this.btnDel.Location = new System.Drawing.Point(760, 5);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(23, 21);
            this.btnDel.TabIndex = 14;
            this.btnDel.TabStop = false;
            this.btnDel.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance16.BackColor = System.Drawing.Color.Transparent;
            appearance16.Image = ((object)(resources.GetObject("appearance16.Image")));
            appearance16.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance16.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance16;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(737, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 21);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.TabStop = false;
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ultraGridBagLayoutPanel1
            // 
            this.ultraGridBagLayoutPanel1.Controls.Add(this.dgMain);
            this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel1.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel1.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
            this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(788, 290);
            this.ultraGridBagLayoutPanel1.TabIndex = 8;
            // 
            // ucSonderleistungenKlient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ultraGridBagLayoutPanel1);
            this.Controls.Add(this.panelTop);
            this.Name = "ucSonderleistungenKlient";
            this.Size = new System.Drawing.Size(788, 318);
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientSonderleistung1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
            this.ultraGridBagLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        public ucSonderleistungenKlient()
		{
			InitializeComponent();
		}

        public bool Save()
        {
            try
            {
                if (!ValidateFields())
                    return false;

                PMDS.GUI.UltraGridTools.EndCurrentEdit(dgMain);
                _sonderleistungen.Update(_dt);
                _DataChenged = false;
                this.dgMain.DisplayLayout.Bands[0].SortedColumns.Clear();
                this.dgMain.DisplayLayout.Bands[0].SortedColumns.Add("Datum", false);
                return true;
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
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
                if (row.Hidden) continue;
                foreach (UltraGridCell cell in row.Cells)
                {
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
            _dt = _sonderleistungen.Readxy(_IDPatient, ENV.IDKlinik);
            _dt.DatumColumn.AllowDBNull = true;
            _dt.IDSonderleistungskatalogColumn.AllowDBNull = true;
            _dt.BetragColumn.AllowDBNull = true;
            _dt.AnzahlColumn.AllowDBNull = true;
            _dt.MWSTColumn.AllowDBNull = true;
            dgMain.DataSource = _dt;
            dgMain.Refresh();

            this.dgMain.DisplayLayout.Bands[0].SortedColumns.Clear();
            this.dgMain.DisplayLayout.Bands[0].SortedColumns.Add("Datum", false);

            RefreshSonderleistungen();
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
        
		private bool ValidateRow(UltraGridRow r)
        {
            bool bError = false;

            if (r == null || r.ListObject == null)
                return !bError;

            foreach (UltraGridCell cell in r.Cells)
            {
                if (!ValidateField(cell))
                {
                    bError = true;
                    break;
                }
            }

            return !bError;
        }

        private bool ValidateField(UltraGridCell cell)
        {
            bool bError = false;

            if (cell == null || cell.Row.ListObject == null)
                return !bError;

            DataRowView v = (DataRowView)cell.Row.ListObject;
            dsPatientSonderleistung.PatientSonderleistungRow r = (dsPatientSonderleistung.PatientSonderleistungRow)v.Row;
            dsPatientSonderleistung.PatientSonderleistungDataTable dt = (dsPatientSonderleistung.PatientSonderleistungDataTable)r.Table;

            r.SetColumnError(cell.Column.Index, "");
           
            if (cell.Column.Key == dt.DatumColumn.ColumnName)
            {
                DateTime t = new DateTime(1900, 1, 1);
                GuiUtil.ValidateField(dgMain, (DateTime.TryParse(cell.Text.Trim(), out t)),
                                     ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);
                if (bError)
                    r.SetColumnError(cell.Column.Index, ENV.String("GUI.E_NO_TEXT"));
            }
            else if (cell.Column.Key == dt.IDSonderleistungskatalogColumn.ColumnName)
            {
                GuiUtil.ValidateField(dgMain, (cell.ValueListResolved.SelectedItemIndex > 0 || (cell.ValueListResolved.SelectedItemIndex == -1 && cell.Value != DBNull.Value && (Guid)cell.Value != Guid.Empty)),
                                     ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);
                if (bError)
                    r.SetColumnError(cell.Column.Index, ENV.String("GUI.E_NO_TEXT"));
            }
            else if (cell.Column.Key == dt.datumVerrechColumn.ColumnName)
            {
                GuiUtil.ValidateField(dgMain, cell.Value != DBNull.Value ,
                                     ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);
                if (bError)
                    r.SetColumnError(cell.Column.Index, ENV.String("GUI.E_NO_TEXT"));
            }
            else if (cell.Column.Key == dt.AnzahlColumn.ColumnName ||
                     cell.Column.Key == dt.BetragColumn.ColumnName ||
                     cell.Column.Key == dt.MWSTColumn.ColumnName
                    )
            {
                bool valid;
                
                try
                {
                    valid = cell.EditorResolved.IsValid;
                }
                catch
                {
                    valid = cell.Value.ToString().Trim() != "";
                }
                
                GuiUtil.ValidateField(dgMain, valid,
                        ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);

                if (bError)
                {
                    r.SetColumnError(cell.Column.Index, ENV.String("GUI.E_NO_TEXT"));
                }
            }

            if (bError)
            {
                dgMain.ActiveCell = cell;
                dgMain.PerformAction(UltraGridAction.EnterEditMode);
            }

            return !bError;
        }
        private dsPatientSonderleistung.PatientSonderleistungRow CurrentSelectedRow()
        {
            if (PMDS.GUI.UltraGridTools.CurrentSelectedRow(dgMain) == null)
                return null;

            return (dsPatientSonderleistung.PatientSonderleistungRow)PMDS.GUI.UltraGridTools.CurrentSelectedRow(dgMain);
        }
        
        private void RefreshSonderleistungen()
        {
            dgMain.DisplayLayout.ValueLists.Clear();
            dsPatientSonderleistung.PatientSonderleistungDataTable dt = new dsPatientSonderleistung.PatientSonderleistungDataTable();
            UltraGridTools.AddSonderleistungsKatalogValueList(dgMain, dt.IDSonderleistungskatalogColumn.ColumnName, ENV.IDKlinik);
        }

	    private UltraGridRow[] GetDelRows()
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
            return ra;
        }

        private bool AskForDelete()
        {
            UltraGridRow[] ra = GetDelRows();

            if (ra.Length == 0)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Zeilen ausgewählt.\r\nBitte markieren sie die zu löschenden Zeilen am linken Rand der Tabelle", "Keine Zeilen ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (PMDS.GUI.UltraGridTools.AskRowDelete() != DialogResult.Yes)
                return false;

            Cursor = Cursors.Default;
            return true;
        }
        private void RemoveSelected()
        {
            if (!AskForDelete())
                return;

            UltraGridRow[] ra = GetDelRows();

            foreach (UltraGridRow r in ra)
                r.Delete(false);
            
            _DataChenged = true;
            ValueChanged(this, null);

            if (dgMain.Rows.Count > 0)
            {
                dgMain.ActiveRow = dgMain.Rows[0];
                dgMain.ActiveRow.Selected = true;
            }
            else
                dgMain.ActiveRow = null;
        }

		private   dsPatientSonderleistung.PatientSonderleistungRow  AddElement(Guid IDSonderleistungsKatalog) 
		{
            dsPatientSonderleistung.PatientSonderleistungRow r = _sonderleistungen.New(_dt, _IDPatient, IDSonderleistungsKatalog, "");
            r.IDSonderleistungskatalog = IDSonderleistungsKatalog;
            PMDS.GUI.UltraGridTools.SelectFieldInLastRowForEdit(dgMain, "IDSonderleistungsKatalog");
            _DataChenged = true;

            if (ValueChanged != null)
                ValueChanged(this, null);

            return r;
        }

        private void dgMain_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell.Value == null)
                return;

            dsPatientSonderleistung.PatientSonderleistungRow row = CurrentSelectedRow();
            if (row == null)
                return;

            SonderleistungsKatalog k = new SonderleistungsKatalog();
            dsSonderleistungsKatalog.SonderleistungsKatalogRow r = null;
            this.dgMain.UpdateData();

            Guid IDSonderleistungskatalog = Guid.Empty;
            if (e.Cell.Row.Cells["IDSonderleistungskatalog"].Value != DBNull.Value)
                IDSonderleistungskatalog = (Guid)e.Cell.Row.Cells["IDSonderleistungskatalog"].Value;
            
            if (IDSonderleistungskatalog != Guid.Empty)
                r = k.ReadByID(IDSonderleistungskatalog);

            row.MWST = r.Mwst;

            if (r == null)
                return;

            double EinzelPreis = 0;
            int Anzahl = 0;
            
            if (e.Cell.Column.Key == "IDSonderleistungskatalog")
            {
                row.EinzelPreis = r.Betrag;
                row.Betrag = System.Convert.ToDecimal(row.Anzahl * r.Betrag);
            }
            else if (e.Cell.Column.Key == "Anzahl" || e.Cell.Column.Key == "EinzelPreis")
            {
                Anzahl = (e.Cell.Row.Cells["Anzahl"].Value.ToString().Trim() == "") ? 0 : (int)e.Cell.Row.Cells["Anzahl"].Value;
                EinzelPreis = row.IsEinzelPreisNull() ? 0 : row.EinzelPreis;
                row.Betrag = System.Convert.ToDecimal(Anzahl * EinzelPreis);
            }
        }

        private void dgMain_CellChange(object sender, CellEventArgs e)
        {
            DataRowView v = (DataRowView)e.Cell.Row.ListObject;
            dsPatientSonderleistung.PatientSonderleistungRow r = (dsPatientSonderleistung.PatientSonderleistungRow)v.Row;
            dsPatientSonderleistung.PatientSonderleistungDataTable dt = (dsPatientSonderleistung.PatientSonderleistungDataTable)r.Table;

            if (e.Cell.Column.Key == dt.IDSonderleistungskatalogColumn.ColumnName)
            {
                e.Cell.Row.Cells[dt.BezeichnungColumn.ColumnName].Value = (Guid)e.Cell.EditorResolved.Value != Guid.Empty ? e.Cell.Text.Trim() : "";
            }

            _DataChenged = true;
            if (ValueChanged != null)
                ValueChanged(this, null);

        }

        private void dgMain_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            ////Wenn der Hacken abgerechnet bei eine Zeile gesetzt ist, darf die Zeile nicht mehr editierbart sein.
            //DataRowView v = (DataRowView)e.Cell.Row.ListObject;
            //dsPatientSonderleistung.PatientSonderleistungRow r = (dsPatientSonderleistung.PatientSonderleistungRow)v.Row;
            //dsPatientSonderleistung.PatientSonderleistungDataTable dt = (dsPatientSonderleistung.PatientSonderleistungDataTable)r.Table;

            //if (e.Cell.Column.Key != dt.BetragColumn.ColumnName && e.Cell.Column.Key != dt.AbgerechnetJNColumn.ColumnName)
            //{
            //    e.Cancel = (bool)e.Cell.Row.Cells[dt.AbgerechnetJNColumn.ColumnName].Value == true;
            //    dgMain.Refresh();
            //}
        }

        private void dgMain_BeforeExitEditMode(object sender, BeforeExitEditModeEventArgs e)
        {
            if (dgMain.ActiveCell != null && (dgMain.ActiveCell.Column.Key == "Datum") && !dgMain.ActiveCell.EditorResolved.IsValid)
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

            Cursor = Cursors.WaitCursor;
            Cursor = Cursors.Default;
            dgMain.PerformAction(UltraGridAction.ExitEditMode);
        }

        private void dgMain_AfterRowActivate(object sender, EventArgs e)
        {
            dgMain.ActiveRow.Selected = true;
        }

        private void dgMain_Error(object sender, ErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dsPatientSonderleistung.PatientSonderleistungRow r = AddElement(Guid.Empty);
            r.IDKlinik = ENV.IDKlinik;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            RemoveSelected();
        }

        private void dgMain_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            if (dgMain.Focused)
                e.Cancel = true;
        }


	}
}
