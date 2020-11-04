using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{
    [Serializable()]
    public class BenutzerAbteilungDTO
    {

        public Guid Idabteilung { get; set; }
        public Guid Idbenutzer { get; set; }
        public Guid Id { get; set; }

    }

}

