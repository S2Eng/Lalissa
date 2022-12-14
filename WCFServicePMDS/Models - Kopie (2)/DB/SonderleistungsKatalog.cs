using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class SonderleistungsKatalog
    {
        public SonderleistungsKatalog()
        {
            PatientSonderleistung = new HashSet<PatientSonderleistung>();
        }

        public Guid Id { get; set; }
        public string Bezeichnung { get; set; }
        public decimal? Betrag { get; set; }
        public decimal? Mwst { get; set; }
        public Guid? Idklinik { get; set; }
        public string Fibu { get; set; }

        public virtual ICollection<PatientSonderleistung> PatientSonderleistung { get; set; }
    }
}