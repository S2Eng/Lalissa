using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class EinrichtungDTO
    {

        public Guid Id { get; set; }
        public string Text { get; set; }
        public Guid? Idadresse { get; set; }
        public Guid? Idkontakt { get; set; }

        public string ElgaOid { get; set; }
        public bool Elgaabgeglichen { get; set; }
        public bool? IstKrankenkasse { get; set; }
        public string ElgaOrganizationOid { get; set; }
        public string ElgaOrganizationName { get; set; }

    }

}

