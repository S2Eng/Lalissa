using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class PlanAnhang
    {
        public Guid Id { get; set; }
        public Guid Idplan { get; set; }
        public byte[] Doku { get; set; }
        public string Bezeichnung { get; set; }
        public string DateiTyp { get; set; }

        public virtual Plan IdplanNavigation { get; set; }
    }
}