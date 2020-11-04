using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblRechteOrdner
    {
        public Guid Id { get; set; }
        public Guid Idordner { get; set; }
        public Guid Idgruppe { get; set; }

        public virtual TblOrdner IdordnerNavigation { get; set; }
    }
}