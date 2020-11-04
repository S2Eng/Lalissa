using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class BillHeader
    {
        public string Id { get; set; }
        public string DbCalc { get; set; }
        public string Protokoll { get; set; }
        public Guid? Idklinik { get; set; }
    }
}