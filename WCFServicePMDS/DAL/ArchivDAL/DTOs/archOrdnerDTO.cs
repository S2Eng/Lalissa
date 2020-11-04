using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class archOrdnerDTO
    {

        public Guid Id { get; set; }
        public string Bezeichnung { get; set; }
        public bool Extern { get; set; }
        public Guid? IdordnerMain { get; set; }
        public DateTime ErstelltAm { get; set; }
        public string ErstelltVon { get; set; }
        public byte[] Icon { get; set; }
        public int Idsystemordner { get; set; }

    }

}

