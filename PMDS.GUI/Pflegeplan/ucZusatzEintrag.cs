using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Global.db.Global;


namespace PMDS.GUI
{
	public class ucZusatzEintrag : QS2.Desktop.ControlManagment.BaseControl, IUCBase
	{
		private ZusatzEintrag _zusatzEintrag;
		private bool _valueChangeEnabled = true;
        public bool _ELGAFieldChanged = false;

        public ucZusatzEintragEdit mainWindow = null;


        public event EventHandler ValueChanged;

		private System.ComponentModel.IContainer components;
		private QS2.Desktop.ControlManagment.BaseLabel lblID;
		private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpZusatzEintrag;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtBezeichnung;
		private QS2.Desktop.ControlManagment.BaseGrid dgListe;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtID;
		private QS2.Desktop.ControlManagment.BaseLabel lblBezeichnung;
		private QS2.Desktop.ControlManagment.BaseOptionSet optTyp;
		private PMDS.GUI.ucButton btnAdd;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private dsINTListe dsINTListe1;
		private QS2.Desktop.ControlManagment.BaseMaskEdit minValue;
		private QS2.Desktop.ControlManagment.BaseLabel lblMin;
		private QS2.Desktop.ControlManagment.BaseLabel lblMax;
		private QS2.Desktop.ControlManagment.BaseMaskEdit maxValue;
		private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpWertebereich;
        private Infragistics.Win.Misc.UltraLabel lblELGA_ID;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtELGA_Code;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor numELGA_ID;
        private Infragistics.Win.Misc.UltraLabel lblELGA_Code;
        private Infragistics.Win.Misc.UltraLabel lblELGA_CodeSystem;
        private Infragistics.Win.Misc.UltraLabel lblELGA_DisplayName;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtELGA_DisplayName;
        private Infragistics.Win.Misc.UltraLabel lblELGA_Unit;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtELGA_Unit;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtELGA_CodeSystem;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtELGA_Version;
        private PMDS.GUI.ucButton btnDel;






