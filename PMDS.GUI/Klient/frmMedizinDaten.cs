using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.GUI.Klient;
using PMDS.Klient;
using PMDS.DB;
using System.Linq;
using PMDS.Global.db.ERSystem;

namespace PMDS.GUI
{

    public partial class frmMedizinDaten : QS2.Desktop.ControlManagment.baseForm 
    {
        protected bool _canClose = false;
        private MedizinischerTyp _medTyp;
        private string _sBezeichnung;
        private State _state;
        private dsMedizinischeDaten.MedizinischeDatenRow _row;
        private PMDS.Global.db.Global.dsMedizinischeDatenLayout.MedizinischeDatenLayoutRow _MedizinischertypVerwaltungRow;

        public Guid IDMedDaten;
        public System.Collections.Generic.List<PMDS.DB.PMDSBusiness.cMedTypDatenCopy> lstPatienteSelected = new List<PMDS.DB.PMDSBusiness.cMedTypDatenCopy>();
        public System.Collections.Generic.List<PMDS.Global.UIGlobal.eSelectedNodes> lstPatienteSelected2 = new List<PMDS.Global.UIGlobal.eSelectedNodes>();

        public PMDSBusinessUI b2 = new PMDSBusinessUI();
        public enum eDekursType
        {
            Dekurs = 0,
            DekursEntwurf = 1,
            DekursEntwurfAlias = 2
        }

        public bool IsELGADocu = false;
        public bool Storniert2 = false;
        public bool Gesendet = false;








        public frmMedizinDaten(State state, MedizinischerTyp medTyp, string sBezeichnung, PMDS.Global.db.Global.dsMedizinischeDatenLayout.MedizinischeDatenLayoutRow row)
        {
            InitializeComponent();
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            Closing += new CancelEventHandler(frm_Closing);
            _medTyp = medTyp;
            _sBezeichnung = sBezeichnung;
            _state = state;
            _MedizinischertypVerwaltungRow = row;
            SetAuswahllistegruppe();
            Init();
            RequiredFields();

            this.btnOpenBefund.Visible = false;
        }

        //Neu nach 05.06.2007 MDA
        private void SetAuswahllistegruppe()
        {
            switch (_medTyp)
            {
                case MedizinischerTyp.AktuelleDiagnosen:
                    cmbTyp.Group = "DGN";
                    break;
                case MedizinischerTyp.DauerDiagnosen:
                    cmbTyp.Group = "DGN";
                    break;
                case MedizinischerTyp.Allergien:
                    cmbTyp.Group = "ALG";
                    break;
                case MedizinischerTyp.Antikoagulation:
                    cmbTyp.Group = "ANK";
                    break;
                case MedizinischerTyp.Unvertraeglichkeiten:
                    cmbTyp.Group = "CAV";
                    break;
                case MedizinischerTyp.Diabetes:
                    cmbTyp.Group = "DTH";
                    break;
                case MedizinischerTyp.Impfungen:
                    cmbTyp.Group = "IMF";
                    break;
                case MedizinischerTyp.ImplentateProthesen:
                    cmbTyp.Group = "IPR";
                    break;
                case MedizinischerTyp.Infektionen:
                    cmbTyp.Group = "INF";
                    break;
                case MedizinischerTyp.KathederSondenStomata:
                    cmbTyp.Group = "KSS";
                    break;
                case MedizinischerTyp.Kostform:
                    cmbTyp.Group = "KOF";
                    break;
                case MedizinischerTyp.Nuechtern:
                    cmbTyp.Group = "NTR";
                    break;
                case MedizinischerTyp.Sonstige:
                    cmbTyp.Group = "STG";
                    break;
                case MedizinischerTyp.Suchtmittel:
                    cmbTyp.Group = "STM";
                    break;
                case MedizinischerTyp.Befunde:
                    cmbTyp.Group = "BEF";
                    break;
            }
        }

