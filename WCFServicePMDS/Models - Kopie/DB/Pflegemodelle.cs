using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Pflegemodelle
    {
        public Pflegemodelle()
        {
            Pdxpflegemodelle = new HashSet<Pdxpflegemodelle>();
        }

        public Guid Id { get; set; }
        public string Modell { get; set; }
        public string ModellgruppeKlartext { get; set; }
        public int Modellgruppe { get; set; }
        public int Reihenfolge { get; set; }

        public virtual ICollection<Pdxpflegemodelle> Pdxpflegemodelle { get; set; }
    }
}