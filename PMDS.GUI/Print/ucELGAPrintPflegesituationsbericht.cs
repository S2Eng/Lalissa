using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using qs2.core.vb;
using PMDS.Global;
using Infragistics.Win.UltraWinGrid;
using PMDS.Klient;
using Patagames.Pdf.Enums;
using System.Reflection;
using System.Xml;
using System.IO;
using PMDS.db.Entities;
using Infragistics.Win.UltraWinListView;   

using MARC.Everest.DataTypes.Interfaces;
using MARC.Everest.RMIM.UV.CDAr2.POCD_MT000040UV;
using MARC.Everest.RMIM.UV.CDAr2.Vocabulary;
using MARC.Everest.Xml;
using MARC.Everest.DataTypes;
using PMDS.DynReportsForms;
using PMDS.BusinessLogic;
//using MARC.Everest.RMIM.UV.NE2010.REPC_MT000324UV01;


namespace PMDS.GUI.Print
{
    public partial class ucELGAPrintPflegesituationsbericht : UserControl
    {
        private System.Globalization.CultureInfo currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
        private Guid IDEmpfaenger { get; set; }
        private List<ccode> ELGACodes = new List<ccode>();
        private cELGADB.Organistion Klinik = new cELGADB.Organistion();
        private cELGADB.Person Klient = new cELGADB.Person();
        private cELGADB.Aufenthalt Aufenthalt = new cELGADB.Aufenthalt();
        private List<Sektion> Sektionen = new List<Sektion>();
        private List<cELGADB.Person> lSachwalter = new List<cELGADB.Person>();
        private cELGADB.Person Benutzer = new cELGADB.Person();
        private cELGADB.Organistion Empfaenger = new cELGADB.Organistion();
        private cELGADB.Organistion Hausarzt = new cELGADB.Organistion();
        private List<cELGADB.Person> Kontaktpersonen = new List<cELGADB.Person>();

        private enum eELGATypeSektion
        {
            Brieftext = 1,
            Pflegediagnosen = 2,
            FachlicheSektion = 3,
            Vitalparameter = 4,
            Enlassungsmanagement = 5,
            Patientenverfügung = 6,
            AbschliessendeBemerkung = 7,
            Beilagen = 8
        }

        private enum SektionOrder
        {
            Brieftext = 0,
            Pflegediagnosen = 1,
            Mobilität = 2,
            KörperpflegeUndKleiden = 3,
            Ernährung = 4,
            Ausscheidung = 5,
            Hautzustand = 6,
            Atmung = 7,
            Schlaf = 8,
            Schmerz = 9,
            OrientierungUndBewusstseinslage = 10,
            SozialeUmständeUndVerhalten = 11,
            Kommunikation = 12,
            RollenwahnehmungUndSinnfindung = 13,
            Vitalparameter = 14,
            PflegerelvanteInforamtionenZurMedizinischenBehandlung = 15,
            Medikamentenverabreichung = 16,
            Anmerkungen = 17,
            PflegeUndBetreuungsumfang = 18,
            Entlassungsmanagment = 19,
            Patientenverfügung = 20,
            AbschliessendeBemerkungen = 21,
            Beilagen = 22
        }

        private enum RTFTyp
        {
            Text = 1,
            Res = 2,
            Risk = 3
        }

        private enum eTypeCDA
        {
            Entlassungsbrief = 0,
            Pflegesituationbericht = 1
        }

        private class RTFTag
        {
            public SektionOrder Order;
            public String Tag;
            public RTFTyp Typ;
        }

        private class cdaInfo
        {
            public SET<CS<BindingRealm>>  ccdaRealmCode = new SET<CS<BindingRealm>>(new CS<BindingRealm>(BindingRealm.Austria));
            public II ccdaTypeId = new II { Root = "2.16.840.1.113883.1.3", Extension = "POCD_HD000040" };
            public II cdaID = new II(Guid.NewGuid());
            public II cdaSetID = new II(Guid.NewGuid());
            public int cdaVersion = 1;
            public ST cdaTitle = new ST("Pflegesituationsbericht");
            public ccode cdaCode = new ccode { code = "28651-8", displayName = "Nurse Transfer Note", codeSystem = "2.16.840.1.113883.6.1", codeSystemName = "LOINC" };
            public List<II> cdatemplateIDs = new List<II> { new II { Root="1.2.40.0.34.11.1" , AssigningAuthorityName = "ELGA" },
                                                            new II { Root="1.2.40.0.34.11.12", AssigningAuthorityName="ELGA" },
                                                            new II { Root="1.2.40.0.34.11.12.0.3", AssigningAuthorityName="ELGA" }
                                                          };
            public TS cdaEffectiveTime = new TS(DateTime.Now);
            public CE<x_BasicConfidentialityKind>  ccdaConfidentialityCode = new CE<x_BasicConfidentialityKind>(x_BasicConfidentialityKind.Normal, "2.16.840.1.113883.5.25", "HL7:Confidentiality", null);
            public string ccdaConfidentialityCodeDisplayName = "normal";
            public CS<string> ccdaLanguageCode = new CS<string>("de-AT");
        }

        private class ccode
        {
            public string code;
            public string displayName;
            public string codeSystem = "1.2.40.0.34.5.40";
            public string codeSystemName = "ELGA";
            public string originalText;
            public string IDAuswahllisteGruppe;
            public string Bezeichnung;
        }

        private class PflegediagnosenObservation
        {
            public List<II> cdatemplateIDs = new List<II> { new II { Root = "1.2.40.0.34.11.1.3.6", AssigningAuthorityName = "ELGA" },
                                                            new II { Root="1.3.6.1.4.1.19376.1.5.3.1.4.5", AssigningAuthorityName="IHE PCC" },
                                                            new II { Root="2.16.840.1.113883.10.20.1.28", AssigningAuthorityName="HL7 CCD" },
                                                          };

            public Guid id_root;
            public ccode code = new ccode { code = "282291009", displayName = "Diagnosis", codeSystem = "2.16.840.1.113883.6.96", codeSystemName = "SNOMED CT" };
            public string text_reference;
            public DateTime effectivTime_low_value;
            public string value_xsi_type = "CD";
            public string value_code;
            public string value_displayName;
            public string value_codeSystem = "1.2.40.0.34.3.1.2.99.8888";
            public string value_codeSystemName = "Internal";
            public string value_originalText_reference_value;
        }

        private class PflegediagnosenEntryRelationship
        {
            public string entryRelationship_inversionInd = "false";
            public string entryRelationship_typeCode = "SUBJ";
            public PflegediagnosenObservation observation = new PflegediagnosenObservation();
        }

        private class BeilagenEntry
        {
            public string id = "";
            public string referencedObject = "";
            public LIST<II> cdatemplateIDs = new LIST<II> { new II { Root = "1.2.40.0.34.11.1.3.1", AssigningAuthorityName = "ELGA" } };
            public string value_mediaType = "application/pdf";
            public EncapsulatedDataRepresentation value_representation = EncapsulatedDataRepresentation.B64;
            public byte[] value = null;
        }

        private class PflegediagnoseEntry
        {
            public LIST<II> cdatemplateIDs = new LIST<II> { new II { Root = "1.2.40.0.34.11.3.3.1", AssigningAuthorityName = "ELGA" },
                                                            new II { Root="1.2.40.0.34.11.1.3.5", AssigningAuthorityName = "ELGA" },
                                                            new II { Root="1.3.6.1.4.1.19376.1.5.3.1.4.5.1", AssigningAuthorityName="IHE PCC" },
                                                            new II { Root="1.3.6.1.4.1.19376.1.5.3.1.4.5.2", AssigningAuthorityName="IHE PCC" },
                                                            new II { Root="2.16.840.1.113883.10.20.1.27", AssigningAuthorityName="HL7 CCD" },
                                                          };
            public Guid id_root;
            public string code_nullFlavor = "NA";
            public string statusCode_code = "active";
            public DateTime effectiveTime_low_value;
            public PflegediagnosenEntryRelationship entryRelationship = new PflegediagnosenEntryRelationship();
        }

        //private class VitalparameterObservation
        //{
        //    public LIST<II> cdatemplateIDs = new LIST<II> { new II { Root = "1.2.40.0.34.11.1.3.4" , AssigningAuthorityName = "ELGA" },
        //                                                  new II { Root="1.3.6.1.4.1.19376.1.5.3.1.4.13", AssigningAuthorityName="IHE PCC" },
        //                                                  new II { Root="1.3.6.1.4.1.19376.1.5.3.1.4.13.2", AssigningAuthorityName="IHE PCC" },
        //                                                  new II { Root="2.16.840.1.113883.10.20.1.31", AssigningAuthorityName="HL7 CCD" }
        //                                                };
        //    public string id_root;
        //    public ccode code = new ccode();
        //    public string text_reference;
        //    public string statusCode_code = "completed";
        //    public string value_xsi_type = "PQ";
        //    public string value_code;
        //    public string value_unit;
        //}

        //private class VitalparameterEntry
        //{
        //    public LIST<II> cdatemplateIDs = new LIST<II> { new II { Root = "1.2.40.0.34.11.1.3.3", AssigningAuthorityName = "ELGA" },
        //                                                    new II { Root="1.3.6.1.4.1.19376.1.5.3.1.4.13.1", AssigningAuthorityName="IHE PCC" },
        //                                                    new II { Root="2.16.840.1.113883.10.20.1.32", AssigningAuthorityName="HL7 CCD" },
        //                                                    new II { Root="2.16.840.1.113883.10.20.1.35", AssigningAuthorityName="HL7 CCD" },
        //                                                  };
        //    public Guid root;
        //    public ccode code = new ccode { code = "46680005", codeSystem = "2.16.840.1.113883.6.96", codeSystemName = "SNOMED CT", displayName = "Vital signs" };
        //    public CS<ActStatus> statusCode_code = new CS<ActStatus>(ActStatus.Completed);
        //    public string effectiveTime;
        //    public List<VitalparameterObservation> observations = new List<VitalparameterObservation>();
        //}

        private class Risiko
        {
            public LIST<II> cdatemplateIDs = new LIST<II> { new II { Root = "1.2.40.0.34.11.1.2.8", AssigningAuthorityName = "ELGA" } };
            public string title = "Risiken";
            public ccode code = new ccode { code = "51898-5", displayName = "Risk factors", codeSystem = "LOINC", codeSystemName = "LOINC" };
            public string textHTML;
            public string list_listType = "unordered";
            public string list_styleCode = "Disc";
            public List<string> items;
        }

        private class HilfsmittelRessourcen
        {
            public LIST<II> cdatemplateIDs = new LIST<II> { new II { Root = "1.2.40.0.34.11.1.2.9", AssigningAuthorityName = "ELGA" } };
            public string title = "Hilfsmittel und Ressourcen";
            public ccode code = new ccode { code = "RES", displayName = "Hilfsmittel und Ressourcen", codeSystem = "1.2.40.0.34.5.40", codeSystemName = "ELGA_Sections" };
            public string textHTML;
        }

        private class Sektion
        {
            public int order;
            public bool use = false;
            public eELGATypeSektion typ;
            public string title;
            public LIST<II> cdatemplateIDs;
            public ccode code = new ccode { code = "", displayName = "", codeSystem = "", codeSystemName = "" };
            public string textHTML;
            public List<PflegediagnoseEntry> PflegediagnosenEntrys;
            //public VitalparameterEntry VitalparamterEntry;
            public Risiko Risiko;
            public HilfsmittelRessourcen HilfsmittelUndRessourcen;
            public List<BeilagenEntry> BeilagenEntries;
            public string Tag;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static ClinicalDocument ccda { get; set; } = new ClinicalDocument();
        Component2 compSektionen = new Component2();
        StructuredBody structBody = new StructuredBody();

        public ucELGAPrintPflegesituationsbericht()
        {
            InitializeComponent();
        }

        public void Init(Guid pIDEmpfaenger)
        {
            IDEmpfaenger = pIDEmpfaenger;
            ReadAllELGACodes();
            ccda = new ClinicalDocument();

            //Headerdaten aus DB lesen
            cELGADB.LoadKlinik(ref Klinik);
            cELGADB.LoadKlient(ref Klient);
            cELGADB.LoadAufenthalt(ref Aufenthalt);
            cELGADB.LoadSachwalter(ref lSachwalter);
            cELGADB.LoadBenutzer(ref Benutzer);
            cELGADB.LoadEmfaenger(ref Empfaenger);
            cELGADB.LoadHausarzt(ref Hausarzt);
            cELGADB.LoadKontaktpersonen(ref Kontaktpersonen);

            ////Headerdaten in CDA-Dokument schreiben
            //InitCDA();
            //InitKlient();
            //InitAuthor();
            //InitVerwahrer();
            //InitEmpfaenger();
            //InitRechtlicherUnterzeichner();
            //InitAnsprechperson();
            //InitHausarzt();
            //InitKontaktpersonen();

            //Klassen für fachliche Sektionen aus DB befüllen
            InitRTFTags();
            InitSektionen();
            LoadPDx();
            LoadRessourcenRisiken();
            LoadVitalparameter();
            LoadMedDaten();
            LoadRezepte();
            LoadPatientenverfügung();
            LoadPflegeUndBetreuungsumfang();
            LoadBeilagen();
        }

        private void InitCDA()
        {
            try
            {
                ccda = new ClinicalDocument();
                cdaInfo Info = new cdaInfo();
                ccda.RealmCode = Info.ccdaRealmCode;
                ccda.TypeId = Info.ccdaTypeId;
                ccda.TemplateId = Info.cdatemplateIDs;
                ccda.Id = Info.cdaID;
                ccda.SetId = Info.cdaSetID;
                ccda.VersionNumber = Info.cdaVersion;
                ccda.EffectiveTime = Info.cdaEffectiveTime;
                ccda.ConfidentialityCode = Info.ccdaConfidentialityCode;
                ccda.ConfidentialityCode.DisplayName = Info.ccdaConfidentialityCodeDisplayName;
                ccda.LanguageCode = Info.ccdaLanguageCode;
                ccda.SetId.AssigningAuthorityName = Klinik.Bezeichnung;      // Klinik.ELGA_OrganizationName?;
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.InitCDA: " + ex.ToString());
            }
        }

