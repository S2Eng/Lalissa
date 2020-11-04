using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblFortbildungBenutzer
    {
        public Guid Id { get; set; }
        public Guid Idbenutzer { get; set; }
        public Guid Idfortbildung { get; set; }
        public DateTime? Anmeldedatum { get; set; }
        public int Erfolg { get; set; }
        public DateTime? AbgeschlossenAm { get; set; }
        public DateTime? ZuErneuernAm { get; set; }
        public string Status { get; set; }
        public string Anmerkung { get; set; }

        public virtual Benutzer IdbenutzerNavigation { get; set; }
        public virtual TblFortbildungen IdfortbildungNavigation { get; set; }
    }
}