using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class RezeptEintrag
    {
        public RezeptEintrag()
        {
            RezeptEintragMedDaten = new HashSet<RezeptEintragMedDaten>();
        }

        public Guid Id { get; set; }
        public Guid Idmedikament { get; set; }
        public DateTime AbzugebenVon { get; set; }
        public DateTime AbzugebenBis { get; set; }
        public bool BeaufsichtigungJn { get; set; }
        public double Zp0 { get; set; }
        public double Zp1 { get; set; }
        public double Zp2 { get; set; }
        public double Zp3 { get; set; }
        public double Zp4 { get; set; }
        public double Zp5 { get; set; }
        public double Zp6 { get; set; }
        public string Einheit { get; set; }
        public int Intervall { get; set; }
        public int Wochentage { get; set; }
        public bool BedarfsMedikationJn { get; set; }
        public string Bemerkung { get; set; }
        public Guid IdbenutzerErstellt { get; set; }
        public Guid IdbenutzerGeaendert { get; set; }
        public DateTime DatumErstellt { get; set; }
        public DateTime DatumGeaendert { get; set; }
        public int Herrichten { get; set; }
        public bool? AerztlichevorbereitungJn { get; set; }
        public int Verabreichungsart { get; set; }
        public string Applikationsform { get; set; }
        public int Wiederholungstyp { get; set; }
        public int Wiederholungseinheit { get; set; }
        public double Wiederholungswert { get; set; }
        public bool StandardzeitenJn { get; set; }
        public DateTime? Zeitpunkt0 { get; set; }
        public DateTime? Zeitpunkt1 { get; set; }
        public DateTime? Zeitpunkt2 { get; set; }
        public DateTime? Zeitpunkt3 { get; set; }
        public DateTime? Zeitpunkt4 { get; set; }
        public double? Packunggroesse { get; set; }
        public string Rezeptdaten { get; set; }
        public string Packungeinheit { get; set; }
        public bool BestellenJn { get; set; }
        public Guid? Idaerzte { get; set; }
        public Guid? Idaufenthalt { get; set; }
        public DateTime? AusstellungsDatum { get; set; }
        public string DosierungAsstring { get; set; }
        public int Packungsanzahl { get; set; }
        public DateTime? ZuletztBestelltAm { get; set; }
        public Guid? IdaerzteGeaendert { get; set; }
        public Guid? IdarztAbgesetzt { get; set; }
        public Guid? ZuletztBestelltVon { get; set; }
        public bool HagpflichtigJn { get; set; }
        public string LstMedDaten { get; set; }
        public DateTime? ZeitpunktBlisterliste { get; set; }
        public int NumberMedDaten { get; set; }
        public string LstWunden { get; set; }
        public int NumberWunden { get; set; }

        public virtual Aerzte IdaerzteNavigation { get; set; }
        public virtual Aufenthalt IdaufenthaltNavigation { get; set; }
        public virtual Medikament IdmedikamentNavigation { get; set; }
        public virtual ICollection<RezeptEintragMedDaten> RezeptEintragMedDaten { get; set; }
    }
}