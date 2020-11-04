using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class PflegegeldstufeGueltig
    {
        public Guid Id { get; set; }
        public Guid Idpflegegeldstufe { get; set; }
        public DateTime GueltigAb { get; set; }
        public decimal? Betrag { get; set; }

        public virtual Pflegegeldstufe IdpflegegeldstufeNavigation { get; set; }
    }
}