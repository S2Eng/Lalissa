using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblTextTemplates
    {
        public TblTextTemplates()
        {
            TblTextTemplatesFiles = new HashSet<TblTextTemplatesFiles>();
        }

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

        public virtual ICollection<TblTextTemplatesFiles> TblTextTemplatesFiles { get; set; }
    }
}