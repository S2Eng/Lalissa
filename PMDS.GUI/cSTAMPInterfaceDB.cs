using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using S2Extensions;

using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

using System.Threading;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace PMDS.Global.db
{
    public class cSTAMPInterfaceDB
    {
        public static DateTime _Now { get; set; } = DateTime.Now;
        private static DateTime _MinPeriode = new DateTime(2022, 4, 1);
        private static DateTime _Periode = _Now;
        private static DateTime _FirstOfPeriode = _Periode;
        private static DateTime _LastOfPeriode = _Periode;
        private static StringBuilder sbLog = new StringBuilder();
        private string dFormat = "dd.MM.yyyy";

        private string traeger = "";            //Abfrage von Rest-Service
        private string standort = "";           //Abfrage von Rest-Service

        private enum ErrorClass
        {
            Hinweis = 1,
            Warnung = 2,
            Kritisch = 3
        }

        public enum ServiceCallType
        {
            traeger = 1,
            standort = 2,
            bewohnermelden = 3,
            bewohnerupdate = 4
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

        public class CheckStatus
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

        //--------------------------- JSON - Strukturen für REST-Service, wird in CheckAll gefüllt -----------------
        public class JSONBewohnerdatenKurz
        {
            public string vorname { get; set; } = "";
            public string nachname { get; set; } = "";
            public string geburtsdatum { get; set; } = "";
            public string staatsbuergerschaft { get; set; } = "";                  //Exakt drei Zeichen
            public string geschlecht { get; set; } = "";                          //Ein Zeichen {m, w, d, u } 
            public bool forensicherHintergrund { get; set; }
            public bool gemeldetAmStandort { get; set; } = true;
            public string plz { get; set; } = "";                                 //Max. 10 
            public string ort { get; set; } = "";                                 //Max. 50
            public string strasse { get; set; } = "";                             //Max. 60
            public string hausnummer { get; set; } = "";                          //Max. 10
            public string synonymVorsystem { get; set; } = "";                    //Max. 50     //IDPatient
        }

        public class JSONBewohnerdaten
        {
            public string staatsbuergerschaft { get; set; } = "";                  //Exakt drei Zeichen
            public string geschlecht { get; set; } = "";                          //Ein Zeichen {m, w, d, u } 
            public bool forensicherHintergrund { get; set; }
            public string synonymVorsystem { get; set; } = "";                    //Max. 50     //IDPatient
            public JSONAufenthalt[] aufenthalte { get; set; } = Array.Empty<JSONAufenthalt>();
            public JSONPflegegeldstufe[] pflegegeldstufen { get; set; } = Array.Empty<JSONPflegegeldstufe>();
            public JSONPflegegeldverfahren[] pflegegeldverfahren { get; set; } = Array.Empty<JSONPflegegeldverfahren>();
        }

        public class JSONAufenthalt
        {
            public string letzteHauptwohnsitzgemeinde { get; set; } = "";
            public JSONVorherigeBetreuungsform[] vorherigeBetreuungsformen { get; set; }
            public string eintrittsdatum { get; set; } = "";
            public string austrittsdatum { get; set; }
            public string austrittWohin { get; set; } = "";              //{ BET_WOH. 24H_BET, AND_PH, TOD, SONST }
            public JSONkostentragung[] kostentragungen { get; set; } = Array.Empty<JSONkostentragung>();
            public JSONabwesenheit[] abwesenheiten { get; set; } = Array.Empty<JSONabwesenheit>();
        }

        public class JSONVorherigeBetreuungsform
        {
            public string vorherigeBeteuungsform { get; set; } = "";     //{ MOB_HK, TAGZ, BET_WOH, 24H_BET, AND_PH, KH, PRIV_BET, KEINE, SONST }
        }

        public class JSONkostentragung
        {
            public string finanzierung { get; set; } = "";     //SZ, RESTK_13_xxx, RESTK_13_2_xxx, RESTK_19_xxx, BUND, AB_X, AS_XXX. SONST, LE_ZU_LAUFEND }
            public string finanzierungSonstige { get; set; } = "";
            public string gueltigVon { get; set; }
            public string gueltigBis { get; set; }
        }

        public class JSONabwesenheit
        {
            public string abwesenheitsgrund { get; set; } = "";   //{ PRIVAT, KH_KU_RE }
            public string datumVon { get; set; } 
            public string datumBis { get; set; }
        }

        public class JSONPflegegeldstufe
        {
            public string pflegegeldstufe { get; set; } = "";     // { keine, 1, 2, 3, 4, 5, 6, 7 }
            public string gueltigVon { get; set; }
            public string gueltigBis { get; set; }
        }

        public class JSONPflegegeldverfahren
        {
            public string beantragtAm { get; set; }
            public string vorlaufigePflegegeldstufeVerrechnungPersonal { get; set; } = "";    // { keine, 1, 2, 3, 4, 5, 6, 7 }
            public string kenntnisnahmeDatumBescheid { get; set; }
        }

        //--------------------------- C# - Strukturen für Check -----------------
        public class Bewohnerdaten
        {
            public string synonym { get; set; } = "";                             //ID von STAMP
            public string vorname { get; set; } = "";
            public string nachname { get; set; } = "";
            public DateTime geburtsdatum { get; set; } = DateTime.MinValue;
            public string staatsbuergerschaft { get; set; } = "";                 
            public string geschlecht { get; set; } = "";                         
            public string letzteHauptwohnsitzgemeinde { get; set; } = "";         
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
            public JSONBewohnerdatenKurz JSONKurz { get; set; } = new JSONBewohnerdatenKurz();
            public JSONBewohnerdaten JSON { get; set; } = new JSONBewohnerdaten();
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
            public string Gemeinde { get; set; } = "";
            public string Bundesland { get; set; } = "";
            public string Land { get; set; } = "";
            public DateTime gueltigVon { get; set; } = DateTime.MinValue;
            public DateTime gueltigBis { get; set; } = DateTime.MaxValue;
            public StringBuilder sbErrLog { get; set; } = new StringBuilder();
            public bool HasError { get; set; }

        }

        public class abwesenheit
        {
            public string abwesenheitsgrund { get; set; } = "";   //{ PRIVAT, KH_KU_RE }
            public DateTime datumVon { get; set; } = DateTime.MinValue;
            public DateTime datumBis { get; set; } = DateTime.MaxValue;
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

        public bool Init(DateTime Periode)
        {
            try
            {

                if (Periode != null)
                {
                    if (Periode < _MinPeriode)
                    {
                        return false;
                    }
                    else
                    {
                        _Periode = Periode;
                        _FirstOfPeriode = new DateTime(_Periode.Year, _Periode.Month, 1);
                        _LastOfPeriode = _FirstOfPeriode.AddMonths(1).AddSeconds(-1);
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Bewohnerliste LoadBewohnerliste()
        {
            try
            {
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
                        bew.geburtsdatum = (DateTime)kl.pat_geburtsdatum;
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
                                              && (
                                                    (auf.Aufnahmezeitpunkt < _LastOfPeriode && auf.Entlassungszeitpunkt == null) ||
                                                    (auf.Aufnahmezeitpunkt <= _LastOfPeriode && auf.Aufnahmezeitpunkt >= _MinPeriode)
                                                 )
                                              select new
                                              {
                                                  IDAufenthalt = a.IDAufenthalt,
                                                  auf_letzteHauptwohnsitzgemeinde = auf.Hauptwohnsitzgemeinde,
                                                  auf_vorherigeBetreuungsform = auf.STAMP_VorherigeBetreuungsformen,
                                                  auf_eintrittsdatum = auf.Aufnahmezeitpunkt,
                                                  auf_austrittsdatum = auf.Entlassungszeitpunkt,
                                                  auf_austrittWohin = auf.STAMP_AustrittWohin
                                              }).OrderBy(o => o.auf_eintrittsdatum).ToList();

                        foreach (var auf in lstAufenthalte)
                        {
                            Aufenthalt a = new Aufenthalt();
                            a.letzteHauptwohnsitzgemeinde = auf.auf_letzteHauptwohnsitzgemeinde;  

                            if (!String.IsNullOrEmpty((string)auf.auf_vorherigeBetreuungsform))
                            {
                                string[] vbf = auf.auf_vorherigeBetreuungsform.ToString().Split(new char[] { ';' }, 1);
                                a.vorherigeBetreuungsformen = new List<VorherigeBetreuungsform>();
                                foreach (string v in vbf)
                                {
                                    a.vorherigeBetreuungsformen.Add(new VorherigeBetreuungsform { vorherigeBeteuungsform = v.Replace(";", "") });
                                }
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
                                       where kt.IDAufenthalt == auf.IDAufenthalt
                                       select new
                                       {
                                           kt.ID,
                                           kt.IDAufenthalt,
                                           kt.Finanzierung,
                                           kt.Gemeinde,
                                           kt.Bundesland,
                                           kt.Land,
                                           kt.FinanzierungSonstige,
                                           kt.GueltigVon,
                                           kt.GueltigBis
                                       }).ToList();

                            foreach (var kt in kts)
                            {
                                kostentragung kostTrag = new kostentragung();
                                kostTrag.finanzierung = kt.Finanzierung;
                                kostTrag.Gemeinde = kt.Gemeinde;
                                kostTrag.Bundesland = kt.Bundesland;
                                kostTrag.Land = kt.Land;
                                kostTrag.finanzierungSonstige = kt.FinanzierungSonstige;
                                kostTrag.gueltigVon = kt.GueltigVon;
                                if (kt.GueltigBis != null)
                                    kostTrag.gueltigBis = (DateTime)kt.GueltigBis;
                                a.kostentragungen.Add(kostTrag);
                            }

                            //Abwesenheiten zu Aufenthalt
                            var abw = (from auf1 in db.Aufenthalt
                                       join url in db.UrlaubVerlauf on auf1.ID equals url.IDAufenthalt
                                       where auf1.ID == auf.IDAufenthalt
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
                                abwh.datumVon = (DateTime)ab.gueltigVon;
                                if (ab.gueltigBis != null)
                                {
                                    abwh.datumBis = (DateTime)ab.gueltigBis;
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

                        //bew.JSON = JsonConvert.SerializeObject(bew.);
                    }
                }
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

        public CheckStatus CheckAll(ref Bewohnerliste lBew)
        {
            CheckStatus chk = new CheckStatus();
            int i = 0;
            int j = 0;

            foreach (Bewohnerdaten bew in lBew.bewohnerdaten)
            {
                chk.BewohnerdatenOK = true;
                //Strukturen für Bewohnerdaten-Neumeldung (JSONKurz) und Bewohnerdaten-Update (JSON) erzeugen

                bew.JSONKurz.vorname = bew.vorname;
                bew.JSONKurz.nachname = bew.nachname;
                bew.JSONKurz.geburtsdatum = bew.geburtsdatum.ToString(dFormat);
                
                bew.JSONKurz.staatsbuergerschaft = LookupAuswahllisteBezeichnung("LND", bew.staatsbuergerschaft, AuswahllisteSucheTyp.ELGA_Code);
                if (String.IsNullOrWhiteSpace(bew.JSON.staatsbuergerschaft))
                {
                    AddLog(ref chk, "Staatsbürgerschaft '" + bew.staatsbuergerschaft + "' ist kein gültiger Listeneintrag", ErrorLogClass.Bewohnerdaten, bew, null);
                }
                bew.JSON.staatsbuergerschaft = bew.JSONKurz.staatsbuergerschaft;

                bew.JSONKurz.geschlecht = ConvertGeschlecht(bew.geschlecht);
                if (String.IsNullOrWhiteSpace(bew.JSON.geschlecht))
                {
                    AddLog(ref chk, "Geschlecht '" + bew.geschlecht + "' ist kein gültiger Listeneintrag", ErrorLogClass.Bewohnerdaten, bew, null);
                }
                bew.JSON.geschlecht = bew.JSONKurz.geschlecht;

                bew.JSONKurz.forensicherHintergrund = bew.forensicherHintergrund;
                bew.JSON.forensicherHintergrund = bew.JSON.forensicherHintergrund;

                bew.JSONKurz.gemeldetAmStandort = bew.gemeldetAmStandort;
                bew.JSONKurz.plz = bew.plz;
                bew.JSONKurz.ort = bew.ort;
                bew.JSONKurz.strasse = bew.strasse;
                bew.JSONKurz.hausnummer = bew.hausnummer;
                
                bew.JSONKurz.synonymVorsystem = bew.synonymVorsystem;
                bew.JSON.synonymVorsystem = bew.JSONKurz.synonymVorsystem;

                if (!bew.pflegegeldstufen.Any())
                {
                    AddLog(ref chk, "Keine Pflegegeldstufe gefunden", ErrorLogClass.Pflegegeldstufe, bew, null);
                }

                bew.JSON.pflegegeldstufen = new JSONPflegegeldstufe[bew.pflegegeldstufen.Count];
                i = 0;
                foreach (Pflegegeldstufe pgs in bew.pflegegeldstufen)
                {
                    JSONPflegegeldstufe jpgs = new JSONPflegegeldstufe();
                    jpgs.pflegegeldstufe = pgs.pflegegeldstufe;
                    jpgs.gueltigVon = pgs.gueltigVon.ToString(dFormat);
                    jpgs.gueltigBis = pgs.gueltigBis.ToString(dFormat);
                    bew.JSON.pflegegeldstufen[i] = jpgs;
                    i++;
                    chk.PflegegeldstufeOK = true;
                }

                bew.JSON.pflegegeldverfahren = new JSONPflegegeldverfahren[bew.pflegegeldverfahren.Count];
                i = 0;
                foreach (Pflegegeldverfahren pgv in bew.pflegegeldverfahren)
                {
                    JSONPflegegeldverfahren jpgv = new JSONPflegegeldverfahren();
                    jpgv.beantragtAm = pgv.beantragtAm.ToString(dFormat);
                    jpgv.vorlaufigePflegegeldstufeVerrechnungPersonal = pgv.vorlaufigePflegegeldstufeVerrechnungPersonal;
                    jpgv.kenntnisnahmeDatumBescheid = pgv.kenntnisnahmeDatumBescheid.ToString(dFormat);
                    bew.JSON.pflegegeldverfahren[i] = jpgv;
                    i++;
                    chk.PflegegeldstufeOK = true;
                }

                bew.JSON.aufenthalte = new JSONAufenthalt[bew.aufenthalte.Count];
                i = 0;
                foreach (Aufenthalt auf in bew.aufenthalte)
                {
                    chk.AufenthaltOK = true;

                    JSONAufenthalt jauf = new JSONAufenthalt();
                    jauf.letzteHauptwohnsitzgemeinde = LookupAuswahllisteBezeichnung("GKZ", auf.letzteHauptwohnsitzgemeinde, AuswahllisteSucheTyp.Beschreibung);
                    if (String.IsNullOrWhiteSpace(jauf.letzteHauptwohnsitzgemeinde))
                    {
                        AddLog(ref chk, "Letzte Hauptwohnsitzgemeinde '" + auf.letzteHauptwohnsitzgemeinde + "' ist kein gültiger Listeneintrag", ErrorLogClass.Aufenthalt, bew, auf);
                    }

                    if (!auf.vorherigeBetreuungsformen.Any())
                    {
                        AddLog(ref chk, "Keine vorherigen Betreuungsform gefunden", ErrorLogClass.VorherigeBetreuungsform, bew, auf);
                    }
                    else
                    {
                        jauf.vorherigeBetreuungsformen = new JSONVorherigeBetreuungsform[auf.vorherigeBetreuungsformen.Count];
                        j = 0;
                        foreach (VorherigeBetreuungsform vbf in auf.vorherigeBetreuungsformen)
                        {
                            JSONVorherigeBetreuungsform jvbf = new JSONVorherigeBetreuungsform();
                            jvbf.vorherigeBeteuungsform = LookupAuswahllisteBezeichnung("VBF", vbf.vorherigeBeteuungsform, AuswahllisteSucheTyp.Beschreibung);
                            jauf.vorherigeBetreuungsformen[j] = jvbf;
                            j++;
                            if (String.IsNullOrWhiteSpace(jvbf.vorherigeBeteuungsform))
                            {
                                AddLog(ref chk, "Vorhereige Betreuungsform '" + bew.letzteHauptwohnsitzgemeinde + "' ist kein gültiger Listeneintrag", ErrorLogClass.VorherigeBetreuungsform, bew, auf);
                            }
                        }
                    }

                    jauf.eintrittsdatum = auf.eintrittsdatum.ToString(dFormat);
                    
                    jauf.austrittWohin = LookupAuswahllisteBezeichnung("AWO", auf.austrittWohin, AuswahllisteSucheTyp.Beschreibung);
                    if (auf.austrittsdatum != DateTime.MinValue && String.IsNullOrWhiteSpace(jauf.austrittWohin))
                    {
                        AddLog(ref chk, "Austritt wohin' " + auf.austrittWohin + "' ist kein gültiger Listeneintrag", ErrorLogClass.Aufenthalt, bew, auf);
                    }

                    //Gültigkeit wird bereits in der Oberfläche geprüft
                    if (!auf.kostentragungen.Any())
                    {
                        AddLog(ref chk, "Keine Kostentragungen gefunden", ErrorLogClass.Kostentragung, bew, auf);
                    }

                    jauf.kostentragungen = new JSONkostentragung[auf.kostentragungen.Count];
                    j = 0;
                    foreach (kostentragung kt in auf.kostentragungen)
                    {
                        JSONkostentragung jkt = new JSONkostentragung();
                        jkt.finanzierung = LookupAuswahllisteBezeichnung("SFI", kt.finanzierung, AuswahllisteSucheTyp.Beschreibung);  //Prüfung erfolgt bereits in der GUI
                        string Gemeinde = LookupAuswahllisteBezeichnung("GKZ", kt.Gemeinde, AuswahllisteSucheTyp.Beschreibung);
                        string Bundesland = LookupAuswahllisteBezeichnung("GKZ", kt.Bundesland, AuswahllisteSucheTyp.Beschreibung);
                        string Land = LookupAuswahllisteBezeichnung("LND", kt.Land, AuswahllisteSucheTyp.ELGA_Code);

                        switch (jkt.finanzierung) 
                        {
                            case "RESTK_13_":
                            case "RESTK_13_2_":
                            case "RESTK_19_":
                                jkt.finanzierung += Gemeinde.Substring(0, 3);
                                break;
                            case "AB_":
                                jkt.finanzierung += Bundesland.Substring(0, 1);
                                break;
                            case "AS_":
                                jkt.finanzierung += Land;
                                break;
                            case "SONST":
                                jkt.finanzierungSonstige = jkt.finanzierungSonstige;
                                break;
                        }
                        jkt.gueltigVon = kt.gueltigVon.ToString(dFormat);
                        jkt.gueltigBis = kt.gueltigBis.ToString(dFormat);
                        jauf.kostentragungen[j] = jkt;
                        j++;
                    }

                    jauf.abwesenheiten = new JSONabwesenheit[auf.abwesenheiten.Count];
                    j = 0;
                    foreach (abwesenheit abw in auf.abwesenheiten)
                    {
                        chk.AbwesenheitOK = true;

                        JSONabwesenheit jabw = new JSONabwesenheit();
                        jabw.abwesenheitsgrund = LookupAuswahllisteBezeichnung("SAG", abw.abwesenheitsgrund, AuswahllisteSucheTyp.Beschreibung);
                        if (String.IsNullOrWhiteSpace(jabw.abwesenheitsgrund))
                        {
                            AddLog(ref chk, "Abwesenheitsgrund '" + abw.abwesenheitsgrund + "' ist kein gültiger Listeneintrag bei Abwesenheit vom " + abw.datumVon.ToString("dd.MM.yyyy"), ErrorLogClass.Abwesenheit, bew, auf);
                        }
                        jabw.datumVon = abw.datumVon.ToString(dFormat);
                        jabw.datumBis = abw.datumBis.ToString(dFormat);
                        jauf.abwesenheiten[j] = jabw;
                        j++;
                    }
                    bew.JSON.aufenthalte[i] = jauf;
                }

                if (!chk.BewohnerdatenOK)
                {
                    lBew.HasErrors = true;
                    chk.sbLog.Append("\n");
                }
            }
            lBew.sbLog = chk.sbLog;

            string res = JsonConvert.SerializeObject(lBew.bewohnerdaten[2].JSON, Formatting.Indented);

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

        //------------------------------------------------------------------------------------------------------------
        //--   Service Calls
        //------------------------------------------------------------------------------------------------------------

        static async Task<RestResponse> CallService(ServiceCallType scType, string traeger, string standort, string synonym, object value)
        {
            CancellationToken cancellationToken = new CancellationToken();

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

            var certFile = System.IO.Path.Combine(@"C:\", "temp", "s2engineer_test_appuser.pfx");
            X509Certificate2 certificate = new X509Certificate2(certFile, "kjhg8830MNB11000MNB11000MNB11000MNB11000MNB");

            RestClientOptions ro = new RestClientOptions(ENV.STAMP_URL)
            {
                ClientCertificates = new X509CertificateCollection() { certificate },
                Proxy = new WebProxy()
            };

            using (RestClient client = new RestClient(ro))
            {
                if (scType == ServiceCallType.traeger)
                {
                    var request = new RestRequest("/traeger", Method.Get);
                    request.RequestFormat = RestSharp.DataFormat.Json;
                    RestResponse result = await client.ExecuteGetAsync(request, cancellationToken);
                    return result;
                }
                else if (scType == ServiceCallType.standort)
                {
                    var request = new RestRequest("/traeger/" + traeger + "/standort", Method.Get);
                    request.RequestFormat = RestSharp.DataFormat.Json;
                    RestResponse result = await client.ExecuteGetAsync(request, cancellationToken);
                    return result;
                }
                else if(scType == ServiceCallType.bewohnermelden)
                {
                    var request = new RestRequest("/traeger/" + traeger + "/standort/" + standort + "/bewohner", Method.Post);
                    request.RequestFormat = RestSharp.DataFormat.Json;
                    request.AddParameter("application/json", value, ParameterType.RequestBody);
                    RestResponse result = await client.ExecutePostAsync(request, cancellationToken);
                    return result;
                }
                else if (scType == ServiceCallType.bewohnerupdate)
                {
                    var request = new RestRequest("/traeger/" + traeger + "/standort/" + standort + "/bewohner/" + synonym, Method.Post);
                    request.RequestFormat = RestSharp.DataFormat.Json;
                    request.AddParameter("application/json", value.ToString(), ParameterType.RequestBody);
                    RestResponse result = await client.ExecutePostAsync(request, cancellationToken);
                    return result;
                }
                return null;
            }
        }

        public async Task<bool> StartBewohnerMelden(ServiceCallType sc, Bewohnerliste lBew)
        {
            try
            {
                await StartService(ServiceCallType.traeger, "", null);
                await StartService(ServiceCallType.standort, "", null);

                foreach(Bewohnerdaten bew in lBew.bewohnerdaten)
                {
                    if (String.IsNullOrWhiteSpace(bew.synonym) && !bew.HasError)
                    {
                        if (sc == ServiceCallType.bewohnermelden)
                        {
                            await StartService(sc, "", JsonConvert.SerializeObject(bew.JSONKurz, Formatting.Indented));
                        }
                        else if (sc == ServiceCallType.bewohnerupdate)
                        {
                            await StartService(sc, "", JsonConvert.SerializeObject(bew.JSON, Formatting.Indented));
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                lBew.sbLog.Clear();
                lBew.sbLog.Append(ex.Message);
                return false;
            }
        }

        //--------------------------- Service-Calls --------------------------------
        private async Task<RestResponse> StartService(ServiceCallType scType, string synonym, object value)
        {
            try
            {
                RestResponse resp = new RestResponse();

                if (scType == ServiceCallType.traeger)
                {
                    resp = await CallService(scType, "", "", "", "");
                    if (resp.IsSuccessful)
                    {
                        var objects = JArray.Parse(resp.Content); // parse as array  
                        foreach (JObject root in objects)
                        {
                            foreach (KeyValuePair<String, JToken> app in root)
                            {
                                if (app.Key.sEquals("sekID"))
                                {
                                    traeger = app.Value.ToString();
                                    break;
                                }
                            }
                        }
                    }
                }

                else if (scType == ServiceCallType.standort)
                {
                    resp = await CallService(scType, traeger, "", "", "");
                    if (resp.IsSuccessful)
                    {
                        var objects = JArray.Parse(resp.Content); // parse as array  
                        foreach (JObject root in objects)
                        {
                            foreach (KeyValuePair<String, JToken> app in root)
                            {
                                if (app.Key.sEquals("id"))
                                {
                                    standort = app.Value.ToString();
                                    break;
                                }
                            }
                        }
                    }
                }

                else if (scType == ServiceCallType.bewohnermelden)
                {
                    resp = await CallService(scType, traeger, standort, "", value);
                    if (resp.IsSuccessful)
                    {
                        
                    }
                }

                else if (scType == ServiceCallType.bewohnerupdate)
                {
                    //Bewohnername entfernen

                    resp = await CallService(scType, traeger, standort, synonym, value);
                    if (resp.IsSuccessful)
                    {

                    }
                }
                return resp;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                throw new Exception(ex.ToString());
            }
        }
    }
}
