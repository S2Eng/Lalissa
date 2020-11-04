using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblQueryJoinsTemp
    {
        public Guid Idguid { get; set; }
        public string FromTable { get; set; }
        public string FromColumn { get; set; }
        public string ToTable { get; set; }
        public string ToColumn { get; set; }
        public int Order { get; set; }
        public string TypJoin { get; set; }
        public bool AlwaysDoJoin { get; set; }
    }
}