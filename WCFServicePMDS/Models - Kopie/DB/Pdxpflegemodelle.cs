using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Pdxpflegemodelle
    {
        public Guid Id { get; set; }
        public Guid Idpdx { get; set; }
        public Guid Idpflegemodelle { get; set; }

        public virtual Pdx IdpdxNavigation { get; set; }
        public virtual Pflegemodelle IdpflegemodelleNavigation { get; set; }
    }
}