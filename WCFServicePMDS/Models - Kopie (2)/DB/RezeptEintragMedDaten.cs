using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class RezeptEintragMedDaten
    {
        public Guid Id { get; set; }
        public Guid? Idrezepteintrag { get; set; }
        public Guid? IdmedDaten { get; set; }
        public Guid? IdwundeKopf { get; set; }
        public Guid? Idverordnung { get; set; }

        public virtual MedizinischeDaten IdmedDatenNavigation { get; set; }
        public virtual RezeptEintrag IdrezepteintragNavigation { get; set; }
    }
}