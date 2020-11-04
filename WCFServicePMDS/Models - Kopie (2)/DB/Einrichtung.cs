using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Einrichtung
    {
        public Einrichtung()
        {
            AufenthaltIdeinrichtungAufnahmeNavigation = new HashSet<Aufenthalt>();
            AufenthaltIdeinrichtungEntlassungNavigation = new HashSet<Aufenthalt>();
        }

        public Guid Id { get; set; }
        public string Text { get; set; }
        public Guid? Idadresse { get; set; }
        public Guid? Idkontakt { get; set; }

        public virtual Adresse IdadresseNavigation { get; set; }
        public virtual Kontakt IdkontaktNavigation { get; set; }
        public virtual ICollection<Aufenthalt> AufenthaltIdeinrichtungAufnahmeNavigation { get; set; }
        public virtual ICollection<Aufenthalt> AufenthaltIdeinrichtungEntlassungNavigation { get; set; }
    }
}