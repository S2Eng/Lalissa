using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class AuswahlListe
    {
        public AuswahlListe()
        {
            Benutzer = new HashSet<Benutzer>();
        }

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

        public virtual AuswahlListeGruppe IdauswahlListeGruppeNavigation { get; set; }
        public virtual ICollection<Benutzer> Benutzer { get; set; }
    }
}