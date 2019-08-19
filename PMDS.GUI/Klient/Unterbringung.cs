using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PMDS.Klient;
using PMDS.Global;
using PMDS.GUI.Klient;

namespace PMDS.BusinessLogic
{
    public class Unterbringung
    {
        public DBUnterbringung     _db;
        private Guid                _idAufenthalt = Guid.NewGuid();

        public Unterbringung()
        {
            _db = new DBUnterbringung();
            _db.IDAufenthalt = _idAufenthalt;
        }

        public Unterbringung(Guid idAufenthalt)
        {
            _idAufenthalt = idAufenthalt;
            _db = new DBUnterbringung();
            _db.IDAufenthalt = _idAufenthalt;
            Read();
        }

        public Guid IDAufenthalt
        {
            get { return _idAufenthalt; }
            set
            {
                _idAufenthalt = value;
                _db.IDAufenthalt = value;
                Read();
            }
        }

        /// <summary>
        /// Alle Patien Rehabilitationen
        /// </summary>
        public dsUnterbringung ALL
        {
            get { return _db.ALL; }
        }

        /// <summary>
        /// Daten lesen
        /// </summary>
        public void Read()
        {
            _db.Read();
        }

        /// <summary>
        /// Daten schreiben
        /// </summary>
        public void Write()
        {
            _db.Write();
        }

        public void Add(dsUnterbringung.UnterbringungRow r)
        {
            ALL.Unterbringung.Rows.Add(r.ItemArray);
        }

        /// <summary>
        /// Neue Unterbringung einfügen
        /// </summary>
        /// 

        public dsUnterbringung.UnterbringungRow New(string grund, DateTime beginn, int Berufsgruppe, string angeordnetVon,
                    DateTime angeordnetAm, DateTime aufgehobenAm, bool eingriffUnerlaesslichJN, string eingriffUnerlBeschreibung, int voraussichtlicheDauer, int voraussichtlicheDauer2010,
                    string zeitraum, bool klientZustimmungJN, bool psychischekrankheitJN, bool geistigeBehinderungJN, string medDiagICD,
                    string medizinischeDiagnose, bool selbstgefaehrdungJN, bool fremdgefaehrdungJN, string einrichtungsleiter,
                    bool elektronischesUeberwachungJN, bool zurueckhaltensandrohungJN, bool verschlosseneTuerJN, bool drehknopfJN,
                    bool codierungJN, bool labyrinthJN, string baulicheMassnahmen, bool hindernRollstuhlGurtenJN,
                    bool hindernRollstuhTischJN, bool hindernRollstuhTherapietischJN, string hindernRollstuhlBesch,
                    bool hindernSitzgelGurtenJN, bool hindernSitzgelTischJN, bool hindernSitzgelTherapietischJN,
                    string hindernSitzgelegenheitBeschr, bool hindernVerlassenBettSeitenteilenJN, bool hindernVerlassenBettGurtenJN,
                    string hindernBettVerlassenBeschr, bool medikFreihBeschraenkungJN, string medikBezeichnung,
                    bool infoAnBewohnervertreterJN, bool infoAnGesetzVertreterJN, bool infoAnSelbstGewaehlteVertreterJN,
                    bool infoAnVertrauenspersonJN, DateTime? VoraussichtlichesEnde, 
                    bool BettHandmanschettenJN, bool RollstuhlBremsenJN, bool RollstuhlSitzhoseJN,
                    int AerztlDokumentArt, string AerztlDokumentArzt, DateTime? AerztlDokumentDatum,
                    int TatsaechlicheEndeGrund, 
                    string AerztlDokumentArztTitel, string AerztlDokumentArztVorname,
                    string EinrichtungsleiterTitel, string EinrichtungsleiterVorname, string Einrichtungsleiter,
                    string AngeordnetVonTitel, string AngeordnetVonVorname,
                    string AbgesetztVonTitel, string AbgesetztVonVorname, bool hindernSitzgelSitzhoseJN
                    )
        {
            dsUnterbringung.UnterbringungRow row = _db.New(grund, beginn, Berufsgruppe, angeordnetVon, angeordnetAm, aufgehobenAm, eingriffUnerlaesslichJN,
                        eingriffUnerlBeschreibung, voraussichtlicheDauer, voraussichtlicheDauer2010, zeitraum, klientZustimmungJN,
                        psychischekrankheitJN, geistigeBehinderungJN, medDiagICD, medizinischeDiagnose, selbstgefaehrdungJN,
                        fremdgefaehrdungJN, einrichtungsleiter, elektronischesUeberwachungJN, zurueckhaltensandrohungJN,
                        verschlosseneTuerJN, drehknopfJN, codierungJN, labyrinthJN, baulicheMassnahmen,
                        hindernRollstuhlGurtenJN, hindernRollstuhTischJN, hindernRollstuhTherapietischJN,
                        hindernRollstuhlBesch, hindernSitzgelGurtenJN, hindernSitzgelTischJN, hindernSitzgelTherapietischJN,
                        hindernSitzgelegenheitBeschr, hindernVerlassenBettSeitenteilenJN, hindernVerlassenBettGurtenJN,
                        hindernBettVerlassenBeschr, medikFreihBeschraenkungJN, medikBezeichnung,
                        infoAnBewohnervertreterJN, infoAnGesetzVertreterJN, infoAnSelbstGewaehlteVertreterJN, infoAnVertrauenspersonJN, VoraussichtlichesEnde,
                        BettHandmanschettenJN, RollstuhlBremsenJN, RollstuhlSitzhoseJN,
                        AerztlDokumentArt, AerztlDokumentArzt, AerztlDokumentDatum,
                        TatsaechlicheEndeGrund,
                        AerztlDokumentArztTitel, AerztlDokumentArztVorname,
                        EinrichtungsleiterTitel, EinrichtungsleiterVorname, Einrichtungsleiter,
                        AngeordnetVonTitel, AngeordnetVonVorname,
                        AbgesetztVonTitel, AbgesetztVonVorname, hindernSitzgelSitzhoseJN);

            return row;
        }

