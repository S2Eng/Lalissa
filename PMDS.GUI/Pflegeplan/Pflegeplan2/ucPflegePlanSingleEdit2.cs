using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using PMDS.Data.PflegePlan;
using PMDS.Global;
using PMDS.BusinessLogic;
using System.Linq;
using S2Extensions;

namespace PMDS.GUI
{
    public class ucPflegePlanSingleEdit2 : QS2.Desktop.ControlManagment.BaseControl, IReadOnly
    {
        private dsPflegePlan.PflegePlanRow _row;
        private EintragGruppe _EintragGruppe = EintragGruppe.A;

        private bool _TransferMode = false;
        public event EventHandler ASZMValueChanged;
        private bool _valueChangeEnabled = true;
        private bool _isTextChanged = false;
        private bool _MassnahmeOhneZeitbezug = false;
        private PflegePlanModi _PflegePlanMode = PflegePlanModi.PflegePlan;

        public int _IDEintrag = 3;
        public bool userHasEintragFlagChanged = false;

        public Nullable<Guid> IDPflegeplan = null;
        public ucASZMTransfer2 mainWindow = null;









        private QS2.Desktop.ControlManagment.BaseLabel lblInfoCreated;
        private QS2.Desktop.ControlManagment.BasePanel pnlInfo;
        private QS2.Desktop.ControlManagment.BasePanel pnlGenerell;
        private QS2.Desktop.ControlManagment.BasePanel pnlM;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbText;
        public QS2.Desktop.ControlManagment.BaseLabel lblBezeichnung;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel2;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel3;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbAnmerkung;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel4;
        private QS2.Desktop.ControlManagment.BaseOptionSet osIntervall;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbEinmalig;
        private QS2.Desktop.ControlManagment.BasePanel pnlIntervall;
        private QS2.Desktop.ControlManagment.BasePanel pnlEinmalig;
        private QS2.Desktop.ControlManagment.BasePanel pnlLokalisierung;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbLokalisierung;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbParalell;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cbSide;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cbArea;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel6;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel7;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel8;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel9;
        private PMDS.GUI.ucWochenTage1 ucWochenTage11;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel10;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbWarnung;
        private QS2.Desktop.ControlManagment.BaseNumericEditor tbIntervall;
        private QS2.Desktop.ControlManagment.BaseNumericEditor tbDauer;
        private QS2.Desktop.ControlManagment.BasePanel pnlBerufsstand;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cbBerufsstand;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cbTermin;
        private QS2.Desktop.ControlManagment.BasePanel pnlUhrzeit;
        private QS2.Desktop.ControlManagment.BaseLabel lblUhrzeit;
        private QS2.Desktop.ControlManagment.BaseLabel lblDokument;
        private PMDS.GUI.BaseControls.LinkDokumenteCombo cbLinkDokument;
        private QS2.Desktop.ControlManagment.BasePanel pnlcbParalell;
        private QS2.Desktop.ControlManagment.BasePanel pnlcbLokalisierung;
        private QS2.Desktop.ControlManagment.BasePanel pnlcbEinmalig;
        private QS2.Desktop.ControlManagment.BasePanel pnlBez;
        private QS2.Desktop.ControlManagment.BasePanel pnlW;
        private QS2.Desktop.ControlManagment.BasePanel pnlDokument;
        private QS2.Desktop.ControlManagment.BasePanel pnlAnm;
        private QS2.Desktop.ControlManagment.BaseButton btnShow;
        private QS2.Desktop.ControlManagment.BaseOptionSet osZeit;
        private QS2.Desktop.ControlManagment.BasePanel pnlNaechsteEvaluierung;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpNaechsteEvaluierung;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbNaechsteEvaluierungBemerkung;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel11;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel14;
        private QS2.Desktop.ControlManagment.BaseTabControl tabMain;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;

        private List<Control> _aVisibleControls = new List<Control>();
        private PMDS.GUI.PflegePlan2.ucZusatzeintrag ucZusatzeintrag1;
        private QS2.Desktop.ControlManagment.BasePanel pnlRMOptional;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbRMOptionalJN;
        private QS2.Desktop.ControlManagment.BasePanel pnlEintragFlag;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbEintagFlag;
        private QS2.Desktop.ControlManagment.BaseLabel baseLabel1;
        private BaseControls.ZeitbereichCombo cbZeitbereich;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpTime;
        private QS2.Desktop.ControlManagment.BaseLabel baseLabel2;
        private BaseControls.UserCombo cbChanged;
        private QS2.Desktop.ControlManagment.BaseLabel lblInfoChanged;
        private BaseControls.UserCombo cbCreated;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private IContainer components;







