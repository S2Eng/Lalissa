using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Kostentraeger
    {
        public Kostentraeger()
        {
            PatientEinkommen = new HashSet<PatientEinkommen>();
            PatientKostentraeger = new HashSet<PatientKostentraeger>();
            PatientTaschengeldKostentraeger = new HashSet<PatientTaschengeldKostentraeger>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Strasse { get; set; }
        public string Plz { get; set; }
        public string Ort { get; set; }
        public string Rechnungsempfaenger { get; set; }
        public string Rechnungsanschrift { get; set; }
        public string Blz { get; set; }
        public string Kontonr { get; set; }
        public string Bank { get; set; }
        public string Fibukonto { get; set; }
        public bool ErlagscheingebuehrJn { get; set; }
        public Guid? Idpatient { get; set; }
        public double? Betrag { get; set; }
        public bool TransferleistungJn { get; set; }
        public bool TaschengeldJn { get; set; }
        public string ZahlartOld { get; set; }
        public int? Zahlart { get; set; }
        public bool PatientbezogenJn { get; set; }
        public bool SammelabrechnungJn { get; set; }
        public string Uidnr { get; set; }
        public string Anrede { get; set; }
        public string Vorname { get; set; }
        public decimal Gsbg { get; set; }
        public Guid? Idklinik { get; set; }
        public Guid? IdkostentraegerSub { get; set; }
        public Guid? IdpatientIstZahler { get; set; }

        public virtual ICollection<PatientEinkommen> PatientEinkommen { get; set; }
        public virtual ICollection<PatientKostentraeger> PatientKostentraeger { get; set; }
        public virtual ICollection<PatientTaschengeldKostentraeger> PatientTaschengeldKostentraeger { get; set; }
    }
}