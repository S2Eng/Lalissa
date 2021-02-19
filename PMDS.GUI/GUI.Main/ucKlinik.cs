using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.DB;



namespace PMDS.GUI
{

	public class ucKlinik : QS2.Desktop.ControlManagment.BaseControl, IUCBase
	{
		private bool	_valueChangeEnabled = true;
		private Klinik	_klinik;
        private IContainer components;
        public event EventHandler ValueChanged;
		private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpKontakt;
        public ucKontakt ucKontakt1;
        private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpEinrichtungAdresse;
		private QS2.Desktop.ControlManagment.BaseButton btnBereiche;
		private QS2.Desktop.ControlManagment.BaseButton btnAbteilungen;
        public QS2.Desktop.ControlManagment.BaseTextEditor txtKlinik;
        private QS2.Desktop.ControlManagment.BaseLabel lblEinrichtung;
        public ucAdresse ucAdresse1;
        private PMDS.GUI.ucZusatzWert ucZusatzWert1;
		private QS2.Desktop.ControlManagment.BaseTabControl tabMain;
		private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpLeitung;
        private QS2.Desktop.ControlManagment.BaseLabel lblTitel;
        private QS2.Desktop.ControlManagment.BaseOptionSet osÄrtzlicheLeitung;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
        private PMDS.GUI.BaseControls.ucBank ucBank1;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtZVR;
        private QS2.Desktop.ControlManagment.BaseLabel lblZVRUID;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private QS2.Desktop.ControlManagment.BaseLabel lblBereich;
        public QS2.Desktop.ControlManagment.BaseTextEditor tbNachname;
        private QS2.Desktop.ControlManagment.BaseLabel lblNachname;
        public QS2.Desktop.ControlManagment.BaseTextEditor tbVorname;
        private QS2.Desktop.ControlManagment.BaseLabel lblVorname;
        private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpSonstigeAngaben;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtRechnungsformular;
        private QS2.Desktop.ControlManagment.BaseLabel lblRechnungsformular;
        private System.Windows.Forms.ErrorProvider errorProvider1;


        public PMDSBusiness b = new PMDSBusiness();
        private QS2.Desktop.ControlManagment.BaseTextEditor txtRechnungsformularDepot;
        private QS2.Desktop.ControlManagment.BaseLabel baseLabel1;
        private QS2.Desktop.ControlManagment.BaseMaskEdit txtBereich;
        private QS2.Desktop.ControlManagment.BaseLabel lblELGA_AuthorSpeciality;
        private BaseControls.AuswahlGruppeCombo cboELGA_AuthorSpeciality;
        public BaseControls.AuswahlGruppeCombo cboTitel;
        public QS2.Desktop.ControlManagment.BaseTextEditor txtELGAGdaOid;
        private QS2.Desktop.ControlManagment.BaseLabel lblELGAGdaID;
        public ucKlinikEdit mainWindow = null;






