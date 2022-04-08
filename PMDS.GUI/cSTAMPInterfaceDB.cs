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

        private enum AuswahllisteSucheTyp
        {
            ELGA_ID = 1,
            ELGA_Code = 2,
            Beschreibung = 3
        }

        public class Bewohnerliste
        {
            public Guid ID { get; set; } = Guid.NewGuid();
            public DateTime ErstelltAm { get; set; } = _Now;
            public List<Bewohnerdaten> bewohnerdaten { get; set; } = new List<Bewohnerdaten>();
            public string Log { get; set; } = "";
            public bool HasErrors { get; set; }
        }


        public class Bewohnerdaten
        {
            public string synonym { get; set; } = "";                             //ID von STAMP
            public string vorname { get; set; } = "";
            public string nachname { get; set; } = "";
            public DateTime geburtsdatum { get; set; } = DateTime.MinValue;
            public string staatsbergerschaft { get; set; } = "";                  //Exakt drei Zeichen
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
            public string ErrLog { get; set; } = "";
        }

        public class STAMPString
        {
            string Text { get; set; } = "";
            int MaxLength { get; set; }
            bool TrimText { get; set; } = true;
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
            public string ErrLog { get; set; } = "";

        }

        public class VorherigeBetreuungsform
        {
            public string vorherigeBeteuungsform { get; set; } = "";      //{ MOB_HK, TAGZ, BET_WOH, 24H_BET, AND_PH, KH, PRIV_BET, KEINE, SONST }
            public string ErrLog { get; set; } = "";

        }

        public class kostentragung
        {
            public string finanzierung { get; set; } = "";     //SZ, RESTK_13_xxx, RESTK_13_2_xxx, RESTK_19_xxx, BUND, AB_X, AS_XXX. SONST, LE_ZU_LAUFEND }
            public string finanzierungSonstige { get; set; } = "";
            public DateTime gueltigVon { get; set; } = DateTime.MinValue;
            public DateTime gueltigBis { get; set; } = DateTime.MaxValue;
            public string ErrLog { get; set; } = "";

        }

        public class abwesenheit
        {
            public string abwesenheitsgrund { get; set; } = "";   //{ PRIVAT, KH_KU_RE }
            public DateTime vonDatum { get; set; } = DateTime.MinValue;
            public DateTime bisDatum { get; set; } = DateTime.MaxValue;
            public Guid IDUrlaub { get; set; } = Guid.Empty;
            public string ErrLog { get; set; } = "";

        }

        public class Pflegegeldstufe
        {
            public string pflegegeldstufe { get; set; } = "";     // { keine, 1, 2, 3, 4, 5, 6, 7 }
            public DateTime gueltigVon { get; set; } = DateTime.MinValue;
            public DateTime gueltigBis { get; set; } = DateTime.MaxValue;
            public Guid IDPflegestufe { get; set; } = Guid.Empty;
            public string ErrLog { get; set; } = "";

        }

        public class Pflegegeldverfahren
        {
            public DateTime beantragtAm { get; set; }
            public string vorlaufigePflegegeldstufeVerrechnungPersonal { get; set; } = "";    // { keine, 1, 2, 3, 4, 5, 6, 7 }
            public DateTime kenntnisnahmeDatumBescheid { get; set; } = DateTime.MaxValue;
            public Guid IDPflegestufe { get; set; } = Guid.Empty;
            public string ErrLog { get; set; } = "";

        }

        public bool init(DateTime Periode)
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
                                           }).GroupBy(p => p.IDKlient).Select(g => g.FirstOrDefault()).ToList();


                    foreach (var kl in lstKlientenID)
                    {
                        Bewohnerdaten bew = new Bewohnerdaten();

                        bew.synonym = kl.pat_synonym;
                        bew.vorname = kl.pat_vorname;
                        bew.nachname = kl.pat_nachname;
                        string STAMPstaatsbergerschaft = LookupAuswahllisteBezeichnung("LND", kl.pat_staatsbürgerschaft, AuswahllisteSucheTyp.ELGA_Code);
                        if (!String.IsNullOrWhiteSpace(STAMPstaatsbergerschaft))
                        {
                            bew.staatsbergerschaft = STAMPstaatsbergerschaft;
                        }
                        else
                        {
                            bew.ErrLog += "Staatsbürgerschaft " + kl.pat_staatsbürgerschaft + " ist kein gültiger Listeneintrag\n";
                            lBew.HasErrors = true;
                        }
                        if (!String.IsNullOrWhiteSpace(ConvertGeschlecht(kl.pat_geschlecht)))
                        {
                            bew.geschlecht = ConvertGeschlecht(kl.pat_geschlecht);
                        }
                        else
                        {
                            bew.ErrLog += "Geschlecht " + kl.pat_geschlecht + " ist kein gültiger Listeneintrag.\n";
                            lBew.HasErrors = true;
                        }

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
                                              }).ToList();

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
                            if (!kts.Any())
                            {
                                a.ErrLog += "Keine Kostentragungen gefunden.";
                                lBew.HasErrors = true;
                            };

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
                                if (String.IsNullOrWhiteSpace(abwh.abwesenheitsgrund))
                                {
                                    abwh.ErrLog += "Kein gültiger Abwesenheitsgrund für Abwesenheit vom " + abwh.vonDatum.ToString("dd.MM.yyyy") + " gefunden.";
                                    lBew.HasErrors = true;
                                }
                                if (ab.gueltigBis != null)
                                {
                                    abwh.bisDatum = (DateTime)ab.gueltigBis;
                                }
                                a.abwesenheiten.Add(abwh);
                            }
                            bew.aufenthalte.Add(a);

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

                                if (ps.gueltigVon == null)
                                {
                                    bew.ErrLog += "Pflegestufeneintrag ohne gültigem von-Datum gefunden.";
                                    lBew.HasErrors = true;
                                }
                                else
                                {
                                    pst.gueltigVon = ps.gueltigVon;
                                }

                                if (ps.gueltigBis != null)
                                {
                                    pst.gueltigBis = (DateTime)ps.gueltigBis;
                                }
                                bew.pflegegeldstufen.Add(pst);
                            }
                            //Mindestens eine PS -> sonst Fehler!
                            if (!bew.pflegegeldstufen.Any())
                            {
                                bew.ErrLog += "Keine Pflegestufeneinträge gefunden.";
                                lBew.HasErrors = true;
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
                        //Mindestens ein Aufenthalt, sonst Fehler!
                        if (bew.aufenthalte.Count == 0)
                        {
                            bew.ErrLog += "Kein Aufenthalt für diesen Bewohner gefunden.";
                            lBew.HasErrors = true;
                        }
                    }                    
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
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
