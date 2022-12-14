using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class WundeKopf
    {
        public WundeKopf()
        {
            WundePos = new HashSet<WundePos>();
            WundeTherapie = new HashSet<WundeTherapie>();
        }

        public Guid Id { get; set; }
        public Guid IdaufenthaltPdx { get; set; }
        public string Wundart { get; set; }
        public string Dekuskala { get; set; }
        public int? Dekuwert { get; set; }
        public byte[] ClickedImage { get; set; }
        public int? ClickedValueX { get; set; }
        public int? ClickedValueY { get; set; }
        public Guid? IdbenutzerErstellt { get; set; }
        public Guid? IdbenutzerGeaendert { get; set; }
        public DateTime? DatumErstellt { get; set; }
        public DateTime? DatumGeaendert { get; set; }
        public DateTime? BekanntSeit { get; set; }
        public string BisherigeBehandlung { get; set; }
        public string WundeEntstanden { get; set; }

        public virtual ICollection<WundePos> WundePos { get; set; }
        public virtual ICollection<WundeTherapie> WundeTherapie { get; set; }
    }
}