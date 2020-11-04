using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class QuickFilter
    {
        public Guid Id { get; set; }
        public string Bezeichnung { get; set; }
        public bool? MassnahmeJn { get; set; }
        public Guid? Ideintrag { get; set; }
        public bool? BezugspersonJn { get; set; }
        public Guid? Idbenutzer { get; set; }
        public bool? ZeitraumJn { get; set; }
        public int? Tagevorher { get; set; }
        public int? Tagenachher { get; set; }
        public bool? RueckgemeldeteTermineJn { get; set; }
        public bool? AbwBerufstandJn { get; set; }
        public string Massnahmen { get; set; }
        public bool? TypJn { get; set; }
        public int? EintragTyp { get; set; }
        public string Tooltip { get; set; }
        public Guid? Idabteilung { get; set; }
        public bool? BenutzenInInterventionJn { get; set; }
        public bool? BenutzenInEvaluierungJn { get; set; }
        public int? OhneZeitBezug { get; set; }
        public int? Reihenfolge { get; set; }
        public string KeyLayout { get; set; }
        public string KeyQuickFilter { get; set; }
        public bool? BereichIntervention { get; set; }
        public bool? BereichÜbergabe { get; set; }
        public string LstErstelltVonBerufgruppe { get; set; }
        public string LstWichtigFürBerufsgruppe { get; set; }
        public bool BenutzenInDekursJn { get; set; }
        public bool BereichDekurs { get; set; }
        public int ShowCc { get; set; }
        public string LstZusatzwerte { get; set; }
        public string LstZeitbezug { get; set; }
        public string LstHerkunftPlanungsEintrag { get; set; }
        public int AbzeichnenJn { get; set; }
        public string LstInterventionsTyp { get; set; }
        public bool IsStandard { get; set; }
        public string LstBerufsstand { get; set; }
        public string LstBsquickfilter { get; set; }
        public string IdinterventionEinzel { get; set; }
        public string IdinterventionBereich { get; set; }
        public string IdbereichEinzel { get; set; }
        public string IdbereichBereich { get; set; }
        public string IddekursEinzel { get; set; }
        public string IddekursBereich { get; set; }

        public virtual Eintrag IdeintragNavigation { get; set; }
    }
}