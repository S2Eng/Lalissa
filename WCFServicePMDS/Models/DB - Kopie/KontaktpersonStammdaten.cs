using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class KontaktpersonStammdaten
    {
        public KontaktpersonStammdaten()
        {
            Kontaktperson = new HashSet<Kontaktperson>();
            Sachwalter = new HashSet<Sachwalter>();
        }

        public Guid Id { get; set; }
        public string Titel { get; set; }
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public Guid Idkontakt { get; set; }
        public Guid Idadresse { get; set; }

        public virtual ICollection<Kontaktperson> Kontaktperson { get; set; }
        public virtual ICollection<Sachwalter> Sachwalter { get; set; }
    }
}