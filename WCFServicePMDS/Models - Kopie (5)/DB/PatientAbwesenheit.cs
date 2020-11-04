using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class PatientAbwesenheit
    {
        public Guid Id { get; set; }
        public Guid Idpatient { get; set; }
        public DateTime Von { get; set; }
        public DateTime? Bis { get; set; }
        public bool BetrifftPflegegeldJn { get; set; }
        public int AbTagN { get; set; }
        public string Grund { get; set; }
        public DateTime? ErfasstAm { get; set; }
        public Guid? Idbenutzer { get; set; }
        public DateTime? AbgerechnetBis { get; set; }
        public string Idüber { get; set; }
        public bool Übersp { get; set; }
        public Guid? Idklinik { get; set; }

        public virtual Patient IdpatientNavigation { get; set; }
    }
}