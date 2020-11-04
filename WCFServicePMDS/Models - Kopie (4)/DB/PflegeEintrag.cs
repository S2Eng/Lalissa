using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class PflegeEintrag
    {
        public Guid Id { get; set; }
        public Guid Idaufenthalt { get; set; }
        public Guid? IdpflegePlan { get; set; }
        public Guid? Idbenutzer { get; set; }
        public Guid? Ideintrag { get; set; }
        public Guid? Idberufsstand { get; set; }
        public DateTime? DatumErstellt { get; set; }
        public DateTime? Zeitpunkt { get; set; }
        public string Text { get; set; }
        public int? IstDauer { get; set; }
        public bool? DurchgefuehrtJn { get; set; }
        public int? EintragsTyp { get; set; }
        public int? Wichtig { get; set; }
        public Guid? Idwichtig { get; set; }
        public Guid? Idevaluierung { get; set; }
        public int? EvalStatus { get; set; }
        public string PflegeplanText { get; set; }
        public Guid? Idsollberufsstand { get; set; }
        public Guid? IdpflegePlanBerufsstand { get; set; }
        public Guid? IdpflegeplanH { get; set; }
        public int? Solldauer { get; set; }
        public Guid? Idbereich { get; set; }
        public Guid? Idabteilung { get; set; }
        public int? PflegePlanDauer { get; set; }
        public Guid? Iddekurs { get; set; }
        public bool Cc { get; set; }
        public Guid? Idextern { get; set; }
        public DateTime? StartdatumNeu { get; set; }
        public string TextRtf { get; set; }
        public bool AbgezeichnetJn { get; set; }
        public Guid? AbgezeichnetIdbenutzer { get; set; }
        public DateTime? AbgezeichnetAm { get; set; }
        public int Dekursherkunft { get; set; }
        public bool AbzeichnenJn { get; set; }
        public bool HagpflichtigJn { get; set; }
        public Guid? Idbefund { get; set; }
        public string LogInNameFrei { get; set; }
        public string TextHistorie { get; set; }
        public string TextHistorieRtf { get; set; }
        public Guid? Idgruppe { get; set; }

        public virtual Abteilung IdabteilungNavigation { get; set; }
        public virtual Aufenthalt IdaufenthaltNavigation { get; set; }
        public virtual Benutzer IdbenutzerNavigation { get; set; }
        public virtual Bereich IdbereichNavigation { get; set; }
        public virtual Eintrag IdeintragNavigation { get; set; }
        public virtual PflegePlan IdpflegePlanNavigation { get; set; }
    }
}