using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Klinik
    {
        public Klinik()
        {
            Abteilung = new HashSet<Abteilung>();
            BenutzerEinrichtung = new HashSet<BenutzerEinrichtung>();
        }

        public Guid Id { get; set; }
        public string Bezeichnung { get; set; }
        public Guid? Idadresse { get; set; }
        public Guid? Idkontakt { get; set; }
        public bool? MitAerztlicheLeitungJn { get; set; }
        public bool? MitAerztlicheAufsichtJn { get; set; }
        public bool? MitPflegedienstleitungJn { get; set; }
        public bool? MitPaedagischeLeitungJn { get; set; }
        public string Einrichtungsleiter { get; set; }
        public Guid? Idbank { get; set; }
        public string Zvr { get; set; }
        public string Bereich { get; set; }
        public string EinrichtungsleiterTitel { get; set; }
        public string EinrichtungsleiterVorname { get; set; }
        public string Rechnungsformular { get; set; }
        public string RechnungsformularDepot { get; set; }
        public string FormatRechNr { get; set; }
        public string FormatStornoNr { get; set; }
        public string FormatZahlungsbestätigung { get; set; }
        public string ElgaOid { get; set; }
        public string ElgaAuthorSpeciality { get; set; }
        public string ElgaOrganizationOid { get; set; }
        public string ElgaOrganizationName { get; set; }

        public virtual Adresse IdadresseNavigation { get; set; }
        public virtual Bank IdbankNavigation { get; set; }
        public virtual Kontakt IdkontaktNavigation { get; set; }
        public virtual ICollection<Abteilung> Abteilung { get; set; }
        public virtual ICollection<BenutzerEinrichtung> BenutzerEinrichtung { get; set; }
    }
}