using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class QuickMeldung
    {
        public Guid Id { get; set; }
        public string Bezeichnung { get; set; }
        public Guid? Ideintrag { get; set; }
        public Guid Idabteilung { get; set; }

        public virtual Eintrag IdeintragNavigation { get; set; }
    }
}