using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class BereichDTO
    {
        public Guid Id { get; set; }
        public Guid? Idabteilung { get; set; }
        public Guid? Idbereich { get; set; }
        public string Bezeichnung { get; set; }
        public bool? UnterAerztlicheFuehrungJn { get; set; }
        public int Reihenfolge { get; set; }
        public int AnzahlBetten { get; set; }
        public string Bereichstyp { get; set; }


    }

}

