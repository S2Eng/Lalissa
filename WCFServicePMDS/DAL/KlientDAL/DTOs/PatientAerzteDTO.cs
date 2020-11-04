using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class PatientAerzteDTO
    {

        public Guid Id { get; set; }
        public Guid Idpatient { get; set; }
        public Guid Idaerzte { get; set; }
        public bool? HausarztJn { get; set; }
        public bool? ZuweiserJn { get; set; }
        public bool? AufnahmearztJn { get; set; }
        public bool? BehandelnderFajn { get; set; }
        public DateTime? Von { get; set; }
        public DateTime? Bis { get; set; }

    }

}

