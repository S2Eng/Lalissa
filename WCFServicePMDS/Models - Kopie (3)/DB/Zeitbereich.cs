using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Zeitbereich
    {
        public Zeitbereich()
        {
            EintragZusatz = new HashSet<EintragZusatz>();
            PflegePlan = new HashSet<PflegePlan>();
            ZeitbereichSerienIdzeitbereich0Navigation = new HashSet<ZeitbereichSerien>();
            ZeitbereichSerienIdzeitbereich1Navigation = new HashSet<ZeitbereichSerien>();
            ZeitbereichSerienIdzeitbereich2Navigation = new HashSet<ZeitbereichSerien>();
            ZeitbereichSerienIdzeitbereich3Navigation = new HashSet<ZeitbereichSerien>();
            ZeitbereichSerienIdzeitbereich4Navigation = new HashSet<ZeitbereichSerien>();
            ZeitbereichSerienIdzeitbereich5Navigation = new HashSet<ZeitbereichSerien>();
            ZeitbereichSerienIdzeitbereich6Navigation = new HashSet<ZeitbereichSerien>();
            ZeitbereichSerienIdzeitbereich7Navigation = new HashSet<ZeitbereichSerien>();
        }

        public Guid Id { get; set; }
        public string Bezeichnung { get; set; }
        public DateTime Von { get; set; }
        public DateTime Bis { get; set; }

        public virtual ICollection<EintragZusatz> EintragZusatz { get; set; }
        public virtual ICollection<PflegePlan> PflegePlan { get; set; }
        public virtual ICollection<ZeitbereichSerien> ZeitbereichSerienIdzeitbereich0Navigation { get; set; }
        public virtual ICollection<ZeitbereichSerien> ZeitbereichSerienIdzeitbereich1Navigation { get; set; }
        public virtual ICollection<ZeitbereichSerien> ZeitbereichSerienIdzeitbereich2Navigation { get; set; }
        public virtual ICollection<ZeitbereichSerien> ZeitbereichSerienIdzeitbereich3Navigation { get; set; }
        public virtual ICollection<ZeitbereichSerien> ZeitbereichSerienIdzeitbereich4Navigation { get; set; }
        public virtual ICollection<ZeitbereichSerien> ZeitbereichSerienIdzeitbereich5Navigation { get; set; }
        public virtual ICollection<ZeitbereichSerien> ZeitbereichSerienIdzeitbereich6Navigation { get; set; }
        public virtual ICollection<ZeitbereichSerien> ZeitbereichSerienIdzeitbereich7Navigation { get; set; }
    }
}