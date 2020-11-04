using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class AbteilungDTO
    {
        public Guid Id { get; set; }
        public string Bezeichnung { get; set; }
        public Guid? Idklinik { get; set; }
        public Guid? Idkontakt { get; set; }
        public bool RmoptionalJn { get; set; }
        public int Reihenfolge { get; set; }
        public bool Basisabteilung { get; set; }


    }

}

