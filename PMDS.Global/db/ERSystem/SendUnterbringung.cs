using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PMDS.DB;
using PMDS.db.Entities;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Xml;
using System.IO;
using System.Net.Http;
using System.Security.Principal;
using System.Windows.Forms;

namespace PMDS.Global.db.ERSystem
{
    

    public class SendUnterbringung
    {

        public enum eMeldungstyp
        {
            Vornahme = 1,
            Verlaengerung = 2,
            Aufhebung = 3
        }

        public class retSendUnterbringung
        {
            public bool OK = false;
            public int ErrorCode = -999;
            public string ErrorTxt = "";
            public string ResultXML = "";
        }


        public bool Send(System.Guid IDUnterbringung, ref retSendUnterbringung retSendUnterbringung1, ref eMeldungstyp Meldungart,
                            ref PMDS.db.Entities.Unterbringung rUnterbringungFromService, ref PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                Dictionary<int, string> dictMeldungstyp = new Dictionary<int, string>();
                dictMeldungstyp.Add(1, "Vornahme");
                dictMeldungstyp.Add(2, "Verlaengerung");
                dictMeldungstyp.Add(3, "Aufhebung");
                
                Dictionary<int, string> dictAufhebungsgrund = new Dictionary<int, string>();
                dictAufhebungsgrund.Add(1, "verlegt");
                dictAufhebungsgrund.Add(2, "verstorben");
                dictAufhebungsgrund.Add(3, "sonstiger Grund");



                Dictionary<int, string> dictBeschraenkungsdauer = new Dictionary<int, string>();
                dictBeschraenkungsdauer.Add(5, "48h");
                dictBeschraenkungsdauer.Add(6, "3d-7d");
                dictBeschraenkungsdauer.Add(2, "8d-6m");
                dictBeschraenkungsdauer.Add(3, "6m");

                Dictionary<int, string> dictBerufsstand = new Dictionary<int, string>();
                dictBerufsstand.Add(0, "Arzt");
                dictBerufsstand.Add(1, "DGKS/P");
                dictBerufsstand.Add(2, "DGKS/P");
                dictBerufsstand.Add(3, "Leiter");

                Dictionary<int, string> dictZeugnisart = new Dictionary<int, string>();
                dictZeugnisart.Add(0, "Keines");
                dictZeugnisart.Add(1, "Gutachten");
                dictZeugnisart.Add(2, "Zeugnis");
                dictZeugnisart.Add(3, "Sonstiges");
                
                System.Linq.IQueryable<PMDS.db.Entities.Unterbringung> tUnterbringung = null;
                PMDS.db.Entities.Unterbringung rUnterbringung = null;
                System.Linq.IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt = null;
                PMDS.db.Entities.Aufenthalt rAufenthalt = null;
                System.Linq.IQueryable<PMDS.db.Entities.Patient> tPatient = null;
                PMDS.db.Entities.Patient rPatient = null;
                System.Linq.IQueryable<PMDS.db.Entities.Klinik> tKlinik = null;
                PMDS.db.Entities.Klinik rKlinik = null;
                System.Linq.IQueryable<PMDS.db.Entities.Abteilung> tAbteilung = null;
                PMDS.db.Entities.Abteilung rAbteilung = null;
                System.Linq.IQueryable<PMDS.db.Entities.Adresse> tAdresse = null;
                PMDS.db.Entities.Adresse rAdresse = null;
                    
                tUnterbringung = db.Unterbringung.Where(o => o.ID == IDUnterbringung);
                rUnterbringung = tUnterbringung.First();
                tAufenthalt = db.Aufenthalt.Where(o => o.ID == rUnterbringung.IDAufenthalt);
                rAufenthalt = tAufenthalt.First();
                tPatient = db.Patient.Where(o => o.ID == rAufenthalt.IDPatient);
                rPatient = tPatient.First();
                tKlinik = db.Klinik.Where(o => o.ID == rAufenthalt.IDKlinik);
                rKlinik = tKlinik.First();
                tAbteilung = db.Abteilung.Where(o => o.ID == rAufenthalt.IDAbteilung);
                rAbteilung = tAbteilung.First();
                tAdresse = db.Adresse.Where(o => o.ID == rKlinik.IDAdresse);
                rAdresse = tAdresse.First();

                string txt = "";
                string DateFormat = "yyyy-MM-ddThh:mm:ss";

                   
                Chilkat.Xml xml = new Chilkat.Xml();
                xml.Encoding = "ISO-8859-1";
                xml.Standalone = true;
                xml.Tag = "Meldung";

                xml.AddAttribute("Art", LookUp(dictMeldungstyp, (int)Meldungart));
                    
                //-----------------Bewohner 
                Chilkat.Xml Bewohner = xml.NewChild("Bewohner", "");
                Bewohner.NewChild("Titel", rPatient.Titel.Trim());
                Bewohner.NewChild("VorName", rPatient.Vorname.Trim());
                Bewohner.NewChild("FamilienName", rPatient.Nachname.Trim());
                Bewohner.NewChild("Geschlecht", rPatient.Sexus.Trim().Substring(0, Math.Min(1, rPatient.Sexus.Trim().Length)));
                Bewohner.NewChild("GeburtsDatum", rPatient.Geburtsdatum.Value.ToString(DateFormat));

                //-----------------Einrichtung 
                Chilkat.Xml Einrichtung = xml.NewChild("Einrichtung", "");
                Einrichtung.NewChild("PostLeitzahl", rAdresse.Plz.ToString().Trim());
                Einrichtung.NewChild("Abteilung", rAbteilung.Bezeichnung.ToString().Trim());
                Einrichtung.NewChild("Patientencode", rPatient.ID.ToString().Trim());
                
                //-----------------Meldungsdaten 
                Chilkat.Xml Meldungsdaten = xml.NewChild("Meldungsdaten", "");
                if (Meldungart == eMeldungstyp.Vornahme || Meldungart == eMeldungstyp.Verlaengerung) 
                {
                    Meldungsdaten.NewChild("Beginn", rUnterbringung.Beginn.Value.ToString(DateFormat));
                    Chilkat.Xml Patientenzustimmung = Meldungsdaten.NewChild("Patientenzustimmung", (rUnterbringung.Anmerkung == null ? "" : rUnterbringung.Anmerkung.Trim()));
                    Patientenzustimmung.AddAttribute("Vorhanden", rUnterbringung.KlientZustimmungJN == true ? "ja" : "nein");
                }
                else
                {
                    Chilkat.Xml Aufhebung = Meldungsdaten.NewChild("Aufhebung", (rUnterbringung.Anmerkung == null? "": rUnterbringung.Anmerkung.Trim()));
                    if ((int)rUnterbringung.TatsaechlicheEndeGrund == 1 || (int)rUnterbringung.TatsaechlicheEndeGrund == 2 )
                        Aufhebung.AddAttribute("Grund", LookUp(dictAufhebungsgrund, (int)rUnterbringung.TatsaechlicheEndeGrund));
                    Aufhebung.NewChild("Ende", (rUnterbringung.AufgehobenAm == null?"": rUnterbringung.AufgehobenAm.Value.ToString(DateFormat)));
                    if ((int)rUnterbringung.TatsaechlicheEndeGrund == 3)
                        Aufhebung.NewChild("Grund", LookUp(dictAufhebungsgrund, (int)rUnterbringung.TatsaechlicheEndeGrund));
                    //Aufhebung Grund FEHLT IN DB //osxy
                }

                if (Meldungart == eMeldungstyp.Vornahme || Meldungart == eMeldungstyp.Verlaengerung)
                {
                    //-----------------Grund 
                    Chilkat.Xml Grund = xml.NewChild("Grund", "");
                    if (rUnterbringung.PsychischekrankheitJN == true)
                    {
                        Chilkat.Xml Einschraenkung = Grund.NewChild("Einschraenkung", "");
                        Einschraenkung.AddAttribute("Typ", "psychisch");
                    }

                    if (rUnterbringung.GeistigeBehinderungJN == true)
                    {
                        Chilkat.Xml Einschraenkung = Grund.NewChild("Einschraenkung", "");
                        Einschraenkung.AddAttribute("Typ", "geistig");
                    }
                    Grund.NewChild("MedizinischeDiagnose", rUnterbringung.MedizinischeDiagnose.ToString().Trim());

                    if (rUnterbringung.MedDiagnICD != null)
                        Grund.NewChild("ICD10", rUnterbringung.MedDiagnICD.ToString().Trim() );

                    if (rUnterbringung.ErheblicheSelbstgefaehrdungJN == true)
                    {
                        Chilkat.Xml Einschraenkung = Grund.NewChild("Gefaehrdung", "");
                        Einschraenkung.AddAttribute("Typ", "selbst");
                    }

                    if (rUnterbringung.ErheblicheFremdgefaehrdungJN == true)
                    {
                        Chilkat.Xml Einschraenkung = Grund.NewChild("Gefaehrdung", "");
                        Einschraenkung.AddAttribute("Typ", "fremd");
                    }
                    
                    if (rUnterbringung.Grund != null)
                        Grund.NewChild("GefaehrdungsBeschreibung", rUnterbringung.Grund.ToString().Trim());

                    bool DokumentErforderlich = (rUnterbringung.VoraussichtlicheDauer == 5 ? false : true);

                    if (DokumentErforderlich || (int) rUnterbringung.AerztlDokumentArt != 0)
                    {
                        Chilkat.Xml Dokument = Grund.NewChild("Dokument", "");
                        Dokument.AddAttribute("Art", LookUp(dictZeugnisart, (int) rUnterbringung.AerztlDokumentArt));
                        Chilkat.Xml DokumentArzt = Dokument.NewChild("Arzt", "");
                        DokumentArzt.NewChild("Titel", rUnterbringung.AerztlDokumentArztTitel.ToString().Trim());
                        DokumentArzt.NewChild("VorName", rUnterbringung.AerztlDokumentArztVorname.ToString().Trim());
                        DokumentArzt.NewChild("FamilienName", rUnterbringung.AerztlDokumentArzt.ToString().Trim());
                        if (rUnterbringung.AerztlDokumentDatum != null)
                            Dokument.NewChild("Erstellung", rUnterbringung.AerztlDokumentDatum.Value.ToString(DateFormat).Trim());

                    }

                    if (rUnterbringung.EingriffUnerlaesslichBeschreibung != null)
                    {
                        Chilkat.Xml GrundEignung = Grund.NewChild("Eignung", rUnterbringung.EingriffUnerlaesslichBeschreibung.ToString().Trim());
                        if (rUnterbringung.EingriffUnerlaesslichJN != null)
                            GrundEignung.AddAttribute("Geeignet", rUnterbringung.EingriffUnerlaesslichJN == true ? "ja" : "nein");
                    }

                }

    
                //-----------------Beschränkungen 
                Chilkat.Xml Beschraenkungen = xml.NewChild("Beschraenkungen", "");
                string BeschrDauer = LookUp(dictBeschraenkungsdauer, rUnterbringung.VoraussichtlicheDauer.Value);

                if (rUnterbringung.ElektronischesUeberwachungJN == true || rUnterbringung.ZurueckhaltensandrohungJN == true ||
                        rUnterbringung.VerschlosseneTuerJN == true || rUnterbringung.DrehknopfJN == true ||
                        rUnterbringung.CodierungJN == true || rUnterbringung.BaulicheMassnahmen.ToString().Trim() != "")
                {
                    Chilkat.Xml BeschraenkungBereich = Beschraenkungen.NewChild("Beschraenkung", "");
                    BeschraenkungBereich.AddAttribute("Art", "Bereich");
                    if (Meldungart == eMeldungstyp.Vornahme || Meldungart == eMeldungstyp.Verlaengerung) 
                        BeschraenkungBereich.AddAttribute("Dauer", BeschrDauer);
                    if (rUnterbringung.ElektronischesUeberwachungJN == true) BeschraenkungBereich.NewChild("Elektronisch", "");
                    if (rUnterbringung.ZurueckhaltensandrohungJN == true) BeschraenkungBereich.NewChild("Androhung", "");
                    if (rUnterbringung.VerschlosseneTuerJN == true || rUnterbringung.DrehknopfJN == true ||
                        rUnterbringung.CodierungJN == true || rUnterbringung.BaulicheMassnahmen.ToString().Trim() != "")
                    {
                        Chilkat.Xml BeschaenkungBereichBaulich = BeschraenkungBereich.NewChild("Baulich", "");
                        if (rUnterbringung.VerschlosseneTuerJN == true) BeschaenkungBereichBaulich.NewChild("Tuer", "");
                        if (rUnterbringung.DrehknopfJN == true) BeschaenkungBereichBaulich.NewChild("Drehknopf", "");
                        if (rUnterbringung.CodierungJN == true) BeschaenkungBereichBaulich.NewChild("Codierung", "");
                        if (rUnterbringung.LabyrinthJN == true)
                        {
                            BeschaenkungBereichBaulich.NewChild("Sonstiges", "");
                            BeschaenkungBereichBaulich.NewChild("Sonstiges", rUnterbringung.BaulicheMassnahmen.ToString().Trim());
                        } 
                    }
                } 

                if (rUnterbringung.HindernRollstuhlGurtenJN == true || rUnterbringung.HindernRollstuhTischJN == true ||
                    rUnterbringung.HindernRollstuhTherapietischJN == true || rUnterbringung.HindernRollstuhlBremsenJN == true || 
                    rUnterbringung.HindernRollstuhlSitzhoseJN == true || rUnterbringung.HindernRollstuhl.ToString().Trim() != "")
                {
                    Chilkat.Xml BeschraenkungRollstuhl = Beschraenkungen.NewChild("Beschraenkung", "");
                    BeschraenkungRollstuhl.AddAttribute("Art", "Rollstuhl");
                    if (Meldungart == eMeldungstyp.Vornahme || Meldungart == eMeldungstyp.Verlaengerung) 
                        BeschraenkungRollstuhl.AddAttribute("Dauer", BeschrDauer.Trim());
                    if (rUnterbringung.HindernRollstuhlGurtenJN == true) BeschraenkungRollstuhl.NewChild("Gurten", "");
                    if (rUnterbringung.HindernRollstuhTischJN == true) BeschraenkungRollstuhl.NewChild("Tisch", "");
                    if (rUnterbringung.HindernRollstuhTherapietischJN == true) BeschraenkungRollstuhl.NewChild("Therapietisch", "");
                    if (rUnterbringung.HindernRollstuhlBremsenJN == true) BeschraenkungRollstuhl.NewChild("Bremsen", "");
                    if (rUnterbringung.HindernRollstuhlSitzhoseJN == true) BeschraenkungRollstuhl.NewChild("Sitzhose", "");
                    if (rUnterbringung.HindernRollstuhl.ToString().Trim() != "") BeschraenkungRollstuhl.NewChild("Sonstiges", rUnterbringung.HindernRollstuhl.ToString().Trim().Trim());
                }

                if (rUnterbringung.HindernSitzgelGurtenJN == true || rUnterbringung.HindernSitzgelTischJN == true ||
                    rUnterbringung.HindernSitzgelTherapietischJN == true || rUnterbringung.HindernSitzgelSitzhoseJN == true ||
                    rUnterbringung.HindernSitzgelegenheit.ToString().Trim() != "")
                {
                    Chilkat.Xml BeschraenkungSitzgelegenheit = Beschraenkungen.NewChild("Beschraenkung", "");
                    BeschraenkungSitzgelegenheit.AddAttribute("Art", "Sitzgelegenheit");
                    if (Meldungart == eMeldungstyp.Vornahme || Meldungart == eMeldungstyp.Verlaengerung) 
                        BeschraenkungSitzgelegenheit.AddAttribute("Dauer", BeschrDauer);
                    if (rUnterbringung.HindernSitzgelGurtenJN == true) BeschraenkungSitzgelegenheit.NewChild("Gurten", "");
                    if (rUnterbringung.HindernSitzgelTischJN == true) BeschraenkungSitzgelegenheit.NewChild("Tisch", "");
                    if (rUnterbringung.HindernSitzgelTherapietischJN == true) BeschraenkungSitzgelegenheit.NewChild("Therapietisch", "");
                    if (rUnterbringung.HindernSitzgelSitzhoseJN == true) BeschraenkungSitzgelegenheit.NewChild("Sitzhose", "");
                    if (rUnterbringung.HindernSitzgelegenheit.ToString().Trim() != "") BeschraenkungSitzgelegenheit.NewChild("Sonstiges", rUnterbringung.HindernSitzgelegenheit.ToString().Trim());
                }

                if (rUnterbringung.HindernVerlassenBettSeitenteilenJN == true || rUnterbringung.HindernVerlassenBettGurtenJN == true ||
                    rUnterbringung.HindernVerlassenBettHandmanschettenJN == true)
                {
                    Chilkat.Xml BeschraenkungBett = Beschraenkungen.NewChild("Beschraenkung", "");
                    BeschraenkungBett.AddAttribute("Art", "Bett");
                    if (Meldungart == eMeldungstyp.Vornahme || Meldungart == eMeldungstyp.Verlaengerung)
                        BeschraenkungBett.AddAttribute("Dauer", BeschrDauer.Trim());
                    if (rUnterbringung.HindernVerlassenBettSeitenteilenJN == true) BeschraenkungBett.NewChild("Seitenteilen", "");
                    if (rUnterbringung.HindernVerlassenBettGurtenJN == true) BeschraenkungBett.NewChild("Gurten", "");
                    if (rUnterbringung.HindernVerlassenBettHandmanschettenJN == true) BeschraenkungBett.NewChild("Handmanschette", "");
                    if (rUnterbringung.HindernSitzgelegenheit.ToString().Trim() != "") BeschraenkungBett.NewChild("Sonstiges", rUnterbringung.HindernBettVerlassen.ToString().Trim());
                }

                if (rUnterbringung.MedikFreihBeschraenkungJN == true || rUnterbringung.MedikBezeichnung.ToString().Trim() != "")
                {
                    Chilkat.Xml BeschraenkungMedkiamente = Beschraenkungen.NewChild("Beschraenkung", "");
                    BeschraenkungMedkiamente.AddAttribute("Art", "Medikamente");
                    if (Meldungart == eMeldungstyp.Vornahme || Meldungart == eMeldungstyp.Verlaengerung) 
                        BeschraenkungMedkiamente.AddAttribute("Dauer", BeschrDauer.Trim());
                    if (rUnterbringung.MedikBezeichnung.ToString().Trim() != "") BeschraenkungMedkiamente.NewChild("Medikation", rUnterbringung.MedikBezeichnung.ToString().Trim());
                }

                //-----------------Anordnung
                Chilkat.Xml Anordnung = xml.NewChild("Anordnung", "");
                Chilkat.Xml AnordnungPerson = Anordnung.NewChild("Person", "");

                if (Meldungart == eMeldungstyp.Vornahme || Meldungart == eMeldungstyp.Verlaengerung)
                {
                    AnordnungPerson.AddAttribute("Typ", LookUp(dictBerufsstand, (int)rUnterbringung.Berufsgruppe));
                    AnordnungPerson.NewChild("Titel", (rUnterbringung.AngeordnetVonTitel.Trim() != "" ? rUnterbringung.AngeordnetVonTitel.Trim() : "k.A."));
                    AnordnungPerson.NewChild("VorName", (rUnterbringung.AngeordnetVonVorname.Trim() != "" ? rUnterbringung.AngeordnetVonVorname.Trim() : "k.A."));
                    AnordnungPerson.NewChild("FamilienName", (rUnterbringung.AngeordnetVon.Trim() != "" ? rUnterbringung.AngeordnetVon.Trim() : "k.A.")); 
                }
                else
                {
                    AnordnungPerson.AddAttribute("Typ", LookUp(dictBerufsstand, (int) rUnterbringung.ENDEBerufsgruppe));
                    AnordnungPerson.NewChild("Titel", (rUnterbringung.AufgehobenVonTitel.Trim() != "" ? rUnterbringung.AufgehobenVonTitel.Trim() : "k.A."));
                    AnordnungPerson.NewChild("VorName", (rUnterbringung.AufgehobenVonVorname.Trim() != "" ? rUnterbringung.AufgehobenVonVorname.Trim() : "k.A."));
                    AnordnungPerson.NewChild("FamilienName", (rUnterbringung.AufgehobenVon != null ? rUnterbringung.AufgehobenVon.Trim() : "k.A.")); 
                }

                //-----------------Einrichtungsleiter
                Chilkat.Xml Einrichtungsleiter = xml.NewChild("Einrichtungsleiter", "");
                Einrichtungsleiter.NewChild("Titel", (rUnterbringung.EinrichtungsleiterTitel.Trim() != "" ? rUnterbringung.EinrichtungsleiterTitel.Trim() : "k.A."));
                Einrichtungsleiter.NewChild("VorName", (rUnterbringung.EinrichtungsleiterVorname.Trim() != "" ? rUnterbringung.EinrichtungsleiterVorname.Trim() : "k.A."));
                Einrichtungsleiter.NewChild("FamilienName", (rUnterbringung.Einrichtungsleiter.Trim() != "" ? rUnterbringung.Einrichtungsleiter.Trim() : "k.A.")); 

                //-----------------Gesendet
                Chilkat.Xml Gesendet = xml.NewChild("Gesendet", "");
                Gesendet.NewChild("BWV", "");

                if (rUnterbringung.ENDEGesendetAnGesetzVertreterJN == true)
                {
                    Gesendet.NewChild("GV", "");
                }
                if (rUnterbringung.ENDEGesendetAnSelbstGewVertreterJN == true)
                {
                    Gesendet.NewChild("SV", ""); 
                }
                if (rUnterbringung.ENDEGesendetAnVertrauenspersonJN == true)
                {
                    Gesendet.NewChild("VP", "");
                } 
                    
                txt = xml.GetXml();
                txt = txt.Replace("<BWV />", "<BWV/>");
                if (rUnterbringung.ENDEGesendetAnGesetzVertreterJN == true)
                {
                    txt = txt.Replace("<GV />", "<GV/>");
                }
                if (rUnterbringung.ENDEGesendetAnSelbstGewVertreterJN == true)
                {
                    txt = txt.Replace("<SV />", "<SV/>");
                }
                if (rUnterbringung.ENDEGesendetAnVertrauenspersonJN == true)
                {
                    txt = txt.Replace("<VP />", "<VP/>");
                } 

                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.LoadXml(txt);
                System.Xml.XmlNode FirstNode = xmldoc.ChildNodes[1];

                string ResServiceCall = "";
                this.CallService(xmldoc, ref ResServiceCall);

                qs2.core.vb.dsProtocol dsProtocol1 = new qs2.core.vb.dsProtocol();
                qs2.core.vb.sqlProtocoll sqlProtocoll = new qs2.core.vb.sqlProtocoll();
                sqlProtocoll.initControl();
                string CmdReturn = "";
                sqlProtocoll.getProtocol(System.Guid.NewGuid(), ref dsProtocol1, qs2.core.vb.sqlProtocoll.eSelProtocoll.ID, "", System.Guid.NewGuid(), -1, "", "", null, null, "", ref CmdReturn);

                qs2.core.vb.dsProtocol.ProtocolRow rNewProt = (qs2.core.vb.dsProtocol.ProtocolRow)sqlProtocoll.newProtocol(ref dsProtocol1);
                rNewProt.Type = "";
                rNewProt.IDApplication = "PMDS";
                PMDS.BusinessLogic.Benutzer ben = new PMDS.BusinessLogic.Benutzer(ENV.USERID);
                rNewProt.Created = DateTime.Now;
                rNewProt.User = ben.FullName;
                rNewProt.Info = QS2.Desktop.ControlManagment.ControlManagment.getRes("Senden Unterbringung");  
                rNewProt.Protocol = ResServiceCall;
                rNewProt.IDGuid = System.Guid.NewGuid();

                System.Xml.XmlDocument xmlResult = new System.Xml.XmlDocument();
                xmlResult.LoadXml(ResServiceCall);
                System.Xml.XmlElement rootResult = xmlResult.DocumentElement;
                retSendUnterbringung1.ResultXML = ResServiceCall.ToString();

                foreach (System.Xml.XmlElement xnode in rootResult.ChildNodes)
                {
                    string nameParent = xnode.Name;
                    string valueParent = xnode.InnerText;
                    if (nameParent.Trim().Equals(("Validation").Trim(), StringComparison.CurrentCultureIgnoreCase))
                    {
                        string sValidYN = xnode.Attributes["Result"].Value;
                        if (sValidYN.Trim().Equals(("Valid").Trim(), StringComparison.CurrentCultureIgnoreCase))
                        {
                            rNewProt.progress = "OK";
                            retSendUnterbringung1.OK = true;
                        }
                        else if (sValidYN.Trim().Equals(("Invalid").Trim(), StringComparison.CurrentCultureIgnoreCase))
                        {
                            rNewProt.progress = "Error";
                            retSendUnterbringung1.OK = false;
                        }
                    }

                    foreach (System.Xml.XmlElement xnode2 in xnode.ChildNodes)
                    {
                        string name = xnode2.Name;
                        string value = xnode2.InnerText;
                        if (name.Trim().Equals(("ErrorCode").Trim(), StringComparison.CurrentCultureIgnoreCase))
                        {
                            retSendUnterbringung1.ErrorCode = System.Convert.ToInt32(value);
                        }
                        if (name.Trim().Equals(("ErrorMessage").Trim(), StringComparison.CurrentCultureIgnoreCase))
                        {
                            retSendUnterbringung1.ErrorTxt = value.Trim();
                        }
                    }
                }

                sqlProtocoll.daProtocol.Update(dsProtocol1.Protocol);

                rUnterbringung.EDI_Datum = DateTime.Now;
                rUnterbringung.EDI_Benutzer = ENV.USERID;
                rUnterbringungFromService = rUnterbringung;

                return true;
           
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.DB.PMDSBusiness b = new PMDSBusiness();
                throw new System.Data.Entity.Validation.DbEntityValidationException(b.getDbEntityValidationException(ex), ex);
            }
            catch(Exception ex)
            {
                throw new Exception("SendUnterbringung.Send: " + ex.ToString());
            }
        }

