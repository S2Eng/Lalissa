using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class RechtDTO
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public bool Elga { get; set; }


    }

}

