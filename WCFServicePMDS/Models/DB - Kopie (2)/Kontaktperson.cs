// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Kontaktperson
    {
        public Guid Id { get; set; }
        public Guid Idpatient { get; set; }
        public Guid? Idadresse { get; set; }
        public Guid? Idkontakt { get; set; }
        public string Titel { get; set; }
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public bool? VerstaendigenJn { get; set; }
        public string Kontaktart { get; set; }
        public string Verwandtschaft { get; set; }
        public bool? ExternerDienstleisterJn { get; set; }
        public Guid? IdkontaktStammdaten { get; set; }

        public virtual Adresse IdadresseNavigation { get; set; }
        public virtual Kontakt IdkontaktNavigation { get; set; }
        public virtual KontaktpersonStammdaten IdkontaktStammdatenNavigation { get; set; }
        public virtual Patient IdpatientNavigation { get; set; }
    }
}