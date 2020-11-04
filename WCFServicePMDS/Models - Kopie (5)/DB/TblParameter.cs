using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblParameter
    {
        public string Bezeichnung { get; set; }
        public string SqlParameter { get; set; }
        public bool TextParameter { get; set; }
    }
}