using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblAdjust
    {
        public string Setting { get; set; }
        public string Client { get; set; }
        public bool UsrSetting { get; set; }
        public string Type { get; set; }
        public string Str { get; set; }
        public double Dbl { get; set; }
        public bool Bool { get; set; }
        public DateTime? Dat { get; set; }
        public byte[] Byt { get; set; }
    }
}