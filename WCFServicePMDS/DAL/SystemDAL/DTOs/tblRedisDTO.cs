using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class tblRedistDTO
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

