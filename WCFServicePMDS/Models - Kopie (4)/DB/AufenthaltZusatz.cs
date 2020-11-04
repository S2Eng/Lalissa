using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class AufenthaltZusatz
    {
        public Guid Id { get; set; }
        public Guid Idaufenthalt { get; set; }
        public string Zimmernummer { get; set; }
        public DateTime? SozialhilfeAntragDatum { get; set; }
        public bool SozialhilfeBescheidJn { get; set; }
        public double MinSaldo { get; set; }
        public bool OffeneRechnungJn { get; set; }
        public string SozialhilfeBescheidGz { get; set; }

        public virtual Aufenthalt IdaufenthaltNavigation { get; set; }
    }
}