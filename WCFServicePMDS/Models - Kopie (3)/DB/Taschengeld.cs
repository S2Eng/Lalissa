using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Taschengeld
    {
        public Guid Id { get; set; }
        public Guid? Idpatient { get; set; }
        public Guid? Idbenutzerdurchgefuehrt { get; set; }
        public string BelegNr { get; set; }
        public DateTime? Datum { get; set; }
        public string Grund { get; set; }
        public decimal? Einzahlung { get; set; }
        public decimal? Auszahlung { get; set; }
        public decimal? Saldo { get; set; }
        public string Lieferant { get; set; }
        public string Bemerkung { get; set; }
        public int? Zahlart { get; set; }
        public bool AbgerechnetJn { get; set; }
        public Guid? Idklinik { get; set; }

        public virtual Benutzer IdbenutzerdurchgefuehrtNavigation { get; set; }
        public virtual Patient IdpatientNavigation { get; set; }
    }
}