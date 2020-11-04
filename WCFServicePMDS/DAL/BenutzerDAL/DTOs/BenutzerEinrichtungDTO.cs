using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class BenutzerEinrichtungDTO
    {

        public Guid Id { get; set; }
        public Guid Idbenutzer { get; set; }
        public Guid Ideinrichtung { get; set; }
        public bool Default { get; set; }

    }

}

