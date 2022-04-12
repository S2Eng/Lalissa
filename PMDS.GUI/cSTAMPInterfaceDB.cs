using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using S2Extensions;

namespace PMDS.Global.db
{
    public class cSTAMPInterfaceDB
    {
        public static DateTime _Now { get; set; } = DateTime.Now;
        private static DateTime _Periode = _Now;
        private static DateTime _FirstOfPeriode = _Periode;
        private static DateTime _LastOfPeriode = _Periode;
        private static StringBuilder sbLog = new StringBuilder();

        private enum ErrorClass
        {
            Hinweis = 1,
            Warnung = 2,
            Kritisch = 3
        }

        private enum ErrorLogClass
        {
            Bewohnerliste = 0,
            Bewohnerdaten = 1,
            Aufenthalt = 2,
            VorherigeBetreuungsform =3,
            Kostentragung = 4,
            Abwesenheit = 5,
            Pflegegeldstufe = 6,
            Pflegegeldverfahren = 7
        }

        private enum AuswahllisteSucheTyp
        {
            ELGA_ID = 1,
            ELGA_Code = 2,
            Beschreibung = 3
        }

        private class CheckStatus
        {
            public StringBuilder sbLog = new StringBuilder();
            public bool BewohnerlisteOK = true;
            public bool BewohnerdatenOK = true;
            public bool AufenthaltOK = true;
            public bool VorherigeBetreuungsformOK = true;
            public bool KostentragungOK = true;
            public bool AbwesenheitOK = true;
            public bool PflegegeldstufeOK = true;
            public bool PflegegeldverfahrenOK = true;
        }

        public class Bewohnerliste
        {
            public Guid ID { get; set; } = Guid.NewGuid();
            public DateTime ErstelltAm { get; set; } = _Now;
            public List<Bewohnerdaten> bewohnerdaten { get; set; } = new List<Bewohnerdaten>();
            public StringBuilder sbLog { get; set; } = new StringBuilder();
            public bool IsInitialized { get; set; }
            public bool HasErrors { get; set; }
        }

        public class Bewohnerdaten
        {
            public string synonym { get; set; } = "";                             //ID von STAMP
            public string vorname { get; set; } = "";
            public string nachname { get; set; } = "";
            public DateTime geburtsdatum { get; set; } = DateTime.MinValue;
            public string staatsbuergerschaft { get; set; } = "";                  //Exakt drei Zeichen
            public string geschlecht { get; set; } = "";                          //Ein Zeichen {m, w, d, u } 
            public string letzteHauptwohnsitzgemeinde { get; set; } = "";         //Fünf Zeichen
            public bool forensicherHintergrund { get; set; }
            public bool gemeldetAmStandort { get; set; } = true;
            public string plz { get; set; } = "";                                 //Max. 10 
            public string ort { get; set; } = "";                                 //Max. 50
            public string strasse { get; set; } = "";                             //Max. 60
            public string hausnummer { get; set; } = "";                          //Max. 10
            public string synonymVorsystem { get; set; } = "";                    //Max. 50     //IDPatient
            public List<Aufenthalt> aufenthalte { get; } = new List<Aufenthalt>();
            public List<Pflegegeldstufe> pflegegeldstufen { get; } = new List<Pflegegeldstufe>();
            public List<Pflegegeldverfahren> pflegegeldverfahren { get; } = new List<Pflegegeldverfahren>();
            public Guid IDKlient { get; set; } = Guid.Empty;
            public StringBuilder sbErrLog { get; set; } = new StringBuilder();
            public bool HasError { get; set; }
        }

