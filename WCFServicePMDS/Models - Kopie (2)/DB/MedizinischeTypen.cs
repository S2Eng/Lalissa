using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class MedizinischeTypen
    {
        public Guid Id { get; set; }
        public int Nummer { get; set; }
        public int MedizinischerTyp { get; set; }
        public string Beschreibung { get; set; }
        public byte[] Icon { get; set; }
        public byte[] IconOff { get; set; }
        public bool? BVisible { get; set; }
    }
}