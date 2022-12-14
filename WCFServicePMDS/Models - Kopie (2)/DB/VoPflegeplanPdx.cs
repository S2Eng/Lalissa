using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class VoPflegeplanPdx
    {
        public Guid Id { get; set; }
        public Guid Idverordnung { get; set; }
        public Guid IduntertaegigeGruppe { get; set; }
        public Guid IdbenutzerErstellt { get; set; }
        public string LoginNameFreiErstellt { get; set; }
        public DateTime DatumEsrstellt { get; set; }
        public Guid IdbenutzerGeaendert { get; set; }
        public string LoginNameFreiGeaendert { get; set; }
        public DateTime DatumGeaendert { get; set; }

        public virtual Benutzer IdbenutzerErstelltNavigation { get; set; }
        public virtual Benutzer IdbenutzerGeaendertNavigation { get; set; }
        public virtual Vo IdverordnungNavigation { get; set; }
    }
}