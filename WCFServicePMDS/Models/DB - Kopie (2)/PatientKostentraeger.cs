// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class PatientKostentraeger
    {
        public Guid Id { get; set; }
        public Guid Idpatient { get; set; }
        public Guid Idkostentraeger { get; set; }
        public DateTime GueltigAb { get; set; }
        public DateTime? GueltigBis { get; set; }
        public int EnumKostentraegerart { get; set; }
        public bool BetragErrechnetJn { get; set; }
        public decimal? Betrag { get; set; }
        public DateTime? ErfasstAm { get; set; }
        public Guid? Idbenutzer { get; set; }
        public DateTime? AbgerechnetBis { get; set; }
        public bool VorauszahlungJn { get; set; }
        public bool? RechnungJn { get; set; }
        public int RechnungTyp { get; set; }
        public Guid? IdpatientIstZahler { get; set; }

        public virtual Kostentraeger IdkostentraegerNavigation { get; set; }
        public virtual Patient IdpatientNavigation { get; set; }
    }
}