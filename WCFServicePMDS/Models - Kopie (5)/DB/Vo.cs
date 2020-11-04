using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Vo
    {
        public Vo()
        {
            VoBestelldaten = new HashSet<VoBestelldaten>();
            VoLager = new HashSet<VoLager>();
            VoMedizinischeDaten = new HashSet<VoMedizinischeDaten>();
            VoPflegeplanPdx = new HashSet<VoPflegeplanPdx>();
            VoWunde = new HashSet<VoWunde>();
        }

        public Guid Id { get; set; }
        public Guid Idaufenthalt { get; set; }
        public Guid Idmedikament { get; set; }
        public Guid Typ { get; set; }
        public double Menge { get; set; }
        public string Einheit { get; set; }
        public string Hinweis { get; set; }
        public DateTime DatumVerordnetAb { get; set; }
        public DateTime? DatumVerordnetBis { get; set; }
        public string BestaetigtVon { get; set; }
        public DateTime DatumErstellt { get; set; }
        public Guid IdbenutzerErstellt { get; set; }
        public string LoginNameFreiErstellt { get; set; }
        public DateTime DatumGeaendert { get; set; }
        public Guid IdbenutzerGeaendert { get; set; }
        public string LoginNameFreiGeaendert { get; set; }
        public Guid? Lieferant { get; set; }
        public string HinweisLieferant { get; set; }
        public string Anmerkung { get; set; }

        public virtual Aufenthalt IdaufenthaltNavigation { get; set; }
        public virtual Medikament IdmedikamentNavigation { get; set; }
        public virtual ICollection<VoBestelldaten> VoBestelldaten { get; set; }
        public virtual ICollection<VoLager> VoLager { get; set; }
        public virtual ICollection<VoMedizinischeDaten> VoMedizinischeDaten { get; set; }
        public virtual ICollection<VoPflegeplanPdx> VoPflegeplanPdx { get; set; }
        public virtual ICollection<VoWunde> VoWunde { get; set; }
    }
}