using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class StandardProzeduren
    {
        public StandardProzeduren()
        {
            EintragStandardprozeduren = new HashSet<EintragStandardprozeduren>();
            Sp = new HashSet<Sp>();
            SpdynRep = new HashSet<SpdynRep>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool ShowPrintDialog { get; set; }
        public bool NotfallJn { get; set; }
        public bool Unterdrücken { get; set; }

        public virtual ICollection<EintragStandardprozeduren> EintragStandardprozeduren { get; set; }
        public virtual ICollection<Sp> Sp { get; set; }
        public virtual ICollection<SpdynRep> SpdynRep { get; set; }
    }
}