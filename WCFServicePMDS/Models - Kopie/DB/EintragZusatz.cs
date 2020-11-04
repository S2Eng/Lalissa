using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class EintragZusatz
    {
        public Guid Ideintrag { get; set; }
        public Guid Idabteilung { get; set; }
        public int? Intervall { get; set; }
        public int? WochenTage { get; set; }
        public int? IntervallTyp { get; set; }
        public int? EvalTage { get; set; }
        public Guid? Idberufsstand { get; set; }
        public bool? ParalellJn { get; set; }
        public int? Dauer { get; set; }
        public bool? LokalisierungJn { get; set; }
        public bool? EinmaligJn { get; set; }
        public bool RmoptionalJn { get; set; }
        public bool UntertaegigJn { get; set; }
        public Guid? Idmassnahmenserien { get; set; }
        public Guid? IdzeitbereichSerien { get; set; }
        public Guid? Idzeitbereich { get; set; }

        public virtual Eintrag IdeintragNavigation { get; set; }
        public virtual Massnahmenserien IdmassnahmenserienNavigation { get; set; }
        public virtual Zeitbereich IdzeitbereichNavigation { get; set; }
        public virtual ZeitbereichSerien IdzeitbereichSerienNavigation { get; set; }
    }
}