using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblNachricht
    {
        public Guid Id { get; set; }
        public Guid IdpflegePlan { get; set; }
        public Guid Ideintrag { get; set; }
        public Guid IdbenutzerFrom { get; set; }
        public Guid IdberufsstandFrom { get; set; }
        public Guid IdbenutzerTo { get; set; }
        public Guid IdberufsstandTo { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime Zeitpunkt { get; set; }
        public int TerminTyp { get; set; }
        public int EintragsTyp { get; set; }
        public DateTime Zeitstempel { get; set; }
        public string Nachricht { get; set; }
    }
}