        private void Init()
        {
            switch (_state)
            {
                case State.On:
                    Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Beginn ") + _sBezeichnung;
                    
                    break;
                case State.Off:
                    Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Ende ") + _sBezeichnung;
                    
                    //
                    //dtpBeginn
                    dtpBeginn.Enabled = false;
                    break;
                case State.Update:
                    Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bearbeiten ") + _sBezeichnung;
                    break;
            }
            
            lblHeader.Text = Text;

            int h = 0;

            if (_medTyp == MedizinischerTyp.Impfungen)
            {
                lblBeginn.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Am");
                lblEnde.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Folgeimpfung am");
            }

            //
            //tbICDCode
            if (_state == State.Off || (_medTyp != MedizinischerTyp.AktuelleDiagnosen && _medTyp != MedizinischerTyp.DauerDiagnosen))
            {
                lblIcdCode.Visible = false;
                tbICDCode.Visible = false;
            }

            //
            //dtpLetztVers - dtpNaechVers
            if (_state == State.Off || (_medTyp != MedizinischerTyp.ImplentateProthesen && _medTyp != MedizinischerTyp.KathederSondenStomata))
            {
                pnlVersorgung.Visible = false;
                //dtpEnde.Location = new Point(lblEnde.Location.X + lblEnde.Width + 2, dtpEnde.Location.Y);
                h += pnlVersorgung.Height;
            }

            //
            //cbAufnDiagn
            if (_state == State.Off || (_medTyp != MedizinischerTyp.AktuelleDiagnosen && _medTyp != MedizinischerTyp.DauerDiagnosen))
            {
                pnlDiagAntik.Visible = false;
                h += pnlDiagAntik.Height;
            }

            //Nüchtern
            pnlNuechtern.Visible = false;
            h += pnlNuechtern.Height;
            NUECHTERN = _medTyp == MedizinischerTyp.Nuechtern ? true : false;


            //
            //tbAnzahl
            if (_state == State.Off || _medTyp != MedizinischerTyp.Suchtmittel)
            {
                pnlAnzahl.Visible = false;
                h += pnlAnzahl.Height;
            }

            if (_MedizinischertypVerwaltungRow == null)
                return;
            
            int pnlAnzahlIdx = this.Controls.Count - 1 - this.Controls.IndexOf(pnlAnzahl);
            
            //Beschreibung
            if (_state == State.Off || _MedizinischertypVerwaltungRow.IsBeschreibungNull())
            {
                pnlBeschreibung.Visible = false;
                h += pnlBeschreibung.Height;
            }
            else
            {
                int tmpIndex = _MedizinischertypVerwaltungRow.Beschreibung;
                if (_MedizinischertypVerwaltungRow.Beschreibung >= 1000)
                    tmpIndex = _MedizinischertypVerwaltungRow.Beschreibung - 1000;
                this.Controls.SetChildIndex(pnlBeschreibung, pnlAnzahlIdx - tmpIndex);
                pnlBeschreibung.TabIndex = this.Controls.Count - 3 - pnlAnzahlIdx + tmpIndex;
            }

            //Bemerkung
            if (_state == State.Off || _MedizinischertypVerwaltungRow.IsBemerkungNull())
            {
                pnlBemerkung.Visible = false;
                h += pnlBemerkung.Height;
            }
            else
            {
                int tmpIndex = _MedizinischertypVerwaltungRow.Bemerkung;
                if (_MedizinischertypVerwaltungRow.Bemerkung >= 1000)
                    tmpIndex = _MedizinischertypVerwaltungRow.Bemerkung - 1000;
                this.Controls.SetChildIndex(pnlBemerkung, pnlAnzahlIdx - tmpIndex);
                pnlBemerkung.TabIndex = this.Controls.Count - 3 - pnlAnzahlIdx + tmpIndex;
            }

            //Bendigungsgrund
            if (_state == State.Off || _MedizinischertypVerwaltungRow.IsBeendigungsgrundNull())
            {
                pnlBeendGrung.Visible = false;
                h += pnlBeendGrung.Height;
            }
            else
            {
                int tmpIndex = _MedizinischertypVerwaltungRow.Beendigungsgrund;
                if (_MedizinischertypVerwaltungRow.Beendigungsgrund >= 1000)
                    tmpIndex = _MedizinischertypVerwaltungRow.Beendigungsgrund - 1000;
                this.Controls.SetChildIndex(pnlBeendGrung, pnlAnzahlIdx - tmpIndex);
                pnlBeendGrung.TabIndex = this.Controls.Count - 3 - pnlAnzahlIdx + tmpIndex;
            }

            //Therapie
            if (_state == State.Off || _MedizinischertypVerwaltungRow.IsTherapieNull())
            {
                pnlTherapie.Visible = false;
                h += pnlTherapie.Height;
            }
            else
            {
                int tmpIndex = _MedizinischertypVerwaltungRow.Therapie;
                if (_MedizinischertypVerwaltungRow.Therapie >= 1000)
                    tmpIndex = _MedizinischertypVerwaltungRow.Therapie - 1000;
                this.Controls.SetChildIndex(pnlTherapie, pnlAnzahlIdx - tmpIndex);
                pnlTherapie.TabIndex = this.Controls.Count - 3 - pnlAnzahlIdx + tmpIndex;
            }

            //Typ
            if (_state == State.Off || _MedizinischertypVerwaltungRow.IsTypNull())
            {
                this.Controls.Remove(pnlTyp);
                pnlTyp.Visible = false;
                h += pnlTyp.Height;
            }
            else
            {
                int tmpIndex = _MedizinischertypVerwaltungRow.Typ;
                if (_MedizinischertypVerwaltungRow.Typ >= 1000)
                    tmpIndex = _MedizinischertypVerwaltungRow.Typ - 1000;
                this.Controls.SetChildIndex(pnlTyp, pnlAnzahlIdx - tmpIndex);
                pnlTyp.TabIndex = this.Controls.Count - 3 - pnlAnzahlIdx + tmpIndex;
            }

            //
            //tbHandling
            if (_state == State.Off ||  _medTyp == MedizinischerTyp.KathederSondenStomata || _medTyp == MedizinischerTyp.Befunde)
            {
                pnlHandling.Visible = true;
                h += pnlHandling.Height;
            }
            else
            {
                pnlHandling.Visible = false;
                h -= pnlHandling.Height;
            }

            //
            //tbModell
            if (_state == State.Off || (_medTyp != MedizinischerTyp.ImplentateProthesen &&
                _medTyp != MedizinischerTyp.KathederSondenStomata))
            {
                pnlModell.Visible = false;
                h += pnlModell.Height;

                pnlGroesse.Visible = false;
                h += pnlGroesse.Height;
            }

            if (h > 0)
                Height -= h;
        }

