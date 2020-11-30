﻿using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblFortbildungen
    {
        public TblFortbildungen()
        {
            TblFortbildungBenutzer = new HashSet<TblFortbildungBenutzer>();
        }

        public Guid Id { get; set; }
        public Guid Idveranstalter { get; set; }
        public string Bezeichnung { get; set; }
        public string Beschreibung { get; set; }
        public DateTime? Beginn { get; set; }
        public DateTime? Ende { get; set; }
        public int AnzahlStunden { get; set; }
        public string Zertifikat { get; set; }
        public string Vortragender { get; set; }
        public string Veranstaltungsort { get; set; }
        public string Voraussetzungen { get; set; }
        public int AnzahlFreiePlätze { get; set; }

        public virtual TblVeranstalter IdveranstalterNavigation { get; set; }
        public virtual ICollection<TblFortbildungBenutzer> TblFortbildungBenutzer { get; set; }
    }
}