        private void InitKlient()
        {
            try
            {
                PatientRole patientRole = new PatientRole();

                patientRole.Id = new SET<II> { new II { Root = Klient.ID.ToString(), AssigningAuthorityName = Klinik.Bezeichnung } };

                if (String.IsNullOrWhiteSpace(Klient.VersicherungsNr) && Klient.SozVersLeerGrund.Equals("Klient hat keine Sozialversicherungsnummer", StringComparison.OrdinalIgnoreCase))
                {
                    patientRole.Id.Add(new II { Root = "1.2.40.0.10.1.4.3.1", NullFlavor = new CS<NullFlavor>(NullFlavor.NoInformation), AssigningAuthorityName = "Österreichische Sozialversicherung" });
                }
                else if (String.IsNullOrWhiteSpace(Klient.VersicherungsNr) && Klient.SozVersLeerGrund.Equals("Sozialversicherungsnummer unbekannt", StringComparison.OrdinalIgnoreCase))
                {
                    patientRole.Id.Add(new II { Root = "1.2.40.0.10.1.4.3.1", NullFlavor = new CS<NullFlavor>(NullFlavor.Unknown), AssigningAuthorityName = "Österreichische Sozialversicherung" });
                }
                else if (!String.IsNullOrWhiteSpace(Klient.VersicherungsNr))
                {
                    patientRole.Id.Add(new II { Root = "1.2.40.0.10.1.4.3.1", Extension = Klient.VersicherungsNr, AssigningAuthorityName = "Österreichische Sozialversicherung" });
                }
                else
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB("Fehler bei der Sozialversicherungsnummer. Dokument kann nicht erstellt werden!", MessageBoxButtons.OK, "Wichtiger Hinweis!");
                    return;
                }
                patientRole.Id.Add(new II { Root = "1.2.40.0.10.2.1.1.149", Extension = Klient.bPK, AssigningAuthorityName = "Österreichische Stammzahlenregisterbehörde" });


                if (Klient.WohnungAbgemeldetJN)
                    patientRole.Addr = NewAdress(PostalAddressUse.PrimaryHome, Klinik.Adresse.PLZ, Klinik.Adresse.Ort, Klinik.Adresse.Strasse, null, Klinik.Adresse.Land);
                else
                    patientRole.Addr = NewAdress(PostalAddressUse.PrimaryHome, Klient.Adresse.PLZ, Klient.Adresse.Ort, Klient.Adresse.Strasse, null, Klient.Adresse.Land);

                if (!String.IsNullOrWhiteSpace(Klient.Kontakt.Telefon))
                {
                    if (patientRole.Telecom == null)
                        patientRole.Telecom = new SET<TEL>();
                    patientRole.Telecom.Add(new TEL(Klient.Kontakt.Telefon, TelecommunicationAddressUse.Home));
                }

                if (!String.IsNullOrWhiteSpace(Klient.Kontakt.TelefonMobil))
                {
                    if (patientRole.Telecom == null)
                        patientRole.Telecom = new SET<TEL>();
                    patientRole.Telecom.Add(new TEL(Klient.Kontakt.TelefonMobil, TelecommunicationAddressUse.MobileContact));
                }

                if (!String.IsNullOrWhiteSpace(Klient.Kontakt.eMail))
                {
                    if (patientRole.Telecom == null)
                        patientRole.Telecom = new SET<TEL>();
                    patientRole.Telecom.Add(new TEL(Klient.Kontakt.eMail));
                }

                MARC.Everest.RMIM.UV.CDAr2.POCD_MT000040UV.Patient patient = new MARC.Everest.RMIM.UV.CDAr2.POCD_MT000040UV.Patient();

                patient.Name = MakeNameNode(Klient.Titel, Klient.Vorname, Klient.Nachname, Klient.LedigerName, Klient.TitelPost);

                ccode SEX = SearchELGACode(Klient.Sexus, "SEX");
                if (SEX != null)
                    patient.AdministrativeGenderCode = new CE<string> { Code = SEX.code, CodeSystem = SEX.codeSystem, CodeSystemName = "HL7:AdministrativeGender", DisplayName = SEX.displayName };
                else
                {
                    patient.AdministrativeGenderCode.NullFlavor = new MARC.Everest.DataTypes.NullFlavor();
                    patient.AdministrativeGenderCode.NullFlavor = MARC.Everest.DataTypes.NullFlavor.Unknown;
                }

                patient.BirthTime = new TS(Klient.Geburtsdatum);

                ccode FAM = SearchELGACode(Klient.Familienstand, "FAM");
                if (FAM != null)
                    patient.MaritalStatusCode = new CE<string> { Code = FAM.code, CodeSystem = FAM.codeSystem, CodeSystemName = "HL7:MaritalStatus", DisplayName = FAM.displayName };
                else
                {
                    patient.MaritalStatusCode.NullFlavor = new MARC.Everest.DataTypes.NullFlavor();
                    patient.MaritalStatusCode.NullFlavor = MARC.Everest.DataTypes.NullFlavor.Unknown;
                }

                ccode KON = SearchELGACode(Klient.Konfession, "KON" );
                if (KON != null)
                    patient.ReligiousAffiliationCode = new CE<string> { Code = KON.code, CodeSystem = KON.codeSystem, CodeSystemName = "HL7.AT:ReligionAustria", DisplayName = KON.displayName };
                else
                {
                    patient.ReligiousAffiliationCode.NullFlavor = new MARC.Everest.DataTypes.NullFlavor();
                    patient.ReligiousAffiliationCode.NullFlavor = MARC.Everest.DataTypes.NullFlavor.Unknown;
                }

                List<LanguageCommunication> lLang = new List<LanguageCommunication>();
                foreach (string sprache in Klient.lstSprachen.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    ccode SPA = SearchELGACode(sprache, "SPA");
                    if (SPA != null)
                            patient.LanguageCommunication.Add(new LanguageCommunication(new CS<String>(SPA.code), null, null, null));
                }

                //---Sachwalter (es gibt nur Personen)
                foreach (cELGADB.Person pSachwalter in lSachwalter)
                {
                    Person sw = new Person();
                    sw.Name = MakeNameNode(pSachwalter.Titel, pSachwalter.Vorname, pSachwalter.Nachname, pSachwalter.LedigerName, pSachwalter.TitelPost);

                    Guardian Sachwalter = new Guardian();
                    Sachwalter.GuardianChoice = GuardianChoice.CreatePerson(sw.Name);
                    Sachwalter.Addr = NewAdress(PostalAddressUse.WorkPlace, pSachwalter.Adresse.PLZ, pSachwalter.Adresse.Ort, pSachwalter.Adresse.Strasse, null, pSachwalter.Adresse.Land);

                    if (!String.IsNullOrWhiteSpace(pSachwalter.Kontakt.Telefon))
                    {
                        if (Sachwalter.Telecom == null)
                            Sachwalter.Telecom = new SET<TEL>();
                        Sachwalter.Telecom.Add(new TEL(pSachwalter.Kontakt.Telefon, TelecommunicationAddressUse.Home));
                    }

                    if (!String.IsNullOrWhiteSpace(pSachwalter.Kontakt.TelefonMobil))
                    {
                        if (Sachwalter.Telecom == null)
                            Sachwalter.Telecom = new SET<TEL>();
                        Sachwalter.Telecom.Add(new TEL(pSachwalter.Kontakt.TelefonMobil, TelecommunicationAddressUse.MobileContact));
                    }

                    if (!String.IsNullOrWhiteSpace(pSachwalter.Kontakt.eMail))
                    {
                        if (Sachwalter.Telecom == null)
                            Sachwalter.Telecom = new SET<TEL>();
                        Sachwalter.Telecom.Add(new TEL(pSachwalter.Kontakt.eMail));
                    }
                    patient.Guardian.Add(Sachwalter);
                }

                if (!String.IsNullOrWhiteSpace(Klient.Geburtsort))
                {                    
                    MARC.Everest.RMIM.UV.CDAr2.POCD_MT000040UV.Birthplace GebOrt = new MARC.Everest.RMIM.UV.CDAr2.POCD_MT000040UV.Birthplace();
                    GebOrt.Place = new MARC.Everest.RMIM.UV.CDAr2.POCD_MT000040UV.Place();
                    GebOrt.Place.Addr = new AD(new ADXP[] { new ADXP(Klient.Geburtsort, AddressPartType.City) } );                   
                    patient.Birthplace = GebOrt;
                }

                patientRole.Patient = patient;

                RecordTarget recordTarget = new RecordTarget();
                recordTarget.ContextControlCode = ContextControl.OverridingPropagating;
                recordTarget.PatientRole = patientRole;
                ccda.RecordTarget.Add(recordTarget);

            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.InitKlient: " + ex.ToString());
            }
        }

        private void InitAuthor()
        {
            try
            {
                Author author = new Author();
                author.AssignedAuthor = new AssignedAuthor(new SET<II> { new II(Benutzer.ID) });
                author.AssignedAuthor.Id[0].AssigningAuthorityName = Klinik.Bezeichnung;
                author.AssignedAuthor.Addr = NewAdress(PostalAddressUse.PostalAddress, Klinik.Adresse.PLZ, Klinik.Adresse.Ort, Klinik.Adresse.Strasse, null, Klinik.Adresse.Land);              
                Person Verfasser = new Person();
                Verfasser.Name = MakeNameNode(Benutzer.Titel, Benutzer.Vorname, Benutzer.Nachname, Benutzer.LedigerName, Benutzer.TitelPost);
                author.AssignedAuthor.SetAssignedAuthorChoice(Verfasser);

                Organization AuthorOrg = new Organization();
                AuthorOrg.Id = new SET<II> { new II { AssigningAuthorityName = "GDA Index", Root = Klinik.ELGA_OID } };

                ON on = new ON();
                on.Part.Add(new ENXP(Klinik.Bezeichnung + ", " + Aufenthalt.Abteilung));
                AuthorOrg.Name = new SET<ON> {(on)};
                AuthorOrg.Addr = NewAdress(PostalAddressUse.WorkPlace, Klinik.Adresse.PLZ, Klinik.Adresse.Ort, Klinik.Adresse.Strasse, null, Klinik.Adresse.Land);

                if (!String.IsNullOrWhiteSpace(Klinik.Kontakt.Telefon))
                {
                    if (AuthorOrg.Telecom == null)
                        AuthorOrg.Telecom = new SET<TEL>();
                    AuthorOrg.Telecom.Add(new TEL(Klinik.Kontakt.Telefon, TelecommunicationAddressUse.Home));
                }

                if (!String.IsNullOrWhiteSpace(Klinik.Kontakt.TelefonMobil))
                {
                    if (AuthorOrg.Telecom == null)
                        AuthorOrg.Telecom = new SET<TEL>();
                    AuthorOrg.Telecom.Add(new TEL(Klinik.Kontakt.TelefonMobil, TelecommunicationAddressUse.MobileContact));
                }

                if (!String.IsNullOrWhiteSpace(Klinik.Kontakt.eMail))
                {
                    if (AuthorOrg.Telecom == null)
                        AuthorOrg.Telecom = new SET<TEL>();
                    AuthorOrg.Telecom.Add(new TEL(Klinik.Kontakt.eMail));
                }
                author.AssignedAuthor.RepresentedOrganization = AuthorOrg;
                author.ContextControlCode = null;

                ccda.Author.Add(author);

            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.InitAuthor: " + ex.ToString());
            }
        }

        private void InitVerwahrer()
        {
            try
            {
                CustodianOrganization VerwahrerOrg = new CustodianOrganization();
                SET<II> II = new SET<II> { new II { AssigningAuthorityName = "GDA Index", Root = Klinik.ELGA_OID } };

                ON Name = new ON();
                Name.Part.Add(new ENXP(Klinik.Bezeichnung + ", " + Aufenthalt.Abteilung));

                AD Adresse = new AD();
                Adresse = NewAdress(PostalAddressUse.WorkPlace, Klinik.Adresse.PLZ, Klinik.Adresse.Ort, Klinik.Adresse.Strasse, null, Klinik.Adresse.Land).First();

                TEL Telefon = new TEL();
                if (!String.IsNullOrWhiteSpace(Klinik.Kontakt.Telefon))
                {
                    Telefon = new TEL(Klinik.Kontakt.Telefon, TelecommunicationAddressUse.Home);
                }

                Custodian Verwahrer = new Custodian(new AssignedCustodian());
                Verwahrer.AssignedCustodian.RepresentedCustodianOrganization = new CustodianOrganization(II, Name, Telefon, Adresse);
                ccda.Custodian = Verwahrer;
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.InitAuthor: " + ex.ToString());
            }
        }

        private void InitEmpfaenger()
        {
            try
            {
                InformationRecipient Empfaenger = new InformationRecipient(new CS<x_InformationRecipient>(x_InformationRecipient.PRCP));

                IntendedRecipient GeplEmpfänger = new IntendedRecipient();
                SET<II> iis = new SET<II>();
                II i = new II();

                if (this.Empfaenger.Bezeichnung.Equals("Hausarzt", StringComparison.OrdinalIgnoreCase))
                {
                    i.NullFlavor = NullFlavor.Unknown;
                    GeplEmpfänger.Id.Add(i);
                    GeplEmpfänger.InformationRecipient = new Person();
                    GeplEmpfänger.InformationRecipient.Name = new SET<PN> { new PN("Hausarzt") };
                    Empfaenger.IntendedRecipient = GeplEmpfänger;
                }
                else if (this.Empfaenger.Bezeichnung.Equals("Klient", StringComparison.OrdinalIgnoreCase))
                {
                    i.NullFlavor = NullFlavor.NoInformation;
                    GeplEmpfänger.Id.Add(i);
                    GeplEmpfänger.InformationRecipient = new Person();
                    GeplEmpfänger.InformationRecipient.Name = new SET<PN> { new PN("An den Klienten " + (Klient.Titel + Klient.Vorname + " " + Klient.Nachname + " " + Klient.TitelPost).Trim()) };
                    Empfaenger.IntendedRecipient = GeplEmpfänger;
                }
                else
                {
                    i.NullFlavor = NullFlavor.Unknown;
                    GeplEmpfänger.Id = new SET<II> { i};
                    GeplEmpfänger.InformationRecipient = new Person();
                    GeplEmpfänger.InformationRecipient.Name = new SET<PN> { new PN("An die Einrichtung") };
                    Empfaenger.IntendedRecipient = GeplEmpfänger;

                    ON on = new ON();
                    on.Part.Add(new ENXP(this.Empfaenger.Bezeichnung));
                    GeplEmpfänger.ReceivedOrganization = new Organization();
                    GeplEmpfänger.ReceivedOrganization.Id = new SET<II> { new II { AssigningAuthorityName = "GDA Index", Root = this.Empfaenger.ELGA_OID } };
                    GeplEmpfänger.ReceivedOrganization.Name = new SET<ON> { (on) };
                    GeplEmpfänger.ReceivedOrganization.Addr = NewAdress(PostalAddressUse.WorkPlace, this.Empfaenger.Adresse.PLZ, this.Empfaenger.Adresse.Ort, this.Empfaenger.Adresse.Strasse, null, this.Empfaenger.Adresse.Land);

                    if (!String.IsNullOrWhiteSpace(this.Empfaenger.Kontakt.Telefon))
                    {
                        if (GeplEmpfänger.ReceivedOrganization.Telecom == null)
                            GeplEmpfänger.ReceivedOrganization.Telecom = new SET<TEL>();
                        GeplEmpfänger.ReceivedOrganization.Telecom.Add(new TEL(this.Empfaenger.Kontakt.Telefon, TelecommunicationAddressUse.Home));
                    }

                    if (!String.IsNullOrWhiteSpace(this.Empfaenger.Kontakt.TelefonMobil))
                    {
                        if (GeplEmpfänger.ReceivedOrganization.Telecom == null)
                            GeplEmpfänger.ReceivedOrganization.Telecom = new SET<TEL>();
                        GeplEmpfänger.ReceivedOrganization.Telecom.Add(new TEL(this.Empfaenger.Kontakt.TelefonMobil, TelecommunicationAddressUse.MobileContact));
                    }

                    if (!String.IsNullOrWhiteSpace(this.Empfaenger.Kontakt.eMail))
                    {
                        if (GeplEmpfänger.ReceivedOrganization.Telecom == null)
                            GeplEmpfänger.ReceivedOrganization.Telecom = new SET<TEL>();
                        GeplEmpfänger.ReceivedOrganization.Telecom.Add(new TEL(this.Empfaenger.Kontakt.eMail));
                    }
                }

                ccda.InformationRecipient = new List<InformationRecipient>();
                ccda.InformationRecipient.Add(Empfaenger);
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.InitEmpfaenger: " + ex.ToString());
            }
        }

