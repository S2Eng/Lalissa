using System;
using System.Collections.Generic;
using System.Linq;

namespace PMDS.GUI.Print
{
    public static class cELGADB
    {

        public enum eOrganistionRolle
        {
            Klinik = 0,
            Empfänger = 1,
            Hausarzt = 2,
            Arzt = 3,
            Krankenkasse = 4,
            Null = 99
        }

        public enum ePersonRolle
        {
            Klient = 0,
            Sachwalter = 1,
            Kontaktperson = 2,
            Benutzer = 3
        }

        public enum eValid
        {
            yes = 1,
            no = 0
        }

        public class cParameters
        {
            public Guid IDAufenthalt;
            public Guid IDEmpfänger;
            public Guid IDUser;
            public DateTime dNow;
        }

        public class Adresse
        {
            public Guid ID;
            public string Strasse;
            public string PLZ;
            public string Ort;
            public string Land;
        }

        public class Kontakt
        {
            public Guid ID;
            public string Telefon;
            public string TelefonMobil;
            public string eMail;
        }

        public class Arztdaten
        {
            public string Titel;
            public string Vorname;
            public string Nachname;
            public string Fachrichtung;
            public string ELGA_AuthorSpeciality;
            public string ELGA_OID;
            public string ELGA_OrganizationName;
            public string ELGA_OrganizationOID;
        }

        public class Versicherungsdaten
        {
            public string VersicherungsNr;
            public string KrankenKasse;
            public string SozVersStatus;
            public string SozVersMitversichertBei;
            public string SozVersLeerGrund;
        }

        public class Leitungsdaten
        {
            public string Titel;
            public string Vorname;
            public string Nachname;
        }

        public class Organistion
        {
            public eOrganistionRolle Rolle;
            public Guid ID;
            public string Bezeichnung;
            public string ELGA_AuthorSpeciality;
            public string ELGA_OID;
            public string ELGA_OrganizationName;
            public string ELGA_OrganizationOID;
            public Adresse Adresse = new Adresse();
            public Kontakt Kontakt = new Kontakt();
            public Arztdaten Arztdaten = new Arztdaten();
            public Leitungsdaten Leitungsdaten = new Leitungsdaten();
        }

        public class Kontaktdaten
        {
            public bool VerstaendigenJN;
            public string Kontaktart;
            public string Verwandtschaft;
        }

        public class Person
        {
            public ePersonRolle Rolle;
            public Guid ID;
            public bool WohnungAbgemeldetJN;
            public bool ELGAAbgemeldet;
            public string ELGALocalID;
            public bool ELGASOOJN;
            public string Titel;
            public string Vorname;
            public string Nachname;
            public string LedigerName;
            public string TitelPost;
            public string Konfession;
            public string Sexus;
            public DateTime Geburtsdatum;
            public string Geburtsort;
            public string lstSprachen;
            public string bPK;
            public string Familienstand;
            public Adresse Adresse = new Adresse();
            public Kontakt Kontakt = new Kontakt();
            public Kontaktdaten Kontaktdaten = new Kontaktdaten();
            public Versicherungsdaten Versicherungsdaten = new Versicherungsdaten();
        }

        public class Aufenthalt
        {
            public Guid ID;
            public DateTime Aufnahmezeitpunkt;
            public string Abteilung;
        }

        public class PDX
        {
            public string Klartext;
            public string Lokalisierung;
            public string LokalisierungSeite;
            public bool WundeJN;
            public DateTime Startdatum;
            public string Code;
            public Guid ID;
        }

        public class RessourceRisiko
        {
            public string Klartext;
            public bool WundeJN;
            public Guid ID;
            public string Eintraggruppe;
            public int Gruppe;
            public string Text;
            public string Code;
        }

        public class Vitalparameter
        {
            public Guid ID;
            public string Bezeichnung;
            public string Wert;
            public int Zahlenwert;
            public float ZahlenwertFloat;
            public int Typ;
            public string ELGA_Unit;
            public string ELGA_Code;
            public string ELGA_DisplayName;
            public string ELGA_CodeSystem;
            public DateTime Zeitpunkt;
            public float MinValue;
            public string ZEID;
        }

        public class MedizinischeDaten
        {
            public DateTime Von;
            public DateTime Bis;
            public string Beschreibung;
            public string Bemerkung;
            public string Typ;
            public string Groesse;
            public string Modell;
            public DateTime LetzteVersorgung;
            public DateTime NaechsteVersorgung;
            public bool AntikoaguliertJN;
            public string MTBeschreibung;
        }

        public class Rezept
        {
            public string Bezeichnung;
            public string DosierungASString;
            public string Einheit;
            public string Applikationsform;
            public DateTime AbzugebenVon;
            public DateTime AbzugebenBis;
            public string Bemerkung;
            public bool BedarfsMedikationJN;
            public string Nachname;
            public string Vorname;
            public string Titel;
            public DateTime DatumErstellt;
        }

        public class Patientenverfügung
        {
            public string Nachname;
            public string Vorname;
            public bool PatientenverfuegungJN;
            public DateTime PatientverfuegungDatum;
            public bool PatientenverfuegungBeachtlichJN;
            public string PatientverfuegungAnmerkung;
            public string Konfession;
        }

        public class Pflegestufe
        {
            public string Nachname;
            public string Vorname;
            public string Bezeichnung;
            public DateTime GenehmigungDatum;
            public eValid eValid = eValid.no;
        }

        public class Rezeptgebührenbefreiung
        {
            public Guid ID;
            public bool Datenschutz;
            public bool DNR;
            public bool Palliativ;
            public bool KZUeberlebender;

            public bool RezeptgebuehrbefreiungJN;
            public bool RezGebBef_RegoJN;
            public DateTime RezGebBef_RegoAb;
            public DateTime RezGebBef_RegoBis;
            public bool RezGebBef_UnbefristetJN;
            public bool RezGebBef_BefristetJN;
            public DateTime RezGebBef_BefristetAb;
            public DateTime RezGebBef_BefristetBis;
            public bool RezGebBef_WiderrufJN;
            public string RezGebBef_WiderrufGrund;
            public bool RezGebBef_SachwalterJN;
            public string RezGebBef_Anmerkung;

            public DateTime Geburtsdatum;
        }

        public class Freiheitsbeschränkung
        {

            public string Aktion;
            public DateTime Beginn;
            public bool KlientZustimmungJN;

            public bool PsychischekrankheitJN;
            public bool GeistigeBehinderungJN;
            public string MedizinischeDiagnose;
            public bool ErheblicheSelbstgefaehrdungJN;
            public bool ErheblicheFremdgefaehrdungJN;
            public string AnmerkungVerhalten_2016;
            public string AnmerkungGutachten_2016;

            public bool EinzelfallmedikationJN_2016;
            public string Einzelfallmedikation_2016;
            public bool DauermedikationJN_2016;
            public string Dauermedikation_2016;

