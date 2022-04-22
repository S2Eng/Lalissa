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

using System.IO;

namespace PMDS.Global.db
{
    public class cSTAMPInterfaceDB
    {
        public event Action LoadAll = delegate { };
        public event Action ShowLog = delegate { };
        public event Action SaveServiceResult = delegate { };

        private DateTime _Now { get; set; } = DateTime.Now;
        private string _ServiceLogID { get; set; } = "";
        private static DateTime _MinPeriode = new DateTime(2022, 4, 1);
        private DateTime _Periode;
        private DateTime _FirstOfPeriode;
        private DateTime _LastOfPeriode;

        private string dFormat = "dd.MM.yyyy";
        private Bewohnerliste lBew = new Bewohnerliste();

        private string traeger = "";            //Abfrage von Rest-Service
        private string standort = "";           //Abfrage von Rest-Service
        private string certFile = "";           //Von Festplatte
        private string STAMP_PW = "";           //Von Festplatte

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
            public DateTime ErstelltAm { get; set; }
            public String ServiceLogID { get; set; }
            public List<Bewohnerdaten> bewohnerdaten { get; set; } = new List<Bewohnerdaten>();
            public StringBuilder sbLog { get; set; } = new StringBuilder();
            public StringBuilder sbLogOk { get; set; } = new StringBuilder();
            public StringBuilder sbLogNoSynonym { get; set; } = new StringBuilder();
            public StringBuilder sbLogServiceCalls { get; set; } = new StringBuilder();
            public int NeueBewohner { get; set; }
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
            public bool forensischerHintergrund { get; set; }
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
            public bool forensischerHintergrund { get; set; }
            public string synonymVorsystem { get; set; } = "";                    //Max. 50     //IDPatient
            public JSONAufenthalt[] aufenthalte { get; set; } = Array.Empty<JSONAufenthalt>();
            public JSONPflegegeldstufe[] pflegegeldstufen { get; set; } = Array.Empty<JSONPflegegeldstufe>();
            public JSONPflegegeldverfahren[] pflegegeldverfahren { get; set; } = Array.Empty<JSONPflegegeldverfahren>();
        }

        public class JSONAufenthalt
        {
            public string letzteHauptwohnsitzgemeinde { get; set; }
            public string[] vorherigeBetreuungsformen { get; set; }
            public string eintrittsdatum { get; set; } = "";
            public string austrittsdatum { get; set; }
            public string austrittWohin { get; set; }           //{ BET_WOH. 24H_BET, AND_PH, TOD, SONST }
            public JSONkostentragung[] kostentragungen { get; set; } = Array.Empty<JSONkostentragung>();
            public JSONabwesenheit[] abwesenheiten { get; set; } = Array.Empty<JSONabwesenheit>();
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
            public string vorlauefigePflegegeldstufePersonal { get; set; } = "";    // { keine, 1, 2, 3, 4, 5, 6, 7 }
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
            public bool forensischerHintergrund { get; set; }
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
            public List<string> vorherigeBetreuungsformen { get; set; } = new List<string>();
            public DateTime eintrittsdatum { get; set; } = DateTime.MinValue;
            public DateTime austrittsdatum { get; set; }
            public string austrittWohin { get; set; }               //{ BET_WOH. 24H_BET, AND_PH, TOD, SONST }
            public List<kostentragung> kostentragungen { get; } = new List<kostentragung>();
            public List<abwesenheit> abwesenheiten { get; } = new List<abwesenheit>();
            public Guid IDAufenthalt { get; set; } = Guid.Empty;
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
            public string vorlauefigePflegegeldstufePersonal { get; set; } = "";    // { keine, 1, 2, 3, 4, 5, 6, 7 }
            public DateTime kenntnisnahmeDatumBescheid { get; set; } = DateTime.MaxValue;
            public Guid IDPflegestufe { get; set; } = Guid.Empty;
            public StringBuilder sbErrLog { get; set; } = new StringBuilder();
            public bool HasError { get; set; }
        }