        private void InitRechtlicherUnterzeichner()
        {
            try
            {
                LegalAuthenticator Unterzeichner = new LegalAuthenticator();
                Unterzeichner.Time = new TS(DateTime.Now);
                Unterzeichner.SignatureCode = new CS<string>("S");

                AssignedEntity assignedEntity = new AssignedEntity(null, null, null, null, null, null);
                assignedEntity.Id = new SET<II>{ { new II(Benutzer.ID) } };
                assignedEntity.Id[0].AssigningAuthorityName = Klinik.Bezeichnung;

                if (!String.IsNullOrWhiteSpace(Klinik.Kontakt.Telefon))
                {
                    if (assignedEntity.Telecom == null)
                        assignedEntity.Telecom = new SET<TEL>();
                    assignedEntity.Telecom.Add(new TEL(Klinik.Kontakt.Telefon, TelecommunicationAddressUse.Home));
                }

                if (!String.IsNullOrWhiteSpace(Klinik.Kontakt.TelefonMobil))
                {
                    if (assignedEntity.Telecom == null)
                        assignedEntity.Telecom = new SET<TEL>();
                    assignedEntity.Telecom.Add(new TEL(Klinik.Kontakt.TelefonMobil, TelecommunicationAddressUse.MobileContact));
                }

                if (!String.IsNullOrWhiteSpace(Klinik.Kontakt.eMail))
                {
                    if (assignedEntity.Telecom == null)
                        assignedEntity.Telecom = new SET<TEL>();
                    assignedEntity.Telecom.Add(new TEL(Klinik.Kontakt.eMail));
                }

                assignedEntity.AssignedPerson = new Person();
                assignedEntity.AssignedPerson.Name = MakeNameNode(Benutzer.Titel, Benutzer.Vorname, Benutzer.Nachname, Benutzer.LedigerName, Benutzer.TitelPost);

                assignedEntity.RepresentedOrganization = new Organization();
                assignedEntity.RepresentedOrganization.Id = new SET<II> { new II { AssigningAuthorityName = "GDA Index", Root = Klinik.ELGA_OID } };

                ON on = new ON();
                on.Part.Add(new ENXP(Klinik.Bezeichnung + ", " + Aufenthalt.Abteilung));
                assignedEntity.RepresentedOrganization.Name = new SET<ON> { (on) };
                assignedEntity.RepresentedOrganization.Addr = NewAdress(PostalAddressUse.Public, Klinik.Adresse.PLZ, Klinik.Adresse.Ort, Klinik.Adresse.Strasse, null, Klinik.Adresse.Land);

                if (!String.IsNullOrWhiteSpace(Klinik.Kontakt.Telefon))
                {
                    if (assignedEntity.RepresentedOrganization.Telecom == null)
                        assignedEntity.RepresentedOrganization.Telecom = new SET<TEL>();
                    assignedEntity.RepresentedOrganization.Telecom.Add(new TEL(Klinik.Kontakt.Telefon, TelecommunicationAddressUse.Home));
                }

                if (!String.IsNullOrWhiteSpace(Klinik.Kontakt.TelefonMobil))
                {
                    if (assignedEntity.RepresentedOrganization.Telecom == null)
                        assignedEntity.RepresentedOrganization.Telecom = new SET<TEL>();
                    assignedEntity.RepresentedOrganization.Telecom.Add(new TEL(Klinik.Kontakt.TelefonMobil, TelecommunicationAddressUse.MobileContact));
                }

                if (!String.IsNullOrWhiteSpace(Klinik.Kontakt.eMail))
                {
                    if (assignedEntity.RepresentedOrganization.Telecom == null)
                        assignedEntity.RepresentedOrganization.Telecom = new SET<TEL>();
                    assignedEntity.RepresentedOrganization.Telecom.Add(new TEL(Klinik.Kontakt.eMail));
                }

                Unterzeichner.AssignedEntity = assignedEntity;
                ccda.LegalAuthenticator = Unterzeichner;
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.InitRechtlicherUnterzeichner: " + ex.ToString());
            }
        }

        private void InitAnsprechperson()
        {
            try
            {
                Participant1 Ansprechperson = new Participant1(new CS<ParticipationType>(ParticipationType.CallbackContact), null);
                Ansprechperson.TemplateId = new LIST<II> { new II { Root = "1.2.40.0.34.11.1.1.1" } };
                Ansprechperson.AssociatedEntity = new AssociatedEntity(new CS<RoleClassAssociative>(RoleClassAssociative.HealthcareProvider));
                Ansprechperson.AssociatedEntity.Telecom = new SET<TEL> { new TEL(Klinik.Kontakt.Telefon, TelecommunicationAddressUse.WorkPlace)};
                Ansprechperson.AssociatedEntity.AssociatedPerson = new Person();
                Ansprechperson.AssociatedEntity.AssociatedPerson.Name = MakeNameNode(Benutzer.Titel, Benutzer.Vorname, Benutzer.Nachname, Benutzer.LedigerName, Benutzer.TitelPost);

                Ansprechperson.AssociatedEntity.ScopingOrganization = new Organization();
                Ansprechperson.AssociatedEntity.ScopingOrganization.Id = new SET<II> { new II { AssigningAuthorityName = "GDA Index", Root = Klinik.ELGA_OID } };

                ON on = new ON();
                on.Part.Add(new ENXP(Klinik.Bezeichnung + ", " + Aufenthalt.Abteilung));
                Ansprechperson.AssociatedEntity.ScopingOrganization.Name = new SET<ON> { (on) };
                Ansprechperson.AssociatedEntity.ScopingOrganization.Addr = NewAdress(PostalAddressUse.Public, Klinik.Adresse.PLZ, Klinik.Adresse.Ort, Klinik.Adresse.Strasse, null, Klinik.Adresse.Land);

                if (!String.IsNullOrWhiteSpace(Klinik.Kontakt.Telefon))
                {
                    if (Ansprechperson.AssociatedEntity.ScopingOrganization.Telecom == null)
                        Ansprechperson.AssociatedEntity.ScopingOrganization.Telecom = new SET<TEL>();
                    Ansprechperson.AssociatedEntity.ScopingOrganization.Telecom.Add(new TEL(Klinik.Kontakt.Telefon, TelecommunicationAddressUse.Home));
                }

                if (!String.IsNullOrWhiteSpace(Klinik.Kontakt.TelefonMobil))
                {
                    if (Ansprechperson.AssociatedEntity.ScopingOrganization.Telecom == null)
                        Ansprechperson.AssociatedEntity.ScopingOrganization.Telecom = new SET<TEL>();
                    Ansprechperson.AssociatedEntity.ScopingOrganization.Telecom.Add(new TEL(Klinik.Kontakt.TelefonMobil, TelecommunicationAddressUse.MobileContact));
                }

                if (!String.IsNullOrWhiteSpace(Klinik.Kontakt.eMail))
                {
                    if (Ansprechperson.AssociatedEntity.ScopingOrganization.Telecom == null)
                        Ansprechperson.AssociatedEntity.ScopingOrganization.Telecom = new SET<TEL>();
                    Ansprechperson.AssociatedEntity.ScopingOrganization.Telecom.Add(new TEL(Klinik.Kontakt.eMail));
                }
                ccda.Participant.Add(Ansprechperson);
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.InitAnsprechperson: " + ex.ToString());
            }
        }

