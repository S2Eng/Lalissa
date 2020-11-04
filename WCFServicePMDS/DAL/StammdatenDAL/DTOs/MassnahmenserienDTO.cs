using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class MassnahmenserienDTO
    {

        public Guid Id { get; set; }
        public string Bezeichnung { get; set; }
        public DateTime? Z0 { get; set; }
        public DateTime? Z1 { get; set; }
        public DateTime? Z2 { get; set; }
        public DateTime? Z3 { get; set; }
        public DateTime? Z4 { get; set; }
        public DateTime? Z5 { get; set; }
        public DateTime? Z6 { get; set; }
        public DateTime? Z7 { get; set; }


    }

}

