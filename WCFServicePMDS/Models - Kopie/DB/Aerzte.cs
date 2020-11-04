using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Aerzte
    {
        public Aerzte()
        {
            PatientAerzte = new HashSet<PatientAerzte>();
            RezeptEintrag = new HashSet<RezeptEintrag>();
        }

        public Guid Id { get; set; }
        public Guid? Idadresse { get; set; }
        public Guid? Idkontakt { get; set; }
        public string Titel { get; set; }
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public string Fachrichtung { get; set; }

        public virtual Adresse IdadresseNavigation { get; set; }
        public virtual Kontakt IdkontaktNavigation { get; set; }
        public virtual ICollection<PatientAerzte> PatientAerzte { get; set; }
        public virtual ICollection<RezeptEintrag> RezeptEintrag { get; set; }
    }
}