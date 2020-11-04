using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class KlinikDTO
    {

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

    }

    public class KlinikS1DTO
    {

        public Guid Id { get; set; }
        public string Bezeichnung { get; set; }
        public Guid? Idadresse { get; set; }
        public Guid? Idkontakt { get; set; }

    }
}

