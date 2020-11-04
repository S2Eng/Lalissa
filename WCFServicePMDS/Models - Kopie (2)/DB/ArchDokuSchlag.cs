using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class ArchDokuSchlag
    {
        public Guid Id { get; set; }
        public Guid Iddoku { get; set; }
        public string Schlagwort { get; set; }

        public virtual ArchDoku IddokuNavigation { get; set; }
    }
}