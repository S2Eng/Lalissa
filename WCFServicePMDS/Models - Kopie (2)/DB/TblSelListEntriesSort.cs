using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblSelListEntriesSort
    {
        public Guid Id { get; set; }
        public int IdselListEntry { get; set; }
        public string Idparticipant { get; set; }
        public int Sort { get; set; }

        public virtual TblSelListEntries IdselListEntryNavigation { get; set; }
    }
}