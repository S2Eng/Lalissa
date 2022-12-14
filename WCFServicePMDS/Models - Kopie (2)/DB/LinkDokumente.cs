using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class LinkDokumente
    {
        public Guid Id { get; set; }
        public string Beschreibung { get; set; }
        public string LinkName { get; set; }
        public byte[] Dokument { get; set; }
        public string Gruppe { get; set; }
        public DateTime Erstellungsdatum { get; set; }
        public DateTime Aenderungsdatum { get; set; }
        public Guid IdbenutzerErstellt { get; set; }
        public Guid IdbenutzerGeaendert { get; set; }
    }
}