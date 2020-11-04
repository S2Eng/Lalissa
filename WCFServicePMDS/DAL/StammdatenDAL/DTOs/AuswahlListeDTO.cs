using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class AuswahlListeDTO
    {
        public Guid Id { get; set; }
        public string IdauswahlListeGruppe { get; set; }
        public int? Reihenfolge { get; set; }
        public string Bezeichnung { get; set; }
        public bool IstGruppe { get; set; }
        public string GehörtzuGruppe { get; set; }
        public int Hierarche { get; set; }
        public string Beschreibung { get; set; }
        public bool Unterdruecken { get; set; }
        public int ElgaId { get; set; }
        public string ElgaCode { get; set; }
        public string ElgaCodeSystem { get; set; }
        public string ElgaDisplayName { get; set; }
        public string ElgaVersion { get; set; }

    }

    public class AuswahlListeS1DTO
    {
        public Guid Id { get; set; }
        public string IdauswahlListeGruppe { get; set; }
        public int? Reihenfolge { get; set; }
        public string Bezeichnung { get; set; }
        public bool Unterdruecken { get; set; }
        public int ElgaId { get; set; }
        public string ElgaCode { get; set; }
        public string ElgaCodeSystem { get; set; }
        public string ElgaDisplayName { get; set; }

    }

}

