using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblThemen
    {
        public TblThemen()
        {
            TblSchlagwörter = new HashSet<TblSchlagwörter>();
        }

        public Guid Id { get; set; }
        public string Thema { get; set; }
        public DateTime ErstelltAm { get; set; }
        public string ErstelltVon { get; set; }

        public virtual ICollection<TblSchlagwörter> TblSchlagwörter { get; set; }
    }
}