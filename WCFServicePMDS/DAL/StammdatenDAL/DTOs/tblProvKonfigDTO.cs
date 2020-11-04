using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class tblProvKonfigDTO
    {

        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

    }

}