        public ucPflegePlanSingleEdit2()
        {
            InitializeComponent();

            cbZeitbereich.Top = dtpTime.Top;          

            if (DesignMode || !ENV.AppRunning)
                return;

            cbZeitbereich.RefreshList(true);            
            cbZeitbereich.IDZeitbereich = Guid.Empty;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ZusatzGruppe ZusatzGruppe
        {
            get { return ucZusatzeintrag1.ZusatzGruppe; }
            set { ucZusatzeintrag1.ZusatzGruppe = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PflegePlanModi PflegePlanMode
        {
            get { return _PflegePlanMode; }
            set { _PflegePlanMode = value; }
        }

        private bool IS_FIXEZEIT { get { return osZeit.CheckedIndex == 0; } }
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
                if (value)
                {
                    _aVisibleControls.Add(cbParalell);
                    _aVisibleControls.Add(pnlcbParalell);
                }
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
                PARALELL_CB_VISIBLE = false;

                cbLokalisierung.Visible = false;
                pnlcbLokalisierung.Visible = false;
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
        //----------------------------------------------------------------------------
        /// <summary>
        /// Die zu bearbeitende Row
        /// ACHTUNG die Daten der ROW werden aktuaisiert wenn AcceptChanges ausgeführt wird
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsPflegePlan.PflegePlanRow PFLEGEPLANROW
        {
            set
            {
                if (value == null)
                    return;
                if (DesignMode)
                    return;
                _isTextChanged = false;
                _valueChangeEnabled = false;
                _row = value;
                _EintragGruppe = PDx.GetEintragGruppeFromChar(_row.EintragGruppe[0]);
                ReadOnly = _row.ErledigtJN;
                ShowHideFields();
                RefreshControl();
                //ShowHideFields();
                _valueChangeEnabled = true;
            }
            get
            {
                return _row;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool MassnahmeOhneZeitbezug
        {
            get { return _MassnahmeOhneZeitbezug; }
            set
            {
                _MassnahmeOhneZeitbezug = value;
                ShowHideControls();
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Versteckt oder zeigt die entsprechenden Felder
        /// </summary>
        //----------------------------------------------------------------------------
        private void ShowHideFields()
        {

            if (_row == null)
                return;
            _aVisibleControls.Clear();
            _aVisibleControls.Add(pnlBez);
            _aVisibleControls.Add(pnlW);
            _aVisibleControls.Add(pnlDokument);

            if (_EintragGruppe == EintragGruppe.M || _EintragGruppe == EintragGruppe.T)
            {
                pnlEinmalig.Visible = true;
                _aVisibleControls.Add(pnlEinmalig);
                pnlIntervall.Visible = true;
                _aVisibleControls.Add(pnlIntervall);
                pnlBerufsstand.Visible = true;
                _aVisibleControls.Add(pnlBerufsstand);
                pnlLokalisierung.Visible = false;// TransferMode ? false : true;

                if (!TransferMode)
                    _aVisibleControls.Add(pnlLokalisierung);
                pnlRMOptional.Visible = true;
                _aVisibleControls.Add(pnlRMOptional);

                if (_EintragGruppe == EintragGruppe.M)
                {
                    pnlUhrzeit.Visible = TransferMode ? false : true;
                    if (!TransferMode)
                        _aVisibleControls.Add(pnlUhrzeit);
                }
                else
                    pnlUhrzeit.Visible = false;

                if (_EintragGruppe == EintragGruppe.M)
                    tabMain.Tabs["Zusatzwerte"].Visible = true;
                else
                    tabMain.Tabs["Zusatzwerte"].Visible = false;
                // QS2.Desktop.ControlManagment.ControlManagment.MessageBox(pnlEintragFlag.Visible.ToString());
                //if (_EintragGruppe == EintragGruppe.M && _row.EintragFlag != 5) // bei Haupt/PDx-Maßnahmen nicht anzeigen 
                //{
                    pnlEintragFlag.Visible = true;
                    _aVisibleControls.Add(pnlEintragFlag);
                //}
                //else
                //    pnlEintragFlag.Visible = false;
            }
            else
            {
                pnlEinmalig.Visible = false;
                pnlIntervall.Visible = false;
                pnlBerufsstand.Visible = false;
                pnlLokalisierung.Visible = false;
                pnlUhrzeit.Visible = false;
                pnlRMOptional.Visible = false;
                pnlEintragFlag.Visible = false;
                tabMain.Tabs["Zusatzwerte"].Visible = false;
            }


            // Nächste Evaluierung ist nur im Modus Klient sowie bei den Zielen mit Evaluierung nach Zielen oder Zielen und Unterventionen ODER maßnahmen und Evaluierung Ziel und Intervention notwendig
            if (
                (_EintragGruppe == EintragGruppe.Z && ENV.EvaluierungsTyp == EvaluierungsTypen.Ziel) ||
                (_EintragGruppe == EintragGruppe.M && ENV.InterventionenEvaluieren)
               )
            {
                pnlNaechsteEvaluierung.Visible = true;
                _aVisibleControls.Add(pnlNaechsteEvaluierung);
            }
            else
            {
                pnlNaechsteEvaluierung.Visible = false;
            }

            // Bei Termin gibt es eine Auswahlcombo für die Art des Termines
            if (ISTERMIN)
            {
                cbTermin.Visible = true;
                _aVisibleControls.Add(cbTermin);
                tbText.Visible = false;
            }
            else
            {
                cbTermin.Visible = false;
                tbText.Visible = true;
                _aVisibleControls.Add(tbText);
            }

            pnlInfo.Visible = ISTERMIN;                 // 4.7.2007 RBU: Wunsch enz 

            if (ISTERMIN)
                _aVisibleControls.Add(pnlInfo);
            if (TransferMode)                            // Im Transfermodus bestimmte Elemente ausblenden
                HideFieldsForTransfermode();

            //Feld Anmerkung verstecken wenn es sich um eine Maßnahme mit Zeitbezug handelt (Anmerkungen sind dann bei Einzelzeilen)

            _showPnlAnm = (PFLEGEPLANROW.EintragGruppe == "M" && PFLEGEPLANROW.OhneZeitBezug) ? false : true;

            if (_showPnlAnm)
                _aVisibleControls.Add(pnlAnm);


            RecalcHeight();
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktualisiert das Control
        /// </summary>
        //----------------------------------------------------------------------------
        public void RefreshControl()
        {
            if (DesignMode)
                return;
            if (_row == null)
                return;

            cbCreated.Value = _row.IDBenutzer_Erstellt;
            cbChanged.Value = _row.IDBenutzer_Geaendert;
            
            tbText.Text = _row.Text;       

            if (ISTERMIN)				            							// Bei Termin muss die Combo mit dem Wert befüllt werden
                cbTermin.Text = _row.Text;

            tbWarnung.Text = _row.Warnhinweis;
            tbAnmerkung.Text = _row.Anmerkung;

            tbNaechsteEvaluierungBemerkung.Text = _row.NaechsteEvaluierungBemerkung;
            if (_row.IsNaechsteEvaluierungNull())
            {
                if (_row.EintragGruppe.sEquals(EintragGruppe.M))
                {
                    dtpNaechsteEvaluierung.Value = null;
                }
                else
                    dtpNaechsteEvaluierung.DateTime = new DateTime(1900, 1, 1);
            }
            else
            {
                dtpNaechsteEvaluierung.DateTime = _row.NaechsteEvaluierung;
            }

            if (_row.IsIDLinkDokumentNull())
                cbLinkDokument.IDLinkDokument = Guid.Empty;//(Guid)((dsEintrag.EintragDataTable)((new Eintrag()).Read(_row.IDEintrag)).Rows[0].;
            else
                cbLinkDokument.IDLinkDokument = _row.IDLinkDokument;

            if (!(_EintragGruppe == EintragGruppe.M || _EintragGruppe == EintragGruppe.T))					// Alles folgende gilt nur für Maßnahmen
                return;

            cbEinmalig.Checked = _row.EinmaligJN;
            cbRMOptionalJN.Checked = _row.RMOptionalJN;
            cbLokalisierung.Checked = _row.LokalisierungJN;
            cbParalell.Checked = _row.ParalellJN;
            ucWochenTage11.WOCHENTAGE = _row.WochenTage;
            tbDauer.Value = _row.Dauer;
            cbBerufsstand.Value = _row.IDBerufsstand;
            cbArea.Text = _row.Lokalisierung.Trim();
            cbSide.Text = _row.LokalisierungSeite.Trim();
            dtpTime.Value = _row.StartDatum;
            MassnahmeOhneZeitbezug = _row.OhneZeitBezug;


      //      if (_EintragGruppe == EintragGruppe.M && _row.EintragFlag != 5) // bei Haupt/PDx-Maßnahmen nicht anzeigen 
      //      {
                pnlEintragFlag.Visible = true;
                _aVisibleControls.Add(pnlEintragFlag);
            //}
            //else
            //    pnlEintragFlag.Visible = false;
            //this._IDEintrag = 3;

            this.userHasEintragFlagChanged = false;
            if (_row.EintragFlag == 1 || _row.EintragFlag == 4)
            {
                cbEintagFlag.Checked = true;
                this._IDEintrag = 4;
            }
            else
            {
                cbEintagFlag.Checked = false;
                if (_row.EintragFlag == 0)
                {
                    this._IDEintrag = 3;
                }
                else
                {
                    this._IDEintrag = 3;
                }
                if (_row.EintragFlag == 2)
                {
                    this._IDEintrag = 5;
                }
                else
                {
                    this._IDEintrag = 3;
                }
            }

            ucZusatzeintrag1.IDEintrag = _row.IDEintrag;

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

            if (_row.Intervall % 721 == 0)							// Monate
            {
                tbIntervall.Value = 1;
                osIntervall.CheckedIndex = 2;
            }
            else if (_row.Intervall % 168 == 0)							// woche
            {
                tbIntervall.Value = _row.Intervall / 168;
                osIntervall.CheckedIndex = 1;
            }
            else if (_row.Intervall % 24 == 0)							// Tage
            {
                tbIntervall.Value = _row.Intervall / 24;
                osIntervall.CheckedIndex = 0;
            }

            //this.ucVOErfassen1.initControl(Verordnungen.ucVOErfassen.eTypeUI.VOErfassenPlanung);
            //using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
            //{
                //PMDS.db.Entities.PflegePlanPDx rPflegePlanPDx = db.PflegePlanPDx.Where(o => o.IDPflegePlan == _row.ID).First();
        
            //}
           
            cbLokalisierung_CheckedChanged(this, null);

            SetShowbuttonEnabled();
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert True wenn der Originaltext modifiziert wurde als verändert.
        /// Ein Text hinzufügen bedeutet keine Veränderung.
        /// </summary>
        //----------------------------------------------------------------------------
        public bool IsOriginalModified()
        {
            return IsOriginalModified(_row.IDEintrag, tbText.Text.Trim());
        }

        private bool IsOriginalModified(Guid IDEintrag, string sNewText)
        {
            string sOriginal = Eintrag.GetText(IDEintrag);
            if (sNewText.IndexOf(sOriginal) > -1)					// gefunden ==> original
                return false;
            else
                return true;

        }

        public bool ValidateFields()
        {
            bool bError = !ucZusatzeintrag1.ValidateFields();

            if (bError)
                tabMain.SelectedTab = tabMain.Tabs["Zusatzwerte"];
            
            //if (!this.ucVOErfassen1.validateData())
            //{
            //    bError = true;
            //}

            return !bError;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Schreibt die Änderungen in die Row
        /// </summary>
        //----------------------------------------------------------------------------
        public void AcceptChanges()
        {
            if (_isTextChanged && IsOriginalModified())
            {
                DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("PP_ORIGINAL_TEXT_CHANGED"),
                                                                                            ENV.String("DIALOGTITLE_PP_ORIGINAL_TEXT_CHANGED"),
                                                                                            MessageBoxButtons.YesNo,
                                                                                            MessageBoxIcon.Question, true);
                if (res != DialogResult.Yes)
                {
                    _isTextChanged = false;
                    return;
                }
            }

            _isTextChanged = false;

            string sText = "";
            if (ISTERMIN)
                sText = cbTermin.Text.Trim();
            else
                sText = tbText.Text.Trim();

            bool bOriginalModified = false;
            if (!ISTERMIN && !_row.IsIDEintragNull())
                bOriginalModified = IsOriginalModified(_row.IDEintrag, sText);

            if (bOriginalModified)
                _row.OriginalJN = false;
            else
                _row.OriginalJN = true;

            _row.Text = sText;


            _row.Warnhinweis = tbWarnung.Text.Trim();

            if (!_row.UntertaegigeJN)
                _row.Anmerkung = tbAnmerkung.Text.Trim();

            if (this.mainWindow != null && this.mainWindow.cbMohneZeitbezug.Checked)
            {
                _row.Anmerkung = tbAnmerkung.Text.Trim();
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


            if (!(_EintragGruppe == EintragGruppe.M || _EintragGruppe == EintragGruppe.T))					// Alles folgende gilt nur für Maßnahmen
                return;

            _row.EinmaligJN = cbEinmalig.Checked ? true : false;
            _row.RMOptionalJN = cbRMOptionalJN.Checked ? true : false;
            _row.LokalisierungJN = cbLokalisierung.Checked ? true : false;
            _row.ParalellJN = cbParalell.Checked ? true : false;
            _row.WochenTage = ucWochenTage11.WOCHENTAGE;
            _row.Dauer = (int)tbDauer.Value;
            _row.IDBerufsstand = cbBerufsstand.Value == null ? Guid.Empty : (Guid)cbBerufsstand.Value;
            _row.Lokalisierung = cbArea.Text.Trim();
            _row.LokalisierungSeite = cbSide.Text.Trim();

            DateTime dt = _row.StartDatum;
            DateTime dtt = dtpTime.DateTime;
            _row.StartDatum = new DateTime(dt.Year, dt.Month, dt.Day, dtt.Hour, dtt.Minute, 0);		// Startdatum gemäß Uhrzeit setzen
            _row.OhneZeitBezug = MassnahmeOhneZeitbezug;

            //if (pnlEintragFlag.Visible && _EintragGruppe != EintragGruppe.T)
            //    if (_row.EintragFlag != 5 && _EintragGruppe != EintragGruppe.T)
            //    {
            //        if (cbEintagFlag.Checked)
            //            _row.EintragFlag = 4;
            //        else
            //            _row.EintragFlag = 3;
            //    }
            //    else _row.EintragFlag = 5;


            if (this.userHasEintragFlagChanged)
            {
                if (this.cbEintagFlag.Checked)
                {
                    _row.EintragFlag = 4;
                }
                else
                {
                    _row.EintragFlag = 3;
                }
            }
            else
            {
                _row.EintragFlag = this._IDEintrag;
            }

            if (!_row.IsLetztesDatumNull())
            {
                DateTime dtl = _row.LetztesDatum;
                _row.LetztesDatum = new DateTime(dtl.Year, dtl.Month, dtl.Day, dtt.Hour, dtt.Minute, 0);	// Das letzte Datum muss mit der Uhrzeit korrespondieren
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
                _row.StartDatum = new DateTime(_row.StartDatum.Year, _row.StartDatum.Month, _row.StartDatum.Day, cbZeitbereich.VON_SELECTED.Hour, cbZeitbereich.VON_SELECTED.Minute, 0);
                if (!_row.IsLetztesDatumNull())
                    _row.LetztesDatum = new DateTime(_row.LetztesDatum.Year, _row.LetztesDatum.Month, _row.LetztesDatum.Day, cbZeitbereich.VON_SELECTED.Hour, cbZeitbereich.VON_SELECTED.Minute, 0);	// Das letzte Datum muss mit der Uhrzeit korrespondieren
                _row.IDZeitbereich = cbZeitbereich.IDZeitbereich;

            }


            switch (osIntervall.CheckedIndex)
            {
                case 0:
                    _row.Intervall = (int)tbIntervall.Value * 24;		// Tage
                    break;
                case 1:
                    _row.Intervall = (int)tbIntervall.Value * 168;	// Wochen
                    break;
                case 2:
                    _row.Intervall = (int)tbIntervall.Value * 721;	// Monate
                    break;
            }

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Dispose
        /// </summary>
        //----------------------------------------------------------------------------
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.ValueListItem valueListItem17 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem18 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.pnlUhrzeit = new QS2.Desktop.ControlManagment.BasePanel();
            this.cbZeitbereich = new PMDS.GUI.BaseControls.ZeitbereichCombo();
            this.dtpTime = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.osZeit = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.lblUhrzeit = new QS2.Desktop.ControlManagment.BaseLabel();
            this.pnlM = new QS2.Desktop.ControlManagment.BasePanel();
            this.pnlNaechsteEvaluierung = new QS2.Desktop.ControlManagment.BasePanel();
            this.tbNaechsteEvaluierungBemerkung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.dtpNaechsteEvaluierung = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.ultraLabel14 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ultraLabel11 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.pnlLokalisierung = new QS2.Desktop.ControlManagment.BasePanel();
            this.baseLabel2 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbSide = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.ultraLabel6 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbArea = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.ultraLabel7 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.pnlBerufsstand = new QS2.Desktop.ControlManagment.BasePanel();
            this.baseLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbBerufsstand = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.tbDauer = new QS2.Desktop.ControlManagment.BaseNumericEditor();
            this.ultraLabel9 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ultraLabel8 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.pnlIntervall = new QS2.Desktop.ControlManagment.BasePanel();
            this.ucWochenTage11 = new PMDS.GUI.ucWochenTage1();
            this.ultraLabel4 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ultraLabel10 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.osIntervall = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.tbIntervall = new QS2.Desktop.ControlManagment.BaseNumericEditor();
            this.pnlEinmalig = new QS2.Desktop.ControlManagment.BasePanel();
            this.pnlcbLokalisierung = new QS2.Desktop.ControlManagment.BasePanel();
            this.cbLokalisierung = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.pnlcbParalell = new QS2.Desktop.ControlManagment.BasePanel();
            this.cbParalell = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.pnlcbEinmalig = new QS2.Desktop.ControlManagment.BasePanel();
            this.cbEinmalig = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.pnlRMOptional = new QS2.Desktop.ControlManagment.BasePanel();
            this.cbRMOptionalJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.pnlEintragFlag = new QS2.Desktop.ControlManagment.BasePanel();
            this.cbEintagFlag = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.pnlInfo = new QS2.Desktop.ControlManagment.BasePanel();
            this.cbChanged = new PMDS.GUI.BaseControls.UserCombo();
            this.lblInfoCreated = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblInfoChanged = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbCreated = new PMDS.GUI.BaseControls.UserCombo();
            this.pnlGenerell = new QS2.Desktop.ControlManagment.BasePanel();
            this.pnlDokument = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnShow = new QS2.Desktop.ControlManagment.BaseButton();
            this.lblDokument = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbLinkDokument = new PMDS.GUI.BaseControls.LinkDokumenteCombo();
            this.pnlAnm = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraLabel3 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbAnmerkung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.pnlBez = new QS2.Desktop.ControlManagment.BasePanel();
            this.tbText = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.cbTermin = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.lblBezeichnung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.pnlW = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraLabel2 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbWarnung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ucZusatzeintrag1 = new PMDS.GUI.PflegePlan2.ucZusatzeintrag();
            this.tabMain = new QS2.Desktop.ControlManagment.BaseTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.ultraTabPageControl1.SuspendLayout();
            this.pnlUhrzeit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbZeitbereich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osZeit)).BeginInit();
            this.pnlM.SuspendLayout();
            this.pnlNaechsteEvaluierung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbNaechsteEvaluierungBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNaechsteEvaluierung)).BeginInit();
            this.pnlLokalisierung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbArea)).BeginInit();
            this.pnlBerufsstand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbBerufsstand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDauer)).BeginInit();
            this.pnlIntervall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.osIntervall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbIntervall)).BeginInit();
            this.pnlEinmalig.SuspendLayout();
            this.pnlcbLokalisierung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbLokalisierung)).BeginInit();
            this.pnlcbParalell.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbParalell)).BeginInit();
            this.pnlcbEinmalig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbEinmalig)).BeginInit();
            this.pnlRMOptional.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbRMOptionalJN)).BeginInit();
            this.pnlEintragFlag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbEintagFlag)).BeginInit();
            this.pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbChanged)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCreated)).BeginInit();
            this.pnlGenerell.SuspendLayout();
            this.pnlDokument.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbLinkDokument)).BeginInit();
            this.pnlAnm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAnmerkung)).BeginInit();
            this.pnlBez.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTermin)).BeginInit();
            this.pnlW.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbWarnung)).BeginInit();
            this.ultraTabPageControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.pnlUhrzeit);
            this.ultraTabPageControl1.Controls.Add(this.pnlM);
            this.ultraTabPageControl1.Controls.Add(this.pnlInfo);
            this.ultraTabPageControl1.Controls.Add(this.pnlGenerell);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 24);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(678, 430);
            // 
            // pnlUhrzeit
            // 
            this.pnlUhrzeit.Controls.Add(this.cbZeitbereich);
            this.pnlUhrzeit.Controls.Add(this.dtpTime);
            this.pnlUhrzeit.Controls.Add(this.osZeit);
            this.pnlUhrzeit.Controls.Add(this.lblUhrzeit);
            this.pnlUhrzeit.Location = new System.Drawing.Point(4, 383);
            this.pnlUhrzeit.Name = "pnlUhrzeit";
            this.pnlUhrzeit.Size = new System.Drawing.Size(494, 31);
            this.pnlUhrzeit.TabIndex = 6;
            // 
            // cbZeitbereich
            // 
            this.cbZeitbereich.Location = new System.Drawing.Point(357, 3);
            this.cbZeitbereich.Name = "cbZeitbereich";
            this.cbZeitbereich.Size = new System.Drawing.Size(131, 24);
            this.cbZeitbereich.TabIndex = 15;
            this.cbZeitbereich.Visible = false;
            this.cbZeitbereich.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cbZeitbereich_BeforeDropDown);
            this.cbZeitbereich.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // dtpTime
            // 
            this.dtpTime.DateTime = new System.DateTime(2008, 10, 9, 0, 0, 0, 0);
            this.dtpTime.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.dtpTime.FormatString = "dd.MM.yyyy";
            this.dtpTime.Location = new System.Drawing.Point(294, 3);
            this.dtpTime.MaskInput = "hh:mm";
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ownFormat = "";
            this.dtpTime.ownMaskInput = "";
            this.dtpTime.Size = new System.Drawing.Size(48, 24);
            this.dtpTime.TabIndex = 0;
            this.dtpTime.Value = new System.DateTime(2008, 10, 9, 0, 0, 0, 0);
            this.dtpTime.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // osZeit
            // 
            this.osZeit.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.osZeit.CheckedIndex = 0;
            valueListItem17.DataValue = "ValueListItem1";
            valueListItem17.DisplayText = "Fixe Zeit";
            valueListItem18.DataValue = "ValueListItem2";
            valueListItem18.DisplayText = "Zeitbereich";
            this.osZeit.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem17,
            valueListItem18});
            this.osZeit.ItemSpacingVertical = 2;
            this.osZeit.Location = new System.Drawing.Point(9, 7);
            this.osZeit.Name = "osZeit";
            this.osZeit.Size = new System.Drawing.Size(168, 21);
            this.osZeit.TabIndex = 14;
            this.osZeit.Text = "Fixe Zeit";
            this.osZeit.ValueChanged += new System.EventHandler(this.osZeit_ValueChanged);
            // 
            // lblUhrzeit
            // 
            this.lblUhrzeit.Location = new System.Drawing.Point(234, 7);
            this.lblUhrzeit.Name = "lblUhrzeit";
            this.lblUhrzeit.Size = new System.Drawing.Size(54, 16);
            this.lblUhrzeit.TabIndex = 13;
            this.lblUhrzeit.Text = "Uhrzeit";
            // 
            // pnlM
            // 
            this.pnlM.Controls.Add(this.pnlNaechsteEvaluierung);
            this.pnlM.Controls.Add(this.pnlLokalisierung);
            this.pnlM.Controls.Add(this.pnlBerufsstand);
            this.pnlM.Controls.Add(this.pnlIntervall);
            this.pnlM.Controls.Add(this.pnlEinmalig);
            this.pnlM.Location = new System.Drawing.Point(4, 156);
            this.pnlM.Name = "pnlM";
            this.pnlM.Size = new System.Drawing.Size(674, 190);
            this.pnlM.TabIndex = 4;
            // 
            // pnlNaechsteEvaluierung
            // 
            this.pnlNaechsteEvaluierung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNaechsteEvaluierung.Controls.Add(this.tbNaechsteEvaluierungBemerkung);
            this.pnlNaechsteEvaluierung.Controls.Add(this.dtpNaechsteEvaluierung);
            this.pnlNaechsteEvaluierung.Controls.Add(this.ultraLabel14);
            this.pnlNaechsteEvaluierung.Controls.Add(this.ultraLabel11);
            this.pnlNaechsteEvaluierung.Location = new System.Drawing.Point(0, 132);
            this.pnlNaechsteEvaluierung.Name = "pnlNaechsteEvaluierung";
            this.pnlNaechsteEvaluierung.Size = new System.Drawing.Size(671, 55);
            this.pnlNaechsteEvaluierung.TabIndex = 9;
            // 
            // tbNaechsteEvaluierungBemerkung
            // 
            this.tbNaechsteEvaluierungBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNaechsteEvaluierungBemerkung.Location = new System.Drawing.Point(300, 6);
            this.tbNaechsteEvaluierungBemerkung.MaxLength = 255;
            this.tbNaechsteEvaluierungBemerkung.Multiline = true;
            this.tbNaechsteEvaluierungBemerkung.Name = "tbNaechsteEvaluierungBemerkung";
            this.tbNaechsteEvaluierungBemerkung.Size = new System.Drawing.Size(368, 47);
            this.tbNaechsteEvaluierungBemerkung.TabIndex = 21;
            this.tbNaechsteEvaluierungBemerkung.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // dtpNaechsteEvaluierung
            // 
            this.dtpNaechsteEvaluierung.DateTime = new System.DateTime(2008, 10, 9, 0, 0, 0, 0);
            this.dtpNaechsteEvaluierung.FormatString = "";
            this.dtpNaechsteEvaluierung.Location = new System.Drawing.Point(140, 6);
            this.dtpNaechsteEvaluierung.MaskInput = "";
            this.dtpNaechsteEvaluierung.Name = "dtpNaechsteEvaluierung";
            this.dtpNaechsteEvaluierung.ownFormat = "";
            this.dtpNaechsteEvaluierung.ownMaskInput = "";
            this.dtpNaechsteEvaluierung.Size = new System.Drawing.Size(106, 24);
            this.dtpNaechsteEvaluierung.TabIndex = 20;
            this.dtpNaechsteEvaluierung.Value = new System.DateTime(2008, 10, 9, 0, 0, 0, 0);
            this.dtpNaechsteEvaluierung.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.dtpNaechsteEvaluierung.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.dtpNaechsteEvaluierung_BeforeDropDown);
            // 
            // ultraLabel14
            // 
            this.ultraLabel14.Location = new System.Drawing.Point(260, 10);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(37, 21);
            this.ultraLabel14.TabIndex = 22;
            this.ultraLabel14.Text = "Anm.";
            // 
            // ultraLabel11
            // 
            this.ultraLabel11.Location = new System.Drawing.Point(10, 10);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(142, 19);
            this.ultraLabel11.TabIndex = 23;
            this.ultraLabel11.Text = "Nächste Evaluierung";
            // 
            // pnlLokalisierung
            // 
            this.pnlLokalisierung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLokalisierung.Controls.Add(this.baseLabel2);
            this.pnlLokalisierung.Controls.Add(this.cbSide);
            this.pnlLokalisierung.Controls.Add(this.ultraLabel6);
            this.pnlLokalisierung.Controls.Add(this.cbArea);
            this.pnlLokalisierung.Controls.Add(this.ultraLabel7);
            this.pnlLokalisierung.Location = new System.Drawing.Point(0, 99);
            this.pnlLokalisierung.Name = "pnlLokalisierung";
            this.pnlLokalisierung.Size = new System.Drawing.Size(671, 31);
            this.pnlLokalisierung.TabIndex = 5;
            // 
            // baseLabel2
            // 
            this.baseLabel2.Location = new System.Drawing.Point(13, 6);
            this.baseLabel2.Name = "baseLabel2";
            this.baseLabel2.Size = new System.Drawing.Size(99, 16);
            this.baseLabel2.TabIndex = 14;
            this.baseLabel2.Text = "Lokalisierung:";
            // 
            // cbSide
            // 
            this.cbSide.AddEmptyEntry = false;
            this.cbSide.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cbSide.AutoOpenCBO = false;
            this.cbSide.BerufsstandGruppeJNA = -1;
            this.cbSide.Enabled = false;
            this.cbSide.ExactMatch = false;
            this.cbSide.Group = "LOS";
            this.cbSide.ID_PEP = -1;
            this.cbSide.IgnoreUnterdruecken = true;
            this.cbSide.Location = new System.Drawing.Point(365, 3);
            this.cbSide.MaxLength = 50;
            this.cbSide.Name = "cbSide";
            this.cbSide.PflichtJN = false;
            this.cbSide.SelectDistinct = false;
            this.cbSide.ShowAddButton = true;
            this.cbSide.Size = new System.Drawing.Size(122, 24);
            this.cbSide.sys = false;
            this.cbSide.TabIndex = 1;
            this.cbSide.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cbSide_BeforeDropDown);
            this.cbSide.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Location = new System.Drawing.Point(319, 7);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(40, 16);
            this.ultraLabel6.TabIndex = 13;
            this.ultraLabel6.Text = "Seite";
            // 
            // cbArea
            // 
            this.cbArea.AddEmptyEntry = false;
            this.cbArea.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cbArea.AutoOpenCBO = false;
            this.cbArea.BerufsstandGruppeJNA = -1;
            this.cbArea.Enabled = false;
            this.cbArea.ExactMatch = false;
            this.cbArea.Group = "LOA";
            this.cbArea.ID_PEP = -1;
            this.cbArea.IgnoreUnterdruecken = true;
            this.cbArea.Location = new System.Drawing.Point(189, 3);
            this.cbArea.MaxLength = 50;
            this.cbArea.Name = "cbArea";
            this.cbArea.PflichtJN = false;
            this.cbArea.SelectDistinct = false;
            this.cbArea.ShowAddButton = true;
            this.cbArea.Size = new System.Drawing.Size(124, 24);
            this.cbArea.sys = false;
            this.cbArea.TabIndex = 0;
            this.cbArea.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cbArea_BeforeDropDown);
            this.cbArea.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.Location = new System.Drawing.Point(115, 6);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(68, 16);
            this.ultraLabel7.TabIndex = 12;
            this.ultraLabel7.Text = "Körperteil";
            // 
            // pnlBerufsstand
            // 
            this.pnlBerufsstand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBerufsstand.Controls.Add(this.baseLabel1);
            this.pnlBerufsstand.Controls.Add(this.cbBerufsstand);
            this.pnlBerufsstand.Controls.Add(this.tbDauer);
            this.pnlBerufsstand.Controls.Add(this.ultraLabel9);
            this.pnlBerufsstand.Controls.Add(this.ultraLabel8);
            this.pnlBerufsstand.Location = new System.Drawing.Point(1, 65);
            this.pnlBerufsstand.Name = "pnlBerufsstand";
            this.pnlBerufsstand.Size = new System.Drawing.Size(671, 31);
            this.pnlBerufsstand.TabIndex = 4;
            // 
            // baseLabel1
            // 
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.baseLabel1.Appearance = appearance1;
            this.baseLabel1.Location = new System.Drawing.Point(150, 7);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(34, 16);
            this.baseLabel1.TabIndex = 9;
            this.baseLabel1.Text = "Min.";
            // 
            // cbBerufsstand
            // 
            this.cbBerufsstand.AddEmptyEntry = false;
            this.cbBerufsstand.AutoOpenCBO = false;
            this.cbBerufsstand.BerufsstandGruppeJNA = -1;
            this.cbBerufsstand.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbBerufsstand.ExactMatch = false;
            this.cbBerufsstand.Group = "BER";
            this.cbBerufsstand.ID_PEP = -1;
            this.cbBerufsstand.IgnoreUnterdruecken = true;
            this.cbBerufsstand.Location = new System.Drawing.Point(326, 3);
            this.cbBerufsstand.Name = "cbBerufsstand";
            this.cbBerufsstand.PflichtJN = false;
            this.cbBerufsstand.SelectDistinct = false;
            this.cbBerufsstand.ShowAddButton = true;
            this.cbBerufsstand.Size = new System.Drawing.Size(161, 24);
            this.cbBerufsstand.sys = false;
            this.cbBerufsstand.TabIndex = 8;
            this.cbBerufsstand.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cbBerufsstand_BeforeDropDown);
            this.cbBerufsstand.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // tbDauer
            // 
            this.tbDauer.Location = new System.Drawing.Point(114, 3);
            this.tbDauer.MaskInput = "nnnn";
            this.tbDauer.MaxValue = 9999;
            this.tbDauer.MinValue = 0;
            this.tbDauer.Name = "tbDauer";
            this.tbDauer.PromptChar = ' ';
            this.tbDauer.Size = new System.Drawing.Size(31, 24);
            this.tbDauer.TabIndex = 0;
            this.tbDauer.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // ultraLabel9
            // 
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance2;
            this.ultraLabel9.Location = new System.Drawing.Point(221, 7);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(85, 16);
            this.ultraLabel9.TabIndex = 7;
            this.ultraLabel9.Text = "Berufsstand";
            // 
            // ultraLabel8
            // 
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance3;
            this.ultraLabel8.Location = new System.Drawing.Point(10, 7);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(105, 16);
            this.ultraLabel8.TabIndex = 5;
            this.ultraLabel8.Text = "Dauer";
            // 
            // pnlIntervall
            // 
            this.pnlIntervall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlIntervall.Controls.Add(this.ucWochenTage11);
            this.pnlIntervall.Controls.Add(this.ultraLabel4);
            this.pnlIntervall.Controls.Add(this.ultraLabel10);
            this.pnlIntervall.Controls.Add(this.osIntervall);
            this.pnlIntervall.Controls.Add(this.tbIntervall);
            this.pnlIntervall.Location = new System.Drawing.Point(1, 3);
            this.pnlIntervall.Name = "pnlIntervall";
            this.pnlIntervall.Size = new System.Drawing.Size(670, 59);
            this.pnlIntervall.TabIndex = 2;
            // 
            // ucWochenTage11
            // 
            this.ucWochenTage11.Location = new System.Drawing.Point(114, 32);
            this.ucWochenTage11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucWochenTage11.Name = "ucWochenTage11";
            this.ucWochenTage11.Size = new System.Drawing.Size(359, 26);
            this.ucWochenTage11.TabIndex = 5;
            this.ucWochenTage11.WOCHENTAGE = 2;
            this.ucWochenTage11.ASZMValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // ultraLabel4
            // 
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance4;
            this.ultraLabel4.Location = new System.Drawing.Point(9, 7);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(80, 16);
            this.ultraLabel4.TabIndex = 3;
            this.ultraLabel4.Text = "Intervall alle";
            // 
            // ultraLabel10
            // 
            appearance5.TextHAlignAsString = "Left";
            appearance5.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance5;
            this.ultraLabel10.Location = new System.Drawing.Point(9, 37);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(85, 16);
            this.ultraLabel10.TabIndex = 10;
            this.ultraLabel10.Text = "Wochentage";
            // 
            // osIntervall
            // 
            this.osIntervall.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            valueListItem13.DataValue = "ValueListItem1";
            valueListItem13.DisplayText = "Tage";
            valueListItem14.DataValue = "ValueListItem2";
            valueListItem14.DisplayText = "Wochen";
            valueListItem1.DataValue = "ValueListItem3";
            valueListItem1.DisplayText = "Monate";
            this.osIntervall.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem13,
            valueListItem14,
            valueListItem1});
            this.osIntervall.ItemSpacingVertical = 2;
            this.osIntervall.Location = new System.Drawing.Point(150, 6);
            this.osIntervall.Name = "osIntervall";
            this.osIntervall.Size = new System.Drawing.Size(251, 22);
            this.osIntervall.TabIndex = 1;
            this.osIntervall.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // tbIntervall
            // 
            this.tbIntervall.Location = new System.Drawing.Point(113, 3);
            this.tbIntervall.MaskInput = "nnnn";
            this.tbIntervall.MaxValue = 9999;
            this.tbIntervall.MinValue = 0;
            this.tbIntervall.Name = "tbIntervall";
            this.tbIntervall.PromptChar = ' ';
            this.tbIntervall.Size = new System.Drawing.Size(32, 24);
            this.tbIntervall.TabIndex = 0;
            this.tbIntervall.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // pnlEinmalig
            // 
            this.pnlEinmalig.Controls.Add(this.pnlcbLokalisierung);
            this.pnlEinmalig.Controls.Add(this.pnlcbParalell);
            this.pnlEinmalig.Controls.Add(this.pnlcbEinmalig);
            this.pnlEinmalig.Controls.Add(this.pnlRMOptional);
            this.pnlEinmalig.Controls.Add(this.pnlEintragFlag);
            this.pnlEinmalig.Location = new System.Drawing.Point(0, -67);
            this.pnlEinmalig.Name = "pnlEinmalig";
            this.pnlEinmalig.Size = new System.Drawing.Size(550, 29);
            this.pnlEinmalig.TabIndex = 0;
            // 
            // pnlcbLokalisierung
            // 
            this.pnlcbLokalisierung.Controls.Add(this.cbLokalisierung);
            this.pnlcbLokalisierung.Location = new System.Drawing.Point(437, 0);
            this.pnlcbLokalisierung.Name = "pnlcbLokalisierung";
            this.pnlcbLokalisierung.Size = new System.Drawing.Size(110, 29);
            this.pnlcbLokalisierung.TabIndex = 4;
            // 
            // cbLokalisierung
            // 
            this.cbLokalisierung.Enabled = false;
            this.cbLokalisierung.Location = new System.Drawing.Point(3, 4);
            this.cbLokalisierung.Name = "cbLokalisierung";
            this.cbLokalisierung.Size = new System.Drawing.Size(105, 20);
            this.cbLokalisierung.TabIndex = 1;
            this.cbLokalisierung.Text = "Lokalisierung";
            this.cbLokalisierung.CheckedChanged += new System.EventHandler(this.cbLokalisierung_CheckedChanged);
            // 
            // pnlcbParalell
            // 
            this.pnlcbParalell.Controls.Add(this.cbParalell);
            this.pnlcbParalell.Location = new System.Drawing.Point(361, 0);
            this.pnlcbParalell.Name = "pnlcbParalell";
            this.pnlcbParalell.Size = new System.Drawing.Size(77, 29);
            this.pnlcbParalell.TabIndex = 5;
            this.pnlcbParalell.Visible = false;
            // 
            // cbParalell
            // 
            this.cbParalell.Location = new System.Drawing.Point(4, 5);
            this.cbParalell.Name = "cbParalell";
            this.cbParalell.Size = new System.Drawing.Size(70, 20);
            this.cbParalell.TabIndex = 2;
            this.cbParalell.Text = "Paralell";
            this.cbParalell.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // pnlcbEinmalig
            // 
            this.pnlcbEinmalig.Controls.Add(this.cbEinmalig);
            this.pnlcbEinmalig.Location = new System.Drawing.Point(272, 0);
            this.pnlcbEinmalig.Name = "pnlcbEinmalig";
            this.pnlcbEinmalig.Size = new System.Drawing.Size(90, 29);
            this.pnlcbEinmalig.TabIndex = 3;
            // 
            // cbEinmalig
            // 
            this.cbEinmalig.Location = new System.Drawing.Point(5, 5);
            this.cbEinmalig.Name = "cbEinmalig";
            this.cbEinmalig.Size = new System.Drawing.Size(76, 20);
            this.cbEinmalig.TabIndex = 1;
            this.cbEinmalig.Text = "Einmalig";
            this.cbEinmalig.CheckedChanged += new System.EventHandler(this.cbEinmalig_CheckedChanged);
            // 
            // pnlRMOptional
            // 
            this.pnlRMOptional.Controls.Add(this.cbRMOptionalJN);
            this.pnlRMOptional.Location = new System.Drawing.Point(147, 0);
            this.pnlRMOptional.Name = "pnlRMOptional";
            this.pnlRMOptional.Size = new System.Drawing.Size(127, 29);
            this.pnlRMOptional.TabIndex = 7;
            // 
            // cbRMOptionalJN
            // 
            this.cbRMOptionalJN.Location = new System.Drawing.Point(4, 5);
            this.cbRMOptionalJN.Name = "cbRMOptionalJN";
            this.cbRMOptionalJN.Size = new System.Drawing.Size(122, 20);
            this.cbRMOptionalJN.TabIndex = 1;
            this.cbRMOptionalJN.Text = "Bericht freiwillig";
            this.cbRMOptionalJN.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // pnlEintragFlag
            // 
            this.pnlEintragFlag.Controls.Add(this.cbEintagFlag);
            this.pnlEintragFlag.Location = new System.Drawing.Point(9, 0);
            this.pnlEintragFlag.Name = "pnlEintragFlag";
            this.pnlEintragFlag.Size = new System.Drawing.Size(147, 29);
            this.pnlEintragFlag.TabIndex = 8;
            // 
            // cbEintagFlag
            // 
            this.cbEintagFlag.Location = new System.Drawing.Point(4, 3);
            this.cbEintagFlag.Name = "cbEintagFlag";
            this.cbEintagFlag.Size = new System.Drawing.Size(139, 23);
            this.cbEintagFlag.TabIndex = 2;
            this.cbEintagFlag.Text = "mit PD abzeichnen";
            this.cbEintagFlag.CheckedChanged += new System.EventHandler(this.cbEintagFlag_CheckedChanged);
            // 
            // pnlInfo
            // 
            this.pnlInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInfo.Controls.Add(this.cbChanged);
            this.pnlInfo.Controls.Add(this.lblInfoCreated);
            this.pnlInfo.Controls.Add(this.lblInfoChanged);
            this.pnlInfo.Controls.Add(this.cbCreated);
            this.pnlInfo.Location = new System.Drawing.Point(3, 349);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(675, 31);
            this.pnlInfo.TabIndex = 0;
            this.pnlInfo.Visible = false;
            // 
            // cbChanged
            // 
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.cbChanged.Appearance = appearance6;
            this.cbChanged.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbChanged.Enabled = false;
            this.cbChanged.Location = new System.Drawing.Point(358, 3);
            this.cbChanged.Name = "cbChanged";
            this.cbChanged.Size = new System.Drawing.Size(131, 24);
            this.cbChanged.TabIndex = 1;
            this.cbChanged.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cbChanged_BeforeDropDown);
            this.cbChanged.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // lblInfoCreated
            // 
            this.lblInfoCreated.Location = new System.Drawing.Point(11, 7);
            this.lblInfoCreated.Name = "lblInfoCreated";
            this.lblInfoCreated.Size = new System.Drawing.Size(86, 16);
            this.lblInfoCreated.TabIndex = 0;
            this.lblInfoCreated.Text = "Erstellt von";
            // 
            // lblInfoChanged
            // 
            this.lblInfoChanged.Location = new System.Drawing.Point(265, 7);
            this.lblInfoChanged.Name = "lblInfoChanged";
            this.lblInfoChanged.Size = new System.Drawing.Size(91, 16);
            this.lblInfoChanged.TabIndex = 1;
            this.lblInfoChanged.Text = "Geändert von";
            // 
            // cbCreated
            // 
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            this.cbCreated.Appearance = appearance7;
            this.cbCreated.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbCreated.Enabled = false;
            this.cbCreated.Location = new System.Drawing.Point(115, 3);
            this.cbCreated.Name = "cbCreated";
            this.cbCreated.Size = new System.Drawing.Size(129, 24);
            this.cbCreated.TabIndex = 0;
            this.cbCreated.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cbCreated_BeforeDropDown);
            this.cbCreated.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // pnlGenerell
            // 
            this.pnlGenerell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGenerell.Controls.Add(this.pnlDokument);
            this.pnlGenerell.Controls.Add(this.pnlAnm);
            this.pnlGenerell.Controls.Add(this.pnlBez);
            this.pnlGenerell.Controls.Add(this.pnlW);
            this.pnlGenerell.Location = new System.Drawing.Point(4, 2);
            this.pnlGenerell.Name = "pnlGenerell";
            this.pnlGenerell.Size = new System.Drawing.Size(672, 151);
            this.pnlGenerell.TabIndex = 1;
            // 
            // pnlDokument
            // 
            this.pnlDokument.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDokument.BackColor = System.Drawing.Color.Transparent;
            this.pnlDokument.Controls.Add(this.btnShow);
            this.pnlDokument.Controls.Add(this.lblDokument);
            this.pnlDokument.Controls.Add(this.cbLinkDokument);
            this.pnlDokument.Location = new System.Drawing.Point(2, 121);
            this.pnlDokument.Name = "pnlDokument";
            this.pnlDokument.Size = new System.Drawing.Size(667, 29);
            this.pnlDokument.TabIndex = 25;
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.AutoWorkLayout = false;
            this.btnShow.IsStandardControl = false;
            this.btnShow.Location = new System.Drawing.Point(585, 2);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 25);
            this.btnShow.TabIndex = 22;
            this.btnShow.Text = "anzeigen";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // lblDokument
            // 
            appearance8.TextHAlignAsString = "Left";
            appearance8.TextVAlignAsString = "Middle";
            this.lblDokument.Appearance = appearance8;
            this.lblDokument.Location = new System.Drawing.Point(8, 6);
            this.lblDokument.Name = "lblDokument";
            this.lblDokument.Size = new System.Drawing.Size(96, 16);
            this.lblDokument.TabIndex = 7;
            this.lblDokument.Text = "Richtlinie";
            // 
            // cbLinkDokument
            // 
            this.cbLinkDokument.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLinkDokument.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbLinkDokument.IDLinkDokument = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.cbLinkDokument.Location = new System.Drawing.Point(113, 2);
            this.cbLinkDokument.Name = "cbLinkDokument";
            this.cbLinkDokument.Size = new System.Drawing.Size(466, 22);
            this.cbLinkDokument.TabIndex = 20;
            this.cbLinkDokument.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.cbLinkDokument.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbLinkDokument.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cbLinkDokument_BeforeDropDown);
            this.cbLinkDokument.ValueChanged += new System.EventHandler(this.cbLinkDokument_ValueChanged);
            // 
            // pnlAnm
            // 
            this.pnlAnm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAnm.BackColor = System.Drawing.Color.Transparent;
            this.pnlAnm.Controls.Add(this.ultraLabel3);
            this.pnlAnm.Controls.Add(this.tbAnmerkung);
            this.pnlAnm.Location = new System.Drawing.Point(3, 79);
            this.pnlAnm.Name = "pnlAnm";
            this.pnlAnm.Size = new System.Drawing.Size(665, 41);
            this.pnlAnm.TabIndex = 24;
            // 
            // ultraLabel3
            // 
            appearance9.TextHAlignAsString = "Left";
            appearance9.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance9;
            this.ultraLabel3.Location = new System.Drawing.Point(8, 3);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(96, 16);
            this.ultraLabel3.TabIndex = 6;
            this.ultraLabel3.Text = "Anmerkung";
            // 
            // tbAnmerkung
            // 
            this.tbAnmerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAnmerkung.Location = new System.Drawing.Point(112, 2);
            this.tbAnmerkung.MaxLength = 255;
            this.tbAnmerkung.Multiline = true;
            this.tbAnmerkung.Name = "tbAnmerkung";
            this.tbAnmerkung.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbAnmerkung.Size = new System.Drawing.Size(549, 37);
            this.tbAnmerkung.TabIndex = 3;
            this.tbAnmerkung.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // pnlBez
            // 
            this.pnlBez.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBez.Controls.Add(this.tbText);
            this.pnlBez.Controls.Add(this.cbTermin);
            this.pnlBez.Controls.Add(this.lblBezeichnung);
            this.pnlBez.Location = new System.Drawing.Point(3, 2);
            this.pnlBez.Name = "pnlBez";
            this.pnlBez.Size = new System.Drawing.Size(665, 38);
            this.pnlBez.TabIndex = 22;
            // 
            // tbText
            // 
            this.tbText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbText.Location = new System.Drawing.Point(112, 3);
            this.tbText.MaxLength = 255;
            this.tbText.Multiline = true;
            this.tbText.Name = "tbText";
            this.tbText.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbText.Size = new System.Drawing.Size(549, 33);
            this.tbText.TabIndex = 1;
            this.tbText.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // cbTermin
            // 
            this.cbTermin.AddEmptyEntry = false;
            this.cbTermin.AutoOpenCBO = false;
            this.cbTermin.BerufsstandGruppeJNA = -1;
            this.cbTermin.ExactMatch = false;
            this.cbTermin.Group = "TRM";
            this.cbTermin.ID_PEP = -1;
            this.cbTermin.IgnoreUnterdruecken = true;
            this.cbTermin.Location = new System.Drawing.Point(131, 43);
            this.cbTermin.Name = "cbTermin";
            this.cbTermin.PflichtJN = false;
            this.cbTermin.SelectDistinct = false;
            this.cbTermin.ShowAddButton = true;
            this.cbTermin.Size = new System.Drawing.Size(408, 24);
            this.cbTermin.sys = false;
            this.cbTermin.TabIndex = 0;
            this.cbTermin.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cbTermin_BeforeDropDown);
            this.cbTermin.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // lblBezeichnung
            // 
            appearance10.TextHAlignAsString = "Left";
            this.lblBezeichnung.Appearance = appearance10;
            this.lblBezeichnung.Location = new System.Drawing.Point(7, 3);
            this.lblBezeichnung.Name = "lblBezeichnung";
            this.lblBezeichnung.Size = new System.Drawing.Size(87, 17);
            this.lblBezeichnung.TabIndex = 2;
            this.lblBezeichnung.Text = "Bezeichnung";
            this.lblBezeichnung.MouseEnterElement += new Infragistics.Win.UIElementEventHandler(this.lblBezeichnung_MouseEnterElement);
            // 
            // pnlW
            // 
            this.pnlW.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlW.BackColor = System.Drawing.Color.Transparent;
            this.pnlW.Controls.Add(this.ultraLabel2);
            this.pnlW.Controls.Add(this.tbWarnung);
            this.pnlW.Location = new System.Drawing.Point(3, 41);
            this.pnlW.Name = "pnlW";
            this.pnlW.Size = new System.Drawing.Size(665, 38);
            this.pnlW.TabIndex = 23;
            // 
            // ultraLabel2
            // 
            appearance11.TextHAlignAsString = "Left";
            appearance11.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance11;
            this.ultraLabel2.Location = new System.Drawing.Point(7, 3);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(96, 16);
            this.ultraLabel2.TabIndex = 4;
            this.ultraLabel2.Text = "Hinweis";
            // 
            // tbWarnung
            // 
            this.tbWarnung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWarnung.Location = new System.Drawing.Point(112, 2);
            this.tbWarnung.MaxLength = 255;
            this.tbWarnung.Multiline = true;
            this.tbWarnung.Name = "tbWarnung";
            this.tbWarnung.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbWarnung.Size = new System.Drawing.Size(549, 34);
            this.tbWarnung.TabIndex = 2;
            this.tbWarnung.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.Controls.Add(this.ucZusatzeintrag1);
            this.ultraTabPageControl3.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(678, 430);
            // 
            // ucZusatzeintrag1
            // 
            this.ucZusatzeintrag1.BackColor = System.Drawing.Color.White;
            this.ucZusatzeintrag1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucZusatzeintrag1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucZusatzeintrag1.Location = new System.Drawing.Point(0, 0);
            this.ucZusatzeintrag1.Name = "ucZusatzeintrag1";
            this.ucZusatzeintrag1.Size = new System.Drawing.Size(678, 430);
            this.ucZusatzeintrag1.TabIndex = 1;
            this.ucZusatzeintrag1.ValueChanged += new System.EventHandler(this.ucZusatzeintrag1_ValueChanged);
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.ultraTabSharedControlsPage1);
            this.tabMain.Controls.Add(this.ultraTabPageControl1);
            this.tabMain.Controls.Add(this.ultraTabPageControl3);
            this.tabMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tabMain.Location = new System.Drawing.Point(2, 2);
            this.tabMain.Name = "tabMain";
            this.tabMain.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.tabMain.Size = new System.Drawing.Size(682, 457);
            this.tabMain.TabIndex = 7;
            ultraTab1.Key = "Details";
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "Details";
            ultraTab2.Key = "Zusatzwerte";
            ultraTab2.TabPage = this.ultraTabPageControl3;
            ultraTab2.Text = "Zusatzwerte";
            this.tabMain.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2});
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(678, 430);
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(196, 74);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 15000;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // ucPflegePlanSingleEdit2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabMain);
            this.Name = "ucPflegePlanSingleEdit2";
            this.Size = new System.Drawing.Size(687, 462);
            this.Load += new System.EventHandler(this.ucPflegePlanSingleEdit2_Load);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.pnlUhrzeit.ResumeLayout(false);
            this.pnlUhrzeit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbZeitbereich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osZeit)).EndInit();
            this.pnlM.ResumeLayout(false);
            this.pnlNaechsteEvaluierung.ResumeLayout(false);
            this.pnlNaechsteEvaluierung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbNaechsteEvaluierungBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNaechsteEvaluierung)).EndInit();
            this.pnlLokalisierung.ResumeLayout(false);
            this.pnlLokalisierung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbArea)).EndInit();
            this.pnlBerufsstand.ResumeLayout(false);
            this.pnlBerufsstand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbBerufsstand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDauer)).EndInit();
            this.pnlIntervall.ResumeLayout(false);
            this.pnlIntervall.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.osIntervall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbIntervall)).EndInit();
            this.pnlEinmalig.ResumeLayout(false);
            this.pnlcbLokalisierung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbLokalisierung)).EndInit();
            this.pnlcbParalell.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbParalell)).EndInit();
            this.pnlcbEinmalig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbEinmalig)).EndInit();
            this.pnlRMOptional.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbRMOptionalJN)).EndInit();
            this.pnlEintragFlag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbEintagFlag)).EndInit();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbChanged)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCreated)).EndInit();
            this.pnlGenerell.ResumeLayout(false);
            this.pnlDokument.ResumeLayout(false);
            this.pnlDokument.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbLinkDokument)).EndInit();
            this.pnlAnm.ResumeLayout(false);
            this.pnlAnm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAnmerkung)).EndInit();
            this.pnlBez.ResumeLayout(false);
            this.pnlBez.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTermin)).EndInit();
            this.pnlW.ResumeLayout(false);
            this.pnlW.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbWarnung)).EndInit();
            this.ultraTabPageControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        //----------------------------------------------------------------------------
        /// <summary>
        /// Load
        /// </summary>
        //----------------------------------------------------------------------------
        private void ucPflegePlanSingleEdit2_Load(object sender, System.EventArgs e)
        {
            if (DesignMode || !ENV.AppRunning)
                return;
            cbArea.Group = "LOA";
            cbSide.Group = "LOS";
            cbBerufsstand.Group = "BER";

            // Combo Termin genau über das Textfeld schieben
            cbTermin.Left = tbText.Left;
            cbTermin.Top = tbText.Top;

            cbLinkDokument.RefreshList();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Zeigen oder verstecken der Parameter für einmalig
        /// </summary>
        //----------------------------------------------------------------------------
        private void cbEinmalig_CheckedChanged(object sender, System.EventArgs e)
        {
            if (!cbEinmalig.Checked)
            {
                pnlIntervall.Visible = true;
            }
            else
            {
                pnlIntervall.Visible = false;
            }

            if (_valueChangeEnabled && ASZMValueChanged != null)
                ASZMValueChanged(sender, e);
        }

        private void cbLokalisierung_CheckedChanged(object sender, System.EventArgs e)
        {
            if (cbLokalisierung.Checked)
            {
                pnlLokalisierung.Visible = false;// true;
            }
            else
            {
                pnlLokalisierung.Visible = false;
                cbArea.Clear();
                cbSide.Clear();
            }
            if (_valueChangeEnabled && ASZMValueChanged != null)
                ASZMValueChanged(sender, e);
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
                cbCreated.ReadOnly = value;
                cbChanged.ReadOnly = value;
                tbText.ReadOnly = value;
                tbWarnung.ReadOnly = value;
                tbAnmerkung.ReadOnly = value;
                cbEinmalig.Enabled = !value;
                cbParalell.Enabled = !value;
                tbIntervall.ReadOnly = value;
                osIntervall.Enabled = !value;
                ucWochenTage11.Enabled = !value;
                tbDauer.ReadOnly = value;
                cbBerufsstand.ReadOnly = value;
                cbArea.ReadOnly = value;
                cbSide.ReadOnly = value;
                cbRMOptionalJN.Enabled = !value;
                cbLinkDokument.ReadOnly = value;
                dtpNaechsteEvaluierung.ReadOnly = value;
                tbNaechsteEvaluierungBemerkung.ReadOnly = value;
            }
        }

        #endregion

        private void cbLinkDokument_ValueChanged(object sender, EventArgs e)
        {
            SetShowbuttonEnabled();
            if (_valueChangeEnabled && ASZMValueChanged != null)
                ASZMValueChanged(sender, e);
        }

        private void SetShowbuttonEnabled()
        {
            btnShow.Enabled = cbLinkDokument.IDLinkDokument != Guid.Empty;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            GuiUtil.ShowLinkDokument(cbLinkDokument.IDLinkDokument);
        }
        public void setControlsAktivDisable(bool bOn)
        {
            PMDS.GUI.BaseControls.historie.OnOffControls(this, bOn);
            this.ucWochenTage11.setControlsAktivDisable(bOn);
            this.ucZusatzeintrag1.setControlsAktivDisable(bOn);

            this.btnShow.Visible = true;
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Die höhe des Controls anpassen
        /// </summary>
        //----------------------------------------------------------------------------
        public bool _showPnlAnm = true;

        public void RecalcHeight()
        {
            //pnlGenerell  - Groupbbox kann verschieden viele Einträge haben
            pnlGenerell.Height = pnlBez.Top + pnlBez.Height;

            this.pnlW.Top = pnlGenerell.Height;
            int pnlW = (this.pnlW.Visible ? this.pnlW.Height : 0);
            pnlGenerell.Height += pnlW;

            pnlAnm.Visible = _showPnlAnm;
            this.pnlAnm.Top = pnlGenerell.Height;
            int pnlA = (this.pnlAnm.Visible ? this.pnlAnm.Height : 0);
//            int pnlA = (showAnmerkung ? this.pnlAnm.Height : 0);

            pnlGenerell.Height += pnlA;

            this.pnlDokument.Top = pnlGenerell.Height;
            int pnlDokument = (this.pnlDokument.Visible ? this.pnlDokument.Height : 0);
            pnlGenerell.Height += pnlDokument;

            pnlGenerell.Height += 3;           // Rand unten
            
            // pnlMain - es können verschieden viele Panels angezeigt werden
            pnlM.Top = pnlGenerell.Bottom;
            pnlM.Height = 0;
            foreach (Control c in pnlM.Controls)
            {
                if (c is Panel && _aVisibleControls.IndexOf(c) != -1)
                {
                    c.Top = pnlM.Height;
                    pnlM.Height += c.Height;
                }
            }

            //pnlInfo
            pnlInfo.Top = pnlM.Bottom;
            pnlInfo.Height = (pnlInfo.Visible ? pnlInfo.Height : 0);

            //pnlUhrzeit
            pnlUhrzeit.Top = pnlInfo.Bottom;
            pnlUhrzeit.Height = (pnlUhrzeit.Visible ? pnlUhrzeit.Height : 0);
            // Control Höhe berechnen

            this.Height = pnlUhrzeit.Bottom + tabMain.Tabs["Details"].TabPage.Location.Y + 1;
        }

        ////----------------------------------------------------------------------------
        ///// <summary>
        ///// Die höhe des Controls anpassen
        ///// </summary>
        ////----------------------------------------------------------------------------
        //private void RecalcHeight()
        //{
        //    // pnlMain berechnen die Höhe ergibt sich aus der Summe der enthaltenen einzelpanels
        //    int y = 0;
        //    foreach (Control c in pnlM.Controls)
        //        if (c is Panel && c.Visible)
        //            y += c.Height;
        //    pnlM.Height = y;

        //    int y1 = 0;
        //    foreach (Control c in groupBox5.Controls)
        //        if (c is Panel && c.Visible)
        //            y1 += c.Height;
        //    y1 += pnlBez.Location.Y + 4;
        //    pnlGenerell.Height = y1;
        //    groupBox5.Height = y1;

        //    // Control Höhe berechnen
        //    int y2 = 0;
        //    //foreach (Control c in this.Controls)
        //    //{
        //    //    if (c.Equals(pnlM) || c.Equals(pnlGenerell))                 // m wurde bereits berücksichtigt in der höhenberechnung
        //    //        continue;
        //    //    if (c is Panel && c.Visible)
        //    //        y2 += c.Height;
        //    //}
        //    foreach (Control c in tabMain.Tabs["Details"].TabPage.Controls)
        //    {
        //        if (c.Equals(pnlM) || c.Equals(pnlGenerell))                 // m wurde bereits berücksichtigt in der höhenberechnung
        //            continue;
        //        if (c is Panel && c.Visible)
        //            y2 += c.Height;
        //    }

        //    this.Height = y1 + y2 + y + tabMain.Tabs["Details"].TabPage.Location.Y + 2;
        //}

        /// <summary>
        /// Wenn es um eine Maßnahme ohne Zeitbezung handelt, dann Checkbos Einmalig Maßnahme und Pane Wochentage nicht anzeigen
        /// </summary>
        private void ShowHideControls()
        {
            pnlcbEinmalig.Visible = !_MassnahmeOhneZeitbezug;

            if (_MassnahmeOhneZeitbezug || cbEinmalig.Checked)
                pnlIntervall.Visible = false;
            else if (_EintragGruppe == EintragGruppe.M || _EintragGruppe == EintragGruppe.T)
                pnlIntervall.Visible = true;
            else
                pnlIntervall.Visible = false;
        }

        private void Control_ValueChanged(object sender, EventArgs e)
        {
            if (_valueChangeEnabled)
            {
                Control c = (Control)sender;
                //if (c.Name = "tbText" || c.Name = "cbTermin")
                if (c == tbText || c == cbTermin)
                    _isTextChanged = true;
                if (ASZMValueChanged != null)
                    ASZMValueChanged(sender, e);
            }
        }

        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            if (_valueChangeEnabled)
            {
                if (ASZMValueChanged != null)
                    ASZMValueChanged(sender, e);
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die Auswahl "fixe Zeit" / "zeitbereich" wurde verändert
        /// </summary>
        //----------------------------------------------------------------------------
        private void osZeit_ValueChanged(object sender, EventArgs e)
        {
            lblUhrzeit.Text = IS_FIXEZEIT ? QS2.Desktop.ControlManagment.ControlManagment.getRes("Uhrzeit") : QS2.Desktop.ControlManagment.ControlManagment.getRes("Zeitbereich");
            cbZeitbereich.Visible = !IS_FIXEZEIT;
            dtpTime.Visible = IS_FIXEZEIT;

        }

        private void ucZusatzeintrag1_ValueChanged(object sender, EventArgs e)
        {
            //if (_valueChangeEnabled)
            //{
            //    if (ASZMValueChanged != null)
            //        ASZMValueChanged(sender, e);
            //}
        }

        private void cbLinkDokument_BeforeDropDown(object sender, CancelEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn)
                e.Cancel = true;
        }

        private void cbTermin_BeforeDropDown(object sender, CancelEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn)
                e.Cancel = true;
        }

        private void cbCreated_BeforeDropDown(object sender, CancelEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn)
                e.Cancel = true;
        }

        private void cbChanged_BeforeDropDown(object sender, CancelEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn)
                e.Cancel = true;
        }

        private void cbArea_BeforeDropDown(object sender, CancelEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn)
                e.Cancel = true;
        }

        private void cbSide_BeforeDropDown(object sender, CancelEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn)
                e.Cancel = true;
        }

        private void cbBerufsstand_BeforeDropDown(object sender, CancelEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn)
                e.Cancel = true;
        }

        private void dtpNaechsteEvaluierung_BeforeDropDown(object sender, CancelEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn)
                e.Cancel = true;
        }

        private void cbZeitbereich_BeforeDropDown(object sender, CancelEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn)
                e.Cancel = true;
        }

        private void cbEintagFlag_CheckedChanged(object sender, EventArgs e)
        {
            if (_valueChangeEnabled)
            {
                this._IDEintrag = 3;
                this.userHasEintragFlagChanged = true;
                if (ASZMValueChanged != null)
                    ASZMValueChanged(sender, e);
            }

        }

        private void lblBezeichnung_MouseEnterElement(object sender, Infragistics.Win.UIElementEventArgs e)
        {
            try
            {
                string txtOrig = Eintrag.GetText(_row.IDEintrag).Trim();
                if (this.tbText.Text.Trim() != "" && !tbText.Text.Trim().ToLower().Equals(txtOrig.Trim().ToLower()))
                {
                    Infragistics.Win.UltraWinToolTip.UltraToolTipInfo tipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo(txtOrig, Infragistics.Win.ToolTipImage.Default, "", Infragistics.Win.DefaultableBoolean.True);
                    this.ultraToolTipManager1.SetUltraToolTip(this.lblBezeichnung, tipInfo);
                    this.ultraToolTipManager1.ShowToolTip(this.lblBezeichnung);
                }
                else
                {
                    this.ultraToolTipManager1.SetUltraToolTip(this.lblBezeichnung, null);
                    this.ultraToolTipManager1.HideToolTip();
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        public void btnVerordnungenClick()
        {
            try
            {
                if (this.IDPflegeplan != null)
                {
                    PMDS.GUI.Verordnungen.frmVOErfassen frmVOErfassen1 = new Verordnungen.frmVOErfassen();
                    frmVOErfassen1.initControl(PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenPlanung2, true, false, null);
                    frmVOErfassen1.ucVOErfassen1.search2(ENV.IDAUFENTHALT, this.IDPflegeplan, null, null);
                    frmVOErfassen1.ShowDialog(this);
                }
                else
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Planungseintrag nicht gespeichert oder nicht vorhanden!" + "\r\n" + 
                                                                                "Bitte vorher speichern!", "", MessageBoxButtons.OK);
                }
            
            }
            catch (Exception ex)
            {
                throw new Exception("btnVerordnungenClick: " + ex.ToString());
            }
        }

    }

}