        public class Aufenthalt
        {
            public string letzteHauptwohnsitzgemeinde { get; set; } = "";
            public List<VorherigeBetreuungsform> vorherigeBetreuungsformen { get; set; } = new List<VorherigeBetreuungsform>();
            public DateTime eintrittsdatum { get; set; } = DateTime.MinValue;
            public DateTime austrittsdatum { get; set; }
            public string austrittWohin { get; set; } = "";              //{ BET_WOH. 24H_BET, AND_PH, TOD, SONST }
            public List<kostentragung> kostentragungen { get; } = new List<kostentragung>();
            public List<abwesenheit> abwesenheiten { get; } = new List<abwesenheit>();
            public Guid IDAufenthalt { get; set; } = Guid.Empty;
            public StringBuilder sbErrLog { get; set; } = new StringBuilder();
            public bool HasError { get; set; }
        }

        public class VorherigeBetreuungsform
        {
            public string vorherigeBeteuungsform { get; set; } = "";      //{ MOB_HK, TAGZ, BET_WOH, 24H_BET, AND_PH, KH, PRIV_BET, KEINE, SONST }
            public StringBuilder sbErrLog { get; set; } = new StringBuilder();
            public bool HasError { get; set; }

        }

        public class kostentragung
        {
            public string finanzierung { get; set; } = "";     //SZ, RESTK_13_xxx, RESTK_13_2_xxx, RESTK_19_xxx, BUND, AB_X, AS_XXX. SONST, LE_ZU_LAUFEND }
            public string finanzierungSonstige { get; set; } = "";
            public DateTime gueltigVon { get; set; } = DateTime.MinValue;
            public DateTime gueltigBis { get; set; } = DateTime.MaxValue;
            public StringBuilder sbErrLog { get; set; } = new StringBuilder();
            public bool HasError { get; set; }

        }

        public class abwesenheit
        {
            public string abwesenheitsgrund { get; set; } = "";   //{ PRIVAT, KH_KU_RE }
            public DateTime vonDatum { get; set; } = DateTime.MinValue;
            public DateTime bisDatum { get; set; } = DateTime.MaxValue;
            public Guid IDUrlaub { get; set; } = Guid.Empty;
            public StringBuilder sbErrLog { get; set; } = new StringBuilder();
            public bool HasError { get; set; }

        }

        public class Pflegegeldstufe
        {
            public string pflegegeldstufe { get; set; } = "";     // { keine, 1, 2, 3, 4, 5, 6, 7 }
            public DateTime gueltigVon { get; set; } = DateTime.MinValue;
            public DateTime gueltigBis { get; set; } = DateTime.MaxValue;
            public Guid IDPflegestufe { get; set; } = Guid.Empty;
            public StringBuilder sbErrLog { get; set; } = new StringBuilder();
            public bool HasError { get; set; }
        }

        public class Pflegegeldverfahren
        {
            public DateTime beantragtAm { get; set; }
            public string vorlaufigePflegegeldstufeVerrechnungPersonal { get; set; } = "";    // { keine, 1, 2, 3, 4, 5, 6, 7 }
            public DateTime kenntnisnahmeDatumBescheid { get; set; } = DateTime.MaxValue;
            public Guid IDPflegestufe { get; set; } = Guid.Empty;
            public StringBuilder sbErrLog { get; set; } = new StringBuilder();
            public bool HasError { get; set; }
        }

