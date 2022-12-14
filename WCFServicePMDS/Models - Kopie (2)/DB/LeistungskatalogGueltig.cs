using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class LeistungskatalogGueltig
    {
        public Guid Id { get; set; }
        public Guid Idleistungskatalog { get; set; }
        public DateTime GueltigAb { get; set; }
        public decimal? Betrag { get; set; }
        public decimal Mwst { get; set; }
        public decimal GutschriftProTagAbwesend { get; set; }
        public bool TagsatzberechnungJn { get; set; }
        public DateTime? GueltigBis { get; set; }

        public virtual Leistungskatalog IdleistungskatalogNavigation { get; set; }
    }
}