using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblOrdner
    {
        public TblOrdner()
        {
            TblRechteOrdner = new HashSet<TblRechteOrdner>();
        }

        public Guid Id { get; set; }
        public string Bezeichnung { get; set; }
        public Guid Idfach { get; set; }
        public DateTime ErstelltAm { get; set; }
        public string ErstelltVon { get; set; }
        public byte[] Icon { get; set; }
        public bool Extern { get; set; }
        public int Idsystemordner { get; set; }

        public virtual ICollection<TblRechteOrdner> TblRechteOrdner { get; set; }
    }
}