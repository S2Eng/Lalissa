using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class PatientLeistungsplan
    {
        public Guid Id { get; set; }
        public Guid Idpatient { get; set; }
        public Guid Idleistungskatalog { get; set; }
        public bool ImVorausJn { get; set; }
        public DateTime GueltigAb { get; set; }
        public DateTime? GueltigBis { get; set; }
        public DateTime? ErfasstAm { get; set; }
        public Guid? Idbenutzer { get; set; }
        public DateTime? AbgerechnetBis { get; set; }
        public bool StornoJn { get; set; }
        public Guid? Idklinik { get; set; }

        public virtual Leistungskatalog IdleistungskatalogNavigation { get; set; }
        public virtual Patient IdpatientNavigation { get; set; }
    }
}