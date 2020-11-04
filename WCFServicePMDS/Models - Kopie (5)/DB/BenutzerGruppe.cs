using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class BenutzerGruppe
    {
        public Guid Idbenutzer { get; set; }
        public Guid Idgruppe { get; set; }
        public Guid Id { get; set; }
    }
}