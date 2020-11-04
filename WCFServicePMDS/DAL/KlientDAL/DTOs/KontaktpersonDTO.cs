using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{
    [Serializable()]
    public class KontaktpersonDTO
    {

        public Guid Id { get; set; }
        public Guid Idpatient { get; set; }
        public Guid? Idadresse { get; set; }
        public Guid? Idkontakt { get; set; }
        public string Titel { get; set; }
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public bool? VerstaendigenJn { get; set; }
        public string Kontaktart { get; set; }
        public string Verwandtschaft { get; set; }
        public bool? ExternerDienstleisterJn { get; set; }
        public Guid? IdkontaktStammdaten { get; set; }

    }

    [Serializable()]
    public class KontaktpersonS1DTO
    {

        public Guid Id { get; set; }
        public Guid Idpatient { get; set; }
        public Guid? Idadresse { get; set; }
        public Guid? Idkontakt { get; set; }
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public string Verwandtschaft { get; set; }
        public bool? VerstaendigenJn { get; set; }



    }

}

