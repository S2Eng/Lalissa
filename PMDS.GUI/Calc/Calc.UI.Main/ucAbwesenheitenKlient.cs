using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using PMDS.BusinessLogic.Abrechnung;
using PMDS.Abrechnung.Global;
using PMDS.GUI;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.Patient;



namespace PMDS.Calc.UI.Admin
{


    public class ucAbwesenheitenKlient : QS2.Desktop.ControlManagment.BaseControl
	{


        private dsPatientAbwesenheit.PatientAbwesenheitDataTable _dt = new dsPatientAbwesenheit.PatientAbwesenheitDataTable();
        private PMDS.Calc.Admin.DB.DBPatientAbwesenheit dbAbw  = new PMDS.Calc.Admin.DB.DBPatientAbwesenheit();

        private abwÜbersp.abwÜberspSitemap abwÜberspSitemap = new abwÜbersp.abwÜberspSitemap();
        public PMDS.UI.Sitemap.UIFct sitemap = new PMDS.UI.Sitemap.UIFct();

        public event EventHandler ValueChanged;
		private Guid _IDPatient = Guid.Empty;
        private bool _DataChenged = false;
        private bool abwHändBerech = false;



        private QS2.Desktop.ControlManagment.BaseGrid dgMain;
        private PMDS.Abrechnung.Global.dsPatientAbwesenheit dsPatientAbwesenheit1;
        private ErrorProvider errorProvider1;
        private QS2.Desktop.ControlManagment.BaseLabel lblWirdHändischBerechnet;
        private ucButton btnDel;
        private ucButton btnAdd;
        private QS2.Desktop.ControlManagment.BasePanel panel1;
        private QS2.Desktop.ControlManagment.BasePanel panelTop;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private QS2.Desktop.ControlManagment.BaseComboEditor cboGrund;
        public GUI.BaseControls.ucKlinikDropDown ucKlinikDropDown1;
        private IContainer components;






        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAbwesenheitenKlient));
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PatientAbwesenheit", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPatient");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Von");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BetrifftPflegegeldJN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("abTagN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Grund");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ErfasstAm");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBenutzer");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AbgerechnetBis");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDÜber");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Übersp");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik", -1, "dropDownKliniken");
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
            this.cboGrund = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDel = new PMDS.GUI.ucButton(this.components);
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.lblWirdHändischBerechnet = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dgMain = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsPatientAbwesenheit1 = new PMDS.Abrechnung.Global.dsPatientAbwesenheit();
            this.panelTop = new QS2.Desktop.ControlManagment.BasePanel();
            this.ucKlinikDropDown1 = new PMDS.GUI.BaseControls.ucKlinikDropDown();
            this.panel1 = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cboGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientAbwesenheit1)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
            this.ultraGridBagLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboGrund
            // 
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            editorButton1.Appearance = appearance1;
            this.cboGrund.ButtonsRight.Add(editorButton1);
            this.cboGrund.Location = new System.Drawing.Point(560, 6);
            this.cboGrund.Name = "cboGrund";
            this.cboGrund.Size = new System.Drawing.Size(108, 21);
            this.cboGrund.TabIndex = 157;
            this.cboGrund.Visible = false;
            this.cboGrund.ValueChanged += new System.EventHandler(this.cboGrund_ValueChanged);
            this.cboGrund.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.cboGrund_EditorButtonClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance16.BackColor = System.Drawing.Color.Transparent;
            appearance16.Image = ((object)(resources.GetObject("appearance16.Image")));
            appearance16.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance16.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance16;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDel.DoOnClick = true;
            this.btnDel.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDel.IsStandardControl = true;
            this.btnDel.Location = new System.Drawing.Point(731, 7);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(23, 21);
            this.btnDel.TabIndex = 127;
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
            this.btnAdd.Location = new System.Drawing.Point(708, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 21);
            this.btnAdd.TabIndex = 126;
            this.btnAdd.TabStop = false;
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblWirdHändischBerechnet
            // 
            appearance14.ForeColor = System.Drawing.Color.DarkRed;
            this.lblWirdHändischBerechnet.Appearance = appearance14;
            this.lblWirdHändischBerechnet.AutoSize = true;
            this.lblWirdHändischBerechnet.Location = new System.Drawing.Point(5, 13);
            this.lblWirdHändischBerechnet.Name = "lblWirdHändischBerechnet";
            this.lblWirdHändischBerechnet.Size = new System.Drawing.Size(430, 14);
            this.lblWirdHändischBerechnet.TabIndex = 125;
            this.lblWirdHändischBerechnet.Text = "Abwesenheiten werden händisch berechnet, bitte erfassen Sie manuelle Buchungen.";
            this.lblWirdHändischBerechnet.Visible = false;
            // 
            // dgMain
            // 
            this.dgMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMain.AutoWork = true;
            this.dgMain.DataSource = this.dsPatientAbwesenheit1.PatientAbwesenheit;
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance2.BackColorDisabled = System.Drawing.Color.White;
            appearance2.BackColorDisabled2 = System.Drawing.Color.WhiteSmoke;
            appearance2.BorderColor = System.Drawing.Color.Black;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.dgMain.DisplayLayout.Appearance = appearance2;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(94, 0);
            ultraGridColumn3.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn3.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn4.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(89, 0);
            ultraGridColumn4.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn4.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.Header.Caption = "Kürzung Grundlstg.";
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn5.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn5.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(116, 0);
            ultraGridColumn5.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn5.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.Header.Caption = "Tage ohne Reduzierung";
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.ToolTipText = "Anzahl der Tage nach Beginn der Abwesenheit, an denen keine Kürzung der Grundleis" +
    "tung erfolgt!";
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.RowLayoutColumnInfo.OriginX = 8;
            ultraGridColumn6.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(107, 0);
            ultraGridColumn6.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn6.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn7.EditorComponent = this.cboGrund;
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn7.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn7.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(166, 0);
            ultraGridColumn7.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn7.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn7.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.Header.Caption = "Erfasst am";
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.RowLayoutColumnInfo.OriginX = 10;
            ultraGridColumn8.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn8.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(86, 0);
            ultraGridColumn8.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn8.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn9.Header.Caption = "Benutzer";
            ultraGridColumn9.Header.Editor = null;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn9.RowLayoutColumnInfo.OriginX = 12;
            ultraGridColumn9.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn9.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(98, 0);
            ultraGridColumn9.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn9.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn10.Header.Caption = "Abgerechnet bis";
            ultraGridColumn10.Header.Editor = null;
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn10.RowLayoutColumnInfo.OriginX = 14;
            ultraGridColumn10.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn10.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(91, 0);
            ultraGridColumn10.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn10.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn11.Header.Editor = null;
            ultraGridColumn11.Header.VisiblePosition = 10;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn12.Header.Caption = "Überspielt";
            ultraGridColumn12.Header.Editor = null;
            ultraGridColumn12.Header.VisiblePosition = 11;
            ultraGridColumn25.Header.Caption = "Einrichtung";
            ultraGridColumn25.Header.Editor = null;
            ultraGridColumn25.Header.VisiblePosition = 12;
            ultraGridColumn25.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(196, 0);
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
            ultraGridColumn25});
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
            this.dgMain.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            this.dgMain.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.dgMain.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            this.dgMain.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgMain.DisplayLayout.Override.CellAppearance = appearance9;
            this.dgMain.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
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
            this.dgMain.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.dgMain.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
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
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.dgMain, new System.Drawing.Size(447, 175));
            this.dgMain.Size = new System.Drawing.Size(750, 419);
            this.dgMain.TabIndex = 3;
            this.dgMain.Text = "ultraGrid1";
            this.dgMain.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgMain_CellChange);
            this.dgMain.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.dgMain_BeforeCellActivate);
            this.dgMain.BeforeExitEditMode += new Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventHandler(this.dgMain_BeforeExitEditMode);
            this.dgMain.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.dgMain_BeforeRowsDeleted);
            this.dgMain.Error += new Infragistics.Win.UltraWinGrid.ErrorEventHandler(this.dgMain_Error);
            // 
            // dsPatientAbwesenheit1
            // 
            this.dsPatientAbwesenheit1.DataSetName = "dsPatientAbwesenheit";
            this.dsPatientAbwesenheit1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsPatientAbwesenheit1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.ucKlinikDropDown1);
            this.panelTop.Controls.Add(this.cboGrund);
            this.panelTop.Controls.Add(this.lblWirdHändischBerechnet);
            this.panelTop.Controls.Add(this.btnAdd);
            this.panelTop.Controls.Add(this.btnDel);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(760, 30);
            this.panelTop.TabIndex = 128;
            // 
            // ucKlinikDropDown1
            // 
            this.ucKlinikDropDown1.BackColor = System.Drawing.Color.Silver;
            this.ucKlinikDropDown1.Location = new System.Drawing.Point(503, 4);
            this.ucKlinikDropDown1.Name = "ucKlinikDropDown1";
            this.ucKlinikDropDown1.Size = new System.Drawing.Size(33, 20);
            this.ucKlinikDropDown1.TabIndex = 165;
            this.ucKlinikDropDown1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ultraGridBagLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 424);
            this.panel1.TabIndex = 129;
            // 
            // ultraGridBagLayoutPanel1
            // 
            this.ultraGridBagLayoutPanel1.Controls.Add(this.dgMain);
            this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel1.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel1.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
            this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(760, 424);
            this.ultraGridBagLayoutPanel1.TabIndex = 4;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 0;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // ucAbwesenheitenKlient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTop);
            this.Name = "ucAbwesenheitenKlient";
            this.Size = new System.Drawing.Size(760, 454);
            ((System.ComponentModel.ISupportInitialize)(this.cboGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientAbwesenheit1)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
            this.ultraGridBagLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion


        public ucAbwesenheitenKlient()
		{
			InitializeComponent();
		}
        public void initControl()
        {
            this.ucKlinikDropDown1.initControl();
            this.ucKlinikDropDown1.loadComboAllKliniken();

            RefreshUserList();
            if (ENV.HasRight(UserRights.AuswahllistenVerwalten))
            {
                //this.BtnGrundStammdaten.Visible = true;
            }
        }
        
        public bool Save()
        {
            try
            {
                if (!ValidateFields())
                    return false;

                PMDS.GUI.UltraGridTools.EndCurrentEdit(dgMain);
                dbAbw.Update(_dt);
                _DataChenged = false;
                return true;
            }
            catch (Exception e)
            {
                PMDS.Global.ENV.HandleException(e);
                return false;
            }
        }

        public bool IsChanged { get { return _DataChenged; } }
        public bool ValidateFields()
        {
            bool bError = false;

            foreach (UltraGridRow row in dgMain.Rows)
            {
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

            //if (!checkDate()) bError = true;

            return !bError;
        }
        private void loadData()
        {
            _DataChenged = false;
            _dt = dbAbw.Read(_IDPatient, ENV.IDKlinik);
            _dt.VonColumn.AllowDBNull = true;
            _dt.abTagNColumn.AllowDBNull = true;
            this.sitemap.refreshAuswahlGrp(this.cboGrund, "URL");

            dgMain.DataSource = _dt;
            dgMain.Refresh();
            readPatientFelderSonstige(this._IDPatient);

            this.dgMain.DisplayLayout.Bands[0].SortedColumns.Clear();
            this.dgMain.DisplayLayout.Bands[0].SortedColumns.Add("Von", false);
            this.dgMain.DisplayLayout.Bands[0].SortedColumns.Add("Bis", false);
           
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDPatient
        {
            get { return _IDPatient; }
            set
            {
                _IDPatient = value;
                loadData();
            }
        }
		
        private void RefreshUserList()
        {
            try
            {
                PMDS.GUI.UltraGridTools.AddBenutzerValueList(dgMain, "IDBenutzer");
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
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
            dsPatientAbwesenheit.PatientAbwesenheitRow r = (dsPatientAbwesenheit.PatientAbwesenheitRow)v.Row;
            dsPatientAbwesenheit.PatientAbwesenheitDataTable dt = (dsPatientAbwesenheit.PatientAbwesenheitDataTable)r.Table;

            r.SetColumnError(cell.Column.Index, "");

            if (cell.Column.Key == dt.GrundColumn.ColumnName)
            {
                GuiUtil.ValidateField(dgMain, (cell.Text.Trim() != ""),
                                     ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);
                if (bError)
                    r.SetColumnError(cell.Column.Index, ENV.String("GUI.E_NO_TEXT"));
            }
            else if (cell.Column.Key == dt.VonColumn.ColumnName)
            {
                DateTime t = new DateTime(1900, 1, 1);
                GuiUtil.ValidateField(dgMain, (DateTime.TryParse(cell.Text.Trim(), out t)),
                                     ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);
                if (bError)
                    r.SetColumnError(cell.Column.Index, ENV.String("GUI.E_NO_TEXT") + QS2.Desktop.ControlManagment.ControlManagment.getRes("\nDas aktuelle Datum wurde gesetzt."));
                
            }
            else if (cell.Column.Key == dt.BisColumn.ColumnName)
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
                DateTime.TryParse(cell.Row.Cells[dt.VonColumn.ColumnName].Value.ToString(), out tGueltAb);

                if (!bError && tGueltAb != new DateTime(1900, 1, 1))
                {
                    string txt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Datum Bis darf nicht vor dem ") + tGueltAb.ToString("dd.MM.yyyy") + QS2.Desktop.ControlManagment.ControlManagment.getRes(" liegen.");
                    GuiUtil.ValidateField(dgMain, tGueltAb <= t, txt, ref bError, false, null);

                    if (bError)
                        r.SetColumnError(cell.Column.Index, txt);
                }

                //if (!bError && cell.Row.Cells[dt.AbgerechnetBisColumn.ColumnName].Value != DBNull.Value)
                //{
                //    DateTime dtAbgBis = (DateTime)cell.Row.Cells[dt.AbgerechnetBisColumn.ColumnName].Value;
                //    string txt = "Es wurde bereits bis " + dtAbgBis.ToString("dd.MM.yyyy") +
                //                 " abgerechnet. Das Datum Gültig bis darf nicht kleiner als " + dtAbgBis.ToString("dd.MM.yyyy");
                //    GuiUtil.ValidateField(dgMain, t >= dtAbgBis, txt, ref bError, false, null);

                //    if (bError)
                //        r.SetColumnError(cell.Column.Index, txt);
                //}
            }
            else if(cell.Column.Key == dt.abTagNColumn.ColumnName)
            {
                GuiUtil.ValidateField(dgMain, (cell.Text.Trim() != ""),
                        ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);
                if (bError)
                {
                    r.SetColumnError(cell.Column.Index, ENV.String("GUI.E_NO_TEXT"));
                }
                else
                {
                    foreach (char c in cell.Text)
                    {
                        GuiUtil.ValidateField(dgMain, (char.IsNumber(c)),
                                              QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte nur ganze Zahlen eingeben."), ref bError, false, null);

                        if (bError)
                        {
                            r.SetColumnError(cell.Column.Index, QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte nur ganze Zahlen eingeben."));
                            break;
                        }
                    }
                }
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
        private bool checkDatexy( )
        {
            //this.dgMain.DisplayLayout.Bands[0].SortedColumns.Clear();
            //this.dgMain.DisplayLayout.Bands[0].SortedColumns.Add("Von", false);
            //this.dgMain.DisplayLayout.Bands[0].SortedColumns.Add("Bis", false);

            //UltraGridRow rLast = null;
            //foreach (UltraGridRow rAbw in this.dgMain.Rows)
            //{
            //    if (rLast != null)
            //    {
            //        if  ((rLast.Cells["Bis"].Value == System.DBNull.Value  ) || ((DateTime)rAbw.Cells["Von"].Value < (DateTime)rLast.Cells["Bis"].Value))
            //        {
            //            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Abwesenheiten dürfen sich nicht überschneiden. Bitte korrigieren!", "Eingabefehler", MessageBoxButtons.OK);
            //            dgMain.Selected.Rows.Clear();
            //            rAbw.Selected = true;
            //            dgMain.ActiveRow = rAbw;
            //            return false;
            //        }
            //    }
            //    rLast = rAbw;
            //}

            //dsPatientAbwesenheit.PatientAbwesenheitRow rLast = null;        //ds.DefaultViewManager.DataViewSettings[0].Table.Rows
            //foreach (dsPatientAbwesenheit.PatientAbwesenheitRow rAbw in _dt.DefaultView.Table.Rows  )
            //{
            //    if (rLast != null)
            //    {
            //        if (rAbw.Von <= rLast.Bis)
            //        {
            //            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Abwesenheiten dürfen sich nicht überschneiden. Bitte korregieren!", "Eingabefehler", MessageBoxButtons.OK);
            //            return false;
            //        }
            //    }
            //    rLast = rAbw;
            //}

            return true ;
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

            dsPatientAbwesenheit.PatientAbwesenheitDataTable dt = new dsPatientAbwesenheit.PatientAbwesenheitDataTable();

            bool del = false;
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
        
        private void dgMain_CellChange(object sender, CellEventArgs e)
        {
            if (!this.abwHändBerech)
            {
                _DataChenged = true;
                if (ValueChanged != null)
                    ValueChanged(this, null);
            }
        }

        private void dgMain_BeforeExitEditMode(object sender, BeforeExitEditModeEventArgs e)
        {
            if (dgMain.ActiveCell != null &&
                 (dgMain.ActiveCell.Column.Key == _dt.VonColumn.ColumnName ||
                  dgMain.ActiveCell.Column.Key == _dt.BisColumn.ColumnName ||
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
        }

        private void dgMain_Error(object sender, ErrorEventArgs e)
        {
            //e.Cancel = true;
        }

        public void readPatientFelderSonstige(System.Guid IDPatient)
        {
            if (abwÜberspSitemap.abwHändBerech(IDPatient))
            {
                this.abwHändBerech = true;
                this.lblWirdHändischBerechnet.Visible = true;
                btnDel.Visible = false;
                btnAdd.Visible = false;
                //this.dgMain.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
                this.dgMain.Enabled = true;
            }
            else
            {
                this.abwHändBerech = false;
                this.lblWirdHändischBerechnet.Visible = false ;
                btnDel.Visible = true;
                btnAdd.Visible = true;
                //this.dgMain.DisplayLayout.Override.CellClickAction = CellClickAction.Edit;
                dgMain.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dsPatientAbwesenheit.PatientAbwesenheitRow r = dbAbw.New(_dt, _IDPatient, ENV.USERID);
            r.IDKlinik = ENV.IDKlinik;

            PMDS.GUI.UltraGridTools.SelectFieldInLastRowForEdit(dgMain, "Grund");
            _DataChenged = true;
            if (ValueChanged != null)
                ValueChanged(this, null);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            RemoveSelected();
        }

        private void dgMain_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (e.Cell.Column.ToString() == "IDKlinik")
            {
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
            //else
            //{
            //    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //}
        }

        private void cboGrund_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            this.sitemap.openFormAuswahlGrp(this.cboGrund, "URL");
        }

        private void cboGrund_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgMain_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            if (dgMain.Focused)
                e.Cancel = true;
        }

	}
}
