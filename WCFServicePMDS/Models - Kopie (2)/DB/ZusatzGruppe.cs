using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class ZusatzGruppe
    {
        public ZusatzGruppe()
        {
            ZusatzGruppeEintrag = new HashSet<ZusatzGruppeEintrag>();
        }

        public string Id { get; set; }
        public string Bezeichnung { get; set; }

        public virtual ICollection<ZusatzGruppeEintrag> ZusatzGruppeEintrag { get; set; }
    }
}