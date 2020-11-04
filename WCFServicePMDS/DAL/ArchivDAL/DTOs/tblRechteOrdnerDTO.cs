using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class tblRechteOrdnerDTO
    {
        public Guid Id { get; set; }
        public Guid Idordner { get; set; }
        public Guid Idgruppe { get; set; }


    }

}

