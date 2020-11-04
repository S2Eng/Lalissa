using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class PflegePlanH
    {
        public Guid Id { get; set; }
        public string Aktion { get; set; }
        public Guid? IdpflegePlan { get; set; }
        public Guid? Idaufenthalt { get; set; }
        public Guid? Ideintrag { get; set; }
        public Guid? IdbenutzerErstellt { get; set; }
        public Guid? IdbenutzerGeaendert { get; set; }
        public bool? OriginalJn { get; set; }
        public DateTime? DatumErstellt { get; set; }
        public DateTime? DatumGeaendert { get; set; }
        public DateTime? StartDatum { get; set; }
        public DateTime? EndeDatum { get; set; }
        public DateTime? LetztesDatum { get; set; }
        public DateTime? LetzteEvaluierung { get; set; }
        public string Warnhinweis { get; set; }
        public string Anmerkung { get; set; }
        public string ErledigtGrund { get; set; }
        public string Text { get; set; }
        public int? Intervall { get; set; }
        public int? WochenTage { get; set; }
        public int? IntervallTyp { get; set; }
        public int? EvalTage { get; set; }
        public Guid? Idberufsstand { get; set; }
        public bool? ParalellJn { get; set; }
        public int? Dauer { get; set; }
        public bool? LokalisierungJn { get; set; }
        public bool? EinmaligJn { get; set; }
        public bool? ErledigtJn { get; set; }
        public bool? GeloeschtJn { get; set; }
        public string Lokalisierung { get; set; }
        public string LokalisierungSeite { get; set; }
        public string EintragGruppe { get; set; }
        public bool? Pdxjn { get; set; }
        public bool RmoptionalJn { get; set; }
        public Guid? Idevaluierung { get; set; }
        public DateTime? NaechsteEvaluierung { get; set; }
        public string NaechsteEvaluierungBemerkung { get; set; }
        public bool OhneZeitBezug { get; set; }
        public Guid? Idzeitbereich { get; set; }
        public DateTime? ZuErledigenBis { get; set; }
        public int EintragFlag { get; set; }
        public Guid? Idbefund { get; set; }
        public string Verordnungen { get; set; }

        public virtual Benutzer IdbenutzerErstelltNavigation { get; set; }
        public virtual Benutzer IdbenutzerGeaendertNavigation { get; set; }
    }
}