using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class VoLager
    {
        public Guid Id { get; set; }
        public Guid Idvo { get; set; }
        public string Seriennummer { get; set; }
        public string Zustand { get; set; }
        public DateTime DatumErstellt { get; set; }
        public Guid IdbenutzerErstellt { get; set; }
        public string LoginNameFreiErstellt { get; set; }
        public DateTime DatumGeaendert { get; set; }
        public Guid IdbenutzerGeaendert { get; set; }
        public string LoginNameFreiGeaendert { get; set; }

        public virtual Vo IdvoNavigation { get; set; }
    }
}