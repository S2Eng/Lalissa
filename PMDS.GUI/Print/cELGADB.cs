using MARC.Everest.RMIM.UV.NE2010.COCT_MT840000UV09;
using PMDS.BusinessLogic;
using PMDS.Global;
using qs2.core.vb.QS2Service1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Null = 99
        }

        public enum ePersonRolle
        {
            Klient = 0,
            Sachwalter = 1,
            Kontaktperson = 2,
            Benutzer = 3
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
            public string VersicherungsNr;
            public string KrankenKasse;
            public string SozVersStatus;
            public string SozVersMitversichertBei;
            public string SozVersLeerGrund;
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
        }

        public class Aufenthalt
        {
            public Guid ID;
            public DateTime Aufnahmezeitpunkt;
            public string Abteilung;
        }

        public static void LoadKlinik(ref Organistion Klinik)
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
                                   where auf.ID == ENV.IDAUFENTHALT
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
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.InitKlinik: " + ex.ToString());
            }
        }

        public static void LoadKlient(ref Person Klient)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var rKlient = (from auf in db.Aufenthalt
                                   join pat in db.Patient on auf.IDPatient equals pat.ID
                                   join adr in db.Adresse on pat.IDAdresse equals adr.ID
                                   join kon in db.Kontakt on pat.IDKontakt equals kon.ID
                                   where auf.ID == ENV.IDAUFENTHALT
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
                    Klient.VersicherungsNr = rKlient.VersicherungsNr;
                    Klient.KrankenKasse = rKlient.KrankenKasse;
                    Klient.SozVersStatus = rKlient.SozVersStatus;
                    Klient.SozVersMitversichertBei = rKlient.SozVersMitversichertBei;
                    Klient.SozVersLeerGrund = rKlient.SozVersLeerGrund;
                    Klient.Adresse.Strasse = rKlient.Strasse;
                    Klient.Adresse.PLZ = rKlient.Plz;
                    Klient.Adresse.Ort = rKlient.Ort;
                    Klient.Adresse.Land = rKlient.LandKZ;
                    Klient.WohnungAbgemeldetJN = (bool)rKlient.WohnungAbgemeldetJN;
                    Klient.Kontakt.Telefon = rKlient.Tel;
                    Klient.Kontakt.TelefonMobil = rKlient.Mobil;
                    Klient.Kontakt.eMail = rKlient.Email;
                    Klient.ELGAAbgemeldet = (bool)rKlient.ELGAAbgemeldet;
                    Klient.ELGALocalID = rKlient.ELGALocalID;
                    Klient.ELGASOOJN = (bool)rKlient.ELGASOOJN;
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
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadKlient: " + ex.ToString());
            }
        }

        public static void LoadSachwalter(ref List<Person> lSachwalter)
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
                                   where auf.ID == ENV.IDAUFENTHALT
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

        public static void LoadBenutzer(ref Person Benutzer)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var rBenutzer = (from ben in db.Benutzer
                                       where ben.ID == ENV.USERID
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

        public static void LoadAufenthalt(ref Aufenthalt Aufenthalt)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var rAufenthalt = (from auf in db.Aufenthalt
                                       join abt in db.Abteilung on auf.IDAbteilung equals abt.ID
                                     where auf.ID == ENV.IDAUFENTHALT
                                     select new
                                     {
                                         ID = auf.ID,
                                         auf.Aufnahmezeitpunkt,
                                         Abteilung = abt.Bezeichnung
                                     }
                                  ).First();

                    Guid IDAufenthalt = (Guid)rAufenthalt.ID;
                    DateTime AufnahmeZeit = (DateTime)rAufenthalt.Aufnahmezeitpunkt;
                    Aufenthalt.Aufnahmezeitpunkt = AufnahmeZeit;
                    Aufenthalt.Abteilung = rAufenthalt.Abteilung.Trim();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadBenutzer: " + ex.ToString());
            }
        }

        public static void LoadEmfaenger(ref Organistion Empfaenger)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var rEmpfaenger = (from emp in db.Einrichtung
                                   join adr in db.Adresse on emp.IDAdresse equals adr.ID
                                   join kon in db.Kontakt on emp.IDKontakt equals kon.ID
                                   where emp.IstKrankenkasse == false
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

        public static void LoadHausarzt(ref Organistion Arzt)
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
                                 join auf in db.Aufenthalt on pat.ID equals auf.ID
                                 where auf.ID == ENV.IDAUFENTHALT && arzt.ELGAHausarzt == true
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

        public static void LoadKontaktpersonen(ref List<Person> Kontaktpersonen)
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
                                   where auf.ID == ENV.IDAUFENTHALT
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
                        Kontaktperson.Kontaktdaten.VerstaendigenJN = (bool)rKontaktperson.VerstaendigenJN;
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


    }


}
