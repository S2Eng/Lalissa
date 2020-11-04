using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WCFServicePMDS.Models.DB
{
    public partial class vInterventionen2
    {
        public vInterventionen2()
        {

        }

        public bool Auswahl { get; set; }
        public string von { get; set; }
        public string bis { get; set; }

        public string Klient { get; set; }
        public string Geburtsdatum { get; set; }
        public string Maßnahme { get; set; }
        public string AnmerkungUndHinweis { get; set; }
        public string Anmerkung { get; set; }
        public string Warnhinweis { get; set; }
        public string AnmerkungRTF { get; set; }
        public string Lokalisierung { get; set; }
        public string Klinik { get; set; }
        public string Abteilung { get; set; }
        public string Bereich { get; set; }
        public string BenutzerErstellt { get; set; }
        public string BenutzerGeändert { get; set; }
        public string BerufsstandSoll { get; set; }
        public int Eintragstyp { get; set; }
        public int UrlaubJN { get; set; }
        public int EntlassenJN { get; set; }
        public string IDBezug { get; set; }
        public string lstIDPDx { get; set; }
        public string lstBDxBezeichnung { get; set; }
        public int AbgesetztJN { get; set; }
        public bool EinmaligJN { get; set; }
        public int ErledigtJN { get; set; }
        public bool GelöschtJN { get; set; }
        public bool PrivatJN { get; set; }
        public bool OhneZeitbezugJN { get; set; }
        public int MitPflegediagnoseAbzeichnenJN { get; set; }
        public bool ÜberfälligJN { get; set; }
        public int TerminJN { get; set; }
        public Nullable<DateTime> Startdatum { get; set; }
        public Nullable<DateTime> ZuErledigenBis { get; set; }
        public Nullable<Guid> IDPflegeplan { get; set; }
        public Nullable<Guid> IDUntertaegigeGruppe { get; set; }

        public Nullable<Guid> IDAufenthalt { get; set; }
        public Nullable<Guid> IDKlinik { get; set; }
        public Nullable<Guid> IDAbteilung { get; set; }
        public Nullable<Guid> IDBereich { get; set; }
        public Nullable<Guid> IDKlient { get; set; }
        public Nullable<Guid> IDEintrag { get; set; }
        public Nullable<Guid> IDBenutzer_Erstellt { get; set; }
        public Nullable<Guid> IDBenutzer_Geaendert { get; set; }
        public Nullable<Guid> IDBerufsstand { get; set; }
        public Nullable<Guid> IDLinkDokument { get; set; }
        public Nullable<DateTime> vonDatum { get; set; }
        public Nullable<DateTime> bisDatum { get; set; }
        public Nullable<Guid> IDBefund { get; set; }
        public bool RMOptionalJN { get; set; }
        public string LogInNameFrei { get; set; }

        [Key]
        public Guid IDKey { get; set; }
    }
}
