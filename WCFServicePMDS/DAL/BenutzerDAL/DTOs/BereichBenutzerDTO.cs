using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{
    [Serializable()]
    public class BereichBenutzerDTO
    {

        public Guid Idbereich { get; set; }
        public Guid Idbenutzer { get; set; }
        public string Info { get; set; }


    }

}

