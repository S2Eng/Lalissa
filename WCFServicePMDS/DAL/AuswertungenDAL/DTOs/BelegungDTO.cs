using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{
    [Serializable()]
    public class BelegungDTO
    {

        public Guid Id { get; set; }
        public Guid Idabteilung { get; set; }
        public DateTime Tag { get; set; }
        public int AnzahlBetten { get; set; }
        public int Belegung1 { get; set; }

    }

}

