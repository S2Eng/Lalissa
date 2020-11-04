using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class BenutzerBezug
    {
        public Guid Idbenutzer { get; set; }
        public Guid IdaufenthaltVerlauf { get; set; }
        public Guid Id { get; set; }
    }
}