        public Bewohnerliste init(DateTime Periode)
        {
            try
            {
                if (Periode != null)
                {
                    _Periode = Periode;
                    _FirstOfPeriode = new DateTime(_Periode.Year, _Periode.Month, 1);
                    _LastOfPeriode = _FirstOfPeriode.AddMonths(1).AddSeconds(-1);
                }
                else
                {
                    sbLog.Append(AddLog("Kein gültiges Datum für die Meldeperiode.\n", ErrorClass.Kritisch));
                }

                Bewohnerliste lBew = new Bewohnerliste();
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    //distinct PatientenIDs der betroffenen Aufenthalte
                    var lstKlientenID = (from a in db.vAufenthaltsliste
                                         join pat in db.Patient on a.IDPatient equals pat.ID
                                         join adr in db.Adresse on pat.IDAdresse equals adr.ID
                                         where a.IDKlinik == ENV.IDKlinik &&
                                                (
                                                    (a.Entlassungszeitpunkt >= _FirstOfPeriode && a.Entlassungszeitpunkt < _LastOfPeriode) ||
                                                    (a.Aufnahmezeitpunkt >= _FirstOfPeriode && a.Aufnahmezeitpunkt < _LastOfPeriode) ||
                                                    (a.Aufnahmezeitpunkt < _FirstOfPeriode && (a.Entlassungszeitpunkt > _LastOfPeriode || a.Entlassungszeitpunkt == null))
                                                )
                                           select new
                                           {
                                               IDKlient = a.IDPatient,
                                               IDAufenthalt = a.IDAufenthalt,
                                               IDAdresse = adr.ID,
                                               //Klient
                                               pat_vorname = pat.Vorname,
                                               pat_nachname = pat.Nachname,
                                               pat_geburtsdatum = pat.Geburtsdatum,
                                               pat_staatsbürgerschaft = pat.Staatsb,
                                               pat_geschlecht = pat.Sexus,
                                               pat_forensicherHintergrund = pat.ForensischerHintergrund,      
                                               pat_gemeldetAmStandort = pat.WohnungAbgemeldetJN,
                                               pat_synonym = pat.STAMP_Synonym,                        
                                               //Adresse
                                               adr_plz = adr.Plz,
                                               adr_ort = adr.Ort,
                                               adr_strasse = adr.Strasse_OhneHausnummer,
                                               adr_hausnummer = adr.Hausnummer
                                           }).GroupBy(p => p.IDKlient).Select(g => g.FirstOrDefault()).OrderBy(g => g.pat_nachname).ThenBy(g => g.pat_vorname).ToList();


                    foreach (var kl in lstKlientenID)
                    {
                        Bewohnerdaten bew = new Bewohnerdaten();

                        bew.synonym = kl.pat_synonym;
                        bew.vorname = kl.pat_vorname;
                        bew.nachname = kl.pat_nachname;
                        bew.staatsbuergerschaft = kl.pat_staatsbürgerschaft;
                        bew.geschlecht = kl.pat_geschlecht;

                        if (kl.pat_forensicherHintergrund != null)
                            bew.forensicherHintergrund = (bool)kl.pat_forensicherHintergrund;
                        bew.gemeldetAmStandort = (bool)kl.pat_gemeldetAmStandort;
                        if (!bew.gemeldetAmStandort)
                        {
                            bew.plz = kl.adr_plz;
                            bew.ort = kl.adr_ort;
                            bew.strasse = kl.adr_strasse;
                            bew.hausnummer = kl.adr_hausnummer;
                        }
                        bew.synonymVorsystem = kl.IDKlient.ToString();
                        bew.IDKlient = kl.IDKlient;

                        lBew.bewohnerdaten.Add(bew);

                        //Aufenthalte zu Klient
                        var lstAufenthalte = (from a in db.vAufenthaltsliste
                                              join auf in db.Aufenthalt on a.IDAufenthalt equals auf.ID
                                              where a.IDPatient == kl.IDKlient
                                              select new
                                              {
                                                  IDAufenthalt = a.IDAufenthalt,
                                                  auf_letzteHauptwohnsitzgemeinde = auf.Hauptwohnsitzgemeinde,
                                                  auf_vorherigeBetreuungsform = "",
                                                  auf_eintrittsdatum = auf.Aufnahmezeitpunkt,
                                                  auf_austrittsdatum = auf.Entlassungszeitpunkt,
                                                  auf_austrittWohin = ""
                                              }).OrderBy(o => o.auf_eintrittsdatum).ToList();

                        foreach (var auf in lstAufenthalte)
                        {
                            Aufenthalt a = new Aufenthalt();
                            a.letzteHauptwohnsitzgemeinde = LookupAuswahllisteBezeichnung("GEM", auf.auf_letzteHauptwohnsitzgemeinde, AuswahllisteSucheTyp.ELGA_Code);

                            if (!String.IsNullOrEmpty((string)auf.auf_vorherigeBetreuungsform))
                            {
                                a.vorherigeBetreuungsformen = new List<VorherigeBetreuungsform>() { new VorherigeBetreuungsform { vorherigeBeteuungsform = (string)auf.auf_vorherigeBetreuungsform } };
                            }

                            a.eintrittsdatum = (DateTime)auf.auf_eintrittsdatum;

                            if (auf.auf_austrittsdatum != null)
                            {
                                a.austrittsdatum = (DateTime)auf.auf_austrittsdatum;
                            }

                            if (!String.IsNullOrEmpty((string)auf.auf_austrittWohin))
                            {
                                a.austrittWohin = (string)auf.auf_austrittWohin;
                            }

                            //Kostentragungen zu Aufenthalt
                            var kts = (from kt in db.STAMP_Kostentragungen
                                       where kt.IDAufenthalt == a.IDAufenthalt
                                       select new
                                       {
                                           kt.ID,
                                           kt.IDAufenthalt,
                                           kt.Finanzierung,
                                           kt.FinanzierungSonstige,
                                           kt.GueltigVon,
                                           kt.GueltigBis
                                       }).ToList();

                            foreach (var kt in kts)
                            {
                                kostentragung kostTrag = new kostentragung();
                                kostTrag.finanzierung = kt.Finanzierung;
                                kostTrag.finanzierungSonstige = kt.FinanzierungSonstige;
                                kostTrag.gueltigVon = kt.GueltigVon;
                                if (kt.GueltigBis != null)
                                    kostTrag.gueltigBis = (DateTime) kt.GueltigBis;
                                a.kostentragungen.Add(kostTrag);
                            }

                            //Abwesenheiten zu Aufenthalt
                            var abw = (from auf1 in db.Aufenthalt
                                       join url in db.UrlaubVerlauf on auf1.ID equals url.IDAufenthalt
                                       where auf1.ID == a.IDAufenthalt
                                       select new
                                       {
                                           abwesenheitsgrund = url.Text,
                                           gueltigVon = url.StartDatum,
                                           gueltigBis = url.EndeDatum
                                       }).ToList();

                            foreach (var ab in abw)
                            {
                                if (ab.gueltigBis != null)
                                {
                                    //Nur Abweseneheiten mit mindestens einer Nacht
                                    DateTime bis = (DateTime)ab.gueltigBis;
                                    DateTime von = (DateTime)ab.gueltigVon;
                                    if (bis.Date <= von.Date)
                                        continue;
                                }

                                abwesenheit abwh = new abwesenheit();
                                abwh.abwesenheitsgrund = LookupAuswahllisteBezeichnung("URL", ab.abwesenheitsgrund, AuswahllisteSucheTyp.Beschreibung);
                                abwh.vonDatum = (DateTime)ab.gueltigVon;
                                if (ab.gueltigBis != null)
                                {
                                    abwh.bisDatum = (DateTime)ab.gueltigBis;
                                }
                                a.abwesenheiten.Add(abwh);
                            }
                            bew.aufenthalte.Add(a);

                        }
                        //Pflegegeldstufen zum Klienten
                        var lPST = (from kl1 in db.Patient
                                    join pps in db.PatientPflegestufe on kl1.ID equals pps.IDPatient
                                    join ps in db.Pflegegeldstufe on pps.IDPflegegeldstufe equals ps.ID
                                    where kl1.ID == bew.IDKlient
                                    select new
                                    {
                                        ID = pps.ID,
                                        pflegegeldstufe = ps.StufeNr,
                                        gueltigVon = pps.GueltigAb,
                                        gueltigBis = pps.GueltigBis,
                                    }).ToList();

                        foreach (var ps in lPST)
                        {
                            Pflegegeldstufe pst = new Pflegegeldstufe();
                            pst.pflegegeldstufe = ps.pflegegeldstufe.ToString();
                            pst.gueltigVon = ps.gueltigVon;

                            if (ps.gueltigBis != null)
                            {
                                pst.gueltigBis = (DateTime)ps.gueltigBis;
                            }
                            bew.pflegegeldstufen.Add(pst);
                        }

                        //Pflegegeldverfahren zum Klienten
                        var lPSTV = (from kl1 in db.Patient
                                     join pps in db.PatientPflegestufe on kl1.ID equals pps.IDPatient
                                     join ps in db.Pflegegeldstufe on pps.IDPflegegeldstufeAntrag equals ps.ID
                                     where kl1.ID == bew.IDKlient &&
                                     pps.AenderungsantragDatum != null
                                     select new
                                     {
                                         ID = pps.ID,
                                         beantragtAm = pps.AenderungsantragDatum,
                                         vorlaeufigePflegegeldstufeVerrechnungPersonal = ps.StufeNr,
                                         kenntnisnahmeDatumBescheid = pps.GenehmigungDatum
                                     }).ToList();

                        foreach (var psv in lPSTV)
                        {
                            Pflegegeldverfahren pgv = new Pflegegeldverfahren();
                            pgv.beantragtAm = (DateTime)psv.beantragtAm;
                            pgv.vorlaufigePflegegeldstufeVerrechnungPersonal = psv.vorlaeufigePflegegeldstufeVerrechnungPersonal == 0 ? "keine" : psv.vorlaeufigePflegegeldstufeVerrechnungPersonal.ToString();
                            if (psv.kenntnisnahmeDatumBescheid != null)
                            {
                                pgv.kenntnisnahmeDatumBescheid = (DateTime)psv.kenntnisnahmeDatumBescheid;
                            }
                            bew.pflegegeldverfahren.Add(pgv);
                        }

                    }
                }

                lBew.sbLog = CheckAll(lBew).sbLog;
                lBew.IsInitialized = true;
                return lBew;
            }
            catch (Exception ex)
            {
                Bewohnerliste lBewError = new Bewohnerliste();
                lBewError.sbLog.Append(ex.Message);
                return new Bewohnerliste();
            }
        }

