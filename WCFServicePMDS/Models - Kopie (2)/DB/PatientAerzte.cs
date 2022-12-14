using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class PatientAerzte
    {
        public Guid Id { get; set; }
        public Guid Idpatient { get; set; }
        public Guid Idaerzte { get; set; }
        public bool? HausarztJn { get; set; }
        public bool? ZuweiserJn { get; set; }
        public bool? AufnahmearztJn { get; set; }
        public bool? BehandelnderFajn { get; set; }
        public DateTime? Von { get; set; }
        public DateTime? Bis { get; set; }

        public virtual Aerzte IdaerzteNavigation { get; set; }
        public virtual Patient IdpatientNavigation { get; set; }
    }
}