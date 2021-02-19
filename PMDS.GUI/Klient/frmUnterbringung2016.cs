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


    public partial class frmUnterbringung2016 : QS2.Desktop.ControlManagment.baseForm
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








        public frmUnterbringung2016(Unterbringungsaktion aktion, KlientDetails klient)
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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

            EinrichtungsleiterTitel = _klient.KLINIK.KlinikByAufenthalt.Klinik[0]["EinrichtungsleiterTitel"].ToString();
            EinrichtungsleiterVorname = _klient.KLINIK.KlinikByAufenthalt.Klinik[0]["EinrichtungsleiterVorname"].ToString();
            Einrichtungsleiter = _klient.KLINIK.KlinikByAufenthalt.Klinik[0]["Einrichtungsleiter"].ToString();

            InitHeaderText(_aktion);

            if (_aktion == Unterbringungsaktion.Beginn)
            {
                Beginn = DateTime.Now;
                gbAufhebung.Visible = false;
            }
            else if (_aktion == Unterbringungsaktion.Ende)
            {
                
                SetEnabled(gBBeginn, false);
                SetEnabled(gBZustimmung, false);
                SetEnabled(gBGrund, false);
                SetEnabled(gbArt, false);
            }
            else if (_aktion == Unterbringungsaktion.Verlaengerung)
            {
                SetEnabled(gBBeginn, true);
                gbAufhebung.Visible = false;
                SetEnabled(gBZustimmung, false);
                SetEnabled(gBGrund, false);
                SetEnabled(gbArt, false);
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

            sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Meldung"));
            switch (aktion)
            {
                case Unterbringungsaktion.Beginn:
                    sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes(" über die Vornahme einer Freiheitsbeschränkung/einschränkung"));
                    break;
                case Unterbringungsaktion.Ende:
                    sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes(" über die Aufhebung einer Freiheitsbeschränkung/einschränkung"));
                    break;
                case Unterbringungsaktion.Verlaengerung:
                    sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes(" über die Verlängerung einer gerichtlich zulässig erklärten Freiheitsbeschränkung nach Ablauf der Frist"));
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


            if (!_row.IsBeginnNull()) Beginn = _row.Beginn;
            if (!_row.IsDauerNull()) Dauer = _row.Dauer;
            if (!_row.IsVoraussichtlichesEndeNull()) VoraussichtlichesEnde = _row.VoraussichtlichesEnde;
            if (!_row.IsBerufsgruppeNull()) Berufsgruppe = _row.Berufsgruppe;

            EinrichtungsleiterTitel = _row.EinrichtungsleiterTitel;
            if (!_row.IsEinrichtungsleiterNull()) Einrichtungsleiter = _row.Einrichtungsleiter;
            EinrichtungsleiterVorname = _row.EinrichtungsleiterVorname;

            AngeordnetVonTitel = _row.AngeordnetVonTitel.Trim();
            AngeordnetVonVorname = _row.AngeordnetVonVorname.Trim();
            if (!_row.IsAngeordnetVonNull()) AngeordnetVon = _row.AngeordnetVon.Trim();

            if (_aktion == Unterbringungsaktion.Verlaengerung || _aktion == Unterbringungsaktion.Historie || _aktion == Unterbringungsaktion.Beginn)
            {
                if (!_row.IsAufgehobenAmNull()) Ende = _row.AufgehobenAm;
            }
            else
            {
                Ende = DateTime.Now;
            }

            TatsaechlicheEndeGrund = _row.TatsaechlicheEndeGrund;
            if (!_row.IsENDEBerufsgruppeNull()) EndeBerufsgruppe = _row.ENDEBerufsgruppe;
            EndeAngeordnetVonTitel = _row.AufgehobenVonTitel;
            EndeAngeordnetVonVorname = _row.AufgehobenVonVorname;
            if (!_row.IsENDEAngeordnetVonNull()) EndeAngeordnetVon = _row.ENDEAngeordnetVon.Trim();
            if (!_row.IsKlientZustimmungJNNull()) KlientZustimmungJN = _row.KlientZustimmungJN;
            if (!_row.IsPsychischekrankheitJNNull()) PsychischeKrankheitJN = _row.PsychischekrankheitJN;
            if (!_row.IsGeistigeBehinderungJNNull()) GeistigeBehinderungJN = _row.GeistigeBehinderungJN;
            if (!_row.IsMedizinischeDiagnoseNull()) MedizinischeDiagnose = _row.MedizinischeDiagnose;
            if (!_row.IsErheblicheSelbstgefaehrdungJNNull()) SelbstgefaehrdungJN = _row.ErheblicheSelbstgefaehrdungJN;
            if (!_row.IsErheblicheFremdgefaehrdungJNNull()) FremdgefaehrdungJN = _row.ErheblicheFremdgefaehrdungJN;
            if (!_row.IsAnmerkungVerhalten_2016Null()) AnmerkungVerhalten_2016 = _row.AnmerkungVerhalten_2016.Trim();
            if (!_row.IsAnmerkungGutachten_2016Null()) AnmerkungGutachten_2016 = _row.AnmerkungGutachten_2016.Trim();
            if (!_row.IsEinzelfallmedikationJN_2016Null()) EinzelfallmedikationJN_2016 = _row.EinzelfallmedikationJN_2016;
            if (!_row.IsEinzelfallmedikation_2016Null()) Einzelfallmedikation_2016 = _row.Einzelfallmedikation_2016.Trim();
            if (!_row.IsDauermedikationJN_2016Null()) DauermedikationJN_2016 = _row.DauermedikationJN_2016;
            if (!_row.IsDauermedikation_2016Null()) Dauermedikation_2016 = _row.Dauermedikation_2016.Trim();
            if (!_row.IsHindernVerlassenBettSeitenteilenJNNull()) HindernVerlassenBettSeitenteilenJN = _row.HindernVerlassenBettSeitenteilenJN;
            if (!_row.IsHindernVerlassenBettBauchgurtJN_2016Null()) HindernVerlassenBettBauchgurtJN_2016 = _row.HindernVerlassenBettBauchgurtJN_2016;
            if (!_row.IsHindernVerlassenBettElektronischJN_2016Null()) HindernVerlassenBettElektronischJN_2016 = _row.HindernVerlassenBettElektronischJN_2016;
            if (!_row.IsHindernVerlassenBettHandArmgurte_2016Null()) HindernVerlassenBettHandArmgurte_2016 = _row.HindernVerlassenBettHandArmgurte_2016;
            if (!_row.IsHindernVerlassenBettFussBeingurte_2016Null()) HindernVerlassenBettFussBeingurte_2016 = _row.HindernVerlassenBettFussBeingurte_2016;
            if (!_row.IsHindernVerlassenBettElektronischJN_2016Null()) HindernVerlassenBettElektronischJN_2016 = _row.HindernVerlassenBettElektronischJN_2016;
            if (!_row.IsHindernVerlassenBettAndereJN_2016Null()) HindernVerlassenBettAndereJN_2016 = _row.HindernVerlassenBettAndereJN_2016;
            if (!_row.IsHindernBettVerlassenNull()) HindernVerlassenBett = _row.HindernBettVerlassen;
            HindernSitzgelSitzhoseJN = _row.HindernSitzgelSitzhoseJN;
            if (!_row.IsHindernSitzgelBauchgurtJN_2016Null()) HindernSitzgelBauchgurtJN_2016 = _row.HindernSitzgelBauchgurtJN_2016;
            if (!_row.IsHindernSitzgelBrustgurtJN_2016Null()) HindernSitzgelBrustgurtJN_2016 = _row.HindernSitzgelBrustgurtJN_2016;
            if (!_row.IsHindernSitzgelHandArmgurte_2016Null()) HindernSitzgelHandArmgurte_2016 = _row.HindernSitzgelHandArmgurte_2016;
            if (!_row.IsHindernSitzgelTischJNNull()) HindernSitzgelTischJN = _row.HindernSitzgelTischJN;
            if (!_row.IsHindernSitzgelTherapietischJNNull()) HindernSitzgelTherapietischJN = _row.HindernSitzgelTherapietischJN;
            if (!_row.IsHindernSitzgelFussBeingurte_2016Null()) HindernSitzgelFussBeingurte_2016 = _row.HindernSitzgelFussBeingurte_2016;
            if (!_row.IsHindernSitzgelAndereJN_2016Null()) HindernSitzgelAndereJN_2016 = _row.HindernSitzgelAndereJN_2016;
            if (!_row.IsHindernSitzgelegenheitNull()) HindernSitzgelBeschr = _row.HindernSitzgelegenheit.Trim();
            if (!_row.IsZurueckhaltensandrohungJNNull()) ZurueckhaltensandrohungJN = _row.ZurueckhaltensandrohungJN;
            if (!_row.IsHindernBereichFesthaltenJN_2016Null()) HindernBereichFesthaltenJN_2016 = _row.HindernBereichFesthaltenJN_2016;
            if (!_row.IsHindernBereichVersperrterBereichJN_2016Null()) HindernBereichVersperrterBereichJN_2016 = _row.HindernBereichVersperrterBereichJN_2016;
            if (!_row.IsHindernBereichBarriereJN_2016Null()) HindernBereichBarriereJN_2016 = _row.HindernBereichBarriereJN_2016;
            if (!_row.IsElektronischesUeberwachungJNNull()) ElektronischeUeberwachungJN = _row.ElektronischesUeberwachungJN;
            if (!_row.IsHindernBereichVersperrtesZimmerJN_2016Null()) HindernBereichVersperrtesZimmerJN_2016 = _row.HindernBereichVersperrtesZimmerJN_2016;
            if (!_row.IsHindernBereichHinderAmFortbewegenJN_2016Null()) HindernBereichHinderAmFortbewegenJN_2016 = _row.HindernBereichHinderAmFortbewegenJN_2016;
            if (!_row.IsHindernBereichAndereJN_2016Null()) HindernBereichAndereJN_2016 = _row.HindernBereichAndereJN_2016;
            if (!_row.IsBaulicheMassnahmenNull()) BaulicheMassnahmen = _row.BaulicheMassnahmen.Trim();

            EinrichtungsleiterTitel = _row.EinrichtungsleiterTitel;
            EinrichtungsleiterVorname = _row.EinrichtungsleiterVorname;
            if (!_row.IsEinrichtungsleiterNull()) Einrichtungsleiter = _row.Einrichtungsleiter;

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

            if (_aktion == Unterbringungsaktion.Historie)
            {
                //Keine Veränderung zulassen
                SetEnabled(this, false);

                if (_row.RowState != DataRowState.Added)
                    btnPreview.Visible = true;

                if (_row.IsAufgehobenAmNull())
                    gbAufhebung.Visible = false;
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

            if (_aktion == Unterbringungsaktion.Historie)
                return;

            if (_row == null)
                return;

            if (_aktion == Unterbringungsaktion.Ende)
                _row.AufgehobenAm = Ende;



            //AngeordnetAm??

            _row.Beginn = Beginn;
            _row.Dauer = Dauer;
            if (VoraussichtlichesEnde != null)
                 _row.VoraussichtlichesEnde =  VoraussichtlichesEnde.Value;
            _row.Berufsgruppe = Berufsgruppe;
            _row.AngeordnetVonTitel = AngeordnetVonTitel.Trim();
            _row.AngeordnetVonVorname = AngeordnetVonVorname.Trim();
            _row.AngeordnetVon = AngeordnetVon.Trim();

            if (Ende != DateTime.MinValue)
                _row.AufgehobenAm = Ende;
            else
                _row.SetAufgehobenAmNull();

            _row.TatsaechlicheEndeGrund = TatsaechlicheEndeGrund;
            _row.ENDEBerufsgruppe = EndeBerufsgruppe;
            _row.AufgehobenVonTitel = EndeAngeordnetVonTitel;
            _row.AufgehobenVonVorname = EndeAngeordnetVonVorname;
            _row.ENDEAngeordnetVon = EndeAngeordnetVon.Trim();
            _row.KlientZustimmungJN = KlientZustimmungJN;
            _row.PsychischekrankheitJN = PsychischeKrankheitJN;
            _row.GeistigeBehinderungJN = GeistigeBehinderungJN;
            _row.MedizinischeDiagnose = MedizinischeDiagnose;
            _row.ErheblicheSelbstgefaehrdungJN = SelbstgefaehrdungJN;
            _row.ErheblicheFremdgefaehrdungJN = FremdgefaehrdungJN;
            _row.AnmerkungVerhalten_2016 = AnmerkungVerhalten_2016.Trim();
            _row.AnmerkungGutachten_2016 = AnmerkungGutachten_2016.Trim();
            _row.EinzelfallmedikationJN_2016 = EinzelfallmedikationJN_2016;
            _row.Einzelfallmedikation_2016 = Einzelfallmedikation_2016.Trim();
            _row.DauermedikationJN_2016 = DauermedikationJN_2016;
            _row.Dauermedikation_2016 = Dauermedikation_2016.Trim();
            _row.HindernVerlassenBettSeitenteilenJN = HindernVerlassenBettSeitenteilenJN;
            _row.HindernVerlassenBettBauchgurtJN_2016 = HindernVerlassenBettBauchgurtJN_2016;
            _row.HindernVerlassenBettElektronischJN_2016 = HindernVerlassenBettElektronischJN_2016;
            _row.HindernVerlassenBettHandArmgurte_2016 = HindernVerlassenBettHandArmgurte_2016;
            _row.HindernVerlassenBettFussBeingurte_2016 = HindernVerlassenBettFussBeingurte_2016;
            _row.HindernVerlassenBettElektronischJN_2016 = HindernVerlassenBettElektronischJN_2016;
            _row.HindernBettVerlassen = HindernVerlassenBett;
            _row.HindernSitzgelSitzhoseJN = HindernSitzgelSitzhoseJN;
            _row.HindernSitzgelBauchgurtJN_2016 = HindernSitzgelBauchgurtJN_2016;
            _row.HindernSitzgelBrustgurtJN_2016 = HindernSitzgelBrustgurtJN_2016;
            _row.HindernSitzgelHandArmgurte_2016 = HindernSitzgelHandArmgurte_2016;
            _row.HindernSitzgelTischJN = HindernSitzgelTischJN;
            _row.HindernSitzgelTherapietischJN = HindernSitzgelTherapietischJN;
            _row.HindernSitzgelFussBeingurte_2016 = HindernSitzgelFussBeingurte_2016;
            _row.HindernSitzgelAndereJN_2016 = HindernSitzgelAndereJN_2016;
            _row.HindernSitzgelegenheit = HindernSitzgelBeschr.Trim();
            _row.ZurueckhaltensandrohungJN = ZurueckhaltensandrohungJN;
            _row.HindernBereichFesthaltenJN_2016 = HindernBereichFesthaltenJN_2016;
            _row.HindernBereichVersperrterBereichJN_2016 = HindernBereichVersperrterBereichJN_2016;
            _row.HindernBereichBarriereJN_2016 = HindernBereichBarriereJN_2016;
            _row.ElektronischesUeberwachungJN = ElektronischeUeberwachungJN;
            _row.HindernBereichVersperrtesZimmerJN_2016 = HindernBereichVersperrtesZimmerJN_2016;
            _row.HindernBereichHinderAmFortbewegenJN_2016 = HindernBereichHinderAmFortbewegenJN_2016;
            _row.HindernBereichAndereJN_2016 = HindernBereichAndereJN_2016;
            _row.BaulicheMassnahmen = BaulicheMassnahmen.Trim();
            _row.EinrichtungsleiterTitel = EinrichtungsleiterTitel;
            _row.EinrichtungsleiterVorname = EinrichtungsleiterVorname;
            _row.Einrichtungsleiter = Einrichtungsleiter;
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

            //Maßnahmendauer
            strError = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte eine Dauer auswählen.");
            if (Dauer == 0)
                GuiUtil.ValidateField(this.opDauer, false,
                        strError, ref bError, bInfo, errorProvider1);

            //anordnende Person darf nicht leer sein
            strError = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte anordnende Person angeben.");
            GuiUtil.ValidateField(tbAngeorVon, AngeordnetVon != "" ? true : false,
                   strError, ref bError, bInfo, errorProvider1);


            //Freiheitsbeschränkung!
            if (!cbKlientZustimmumgJN.Checked)
            {
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
            }


            strError = QS2.Desktop.ControlManagment.ControlManagment.getRes("Datum vor 11.1.2016 nicht erlaubt.");
            GuiUtil.ValidateField(dtpBeginn, Beginn >= new DateTime(2016,01,11),
                    strError, ref bError, bInfo, errorProvider1);

            if (_aktion == Unterbringungsaktion.Ende)
            {
                GuiUtil.ValidateField(dtpAufgehobenAm, Ende != DateTime.MinValue, ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
                strError = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte auswählen.");
                GuiUtil.ValidateField(tbEndeAngeorVon, tbEndeAngeorVon.Text.Trim() != "", ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
                if (Beginn >= new DateTime(2010, 7, 1))
                    GuiUtil.ValidateField(opTatsaechlicheEndeGrund, (int)opTatsaechlicheEndeGrund.CheckedIndex >= 0 ? true : false, 
                    strError, ref bError, bInfo, errorProvider1);

            }

            strError = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Berufsgruppe auswählen.");
            GuiUtil.ValidateField(this.opBerufsgruppe, (this.opBerufsgruppe.CheckedIndex >= 0 ? true : false),
                    strError, ref bError, bInfo, errorProvider1);

            strError = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Art der Freiheitsbeschränkung/- einschränkung auswählen");
            GuiUtil.ValidateField(gbArt, (EinzelfallmedikationJN_2016 ||
                                            DauermedikationJN_2016 ||
                                            HindernVerlassenBettSeitenteilenJN ||
                                            HindernVerlassenBettBauchgurtJN_2016 ||
                                            HindernVerlassenBettElektronischJN_2016 ||
                                            HindernVerlassenBettHandArmgurte_2016 > 0 ||
                                            HindernVerlassenBettFussBeingurte_2016 > 0 ||
                                            HindernVerlassenBettAndereJN_2016 ||
                                            HindernSitzgelSitzhoseJN ||
                                            HindernSitzgelBauchgurtJN_2016 ||
                                            HindernSitzgelBrustgurtJN_2016 ||
                                            HindernSitzgelHandArmgurte_2016 > 0 ||
                                            HindernSitzgelTischJN ||
                                            HindernSitzgelTherapietischJN ||
                                            HindernSitzgelFussBeingurte_2016 > 0 ||
                                            HindernSitzgelAndereJN_2016 ||
                                            ZurueckhaltensandrohungJN ||
                                            HindernBereichFesthaltenJN_2016 ||
                                            HindernBereichVersperrterBereichJN_2016 ||
                                            HindernBereichBarriereJN_2016 ||
                                            ElektronischeUeberwachungJN ||
                                            HindernBereichVersperrtesZimmerJN_2016 ||
                                            HindernBereichHinderAmFortbewegenJN_2016 ||
                                            HindernBereichAndereJN_2016),
                    strError, ref bError, bInfo, errorProvider1);

            


            if (_aktion == Unterbringungsaktion.Verlaengerung && _row != null &&
                !_row.IsVoraussichtlichesEndeNull() && !_row.IsAufgehobeneMassnahmeInfoNull()
               )
            {
                strError = QS2.Desktop.ControlManagment.ControlManagment.getRes("Für eine Verlängerung bitte das vorraussichtliche Ende ändern.");
                GuiUtil.ValidateField(dtpVoraussichtlichesEnde, (VoraussichtlichesEnde.Value != _row.VoraussichtlichesEnde),
                          strError, ref bError, bInfo, errorProvider1);
            }

            return !bError;
        }

        #region Properties
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Dauer
        {
            get { return Convert.ToInt32(opDauer.Value); }
            set { opDauer.Value = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
                dtpVoraussichtlichesEnde.Value = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Berufsgruppe
        {
            get { return Convert.ToInt32(opBerufsgruppe.Value); }
            set { opBerufsgruppe.Value = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string AngeordnetVonTitel
        {
            get { return tbAngeorVonTitel.Text.Trim(); }
            set { tbAngeorVonTitel.Text = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string AngeordnetVonVorname
        {
            get { return tbAngeorVonVorname.Text.Trim(); }
            set { tbAngeorVonVorname.Text = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string AngeordnetVon
        {
            get { return tbAngeorVon.Text.Trim(); }
            set { tbAngeorVon.Text = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int TatsaechlicheEndeGrund
        {
            get { return Convert.ToInt32(opTatsaechlicheEndeGrund.Value); }
            set { opTatsaechlicheEndeGrund.Value = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int EndeBerufsgruppe
        {
            get { return Convert.ToInt32(opEndeBerufsgruppe.Value); }
            set { opEndeBerufsgruppe.Value = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string EndeAngeordnetVonTitel
        {
            get { return tbEndeAngeorVonTitel.Text.Trim(); }
            set { tbEndeAngeorVonTitel.Text = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string EndeAngeordnetVonVorname
        {
            get { return tbEndeAngeorVonVorname.Text.Trim(); }
            set { tbEndeAngeorVonVorname.Text = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string EndeAngeordnetVon
        {
            get { return tbEndeAngeorVon.Text.Trim(); }
            set { tbEndeAngeorVon.Text = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool KlientZustimmungJN
        {
            get { return cbKlientZustimmumgJN.Checked; }
            set { cbKlientZustimmumgJN.Checked = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool PsychischeKrankheitJN
        {
            get { return cbPsyKrankheitJN.Checked; }
            set { cbPsyKrankheitJN.Checked = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool GeistigeBehinderungJN
        {
            get { return cbGeistBehinderungJN.Checked; }
            set { cbGeistBehinderungJN.Checked = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MedizinischeDiagnose
        {
            get { return tbMedizinischeDiagnose.Text.Trim(); }
            set { tbMedizinischeDiagnose.Text = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SelbstgefaehrdungJN
        {
            get { return cbErnErhSelbstgefaehrdungJN.Checked; }
            set { cbErnErhSelbstgefaehrdungJN.Checked = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool FremdgefaehrdungJN
        {
            get { return cbErnErhFremdgefaehrdungJN.Checked; }
            set { cbErnErhFremdgefaehrdungJN.Checked = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string AnmerkungVerhalten_2016
        {
            get { return tbAnmerkungVerhalten_2016.Text.Trim(); }
            set { tbAnmerkungVerhalten_2016.Text = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string AnmerkungGutachten_2016
        {
            get { return tbAnmerkungGutachten_2016.Text.Trim(); }
            set { tbAnmerkungGutachten_2016.Text = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool EinzelfallmedikationJN_2016
        {
            get { return cbEinzelfallmedikationJN_2016.Checked; }
            set { cbEinzelfallmedikationJN_2016.Checked = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Einzelfallmedikation_2016
        {
            get { return tbEinzelfallmedikation_2016.Text.Trim(); }
            set { tbEinzelfallmedikation_2016.Text = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DauermedikationJN_2016
        {
            get { return cbDauermedikationJN_2016.Checked; }
            set { cbDauermedikationJN_2016.Checked = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Dauermedikation_2016
        {
            get { return tbDauermedikation_2016.Text.Trim(); }
            set { tbDauermedikation_2016.Text = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HindernVerlassenBettSeitenteilenJN
        {
            get { return cbBettSeitenteileJN.Checked; }
            set { cbBettSeitenteileJN.Checked = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HindernVerlassenBettBauchgurtJN_2016
        {
            get { return cbHindernVerlassenBettBauchgurtJN_2016.Checked; }
            set { cbHindernVerlassenBettBauchgurtJN_2016.Checked = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HindernVerlassenBettElektronischJN_2016
        {
            get { return cbHindernVerlassenBettElektronischJN_2016.Checked; }
            set { cbHindernVerlassenBettElektronischJN_2016.Checked = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int HindernVerlassenBettHandArmgurte_2016
        {
            get { return Convert.ToInt32(rbHindernVerlassenBettHandArmgurte_2016.Value); }
            set { rbHindernVerlassenBettHandArmgurte_2016.Value = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int HindernVerlassenBettFussBeingurte_2016
        {
            get { return Convert.ToInt32(rbHindernVerlassenBettFussBeingurte_2016.Value); }
            set { rbHindernVerlassenBettFussBeingurte_2016.Value = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HindernVerlassenBettAndereJN_2016
        {
            get { return cbHindernVerlassenBettAndereJN_2016.Checked; }
            set { cbHindernVerlassenBettAndereJN_2016.Checked = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string HindernVerlassenBett
        {
            get { return tbHindernVerlassenBett.Text.Trim(); }
            set { tbHindernVerlassenBett.Text = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HindernSitzgelSitzhoseJN
        {
            get { return cbHindernSitzgelSitzhoseJN.Checked; }
            set { cbHindernSitzgelSitzhoseJN.Checked = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HindernSitzgelBauchgurtJN_2016
        {
            get { return cbHindernSitzgelBauchgurtJN_2016.Checked; }
            set { cbHindernSitzgelBauchgurtJN_2016.Checked = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HindernSitzgelBrustgurtJN_2016
        {
            get { return cbHindernSitzgelBrustgurtJN_2016.Checked; }
            set { cbHindernSitzgelBrustgurtJN_2016.Checked = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int HindernSitzgelHandArmgurte_2016
        {
            get { return Convert.ToInt32(rbHindernSitzgelHandArmgurte_2016.Value); }
            set { rbHindernSitzgelHandArmgurte_2016.Value = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HindernSitzgelTischJN
        {
            get { return cbHindernSitzgelTischJN.Checked; }
            set { cbHindernSitzgelTischJN.Checked = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HindernSitzgelTherapietischJN
        {
            get { return cbHindernSitzgelTherapietischJN.Checked; }
            set { cbHindernSitzgelTherapietischJN.Checked = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int HindernSitzgelFussBeingurte_2016
        {
            get { return Convert.ToInt32(rbHindernSitzgelFussBeingurte_2016.Value); }
            set { rbHindernSitzgelFussBeingurte_2016.Value = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HindernSitzgelAndereJN_2016
        {
            get { return cbHindernSitzgelAndereJN_2016.Checked; }
            set { cbHindernSitzgelAndereJN_2016.Checked = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string HindernSitzgelBeschr
        {
            get { return tbHindernSitzgelBeschr.Text.Trim(); }
            set { tbHindernSitzgelBeschr.Text = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ZurueckhaltensandrohungJN
        {
            get { return cbZurhaltAndrohungAnordnungJN.Checked; }
            set { cbZurhaltAndrohungAnordnungJN.Checked = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HindernBereichFesthaltenJN_2016
        {
            get { return cbHindernBereichFesthaltenJN_2016.Checked; }
            set { cbHindernBereichFesthaltenJN_2016.Checked = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HindernBereichVersperrterBereichJN_2016
        {
            get { return cbHindernBereichVersperrterBereichJN_2016.Checked; }
            set { cbHindernBereichVersperrterBereichJN_2016.Checked = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HindernBereichBarriereJN_2016
        {
            get { return cbHindernBereichBarriereJN_2016.Checked; }
            set { cbHindernBereichBarriereJN_2016.Checked = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ElektronischeUeberwachungJN
        {
            get { return cbElektronischeUeberwachungJN.Checked; }
            set { cbElektronischeUeberwachungJN.Checked = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HindernBereichVersperrtesZimmerJN_2016
        {
            get { return cbHindernBereichVersperrtesZimmerJN_2016.Checked; }
            set { cbHindernBereichVersperrtesZimmerJN_2016.Checked = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HindernBereichHinderAmFortbewegenJN_2016
        {
            get { return cbHindernBereichHinderAmFortbewegenJN_2016.Checked; }
            set { cbHindernBereichHinderAmFortbewegenJN_2016.Checked = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HindernBereichAndereJN_2016
        {
            get { return cbHindernBereichAndereJN_2016.Checked; }
            set { cbHindernBereichAndereJN_2016.Checked = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string BaulicheMassnahmen
        {
            get { return tbBaulicheMassnahmen.Text.Trim(); }
            set { tbBaulicheMassnahmen.Text = value; }
        }


        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string EinrichtungsleiterTitel
        {
            get { return lblEinrichtugLeitTitel.Text.Trim(); }
            set { lblEinrichtugLeitTitel.Text = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string EinrichtungsleiterVorname
        {
            get { return lblEinrichtugLeitVorname.Text.Trim(); }
            set { lblEinrichtugLeitVorname.Text = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Einrichtungsleiter
        {
            get { return lblEinrichtugLeit.Text.Trim(); }
            set { lblEinrichtugLeit.Text = value; }
        }

        #endregion

        #region Events
        //private void dtpAufgehobenAm_ValueChanged(object sender, EventArgs e)
        //{
        //    if (_pruefen)
        //    {
        //        bool bError = false;
        //        bool bInfo = true;

        //        StringBuilder sb = new StringBuilder();
        //        sb.Append("Zeitpunkt der Aufhebung darf nicht kleiner als der Beginn sein.");

        //        GuiUtil.ValidateField(dtpAufgehobenAm, (Beginn != DateTime.MinValue && Ende != DateTime.MinValue && Ende > Beginn),
        //            sb.ToString(), ref bError, bInfo, errorProvider1);

        //    }
        //}



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
                UpdateData();

            this.OKClicked = true;
        }

        private void frmUnterbringung_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_CanClose;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _CanClose = true;
        }


        private void dtpBeginn_ValueChanged(object sender, EventArgs e)
        {

                this.opDauer.Visible = true;

        }

        private void opBerufsgruppe_ValueChanged(object sender, EventArgs e)
        {

        }

        private void gBArt_Click(object sender, EventArgs e)
        {

        }

        private void baseButton1_Click(object sender, EventArgs e)
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

        private void ucButton1_Click(object sender, EventArgs e)
        {
            _CanClose = true;
            this.Close();
        }

        private void ucButton2_Click(object sender, EventArgs e)
        {
            try
            {
                _CanClose = ValidateRechtlichePruefung();
                if (_CanClose)
                {
                    UpdateData();

                    if (this.TypeUIUnterbringung == eTypeUIUnterbringung.AddUnterbringung)
                    {
                        this.mainWindow.AddUnterbringung2016_Click(this);
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
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void frmUnterbringung2016_Load(object sender, EventArgs e)
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
