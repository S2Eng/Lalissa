using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Massnahmenserien
    {
        public Massnahmenserien()
        {
            EintragZusatz = new HashSet<EintragZusatz>();
        }

        public Guid Id { get; set; }
        public string Bezeichnung { get; set; }
        public DateTime? Z0 { get; set; }
        public DateTime? Z1 { get; set; }
        public DateTime? Z2 { get; set; }
        public DateTime? Z3 { get; set; }
        public DateTime? Z4 { get; set; }
        public DateTime? Z5 { get; set; }
        public DateTime? Z6 { get; set; }
        public DateTime? Z7 { get; set; }

        public virtual ICollection<EintragZusatz> EintragZusatz { get; set; }
    }
}