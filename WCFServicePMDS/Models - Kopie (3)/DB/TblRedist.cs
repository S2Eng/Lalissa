using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblRedist
    {
        public Guid Id { get; set; }
        public bool InUse { get; set; }
        public int PortNr { get; set; }
        public int Sort { get; set; }
        public Guid? VersionsNr { get; set; }
        public string Wcfurl { get; set; }
        public DateTime ActivatedAt { get; set; }
        public DateTime? LastCall { get; set; }
        public bool LastInstall { get; set; }
        public DateTime? LastActivation { get; set; }
        public string ServiceName { get; set; }
        public string InstallDir { get; set; }
    }
}