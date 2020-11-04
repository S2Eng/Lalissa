using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class DBLizenzDTO
    {
        public int Id { get; set; }
        public string Lizenz { get; set; }
        public Guid Idguid { get; set; }


    }

}