            public bool HindernVerlassenBettSeitenteilenJN;
            public bool HindernVerlassenBettBauchgurtJN_2016;
            public bool HindernVerlassenBettElektronischJN_2016;
            public int HindernVerlassenBettHandArmgurte_2016;
            public int HindernVerlassenBettFussBeingurte_2016;
            public bool HindernVerlassenBettAndereJN_2016;
            public string HindernBettVerlassen;

            public bool HindernSitzgelSitzhoseJN;
            public bool HindernSitzgelBauchgurtJN_2016;
            public bool HindernSitzgelBrustgurtJN_2016;
            public bool HindernSitzgelTischJN;
            public bool HindernSitzgelTherapietischJN;
            public int HindernSitzgelHandArmgurte_2016;
            public int HindernSitzgelFussBeingurte_2016;
            public bool HindernSitzgelAndereJN_2016;
            public string HindernSitzgelegenheit;

            public bool ZurueckhaltensandrohungJN;
            public bool HindernBereichFesthaltenJN_2016;
            public bool HindernBereichVersperrterBereichJN_2016;
            public bool HindernBereichBarriereJN_2016;
            public bool ElektronischesUeberwachungJN;
            public bool HindernBereichVersperrtesZimmerJN_2016;
            public bool HindernBereichHinderAmFortbewegenJN_2016;
            public bool HindernBereichAndereJN_2016;
            public string BaulicheMassnahmen;
        }

        public class Beilage
        {
            public string Bezeichnung;
            public string Archivordner;
            public string DateinameArchiv;
            public Guid refObject;
            public string DateinameOrig;
            public string Notiz;
        }

        public static void LoadKlinik(ref Organistion Klinik, cParameters p)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var rKlinik = (from auf in db.Aufenthalt
                                   join abt in db.Abteilung on auf.IDAbteilung equals abt.ID
                                   join kli in db.Klinik on abt.IDKlinik equals kli.ID
                                   join adr in db.Adresse on kli.IDAdresse equals adr.ID
                                   join kon in db.Kontakt on kli.IDKontakt equals kon.ID
                                   where auf.ID == p.IDAufenthalt
                                   select new
                                   {
                                       IDKlinik = kli.ID,
                                       kli.Bezeichnung,
                                       kli.ELGA_AuthorSpeciality,
                                       kli.ELGA_OID,
                                       kli.ELGA_OrganizationName,
                                       kli.ELGA_OrganizationOID,
                                       adr.Strasse,
                                       adr.Plz,
                                       adr.Ort,
                                       adr.LandKZ,
                                       kon.Tel,
                                       kon.Mobil,
                                       kon.Email,
                                       kli.EinrichtungsleiterTitel,
                                       kli.EinrichtungsleiterVorname,
                                       kli.Einrichtungsleiter,
                                   }
                                   ).First();

