using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    public class tblSuchtgiftschrankSchlüsselDTO
    {

        public Guid Id { get; set; }
        public string UserÜbergeber { get; set; }
        public string UserÜbergeberPool { get; set; }
        public string UserÜbernehmer { get; set; }
        public string UserÜbernehmerPool { get; set; }
        public DateTime Am { get; set; }
        public string Anmerkung { get; set; }
        public Guid Idabteilung { get; set; }

    }

}

