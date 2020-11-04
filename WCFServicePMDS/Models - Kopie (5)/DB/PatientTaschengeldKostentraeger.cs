using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class PatientTaschengeldKostentraeger
    {
        public Guid Id { get; set; }
        public Guid Idpatient { get; set; }
        public Guid Idkostentraeger { get; set; }
        public DateTime GueltigAb { get; set; }
        public DateTime? GueltigBis { get; set; }
        public decimal? Betrag { get; set; }
        public DateTime ErfasstAm { get; set; }
        public Guid Idbenutzer { get; set; }
        public DateTime? AbgerechnetBis { get; set; }

        public virtual Kostentraeger IdkostentraegerNavigation { get; set; }
        public virtual Patient IdpatientNavigation { get; set; }
    }
}