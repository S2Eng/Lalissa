using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Unterbringung
    {
        public Guid Id { get; set; }
        public Guid? Idaufenthalt { get; set; }
        public string Grund { get; set; }
        public DateTime? Beginn { get; set; }
        public int? Dauer { get; set; }
        public string AngeordnetVon { get; set; }
        public DateTime? AngeordnetAm { get; set; }
        public DateTime? AufgehobenAm { get; set; }
        public bool? GefahrFuerLebenGesundheitJn { get; set; }
        public bool? EingriffUnerlaesslichJn { get; set; }
        public string AufgehobenVon { get; set; }
        public DateTime? TatsaechlicheEnde { get; set; }
        public string Aktion { get; set; }
        public int? VoraussichtlicheDauer { get; set; }
        public string Zeitraum { get; set; }
        public bool? PsychischekrankheitJn { get; set; }
        public bool? GeistigeBehinderungJn { get; set; }
        public string MedDiagnIcd { get; set; }
        public string MedizinischeDiagnose { get; set; }
        public bool? ErheblicheSelbstgefaehrdungJn { get; set; }
        public bool? ErheblicheFremdgefaehrdungJn { get; set; }
        public string EingriffUnerlaesslichBeschreibung { get; set; }
        public string Einrichtungsleiter { get; set; }
        public bool? ElektronischesUeberwachungJn { get; set; }
        public bool? ZurueckhaltensandrohungJn { get; set; }
        public bool? VerschlosseneTuerJn { get; set; }
        public bool? DrehknopfJn { get; set; }
        public bool? CodierungJn { get; set; }
        public bool? LabyrinthJn { get; set; }
        public string BaulicheMassnahmen { get; set; }
        public bool? HindernRollstuhlGurtenJn { get; set; }
        public bool? HindernRollstuhTischJn { get; set; }
        public bool? HindernRollstuhTherapietischJn { get; set; }
        public string HindernRollstuhl { get; set; }
        public bool? HindernSitzgelGurtenJn { get; set; }
        public bool? HindernSitzgelTischJn { get; set; }
        public bool? HindernSitzgelTherapietischJn { get; set; }
        public string HindernSitzgelegenheit { get; set; }
        public bool? HindernVerlassenBettSeitenteilenJn { get; set; }
        public bool? HindernVerlassenBettGurtenJn { get; set; }
        public string HindernBettVerlassen { get; set; }
        public bool? MedikFreihBeschraenkungJn { get; set; }
        public string MedikBezeichnung { get; set; }
        public bool? GesendetAnBewohnervertreterJn { get; set; }
        public bool? GesendetAnGesetzVertreterJn { get; set; }
        public bool? GesendetAnSelbstGewVertreterJn { get; set; }
        public bool? GesendetAnVertrauenspersonJn { get; set; }
        public bool? KlientZustimmungJn { get; set; }
        public int? AufgehobeneMassnahmeInfo { get; set; }
        public int? Berufsgruppe { get; set; }
        public string Anmerkung { get; set; }
        public int? Endeberufsgruppe { get; set; }
        public string EndeangeordnetVon { get; set; }
        public bool? EndegesendetAnBewohnervertreterJn { get; set; }
        public bool? EndegesendetAnGesetzVertreterJn { get; set; }
        public bool? EndegesendetAnSelbstGewVertreterJn { get; set; }
        public bool? EndegesendetAnVertrauenspersonJn { get; set; }
        public DateTime? VoraussichtlichesEnde { get; set; }
        public int? Info { get; set; }
        public int AerztlDokumentArt { get; set; }
        public string AerztlDokumentArzt { get; set; }
        public DateTime? AerztlDokumentDatum { get; set; }
        public bool HindernRollstuhlBremsenJn { get; set; }
        public bool HindernRollstuhlSitzhoseJn { get; set; }
        public bool HindernVerlassenBettHandmanschettenJn { get; set; }
        public int TatsaechlicheEndeGrund { get; set; }
        public string AerztlDokumentArztTitel { get; set; }
        public string AerztlDokumentArztVorname { get; set; }
        public string AngeordnetVonTitel { get; set; }
        public string AngeordnetVonVorname { get; set; }
        public string AufgehobenVonTitel { get; set; }
        public string AufgehobenVonVorname { get; set; }
        public bool? HindernSitzgelSitzhoseJn { get; set; }
        public DateTime? EdiDatum { get; set; }
        public Guid? EdiBenutzer { get; set; }
        public string EinrichtungsleiterTitel { get; set; }
        public string EinrichtungsleiterVorname { get; set; }
        public string EdiProtokoll { get; set; }
        public string AnmerkungGutachten2016 { get; set; }
        public string AnmerkungVerhalten2016 { get; set; }
        public int? HindernVerlassenBettHandArmgurte2016 { get; set; }
        public int? HindernVerlassenBettFussBeingurte2016 { get; set; }
        public bool? HindernVerlassenBettAndereJn2016 { get; set; }
        public bool? HindernVerlassenBettBauchgurtJn2016 { get; set; }
        public bool? HindernVerlassenBettElektronischJn2016 { get; set; }
        public int? HindernSitzgelHandArmgurte2016 { get; set; }
        public int? HindernSitzgelFussBeingurte2016 { get; set; }
        public bool? HindernSitzgelAndereJn2016 { get; set; }
        public bool? HindernSitzgelBauchgurtJn2016 { get; set; }
        public bool? HindernSitzgelBrustgurtJn2016 { get; set; }
        public bool? HindernBereichFesthaltenJn2016 { get; set; }
        public bool? HindernBereichBarriereJn2016 { get; set; }
        public bool? HindernBereichVersperrterBereichJn2016 { get; set; }
        public bool? HindernBereichVersperrtesZimmerJn2016 { get; set; }
        public bool? HindernBereichHinderAmFortbewegenJn2016 { get; set; }
        public bool? HindernBereichAndereJn2016 { get; set; }
        public bool? EinzelfallmedikationJn2016 { get; set; }
        public string Einzelfallmedikation2016 { get; set; }
        public bool? DauermedikationJn2016 { get; set; }
        public string Dauermedikation2016 { get; set; }

        public virtual Aufenthalt IdaufenthaltNavigation { get; set; }
    }
}