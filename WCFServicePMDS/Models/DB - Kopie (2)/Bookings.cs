// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Bookings
    {
        public string Id { get; set; }
        public DateTime Buchungsdatum { get; set; }
        public string Text { get; set; }
        public string Sollkonto { get; set; }
        public string Habenkonto { get; set; }
        public decimal Betrag { get; set; }
        public int MwstSatz { get; set; }
        public string RechNr { get; set; }
        public string Idklient { get; set; }
        public string Idkostenträger { get; set; }
        public string Erstellt { get; set; }
        public DateTime ErstellAm { get; set; }
        public Guid? Idklinik { get; set; }
    }
}