        private CheckStatus CheckAll(Bewohnerliste lBew)
        {
            CheckStatus chk = new CheckStatus();
            foreach (Bewohnerdaten bew in lBew.bewohnerdaten)
            {
                chk.BewohnerdatenOK = true;
                if (String.IsNullOrWhiteSpace(LookupAuswahllisteBezeichnung("LND", bew.staatsbuergerschaft, AuswahllisteSucheTyp.ELGA_Code)))
                {
                    AddLog(ref chk, "Staatsbürgerschaft '" + bew.staatsbuergerschaft + "' ist kein gültiger Listeneintrag", ErrorLogClass.Bewohnerdaten, bew, null);
                }

                if (String.IsNullOrWhiteSpace(ConvertGeschlecht(bew.geschlecht)))
                {
                    AddLog(ref chk, "Geschlecht '" + bew.geschlecht + "' ist kein gültiger Listeneintrag", ErrorLogClass.Bewohnerdaten, bew, null);
                }

                if (!bew.pflegegeldstufen.Any())
                {
                    AddLog(ref chk, "Keine Pflegegeldstufe gefunden", ErrorLogClass.Pflegegeldstufe, bew, null);
                }

                foreach (Pflegegeldstufe pgs in bew.pflegegeldstufen)
                {
                    chk.PflegegeldstufeOK = true;
                }

                foreach (Pflegegeldverfahren pgf in bew.pflegegeldverfahren)
                {
                    chk.PflegegeldstufeOK = true;
                }

                foreach (Aufenthalt auf in bew.aufenthalte)
                {
                    chk.AufenthaltOK = true;

                    if (String.IsNullOrWhiteSpace(LookupAuswahllisteBezeichnung("GKZ", auf.letzteHauptwohnsitzgemeinde, AuswahllisteSucheTyp.Beschreibung)))
                    {
                        AddLog(ref chk, "Letzte Hauptwohnsitzgemeinde '" + bew.letzteHauptwohnsitzgemeinde + "' ist kein gültiger Listeneintrag", ErrorLogClass.Aufenthalt, bew, auf);
                    }

                    if (!auf.vorherigeBetreuungsformen.Any())
                    {
                        AddLog(ref chk, "Keine vorherigen Betreuungsform gefunden", ErrorLogClass.VorherigeBetreuungsform, bew, auf);
                    }
                    else
                    {
                        foreach (VorherigeBetreuungsform vbf in auf.vorherigeBetreuungsformen)
                        {
                            if (String.IsNullOrWhiteSpace(LookupAuswahllisteBezeichnung("VBF", vbf.vorherigeBeteuungsform, AuswahllisteSucheTyp.Beschreibung)))
                            {
                                AddLog(ref chk, "Vorhereige Betreuungsform '" + bew.letzteHauptwohnsitzgemeinde + "' ist kein gültiger Listeneintrag", ErrorLogClass.VorherigeBetreuungsform, bew, auf);
                            }
                        }
                    }

                    if (auf.austrittsdatum != DateTime.MinValue && String.IsNullOrWhiteSpace(LookupAuswahllisteBezeichnung("AWO", auf.austrittWohin, AuswahllisteSucheTyp.Beschreibung)))
                    {
                        AddLog(ref chk, "Austritt wohin' " + auf.austrittWohin + "' ist kein gültiger Listeneintrag", ErrorLogClass.Aufenthalt, bew, auf);
                    }

                    //Gültigkeit wird bereits in der Oberfläche geprüft, daher nur Prüfung, ob es mindestens eine gibt.
                    if (!auf.kostentragungen.Any())
                    {
                        AddLog(ref chk, "Keine Kostentragungen gefunden", ErrorLogClass.Kostentragung, bew, auf);
                    }

                    foreach (abwesenheit abw in auf.abwesenheiten)
                    {
                        chk.AbwesenheitOK = true;
                        if (String.IsNullOrWhiteSpace(LookupAuswahllisteBezeichnung("SAG", abw.abwesenheitsgrund, AuswahllisteSucheTyp.Beschreibung)))
                        {
                            AddLog(ref chk, "Abwesenheitsgrund '" + abw.abwesenheitsgrund + "' ist kein gültiger Listeneintrag bei Abwesenheit vom " + abw.vonDatum.ToString("dd.MM.yyyy"), ErrorLogClass.Abwesenheit, bew, auf);
                        }
                    }
                }

                if (!chk.BewohnerdatenOK)
                {
                    chk.sbLog.Append("\n");
                }
            }
            return chk;
        }

