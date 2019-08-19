using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
using PMDS.Global;
using PMDS.GUI.Klient;




namespace PMDS.Klient
{
    public partial class DBUnterbringung : Component
    {
        private Guid _idAufenthalt = Guid.NewGuid();

        public DBUnterbringung()
        {
            InitializeComponent();
        }

        public DBUnterbringung(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public Guid IDAufenthalt
        {
            get { return _idAufenthalt; }
            set { _idAufenthalt = value; }
        }

        /// <summary>
        /// Alle Patien Rehabilitationen
        /// </summary>
        public dsUnterbringung ALL
        {
            get { return dsUnterbringung1; }
        }


        /// <summary>
        /// Alle Patien Rehabilitationen einlesen
        /// </summary>
        public void Read()
        {
            dsUnterbringung1.Unterbringung.Clear();
            daUnterbringung.SelectCommand.Parameters[0].Value = _idAufenthalt;
            PMDS.Global.dbBase.setConnection(daUnterbringung, RBU.DataBase.CONNECTION);
            RBU.DataBase.Fill(daUnterbringung, dsUnterbringung1);
        }

        /// <summary>
        /// Daten schreiben
        /// </summary>
        public void Write()
        { 
            try
            {
                RBU.DataBase.Update(daUnterbringung, dsUnterbringung1);
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                throw new Exception("DBUnterbringung.Write: " + ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("DBUnterbringung.Write: " + ex.ToString());
            }
        }

        /// <summary>
        /// Neue Unterbringung einfügen
        /// </summary>
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
                    int TatsaechlicheEndeGrund, string AerztlDokumentArztTitel, string AerztlDokumentArztVorname,
                    string EinrichtungsleiterTitel, string EinrichtungsleiterVorname, string Einrichtungsleiter,
                    string AngeordnetVonTitel, string AngeordnetVonVorname,
                    string AbgesetztVonTitel, string AbgesetztVonVorname,
                    bool hindernSitzgelSitzhoseJN)

        {

            dsUnterbringung.UnterbringungRow r = dsUnterbringung1.Unterbringung.NewUnterbringungRow();
            r.ID                                    = Guid.NewGuid();
            r.IDAufenthalt                          = IDAufenthalt;
            r.Aktion                                = "Vornahme";
            r.Grund                                 = grund;
            r.Beginn                                = beginn;
            //r.Dauer
            r.Berufsgruppe                          = Berufsgruppe;
            r.AngeordnetVon                         = angeordnetVon;
            r.AngeordnetAm                          = angeordnetAm;

            if (aufgehobenAm != DateTime.MinValue)
                r.AufgehobenAm = aufgehobenAm;
            
            r.EingriffUnerlaesslichJN               = eingriffUnerlaesslichJN;
            r.EingriffUnerlaesslichBeschreibung     = eingriffUnerlBeschreibung;

            if (aufgehobenAm != DateTime.MinValue)
                r.AufgehobeneMassnahmeInfo = Berufsgruppe;

            if (aufgehobenAm != DateTime.MinValue)
                r.AufgehobenVon = angeordnetVon;

            // bei Neuen Sätzen kann nurmehr aus 2010 gewählt werden 
            r.VoraussichtlicheDauer                 = voraussichtlicheDauer2010;
            r.Zeitraum                              = zeitraum;
            r.KlientZustimmungJN                    = klientZustimmungJN;
            r.PsychischekrankheitJN                 = psychischekrankheitJN;
            r.GeistigeBehinderungJN                 = geistigeBehinderungJN;
            r.MedDiagnICD                           = medDiagICD;
            r.MedizinischeDiagnose                  = medizinischeDiagnose;
            r.ErheblicheSelbstgefaehrdungJN         = selbstgefaehrdungJN;
            r.ErheblicheFremdgefaehrdungJN          = fremdgefaehrdungJN;
            r.Einrichtungsleiter                    = einrichtungsleiter;
            r.ElektronischesUeberwachungJN          = elektronischesUeberwachungJN;
            r.ZurueckhaltensandrohungJN             = zurueckhaltensandrohungJN;
            r.VerschlosseneTuerJN                   = verschlosseneTuerJN;
            r.DrehknopfJN                           = drehknopfJN;
            r.CodierungJN                           = codierungJN;
            r.LabyrinthJN                           = labyrinthJN;
            r.BaulicheMassnahmen                    = baulicheMassnahmen;
            r.HindernRollstuhlGurtenJN              = hindernRollstuhlGurtenJN;
            r.HindernRollstuhTischJN                = hindernRollstuhTischJN;
            r.HindernRollstuhTherapietischJN        = hindernRollstuhTherapietischJN;
            r.HindernRollstuhl                      = hindernRollstuhlBesch;
            r.HindernSitzgelGurtenJN                = hindernSitzgelGurtenJN;
            r.HindernSitzgelTischJN                 = hindernSitzgelTischJN;
            r.HindernSitzgelTherapietischJN         = hindernSitzgelTherapietischJN;
            r.HindernSitzgelegenheit                = hindernSitzgelegenheitBeschr;
            r.HindernVerlassenBettSeitenteilenJN    = hindernVerlassenBettSeitenteilenJN;
            r.HindernVerlassenBettGurtenJN          = hindernVerlassenBettGurtenJN;
            r.HindernBettVerlassen                  = hindernBettVerlassenBeschr;
            r.MedikFreihBeschraenkungJN             = medikFreihBeschraenkungJN;
            r.MedikBezeichnung                      = medikBezeichnung;
            r.GesendetAnBewohnervertreterJN         = infoAnBewohnervertreterJN;
            r.GesendetAnGesetzVertreterJN           = infoAnGesetzVertreterJN;
            r.GesendetAnSelbstGewVertreterJN        = infoAnSelbstGewaehlteVertreterJN;
            r.GesendetAnVertrauenspersonJN          = infoAnVertrauenspersonJN;
            
            if (VoraussichtlichesEnde != null)
                r.VoraussichtlichesEnde = (DateTime)VoraussichtlichesEnde;
            else
                r.SetVoraussichtlichesEndeNull();

            r.AerztlDokumentArt = AerztlDokumentArt;
            r.AerztlDokumentArzt = AerztlDokumentArzt;

            if (AerztlDokumentDatum != null)
                r.AerztlDokumentDatum = (DateTime)AerztlDokumentDatum;
            else
                r.SetAerztlDokumentDatumNull();

            r.HindernRollstuhlBremsenJN = RollstuhlBremsenJN;
            r.HindernRollstuhlSitzhoseJN = RollstuhlSitzhoseJN;
            r.HindernVerlassenBettHandmanschettenJN = BettHandmanschettenJN;
            r.TatsaechlicheEndeGrund = TatsaechlicheEndeGrund;

            //2013-12-17
            r.AerztlDokumentArztTitel = AerztlDokumentArztTitel;
            r.AerztlDokumentArztVorname = AerztlDokumentArztVorname;
            r.EinrichtungsleiterTitel = EinrichtungsleiterTitel;     
            r.EinrichtungsleiterVorname = EinrichtungsleiterVorname;
            r.EinrichtungsleiterVorname = Einrichtungsleiter;
            r.AngeordnetVonTitel = AngeordnetVonTitel;
            r.AngeordnetVonVorname = AngeordnetVonVorname;
            r.AufgehobenVonTitel = AbgesetztVonTitel;
            r.AufgehobenVonVorname = AbgesetztVonVorname;
            r.HindernSitzgelSitzhoseJN = hindernSitzgelSitzhoseJN;

            r.SetEDI_BenutzerNull ();
            r.SetEDI_DatumNull();
            r.EDI_Protokoll = "";


            dsUnterbringung1.Unterbringung.AddUnterbringungRow(r);
            return r;
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

            dsUnterbringung.UnterbringungRow r = dsUnterbringung1.Unterbringung.NewUnterbringungRow();
            r.ID = Guid.NewGuid();
            r.IDAufenthalt = IDAufenthalt;
            r.Aktion = "Vornahme";
            r.AngeordnetAm = DateTime.Now;

            r.Beginn = Beginn;
            r.Dauer = Dauer;

            if (VoraussichtlichesEnde != null)
                r.VoraussichtlichesEnde = (DateTime)VoraussichtlichesEnde;
            else
                r.SetVoraussichtlichesEndeNull();

            r.Berufsgruppe = Berufsgruppe;
            r.AngeordnetVonTitel = AngeordnetVonTitel;
            r.AngeordnetVonVorname = AngeordnetVonVorname;
            r.AngeordnetVon = AngeordnetVon;
            //r.AufgehobenAm = Ende;

            if (Ende != DateTime.MinValue)
                r.AufgehobenAm = Ende;

            r.TatsaechlicheEndeGrund = TatsaechlicheEndeGrund;
            r.ENDEBerufsgruppe = EndeBerufsgruppe;
            r.AufgehobenVonTitel = EndeAngeordnetVonTitel;
            r.AufgehobenVonVorname = EndeAngeordnetVonVorname;
            r.ENDEAngeordnetVon = EndeAngeordnetVon;
            r.KlientZustimmungJN = KlientZustimmungJN;
            r.PsychischekrankheitJN = PsychischeKrankheitJN;
            r.GeistigeBehinderungJN = GeistigeBehinderungJN;
            r.MedizinischeDiagnose = MedizinischeDiagnose;
            r.ErheblicheSelbstgefaehrdungJN = SelbstgefaehrdungJN;
            r.ErheblicheFremdgefaehrdungJN = FremdgefaehrdungJN;
            r.AnmerkungVerhalten_2016 = AnmerkungVerhalten_2016;
            r.AnmerkungGutachten_2016 = AnmerkungGutachten_2016;
            r.EinzelfallmedikationJN_2016 = EinzelfallmedikationJN_2016;
            r.Einzelfallmedikation_2016 = Einzelfallmedikation_2016;
            r.DauermedikationJN_2016 = DauermedikationJN_2016;
            r.Dauermedikation_2016 = Dauermedikation_2016;
            r.HindernVerlassenBettSeitenteilenJN = HindernVerlassenBettSeitenteilenJN;
            r.HindernVerlassenBettBauchgurtJN_2016 = HindernVerlassenBettBauchgurtJN_2016;
            r.HindernVerlassenBettElektronischJN_2016 = HindernVerlassenBettElektronischJN_2016;
            r.HindernVerlassenBettHandArmgurte_2016 = HindernVerlassenBettHandArmgurte_2016;
            r.HindernVerlassenBettFussBeingurte_2016 = HindernVerlassenBettFussBeingurte_2016;
            r.HindernVerlassenBettAndereJN_2016 = HindernVerlassenBettAndereJN_2016;
            r.HindernBettVerlassen = HindernVerlassenBett;
            r.HindernSitzgelSitzhoseJN = HindernSitzgelSitzhoseJN;
            r.HindernSitzgelBauchgurtJN_2016 = HindernSitzgelBauchgurtJN_2016;
            r.HindernSitzgelBrustgurtJN_2016 = HindernSitzgelBrustgurtJN_2016;
            r.HindernSitzgelHandArmgurte_2016 = HindernSitzgelHandArmgurte_2016;
            r.HindernSitzgelTischJN = HindernSitzgelTischJN;
            r.HindernSitzgelTherapietischJN = HindernSitzgelTherapietischJN;
            r.HindernSitzgelFussBeingurte_2016 = HindernSitzgelFussBeingurte_2016;
            r.HindernSitzgelAndereJN_2016 = HindernSitzgelAndereJN_2016;
            r.HindernSitzgelegenheit = HindernSitzgelBeschr;
            r.ZurueckhaltensandrohungJN = ZurueckhaltensandrohungJN;
            r.HindernBereichFesthaltenJN_2016 = HindernBereichFesthaltenJN_2016;
            r.HindernBereichVersperrterBereichJN_2016 = HindernBereichVersperrterBereichJN_2016;
            r.HindernBereichBarriereJN_2016 = HindernBereichBarriereJN_2016;
            r.ElektronischesUeberwachungJN = ElektronischeUeberwachungJN;
            r.HindernBereichVersperrtesZimmerJN_2016 = HindernBereichVersperrtesZimmerJN_2016;
            r.HindernBereichHinderAmFortbewegenJN_2016 = HindernBereichHinderAmFortbewegenJN_2016;
            r.HindernBereichAndereJN_2016 = HindernBereichAndereJN_2016;
            r.BaulicheMassnahmen = BaulicheMassnahmen;
            r.EinrichtungsleiterTitel = EinrichtungsleiterTitel;
            r.EinrichtungsleiterVorname = EinrichtungsleiterVorname;
            r.Einrichtungsleiter = Einrichtungsleiter;

            //----------------------- Nicht-Null-Felder aus alter Version setzen
            r.AerztlDokumentArt = 0;
            r.AerztlDokumentArzt = "";
            r.HindernRollstuhlBremsenJN = false;
            r.HindernRollstuhlSitzhoseJN = false;
            r.HindernVerlassenBettHandmanschettenJN = false;
            r.AerztlDokumentArztTitel = "";
            r.AerztlDokumentArztVorname = "";
            r.EDI_Protokoll = "";
            r.SetEDI_BenutzerNull();
            r.SetEDI_DatumNull();

            //--------------------- Sonstige Felder
            r.VoraussichtlicheDauer = 0;

            dsUnterbringung1.Unterbringung.AddUnterbringungRow(r);
            return r;
        }

    }



}
