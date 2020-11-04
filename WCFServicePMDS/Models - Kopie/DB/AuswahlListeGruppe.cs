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

        public virtual ICollection<AuswahlListe> AuswahlListe { get; set; }
    }
}