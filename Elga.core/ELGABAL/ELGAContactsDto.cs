using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServicePMDS.BAL2.ELGABAL
{

    [Serializable()]
    public class ELGAContactsDto
    {
        public string TreatmentID { get; set; }
        public string PatientID { get; set; }

        public string creationDate { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string GdaID { get; set; }
        public string GdaDelegatorID { get; set; }
    }

}