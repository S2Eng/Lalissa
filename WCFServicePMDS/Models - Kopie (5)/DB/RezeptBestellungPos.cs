using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class RezeptBestellungPos
    {
        public Guid Id { get; set; }
        public Guid IdrezeptEintrag { get; set; }
        public bool BestelltJn { get; set; }
        public DateTime? DatumBestellt { get; set; }
        public bool GedrucktJn { get; set; }
        public bool Dringend { get; set; }
        public DateTime? DatumGedruckt { get; set; }
        public bool RezeptAngefordertJn { get; set; }
        public DateTime? RezeptAngefordertDatum { get; set; }
        public DateTime? RezeptAnforderungDatum { get; set; }
        public int Packungsanzahl { get; set; }
    }
}