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

        public enum STAMPBewohnerStatus
        {
            neu = 0,
            ok = 1,
            SynonymFehlt = 2,
            Datenfehler = 3,
        }

        public class Bewohnerliste
        {
            public Guid ID { get; set; } = Guid.NewGuid();
            public DateTime ErstelltAm { get; set; } = _Now;
            public List<Bewohnerdaten> bewohnerdaten { get; set; } = new List<Bewohnerdaten>();
            public string Log { get; set; } = "";
        }


        public class Bewohnerdaten
        {
            public string synonym { get; set; } = "";                             //ID von STAMP
            public string vorname { get; set; } = "";
            public string nachname { get; set; } = "";
            public DateTime geburtsdatum { get; set; } = DateTime.MinValue;
            public string staatsbergerschaft { get; set; } = "";                  //Exakt drei Zeichen
            public string geschlecht { get; set; } = "";                          //Ein Zeichen {m, w, d, u } 
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
            public STAMPBewohnerStatus Status { get; set; } = STAMPBewohnerStatus.neu;
        }

        public class STAMPString
        {
            string Text { get; set; } = "";
            int MaxLength { get; set; }
            bool TrimText { get; set; } = true;
        }

        public class Aufenthalt
        {
            public string letzteHauptwohnsitzgemeinde { get; set; } = "";         //Fünf Zeichen
            public List<VorherigeBetreuungsform> vorherigeBetreuungsformen { get; set; } = new List<VorherigeBetreuungsform>();
            public DateTime eintrittsdatum { get; set; } = DateTime.MinValue;
            public DateTime austrittsdatum { get; set; }
            public string austrittWohin { get; set; } = "";              //{ BET_WOH. 24H_BET, AND_PH, TOD, SONST }
            public List<kostentragung> kostentragungen { get; set; } = new List<kostentragung>();
            public List<abwesenheit> abwesenheiten { get; set; } = new List<abwesenheit>();
            public Guid IDAufenthalt { get; set; } = Guid.Empty;
        }

        public class VorherigeBetreuungsform
        {
            public string vorherigeBeteuungsform { get; set; } = "";      //{ MOB_HK, TAGZ, BET_WOH, 24H_BET, AND_PH, KH, PRIV_BET, KEINE, SONST }
        }

        public class kostentragung
        {
            public string finanzierung { get; set; } = "";     //SZ, RESTK_13_xxx, RESTK_13_2_xxx, RESTK_19_xxx, BUND, AB_X, AS_XXX. SONST, LE_ZU_LAUFEND }
            public string finanzierungSonstige { get; set; } = "";
            public DateTime gueltigVon { get; set; } = DateTime.MinValue;
            public DateTime gueltigBis { get; set; } = DateTime.MaxValue;
        }

        public class abwesenheit
        {
            public string abwesenheitsgrund { get; set; } = "";   //{ PRIVAT, KH_KU_RE }
            public DateTime vonDatum { get; set; } = DateTime.MinValue;
            public DateTime bisDatum { get; set; } = DateTime.MaxValue;
            public Guid IDUrlaub { get; set; } = Guid.Empty;
        }

        public class Pflegegeldstufe
        {
            public string pflegegeldstufe { get; set; } = "";     // { keine, 1, 2, 3, 4, 5, 6, 7 }
            public DateTime gueltigVon { get; set; } = DateTime.MinValue;
            public DateTime gueltigBis { get; set; } = DateTime.MaxValue;
            public Guid IDPflegestufe { get; set; } = Guid.Empty;
        }

        public class Pflegegeldverfahren
        {
            public DateTime beantragtAm { get; set; }
            public string vorlaufigePflegegeldstufeVerrechnungPersonal { get; set; } = "";    // { keine, 1, 2, 3, 4, 5, 6, 7 }
            public DateTime kenntnisnahmeDatumBescheid { get; set; } = DateTime.MaxValue;
            public Guid IDPflegestufe { get; set; } = Guid.Empty;
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

                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var lstAufenthalte = (from a in db.vAufenthaltsliste
                                   join auf in db.Aufenthalt on a.IDAufenthalt equals auf.ID
                                   join pat in db.Patient on a.IDPatient equals pat.ID
                                   join adr in db.Adresse on pat.IDAdresse equals adr.ID
                                   where a.IDKlinik == ENV.IDKlinik && 
                                        (
                                            (auf.Entlassungszeitpunkt >= _FirstOfPeriode && auf.Entlassungszeitpunkt < _LastOfPeriode) ||
                                            (auf.Aufnahmezeitpunkt >= _FirstOfPeriode && auf.Aufnahmezeitpunkt < _LastOfPeriode) ||
                                            (auf.Aufnahmezeitpunkt < _FirstOfPeriode && (auf.Entlassungszeitpunkt > _LastOfPeriode || auf.Entlassungszeitpunkt == null)) 
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
                                       pat_letzteHauptwohnsitzgemeinde = "",    //Patient.STAMP_LetzteHauptwohnsitzgemeinde
                                       pat_forensicherHintergrund = false,      //Patient.STAMP_ForensicherHintergrund
                                       pat_gemeldetAmStandort = pat.WohnungAbgemeldetJN,
                                       pat_synonym = "",                        //Patient.STAMP_Synonym

                                       //Adresse
                                       adr_plz = adr.Plz,
                                       adr_ort = adr.Ort,
                                       adr_strasse = adr.Strasse,
                                       adr_hausnummer = "",                     //Adresse.Hausnummer

                                       //Aufenthalt
                                       auf_vorherigeBetreuungsform = "",
                                       auf_eintrittsdatum = auf.Aufnahmezeitpunkt,
                                       auf_austrittsdatum = auf.Entlassungszeitpunkt,
                                       auf_austrittWohin = ""
                                   }).ToList();

                    Bewohnerliste lBew = new Bewohnerliste();

                    foreach (var auf in lstAufenthalte)
                    {
                        Bewohnerdaten bew = new Bewohnerdaten();

                        bool bewExists = false ;
                        foreach (Bewohnerdaten bewCheck in lBew.bewohnerdaten)         
                        {
                            if (bewCheck.IDKlient == auf.IDKlient)
                            {
                                bew = bewCheck;
                                bewExists = true;
                                continue;
                            }
                        }

                        if (!bewExists)
                        {

                            bew.synonym = auf.pat_synonym;
                            bew.vorname = auf.pat_vorname;
                            bew.nachname = auf.pat_nachname;
                            string STAMPstaatsbergerschaft = LookupAuswahllisteBezeichnung("LND", auf.pat_staatsbürgerschaft, AuswahllisteSucheTyp.ELGA_Code);
                            if (!String.IsNullOrWhiteSpace(STAMPstaatsbergerschaft))
                            {
                                bew.staatsbergerschaft = STAMPstaatsbergerschaft;
                            }
                            else
                            {
                                bew.Status = STAMPBewohnerStatus.Datenfehler;
                            }
                            bew.geschlecht = ConvertGeschlecht(auf.pat_geschlecht);
                            bew.letzteHauptwohnsitzgemeinde = LookupAuswahllisteBezeichnung("GEM", auf.pat_letzteHauptwohnsitzgemeinde, AuswahllisteSucheTyp.ELGA_Code);
                            bew.forensicherHintergrund = auf.pat_forensicherHintergrund;
                            bew.gemeldetAmStandort = (bool)auf.pat_gemeldetAmStandort;
                            bew.plz = auf.adr_plz;
                            bew.ort = auf.adr_ort;
                            bew.strasse = auf.adr_strasse;
                            bew.hausnummer = auf.adr_hausnummer;
                            bew.synonymVorsystem = auf.IDKlient.ToString();
                            bew.IDKlient = auf.IDKlient;

                            lBew.bewohnerdaten.Add(bew);
                        }

                        Aufenthalt a = new Aufenthalt();
                        if (!String.IsNullOrEmpty((string)auf.auf_vorherigeBetreuungsform))
                        {
                            a.vorherigeBetreuungsformen = new List<VorherigeBetreuungsform>() { new VorherigeBetreuungsform { vorherigeBeteuungsform = (string)auf.auf_vorherigeBetreuungsform } };
                        }

                        a.eintrittsdatum = (DateTime) auf.auf_eintrittsdatum;
                        
                        if (auf.auf_austrittsdatum != null)
                        {
                            a.austrittsdatum = (DateTime)auf.auf_austrittsdatum;
                        }

                        if (!String.IsNullOrEmpty((string)auf.auf_austrittWohin))
                        {
                            a.austrittWohin = (string)auf.auf_austrittWohin;
                        }

                        //Kostentragungen zu Aufenthalt (STAMP_Kostentragungen)
                        


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
                            abwh.abwesenheitsgrund = LookupAuswahllisteBezeichnung("URL", ab.abwesenheitsgrund, AuswahllisteSucheTyp.Beschreibung) ;
                            abwh.vonDatum = (DateTime) ab.gueltigVon;
                            if (ab.gueltigBis != null)
                            {
                                abwh.bisDatum = (DateTime)ab.gueltigBis;
                            }
                            a.abwesenheiten.Add(abwh);
                        }
                        bew.aufenthalte.Add(a);

                        //Pflegegeldstufen zum Klienten
                        var lPST = (from kl in db.Patient
                                    join pps in db.PatientPflegestufe on kl.ID equals pps.IDPatient
                                    join ps in db.Pflegegeldstufe on pps.IDPflegegeldstufe equals ps.ID
                                    where kl.ID == bew.IDKlient
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
                                pst.gueltigBis = (DateTime) ps.gueltigBis;
                            }
                            bew.pflegegeldstufen.Add(pst);                                
                        }

                        //Pflegegeldverfahren zum Klienten
                        var lPSTV = (from kl in db.Patient
                                    join pps in db.PatientPflegestufe on kl.ID equals pps.IDPatient
                                    join ps in db.Pflegegeldstufe on pps.IDPflegegeldstufeAntrag equals ps.ID
                                    where kl.ID == bew.IDKlient &&
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
                            pgv.beantragtAm = (DateTime) psv.beantragtAm;
                            pgv.vorlaufigePflegegeldstufeVerrechnungPersonal = psv.vorlaeufigePflegegeldstufeVerrechnungPersonal == 0 ? "keine" : psv.vorlaeufigePflegegeldstufeVerrechnungPersonal.ToString();
                            if (psv.kenntnisnahmeDatumBescheid != null)
                            {
                                pgv.kenntnisnahmeDatumBescheid = (DateTime) psv.kenntnisnahmeDatumBescheid;
                            }
                            bew.pflegegeldverfahren.Add(pgv);
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
                    return "u";
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
