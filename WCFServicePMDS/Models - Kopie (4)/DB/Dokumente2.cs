using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Dokumente2
    {
        public Guid Id { get; set; }
        public string Bezeichnung { get; set; }
        public string DokumentenName { get; set; }
        public string Abteilungen { get; set; }
        public string Benutzergruppen { get; set; }
        public DateTime ErstelltAm { get; set; }
        public string ErstelltVon { get; set; }
        public byte[] ByteDoc { get; set; }
        public byte[] ByteJpg { get; set; }
        public string TypeDocu { get; set; }
        public Guid? Idrelation { get; set; }
        public string FileType { get; set; }
    }
}