        public bool CallService(System.Xml.XmlNode FirstNode, ref string ResServiceCall)
        {
            X509Certificate certificate;
            string fileName = ENV.pathConfig + "\\" + "HAGZertifikat.pfx";
            try
            {

                BIDS_EDIService.BIDS_EDI_Service wsEDI = new BIDS_EDIService.BIDS_EDI_Service();
                wsEDI.Url = "https://edi-v1.bewohnervertretung.at/BIDS_EDIService.asmx";
                certificate = new X509Certificate(fileName);


                var proxy = WebRequest.DefaultWebProxy;
                try
                {
                    System.Uri uri = new System.Uri(ENV.HAG_Url);
                    if (!proxy.IsBypassed(uri))
                    {

                        //Mit den Anmeldeinformationen des Users
                        //handler.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;

                        // Mit fixen Werten aus der ENV
                        //WebProxy wProxy = new WebProxy();
                        //CredentialCache cc = new CredentialCache();
                        //NetworkCredential nc = new NetworkCredential(ENV.ProxyUserName.Trim(), ENV.ProxyPassword.Trim(), ENV.ProxyDomain.Trim());
                        //cc.Add(ENV.ProxyHost.Trim(), ENV.ProxyPort, ENV.ProxyAuthentication.Trim(), nc);
                        //wProxy.Credentials = cc;

                        //Mit eingabe des Passworts
                        string pw = Console.ReadLine();
                        string promptValue = "";
                        if (ENV.HAG_PASSWORD_TMP == "")
                        {
                            promptValue = Prompt.ShowDialog(QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte geben Sie Ihr Passwort ein"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Meldung senden"));  
                            ENV.HAG_PASSWORD_TMP = promptValue;
                        }
                        else
                            promptValue = ENV.HAG_PASSWORD_TMP;
                        string uName = WindowsIdentity.GetCurrent().Name;
                        proxy.Credentials = new NetworkCredential(uName, promptValue);
                        wsEDI.Credentials = proxy.Credentials;
                    }
                }
                catch
                {
                    WebRequest.DefaultWebProxy = WebRequest.GetSystemWebProxy();  
                    WebRequest.DefaultWebProxy.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                }


                //if (ENV.ProxyJN)
                //{
                //    WebProxy wProxy = new WebProxy();
                //    CredentialCache cc = new CredentialCache();
                //    NetworkCredential nc = new NetworkCredential(ENV.ProxyUserName.Trim(), ENV.ProxyPassword.Trim(), ENV.ProxyDomain.Trim());
                //    cc.Add(ENV.ProxyHost.Trim(), ENV.ProxyPort, ENV.ProxyAuthentication.Trim(), nc);

                //    wProxy.Credentials = cc;
                //    wsEDI.Proxy = wProxy;
                //}
                //else
                //{
                //    WebRequest.DefaultWebProxy = WebRequest.GetSystemWebProxy();  
                //    WebRequest.DefaultWebProxy.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;

                //WebRequest.DefaultWebProxy = WebRequest.GetSystemWebProxy();
                //WebRequest.DefaultWebProxy.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;

                wsEDI.ClientCertificates.Add(certificate);
                XmlNode node = wsEDI.SubmitReport(FirstNode);
                StringWriter w = new StringWriter();
                XmlTextWriter writer2 = new XmlTextWriter(w);
                node.WriteTo(writer2);
                ResServiceCall = w.ToString();

                return true;
            }
            catch (XmlException exception)
            {
                string txtException = string.Concat(new object[] { "XmlException:\r\n", exception.Message, "\r\nLineNumber: ", exception.LineNumber, "\r\nLinePosition: ", exception.LinePosition, "\r\nStackTrace:\r\n", exception.StackTrace });
                throw new Exception("SendUnterbringung: " + txtException);
            }
            catch (Exception exception2)
            {
                throw new Exception("SendUnterbringung: " + exception2.ToString());
            }

        }

        public bool Send2016(System.Guid IDUnterbringung, ref retSendUnterbringung retSendUnterbringung1, ref eMeldungstyp Meldungsart,
                            ref PMDS.db.Entities.Unterbringung rUnterbringungFromService, ref PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                Dictionary<int, string> dictMeldungstyp = new Dictionary<int, string>();
                dictMeldungstyp.Add(1, "Vornahme");
                dictMeldungstyp.Add(2, "Verlaengerung");
                dictMeldungstyp.Add(3, "Aufhebung");

                Dictionary<int, string> dictAufhebungsgrund = new Dictionary<int, string>();
                dictAufhebungsgrund.Add(1, "ZUG");
                dictAufhebungsgrund.Add(2, "TOT");
                dictAufhebungsgrund.Add(3, "AND");
                dictAufhebungsgrund.Add(4, "ALT");
                dictAufhebungsgrund.Add(5, "UEB");
                dictAufhebungsgrund.Add(6, "WEG");

                Dictionary<int, string> dictBeschraenkungsdauer = new Dictionary<int, string>();
                dictBeschraenkungsdauer.Add(5, "Unter48h");
                dictBeschraenkungsdauer.Add(10, "Ueber48h");
                //dictBeschraenkungsdauer.Add(11, "Wiederholt");

                Dictionary<int, string> dictBerufsstand = new Dictionary<int, string>();
                dictBerufsstand.Add(0, "IsArzt");
                dictBerufsstand.Add(1, "IsDGKSP");
                dictBerufsstand.Add(2, "IsDGKSP");
                dictBerufsstand.Add(3, "IsPaedagogischeLeitung");


                System.Linq.IQueryable<PMDS.db.Entities.Unterbringung> tUnterbringung = null;
                PMDS.db.Entities.Unterbringung rUnterbringung = null;
                System.Linq.IQueryable<PMDS.db.Entities.Aufenthalt> tAufenthalt = null;
                PMDS.db.Entities.Aufenthalt rAufenthalt = null;
                System.Linq.IQueryable<PMDS.db.Entities.Patient> tPatient = null;
                PMDS.db.Entities.Patient rPatient = null;
                System.Linq.IQueryable<PMDS.db.Entities.Klinik> tKlinik = null;
                PMDS.db.Entities.Klinik rKlinik = null;
                System.Linq.IQueryable<PMDS.db.Entities.Abteilung> tAbteilung = null;
                PMDS.db.Entities.Abteilung rAbteilung = null;
                System.Linq.IQueryable<PMDS.db.Entities.Adresse> tAdresse = null;
                PMDS.db.Entities.Adresse rAdresse = null;

                tUnterbringung = db.Unterbringung.Where(o => o.ID == IDUnterbringung);
                rUnterbringung = tUnterbringung.First();
                tAufenthalt = db.Aufenthalt.Where(o => o.ID == rUnterbringung.IDAufenthalt);
                rAufenthalt = tAufenthalt.First();
                tPatient = db.Patient.Where(o => o.ID == rAufenthalt.IDPatient);
                rPatient = tPatient.First();
                tKlinik = db.Klinik.Where(o => o.ID == rAufenthalt.IDKlinik);
                rKlinik = tKlinik.First();
                tAbteilung = db.Abteilung.Where(o => o.ID == rAufenthalt.IDAbteilung);
                rAbteilung = tAbteilung.First();
                tAdresse = db.Adresse.Where(o => o.ID == rKlinik.IDAdresse);
                rAdresse = tAdresse.First();

                string txt = "";
                string DateTimeFormat = "yyyy-MM-ddThh:mm:ss";
                string DateFormat = "yyyy-MM-dd";


                Chilkat.Xml xml = new Chilkat.Xml();
                xml.Encoding = "utf-8";
                xml.Tag = LookUp(dictMeldungstyp, (int)Meldungsart);

                xml.AddAttribute("xmlns", "http://www.bewohnervertretung.at/Edi" + LookUp(dictMeldungstyp, (int)Meldungsart));
                xml.AddAttribute("xmlns:t", "http://www.bewohnervertretung.at/EdiTypes");

                //-----------------Bewohner 
                Chilkat.Xml Bewohner = xml.NewChild("Bewohner", "");
                Bewohner.NewChild("t:Vorname", rPatient.Vorname.Trim());
                Bewohner.NewChild("t:Nachname", rPatient.Nachname.Trim());
                Bewohner.NewChild("t:Geburtsdatum", rPatient.Geburtsdatum.Value.ToString(DateFormat));
                Bewohner.NewChild("t:Geschlecht", rPatient.Sexus.Trim().Substring(0, Math.Min(1, rPatient.Sexus.Trim().Length)).ToUpper());

                //-----------------Einrichtung 
                Chilkat.Xml Einrichtung = xml.NewChild("Einrichtung", "");
                Einrichtung.AddAttribute("Name", rKlinik.Bezeichnung.Trim().Substring(0, Math.Min(128, rKlinik.Bezeichnung.Trim().Length)));
                Chilkat.Xml Abteilung = Einrichtung.NewChild("t:Abteilung", "");
                Abteilung.AddAttribute("Name", rAbteilung.Bezeichnung.Trim().Substring(0, Math.Min(128, rAbteilung.Bezeichnung.Trim().Length)));

                //-----------------Meldedaten 
                if (Meldungsart == eMeldungstyp.Vornahme)
                {
                    Chilkat.Xml Meldungsdaten = xml.NewChild("Meldedaten", "");

                    Meldungsdaten.AddAttribute("Beginn", rUnterbringung.Beginn.Value.ToString(DateTimeFormat));

                    if (rUnterbringung.ErheblicheFremdgefaehrdungJN == true)
                        Meldungsdaten.AddAttribute("IsFremdgefaehrdung", "true");
                    if (rUnterbringung.GeistigeBehinderungJN == true)
                        Meldungsdaten.AddAttribute("IsGeistigeBehinderung", "true");
                    if (rUnterbringung.PsychischekrankheitJN == true)
                        Meldungsdaten.AddAttribute("IsPsychischeErkrankung", "true");
                    if (rUnterbringung.ErheblicheSelbstgefaehrdungJN == true)
                        Meldungsdaten.AddAttribute("IsSelbstgefaehrdung", "true");
                    if (rUnterbringung.KlientZustimmungJN == true)
                        Meldungsdaten.AddAttribute("IsZustimmung", "true");

                    Chilkat.Xml Dauer = Meldungsdaten.NewChild("Dauer", "");
                    if (rUnterbringung.Dauer == 5)
                    {
                        Chilkat.Xml BeschraenkungsDauer = Dauer.NewChild(LookUp(dictBeschraenkungsdauer, 5), "");
                    }
                    else if (rUnterbringung.Dauer == 10)
                    {
                        Chilkat.Xml BeschraenkungsDauer = Dauer.NewChild(LookUp(dictBeschraenkungsdauer, 10), "");
                    }
                    else if (rUnterbringung.Dauer == 11)
                    {
                        Chilkat.Xml BeschraenkungsDauer = Dauer.NewChild(LookUp(dictBeschraenkungsdauer, 11), "");
                    }

                    if (!rUnterbringung.MedizinischeDiagnose.Trim().Equals(""))
                    {
                        Chilkat.Xml AnmerkungErkrankung = Meldungsdaten.NewChild("AnmerkungErkrankung", rUnterbringung.MedizinischeDiagnose.Trim().Substring(0, Math.Min(1024, rUnterbringung.MedizinischeDiagnose.Trim().Length)));
                    }

                    if (!rUnterbringung.AnmerkungGutachten_2016.Trim().Equals(""))
                    {
                        Chilkat.Xml AnmerkungErkrankung = Meldungsdaten.NewChild("AnmerkungGutachten", rUnterbringung.AnmerkungGutachten_2016.Trim().Substring(0, Math.Min(1024, rUnterbringung.AnmerkungGutachten_2016.Trim().Length)));
                    }

                    if (!rUnterbringung.AnmerkungVerhalten_2016.Trim().Equals(""))
                    {
                        Chilkat.Xml AnmerkungVerhalten = Meldungsdaten.NewChild("AnmerkungVerhalten", rUnterbringung.AnmerkungVerhalten_2016.Trim().Substring(0, Math.Min(1024, rUnterbringung.AnmerkungVerhalten_2016.Trim().Length)));
                    }

                    //---------------------------------------- Angeordnet von -------------------------
                    Chilkat.Xml AngeordnetVon = xml.NewChild("AngeordnetVon", "");
                    AngeordnetVon.AddAttribute(LookUp(dictBerufsstand, (int)rUnterbringung.Berufsgruppe), "true");

                    Chilkat.Xml AnordnendePerson = AngeordnetVon.NewChild("t:AnordnendePerson", "");
                    string tmpAngeordnetVonVorname = rUnterbringung.AngeordnetVonVorname.Trim().Substring(0, Math.Min(128, rUnterbringung.AngeordnetVonVorname.Trim().Length));
                    if (tmpAngeordnetVonVorname == "") tmpAngeordnetVonVorname = "<nicht eingetragen>";
                    Chilkat.Xml AnordnendePersonVorname = AnordnendePerson.NewChild("t:Vorname", tmpAngeordnetVonVorname);

                    string tmpAngeordnetVonNachname = rUnterbringung.AngeordnetVon.Trim().Substring(0, Math.Min(128, rUnterbringung.AngeordnetVon.Trim().Length));
                    if (tmpAngeordnetVonNachname == "") tmpAngeordnetVonNachname = "<nicht eingetragen>";
                    Chilkat.Xml AnordnendePersonNachname = AnordnendePerson.NewChild("t:Nachname", tmpAngeordnetVonNachname);

                    Chilkat.Xml Einrichtungsleiter = AngeordnetVon.NewChild("t:Einrichtungsleiter", "");
                    string tmpEinrichtungsLeiterVorname = rUnterbringung.EinrichtungsleiterVorname.Trim().Substring(0, Math.Min(128, rUnterbringung.EinrichtungsleiterVorname.Trim().Length));
                    if (tmpEinrichtungsLeiterVorname == "") tmpEinrichtungsLeiterVorname = "<nicht eingetragen>";
                    Chilkat.Xml EinrichtungsleiterVorname = Einrichtungsleiter.NewChild("t:Vorname", tmpEinrichtungsLeiterVorname);

                    string tmpEinrichtungsLeiter = rUnterbringung.Einrichtungsleiter.Trim().Substring(0, Math.Min(128, rUnterbringung.Einrichtungsleiter.Trim().Length));
                    if (tmpEinrichtungsLeiter == "")  tmpEinrichtungsLeiter =  "<nicht eingetragen>" ;
                    Chilkat.Xml EinrichtungsleiterNachname = Einrichtungsleiter.NewChild("t:Nachname",tmpEinrichtungsLeiter);
                }

                else if (Meldungsart == eMeldungstyp.Aufhebung)
                {
                    Chilkat.Xml Meldungsdaten = xml.NewChild("Meldedaten", "");

                    Meldungsdaten.AddAttribute("Aufhebungsdatum", rUnterbringung.AufgehobenAm.Value.ToString(DateTimeFormat));
                    Meldungsdaten.AddAttribute("Aufhebungsgrund", LookUp(dictAufhebungsgrund, rUnterbringung.TatsaechlicheEndeGrund));
                }

                //------------------------------- Maßnahmen -------------------------------------------------

                // -------------------- Bereich ----------------------
                if (!rUnterbringung.BaulicheMassnahmen.Trim().Equals("") && rUnterbringung.HindernBereichAndereJN_2016 == true)
                {
                    Chilkat.Xml Massnahme_BereichAndere_1 = xml.NewChild("Massnahme", "");
                    Chilkat.Xml Massnahme_BereichAndere_2 = Massnahme_BereichAndere_1.NewChild("t:Bereich", "");
                    Chilkat.Xml Massnahme_BereichAndere_3 = Massnahme_BereichAndere_2.NewChild("t:Andere", rUnterbringung.BaulicheMassnahmen.Trim().Substring(0, Math.Min(1024, rUnterbringung.BaulicheMassnahmen.Trim().Length)));
                }

                if (rUnterbringung.HindernBereichBarriereJN_2016 == true)
                {
                    Chilkat.Xml Massnahme_BereichBarriere_1 = xml.NewChild("Massnahme", "");
                    Chilkat.Xml Massnahme_BereichBarriere_2 = Massnahme_BereichBarriere_1.NewChild("t:Bereich", "");
                    Chilkat.Xml Massnahme_BereichBarriere_3 = Massnahme_BereichBarriere_2.NewChild("t:Barriere", "");
                }

                if (rUnterbringung.HindernBereichFesthaltenJN_2016 == true)
                {
                    Chilkat.Xml Massnahme_BereichFesthalten_1 = xml.NewChild("Massnahme", "");
                    Chilkat.Xml Massnahme_BereichFesthalten_2 = Massnahme_BereichFesthalten_1.NewChild("t:Bereich", "");
                    Chilkat.Xml Massnahme_BereichFesthalten_3 = Massnahme_BereichFesthalten_2.NewChild("t:Festhalten", "");
                }

                if (rUnterbringung.HindernBereichHinderAmFortbewegenJN_2016 == true)
                {
                    Chilkat.Xml Massnahme_BereichHindernAmFortbewegen_1 = xml.NewChild("Massnahme", "");
                    Chilkat.Xml Massnahme_BereichHindernAmFortbewegen_2 = Massnahme_BereichHindernAmFortbewegen_1.NewChild("t:Bereich", "");
                    Chilkat.Xml Massnahme_BereichHindernAmFortbewegen_3 = Massnahme_BereichHindernAmFortbewegen_2.NewChild("t:HindernAmFortbewegen", "");
                }

                if (rUnterbringung.ElektronischesUeberwachungJN == true)
                {
                    Chilkat.Xml Massnahme_BereichSensor_1 = xml.NewChild("Massnahme", "");
                    Chilkat.Xml Massnahme_BereichSensor_2 = Massnahme_BereichSensor_1.NewChild("t:Bereich", "");
                    Chilkat.Xml Massnahme_BereichSensor_3 = Massnahme_BereichSensor_2.NewChild("t:Sensor", "");
                }

                if (rUnterbringung.HindernBereichVersperrterBereichJN_2016 == true)
                {
                    Chilkat.Xml Massnahme_BereichVersperrterBereich_1 = xml.NewChild("Massnahme", "");
                    Chilkat.Xml Massnahme_BereichVersperrterBereich_2 = Massnahme_BereichVersperrterBereich_1.NewChild("t:Bereich", "");
                    Chilkat.Xml Massnahme_BereichVersperrterBereich_3 = Massnahme_BereichVersperrterBereich_2.NewChild("t:VersperrterBereich", "");
                }

                if (rUnterbringung.HindernBereichVersperrtesZimmerJN_2016 == true)
                {
                    Chilkat.Xml Massnahme_BereichVersperrtesZimmer_1 = xml.NewChild("Massnahme", "");
                    Chilkat.Xml Massnahme_BereichVersperrtesZimmer_2 = Massnahme_BereichVersperrtesZimmer_1.NewChild("t:Bereich", "");
                    Chilkat.Xml Massnahme_BereichVersperrtesZimmer_3 = Massnahme_BereichVersperrtesZimmer_2.NewChild("t:VersperrtesZimmer", "");
                }

                if (rUnterbringung.ZurueckhaltensandrohungJN == true)
                {
                    Chilkat.Xml Massnahme_BereichZurueckhalten_1 = xml.NewChild("Massnahme", "");
                    Chilkat.Xml Massnahme_BereichZurueckhalten_2 = Massnahme_BereichZurueckhalten_1.NewChild("t:Bereich", "");
                    Chilkat.Xml Massnahme_BereichZurueckhalten_3 = Massnahme_BereichZurueckhalten_2.NewChild("t:Zurueckhalten", "");
                }

                // -------------------- Bett ----------------------
                if (!rUnterbringung.HindernBettVerlassen.Trim().Equals("") && rUnterbringung.HindernVerlassenBettAndereJN_2016 == true)
                {
                    Chilkat.Xml Massnahme_BettAndere_1 = xml.NewChild("Massnahme", "");
                    Chilkat.Xml Massnahme_BettAndere_2 = Massnahme_BettAndere_1.NewChild("t:Bett", "");
                    Chilkat.Xml Massnahme_BéttAndere_3 = Massnahme_BettAndere_2.NewChild("t:Andere", rUnterbringung.HindernBettVerlassen.Trim().Substring(0, Math.Min(1024, rUnterbringung.HindernBettVerlassen.Trim().Length)));
                }

                if (rUnterbringung.HindernVerlassenBettBauchgurtJN_2016 == true)
                {
                    Chilkat.Xml Massnahme_BettBauchgurt_1 = xml.NewChild("Massnahme", "");
                    Chilkat.Xml Massnahme_BettBauchgurt_2 = Massnahme_BettBauchgurt_1.NewChild("t:Bett", "");
                    Chilkat.Xml Massnahme_BettBauchgurt_3 = Massnahme_BettBauchgurt_2.NewChild("t:Bauchgurt", "");
                }

                if (rUnterbringung.HindernVerlassenBettElektronischJN_2016 == true)
                {
                    Chilkat.Xml Massnahme_BettElektronisch_1 = xml.NewChild("Massnahme", "");
                    Chilkat.Xml Massnahme_BettElektronisch_2 = Massnahme_BettElektronisch_1.NewChild("t:Bett", "");
                    Chilkat.Xml Massnahme_BettElektronisch_3 = Massnahme_BettElektronisch_2.NewChild("t:Elektronisch", "");
                }

                if ((int)rUnterbringung.HindernVerlassenBettFussBeingurte_2016 >= 1)
                {
                    Chilkat.Xml Massnahme_BettFussBeingurte1_1 = xml.NewChild("Massnahme", "");
                    Chilkat.Xml Massnahme_BettFussBeingurte1_2 = Massnahme_BettFussBeingurte1_1.NewChild("t:Bett", "");
                    int Anz = (int)rUnterbringung.HindernVerlassenBettFussBeingurte_2016;
                    Chilkat.Xml Massnahme_BettFussBeingurte1_3 = Massnahme_BettFussBeingurte1_2.NewChild("t:FussBeingurte", Anz.ToString());
                }

                if ((int)rUnterbringung.HindernVerlassenBettHandArmgurte_2016 >= 1)
                {
                    Chilkat.Xml Massnahme_BettHandArmgurte1_1 = xml.NewChild("Massnahme", "");
                    Chilkat.Xml Massnahme_BettHandArmgurte1_2 = Massnahme_BettHandArmgurte1_1.NewChild("t:Bett", "");
                    int Anz = (int)rUnterbringung.HindernVerlassenBettHandArmgurte_2016;
                    Chilkat.Xml Massnahme_BettHandArmgurte1_3 = Massnahme_BettHandArmgurte1_2.NewChild("t:HandArmgurte", Anz.ToString());
                }

                if (rUnterbringung.HindernVerlassenBettSeitenteilenJN == true)
                {
                    Chilkat.Xml Massnahme_BettSeitenteile_1 = xml.NewChild("Massnahme", "");
                    Chilkat.Xml Massnahme_BettSeitenteile_2 = Massnahme_BettSeitenteile_1.NewChild("t:Bett", "");
                    Chilkat.Xml Massnahme_BettSeitenteile_3 = Massnahme_BettSeitenteile_2.NewChild("t:Seitenteile", "");
                }

                //------------- Medikation ------
                if (!rUnterbringung.Einzelfallmedikation_2016.Trim().Equals("") && rUnterbringung.EinzelfallmedikationJN_2016 == true)
                {
                    Chilkat.Xml Massnahme_Einzelfallmedikation_1 = xml.NewChild("Massnahme", "");
                    Chilkat.Xml Massnahme_Einzelfallmedikation_2 = Massnahme_Einzelfallmedikation_1.NewChild("t:Medikament", "");
                    Chilkat.Xml Massnahme_Einzelfallmedikation_3 = Massnahme_Einzelfallmedikation_2.NewChild("t:Einzelfallmedikation", rUnterbringung.Einzelfallmedikation_2016.Trim().Substring(0, Math.Min(1024, rUnterbringung.Einzelfallmedikation_2016.Length)));
                }

                if (!rUnterbringung.Dauermedikation_2016.Trim().Equals("") && rUnterbringung.DauermedikationJN_2016 == true)
                {
                    Chilkat.Xml Massnahme_Dauermedikation_1 = xml.NewChild("Massnahme", "");
                    Chilkat.Xml Massnahme_Dauermedikation_2 = Massnahme_Dauermedikation_1.NewChild("t:Medikament", "");
                    Chilkat.Xml Massnahme_Dauermedikation_3 = Massnahme_Dauermedikation_2.NewChild("t:Dauermedikation", rUnterbringung.Dauermedikation_2016.Trim().Substring(0, Math.Min(1024, rUnterbringung.Dauermedikation_2016.Length)));
                }

                //---------------- Sitz ------------------
                if (!rUnterbringung.HindernSitzgelegenheit.Trim().Equals("") && rUnterbringung.HindernSitzgelAndereJN_2016 == true)
                {
                    Chilkat.Xml Massnahme_SitzAndere_1 = xml.NewChild("Massnahme", "");
                    Chilkat.Xml Massnahme_SitzAndere_2 = Massnahme_SitzAndere_1.NewChild("t:Sitz", "");
                    Chilkat.Xml Massnahme_SitzAndere_3 = Massnahme_SitzAndere_2.NewChild("t:Andere", rUnterbringung.HindernSitzgelegenheit.Trim().Substring(0, Math.Min(1024, rUnterbringung.HindernSitzgelegenheit.Trim().Length)));
                }

                if (rUnterbringung.HindernSitzgelBauchgurtJN_2016 == true)
                {
                    Chilkat.Xml Massnahme_SitzBauchgurt_1 = xml.NewChild("Massnahme", "");
                    Chilkat.Xml Massnahme_SitzBauchgurt_2 = Massnahme_SitzBauchgurt_1.NewChild("t:Sitz", "");
                    Chilkat.Xml Massnahme_SitzBauchgurt_3 = Massnahme_SitzBauchgurt_2.NewChild("t:Bauchgurt", "");
                }

                if (rUnterbringung.HindernSitzgelBrustgurtJN_2016 == true)
                {
                    Chilkat.Xml Massnahme_SitzBrustgurt_1 = xml.NewChild("Massnahme", "");
                    Chilkat.Xml Massnahme_SitzBrustgurt_2 = Massnahme_SitzBrustgurt_1.NewChild("t:Sitz", "");
                    Chilkat.Xml Massnahme_SitzBrustgurt_3 = Massnahme_SitzBrustgurt_2.NewChild("t:Brustgurt", "");
                }

                if ((int)rUnterbringung.HindernSitzgelFussBeingurte_2016 >= 1)
                {
                    Chilkat.Xml Massnahme_SitzFussBeingurte1_1 = xml.NewChild("Massnahme", "");
                    Chilkat.Xml Massnahme_SitzFussBeingurte1_2 = Massnahme_SitzFussBeingurte1_1.NewChild("t:Sitz", "");
                    int Anz = (int)rUnterbringung.HindernSitzgelFussBeingurte_2016;
                    Chilkat.Xml Massnahme_SitzFussBeingurte1_3 = Massnahme_SitzFussBeingurte1_2.NewChild("t:FussBeingurte", Anz.ToString());
                }

                if ((int)rUnterbringung.HindernSitzgelHandArmgurte_2016 >= 1)
                {
                    Chilkat.Xml Massnahme_SitzHandArmgurte1_1 = xml.NewChild("Massnahme", "");
                    Chilkat.Xml Massnahme_SitzHandArmgurte1_2 = Massnahme_SitzHandArmgurte1_1.NewChild("t:Sitz", "");
                    int Anz = (int)rUnterbringung.HindernSitzgelHandArmgurte_2016;
                    Chilkat.Xml Massnahme_SitzHandArmgurte1_3 = Massnahme_SitzHandArmgurte1_2.NewChild("t:HandArmgurte", Anz.ToString());
                }

                if (rUnterbringung.HindernSitzgelSitzhoseJN == true)
                {
                    Chilkat.Xml Massnahme_SitzSitzhose_1 = xml.NewChild("Massnahme", "");
                    Chilkat.Xml Massnahme_SitzSitzhose_2 = Massnahme_SitzSitzhose_1.NewChild("t:Sitz", "");
                    Chilkat.Xml Massnahme_SitzSitzhose_3 = Massnahme_SitzSitzhose_2.NewChild("t:Sitzhose", "");
                }

                if (rUnterbringung.HindernSitzgelTherapietischJN == true)
                {
                    Chilkat.Xml Massnahme_SitzTherapietisch_1 = xml.NewChild("Massnahme", "");
                    Chilkat.Xml Massnahme_SitzTherapietisch_2 = Massnahme_SitzTherapietisch_1.NewChild("t:Sitz", "");
                    Chilkat.Xml Massnahme_SitzTherapietisch_3 = Massnahme_SitzTherapietisch_2.NewChild("t:Therapietisch", "");
                }

                if (rUnterbringung.HindernSitzgelTischJN == true)
                {
                    Chilkat.Xml Massnahme_SitzTisch_1 = xml.NewChild("Massnahme", "");
                    Chilkat.Xml Massnahme_SitzTisch_2 = Massnahme_SitzTisch_1.NewChild("t:Sitz", "");
                    Chilkat.Xml Massnahme_SitzTisch_3 = Massnahme_SitzTisch_2.NewChild("t:Tisch", "");
                }

                txt = xml.GetXml();

                string strCode = "";
                string strReason = "";
                string strResult = "";





                bool res = SendMeldungHTTP(txt, ENV.HAG_Url, ENV.HAG_Zertifikat, ref strResult, ref strCode, ref strReason);

                if (res)
                {

                    //XML im Log sichern
                    string LOGHAGPath = Path.Combine(ENV.ArchivPath, "HAG");
                    try
                    {
                        PMDS.Global.ENV.check_Path(LOGHAGPath, true);
                        using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(LOGHAGPath, rPatient.Nachname + "_" + rPatient.Vorname + "_" + System.Guid.NewGuid().ToString() + ".xml")))
                        {
                            outputFile.WriteLine(txt);
                        }
                    }
                    catch (Exception ex)
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Die Daten werden im Log-Verzeichnis protokolliert!", "HAG Protokoll-Verzeichnis", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(ENV.LOGPATH, rPatient.Nachname + "_" + rPatient.Vorname + "_" + System.Guid.NewGuid().ToString() + ".xml")))
                        {
                            outputFile.WriteLine(txt);
                        }
                    }

                    qs2.core.vb.dsProtocol dsProtocol1 = new qs2.core.vb.dsProtocol();
                    qs2.core.vb.sqlProtocoll sqlProtocoll = new qs2.core.vb.sqlProtocoll();
                    sqlProtocoll.initControl();
                     string CmdReturn = "";
                    sqlProtocoll.getProtocol(System.Guid.NewGuid(), ref dsProtocol1, qs2.core.vb.sqlProtocoll.eSelProtocoll.ID, "", System.Guid.NewGuid(), -1, "", "", null, null, "", ref CmdReturn);

                    qs2.core.vb.dsProtocol.ProtocolRow rNewProt = (qs2.core.vb.dsProtocol.ProtocolRow)sqlProtocoll.newProtocol(ref dsProtocol1);
                    rNewProt.Type = "";
                    rNewProt.IDApplication = "PMDS";
                    PMDS.BusinessLogic.Benutzer ben = new PMDS.BusinessLogic.Benutzer(ENV.USERID);
                    rNewProt.Created = DateTime.Now;
                    rNewProt.User = ben.FullName;
                    rNewProt.Info = QS2.Desktop.ControlManagment.ControlManagment.getRes("Senden HAG-Meldung");    
                    rNewProt.Protocol = strResult;
                    rNewProt.IDGuid = System.Guid.NewGuid();

                    if (strCode == "OK")
                    {
                        rNewProt.progress = strCode;
                        retSendUnterbringung1.OK = true;
                        retSendUnterbringung1.ResultXML = strCode.ToString();
                    }
                    else
                    {
                        rNewProt.progress = "Error";
                        retSendUnterbringung1.OK = false;
                        retSendUnterbringung1.ErrorTxt = strResult.Trim() + "\n\r" + strReason.Trim(); ;
                        retSendUnterbringung1.ResultXML = strReason.ToString();
                    }
                    sqlProtocoll.daProtocol.Update(dsProtocol1.Protocol);

                    rUnterbringung.EDI_Datum = DateTime.Now;
                    rUnterbringung.EDI_Benutzer = ENV.USERID;
                    rUnterbringungFromService = rUnterbringung;
                    return true;
                }
                else
                {
                    retSendUnterbringung1.ErrorTxt = strResult;
                    return false;
                }
            }


            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.DB.PMDSBusiness b = new PMDSBusiness();
                throw new System.Data.Entity.Validation.DbEntityValidationException(b.getDbEntityValidationException(ex), ex);
            }
            catch (Exception ex)
            {
                throw new Exception("SendUnterbringung.Send: " + ex.ToString());
            }
        }


        public string LookUp(Dictionary<int, string> dict, int SearchFor)
        {
            foreach (KeyValuePair<int, string> val in dict)
            {
                if (val.Key == SearchFor) return val.Value;
            }
            throw new Exception("LookUp: Value '" + SearchFor + "' in ENUM not found!");
        }


        public bool SendMeldungHTTP(string meldung, string url, string CertificateName, ref string strResult, ref string strCode, ref string strReason)
        {


            try
            {
                var result = new HttpResponseMessage();
                var resCode = new System.Net.HttpStatusCode();
                string resResult = "";
                string resReason = "";

                if (ENV.HAG_USER != "" && ENV.HAG_PASSWORD != "")
                {
                    // Zertifikat aus dem LocalMachine-Zertifikatsspeicher mit dem User aus der Config 
                    Impersonation.RunAction(ENV.HAG_USER, ENV.HAG_PASSWORD, System.Environment.MachineName, LogonType.LOGON32_LOGON_NEW_CREDENTIALS, LogonProvider.LOGON32_PROVIDER_DEFAULT, () =>
                    {
                        // Code der unter dem User laufen soll
                        X509Certificate2 certificate = FindCertificateFromStore(CertificateName, StoreLocation.LocalMachine, StoreName.My);
                        WebRequestHandler handler = new WebRequestHandler();
                        handler.ClientCertificates.Add(certificate);

                        using (HttpClient client = new HttpClient(handler))
                        {
                            var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("", meldung)
                };
                            var content = new FormUrlEncodedContent(pairs);

                            result = client.PostAsync(url, content).Result;
                            resCode = result.StatusCode;
                            resReason = result.ReasonPhrase.ToString();
                            resResult = result.Content.ReadAsStringAsync().Result;
                        }
                    });
                }
                else
                {
                    X509Certificate2 certificate = new X509Certificate2();
                    WebRequestHandler handler = new WebRequestHandler();
                    handler = new WebRequestHandler();

                    //Wenn als Zertifikat ein existierendes Zertifiakt angegeben ist und das Passwort gesetzt ist
                    if (File.Exists(CertificateName) && ENV.HAG_PASSWORD != "")
                    {
                        // Zertifikat von der Festplatte laden
                        certificate = new X509Certificate2(CertificateName, ENV.HAG_PASSWORD);
                    }
                    else if (ENV.HAG_USER == "" && ENV.HAG_PASSWORD == "")
                    {
                        // Zertifikat aus dem Zertifikatsspeicher des Benutzers holen
                        FindCertificateFromStore(CertificateName, StoreLocation.CurrentUser, StoreName.My);
                    }
                    else
                    {
                        strCode = QS2.Desktop.ControlManagment.ControlManagment.getRes("Interner Fehler");
                        strReason = QS2.Desktop.ControlManagment.ControlManagment.getRes("Kein gültiges Zertifikat gefunden.");
                        strResult = QS2.Desktop.ControlManagment.ControlManagment.getRes("Kein gültiges Zertifikat gefunden.")  + "\n\r" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Nicht gesendet");
                        return false;
                    }

                    handler.ClientCertificates.Add(certificate);


                    var proxy = WebRequest.DefaultWebProxy;
                    try
                    {
                        System.Uri uri = new System.Uri(url);
                        if (!proxy.IsBypassed(uri))
                        {

                            //Mit den Anmeldeinformationen des Users
                            //handler.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;

                            // Mit fixen Werten aus der ENV
                            //WebProxy wProxy = new WebProxy();
                            //CredentialCache cc = new CredentialCache();
                            //NetworkCredential nc = new NetworkCredential(ENV.ProxyUserName.Trim(), ENV.ProxyPassword.Trim(), ENV.ProxyDomain.Trim());
                            //cc.Add(ENV.ProxyHost.Trim(), ENV.ProxyPort, ENV.ProxyAuthentication.Trim(), nc);
                            //wProxy.Credentials = cc;

                            //Mit eingabe des Passworts
                            string pw = Console.ReadLine();
                            string promptValue = "";
                            if (ENV.HAG_PASSWORD_TMP == "")
                            {
                                promptValue = Prompt.ShowDialog(QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte geben Sie Ihr Passwort ein"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Meldung senden"));
                                ENV.HAG_PASSWORD_TMP = promptValue;
                            }
                            else
                                promptValue = ENV.HAG_PASSWORD_TMP;

                            string uName = WindowsIdentity.GetCurrent().Name;
                            proxy.Credentials = new NetworkCredential(uName, promptValue);
                            handler.Credentials = proxy.Credentials;
                        }
                    }
                    catch
                    {
                        //Kein Proxy erforderlich, nichts tun
                    }

                    using (HttpClient client = new HttpClient(handler))
                    {

                        try
                        {
                            //Cursor.Current = Cursors.WaitCursor;
                            var pairs = new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>("", meldung)
                            };
                            var content = new FormUrlEncodedContent(pairs);
                            //System.Windows.Forms.MessageBox.Show(url);
                            //System.Windows.Forms.MessageBox.Show(meldung);

                            result = client.PostAsync(url, content).Result;
                            resCode = result.StatusCode;
                            resReason = result.ReasonPhrase.ToString();
                            resResult = result.Content.ReadAsStringAsync().Result;
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.ToString());
                        }
                    }
                }

                strCode = resCode.ToString();
                strReason = resReason.ToString();
                strResult = resResult;
                return result.IsSuccessStatusCode;

            }
            catch (Exception ex)
            {
                strCode = QS2.Desktop.ControlManagment.ControlManagment.getRes("Fehler");
                strReason = QS2.Desktop.ControlManagment.ControlManagment.getRes(ex.ToString());
                strResult = QS2.Desktop.ControlManagment.ControlManagment.getRes("Nicht gesendet");
                return false;
            }
        }


        private static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 300,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedToolWindow,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 50, Top = 20, Width = 200, Text = text };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 200 };
                textBox.PasswordChar = '*';
                textBox.Font = new System.Drawing.Font(textBox.Font.FontFamily, 10);
                Button confirmation = new Button() { Text = "Ok", Left = 150, Width = 100, Top = 80, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }

        private X509Certificate2 FindCertificateFromStore(string cerSubject, StoreLocation storeLocation, StoreName storeName)
        {
            X509Certificate2 cert = null;

            var certStore = new X509Store(storeName, storeLocation);
            certStore.Open(OpenFlags.ReadOnly);

            foreach (var item in certStore.Certificates)
            {
                if (item.Subject.Equals("CN=" + cerSubject, StringComparison.InvariantCultureIgnoreCase))
                {
                    cert = item;
                    break;
                }
            }

            certStore.Close();

            return cert;
        }


    }

}