        private void InitGUI()
        {
            if (!_row.IsVonNull())
                BEGINN = _row.Von;

            if (!_row.IsBisNull())
                ENDE = _row.Bis;

            if (!_row.IsICDCodeNull())
                ICDCode = _row.ICDCode.Trim();

            if (!_row.IsLetzteVersorgungNull())
                LETZTE_VERSORGUNG = _row.LetzteVersorgung;

            if (!_row.IsNaechsteVersorgungNull())
                NAECHSTE_VERSORGUNG = _row.NaechsteVersorgung;

            if (!_row.IsAnzahlNull())
                ANZAHL = _row.Anzahl;

            if (!_row.IsAufnahmediagnoseJNNull())
                AUFNAHMEDIAGNOSE = _row.AufnahmediagnoseJN;

            if (!_row.IsAntikoaguliertJNNull())
                ANTIKOAGULIERT = _row.AntikoaguliertJN;

            if (!_row.IsBeschreibungNull())
                BESCHREIBUNG = _row.Beschreibung.Trim();

            if (!_row.IsBemerkungNull())
                BEMERKUNG = _row.Bemerkung.Trim();

            if (!_row.IsBeendigungsgrundNull())
                BEENDIGUNGSGRUND = _row.Beendigungsgrund.Trim();

            if (!_row.IsTherapieNull())
                THERAPIE = _row.Therapie.Trim();

            if (!_row.IsTypNull())
                TYP = _row.Typ.Trim();

            if (!_row.IsHandlingNull())
                HANDLING = _row.Handling.Trim();

            if (!_row.IsModellNull())
                MODELL = _row.Modell.Trim();

            if (!_row.IsNuechternJNNull())
                NUECHTERN = _row.NuechternJN;

            if (!_row.IsGroesseNull())
                GROESSE = _row.Groesse.Trim();

            if (!_row.IsIDBefundNull())
            {
                this.btnOpenBefund.Visible = true;
            }
            else
            {
                this.btnOpenBefund.Visible = false; 
            }
            this.btnBefundStorno.Visible = false;
            this.btnBefundSend.Visible = false;

            using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
            {
                var rMedDaten = (from p in db.MedizinischeDaten
                                where p.ID == _row.ID
                                select new
                                {
                                    p.ID,
                                    p.IDDocu
                                }).FirstOrDefault();

                if (rMedDaten != null && rMedDaten.IDDocu != null)
                {
                    var rDocuEintrag = (from de in db.tblDokumenteintrag
                                     where de.ID ==  rMedDaten.IDDocu
                                     select new
                                     {
                                         de.ID,
                                         de.ELGAStorniert,
                                         de.ELGAStorniertDatum,
                                         de.ELGAStorniertUser,
                                         de.ELGAÜbertragen,
                                         de.IsELGADocu,
                                         de.ELGADocuType,
                                         de.ELGACreatedInPMDS
                                     }).FirstOrDefault();

                    var rAufenthalt = (from a in db.Aufenthalt
                                        where a.ID == ENV.IDAUFENTHALT
                                       select new
                                        {
                                            a.ID,
                                            a.ELGASOOJN,
                                            a.ELGAKontaktbestätigungStornoJN,
                                            a.ELGALocalID
                                        }).FirstOrDefault();

                    this.IsELGADocu = true;
                    this.btnOpenBefund.Visible = true;
                    this.btnBefundStorno.Visible = !rDocuEintrag.ELGAStorniert && rDocuEintrag.ELGACreatedInPMDS;

                    if (!rAufenthalt.ELGASOOJN && rDocuEintrag.ELGAÜbertragen == 0 &&
                        (rDocuEintrag.ELGADocuType.Trim().ToLower().Equals(WCFServicePMDS.CDABAL.CDA.eTypeCDA.Pflegesituationbericht.ToString().Trim().ToLower()) || 
                        rDocuEintrag.ELGADocuType.Trim().ToLower().Equals(WCFServicePMDS.CDABAL.CDA.eTypeCDA.Entlassungsbrief.ToString().Trim().ToLower())))
                    {
                        this.btnBefundSend.Visible = true;
                    }
                }
            }
        }

