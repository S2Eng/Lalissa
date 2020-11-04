using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Textbausteine
    {
        public Guid Id { get; set; }
        public string Kurzbezeichnung { get; set; }
        public string Berufsgruppen { get; set; }
        public string TextRtf { get; set; }
        public DateTime ErstelltAm { get; set; }
        public string ErstelltVon { get; set; }
    }
}