        private void AddLog(ref CheckStatus chk, string txtLog, ErrorLogClass elc, Bewohnerdaten bew, Aufenthalt auf)
        {
            AddHeaderToLog(ref chk, bew, auf);

            switch (elc) { 
                case ErrorLogClass.Bewohnerliste:
                    break;

                case ErrorLogClass.Bewohnerdaten:
                    chk.sbLog.Append("> " + txtLog + "\n");
                    break;

                case ErrorLogClass.Aufenthalt:
                    chk.sbLog.Append("   " + txtLog + "\n");
                    break;
                
                case ErrorLogClass.VorherigeBetreuungsform:
                    chk.VorherigeBetreuungsformOK = false;
                    chk.sbLog.Append("   " + txtLog + "\n");
                    break;
                
                case ErrorLogClass.Kostentragung:
                    chk.KostentragungOK = false;
                    chk.sbLog.Append("   " + txtLog + "\n");
                    break;
                
                case ErrorLogClass.Abwesenheit:
                    chk.AbwesenheitOK = false;
                    chk.sbLog.Append("   " + txtLog + "\n");
                    break;
                
                case ErrorLogClass.Pflegegeldstufe:
                    chk.PflegegeldstufeOK = false;
                    chk.sbLog.Append("> " + txtLog + "\n");
                    break;
                
                case ErrorLogClass.Pflegegeldverfahren:
                    chk.PflegegeldverfahrenOK = false;
                    chk.sbLog.Append("> " + txtLog + "\n");
                    break;
                
                default:
                    break;
            }
            chk.BewohnerlisteOK = false;
        }

