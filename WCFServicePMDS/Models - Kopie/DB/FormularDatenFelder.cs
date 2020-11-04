using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class FormularDatenFelder
    {
        public Guid Id { get; set; }
        public Guid IdformularDaten { get; set; }
        public string Feldname { get; set; }
        public string Feldtyp { get; set; }
        public string Feldwert { get; set; }

        public virtual FormularDaten IdformularDatenNavigation { get; set; }
    }
}