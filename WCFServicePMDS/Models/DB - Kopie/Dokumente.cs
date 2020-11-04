using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Dokumente
    {
        public Guid Id { get; set; }
        public Guid Idobject { get; set; }
        public string Gruppe { get; set; }
        public int SortOrder { get; set; }
        public byte[] Inhalt { get; set; }
        public DateTime Erstellungsdatum { get; set; }
        public DateTime Aenderungsdatum { get; set; }
        public Guid IdbenutzerErstellt { get; set; }
        public Guid IdbenutzerGeaendert { get; set; }

        public virtual Benutzer IdbenutzerErstelltNavigation { get; set; }
        public virtual Benutzer IdbenutzerGeaendertNavigation { get; set; }
    }
}