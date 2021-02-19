//----------------------------------------------------------------------------
/// <summary>
/// 20.8.2008   RBU: Umbau des mda Codes
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinMaskedEdit;
using PMDS.GUI.BaseControls;
using PMDS.Global;
using PMDS.Klient;
using PMDS.BusinessLogic;
using PMDS.GUI.Klient;




namespace PMDS.GUI
{


    public partial class frmUnterbringung : QS2.Desktop.ControlManagment.baseForm 
    {

        Unterbringungsaktion _aktion;
        KlientDetails _klient;
        private dsUnterbringung.UnterbringungRow _row;
        private bool _pruefen = false;
        private bool _CanClose = true;
        public bool OKClicked = false;

        public ucRegelungen mainWindow = null;
        public dsUnterbringung.UnterbringungRow rnew = null;
        public dsUnterbringung.UnterbringungRow r = null;

        public PMDS.Global.eTypeUIUnterbringung TypeUIUnterbringung;






        public frmUnterbringung(Unterbringungsaktion aktion, KlientDetails klient)
        {
            InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            _aktion = aktion;
            _klient = klient;
            Init();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsUnterbringung.UnterbringungRow UNTERBRINGUNG_ROW
        {
            get
            {
                return _row;
            }

            set
            {
                _row = value;
                UpdateGUI();
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Form Felder Initialisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void Init()
        {
            InitHeaderText(_aktion);

            Beginn = DateTime.Now;
            EinrichtungsleiterTitel   = _klient.KLINIK.KlinikByAufenthalt.Klinik[0]["EinrichtungsleiterTitel"].ToString();
            EinrichtungsleiterVorname = _klient.KLINIK.KlinikByAufenthalt.Klinik[0]["EinrichtungsleiterVorname"].ToString();
            Einrichtungsleiter        = _klient.KLINIK.KlinikByAufenthalt.Klinik[0]["Einrichtungsleiter"].ToString();

            _pruefen = true;

            SetEnabled(gBEndeGesendetAn, _aktion == Unterbringungsaktion.Ende);
            SetEnabled(gBEndeAngeordnetVon, _aktion == Unterbringungsaktion.Ende);

            if (_aktion == Unterbringungsaktion.Verlaengerung)
            {
                SetEnabled(gBBeginn, false);
                SetEnabled(gBZustimmung, false);
                SetEnabled(gBGrund, false);
                SetEnabled(gbAufhebung, false);
                SetEnabled(gBArt, false);
                SetEnabled(gBGesendetAn, true);
            }
            else if (_aktion == Unterbringungsaktion.Ende)
            {
                SetEnabled(gBBeginn, false);
                SetEnabled(gBDauer, false);
                SetEnabled(gBZustimmung, false);
                SetEnabled(gBGrund, false);
                SetEnabled(gBArt, false);
                SetEnabled(gBAngeordnetVon, false);
                SetEnabled(gBGesendetAn, false);

            }
            else if (_aktion == Unterbringungsaktion.Beginn)
            {
                gbAufhebung.Visible = false;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Header Text inisialisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void InitHeaderText(Unterbringungsaktion aktion)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Dokumentation/ Meldung über die "));
            switch (aktion)
            {
                case Unterbringungsaktion.Beginn:
                    sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Vornahme einer Freiheitsbeschränkung/ -einschränkung"));
                    break;
                case Unterbringungsaktion.Ende:
                    sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Aufhebung einer Freiheitsbeschränkung"));
                    break;
                case Unterbringungsaktion.Verlaengerung:
                    sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Verlängerung einer Freiheitsbeschränkung gem §19"));
                    break;
            }

            sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes(" gemäß HeimAufG"));
            sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("\n für ") + _klient.FullName);

            lblHeader.Text = sb.ToString();
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// lädt die Daten aus einem Businessobject und aktualisiert die GUI.
        /// </summary>
        //----------------------------------------------------------------------------
        private void UpdateGUI()
        {
            if (_row == null)
                return;

            _pruefen = false;

            gBEndeGesendetAn.Visible = _aktion == Unterbringungsaktion.Ende || (_aktion == Unterbringungsaktion.Historie && !_row.IsAufgehobenAmNull());
            gBEndeAngeordnetVon.Visible = _aktion == Unterbringungsaktion.Ende || (_aktion == Unterbringungsaktion.Historie && !_row.IsAufgehobenAmNull());
            if (!_row.IsBeginnNull()) Beginn = _row.Beginn;
            if (!_row.IsAufgehobenAmNull()) Ende = _row.AufgehobenAm; else dtpAufgehobenAm.Value = null;
            if (!_row.IsVoraussichtlicheDauerNull()) VoraussichtlicheDauer2010 = _row.VoraussichtlicheDauer;
            if (!_row.IsVoraussichtlicheDauerNull()) VoraussichtlicheDauer = _row.VoraussichtlicheDauer;
            if (!_row.IsZeitraumNull()) DauerZeitraum = _row.Zeitraum.Trim();
            if (!_row.IsKlientZustimmungJNNull()) KlientZustimmungJN = _row.KlientZustimmungJN;
            if (!_row.IsPsychischekrankheitJNNull()) PsychischeKrankheitJN = _row.PsychischekrankheitJN;
            if (!_row.IsGeistigeBehinderungJNNull()) GeistigeBehinderungJN = _row.GeistigeBehinderungJN;
            if (!_row.IsMedDiagnICDNull()) MedDiagnoseICD = _row.MedDiagnICD.Trim();
            if (!_row.IsMedizinischeDiagnoseNull()) MedDiagnose = _row.MedizinischeDiagnose.Trim();
            if (!_row.IsErheblicheSelbstgefaehrdungJNNull()) SelbstgefaehrdungJN = _row.ErheblicheSelbstgefaehrdungJN;
            if (!_row.IsErheblicheFremdgefaehrdungJNNull()) FremdgefaehrdungJN = _row.ErheblicheFremdgefaehrdungJN;
            if (!_row.IsGrundNull()) Grund = _row.Grund.Trim();
            if (!_row.IsEingriffUnerlaesslichJNNull()) EingriffUnerlaesslichJN = _row.EingriffUnerlaesslichJN;
            if (!_row.IsEingriffUnerlaesslichBeschreibungNull()) AbwehrBeschreibung = _row.EingriffUnerlaesslichBeschreibung.Trim();
            if (_aktion == Unterbringungsaktion.Verlaengerung)
            {
                if (!_row.IsAufgehobeneMassnahmeInfoNull())
                    Berufsgruppe = _row.AufgehobeneMassnahmeInfo;
                else if (!_row.IsBerufsgruppeNull())
                    Berufsgruppe = _row.Berufsgruppe;
            }
            else
            {
                if (!_row.IsBerufsgruppeNull()) Berufsgruppe = _row.Berufsgruppe;
            }

            EinrichtungsleiterTitel = _row.EinrichtungsleiterTitel;
            if (!_row.IsEinrichtungsleiterNull()) Einrichtungsleiter = _row.Einrichtungsleiter;
            EinrichtungsleiterVorname = _row.EinrichtungsleiterVorname;

            AngeordnetVonTitel = _row.AngeordnetVonTitel.Trim();
            AngeordnetVonVorname = _row.AngeordnetVonVorname.Trim();
            if (!_row.IsAngeordnetVonNull()) AngeordnetVon = _row.AngeordnetVon.Trim();
            if (!_row.IsElektronischesUeberwachungJNNull()) ElektronischeUeberwachungJN = _row.ElektronischesUeberwachungJN;
            if (!_row.IsZurueckhaltensandrohungJNNull()) ZurueckhaltensandrohungJN = _row.ZurueckhaltensandrohungJN;
            if (!_row.IsVerschlosseneTuerJNNull()) VerschlosseneTuerJN = _row.VerschlosseneTuerJN;
            if (!_row.IsDrehknopfJNNull()) DrehknopfJN = _row.DrehknopfJN;
            if (!_row.IsCodierungJNNull()) CodierungJN = _row.CodierungJN;
            if (!_row.IsLabyrinthJNNull()) LabyrinthJN = _row.LabyrinthJN;
            if (!_row.IsBaulicheMassnahmenNull()) BaulicheMassnahme = _row.BaulicheMassnahmen.Trim();
            if (!_row.IsHindernRollstuhlGurtenJNNull()) HindernRollstuhlGurtenJN = _row.HindernRollstuhlGurtenJN;
            if (!_row.IsHindernRollstuhTischJNNull()) HindernRollstuhlTischJN = _row.HindernRollstuhTischJN;
            if (!_row.IsHindernRollstuhTherapietischJNNull()) HindernRollstuhlTherapietischJN = _row.HindernRollstuhTherapietischJN;
            if (!_row.IsHindernRollstuhlNull()) HindernRollstuhlBeschr = _row.HindernRollstuhl.Trim();
            if (!_row.IsHindernSitzgelGurtenJNNull()) HindernSitzgelgGurtenJN = _row.HindernSitzgelGurtenJN;
            if (!_row.IsHindernSitzgelTischJNNull()) HindernSitzgelgTischJN = _row.HindernSitzgelTischJN;
            if (!_row.IsHindernSitzgelTherapietischJNNull()) HindernSitzgelgTherapietischJN = _row.HindernSitzgelTherapietischJN;
            HindernSitzgelgSitzhoseJN = _row.HindernSitzgelSitzhoseJN;
            if (!_row.IsHindernSitzgelegenheitNull()) HindernSitzgelgBeschr = _row.HindernSitzgelegenheit.Trim();
            if (!_row.IsHindernVerlassenBettSeitenteilenJNNull()) HindernBettVerlSeitenteilenJN = _row.HindernVerlassenBettSeitenteilenJN;
            if (!_row.IsHindernVerlassenBettGurtenJNNull()) HindernBettVerlGurtenJN = _row.HindernVerlassenBettGurtenJN;
            if (!_row.IsHindernBettVerlassenNull()) HindernBettVerlBeschr = _row.HindernBettVerlassen.Trim();
            if (!_row.IsMedikFreihBeschraenkungJNNull()) MedikFreihBeschraenkungJN = _row.MedikFreihBeschraenkungJN;
            if (!_row.IsMedikBezeichnungNull()) MedikBezDosierung = _row.MedikBezeichnung.Trim();
            if (!_row.IsGesendetAnBewohnervertreterJNNull()) GesendetAnBewohnervertrJN = _row.GesendetAnBewohnervertreterJN;
            if (!_row.IsGesendetAnGesetzVertreterJNNull()) GesendetAnGestzVertrJN = _row.GesendetAnGesetzVertreterJN;
            if (!_row.IsGesendetAnSelbstGewVertreterJNNull()) GesendetAnSelbstgewVertrJN = _row.GesendetAnSelbstGewVertreterJN;
            if (!_row.IsGesendetAnVertrauenspersonJNNull()) GesendetAnVertrauenspersJN = _row.GesendetAnVertrauenspersonJN;
            if (!_row.IsENDEGesendetAnBewohnervertreterJNNull()) EndeGesendetAnBewohnervertrJN = _row.ENDEGesendetAnBewohnervertreterJN;
            if (!_row.IsENDEGesendetAnGesetzVertreterJNNull()) EndeGesendetAnGestzVertrJN = _row.ENDEGesendetAnGesetzVertreterJN;
            if (!_row.IsENDEGesendetAnSelbstGewVertreterJNNull()) EndeGesendetAnSelbstgewVertrJN = _row.ENDEGesendetAnSelbstGewVertreterJN;
            if (!_row.IsENDEGesendetAnVertrauenspersonJNNull()) EndeGesendetAnVertrauenspersJN = _row.ENDEGesendetAnVertrauenspersonJN;
            EndeAngeordnetVonTitel = _row.AufgehobenVonTitel;
            EndeAngeordnetVonVorname = _row.AufgehobenVonVorname;
            if (!_row.IsENDEAngeordnetVonNull()) EndeAngeordnetVon = _row.ENDEAngeordnetVon.Trim();
            if (!_row.IsENDEBerufsgruppeNull()) EndeBerufsgruppe = _row.ENDEBerufsgruppe;
            if (!_row.IsVoraussichtlichesEndeNull()) dtpVoraussichtlichesEnde.Value = _row.VoraussichtlichesEnde; else dtpVoraussichtlichesEnde.Value = DBNull.Value;

            //Neue Felder können nicht NULL sein, daher keine Prüfung
            AerztlDokumentArt = _row.AerztlDokumentArt;
            AerztlDokumentArztTitel = _row.AerztlDokumentArztTitel.Trim();
            AerztlDokumentArztVorname = _row.AerztlDokumentArztVorname.Trim();
            AerztlDokumentArzt = _row.AerztlDokumentArzt.Trim();

            if (!_row.IsAerztlDokumentDatumNull()) AerztlDokumentDatum = _row.AerztlDokumentDatum;
            RollstuhlBremsenJN = _row.HindernRollstuhlBremsenJN;
            RollstuhlSitzhoseJN = _row.HindernRollstuhlSitzhoseJN;
            BettHandmanschettenJN = _row.HindernVerlassenBettHandmanschettenJN;
            TatsaechlicheEndeGrund = _row.TatsaechlicheEndeGrund;    

            _pruefen = true;

            if (_aktion == Unterbringungsaktion.Historie)
            {
                //Keine Veränderung zulassen
                SetEnabled(this, false);

                if (_row.RowState != DataRowState.Added)
                    btnPreview.Visible = true;

                //switch (_row.Aktion)
                //{
                //    case "Beginn":
                //        InitHeaderText(Unterbringungsaktion.Beginn);
                //        break;
                //    case "Ende":
                //        InitHeaderText(Unterbringungsaktion.Ende);
                //        break;
                //    case "Verlaengerung":
                //        InitHeaderText(Unterbringungsaktion.Verlaengerung);
                //        break;
                //}
            }

        }

        private void SetEnabled(Control c, bool enabled)
        {
            foreach (Control con in c.Controls)
            {
                if (con.Controls.Count > 0)
                {
                    SetEnabled(con, enabled);
                }

                if (con is UltraDateTimeEditor || con is UltraTextEditor || con is UltraMaskedEdit || con is UltraCheckEditor ||
                         con is AuswahlGruppeCombo || (con is UltraComboEditor && con.Name != "cmbErstelltAm") || con is UltraOptionSet)
                {
                    if (con is UltraTextEditor)
                        ((UltraTextEditor)con).ReadOnly = !enabled;
                    else if (con is UltraDateTimeEditor)
                        ((UltraDateTimeEditor)con).ReadOnly = !enabled;
                    else if (con is UltraMaskedEdit)
                        ((UltraMaskedEdit)con).ReadOnly = !enabled;
                    else if (con is AuswahlGruppeCombo)
                    {
                        ((AuswahlGruppeCombo)con).ReadOnly = !enabled;
                        ((AuswahlGruppeCombo)con).ShowAddButton = enabled;
                    }
                    else if (con is UltraComboEditor)
                        ((UltraComboEditor)con).ReadOnly = !enabled;
                    else
                        con.Enabled = enabled;
                }
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktualisiert die Gui Daten über das Businessobject in die Datenbank.
        /// </summary>
        //----------------------------------------------------------------------------
        private void UpdateData()
        {
            if (_row == null)
                return;

            if (_aktion == Unterbringungsaktion.Historie)
                return;

            if (_aktion == Unterbringungsaktion.Ende)
                _row.AufgehobenAm = Ende;

            _row.VoraussichtlicheDauer = VoraussichtlicheDauer2010;
            _row.Zeitraum = DauerZeitraum;
            _row.KlientZustimmungJN = KlientZustimmungJN;
            _row.PsychischekrankheitJN = PsychischeKrankheitJN;
            _row.GeistigeBehinderungJN = GeistigeBehinderungJN;
            _row.MedDiagnICD = MedDiagnoseICD;
            _row.MedizinischeDiagnose = MedDiagnose;
            _row.ErheblicheSelbstgefaehrdungJN = SelbstgefaehrdungJN;
            _row.ErheblicheFremdgefaehrdungJN = FremdgefaehrdungJN;
            _row.Grund = Grund;
            _row.EingriffUnerlaesslichJN = EingriffUnerlaesslichJN;
            _row.EingriffUnerlaesslichBeschreibung = AbwehrBeschreibung;
            _row.Berufsgruppe = Berufsgruppe;
            _row.AngeordnetVonTitel = AngeordnetVonTitel;
            _row.AngeordnetVonVorname = AngeordnetVonVorname;
            _row.AngeordnetVon = AngeordnetVon;
            _row.ElektronischesUeberwachungJN = ElektronischeUeberwachungJN;
            _row.ZurueckhaltensandrohungJN = ZurueckhaltensandrohungJN;
            _row.VerschlosseneTuerJN = VerschlosseneTuerJN;
            _row.DrehknopfJN = DrehknopfJN;
            _row.CodierungJN = CodierungJN;
            _row.LabyrinthJN = LabyrinthJN;
            _row.BaulicheMassnahmen = BaulicheMassnahme;
            _row.HindernRollstuhlGurtenJN = HindernRollstuhlGurtenJN;
            _row.HindernRollstuhTischJN = HindernRollstuhlTischJN;
            _row.HindernRollstuhTherapietischJN = HindernRollstuhlTherapietischJN;
            _row.HindernRollstuhl = HindernRollstuhlBeschr;
            _row.HindernSitzgelGurtenJN = HindernSitzgelgGurtenJN;
            _row.HindernSitzgelTischJN = HindernSitzgelgTischJN;
            _row.HindernSitzgelTherapietischJN = HindernSitzgelgTherapietischJN;
            _row.HindernSitzgelSitzhoseJN = HindernSitzgelgSitzhoseJN;
            _row.HindernSitzgelegenheit = HindernSitzgelgBeschr;
            _row.HindernVerlassenBettSeitenteilenJN = HindernBettVerlSeitenteilenJN;
            _row.HindernVerlassenBettGurtenJN = HindernBettVerlGurtenJN;
            _row.HindernBettVerlassen = HindernBettVerlBeschr;
            _row.MedikFreihBeschraenkungJN = MedikFreihBeschraenkungJN;
            _row.MedikBezeichnung = MedikBezDosierung;
            _row.GesendetAnBewohnervertreterJN = GesendetAnBewohnervertrJN;
            _row.GesendetAnGesetzVertreterJN = GesendetAnGestzVertrJN;
            _row.GesendetAnSelbstGewVertreterJN = GesendetAnSelbstgewVertrJN;
            _row.GesendetAnVertrauenspersonJN = GesendetAnVertrauenspersJN;
            _row.ENDEGesendetAnBewohnervertreterJN = EndeGesendetAnBewohnervertrJN;
            _row.ENDEGesendetAnGesetzVertreterJN = EndeGesendetAnGestzVertrJN;
            _row.ENDEGesendetAnSelbstGewVertreterJN = EndeGesendetAnSelbstgewVertrJN;
            _row.ENDEGesendetAnVertrauenspersonJN = EndeGesendetAnVertrauenspersJN;
            _row.ENDEBerufsgruppe = EndeBerufsgruppe;
            _row.AufgehobenVonTitel = EndeAngeordnetVonTitel;
            _row.AufgehobenVonVorname = EndeAngeordnetVonVorname;
            _row.ENDEAngeordnetVon = EndeAngeordnetVon;

            if (dtpVoraussichtlichesEnde.Value == DBNull.Value || dtpVoraussichtlichesEnde.Value == null || dtpVoraussichtlichesEnde.DateTime .Year == 1753)
                _row.SetVoraussichtlichesEndeNull();
            else
                _row.VoraussichtlichesEnde = dtpVoraussichtlichesEnde.DateTime;

            // Felder ab 2010
            _row.AerztlDokumentArt =AerztlDokumentArt ;
            _row.AerztlDokumentArztTitel = AerztlDokumentArztTitel;
            _row.AerztlDokumentArztVorname = AerztlDokumentArztVorname;
            _row.AerztlDokumentArzt = AerztlDokumentArzt;

            if (dtpAerztlDokumentDatum.Value == DBNull.Value || dtpAerztlDokumentDatum.Value == null || dtpAerztlDokumentDatum.DateTime.Year == 1753)
                _row.SetAerztlDokumentDatumNull();
            else
                _row.AerztlDokumentDatum = dtpAerztlDokumentDatum.DateTime;

            _row.HindernRollstuhlBremsenJN= RollstuhlBremsenJN;
            _row.HindernRollstuhlSitzhoseJN =RollstuhlSitzhoseJN ;
            _row.HindernVerlassenBettHandmanschettenJN= BettHandmanschettenJN;
            _row.TatsaechlicheEndeGrund= TatsaechlicheEndeGrund;
            

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Rechtlichepruefung.
        /// </summary>
        //----------------------------------------------------------------------------
        private bool ValidateRechtlichePruefung()
        {
            bool bError = false;
            bool bInfo = true;
            string strError;

            //GuiUtil.ValidateField(dtpBeginn, (Beginn != DateTime.MinValue),
            //        ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            // wenn Medikamente (unabhängig von Dauer) -> Arzt, Medikament und Dosierung erforderlich
            if (MedikFreihBeschraenkungJN)
            {
                strError = QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikamentöse Freiheitsbeschränkung/-einschränkung kann nur ein Arzt anordnen. Bitte Arzt auswählen und eintragen und Dosierung überprüfen.");
                GuiUtil.ValidateField(cbMediFreihbeschrJN, (Berufsgruppe == (int)Angeordnetvon.Arzt && tbMediBezDosierung.Text != "" ? true : false),
                        strError, ref bError, bInfo, errorProvider1);
            }

            //Maßnahmendauer
            strError = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte eine Dauer auswählen.");
            if (VoraussichtlicheDauer2010 == 0)
                GuiUtil.ValidateField(this.opVoraussichtlicheDauer2010, false,
                        strError, ref bError, bInfo, errorProvider1);

            //anordnende Person darf nicht leer sein
            strError = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte anordnende Person angeben.");
            GuiUtil.ValidateField(tbAngeorVon, AngeordnetVon != "" ? true:false,
                   strError, ref bError, bInfo, errorProvider1);


            //Freiheitsbeschränkung!
            if (!cbKlientZustimmumgJN.Checked)
            {
                // wenn > 48 Stunden -> ärztliches Dokument, Name des Arztes, der das Dokument ausgestellt hat und Datum
                if (VoraussichtlicheDauer2010 == (int)Voraussichtlichedauer.Von3TBis7T || 
                    VoraussichtlicheDauer2010 == (int)Voraussichtlichedauer.Von8TBis6M ||
                    VoraussichtlicheDauer2010 == (int)Voraussichtlichedauer.Ueber6M)
                {
                    strError = QS2.Desktop.ControlManagment.ControlManagment.getRes("Es muss ein ärztliches Dokument angegeben werden (Art, Arzt und Datum prüfen).");
                    GuiUtil.ValidateField(gbAerztlDokument, (tbAerztlDokumentArzt.Text != "" ? true : false) && dtpAerztlDokumentDatum.DateTime != null && dtpAerztlDokumentDatum.DateTime.Year > 1900,
                        strError, ref bError, bInfo, errorProvider1);
                }
            }

            strError = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte psychische Krankheit oder geistige Behinderung oder beide auswählen.");
            GuiUtil.ValidateField(cbPsyKrankheitJN, (PsychischeKrankheitJN || GeistigeBehinderungJN),
                    strError, ref bError, bInfo, errorProvider1);
            GuiUtil.ValidateField(cbGeistBehinderungJN, (PsychischeKrankheitJN || GeistigeBehinderungJN),
                    strError, ref bError, bInfo, errorProvider1);
                
            strError = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Selbstgefährdung oder Fremdengefährdung oder beide auswählen.");
            GuiUtil.ValidateField(cbErnErhSelbstgefaehrdungJN, (SelbstgefaehrdungJN || FremdgefaehrdungJN),
                    strError, ref bError, bInfo, errorProvider1);
            GuiUtil.ValidateField(cbErnErhFremdgefaehrdungJN, (SelbstgefaehrdungJN || FremdgefaehrdungJN),
                    strError, ref bError, bInfo, errorProvider1);

            strError = QS2.Desktop.ControlManagment.ControlManagment.getRes("Muss ausgewählt werden.");
            GuiUtil.ValidateField(cbEingriffUnerlaesslich, EingriffUnerlaesslichJN,
                    strError, ref bError, bInfo, errorProvider1);

                //if (!this.cbPsyKrankheitJN.Checked && !this.cbGeistBehinderungJN.Checked)
                //{
                //    bool 
                //    strError = "Bitte psychische Krankheit und/oder geistige Behinderung auswählen!";
                //    GuiUtil.ValidateField(cbEingriffUnerlaesslich, EingriffUnerlaesslichJN,
                //                            strError, ref bError, bInfo, errorProvider1);
                //}
                


            if (_aktion == Unterbringungsaktion.Ende)
            {
                GuiUtil.ValidateField(dtpAufgehobenAm, Ende != DateTime.MinValue, ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
                strError = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte auswählen.");
                GuiUtil.ValidateField(gBEndeGesendetAn, (cbEndeBewohnervertrJN.Checked || cbEndeGestzVertrJN.Checked || cbEndeSelbstgewVertrJN.Checked || cbEndeVertrauenspersJN.Checked), strError, ref bError, bInfo, errorProvider1);
                GuiUtil.ValidateField(tbEndeAngeorVon, tbEndeAngeorVon.Text.Trim() != "", ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
                if (dtpBeginn.DateTime >= new DateTime(2010,7,1)) GuiUtil.ValidateField(opTatsaechlicheEndeGrund, (int)opTatsaechlicheEndeGrund.CheckedIndex >= 0 ?true:false, strError, ref bError, bInfo, errorProvider1);
      
            }

            strError = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Empfänger auswählen.");
            GuiUtil.ValidateField(gBGesendetAn, (GesendetAnBewohnervertrJN || GesendetAnGestzVertrJN || GesendetAnSelbstgewVertrJN || GesendetAnVertrauenspersJN),
                    strError, ref bError, bInfo, errorProvider1);

            strError = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Berufsgruppe auswählen.");
            GuiUtil.ValidateField(this.opBerufsgruppe, (this.opBerufsgruppe.CheckedIndex >= 0 ? true : false),
                    strError, ref bError, bInfo, errorProvider1);

            strError = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Art der Freiheitsbeschränkung/- einschränkung auswählen");
            GuiUtil.ValidateField(gBArt, (ElektronischeUeberwachungJN || ZurueckhaltensandrohungJN || 
                this.VerschlosseneTuerJN || this.CodierungJN || this.DrehknopfJN ||
                HindernRollstuhlGurtenJN || HindernRollstuhlTischJN || HindernRollstuhlTherapietischJN || this.RollstuhlBremsenJN || this.RollstuhlSitzhoseJN ||
                HindernSitzgelgGurtenJN || HindernSitzgelgTischJN || HindernSitzgelgTherapietischJN || HindernSitzgelgSitzhoseJN ||
                HindernBettVerlSeitenteilenJN || HindernBettVerlGurtenJN || this.BettHandmanschettenJN ||
                MedikFreihBeschraenkungJN),
                    strError, ref bError, bInfo, errorProvider1);


            if (_aktion == Unterbringungsaktion.Verlaengerung && _row != null &&
                !_row.IsVoraussichtlicheDauerNull() && !_row.IsAufgehobeneMassnahmeInfoNull()
               )
            {
                strError = QS2.Desktop.ControlManagment.ControlManagment.getRes("Für eine Verlängerung, Vorraussichtliche Dauer oder oder Berufsgruppe ändern.");
                GuiUtil.ValidateField(opVoraussichtlicheDauer, (VoraussichtlicheDauer != _row.VoraussichtlicheDauer || Berufsgruppe != _row.AufgehobeneMassnahmeInfo),
                        strError, ref bError, bInfo, errorProvider1);

                GuiUtil.ValidateField(opBerufsgruppe, (VoraussichtlicheDauer != _row.VoraussichtlicheDauer || Berufsgruppe != _row.AufgehobeneMassnahmeInfo),
                        strError, ref bError, bInfo, errorProvider1);
            }

            return !bError;
        }

        #region Properties
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime Beginn
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
        public int VoraussichtlicheDauer
        {
            get { return Convert.ToInt32(opVoraussichtlicheDauer.Value); }
            set { opVoraussichtlicheDauer.Value = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DauerZeitraum
        {
            get { return tbDauerZeitraum.Text.Trim(); }
            set { tbDauerZeitraum.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool KlientZustimmungJN
        {
            get { return cbKlientZustimmumgJN.Checked; }
            set { cbKlientZustimmumgJN.Checked = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool PsychischeKrankheitJN
        {
            get { return cbPsyKrankheitJN.Checked; }
            set { cbPsyKrankheitJN.Checked = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool GeistigeBehinderungJN
        {
            get { return cbGeistBehinderungJN.Checked; }
            set { cbGeistBehinderungJN.Checked = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MedDiagnoseICD
        {
            get { return tbMedDiagICD.Text.Trim(); }
            set { tbMedDiagICD.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MedDiagnose
        {
            get { return tbMedDiag.Text.Trim(); }
            set { tbMedDiag.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SelbstgefaehrdungJN
        {
            get { return cbErnErhSelbstgefaehrdungJN.Checked; }
            set { cbErnErhSelbstgefaehrdungJN.Checked = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool FremdgefaehrdungJN
        {
            get { return cbErnErhFremdgefaehrdungJN.Checked; }
            set { cbErnErhFremdgefaehrdungJN.Checked = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Grund
        {
            get { return tbGefaehrdung.Text.Trim(); }
            set { tbGefaehrdung.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool EingriffUnerlaesslichJN
        {
            get { return cbEingriffUnerlaesslich.Checked; }
            set { cbEingriffUnerlaesslich.Checked = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string AbwehrBeschreibung
        {
            get { return tbAbwehrBeschr.Text.Trim(); }
            set { tbAbwehrBeschr.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Berufsgruppe
        {
            get { return Convert.ToInt32(opBerufsgruppe.Value); }
            set { opBerufsgruppe.Value = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string AngeordnetVonTitel
        {
            get { return tbAngeorVonTitel.Text.Trim(); }
            set { tbAngeorVonTitel.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string AngeordnetVonVorname
        {
            get { return tbAngeorVonVorname.Text.Trim(); }
            set { tbAngeorVonVorname.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string AngeordnetVon
        {
            get { return tbAngeorVon.Text.Trim(); }
            set { tbAngeorVon.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string EinrichtungsleiterTitel
        {
            get { return lblEinrichtugLeitTitel.Text.Trim(); }
            set { lblEinrichtugLeitTitel.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string EinrichtungsleiterVorname
        {
            get { return lblEinrichtugLeitVorname.Text.Trim(); }
            set { lblEinrichtugLeitVorname.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Einrichtungsleiter
        {
            get { return lblEinrichtugLeit.Text.Trim(); }
            set { lblEinrichtugLeit.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime Ende
        {
            get
            {
                if (dtpAufgehobenAm.Value == null)
                    return DateTime.MinValue;
                else
                    return dtpAufgehobenAm.DateTime;
            }

            set
            {
                dtpAufgehobenAm.Value = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ElektronischeUeberwachungJN
        {
            get { return cbElektUeberwJN.Checked; }
            set { cbElektUeberwJN.Checked = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ZurueckhaltensandrohungJN
        {
            get { return cbZurhaltAndrohungAnordnungJN.Checked; }
            set { cbZurhaltAndrohungAnordnungJN.Checked = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool VerschlosseneTuerJN
        {
            get { return cbVerschlosseneTuerJN.Checked; }
            set { cbVerschlosseneTuerJN.Checked = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DrehknopfJN
        {
            get { return cbDrehknopfJN.Checked; }
            set { cbDrehknopfJN.Checked = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CodierungJN
        {
            get { return cbCodierungJN.Checked; }
            set { cbCodierungJN.Checked = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool LabyrinthJN
        {
            get { return cbLabyrithJN.Checked; }
            set { cbLabyrithJN.Checked = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string BaulicheMassnahme
        {
            get { return tbBaulMassnBeschreibung.Text.Trim(); }
            set { tbBaulMassnBeschreibung.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HindernRollstuhlGurtenJN
        {
            get { return cbRollstuhlGurtenJN.Checked; }
            set { cbRollstuhlGurtenJN.Checked = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HindernRollstuhlTischJN
        {
            get { return cbRollstuhlTischJN.Checked; }
            set { cbRollstuhlTischJN.Checked = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HindernRollstuhlTherapietischJN
        {
            get { return cbRollstuhlTherapietischJN.Checked; }
            set { cbRollstuhlTherapietischJN.Checked = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string HindernRollstuhlBeschr
        {
            get { return tbRollstuhlBeschr.Text.Trim(); }
            set { tbRollstuhlBeschr.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HindernSitzgelgGurtenJN
        {
            get { return cbSitzgelegGurtenJN.Checked; }
            set { cbSitzgelegGurtenJN.Checked = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HindernSitzgelgTischJN
        {
            get { return cbSitzgelgTischJN.Checked; }
            set { cbSitzgelgTischJN.Checked = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HindernSitzgelgTherapietischJN
        {
            get { return cbSitzgelegTherapietischJN.Checked; }
            set { cbSitzgelegTherapietischJN.Checked = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HindernSitzgelgSitzhoseJN
        {
            get { return cbSitzgelegSitzhoseJN.Checked; }
            set { cbSitzgelegSitzhoseJN.Checked = value; }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string HindernSitzgelgBeschr
        {
            get { return tbSitzgelegBeschr.Text.Trim(); }
            set { tbSitzgelegBeschr.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HindernBettVerlSeitenteilenJN
        {
            get { return cbBettSeitentellenJN.Checked; }
            set { cbBettSeitentellenJN.Checked = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HindernBettVerlGurtenJN
        {
            get { return cbBettGurtenJN.Checked; }
            set { cbBettGurtenJN.Checked = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string HindernBettVerlBeschr
        {
            get { return tbBettBeschr.Text.Trim(); }
            set { tbBettBeschr.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool MedikFreihBeschraenkungJN
        {
            get { return cbMediFreihbeschrJN.Checked; }
            set { cbMediFreihbeschrJN.Checked = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MedikBezDosierung
        {
            get { return tbMediBezDosierung.Text.Trim(); }
            set { tbMediBezDosierung.Text = value; }
        }

        public bool GesendetAnBewohnervertrJN
        {
            get { return cbBewohnervertrJN.Checked; }
            set { cbBewohnervertrJN.Checked = value; }
        }

        public bool GesendetAnGestzVertrJN
        {
            get { return cbGestzVertrJN.Checked; }
            set { cbGestzVertrJN.Checked = value; }
        }

        public bool GesendetAnSelbstgewVertrJN
        {
            get { return cbSelbstgewVertrJN.Checked; }
            set { cbSelbstgewVertrJN.Checked = value; }
        }

        public bool GesendetAnVertrauenspersJN
        {
            get { return cbVertrauenspersJN.Checked; }
            set { cbVertrauenspersJN.Checked = value; }
        }


        public bool EndeGesendetAnBewohnervertrJN
        {
            get { return cbEndeBewohnervertrJN.Checked; }
            set { cbEndeBewohnervertrJN.Checked = value; }
        }

        public bool EndeGesendetAnGestzVertrJN
        {
            get { return cbEndeGestzVertrJN.Checked; }
            set { cbEndeGestzVertrJN.Checked = value; }
        }

        public bool EndeGesendetAnSelbstgewVertrJN
        {
            get { return cbEndeSelbstgewVertrJN.Checked; }
            set { cbEndeSelbstgewVertrJN.Checked = value; }
        }

        public bool EndeGesendetAnVertrauenspersJN
        {
            get { return cbEndeVertrauenspersJN.Checked; }
            set { cbEndeVertrauenspersJN.Checked = value; }
        }

        public string EndeAngeordnetVonTitel
        {
            get { return tbEndeAngeorVonTitel.Text.Trim(); }
            set { tbEndeAngeorVonTitel.Text = value; }
        }

        public string EndeAngeordnetVonVorname
        {
            get { return tbEndeAngeorVonVorname.Text.Trim(); }
            set { tbEndeAngeorVonVorname.Text = value; }
        }

        public string EndeAngeordnetVon
        {
            get { return tbEndeAngeorVon.Text.Trim(); }
            set { tbEndeAngeorVon.Text = value; }
        }

        public int EndeBerufsgruppe
        {
            get { return Convert.ToInt32(opEndeBerufsgruppe.Value); }
            set { opEndeBerufsgruppe.Value = value; }
        }

        public DateTime? VoraussichtlichesEnde
        {
            get
            {
                if (dtpVoraussichtlichesEnde.Value == DBNull.Value || dtpVoraussichtlichesEnde.DateTime.Year == 1753)
                    return null;
                else
                    return dtpVoraussichtlichesEnde.DateTime;
            }
            set
            {

            }
        }

//----- Für Felder ab 1.7.2010

        public int VoraussichtlicheDauer2010
        {
            get { return Convert.ToInt32(opVoraussichtlicheDauer2010.Value); }
            set { opVoraussichtlicheDauer2010.Value = value; }
        }

        public bool BettHandmanschettenJN
        {
            get { return cbBettHandmanschettenJN.Checked; }
            set { cbBettHandmanschettenJN.Checked = value; }
        }

        public bool RollstuhlBremsenJN
        {
            get { return cbRollstuhlBremsenJN.Checked; }
            set { cbRollstuhlBremsenJN.Checked = value; }
        }

        public bool RollstuhlSitzhoseJN
        {
            get { return cbRollstuhlSitzhoseJN.Checked; }
            set { cbRollstuhlSitzhoseJN.Checked = value; }
        }

        public int AerztlDokumentArt
        {
            get { return Convert.ToInt32(opAerztlDokumentArt.Value); }
            set { opAerztlDokumentArt.Value = value; }
        }

        public string AerztlDokumentArztTitel
        {
            get { return tbAerztlDokumentArztTitel.Text.Trim(); }
            set { tbAerztlDokumentArztTitel.Text = value; }
        }

        public string AerztlDokumentArztVorname
        {
            get { return tbAerztlDokumentArztVorname.Text.Trim(); }
            set { tbAerztlDokumentArztVorname.Text = value; }
        }

        public string AerztlDokumentArzt
        {
            get { return tbAerztlDokumentArzt.Text.Trim(); }
            set { tbAerztlDokumentArzt.Text = value; }
        }

        public DateTime? AerztlDokumentDatum
        {
            get
            {
                if (dtpAerztlDokumentDatum.Value == DBNull.Value || dtpAerztlDokumentDatum.DateTime.Year == 1753)
                    return null;
                else
                    return dtpAerztlDokumentDatum.DateTime;
            }
            set
            {
                dtpAerztlDokumentDatum.Value = value;
            }
        }

        public int TatsaechlicheEndeGrund
        {
            get { return Convert.ToInt32(opTatsaechlicheEndeGrund.Value); }
            set { opTatsaechlicheEndeGrund.Value = value; }
        }


        #endregion

        #region Events
        private void dtpAufgehobenAm_ValueChanged(object sender, EventArgs e)
        {
            if (_pruefen)
            {
                bool bError = false;
                bool bInfo = true;

                StringBuilder sb = new StringBuilder();
                sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Zeitpunkt der Aufhebung darf nicht kleiner als der Beginn sein."));
                
                GuiUtil.ValidateField(dtpAufgehobenAm, (Beginn != DateTime.MinValue && Ende != DateTime.MinValue && Ende > Beginn),
                    sb.ToString(), ref bError, bInfo, errorProvider1);

            }
        }



        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Guid IDKlinik_current = ENV.IDKlinik;
                KlientGuiAction.PrintDynamicReport(UNTERBRINGUNG_ROW, IDKlinik_current);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }
        #endregion

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
            base.OnKeyDown(e);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _CanClose = ValidateRechtlichePruefung();
            if (_CanClose)
            {
                UpdateData();

                if (this.TypeUIUnterbringung == eTypeUIUnterbringung.AddUnterbringung)
                {
                    this.mainWindow.AddUnterbringung_Click(this);
                    this.Close();
                }
                else if (this.TypeUIUnterbringung == eTypeUIUnterbringung.Verlängern)
                {
                    this.mainWindow.Verlaengern2016_OKClick(rnew, r);
                    this.Close();
                }
                else if (this.TypeUIUnterbringung == eTypeUIUnterbringung.Aufheben)
                {
                    this.mainWindow.Aufheben2016_Click();
                    this.Close();
                }
                else if (this.TypeUIUnterbringung == eTypeUIUnterbringung.HistoryAnzeigen)
                {
                    this.Close();
                }
            }

            this.OKClicked = true;
            ENV.SignalMedizinDatenChanged();
        }

        private void frmUnterbringung_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_CanClose;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _CanClose = true;
            this.Close();
        }


        private void dtpBeginn_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBeginn.DateTime >= DateTime.ParseExact("2010-07-01", "yyyy-MM-dd", null))
            {
                this.opVoraussichtlicheDauer.Visible = false;
                this.lblZeitraum.Visible = false;
                this.tbDauerZeitraum.Visible = false;
                this.cbLabyrithJN.Visible = false;

                this.opVoraussichtlicheDauer2010.Visible = true;
                this.cbBettHandmanschettenJN.Visible = true;
                this.cbRollstuhlBremsenJN.Visible = true;
                this.cbRollstuhlSitzhoseJN.Visible = true;
                this.gbAerztlDokument.Visible = true;
                this.opTatsaechlicheEndeGrund.Visible = true;

            }
            else
            {
                this.opVoraussichtlicheDauer.Visible = true;
                this.lblZeitraum.Visible = true;
                this.tbDauerZeitraum.Visible = true;
                this.cbLabyrithJN.Visible = true;
                
                this.opVoraussichtlicheDauer2010.Visible = false;
                this.cbBettHandmanschettenJN.Visible = false;
                this.cbRollstuhlBremsenJN.Visible = false;
                this.cbRollstuhlSitzhoseJN.Visible = false;
                this.gbAerztlDokument.Visible = false;
                this.opTatsaechlicheEndeGrund.Visible = false;
            }

        }

        private void frmUnterbringung_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
    }
}