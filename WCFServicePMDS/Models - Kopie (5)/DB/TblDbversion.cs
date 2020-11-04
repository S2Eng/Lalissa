using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblDbversion
    {
        public DateTime VersionDate { get; set; }
        public string Description { get; set; }
    }
}