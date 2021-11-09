using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using PMDS.Data.PflegePlan;
using PMDS.Global;
using PMDS.BusinessLogic;
using Infragistics.Win;

namespace PMDS.GUI
{


	public class ucPflegePlanSingleEdit : QS2.Desktop.ControlManagment.BaseControl, IReadOnly
	{

		private dsPflegePlan.PflegePlanRow				_row;
		private EintragGruppe							_EintragGruppe = EintragGruppe.A;

        private bool                                    _TransferMode = false;
        public Nullable<Guid> IDDekurs = null;
        public Nullable<Guid> IDExtern = null;
        public bool IsNew = false;

        public string extDatum = "";
        public string extTermin = "";
        public string extWarnung = "";
        public string extAnmerkung = "";
        public bool extEinmaligJN = true;

		private QS2.Desktop.ControlManagment.BaseLabel lblInfoCreated;
		private QS2.Desktop.ControlManagment.BaseLabel lblInfoChanged;
		private QS2.Desktop.ControlManagment.BasePanel pnlInfo;
		private QS2.Desktop.ControlManagment.BasePanel pnlGenerell;
        private QS2.Desktop.ControlManagment.BasePanel pnlM;
        public QS2.Desktop.ControlManagment.BaseTextEditor tbText;
		private QS2.Desktop.ControlManagment.BaseLabel lblBezeichnung;
		private QS2.Desktop.ControlManagment.BaseLabel lblHinweis;
		private QS2.Desktop.ControlManagment.BaseLabel lblAnmerkung;
		private QS2.Desktop.ControlManagment.BaseTextEditor tbAnmerkung;
		private QS2.Desktop.ControlManagment.BaseLabel lblintervallAlle;
		private QS2.Desktop.ControlManagment.BaseOptionSet osIntervall;
		private QS2.Desktop.ControlManagment.BaseOptionSet osEvaluierung;
		private QS2.Desktop.ControlManagment.BaseLabel lblEvaluierungAlle;
		private QS2.Desktop.ControlManagment.BaseCheckBox cbEinmalig;
		private QS2.Desktop.ControlManagment.BasePanel pnlIntervall;
		private QS2.Desktop.ControlManagment.BasePanel pnlEinmalig;
		private QS2.Desktop.ControlManagment.BasePanel pnlLokalisierung;
		private QS2.Desktop.ControlManagment.BaseCheckBox cbLokalisierung;
		private QS2.Desktop.ControlManagment.BaseCheckBox cbParalell;
		private PMDS.GUI.BaseControls.AuswahlGruppeCombo cbSide;
		private PMDS.GUI.BaseControls.AuswahlGruppeCombo cbArea;
		private QS2.Desktop.ControlManagment.BaseLabel lblSeite;
		private QS2.Desktop.ControlManagment.BaseLabel lblKörperteil;
		private QS2.Desktop.ControlManagment.BaseLabel lblDauer;
		private QS2.Desktop.ControlManagment.BaseLabel lblBerufsstand;
		private PMDS.GUI.ucWochenTage ucWochenTage1;
		private QS2.Desktop.ControlManagment.BaseLabel lblWochentage;
		private PMDS.GUI.BaseControls.UserCombo cbChanged;
		private PMDS.GUI.BaseControls.UserCombo cbCreated;
		private QS2.Desktop.ControlManagment.BaseTextEditor tbWarnung;
		private QS2.Desktop.ControlManagment.BaseNumericEditor tbIntervall;
		private QS2.Desktop.ControlManagment.BaseNumericEditor tbEvaluierung;
		private QS2.Desktop.ControlManagment.BaseNumericEditor tbDauer;
		private QS2.Desktop.ControlManagment.BasePanel pnlBerufsstand;
		private PMDS.GUI.BaseControls.AuswahlGruppeCombo cbBerufsstand;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cbTermin;
		private QS2.Desktop.ControlManagment.BaseCheckBox cbRMOptionalJN;
		private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpBenutzer;
		private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpLokalisierung;
		private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpSollwerte;
		private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpDurchführung;
		private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpInformation;
		private QS2.Desktop.ControlManagment.BasePanel pnlUhrzeit;
		private QS2.Desktop.ControlManagment.BaseLabel lblUhrzeit;
		private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpUhrzeit;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpTime;
        private QS2.Desktop.ControlManagment.BaseLabel lblPflegestandard;
        private PMDS.GUI.BaseControls.LinkDokumenteCombo cbLinkDokument;
        private QS2.Desktop.ControlManagment.BasePanel pnlNaechsteEvaluierung;
        private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpNächsteEvaluierung;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpNaechsteEvaluierung;
        public QS2.Desktop.ControlManagment.BaseTextEditor tbNaechsteEvaluierungBemerkung;
        private QS2.Desktop.ControlManagment.BaseLabel lblDatum;
        private QS2.Desktop.ControlManagment.BaseLabel lblAnmerkung2;
        private QS2.Desktop.ControlManagment.BasePanel pnlRMOptional;
        private QS2.Desktop.ControlManagment.BasePanel pnlcbParalell;
        private QS2.Desktop.ControlManagment.BasePanel pnlcbLokalisierung;
        private QS2.Desktop.ControlManagment.BasePanel pnlcbEinmalig;
        private QS2.Desktop.ControlManagment.BaseOptionSet osZeit;
        private PMDS.GUI.BaseControls.ZeitbereichCombo cbZeitbereich;
        private CheckBox cbMohneZeitbezug;
        private QS2.Desktop.ControlManagment.BaseButton btnShow;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkPrivatJN;
        private IContainer components;
        private QS2.Desktop.ControlManagment.BaseLabel lblPflegestufeneinschaetzung;
        private BaseControls.PflegestufenEinschaetzung cbPflegestufenEinschaetzung;
        public bool VisibleIsInitialized = false;








        public ucPflegePlanSingleEdit()
		{
			InitializeComponent();

            cbZeitbereich.Top = dtpTime.Top;            // Visuelle Hilfe korrigieren

            if (!ENV.AppRunning)
                return;

            cbZeitbereich.RefreshList(true);                // Initialisieren
            cbZeitbereich.IDZeitbereich = Guid.Empty;
		}

        public bool TransferMode
        {
            get { return _TransferMode; }
            set { _TransferMode = value; }
        }

        private bool UHRZEIT_VISIBLE
        {
            set
            {
                pnlUhrzeit.Visible = value;
            }
            get
            {
                return pnlUhrzeit.Visible;
            }
        }

        private bool PARALELL_CB_VISIBLE
        {
            set
            {
                cbParalell.Visible = value;
                pnlcbParalell.Visible = value;
            }
            get
            {
                return cbParalell.Visible;
            }
        }

        private void HideFieldsForTransfermode()
        {
            if (TransferMode)
            {
                PARALELL_CB_VISIBLE         = false;
                cbLokalisierung.Visible     = false;
                pnlcbLokalisierung.Visible  = false;
                //Neu nach 04.06.2007 MDA: Text kann geändert werden.
                //tbText.ReadOnly              = true;            // keine Änderung des Textes im Transfermodus
            }
        }

		public bool ISTERMIN 
		{
			get
			{
				return _EintragGruppe == EintragGruppe.T ? true : false;
			}
		}