                    Klinik.Rolle = eOrganistionRolle.Klinik;
                    Klinik.ID = (Guid)rKlinik.IDKlinik;
                    Klinik.Bezeichnung = rKlinik.Bezeichnung;
                    Klinik.ELGA_AuthorSpeciality = rKlinik.ELGA_AuthorSpeciality;
                    Klinik.ELGA_OID = rKlinik.ELGA_OID;
                    Klinik.ELGA_OrganizationName = rKlinik.ELGA_OrganizationName;
                    Klinik.ELGA_OrganizationOID = rKlinik.ELGA_OrganizationOID;
                    Klinik.Adresse.Strasse = rKlinik.Strasse;
                    Klinik.Adresse.PLZ = rKlinik.Plz;
                    Klinik.Adresse.Ort = rKlinik.Ort;
                    Klinik.Adresse.Land = rKlinik.LandKZ;
                    Klinik.Kontakt.Telefon = rKlinik.Tel;
                    Klinik.Kontakt.TelefonMobil = rKlinik.Mobil;
                    Klinik.Kontakt.eMail = rKlinik.Email;
                    Klinik.Leitungsdaten.Titel = rKlinik.EinrichtungsleiterTitel;
                    Klinik.Leitungsdaten.Vorname = rKlinik.EinrichtungsleiterVorname;
                    Klinik.Leitungsdaten.Nachname = rKlinik.Einrichtungsleiter;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.InitKlinik: " + ex.ToString());
            }
        }

        public static void LoadKlient(ref Person Klient, cParameters p)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var rKlient = (from auf in db.Aufenthalt
                                   join pat in db.Patient on auf.IDPatient equals pat.ID
                                   join adr in db.Adresse on pat.IDAdresse equals adr.ID
                                   join kon in db.Kontakt on pat.IDKontakt equals kon.ID
                                   where auf.ID == p.IDAufenthalt
                                   select new
                                   {
                                       IDKlient = pat.ID,
                                       pat.VersicherungsNr,
                                       pat.KrankenKasse,
                                       pat.SozVersStatus,
                                       pat.SozVersMitversichertBei,
                                       pat.SozVersLeerGrund,
                                       adr.Strasse,
                                       adr.Plz,
                                       adr.Ort,
                                       adr.LandKZ,
                                       pat.WohnungAbgemeldetJN,
                                       kon.Tel,
                                       kon.Mobil,
                                       kon.Email,
                                       pat.ELGAAbgemeldet,
                                       auf.ELGALocalID,
                                       auf.ELGASOOJN,
                                       pat.Titel,
                                       pat.Vorname,
                                       pat.Nachname,
                                       pat.LedigerName,
                                       pat.TitelPost,
                                       pat.Konfision,
                                       pat.Sexus,
                                       pat.Geburtsdatum,
                                       pat.Geburtsort,
                                       pat.lstSprachen,
                                       pat.bPK,
                                       pat.Familienstand
                                   }
                                  ).First();

                    Guid IDKlient = (Guid)rKlient.IDKlient;
                    Klient.Rolle = ePersonRolle.Klient;
                    Klient.ID = IDKlient;
                    Klient.Adresse.Strasse = rKlient.Strasse;
                    Klient.Adresse.PLZ = rKlient.Plz;
                    Klient.Adresse.Ort = rKlient.Ort;
                    Klient.Adresse.Land = rKlient.LandKZ;
                    Klient.WohnungAbgemeldetJN = (bool)rKlient.WohnungAbgemeldetJN;
                    Klient.Kontakt.Telefon = rKlient.Tel;
                    Klient.Kontakt.TelefonMobil = rKlient.Mobil;
                    Klient.Kontakt.eMail = rKlient.Email;

                    Klient.ELGAAbgemeldet = rKlient.ELGAAbgemeldet ?? false;
                    Klient.ELGALocalID = rKlient.ELGALocalID;
                    Klient.ELGASOOJN = rKlient.ELGASOOJN;
                    Klient.Titel = rKlient.Titel;
                    Klient.Vorname = rKlient.Vorname;
                    Klient.Nachname = rKlient.Nachname;
                    Klient.LedigerName = rKlient.LedigerName;
                    Klient.TitelPost = rKlient.TitelPost;
                    Klient.Konfession = rKlient.Konfision;
                    Klient.Sexus = rKlient.Sexus;
                    Klient.Geburtsdatum = (DateTime)rKlient.Geburtsdatum;
                    Klient.Geburtsort = rKlient.Geburtsort;
                    Klient.lstSprachen = rKlient.lstSprachen;
                    Klient.bPK = rKlient.bPK;
                    Klient.Familienstand = rKlient.Familienstand;
                    Klient.Versicherungsdaten.VersicherungsNr = rKlient.VersicherungsNr;
                    Klient.Versicherungsdaten.KrankenKasse = rKlient.KrankenKasse;
                    Klient.Versicherungsdaten.SozVersStatus = rKlient.SozVersStatus;
                    Klient.Versicherungsdaten.SozVersMitversichertBei = rKlient.SozVersMitversichertBei;
                    Klient.Versicherungsdaten.SozVersLeerGrund = rKlient.SozVersLeerGrund;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadKlient: " + ex.ToString());
            }
        }

        public static void LoadSachwalter(ref List<Person> lSachwalter, cParameters p)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var tSachwalter = (from sw in db.Sachwalter
                                   join adr in db.Adresse on sw.IDAdresse equals adr.ID
                                   join kon in db.Kontakt on sw.IDKontakt equals kon.ID
                                   join pat in db.Patient on sw.IDPatient equals pat.ID
                                   join auf in db.Aufenthalt on pat.ID equals auf.IDPatient
                                   where auf.ID == p.IDAufenthalt
                                   select new
                                   {
                                       IDSachwalter = sw.ID,
                                       adr.Strasse,
                                       adr.Plz,
                                       adr.Ort,
                                       adr.LandKZ,
                                       kon.Tel,
                                       kon.Mobil,
                                       kon.Email,
                                       sw.Titel,
                                       sw.Vorname,
                                       sw.Nachname
                                   }
                                  );

                    foreach (var rSachwalter in tSachwalter )
                    {
                        Person Sachwalter = new Person();
                        Guid IDSachwalter = (Guid)rSachwalter.IDSachwalter;
                        Sachwalter.Rolle = ePersonRolle.Sachwalter;
                        Sachwalter.ID = IDSachwalter;
                        Sachwalter.Adresse.Strasse = rSachwalter.Strasse;
                        Sachwalter.Adresse.PLZ = rSachwalter.Plz;
                        Sachwalter.Adresse.Ort = rSachwalter.Ort;
                        Sachwalter.Adresse.Land = rSachwalter.LandKZ;
                        Sachwalter.Kontakt.Telefon = rSachwalter.Tel;
                        Sachwalter.Kontakt.TelefonMobil = rSachwalter.Mobil;
                        Sachwalter.Kontakt.eMail = rSachwalter.Email;
                        Sachwalter.Titel = rSachwalter.Titel;
                        Sachwalter.Vorname = rSachwalter.Vorname;
                        Sachwalter.Nachname = rSachwalter.Nachname;
                        lSachwalter.Add(Sachwalter);
                    }                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadSachwalter: " + ex.ToString());
            }
        }

        public static void LoadBenutzer(ref Person Benutzer, cParameters p)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var rBenutzer = (from ben in db.Benutzer
                                       where ben.ID == p.IDUser
                                       select new
                                       {
                                           IDSachwalter = ben.ID,
                                           ben.Vorname,
                                           ben.Nachname
                                       }
                                  ).First();

                    Guid IDBenutzer = (Guid)rBenutzer.IDSachwalter;
                    Benutzer.Rolle = ePersonRolle.Benutzer;
                    Benutzer.ID = IDBenutzer;
                    Benutzer.Vorname = rBenutzer.Vorname;
                    Benutzer.Nachname = rBenutzer.Nachname;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadBenutzer: " + ex.ToString());
            }
        }

        public static void LoadAufenthalt(ref Aufenthalt Aufenthalt, cParameters p)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var rAufenthalt = (from auf in db.Aufenthalt
                                       join abt in db.Abteilung on auf.IDAbteilung equals abt.ID
                                     where auf.ID == p.IDAufenthalt
                                     select new
                                     {
                                         ID = auf.ID,
                                         auf.Aufnahmezeitpunkt,
                                         Abteilung = abt.Bezeichnung
                                     }
                                  ).First();

                    Guid IDAufenthalt = (Guid)rAufenthalt.ID;
                    DateTime AufnahmeZeit = (DateTime)rAufenthalt.Aufnahmezeitpunkt;
                    Aufenthalt.ID = IDAufenthalt;
                    Aufenthalt.Aufnahmezeitpunkt = AufnahmeZeit;
                    Aufenthalt.Abteilung = rAufenthalt.Abteilung.Trim();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadBenutzer: " + ex.ToString());
            }
        }

        public static void LoadEmfaenger(ref Organistion Empfaenger, cParameters p)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var rEmpfaenger = (from emp in db.Einrichtung
                                   join adr in db.Adresse on emp.IDAdresse equals adr.ID
                                   join kon in db.Kontakt on emp.IDKontakt equals kon.ID
                                   where emp.ID == p.IDEmpfänger
                                   select new
                                   {
                                       IDEmpfaenger = emp.ID,
                                       Bezeichnung = emp.Text,
                                       emp.ELGA_OID,
                                       emp.ELGA_OrganizationName,
                                       emp.ELGA_OrganizationOID,
                                       adr.Strasse,
                                       adr.Plz,
                                       adr.Ort,
                                       adr.LandKZ,
                                       kon.Tel,
                                       kon.Mobil,
                                       kon.Email,
                                   }
                                   ).First();

                    Empfaenger.Rolle = eOrganistionRolle.Empfänger;
                    Empfaenger.ID = (Guid)rEmpfaenger.IDEmpfaenger;
                    Empfaenger.Bezeichnung = rEmpfaenger.Bezeichnung;
                    Empfaenger.ELGA_OID = rEmpfaenger.ELGA_OID;
                    Empfaenger.ELGA_OrganizationName = rEmpfaenger.ELGA_OrganizationName;
                    Empfaenger.ELGA_OrganizationOID = rEmpfaenger.ELGA_OrganizationOID;
                    Empfaenger.Adresse.Strasse = rEmpfaenger.Strasse;
                    Empfaenger.Adresse.PLZ = rEmpfaenger.Plz;
                    Empfaenger.Adresse.Ort = rEmpfaenger.Ort;
                    Empfaenger.Adresse.Land = rEmpfaenger.LandKZ;
                    Empfaenger.Kontakt.Telefon = rEmpfaenger.Tel;
                    Empfaenger.Kontakt.TelefonMobil = rEmpfaenger.Mobil;
                    Empfaenger.Kontakt.eMail = rEmpfaenger.Email;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.InitKlinik: " + ex.ToString());
            }
        }

        public static void LoadKrankenkasse(ref Organistion Krankenkasse, cParameters p)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var rKrankenkasse = (from krk in db.Einrichtung
                                       join adr in db.Adresse on krk.IDAdresse equals adr.ID
                                       join kon in db.Kontakt on krk.IDKontakt equals kon.ID
                                       join pat in db.Patient on krk.Text equals pat.KrankenKasse
                                       join auf in db.Aufenthalt on pat.ID equals auf.IDPatient
                                       where auf.ID == p.IDAufenthalt
                                       select new
                                       {
                                           IDEmpfaenger = krk.ID,
                                           Bezeichnung = krk.Text,
                                           adr.Strasse,
                                           adr.Plz,
                                           adr.Ort,
                                           adr.LandKZ,
                                           kon.Tel,
                                           kon.Mobil,
                                           kon.Email,
                                       }
                                   ).FirstOrDefault();
                    if (rKrankenkasse != null)
                    {
                        Krankenkasse.Rolle = eOrganistionRolle.Krankenkasse;
                        Krankenkasse.ID = (Guid)rKrankenkasse.IDEmpfaenger;
                        Krankenkasse.Bezeichnung = rKrankenkasse.Bezeichnung;
                        Krankenkasse.Adresse.Strasse = rKrankenkasse.Strasse;
                        Krankenkasse.Adresse.PLZ = rKrankenkasse.Plz;
                        Krankenkasse.Adresse.Ort = rKrankenkasse.Ort;
                        Krankenkasse.Adresse.Land = rKrankenkasse.LandKZ;
                        Krankenkasse.Kontakt.Telefon = rKrankenkasse.Tel;
                        Krankenkasse.Kontakt.TelefonMobil = rKrankenkasse.Mobil;
                        Krankenkasse.Kontakt.eMail = rKrankenkasse.Email;
                    }
                    else
                    {
                        Krankenkasse.Rolle = eOrganistionRolle.Null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.InitKlinik: " + ex.ToString());
            }
        }

        public static void LoadHausarzt(ref Organistion Arzt, cParameters p)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var rArzt = (from arzt in db.Aerzte
                                 join adr in db.Adresse on arzt.IDAdresse equals adr.ID
                                 join kon in db.Kontakt on arzt.IDKontakt equals kon.ID
                                 join ap in db.PatientAerzte on arzt.ID equals ap.IDAerzte
                                 join pat in db.Patient on ap.IDPatient equals pat.ID
                                 join auf in db.Aufenthalt on pat.ID equals auf.IDPatient
                                 where auf.ID == p.IDAufenthalt &&
                                    (ap.Von == null || ap.Von <= p.dNow) &&
                                    (ap.Bis == null || ap.Bis >= p.dNow) &&
                                    ap.ELGA_HausarztJN == true 
                                 select new
                                 {
                                     ID = arzt.ID,
                                     Titel = arzt.Titel,
                                     Vorname = arzt.Vorname,
                                     Nachname = arzt.Nachname,
                                     Fachrichtung = arzt.Fachrichtung,
                                     ELGA_OID = arzt.ELGA_OID,
                                     ELGA_OrganizationName = arzt.ELGA_OrganizationName,
                                     ELGA_OrganizationOID = arzt.ELGA_OrganizationOID,
                                     Plz = adr.Plz,
                                     Ort = adr.Ort,
                                     Strasse = adr.Strasse,
                                     LandKZ = adr.LandKZ,
                                     Tel = kon.Tel,
                                     Mobil = kon.Mobil,
                                     eMail = kon.Email,
                                  }
                                   ).FirstOrDefault();

                    if (rArzt != null)
                    {
                        Arzt.Rolle = eOrganistionRolle.Arzt;
                        Arzt.ID = (Guid)rArzt.ID;
                        Arzt.Arztdaten.Titel = rArzt.Titel;
                        Arzt.Arztdaten.Vorname = rArzt.Vorname;
                        Arzt.Arztdaten.Nachname = rArzt.Nachname;
                        Arzt.Arztdaten.Fachrichtung = rArzt.Fachrichtung;
                        Arzt.Arztdaten.ELGA_OID = rArzt.ELGA_OID;
                        Arzt.Arztdaten.ELGA_OrganizationName = rArzt.ELGA_OrganizationName;
                        Arzt.Arztdaten.ELGA_OrganizationOID = rArzt.ELGA_OrganizationOID;
                        Arzt.Adresse.Strasse = rArzt.Strasse;
                        Arzt.Adresse.PLZ = rArzt.Plz;
                        Arzt.Adresse.Ort = rArzt.Ort;
                        Arzt.Adresse.Land = rArzt.LandKZ;
                        Arzt.Kontakt.Telefon = rArzt.Tel;
                        Arzt.Kontakt.TelefonMobil = rArzt.Mobil;
                        Arzt.Kontakt.eMail = rArzt.eMail;
                    }
                    else
                        Arzt.Rolle = eOrganistionRolle.Null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.InitKlinik: " + ex.ToString());
            }
        }

        public static void LoadKontaktpersonen(ref List<Person> Kontaktpersonen, cParameters p)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var tKontaktersonen = (from kp in db.Kontaktperson
                                   join pat in db.Patient on kp.IDPatient equals pat.ID
                                   join adr in db.Adresse on kp.IDAdresse equals adr.ID
                                   join kon in db.Kontakt on kp.IDKontakt equals kon.ID
                                   join auf in db.Aufenthalt on pat.ID equals auf.IDPatient
                                   where auf.ID == p.IDAufenthalt
                                   select new
                                   {
                                       ID = kp.ID,
                                       adr.Strasse,
                                       adr.Plz,
                                       adr.Ort,
                                       adr.LandKZ,
                                       kon.Tel,
                                       kon.Mobil,
                                       kon.Email,
                                       kp.Titel,
                                       kp.Vorname,
                                       kp.Nachname,
                                       kp.VerstaendigenJN,
                                       kp.Verwandtschaft,
                                       kp.Kontaktart
                                   }
                                  );

                    foreach (var rKontaktperson in tKontaktersonen)
                    {
                        Person Kontaktperson = new Person();
                        Guid ID = (Guid)rKontaktperson.ID;
                        Kontaktperson.Rolle = ePersonRolle.Kontaktperson;
                        Kontaktperson.ID = ID;
                        Kontaktperson.Adresse.Strasse = rKontaktperson.Strasse;
                        Kontaktperson.Adresse.PLZ = rKontaktperson.Plz;
                        Kontaktperson.Adresse.Ort = rKontaktperson.Ort;
                        Kontaktperson.Adresse.Land = rKontaktperson.LandKZ;
                        Kontaktperson.Kontakt.Telefon = rKontaktperson.Tel;
                        Kontaktperson.Kontakt.TelefonMobil = rKontaktperson.Mobil;
                        Kontaktperson.Kontakt.eMail = rKontaktperson.Email;
                        Kontaktperson.Titel = rKontaktperson.Titel;
                        Kontaktperson.Vorname = rKontaktperson.Vorname;
                        Kontaktperson.Nachname = rKontaktperson.Nachname;
                        Kontaktperson.Kontaktdaten.Kontaktart = rKontaktperson.Kontaktart;
                        Kontaktperson.Kontaktdaten.VerstaendigenJN = rKontaktperson.VerstaendigenJN ?? false;
                        Kontaktperson.Kontaktdaten.Verwandtschaft = rKontaktperson.Verwandtschaft;
                        Kontaktpersonen.Add(Kontaktperson);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadKlient: " + ex.ToString());
            }
        }

        public static void LoadPDX(ref List<PDX> lPDX, cParameters p)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var tPDx = (from apdx in db.AufenthaltPDx
                                join pdx in db.PDX on apdx.IDPDX equals pdx.ID
                                where apdx.IDAufenthalt == p.IDAufenthalt && (apdx.EndeDatum == null || apdx.ErledigtJN == false)
                                orderby apdx.wundejn, pdx.Klartext
                                select new
                                {
                                    Klartext = pdx.Klartext,
                                    Lokalisierung = apdx.Lokalisierung,
                                    LokalisierungSeite = apdx.LokalisierungSeite,
                                    WundeJN = apdx.wundejn,
                                    Startdatum = apdx.StartDatum,
                                    Code = pdx.Code,
                                    ID = apdx.ID
                                });

                    foreach (var rpdx in tPDx)
                    {
                        DateTime Start = (DateTime)rpdx.Startdatum;
                        Guid Id = (Guid)rpdx.ID;

                        PDX pdx = new PDX();
                        pdx.Klartext = rpdx.Klartext;
                        pdx.Lokalisierung = rpdx.Lokalisierung;
                        pdx.LokalisierungSeite = rpdx.LokalisierungSeite;
                        pdx.WundeJN = rpdx.WundeJN;
                        pdx.Startdatum = Start;
                        pdx.Code = rpdx.Code;
                        pdx.ID = Id;
                        lPDX.Add(pdx);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadPDX: " + ex.ToString());
            }
        }

        public static void LoadRessourcenRisiken(ref List<RessourceRisiko> lRessourcenRisiken, cParameters p)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    //Alle Ressourcen (Eintraggruppe = "R") und Risiken (Eintraggruppe = "A") aus Pflegeplan holen
                    var tR = (from apdx in db.AufenthaltPDx
                              join pdx in db.PDX on apdx.IDPDX equals pdx.ID
                              join PDxPM in db.PDXPflegemodelle on pdx.ID equals PDxPM.IDPDX
                              join PM in db.Pflegemodelle on PDxPM.IDPflegemodelle equals PM.ID
                              join PPPDx in db.PflegePlanPDx on apdx.ID equals PPPDx.IDAufenthaltPDx
                              join e in db.Eintrag on PPPDx.IDEintrag equals e.ID
                              join PP in db.PflegePlan on PPPDx.IDPflegePlan equals PP.ID

                              where apdx.IDAufenthalt == p.IDAufenthalt &&
                                    PM.Modell == "ELGA" &&
                                    apdx.EndeDatum == null &&
                                    PPPDx.ErledigtJN == false &&
                                    (e.EintragGruppe == "R" || (e.EintragGruppe == "A" && pdx.Gruppe == 1))

                              orderby e.EintragGruppe descending, PM.code, PP.Text

                              select new
                              {
                                  Klartext = pdx.Klartext,
                                  WundeJN = apdx.wundejn,
                                  ID = PPPDx.IDPflegePlan,
                                  Eintraggruppe = e.EintragGruppe,
                                  Gruppe = pdx.Gruppe,
                                  Text = PP.Text,
                                  Code = PM.code
                              });

                    foreach (var rr in tR)
                    {
                        Guid Id = (Guid)rr.ID;

                        RessourceRisiko r = new RessourceRisiko();
                        r.Klartext = rr.Klartext;
                        r.WundeJN = rr.WundeJN;
                        r.ID = Id;
                        r.Eintraggruppe = rr.Eintraggruppe;
                        r.Gruppe = (int)rr.Gruppe;
                        r.Text = rr.Text;
                        r.Code = rr.Code;
                        lRessourcenRisiken.Add(r);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadRessourcenRisiken: " + ex.ToString());
            }
        }

        public static void LoadVitalparameter(ref List<Vitalparameter> lVitalparameter, cParameters p)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    //Alle Ressourcen (Eintraggruppe = "R") und Risiken (Eintraggruppe = "A") aus Pflegeplan holen
                    var tZusatzwerte = (from pe in db.PflegeEintrag
                                        join zw in db.ZusatzWert on pe.ID equals zw.IDObjekt
                                        join zge in db.ZusatzGruppeEintrag on zw.IDZusatzGruppeEintrag equals zge.ID
                                        join ze in db.ZusatzEintrag on zge.IDZusatzEintrag equals ze.ID
                                        where zge.AktivJN == true && (ze.ELGA_ID > 0 || ze.ID == "ERF") && pe.IDAufenthalt == p.IDAufenthalt

                                        select new
                                        {
                                            ID = zw.ID,
                                            Bezeichnung = ze.Bezeichnung,
                                            Wert = zw.Wert,
                                            Zahlenwert = zw.ZahlenWert,
                                            ZahlenwertFloat = zw.ZahlenWertFloat,
                                            Typ = ze.Typ,
                                            ze.ELGA_Unit,
                                            ze.ELGA_Code,
                                            ze.ELGA_DisplayName,
                                            ze.ELGA_CodeSystem,
                                            Zeitpunkt = pe.Zeitpunkt,
                                            MinValue = ze.MinValue,
                                            ZEID = ze.ID
                                        }).GroupBy(ze => ze.ELGA_Code).Select(g => g.OrderByDescending(pe => pe.Zeitpunkt).FirstOrDefault());

                    foreach (var rzw in tZusatzwerte)
                    {
                        Vitalparameter rv = new Vitalparameter();
                        rv.ID = (Guid)rzw.ID;
                        rv.Bezeichnung = rzw.Bezeichnung;
                        rv.Wert = rzw.Wert;
                        rv.Zahlenwert = (int)rzw.Zahlenwert;
                        rv.ZahlenwertFloat = (float)rzw.ZahlenwertFloat;
                        rv.Typ = (int)rzw.Typ;
                        rv.ELGA_Unit = rzw.ELGA_Unit;
                        rv.ELGA_Code = rzw.ELGA_Code;
                        rv.ELGA_DisplayName = rzw.ELGA_DisplayName;
                        rv.ELGA_CodeSystem = rzw.ELGA_CodeSystem;
                        rv.Zeitpunkt = (DateTime)rzw.Zeitpunkt;
                        rv.MinValue = (float)rzw.MinValue;
                        rv.ZEID = rzw.ZEID;
                        lVitalparameter.Add(rv);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadVitalparameter: " + ex.ToString());
            }
        }

        public static void LoadMedizinischeDaten(ref List<MedizinischeDaten> lMedizinischeDaten, cParameters p)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var tMedDaten = (from md in db.MedizinischeDaten
                                     join par in db.Patient on md.IDPatient equals par.ID
                                     join a in db.Aufenthalt on par.ID equals a.IDPatient
                                     join mt in db.MedizinischeTypen on md.MedizinischerTyp equals mt.MedizinischerTyp
                                     where a.ID == p.IDAufenthalt
                                     && mt.MedizinischerTyp != 8 && mt.MedizinischerTyp != 15
                                     && md.Von <p.dNow
                                     && (md.Bis > p.dNow || md.Bis == null)
                                     orderby (mt.MedizinischerTyp)
                                     select new
                                     {
                                         md.Von,
                                         md.Bis,
                                         md.Beschreibung,
                                         md.Bemerkung,
                                         md.Typ,
                                         md.Groesse,
                                         md.Modell,
                                         md.LetzteVersorgung,
                                         md.NaechsteVersorgung,
                                         md.AntikoaguliertJN,
                                         MTBeschreibung = mt.Beschreibung
                                     });

                    foreach (var rmed in tMedDaten)
                    {
                        DateTime von = (DateTime)rmed.Von;
                        DateTime bis = new DateTime(1900, 1, 1);
                        if (rmed.Bis != null)
                            bis = (DateTime)rmed.Bis;

                        DateTime letzteVersorung = new DateTime(1900, 1, 1);
                        if (rmed.LetzteVersorgung != null)
                            letzteVersorung = (DateTime)rmed.LetzteVersorgung;

                        DateTime naechsteVersorgung = new DateTime(1900, 1, 1);
                        if (rmed.NaechsteVersorgung != null)
                            naechsteVersorgung = (DateTime)rmed.NaechsteVersorgung;

                        bool antikoaguliertjn = rmed.AntikoaguliertJN ?? false;

                        MedizinischeDaten md = new MedizinischeDaten
                        {
                            Von = von,
                            Bis = bis,
                            Beschreibung = rmed.Beschreibung,
                            Bemerkung = rmed.Bemerkung,
                            Typ = rmed.Typ,
                            Groesse = rmed.Groesse,
                            Modell = rmed.Modell,
                            LetzteVersorgung = letzteVersorung,
                            NaechsteVersorgung = naechsteVersorgung,
                            AntikoaguliertJN = antikoaguliertjn,
                            MTBeschreibung = rmed.MTBeschreibung
                        };
                        lMedizinischeDaten.Add(md);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadMedizinischeDaten: " + ex.ToString());
            }
        }

        public static void LoadRezepte(ref List<Rezept> lRezepte, cParameters p)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var tRezepte = (from re in db.RezeptEintrag
                                    join med in db.Medikament on re.IDMedikament equals med.ID
                                    join ar in db.Aerzte on re.IDAerzte equals ar.ID
                                    where re.IDAufenthalt == p.IDAufenthalt
                                        && re.AbzugebenVon < p.dNow
                                        && re.AbzugebenBis > p.dNow
                                    orderby re.BedarfsMedikationJN, med.Bezeichnung
                                    select new
                                    {
                                        med.Bezeichnung,
                                        re.DosierungASString,
                                        re.Einheit,
                                        re.Applikationsform,
                                        re.AbzugebenVon,
                                        re.AbzugebenBis,
                                        re.Bemerkung,
                                        re.BedarfsMedikationJN,
                                        ar.Nachname,
                                        ar.Vorname,
                                        ar.Titel,
                                        re.DatumErstellt
                                    });

                    foreach (var rr in tRezepte)
                    {
                        Rezept r = new Rezept
                        {
                            Bezeichnung = rr.Bezeichnung,
                            DosierungASString = rr.DosierungASString,
                            Einheit = rr.Einheit,
                            Applikationsform = rr.Applikationsform,
                            AbzugebenVon = (DateTime)rr.AbzugebenVon,
                            AbzugebenBis = (DateTime)rr.AbzugebenBis,
                            Bemerkung = rr.Bemerkung,
                            BedarfsMedikationJN = rr.BedarfsMedikationJN,
                            Nachname = rr.Nachname,
                            Vorname = rr.Vorname,
                            Titel = rr.Titel,
                            DatumErstellt = (DateTime)rr.DatumErstellt
                        };
                        lRezepte.Add(r);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadRezepte: " + ex.ToString());
            }
        }

        public static void LoadPatientenverfügung(ref Patientenverfügung PatVerf, cParameters p)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var rPatInfo = (from pat in db.Patient
                                    join a in db.Aufenthalt on pat.ID equals a.IDPatient
                                    where a.ID == p.IDAufenthalt
                                    select new
                                    {
                                        pat.Nachname,
                                        pat.Vorname,
                                        pat.PatientenverfuegungJN,
                                        pat.PatientverfuegungDatum,
                                        pat.PatientenverfuegungBeachtlichJN,
                                        pat.PatientverfuegungAnmerkung,
                                        Konfession = pat.Konfision
                                    }).FirstOrDefault();


                    PatVerf.Nachname = rPatInfo.Nachname;
                    PatVerf.Vorname = rPatInfo.Vorname;
                    PatVerf.PatientenverfuegungJN = rPatInfo.PatientenverfuegungJN ?? false;
                    if (rPatInfo.PatientverfuegungDatum != null)
                        PatVerf.PatientverfuegungDatum = (DateTime)rPatInfo.PatientverfuegungDatum;
                    PatVerf.PatientenverfuegungBeachtlichJN = rPatInfo.PatientenverfuegungBeachtlichJN ?? false;
                    PatVerf.PatientverfuegungAnmerkung = rPatInfo.PatientverfuegungAnmerkung;
                    PatVerf.Konfession = rPatInfo.Konfession;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadPatientenverfügung: " + ex.ToString());
            }
        }

        public static void LoadPflegestufe(ref Pflegestufe PflegStuf, cParameters p)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var rPatInfo = (from pat in db.Patient
                                    join a in db.Aufenthalt on pat.ID equals a.IDPatient
                                    join pps in db.PatientPflegestufe on pat.ID equals pps.IDPatient
                                    join ps in db.Pflegegeldstufe on pps.IDPflegegeldstufe equals ps.ID
                                    where a.ID == p.IDAufenthalt
                                    orderby pps.GenehmigungDatum descending
                                    select new
                                    {
                                        pat.Nachname,
                                        pat.Vorname,
                                        ps.Bezeichnung,
                                        pps.GenehmigungDatum
                                    }).FirstOrDefault();

                    if (rPatInfo != null)
                    {
                        PflegStuf.Nachname = rPatInfo.Nachname;
                        PflegStuf.Vorname = rPatInfo.Vorname;
                        PflegStuf.Bezeichnung = rPatInfo.Bezeichnung;
                        if (rPatInfo.GenehmigungDatum != null)
                            PflegStuf.GenehmigungDatum = (DateTime)rPatInfo.GenehmigungDatum;
                        PflegStuf.eValid = eValid.yes;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadPflegestufe: " + ex.ToString());
            }
        }

        public static void LoadFreiheitsbeschränkungen(ref List<Freiheitsbeschränkung> lFreiBesch, cParameters p)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var tHAG = (from u in db.Unterbringung
                                where u.IDAufenthalt == p.IDAufenthalt
                                orderby u.Beginn
                                select new
                                {
                                    u.Aktion,
                                    u.Beginn,

                                    u.KlientZustimmungJN,
                                    u.PsychischekrankheitJN,
                                    u.GeistigeBehinderungJN,
                                    u.MedizinischeDiagnose,
                                    u.ErheblicheSelbstgefaehrdungJN,
                                    u.ErheblicheFremdgefaehrdungJN,
                                    u.AnmerkungVerhalten_2016,
                                    u.AnmerkungGutachten_2016,

                                    u.EinzelfallmedikationJN_2016,
                                    u.Einzelfallmedikation_2016,
                                    u.DauermedikationJN_2016,
                                    u.Dauermedikation_2016,

                                    u.HindernVerlassenBettSeitenteilenJN,
                                    u.HindernVerlassenBettBauchgurtJN_2016,
                                    u.HindernVerlassenBettElektronischJN_2016,
                                    u.HindernVerlassenBettHandArmgurte_2016,
                                    u.HindernVerlassenBettFussBeingurte_2016,
                                    u.HindernVerlassenBettAndereJN_2016,
                                    u.HindernBettVerlassen,

                                    u.HindernSitzgelSitzhoseJN,
                                    u.HindernSitzgelBauchgurtJN_2016,
                                    u.HindernSitzgelBrustgurtJN_2016,
                                    u.HindernSitzgelTischJN,
                                    u.HindernSitzgelTherapietischJN,
                                    u.HindernSitzgelHandArmgurte_2016,
                                    u.HindernSitzgelFussBeingurte_2016,
                                    u.HindernSitzgelAndereJN_2016,
                                    u.HindernSitzgelegenheit,

                                    u.ZurueckhaltensandrohungJN,
                                    u.HindernBereichFesthaltenJN_2016,
                                    u.HindernBereichVersperrterBereichJN_2016,
                                    u.HindernBereichBarriereJN_2016,
                                    u.ElektronischesUeberwachungJN,
                                    u.HindernBereichVersperrtesZimmerJN_2016,
                                    u.HindernBereichHinderAmFortbewegenJN_2016,
                                    u.HindernBereichAndereJN_2016,
                                    u.BaulicheMassnahmen
                                });

                    foreach (var rHAG in tHAG)
                    {
                        Freiheitsbeschränkung frbesch = new Freiheitsbeschränkung();

                        frbesch.Aktion = rHAG.Aktion;
                        frbesch.Beginn = (DateTime)rHAG.Beginn;

                        frbesch.KlientZustimmungJN = rHAG.KlientZustimmungJN ?? false;
                        frbesch.PsychischekrankheitJN = rHAG.PsychischekrankheitJN ?? false;
                        frbesch.GeistigeBehinderungJN = rHAG.GeistigeBehinderungJN ?? false;
                        frbesch.MedizinischeDiagnose = rHAG.MedizinischeDiagnose;
                        frbesch.ErheblicheSelbstgefaehrdungJN = rHAG.ErheblicheSelbstgefaehrdungJN ?? false;
                        frbesch.ErheblicheFremdgefaehrdungJN = rHAG.ErheblicheFremdgefaehrdungJN ?? false;
                        frbesch.AnmerkungVerhalten_2016 = rHAG.AnmerkungVerhalten_2016 ?? "";
                        frbesch.AnmerkungGutachten_2016 = rHAG.AnmerkungGutachten_2016 ?? "";

                        frbesch.EinzelfallmedikationJN_2016 = rHAG.EinzelfallmedikationJN_2016 ?? false ;
                        frbesch.Einzelfallmedikation_2016 = rHAG.Einzelfallmedikation_2016 ?? "";
                        frbesch.DauermedikationJN_2016 = rHAG.DauermedikationJN_2016 ?? false;
                        frbesch.Dauermedikation_2016 = rHAG.Dauermedikation_2016 ?? "";

                        frbesch.HindernVerlassenBettSeitenteilenJN = rHAG.HindernVerlassenBettSeitenteilenJN ?? false;
                        frbesch.HindernVerlassenBettBauchgurtJN_2016 = rHAG.HindernVerlassenBettBauchgurtJN_2016 ?? false;
                        frbesch.HindernVerlassenBettElektronischJN_2016 = rHAG.HindernVerlassenBettElektronischJN_2016 ?? false;
                        frbesch.HindernVerlassenBettHandArmgurte_2016 = rHAG.HindernVerlassenBettHandArmgurte_2016 ?? 0;
                        frbesch.HindernVerlassenBettFussBeingurte_2016 = rHAG.HindernVerlassenBettFussBeingurte_2016 ?? 0;
                        frbesch.HindernVerlassenBettAndereJN_2016 = rHAG.HindernVerlassenBettAndereJN_2016 ?? false;
                        frbesch.HindernBettVerlassen = rHAG.HindernBettVerlassen ?? "";

                        frbesch.HindernSitzgelSitzhoseJN = rHAG.HindernSitzgelSitzhoseJN;
                        frbesch.HindernSitzgelBauchgurtJN_2016 = rHAG.HindernSitzgelBauchgurtJN_2016 ?? false;
                        frbesch.HindernSitzgelBrustgurtJN_2016 = rHAG.HindernSitzgelBrustgurtJN_2016 ?? false;
                        frbesch.HindernSitzgelTischJN = rHAG.HindernSitzgelTischJN ?? false;
                        frbesch.HindernSitzgelTherapietischJN = rHAG.HindernSitzgelTherapietischJN ?? false;
                        frbesch.HindernSitzgelHandArmgurte_2016 = rHAG.HindernSitzgelHandArmgurte_2016 ?? 0;
                        frbesch.HindernSitzgelFussBeingurte_2016 = rHAG.HindernSitzgelFussBeingurte_2016 ?? 0;
                        frbesch.HindernSitzgelAndereJN_2016 = rHAG.HindernSitzgelAndereJN_2016 ?? false;
                        frbesch.HindernSitzgelegenheit = rHAG.HindernSitzgelegenheit ?? "";

                        frbesch.ZurueckhaltensandrohungJN = rHAG.ZurueckhaltensandrohungJN ?? false;
                        frbesch.HindernBereichFesthaltenJN_2016 = rHAG.HindernBereichFesthaltenJN_2016 ?? false;
                        frbesch.HindernBereichVersperrterBereichJN_2016 = rHAG.HindernBereichVersperrterBereichJN_2016 ?? false;
                        frbesch.HindernBereichBarriereJN_2016 = rHAG.HindernBereichBarriereJN_2016 ?? false;
                        frbesch.ElektronischesUeberwachungJN = rHAG.ElektronischesUeberwachungJN ?? false;
                        frbesch.HindernBereichVersperrtesZimmerJN_2016 = rHAG.HindernBereichVersperrtesZimmerJN_2016 ?? false;
                        frbesch.HindernBereichHinderAmFortbewegenJN_2016 = rHAG.HindernBereichHinderAmFortbewegenJN_2016 ?? false;
                        frbesch.HindernBereichAndereJN_2016 = rHAG.HindernBereichAndereJN_2016 ?? false;
                        frbesch.BaulicheMassnahmen = rHAG.BaulicheMassnahmen ?? "";

                        lFreiBesch.Add(frbesch);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadFreiheitsbeschränkungen: " + ex.ToString());
            }
        }

        public static void LoadRezeptgebührenbefreiung(ref Rezeptgebührenbefreiung RezGeb, cParameters p)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    //Rezeptgebührenbefreiung
                    var rPatMedDaten = (from pat in db.Patient
                                        join a in db.Aufenthalt on pat.ID equals a.IDPatient
                                        where a.ID == p.IDAufenthalt
                                        select new
                                        {
                                            pat.ID,
                                            pat.Datenschutz,
                                            pat.DNR,
                                            pat.Palliativ,
                                            pat.KZUeberlebender,

                                            pat.RezeptgebuehrbefreiungJN,
                                            pat.RezGebBef_RegoJN,
                                            pat.RezGebBef_RegoAb,
                                            pat.RezGebBef_RegoBis,
                                            pat.RezGebBef_UnbefristetJN,
                                            pat.RezGebBef_BefristetJN,
                                            pat.RezGebBef_BefristetAb,
                                            pat.RezGebBef_BefristetBis,
                                            pat.RezGebBef_WiderrufJN,
                                            pat.RezGebBef_WiderrufGrund,
                                            pat.RezGebBef_SachwalterJN,
                                            pat.RezGebBef_Anmerkung,

                                            pat.Geburtsdatum
                                        }).First();

                    RezGeb.ID = (Guid)rPatMedDaten.ID;
                    RezGeb.Datenschutz = rPatMedDaten.Datenschutz;
                    RezGeb.DNR = rPatMedDaten.DNR;
                    RezGeb.Palliativ = rPatMedDaten.Palliativ;
                    RezGeb.KZUeberlebender = rPatMedDaten.KZUeberlebender;

                    RezGeb.RezeptgebuehrbefreiungJN = rPatMedDaten.RezeptgebuehrbefreiungJN;
                    RezGeb.RezGebBef_RegoJN = rPatMedDaten.RezGebBef_RegoJN;
                    if (rPatMedDaten.RezGebBef_RegoAb != null)
                        RezGeb.RezGebBef_RegoAb = (DateTime)rPatMedDaten.RezGebBef_RegoAb;
                    if (rPatMedDaten.RezGebBef_RegoBis != null)
                        RezGeb.RezGebBef_RegoBis = (DateTime)rPatMedDaten.RezGebBef_RegoBis;
                    RezGeb.RezGebBef_UnbefristetJN = rPatMedDaten.RezGebBef_UnbefristetJN;
                    RezGeb.RezGebBef_BefristetJN = rPatMedDaten.RezGebBef_BefristetJN;
                    if (rPatMedDaten.RezGebBef_RegoAb != null)
                        RezGeb.RezGebBef_BefristetAb = (DateTime)rPatMedDaten.RezGebBef_BefristetAb;
                    if (rPatMedDaten.RezGebBef_RegoBis != null)
                        RezGeb.RezGebBef_BefristetBis = (DateTime)rPatMedDaten.RezGebBef_BefristetBis;
                    RezGeb.RezGebBef_WiderrufJN = rPatMedDaten.RezGebBef_WiderrufJN;
                    RezGeb.RezGebBef_WiderrufGrund = rPatMedDaten.RezGebBef_WiderrufGrund;
                    RezGeb.RezGebBef_SachwalterJN = rPatMedDaten.RezGebBef_SachwalterJN;
                    RezGeb.RezGebBef_Anmerkung = rPatMedDaten.RezGebBef_Anmerkung;

                    RezGeb.Geburtsdatum = (DateTime)rPatMedDaten.Geburtsdatum;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadRezeptgebührenbefreiung: " + ex.ToString());
            }
        }

        public static void LoadBeilagen(ref List<Beilage> lBeilagen, cParameters p)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var tBeilagen = (from dokein in db.tblDokumenteintrag
                                     join dok in db.tblDokumente on dokein.ID equals dok.IDDokumenteintrag
                                     join ordner in db.tblOrdner on dokein.IDOrdner equals ordner.ID
                                     join obj in db.tblObjekt on dokein.ID equals obj.IDDokumenteintrag
                                     join pat in db.Patient on obj.ID_guid equals pat.ID
                                     join auf in db.Aufenthalt on pat.ID equals auf.IDPatient

                                     where auf.ID == p.IDAufenthalt && ordner.Bezeichnung == "ELGAPflegesituationsbericht" && dok.DateinameTyp == ".pdf"
                                     && (dokein.GültigVon == null || dokein.GültigVon <= p.dNow)
                                     && (dokein.GültigBis == null || dokein.GültigBis >= p.dNow)

                                     select new
                                     {
                                         dokein.Bezeichnung,
                                         dok.Archivordner,
                                         dok.DateinameArchiv,
                                         refObject = dok.ID,
                                         dok.DateinameOrig,
                                         dokein.Notiz
                                     });

                    foreach (var rBeilage in tBeilagen)
                    {
                        Beilage rBeil = new Beilage();
                        rBeil.Bezeichnung = rBeilage.Bezeichnung;
                        rBeil.Archivordner = rBeilage.Archivordner;
                        rBeil.DateinameArchiv = rBeilage.DateinameArchiv;
                        rBeil.refObject = (Guid)rBeilage.refObject;
                        rBeil.DateinameOrig = rBeilage.DateinameOrig;
                        rBeil.Notiz = rBeilage.Notiz;

                        lBeilagen.Add(rBeil);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadBeilagen: " + ex.ToString());
            }
        }

    }
}


