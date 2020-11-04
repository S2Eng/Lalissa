using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class PdxgruppeEintrag
    {
        public Guid Idpdx { get; set; }
        public Guid Idpdxgruppe { get; set; }
        public Guid Id { get; set; }

        public virtual Pdxgruppe IdpdxgruppeNavigation { get; set; }
    }
}