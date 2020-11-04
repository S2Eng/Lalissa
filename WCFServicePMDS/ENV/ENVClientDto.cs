using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace WCFServicePMDS
{

    [Serializable()]
    public class ENVClientDto
    {
        public Guid IDClient { get; set; }

        public string Db { get; set; }
        public string Srv { get; set; }
        public string Usr { get; set; }
        public string Pwd { get; set; }
        public bool trusted { get; set; }

        public string ConfigPathPMDS { get; set; }
        public string ConfigFilePMDS { get; set; }
    }

}

