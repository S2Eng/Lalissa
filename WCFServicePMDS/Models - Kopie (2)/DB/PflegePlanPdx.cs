using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class PflegePlanPdx
    {
        public Guid Id { get; set; }
        public Guid? IdpflegePlan { get; set; }
        public Guid? Ideintrag { get; set; }
        public Guid? Idpdx { get; set; }
        public Guid? IdbenutzerErstellt { get; set; }
        public Guid? IdbenutzerBeendet { get; set; }
        public DateTime? DatumErstellt { get; set; }
        public DateTime? DatumBeendet { get; set; }
        public bool? ErledigtJn { get; set; }
        public string ErledigtGrund { get; set; }
        public Guid? IdaufenthaltPdx { get; set; }
        public Guid? IduntertaegigeGruppe { get; set; }

        public virtual AufenthaltPdx IdaufenthaltPdxNavigation { get; set; }
        public virtual Benutzer IdbenutzerBeendetNavigation { get; set; }
        public virtual Benutzer IdbenutzerErstelltNavigation { get; set; }
        public virtual Eintrag IdeintragNavigation { get; set; }
        public virtual Pdx IdpdxNavigation { get; set; }
        public virtual PflegePlan IdpflegePlanNavigation { get; set; }
    }
}