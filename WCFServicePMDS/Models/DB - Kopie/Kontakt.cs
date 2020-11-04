using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Kontakt
    {
        public Kontakt()
        {
            Abteilung = new HashSet<Abteilung>();
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
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Mobil { get; set; }
        public string Andere { get; set; }
        public string Email { get; set; }
        public string Ansprechpartner { get; set; }
        public string Zusatz1 { get; set; }
        public string Zusatz2 { get; set; }
        public string Zusatz3 { get; set; }

        public virtual ICollection<Abteilung> Abteilung { get; set; }
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