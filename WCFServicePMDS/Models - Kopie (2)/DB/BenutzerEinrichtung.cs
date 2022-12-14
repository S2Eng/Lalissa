using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class BenutzerEinrichtung
    {
        public Guid Id { get; set; }
        public Guid Idbenutzer { get; set; }
        public Guid Ideinrichtung { get; set; }
        public bool Default { get; set; }

        public virtual Benutzer IdbenutzerNavigation { get; set; }
        public virtual Klinik IdeinrichtungNavigation { get; set; }
    }
}