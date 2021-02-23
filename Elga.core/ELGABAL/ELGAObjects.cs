using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServicePMDS.BAL2.ELGABAL
{

    [Serializable()]
    public class ObjectDTO
    {
        public string IDELgaGda { get; set; }

        public string NachNameFirma { get; set; }
        public string Vorname { get; set; }
        public string Title { get; set; }
        public string SozVersNrLocalPatID { get; set; }
        public Nullable<DateTime> birthdate { get; set; }
        public bool isOrganisation { get; set; }
        public string Fachrichtung { get; set;  }

        public string Zip { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNr { get; set; }
        public string Country { get; set; }
        public string Tel { get; set; }

        public List<AdressDto> lAdresses { get; set; }
    }
    [Serializable()]
    public class AdressDto
    {
        public string ID { get; set; }
        public string Status { get; set; }
        public string State { get; set; }

        public string Street { get; set; }
        public string StreetNr { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Tel { get; set; }
    }

}

