using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class MedizinischeDatenLayout
    {
        public Guid Id { get; set; }
        public int? MedizinischerTyp { get; set; }
        public string Bezeichnung { get; set; }
        public int? Beschreibung { get; set; }
        public int? Bemerkung { get; set; }
        public int? Beendigungsgrund { get; set; }
        public int? Therapie { get; set; }
        public int? Typ { get; set; }
        public bool? BVisible { get; set; }
    }
}