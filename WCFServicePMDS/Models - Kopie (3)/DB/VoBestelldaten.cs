using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class VoBestelldaten
    {
        public VoBestelldaten()
        {
            VoBestellpostitionen = new HashSet<VoBestellpostitionen>();
        }

        public Guid Id { get; set; }
        public Guid Idverordnung { get; set; }
        public DateTime GueltigAb { get; set; }
        public DateTime? GueltigBis { get; set; }
        public Guid Typ { get; set; }
        public Guid Idmedikament { get; set; }
        public bool EigentumKlient { get; set; }
        public double Menge { get; set; }
        public string Einheit { get; set; }
        public Guid? Lieferant { get; set; }
        public string HinweisLieferant { get; set; }
        public string Anmerkung { get; set; }
        public Guid IdbenutzerErstellt { get; set; }
        public string LoginNameFreiErstellt { get; set; }
        public DateTime DatumErstellt { get; set; }
        public Guid Idbenutzergeaendert { get; set; }
        public string LoginNameFreiGeaendert { get; set; }
        public DateTime DatumGeaendert { get; set; }
        public bool Dauerbestellung { get; set; }
        public DateTime? DatumNaechsterAnspruch { get; set; }
        public DateTime? SerienterminEndetAm { get; set; }
        public string SerienterminType { get; set; }
        public int? WiedWertJeden { get; set; }
        public string TagWochenMonat { get; set; }
        public int? NTenMonat { get; set; }
        public string Wochentage { get; set; }
        public int Dauer { get; set; }
        public bool EinmaligeAnforderung { get; set; }

        public virtual Benutzer IdbenutzerErstelltNavigation { get; set; }
        public virtual Medikament IdmedikamentNavigation { get; set; }
        public virtual Vo IdverordnungNavigation { get; set; }
        public virtual ICollection<VoBestellpostitionen> VoBestellpostitionen { get; set; }
    }
}