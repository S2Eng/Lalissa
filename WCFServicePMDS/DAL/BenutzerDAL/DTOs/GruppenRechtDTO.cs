using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class GruppenRechtDTO
    {
        public Guid Idgruppe { get; set; }
        public int Idrecht { get; set; }
        public Guid Id { get; set; }


    }

}

