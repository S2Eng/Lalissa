using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class KontaktDTO
    {
        public Guid Id { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Mobil { get; set; }
        public string Andere { get; set; }
        public string Email { get; set; }
        public string Ansprechpartner { get; set; }
        public string Zusatz1 { get; set; }
        public string Zusatz2 { get; set; }
        public string Zusatz3 { get; set; }

    }

}

