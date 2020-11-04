using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class WundePosBilder
    {
        public Guid Id { get; set; }
        public Guid IdwundePos { get; set; }
        public byte[] Bild { get; set; }
        public byte[] Thumbnail { get; set; }
        public int Reihenfolge { get; set; }
        public bool DruckenJn { get; set; }
        public string Beschreibung { get; set; }
        public DateTime ZeitpunktBild { get; set; }
        public Guid? IdbenutzerErstellt { get; set; }
        public Guid? IdbenutzerGeaendert { get; set; }
        public DateTime? DatumErstellt { get; set; }
        public DateTime? DatumGeaendert { get; set; }
        public byte[] BildOrig { get; set; }

        public virtual WundePos IdwundePosNavigation { get; set; }
    }
}