		[Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsPflegePlan.PflegePlanRow PFLEGEPLANROW 
		{
			set 
			{
				if(value == null)
					return;
				if(DesignMode)
					return;
				_row = value;
				_EintragGruppe = PDx.GetEintragGruppeFromChar(_row.EintragGruppe[0]);
				ShowHideFields();
				RefreshControl();
			}
			get 
			{
				return _row;
			}
		}

        
		private void ShowHideFields()
		{
			if (_row == null)
				return;
            
			if(_EintragGruppe == EintragGruppe.M || _EintragGruppe == EintragGruppe.T) 
			{
				pnlEinmalig.Visible			= true;
				pnlIntervall.Visible		= true;
				pnlBerufsstand.Visible		= true;
				pnlLokalisierung.Visible	= TransferMode ? false : true;	
                pnlRMOptional.Visible       = true;
				if(_EintragGruppe == EintragGruppe.M)
					pnlUhrzeit.Visible			= TransferMode ? false : true;
				else
					pnlUhrzeit.Visible			= false;
			}
			else
			{
				pnlEinmalig.Visible			= false;
				pnlIntervall.Visible		= false;
				pnlBerufsstand.Visible		= false;
				pnlLokalisierung.Visible	= false;
				pnlUhrzeit.Visible			= false;
                pnlRMOptional.Visible       = false;
			}


            // Nächste Evaluierung ist nur im Modus Klient sowie bei den Zielen notwendig
            if (_EintragGruppe == EintragGruppe.Z && ENV.EvaluierungsTyp == EvaluierungsTypen.Ziel)
            {
                pnlNaechsteEvaluierung.Visible = true;
            }
            else
            {
                pnlNaechsteEvaluierung.Visible = false;
            }

			// Bei Termin gibt es eine Auswahlcombo für die Art des Termines
			if(ISTERMIN) 
			{
				cbTermin.Visible	= true;
				tbText.Visible		= false;
			}
			else
			{
				cbTermin.Visible	= false;
				tbText.Visible		= true;
			}

            pnlInfo.Visible = ISTERMIN;                 // 4.7.2007 RBU: Wunsch enz 

            if(TransferMode)                            // Im Transfermodus bestimmte Elemente ausblenden
                HideFieldsForTransfermode();

            RecalcHeight();
		}

		public void RefreshControl() 
		{
			if(System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
				return;
			if(_row == null)
				return;

			cbCreated.Value	= _row.IDBenutzer_Erstellt;
			cbChanged.Value	= _row.IDBenutzer_Geaendert;

			tbText.Text					            = _row.Text;
			
			if(ISTERMIN)				            							// Bei Termin muss die Combo mit dem Wert befüllt werden
				cbTermin.Text			            = _row.Text;

			tbWarnung.Text				            = _row.Warnhinweis;
			tbAnmerkung.Text			            = _row.Anmerkung;
            this.chkPrivatJN.Checked = _row.PrivatJN;

            tbNaechsteEvaluierungBemerkung.Text     = _row.NaechsteEvaluierungBemerkung;
            if (_row.IsNaechsteEvaluierungNull())
                dtpNaechsteEvaluierung.DateTime = new DateTime(1900, 1, 1);
            else
                dtpNaechsteEvaluierung.DateTime = _row.NaechsteEvaluierung;

            if (_row.IsIDLinkDokumentNull())
                cbLinkDokument.IDLinkDokument = Guid.Empty;
            else
                cbLinkDokument.IDLinkDokument = _row.IDLinkDokument;

			if(!(_EintragGruppe == EintragGruppe.M || _EintragGruppe == EintragGruppe.T))					               
				return;


            // Alles folgende gilt nur für Maßnahmen
            cbEinmalig.Checked			    = _row.EinmaligJN;
			cbRMOptionalJN.Checked		    = _row.RMOptionalJN;
			cbLokalisierung.Checked		    = _row.LokalisierungJN;
			cbParalell.Checked			    = _row.ParalellJN;
			ucWochenTage1.WOCHENTAGE	    = _row.WochenTage;
			tbDauer.Value				    = _row.Dauer;
			cbBerufsstand.Value			    = _row.IDBerufsstand;
			cbArea.Text					    = _row.Lokalisierung.Trim();
			cbSide.Text					    = _row.LokalisierungSeite.Trim();
			dtpTime.Value				    = _row.StartDatum;
            extDatum                        = _row.StartDatum.ToString();
            cbMohneZeitbezug.Checked        = _row.OhneZeitBezug;
            if (ENV.lic_PflegestufenEinschätzung)
            {
                cbPflegestufenEinschaetzung.PSEKlasse = _row.PSEKlasse;
            }

            if (!_row.IsIDZeitbereichNull())                            // Zeitbereich
            {
                osZeit.CheckedIndex = 1;
                cbZeitbereich.IDZeitbereich = _row.IDZeitbereich;
            }
            else
            {
                osZeit.CheckedIndex = 0;
                cbZeitbereich.IDZeitbereich = Guid.Empty;
            }

			if(_row.Intervall % (24*7) == 0)							// woche
			{
				tbIntervall.Value = _row.Intervall / 24 / 7;			
				osIntervall.CheckedIndex = 1;
			} 
			else if (_row.Intervall % 24 == 0)							// Tage
			{
				tbIntervall.Value = _row.Intervall / 24;			
				osIntervall.CheckedIndex = 0;
			}


			if(_row.EvalTage % (24*7) == 0)								// woche
			{
				tbEvaluierung.Value = _row.EvalTage / 24 / 7;			
				osEvaluierung.CheckedIndex = 1;
			} 
			else if (_row.EvalTage % 24 == 0)								
			{
				tbEvaluierung.Value = _row.EvalTage / 24;				// Tage
				osEvaluierung.CheckedIndex = 0;
			}

			cbLokalisierung_CheckedChanged(this,null);

            SetShowbuttonEnabled();
		}


		public bool IsOriginalModified()
		{
			return IsOriginalModified(_row.IDEintrag, tbText.Text.Trim());
		}

		private bool IsOriginalModified(Guid IDEintrag, string sNewText) 
		{
			string sOriginal = Eintrag.GetText(IDEintrag);
			if(sNewText.IndexOf(sOriginal) > -1)					// gefunden ==> original
				return false;
			else
				return true;

		}

		public void AcceptChanges() 
		{
			string sText = "";
			if(ISTERMIN)
            {
                sText = cbTermin.Text.Trim();
                if (ENV.lic_PflegestufenEinschätzung)
                {
                    _row.PSEKlasse = cbPflegestufenEinschaetzung.Text;
                }
            }
            else
				sText = tbText.Text.Trim();

			bool bOriginalModified = false;
			if(!ISTERMIN && !_row.IsIDEintragNull())
				bOriginalModified =  IsOriginalModified(_row.IDEintrag, sText);

			if(bOriginalModified)
				_row.OriginalJN = false;
			else
				_row.OriginalJN = true;

			_row.Text	= sText;
			_row.Warnhinweis			= tbWarnung.Text.Trim();
			_row.Anmerkung				= tbAnmerkung.Text.Trim();
            _row.PrivatJN = this.chkPrivatJN.Checked;
            if(this.IsNew)
            {
                if (this.IDDekurs != null)
                {
                    _row.IDDekurs = (Guid)this.IDDekurs;
                }
                else
                {
                    _row.SetIDDekursNull();
                }
            }
            if (this.IsNew)
            {
                if (this.IDExtern != null)
                {
                    _row.IDExtern = (Guid)this.IDExtern;
                }
                else
                {
                    _row.SetIDExternNull();
                }
            }

            if (cbLinkDokument.IDLinkDokument == Guid.Empty)
                _row.SetIDLinkDokumentNull();
            else
                _row.IDLinkDokument = cbLinkDokument.IDLinkDokument;

            _row.NaechsteEvaluierungBemerkung = tbNaechsteEvaluierungBemerkung.Text.Trim();
            if (dtpNaechsteEvaluierung.DateTime.Date == new DateTime(1900, 1, 1))
                _row.SetNaechsteEvaluierungNull();
            else
                _row.NaechsteEvaluierung = dtpNaechsteEvaluierung.DateTime.Date;


			if(! (_EintragGruppe == EintragGruppe.M || _EintragGruppe == EintragGruppe.T))					// Alles folgende gilt nur für Maßnahmen
				return;

			_row.EinmaligJN				= cbEinmalig.Checked ? true : false;
			_row.RMOptionalJN			= cbRMOptionalJN.Checked ? true : false;
			_row.LokalisierungJN		= cbLokalisierung.Checked ? true : false;
			_row.ParalellJN				= cbParalell.Checked ? true : false;
			_row.WochenTage				= ucWochenTage1.WOCHENTAGE;
			_row.Dauer					= (int)tbDauer.Value;
			_row.IDBerufsstand			= cbBerufsstand.Value == null ? Guid.Empty : (Guid)cbBerufsstand.Value;
			_row.Lokalisierung			= cbArea.Text.Trim();
			_row.LokalisierungSeite		= cbSide.Text.Trim();

			DateTime dt					= _row.StartDatum;
			DateTime dtt				= dtpTime.DateTime;
			_row.StartDatum				= new DateTime(dt.Year,dt.Month, dt.Day, dtt.Hour, dtt.Minute, 0);		// Startdatum gemäß Uhrzeit setzen
            _row.OhneZeitBezug          = cbMohneZeitbezug.Checked;

            

			
			if(!_row.IsLetztesDatumNull()) 
			{
				DateTime dtl				= _row.LetztesDatum;
				_row.LetztesDatum			= new DateTime(dtl.Year,dtl.Month, dtl.Day, dtt.Hour, dtt.Minute, 0);	// Das letzte Datum muss mit der Uhrzeit korrespondieren
			}

            // Bei Fixzeit alles wie gehabt. Sonst ist der Startpunkt des Zeitbereiches gleich die Zeit des Startdatums
            if (IS_FIXEZEIT)
            {
                _row.ZuErledigenBis = _row.StartDatum;
                _row.SetIDZeitbereichNull();
            }
            else    // Uhrzeiten korrigieren gemäß der von Uhrzeit des Zeitbereiches
            {
                _row.ZuErledigenBis = cbZeitbereich.BIS_SELECTED;
                _row.StartDatum     = new DateTime(_row.StartDatum.Year,    _row.StartDatum.Month,   _row.StartDatum.Day,   cbZeitbereich.VON_SELECTED.Hour, cbZeitbereich.VON_SELECTED.Minute, 0);
                if (!_row.IsLetztesDatumNull()) 
                    _row.LetztesDatum   = new DateTime(_row.LetztesDatum.Year,  _row.LetztesDatum.Month, _row.LetztesDatum.Day, cbZeitbereich.VON_SELECTED.Hour, cbZeitbereich.VON_SELECTED.Minute, 0);	// Das letzte Datum muss mit der Uhrzeit korrespondieren
                _row.IDZeitbereich = cbZeitbereich.IDZeitbereich;

            }

			switch(osIntervall.CheckedIndex)
			{
				case 0:
					_row.Intervall		= (int)tbIntervall.Value * 24;		// Tage
					break;
				case 1:	
					_row.Intervall		= (int)tbIntervall.Value * 168;	// Wochen
					break;
                case 2:
                    _row.Intervall = (int)tbIntervall.Value * 721;	// Monate
                    break;

			}

			switch(osEvaluierung.CheckedIndex)
			{
				case 0:
					_row.EvalTage		= (int)tbEvaluierung.Value * 24;	// Tage
					break;
				case 1:	
					_row.EvalTage		= (int)tbEvaluierung.Value * 168;	// Wochen
					break;
                case 2:
                    _row.EvalTage       = (int)tbEvaluierung.Value * 721;	// Monate
                    break;

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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.lblInfoCreated = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblInfoChanged = new QS2.Desktop.ControlManagment.BaseLabel();
            this.pnlInfo = new QS2.Desktop.ControlManagment.BasePanel();
            this.grpBenutzer = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.chkPrivatJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.pnlGenerell = new QS2.Desktop.ControlManagment.BasePanel();
            this.grpInformation = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.btnShow = new QS2.Desktop.ControlManagment.BaseButton();
            this.lblBezeichnung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblPflegestandard = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblHinweis = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbText = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblAnmerkung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbWarnung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.tbAnmerkung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.pnlM = new QS2.Desktop.ControlManagment.BasePanel();
            this.pnlNaechsteEvaluierung = new QS2.Desktop.ControlManagment.BasePanel();
            this.grpNächsteEvaluierung = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.dtpNaechsteEvaluierung = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.tbNaechsteEvaluierungBemerkung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblDatum = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblAnmerkung2 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.pnlLokalisierung = new QS2.Desktop.ControlManagment.BasePanel();
            this.grpLokalisierung = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.lblSeite = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblKörperteil = new QS2.Desktop.ControlManagment.BaseLabel();
            this.pnlBerufsstand = new QS2.Desktop.ControlManagment.BasePanel();
            this.grpSollwerte = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.lblPflegestufeneinschaetzung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbDauer = new QS2.Desktop.ControlManagment.BaseNumericEditor();
            this.lblBerufsstand = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblDauer = new QS2.Desktop.ControlManagment.BaseLabel();
            this.pnlIntervall = new QS2.Desktop.ControlManagment.BasePanel();
            this.grpDurchführung = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.cbMohneZeitbezug = new System.Windows.Forms.CheckBox();
            this.tbIntervall = new QS2.Desktop.ControlManagment.BaseNumericEditor();
            this.lblWochentage = new QS2.Desktop.ControlManagment.BaseLabel();
            this.osIntervall = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.osEvaluierung = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.tbEvaluierung = new QS2.Desktop.ControlManagment.BaseNumericEditor();
            this.lblEvaluierungAlle = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblintervallAlle = new QS2.Desktop.ControlManagment.BaseLabel();
            this.pnlEinmalig = new QS2.Desktop.ControlManagment.BasePanel();
            this.pnlRMOptional = new QS2.Desktop.ControlManagment.BasePanel();
            this.cbRMOptionalJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.pnlcbParalell = new QS2.Desktop.ControlManagment.BasePanel();
            this.cbParalell = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.pnlcbLokalisierung = new QS2.Desktop.ControlManagment.BasePanel();
            this.cbLokalisierung = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.pnlcbEinmalig = new QS2.Desktop.ControlManagment.BasePanel();
            this.cbEinmalig = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.pnlUhrzeit = new QS2.Desktop.ControlManagment.BasePanel();
            this.grpUhrzeit = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.dtpTime = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblUhrzeit = new QS2.Desktop.ControlManagment.BaseLabel();
            this.osZeit = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.cbPflegestufenEinschaetzung = new PMDS.GUI.BaseControls.PflegestufenEinschaetzung();
            this.cbBerufsstand = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.ucWochenTage1 = new PMDS.GUI.ucWochenTage();
            this.cbArea = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.cbSide = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.cbLinkDokument = new PMDS.GUI.BaseControls.LinkDokumenteCombo();
            this.cbTermin = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.cbChanged = new PMDS.GUI.BaseControls.UserCombo();
            this.cbCreated = new PMDS.GUI.BaseControls.UserCombo();
            this.cbZeitbereich = new PMDS.GUI.BaseControls.ZeitbereichCombo();
            this.pnlInfo.SuspendLayout();
            this.grpBenutzer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrivatJN)).BeginInit();
            this.pnlGenerell.SuspendLayout();
            this.grpInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbWarnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAnmerkung)).BeginInit();
            this.pnlM.SuspendLayout();
            this.pnlNaechsteEvaluierung.SuspendLayout();
            this.grpNächsteEvaluierung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNaechsteEvaluierung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNaechsteEvaluierungBemerkung)).BeginInit();
            this.pnlLokalisierung.SuspendLayout();
            this.grpLokalisierung.SuspendLayout();
            this.pnlBerufsstand.SuspendLayout();
            this.grpSollwerte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDauer)).BeginInit();
            this.pnlIntervall.SuspendLayout();
            this.grpDurchführung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbIntervall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osIntervall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osEvaluierung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbEvaluierung)).BeginInit();
            this.pnlEinmalig.SuspendLayout();
            this.pnlRMOptional.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbRMOptionalJN)).BeginInit();
            this.pnlcbParalell.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbParalell)).BeginInit();
            this.pnlcbLokalisierung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbLokalisierung)).BeginInit();
            this.pnlcbEinmalig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbEinmalig)).BeginInit();
            this.pnlUhrzeit.SuspendLayout();
            this.grpUhrzeit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osZeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPflegestufenEinschaetzung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBerufsstand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLinkDokument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTermin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbChanged)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCreated)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbZeitbereich)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfoCreated
            // 
            this.lblInfoCreated.Location = new System.Drawing.Point(24, 24);
            this.lblInfoCreated.Name = "lblInfoCreated";
            this.lblInfoCreated.Size = new System.Drawing.Size(72, 16);
            this.lblInfoCreated.TabIndex = 0;
            this.lblInfoCreated.Text = "Erstellt von";
            // 
            // lblInfoChanged
            // 
            this.lblInfoChanged.Location = new System.Drawing.Point(266, 24);
            this.lblInfoChanged.Name = "lblInfoChanged";
            this.lblInfoChanged.Size = new System.Drawing.Size(80, 16);
            this.lblInfoChanged.TabIndex = 1;
            this.lblInfoChanged.Text = "Geändert von";
            // 
            // pnlInfo
            // 
            this.pnlInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInfo.Controls.Add(this.grpBenutzer);
            this.pnlInfo.Location = new System.Drawing.Point(0, 69);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(552, 50);
            this.pnlInfo.TabIndex = 0;
            this.pnlInfo.Visible = false;
            // 
            // grpBenutzer
            // 
            this.grpBenutzer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBenutzer.Controls.Add(this.lblInfoCreated);
            this.grpBenutzer.Controls.Add(this.cbChanged);
            this.grpBenutzer.Controls.Add(this.cbCreated);
            this.grpBenutzer.Controls.Add(this.lblInfoChanged);
            this.grpBenutzer.Location = new System.Drawing.Point(8, 0);
            this.grpBenutzer.Name = "grpBenutzer";
            this.grpBenutzer.Size = new System.Drawing.Size(525, 50);
            this.grpBenutzer.TabIndex = 2;
            this.grpBenutzer.TabStop = false;
            this.grpBenutzer.Text = "Benutzer";
            // 
            // chkPrivatJN
            // 
            this.chkPrivatJN.Location = new System.Drawing.Point(112, 51);
            this.chkPrivatJN.Name = "chkPrivatJN";
            this.chkPrivatJN.Size = new System.Drawing.Size(55, 17);
            this.chkPrivatJN.TabIndex = 2;
            this.chkPrivatJN.Text = "Privat";
            // 
            // pnlGenerell
            // 
            this.pnlGenerell.Controls.Add(this.grpInformation);
            this.pnlGenerell.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGenerell.Location = new System.Drawing.Point(0, 69);
            this.pnlGenerell.Name = "pnlGenerell";
            this.pnlGenerell.Size = new System.Drawing.Size(636, 190);
            this.pnlGenerell.TabIndex = 1;
            // 
            // grpInformation
            // 
            this.grpInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInformation.Controls.Add(this.btnShow);
            this.grpInformation.Controls.Add(this.lblBezeichnung);
            this.grpInformation.Controls.Add(this.cbLinkDokument);
            this.grpInformation.Controls.Add(this.lblPflegestandard);
            this.grpInformation.Controls.Add(this.lblHinweis);
            this.grpInformation.Controls.Add(this.cbTermin);
            this.grpInformation.Controls.Add(this.tbText);
            this.grpInformation.Controls.Add(this.lblAnmerkung);
            this.grpInformation.Controls.Add(this.tbWarnung);
            this.grpInformation.Controls.Add(this.tbAnmerkung);
            this.grpInformation.Location = new System.Drawing.Point(8, 0);
            this.grpInformation.Name = "grpInformation";
            this.grpInformation.Size = new System.Drawing.Size(625, 185);
            this.grpInformation.TabIndex = 7;
            this.grpInformation.TabStop = false;
            this.grpInformation.Text = "Informationen";
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.AutoWorkLayout = false;
            this.btnShow.IsStandardControl = false;
            this.btnShow.Location = new System.Drawing.Point(526, 158);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(83, 21);
            this.btnShow.TabIndex = 12;
            this.btnShow.Text = "anzeigen";
            this.btnShow.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // lblBezeichnung
            // 
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.lblBezeichnung.Appearance = appearance3;
            this.lblBezeichnung.Location = new System.Drawing.Point(24, 20);
            this.lblBezeichnung.Name = "lblBezeichnung";
            this.lblBezeichnung.Size = new System.Drawing.Size(80, 16);
            this.lblBezeichnung.TabIndex = 2;
            this.lblBezeichnung.Text = "Bezeichnung";
            // 
            // lblPflegestandard
            // 
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.lblPflegestandard.Appearance = appearance4;
            this.lblPflegestandard.Location = new System.Drawing.Point(24, 160);
            this.lblPflegestandard.Name = "lblPflegestandard";
            this.lblPflegestandard.Size = new System.Drawing.Size(80, 16);
            this.lblPflegestandard.TabIndex = 7;
            this.lblPflegestandard.Text = "Pflegestandard";
            // 
            // lblHinweis
            // 
            appearance5.TextHAlignAsString = "Left";
            appearance5.TextVAlignAsString = "Middle";
            this.lblHinweis.Appearance = appearance5;
            this.lblHinweis.Location = new System.Drawing.Point(24, 81);
            this.lblHinweis.Name = "lblHinweis";
            this.lblHinweis.Size = new System.Drawing.Size(80, 16);
            this.lblHinweis.TabIndex = 4;
            this.lblHinweis.Text = "Hinweis";
            // 
            // tbText
            // 
            this.tbText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbText.Location = new System.Drawing.Point(112, 20);
            this.tbText.MaxLength = 255;
            this.tbText.Multiline = true;
            this.tbText.Name = "tbText";
            this.tbText.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbText.Size = new System.Drawing.Size(497, 57);
            this.tbText.TabIndex = 1;
            // 
            // lblAnmerkung
            // 
            appearance6.TextHAlignAsString = "Left";
            appearance6.TextVAlignAsString = "Middle";
            this.lblAnmerkung.Appearance = appearance6;
            this.lblAnmerkung.Location = new System.Drawing.Point(24, 118);
            this.lblAnmerkung.Name = "lblAnmerkung";
            this.lblAnmerkung.Size = new System.Drawing.Size(80, 16);
            this.lblAnmerkung.TabIndex = 6;
            this.lblAnmerkung.Text = "Anmerkung";
            // 
            // tbWarnung
            // 
            this.tbWarnung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWarnung.Location = new System.Drawing.Point(112, 81);
            this.tbWarnung.MaxLength = 255;
            this.tbWarnung.Multiline = true;
            this.tbWarnung.Name = "tbWarnung";
            this.tbWarnung.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbWarnung.Size = new System.Drawing.Size(497, 34);
            this.tbWarnung.TabIndex = 2;
            this.tbWarnung.ValueChanged += new System.EventHandler(this.tbWarnung_ValueChanged);
            // 
            // tbAnmerkung
            // 
            this.tbAnmerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAnmerkung.Location = new System.Drawing.Point(112, 118);
            this.tbAnmerkung.MaxLength = 255;
            this.tbAnmerkung.Multiline = true;
            this.tbAnmerkung.Name = "tbAnmerkung";
            this.tbAnmerkung.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbAnmerkung.Size = new System.Drawing.Size(497, 34);
            this.tbAnmerkung.TabIndex = 3;
            this.tbAnmerkung.ValueChanged += new System.EventHandler(this.tbAnmerkung_ValueChanged);
            // 
            // pnlM
            // 
            this.pnlM.Controls.Add(this.pnlBerufsstand);
            this.pnlM.Controls.Add(this.pnlIntervall);
            this.pnlM.Controls.Add(this.pnlLokalisierung);
            this.pnlM.Controls.Add(this.pnlNaechsteEvaluierung);
            this.pnlM.Controls.Add(this.pnlEinmalig);
            this.pnlM.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlM.Location = new System.Drawing.Point(0, 259);
            this.pnlM.Name = "pnlM";
            this.pnlM.Size = new System.Drawing.Size(636, 442);
            this.pnlM.TabIndex = 4;
            // 
            // pnlNaechsteEvaluierung
            // 
            this.pnlNaechsteEvaluierung.Controls.Add(this.grpNächsteEvaluierung);
            this.pnlNaechsteEvaluierung.Location = new System.Drawing.Point(3, 247);
            this.pnlNaechsteEvaluierung.Name = "pnlNaechsteEvaluierung";
            this.pnlNaechsteEvaluierung.Size = new System.Drawing.Size(636, 120);
            this.pnlNaechsteEvaluierung.TabIndex = 8;
            // 
            // grpNächsteEvaluierung
            // 
            this.grpNächsteEvaluierung.Controls.Add(this.dtpNaechsteEvaluierung);
            this.grpNächsteEvaluierung.Controls.Add(this.tbNaechsteEvaluierungBemerkung);
            this.grpNächsteEvaluierung.Controls.Add(this.lblDatum);
            this.grpNächsteEvaluierung.Controls.Add(this.lblAnmerkung2);
            this.grpNächsteEvaluierung.Location = new System.Drawing.Point(3, 3);
            this.grpNächsteEvaluierung.Name = "grpNächsteEvaluierung";
            this.grpNächsteEvaluierung.Size = new System.Drawing.Size(627, 113);
            this.grpNächsteEvaluierung.TabIndex = 16;
            this.grpNächsteEvaluierung.TabStop = false;
            this.grpNächsteEvaluierung.Text = "nächste Evaluierung";
            // 
            // dtpNaechsteEvaluierung
            // 
            this.dtpNaechsteEvaluierung.Location = new System.Drawing.Point(92, 19);
            this.dtpNaechsteEvaluierung.Name = "dtpNaechsteEvaluierung";
            this.dtpNaechsteEvaluierung.ownFormat = "";
            this.dtpNaechsteEvaluierung.ownMaskInput = "";
            this.dtpNaechsteEvaluierung.Size = new System.Drawing.Size(106, 21);
            this.dtpNaechsteEvaluierung.TabIndex = 20;
            // 
            // tbNaechsteEvaluierungBemerkung
            // 
            this.tbNaechsteEvaluierungBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNaechsteEvaluierungBemerkung.Location = new System.Drawing.Point(92, 46);
            this.tbNaechsteEvaluierungBemerkung.MaxLength = 255;
            this.tbNaechsteEvaluierungBemerkung.Multiline = true;
            this.tbNaechsteEvaluierungBemerkung.Name = "tbNaechsteEvaluierungBemerkung";
            this.tbNaechsteEvaluierungBemerkung.Size = new System.Drawing.Size(519, 57);
            this.tbNaechsteEvaluierungBemerkung.TabIndex = 21;
            // 
            // lblDatum
            // 
            this.lblDatum.Location = new System.Drawing.Point(13, 23);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(108, 14);
            this.lblDatum.TabIndex = 23;
            this.lblDatum.Text = "Datum";
            // 
            // lblAnmerkung2
            // 
            this.lblAnmerkung2.Location = new System.Drawing.Point(13, 48);
            this.lblAnmerkung2.Name = "lblAnmerkung2";
            this.lblAnmerkung2.Size = new System.Drawing.Size(108, 14);
            this.lblAnmerkung2.TabIndex = 22;
            this.lblAnmerkung2.Text = "Anmerkung";
            // 
            // pnlLokalisierung
            // 
            this.pnlLokalisierung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLokalisierung.Controls.Add(this.grpLokalisierung);
            this.pnlLokalisierung.Location = new System.Drawing.Point(0, 373);
            this.pnlLokalisierung.Name = "pnlLokalisierung";
            this.pnlLokalisierung.Size = new System.Drawing.Size(636, 58);
            this.pnlLokalisierung.TabIndex = 5;
            // 
            // grpLokalisierung
            // 
            this.grpLokalisierung.Controls.Add(this.lblSeite);
            this.grpLokalisierung.Controls.Add(this.lblKörperteil);
            this.grpLokalisierung.Controls.Add(this.cbArea);
            this.grpLokalisierung.Controls.Add(this.cbSide);
            this.grpLokalisierung.Location = new System.Drawing.Point(6, 8);
            this.grpLokalisierung.Name = "grpLokalisierung";
            this.grpLokalisierung.Size = new System.Drawing.Size(627, 50);
            this.grpLokalisierung.TabIndex = 14;
            this.grpLokalisierung.TabStop = false;
            this.grpLokalisierung.Text = "Lokalisierung";
            // 
            // lblSeite
            // 
            this.lblSeite.Location = new System.Drawing.Point(273, 24);
            this.lblSeite.Name = "lblSeite";
            this.lblSeite.Size = new System.Drawing.Size(40, 16);
            this.lblSeite.TabIndex = 13;
            this.lblSeite.Text = "Seite";
            // 
            // lblKörperteil
            // 
            this.lblKörperteil.Location = new System.Drawing.Point(24, 24);
            this.lblKörperteil.Name = "lblKörperteil";
            this.lblKörperteil.Size = new System.Drawing.Size(80, 16);
            this.lblKörperteil.TabIndex = 12;
            this.lblKörperteil.Text = "Körperteil";
            // 
            // pnlBerufsstand
            // 
            this.pnlBerufsstand.Controls.Add(this.grpSollwerte);
            this.pnlBerufsstand.Location = new System.Drawing.Point(0, 146);
            this.pnlBerufsstand.Name = "pnlBerufsstand";
            this.pnlBerufsstand.Size = new System.Drawing.Size(636, 95);
            this.pnlBerufsstand.TabIndex = 4;
            // 
            // grpSollwerte
            // 
            this.grpSollwerte.Controls.Add(this.lblPflegestufeneinschaetzung);
            this.grpSollwerte.Controls.Add(this.cbPflegestufenEinschaetzung);
            this.grpSollwerte.Controls.Add(this.chkPrivatJN);
            this.grpSollwerte.Controls.Add(this.tbDauer);
            this.grpSollwerte.Controls.Add(this.cbBerufsstand);
            this.grpSollwerte.Controls.Add(this.lblBerufsstand);
            this.grpSollwerte.Controls.Add(this.lblDauer);
            this.grpSollwerte.Location = new System.Drawing.Point(7, 3);
            this.grpSollwerte.Name = "grpSollwerte";
            this.grpSollwerte.Size = new System.Drawing.Size(626, 78);
            this.grpSollwerte.TabIndex = 9;
            this.grpSollwerte.TabStop = false;
            this.grpSollwerte.Text = "Sollwerte";
            // 
            // lblPflegestufeneinschaetzung
            // 
            this.lblPflegestufeneinschaetzung.Location = new System.Drawing.Point(185, 48);
            this.lblPflegestufeneinschaetzung.Name = "lblPflegestufeneinschaetzung";
            this.lblPflegestufeneinschaetzung.Padding = new System.Drawing.Size(0, 4);
            this.lblPflegestufeneinschaetzung.Size = new System.Drawing.Size(66, 23);
            this.lblPflegestufeneinschaetzung.TabIndex = 134;
            this.lblPflegestufeneinschaetzung.Text = "PSE-Krit.:";
            // 
            // tbDauer
            // 
            this.tbDauer.Location = new System.Drawing.Point(112, 22);
            this.tbDauer.MaskInput = "nnnn";
            this.tbDauer.MaxValue = 9999;
            this.tbDauer.MinValue = 0;
            this.tbDauer.Name = "tbDauer";
            this.tbDauer.PromptChar = ' ';
            this.tbDauer.Size = new System.Drawing.Size(48, 21);
            this.tbDauer.TabIndex = 0;
            // 
            // lblBerufsstand
            // 
            appearance7.TextHAlignAsString = "Left";
            appearance7.TextVAlignAsString = "Middle";
            this.lblBerufsstand.Appearance = appearance7;
            this.lblBerufsstand.Location = new System.Drawing.Point(185, 24);
            this.lblBerufsstand.Name = "lblBerufsstand";
            this.lblBerufsstand.Size = new System.Drawing.Size(96, 16);
            this.lblBerufsstand.TabIndex = 7;
            this.lblBerufsstand.Text = "Berufsstand";
            // 
            // lblDauer
            // 
            appearance8.TextHAlignAsString = "Left";
            appearance8.TextVAlignAsString = "Middle";
            this.lblDauer.Appearance = appearance8;
            this.lblDauer.Location = new System.Drawing.Point(24, 24);
            this.lblDauer.Name = "lblDauer";
            this.lblDauer.Size = new System.Drawing.Size(86, 16);
            this.lblDauer.TabIndex = 5;
            this.lblDauer.Text = "Dauer (Minuten)";
            // 
            // pnlIntervall
            // 
            this.pnlIntervall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlIntervall.Controls.Add(this.grpDurchführung);
            this.pnlIntervall.Location = new System.Drawing.Point(0, 35);
            this.pnlIntervall.Name = "pnlIntervall";
            this.pnlIntervall.Size = new System.Drawing.Size(635, 108);
            this.pnlIntervall.TabIndex = 2;
            // 
            // grpDurchführung
            // 
            this.grpDurchführung.Controls.Add(this.cbMohneZeitbezug);
            this.grpDurchführung.Controls.Add(this.tbIntervall);
            this.grpDurchführung.Controls.Add(this.lblWochentage);
            this.grpDurchführung.Controls.Add(this.osIntervall);
            this.grpDurchführung.Controls.Add(this.osEvaluierung);
            this.grpDurchführung.Controls.Add(this.tbEvaluierung);
            this.grpDurchführung.Controls.Add(this.lblEvaluierungAlle);
            this.grpDurchführung.Controls.Add(this.ucWochenTage1);
            this.grpDurchführung.Controls.Add(this.lblintervallAlle);
            this.grpDurchführung.Location = new System.Drawing.Point(6, 3);
            this.grpDurchführung.Name = "grpDurchführung";
            this.grpDurchführung.Size = new System.Drawing.Size(627, 102);
            this.grpDurchführung.TabIndex = 11;
            this.grpDurchführung.TabStop = false;
            this.grpDurchführung.Text = "Durchführung ";
            // 
            // cbMohneZeitbezug
            // 
            this.cbMohneZeitbezug.AutoSize = true;
            this.cbMohneZeitbezug.Location = new System.Drawing.Point(24, 22);
            this.cbMohneZeitbezug.Name = "cbMohneZeitbezug";
            this.cbMohneZeitbezug.Size = new System.Drawing.Size(156, 17);
            this.cbMohneZeitbezug.TabIndex = 11;
            this.cbMohneZeitbezug.Text = "Maßnahme ohne Zeitbezug";
            this.cbMohneZeitbezug.UseVisualStyleBackColor = true;
            // 
            // tbIntervall
            // 
            this.tbIntervall.Location = new System.Drawing.Point(112, 47);
            this.tbIntervall.MaskInput = "nnnn";
            this.tbIntervall.MaxValue = 9999;
            this.tbIntervall.MinValue = 0;
            this.tbIntervall.Name = "tbIntervall";
            this.tbIntervall.PromptChar = ' ';
            this.tbIntervall.Size = new System.Drawing.Size(30, 21);
            this.tbIntervall.TabIndex = 0;
            // 
            // lblWochentage
            // 
            appearance9.TextHAlignAsString = "Left";
            appearance9.TextVAlignAsString = "Middle";
            this.lblWochentage.Appearance = appearance9;
            this.lblWochentage.Location = new System.Drawing.Point(24, 71);
            this.lblWochentage.Name = "lblWochentage";
            this.lblWochentage.Size = new System.Drawing.Size(80, 16);
            this.lblWochentage.TabIndex = 10;
            this.lblWochentage.Text = "Wochentage";
            // 
            // osIntervall
            // 
            this.osIntervall.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            valueListItem1.DataValue = "ValueListItem1";
            valueListItem1.DisplayText = "Tage";
            valueListItem2.DataValue = "ValueListItem2";
            valueListItem2.DisplayText = "Wochen";
            valueListItem7.DataValue = "ValueListItem3";
            valueListItem7.DisplayText = "Monate";
            this.osIntervall.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem7});
            this.osIntervall.ItemSpacingVertical = 2;
            this.osIntervall.Location = new System.Drawing.Point(148, 50);
            this.osIntervall.Name = "osIntervall";
            this.osIntervall.Size = new System.Drawing.Size(176, 15);
            this.osIntervall.TabIndex = 1;
            // 
            // osEvaluierung
            // 
            this.osEvaluierung.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            valueListItem3.DataValue = "ValueListItem1";
            valueListItem3.DisplayText = "Tage";
            valueListItem4.DataValue = "ValueListItem2";
            valueListItem4.DisplayText = "Wochen";
            valueListItem8.DataValue = "ValueListItem3";
            valueListItem8.DisplayText = "Monate";
            this.osEvaluierung.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4,
            valueListItem8});
            this.osEvaluierung.ItemSpacingVertical = 2;
            this.osEvaluierung.Location = new System.Drawing.Point(395, 41);
            this.osEvaluierung.Name = "osEvaluierung";
            this.osEvaluierung.Size = new System.Drawing.Size(216, 27);
            this.osEvaluierung.TabIndex = 4;
            this.osEvaluierung.Visible = false;
            // 
            // tbEvaluierung
            // 
            this.tbEvaluierung.Location = new System.Drawing.Point(357, 38);
            this.tbEvaluierung.MaskInput = "nnnn";
            this.tbEvaluierung.MaxValue = 9999;
            this.tbEvaluierung.MinValue = 0;
            this.tbEvaluierung.Name = "tbEvaluierung";
            this.tbEvaluierung.PromptChar = ' ';
            this.tbEvaluierung.Size = new System.Drawing.Size(32, 21);
            this.tbEvaluierung.TabIndex = 3;
            this.tbEvaluierung.Visible = false;
            this.tbEvaluierung.ValueChanged += new System.EventHandler(this.tbEvaluierung_ValueChanged);
            // 
            // lblEvaluierungAlle
            // 
            appearance10.TextHAlignAsString = "Left";
            appearance10.TextVAlignAsString = "Middle";
            this.lblEvaluierungAlle.Appearance = appearance10;
            this.lblEvaluierungAlle.Location = new System.Drawing.Point(357, 19);
            this.lblEvaluierungAlle.Name = "lblEvaluierungAlle";
            this.lblEvaluierungAlle.Size = new System.Drawing.Size(88, 16);
            this.lblEvaluierungAlle.TabIndex = 2;
            this.lblEvaluierungAlle.Text = "Evaluierung alle";
            this.lblEvaluierungAlle.Visible = false;
            // 
            // lblintervallAlle
            // 
            appearance11.TextHAlignAsString = "Left";
            appearance11.TextVAlignAsString = "Middle";
            this.lblintervallAlle.Appearance = appearance11;
            this.lblintervallAlle.Location = new System.Drawing.Point(24, 47);
            this.lblintervallAlle.Name = "lblintervallAlle";
            this.lblintervallAlle.Size = new System.Drawing.Size(72, 16);
            this.lblintervallAlle.TabIndex = 3;
            this.lblintervallAlle.Text = "Intervall alle";
            // 
            // pnlEinmalig
            // 
            this.pnlEinmalig.Controls.Add(this.pnlRMOptional);
            this.pnlEinmalig.Controls.Add(this.pnlcbParalell);
            this.pnlEinmalig.Controls.Add(this.pnlcbLokalisierung);
            this.pnlEinmalig.Controls.Add(this.pnlcbEinmalig);
            this.pnlEinmalig.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEinmalig.Location = new System.Drawing.Point(0, 0);
            this.pnlEinmalig.Name = "pnlEinmalig";
            this.pnlEinmalig.Size = new System.Drawing.Size(636, 29);
            this.pnlEinmalig.TabIndex = 0;
            // 
            // pnlRMOptional
            // 
            this.pnlRMOptional.Controls.Add(this.cbRMOptionalJN);
            this.pnlRMOptional.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlRMOptional.Location = new System.Drawing.Point(400, 0);
            this.pnlRMOptional.Name = "pnlRMOptional";
            this.pnlRMOptional.Size = new System.Drawing.Size(166, 29);
            this.pnlRMOptional.TabIndex = 6;
            // 
            // cbRMOptionalJN
            // 
            this.cbRMOptionalJN.Location = new System.Drawing.Point(6, 6);
            this.cbRMOptionalJN.Name = "cbRMOptionalJN";
            this.cbRMOptionalJN.Size = new System.Drawing.Size(144, 20);
            this.cbRMOptionalJN.TabIndex = 1;
            this.cbRMOptionalJN.Text = "Bericht freiwillig";
            // 
            // pnlcbParalell
            // 
            this.pnlcbParalell.Controls.Add(this.cbParalell);
            this.pnlcbParalell.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlcbParalell.Location = new System.Drawing.Point(258, 0);
            this.pnlcbParalell.Name = "pnlcbParalell";
            this.pnlcbParalell.Size = new System.Drawing.Size(142, 29);
            this.pnlcbParalell.TabIndex = 5;
            // 
            // cbParalell
            // 
            this.cbParalell.Location = new System.Drawing.Point(6, 6);
            this.cbParalell.Name = "cbParalell";
            this.cbParalell.Size = new System.Drawing.Size(136, 20);
            this.cbParalell.TabIndex = 2;
            this.cbParalell.Text = "Parallel durchführbar";
            // 
            // pnlcbLokalisierung
            // 
            this.pnlcbLokalisierung.Controls.Add(this.cbLokalisierung);
            this.pnlcbLokalisierung.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlcbLokalisierung.Location = new System.Drawing.Point(142, 0);
            this.pnlcbLokalisierung.Name = "pnlcbLokalisierung";
            this.pnlcbLokalisierung.Size = new System.Drawing.Size(116, 29);
            this.pnlcbLokalisierung.TabIndex = 4;
            // 
            // cbLokalisierung
            // 
            this.cbLokalisierung.Enabled = false;
            this.cbLokalisierung.Location = new System.Drawing.Point(6, 6);
            this.cbLokalisierung.Name = "cbLokalisierung";
            this.cbLokalisierung.Size = new System.Drawing.Size(96, 20);
            this.cbLokalisierung.TabIndex = 1;
            this.cbLokalisierung.Text = "Lokalisierung";
            this.cbLokalisierung.Visible = false;
            this.cbLokalisierung.CheckedChanged += new System.EventHandler(this.cbLokalisierung_CheckedChanged);
            // 
            // pnlcbEinmalig
            // 
            this.pnlcbEinmalig.Controls.Add(this.cbEinmalig);
            this.pnlcbEinmalig.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlcbEinmalig.Location = new System.Drawing.Point(0, 0);
            this.pnlcbEinmalig.Name = "pnlcbEinmalig";
            this.pnlcbEinmalig.Size = new System.Drawing.Size(142, 29);
            this.pnlcbEinmalig.TabIndex = 3;
            // 
            // cbEinmalig
            // 
            this.cbEinmalig.Location = new System.Drawing.Point(12, 6);
            this.cbEinmalig.Name = "cbEinmalig";
            this.cbEinmalig.Size = new System.Drawing.Size(138, 20);
            this.cbEinmalig.TabIndex = 1;
            this.cbEinmalig.Text = "Einmalige Maßnahme";
            this.cbEinmalig.CheckedChanged += new System.EventHandler(this.cbEinmalig_CheckedChanged);
            // 
            // pnlUhrzeit
            // 
            this.pnlUhrzeit.Controls.Add(this.grpUhrzeit);
            this.pnlUhrzeit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUhrzeit.Location = new System.Drawing.Point(0, 0);
            this.pnlUhrzeit.Name = "pnlUhrzeit";
            this.pnlUhrzeit.Size = new System.Drawing.Size(636, 69);
            this.pnlUhrzeit.TabIndex = 6;
            // 
            // grpUhrzeit
            // 
            this.grpUhrzeit.Controls.Add(this.cbZeitbereich);
            this.grpUhrzeit.Controls.Add(this.dtpTime);
            this.grpUhrzeit.Controls.Add(this.lblUhrzeit);
            this.grpUhrzeit.Controls.Add(this.osZeit);
            this.grpUhrzeit.Location = new System.Drawing.Point(8, 4);
            this.grpUhrzeit.Name = "grpUhrzeit";
            this.grpUhrzeit.Size = new System.Drawing.Size(381, 59);
            this.grpUhrzeit.TabIndex = 15;
            this.grpUhrzeit.TabStop = false;
            this.grpUhrzeit.Text = "Uhrzeit";
            this.grpUhrzeit.Enter += new System.EventHandler(this.groupBox6_Enter);
            // 
            // dtpTime
            // 
            this.dtpTime.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.dtpTime.Location = new System.Drawing.Point(184, 16);
            this.dtpTime.MaskInput = "hh:mm";
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ownFormat = "";
            this.dtpTime.ownMaskInput = "";
            this.dtpTime.Size = new System.Drawing.Size(48, 21);
            this.dtpTime.TabIndex = 0;
            this.dtpTime.ValueChanged += new System.EventHandler(this.dtpTime_ValueChanged);
            // 
            // lblUhrzeit
            // 
            this.lblUhrzeit.Location = new System.Drawing.Point(112, 20);
            this.lblUhrzeit.Name = "lblUhrzeit";
            this.lblUhrzeit.Size = new System.Drawing.Size(86, 17);
            this.lblUhrzeit.TabIndex = 13;
            this.lblUhrzeit.Text = "Uhrzeit";
            // 
            // osZeit
            // 
            this.osZeit.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.osZeit.CheckedIndex = 0;
            valueListItem5.DataValue = "ValueListItem1";
            valueListItem5.DisplayText = "Fixe Zeit";
            valueListItem6.DataValue = "ValueListItem2";
            valueListItem6.DisplayText = "Zeitbereich";
            this.osZeit.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem5,
            valueListItem6});
            this.osZeit.ItemSpacingVertical = 2;
            this.osZeit.Location = new System.Drawing.Point(24, 19);
            this.osZeit.Name = "osZeit";
            this.osZeit.Size = new System.Drawing.Size(110, 32);
            this.osZeit.TabIndex = 11;
            this.osZeit.Text = "Fixe Zeit";
            this.osZeit.ValueChanged += new System.EventHandler(this.osZeit_ValueChanged);
            // 
            // cbPflegestufenEinschaetzung
            // 
            this.cbPflegestufenEinschaetzung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPflegestufenEinschaetzung.Location = new System.Drawing.Point(263, 49);
            this.cbPflegestufenEinschaetzung.Name = "cbPflegestufenEinschaetzung";
            this.cbPflegestufenEinschaetzung.PSEKlasse = "";
            this.cbPflegestufenEinschaetzung.Size = new System.Drawing.Size(347, 21);
            this.cbPflegestufenEinschaetzung.strDefault = null;
            this.cbPflegestufenEinschaetzung.TabIndex = 133;
            // 
            // cbBerufsstand
            // 
            this.cbBerufsstand.AddEmptyEntry = false;
            this.cbBerufsstand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBerufsstand.AutoOpenCBO = false;
            this.cbBerufsstand.BerufsstandGruppeJNA = -1;
            this.cbBerufsstand.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbBerufsstand.ExactMatch = false;
            this.cbBerufsstand.Group = "";
            this.cbBerufsstand.ID_PEP = -1;
            this.cbBerufsstand.Location = new System.Drawing.Point(263, 22);
            this.cbBerufsstand.Name = "cbBerufsstand";
            this.cbBerufsstand.PflichtJN = false;
            this.cbBerufsstand.ShowAddButton = true;
            this.cbBerufsstand.Size = new System.Drawing.Size(347, 21);
            this.cbBerufsstand.sys = false;
            this.cbBerufsstand.TabIndex = 1;
            this.cbBerufsstand.ValueChanged += new System.EventHandler(this.cbBerufsstand_ValueChanged);
            // 
            // ucWochenTage1
            // 
            this.ucWochenTage1.Location = new System.Drawing.Point(112, 71);
            this.ucWochenTage1.Name = "ucWochenTage1";
            this.ucWochenTage1.Size = new System.Drawing.Size(280, 18);
            this.ucWochenTage1.TabIndex = 5;
            this.ucWochenTage1.WOCHENTAGE = 2;
            // 
            // cbArea
            // 
            this.cbArea.AddEmptyEntry = false;
            this.cbArea.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cbArea.AutoOpenCBO = false;
            this.cbArea.BerufsstandGruppeJNA = -1;
            this.cbArea.Enabled = false;
            this.cbArea.ExactMatch = false;
            this.cbArea.Group = "";
            this.cbArea.ID_PEP = -1;
            this.cbArea.Location = new System.Drawing.Point(112, 22);
            this.cbArea.MaxLength = 50;
            this.cbArea.Name = "cbArea";
            this.cbArea.PflichtJN = false;
            this.cbArea.ShowAddButton = true;
            this.cbArea.Size = new System.Drawing.Size(144, 21);
            this.cbArea.sys = false;
            this.cbArea.TabIndex = 0;
            // 
            // cbSide
            // 
            this.cbSide.AddEmptyEntry = false;
            this.cbSide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSide.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cbSide.AutoOpenCBO = false;
            this.cbSide.BerufsstandGruppeJNA = -1;
            this.cbSide.Enabled = false;
            this.cbSide.ExactMatch = false;
            this.cbSide.Group = "";
            this.cbSide.ID_PEP = -1;
            this.cbSide.Location = new System.Drawing.Point(319, 21);
            this.cbSide.MaxLength = 50;
            this.cbSide.Name = "cbSide";
            this.cbSide.PflichtJN = false;
            this.cbSide.ShowAddButton = true;
            this.cbSide.Size = new System.Drawing.Size(302, 21);
            this.cbSide.sys = false;
            this.cbSide.TabIndex = 1;
            // 
            // cbLinkDokument
            // 
            this.cbLinkDokument.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLinkDokument.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbLinkDokument.IDLinkDokument = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.cbLinkDokument.Location = new System.Drawing.Point(112, 158);
            this.cbLinkDokument.Name = "cbLinkDokument";
            this.cbLinkDokument.Size = new System.Drawing.Size(408, 21);
            this.cbLinkDokument.TabIndex = 20;
            this.cbLinkDokument.ValueChanged += new System.EventHandler(this.cbLinkDokument_ValueChanged);
            // 
            // cbTermin
            // 
            this.cbTermin.AddEmptyEntry = false;
            this.cbTermin.AutoOpenCBO = false;
            this.cbTermin.BerufsstandGruppeJNA = -1;
            this.cbTermin.ExactMatch = false;
            this.cbTermin.Group = "TRM";
            this.cbTermin.ID_PEP = -1;
            this.cbTermin.Location = new System.Drawing.Point(128, 15);
            this.cbTermin.Name = "cbTermin";
            this.cbTermin.PflichtJN = false;
            this.cbTermin.ShowAddButton = true;
            this.cbTermin.Size = new System.Drawing.Size(408, 21);
            this.cbTermin.sys = false;
            this.cbTermin.TabIndex = 0;
            this.cbTermin.ValueChanged += new System.EventHandler(this.cbTermin_ValueChanged);
            // 
            // cbChanged
            // 
            appearance1.ForeColorDisabled = System.Drawing.Color.Black;
            this.cbChanged.Appearance = appearance1;
            this.cbChanged.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbChanged.Enabled = false;
            this.cbChanged.Location = new System.Drawing.Point(342, 22);
            this.cbChanged.Name = "cbChanged";
            this.cbChanged.Size = new System.Drawing.Size(121, 21);
            this.cbChanged.TabIndex = 1;
            // 
            // cbCreated
            // 
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.cbCreated.Appearance = appearance2;
            this.cbCreated.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbCreated.Enabled = false;
            this.cbCreated.Location = new System.Drawing.Point(112, 22);
            this.cbCreated.Name = "cbCreated";
            this.cbCreated.Size = new System.Drawing.Size(144, 21);
            this.cbCreated.TabIndex = 0;
            // 
            // cbZeitbereich
            // 
            this.cbZeitbereich.Location = new System.Drawing.Point(184, 30);
            this.cbZeitbereich.Name = "cbZeitbereich";
            this.cbZeitbereich.Size = new System.Drawing.Size(184, 21);
            this.cbZeitbereich.TabIndex = 14;
            this.cbZeitbereich.Visible = false;
            // 
            // ucPflegePlanSingleEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.pnlM);
            this.Controls.Add(this.pnlGenerell);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlUhrzeit);
            this.Name = "ucPflegePlanSingleEdit";
            this.Size = new System.Drawing.Size(636, 723);
            this.Load += new System.EventHandler(this.ucPflegePlanSingleEdit_Load);
            this.VisibleChanged += new System.EventHandler(this.ucPflegePlanSingleEdit_VisibleChanged);
            this.pnlInfo.ResumeLayout(false);
            this.grpBenutzer.ResumeLayout(false);
            this.grpBenutzer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrivatJN)).EndInit();
            this.pnlGenerell.ResumeLayout(false);
            this.grpInformation.ResumeLayout(false);
            this.grpInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbWarnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAnmerkung)).EndInit();
            this.pnlM.ResumeLayout(false);
            this.pnlNaechsteEvaluierung.ResumeLayout(false);
            this.grpNächsteEvaluierung.ResumeLayout(false);
            this.grpNächsteEvaluierung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNaechsteEvaluierung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNaechsteEvaluierungBemerkung)).EndInit();
            this.pnlLokalisierung.ResumeLayout(false);
            this.grpLokalisierung.ResumeLayout(false);
            this.grpLokalisierung.PerformLayout();
            this.pnlBerufsstand.ResumeLayout(false);
            this.grpSollwerte.ResumeLayout(false);
            this.grpSollwerte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDauer)).EndInit();
            this.pnlIntervall.ResumeLayout(false);
            this.grpDurchführung.ResumeLayout(false);
            this.grpDurchführung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbIntervall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osIntervall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osEvaluierung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbEvaluierung)).EndInit();
            this.pnlEinmalig.ResumeLayout(false);
            this.pnlRMOptional.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbRMOptionalJN)).EndInit();
            this.pnlcbParalell.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbParalell)).EndInit();
            this.pnlcbLokalisierung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbLokalisierung)).EndInit();
            this.pnlcbEinmalig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbEinmalig)).EndInit();
            this.pnlUhrzeit.ResumeLayout(false);
            this.grpUhrzeit.ResumeLayout(false);
            this.grpUhrzeit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osZeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPflegestufenEinschaetzung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBerufsstand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLinkDokument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTermin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbChanged)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCreated)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbZeitbereich)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void ucPflegePlanSingleEdit_Load(object sender, System.EventArgs e)
		{
			if(DesignMode)
				return;

            this.cbBerufsstand._SupressLevelHierarchie = PMDSBusinessUI.SupressLevelHierarchieActiveInUI;
            cbBerufsstand.Group = "BER";
            this.cbBerufsstand.RefreshList();

            cbArea.Group		= "LOA";
			cbSide.Group		= "LOS";
			

			// Combo Termin genau über das Textfeld schieben
			cbTermin.Left	= tbText.Left;
			cbTermin.Top	= tbText.Top;

            cbLinkDokument.RefreshList();
            if (ENV.lic_PflegestufenEinschätzung)
            {
                cbPflegestufenEinschaetzung.RefreshList();
            }
            else
            {
                cbPflegestufenEinschaetzung.Visible = false;
                lblPflegestufeneinschaetzung.Visible = false;
            }
        }

		private void cbEinmalig_CheckedChanged(object sender, System.EventArgs e)
		{
            extEinmaligJN = cbEinmalig.Checked;

            if (!cbEinmalig.Checked) 
			{
				pnlIntervall.Visible = true;
			}
			else 
			{
				pnlIntervall.Visible = false;
				tbEvaluierung.Value = 0;
			}
		}

		private void tbEvaluierung_ValueChanged(object sender, System.EventArgs e)
		{
		
		}

		private void cbLokalisierung_CheckedChanged(object sender, System.EventArgs e)
		{
			if(cbLokalisierung.Checked) 
			{
				pnlLokalisierung.Visible = true;
			}
			else
			{
				pnlLokalisierung.Visible = false;
				cbArea.Clear();
				cbSide.Clear();
			}
		}

		private void groupBox6_Enter(object sender, System.EventArgs e)
		{
		
		}

		#region IReadOnly Members

		public bool ReadOnly
		{
			get
			{
				return cbCreated.ReadOnly;
			}
			set
			{
                //cbLokalisierung.Enabled = !value;		raus weil enz wünscht dass lokalisierung nicht mehr veränderbar ist
				cbCreated.ReadOnly		                = value;
				cbChanged.ReadOnly		                = value;
				tbText.ReadOnly			                = value;
				tbWarnung.ReadOnly		                = value;
				tbAnmerkung.ReadOnly	                = value;
				cbEinmalig.Enabled		                = !value;
				cbParalell.Enabled		                = !value;
				tbIntervall.ReadOnly	                = value;
				osIntervall.Enabled		                = !value;
				tbEvaluierung.ReadOnly	                = value;
				osEvaluierung.Enabled	                = !value;
				ucWochenTage1.Enabled	                = !value;
				tbDauer.ReadOnly		                = value;
				cbBerufsstand.ReadOnly	                = value;
                cbPflegestufenEinschaetzung.ReadOnly    = value;
				cbArea.ReadOnly			                = value;
				cbSide.ReadOnly			                = value;
				cbRMOptionalJN.Enabled	                = !value;
                cbLinkDokument.ReadOnly                 = value;
                dtpNaechsteEvaluierung.ReadOnly         = value;
                tbNaechsteEvaluierungBemerkung.ReadOnly = value;
			}
		}

		#endregion

        private void cbLinkDokument_ValueChanged(object sender, EventArgs e)
        {
            SetShowbuttonEnabled();
        }

        private void SetShowbuttonEnabled()
        {
            btnShow.Enabled = cbLinkDokument.IDLinkDokument != Guid.Empty;
        }


        private void RecalcHeight()
        {
            // pnlMain berechnen die Höhe ergibt sich aus der Summe der enthaltenen einzelpanels
            int y = 0;
            foreach (Control c in pnlM.Controls)
                if (c is Panel && c.Visible)
                    y += c.Height;
            pnlM.Height = y;
            

            // Control Höhe berechnen
            int y1 = 0;
            foreach (Control c in this.Controls)
            {
                if (c.Equals(pnlM))                 // m wurde bereits berücksichtigt in der höhenberechnung
                    continue;
                if (c is Panel && c.Visible)
                    y1 += c.Height;
            }
            this.Height = y1 + y;
        }

        private void osZeit_ValueChanged(object sender, EventArgs e)
        {
            lblUhrzeit.Text         = IS_FIXEZEIT ? "Uhrzeit" : "Zeitbereich";
            cbZeitbereich.Visible   = !IS_FIXEZEIT;
            dtpTime.Visible         = IS_FIXEZEIT;
        }

        private bool IS_FIXEZEIT  {  get { return osZeit.CheckedIndex == 0; } }

        private void btnShow_Click(object sender, EventArgs e)
        {
            GuiUtil.ShowLinkDokument(cbLinkDokument.IDLinkDokument);
        } // Liefert true wenn "Fixe Zwit gewählt ist

        private void cbTermin_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbTermin.SelectedItem != null)
                    extTermin = cbTermin.SelectedItem.ToString();

            }
            catch (Exception ex)
            {

                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void tbWarnung_ValueChanged(object sender, EventArgs e)
        {
            extWarnung = tbWarnung.Text.ToString();
        }

        private void tbAnmerkung_ValueChanged(object sender, EventArgs e)
        {
            extAnmerkung = tbAnmerkung.Text.ToString();
        }

        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            extDatum = dtpTime.DateTime.ToString();
        }

        private void ucPflegePlanSingleEdit_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible && !this.VisibleIsInitialized)
                {
                    this.cbTermin.DropDownStyle = DropDownStyle.DropDown;
                    this.cbTermin.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
                    this.cbTermin.AutoSuggestFilterMode = AutoSuggestFilterMode.Contains;

                    this.VisibleIsInitialized = true;
                }

            }
            catch (Exception ex)
            {

                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void cbBerufsstand_ValueChanged(object sender, EventArgs e)
        {
            //string x = "";
        }
    }
}
