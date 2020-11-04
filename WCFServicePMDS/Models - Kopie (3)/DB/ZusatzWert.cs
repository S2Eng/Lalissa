using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class ZusatzWert
    {
        public Guid Id { get; set; }
        public Guid? IdzusatzGruppeEintrag { get; set; }
        public Guid? Idobjekt { get; set; }
        public string Wert { get; set; }
        public int? ZahlenWert { get; set; }
        public byte[] RawFormat { get; set; }
        public double? ZahlenWertFloat { get; set; }

        public virtual ZusatzGruppeEintrag IdzusatzGruppeEintragNavigation { get; set; }
    }
}