using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Adresse
    {
        public Adresse()
        {
            Aerzte = new HashSet<Aerzte>();
            Benutzer = new HashSet<Benutzer>();
            Einrichtung = new HashSet<Einrichtung>();
            Klinik = new HashSet<Klinik>();
            Kontaktperson = new HashSet<Kontaktperson>();
            Patient = new HashSet<Patient>();
            Sachwalter = new HashSet<Sachwalter>();
            TblVeranstalter = new HashSet<TblVeranstalter>();
        }

        public Guid Id { get; set; }
        public string Strasse { get; set; }
        public string Plz { get; set; }
        public string Ort { get; set; }
        public string Region { get; set; }
        public string LandKz { get; set; }

        public virtual ICollection<Aerzte> Aerzte { get; set; }
        public virtual ICollection<Benutzer> Benutzer { get; set; }
        public virtual ICollection<Einrichtung> Einrichtung { get; set; }
        public virtual ICollection<Klinik> Klinik { get; set; }
        public virtual ICollection<Kontaktperson> Kontaktperson { get; set; }
        public virtual ICollection<Patient> Patient { get; set; }
        public virtual ICollection<Sachwalter> Sachwalter { get; set; }
        public virtual ICollection<TblVeranstalter> TblVeranstalter { get; set; }
    }
}