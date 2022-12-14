using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class BereichBenutzer
    {
        public Guid Idbereich { get; set; }
        public Guid Idbenutzer { get; set; }
        public string Info { get; set; }

        public virtual Benutzer IdbenutzerNavigation { get; set; }
        public virtual Bereich IdbereichNavigation { get; set; }
    }
}