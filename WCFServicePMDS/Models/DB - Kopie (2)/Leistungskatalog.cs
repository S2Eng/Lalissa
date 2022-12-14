// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Leistungskatalog
    {
        public Leistungskatalog()
        {
            LeistungskatalogGueltig = new HashSet<LeistungskatalogGueltig>();
            PatientLeistungsplan = new HashSet<PatientLeistungsplan>();
        }

        public Guid Id { get; set; }
        public string Bezeichnung { get; set; }
        public string Barcode { get; set; }
        public string Fibukonto { get; set; }
        public int EnumLeistungsgruppe { get; set; }
        public int DivisorFuerMonatsleistung { get; set; }
        public bool MonatsleistungJn { get; set; }
        public bool TaeglichJn { get; set; }
        public int WochenTage { get; set; }
        public bool VerrechnungImVorrausJn { get; set; }
        public Guid? Idklinik { get; set; }

        public virtual ICollection<LeistungskatalogGueltig> LeistungskatalogGueltig { get; set; }
        public virtual ICollection<PatientLeistungsplan> PatientLeistungsplan { get; set; }
    }
}