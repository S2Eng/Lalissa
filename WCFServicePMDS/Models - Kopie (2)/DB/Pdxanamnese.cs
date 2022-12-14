using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Pdxanamnese
    {
        public Guid Id { get; set; }
        public string Modell { get; set; }
        public int? Modellgruppe { get; set; }
        public Guid? IdanamneseKrohwinkel { get; set; }
        public Guid? IdanamneseOrem { get; set; }
        public Guid? IdanamneseNanda { get; set; }
        public Guid? IdanamneseRt { get; set; }
        public Guid? IdanamneseJuchli { get; set; }
        public Guid? IdanamneseRai { get; set; }
        public Guid? Idpdx { get; set; }
        public string Resourceklient { get; set; }
        public Guid? IdanamnesePop { get; set; }

        public virtual AnamneseKrohwinkel IdanamneseKrohwinkelNavigation { get; set; }
        public virtual AnamneseOrem IdanamneseOremNavigation { get; set; }
        public virtual Pdx IdpdxNavigation { get; set; }
    }
}