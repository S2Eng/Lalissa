using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Text;
using Infragistics.Win.UltraWinGrid;
using PMDS.BusinessLogic.Abrechnung;
using PMDS.Abrechnung.Global;
using PMDS.Global;
using PMDS.GUI;
using Infragistics.Win;
using PMDS.BusinessLogic;
using PMDS.Global.db.Global.ds_abrechnung;
using PMDS.Global.db.Global.ds_abrechnung.ds_KostenträgerPatKostenträger;


namespace PMDS.Calc.UI.Admin
{


    public class ucKostenträgerKlient : QS2.Desktop.ControlManagment.BaseControl, ISave, IPatient, IRefresh, IReadOnly
	{
        private PMDS.Calc.Admin.DB.DBPatientKostentraeger _kost = new PMDS.Calc.Admin.DB.DBPatientKostentraeger();
        private dsPatientKostentraeger.PatientKostentraegerDataTable _dt = new dsPatientKostentraeger.PatientKostentraegerDataTable();
       

        public event EventHandler ValueChanged;
		private Guid _IDPatient = Guid.Empty;
        private bool _DataChenged = false;
        private bool _TransferKostentraegerJN = false;
        private bool _readOnly = false;

        public PMDS.UI.Sitemap.UIFct sitemap = new PMDS.UI.Sitemap.UIFct();


