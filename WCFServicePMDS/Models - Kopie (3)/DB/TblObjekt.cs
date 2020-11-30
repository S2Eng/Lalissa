﻿using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblObjekt
    {
        public Guid Id { get; set; }
        public Guid Iddokumenteintrag { get; set; }
        public bool Datenbankidentität { get; set; }
        public string Server { get; set; }
        public string Datenbank { get; set; }
        public string Benutzer { get; set; }
        public string Passwort { get; set; }
        public int Idtyp { get; set; }
        public Guid? IdGuid { get; set; }
        public string IdStr { get; set; }
        public int? IdInt { get; set; }
        public string Bezeichnung { get; set; }

        public virtual TblDokumenteintrag IddokumenteintragNavigation { get; set; }
    }
}