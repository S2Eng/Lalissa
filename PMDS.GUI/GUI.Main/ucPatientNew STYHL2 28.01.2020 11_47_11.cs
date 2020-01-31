//----------------------------------------------------------------------------
/// <summary>
///	ucPatientNew.cs
/// Erstellt am:	12.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PMDS.BusinessLogic;
using PMDS.Global;
//Neu nach 11.05.2007 MDA
using PMDS.Data.Global;
using PMDS.Data.Patient;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// UserControl zur Erzeugung eines neuen Patienten
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucPatientNew : QS2.Desktop.ControlManagment.BaseControl, IWizardPage
	{
		private bool	_valueChangeEnabled = true;
		private Patient	_patient;
		public event EventHandler ValueChanged;

        public event EventHandler VersDatenChanged;
        private bool _lockValueChanges = false;
        public bool abrechnungHasChanged = false;



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
        private QS2.Desktop.ControlManagment.BaseLabel lblSVNr;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpAufnahmedatum;
        private QS2.Desktop.ControlManagment.BaseLabel lblAufnahmedatum;
        protected QS2.Desktop.ControlManagment.BaseLabel lblAbteilung;
        private PMDS.GUI.BaseControls.ucAbteilungBereichSelektor cbAbteilung;
        private QS2.Desktop.ControlManagment.BaseMaskEdit tbSVNr;
        public Infragistics.Win.UltraWinEditors.UltraCheckEditor chkKontaktbestätigung;
        public ucVersichrungsdaten ucVersichrungsdaten1;
        private IContainer components;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Default Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucPatientNew()
		{
			InitializeComponent();

            //Änderung nach 09.05.2007 MDA
            if (DesignMode)
                return;

            if (ENV.AppRunning)
            {
                Patient pat = new Patient();
                //Neuen Aufenthalt für den aktuellen Patienten erzeugen
                pat.NewAufenthalt(ENV.ABTEILUNG, ENV.USERID);
                Patient = pat;
            }
            RequiredFields();
		}

        

		//----------------------------------------------------------------------------
		/// <summary>
		/// Initialisierung der GUI
		/// </summary>
		//----------------------------------------------------------------------------
		private void ucPatientNew_Load(object sender, System.EventArgs e)
		{
            if (DesignMode || !ENV.AppRunning)
                return;

        }

        public bool ReadOnly
        {
            set
            {
                dtpAufnahmedatum.ReadOnly = false; //Neu nach 08.05.2007 MDA
                txtNachname.ReadOnly      = value;
                txtOrt.ReadOnly           = value;
                txtPLZ.ReadOnly           = value;
                txtSexus.ReadOnly         = value;
                txtStrasse.ReadOnly       = value;
                txtTitel.ReadOnly         = value;
                txtVorname.ReadOnly       = value;
                tbSVNr.ReadOnly           = false;
                dtpGebDatum.ReadOnly      = value;
            }
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dispose
		/// </summary>
		//----------------------------------------------------------------------------
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
            this.lblSVNr = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbSVNr = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.dtpAufnahmedatum = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblAufnahmedatum = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblAbteilung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbAbteilung = new PMDS.GUI.BaseControls.ucAbteilungBereichSelektor();
            this.txtTitel = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.txtSexus = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.chkKontaktbestätigung = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ucVersichrungsdaten1 = new PMDS.GUI.ucVersichrungsdaten();
            ((System.ComponentModel.ISupportInitialize)(this.dtpGebDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPLZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNachname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAufnahmedatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSexus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKontaktbestätigung)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpGebDatum
            // 
            this.dtpGebDatum.DateTime = new System.DateTime(2007, 5, 8, 0, 0, 0, 0);
            this.dtpGebDatum.FormatString = "";
            this.dtpGebDatum.Location = new System.Drawing.Point(101, 220);
            this.dtpGebDatum.MaskInput = "";
            this.dtpGebDatum.Name = "dtpGebDatum";
            this.dtpGebDatum.ownFormat = "";
            this.dtpGebDatum.ownMaskInput = "";
            this.dtpGebDatum.Size = new System.Drawing.Size(104, 21);
            this.dtpGebDatum.TabIndex = 9;
            this.dtpGebDatum.Value = new System.DateTime(2007, 5, 8, 0, 0, 0, 0);
            this.dtpGebDatum.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblGebDatum
            // 
            this.lblGebDatum.AutoSize = true;
            this.lblGebDatum.Location = new System.Drawing.Point(13, 223);
            this.lblGebDatum.Name = "lblGebDatum";
            this.lblGebDatum.Size = new System.Drawing.Size(59, 14);
            this.lblGebDatum.TabIndex = 14;
            this.lblGebDatum.Text = "GebDatum";
            // 
            // txtOrt
            // 
            this.txtOrt.Location = new System.Drawing.Point(101, 196);
            this.txtOrt.MaxLength = 50;
            this.txtOrt.Name = "txtOrt";
            this.txtOrt.Size = new System.Drawing.Size(104, 21);
            this.txtOrt.TabIndex = 8;
            this.txtOrt.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblOrt
            // 
            this.lblOrt.AutoSize = true;
            this.lblOrt.Location = new System.Drawing.Point(13, 199);
            this.lblOrt.Name = "lblOrt";
            this.lblOrt.Size = new System.Drawing.Size(20, 14);
            this.lblOrt.TabIndex = 12;
            this.lblOrt.Text = "Ort";
            // 
            // txtPLZ
            // 
            this.txtPLZ.Location = new System.Drawing.Point(101, 172);
            this.txtPLZ.MaxLength = 6;
            this.txtPLZ.Name = "txtPLZ";
            this.txtPLZ.Size = new System.Drawing.Size(56, 21);
            this.txtPLZ.TabIndex = 7;
            this.txtPLZ.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblPLZ
            // 
            this.lblPLZ.AutoSize = true;
            this.lblPLZ.Location = new System.Drawing.Point(13, 175);
            this.lblPLZ.Name = "lblPLZ";
            this.lblPLZ.Size = new System.Drawing.Size(25, 14);
            this.lblPLZ.TabIndex = 10;
            this.lblPLZ.Text = "PLZ";
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Location = new System.Drawing.Point(13, 79);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(26, 14);
            this.lblTitel.TabIndex = 2;
            this.lblTitel.Text = "Titel";
            // 
            // txtStrasse
            // 
            this.txtStrasse.Location = new System.Drawing.Point(101, 148);
            this.txtStrasse.MaxLength = 50;
            this.txtStrasse.Name = "txtStrasse";
            this.txtStrasse.Size = new System.Drawing.Size(192, 21);
            this.txtStrasse.TabIndex = 6;
            this.txtStrasse.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblStrasse
            // 
            this.lblStrasse.AutoSize = true;
            this.lblStrasse.Location = new System.Drawing.Point(13, 151);
            this.lblStrasse.Name = "lblStrasse";
            this.lblStrasse.Size = new System.Drawing.Size(43, 14);
            this.lblStrasse.TabIndex = 8;
            this.lblStrasse.Text = "Strasse";
            // 
            // lblVorname
            // 
            this.lblVorname.AutoSize = true;
            this.lblVorname.Location = new System.Drawing.Point(13, 103);
            this.lblVorname.Name = "lblVorname";
            this.lblVorname.Size = new System.Drawing.Size(50, 14);
            this.lblVorname.TabIndex = 4;
            this.lblVorname.Text = "Vorname";
            // 
            // txtVorname
            // 
            this.txtVorname.Location = new System.Drawing.Point(101, 100);
            this.txtVorname.MaxLength = 25;
            this.txtVorname.Name = "txtVorname";
            this.txtVorname.Size = new System.Drawing.Size(192, 21);
            this.txtVorname.TabIndex = 4;
            this.txtVorname.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtNachname
            // 
            this.txtNachname.Location = new System.Drawing.Point(101, 124);
            this.txtNachname.MaxLength = 25;
            this.txtNachname.Name = "txtNachname";
            this.txtNachname.Size = new System.Drawing.Size(192, 21);
            this.txtNachname.TabIndex = 5;
            this.txtNachname.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblNachname
            // 
            this.lblNachname.AutoSize = true;
            this.lblNachname.Location = new System.Drawing.Point(13, 127);
            this.lblNachname.Name = "lblNachname";
            this.lblNachname.Size = new System.Drawing.Size(59, 14);
            this.lblNachname.TabIndex = 6;
            this.lblNachname.Text = "Nachname";
            // 
            // lblGeschlecht
            // 
            this.lblGeschlecht.AutoSize = true;
            this.lblGeschlecht.Location = new System.Drawing.Point(13, 55);
            this.lblGeschlecht.Name = "lblGeschlecht";
            this.lblGeschlecht.Size = new System.Drawing.Size(61, 14);
            this.lblGeschlecht.TabIndex = 0;
            this.lblGeschlecht.Text = "Geschlecht";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblSVNr
            // 
            this.lblSVNr.AutoSize = true;
            this.lblSVNr.Location = new System.Drawing.Point(13, 247);
            this.lblSVNr.Name = "lblSVNr";
            this.lblSVNr.Size = new System.Drawing.Size(41, 14);
            this.lblSVNr.TabIndex = 16;
            this.lblSVNr.Text = "SV Nr.:";
            // 
            // tbSVNr
            // 
            this.tbSVNr.ClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.tbSVNr.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.tbSVNr.InputMask = "nnnn nnnnnn";
            this.tbSVNr.Location = new System.Drawing.Point(101, 246);
            this.tbSVNr.Name = "tbSVNr";
            this.tbSVNr.NonAutoSizeHeight = 20;
            this.tbSVNr.NullText = "<SV-Nr eingeben>";
            this.tbSVNr.Size = new System.Drawing.Size(189, 20);
            this.tbSVNr.TabIndex = 21;
            this.tbSVNr.Text = " ";
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
            this.lblAbteilung.Location = new System.Drawing.Point(13, 31);
            this.lblAbteilung.Name = "lblAbteilung";
            this.lblAbteilung.Size = new System.Drawing.Size(52, 14);
            this.lblAbteilung.TabIndex = 20;
            this.lblAbteilung.Text = "Abteilung";
            // 
            // cbAbteilung
            // 
            this.cbAbteilung.BackColor = System.Drawing.Color.White;
            this.cbAbteilung.Location = new System.Drawing.Point(101, 27);
            this.cbAbteilung.Name = "cbAbteilung";
            this.cbAbteilung.Size = new System.Drawing.Size(192, 23);
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
            this.txtTitel.Location = new System.Drawing.Point(101, 76);
            this.txtTitel.Name = "txtTitel";
            this.txtTitel.PflichtJN = false;
            this.txtTitel.ShowAddButton = true;
            this.txtTitel.Size = new System.Drawing.Size(128, 21);
            this.txtTitel.sys = false;
            this.txtTitel.TabIndex = 3;
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
            this.txtSexus.Location = new System.Drawing.Point(101, 52);
            this.txtSexus.Name = "txtSexus";
            this.txtSexus.PflichtJN = false;
            this.txtSexus.ShowAddButton = true;
            this.txtSexus.Size = new System.Drawing.Size(128, 21);
            this.txtSexus.sys = false;
            this.txtSexus.TabIndex = 2;
            this.txtSexus.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // chkKontaktbestätigung
            // 
            this.chkKontaktbestätigung.Location = new System.Drawing.Point(13, 520);
            this.chkKontaktbestätigung.Name = "chkKontaktbestätigung";
            this.chkKontaktbestätigung.Size = new System.Drawing.Size(228, 18);
            this.chkKontaktbestätigung.TabIndex = 22;
            this.chkKontaktbestätigung.Text = "Kontaktbestätigung";
            // 
            // ucVersichrungsdaten1
            // 
            this.ucVersichrungsdaten1.BackColor = System.Drawing.Color.Transparent;
            this.ucVersichrungsdaten1.Location = new System.Drawing.Point(12, 272);
            this.ucVersichrungsdaten1.Margin = new System.Windows.Forms.Padding(4);
            this.ucVersichrungsdaten1.Name = "ucVersichrungsdaten1";
            this.ucVersichrungsdaten1.Size = new System.Drawing.Size(550, 241);
            this.ucVersichrungsdaten1.TabIndex = 23;
            this.ucVersichrungsdaten1.ValueChanged += new System.EventHandler(this.OnVersValueChanged);
            this.ucVersichrungsdaten1.KrankenkasseChanged += new System.EventHandler(this.onVersChanged);
            this.ucVersichrungsdaten1.SVNrChanged += new System.EventHandler(this.onVersChanged);
            this.ucVersichrungsdaten1.KlasseChanged += new System.EventHandler(this.onVersChanged);
            this.ucVersichrungsdaten1.PrivatversicherungChanged += new System.EventHandler(this.onVersChanged);
            this.ucVersichrungsdaten1.PolNrChanged += new System.EventHandler(this.onVersChanged);
            // 
            // ucPatientNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.ucVersichrungsdaten1);
            this.Controls.Add(this.chkKontaktbestätigung);
            this.Controls.Add(this.tbSVNr);
            this.Controls.Add(this.cbAbteilung);
            this.Controls.Add(this.lblAbteilung);
            this.Controls.Add(this.dtpAufnahmedatum);
            this.Controls.Add(this.lblAufnahmedatum);
            this.Controls.Add(this.lblSVNr);
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
            this.Size = new System.Drawing.Size(574, 709);
            this.Load += new System.EventHandler(this.ucPatientNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtpGebDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPLZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNachname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAufnahmedatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSexus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKontaktbestätigung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// PATIENT setzen/auslesen
		/// </summary>
		//----------------------------------------------------------------------------
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
				UpdateGUI();
				_valueChangeEnabled = true;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten nach GUI übertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public void UpdateGUI()
		{
            dtpAufnahmedatum.Value     = Patient.Aufenthalt.Aufnahmezeitpunkt; //Neu nach 08.05.2007 MDA
            cbAbteilung.IDAbteilung    = Patient.Aufenthalt.IDAbteilung;
			txtSexus.Text		       = Patient.Sexus;
			txtTitel.Text		       = Patient.Titel;
			txtVorname.Text		       = Patient.Vorname;
			txtNachname.Text	       = Patient.Nachname;
			txtStrasse.Text		       = Patient.Adresse.Strasse;
			txtPLZ.Text			       = Patient.Adresse.Plz;
			txtOrt.Text			       = Patient.Adresse.Ort;
			dtpGebDatum.Value	       = Patient.Geburtsdatum;
            tbSVNr.Text                = Patient.VersicherungsNr;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI nach Daten übertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public void UpdateDATA()
		{
            Patient.Aufenthalt.Aufnahmezeitpunkt = dtpAufnahmedatum.DateTime; //Neu nach 08.05.2007 MDA 

            if (cbAbteilung.IsAbteilungSelected)
            {
                Patient.Aufenthalt.IDAbteilung = cbAbteilung.IDAbteilung;
                Patient.Aufenthalt.AufnahmeVerlauf.IDAbteilung_Nach = cbAbteilung.IDAbteilung;
                Patient.Aufenthalt.IDKlinik = this.cbAbteilung.IDKlinik;
                Patient.Aufenthalt.IDBereich = this.cbAbteilung.IDBereich;
            }

            Patient.Sexus			             = txtSexus.Text;
			Patient.Titel			             = txtTitel.Text;
			Patient.Vorname			             = txtVorname.Text;
			Patient.Nachname		             = txtNachname.Text;
			Patient.Adresse.Strasse	             = txtStrasse.Text;
			Patient.Adresse.Plz		             = txtPLZ.Text;
			Patient.Adresse.Ort		             = txtOrt.Text;
			Patient.Geburtsdatum	             = dtpGebDatum.Value;
            Patient.VersicherungsNr              = tbSVNr.Text.Trim();


            if (Patient.Aufenthalt.IDAbteilung == null)
            {
                throw new Exception("UpdateDATA: Patient.Aufenthalt.IDAbteilung == null not allowed for Patient '" + Patient.Nachname.Trim () + "'!");
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
            
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten-Änderungs signalisieren
		/// </summary>
		//----------------------------------------------------------------------------
		protected void OnValueChanged(object sender, EventArgs args)
		{
			if (_valueChangeEnabled && (ValueChanged != null))
				ValueChanged(sender, args);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Benötigte Felder setzen
		/// </summary>
		//----------------------------------------------------------------------------
		protected void RequiredFields()
		{
            GuiUtil.ValidateRequired(dtpAufnahmedatum);
            GuiUtil.ValidateRequired(cbAbteilung);
			GuiUtil.ValidateRequired(txtSexus);
			GuiUtil.ValidateRequired(txtVorname);
			GuiUtil.ValidateRequired(txtNachname);
			GuiUtil.ValidateRequired(dtpGebDatum);
            GuiUtil.ValidateRequired(tbSVNr);
		}

		private bool _bmodifymode = false;
		public bool MODIFYMODE 
		{
			set 
			{
				_bmodifymode = value;
			}
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

            //Neu nach 08.05.2007 MDA
            // dtpAufnahmedatum
            //GuiUtil.ValidateField(dtpAufnahmedatum, (dtpAufnahmedatum.DateTime <= DateTime.Now),
            //    "Das Datum darf nicht in der Zukunft liegen.", ref bError, bInfo, errorProvider1);
            
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

            // Versicherungsnummer
            GuiUtil.ValidateField(tbSVNr, (tbSVNr.Text.Trim().Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			// Patient darf noch nicht existieren nur bei neuanlage
			if (!_bmodifymode && !bError && Patient.IsUserDefined(txtVorname.Text, txtNachname.Text, dtpGebDatum.DateTime))
			{
				QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("GUI.E_PATIENT_ALREADY_EXISTS"), true);
				bError = true;
			}

			return !bError;
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
            if (_valueChangeEnabled && (ValueChanged != null))
                ValueChanged(sender, args);
        }

    }
}
