using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblVersions
    {
        public string VersionNr { get; set; }
        public DateTime Created { get; set; }
        public string CreatedFrom { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string Idapplication { get; set; }
        public string Idparticipant { get; set; }
        public string Classification { get; set; }
        public string Description { get; set; }
    }
}