        private void AddHeaderToLog (ref CheckStatus chk, Bewohnerdaten bew, Aufenthalt auf)
        {
            if (chk.BewohnerdatenOK)
            {
                chk.sbLog.Append(("---------- " + bew.nachname + " " + bew.vorname).Trim() + " ----------\n");
                chk.BewohnerdatenOK = false;
            }

            if (auf != null)
            {
                if (chk.AufenthaltOK)
                {
                    string strAbgeschlossen = auf.austrittsdatum == DateTime.MinValue ? "" : " (in Historie)";
                    chk.sbLog.Append(">>> Aufenthalt vom " + auf.eintrittsdatum.ToString("dd.MM.yyyy") + strAbgeschlossen + " <<<\n");
                    chk.AufenthaltOK = false;
                }
            }
        }

        private string LookupAuswahllisteBezeichnung(string IDAuswahllisteGruppe, string SearchValue, AuswahllisteSucheTyp SearchType)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var retValue = (from al in db.AuswahlListe
                                    where al.IDAuswahlListeGruppe == IDAuswahllisteGruppe && al.Bezeichnung == SearchValue
                                    select new
                                    {
                                        Bezeichnung = al.Bezeichnung,
                                        Beschreibung = al.Beschreibung,
                                        ELGA_Code = al.ELGA_Code,
                                        ELGA_ID = al.ELGA_ID
                                    }).FirstOrDefault();

