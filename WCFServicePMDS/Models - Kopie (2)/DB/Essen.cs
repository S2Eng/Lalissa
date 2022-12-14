using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Essen
    {
        public Guid Id { get; set; }
        public DateTime Tag { get; set; }
        public int? AnzahlBetten { get; set; }
        public int? Belegung { get; set; }
        public int EssenPersonal { get; set; }
        public int EssenGaeste { get; set; }
        public int? Urlaube { get; set; }
    }
}