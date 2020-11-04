using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Medikament
    {
        public Medikament()
        {
            RezeptEintrag = new HashSet<RezeptEintrag>();
            Vo = new HashSet<Vo>();
            VoBestelldaten = new HashSet<VoBestelldaten>();
            VoBestellpostitionen = new HashSet<VoBestellpostitionen>();
        }

        public Guid Id { get; set; }
        public string ExtId { get; set; }
        public string Barcode { get; set; }
        public string Zulassungsnummer { get; set; }
        public string Bezeichnung { get; set; }
        public string LangText { get; set; }
        public string Einheit { get; set; }
        public string Gruppe { get; set; }
        public int Herrichten { get; set; }
        public bool AerztlichevorbereitungJn { get; set; }
        public int Verabreichungsart { get; set; }
        public string Applikationsform { get; set; }
        public double Packungsgroesse { get; set; }
        public int Packungsanzahl { get; set; }
        public string Packungseinheit { get; set; }
        public DateTime? Gültigkeitsdatum { get; set; }
        public string Lagervorschrift { get; set; }
        public DateTime? ImportiertAm { get; set; }
        public bool Importiert { get; set; }
        public bool Aktuell { get; set; }
        public string Erstattungscode { get; set; }
        public string Kassenzeichen { get; set; }
        public string Lieferant { get; set; }
        public string HerrichtenTxt { get; set; }

        public virtual ICollection<RezeptEintrag> RezeptEintrag { get; set; }
        public virtual ICollection<Vo> Vo { get; set; }
        public virtual ICollection<VoBestelldaten> VoBestelldaten { get; set; }
        public virtual ICollection<VoBestellpostitionen> VoBestellpostitionen { get; set; }
    }
}