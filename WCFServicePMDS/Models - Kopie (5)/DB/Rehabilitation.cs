using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Rehabilitation
    {
        public Guid Id { get; set; }
        public Guid? Idpatient { get; set; }
        public string Beschreibung { get; set; }
        public string Ziel { get; set; }
        public string Institution { get; set; }
        public DateTime? Von { get; set; }
        public DateTime? Bis { get; set; }
        public string EndeGrund { get; set; }
        public string Bemerkung { get; set; }
        public bool? MassnahmeJn { get; set; }

        public virtual Patient IdpatientNavigation { get; set; }
    }
}