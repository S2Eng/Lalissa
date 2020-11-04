using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class TextbausteineDTO
    {

        public Guid Id { get; set; }
        public string Kurzbezeichnung { get; set; }
        public string Berufsgruppen { get; set; }
        //public string TextRtf { get; set; }
        public DateTime ErstelltAm { get; set; }
        public string ErstelltVon { get; set; }

    }

}

