using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblSchrank
    {
        public TblSchrank()
        {
            TblFach = new HashSet<TblFach>();
        }

        public Guid Id { get; set; }
        public string Bezeichnung { get; set; }
        public DateTime ErstelltAm { get; set; }
        public string ErstelltVon { get; set; }
        public bool Extern { get; set; }

        public virtual ICollection<TblFach> TblFach { get; set; }
    }
}