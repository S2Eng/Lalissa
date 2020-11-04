using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class AufenthaltPdx
    {
        public AufenthaltPdx()
        {
            PflegePlanPdx = new HashSet<PflegePlanPdx>();
        }

        public Guid Id { get; set; }
        public Guid? Idaufenthalt { get; set; }
        public Guid? Idpdx { get; set; }
        public DateTime? StartDatum { get; set; }
        public DateTime? EndeDatum { get; set; }
        public string ErledigtGrund { get; set; }
        public bool? ErledigtJn { get; set; }
        public Guid? IdbenutzerErstellt { get; set; }
        public Guid? IdbenutzerBeendet { get; set; }
        public DateTime? DatumErstellt { get; set; }
        public DateTime? DatumGeaendert { get; set; }
        public bool LokalisierungJn { get; set; }
        public string Lokalisierung { get; set; }
        public string LokalisierungSeite { get; set; }
        public string Resourceklient { get; set; }
        public DateTime? NaechsteEvaluierung { get; set; }
        public string NaechsteEvaluierungBemerkung { get; set; }
        public Guid? Idevaluierung { get; set; }
        public bool Wundejn { get; set; }

        public virtual Aufenthalt IdaufenthaltNavigation { get; set; }
        public virtual Pdx IdpdxNavigation { get; set; }
        public virtual ICollection<PflegePlanPdx> PflegePlanPdx { get; set; }
    }
}