﻿using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class AufenthaltVerlauf
    {
        public Guid Id { get; set; }
        public Guid? Idaufenthalt { get; set; }
        public Guid? Idbenutzer { get; set; }
        public Guid? IdabteilungVon { get; set; }
        public Guid? IdabteilungNach { get; set; }
        public Guid? Idbereich { get; set; }
        public string Bemerkung { get; set; }
        public DateTime? Datum { get; set; }
        public string ZuweisenderArzt { get; set; }
        public string AufnahmeArzt { get; set; }
        public string Aufnahmegespraech { get; set; }
        public string Abschlussbemerkung { get; set; }
        public string AufnahmeStatus { get; set; }

        public virtual Abteilung IdabteilungNachNavigation { get; set; }
        public virtual Abteilung IdabteilungVonNavigation { get; set; }
        public virtual Aufenthalt IdaufenthaltNavigation { get; set; }
        public virtual Benutzer IdbenutzerNavigation { get; set; }
        public virtual Bereich IdbereichNavigation { get; set; }
    }
}