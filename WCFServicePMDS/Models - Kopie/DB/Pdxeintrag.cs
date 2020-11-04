using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Pdxeintrag
    {
        public Guid Id { get; set; }
        public Guid? Idpdx { get; set; }
        public Guid? Ideintrag { get; set; }
        public Guid? Idabteilung { get; set; }

        public virtual Abteilung IdabteilungNavigation { get; set; }
        public virtual Eintrag IdeintragNavigation { get; set; }
        public virtual Pdx IdpdxNavigation { get; set; }
    }
}