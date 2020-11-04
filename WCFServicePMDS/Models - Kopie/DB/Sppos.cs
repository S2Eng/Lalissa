using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Sppos
    {
        public Guid Id { get; set; }
        public Guid? Idsp { get; set; }
        public Guid? Ideintrag { get; set; }
        public bool OefterJn { get; set; }
        public string Anmerkung { get; set; }
        public Guid? IdbenutzerErstellt { get; set; }
        public Guid? IdbenutzerGeaendert { get; set; }
        public DateTime? DatumGeaendert { get; set; }
        public DateTime? DatumErstellt { get; set; }
        public bool AktivJn { get; set; }
        public DateTime? Wiederumam { get; set; }

        public virtual Benutzer IdbenutzerErstelltNavigation { get; set; }
        public virtual Benutzer IdbenutzerGeaendertNavigation { get; set; }
        public virtual Eintrag IdeintragNavigation { get; set; }
        public virtual Sp IdspNavigation { get; set; }
    }
}