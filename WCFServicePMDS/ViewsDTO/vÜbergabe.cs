using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WCFServicePMDS.Models.DB
{
    public partial class vÜbergabe2
    {
        public vÜbergabe2()
        {

        }



        public bool Auswahl { get; set; }
        public string Klient     { get; set; }
        public string Geburtsdatum { get; set; }

        public string Zeitpunkt { get; set; }
        public Nullable<bool> Durchgeführt { get; set; }

        public string Maßnahme { get; set; }
        public string Dekurs { get; set; }
        public string DekursRtf { get; set; }
        public Nullable<int> DekursHerkunft { get; set; }
        public string Warnhinweis { get; set; }
        public string Anmerkung { get; set; }
        public string Lokalisierung { get; set; }
        public string Zusatzwerte    { get; set; }
        public string lstIDZusatzwerte { get; set; }
        public string Klinik { get; set; }
        public string Abteilung { get; set; }
        public string Bereich { get; set; }
        public string Benutzer { get; set; }
        public Nullable<bool> AbzeichnenJN { get; set; }
        public Nullable<bool> AbgezeichnetJN { get; set; }
        public Nullable<DateTime> DatumAbgezeichnet { get; set; }
        public string BenutzerAbgezeichnet { get; set; }
        public string BerufsstandIst { get; set; }
        public string BerufsstandSoll { get; set; }
        public string WichtigFür { get; set; }
        public Nullable<bool> CC    { get; set; }
        public string IDBezug    { get; set; }
        public Nullable<int> Eintragstyp { get; set; }
        public Nullable<DateTime> ZeitpunktDatum { get; set; }
        public Nullable<Guid> IDAufenthalt { get; set; }
        public Nullable<Guid> IDPflegeEintrag { get; set; }
        public Nullable<Guid> IDEintrag { get; set; }
        public Nullable<Guid> IDWichtigFür { get; set; }
        public Nullable<Guid> IDBenutzer { get; set; }
        public Nullable<Guid> IDBenutzerAbgezeichnet { get; set; }
        public Nullable<Guid> IDBerufsstand { get; set; }
        public Nullable<Guid> IDSollberufsstand { get; set; }
        public Nullable<Guid> IDKlient   { get; set; }
        public Nullable<Guid> IDKlinik { get; set; }
        public Nullable<Guid> IDAbteilung   { get; set; }
        public Nullable<Guid> IDBereich { get; set; }
        public Nullable<Guid> IDPflegeplan { get; set; }
        public string GehörtZuGruppe { get; set; }
        public Nullable<int> BerufsstandHierarchie { get; set; }
        public Nullable<DateTime> DatumErstellt { get; set; }
        public string lstZusatzIDs { get; set; }
        public Nullable<bool> HAGPflichtigJN { get; set; }
        public Nullable<Guid> IDBefund { get; set; }
        public Nullable<bool> RMOptionalJN { get; set; }
        public string LogInNameFrei { get; set; }

        [Key]
        public Guid IDKey { get; set; }
    }
}

