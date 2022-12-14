using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Dienstzeiten
    {
        public Guid Id { get; set; }
        public Guid Idabteilung { get; set; }
        public string Bezeichnung { get; set; }
        public DateTime Von { get; set; }
        public DateTime Bis { get; set; }
        public int Reihenfolge { get; set; }
        public string VerwendenIn { get; set; }
        public Guid Idguid { get; set; }
    }
}