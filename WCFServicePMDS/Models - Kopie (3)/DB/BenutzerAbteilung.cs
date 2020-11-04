using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class BenutzerAbteilung
    {
        public Guid Idabteilung { get; set; }
        public Guid Idbenutzer { get; set; }
        public Guid Id { get; set; }
    }
}