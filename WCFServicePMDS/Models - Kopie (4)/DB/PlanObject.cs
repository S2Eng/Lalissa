using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class PlanObject
    {
        public Guid Id { get; set; }
        public Guid Idplan { get; set; }
        public Guid Idobject { get; set; }
        public Guid? IdselList { get; set; }
        public string Status { get; set; }

        public virtual Plan IdplanNavigation { get; set; }
    }
}