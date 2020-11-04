using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServicePMDS.BAL2.ELGABAL
{

    [Serializable()]
    public class ELGAPidsDTO
    {
        public Guid ID { get; set; }
        public string patientID { get; set; }
        public string patientIDType { get; set; }
        public int ehrPIDType { get; set; }
        public string authUniversalID { get; set; }

    }

}

