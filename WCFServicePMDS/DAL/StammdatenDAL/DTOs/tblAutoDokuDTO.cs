using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{


    [Serializable()]
    public class tblAutoDokuDTO
    {

        public Guid Id { get; set; }
        public string Typ { get; set; }
        public string DocuRtf { get; set; }
        public DateTime ErstelltAm { get; set; }
        public string ErstelltVon { get; set; }
        public string Html { get; set; }
        public string Txt { get; set; }
        public string IdresTitle { get; set; }
        public string Language { get; set; }

    }

}

