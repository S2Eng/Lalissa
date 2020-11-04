using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class ZusatzEintrag
    {
        public ZusatzEintrag()
        {
            ZusatzGruppeEintrag = new HashSet<ZusatzGruppeEintrag>();
        }

        public string Id { get; set; }
        public string Bezeichnung { get; set; }
        public int? Typ { get; set; }
        public string ListenEintraege { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public int FeldNr { get; set; }
        public int ElgaId { get; set; }
        public string ElgaCode { get; set; }
        public string ElgaCodeSystem { get; set; }
        public string ElgaDisplayName { get; set; }
        public string ElgaUnit { get; set; }
        public string ElgaVersion { get; set; }

        public virtual ICollection<ZusatzGruppeEintrag> ZusatzGruppeEintrag { get; set; }
    }
}