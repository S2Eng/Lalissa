using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Global;
using PMDS.Data.Patient;
using PMDS.DB;
using System.Linq;

namespace PMDS.GUI
{

	public class ucPatientNew : QS2.Desktop.ControlManagment.BaseControl, IWizardPage
	{
        public event EventHandler ValueChanged;
        public event EventHandler VersDatenChanged;
        public bool abrechnungHasChanged { get; set; }

        private bool	_valueChangeEnabled = true;
		private Patient	_patient;
        private bool _lockValueChanges;
        private PMDSBusinessUI bUI = new PMDSBusinessUI();
        private PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpGebDatum;
		private QS2.Desktop.ControlManagment.BaseLabel lblGebDatum;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtOrt;
		private QS2.Desktop.ControlManagment.BaseLabel lblOrt;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtPLZ;
		private QS2.Desktop.ControlManagment.BaseLabel lblPLZ;
		private QS2.Desktop.ControlManagment.BaseLabel lblTitel;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtStrasse;
		private QS2.Desktop.ControlManagment.BaseLabel lblStrasse;
		private QS2.Desktop.ControlManagment.BaseLabel lblVorname;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtVorname;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtNachname;
		private QS2.Desktop.ControlManagment.BaseLabel lblNachname;
		private QS2.Desktop.ControlManagment.BaseLabel lblGeschlecht;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private PMDS.GUI.BaseControls.AuswahlGruppeCombo txtSexus;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo txtTitel;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpAufnahmedatum;
        private QS2.Desktop.ControlManagment.BaseLabel lblAufnahmedatum;
        protected QS2.Desktop.ControlManagment.BaseLabel lblAbteilung;
        private PMDS.GUI.BaseControls.ucAbteilungBereichSelektor cbAbteilung;
        public Infragistics.Win.UltraWinEditors.UltraCheckEditor chkKontaktbestätigung;
        public ucVersichrungsdaten ucVersichrungsdaten1;
        private QS2.Desktop.ControlManagment.BaseLabel lblHausnummer;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtHausnummer;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtStrasseOhneHausnummer;
        private BaseControls.AuswahlGruppeCombo cmbLand;
        private QS2.Desktop.ControlManagment.BaseLabel lblLand;
        private QS2.Desktop.ControlManagment.BaseLabel lblTitelPost;
        private BaseControls.AuswahlGruppeCombo cboTitelPost;
        private BaseControls.AuswahlGruppeCombo cmbAnrede;
        private QS2.Desktop.ControlManagment.BaseLabel baseLabel1;
        private BaseControls.AuswahlGruppeCombo cmbStaatsB;
        private QS2.Desktop.ControlManagment.BaseLabel lblStatsB;
        private BaseControls.AuswahlGruppeCombo cmbFAM;
        private QS2.Desktop.ControlManagment.BaseLabel lblFamiliensst;
        private IContainer components;

		public ucPatientNew()
		{
            InitializeComponent();

            //Änderung nach 09.05.2007 MDA
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
                return;

            Patient pat = new Patient();              
            pat.NewAufenthalt(ENV.ABTEILUNG, ENV.USERID);       //Neuen Aufenthalt für den aktuellen Patienten erzeugen
            Patient = pat;
            RequiredFields();
		}

		private void ucPatientNew_Load(object sender, System.EventArgs e)
		{

        }

