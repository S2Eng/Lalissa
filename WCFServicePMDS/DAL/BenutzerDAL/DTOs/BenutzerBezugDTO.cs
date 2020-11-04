using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{
    [Serializable()]
    public class BenutzerBezugDTO
    {

        public Guid Idbenutzer { get; set; }
        public Guid IdaufenthaltVerlauf { get; set; }
        public Guid Id { get; set; }

    }

}

