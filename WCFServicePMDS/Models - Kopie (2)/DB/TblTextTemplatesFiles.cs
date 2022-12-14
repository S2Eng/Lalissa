using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblTextTemplatesFiles
    {
        public Guid Id { get; set; }
        public Guid IdtextTemplate { get; set; }
        public byte[] Docu { get; set; }
        public string Bezeichnung { get; set; }
        public string FileType { get; set; }

        public virtual TblTextTemplates IdtextTemplateNavigation { get; set; }
    }
}