        public bool ReadOnly
        {
            set
            {
                dtpAufnahmedatum.ReadOnly = false;
                txtNachname.ReadOnly      = value;
                txtVorname.ReadOnly = value;
                txtSexus.ReadOnly = value;
                cmbAnrede.ReadOnly = value;     //Anrede
                dtpGebDatum.ReadOnly = value;
                txtTitel.ReadOnly = value;
                cboTitelPost.ReadOnly = value;  //TitelPost
                cmbFAM.ReadOnly = value;        //Familienstand
                cmbStaatsB.ReadOnly = value;    //Staatsbürgerschaft
                txtStrasse.ReadOnly = value;
                txtStrasseOhneHausnummer.ReadOnly = value;  //StrasseOhneHausnummer
                txtHausnummer.ReadOnly = value; //Hausnummer
                txtPLZ.ReadOnly = value;
                txtOrt.ReadOnly           = value;
                cmbLand.ReadOnly = value;       //Land
            }
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
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.dtpGebDatum = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblGebDatum = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtOrt = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblOrt = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtPLZ = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblPLZ = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblTitel = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtStrasse = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblStrasse = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblVorname = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtVorname = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtNachname = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblNachname = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblGeschlecht = new QS2.Desktop.ControlManagment.BaseLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtpAufnahmedatum = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblAufnahmedatum = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblAbteilung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.chkKontaktbestätigung = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ucVersichrungsdaten1 = new PMDS.GUI.ucVersichrungsdaten();
            this.cbAbteilung = new PMDS.GUI.BaseControls.ucAbteilungBereichSelektor();
            this.txtTitel = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.txtSexus = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.lblHausnummer = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtHausnummer = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtStrasseOhneHausnummer = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.cmbLand = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.lblLand = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblTitelPost = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cboTitelPost = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.cmbAnrede = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.baseLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cmbStaatsB = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.lblStatsB = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cmbFAM = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.lblFamiliensst = new QS2.Desktop.ControlManagment.BaseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dtpGebDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPLZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNachname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAufnahmedatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKontaktbestätigung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSexus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHausnummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStrasseOhneHausnummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTitelPost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAnrede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStaatsB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFAM)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpGebDatum
            // 
            this.dtpGebDatum.DateTime = new System.DateTime(2007, 5, 8, 0, 0, 0, 0);
            this.dtpGebDatum.FormatString = "";
            this.dtpGebDatum.Location = new System.Drawing.Point(101, 112);
            this.dtpGebDatum.MaskInput = "";
            this.dtpGebDatum.Name = "dtpGebDatum";
            this.dtpGebDatum.ownFormat = "";
            this.dtpGebDatum.ownMaskInput = "";
            this.dtpGebDatum.Size = new System.Drawing.Size(104, 21);
            this.dtpGebDatum.TabIndex = 6;
            this.dtpGebDatum.Value = new System.DateTime(2007, 5, 8, 0, 0, 0, 0);
            this.dtpGebDatum.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblGebDatum
            // 
            this.lblGebDatum.AutoSize = true;
            this.lblGebDatum.Location = new System.Drawing.Point(13, 115);
            this.lblGebDatum.Name = "lblGebDatum";
            this.lblGebDatum.Size = new System.Drawing.Size(59, 14);
            this.lblGebDatum.TabIndex = 14;
            this.lblGebDatum.Text = "GebDatum";
            // 
            // txtOrt
            // 
            this.txtOrt.Location = new System.Drawing.Point(210, 232);
            this.txtOrt.MaxLength = 50;
            this.txtOrt.Name = "txtOrt";
            this.txtOrt.Size = new System.Drawing.Size(342, 21);
            this.txtOrt.TabIndex = 14;
            this.txtOrt.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblOrt
            // 
            this.lblOrt.AutoSize = true;
            this.lblOrt.Location = new System.Drawing.Point(184, 235);
            this.lblOrt.Name = "lblOrt";
            this.lblOrt.Size = new System.Drawing.Size(20, 14);
            this.lblOrt.TabIndex = 12;
            this.lblOrt.Text = "Ort";
            // 
            // txtPLZ
            // 
            this.txtPLZ.Location = new System.Drawing.Point(101, 232);
            this.txtPLZ.MaxLength = 6;
            this.txtPLZ.Name = "txtPLZ";
            this.txtPLZ.Size = new System.Drawing.Size(56, 21);
            this.txtPLZ.TabIndex = 13;
            this.txtPLZ.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblPLZ
            // 
            this.lblPLZ.AutoSize = true;
            this.lblPLZ.Location = new System.Drawing.Point(13, 235);
            this.lblPLZ.Name = "lblPLZ";
            this.lblPLZ.Size = new System.Drawing.Size(25, 14);
            this.lblPLZ.TabIndex = 10;
            this.lblPLZ.Text = "PLZ";
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Location = new System.Drawing.Point(13, 146);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(48, 14);
            this.lblTitel.TabIndex = 2;
            this.lblTitel.Text = "Titel vor.";
            // 
            // txtStrasse
            // 
            this.txtStrasse.Location = new System.Drawing.Point(471, 204);
            this.txtStrasse.MaxLength = 50;
            this.txtStrasse.Name = "txtStrasse";
            this.txtStrasse.Size = new System.Drawing.Size(192, 21);
            this.txtStrasse.TabIndex = 6;
            this.txtStrasse.Visible = false;
            this.txtStrasse.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblStrasse
            // 
            this.lblStrasse.AutoSize = true;
            this.lblStrasse.Location = new System.Drawing.Point(13, 208);
            this.lblStrasse.Name = "lblStrasse";
            this.lblStrasse.Size = new System.Drawing.Size(43, 14);
            this.lblStrasse.TabIndex = 8;
            this.lblStrasse.Text = "Strasse";
            // 
            // lblVorname
            // 
            this.lblVorname.AutoSize = true;
            this.lblVorname.Location = new System.Drawing.Point(13, 61);
            this.lblVorname.Name = "lblVorname";
            this.lblVorname.Size = new System.Drawing.Size(50, 14);
            this.lblVorname.TabIndex = 4;
            this.lblVorname.Text = "Vorname";
            // 
            // txtVorname
            // 
            this.txtVorname.Location = new System.Drawing.Point(101, 58);
            this.txtVorname.MaxLength = 25;
            this.txtVorname.Name = "txtVorname";
            this.txtVorname.Size = new System.Drawing.Size(237, 21);
            this.txtVorname.TabIndex = 3;
            this.txtVorname.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtNachname
            // 
            this.txtNachname.Location = new System.Drawing.Point(101, 31);
            this.txtNachname.MaxLength = 25;
            this.txtNachname.Name = "txtNachname";
            this.txtNachname.Size = new System.Drawing.Size(237, 21);
            this.txtNachname.TabIndex = 2;
            this.txtNachname.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblNachname
            // 
            this.lblNachname.AutoSize = true;
            this.lblNachname.Location = new System.Drawing.Point(13, 34);
            this.lblNachname.Name = "lblNachname";
            this.lblNachname.Size = new System.Drawing.Size(59, 14);
            this.lblNachname.TabIndex = 6;
            this.lblNachname.Text = "Nachname";
            // 
            // lblGeschlecht
            // 
            this.lblGeschlecht.AutoSize = true;
            this.lblGeschlecht.Location = new System.Drawing.Point(13, 88);
            this.lblGeschlecht.Name = "lblGeschlecht";
            this.lblGeschlecht.Size = new System.Drawing.Size(61, 14);
            this.lblGeschlecht.TabIndex = 0;
            this.lblGeschlecht.Text = "Geschlecht";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dtpAufnahmedatum
            // 
            this.dtpAufnahmedatum.AutoFillTime = Infragistics.Win.UltraWinMaskedEdit.AutoFillTime.Midnight;
            this.dtpAufnahmedatum.DateTime = new System.DateTime(2007, 5, 8, 0, 0, 0, 0);
            this.dtpAufnahmedatum.FormatString = "";
            this.dtpAufnahmedatum.Location = new System.Drawing.Point(101, 4);
            this.dtpAufnahmedatum.MaskInput = "{date}";
            this.dtpAufnahmedatum.MinDate = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            this.dtpAufnahmedatum.Name = "dtpAufnahmedatum";
            this.dtpAufnahmedatum.ownFormat = "";
            this.dtpAufnahmedatum.ownMaskInput = "";
            this.dtpAufnahmedatum.Size = new System.Drawing.Size(104, 21);
            this.dtpAufnahmedatum.TabIndex = 0;
            this.dtpAufnahmedatum.Value = new System.DateTime(2007, 5, 8, 0, 0, 0, 0);
            this.dtpAufnahmedatum.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblAufnahmedatum
            // 
            this.lblAufnahmedatum.AutoSize = true;
            this.lblAufnahmedatum.Location = new System.Drawing.Point(13, 7);
            this.lblAufnahmedatum.Name = "lblAufnahmedatum";
            this.lblAufnahmedatum.Size = new System.Drawing.Size(87, 14);
            this.lblAufnahmedatum.TabIndex = 18;
            this.lblAufnahmedatum.Text = "Aufnahmedatum";
            // 
            // lblAbteilung
            // 
            this.lblAbteilung.AutoSize = true;
            this.lblAbteilung.Location = new System.Drawing.Point(305, 11);
            this.lblAbteilung.Name = "lblAbteilung";
            this.lblAbteilung.Size = new System.Drawing.Size(52, 14);
            this.lblAbteilung.TabIndex = 20;
            this.lblAbteilung.Text = "Abteilung";
            // 
            // chkKontaktbestätigung
            // 
            this.chkKontaktbestätigung.Location = new System.Drawing.Point(13, 508);
            this.chkKontaktbestätigung.Name = "chkKontaktbestätigung";
            this.chkKontaktbestätigung.Size = new System.Drawing.Size(228, 18);
            this.chkKontaktbestätigung.TabIndex = 17;
            this.chkKontaktbestätigung.Text = "Kontaktbestätigung";
            // 
            // ucVersichrungsdaten1
            // 
            this.ucVersichrungsdaten1.BackColor = System.Drawing.Color.Transparent;
            this.ucVersichrungsdaten1.Location = new System.Drawing.Point(12, 297);
            this.ucVersichrungsdaten1.Margin = new System.Windows.Forms.Padding(4);
            this.ucVersichrungsdaten1.Name = "ucVersichrungsdaten1";
            this.ucVersichrungsdaten1.Size = new System.Drawing.Size(550, 204);
            this.ucVersichrungsdaten1.TabIndex = 16;
            this.ucVersichrungsdaten1.ValueChanged += new System.EventHandler(this.OnVersValueChanged);
            this.ucVersichrungsdaten1.KrankenkasseChanged += new System.EventHandler(this.onVersChanged);
            this.ucVersichrungsdaten1.SVNrChanged += new System.EventHandler(this.onVersChanged);
            this.ucVersichrungsdaten1.KlasseChanged += new System.EventHandler(this.onVersChanged);
            this.ucVersichrungsdaten1.PrivatversicherungChanged += new System.EventHandler(this.onVersChanged);
            this.ucVersichrungsdaten1.PolNrChanged += new System.EventHandler(this.onVersChanged);
            // 
            // cbAbteilung
            // 
            this.cbAbteilung.BackColor = System.Drawing.Color.White;
            this.cbAbteilung.Location = new System.Drawing.Point(379, 7);
            this.cbAbteilung.Name = "cbAbteilung";
            this.cbAbteilung.Size = new System.Drawing.Size(173, 23);
            this.cbAbteilung.TabIndex = 1;
            this.cbAbteilung.Tag = "DONTPATCH";
            // 
            // txtTitel
            // 
            this.txtTitel.AddEmptyEntry = false;
            this.txtTitel.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.txtTitel.AutoOpenCBO = false;
            this.txtTitel.BerufsstandGruppeJNA = -1;
            this.txtTitel.ExactMatch = false;
            this.txtTitel.Group = "TIT";
            this.txtTitel.ID_PEP = -1;
            this.txtTitel.IgnoreUnterdruecken = true;
            this.txtTitel.Location = new System.Drawing.Point(101, 143);
            this.txtTitel.Name = "txtTitel";
            this.txtTitel.PflichtJN = false;
            this.txtTitel.SelectDistinct = false;
            this.txtTitel.ShowAddButton = true;
            this.txtTitel.Size = new System.Drawing.Size(192, 21);
            this.txtTitel.sys = false;
            this.txtTitel.TabIndex = 7;
            this.txtTitel.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtSexus
            // 
            this.txtSexus.AddEmptyEntry = false;
            this.txtSexus.AutoOpenCBO = false;
            this.txtSexus.BerufsstandGruppeJNA = -1;
            this.txtSexus.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.txtSexus.ExactMatch = false;
            this.txtSexus.Group = "SEX";
            this.txtSexus.ID_PEP = -1;
            this.txtSexus.IgnoreUnterdruecken = true;
            this.txtSexus.Location = new System.Drawing.Point(101, 85);
            this.txtSexus.Name = "txtSexus";
            this.txtSexus.PflichtJN = false;
            this.txtSexus.SelectDistinct = false;
            this.txtSexus.ShowAddButton = true;
            this.txtSexus.Size = new System.Drawing.Size(128, 21);
            this.txtSexus.sys = false;
            this.txtSexus.TabIndex = 4;
            this.txtSexus.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblHausnummer
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            this.lblHausnummer.Appearance = appearance6;
            this.lblHausnummer.AutoSize = true;
            this.lblHausnummer.Location = new System.Drawing.Point(344, 209);
            this.lblHausnummer.Name = "lblHausnummer";
            this.lblHausnummer.Size = new System.Drawing.Size(19, 14);
            this.lblHausnummer.TabIndex = 127;
            this.lblHausnummer.Text = "Nr.";
            // 
            // txtHausnummer
            // 
            this.txtHausnummer.Location = new System.Drawing.Point(379, 205);
            this.txtHausnummer.MaxLength = 10;
            this.txtHausnummer.Name = "txtHausnummer";
            this.txtHausnummer.Size = new System.Drawing.Size(77, 21);
            this.txtHausnummer.TabIndex = 12;
            this.txtHausnummer.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtStrasseOhneHausnummer
            // 
            this.txtStrasseOhneHausnummer.Location = new System.Drawing.Point(101, 205);
            this.txtStrasseOhneHausnummer.MaxLength = 60;
            this.txtStrasseOhneHausnummer.Name = "txtStrasseOhneHausnummer";
            this.txtStrasseOhneHausnummer.Size = new System.Drawing.Size(237, 21);
            this.txtStrasseOhneHausnummer.TabIndex = 11;
            this.txtStrasseOhneHausnummer.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // cmbLand
            // 
            this.cmbLand.AddEmptyEntry = false;
            this.cmbLand.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbLand.AutoOpenCBO = false;
            this.cmbLand.BerufsstandGruppeJNA = -1;
            this.cmbLand.ExactMatch = false;
            this.cmbLand.Group = "LND";
            this.cmbLand.ID_PEP = -1;
            this.cmbLand.IgnoreUnterdruecken = true;
            this.cmbLand.Location = new System.Drawing.Point(101, 259);
            this.cmbLand.MaxLength = 20;
            this.cmbLand.Name = "cmbLand";
            this.cmbLand.PflichtJN = false;
            this.cmbLand.SelectDistinct = false;
            this.cmbLand.ShowAddButton = true;
            this.cmbLand.Size = new System.Drawing.Size(451, 21);
            this.cmbLand.sys = false;
            this.cmbLand.TabIndex = 15;
            this.cmbLand.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblLand
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.lblLand.Appearance = appearance5;
            this.lblLand.AutoSize = true;
            this.lblLand.Location = new System.Drawing.Point(13, 263);
            this.lblLand.Name = "lblLand";
            this.lblLand.Size = new System.Drawing.Size(29, 14);
            this.lblLand.TabIndex = 227;
            this.lblLand.Text = "Land";
            // 
            // lblTitelPost
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.lblTitelPost.Appearance = appearance4;
            this.lblTitelPost.AutoSize = true;
            this.lblTitelPost.Location = new System.Drawing.Point(305, 146);
            this.lblTitelPost.Name = "lblTitelPost";
            this.lblTitelPost.Size = new System.Drawing.Size(56, 14);
            this.lblTitelPost.TabIndex = 229;
            this.lblTitelPost.Text = "Titel nach.";
            // 
            // cboTitelPost
            // 
            this.cboTitelPost.AddEmptyEntry = false;
            this.cboTitelPost.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cboTitelPost.AutoOpenCBO = true;
            this.cboTitelPost.BerufsstandGruppeJNA = -1;
            this.cboTitelPost.ExactMatch = false;
            this.cboTitelPost.Group = "TTP";
            this.cboTitelPost.ID_PEP = -1;
            this.cboTitelPost.IgnoreUnterdruecken = true;
            this.cboTitelPost.Location = new System.Drawing.Point(379, 143);
            this.cboTitelPost.MaxLength = 40;
            this.cboTitelPost.Name = "cboTitelPost";
            this.cboTitelPost.PflichtJN = false;
            this.cboTitelPost.SelectDistinct = false;
            this.cboTitelPost.ShowAddButton = true;
            this.cboTitelPost.Size = new System.Drawing.Size(173, 21);
            this.cboTitelPost.sys = false;
            this.cboTitelPost.TabIndex = 8;
            this.cboTitelPost.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // cmbAnrede
            // 
            this.cmbAnrede.AddEmptyEntry = false;
            this.cmbAnrede.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbAnrede.AutoOpenCBO = true;
            this.cmbAnrede.BerufsstandGruppeJNA = -1;
            this.cmbAnrede.ExactMatch = false;
            this.cmbAnrede.Group = "ANR";
            this.cmbAnrede.ID_PEP = -1;
            this.cmbAnrede.IgnoreUnterdruecken = true;
            this.cmbAnrede.Location = new System.Drawing.Point(379, 84);
            this.cmbAnrede.MaxLength = 15;
            this.cmbAnrede.Name = "cmbAnrede";
            this.cmbAnrede.PflichtJN = false;
            this.cmbAnrede.SelectDistinct = false;
            this.cmbAnrede.ShowAddButton = true;
            this.cmbAnrede.Size = new System.Drawing.Size(173, 21);
            this.cmbAnrede.sys = false;
            this.cmbAnrede.TabIndex = 5;
            this.cmbAnrede.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // baseLabel1
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.baseLabel1.Appearance = appearance3;
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Location = new System.Drawing.Point(305, 88);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(41, 14);
            this.baseLabel1.TabIndex = 231;
            this.baseLabel1.Text = "Anrede";
            // 
            // cmbStaatsB
            // 
            this.cmbStaatsB.AddEmptyEntry = false;
            this.cmbStaatsB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStaatsB.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbStaatsB.AutoOpenCBO = true;
            this.cmbStaatsB.BerufsstandGruppeJNA = -1;
            this.cmbStaatsB.ExactMatch = false;
            this.cmbStaatsB.Group = "SBS";
            this.cmbStaatsB.ID_PEP = -1;
            this.cmbStaatsB.IgnoreUnterdruecken = true;
            this.cmbStaatsB.Location = new System.Drawing.Point(379, 173);
            this.cmbStaatsB.MaxLength = 255;
            this.cmbStaatsB.Name = "cmbStaatsB";
            this.cmbStaatsB.PflichtJN = false;
            this.cmbStaatsB.SelectDistinct = false;
            this.cmbStaatsB.ShowAddButton = true;
            this.cmbStaatsB.Size = new System.Drawing.Size(173, 21);
            this.cmbStaatsB.sys = false;
            this.cmbStaatsB.TabIndex = 10;
            this.cmbStaatsB.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblStatsB
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.lblStatsB.Appearance = appearance1;
            this.lblStatsB.AutoSize = true;
            this.lblStatsB.Location = new System.Drawing.Point(305, 177);
            this.lblStatsB.Name = "lblStatsB";
            this.lblStatsB.Size = new System.Drawing.Size(52, 14);
            this.lblStatsB.TabIndex = 234;
            this.lblStatsB.Text = "Staatsbg.";
            // 
            // cmbFAM
            // 
            this.cmbFAM.AddEmptyEntry = false;
            this.cmbFAM.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cmbFAM.AutoOpenCBO = false;
            this.cmbFAM.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cmbFAM.BerufsstandGruppeJNA = -1;
            this.cmbFAM.ExactMatch = false;
            this.cmbFAM.Group = "FAM";
            this.cmbFAM.ID_PEP = -1;
            this.cmbFAM.IgnoreUnterdruecken = true;
            this.cmbFAM.Location = new System.Drawing.Point(101, 173);
            this.cmbFAM.MaxLength = 15;
            this.cmbFAM.Name = "cmbFAM";
            this.cmbFAM.PflichtJN = false;
            this.cmbFAM.SelectDistinct = false;
            this.cmbFAM.ShowAddButton = true;
            this.cmbFAM.Size = new System.Drawing.Size(192, 21);
            this.cmbFAM.sys = false;
            this.cmbFAM.TabIndex = 9;
            this.cmbFAM.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblFamiliensst
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.lblFamiliensst.Appearance = appearance2;
            this.lblFamiliensst.AutoSize = true;
            this.lblFamiliensst.Location = new System.Drawing.Point(13, 177);
            this.lblFamiliensst.Name = "lblFamiliensst";
            this.lblFamiliensst.Size = new System.Drawing.Size(63, 14);
            this.lblFamiliensst.TabIndex = 235;
            this.lblFamiliensst.Text = "Fam. Stand";
            // 
            // ucPatientNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.cmbStaatsB);
            this.Controls.Add(this.lblStatsB);
            this.Controls.Add(this.cmbFAM);
            this.Controls.Add(this.lblFamiliensst);
            this.Controls.Add(this.cmbAnrede);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.lblTitelPost);
            this.Controls.Add(this.cboTitelPost);
            this.Controls.Add(this.cmbLand);
            this.Controls.Add(this.lblLand);
            this.Controls.Add(this.lblHausnummer);
            this.Controls.Add(this.txtHausnummer);
            this.Controls.Add(this.txtStrasseOhneHausnummer);
            this.Controls.Add(this.ucVersichrungsdaten1);
            this.Controls.Add(this.chkKontaktbestätigung);
            this.Controls.Add(this.cbAbteilung);
            this.Controls.Add(this.lblAbteilung);
            this.Controls.Add(this.dtpAufnahmedatum);
            this.Controls.Add(this.lblAufnahmedatum);
            this.Controls.Add(this.txtTitel);
            this.Controls.Add(this.txtSexus);
            this.Controls.Add(this.lblGeschlecht);
            this.Controls.Add(this.dtpGebDatum);
            this.Controls.Add(this.lblGebDatum);
            this.Controls.Add(this.txtOrt);
            this.Controls.Add(this.lblOrt);
            this.Controls.Add(this.txtPLZ);
            this.Controls.Add(this.lblPLZ);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.txtStrasse);
            this.Controls.Add(this.lblStrasse);
            this.Controls.Add(this.lblVorname);
            this.Controls.Add(this.txtVorname);
            this.Controls.Add(this.txtNachname);
            this.Controls.Add(this.lblNachname);
            this.Name = "ucPatientNew";
            this.Size = new System.Drawing.Size(574, 561);
            this.Load += new System.EventHandler(this.ucPatientNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtpGebDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPLZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNachname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAufnahmedatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKontaktbestätigung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSexus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHausnummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStrasseOhneHausnummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTitelPost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAnrede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStaatsB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFAM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public Patient Patient
		{
			get	
			{	
				return _patient;	
			}
			set	
			{
				if (value == null)
					throw new ArgumentNullException("Patient");

                _valueChangeEnabled = false;
				_patient = value;

                this.ReadOnlyVersDat = false;

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    if (b.checkPatientExists(_patient.ID, db))
                    {
                        KlientDetails klient = new KlientDetails(_patient.ID, Aufenthalt.LastByPatient(_patient.ID), true);
                        this.ucVersichrungsdaten1.Klient = klient;
                    }
                    else
                    {
                        this.ucVersichrungsdaten1.initNoKlient();
                    }
                }

                UpdateGUI();
				_valueChangeEnabled = true;
			}
		}

        public void UpdateGUI()
        {
            dtpAufnahmedatum.Value = Patient.Aufenthalt.Aufnahmezeitpunkt;
            cbAbteilung.IDAbteilung = Patient.Aufenthalt.IDAbteilung;
            txtSexus.Text = Patient.Sexus;
            txtTitel.Text = Patient.Titel;
            txtVorname.Text = Patient.Vorname;
            txtNachname.Text = Patient.Nachname;
            txtStrasse.Text = Patient.Adresse.Strasse;
            txtPLZ.Text = Patient.Adresse.Plz;
            txtOrt.Text = Patient.Adresse.Ort;
            dtpGebDatum.Value = Patient.Geburtsdatum;

            using (PMDS.db.Entities.ERModellPMDSEntities db1 = PMDSBusiness.getDBContext())
            {
                if (this.b.checkPatientExists(Patient.ID, db1))
                {
                    var rPatInfo = (from p in db1.Patient
                                    join adr in db1.Adresse on p.IDAdresse equals adr.ID
                                    where p.ID == Patient.ID

                                    select new
                                    {
                                        p.TitelPost,
                                        p.Anrede,
                                        p.Familienstand,
                                        p.Staatsb,
                                        adr.Strasse_OhneHausnummer,
                                        adr.Hausnummer,
                                        adr.LandKZ
                                    }
                                   ).First();
                    this.cmbAnrede.Text = rPatInfo.Anrede;
                    this.cboTitelPost.Text = rPatInfo.TitelPost;
                    this.cmbFAM.Text = rPatInfo.Familienstand;
                    this.cmbStaatsB.Text = rPatInfo.Staatsb;
                    this.txtStrasseOhneHausnummer.Text = rPatInfo.Strasse_OhneHausnummer == null ? "" : rPatInfo.Strasse_OhneHausnummer.ToString();
                    this.txtHausnummer.Text = rPatInfo.Hausnummer == null ? "" : rPatInfo.Hausnummer.ToString();
                    this.cmbLand.Text = rPatInfo.LandKZ;
                }
            }
        }

        public void UpdateDATA()
        {
            Patient.Aufenthalt.Aufnahmezeitpunkt = dtpAufnahmedatum.DateTime;

            if (cbAbteilung.IsAbteilungSelected)
            {
                Patient.Aufenthalt.IDAbteilung = cbAbteilung.IDAbteilung;
                Patient.Aufenthalt.AufnahmeVerlauf.IDAbteilung_Nach = cbAbteilung.IDAbteilung;
                Patient.Aufenthalt.IDKlinik = this.cbAbteilung.IDKlinik;
                Patient.Aufenthalt.IDBereich = this.cbAbteilung.IDBereich;
            }

            Patient.Sexus = txtSexus.Text;
            Patient.Titel = txtTitel.Text;
            Patient.Vorname = txtVorname.Text;
            Patient.Nachname = txtNachname.Text;
            Patient.Adresse.Strasse = txtStrasse.Text;
            Patient.Adresse.Plz = txtPLZ.Text;
            Patient.Adresse.Ort = txtOrt.Text;
            Patient.Geburtsdatum = dtpGebDatum.Value;

            if (Patient.Aufenthalt.IDAbteilung == null)
            {
                throw new Exception("UpdateDATA: Patient.Aufenthalt.IDAbteilung == null not allowed for Patient '" + Patient.Nachname.Trim() + "'!");
            }

            Patient.IDAbteilung = Patient.Aufenthalt.IDAbteilung;
            if (cbAbteilung.IDBereich != null)
            {
                Patient.IDBereich = Patient.Aufenthalt.IDBereich;
            }
            else
            {
                Patient.IDBereich = null;
            }

            if (cbAbteilung.IsBereichSelected)
                Patient.Aufenthalt.AufnahmeVerlauf.IDBereich = cbAbteilung.IDBereich;

            this.ucVersichrungsdaten1.UpdateDATA();
        }

        public void UpdateDataER()
        {
            //Save ER
            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
            {
                if (this.b.checkPatientExists(Patient.ID, db))
                {
                    //Patientenstammdaten
                    PMDS.db.Entities.Patient rPatient = this.b.getPatient(Patient.ID, db);
                    rPatient.Anrede = cmbAnrede.Text;
                    rPatient.TitelPost = cboTitelPost.Text;
                    rPatient.Familienstand = cmbFAM.Text;
                    rPatient.Staatsb = cmbStaatsB.Text;
                    rPatient.ForensischerHintergrund = false;

                    //Versicherungsdaten
                    rPatient.SozVersMitversichertBei = this.ucVersichrungsdaten1.txtSozVersMitversichertBei.Text;
                    rPatient.SozVersLeerGrund = this.ucVersichrungsdaten1.cboSozVersLeerGrund.Text;
                    rPatient.SozVersStatus = this.ucVersichrungsdaten1.cboSozVersStatus.Text;
                    rPatient.Klasse = this.ucVersichrungsdaten1.Klasse;

                    //Adressdaten
                    PMDS.db.Entities.Adresse rAdresse = this.b.getAdresse((Guid)rPatient.IDAdresse, db);
                    rAdresse.Strasse_OhneHausnummer = txtStrasseOhneHausnummer.Text;
                    rAdresse.Hausnummer = txtHausnummer.Text;
                    rAdresse.Strasse = (txtStrasseOhneHausnummer.Text + " " + txtHausnummer.Text).Trim();
                    rAdresse.LandKZ = cmbLand.Text;

                    db.SaveChanges();
                }
            }
        }

		protected void OnValueChanged(object sender, EventArgs args)
		{
			if (_valueChangeEnabled && (ValueChanged != null))
				ValueChanged(sender, args);
		}

		protected void RequiredFields()
		{
            GuiUtil.ValidateRequired(dtpAufnahmedatum);
            GuiUtil.ValidateRequired(cbAbteilung);
			GuiUtil.ValidateRequired(txtSexus);
			GuiUtil.ValidateRequired(txtVorname);
			GuiUtil.ValidateRequired(txtNachname);
			GuiUtil.ValidateRequired(dtpGebDatum);
		}

		private bool _bmodifymode;
		public bool MODIFYMODE 
		{
			set 
			{
				_bmodifymode = value;
			}
		}

		public bool ValidateFields()
		{
			bool bError = false;
			bool bInfo = true;

            // cbAbteilung
            GuiUtil.ValidateField(cbAbteilung, cbAbteilung.IsAbteilungSelected,
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			// txtSexus
			GuiUtil.ValidateField(txtSexus, (txtSexus.Text.Length > 0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			// txtVorname
			GuiUtil.ValidateField(txtVorname, (txtVorname.Text.Length > 0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			// txtNachname
			GuiUtil.ValidateField(txtNachname, (txtNachname.Text.Length > 0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			// dtpGebDatum
			GuiUtil.ValidateField(dtpGebDatum, (dtpGebDatum.Text.Length > 0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			if (!_bmodifymode && !bError && Patient.IsUserDefined(txtVorname.Text, txtNachname.Text, dtpGebDatum.DateTime))
			{
				QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("GUI.E_PATIENT_ALREADY_EXISTS"), true);
				bError = true;
			}

			return !bError;
		}

        public bool validateDataVersNr(bool withMsgBox)
        {
            try
            {
                return bUI.validateDataVersNr(this.ucVersichrungsdaten1, null);

            }
            catch (Exception ex)
            {
                throw new Exception("ucPatientNew.validateDataVersNr: " + ex.ToString());
            }
        }

        private void onVersChanged(object sender, EventArgs e)
        {
            if (this._lockValueChanges) return;
            if (_valueChangeEnabled && (VersDatenChanged != null))
                VersDatenChanged(sender, e);
        }

        protected void OnVersValueChanged(object sender, EventArgs args)
        {
            if (this._lockValueChanges) return;
            abrechnungHasChanged = true;
            if (_valueChangeEnabled)
                OnValueChanged(sender, args);
        }

        public bool ReadOnlyVersDat
        {
            get { return ucVersichrungsdaten1.ReadOnly; }
            set
            {
                ucVersichrungsdaten1.ReadOnly = value;
            }
        }
    }

}

