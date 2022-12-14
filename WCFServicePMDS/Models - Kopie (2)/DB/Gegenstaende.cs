using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Gegenstaende
    {
        public Guid Id { get; set; }
        public Guid? Idaufenthalt { get; set; }
        public Guid? Idbenutzerausgegeben { get; set; }
        public Guid? Idbenutzerzurueck { get; set; }
        public string Beschreibung { get; set; }
        public string Nr { get; set; }
        public DateTime? Von { get; set; }
        public DateTime? Bis { get; set; }
        public string Eigentuemer { get; set; }
        public string Bemerkung { get; set; }
        public bool? HilfesmittelJn { get; set; }
        public bool? EigentumKlinikJn { get; set; }
        public bool? EigentumKlientJn { get; set; }
        public bool? MieteJn { get; set; }
        public DateTime? LetzteUeberpruefungAm { get; set; }
        public DateTime? NaechsteUeberpruefungAm { get; set; }

        public virtual Aufenthalt IdaufenthaltNavigation { get; set; }
        public virtual Benutzer IdbenutzerausgegebenNavigation { get; set; }
        public virtual Benutzer IdbenutzerzurueckNavigation { get; set; }
    }
}