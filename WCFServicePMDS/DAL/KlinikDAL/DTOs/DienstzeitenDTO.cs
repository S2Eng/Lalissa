using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class DienstzeitenDTO
    {
        public Guid Id { get; set; }
        public Guid Idabteilung { get; set; }
        public string Bezeichnung { get; set; }
        public DateTime Von { get; set; }
        public DateTime Bis { get; set; }
        public int Reihenfolge { get; set; }
        public string VerwendenIn { get; set; }
        public Guid Idguid { get; set; }


    }

}