                    if (retValue != null)
                    {
                        switch (SearchType)
                        {
                            case AuswahllisteSucheTyp.ELGA_ID:
                                return retValue.ELGA_ID.ToString();
                            case AuswahllisteSucheTyp.ELGA_Code:
                                return retValue.ELGA_Code;
                            case AuswahllisteSucheTyp.Beschreibung:
                                return retValue.Beschreibung;
                            default:
                                AddLog("Fehlerhafter Suchtyp für Auswahlliste " + IDAuswahllisteGruppe + ": " + SearchValue, ErrorClass.Kritisch);
                                return "";
                        }
                    }
                    else
                    {
                        AddLog("Fehlerhafter Listeneintrag in Auswahlliste " + IDAuswahllisteGruppe + ": " + SearchValue, ErrorClass.Kritisch);
                        return "";
                    }
                }
            }
            catch (Exception ex)
            {
                AddLog("Fehlerbei Suche in Auswahliste " + IDAuswahllisteGruppe + ": " + SearchValue + "\n" + ex.Message, ErrorClass.Kritisch);
                return "";
            }
        }

        private string ConvertGeschlecht(string GeschlechtIn)
        {
            try
            {
                if (GeschlechtIn.sEquals("Männliche Person"))
                    return "m";
                else if (GeschlechtIn.sEquals("Weibliche Person"))
                    return "w";
                else if (GeschlechtIn.sEquals("Divers"))
                    return "d";
                else
                    return "";
            }
            catch (Exception ex)
            {
                AddLog("Fehlerbei Suche in Umschlüsselung Geschlecht " + GeschlechtIn + "\n" + ex.Message, ErrorClass.Kritisch);
                return "";
            }
        }

        private string AddLog (string Text, ErrorClass Klasse, bool AddLineBreak = true)
        {
            return Klasse.ToString() + ": " + Text + (AddLineBreak ? "\n" : "");
        }

    }
}
