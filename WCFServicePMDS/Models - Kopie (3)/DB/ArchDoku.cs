using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class ArchDoku
    {
        public ArchDoku()
        {
            ArchDokuSchlag = new HashSet<ArchDokuSchlag>();
            ArchObject = new HashSet<ArchObject>();
        }

        public Guid Id { get; set; }
        public Guid? Idordner { get; set; }
        public string Bezeichnung { get; set; }
        public string Notiz { get; set; }
        public DateTime? GültigVon { get; set; }
        public DateTime? GültigBis { get; set; }
        public string Wichtigkeit { get; set; }
        public double Größe { get; set; }
        public string AbgelegtVon { get; set; }
        public DateTime? AbgelegtAm { get; set; }
        public bool Winzip { get; set; }
        public string Archivordner { get; set; }
        public string DateinameArchiv { get; set; }
        public string DateinameTyp { get; set; }
        public byte[] Doku { get; set; }
        public string DokuOrig { get; set; }
        public string RechNr { get; set; }
        public Guid? Idactivity { get; set; }
        public byte[] Db { get; set; }
        public string Idstatus { get; set; }
        public string Idtyp { get; set; }
        public bool? IntReleased { get; set; }
        public byte[] BinIntern { get; set; }

        public virtual ArchOrdner IdordnerNavigation { get; set; }
        public virtual ICollection<ArchDokuSchlag> ArchDokuSchlag { get; set; }
        public virtual ICollection<ArchObject> ArchObject { get; set; }
    }
}