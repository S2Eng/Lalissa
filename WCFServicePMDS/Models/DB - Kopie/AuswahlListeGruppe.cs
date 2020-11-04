using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class AuswahlListeGruppe
    {
        public AuswahlListeGruppe()
        {
            AuswahlListe = new HashSet<AuswahlListe>();
        }

        public string Id { get; set; }
        public string Bezeichnung { get; set; }
        public bool Sys { get; set; }
        public bool ExactMatch { get; set; }
        public bool PflichtJn { get; set; }
        public int IntId { get; set; }
        public bool ElgaJn { get; set; }
        public int ElgaUseMeaning { get; set; }

        public virtual ICollection<AuswahlListe> AuswahlListe { get; set; }
    }
}