        private dsPatientKostentraeger dsPatientKostentraeger1;
        private QS2.Desktop.ControlManagment.BaseButton btnDel;
        private ErrorProvider errorProvider1;
        private QS2.Desktop.ControlManagment.BaseButton btnAdd;
        private QS2.Desktop.ControlManagment.BaseButton btnUpdate;
        private QS2.Desktop.ControlManagment.BaseGrid dgMain;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanelAll;
        private QS2.Desktop.ControlManagment.BasePanel panelButtonsKost;
        private QS2.Desktop.ControlManagment.BasePanel panelButtons;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucKostenträgerKlient));
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Entfernen", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Hinzufügen", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Editieren", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PatientKostentraeger", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPatient");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKostentraeger");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GueltigAb");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GueltigBis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("enumKostentraegerart");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BetragErrechnetJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Betrag");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ErfasstAm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBenutzer");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AbgerechnetBis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VorauszahlungJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RechnungJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RechnungTyp", -1, 961928108);
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
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(961928108);
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            this.btnDel = new QS2.Desktop.ControlManagment.BaseButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAdd = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnUpdate = new QS2.Desktop.ControlManagment.BaseButton();
            this.dsPatientKostentraeger1 = new PMDS.Abrechnung.Global.dsPatientKostentraeger();
            this.dgMain = new QS2.Desktop.ControlManagment.BaseGrid();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.panelButtonsKost = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelButtons = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraGridBagLayoutPanelAll = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientKostentraeger1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).BeginInit();
            this.panelButtonsKost.SuspendLayout();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanelAll)).BeginInit();
            this.ultraGridBagLayoutPanelAll.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDel
            // 
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance1;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDel.IsStandardControl = false;
            this.btnDel.Location = new System.Drawing.Point(25, 3);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(22, 21);
            this.btnDel.TabIndex = 1;
            ultraToolTipInfo3.ToolTipText = "Entfernen";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnDel, ultraToolTipInfo3);
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnAdd
            // 
            appearance16.Image = ((object)(resources.GetObject("appearance16.Image")));
            appearance16.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance16.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance16;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = false;
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(22, 21);
            this.btnAdd.TabIndex = 0;
            ultraToolTipInfo1.ToolTipText = "Hinzufügen";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnAdd, ultraToolTipInfo1);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            appearance17.Image = ((object)(resources.GetObject("appearance17.Image")));
            appearance17.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance17.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUpdate.Appearance = appearance17;
            this.btnUpdate.AutoWorkLayout = false;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUpdate.IsStandardControl = false;
            this.btnUpdate.Location = new System.Drawing.Point(47, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(22, 21);
            this.btnUpdate.TabIndex = 34;
            ultraToolTipInfo2.ToolTipText = "Editieren";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnUpdate, ultraToolTipInfo2);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dsPatientKostentraeger1
            // 
            this.dsPatientKostentraeger1.DataSetName = "dsPatientKostentraeger";
            this.dsPatientKostentraeger1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsPatientKostentraeger1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgMain
            // 
            this.dgMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMain.AutoWork = true;
            this.dgMain.DataSource = this.dsPatientKostentraeger1.PatientKostentraeger;
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance2.BorderColor = System.Drawing.Color.Black;
            this.dgMain.DisplayLayout.Appearance = appearance2;
            this.dgMain.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn3.Header.Caption = "Kostenträger";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(155, 0);
            ultraGridColumn3.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.Header.Caption = "Gültig ab";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn4.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(62, 0);
            ultraGridColumn4.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn4.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn5.Header.Caption = "Gültig bis";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(62, 0);
            ultraGridColumn5.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn6.Header.Caption = "Kostenträgerart";
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn6.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(101, 0);
            ultraGridColumn6.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn7.Header.Caption = "Restzahler";
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn7.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn7.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(90, 0);
            ultraGridColumn7.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn7.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            ultraGridColumn8.CellAppearance = appearance3;
            ultraGridColumn8.Format = "###,###,##0.00";
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.MaskInput = "{double:-9.2}";
            ultraGridColumn8.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn8.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn8.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(52, 0);
            ultraGridColumn8.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn8.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn8.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Currency;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn9.Header.Caption = "Erfasst am";
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn9.RowLayoutColumnInfo.OriginX = 14;
            ultraGridColumn9.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn9.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(60, 0);
            ultraGridColumn9.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn9.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn10.Header.Caption = "Benutzer";
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn10.RowLayoutColumnInfo.OriginX = 16;
            ultraGridColumn10.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn10.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(101, 0);
            ultraGridColumn10.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn10.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn11.Header.Caption = "Abgerechnet bis";
            ultraGridColumn11.Header.VisiblePosition = 10;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn11.RowLayoutColumnInfo.OriginX = 18;
            ultraGridColumn11.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn11.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(90, 0);
            ultraGridColumn11.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn11.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn12.Header.Caption = "Vorauszahlung";
            ultraGridColumn12.Header.VisiblePosition = 11;
            ultraGridColumn12.RowLayoutColumnInfo.OriginX = 12;
            ultraGridColumn12.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn12.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(82, 0);
            ultraGridColumn12.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn12.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn13.Header.Caption = "Rechnung J/N";
            ultraGridColumn13.Header.VisiblePosition = 12;
            ultraGridColumn13.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(60, 0);
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn14.Header.Caption = "Rechnungstyp";
            ultraGridColumn14.Header.VisiblePosition = 13;
            ultraGridColumn14.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(89, 0);
            ultraGridColumn14.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
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
            ultraGridColumn14});
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            ultraGridBand1.Override.CellButtonAppearance = appearance4;
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgMain.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgMain.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMain.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.BorderColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.GroupByBox.Appearance = appearance5;
            appearance6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgMain.DisplayLayout.GroupByBox.BandLabelAppearance = appearance6;
            this.dgMain.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMain.DisplayLayout.GroupByBox.Prompt = "Einen Spaltenkopf hier hereinziehen, um zu gruppieren.";
            appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance7.BackColor2 = System.Drawing.SystemColors.Control;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgMain.DisplayLayout.GroupByBox.PromptAppearance = appearance7;
            this.dgMain.DisplayLayout.MaxColScrollRegions = 1;
            this.dgMain.DisplayLayout.MaxRowScrollRegions = 1;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            appearance8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMain.DisplayLayout.Override.ActiveCellAppearance = appearance8;
            appearance9.BackColor = System.Drawing.SystemColors.Highlight;
            appearance9.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgMain.DisplayLayout.Override.ActiveRowAppearance = appearance9;
            this.dgMain.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMain.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.Override.CardAreaAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.White;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            appearance11.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgMain.DisplayLayout.Override.CellAppearance = appearance11;
            this.dgMain.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.dgMain.DisplayLayout.Override.CellPadding = 0;
            appearance12.BackColor = System.Drawing.SystemColors.Control;
            appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance12.BorderColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.Override.GroupByRowAppearance = appearance12;
            appearance13.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance13.TextHAlignAsString = "Left";
            this.dgMain.DisplayLayout.Override.HeaderAppearance = appearance13;
            this.dgMain.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgMain.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance14.BackColor = System.Drawing.SystemColors.Window;
            appearance14.BorderColor = System.Drawing.Color.Silver;
            this.dgMain.DisplayLayout.Override.RowAppearance = appearance14;
            this.dgMain.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.dgMain.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;
            appearance15.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgMain.DisplayLayout.Override.TemplateAddRowAppearance = appearance15;
            this.dgMain.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgMain.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgMain.DisplayLayout.ValueLists.AddRange(new Infragistics.Win.ValueList[] {
            valueList1});
            this.dgMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 5;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            this.ultraGridBagLayoutPanelAll.SetGridBagConstraint(this.dgMain, gridBagConstraint1);
            this.dgMain.Location = new System.Drawing.Point(5, 0);
            this.dgMain.Name = "dgMain";
            this.ultraGridBagLayoutPanelAll.SetPreferredSize(this.dgMain, new System.Drawing.Size(379, 152));
            this.dgMain.Size = new System.Drawing.Size(744, 162);
            this.dgMain.TabIndex = 2;
            this.dgMain.Text = "ultraGrid1";
            this.dgMain.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.dgMain_BeforeRowsDeleted);
            this.dgMain.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.dgMain_DoubleClickRow);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 0;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // panelButtonsKost
            // 
            this.panelButtonsKost.BackColor = System.Drawing.Color.Transparent;
            this.panelButtonsKost.Controls.Add(this.panelButtons);
            this.panelButtonsKost.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtonsKost.Location = new System.Drawing.Point(0, 0);
            this.panelButtonsKost.Name = "panelButtonsKost";
            this.panelButtonsKost.Size = new System.Drawing.Size(754, 27);
            this.panelButtonsKost.TabIndex = 35;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Controls.Add(this.btnUpdate);
            this.panelButtons.Controls.Add(this.btnDel);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtons.Location = new System.Drawing.Point(679, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(75, 27);
            this.panelButtons.TabIndex = 35;
            // 
            // ultraGridBagLayoutPanelAll
            // 
            this.ultraGridBagLayoutPanelAll.Controls.Add(this.dgMain);
            this.ultraGridBagLayoutPanelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanelAll.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanelAll.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanelAll.Location = new System.Drawing.Point(0, 27);
            this.ultraGridBagLayoutPanelAll.Name = "ultraGridBagLayoutPanelAll";
            this.ultraGridBagLayoutPanelAll.Size = new System.Drawing.Size(754, 167);
            this.ultraGridBagLayoutPanelAll.TabIndex = 36;
            // 
            // ucKostenträgerKlient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.ultraGridBagLayoutPanelAll);
            this.Controls.Add(this.panelButtonsKost);
            this.Name = "ucKostenträgerKlient";
            this.Size = new System.Drawing.Size(754, 194);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientKostentraeger1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).EndInit();
            this.panelButtonsKost.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanelAll)).EndInit();
            this.ultraGridBagLayoutPanelAll.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion


		public ucKostenträgerKlient()
		{
			InitializeComponent();
		}
        public void initControl()
        {
            RefreshValueLists();
        }

        public bool TransferKostentraegerJN
        {
            get { return _TransferKostentraegerJN; }
            set 
            { 
                _TransferKostentraegerJN = value;
                ShowHideColumns();
            }
        }
        public bool Save()
        {
            try
            {
                if (!ValidateFields())
                    return false;

                PMDS.GUI.UltraGridTools.EndCurrentEdit(dgMain);
                _kost.Update(_dt);

                _DataChenged = false;
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
        
        public void RefreshControl()
        {
            _DataChenged = false;
            _dt = _kost.Read(_IDPatient, TransferKostentraegerJN);
            _dt.IDKostentraegerColumn.AllowDBNull = true;
            _dt.GueltigAbColumn.AllowDBNull = true;

            dgMain.DataSource = _dt;
            dgMain.Refresh();

            if (dgMain.ActiveRow != null)
            {
                dgMain.ActiveRow.Selected = true;
            }

            Infragistics .Win.ValueList valList = new  Infragistics .Win.ValueList ();
            valList.ValueListItems.Clear();
            sitemap.fillEnumBillTyp(valList, false);

            dgMain.DisplayLayout .ValueLists.Clear ();
            dgMain.DisplayLayout .ValueLists.Add (valList);
            this.dgMain.DisplayLayout.Bands[0].Columns["RechnungTyp"].ValueList = dgMain.DisplayLayout .ValueLists[0];

            this.dgMain.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
            this.RefreshValueLists();
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

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                SetReadOnly();
            }
        }
        
        private void SetReadOnly()
        {
            btnAdd.Visible = !ReadOnly;
            btnDel.Visible = !ReadOnly;
            btnUpdate.Visible = !ReadOnly;
        }

        private void ShowHideColumns()
        {
            dgMain.DisplayLayout.Bands[0].Columns[_dt.enumKostentraegerartColumn.ColumnName].Hidden = _TransferKostentraegerJN;
            dgMain.DisplayLayout.Bands[0].Columns[_dt.BetragErrechnetJNColumn.ColumnName].Hidden = _TransferKostentraegerJN;
            dgMain.DisplayLayout.Bands[0].Columns[_dt.VorauszahlungJNColumn .ColumnName].Hidden = _TransferKostentraegerJN;
            dgMain.DisplayLayout.Bands[0].Columns[_dt.BetragColumn .ColumnName].Hidden = _TransferKostentraegerJN;
            dgMain.DisplayLayout.Bands[0].Columns[_dt.IDBenutzerColumn.ColumnName].Hidden = true;
            dgMain.DisplayLayout.Bands[0].Columns[_dt.ErfasstAmColumn.ColumnName].Hidden = true;
        }
        public bool ValidateFields()
        {
            //bool bError = false;

            //foreach (UltraGridRow row in dgMain.Rows)
            //{
            //    if (!ValidateField(row))
            //    {
            //        bError = true;
            //        break;
            //    }
            //}

            //return !bError;

            return true;
        }

        private bool ValidateField(UltraGridRow row)
        {
            //bool bError = false;

            //if (row == null || row.ListObject == null)
            //    return !bError;

            

            //DataRowView v = (DataRowView)row.ListObject;
            //dsPatientKostentraeger.PatientKostentraegerRow r = (dsPatientKostentraeger.PatientKostentraegerRow)v.Row;
            
            //r.SetColumnError(_dt.GueltigAbColumn, "");
            //r.SetColumnError(_dt.GueltigBisColumn, "");
           
            //DateTime ab = r.GueltigAb;
            //DateTime bis = r.IsGueltigBisNull() ? abrech.GueltigBis : r.GueltigBis;
            //StringBuilder sb;
            //DateTime pBis;
            //foreach (dsPatientKostentraeger.PatientKostentraegerRow pr in _dt)
            //{
            //    if (pr.RowState == DataRowState.Deleted) continue;

            //    if (pr.ID == (Guid)row.Cells[_dt.IDColumn.ColumnName].Value) continue;

            //    pBis = pr.IsGueltigBisNull() ? abrech.GueltigBis : pr.GueltigBis;
            //    sb = new StringBuilder();

            //    if (pr.IDKostentraeger != r.IDKostentraeger)
            //    {
            //        if (r.enumKostentraegerart != (int)Kostentraegerart.Periodischeleistung &&
            //            pr.enumKostentraegerart != (int)Kostentraegerart.Periodischeleistung &&
            //            r.enumKostentraegerart != (int)Kostentraegerart.Sonderleistung &&
            //            pr.enumKostentraegerart != (int)Kostentraegerart.Sonderleistung &&
            //            r.enumKostentraegerart != (int)Kostentraegerart.PeriodischeLeistung_Sonderleistung &&
            //            pr.enumKostentraegerart != (int)Kostentraegerart.PeriodischeLeistung_Sonderleistung &&
            //            r.BetragErrechnetJN && pr.BetragErrechnetJN)
            //        {
            //            sb.Append("Für der Zeitraum " + ab.ToString("dd.MM.yyyy"));

            //            if (!r.IsGueltigBisNull())
            //                sb.Append(" - " + bis.ToString("dd.MM.yyyy"));

            //            sb.Append(" existiert bereits ein Restzahler. Die Zeiten dürfen sich nicht überschneiden. Bitte ändern.");
            //            GuiUtil.ValidateField(dgMain, (bis.Date < pBis.Date || ab.Date > pBis.Date),
            //                                 sb.ToString(), ref bError, false, null);
            //        }
            //    }
            //    else
            //    {
            //        if (r.enumKostentraegerart == (int)Kostentraegerart.Periodischeleistung ||
            //            r.enumKostentraegerart == (int)Kostentraegerart.Sonderleistung ||
            //            r.enumKostentraegerart == (int)Kostentraegerart.PeriodischeLeistung_Sonderleistung
            //           )
            //        {
            //            if ((r.BetragErrechnetJN && !pr.BetragErrechnetJN) ||
            //                (!r.BetragErrechnetJN && pr.BetragErrechnetJN)
            //               )
            //            {
            //                sb.Append("Für der Zeitraum " + ab.ToString("dd.MM.yyyy"));

            //                if (!r.IsGueltigBisNull())
            //                    sb.Append(" - " + bis.ToString("dd.MM.yyyy"));

            //                sb.Append(" existiert bereits der gleiche Kostenträger. Bitte entscheiden Sie zwichen Betragerrechnet oder Betrag.");

            //                GuiUtil.ValidateField(dgMain, (bis.Date < pBis.Date || ab.Date > pBis.Date),
            //                                 sb.ToString(), ref bError, false, null);
            //            }
            //        }
            //        else
            //        {
            //            sb.Append("Für der Zeitraum " + ab.ToString("dd.MM.yyyy"));

            //            if (!r.IsGueltigBisNull())
            //                sb.Append(" - " + bis.ToString("dd.MM.yyyy"));

            //            sb.Append(" existiert bereits der gleiche Kostenträger. Die Zeiten dürfen sich nicht überschneiden. Bitte ändern.");
            //            GuiUtil.ValidateField(dgMain, (bis.Date < pBis.Date || ab.Date > pBis.Date),
            //                                 sb.ToString(), ref bError, false, null);
            //        }
            //    }

            //    if (bError)
            //    {
            //        r.SetColumnError(_dt.GueltigAbColumn, sb.ToString());

            //        if(!r.IsGueltigBisNull())
            //            r.SetColumnError(_dt.GueltigBisColumn, sb.ToString());
            //        break;
            //    }
            //}

            //return !bError;

            return true;
        }

		private void RefreshValueLists()
        {
            try
            {
                dgMain.DisplayLayout.ValueLists.Clear();
                RefreshKostentraegerValueList();
                GuiTools.AddKostentraegerArtValueList(dgMain, "enumKostentraegerart");
                PMDS.GUI.UltraGridTools.AddBenutzerValueList(dgMain, "IDBenutzer");

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void RefreshKostentraegerValueList()
        {
            try
            {
                if (dgMain.DisplayLayout.ValueLists.Exists("KST"))
                    dgMain.DisplayLayout.ValueLists.Remove("KST");
                dsPatientKostentraeger.PatientKostentraegerDataTable dt = new dsPatientKostentraeger.PatientKostentraegerDataTable();
                this.AddKostentraegerValueList(dgMain, dt.IDKostentraegerColumn.ColumnName);
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        public  void AddKostentraegerValueList(UltraGrid g, string sBoundGridColumn)
        {
            ValueListsCollection vlc = g.DisplayLayout.ValueLists;

            ValueList vl = null;
            if (vlc.Exists("KST"))
                vl = vlc["KST"];
            else
            {
                vl = vlc.Add("KST");
                PMDS.DB.Global .DBKostentraeger  k = new  PMDS.DB.Global .DBKostentraeger();
                vl.ValueListItems.Add(Guid.Empty, QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Kostenträger wählen."));
                
                foreach (dsKostentraeger.KostentraegerRow r in k.Read( true, ENV.IDKlinik))
                    vl.ValueListItems.Add(r.ID, r.Name);
            }

            UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
            c.ValueList = vl;
            c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

            if (g.ActiveCell != null && g.ActiveCell.Column.Key == sBoundGridColumn)
                g.ActiveCell.Value = g.ActiveCell.Value;
        }
        
		private void RemoveSelected() 
		{
			ArrayList al = new ArrayList();
            foreach (UltraGridRow r in dgMain.Selected.Rows)
                al.Add(r);

            if (al.Count == 0 && dgMain.ActiveRow != null && !dgMain.ActiveRow.IsFilteredOut)
                al.Add(dgMain.ActiveRow);

            UltraGridRow[] ra = (UltraGridRow[])al.ToArray(typeof(UltraGridRow));
            if (ra.Length == 0)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Zeilen ausgewählt.\r\nBitte markieren sie die zu löschenden Zeilen am linken Rand der Tabelle", "Keine Zeilen ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (PMDS.GUI.UltraGridTools.AskRowDelete() != DialogResult.Yes)
                return;
            
            dsPatientKostentraeger.PatientKostentraegerDataTable dt = new dsPatientKostentraeger.PatientKostentraegerDataTable();
            ArrayList al2 = new ArrayList();
            bool del = false;
            //PatientEinkommen pe = new PatientEinkommen();
            //dsPatientEinkommen.PatientEinkommenDataTable pedt = pe.Read(IDPatient, ENV.id);
            foreach (UltraGridRow r in ra)
            {
                        r.Delete(false);
                        del = true;
            }

            if (del)
            {
                _DataChenged = true;

                if (ValueChanged != null)
                    ValueChanged(this, null);
            }

            if (dgMain.Rows.Count > 0)
            {
                dgMain.ActiveRow = dgMain.Rows[0];
                dgMain.ActiveRow.Selected = true;
            }
            else
                dgMain.ActiveRow = null;
		}
		private void AddElement(Guid IDKostentraeger) 
		{
			dsPatientKostentraeger.PatientKostentraegerRow r = _kost.New(_dt, _IDPatient, IDKostentraeger);
            if (TransferKostentraegerJN)
                r.enumKostentraegerart = (int)Kostentraegerart.Transferleistung;

            PMDS.GUI.UltraGridTools.SelectFieldInLastRowForEdit(dgMain, "IDKostentraeger");

            frmKostenträger frm = new frmKostenträger();
            frm.mainWindow = this;
            frm.ucPatientkostentraegerEdit1.neuanlage = true;
            frm.PatientKostentraegerRow = r;
            frm.KostentraegerDataTable = _dt;

            DialogResult res = frm.ShowDialog();
            RefreshKostentraegerValueList();

            if (res == DialogResult.OK)
            {
                _DataChenged = true;

                ValidateField(dgMain.ActiveRow);

                if (ValueChanged != null)
                    ValueChanged(this, null);
            }
            else
                r.Delete();
        }
        private void UpdateElement()
        {
            if (dgMain.ActiveRow == null)
                return;

            dsPatientKostentraeger.PatientKostentraegerRow r = (dsPatientKostentraeger.PatientKostentraegerRow)PMDS.GUI.UltraGridTools.CurrentSelectedRow(dgMain);

            frmKostenträger frm = new frmKostenträger();
            frm.mainWindow = this;
            frm.PatientKostentraegerRow = r;
            frm.KostentraegerDataTable = _dt;

            DialogResult res = frm.ShowDialog();
            RefreshKostentraegerValueList();

            if (res == DialogResult.OK)
            {
                _DataChenged = true;
                ValidateField(dgMain.ActiveRow);
                if (ValueChanged != null)
                    ValueChanged(this, null);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddElement(Guid.Empty);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            RemoveSelected();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateElement();
        }

        private void dgMain_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (ReadOnly) return;
            UpdateElement();
        }

        public void setControlsAktivDisablexy(bool bOn)
        {
            //if (bOn) this.panelButtonsKost.Height = 0; else this.panelButtonsKost.Height = 27;
            //this.btnAdd.Enabled = !bOn;
            //this.btnDel.Enabled = !bOn;
            //this.btnUpdate.Enabled = !bOn;

            //this.btnAdd.Visible = !bOn;
            //this.btnDel.Visible = !bOn;
            //this.btnUpdate.Visible = !bOn;
         }

        private void dgMain_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            if (dgMain.Focused)
                e.Cancel = true;
        }

	}
}
