using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class ZeitbereichSerien
    {
        public ZeitbereichSerien()
        {
            EintragZusatz = new HashSet<EintragZusatz>();
        }

        public Guid Id { get; set; }
        public string Bezeichnung { get; set; }
        public Guid? Idzeitbereich0 { get; set; }
        public Guid? Idzeitbereich1 { get; set; }
        public Guid? Idzeitbereich2 { get; set; }
        public Guid? Idzeitbereich3 { get; set; }
        public Guid? Idzeitbereich4 { get; set; }
        public Guid? Idzeitbereich5 { get; set; }
        public Guid? Idzeitbereich6 { get; set; }
        public Guid? Idzeitbereich7 { get; set; }

        public virtual Zeitbereich Idzeitbereich0Navigation { get; set; }
        public virtual Zeitbereich Idzeitbereich1Navigation { get; set; }
        public virtual Zeitbereich Idzeitbereich2Navigation { get; set; }
        public virtual Zeitbereich Idzeitbereich3Navigation { get; set; }
        public virtual Zeitbereich Idzeitbereich4Navigation { get; set; }
        public virtual Zeitbereich Idzeitbereich5Navigation { get; set; }
        public virtual Zeitbereich Idzeitbereich6Navigation { get; set; }
        public virtual Zeitbereich Idzeitbereich7Navigation { get; set; }
        public virtual ICollection<EintragZusatz> EintragZusatz { get; set; }
    }
}