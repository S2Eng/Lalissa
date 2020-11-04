using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WCFServicePMDS.BAL2.ELGABAL
{

    [Serializable()]
    public class ELGAErrorDTO
    {
        public string errTxt { get; set; }
        public string code { get; set; }
        public string location { get; set; }
        public string typeCode { get; set; }
        public string classCode { get; set; }
        public string moodCode { get; set; }
        public string queryResponseCode { get; set; }


        public string QueryResponseCode { get => queryResponseCode; set => queryResponseCode = value; }

    }

}

