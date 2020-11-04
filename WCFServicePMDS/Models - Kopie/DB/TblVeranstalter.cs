using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblVeranstalter
    {
        public TblVeranstalter()
        {
            TblFortbildungen = new HashSet<TblFortbildungen>();
        }

        public Guid Id { get; set; }
        public string Bezeichnung { get; set; }
        public string Beschreibung { get; set; }
        public Guid Idadresse { get; set; }
        public Guid Idkontakt { get; set; }

        public virtual Adresse IdadresseNavigation { get; set; }
        public virtual Kontakt IdkontaktNavigation { get; set; }
        public virtual ICollection<TblFortbildungen> TblFortbildungen { get; set; }
    }
}