		public ucZusatzEintrag()
		{
			InitializeComponent();
			New();
			RequiredFields();
		}
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucZusatzEintrag));
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("INTListe", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TEXT");
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            this.grpZusatzEintrag = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.txtELGA_CodeSystem = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtELGA_Unit = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtELGA_DisplayName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtELGA_Code = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.numELGA_ID = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtBezeichnung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblELGA_Unit = new Infragistics.Win.Misc.UltraLabel();
            this.lblELGA_DisplayName = new Infragistics.Win.Misc.UltraLabel();
            this.lblELGA_CodeSystem = new Infragistics.Win.Misc.UltraLabel();
            this.lblELGA_Code = new Infragistics.Win.Misc.UltraLabel();
            this.lblELGA_ID = new Infragistics.Win.Misc.UltraLabel();
            this.grpWertebereich = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.minValue = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.maxValue = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.lblMin = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblMax = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.btnDel = new PMDS.GUI.ucButton(this.components);
            this.optTyp = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.lblBezeichnung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtID = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.dgListe = new QS2.Desktop.ControlManagment.BaseGrid();
            this.dsINTListe1 = new PMDS.Global.db.Global.dsINTListe();
            this.lblID = new QS2.Desktop.ControlManagment.BaseLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtELGA_Version = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.grpZusatzEintrag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtELGA_CodeSystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtELGA_Unit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtELGA_DisplayName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtELGA_Code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numELGA_ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBezeichnung)).BeginInit();
            this.grpWertebereich.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsINTListe1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtELGA_Version)).BeginInit();
            this.SuspendLayout();
            // 
            // grpZusatzEintrag
            // 
            this.grpZusatzEintrag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpZusatzEintrag.Controls.Add(this.ultraLabel1);
            this.grpZusatzEintrag.Controls.Add(this.txtELGA_Version);
            this.grpZusatzEintrag.Controls.Add(this.txtELGA_CodeSystem);
            this.grpZusatzEintrag.Controls.Add(this.txtELGA_Unit);
            this.grpZusatzEintrag.Controls.Add(this.txtELGA_DisplayName);
            this.grpZusatzEintrag.Controls.Add(this.txtELGA_Code);
            this.grpZusatzEintrag.Controls.Add(this.numELGA_ID);
            this.grpZusatzEintrag.Controls.Add(this.txtBezeichnung);
            this.grpZusatzEintrag.Controls.Add(this.lblELGA_Unit);
            this.grpZusatzEintrag.Controls.Add(this.lblELGA_DisplayName);
            this.grpZusatzEintrag.Controls.Add(this.lblELGA_CodeSystem);
            this.grpZusatzEintrag.Controls.Add(this.lblELGA_Code);
            this.grpZusatzEintrag.Controls.Add(this.lblELGA_ID);
            this.grpZusatzEintrag.Controls.Add(this.grpWertebereich);
            this.grpZusatzEintrag.Controls.Add(this.btnAdd);
            this.grpZusatzEintrag.Controls.Add(this.btnDel);
            this.grpZusatzEintrag.Controls.Add(this.optTyp);
            this.grpZusatzEintrag.Controls.Add(this.lblBezeichnung);
            this.grpZusatzEintrag.Controls.Add(this.txtID);
            this.grpZusatzEintrag.Controls.Add(this.dgListe);
            this.grpZusatzEintrag.Controls.Add(this.lblID);
            this.grpZusatzEintrag.Location = new System.Drawing.Point(8, 8);
            this.grpZusatzEintrag.Name = "grpZusatzEintrag";
            this.grpZusatzEintrag.Size = new System.Drawing.Size(596, 558);
            this.grpZusatzEintrag.TabIndex = 0;
            this.grpZusatzEintrag.TabStop = false;
            this.grpZusatzEintrag.Text = "Zusatz-Eintrag";
            // 
            // txtELGA_CodeSystem
            // 
            this.txtELGA_CodeSystem.Location = new System.Drawing.Point(124, 124);
            this.txtELGA_CodeSystem.Name = "txtELGA_CodeSystem";
            this.txtELGA_CodeSystem.Size = new System.Drawing.Size(376, 21);
            this.txtELGA_CodeSystem.TabIndex = 5;
            this.txtELGA_CodeSystem.ValueChanged += new System.EventHandler(this.TxtELGA_CodeSystem_ValueChanged);
            // 
            // txtELGA_Unit
            // 
            this.txtELGA_Unit.Location = new System.Drawing.Point(124, 201);
            this.txtELGA_Unit.Name = "txtELGA_Unit";
            this.txtELGA_Unit.Size = new System.Drawing.Size(376, 21);
            this.txtELGA_Unit.TabIndex = 8;
            this.txtELGA_Unit.ValueChanged += new System.EventHandler(this.TxtELGA_Unit_ValueChanged);
            // 
            // txtELGA_DisplayName
            // 
            this.txtELGA_DisplayName.Location = new System.Drawing.Point(124, 176);
            this.txtELGA_DisplayName.Name = "txtELGA_DisplayName";
            this.txtELGA_DisplayName.Size = new System.Drawing.Size(376, 21);
            this.txtELGA_DisplayName.TabIndex = 7;
            this.txtELGA_DisplayName.ValueChanged += new System.EventHandler(this.TxtELGA_DisplayName_ValueChanged);
            // 
            // txtELGA_Code
            // 
            this.txtELGA_Code.Location = new System.Drawing.Point(124, 99);
            this.txtELGA_Code.Name = "txtELGA_Code";
            this.txtELGA_Code.Size = new System.Drawing.Size(376, 21);
            this.txtELGA_Code.TabIndex = 4;
            this.txtELGA_Code.ValueChanged += new System.EventHandler(this.TxtELGA_Code_ValueChanged);
            // 
            // numELGA_ID
            // 
            this.numELGA_ID.Location = new System.Drawing.Point(124, 74);
            this.numELGA_ID.Name = "numELGA_ID";
            this.numELGA_ID.Size = new System.Drawing.Size(168, 21);
            this.numELGA_ID.TabIndex = 3;
            this.numELGA_ID.ValueChanged += new System.EventHandler(this.NumELGA_ID_ValueChanged);
            // 
            // txtBezeichnung
            // 
            this.txtBezeichnung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBezeichnung.Location = new System.Drawing.Point(191, 21);
            this.txtBezeichnung.MaxLength = 255;
            this.txtBezeichnung.Name = "txtBezeichnung";
            this.txtBezeichnung.Size = new System.Drawing.Size(395, 21);
            this.txtBezeichnung.TabIndex = 1;
            this.txtBezeichnung.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblELGA_Unit
            // 
            appearance9.TextVAlignAsString = "Middle";
            this.lblELGA_Unit.Appearance = appearance9;
            this.lblELGA_Unit.Location = new System.Drawing.Point(8, 203);
            this.lblELGA_Unit.Name = "lblELGA_Unit";
            this.lblELGA_Unit.Size = new System.Drawing.Size(128, 17);
            this.lblELGA_Unit.TabIndex = 18;
            this.lblELGA_Unit.Text = "ELGA Unit";
            // 
            // lblELGA_DisplayName
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.lblELGA_DisplayName.Appearance = appearance10;
            this.lblELGA_DisplayName.Location = new System.Drawing.Point(8, 178);
            this.lblELGA_DisplayName.Name = "lblELGA_DisplayName";
            this.lblELGA_DisplayName.Size = new System.Drawing.Size(128, 17);
            this.lblELGA_DisplayName.TabIndex = 16;
            this.lblELGA_DisplayName.Text = "ELGA Display-Name";
            // 
            // lblELGA_CodeSystem
            // 
            appearance11.TextVAlignAsString = "Middle";
            this.lblELGA_CodeSystem.Appearance = appearance11;
            this.lblELGA_CodeSystem.Location = new System.Drawing.Point(8, 126);
            this.lblELGA_CodeSystem.Name = "lblELGA_CodeSystem";
            this.lblELGA_CodeSystem.Size = new System.Drawing.Size(111, 17);
            this.lblELGA_CodeSystem.TabIndex = 14;
            this.lblELGA_CodeSystem.Text = "ELGA Code-System";
            // 
            // lblELGA_Code
            // 
            appearance12.TextVAlignAsString = "Middle";
            this.lblELGA_Code.Appearance = appearance12;
            this.lblELGA_Code.Location = new System.Drawing.Point(8, 101);
            this.lblELGA_Code.Name = "lblELGA_Code";
            this.lblELGA_Code.Size = new System.Drawing.Size(128, 17);
            this.lblELGA_Code.TabIndex = 12;
            this.lblELGA_Code.Text = "ELGA Code";
            // 
            // lblELGA_ID
            // 
            appearance13.TextVAlignAsString = "Middle";
            this.lblELGA_ID.Appearance = appearance13;
            this.lblELGA_ID.Location = new System.Drawing.Point(8, 75);
            this.lblELGA_ID.Name = "lblELGA_ID";
            this.lblELGA_ID.Size = new System.Drawing.Size(108, 19);
            this.lblELGA_ID.TabIndex = 11;
            this.lblELGA_ID.Text = "ELGA ID";
            // 
            // grpWertebereich
            // 
            this.grpWertebereich.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpWertebereich.Controls.Add(this.minValue);
            this.grpWertebereich.Controls.Add(this.maxValue);
            this.grpWertebereich.Controls.Add(this.lblMin);
            this.grpWertebereich.Controls.Add(this.lblMax);
            this.grpWertebereich.Location = new System.Drawing.Point(8, 507);
            this.grpWertebereich.Name = "grpWertebereich";
            this.grpWertebereich.Size = new System.Drawing.Size(582, 44);
            this.grpWertebereich.TabIndex = 50;
            this.grpWertebereich.TabStop = false;
            this.grpWertebereich.Text = "Wertebereich";
            // 
            // minValue
            // 
            this.minValue.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Double;
            this.minValue.Enabled = false;
            this.minValue.Location = new System.Drawing.Point(39, 17);
            this.minValue.Name = "minValue";
            this.minValue.NonAutoSizeHeight = 20;
            this.minValue.Size = new System.Drawing.Size(88, 20);
            this.minValue.TabIndex = 1;
            this.minValue.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // maxValue
            // 
            this.maxValue.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Double;
            this.maxValue.Enabled = false;
            this.maxValue.Location = new System.Drawing.Point(167, 17);
            this.maxValue.Name = "maxValue";
            this.maxValue.NonAutoSizeHeight = 20;
            this.maxValue.Size = new System.Drawing.Size(92, 20);
            this.maxValue.TabIndex = 3;
            this.maxValue.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(7, 20);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(26, 14);
            this.lblMin.TabIndex = 0;
            this.lblMin.Text = "Min.";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(135, 20);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(29, 14);
            this.lblMax.TabIndex = 2;
            this.lblMax.Text = "Max.";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance14.Image = ((object)(resources.GetObject("appearance14.Image")));
            appearance14.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance14.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance14;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(530, 204);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 24);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.TabStop = false;
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance7.Image = ((object)(resources.GetObject("appearance7.Image")));
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance7.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance7;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDel.DoOnClick = true;
            this.btnDel.IsStandardControl = true;
            this.btnDel.Location = new System.Drawing.Point(558, 204);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(28, 24);
            this.btnDel.TabIndex = 21;
            this.btnDel.TabStop = false;
            this.btnDel.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // optTyp
            // 
            this.optTyp.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "Text";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "Zahl";
            valueListItem3.DataValue = 2;
            valueListItem3.DisplayText = "Mehrz. Text";
            valueListItem4.DataValue = 4;
            valueListItem4.DisplayText = "Bild";
            valueListItem5.DataValue = 5;
            valueListItem5.DisplayText = "Dezimalzahl";
            this.optTyp.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4,
            valueListItem5});
            this.optTyp.ItemSpacingHorizontal = 10;
            this.optTyp.Location = new System.Drawing.Point(9, 50);
            this.optTyp.Name = "optTyp";
            this.optTyp.Size = new System.Drawing.Size(368, 16);
            this.optTyp.TabIndex = 2;
            this.optTyp.ValueChanged += new System.EventHandler(this.optTyp_ValueChanged);
            // 
            // lblBezeichnung
            // 
            this.lblBezeichnung.AutoSize = true;
            this.lblBezeichnung.Location = new System.Drawing.Point(119, 24);
            this.lblBezeichnung.Name = "lblBezeichnung";
            this.lblBezeichnung.Size = new System.Drawing.Size(70, 14);
            this.lblBezeichnung.TabIndex = 2;
            this.lblBezeichnung.Text = "Bezeichnung";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(32, 21);
            this.txtID.MaxLength = 6;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(80, 21);
            this.txtID.TabIndex = 0;
            this.txtID.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // dgListe
            // 
            this.dgListe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgListe.AutoWork = true;
            this.dgListe.DataSource = this.dsINTListe1.INTListe;
            this.dgListe.DisplayLayout.AddNewBox.Prompt = "Add ...";
            this.dgListe.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridBand1.AddButtonCaption = "AuswahlListeGruppe";
            ultraGridBand1.ColHeadersVisible = false;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(151, 0);
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgListe.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgListe.DisplayLayout.GroupByBox.Prompt = "Drag a column header here to group by that column.";
            this.dgListe.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.dgListe.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.dgListe.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit;
            this.dgListe.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
            this.dgListe.DisplayLayout.Override.NullText = "";
            this.dgListe.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.dgListe.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.dgListe.Location = new System.Drawing.Point(8, 234);
            this.dgListe.Name = "dgListe";
            this.dgListe.Size = new System.Drawing.Size(582, 266);
            this.dgListe.TabIndex = 30;
            this.dgListe.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgListe_CellChange);
            // 
            // dsINTListe1
            // 
            this.dsINTListe1.DataSetName = "dsINTListe";
            this.dsINTListe1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsINTListe1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(8, 24);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(15, 14);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtELGA_Version
            // 
            this.txtELGA_Version.Location = new System.Drawing.Point(124, 149);
            this.txtELGA_Version.Name = "txtELGA_Version";
            this.txtELGA_Version.Size = new System.Drawing.Size(376, 21);
            this.txtELGA_Version.TabIndex = 6;
            // 
            // ultraLabel1
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance8;
            this.ultraLabel1.Location = new System.Drawing.Point(9, 152);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(111, 17);
            this.ultraLabel1.TabIndex = 52;
            this.ultraLabel1.Text = "ELGA Version";
            // 
            // ucZusatzEintrag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.grpZusatzEintrag);
            this.Name = "ucZusatzEintrag";
            this.Size = new System.Drawing.Size(612, 574);
            this.grpZusatzEintrag.ResumeLayout(false);
            this.grpZusatzEintrag.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtELGA_CodeSystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtELGA_Unit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtELGA_DisplayName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtELGA_Code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numELGA_ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBezeichnung)).EndInit();
            this.grpWertebereich.ResumeLayout(false);
            this.grpWertebereich.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsINTListe1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtELGA_Version)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


		public ZusatzEintrag ZusatzEintrag
		{
			get	
			{	
				return _zusatzEintrag;	
			}

			set	
			{	
				if (value == null)
					throw new ArgumentNullException("ZusatzEintrag");

				_valueChangeEnabled = false;
				_zusatzEintrag = value;
				UpdateGUI();
				_valueChangeEnabled = true;
				UpdateButtons();
				txtID.Enabled = false;

                if (this.mainWindow != null)
                    this.mainWindow.btnSave2.Enabled = false;
            }
		}

		public void UpdateGUI()
		{
			txtID.Text			= ZusatzEintrag.ID;
			txtBezeichnung.Text = ZusatzEintrag.Bezeichnung;
			optTyp.Value		= ZusatzEintrag.Typ;
			dgListe.DataSource	= ZusatzEintrag.Liste;
			minValue.Value		= ZusatzEintrag.MinValue;
			maxValue.Value		= ZusatzEintrag.MaxValue;

            this.numELGA_ID.Value = ZusatzEintrag.ELGA_ID;
            this.txtELGA_Code.Text = ZusatzEintrag.ELGA_Code;
            this.txtELGA_CodeSystem.Text = ZusatzEintrag.ELGA_CodeSystem;
            this.txtELGA_Version.Text = ZusatzEintrag.ELGA_Version;
            this.txtELGA_DisplayName.Text = ZusatzEintrag.ELGA_DisplayName;
            this.txtELGA_Unit.Text = ZusatzEintrag.ELGA_Unit;
          

            this._ELGAFieldChanged = false;
        }

		public void UpdateDATA()
		{
			ZusatzEintrag.ID			= txtID.Text;
			ZusatzEintrag.Bezeichnung	= txtBezeichnung.Text;
			ZusatzEintrag.Typ			= (int)optTyp.Value;
			// ZusatzEintrag.Liste = dgListe.DataSource; // mit BINDING
			ZusatzEintrag.MinValue		= (Double)minValue.Value;
			ZusatzEintrag.MaxValue		= (Double)maxValue.Value;

            ZusatzEintrag.ELGA_ID = (int)this.numELGA_ID.Value;
            ZusatzEintrag.ELGA_Code = this.txtELGA_Code.Text.Trim();
            ZusatzEintrag.ELGA_CodeSystem = this.txtELGA_CodeSystem.Text.Trim();
            ZusatzEintrag.ELGA_Version = this.txtELGA_Version.Text.Trim();
            ZusatzEintrag.ELGA_DisplayName = this.txtELGA_DisplayName.Text.Trim();
            ZusatzEintrag.ELGA_Unit = this.txtELGA_Unit.Text.Trim();
        }

        public void valueChagedELGAFied()
        {
            this._ELGAFieldChanged = true;
        }

		public bool New()
		{
			ZusatzEintrag = new ZusatzEintrag();
			txtID.Enabled = true;
			return true;
		}

		public void Read(object id)
		{
			ZusatzEintrag obj = new ZusatzEintrag((string)id);
			ZusatzEintrag = obj;
		}

		public void Read()
		{
			ZusatzEintrag.Read();
			ZusatzEintrag = ZusatzEintrag;
		}

		public void Write()
		{
			ZusatzEintrag.Write();
		}

		public void Delete()
		{
			ZusatzEintrag.Delete();
			New();
		}

		protected void OnValueChanged(object sender, EventArgs args)
		{
			if (_valueChangeEnabled && (ValueChanged != null))
				ValueChanged(sender, args);

            if (this.mainWindow != null)
                this.mainWindow.btnSave2.Enabled = true;
		}

		private void dgListe_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
			OnValueChanged(sender, EventArgs.Empty);
		}

		private void optTyp_ValueChanged(object sender, System.EventArgs e)
		{
			dgListe.Enabled = ZusatzEintrag.HasList((ZusatzEintragTyp)optTyp.Value);
			btnAdd.Enabled = dgListe.Enabled;
			btnDel.Enabled = dgListe.Enabled;
			minValue.Enabled = ZusatzEintrag.HasMinMax((ZusatzEintragTyp)optTyp.Value);
			maxValue.Enabled = minValue.Enabled;
			OnValueChanged(sender, e);
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			ZusatzEintrag.AddEntry();
			OnValueChanged(sender, EventArgs.Empty);
			UpdateButtons();
		}

		private void btnDel_Click(object sender, System.EventArgs e)
		{
			UltraGridTools.DeleteCurrentSelectedRow(dgListe, false);
			OnValueChanged(sender, EventArgs.Empty);
			UpdateButtons();
		}

		private void UpdateButtons()
		{
			btnDel.Enabled = (dgListe.Rows.Count > 0);
		}

		protected void RequiredFields()
		{
			GuiUtil.ValidateRequired(txtID);
			GuiUtil.ValidateRequired(txtBezeichnung);
		}

		public bool ValidateFields()
		{
			bool bError = false;
			bool bInfo = true;

			txtID.Text = txtID.Text.Trim();

			// txtID
			GuiUtil.ValidateField(txtID, (txtID.Text.Length >0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			if (txtID.Text.Length > 0)
			{
				GuiUtil.ValidateField(txtID, !ZusatzEintrag.Exist(txtID.Text),
					ENV.String("GUI.E_ZUSATZ_ENTRY"), ref bError, bInfo, errorProvider1);
			}

			// txtBezeichnung
			GuiUtil.ValidateField(txtBezeichnung, (txtBezeichnung.Text.Length > 0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			return !bError;
		}

		#region IUCBase Members

		DataTable IUCBase.All()
		{
			return ZusatzEintrag.AllEntries();
		}

		IBusinessBase IUCBase.Object
		{
			get	{	return ZusatzEintrag;					}
			set	{	ZusatzEintrag = (ZusatzEintrag)value;	}
		}

        #endregion


        private void TxtELGA_Code_ValueChanged(object sender, EventArgs e)
        {
            if (this.txtELGA_Code.Focused)
            {
                OnValueChanged(sender, EventArgs.Empty);
                this.valueChagedELGAFied();
            }
        }
        private void NumELGA_ID_ValueChanged(object sender, EventArgs e)
        {
            if (this.numELGA_ID.Focused)
            {
                OnValueChanged(sender, EventArgs.Empty);
                this.valueChagedELGAFied();
            }
        }
        private void TxtELGA_CodeSystem_ValueChanged(object sender, EventArgs e)
        {
            if (this.txtELGA_CodeSystem.Focused)
            {
                OnValueChanged(sender, EventArgs.Empty);
                this.valueChagedELGAFied();
            }
        }
        private void TxtELGA_DisplayName_ValueChanged(object sender, EventArgs e)
        {
            if (this.txtELGA_DisplayName.Focused)
            {
                OnValueChanged(sender, EventArgs.Empty);
                this.valueChagedELGAFied();
            }
        }
        private void TxtELGA_Unit_ValueChanged(object sender, EventArgs e)
        {
            if (this.txtELGA_Unit.Focused)
            {
                OnValueChanged(sender, EventArgs.Empty);
                this.valueChagedELGAFied();
            }
        }

    }
}
