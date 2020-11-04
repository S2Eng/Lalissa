using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Bills
    {
        public string Id { get; set; }
        public bool Freigegeben { get; set; }
        public string RechNr { get; set; }
        public DateTime Datum { get; set; }
        public string KlientName { get; set; }
        public string KostenträgerName { get; set; }
        public int Status { get; set; }
        public int Typ { get; set; }
        public string Rechnung { get; set; }
        public string Idklient { get; set; }
        public string Idkost { get; set; }
        public string IdkostIntern { get; set; }
        public decimal Betrag { get; set; }
        public string Idabrechnung { get; set; }
        public string Idsr { get; set; }
        public string Erstellt { get; set; }
        public DateTime ErstellAm { get; set; }
        public string DbBill { get; set; }
        public Guid? Idklinik { get; set; }
        public DateTime? RechDatum { get; set; }
        public string IdbillStorno { get; set; }
        public bool ExportiertJn { get; set; }
        public int RollungAnz { get; set; }
        public string IdbillsGerollt { get; set; }
    }
}