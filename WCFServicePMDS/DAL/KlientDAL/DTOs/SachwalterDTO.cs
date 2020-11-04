using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class SachwalterDTO
    {
        public Guid Id { get; set; }
        public Guid? Idpatient { get; set; }
        public Guid? Idadresse { get; set; }
        public Guid? Idkontakt { get; set; }
        public string Titel { get; set; }
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public bool? SachwalterJn { get; set; }
        public string Belange { get; set; }
        public DateTime? Von { get; set; }
        public DateTime? Bis { get; set; }
        public string Gericht { get; set; }
        public DateTime? BestimmtAm { get; set; }
        public string Bemerkung { get; set; }
        public Guid? Idaufenthalt { get; set; }
        public Guid? IdkontaktStammdaten { get; set; }


    }

    [Serializable()]
    public class SachwalterS1DTO
    {
        public Guid Id { get; set; }
        public Guid? Idpatient { get; set; }
        public Guid? Idadresse { get; set; }
        public Guid? Idkontakt { get; set; }
        public string Titel { get; set; }
        public string Nachname { get; set; }
        public string Vorname { get; set; }
     
    }
}