        public dsUnterbringung.UnterbringungRow New2016(DateTime Beginn, int Dauer, DateTime? VoraussichtlichesEnde, int Berufsgruppe, string AngeordnetVonTitel,
                        string AngeordnetVonVorname, string AngeordnetVon, DateTime Ende, int TatsaechlicheEndeGrund, int EndeBerufsgruppe,
                        string EndeAngeordnetVonTitel, string EndeAngeordnetVonVorname, string EndeAngeordnetVon, bool KlientZustimmungJN,
                        bool PsychischeKrankheitJN, bool GeistigeBehinderungJN, string MedizinischeDiagnose, bool SelbstgefaehrdungJN,
                        bool FremdgefaehrdungJN, string AnmerkungVerhalten_2016, string AnmerkungGutachten_2016, bool EinzelfallmedikationJN_2016,
                        string Einzelfallmedikation_2016, bool DauermedikationJN_2016, string Dauermedikation_2016, bool HindernVerlassenBettSeitenteilenJN,
                        bool HindernVerlassenBettBauchgurtJN_2016, bool HindernVerlassenBettElektronischJN_2016, int HindernVerlassenBettHandArmgurte_2016,
                        int HindernVerlassenBettFussBeingurte_2016, bool HindernVerlassenBettAndereJN_2016, string HindernVerlassenBett,
                        bool HindernSitzgelSitzhoseJN, bool HindernSitzgelBauchgurtJN_2016, bool HindernSitzgelBrustgurtJN_2016,
                        int HindernSitzgelHandArmgurte_2016, bool HindernSitzgelTischJN, bool HindernSitzgelTherapietischJN,
                        int HindernSitzgelFussBeingurte_2016, bool HindernSitzgelAndereJN_2016, string HindernSitzgelBeschr,
                        bool ZurueckhaltensandrohungJN, bool HindernBereichFesthaltenJN_2016, bool HindernBereichVersperrterBereichJN_2016,
                        bool HindernBereichBarriereJN_2016, bool ElektronischeUeberwachungJN, bool HindernBereichVersperrtesZimmerJN_2016,
                        bool HindernBereichHinderAmFortbewegenJN_2016, bool HindernBereichAndereJN_2016, string BaulicheMassnahmen,
                        string EinrichtungsleiterTitel, string EinrichtungsleiterVorname, string Einrichtungsleiter)
        {
            dsUnterbringung.UnterbringungRow row = _db.New2016(Beginn, Dauer, VoraussichtlichesEnde, Berufsgruppe, AngeordnetVonTitel, AngeordnetVonVorname,
                                                AngeordnetVon, Ende, TatsaechlicheEndeGrund, EndeBerufsgruppe, EndeAngeordnetVonTitel,
                                                EndeAngeordnetVonVorname, EndeAngeordnetVon, KlientZustimmungJN, PsychischeKrankheitJN, GeistigeBehinderungJN,
                                                MedizinischeDiagnose, SelbstgefaehrdungJN, FremdgefaehrdungJN, AnmerkungVerhalten_2016, AnmerkungGutachten_2016,
                                                EinzelfallmedikationJN_2016, Einzelfallmedikation_2016, DauermedikationJN_2016, Dauermedikation_2016,
                                                HindernVerlassenBettSeitenteilenJN, HindernVerlassenBettBauchgurtJN_2016, HindernVerlassenBettElektronischJN_2016,
                                                HindernVerlassenBettHandArmgurte_2016, HindernVerlassenBettFussBeingurte_2016, HindernVerlassenBettAndereJN_2016,
                                                HindernVerlassenBett, HindernSitzgelSitzhoseJN, HindernSitzgelBauchgurtJN_2016, HindernSitzgelBrustgurtJN_2016,
                                                HindernSitzgelHandArmgurte_2016, HindernSitzgelTischJN, HindernSitzgelTherapietischJN, HindernSitzgelFussBeingurte_2016,
                                                HindernSitzgelAndereJN_2016, HindernSitzgelBeschr, ZurueckhaltensandrohungJN, HindernBereichFesthaltenJN_2016,
                                                HindernBereichVersperrterBereichJN_2016, HindernBereichBarriereJN_2016, ElektronischeUeberwachungJN,
                                                HindernBereichVersperrtesZimmerJN_2016, HindernBereichHinderAmFortbewegenJN_2016, HindernBereichAndereJN_2016,
                                                BaulicheMassnahmen, EinrichtungsleiterTitel, EinrichtungsleiterVorname, Einrichtungsleiter);

            return row;
        }



    }
}
