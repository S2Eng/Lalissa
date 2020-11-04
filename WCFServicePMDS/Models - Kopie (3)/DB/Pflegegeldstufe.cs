using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Pflegegeldstufe
    {
        public Pflegegeldstufe()
        {
            PatientPflegestufe = new HashSet<PatientPflegestufe>();
            PflegegeldstufeGueltig = new HashSet<PflegegeldstufeGueltig>();
        }

        public Guid Id { get; set; }
        public int StufeNr { get; set; }
        public int Divisor { get; set; }
        public string Bezeichnung { get; set; }

        public virtual ICollection<PatientPflegestufe> PatientPflegestufe { get; set; }
        public virtual ICollection<PflegegeldstufeGueltig> PflegegeldstufeGueltig { get; set; }
    }
}