        //----------------------------- Funktionen ----------------------------
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
                        _Now = DateTime.Now;
                        _Periode = Periode;
                        _FirstOfPeriode = new DateTime(_Periode.Year, _Periode.Month, 1);
                        _LastOfPeriode = _FirstOfPeriode.AddMonths(1).AddSeconds(-1);
                        _ServiceLogID = "STAMP_ServiceLog_" + _Now.ToString("yyyyMMddHHmmssffff") + ".log";
                        lBew.ErstelltAm = _Now;
                        lBew.ServiceLogID = _ServiceLogID;
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
                                             pat_forensischerHintergrund = pat.ForensischerHintergrund,
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
                        if (String.IsNullOrWhiteSpace(bew.synonym))
                        {
                            lBew.NeueBewohner++;
                        }

                        if (kl.pat_nachname == "Bachler")
                        {
                            string x = "";
                        }
                        bew.vorname = kl.pat_vorname;
                        bew.nachname = kl.pat_nachname;
                        bew.geburtsdatum = (DateTime)kl.pat_geburtsdatum;
                        bew.staatsbuergerschaft = kl.pat_staatsbürgerschaft;
                        bew.geschlecht = kl.pat_geschlecht;

                        if (kl.pat_forensischerHintergrund != null)
                            bew.forensischerHintergrund = (bool)kl.pat_forensischerHintergrund;
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
                                                    (auf.Aufnahmezeitpunkt <= _LastOfPeriode && auf.Aufnahmezeitpunkt >= _MinPeriode ||
                                                     auf.Aufnahmezeitpunkt <= _LastOfPeriode && auf.Entlassungszeitpunkt >= _MinPeriode)
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
                                string[] vbf = auf.auf_vorherigeBetreuungsform.ToString().Split(new char[] { ';' });
                                a.vorherigeBetreuungsformen = new List<string>();
                                foreach (string v in vbf)
                                {
                                    if (!String.IsNullOrWhiteSpace(v))
                                    {
                                        a.vorherigeBetreuungsformen.Add(v);
                                    }
                                }
                            }

                            a.eintrittsdatum = (DateTime)auf.auf_eintrittsdatum;

                            if (auf.auf_austrittsdatum != null)
                            {
                                a.austrittsdatum = (DateTime)auf.auf_austrittsdatum;
                            }

                            if (!String.IsNullOrWhiteSpace((string)auf.auf_austrittWohin))
                            {
                                a.austrittWohin = (string)auf.auf_austrittWohin;
                            }
                            else
                            {
                                a.austrittWohin = null;
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
                                           abwesenheitsgrund = url.STAMP_Abwesenheitsgrund,
                                           gueltigVon = url.StartDatum,
                                           gueltigBis = url.EndeDatum
                                       }).ToList();

                            foreach (var ab in abw)
                            {
                                //Keine Abwesenheit ohne Abwsenheitsgrund (wurden vor STAMP begonnen)
                                if (String.IsNullOrWhiteSpace(ab.abwesenheitsgrund))
                                {
                                    continue;
                                }

                                if (ab.gueltigBis != null)
                                {
                                    //Nur Abweseneheiten mit mindestens einer Nacht
                                    DateTime bis = (DateTime)ab.gueltigBis;
                                    DateTime von = (DateTime)ab.gueltigVon;
                                    if (bis.Date <= von.Date)
                                        continue;
                                }

                                abwesenheit abwh = new abwesenheit();
                                abwh.abwesenheitsgrund = ab.abwesenheitsgrund;
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
                                         vorlauefigePflegegeldstufePersonal = ps.StufeNr,
                                         kenntnisnahmeDatumBescheid = pps.GenehmigungDatum
                                     }).ToList();

                        foreach (var psv in lPSTV)
                        {
                            Pflegegeldverfahren pgv = new Pflegegeldverfahren();
                            pgv.beantragtAm = (DateTime)psv.beantragtAm;
                            pgv.vorlauefigePflegegeldstufePersonal = psv.vorlauefigePflegegeldstufePersonal == 0 ? "keine" : psv.vorlauefigePflegegeldstufePersonal.ToString();
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
                
                bew.JSONKurz.staatsbuergerschaft = LookupAuswahllisteBezeichnung("LND", bew.staatsbuergerschaft, AuswahllisteSucheTyp.ELGA_Code, false);
                if (String.IsNullOrWhiteSpace(bew.JSONKurz.staatsbuergerschaft))
                {
                    AddLog(ref chk, "Staatsbürgerschaft '" + bew.staatsbuergerschaft + "' ist kein gültiger Listeneintrag", ErrorLogClass.Bewohnerdaten, bew, null);
                }
                bew.JSON.staatsbuergerschaft = bew.JSONKurz.staatsbuergerschaft;

                bew.JSONKurz.geschlecht = ConvertGeschlecht(bew.geschlecht);
                if (String.IsNullOrWhiteSpace(bew.JSONKurz.geschlecht))
                {
                    AddLog(ref chk, "Geschlecht '" + bew.geschlecht + "' ist kein gültiger Listeneintrag", ErrorLogClass.Bewohnerdaten, bew, null);
                }
                bew.JSON.geschlecht = bew.JSONKurz.geschlecht;

                bew.JSONKurz.forensischerHintergrund = bew.forensischerHintergrund;
                bew.JSON.forensischerHintergrund = bew.JSON.forensischerHintergrund;

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
                    jpgv.vorlauefigePflegegeldstufePersonal = pgv.vorlauefigePflegegeldstufePersonal;
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
                    jauf.letzteHauptwohnsitzgemeinde = LookupAuswahllisteBezeichnung("GKZ", auf.letzteHauptwohnsitzgemeinde, AuswahllisteSucheTyp.Beschreibung, false);
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
                        jauf.vorherigeBetreuungsformen = new string[auf.vorherigeBetreuungsformen.Count];
                        j = 0;
                        foreach (string vbf in auf.vorherigeBetreuungsformen)
                        {
                            string jvbf = LookupAuswahllisteBezeichnung("VBF", vbf, AuswahllisteSucheTyp.Beschreibung, true);
                            jauf.vorherigeBetreuungsformen[j] = jvbf;
                            j++;
                            if (String.IsNullOrWhiteSpace(jvbf))
                            {
                                AddLog(ref chk, "Vorherige Betreuungsform '" + bew.letzteHauptwohnsitzgemeinde + "' ist kein gültiger Listeneintrag", ErrorLogClass.VorherigeBetreuungsform, bew, auf);
                            }
                        }
                    }

                    jauf.eintrittsdatum = auf.eintrittsdatum.ToString(dFormat);
                    
                    jauf.austrittWohin = LookupAuswahllisteBezeichnung("AWO", auf.austrittWohin, AuswahllisteSucheTyp.Beschreibung, true);
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
                        jkt.finanzierung = LookupAuswahllisteBezeichnung("SFI", kt.finanzierung, AuswahllisteSucheTyp.Beschreibung, false);  //Prüfung erfolgt bereits in der GUI
                        string Gemeinde = LookupAuswahllisteBezeichnung("GKZ", kt.Gemeinde, AuswahllisteSucheTyp.Beschreibung, false);
                        string Bundesland = LookupAuswahllisteBezeichnung("GKZ", kt.Bundesland, AuswahllisteSucheTyp.Beschreibung, false);
                        string Land = LookupAuswahllisteBezeichnung("LND", kt.Land, AuswahllisteSucheTyp.ELGA_Code, false);

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
                        jabw.abwesenheitsgrund = LookupAuswahllisteBezeichnung("SAG", abw.abwesenheitsgrund, AuswahllisteSucheTyp.Beschreibung, false);
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

            //string res = JsonConvert.SerializeObject(lBew.bewohnerdaten[2].JSON, Formatting.Indented);

            return chk;
        }

        private void AddLog(ref CheckStatus chk, string txtLog, ErrorLogClass elc, Bewohnerdaten bew, Aufenthalt auf)
        {
            AddHeaderToLog(ref chk, bew, auf);
            bew.HasError = true;
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

        private string LookupAuswahllisteBezeichnung(string IDAuswahllisteGruppe, string SearchValue, AuswahllisteSucheTyp SearchType, bool ReturnNullIfEmpty)
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
                                return ReturnNullIfEmpty ? null : "";
                        }
                    }
                    else
                    {
                        AddLog("Fehlerhafter Listeneintrag in Auswahlliste " + IDAuswahllisteGruppe + ": " + SearchValue, ErrorClass.Kritisch);
                        return ReturnNullIfEmpty ? null : "";
                    }
                }
            }
            catch (Exception ex)
            {
                AddLog("Fehlerbei Suche in Auswahliste " + IDAuswahllisteGruppe + ": " + SearchValue + "\n" + ex.Message, ErrorClass.Kritisch);
                return ReturnNullIfEmpty ? null : "";
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
        public async Task<bool> CallService(ServiceCallType sc, Bewohnerliste lBew)
        {
            try
            {
                //PFX-File und Passwortfile in Unterverzeichnis mit passendem "gültig ab" im Format YYYY-MM-DD suchen
                if (String.IsNullOrWhiteSpace(certFile) && String.IsNullOrWhiteSpace(STAMP_PW))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(ENV.STAMP_PFX_Path);
                    var dirs = dirInfo.EnumerateDirectories().OrderByDescending(d => d.Name);
                    foreach (DirectoryInfo dir in dirs)
                    {
                        if (DateTime.TryParse(dir.Name, out DateTime GültigAb))
                        {
                            if (DateTime.Now >= GültigAb)
                            {
                                var files = dir.EnumerateFiles();
                                foreach (FileInfo file in files)
                                {
                                    if (file.Extension == ".pfx")
                                    {
                                        certFile = file.FullName;
                                        string pwdFile = Path.ChangeExtension(certFile, ".txt");
                                        if (File.Exists(pwdFile))
                                        {
                                            STAMP_PW = PMDS.BusinessLogic.BUtil.DecryptString(File.ReadAllText(pwdFile).Trim());
                                        }
                                        goto BreakSearchForCertificate;
                                    }
                                }
                            }
                        }
                    }
                BreakSearchForCertificate:

                    //Wenn als Zertifikat ein existierendes Zertifiakt angegeben ist und das Passwort gesetzt ist
                    if (String.IsNullOrWhiteSpace(certFile) || String.IsNullOrWhiteSpace(STAMP_PW))
                    {
                        //Fehler!!!
                        lBew.sbLog.Append("Fehler beim Lesen des Zertifikats.\nDie Funktion kann nicht fortgesetzt werden.");
                        return false;
                    }
                }

                await StartService(ServiceCallType.traeger, null, certFile, STAMP_PW, lBew.sbLogServiceCalls);
                if (lBew.sbLog.Length > 0)  //Kritischer Fehler, nicht fortsetzen
                {
                    return false;
                }

                await StartService(ServiceCallType.standort, null, certFile, STAMP_PW, lBew.sbLogServiceCalls);
                if (lBew.sbLog.Length > 0)  //Kritischer Fehler, nicht fortsetzen
                {
                    return false;
                }

                if (sc == ServiceCallType.bewohnermelden)
                {
                    foreach (Bewohnerdaten bew in lBew.bewohnerdaten)
                    {
                        if (String.IsNullOrWhiteSpace(bew.synonym) && !bew.HasError)
                        {
                            StringBuilder sb = await StartService(sc, bew, certFile, STAMP_PW, lBew.sbLogServiceCalls);
                            if (sb.Length > 0)
                            {
                                lBew.sbLog.Append(sb);
                                ShowLog();
                            }
                        }
                    }

                    if (!lBew.HasErrors)
                    {
                        LoadAll();  //Daten neu laden, sonst Fehlermeldung anzeigen
                    }
                }

                if (sc == ServiceCallType.bewohnerupdate)
                {
                    foreach (Bewohnerdaten bew in lBew.bewohnerdaten)
                    {
                        if (!String.IsNullOrWhiteSpace(bew.synonym) && !bew.HasError)
                        {
                            StringBuilder sb = await StartService(sc, bew, certFile, STAMP_PW, lBew.sbLogServiceCalls);
                            if (sb.Length > 0)
                            {
                                lBew.sbLog.Append(sb);
                                ShowLog();
                            }
                            else
                            {
                                SaveServiceResult();
                            }
                        }
                    }
                }
                return (lBew.sbLog.Length == 0);
            }
            catch (Exception ex)
            {
                lBew.sbLog.Clear();
                lBew.sbLog.Append(ex.Message);
                return false;
            }
        }

        private async Task<StringBuilder> StartService(ServiceCallType scType, Bewohnerdaten bew, string certFile, string STAMP_PW, StringBuilder sbLogServiceCalls)
        {
            try
            {
                StringBuilder sbResult = new StringBuilder();
                RestResponse resp = new RestResponse();

                if (scType == ServiceCallType.traeger)
                {
                    resp = await RunService(scType, "", "", certFile, STAMP_PW, null, sbLogServiceCalls).ConfigureAwait(false);
                    var objects = JArray.Parse(resp.Content); // parse as array  
                    if (resp.IsSuccessful)
                    {
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
                    else
                    {
                        sbResult.Append("Fehler beim Abrufen der Träger-ID: \n");
                        foreach (JObject root in objects)
                        {
                            foreach (KeyValuePair<String, JToken> app in root)
                            {
                                sbResult.Append(app.Key + "=" + app.Value.ToString() + "\n");
                            }
                        }
                    }
                }

                else if (scType == ServiceCallType.standort)
                {
                    resp = await RunService(scType, traeger, "", certFile, STAMP_PW, null, sbLogServiceCalls).ConfigureAwait(false);
                    var objects = JArray.Parse(resp.Content); // parse as array  
                    if (resp.IsSuccessful)
                    {
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
                    else
                    {
                        sbResult.Append("Fehler beim Abrufen des Standortes: \n");
                        foreach (JObject root in objects)
                        {
                            foreach (KeyValuePair<String, JToken> app in root)
                            {
                                sbResult.Append(app.Key + "=" + app.Value.ToString() + "\n");
                            }
                        }
                    }
                }

                else if (scType == ServiceCallType.bewohnermelden)
                {
                    resp = await RunService(scType, traeger, standort, certFile, STAMP_PW, bew, sbLogServiceCalls).ConfigureAwait(false);
                    if (resp.IsSuccessful)
                    {
                        //Synonym in DB eintragen und ok
                        var res = JObject.Parse(resp.Content);
                        foreach (KeyValuePair<String, JToken> app in res)
                        {
                            if (app.Key.sEquals("synonym"))
                            {
                                string resUpdate = UpdateSynonymER(bew.IDKlient, app.Value.ToString());
                                if (!String.IsNullOrWhiteSpace(resUpdate))
                                {
                                    sbResult.Append("--------------------------------------------------------------------------\n");
                                    sbResult.Append("Fehler bei Speichern des Synonoms für " + bew.nachname + " " + bew.vorname + ":\n");
                                    sbResult.Append(resUpdate);
                                    sbResult.Append("    \n");
                                }
                                else
                                {
                                    bew.synonym = app.Value.ToString();
                                }
                                break;
                            }
                        }
                    }
                    else
                    {
                        //Fehlermeldung und mit nächstem Bewohner fortsetzen
                        sbResult.Append("--------------------------------------------------------------------------\n");
                        sbResult.Append("STAMP-Service-Fehler beim Melden für " + bew.nachname + " " + bew.vorname + ":\n");
                        var res = JObject.Parse(resp.Content);
                        foreach (KeyValuePair<String, JToken> app in res)
                        {
                            sbResult.Append(app.Key + "=" + app.Value.ToString() + "\n");
                        }
                        sbResult.Append("    \n");
                    }
                }

                else if (scType == ServiceCallType.bewohnerupdate)
                {
                    resp = await RunService(scType, traeger, standort, certFile, STAMP_PW, bew, sbLogServiceCalls).ConfigureAwait(false);
                    if (!resp.IsSuccessful)
                    {
                        //Fehlermeldung und mit nächstem Bewohner fortsetzen
                        sbResult.Append("--------------------------------------------------------------------------\n");
                        sbResult.Append("STAMP-Service-Fehler beim Update für " + bew.nachname + " " + bew.vorname + ":\n");
                        if (!resp.StatusCode.sEquals("OK"))
                        {
                            sbResult.Append(resp.Content.ToString() + "\n");
                        }
                        else
                        {
                            var res = JObject.Parse(resp.Content);
                            foreach (KeyValuePair<String, JToken> app in res)
                            {
                                sbResult.Append(app.Key + "=" + app.Value.ToString() + "\n");
                            }
                        }
                        sbResult.Append("    \n");
                    }
                }

                return sbResult;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                throw new Exception(ex.ToString());
            }
        }

        static async Task<RestResponse> RunService(ServiceCallType scType, string traeger, string standort, string certFile, string STAMP_PW, Bewohnerdaten bew, StringBuilder sbLogServiceCalls)
        {
            CancellationToken cancellationToken = new CancellationToken();

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

            X509Certificate2 certificate = new X509Certificate2(certFile, STAMP_PW);
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
                    sbLogServiceCalls.Append(ServiceLogMessage(result, scType));
                    return result;
                }
                else if (scType == ServiceCallType.standort)
                {
                    var request = new RestRequest("/traeger/" + traeger + "/standort", Method.Get);
                    request.RequestFormat = RestSharp.DataFormat.Json;
                    RestResponse result = await client.ExecuteGetAsync(request, cancellationToken);
                    sbLogServiceCalls.Append(ServiceLogMessage(result, scType));
                    return result;
                }
                else if(scType == ServiceCallType.bewohnermelden)
                {
                    var request = new RestRequest("/traeger/" + traeger + "/standort/" + standort + "/bewohner", Method.Post);
                    request.RequestFormat = RestSharp.DataFormat.Json;
                    request.AddStringBody(JsonConvert.SerializeObject(bew.JSONKurz, Formatting.Indented).ToString(), DataFormat.Json);
                    RestResponse result = await client.ExecutePostAsync(request, cancellationToken);
                    sbLogServiceCalls.Append(ServiceLogMessage(result, scType));
                    return result;
                }
                else if (scType == ServiceCallType.bewohnerupdate)
                {
                    var request = new RestRequest("/traeger/" + traeger + "/standort/" + standort + "/bewohner/" + bew.synonym, Method.Put);
                    request.RequestFormat = RestSharp.DataFormat.Json;
                    request.AddJsonBody(bew.JSON);
                    RestResponse result = await client.ExecutePutAsync(request, cancellationToken);
                    sbLogServiceCalls.Append(ServiceLogMessage(result, scType));
                    return result;
                }
                return null;
            }
        }

        private static StringBuilder ServiceLogMessage(RestResponse resp, ServiceCallType scType)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(">>> Request ");
            sb.Append(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.ffff"));
            sb.Append(" / User=");
            sb.Append(ENV.ActiveUser.Nachname);
            sb.Append(" ");
            sb.Append(ENV.ActiveUser.Vorname);
            sb.Append(" <<<\n");
            sb.Append("Resource = " + ENV.STAMP_URL + resp.Request.Resource);

            switch (scType)
            {
                case ServiceCallType.bewohnermelden:
                    sb.Append("\nParameters:\n");
                    foreach (RestSharp.Parameter h in resp.Request.Parameters) //Daten im Post-Body
                    {
                        sb.Append(h.ToString() + "\n");
                    }
                    break;
                case ServiceCallType.bewohnerupdate:
                    sb.Append("\nParameters:\n");
                    foreach (RestSharp.Parameter h in resp.Request.Parameters) //Daten im PUT-Body
                    {
                        sb.Append(JsonConvert.SerializeObject(h.Value) + "\n");
                    }
                    break;
            }

            sb.Append("\nResponse: " + "StatusCode = " + resp.StatusCode +"\n");
            sb.Append(resp.Content.ToString());
            sb.Append(" \n");
            return sb;
        }

        //---------------- DB Update ------------------------------------------------
        public string UpdateSynonymER(Guid IDPatient, string STAMPSynonym)
        {
            try
            {
                //Save ER
                PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    if (b.checkPatientExists(IDPatient, db))
                    {
                        //Patientenstammdaten
                        PMDS.db.Entities.Patient rPatient = b.getPatient(IDPatient, db);
                        rPatient.STAMP_Synonym = STAMPSynonym;
                        db.SaveChanges();
                    }
                    else
                    {
                        return "Klientendaten wurden in der Datenbank nicht gefunden.";
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
