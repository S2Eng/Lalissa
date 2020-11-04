using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class WundeTherapie
    {
        public Guid Id { get; set; }
        public Guid IdwundeKopf { get; set; }
        public DateTime? VerordnetAm { get; set; }
        public DateTime? AbgesetztAm { get; set; }
        public string Therapie { get; set; }
        public string AngeordnetVon { get; set; }
        public string AbgesetztVon { get; set; }
        public Guid? IdbenutzerErstellt { get; set; }
        public Guid? IdbenutzerGeaendert { get; set; }
        public DateTime? DatumErstellt { get; set; }
        public DateTime? DatumGeaendert { get; set; }
        public string Debridement { get; set; }
        public string Reinigung { get; set; }
        public string Wundauflage { get; set; }
        public string Sekundaerverband { get; set; }
        public string Fixierung { get; set; }
        public string Hyperkeratoseentfernung { get; set; }
        public string Hautpflege { get; set; }
        public string Zusatzernährung { get; set; }
        public string Kompression { get; set; }
        public string Freillagerung { get; set; }
        public string Wundabstrich { get; set; }
        public string Wundrandschutz { get; set; }
        public string Vwintervall { get; set; }
        public bool VidiertJn { get; set; }
        public string VidiertVon { get; set; }
        public DateTime? VidiertAm { get; set; }
        public string VorgeschlagenVon { get; set; }

        public virtual WundeKopf IdwundeKopfNavigation { get; set; }
    }
}