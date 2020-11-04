using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class tblTextTemplatesDTO
    {
        public Guid Id { get; set; }
        public string Bezeichnung { get; set; }
        public string Txt { get; set; }
        public string Type { get; set; }
        public DateTime ErstelltAm { get; set; }
        public string ErstelltVon { get; set; }
        public string Betreff { get; set; }
        public string An { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public string FromPostfach { get; set; }
        public string LstIdpatienten { get; set; }
        public string LstIdbenutzer { get; set; }
        public string LstCategories { get; set; }


    }

}

