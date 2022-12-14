using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class ArchObject
    {
        public Guid Id { get; set; }
        public Guid Iddoku { get; set; }
        public Guid Idobject { get; set; }
        public Guid? IdselList { get; set; }

        public virtual ArchDoku IddokuNavigation { get; set; }
    }
}