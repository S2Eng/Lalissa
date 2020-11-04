using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class ZeitbereichDTO
    {


        public Guid Id { get; set; }
        public string Bezeichnung { get; set; }
        public DateTime Von { get; set; }
        public DateTime Bis { get; set; }

    }

}

