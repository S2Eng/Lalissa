using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class DBVersionDTO
    {

        public int Id { get; set; }
        public int Version { get; set; }
        public string ScriptVersion { get; set; }

    }

}