		public ucKlinik()
		{
			InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || !ENV.AppRunning) return;
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.grpSonstigeAngaben = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.txtRechnungsformularDepot = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.baseLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtRechnungsformular = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblRechnungsformular = new QS2.Desktop.ControlManagment.BaseLabel();
            this.grpLeitung = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.tbNachname = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblNachname = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbVorname = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblVorname = new QS2.Desktop.ControlManagment.BaseLabel();
            this.osÄrtzlicheLeitung = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.lblTitel = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cboTitel = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.grpEinrichtungAdresse = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.btnBereiche = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAbteilungen = new QS2.Desktop.ControlManagment.BaseButton();
            this.cboELGA_AuthorSpeciality = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.lblELGA_AuthorSpeciality = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtBereich = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.lblBereich = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtZVR = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblZVRUID = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtKlinik = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblEinrichtung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ucAdresse1 = new PMDS.GUI.ucAdresse();
            this.grpKontakt = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.ucKontakt1 = new PMDS.GUI.ucKontakt();
            this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ucBank1 = new PMDS.GUI.BaseControls.ucBank();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ucZusatzWert1 = new PMDS.GUI.ucZusatzWert();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabMain = new QS2.Desktop.ControlManagment.BaseTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.txtELGAGdaOid = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblELGAGdaID = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ultraTabPageControl1.SuspendLayout();
            this.grpSonstigeAngaben.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRechnungsformularDepot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRechnungsformular)).BeginInit();
            this.grpLeitung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbNachname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osÄrtzlicheLeitung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTitel)).BeginInit();
            this.grpEinrichtungAdresse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboELGA_AuthorSpeciality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZVR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKlinik)).BeginInit();
            this.grpKontakt.SuspendLayout();
            this.ultraTabPageControl3.SuspendLayout();
            this.ultraTabPageControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtELGAGdaOid)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.txtELGAGdaOid);
            this.ultraTabPageControl1.Controls.Add(this.lblELGAGdaID);
            this.ultraTabPageControl1.Controls.Add(this.grpSonstigeAngaben);
            this.ultraTabPageControl1.Controls.Add(this.grpLeitung);
            this.ultraTabPageControl1.Controls.Add(this.grpEinrichtungAdresse);
            this.ultraTabPageControl1.Controls.Add(this.grpKontakt);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(2, 25);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(972, 477);
            // 
            // grpSonstigeAngaben
            // 
            this.grpSonstigeAngaben.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSonstigeAngaben.Controls.Add(this.txtRechnungsformularDepot);
            this.grpSonstigeAngaben.Controls.Add(this.baseLabel1);
            this.grpSonstigeAngaben.Controls.Add(this.txtRechnungsformular);
            this.grpSonstigeAngaben.Controls.Add(this.lblRechnungsformular);
            this.grpSonstigeAngaben.Location = new System.Drawing.Point(410, 309);
            this.grpSonstigeAngaben.Name = "grpSonstigeAngaben";
            this.grpSonstigeAngaben.Size = new System.Drawing.Size(559, 120);
            this.grpSonstigeAngaben.TabIndex = 18;
            this.grpSonstigeAngaben.TabStop = false;
            this.grpSonstigeAngaben.Text = "Sonstige Angaben";
            // 
            // txtRechnungsformularDepot
            // 
            this.txtRechnungsformularDepot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRechnungsformularDepot.Location = new System.Drawing.Point(109, 52);
            this.txtRechnungsformularDepot.MaxLength = 500;
            this.txtRechnungsformularDepot.Name = "txtRechnungsformularDepot";
            this.txtRechnungsformularDepot.Size = new System.Drawing.Size(443, 24);
            this.txtRechnungsformularDepot.TabIndex = 10;
            this.txtRechnungsformularDepot.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // baseLabel1
            // 
            this.baseLabel1.Location = new System.Drawing.Point(10, 50);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(93, 31);
            this.baseLabel1.TabIndex = 19;
            this.baseLabel1.Text = "RE-Formular Depot";
            // 
            // txtRechnungsformular
            // 
            this.txtRechnungsformular.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRechnungsformular.Location = new System.Drawing.Point(109, 22);
            this.txtRechnungsformular.MaxLength = 500;
            this.txtRechnungsformular.Name = "txtRechnungsformular";
            this.txtRechnungsformular.Size = new System.Drawing.Size(443, 24);
            this.txtRechnungsformular.TabIndex = 9;
            this.txtRechnungsformular.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblRechnungsformular
            // 
            this.lblRechnungsformular.Location = new System.Drawing.Point(10, 25);
            this.lblRechnungsformular.Name = "lblRechnungsformular";
            this.lblRechnungsformular.Size = new System.Drawing.Size(103, 19);
            this.lblRechnungsformular.TabIndex = 17;
            this.lblRechnungsformular.Text = "RE-Formular";
            // 
            // grpLeitung
            // 
            this.grpLeitung.Controls.Add(this.tbNachname);
            this.grpLeitung.Controls.Add(this.lblNachname);
            this.grpLeitung.Controls.Add(this.tbVorname);
            this.grpLeitung.Controls.Add(this.lblVorname);
            this.grpLeitung.Controls.Add(this.osÄrtzlicheLeitung);
            this.grpLeitung.Controls.Add(this.lblTitel);
            this.grpLeitung.Controls.Add(this.cboTitel);
            this.grpLeitung.Location = new System.Drawing.Point(8, 309);
            this.grpLeitung.Name = "grpLeitung";
            this.grpLeitung.Size = new System.Drawing.Size(396, 120);
            this.grpLeitung.TabIndex = 7;
            this.grpLeitung.TabStop = false;
            this.grpLeitung.Text = "Leitung";
            // 
            // tbNachname
            // 
            this.tbNachname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNachname.Location = new System.Drawing.Point(90, 84);
            this.tbNachname.MaxLength = 50;
            this.tbNachname.Name = "tbNachname";
            this.tbNachname.Size = new System.Drawing.Size(301, 24);
            this.tbNachname.TabIndex = 2;
            this.tbNachname.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblNachname
            // 
            this.lblNachname.AutoSize = true;
            this.lblNachname.Location = new System.Drawing.Point(7, 87);
            this.lblNachname.Name = "lblNachname";
            this.lblNachname.Size = new System.Drawing.Size(71, 17);
            this.lblNachname.TabIndex = 7;
            this.lblNachname.Text = "Nachname";
            // 
            // tbVorname
            // 
            this.tbVorname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVorname.Location = new System.Drawing.Point(90, 53);
            this.tbVorname.MaxLength = 50;
            this.tbVorname.Name = "tbVorname";
            this.tbVorname.Size = new System.Drawing.Size(301, 24);
            this.tbVorname.TabIndex = 1;
            this.tbVorname.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblVorname
            // 
            this.lblVorname.AutoSize = true;
            this.lblVorname.Location = new System.Drawing.Point(7, 56);
            this.lblVorname.Name = "lblVorname";
            this.lblVorname.Size = new System.Drawing.Size(61, 17);
            this.lblVorname.TabIndex = 5;
            this.lblVorname.Text = "Vorname";
            // 
            // osÄrtzlicheLeitung
            // 
            this.osÄrtzlicheLeitung.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.osÄrtzlicheLeitung.CheckedIndex = 0;
            valueListItem1.DataValue = "Default Item";
            valueListItem1.DisplayText = "ärztliche Leitung";
            valueListItem2.DataValue = "ValueListItem1";
            valueListItem2.DisplayText = "ärztliche Aufsicht";
            valueListItem3.DataValue = "ValueListItem2";
            valueListItem3.DisplayText = "Pflegedienstleitung";
            valueListItem4.DataValue = "ValueListItem3";
            valueListItem4.DisplayText = "Pädagogische Leitung";
            this.osÄrtzlicheLeitung.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4});
            this.osÄrtzlicheLeitung.ItemSpacingVertical = 2;
            this.osÄrtzlicheLeitung.Location = new System.Drawing.Point(22, 113);
            this.osÄrtzlicheLeitung.Name = "osÄrtzlicheLeitung";
            this.osÄrtzlicheLeitung.Size = new System.Drawing.Size(33, 20);
            this.osÄrtzlicheLeitung.TabIndex = 4;
            this.osÄrtzlicheLeitung.Text = "ärztliche Leitung";
            this.osÄrtzlicheLeitung.Visible = false;
            this.osÄrtzlicheLeitung.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Location = new System.Drawing.Point(7, 26);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(31, 17);
            this.lblTitel.TabIndex = 2;
            this.lblTitel.Text = "Titel";
            // 
            // cboTitel
            // 
            this.cboTitel.AddEmptyEntry = false;
            this.cboTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTitel.AutoOpenCBO = true;
            this.cboTitel.BerufsstandGruppeJNA = 0;
            this.cboTitel.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboTitel.ExactMatch = false;
            this.cboTitel.Group = "TIT";
            this.cboTitel.ID_PEP = -1;
            this.cboTitel.Location = new System.Drawing.Point(90, 22);
            this.cboTitel.Name = "cboTitel";
            this.cboTitel.PflichtJN = false;
            this.cboTitel.ShowAddButton = true;
            this.cboTitel.Size = new System.Drawing.Size(300, 24);
            this.cboTitel.sys = false;
            this.cboTitel.TabIndex = 0;
            this.cboTitel.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // grpEinrichtungAdresse
            // 
            this.grpEinrichtungAdresse.Controls.Add(this.btnBereiche);
            this.grpEinrichtungAdresse.Controls.Add(this.btnAbteilungen);
            this.grpEinrichtungAdresse.Controls.Add(this.cboELGA_AuthorSpeciality);
            this.grpEinrichtungAdresse.Controls.Add(this.lblELGA_AuthorSpeciality);
            this.grpEinrichtungAdresse.Controls.Add(this.txtBereich);
            this.grpEinrichtungAdresse.Controls.Add(this.lblBereich);
            this.grpEinrichtungAdresse.Controls.Add(this.txtZVR);
            this.grpEinrichtungAdresse.Controls.Add(this.lblZVRUID);
            this.grpEinrichtungAdresse.Controls.Add(this.txtKlinik);
            this.grpEinrichtungAdresse.Controls.Add(this.lblEinrichtung);
            this.grpEinrichtungAdresse.Controls.Add(this.ucAdresse1);
            this.grpEinrichtungAdresse.Location = new System.Drawing.Point(8, 8);
            this.grpEinrichtungAdresse.Name = "grpEinrichtungAdresse";
            this.grpEinrichtungAdresse.Size = new System.Drawing.Size(396, 297);
            this.grpEinrichtungAdresse.TabIndex = 2;
            this.grpEinrichtungAdresse.TabStop = false;
            this.grpEinrichtungAdresse.Text = "Einrichtung - Adresse";
            // 
            // btnBereiche
            // 
            this.btnBereiche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBereiche.AutoWorkLayout = false;
            this.btnBereiche.IsStandardControl = false;
            this.btnBereiche.Location = new System.Drawing.Point(179, 267);
            this.btnBereiche.Name = "btnBereiche";
            this.btnBereiche.Size = new System.Drawing.Size(88, 26);
            this.btnBereiche.TabIndex = 6;
            this.btnBereiche.Text = "&Bereiche";
            this.btnBereiche.Click += new System.EventHandler(this.btnBereiche_Click);
            // 
            // btnAbteilungen
            // 
            this.btnAbteilungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbteilungen.AutoWorkLayout = false;
            this.btnAbteilungen.IsStandardControl = false;
            this.btnAbteilungen.Location = new System.Drawing.Point(90, 267);
            this.btnAbteilungen.Name = "btnAbteilungen";
            this.btnAbteilungen.Size = new System.Drawing.Size(88, 26);
            this.btnAbteilungen.TabIndex = 5;
            this.btnAbteilungen.Text = "&Abteilungen";
            this.btnAbteilungen.Click += new System.EventHandler(this.btnAbteilungen_Click);
            // 
            // cboELGA_AuthorSpeciality
            // 
            this.cboELGA_AuthorSpeciality.AddEmptyEntry = false;
            this.cboELGA_AuthorSpeciality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboELGA_AuthorSpeciality.AutoOpenCBO = true;
            this.cboELGA_AuthorSpeciality.BerufsstandGruppeJNA = 0;
            this.cboELGA_AuthorSpeciality.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboELGA_AuthorSpeciality.ExactMatch = false;
            this.cboELGA_AuthorSpeciality.Group = "ROL";
            this.cboELGA_AuthorSpeciality.ID_PEP = -1;
            this.cboELGA_AuthorSpeciality.Location = new System.Drawing.Point(90, 235);
            this.cboELGA_AuthorSpeciality.Name = "cboELGA_AuthorSpeciality";
            this.cboELGA_AuthorSpeciality.PflichtJN = false;
            this.cboELGA_AuthorSpeciality.ShowAddButton = true;
            this.cboELGA_AuthorSpeciality.Size = new System.Drawing.Size(301, 24);
            this.cboELGA_AuthorSpeciality.sys = false;
            this.cboELGA_AuthorSpeciality.TabIndex = 17;
            this.cboELGA_AuthorSpeciality.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblELGA_AuthorSpeciality
            // 
            this.lblELGA_AuthorSpeciality.Location = new System.Drawing.Point(10, 234);
            this.lblELGA_AuthorSpeciality.Name = "lblELGA_AuthorSpeciality";
            this.lblELGA_AuthorSpeciality.Size = new System.Drawing.Size(84, 46);
            this.lblELGA_AuthorSpeciality.TabIndex = 16;
            this.lblELGA_AuthorSpeciality.Text = "ELGA Author speciality";
            // 
            // txtBereich
            // 
            this.txtBereich.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtBereich.InputMask = "##";
            this.txtBereich.Location = new System.Drawing.Point(90, 206);
            this.txtBereich.Name = "txtBereich";
            this.txtBereich.NonAutoSizeHeight = 23;
            this.txtBereich.Size = new System.Drawing.Size(37, 23);
            this.txtBereich.TabIndex = 4;
            this.txtBereich.Text = "30";
            // 
            // lblBereich
            // 
            this.lblBereich.AutoSize = true;
            this.lblBereich.Location = new System.Drawing.Point(10, 210);
            this.lblBereich.Name = "lblBereich";
            this.lblBereich.Size = new System.Drawing.Size(72, 17);
            this.lblBereich.TabIndex = 15;
            this.lblBereich.Text = "FiBu Prefix";
            // 
            // txtZVR
            // 
            this.txtZVR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtZVR.Location = new System.Drawing.Point(90, 176);
            this.txtZVR.MaxLength = 20;
            this.txtZVR.Name = "txtZVR";
            this.txtZVR.Size = new System.Drawing.Size(301, 24);
            this.txtZVR.TabIndex = 3;
            this.txtZVR.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblZVRUID
            // 
            this.lblZVRUID.AutoSize = true;
            this.lblZVRUID.Location = new System.Drawing.Point(10, 180);
            this.lblZVRUID.Name = "lblZVRUID";
            this.lblZVRUID.Size = new System.Drawing.Size(67, 17);
            this.lblZVRUID.TabIndex = 13;
            this.lblZVRUID.Text = "ZVR / UID";
            // 
            // txtKlinik
            // 
            this.txtKlinik.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKlinik.Location = new System.Drawing.Point(90, 24);
            this.txtKlinik.MaxLength = 255;
            this.txtKlinik.Name = "txtKlinik";
            this.txtKlinik.Size = new System.Drawing.Size(300, 24);
            this.txtKlinik.TabIndex = 1;
            this.txtKlinik.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblEinrichtung
            // 
            this.lblEinrichtung.AutoSize = true;
            this.lblEinrichtung.Location = new System.Drawing.Point(10, 28);
            this.lblEinrichtung.Name = "lblEinrichtung";
            this.lblEinrichtung.Size = new System.Drawing.Size(74, 17);
            this.lblEinrichtung.TabIndex = 0;
            this.lblEinrichtung.Text = "Einrichtung";
            // 
            // ucAdresse1
            // 
            this.ucAdresse1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucAdresse1.BackColor = System.Drawing.Color.Transparent;
            this.ucAdresse1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ucAdresse1.Location = new System.Drawing.Point(0, 54);
            this.ucAdresse1.Name = "ucAdresse1";
            this.ucAdresse1.Size = new System.Drawing.Size(396, 115);
            this.ucAdresse1.TabIndex = 2;
            this.ucAdresse1.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // grpKontakt
            // 
            this.grpKontakt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpKontakt.Controls.Add(this.ucKontakt1);
            this.grpKontakt.Location = new System.Drawing.Point(410, 8);
            this.grpKontakt.Name = "grpKontakt";
            this.grpKontakt.Size = new System.Drawing.Size(559, 295);
            this.grpKontakt.TabIndex = 8;
            this.grpKontakt.TabStop = false;
            this.grpKontakt.Text = "Kontakt";
            // 
            // ucKontakt1
            // 
            this.ucKontakt1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucKontakt1.BackColor = System.Drawing.Color.Transparent;
            this.ucKontakt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ucKontakt1.Location = new System.Drawing.Point(9, 20);
            this.ucKontakt1.Name = "ucKontakt1";
            this.ucKontakt1.Size = new System.Drawing.Size(543, 275);
            this.ucKontakt1.TabIndex = 0;
            this.ucKontakt1.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.Controls.Add(this.ucBank1);
            this.ultraTabPageControl3.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(972, 439);
            // 
            // ucBank1
            // 
            this.ucBank1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ucBank1.Location = new System.Drawing.Point(0, 0);
            this.ucBank1.Margin = new System.Windows.Forms.Padding(4);
            this.ucBank1.Name = "ucBank1";
            this.ucBank1.Size = new System.Drawing.Size(510, 190);
            this.ucBank1.TabIndex = 0;
            this.ucBank1.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.ucZusatzWert1);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(972, 439);
            // 
            // ucZusatzWert1
            // 
            this.ucZusatzWert1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucZusatzWert1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ucZusatzWert1.IgnoreNotOptional = false;
            this.ucZusatzWert1.IZusatz = null;
            this.ucZusatzWert1.Location = new System.Drawing.Point(8, 8);
            this.ucZusatzWert1.Margin = new System.Windows.Forms.Padding(4);
            this.ucZusatzWert1.Name = "ucZusatzWert1";
            this.ucZusatzWert1.ReadOnly = false;
            this.ucZusatzWert1.Size = new System.Drawing.Size(903, 422);
            this.ucZusatzWert1.TabIndex = 0;
            this.ucZusatzWert1.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.ultraTabSharedControlsPage1);
            this.tabMain.Controls.Add(this.ultraTabPageControl1);
            this.tabMain.Controls.Add(this.ultraTabPageControl2);
            this.tabMain.Controls.Add(this.ultraTabPageControl3);
            this.tabMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tabMain.Location = new System.Drawing.Point(3, 3);
            this.tabMain.Name = "tabMain";
            this.tabMain.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.tabMain.Size = new System.Drawing.Size(976, 504);
            this.tabMain.TabIndex = 2;
            ultraTab1.Key = "Stammdaten";
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "Stammdaten";
            ultraTab2.Key = "Bank";
            ultraTab2.TabPage = this.ultraTabPageControl3;
            ultraTab2.Text = "Bankverbindung";
            ultraTab3.Key = "Zusatz";
            ultraTab3.TabPage = this.ultraTabPageControl2;
            ultraTab3.Text = "Zusatzinformationen";
            ultraTab3.Visible = false;
            this.tabMain.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2,
            ultraTab3});
            this.tabMain.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.tabMain.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(972, 477);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 0;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.WindowsVista;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // txtELGAGdaOid
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            this.txtELGAGdaOid.Appearance = appearance1;
            this.txtELGAGdaOid.AutoSize = false;
            this.txtELGAGdaOid.BackColor = System.Drawing.Color.White;
            this.txtELGAGdaOid.Location = new System.Drawing.Point(98, 437);
            this.txtELGAGdaOid.MaxLength = 75;
            this.txtELGAGdaOid.Name = "txtELGAGdaOid";
            this.txtELGAGdaOid.ReadOnly = true;
            this.txtELGAGdaOid.Size = new System.Drawing.Size(300, 26);
            this.txtELGAGdaOid.TabIndex = 1006;
            // 
            // lblELGAGdaID
            // 
            this.lblELGAGdaID.AutoSize = true;
            this.lblELGAGdaID.Location = new System.Drawing.Point(15, 443);
            this.lblELGAGdaID.Name = "lblELGAGdaID";
            this.lblELGAGdaID.Size = new System.Drawing.Size(53, 17);
            this.lblELGAGdaID.TabIndex = 1007;
            this.lblELGAGdaID.Text = "GDA-ID";
            // 
            // ucKlinik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.tabMain);
            this.Name = "ucKlinik";
            this.Size = new System.Drawing.Size(982, 507);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl1.PerformLayout();
            this.grpSonstigeAngaben.ResumeLayout(false);
            this.grpSonstigeAngaben.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRechnungsformularDepot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRechnungsformular)).EndInit();
            this.grpLeitung.ResumeLayout(false);
            this.grpLeitung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbNachname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osÄrtzlicheLeitung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTitel)).EndInit();
            this.grpEinrichtungAdresse.ResumeLayout(false);
            this.grpEinrichtungAdresse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboELGA_AuthorSpeciality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZVR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKlinik)).EndInit();
            this.grpKontakt.ResumeLayout(false);
            this.ultraTabPageControl3.ResumeLayout(false);
            this.ultraTabPageControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtELGAGdaOid)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion



		[Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Klinik Klinik
		{
			get	
			{	
				return _klinik;	
			}

			set	
			{	
				if (value == null)
					throw new ArgumentNullException("Klinik");

				_valueChangeEnabled = false;
				_klinik = value;
                UpdateGUI();
				_valueChangeEnabled = true;
				SetButtons(true);
			}
		}

		public void UpdateGUI()
		{
            ucAdresse1.Adresse = Klinik.Adresse;
			ucKontakt1.Kontakt = Klinik.Kontakt;
			ucZusatzWert1.IZusatz = (IZusatz)Klinik;
            //Neu nach 21.08.2008 MDA
            ucBank1.Bank = Klinik.Bank;
            Klinik.Bank.IDKlinik = Klinik.ID;
            this.txtBereich.Text = Klinik.DB_ROW.Bereich;

			txtKlinik.Text = Klinik.Bezeichnung;

            if (!Klinik.DB_ROW.IsMitAerztlicheLeitungJNNull())
            {
                if (Klinik.DB_ROW.MitAerztlicheLeitungJN)
                    osÄrtzlicheLeitung.CheckedIndex = 0;
                else
                    if (Klinik.DB_ROW.MitAerztlicheAufsichtJN)
                        osÄrtzlicheLeitung.CheckedIndex = 1;
                    else
                        if (Klinik.DB_ROW.MitPflegedienstleitungJN)
                            osÄrtzlicheLeitung.CheckedIndex = 2;
                        else
                            osÄrtzlicheLeitung.CheckedIndex = 3;
            }
            this.tbNachname.Text = Klinik.DB_ROW.IsEinrichtungsleiterNull() ? "" : Klinik.DB_ROW.Einrichtungsleiter.Trim();
            this.tbVorname.Text =   Klinik.DB_ROW.EinrichtungsleiterVorname.Trim();
            this.cboTitel.Text = Klinik.DB_ROW.EinrichtungsleiterTitel.Trim();
            this.cboELGA_AuthorSpeciality.Text = Klinik.DB_ROW.ELGA_AuthorSpeciality;
            this.txtELGAGdaOid.Text = Klinik.DB_ROW.ELGA_OID.Trim();

            txtZVR.Text = Klinik.ZVR.Trim();

            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
            {
                PMDS.db.Entities.Klinik rKlinik = this.b.getKlinik(Klinik.ID, db);
                this.txtRechnungsformular.Text = rKlinik.Rechnungsformular.Trim();
                this.txtRechnungsformularDepot.Text = rKlinik.RechnungsformularDepot.Trim();
            }
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI nach Daten übertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public void UpdateDATA()
		{
			ucAdresse1.UpdateDATA();
			ucKontakt1.UpdateDATA();
			ucZusatzWert1.UpdateDATA();
            //Neu nach 21.08.2008 MDA
            ucBank1.UpdateDATA();

			Klinik.Bezeichnung = txtKlinik.Text;
            Klinik.DB_ROW.Einrichtungsleiter = this.tbNachname.Text.Trim();
            Klinik.DB_ROW.EinrichtungsleiterVorname = this.tbVorname.Text.Trim();
            Klinik.DB_ROW.EinrichtungsleiterTitel = this.cboTitel.Text.Trim();
            Klinik.DB_ROW.ELGA_OID = this.txtELGAGdaOid.Text.Trim();

            Klinik.DB_ROW.MitAerztlicheLeitungJN    = osÄrtzlicheLeitung.CheckedIndex == 0;
            Klinik.DB_ROW.MitAerztlicheAufsichtJN   = osÄrtzlicheLeitung.CheckedIndex == 1;
            Klinik.DB_ROW.MitPflegedienstleitungJN  = osÄrtzlicheLeitung.CheckedIndex == 2;
            Klinik.DB_ROW.MitPaedagischeLeitungJN   = osÄrtzlicheLeitung.CheckedIndex == 3;
            Klinik.ZVR = txtZVR.Text.Trim();
            Klinik.DB_ROW.Bereich = this.txtBereich.Text.Trim();            //<20120202>
            Klinik.DB_ROW.ELGA_AuthorSpeciality = this.cboELGA_AuthorSpeciality.Text.Trim();
            Klinik.Bank.IDKlinik = Klinik.ID;

            if (Klinik.DB_ROW.RowState == DataRowState.Added)
            {
                this.setNewIDKlinik();                                      //<20120202>
            }
            
        }

        public void setNewIDKlinik()                                        //<20120202>
        {
            System.Collections.Generic.List<System.Guid> lstGuid = new System.Collections.Generic.List<System.Guid>();
            foreach (DataRow rKlinik in this.Klinik.AllEntries().Rows)
            {
                lstGuid.Add( (System.Guid)rKlinik["ID"]);
            }
            System.Guid gLastGuidFound = PMDS.Global.GenericFunctions.getLastGuid(lstGuid);
            this.Klinik.DB_ROW.ID = PMDS.Global.GenericFunctions.genGuid(gLastGuidFound);
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neues Element
		/// </summary>
		//----------------------------------------------------------------------------
		public bool New()
        {
            Klinik = new Klinik();
            //this.clearUI();
			SetButtons(false);
			return true;
		}
        public void clearUI()
        {
            this.txtKlinik.Text = "";
            this.txtZVR.Text = "";
            this.txtBereich.Text = "";
            this.ucAdresse1.clearUI();
            this.ucKontakt1.clearUI();
            this.ucBank1.clearUI();
            this.osÄrtzlicheLeitung.CheckedIndex = 0;
            this.cboELGA_AuthorSpeciality.Text = "";
            this.cboELGA_AuthorSpeciality.Value = null;

            this.tbNachname.Text = "";
            this.tbVorname.Text = "";
            this.cboTitel.Text = "";
            this.txtRechnungsformular.Text = "";
        }
		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten lesen
		/// </summary>
		//----------------------------------------------------------------------------
		public void Read(object id)
		{
			Klinik obj = new Klinik((Guid)id);
			Klinik = obj;
            this.UpdateGUI();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten neu lesen
		/// </summary>
		//----------------------------------------------------------------------------
		public void Read()
		{
			Klinik.Read();
			Klinik = Klinik;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten schreiben
		/// </summary>
		//----------------------------------------------------------------------------
		public void Write()
		{
            Klinik.Write();
			ucZusatzWert1.Write();
		}
        public void WriteER()
        {
            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
            {
                PMDS.db.Entities.Klinik rKlinik = this.b.getKlinik(Klinik.ID, db);
                rKlinik.Rechnungsformular = this.txtRechnungsformular.Text.Trim();
                rKlinik.RechnungsformularDepot = this.txtRechnungsformularDepot.Text.Trim();
                db.SaveChanges();
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten löschen
        /// </summary>
        //----------------------------------------------------------------------------
        public void Delete()
		{
			Klinik.Delete();
			New();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten-Änderungs signalisieren
		/// </summary>
		//----------------------------------------------------------------------------
		protected void OnValueChanged(object sender, EventArgs args)
		{
            if (_valueChangeEnabled && (ValueChanged != null))
            {
                ValueChanged(sender, args);
                if (this.mainWindow != null)
                    this.mainWindow.btnSave2.Enabled = true;
            }
				
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Benötigte Felder setzen
		/// </summary>
		//----------------------------------------------------------------------------
		protected void RequiredFields()
		{
			GuiUtil.ValidateRequired(txtKlinik);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Felder validieren
		/// </summary>
		//----------------------------------------------------------------------------
		public bool ValidateFields()
		{
			bool bError = false;
			bool bInfo = true;

			// txtKlinik
			GuiUtil.ValidateField(txtKlinik, (txtKlinik.Text.Length > 0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            //Ändrung nach 21.08.2008 MDA
			// Bank und Zusatzwerte
			bError = !ucBank1.ValidateFields() || !ucZusatzWert1.ValidateFields() || bError;

            string MsgTxt = "";
            bool cblandOK = PMDSBusinessUI.checkCboBox(this.ucAdresse1.cboLand, QS2.Desktop.ControlManagment.ControlManagment.getRes("Land"), true, ref MsgTxt);
            bool cbELGAAutSpOK = PMDSBusinessUI.checkCboBox(this.cboELGA_AuthorSpeciality, QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA Author speciality"), true, ref MsgTxt);
            if (!cbELGAAutSpOK || !cblandOK)
            {
                bError = true;
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(MsgTxt, QS2.Desktop.ControlManagment.ControlManagment.getRes("Speichern"), MessageBoxButtons.OK);
            }

            return !bError;
		}

		#region IUCBase Members

		DataTable IUCBase.All()
		{
			return Klinik.AllEntries();
		}

		IBusinessBase IUCBase.Object
		{
			get	{	return Klinik;			}
			set	{	Klinik = (Klinik)value;	}
		}

		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Abteilungsverwaltung/Bereichsverwaltung zugänglich
		/// </summary>
		//----------------------------------------------------------------------------
		private void SetButtons(bool bEnabled)
		{
			btnAbteilungen.Enabled = bEnabled;
			btnBereiche.Enabled = bEnabled;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Abteilungsverwaltung
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnAbteilungen_Click(object sender, System.EventArgs e)
		{
			frmKlinikAbteilungen frm = new frmKlinikAbteilungen(Klinik.Abteilungen);
			frm.ShowDialog();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Bereichsverwaltung
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnBereiche_Click(object sender, System.EventArgs e)
		{
			frmKlinikBereiche frm = new frmKlinikBereiche(Klinik.Bereiche);
            frm.ucBereich1.rSelectedKlinik = this.Klinik.DB_ROW;
			frm.ShowDialog();
		}
	}
}
