using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Belegung
    {
        public Guid Id { get; set; }
        public Guid Idabteilung { get; set; }
        public DateTime Tag { get; set; }
        public int AnzahlBetten { get; set; }
        public int Belegung1 { get; set; }

        public virtual Abteilung IdabteilungNavigation { get; set; }
    }
}