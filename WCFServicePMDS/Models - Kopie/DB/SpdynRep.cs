using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class SpdynRep
    {
        public Guid Id { get; set; }
        public Guid IdstandardProzeduren { get; set; }
        public string DynRep { get; set; }

        public virtual StandardProzeduren IdstandardProzedurenNavigation { get; set; }
    }
}