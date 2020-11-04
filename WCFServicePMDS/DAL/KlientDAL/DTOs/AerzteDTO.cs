using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{
    [Serializable()]
    public class AerzteDTO
    {

        public Guid Id { get; set; }
        public Guid? Idadresse { get; set; }
        public Guid? Idkontakt { get; set; }
        public string Titel { get; set; }
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public string Fachrichtung { get; set; }

        public bool Elgaabgeglichen { get; set; }
        public bool Elgahausarzt { get; set; }
        public string ElgaOid { get; set; }
        public string ElgaOrganizationOid { get; set; }
        public string ElgaOrganizationName { get; set; }
        public bool IstOrganisation { get; set; }


    }

}

