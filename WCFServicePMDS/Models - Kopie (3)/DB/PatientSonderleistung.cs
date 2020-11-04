using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class PatientSonderleistung
    {
        public Guid Id { get; set; }
        public Guid Idpatient { get; set; }
        public string Bezeichnung { get; set; }
        public int Anzahl { get; set; }
        public decimal? Betrag { get; set; }
        public decimal? Mwst { get; set; }
        public DateTime Datum { get; set; }
        public bool AbgerechnetJn { get; set; }
        public Guid? Idsonderleistungskatalog { get; set; }
        public string Belegnummer { get; set; }
        public int? JahrAbrechnung { get; set; }
        public int? MonatAbrechnung { get; set; }
        public double? EinzelPreis { get; set; }
        public DateTime? DatumVerrech { get; set; }
        public Guid? Idklinik { get; set; }

        public virtual Patient IdpatientNavigation { get; set; }
        public virtual SonderleistungsKatalog IdsonderleistungskatalogNavigation { get; set; }
    }
}