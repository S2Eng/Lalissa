using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Pdx
    {
        public Pdx()
        {
            AufenthaltPdx = new HashSet<AufenthaltPdx>();
            Pdxanamnese = new HashSet<Pdxanamnese>();
            Pdxeintrag = new HashSet<Pdxeintrag>();
            Pdxpflegemodelle = new HashSet<Pdxpflegemodelle>();
            PflegePlanPdx = new HashSet<PflegePlanPdx>();
        }

        public Guid Id { get; set; }
        public string Klartext { get; set; }
        public string Code { get; set; }
        public int? ThematischeId { get; set; }
        public bool? EntferntJn { get; set; }
        public string Definition { get; set; }
        public int? Gruppe { get; set; }
        public int LokalisierungsTyp { get; set; }
        public bool Wundejn { get; set; }
        public string Pdxkuerzel { get; set; }

        public virtual ICollection<AufenthaltPdx> AufenthaltPdx { get; set; }
        public virtual ICollection<Pdxanamnese> Pdxanamnese { get; set; }
        public virtual ICollection<Pdxeintrag> Pdxeintrag { get; set; }
        public virtual ICollection<Pdxpflegemodelle> Pdxpflegemodelle { get; set; }
        public virtual ICollection<PflegePlanPdx> PflegePlanPdx { get; set; }
    }
}