        public bool ValidateFields()
        {
            try
            {
                bool bError = false;
                bool bInfo = true;
                //Änderung nach 05.06.2007 MDA: Beginndatum kein Pflichtfeld nur bei Impfungen
                if (_state == State.Off)
                {
                    GuiUtil.ValidateField(dtpEnde, (dtpEnde.Text.Length > 0),
                                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
                }

                GuiUtil.ValidateField(dtpEnde, (dtpEnde.Text.Length == 0 || ENDE.Date >= BEGINN.Date),
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Ende darf nicht kleiner sein als der Beginn."), ref bError, bInfo, errorProvider1);
 
                if ((_state == State.On || _state == State.Update) && (_medTyp == MedizinischerTyp.ImplentateProthesen || _medTyp == MedizinischerTyp.KathederSondenStomata))
                {
                    GuiUtil.ValidateField(dtpNaechVers, (dtpNaechVers.Text.Length == 0 || NAECHSTE_VERSORGUNG.Date >= LETZTE_VERSORGUNG.Date),
                    QS2.Desktop.ControlManagment.ControlManagment.getRes("Nächste Versorgung darf nicht kleiner sein als die letzte Versorgung."), ref bError, bInfo, errorProvider1);
                }


                string sTxtFieldsMessage = "";
                if (_MedizinischertypVerwaltungRow != null)
                {
                    if (this.tbBeschreibung.Visible)
                    {
                        if (!_MedizinischertypVerwaltungRow.IsBeschreibungNull() && _MedizinischertypVerwaltungRow.Beschreibung >= 1000 && this.tbBeschreibung.Text.Trim() == "")
                        {
                            sTxtFieldsMessage += QS2.Desktop.ControlManagment.ControlManagment.getRes("Beschreibung: Eingabe erforderlich!") + "\r\n";
                            bError = true;
                        }
                    }
                    if (this.tbBemerkung.Visible)
                    {
                        if (!_MedizinischertypVerwaltungRow.IsBemerkungNull() && _MedizinischertypVerwaltungRow.Bemerkung >= 1000 && this.tbBemerkung.Text.Trim() == "")
                        {
                            sTxtFieldsMessage += QS2.Desktop.ControlManagment.ControlManagment.getRes("Bemerkung: Eingabe erforderlich!") + "\r\n";
                            bError = true;
                        }
                    }
                    if (this.tbBeendGrund.Visible)
                    {
                        if (!_MedizinischertypVerwaltungRow.IsBeendigungsgrundNull() && _MedizinischertypVerwaltungRow.Beendigungsgrund >= 1000 && this.tbBeendGrund.Text.Trim() == "")
                        {
                            sTxtFieldsMessage += QS2.Desktop.ControlManagment.ControlManagment.getRes("Beendigungsgrund: Eingabe erforderlich!") + "\r\n";
                            bError = true;
                        }
                    }
                    if (this.tbTherapie.Visible)
                    {
                        if (!_MedizinischertypVerwaltungRow.IsTherapieNull() && _MedizinischertypVerwaltungRow.Therapie >= 1000 && this.tbTherapie.Text.Trim() == "")
                        {
                            sTxtFieldsMessage += QS2.Desktop.ControlManagment.ControlManagment.getRes("Therapie: Eingabe erforderlich!") + "\r\n";
                            bError = true;
                        }
                    }
                    if (this.cmbTyp.Visible)
                    {
                        if (!_MedizinischertypVerwaltungRow.IsTypNull() && _MedizinischertypVerwaltungRow.Typ >= 1000 && this.cmbTyp.Text.Trim() == "")
                        {
                            sTxtFieldsMessage += QS2.Desktop.ControlManagment.ControlManagment.getRes("Typ: Eingabe erforderlich!") + "\r\n";
                            bError = true;
                        }
                    }
                }

                if (sTxtFieldsMessage.Trim() != "")
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sTxtFieldsMessage, "PMDS", MessageBoxButtons.OK);
                }

                return !bError;

            }
            catch (Exception ex)
            {
                throw new Exception("frmMedizinDaten.ValidateFields: " + ex.ToString());
            }
        }

