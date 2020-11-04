using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class PatientenBemerkungDTO
    {

        public Guid Id { get; set; }
        public Guid? Idpatient { get; set; }
        public string Bemerkung { get; set; }
        public Guid? Idbenutzer { get; set; }
        public DateTime? Datum { get; set; }
        public bool IstDekurs { get; set; }

    }

}