        private void InitHausarzt()
        {
            try
            {
                if (this.Hausarzt.Rolle == cELGADB.eOrganistionRolle.Arzt)
                {
                    Participant1 Hausarzt = new Participant1(new CS<ParticipationType>(ParticipationType.IND), null);
                    Hausarzt.TemplateId = new LIST<II> { new II { Root = "1.2.40.0.34.11.1.1.3" } };
                    Hausarzt.FunctionCode = new CE<string>("PCP", "2.16.840.1.113883.5.88", "HL7:ParticipationFunction", null, "primary care physician", null);

                    Hausarzt.AssociatedEntity = new AssociatedEntity(new CS<RoleClassAssociative>(RoleClassAssociative.HealthcareProvider));

                    if (String.IsNullOrWhiteSpace(this.Hausarzt.Arztdaten.ELGA_OID))
                        Hausarzt.AssociatedEntity.Id.NullFlavor = MARC.Everest.DataTypes.NullFlavor.Unknown;
                    else
                    {
                        Hausarzt.AssociatedEntity.Id = new SET<II> { new II { Root = this.Hausarzt.Arztdaten.ELGA_OID } };
                    }

                    Hausarzt.AssociatedEntity.AssociatedPerson = new Person();
                    Hausarzt.AssociatedEntity.AssociatedPerson.Name = MakeNameNode(Benutzer.Titel, Benutzer.Vorname, Benutzer.Nachname, null, null);

                    Hausarzt.AssociatedEntity.ScopingOrganization = new Organization();
                    if (String.IsNullOrWhiteSpace(this.Hausarzt.Arztdaten.ELGA_OrganizationOID))
                        Hausarzt.AssociatedEntity.ScopingOrganization.NullFlavor = MARC.Everest.DataTypes.NullFlavor.Unknown;
                    else
                        Hausarzt.AssociatedEntity.ScopingOrganization.Id = new SET<II> { new II { AssigningAuthorityName = "GDA Index", Root = this.Hausarzt.Arztdaten.ELGA_OrganizationOID } };

                    ON on = new ON();
                    on.Part.Add(new ENXP((this.Hausarzt.Arztdaten.Titel + " " + this.Hausarzt.Arztdaten.Vorname + this.Hausarzt.Arztdaten.Nachname).Trim()));
                    Hausarzt.AssociatedEntity.ScopingOrganization.Name = new SET<ON> { (on) };
                    Hausarzt.AssociatedEntity.ScopingOrganization.Addr = NewAdress(PostalAddressUse.Public, this.Hausarzt.Adresse.PLZ, this.Hausarzt.Adresse.Ort, this.Hausarzt.Adresse.Strasse, null, this.Hausarzt.Adresse.Land);

                    if (!String.IsNullOrWhiteSpace(Klinik.Kontakt.Telefon))
                    {
                        if (Hausarzt.AssociatedEntity.ScopingOrganization.Telecom == null)
                            Hausarzt.AssociatedEntity.ScopingOrganization.Telecom = new SET<TEL>();
                        Hausarzt.AssociatedEntity.ScopingOrganization.Telecom.Add(new TEL(Klinik.Kontakt.Telefon, TelecommunicationAddressUse.Home));
                    }

                    if (!String.IsNullOrWhiteSpace(Klinik.Kontakt.TelefonMobil))
                    {
                        if (Hausarzt.AssociatedEntity.ScopingOrganization.Telecom == null)
                            Hausarzt.AssociatedEntity.ScopingOrganization.Telecom = new SET<TEL>();
                        Hausarzt.AssociatedEntity.ScopingOrganization.Telecom.Add(new TEL(Klinik.Kontakt.TelefonMobil, TelecommunicationAddressUse.MobileContact));
                    }

                    if (!String.IsNullOrWhiteSpace(Klinik.Kontakt.eMail))
                    {
                        if (Hausarzt.AssociatedEntity.ScopingOrganization.Telecom == null)
                            Hausarzt.AssociatedEntity.ScopingOrganization.Telecom = new SET<TEL>();
                        Hausarzt.AssociatedEntity.ScopingOrganization.Telecom.Add(new TEL(Klinik.Kontakt.eMail));
                    }
                    ccda.Participant.Add(Hausarzt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.InitHausarzt: " + ex.ToString());
            }
        }

        private void InitKontaktpersonen()
        {
            try
            {
                foreach (cELGADB.Person Kontaktperson in Kontaktpersonen)
                {

                    if (SearchELGACode(Kontaktperson.Kontaktdaten.Verwandtschaft, "VWV") != null)
                    {
                        Participant1 Kontakt = new Participant1(new CS<ParticipationType>(ParticipationType.IND), null);
                        if (Kontaktperson.Kontaktdaten.VerstaendigenJN)
                        {
                            Kontakt.TemplateId = new LIST<II> { new II { Root = "1.2.40.0.34.11.1.1.4" } };
                            Kontakt.AssociatedEntity = new AssociatedEntity(new CS<RoleClassAssociative>(RoleClassAssociative.EmergencyContact));
                        }
                        else
                        {
                            Kontakt.TemplateId = new LIST<II> { new II { Root = "1.2.40.0.34.11.1.1.5" } };
                            Kontakt.AssociatedEntity = new AssociatedEntity(new CS<RoleClassAssociative>(RoleClassAssociative.PersonalRelationship));
                        }

                        Kontakt.FunctionCode = new CE<string>(SearchELGACode(Kontaktperson.Kontaktdaten.Verwandtschaft, "VWV").code, "2.16.840.1.113883.5.111", "HL7:RoleCode", null, SearchELGACode(Kontaktperson.Kontaktdaten.Verwandtschaft, "VWV").displayName, null);


                        Kontakt.AssociatedEntity.AssociatedPerson = new Person();
                        Kontakt.AssociatedEntity.AssociatedPerson.Name = MakeNameNode(Kontaktperson.Titel, Kontaktperson.Vorname, Kontaktperson.Nachname, null, null);
                        ccda.Participant.Add(Kontakt);
                    }
                    else
                        MessageBox.Show("Verwandtschaftsverhältnis '" + Kontaktperson.Kontaktdaten.Verwandtschaft + "' für " + Kontaktperson.Vorname + " " + Kontaktperson.Nachname + " ist ungültig (entspricht keinem ELGA-konformen Eintrag). Der Kontakt wird nicht im Pflegesituationsbericht übermittelt!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.InitKontaktpersonen: " + ex.ToString());
            }
        }

        private SET<PN> MakeNameNode(string Titel, string Vorname, string Nachname, string LedigerName, string TitelPost)
        {
            try
            {
                int iNamensteile = -1;
                int iPrefix = -1;
                int iLedigerName = -1;
                int iPostfix = -1;

                List<ENXP> Namensteile = new List<ENXP>();
                if (!String.IsNullOrWhiteSpace(Titel))
                {
                    iNamensteile++;
                    Namensteile.Add(new ENXP(Titel));
                    iPrefix = iNamensteile;
                }

                Namensteile.Add(new ENXP(Vorname, EntityNamePartType.Given));
                iNamensteile++;

                Namensteile.Add(new ENXP(Nachname, EntityNamePartType.Family));
                iNamensteile++;

                if (!String.IsNullOrWhiteSpace(LedigerName))
                {
                    iNamensteile++;
                    Namensteile.Add(new ENXP(LedigerName, EntityNamePartType.Family));
                    iLedigerName = iNamensteile;
                }

                if (!String.IsNullOrWhiteSpace(TitelPost))
                {
                    iNamensteile++;
                    Namensteile.Add(new ENXP(TitelPost));
                    iPostfix = iNamensteile;
                }

                SET<PN> Name = new SET<PN>(new PN(Namensteile));

                if (iPrefix > -1)
                {
                    Name[0].Part[iPrefix].Qualifier = new SET<CS<EntityNamePartQualifier>>() { EntityNamePartQualifier.Academic, EntityNamePartQualifier.Prefix };
                }

                if (iLedigerName > -1)
                    Name[0].Part[iLedigerName].Qualifier = new SET<CS<EntityNamePartQualifier>>() { EntityNamePartQualifier.Birth };

                if (iPostfix > -1)
                    Name[0].Part[iPostfix].Qualifier = new SET<CS<EntityNamePartQualifier>>() { EntityNamePartQualifier.Academic, EntityNamePartQualifier.Suffix };

                return Name;

            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.MakeNameNode: " + ex.ToString());
            }
        }

        private void InitRTFTags()
        {
            try
            {
                rtfBRIEFT_Text.Tag = new RTFTag { Order = SektionOrder.Brieftext, Tag = "BRIEFT_TEXT", Typ = RTFTyp.Text };

                rtfPFMOB_Text.Tag = new RTFTag { Order = SektionOrder.Mobilität, Tag = "PFMOB_TEXT", Typ = RTFTyp.Text };
                rtfPFMOB_Res.Tag = new RTFTag { Order = SektionOrder.Mobilität, Tag = "PFMOB_RES", Typ = RTFTyp.Res };
                rtfPFMOB_Risk.Tag = new RTFTag { Order = SektionOrder.Mobilität, Tag = "PFMOB_RISK", Typ = RTFTyp.Risk };

                rtfPFKLEI_Text.Tag = new RTFTag { Order = SektionOrder.KörperpflegeUndKleiden, Tag = "PFKLEI_TEXT", Typ = RTFTyp.Text };
                rtfPFKLEI_Res.Tag = new RTFTag { Order = SektionOrder.KörperpflegeUndKleiden, Tag = "PFKLEI_RES", Typ = RTFTyp.Res };
                rtfPFKLEI_Risk.Tag = new RTFTag { Order = SektionOrder.KörperpflegeUndKleiden, Tag = "PFKLEI_RISK", Typ = RTFTyp.Risk };

                rtfPFERN_Text.Tag = new RTFTag { Order = SektionOrder.Ernährung, Tag = "PFERN_TEXT", Typ = RTFTyp.Text };
                rtfPFERN_Res.Tag = new RTFTag { Order = SektionOrder.Ernährung, Tag = "PFERN_RES", Typ = RTFTyp.Res };
                rtfPFERN_Risk.Tag = new RTFTag { Order = SektionOrder.Ernährung, Tag = "PFERN_RISK", Typ = RTFTyp.Risk };

                rtfPFAUS_Text.Tag = new RTFTag { Order = SektionOrder.Ausscheidung, Tag = "PFAUS_TEXT", Typ = RTFTyp.Text };
                rtfPFAUS_Res.Tag = new RTFTag { Order = SektionOrder.Ausscheidung, Tag = "PFAUS_RES", Typ = RTFTyp.Res };
                rtfPFAUS_Risk.Tag = new RTFTag { Order = SektionOrder.Ausscheidung, Tag = "PFAUS_RISK", Typ = RTFTyp.Risk };

                rtfPFHAUT_Text.Tag = new RTFTag { Order = SektionOrder.Hautzustand, Tag = "PFHAUT_TEXT", Typ = RTFTyp.Text };
                rtfPFHAUT_Res.Tag = new RTFTag { Order = SektionOrder.Hautzustand, Tag = "PFHAUT_RES", Typ = RTFTyp.Res };
                rtfPFHAUT_Risk.Tag = new RTFTag { Order = SektionOrder.Hautzustand, Tag = "PFHAUT_RISK", Typ = RTFTyp.Risk };

                rtfPFATM_Text.Tag = new RTFTag { Order = SektionOrder.Atmung, Tag = "PFATM_TEXT", Typ = RTFTyp.Text };
                rtfPFATM_Res.Tag = new RTFTag { Order = SektionOrder.Atmung, Tag = "PFATM_RES", Typ = RTFTyp.Res };
                rtfPFATM_Risk.Tag = new RTFTag { Order = SektionOrder.Atmung, Tag = "PFATM_RISK", Typ = RTFTyp.Risk };

                rtfPFSCHL_Text.Tag = new RTFTag { Order = SektionOrder.Schlaf, Tag = "PFSCHL_TEXT", Typ = RTFTyp.Text };
                rtfPFSCHL_Res.Tag = new RTFTag { Order = SektionOrder.Schlaf, Tag = "PFSCHL_RES", Typ = RTFTyp.Res };
                rtfPFSCHL_Risk.Tag = new RTFTag { Order = SektionOrder.Schlaf, Tag = "PFSCHL_RISK", Typ = RTFTyp.Risk };

                rtfPFSCHMERZ_Text.Tag = new RTFTag { Order = SektionOrder.Schmerz, Tag = "PFSCHMERZ_TEXT", Typ = RTFTyp.Text };
                rtfPFSCHMERZ_Res.Tag = new RTFTag { Order = SektionOrder.Schmerz, Tag = "PFSCHMERZ_RES", Typ = RTFTyp.Res };
                rtfPFSCHMERZ_Risk.Tag = new RTFTag { Order = SektionOrder.Schmerz, Tag = "PFSCHMERZ_RISK", Typ = RTFTyp.Risk };

                rtfPFORIE_Text.Tag = new RTFTag { Order = SektionOrder.OrientierungUndBewusstseinslage, Tag = "PFORIE_TEXT", Typ = RTFTyp.Text };
                rtfPFORIE_Res.Tag = new RTFTag { Order = SektionOrder.OrientierungUndBewusstseinslage, Tag = "PFORIE_RES", Typ = RTFTyp.Res };
                rtfPFORIE_Risk.Tag = new RTFTag { Order = SektionOrder.OrientierungUndBewusstseinslage, Tag = "PFORIE_RISK", Typ = RTFTyp.Risk };

                rtfPFSOZV_Text.Tag = new RTFTag { Order = SektionOrder.SozialeUmständeUndVerhalten, Tag = "PFSOZV_TEXT", Typ = RTFTyp.Text };
                rtfPFSOZV_Res.Tag = new RTFTag { Order = SektionOrder.SozialeUmständeUndVerhalten, Tag = "PFSOZV_RES", Typ = RTFTyp.Res };
                rtfPFSOZV_Risk.Tag = new RTFTag { Order = SektionOrder.SozialeUmständeUndVerhalten, Tag = "PFSOZV_RISK", Typ = RTFTyp.Risk };

                rtfPFKOMM_Text.Tag = new RTFTag { Order = SektionOrder.Kommunikation, Tag = "PFKOMM_TEXT", Typ = RTFTyp.Text };
                rtfPFKOMM_Res.Tag = new RTFTag { Order = SektionOrder.Kommunikation, Tag = "PFKOMM_RES", Typ = RTFTyp.Res };
                rtfPFKOMM_Risk.Tag = new RTFTag { Order = SektionOrder.Kommunikation, Tag = "PFKOMM_RISK", Typ = RTFTyp.Risk };

                rtfPFROLL_Text.Tag = new RTFTag { Order = SektionOrder.RollenwahnehmungUndSinnfindung, Tag = "PFROLL_TEXT", Typ = RTFTyp.Text };
                rtfPFROLL_Res.Tag = new RTFTag { Order = SektionOrder.RollenwahnehmungUndSinnfindung, Tag = "PFROLL_RES", Typ = RTFTyp.Res };
                rtfPFROLL_Risk.Tag = new RTFTag { Order = SektionOrder.RollenwahnehmungUndSinnfindung, Tag = "PFROLL_RISK", Typ = RTFTyp.Risk };

                rtfPFMEDBEH_Text.Tag = new RTFTag { Order = SektionOrder.PflegerelvanteInforamtionenZurMedizinischenBehandlung, Tag = "PFMEDBEH_TEXT", Typ = RTFTyp.Text };
                rtfPFMEDBEH_Risk.Tag = new RTFTag { Order = SektionOrder.PflegerelvanteInforamtionenZurMedizinischenBehandlung, Tag = "PFMEDBEH_RISK" };

                rtfPFMED_Text.Tag = new RTFTag { Order = SektionOrder.Medikamentenverabreichung, Tag = "PFMED_TEXT", Typ = RTFTyp.Text };
                rtfPFMED_Risk.Tag = new RTFTag { Order = SektionOrder.Medikamentenverabreichung, Tag = "PFMED_RISK", Typ = RTFTyp.Risk };

                rtfPUBUMF_Text.Tag = new RTFTag { Order = SektionOrder.PflegeUndBetreuungsumfang, Tag = "PUBUMF_TEXT", Typ = RTFTyp.Text };

                rtfANM_Text.Tag = new RTFTag { Order = SektionOrder.Anmerkungen, Tag = "ANM_TEXT", Typ = RTFTyp.Text };
                rtfANM_Risk.Tag = new RTFTag { Order = SektionOrder.Anmerkungen, Tag = "ANM_RISK", Typ = RTFTyp.Risk };

                rtfPATVERF_Text.Tag = new RTFTag { Order = SektionOrder.Patientenverfügung, Tag = "PATVERF_TEXT", Typ = RTFTyp.Text };

                rtfABBEM_Text.Tag = new RTFTag { Order = SektionOrder.AbschliessendeBemerkungen, Tag = "ABBEM_TEXT", Typ = RTFTyp.Text };
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.InitTextfields: " + ex.ToString());
            }
        }

        private void InitSektionen()
        {
            Sektionen.Add(CreateSektion((int)SektionOrder.Brieftext,
                                            eELGATypeSektion.Brieftext,
                                            "Brieftext",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.1.2.1", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "BRIEFT", displayName = "Brieftext" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Pflegediagnosen,
                                            eELGATypeSektion.Pflegediagnosen,
                                            "Pflegediagnosen",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.1.2.2", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFDIAG", displayName = "Pflegediagnosen" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Mobilität,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Mobilität",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.1.2.3", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFMOB", displayName = "Mobilität" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.KörperpflegeUndKleiden,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Körperpflege und Kleiden",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.1.2.4", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFKLEI", displayName = "Körperpflege und Kleiden" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Ernährung,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Ernährung",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.1.2.5", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFERN", displayName = "Ernährung" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Ausscheidung,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Ausscheidung",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.1.2.6", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFAUS", displayName = "Ausscheidung" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Hautzustand,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Hautzustand",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.1.2.7", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFHAUT", displayName = "Hautzustand" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Atmung,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Atmung",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.1.2.8", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFATM", displayName = "Atmung" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Schlaf,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Schlaf",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.1.2.9", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFSCHL", displayName = "Schlaf" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Schmerz,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Schmerz",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.1.2.10", AssigningAuthorityName = "ELGA" },
                                                           new II { Root = "1.3.6.1.4.1.19376.1.5.3.1.1.20.2.4", AssigningAuthorityName = "IHE PCC" } },
                                            new ccode { code = "38212-7", displayName = "Pain Assessment Panel", codeSystem = "2.16.840.1.113883.6.1", codeSystemName = "LOINC" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.OrientierungUndBewusstseinslage,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Orientierung und Bewusstseinslage",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.1.2.11", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFORIE", displayName = "Orientierung und Bewusstseinslage" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.SozialeUmständeUndVerhalten,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Soziale Umstände und Verhalten",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.1.2.12", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFSOZV", displayName = "Soziale Umstände und Verhalten" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Kommunikation,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Kommunikation",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.1.2.13", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFKOMM", displayName = "Kommunikation" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.RollenwahnehmungUndSinnfindung,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Rollenwahrnehmung und Sinnfindung",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.1.2.14", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFROLL", displayName = "Rollenwahrnehmung und Sinnfindung" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Vitalparameter,
                                            eELGATypeSektion.Vitalparameter,
                                            "Vitalparameter",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.1.2.7", AssigningAuthorityName = "ELGA" },
                                                           new II { Root = "1.3.6.1.4.1.19376.1.5.3.1.3.25", AssigningAuthorityName = "IHE PCC" },
                                                           new II { Root = "1.3.6.1.4.1.19376.1.5.3.1.1.5.3.2", AssigningAuthorityName = "IHE PCC" },
                                                           new II { Root = "2.16.840.1.113883.10.20.1.16", AssigningAuthorityName = "HL7 CCD" }
                                                         },
                                            new ccode { code = "8716-3", displayName = "Vital signs", codeSystem = "2.16.840.1.113883.6.1", codeSystemName = "LOINC" },
                                            "VITPAR"));

            Sektionen.Add(CreateSektion((int)SektionOrder.PflegerelvanteInforamtionenZurMedizinischenBehandlung,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Pflegerelevante Informationen zur medizinischen Behandlung",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.1.2.18", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFMEDBEH", displayName = "Pflegerelevante Informationen zur medizinischen Behandlung" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Medikamentenverabreichung,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Medikamentenverabreichung",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.1.2.15", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFMED", displayName = "Medikamentenverabreichung" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Anmerkungen,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Anmerkungen",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.1.2.5", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "ANM", displayName = "Anmerkungen" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.PflegeUndBetreuungsumfang,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Pflege- und Betreuungsumfang",
                                            new List<II> { new II { Root = "1.2.40.0.34.11.1.2.22", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PUBUMF", displayName = "Pflege- und Betreuungsumfang" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Entlassungsmanagment,
                                            eELGATypeSektion.Enlassungsmanagement,
                                            "Entlassungsmanagement",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.3.2.17", AssigningAuthorityName = "ELGA" },
                                                           new II { Root = "1.3.6.1.4.1.19376.1.5.3.1.3.32", AssigningAuthorityName = "IHE PCC" }
                                                         },
                                            new ccode { code = "8650-4", displayName = "Hospital discharge disposition", codeSystem = "2.16.840.1.113883.6.1", codeSystemName = "LOINC" },
                                            "ENTL"));

            Sektionen.Add(CreateSektion((int)SektionOrder.Patientenverfügung,
                                            eELGATypeSektion.Patientenverfügung,
                                            "Patientenverfügungen und andere juridische Dokumente",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.1.2.4", AssigningAuthorityName = "ELGA" },
                                                           new II { Root = "1.3.6.1.4.1.19376.1.5.3.1.3.34", AssigningAuthorityName = "IHE PCC" },
                                                           new II { Root = "2.16.840.1.113883.10.20.1.1", AssigningAuthorityName = "HL7 CCD" },
                                                         },
                                            new ccode { code = "42348-3", displayName = "Advance directives", codeSystem = "2.16.840.1.113883.6.1", codeSystemName = "LOINC" },
                                            "PATVERF"));

            Sektionen.Add(CreateSektion((int)SektionOrder.AbschliessendeBemerkungen,
                                            eELGATypeSektion.AbschliessendeBemerkung,
                                            "Abschließende Bemerkungen",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.5.40", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "ABBEM", displayName = "Abschließende Bemerkungen" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Beilagen,
                                            eELGATypeSektion.Beilagen,
                                            "Beilagen",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.1.2.3", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "BEIL", displayName = "Beilagen" }));
        }

        private Sektion CreateSektion(int order, eELGATypeSektion typ, string title, LIST<II> cdatemplateIDs, ccode code, string Tag = "")
        {
            try
            {
                Sektion Sektion = new Sektion();
                Sektion.order = order;
                Sektion.typ = typ;
                Sektion.title = title;
                Sektion.cdatemplateIDs = cdatemplateIDs;
                Sektion.code = code;
                if (String.IsNullOrEmpty(Tag))
                    Sektion.Tag = code.code;
                else
                    Sektion.Tag = Tag;

                return Sektion;
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituatuionsbericht.CreateSektion" + ex.ToString());
            }
        }

        private void CDACreateComponent3(Sektion sektion)
        {
            try
            {
                Section sect = new Section();
                sect.TemplateId = sektion.cdatemplateIDs;
                sect.Code = new CE<string>(sektion.code.code, sektion.code.codeSystem, sektion.code.codeSystemName, null, sektion.code.displayName, null);
                sect.Title = sektion.title;
                sect.Title.Language = null;

                sect.Text = new ED();
                if (sektion.textHTML == null)
                    sektion.textHTML = "Keine zusätzliche Information verfügbar.";
                sect.Text.Data = System.Text.Encoding.UTF8.GetBytes(sektion.textHTML);
                sect.Text.Representation = MARC.Everest.DataTypes.Interfaces.EncapsulatedDataRepresentation.XML;
                sect.Text.MediaType = null;

                //Pflegediagnosen
                if (sektion.PflegediagnosenEntrys != null)
                {
                    foreach (PflegediagnoseEntry pdEntry in sektion.PflegediagnosenEntrys)
                    {
                        Observation observation = new Observation(new CS<x_ActMoodDocumentObservation>(x_ActMoodDocumentObservation.Eventoccurrence));
                        observation.NegationInd = new BL(false);
                        observation.ClassCode = new CS<ActClassObservation>(ActClassObservation.OBS);
                        observation.Id = new SET<II>(new II(pdEntry.entryRelationship.observation.id_root));
                        observation.TemplateId = pdEntry.entryRelationship.observation.cdatemplateIDs;
                        observation.Code = new CD<string>(
                            pdEntry.entryRelationship.observation.code.code,
                            pdEntry.entryRelationship.observation.code.codeSystem,
                            pdEntry.entryRelationship.observation.code.codeSystemName,
                            null,
                            pdEntry.entryRelationship.observation.code.displayName,
                            null);

                        observation.StatusCode = new CS<ActStatus>(ActStatus.Completed);
                        observation.EffectiveTime = new IVL<TS>(pdEntry.entryRelationship.observation.effectivTime_low_value, pdEntry.entryRelationship.observation.effectivTime_low_value);
                        if (pdEntry.entryRelationship.observation.effectivTime_low_value > new DateTime(1, 1, 1))
                        {
                            observation.EffectiveTime.High.NullFlavor = MARC.Everest.DataTypes.NullFlavor.Unknown;
                        }
                        else
                        {
                            observation.EffectiveTime.Low.NullFlavor = MARC.Everest.DataTypes.NullFlavor.Unknown;
                            observation.EffectiveTime.High.NullFlavor = MARC.Everest.DataTypes.NullFlavor.Unknown;
                        }                           
                        observation.Value = new CD<string>(
                            pdEntry.entryRelationship.observation.value_code,
                            pdEntry.entryRelationship.observation.value_codeSystem,
                            pdEntry.entryRelationship.observation.value_codeSystemName,
                            null,
                            pdEntry.entryRelationship.observation.value_displayName,
                            new ED(new TEL(pdEntry.entryRelationship.observation.value_originalText_reference_value)));
                        observation.Text = "";
                        observation.Text.Representation = EncapsulatedDataRepresentation.TXT;
                        observation.Text.Language = null;
                        observation.Text.MediaType = null;
                        observation.Text.Reference = pdEntry.entryRelationship.observation.text_reference;
                        observation.Text.Reference.UpdateMode = null;
                        observation.Text.Reference.Flavor = null;
                        observation.Text.Data = null;

                        EntryRelationship entryRelationship = new EntryRelationship();
                        entryRelationship.ContextConductionInd = null;
                        entryRelationship.InversionInd = new BL(false);
                        entryRelationship.TypeCode = new CS<x_ActRelationshipEntryRelationship>(x_ActRelationshipEntryRelationship.SUBJ);
                        entryRelationship.SetClinicalStatement(observation);

                        Entry entry = new Entry();
                        entry.ContextConductionInd = null;

                        entry.SetClinicalStatement(new CS<x_ActClassDocumentEntryAct>(x_ActClassDocumentEntryAct.Act), new CS<x_DocumentActMood>(x_DocumentActMood.Eventoccurrence), null, null, null, null, new CS<ActStatus>(ActStatus.Active), new IVL<TS>(), null, null);

                        entry.GetClinicalStatementIfAct().TemplateId = pdEntry.cdatemplateIDs;

                        Act act = entry.GetClinicalStatementIfAct();
                        act.ClassCode = new CS<x_ActClassDocumentEntryAct>(x_ActClassDocumentEntryAct.Act);
                        act.Id = new SET<II> { new II(pdEntry.id_root) };
                        if (pdEntry.effectiveTime_low_value > new DateTime(1,1,1))
                        {
                            act.EffectiveTime.Low = new TS(pdEntry.effectiveTime_low_value);
                            act.EffectiveTime.Low.UpdateMode = null;
                            act.StatusCode = new CS<ActStatus>(ActStatus.Active);
                        }
                        else                        //für Empty PDx
                        {                            
                            act.EffectiveTime = new IVL<TS>(pdEntry.entryRelationship.observation.effectivTime_low_value, pdEntry.entryRelationship.observation.effectivTime_low_value);
                            act.EffectiveTime.Low.NullFlavor = MARC.Everest.DataTypes.NullFlavor.Unknown;
                            act.EffectiveTime.High.NullFlavor = MARC.Everest.DataTypes.NullFlavor.Unknown;
                            act.StatusCode = new CS<ActStatus>(ActStatus.Completed);
                        }
                        act.LanguageCode = null;
//                        act.EffectiveTime.Value = null;
//                        act.EffectiveTime.High = null;

                        CD<string> c = new CD<string>();
                        c.NullFlavor = MARC.Everest.DataTypes.NullFlavor.NotApplicable;
                        act.Code = c;

                        act.EntryRelationship = new List<EntryRelationship>();
                        act.EntryRelationship.Add(entryRelationship);

                        sect.Entry.Add(entry);
                    }
                }

                //Ressourcen und Hilfsmittel
                if (sektion.HilfsmittelUndRessourcen != null)
                {
                    Section sectRUM = new Section();
                    sectRUM.TemplateId = sektion.HilfsmittelUndRessourcen.cdatemplateIDs;

                    sectRUM.Code = new CE<string>(sektion.HilfsmittelUndRessourcen.code.code,
                        sektion.HilfsmittelUndRessourcen.code.codeSystem,
                        sektion.HilfsmittelUndRessourcen.code.codeSystemName,
                        null,
                        sektion.HilfsmittelUndRessourcen.code.displayName,
                        null);
                    sectRUM.Text = sektion.HilfsmittelUndRessourcen.textHTML;
                    sectRUM.Text.Language = null;
                    sectRUM.Text.MediaType = null;

                    Component5 comp5 = new Component5(null, null, sectRUM);
                    sect.Component.Add(comp5);
                }

                //Risiken
                if (sektion.Risiko != null)
                {
                    Section sectRisk = new Section();
                    sectRisk.TemplateId = sektion.Risiko.cdatemplateIDs;
                    sectRisk.Code = new CE<string>(sektion.Risiko.code.code,
                        sektion.Risiko.code.codeSystem,
                        sektion.Risiko.code.codeSystemName,
                        null,
                        sektion.Risiko.code.displayName,
                        null);
                    sectRisk.Text = sektion.Risiko.textHTML;
                    sectRisk.Text.Language = null;
                    sectRisk.Text.MediaType = null;

                    Component5 comp5 = new Component5(null, null, sectRisk);
                    sect.Component.Add(comp5);
                }

                //if (sektion.VitalparamterEntry != null)
                //{
                //    //Wird nicht zwingend benötigt!
                //}

                //Beilagen
                if (sektion.BeilagenEntries != null)
                {
                    foreach (BeilagenEntry Beilage in sektion.BeilagenEntries)
                    {
                        ENV.ELGAObservationMedia obs = new ENV.ELGAObservationMedia();
                        obs.Value = new ED { MediaType = Beilage.value_mediaType, Representation = Beilage.value_representation, Data = Beilage.value };
                        obs.ID = new ST(Beilage.id);
                        //obs.ID = new ST("xyz");

                        obs.TemplateId = Beilage.cdatemplateIDs;

                        Entry BeilageEntry = new Entry(null, null, obs);
                        sect.Entry.Add(BeilageEntry);
                    }
                }

                Component3 comp3 = new Component3(null, null, sect);
                comp3.ContextConductionInd = null;
                structBody.Component.Add(comp3);
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituatuionsbericht.Component" + ex.ToString());
            }
        }

        private void LoadPDx()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    string PDxHTML = "<table>\r<thead>\r<tr><th>Diagnose</th><th>Lokalisierung</th><th>Zeitpunkt</th></tr></thead>\r";
                    PDxHTML += "<tbody>\r";

                    var tPDx = (from apdx in db.AufenthaltPDx
                                join pdx in db.PDX on apdx.IDPDX equals pdx.ID
                                where apdx.IDAufenthalt == ENV.IDAUFENTHALT && (apdx.EndeDatum == null || apdx.ErledigtJN == false)
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

                    int i = 0;

                    if (tPDx.Count() > 0)
                    {
                        foreach (var pdx in tPDx)
                        {
                            DateTime Start = (DateTime)pdx.Startdatum;
                            Guid Id = (Guid)pdx.ID;

                            PDxHTML += "<tr ID=\"pfdiag" + i.ToString() + "\">";
                            PDxHTML += "<td ID=\"pfdiag_diagnosis" + i.ToString() + "\">" + pdx.Klartext + "</td>";
                            PDxHTML += "<td>" + pdx.Lokalisierung + " " + pdx.LokalisierungSeite + "</td>";
                            PDxHTML += "<td>" + Start.ToString("dd.MM.yyyy") + "</td>";
                            PDxHTML += "</tr>\r";

                            PflegediagnoseEntry PDx = new PflegediagnoseEntry();
                            PDx.effectiveTime_low_value = Start;
                            PDx.id_root = new Guid(Guid.NewGuid().ToString("D").ToUpper());
                            PDx.entryRelationship.observation.id_root = Id;
                            PDx.entryRelationship.observation.text_reference = "#pfdiag" + i.ToString();
                            PDx.entryRelationship.observation.effectivTime_low_value = Start;
                            PDx.entryRelationship.observation.value_code = pdx.Code;
                            PDx.entryRelationship.observation.value_displayName = pdx.Klartext;
                            PDx.entryRelationship.observation.value_originalText_reference_value = "#pfdiag_diagnosis" + i.ToString();

                            if (Sektionen[(int)SektionOrder.Pflegediagnosen].PflegediagnosenEntrys == null)
                                Sektionen[(int)SektionOrder.Pflegediagnosen].PflegediagnosenEntrys = new List<PflegediagnoseEntry>();

                            Sektionen[(int)SektionOrder.Pflegediagnosen].PflegediagnosenEntrys.Add(PDx);
                            i++;
                        }
                    }
                    else     //Leeres Pflegediagnosenentry (Pflicht-Element)
                    {
                        Guid Id = Guid.NewGuid();

                        PDxHTML += "<tr ID=\"pfdiag" + i.ToString() + "\">";
                        PDxHTML += "<td ID=\"pfdiag_diagnosis" + i.ToString() + "\">" + "Keine Pflegediagnosen" + "</td>";
                        PDxHTML += "<td></td>";
                        PDxHTML += "<td></td>";
                        PDxHTML += "</tr>\r";

                        PflegediagnoseEntry PDx = new PflegediagnoseEntry();
                        PDx.id_root = new Guid(Guid.NewGuid().ToString("D").ToUpper());

                        PDx.entryRelationship.observation.id_root = new Guid(Guid.NewGuid().ToString("D").ToUpper());
                        PDx.entryRelationship.observation.text_reference = "#pfdiag" + i.ToString();
                        PDx.entryRelationship.observation.value_originalText_reference_value = "#pfdiag_diagnosis" + i.ToString();

                        PDx.entryRelationship.observation.code.code = "160245001";
                        PDx.entryRelationship.observation.code.displayName = "No current problems or disability";
                        PDx.entryRelationship.observation.code.codeSystem = "2.16.840.1.113883.6.96";
                        PDx.entryRelationship.observation.code.codeSystemName = "SNOMED CT";

                        if (Sektionen[(int)SektionOrder.Pflegediagnosen].PflegediagnosenEntrys == null)
                            Sektionen[(int)SektionOrder.Pflegediagnosen].PflegediagnosenEntrys = new List<PflegediagnoseEntry>();

                        Sektionen[(int)SektionOrder.Pflegediagnosen].PflegediagnosenEntrys.Add(PDx);
                        i++;
                    }

                    PDxHTML += "\r</tbody></table>";
                    Sektionen[(int)SektionOrder.Pflegediagnosen].textHTML = PDxHTML;
                    Sektionen[(int)SektionOrder.Pflegediagnosen].use = true;

                    wbDiagnosen.DocumentText = PDxHTML;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadPDx: " + ex.ToString());
            }
        }

        private void LoadRessourcenRisiken()
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

                              where apdx.IDAufenthalt == ENV.IDAUFENTHALT &&
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

                    foreach (var R in tR)
                    {
                        foreach (Sektion Sektion in Sektionen)
                        {
                            if (Sektion.code.code == R.Code)
                            {
                                Sektion.use = true;
                                if (R.Eintraggruppe == "R")
                                {
                                    if (Sektion.HilfsmittelUndRessourcen == null)
                                    {
                                        HilfsmittelRessourcen Res = new HilfsmittelRessourcen();
                                        Sektion.HilfsmittelUndRessourcen = Res;
                                    }
                                    Sektion.HilfsmittelUndRessourcen.textHTML += R.Text + "\r";
                                    SetRTFTextByTag(this.Controls, R.Code + "_RES", R.Text + "\n");
                                }

                                else if (R.Eintraggruppe == "A")
                                {
                                    if (Sektion.Risiko == null)
                                    {
                                        Risiko Ris = new Risiko();
                                        Sektion.Risiko = Ris;
                                    }
                                    Sektion.Risiko.textHTML += R.Text + "\r";
                                    SetRTFTextByTag(this.Controls, R.Code + "_RISK", R.Text + "\n");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadRessourcenRisiken: " + ex.ToString());
            }
        }

        private void LoadVitalparameter()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    string PDxHTML = "<table>\r<thead><tr><th>Name</th><th>Wert</th><th>Einheit</th><th>Zeitpunkt</th></tr></thead>";
                    PDxHTML += "<tbody>";

                    var tZusatzwerte = (from pe in db.PflegeEintrag
                                        join zw in db.ZusatzWert on pe.ID equals zw.IDObjekt
                                        join zge in db.ZusatzGruppeEintrag on zw.IDZusatzGruppeEintrag equals zge.ID
                                        join ze in db.ZusatzEintrag on zge.IDZusatzEintrag equals ze.ID
                                        where zge.AktivJN == true && (ze.ELGA_ID > 0 || ze.ID == "ERF") && pe.IDAufenthalt == ENV.IDAUFENTHALT

                                        select new
                                        {
                                            ID = zw.ID,
                                            Bezeichnung = ze.Bezeichnung,
                                            Wert = zw.Wert,
                                            Zahlenwert = zw.ZahlenWert,
                                            ZahlenwertFloat = zw.ZahlenWertFloat,
                                            Typ = ze.Typ,
                                            ELGA_Unit = ze.ELGA_Unit,
                                            ELGA_Code = ze.ELGA_Code,
                                            Zeitpunkt = pe.Zeitpunkt,
                                            Decimals = ze.MinValue,
                                            ZEID = ze.ID
                                        }).GroupBy(ze => ze.ELGA_Code).Select(g => g.OrderByDescending(pe => pe.Zeitpunkt).FirstOrDefault());
                    ;

                    int i = 1;
                    foreach (var zw in tZusatzwerte)
                    {
                        PDxHTML += "<tr ID=\"vitsig" + i.ToString() + "\">";
                        PDxHTML += "<td ID=\"vitsigtype" + i.ToString() + "\">" + zw.Bezeichnung + "</td>";

                        string Wert = "?";
                        if (zw.Typ == 1)
                            Wert = zw.Zahlenwert.ToString();
                        else if (zw.Typ == 5)
                            Wert = Math.Round((float)zw.ZahlenwertFloat, 2, MidpointRounding.AwayFromZero).ToString();
                        else if (zw.Typ == 0)
                            Wert = zw.Wert;
                        PDxHTML += "<td>" + Wert + "</td>";
                        PDxHTML += "<td>" + zw.ELGA_Unit + "</td>";
                        PDxHTML += "<td>" + zw.Zeitpunkt.ToString() + "</td>";
                        i++;
                    }

                    PDxHTML += "</tbody></table>";

                    if (i > 1)
                    {
                        Sektionen[(int)SektionOrder.Vitalparameter].use = true;
                        Sektionen[(int)SektionOrder.Vitalparameter].textHTML = PDxHTML;
                        wbVitalzeichen.DocumentText = PDxHTML;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadVitalparameter: " + ex.ToString());
            }
        }

        private void LoadMedDaten()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var tMedDaten = (from md in db.MedizinischeDaten
                                     join p in db.Patient on md.IDPatient equals p.ID
                                     join a in db.Aufenthalt on p.ID equals a.IDPatient
                                     join mt in db.MedizinischeTypen on md.MedizinischerTyp equals mt.MedizinischerTyp
                                     where a.ID == ENV.IDAUFENTHALT
                                     && mt.MedizinischerTyp != 8 && mt.MedizinischerTyp != 15
                                     && md.Von < DateTime.Now
                                     && (md.Bis > DateTime.Now || md.Bis == null)
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

                    string mdText = "";
                    foreach (var rMedDaten in tMedDaten)
                    {
                        DateTime von = (DateTime)rMedDaten.Von;
                        DateTime bis = new DateTime(1900, 1, 1);
                        if (rMedDaten.Bis != null)
                            bis = (DateTime)rMedDaten.Bis;

                        DateTime letzteVersorung = new DateTime(1900, 1, 1);
                        if (rMedDaten.LetzteVersorgung != null)
                            letzteVersorung = (DateTime)rMedDaten.LetzteVersorgung;

                        DateTime naechsteVersorgung = new DateTime(1900, 1, 1);
                        if (rMedDaten.NaechsteVersorgung != null)
                            naechsteVersorgung = (DateTime)rMedDaten.NaechsteVersorgung;

                        mdText += "- " + rMedDaten.MTBeschreibung + ":";
                        mdText += " " + von.ToString("dd.MM.yyyy") + " -";
                        if (bis > new DateTime(1900, 1, 1))
                            mdText += " " + bis.ToString("dd.MM.yyyy");

                        if (rMedDaten.Beschreibung != "")
                            mdText += ", " + rMedDaten.Beschreibung;

                        if (rMedDaten.Typ != null && !String.IsNullOrWhiteSpace(rMedDaten.Typ))
                            mdText += ", " + rMedDaten.Typ;

                        if (rMedDaten.Modell != null && !String.IsNullOrWhiteSpace(rMedDaten.Modell))
                            mdText += ", Modell=" + rMedDaten.Modell;

                        if (rMedDaten.Groesse != null && !String.IsNullOrWhiteSpace(rMedDaten.Groesse))
                            mdText += ", Größe=" + rMedDaten.Groesse;

                        if (letzteVersorung > new DateTime(1900, 1, 1))
                            mdText += "letzte Versorung " + letzteVersorung.ToString("dd.MM.yyyy");

                        if (naechsteVersorgung > new DateTime(1900, 1, 1))
                            mdText += "nächste Versorung " + naechsteVersorgung.ToString("d.MM.yyyy");

                        if (rMedDaten.AntikoaguliertJN != null)
                        {
                            if ((bool)rMedDaten.AntikoaguliertJN)
                                mdText += ", antikoaguliert";
                        }

                        mdText += "\n";
                        rtfPFMEDBEH_Text.Text = mdText;
                        CheckSektionUsed(SektionOrder.Patientenverfügung);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadMedDaten: " + ex.ToString());
            }
        }

        private void LoadRezepte()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var tRezepte = (from re in db.RezeptEintrag
                                    join med in db.Medikament on re.IDMedikament equals med.ID
                                    join ar in db.Aerzte on re.IDAerzte equals ar.ID
                                    where re.IDAufenthalt == ENV.IDAUFENTHALT
                                        && re.AbzugebenVon < DateTime.Now
                                        && re.AbzugebenBis > DateTime.Now
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
                    string rez = "Verordnungen:\n";
                    foreach (var rRezept in tRezepte)
                    {
                        DateTime von = (DateTime)rRezept.AbzugebenVon;
                        DateTime bis = (DateTime)rRezept.AbzugebenBis;
                        DateTime VoDatum = (DateTime)rRezept.DatumErstellt;

                        rez += "- " + rRezept.Bezeichnung + ", ";
                        rez += rRezept.DosierungASString;
                        //rez += " " + rRezept.Einheit;
                        //rez += " " + rRezept.Applikationsform;
                        rez += " ab " + von.ToString("dd.MM.yyyy HH:mm");
                        if (bis < new DateTime(3000, 1, 1, 23, 59, 59))
                            rez += " - " + rRezept.AbzugebenBis.ToString("dd.MM.yyyy HH:mm");

                        if (rRezept.BedarfsMedikationJN == true)
                            rez += " (EINZELVERORDUNG)";

                        if (!String.IsNullOrWhiteSpace(rRezept.Bemerkung))
                            rez += " " + rRezept.Bemerkung;

                        rez += ", verordnet: ";
                        if (!String.IsNullOrWhiteSpace(rRezept.Titel))
                            rez += " " + rRezept.Titel;

                        if (!String.IsNullOrWhiteSpace(rRezept.Vorname))
                            rez += " " + rRezept.Vorname;

                        if (!String.IsNullOrWhiteSpace(rRezept.Nachname))
                            rez += " " + rRezept.Nachname;

                        rez += " (" + rRezept.DatumErstellt.ToString("dd.MM.yyyy") + ")";
                        rez += "\n";
                        rtfPFMED_Text.Text = rez;
                        CheckSektionUsed(SektionOrder.Medikamentenverabreichung);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadRezepte: " + ex.ToString());
            }
        }

        private void LoadPatientenverfügung()
        {
            try
            {
                rtfPATVERF_Text.Text = "";

                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var rPatInfo = (from p in db.Patient
                                    join a in db.Aufenthalt on p.ID equals a.IDPatient
                                    where a.ID == ENV.IDAUFENTHALT
                                    select new
                                    {
                                        p.Nachname,
                                        p.Vorname,
                                        p.PatientenverfuegungJN,
                                        p.PatientverfuegungDatum,
                                        p.PatientenverfuegungBeachtlichJN,
                                        p.PatientverfuegungAnmerkung,
                                        Konfession = p.Konfision
                                    }).FirstOrDefault();
                    if (rPatInfo.PatientenverfuegungJN == true)
                    {
                        DateTime dt = (DateTime)rPatInfo.PatientverfuegungDatum;
                        rtfPATVERF_Text.Text += (rPatInfo.PatientenverfuegungBeachtlichJN == false ? "Beachtliche " : "Verbindliche ");
                        rtfPATVERF_Text.Text = "Patientenverfügung vom " + dt.ToString("dd.MM.yyyy") + ": " + rPatInfo.PatientverfuegungAnmerkung.ToString() + "\n";
                        Sektionen[(int)SektionOrder.Patientenverfügung].use = true;
                    }
                }

                //Freiheitsbeschr. Maßnahmen
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var tHAG = (from u in db.Unterbringung
                                where u.IDAufenthalt == ENV.IDAUFENTHALT
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

                    string txtHAG = rtfPATVERF_Text.Text + "\nFreiheitsbeschränkende Maßnahmen gem. Heimaufenthaltsgesetz\n";
                    foreach (var rHAG in tHAG)
                    {

                        bool KlientZustimmungJN = rHAG.KlientZustimmungJN != null && (bool)rHAG.KlientZustimmungJN;
                        bool PsychischekrankheitJN = rHAG.PsychischekrankheitJN != null && (bool)rHAG.PsychischekrankheitJN;
                        bool GeistigeBehinderungJN = rHAG.GeistigeBehinderungJN != null && (bool)rHAG.GeistigeBehinderungJN;
                        bool ErheblicheSelbstgefaehrdungJN = rHAG.ErheblicheSelbstgefaehrdungJN != null && (bool)rHAG.ErheblicheSelbstgefaehrdungJN;
                        bool ErheblicheFremdgefaehrdungJN = rHAG.ErheblicheFremdgefaehrdungJN != null && (bool)rHAG.ErheblicheFremdgefaehrdungJN;

                        bool EinzelfallmedikationJN_2016 = rHAG.EinzelfallmedikationJN_2016 != null && (bool)rHAG.EinzelfallmedikationJN_2016;
                        bool DauermedikationJN_2016 = rHAG.DauermedikationJN_2016 != null && (bool)rHAG.DauermedikationJN_2016;

                        bool HindernVerlassenBettSeitenteilenJN = rHAG.HindernVerlassenBettSeitenteilenJN != null && (bool)rHAG.HindernVerlassenBettSeitenteilenJN;
                        bool HindernVerlassenBettBauchgurtJN_2016 = rHAG.HindernVerlassenBettBauchgurtJN_2016 != null && (bool)rHAG.HindernVerlassenBettBauchgurtJN_2016;
                        bool HindernVerlassenBettElektronischJN_2016 = rHAG.HindernVerlassenBettElektronischJN_2016 != null && (bool)rHAG.HindernVerlassenBettElektronischJN_2016;
                        bool HindernVerlassenBettAndereJN_2016 = rHAG.HindernVerlassenBettAndereJN_2016 != null && (bool)rHAG.HindernVerlassenBettAndereJN_2016;

                        bool HindernSitzgelSitzhoseJN = (bool)rHAG.HindernSitzgelSitzhoseJN;
                        bool HindernSitzgelBauchgurtJN_2016 = rHAG.HindernSitzgelBauchgurtJN_2016 != null && (bool)rHAG.HindernSitzgelBauchgurtJN_2016;
                        bool HindernSitzgelBrustgurtJN_2016 = rHAG.HindernSitzgelBrustgurtJN_2016 != null && (bool)rHAG.HindernSitzgelBrustgurtJN_2016;
                        bool HindernSitzgelTischJN = rHAG.HindernSitzgelTischJN != null && (bool)rHAG.HindernSitzgelTischJN;
                        bool HindernSitzgelTherapietischJN = rHAG.HindernSitzgelTherapietischJN != null && (bool)rHAG.HindernSitzgelTherapietischJN;
                        bool HindernSitzgelAndereJN_2016 = rHAG.HindernSitzgelAndereJN_2016 != null && (bool)rHAG.HindernSitzgelAndereJN_2016;

                        bool ZurueckhaltensandrohungJN = rHAG.ZurueckhaltensandrohungJN != null && (bool)rHAG.ZurueckhaltensandrohungJN;
                        bool HindernBereichFesthaltenJN_2016 = rHAG.HindernBereichFesthaltenJN_2016 != null && (bool)rHAG.HindernBereichFesthaltenJN_2016;
                        bool HindernBereichVersperrterBereichJN_2016 = rHAG.HindernBereichVersperrterBereichJN_2016 != null && (bool)rHAG.HindernBereichVersperrterBereichJN_2016;
                        bool HindernBereichBarriereJN_2016 = rHAG.HindernBereichBarriereJN_2016 != null && (bool)rHAG.HindernBereichBarriereJN_2016;
                        bool ElektronischesUeberwachungJN = rHAG.ElektronischesUeberwachungJN != null && (bool)rHAG.ElektronischesUeberwachungJN;
                        bool HindernBereichVersperrtesZimmerJN_2016 = rHAG.HindernBereichVersperrtesZimmerJN_2016 != null && (bool)rHAG.HindernBereichVersperrtesZimmerJN_2016;
                        bool HindernBereichHinderAmFortbewegenJN_2016 = rHAG.HindernBereichHinderAmFortbewegenJN_2016 != null && (bool)rHAG.HindernBereichHinderAmFortbewegenJN_2016;
                        bool HindernBereichAndereJN_2016 = rHAG.HindernBereichAndereJN_2016 != null && (bool)rHAG.HindernBereichAndereJN_2016;

                        DateTime Beginn = (DateTime)rHAG.Beginn;
                        txtHAG += "Beginn: " + Beginn.ToString("dd.MM.yyyy");

                        string txtArt = "Grund der Freiheitsbeschränkung";
                        if (PsychischekrankheitJN ||
                            GeistigeBehinderungJN ||
                            ErheblicheSelbstgefaehrdungJN ||
                            ErheblicheFremdgefaehrdungJN
                           )
                        {
                            if (KlientZustimmungJN)
                            {
                                txtHAG += "\nZustimmung des einsichts- und urteilsfähigen Kienten (Freiheitseinschränkung) liegt vor.";
                                txtArt = "Grund der Freiheitseinschränkung";
                            }

                            txtHAG += "\n" + txtArt;
                            if (PsychischekrankheitJN && GeistigeBehinderungJN)
                            {
                                txtHAG += ": Psychische Krankheit und geistige Behinderung,";
                            }

                            if (PsychischekrankheitJN && !GeistigeBehinderungJN)
                            {
                                txtHAG += ": Psychische Krankheit.";
                            }

                            if (!PsychischekrankheitJN && GeistigeBehinderungJN)
                            {
                                txtHAG += ": Geistige Behinderung.";
                            }

                            if ((PsychischekrankheitJN || GeistigeBehinderungJN) && !String.IsNullOrWhiteSpace(rHAG.MedizinischeDiagnose))
                                txtHAG += " Begründung: " + rHAG.MedizinischeDiagnose;

                            if (ErheblicheSelbstgefaehrdungJN && ErheblicheFremdgefaehrdungJN)
                                txtHAG += "\nErhebliche Selbst- und Fremdgfährdung.";

                            if (ErheblicheSelbstgefaehrdungJN && !ErheblicheFremdgefaehrdungJN)
                                txtHAG += "\nErhebliche Selbstgefährdung.";

                            if (!ErheblicheSelbstgefaehrdungJN && ErheblicheFremdgefaehrdungJN)
                                txtHAG += "\nErhebliche Fremdgefährdung.";


                            if ((ErheblicheSelbstgefaehrdungJN || ErheblicheFremdgefaehrdungJN) && !String.IsNullOrWhiteSpace(rHAG.AnmerkungVerhalten_2016))
                                txtHAG += " Gefährdungsgrund: " + rHAG.AnmerkungVerhalten_2016;
                        }

                        if (!String.IsNullOrWhiteSpace(rHAG.AnmerkungGutachten_2016))
                            txtHAG += "\n" + "Ärztliches Gutachten: " + rHAG.AnmerkungGutachten_2016;

                        if (EinzelfallmedikationJN_2016 == true)
                        {
                            txtHAG += "\nEinzelfallmedikation";
                            txtHAG += (!String.IsNullOrWhiteSpace(rHAG.Einzelfallmedikation_2016) ? ": " + rHAG.Einzelfallmedikation_2016 : "");
                        }

                        if (DauermedikationJN_2016 == true)
                        {
                            txtHAG += "\nDauermedikation";
                            txtHAG += (!String.IsNullOrWhiteSpace(rHAG.Dauermedikation_2016) ? ": " + rHAG.Dauermedikation_2016 : "");
                        }

                        if (HindernVerlassenBettSeitenteilenJN ||
                            HindernVerlassenBettBauchgurtJN_2016 ||
                            HindernVerlassenBettElektronischJN_2016 ||
                            HindernVerlassenBettAndereJN_2016)
                        {
                            txtHAG += "\nHindern am Verlassen des Bettes mittels ";
                            txtHAG += (HindernVerlassenBettSeitenteilenJN ? "\n  - Seitenteilen " : "");
                            txtHAG += (HindernVerlassenBettBauchgurtJN_2016 ? "\n  - Bauchgurt " : "");
                            txtHAG += (HindernVerlassenBettElektronischJN_2016 ? "\n  - elektronischer Maßnahme " : "");
                            if (HindernVerlassenBettAndereJN_2016)
                            {
                                txtHAG += "\n  - anderer Maßnahme";
                                if (!String.IsNullOrEmpty(rHAG.HindernBettVerlassen))
                                    txtHAG += ": " + rHAG.HindernBettVerlassen;
                            }
                        }

                        if (HindernSitzgelSitzhoseJN ||
                            HindernSitzgelBauchgurtJN_2016 ||
                            HindernSitzgelBrustgurtJN_2016 ||
                            HindernSitzgelTischJN ||
                            HindernSitzgelTherapietischJN ||
                            HindernSitzgelAndereJN_2016)
                        {
                            txtHAG += "\nHindern am Verlassen von Sitzgelgenheit/Rollstuhl mittels ";
                            txtHAG += (HindernSitzgelSitzhoseJN ? "\n  - Sitzhose " : "");
                            txtHAG += (HindernSitzgelBauchgurtJN_2016 ? "\n  - Bauchgurt " : "");
                            txtHAG += (HindernSitzgelBrustgurtJN_2016 ? "\n  - Brustgurt " : "");
                            txtHAG += (HindernSitzgelTischJN ? "\n  -Tisch " : "");
                            txtHAG += (HindernSitzgelTherapietischJN ? "\n  - Therapietisch " : "");
                            if (HindernSitzgelAndereJN_2016)
                            {
                                txtHAG += "\n  - anderer Maßnahme";
                                if (!String.IsNullOrEmpty(rHAG.HindernSitzgelegenheit))
                                    txtHAG += ": " + rHAG.HindernSitzgelegenheit;
                            }
                        }

                        if (ZurueckhaltensandrohungJN ||
                            HindernBereichFesthaltenJN_2016 ||
                            HindernBereichVersperrterBereichJN_2016 ||
                            HindernBereichBarriereJN_2016 ||
                            ElektronischesUeberwachungJN ||
                            HindernBereichVersperrtesZimmerJN_2016 ||
                            HindernBereichHinderAmFortbewegenJN_2016 ||
                            HindernBereichAndereJN_2016)
                        {
                            txtHAG += "\nHindern am Verlassen eines Bereichs mittels ";
                            txtHAG += (ZurueckhaltensandrohungJN ? "\n  - Zurückhalten/Androhung des Zurückhaltens " : "");
                            txtHAG += (HindernBereichFesthaltenJN_2016 ? "\n  - Körperlicher Zugriff/Festhalten " : "");
                            txtHAG += (HindernBereichVersperrterBereichJN_2016 ? "\n  - versperrter Bereich " : "");
                            txtHAG += (HindernBereichBarriereJN_2016 ? "\n  - Tür/Raumgestaltung, Barierre " : "");
                            txtHAG += (ElektronischesUeberwachungJN ? "\n  - Desorientiertenfürsorgesystem/Sensor " : "");
                            txtHAG += (HindernBereichVersperrtesZimmerJN_2016 ? "\n  - Versperrtes Zimmer " : "");
                            txtHAG += (HindernBereichHinderAmFortbewegenJN_2016 ? "\n  - Hindern am Fortbewegen mit dem Rollstuhl (Bremsen, ..) " : "");
                            if (HindernSitzgelAndereJN_2016)
                            {
                                txtHAG += "\n  - anderer Maßnahme";
                                if (!String.IsNullOrEmpty(rHAG.BaulicheMassnahmen))
                                    txtHAG += ": " + rHAG.BaulicheMassnahmen;
                            }
                        }
                        txtHAG += "\n\n";
                        rtfPATVERF_Text.Text = txtHAG;
                        Sektionen[(int)SektionOrder.Patientenverfügung].use = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadPatientenverfügung: " + ex.ToString());
            }
        }

        private void LoadPflegeUndBetreuungsumfang()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    //Pflegestufe
                    var rPatInfo = (from p in db.Patient
                                    join a in db.Aufenthalt on p.ID equals a.IDPatient
                                    join pps in db.PatientPflegestufe on p.ID equals pps.IDPatient
                                    join ps in db.Pflegegeldstufe on pps.IDPflegegeldstufe equals ps.ID
                                    where a.ID == ENV.IDAUFENTHALT
                                    orderby pps.GenehmigungDatum descending
                                    select new
                                    {
                                        p.Nachname,
                                        p.Vorname,
                                        ps.Bezeichnung,
                                        pps.GenehmigungDatum
                                    }).FirstOrDefault();

                    if (rPatInfo != null && !String.IsNullOrWhiteSpace(rPatInfo.Bezeichnung))
                    {
                        DateTime dt = (DateTime)rPatInfo.GenehmigungDatum;
                        rtfPUBUMF_Text.Text += "Letzte genehmigte Pflegestufe: " + rPatInfo.Bezeichnung + " mit Bescheiddatum vom " + dt.ToString("dd.MM.yyyy") + "\r\n";
                        Sektionen[(int)SektionOrder.PflegeUndBetreuungsumfang].use = true;
                    }

                    //Rezeptgebührenbefreiung
                    var rPatMedDaten = (from p in db.Patient
                                        join a in db.Aufenthalt on p.ID equals a.IDPatient
                                        where a.ID == ENV.IDAUFENTHALT
                                        select new
                                        {
                                            p.ID,
                                            p.Datenschutz,
                                            p.DNR,
                                            p.Palliativ,
                                            p.KZUeberlebender,

                                            p.RezeptgebuehrbefreiungJN,
                                            p.RezGebBef_RegoJN,
                                            p.RezGebBef_RegoAb,
                                            p.RezGebBef_RegoBis,
                                            p.RezGebBef_UnbefristetJN,
                                            p.RezGebBef_BefristetJN,
                                            p.RezGebBef_BefristetAb,
                                            p.RezGebBef_BefristetBis,
                                            p.RezGebBef_WiderrufJN,
                                            p.RezGebBef_WiderrufGrund,
                                            p.RezGebBef_SachwalterJN,
                                            p.RezGebBef_Anmerkung,

                                            p.Geburtsdatum
                                        }).First();

                    if (rPatMedDaten.RezeptgebuehrbefreiungJN)
                    {
                        PMDS.Global.db.ERSystem.PMDSBusinessUI bUI = new PMDS.Global.db.ERSystem.PMDSBusinessUI();
                        string TitleRezeptgebührenbefreit = "";
                        string InfoRezeptgebührenbefreit = "";
                        bool bIsRezeptgebührenbefreit = bUI.showInfoRezeptgebührbefreiungInfo(
                            rPatMedDaten.RezeptgebuehrbefreiungJN,
                            rPatMedDaten.RezGebBef_RegoJN,
                            rPatMedDaten.RezGebBef_RegoAb,
                            rPatMedDaten.RezGebBef_RegoBis,
                            rPatMedDaten.RezGebBef_UnbefristetJN,
                            rPatMedDaten.RezGebBef_BefristetJN,
                            rPatMedDaten.RezGebBef_BefristetAb,
                            rPatMedDaten.RezGebBef_BefristetBis,
                            rPatMedDaten.RezGebBef_WiderrufJN,
                            rPatMedDaten.RezGebBef_WiderrufGrund,
                            rPatMedDaten.RezGebBef_SachwalterJN,
                            rPatMedDaten.RezGebBef_Anmerkung,
                            ref TitleRezeptgebührenbefreit, ref InfoRezeptgebührenbefreit, false);
                        rtfPUBUMF_Text.Text += InfoRezeptgebührenbefreit + "\r\n";
                        Sektionen[(int)SektionOrder.PflegeUndBetreuungsumfang].use = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadPatientenverfügung: " + ex.ToString());
            }
        }

        private void LoadBeilagen() //alle pdf-Dokumente im Archivordner ELGAPflegesituationsbericht anhängen
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

                                     where auf.ID == ENV.IDAUFENTHALT && ordner.Bezeichnung == "ELGAPflegesituationsbericht" && dok.DateinameTyp == ".pdf"
                                     && (dokein.GültigVon == null || dokein.GültigVon <= DateTime.Now)
                                     && (dokein.GültigBis == null || dokein.GültigBis >= DateTime.Now)

                                     select new
                                     {
                                         dokein.Bezeichnung,
                                         dok.Archivordner,
                                         dok.DateinameArchiv,
                                         refObject = dok.ID,
                                         dok.DateinameOrig,
                                         dokein.Notiz
                                     });

                    if (tBeilagen.Count() > 0)
                    {
                        int iCountBeilagen = 0;

                        foreach (var rBeilage in tBeilagen)
                        {
                            string path = Path.Combine(ENV.ArchivPath, rBeilage.Archivordner, rBeilage.DateinameArchiv);
                            if (File.Exists(path))
                            {
                                iCountBeilagen++;
                                UltraListViewItem it = new UltraListViewItem(rBeilage.Bezeichnung, new object[] { Path.Combine( ENV.ArchivPath, rBeilage.Archivordner), rBeilage.DateinameArchiv, (Guid)rBeilage.refObject, rBeilage.DateinameOrig, rBeilage.Notiz });
                                it.Key = iCountBeilagen.ToString();
                                it.Tag = rBeilage.Bezeichnung;
                                it.CheckState = CheckState.Unchecked;
                                it.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_PDF, 32, 32);
                                lvBeilagen.Items.Add(it);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadBeilagen: " + ex.ToString());
            }
        }

        //------------------------------------ Vorbereitete Struktur in CDA-component übertragen -----------------------------------------
        private void CreateCDAFachlicheSektionen()
        {
            try
            {
                compSektionen = new Component2();
                structBody = new StructuredBody();

                foreach (Sektion sektion in Sektionen)
                {
                    if (sektion.use)
                    {
                        CDACreateComponent3(sektion);
                    }
                }

                compSektionen.SetBodyChoice(structBody);
                ccda.Component = new Component2();
                ccda.Component = compSektionen;
                ccda.Component.ContextConductionInd = null;
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.CreateCDA: " + ex.ToString());
            }
        }

        public static void PrintCDA()
        {
            Stream s = null;
            try
            {
                using (MARC.Everest.Xml.XmlStateWriter xsw = new XmlStateWriter(XmlWriter.Create("C:\\temp\\EverestPoC.xml", new XmlWriterSettings() { Indent = true, ConformanceLevel = ConformanceLevel.Document })))
                {
                    //fmtr.AddFormatterAssembly(Assembly.LoadFile(@"C:\Entwicklung\project.PMDS\PMDS.Main\Dlls\MARC.Everest.RMIM.UV.CDAr2.dll"));
                    //fmtr.BuildCache(new Type[] { // Using Build Cache will greatly increase performance
                    //                             typeof(PRPA_IN201305UV02),
                    //                             typeof(PRPA_IN201309UV02)
                    //                         });

                    ENV.ELGAFormatter.Graph(xsw, ccda);
                    xsw.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.PrintCDA: " + ex.ToString());
            }
            finally
            {
                if (s != null)
                    s.Close();
            }
        }

        private void SetRTFTextHTML(object contRTF)
        {
            try
            {
                if (contRTF.GetType() == typeof(System.Windows.Forms.RichTextBox))
                {
                    System.Windows.Forms.RichTextBox cRtf = (System.Windows.Forms.RichTextBox)contRTF;

                    if (cRtf.Tag != null && cRtf.Tag.GetType() == typeof(RTFTag))
                    {
                        RTFTag cTag = (RTFTag)cRtf.Tag;

                        if (cTag.Typ == RTFTyp.Text)
                        {
                            Sektionen[(int)(SektionOrder)cTag.Order].textHTML = cRtf.Text;
                        }
                        else if (cTag.Typ == RTFTyp.Res)
                        {
                            if (Sektionen[(int)(SektionOrder)cTag.Order].HilfsmittelUndRessourcen == null)
                                Sektionen[(int)(SektionOrder)cTag.Order].HilfsmittelUndRessourcen = new HilfsmittelRessourcen();

                            Sektionen[(int)(SektionOrder)cTag.Order].HilfsmittelUndRessourcen.textHTML = cRtf.Text;

                            if (String.IsNullOrWhiteSpace(cRtf.Text))
                                Sektionen[(int)(SektionOrder)cTag.Order].HilfsmittelUndRessourcen = null;
                        }
                        else if (cTag.Typ == RTFTyp.Risk)
                        {
                            if (Sektionen[(int)(SektionOrder)cTag.Order].Risiko == null)
                                Sektionen[(int)(SektionOrder)cTag.Order].Risiko = new Risiko();
                            Sektionen[(int)(SektionOrder)cTag.Order].Risiko.textHTML = cRtf.Text;

                            if (String.IsNullOrWhiteSpace(cRtf.Text))
                                Sektionen[(int)(SektionOrder)cTag.Order].Risiko = null;

                        }
                        CheckSektionUsed((SektionOrder)cTag.Order);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.SetRTFTextHTML: " + ex.ToString());
            }
        }

        private void CheckSektionUsed(SektionOrder Sektion)
        {
            switch (Sektion)
            {
                case SektionOrder.Brieftext:
                    Sektionen[(int)SektionOrder.Brieftext].use = !String.IsNullOrWhiteSpace(rtfBRIEFT_Text.Text);
                    break;

                case SektionOrder.Mobilität:
                    Sektionen[(int)SektionOrder.Mobilität].use = !String.IsNullOrWhiteSpace(rtfPFMOB_Text.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfPFMOB_Res.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfPFMOB_Risk.Text);
                    break;

                case SektionOrder.KörperpflegeUndKleiden:
                    Sektionen[(int)SektionOrder.KörperpflegeUndKleiden].use = !String.IsNullOrWhiteSpace(rtfPFKLEI_Text.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfPFKLEI_Res.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfPFKLEI_Risk.Text);
                    break;

                case SektionOrder.Ernährung:
                    Sektionen[(int)SektionOrder.Ernährung].use = !String.IsNullOrWhiteSpace(rtfPFERN_Text.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfPFERN_Res.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfPFERN_Risk.Text);
                    break;

                case SektionOrder.Ausscheidung:
                    Sektionen[(int)SektionOrder.Ausscheidung].use = !String.IsNullOrWhiteSpace(rtfPFAUS_Text.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfPFAUS_Res.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfPFAUS_Risk.Text);
                    break;

                case SektionOrder.Hautzustand:
                    Sektionen[(int)SektionOrder.Hautzustand].use = !String.IsNullOrWhiteSpace(rtfPFHAUT_Text.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfPFHAUT_Res.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfPFHAUT_Risk.Text);
                    break;

                case SektionOrder.Atmung:
                    Sektionen[(int)SektionOrder.Atmung].use = !String.IsNullOrWhiteSpace(rtfPFATM_Text.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfPFATM_Res.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfPFATM_Risk.Text);
                    break;

                case SektionOrder.Schlaf:
                    Sektionen[(int)SektionOrder.Schlaf].use = !String.IsNullOrWhiteSpace(rtfPFSCHL_Text.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfPFSCHL_Res.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfPFSCHL_Risk.Text);
                    break;

                case SektionOrder.Schmerz:
                    Sektionen[(int)SektionOrder.Schmerz].use = !String.IsNullOrWhiteSpace(rtfPFSCHMERZ_Text.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfPFSCHMERZ_Res.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfPFSCHMERZ_Risk.Text);
                    break;

                case SektionOrder.OrientierungUndBewusstseinslage:
                    Sektionen[(int)SektionOrder.OrientierungUndBewusstseinslage].use = !String.IsNullOrWhiteSpace(rtfPFORIE_Text.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfPFORIE_Res.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfPFORIE_Risk.Text);
                    break;

                case SektionOrder.SozialeUmständeUndVerhalten:
                    Sektionen[(int)SektionOrder.SozialeUmständeUndVerhalten].use = !String.IsNullOrWhiteSpace(rtfPFSOZV_Text.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfPFSOZV_Res.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfPFSOZV_Risk.Text);
                    break;

                case SektionOrder.Kommunikation:
                    Sektionen[(int)SektionOrder.Kommunikation].use = !String.IsNullOrWhiteSpace(rtfPFKOMM_Text.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfPFKOMM_Res.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfPFKOMM_Risk.Text);
                    break;

                case SektionOrder.RollenwahnehmungUndSinnfindung:
                    Sektionen[(int)SektionOrder.RollenwahnehmungUndSinnfindung].use = !String.IsNullOrWhiteSpace(rtfPFROLL_Text.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfPFROLL_Res.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfPFROLL_Risk.Text);
                    break;

                case SektionOrder.PflegerelvanteInforamtionenZurMedizinischenBehandlung:
                    Sektionen[(int)SektionOrder.PflegerelvanteInforamtionenZurMedizinischenBehandlung].use = !String.IsNullOrWhiteSpace(rtfPFMEDBEH_Text.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfPFMEDBEH_Risk.Text);
                    break;

                case SektionOrder.Anmerkungen:
                    Sektionen[(int)SektionOrder.Anmerkungen].use = !String.IsNullOrWhiteSpace(rtfANM_Text.Text) ||
                                                                 !String.IsNullOrWhiteSpace(rtfANM_Risk.Text);
                    break;

                case SektionOrder.PflegeUndBetreuungsumfang:
                    Sektionen[(int)SektionOrder.PflegeUndBetreuungsumfang].use = !String.IsNullOrWhiteSpace(rtfPUBUMF_Text.Text);
                    break;

                case SektionOrder.Patientenverfügung:
                    Sektionen[(int)SektionOrder.Patientenverfügung].use = !String.IsNullOrWhiteSpace(rtfPATVERF_Text.Text);
                    break;

                case SektionOrder.AbschliessendeBemerkungen:
                    Sektionen[(int)SektionOrder.AbschliessendeBemerkungen].use = !String.IsNullOrWhiteSpace(rtfABBEM_Text.Text);
                    break;
            }
        }

        private void SetRTFTextByTag(Control.ControlCollection controls, string Tag, string Text)
        {
            foreach (Control c in controls)
            {
                if (c.GetType() == typeof(System.Windows.Forms.RichTextBox))
                {
                    if (c.Tag.GetType() == typeof(RTFTag))
                    {
                        RTFTag cTag = (RTFTag)c.Tag;
                        if (cTag.Tag.Equals(Tag, StringComparison.OrdinalIgnoreCase))
                        {
                            System.Windows.Forms.RichTextBox cText = (System.Windows.Forms.RichTextBox)c;
                            cText.Text += Text;
                            Application.DoEvents();
                            return;
                        }
                    }
                }

                if (c.HasChildren)
                    SetRTFTextByTag(c.Controls, Tag, Text); //Rekursiver Aufruf
            }
        }

        private void SetWBTextByTag(Control.ControlCollection controls, string Tag, string Text)
        {
            foreach (Control c in controls)
            {
                if (c.Tag != null && c.Tag.ToString().Equals(Tag, StringComparison.OrdinalIgnoreCase))
                {
                    if (c.GetType() == typeof(System.Windows.Forms.WebBrowser))
                    {
                        System.Windows.Forms.WebBrowser cText = (System.Windows.Forms.WebBrowser)c;
                        cText.DocumentText += Text;
                        Application.DoEvents();
                        return;
                    }
                }

                if (c.HasChildren)
                    SetWBTextByTag(c.Controls, Tag, Text); //Rekursiver Aufruf
            }
        }

        private void rtfBrieftext_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFMOB_Text_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFMOB_Res_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFMOB_Risk_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFKLEI_Text_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFKLEI_Res_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFKLEI_Risk_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFERN_Text_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFERN_Res_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFERN_Risk_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFAUS_Text_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFAUS_Res_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFAUS_Risk_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFHAUT_Text_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFHAUT_Res_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFHAUT_Risk_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFATM_Text_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFATM_Res_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFATM_Risk_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFSCHL_Text_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFSCHL_Res_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFSCHL_Risk_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFSCHMERZ_Text_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFSCHMERZ_Res_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFSCHMERZ_Risk_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFORIE_Text_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFORIE_Res_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFORIE_Risk_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFSOZV_Text_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFSOZV_Res_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFSOZV_Risk_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFKOMM_Text_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFKOMM_Res_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFKOMM_Risk_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFROLL_Text_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFROLL_Res_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFROLL_Risk_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFMEDBEH_Text_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFMED_Text_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFLEGE_Text_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfANM_Text_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPATVERF_Text_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfABBEM_Text_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFMEDBEH_Risk_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfPFMED_Risk_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void rtfANM_Risk_TextChanged(object sender, EventArgs e)
        {
            SetRTFTextHTML(sender);
        }

        private void lvBeilagen_ItemCheckStateChanged(object sender, ItemCheckStateChangedEventArgs e)
        {
            try
            {
                UltraListView lvSender = (UltraListView)sender;
                Sektionen[(int)SektionOrder.Beilagen].BeilagenEntries = null;

                string BeilagenHiddenText = "<table><thead><tr><th>Beilagen</th><th>Dokument</th></tr></thead><tbody>";
                int iCountBeilagen = 0;
                int iSizeTotal = 0;
                int iMaxSize = 8000000;
                string sMaxSize = (iMaxSize / 1000).ToString();

                foreach (UltraListViewItem rBeilage in lvSender.Items)
                {
                    if (rBeilage.CheckState == CheckState.Checked)
                    {
                        string path = Path.Combine(rBeilage.SubItems["Archivordner"].Value.ToString(), rBeilage.SubItems["DateinameArchiv"].Value.ToString());
                        if (File.Exists(path))
                        {
                            using (StreamReader streamReader = new StreamReader(path))
                            {

                                List<BeilagenEntry> Beilagenliste = new List<BeilagenEntry>();
                                BeilagenEntry Beilage = new BeilagenEntry();
                                Beilage.value = System.Text.Encoding.UTF8.GetBytes(streamReader.ReadToEnd());

                                iSizeTotal += Beilage.value.Length;

                                if (iSizeTotal < iMaxSize)
                                {
                                    iCountBeilagen++;
                                    string refObject = rBeilage.SubItems["ID"].Value.ToString();
                                    string txtObject = rBeilage.Text;
                                    BeilagenHiddenText += "<tr><td>" + txtObject + "</td><td><renderMultiMedia referencedObject = \"" + refObject + "\"/></td></tr></tbody>";
                                    Beilage.id = refObject;
                                    Beilage.referencedObject = refObject;

                                    if (Sektionen[(int)SektionOrder.Beilagen].BeilagenEntries == null)
                                        Sektionen[(int)SektionOrder.Beilagen].BeilagenEntries = new List<BeilagenEntry>();

                                    Sektionen[(int)SektionOrder.Beilagen].BeilagenEntries.Add(Beilage);
                                }
                                else
                                {
                                    QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB("Die maximale Größe aller Anhänge darf " + sMaxSize + " kB nicht überschreiten!", MessageBoxButtons.OK, "Wichtiger Hinweis!");
                                    rBeilage.CheckState = CheckState.Unchecked;
                                }
                            }
                        }
                    }
                    BeilagenHiddenText += "</tbody></table>";

                    if (iCountBeilagen > 0)
                    {
                        Sektionen[(int)SektionOrder.Beilagen].textHTML = BeilagenHiddenText;
                        Sektionen[(int)SektionOrder.Beilagen].use = true;
                    }
                    else
                    {
                        Sektionen[(int)SektionOrder.Beilagen].textHTML = "";
                        Sektionen[(int)SektionOrder.Beilagen].use = false;
                    }
                }
                lblSize.Text = (Math.Round((float)iSizeTotal / 1000, 1)).ToString() + " kB von max. " + sMaxSize + " kB benutzt.";
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.lvBeilagen_ItemCheckStateChanged: " + ex.ToString());
            }
        }

        public void btnGenerate_Click(object sender, EventArgs e)
        {
            //Headerdaten in CDA-Dokument schreiben
            InitCDA();
            InitKlient();
            InitAuthor();
            InitVerwahrer();
            InitEmpfaenger();
            InitRechtlicherUnterzeichner();
            InitAnsprechperson();
            InitHausarzt();
            InitKontaktpersonen();

            CreateCDAFachlicheSektionen();
            PrintCDA();
        }

        private void btnAddBeilageFrei_Click(object sender, EventArgs e)
        {
            int iCountBeilagen = lvBeilagen.Items.Count;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Environment.SpecialFolder.DesktopDirectory.ToString();
            fileDialog.Title = "Bitte wählen Sie eine Beilage aus";
            fileDialog.DefaultExt = "pdf";
            fileDialog.Filter = "PDF-Dateien|*.pdf";
            fileDialog.CheckFileExists = true;
            fileDialog.CheckPathExists = true;
            fileDialog.Multiselect = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in fileDialog.FileNames)
                {
                    iCountBeilagen++;
                    UltraListViewItem it = new UltraListViewItem(Path.GetFileNameWithoutExtension(file), new object[] { Path.GetDirectoryName(file), Path.GetFileName(file), Guid.NewGuid().ToString().ToUpper(), Path.GetFileName(file), "" });
                    it.Key = iCountBeilagen.ToString();
                    it.Tag = Path.GetFileNameWithoutExtension(file);
                    it.CheckState = CheckState.Unchecked;
                    it.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_PDF, 32, 32);
                    lvBeilagen.Items.Add(it);
                }
            }
        }

        private SET<AD> NewAdress(PostalAddressUse Adressart, string ZIP, string City, string Street, string State, string Country)
        {
            try
            {
                SET<AD> Addr = new SET<AD>(
                        new AD(Adressart,
                            new ADXP[]{
                            new ADXP(Street, AddressPartType.StreetAddressLine),
                            new ADXP(City, AddressPartType.City),
                            new ADXP(ZIP, AddressPartType.PostalCode),
                            new ADXP(Country, AddressPartType.Country)}));
                return Addr;
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.CDABAL.CDA.NewAdress: " + ex.ToString());
            }
        }

        private void ReadAllELGACodes()
        {
            try
            {
                ccode code = new ccode();

                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var codes = (from al in db.AuswahlListe
                                 join alg in db.AuswahlListeGruppe on al.IDAuswahlListeGruppe equals alg.ID
                                 where alg.ElgaJN == true
                                 select new
                                 {
                                     al.ID,
                                     al.ELGA_Code,
                                     al.ELGA_CodeSystem,
                                     al.ELGA_DisplayName,
                                     al.ELGA_ID,
                                     al.ELGA_Version,
                                     IDAuswahllisteGruppe = alg.ID,
                                     al.Bezeichnung
                                 }
                                ).ToList();

                    foreach (var c in codes)
                    {
                        ELGACodes.Add(new ccode { code = c.ELGA_Code, codeSystem = c.ELGA_CodeSystem, displayName = c.ELGA_DisplayName, IDAuswahllisteGruppe = c.IDAuswahllisteGruppe, Bezeichnung = c.Bezeichnung });
                    }

                }
            }
            catch (Exception ex)
            { 
                throw new Exception("WCFServicePMDS.CDABAL.CDA.ReadAllELGACodes: " + ex.ToString());
            }
        }

        private ccode SearchELGACode(string sBezeichnung, string sAuswahllisteGruppe)
        {
            try
            {
                return ELGACodes.Where(x => x.Bezeichnung == sBezeichnung && x.IDAuswahllisteGruppe == sAuswahllisteGruppe).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.CDABAL.CDA.SearchELGACode: " + ex.ToString());
            }
        }

    }
}