        public void openMehrfachselektionPatients()
        {
            try
            {
                PMDS.GUI.GUI.Main.frmPatientenmehrfachauswahl frmPatientenmehrfachauswahl1 = new GUI.Main.frmPatientenmehrfachauswahl();
                frmPatientenmehrfachauswahl1.lstPatienteSelected = this.lstPatienteSelected2;
                frmPatientenmehrfachauswahl1.initControl();
                frmPatientenmehrfachauswahl1.ShowDialog(this);
                if (!frmPatientenmehrfachauswahl1.abort)
                {
                    this.lstPatienteSelected2 = frmPatientenmehrfachauswahl1.lstPatienteSelected;
                    this.lstPatienteSelected.Clear();
                    foreach (PMDS.Global.UIGlobal.eSelectedNodes SelectedNodes in frmPatientenmehrfachauswahl1.lstPatienteSelected)
                    {
                        PMDS.DB.PMDSBusiness.cMedTypDatenCopy newcMedTypDatenCopy = new DB.PMDSBusiness.cMedTypDatenCopy();
                        newcMedTypDatenCopy.SelectedNodes = SelectedNodes;
                        this.lstPatienteSelected.Add(newcMedTypDatenCopy);
                        this.btnKlientenMehrfachauswahl.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Klienten Mehrfachauswahl") + " (" + this.lstPatienteSelected.Count.ToString() + ")";
                    }

                    if (this.lstPatienteSelected.Count > 0)
                    {
                        this.btnKlientenMehrfachauswahl.Appearance.ForeColor = Color.Red;
                    }
                    else
                    {
                        this.btnKlientenMehrfachauswahl.Appearance.ForeColor = Color.Black;
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("openMehrfachselektionPatients: " + ex.ToString());
            }
        }

        public void AllowEdit(bool bSwitch)
        {
            this.btnOK.Enabled = bSwitch;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Benötigte Felder setzen
        /// </summary>
        //----------------------------------------------------------------------------
        protected void RequiredFields()
        {
            //Änderung nach 05.06.2007 MDA: Beginndatum kein Pflichtfeld nur bei Impfungen

            if (_state == State.Off)
            {
                GuiUtil.ValidateRequired(dtpEnde);
            }
        }

        #region Properties
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsMedizinischeDaten.MedizinischeDatenRow MED_DATEN_ROW
        {
            get
            {
                return _row;
            }

            set
            {
                _row = value;
                InitGUI();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime BEGINN
        {
            get
            {
                if (dtpBeginn.Value == null)
                    return DateTime.MinValue;
                else
                    return dtpBeginn.DateTime;
            }

            set
            {
                dtpBeginn.Value = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime ENDE
        {
            get
            {
                if (dtpEnde.Value == null)
                    return DateTime.MinValue;
                else
                    return dtpEnde.DateTime;
            }

            set
            {
                dtpEnde.Value = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime LETZTE_VERSORGUNG
        {
            get
            {
                if (dtpLetztVers.Value == null)
                    return DateTime.MinValue;
                else
                    return dtpLetztVers.DateTime;
            }

            set
            {
                dtpLetztVers.Value = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime NAECHSTE_VERSORGUNG
        {
            get
            {
                if (dtpNaechVers.Value == null)
                    return DateTime.MinValue;
                else
                    return dtpNaechVers.DateTime;
            }

            set
            {
                dtpNaechVers.Value = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AUFNAHMEDIAGNOSE
        {
            get
            {
                return cbAufnDiagn.Checked;
            }

            set
            {
                cbAufnDiagn.Checked = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ANTIKOAGULIERT
        {
            get
            {
                return cbAntikoaguliert.Checked;
            }

            set
            {
                cbAntikoaguliert.Checked = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ICDCode
        {
            get
            {
                return tbICDCode.Text.Trim();
            }

            set
            {
                tbICDCode.Text = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string BESCHREIBUNG
        {
            get
            {
                return tbBeschreibung.Text.Trim();
            }

            set
            {
                tbBeschreibung.Text = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string BEMERKUNG
        {
            get
            {
                return tbBemerkung.Text.Trim();
            }

            set
            {
                tbBemerkung.Text = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string BEENDIGUNGSGRUND
        {
            get
            {
                return tbBeendGrund.Text.Trim();
            }

            set
            {
                tbBeendGrund.Text = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string THERAPIE
        {
            get
            {
                return tbTherapie.Text.Trim();
            }

            set
            {
                tbTherapie.Text = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string HANDLING
        {
            get
            {
                return tbHandling.Text.Trim();
            }

            set
            {
                tbHandling.Text = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MODELL
        {
            get
            {
                return tbModell.Text.Trim();
            }

            set
            {
                tbModell.Text = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string GROESSE
        {
            get
            {
                return tbGroesse.Text.Trim();
            }

            set
            {
                tbGroesse.Text = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double ANZAHL
        {
            get
            {
                return tbAnzahl.Text.Trim() != "" ? (double)tbAnzahl.Value : -1.0;
            }

            set
            {
                tbAnzahl.Value = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NUECHTERN
        {
            get
            {
                return cbNuechtern.Checked;
            }

            set
            {
                cbNuechtern.Checked = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TYP
        {
            get
            {
                return cmbTyp.Text.Trim();
            }

            set
            {
                cmbTyp.Text = value;
            }
        }
        #endregion

        //----------------------------------------------------------------------------
        /// <summary>
        /// Dialog schließen überwachen
        /// </summary>
        //----------------------------------------------------------------------------
        private void frm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !_canClose;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateFields())
                    return;
                _canClose = true;
            }
            finally
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _canClose = true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _canClose = true;
                this.Close();
                return;
            }
            base.OnKeyDown(e);
        }

        private void btnDekursErstellen_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.DekursErstellen(eDekursType.Dekurs);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void btnTerminErstellen_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.TerminErstellen();

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


        public void TerminErstellen()
        {
            try
            {
                ucSiteMapTermine ucSiteMap = null;
                GuiAction.InsertTermin(ENV.IDAUFENTHALT, false, (Form)GuiWorkflow.mainWindow, ucSiteMap, null, this.IDMedDaten);

            }
            catch (Exception ex)
            {
                throw new Exception("SonderterminErstellen: " + ex.ToString());
            }
        }
        public void DekursErstellen(eDekursType DekursType)
        {
            try
            {
                if (DekursType == eDekursType.Dekurs)
                {
                    GuiAction.PatientVermerk(ENV.CurrentIDPatient, this.IDMedDaten, eDekursherkunft.DekursAusMedDiagnosenPatient, "", false, false, null, true, "Fct. frmMedizinDaten.DekursErstellen()", false, "");
                }
                else if (DekursType == eDekursType.DekursEntwurf)
                {
                    GuiAction.PatientVermerk(ENV.CurrentIDPatient, this.IDMedDaten, eDekursherkunft.DekursAusMedDiagnosenPatient, "", false, true, null, true, "Fct. frmMedizinDaten.DekursErstellen()", false, "");
                }
                else if (DekursType == eDekursType.DekursEntwurfAlias)
                {
                    GuiAction.PatientVermerk(ENV.CurrentIDPatient, this.IDMedDaten, eDekursherkunft.DekursAusMedDiagnosenPatient, "", false, true, null, true, "Fct. frmMedizinDaten.DekursErstellen()", true, "");
                }
                else
                {
                    throw new Exception("frmMedizinDaten.DekursErstellen: DekursType '" + DekursType.ToString() + "' not allowed!");
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("frmMedizinDaten.DekursErstellen: " + ex.ToString());
            }
        }



        private void btnDekursEntwurfErstellen_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.DekursErstellen(eDekursType.DekursEntwurf);
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void btnDekursEntwurfErstellenAs_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.DekursErstellen(eDekursType.DekursEntwurfAlias);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnKlientenMehrfachauswahl_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.openMehrfachselektionPatients();

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void frmMedizinDaten_Load(object sender, EventArgs e)
        {
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
        }


        private void btnOpenBefund_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this.IsELGADocu)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                    {
                        var rMedDaten = (from p in db.MedizinischeDaten
                                         where p.ID == _row.ID
                                         select new
                                         {
                                             p.ID,
                                             p.IDDocu
                                         }).FirstOrDefault();

                        if (rMedDaten != null && rMedDaten.IDDocu != null)
                        {
                            ELGAPMDSBusinessUI bUi = new ELGAPMDSBusinessUI();
                            bUi.openELGADocuFromArchive(rMedDaten.IDDocu.Value);
                        }
                    }
                }
                else
                {
                    EDIFact.EDIFact EDIFact1 = new EDIFact.EDIFact();
                    EDIFact1.openBefund(_row.IDBefund);
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnBefundStorno_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this.IsELGADocu)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                    {
                        var rMedDaten = (from p in db.MedizinischeDaten
                                         where p.ID == _row.ID
                                         select new
                                         {
                                             p.ID,
                                             p.IDDocu
                                         }).FirstOrDefault();

                        if (rMedDaten != null && rMedDaten.IDDocu != null)
                        {
                            ELGABusiness bElga = new ELGABusiness();
                            bElga.StornoELGADocu(rMedDaten.IDDocu.Value, rMedDaten.ID);
                            this.btnBefundStorno.Visible = false;
                            this.Storniert2 = true;
                            this._canClose = true;
                            this.Close();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void btnBefundSend_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this.IsELGADocu)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                    {
                        var rMedDaten = (from p in db.MedizinischeDaten
                                         where p.ID == _row.ID
                                         select new
                                         {
                                             p.ID,
                                             p.IDDocu
                                         }).FirstOrDefault();

                        if (rMedDaten != null && rMedDaten.IDDocu != null)
                        {
                            ELGABusiness bElga = new ELGABusiness();
                            bElga.SendELGADocu(rMedDaten.IDDocu.Value, rMedDaten.ID);
                            this.btnBefundSend.Visible = false;
                            this.Gesendet = true;
                            this._canClose = true;
                            this.Close();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

    }
}