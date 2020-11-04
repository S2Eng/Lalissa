using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblAutoDoku
    {
        public Guid Id { get; set; }
        public string Typ { get; set; }
        public string DocuRtf { get; set; }
        public DateTime ErstelltAm { get; set; }
        public string ErstelltVon { get; set; }
        public string Html { get; set; }
        public string Txt { get; set; }
        public string IdresTitle { get; set; }
        public string Language { get; set; }
    }
}