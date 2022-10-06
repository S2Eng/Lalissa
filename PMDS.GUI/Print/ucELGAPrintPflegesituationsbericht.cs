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
using PMDS.Global;
using System.Xml;
using System.IO;
using Infragistics.Win.UltraWinListView;

using MARC.Everest.DataTypes.Interfaces;
using MARC.Everest.RMIM.UV.CDAr2.POCD_MT000040UV;
using MARC.Everest.RMIM.UV.CDAr2.Vocabulary;
using MARC.Everest.Xml;
using MARC.Everest.DataTypes;

using System.Text.RegularExpressions;
using Syncfusion.Pdf.Parsing;

namespace PMDS.GUI.Print
{
    public partial class ucELGAPrintPflegesituationsbericht : UserControl
    {
        public eStatusResult ReturnCode { get; set; } = eStatusResult.Ok;

        private DateTime dNow = DateTime.Now;
        private System.Globalization.CultureInfo currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
        private Guid IDEmpfaenger { get; set; }
        private Guid IDAufenthalt { get; set; }
        public string sFileName { get; set; }
        private List<ccode> ELGACodes = new List<ccode>();
        private PMDS.GUI.Print. cELGADB.Organistion Klinik = new cELGADB.Organistion();
        private cELGADB.Person Klient = new cELGADB.Person();
        private cELGADB.Aufenthalt Aufenthalt = new cELGADB.Aufenthalt();
        private List<Sektion> Sektionen = new List<Sektion>();
        private List<cELGADB.Person> lSachwalter = new List<cELGADB.Person>();
        private cELGADB.Person Benutzer = new cELGADB.Person();
        private cELGADB.Organistion Empfaenger = new cELGADB.Organistion();
        private cELGADB.Organistion Hausarzt = new cELGADB.Organistion();
        private List<cELGADB.Person> Kontaktpersonen = new List<cELGADB.Person>();
        private cELGADB.Organistion Krankenkasse = new cELGADB.Organistion();

        private List<cELGADB.PDX> lPDX = new List<cELGADB.PDX>();
        private List<cELGADB.RessourceRisiko> lRessourcenRisiken = new List<cELGADB.RessourceRisiko>();
        private List<cELGADB.Vitalparameter> lVitalparameter = new List<cELGADB.Vitalparameter>();
        private List<cELGADB.MedizinischeDaten> lMedizinischeDaten = new List<cELGADB.MedizinischeDaten>();
        private List<cELGADB.Rezept> lRezepte = new List<cELGADB.Rezept>();
        private cELGADB.Patientenverfügung Patientenverfügung = new cELGADB.Patientenverfügung();
        private cELGADB.Pflegestufe Pflegestufe = new cELGADB.Pflegestufe();
        private List<cELGADB.Freiheitsbeschränkung> lFreiheitsbeschränkungen = new List<cELGADB.Freiheitsbeschränkung>();
        private cELGADB.Rezeptgebührenbefreiung Rezeptgebührenbefreiung = new cELGADB.Rezeptgebührenbefreiung();
        private List<cELGADB.Beilage> lBeilagen = new List<cELGADB.Beilage>();

        private MemoryStream msXML = new MemoryStream();                        //Ausgabe für Webbrowser
        public static MemoryStream msPSB { get; set; } = new MemoryStream();    //MemoryStream für Archiv
        public string sMessages { get; set; } = "";
        public string sWarnings { get; set; } = "";

        public enum eStatusResult
        {
            Ok = 1,             //Alles OK. Keine Hinweise.
            Messages = 2,       //OK, aber Hinweise (z.B. keine PDx gefunden, kein Hausarzt, ..)
            NoELGA = 3,         //Klient ist abgemeldet oder SOO. Kein PSB möglich -> Weiter zu PBS.
            MissingData = 4     //Datenprobleme, die einen PSB verhindern. Abbruch oder weiter zu PBS.
        }

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
            Beilagen = 22,
            None = 100
        }

        private enum RTFTyp
        {
            Text = 1,
            Res = 2,
            Risk = 3,
            None = 100
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
            public ccode cdaCode = new ccode { code = "28651-8", displayName = "Nurse Transfer note", codeSystem = "2.16.840.1.113883.6.1", codeSystemName = "LOINC" };
            public List<II> cdatemplateIDs = new List<II> { new II { Root="1.2.40.0.34.11.1" , AssigningAuthorityName = "ELGA" },
                                                            new II { Root="1.2.40.0.34.11.12", AssigningAuthorityName="ELGA" },
                                                            new II { Root="1.2.40.0.34.11.12.0.3", AssigningAuthorityName="ELGA" }
                                                          };
            public CE<x_BasicConfidentialityKind>  ccdaConfidentialityCode = new CE<x_BasicConfidentialityKind>(x_BasicConfidentialityKind.Normal, "2.16.840.1.113883.5.25", "HL7:Confidentiality", null);
            public string ccdaConfidentialityCodeDisplayName = "normal";
            public CS<string> ccdaLanguageCode = new CS<string>("de-AT");
        }

        private class ccode
        {
            public string code;
            public string displayName;
            public string codeSystem = "1.2.40.0.34.5.40";
            public string codeSystemName = "ELGA_Sections";
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
            public string sValue = "";
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

        private class VitalparameterEntryComponent
        {
            public LIST<II> cdatemplateIDs = new LIST<II> { new II { Root = "1.2.40.0.34.11.1.3.4" , AssigningAuthorityName = "ELGA" },
                                                          new II { Root="1.3.6.1.4.1.19376.1.5.3.1.4.13", AssigningAuthorityName="IHE PCC" },
                                                          new II { Root="1.3.6.1.4.1.19376.1.5.3.1.4.13.2", AssigningAuthorityName="IHE PCC" },
                                                          new II { Root="2.16.840.1.113883.10.20.1.31", AssigningAuthorityName="HL7 CCD" }
                                                        };
            public string id_root;
            public ccode code = new ccode();
            public string text_reference;
            public string originaltext_reference;
            public string statusCode_code = "completed";
            public string value_xsi_type = "PQ";
            public string value_value;
            public string value_unit;
            public DateTime effectivetime;
        }

        private class VitalparameterEntry
        {
            public LIST<II> cdatemplateIDs = new LIST<II> { new II { Root = "1.2.40.0.34.11.1.3.3", AssigningAuthorityName = "ELGA" },
                                                            new II { Root="1.3.6.1.4.1.19376.1.5.3.1.4.13.1", AssigningAuthorityName="IHE PCC" },
                                                            new II { Root="2.16.840.1.113883.10.20.1.32", AssigningAuthorityName="HL7 CCD" },
                                                            new II { Root="2.16.840.1.113883.10.20.1.35", AssigningAuthorityName="HL7 CCD" },
                                                          };
            public Guid root;
            public ccode code = new ccode { code = "46680005", codeSystem = "2.16.840.1.113883.6.96", codeSystemName = "SNOMED CT", displayName = "Vital signs" };
            public CS<ActStatus> statusCode_code = new CS<ActStatus>(ActStatus.Completed);
            public List<VitalparameterEntryComponent> components = new List<VitalparameterEntryComponent>();
        }

        private class Risiko
        {
            public LIST<II> cdatemplateIDs = new LIST<II> { new II { Root = "1.2.40.0.34.11.1.2.8", AssigningAuthorityName = "ELGA" } };
            public string title = "Risiken";
            public ccode code = new ccode { code = "51898-5", displayName = "Risk factors", codeSystem = "2.16.840.1.113883.6.1", codeSystemName = "LOINC" };
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
            public VitalparameterEntry VitalparamterEntry;
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

        private cELGADB.cParameters pDB = new cELGADB.cParameters();

        public void Init(Guid pIDAufenthalt, Guid pIDEmpfaenger, string pFileName)
        {
            try
            {
                pDB.IDAufenthalt = pIDAufenthalt;
                pDB.IDEmpfänger = pIDEmpfaenger;
                pDB.dNow = dNow;
                pDB.IDUser = ENV.USERID;

                sFileName = (String.IsNullOrWhiteSpace(pFileName) ? Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()) : pFileName);
                Patagames.Pdf.Net.PdfCommon.Initialize(ENV.PdfiumKey);

                ReadAllELGACodes();
                ccda = new ClinicalDocument();

                //Headerdaten aus DB lesen
                cELGADB.LoadKlinik(ref Klinik, pDB);
                cELGADB.LoadKlient(ref Klient, pDB);
                cELGADB.LoadAufenthalt(ref Aufenthalt, pDB);
                cELGADB.LoadSachwalter(ref lSachwalter, pDB);
                cELGADB.LoadBenutzer(ref Benutzer, pDB);
                cELGADB.LoadEmfaenger(ref Empfaenger, pDB);
                cELGADB.LoadHausarzt(ref Hausarzt, pDB);
                cELGADB.LoadKontaktpersonen(ref Kontaktpersonen, pDB);
                cELGADB.LoadKrankenkasse(ref Krankenkasse, pDB);

                //Sektionsdaten aus DB lesen
                cELGADB.LoadPDX(ref lPDX, pDB);
                cELGADB.LoadRessourcenRisiken(ref lRessourcenRisiken, pDB);
                cELGADB.LoadVitalparameter(ref lVitalparameter, pDB);
                cELGADB.LoadMedizinischeDaten(ref lMedizinischeDaten, pDB);
                cELGADB.LoadRezepte(ref lRezepte, pDB);
                cELGADB.LoadPatientenverfügung(ref Patientenverfügung, pDB);
                cELGADB.LoadPflegestufe(ref Pflegestufe, pDB);
                cELGADB.LoadFreiheitsbeschränkungen(ref lFreiheitsbeschränkungen, pDB);
                cELGADB.LoadRezeptgebührenbefreiung(ref Rezeptgebührenbefreiung, pDB);
                cELGADB.LoadBeilagen(ref lBeilagen, pDB);

                CheckData();

                if (ReturnCode != eStatusResult.MissingData)
                {
                    //Oberfläche und Strukturen vorbereiten
                    InitRTFTags();
                    InitSektionen();

                    //Klassen für fachliche Sektionen vorbereiten
                    PreparePDx();
                    PrepareRessourcenRisiken();
                    PrepareVitalparameter();
                    PrepareMedDaten();
                    PrepareRezepte();
                    PreparePatientenverfügung();
                    PreparePflegeUndBetreuungsumfang();
                    PrepareBeilagen();
                }
            }
            catch (IOException e)
            {
                string problem = "The Temporary Folder is full.";
                string message = "PMDS hat festgestellt, dass das lokale, temporäre Verzeichnis voll ist. \n" +
                                 "Dies führt zu Fehlfunktionen im PMDS.\n" +
                                 "Bitte löschen Sie alle nicht benötigten temporären Dateien im Verzeichnis (%TEMP%) and versuchen Sie es erneut.";

                MessageBox.Show(message, caption: problem);
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.Init: " + ex.ToString());
            }
            finally
            {
                //if (sFileName != null) File.Delete(sFileName);
            }
        }

        public void ShowTab()
        {
            try
            {
                baseTabControl1.TabIndex = 6;
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.ShowTab: " + ex.ToString());
            }

        }

        private void CheckData()
        {
            try
            {
                int ErrorLevel = 1;
                if (Klinik.ELGA_OID.Length < 12 || Klinik.ELGA_OID.Substring(0, 12) != "1.2.40.0.34.")
                {
                    rtfMeldungen.Text += "Einrichtung hat keine korrekte ELGA-OID: " + Klinik.ELGA_OID + ".\r\n";
                    ErrorLevel = Math.Max(ErrorLevel, 4);
                }

                if (String.IsNullOrEmpty(Klient.bPK))
                {
                    rtfMeldungen.Text += "Klient hat kein bereichsspezifisches Personenkennzeichen (bPK).\r\n";
                    ErrorLevel = Math.Max(ErrorLevel, 4);
                }

                using (PMDS.GUI.VB.compSql comp = new PMDS.GUI.VB.compSql())
                {
                    if (comp.GetOrdnerBiografie("Pflegebegleitschreiben") == null)
                    {
                        rtfMeldungen.Text += "Das Archiv enthält keinen Ordner 'Pflegebegleitschreiben'.\r\n";
                        ErrorLevel = Math.Max(ErrorLevel, 4);
                    }
                }

                if (Klient.ELGAAbgemeldet)
                {
                    rtfMeldungen.Text += "Klient hat sich von ELGA abgemeldet.\r\n";
                    ErrorLevel = Math.Max(ErrorLevel, 3);
                }

                if (Klient.ELGASOOJN)
                {
                    rtfMeldungen.Text += "Klient hat ein situatives OptOut erklärt.\r\n";
                    ErrorLevel = Math.Max(ErrorLevel, 3);
                }

                if (!String.IsNullOrWhiteSpace(rtfMeldungen2.Text))
                {
                    ErrorLevel = Math.Max(ErrorLevel, 2);
                }

                Type type = typeof(eStatusResult);
                if (!type.IsEnumDefined(ErrorLevel))
                {
                    throw new ArgumentException($"{ErrorLevel} is not a valid ordinal of type {type}.");
                }
                ReturnCode = (eStatusResult)Enum.ToObject(type, ErrorLevel);
                sWarnings = (String.IsNullOrWhiteSpace(rtfMeldungen.Text) ? "" : "Fehler:\r\n" + rtfMeldungen.Text);
                sMessages = (String.IsNullOrWhiteSpace(rtfMeldungen2.Text) ? "" : "Hinweise:\r\n" + rtfMeldungen2.Text + "\r\n");

                if (ErrorLevel > 1)
                {
                    baseTabControl1.SelectedTab = baseTabControl1.Tabs["tabMeldungen"];
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.CheckData: " + ex.ToString());
            }
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
                ccda.EffectiveTime = new TS(dNow, DatePrecision.Second);
                ccda.ConfidentialityCode = Info.ccdaConfidentialityCode;
                ccda.ConfidentialityCode.DisplayName = Info.ccdaConfidentialityCodeDisplayName;
                ccda.LanguageCode = Info.ccdaLanguageCode;
                ccda.SetId.AssigningAuthorityName = Klinik.Bezeichnung;      // Klinik.ELGA_OrganizationName?;
                ccda.Title = Info.cdaTitle;
                ccda.Code = new CE<string> { Code = Info.cdaCode.code, DisplayName = Info.cdaCode.displayName, CodeSystem = Info.cdaCode.codeSystem, CodeSystemName = Info.cdaCode.codeSystemName };
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.InitCDA: " + ex.ToString());
            }
        }

        private void MakeCDAKlient()
        {
            try
            {
                PatientRole patientRole = new PatientRole();

                patientRole.Id = new SET<II> { new II { Root = Klient.ID.ToString().ToUpper(), AssigningAuthorityName = Klinik.Bezeichnung } };

                if (SearchELGACode(Klient.Versicherungsdaten.SozVersLeerGrund, "SVE").code == "NI")
                {
                    patientRole.Id.Add(new II { Root = "1.2.40.0.10.1.4.3.1", NullFlavor = new CS<NullFlavor>(NullFlavor.NoInformation), AssigningAuthorityName = "Österreichische Sozialversicherung" });
                }
                else if (SearchELGACode(Klient.Versicherungsdaten.SozVersLeerGrund, "SVE").code == "UNK")
                {
                    patientRole.Id.Add(new II { Root = "1.2.40.0.10.1.4.3.1", NullFlavor = new CS<NullFlavor>(NullFlavor.Unknown), AssigningAuthorityName = "Österreichische Sozialversicherung" });
                }
                else if (!String.IsNullOrWhiteSpace(Klient.Versicherungsdaten.VersicherungsNr))
                {
                    patientRole.Id.Add(new II { Root = "1.2.40.0.10.1.4.3.1", Extension = Klient.Versicherungsdaten.VersicherungsNr, AssigningAuthorityName = "Österreichische Sozialversicherung" });
                }
                else
                {
                    rtfMeldungen.Text += "Fehler bei den Sozialversicherungsdaten. Die Verarbeitung wurde abgebrochen.\r\n";
                    ReturnCode = eStatusResult.MissingData;
                    return;
                }
                patientRole.Id.Add(new II { Root = "1.2.40.0.10.2.1.1.149", Extension = Klient.bPK, AssigningAuthorityName = "Österreichische Stammzahlenregisterbehörde" });


                if (Klient.WohnungAbgemeldetJN)
                    patientRole.Addr = NewAdress(PostalAddressUse.PrimaryHome, Klinik.Adresse.PLZ, Klinik.Adresse.Ort, Klinik.Adresse.Strasse, null, Klinik.Adresse.Land, "Adresse der Einrichtung (als Wohnsitz des Klienten");
                else
                    patientRole.Addr = NewAdress(PostalAddressUse.PrimaryHome, Klient.Adresse.PLZ, Klient.Adresse.Ort, Klient.Adresse.Strasse, null, Klient.Adresse.Land, "Wohnadresse des Klienten");

                patientRole.Telecom = MakeTel(Klient.Kontakt, TelecommunicationAddressUse.Home);

                MARC.Everest.RMIM.UV.CDAr2.POCD_MT000040UV.Patient patient = new MARC.Everest.RMIM.UV.CDAr2.POCD_MT000040UV.Patient();
                patient.Name = MakeNameNode(Klient.Titel, Klient.Vorname, Klient.Nachname, Klient.LedigerName, Klient.TitelPost);

                ccode SEX = SearchELGACode(Klient.Sexus, "SEX");
                if (SEX != null)
                    patient.AdministrativeGenderCode = new CE<string> { Code = SEX.code, CodeSystem = SEX.codeSystem, CodeSystemName = "HL7:AdministrativeGender", DisplayName = SEX.displayName };
                else
                {
                    patient.AdministrativeGenderCode = new CE<string> { };
                    patient.AdministrativeGenderCode.NullFlavor = new MARC.Everest.DataTypes.NullFlavor();
                    patient.AdministrativeGenderCode.NullFlavor = MARC.Everest.DataTypes.NullFlavor.Unknown;
                }

                patient.BirthTime = new TS(Klient.Geburtsdatum, DatePrecision.Day);

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
                    Sachwalter.Addr = NewAdress(PostalAddressUse.WorkPlace, pSachwalter.Adresse.PLZ, pSachwalter.Adresse.Ort, pSachwalter.Adresse.Strasse, null, pSachwalter.Adresse.Land, "Erwachsenenvertreter " + pSachwalter.Nachname + " "  + pSachwalter.Vorname);
                    Sachwalter.Telecom = MakeTel(pSachwalter.Kontakt, TelecommunicationAddressUse.BadAddress);
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

        private void MakeCDAAuthor()
        {
            try
            {
                Author author = new Author();
                author.AssignedAuthor = new AssignedAuthor(new SET<II> { new II(Benutzer.ID) });
                author.AssignedAuthor.Id[0].AssigningAuthorityName = Klinik.Bezeichnung;
                //author.AssignedAuthor.Addr = NewAdress(PostalAddressUse.PostalAddress, Klinik.Adresse.PLZ, Klinik.Adresse.Ort, Klinik.Adresse.Strasse, null, Klinik.Adresse.Land);              
                Person Verfasser = new Person();
                Verfasser.Name = MakeNameNode(Benutzer.Titel, Benutzer.Vorname, Benutzer.Nachname, Benutzer.LedigerName, Benutzer.TitelPost);
                author.AssignedAuthor.SetAssignedAuthorChoice(Verfasser);

                author.Time = new TS(dNow, DatePrecision.Second); ;
                Organization AuthorOrg = new Organization();
                AuthorOrg.Id = new SET<II> { new II { AssigningAuthorityName = "GDA Index", Root = Klinik.ELGA_OID } };
                AuthorOrg.Name = MakeOrganistionName(Klinik.Bezeichnung + ", " + Aufenthalt.Abteilung);
                AuthorOrg.Addr = NewAdress(PostalAddressUse.WorkPlace, Klinik.Adresse.PLZ, Klinik.Adresse.Ort, Klinik.Adresse.Strasse, null, Klinik.Adresse.Land, "Adresse der Einrichtung als Autor");
                AuthorOrg.Telecom = MakeTel(Klinik.Kontakt, TelecommunicationAddressUse.WorkPlace);

                author.AssignedAuthor.RepresentedOrganization = AuthorOrg;
                author.ContextControlCode = null;
                ccda.Author.Add(author);
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.InitAuthor: " + ex.ToString());
            }
        }

        private void MakeCDAVerwahrer()
        {
            try
            {
                CustodianOrganization VerwahrerOrg = new CustodianOrganization();
                SET<II> II = new SET<II> { new II { AssigningAuthorityName = "GDA Index", Root = Klinik.ELGA_OID } };

                ON Name = new ON();
                Name.Part.Add(new ENXP(Klinik.Bezeichnung + ", " + Aufenthalt.Abteilung));

                AD Adresse = new AD();
                Adresse = NewAdress(PostalAddressUse.WorkPlace, Klinik.Adresse.PLZ, Klinik.Adresse.Ort, Klinik.Adresse.Strasse, null, Klinik.Adresse.Land, "Adresse der Einrichtung (Verwahrer des Dokuments)").First();

                TEL Telefon = new TEL();
                if (!String.IsNullOrWhiteSpace(Klinik.Kontakt.Telefon))
                {
                    string tel = Regex.Replace(Klinik.Kontakt.Telefon, "/[0-9-.()+]/g", "").Replace(" ", "");
                    Telefon = new TEL("tel:" + tel, TelecommunicationAddressUse.WorkPlace);
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

        private void MakeCDAEmpfaenger()
        {
            try
            {
                InformationRecipient Empfaenger = new InformationRecipient(new CS<x_InformationRecipient>(x_InformationRecipient.PRCP));

                IntendedRecipient GeplEmpfänger = new IntendedRecipient();
                SET<II> iis = new SET<II>();
                II i = new II();

                if (this.Empfaenger.Bezeichnung.Equals("<Hausarzt>", StringComparison.OrdinalIgnoreCase))
                {
                    i.NullFlavor = NullFlavor.Unknown;
                    GeplEmpfänger.Id.Add(i);
                    GeplEmpfänger.InformationRecipient = new Person();
                    GeplEmpfänger.InformationRecipient.Name = new SET<PN> { new PN("Hausarzt") };
                    Empfaenger.IntendedRecipient = GeplEmpfänger;
                }
                else if (this.Empfaenger.Bezeichnung.Equals("<Klient>", StringComparison.OrdinalIgnoreCase))
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
                    GeplEmpfänger.Id = new SET<II> { i };
                    GeplEmpfänger.InformationRecipient = new Person();
                    GeplEmpfänger.InformationRecipient.Name = new SET<PN> { new PN("An die Einrichtung") };
                    Empfaenger.IntendedRecipient = GeplEmpfänger;

                    Organization org = new Organization();    
                    if (!String.IsNullOrWhiteSpace(this.Empfaenger.ELGA_OID))
                    {
                        org.Id = new SET<II> { new II { AssigningAuthorityName = "GDA Index", Root = this.Empfaenger.ELGA_OID } };
                    }
                    org.Name = MakeOrganistionName(this.Empfaenger.Bezeichnung);
                    org.Addr = NewAdress(PostalAddressUse.WorkPlace, this.Empfaenger.Adresse.PLZ, this.Empfaenger.Adresse.Ort, this.Empfaenger.Adresse.Strasse, null, this.Empfaenger.Adresse.Land, "Geplanter Empfänger des Dokuments (" + this.Empfaenger.Bezeichnung + ")");
                    org.Telecom = MakeTel(this.Empfaenger.Kontakt, TelecommunicationAddressUse.BadAddress);
                    GeplEmpfänger.ReceivedOrganization = org;
                }

                ccda.InformationRecipient = new List<InformationRecipient>();
                ccda.InformationRecipient.Add(Empfaenger);
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.InitEmpfaenger: " + ex.ToString());
            }
        }

        private void MakeCDARechtlicherUnterzeichner()
        {
            try
            {
                LegalAuthenticator Unterzeichner = new LegalAuthenticator();
                Unterzeichner.Time = new TS(dNow, DatePrecision.Second);
                Unterzeichner.SignatureCode = new CS<string>("S");

                AssignedEntity assignedEntity = new AssignedEntity(null, null, null, null, null, null);
                assignedEntity.Id = new SET<II>{ { new II(Benutzer.ID) } };
                assignedEntity.Id[0].AssigningAuthorityName = Klinik.Bezeichnung;
                assignedEntity.Telecom = MakeTel(Klinik.Kontakt, TelecommunicationAddressUse.WorkPlace);

                Person pers = new Person();
                pers.Name = MakeNameNode(Benutzer.Titel, Benutzer.Vorname, Benutzer.Nachname, Benutzer.LedigerName, Benutzer.TitelPost);

                Organization org = new Organization();
                org.Id = new SET<II> { new II { AssigningAuthorityName = "GDA Index", Root = Klinik.ELGA_OID } };
                org.Name = MakeOrganistionName(Klinik.Bezeichnung + ", " + Aufenthalt.Abteilung);
                org.Addr = NewAdress(PostalAddressUse.Public, Klinik.Adresse.PLZ, Klinik.Adresse.Ort, Klinik.Adresse.Strasse, null, Klinik.Adresse.Land, "Adresse der Einrichtung (Rechtlicher Unterzeichner)");
                org.Telecom = MakeTel(Klinik.Kontakt, TelecommunicationAddressUse.BadAddress);

                assignedEntity.AssignedPerson = pers;
                assignedEntity.RepresentedOrganization = org;
                Unterzeichner.AssignedEntity = assignedEntity;
                ccda.LegalAuthenticator = Unterzeichner;
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.InitRechtlicherUnterzeichner: " + ex.ToString());
            }
        }

        private void MakeCDAAnsprechperson()
        {
            try
            {
                Participant1 Ansprechperson = new Participant1(new CS<ParticipationType>(ParticipationType.CallbackContact), null);
                Ansprechperson.TemplateId = new LIST<II> { new II { Root = "1.2.40.0.34.11.1.1.1" } };

                AssociatedEntity assEnt = new AssociatedEntity(new CS<RoleClassAssociative>(RoleClassAssociative.HealthcareProvider));
                assEnt.Telecom = MakeTel(Klinik.Kontakt, TelecommunicationAddressUse.WorkPlace);

                Person pers = new Person();                
                pers.Name = MakeNameNode(Benutzer.Titel, Benutzer.Vorname, Benutzer.Nachname, Benutzer.LedigerName, Benutzer.TitelPost);

                Organization org = new Organization();
                org.Id = new SET<II> { new II { AssigningAuthorityName = "GDA Index", Root = Klinik.ELGA_OID } };
                org.Name = MakeOrganistionName(Klinik.Bezeichnung + ", " + Aufenthalt.Abteilung);
                org.Addr = NewAdress(PostalAddressUse.Public, Klinik.Adresse.PLZ, Klinik.Adresse.Ort, Klinik.Adresse.Strasse, null, Klinik.Adresse.Land, "Adresse der Einrichtung (Ansprechperson)");
                org.Telecom = MakeTel(Klinik.Kontakt, TelecommunicationAddressUse.WorkPlace);

                assEnt.AssociatedPerson = pers;
                assEnt.ScopingOrganization = org;
                Ansprechperson.AssociatedEntity = assEnt;
                ccda.Participant.Add(Ansprechperson);
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.InitAnsprechperson: " + ex.ToString());
            }
        }

        private void MakeCDAHausarzt()
        {
            try
            {
                if (this.Hausarzt.Rolle == cELGADB.eOrganistionRolle.Arzt)
                {
                    Participant1 Hausarzt = new Participant1(new CS<ParticipationType>(ParticipationType.IND), null);
                    Hausarzt.TemplateId = new LIST<II> { new II { Root = "1.2.40.0.34.11.1.1.3" } };
                    Hausarzt.FunctionCode = new CE<string>("PCP", "2.16.840.1.113883.5.88", "HL7:ParticipationFunction", null, "primary care physician", null);

                    AssociatedEntity assEnt = new AssociatedEntity(new CS<RoleClassAssociative>(RoleClassAssociative.HealthcareProvider));                   

                    assEnt.Id = new SET<II> {};
                    assEnt.Id.NullFlavor = new CS<NullFlavor>(NullFlavor.Unknown);

                    Person pers = new Person();
                    pers.Name = MakeNameNode(this.Hausarzt.Arztdaten.Titel, this.Hausarzt.Arztdaten.Vorname, this.Hausarzt.Arztdaten.Nachname, null, null);

                    Organization org = new Organization();
                    if (!String.IsNullOrWhiteSpace(this.Hausarzt.Arztdaten.ELGA_OrganizationOID))
                        org.Id = new SET<II> { new II { AssigningAuthorityName = "GDA Index", Root = this.Hausarzt.Arztdaten.ELGA_OrganizationOID } };
                    else
                    {
                        org.Id = new SET<II> { };
                        org.Id.NullFlavor = new CS<NullFlavor>(NullFlavor.Unknown);
                    }

                    org.Name = MakeOrganistionName((this.Hausarzt.Arztdaten.Titel + " " + this.Hausarzt.Arztdaten.Vorname + " " + this.Hausarzt.Arztdaten.Nachname).Trim());
                    org.Addr = NewAdress(PostalAddressUse.Public, this.Hausarzt.Adresse.PLZ, this.Hausarzt.Adresse.Ort, this.Hausarzt.Adresse.Strasse, null, this.Hausarzt.Adresse.Land, "Adresse des Hausarztes " + this.Hausarzt.Arztdaten.Nachname + " " + this.Hausarzt.Arztdaten.Vorname);
                    org.Telecom = MakeTel(this.Hausarzt.Kontakt, TelecommunicationAddressUse.BadAddress);

                    Hausarzt.AssociatedEntity = assEnt;
                    Hausarzt.AssociatedEntity.AssociatedPerson = pers;
                    Hausarzt.AssociatedEntity.ScopingOrganization = org;
                    Hausarzt.AssociatedEntity = assEnt;
                    ccda.Participant.Add(Hausarzt);
                }
                else
                {
                    rtfMeldungen2.Text += "Hinweis: Kein Hausarzt für ELGA gefunden.\r\n";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.InitHausarzt: " + ex.ToString());
            }
        }

        private void MakeCDAKontaktpersonen()
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

                        Kontakt.AssociatedEntity.Code = new CE<string>(SearchELGACode(Kontaktperson.Kontaktdaten.Verwandtschaft, "VWV").code, "2.16.840.1.113883.5.111", "HL7:RoleCode", null, SearchELGACode(Kontaktperson.Kontaktdaten.Verwandtschaft, "VWV").displayName, null);


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

        private void MakeCDAKrankenkasse()
        {
            try
            {
                Participant1 Krankenkasse = new Participant1(new CS<ParticipationType>(ParticipationType.Holder), null);
                Krankenkasse.TemplateId = new LIST<II> { new II { Root = "1.2.40.0.34.11.1.1.6" } };

                AssociatedEntity ascEnt = new AssociatedEntity(new CS<RoleClassAssociative>(RoleClassAssociative.PolicyHolder));

                if (SearchELGACode(Klient.Versicherungsdaten.SozVersStatus, "SVE") != null && SearchELGACode(Klient.Versicherungsdaten.SozVersStatus, "SVE").code == "NI")
                {
                    ascEnt.Id.NullFlavor = new CS<NullFlavor>(NullFlavor.NoInformation);
                }
                else if (SearchELGACode(Klient.Versicherungsdaten.SozVersStatus, "SVE") != null && SearchELGACode(Klient.Versicherungsdaten.SozVersStatus, "SVS").code == "UNK")
                {
                    ascEnt.Id.NullFlavor = new CS<NullFlavor>(NullFlavor.Unknown);
                }
                else
                {
                    ascEnt.Id = new SET<II>(new II { Root = "1.2.40.0.10.1.4.3.1", Extension = Klient.Versicherungsdaten.VersicherungsNr, AssigningAuthorityName = "Österreichische Sozialversicherung" });

                    ascEnt.Code = new CE<string> { Code = SearchELGACode(Klient.Versicherungsdaten.SozVersStatus, "SVS").code, CodeSystem = "2.16.840.1.113883.5.111", CodeSystemName = "HL7:RoleCode" };

                    if (SearchELGACode(Klient.Versicherungsdaten.SozVersStatus, "SVS").code == "FAMDEP")
                    {
                        ascEnt.AssociatedPerson = new Person();
                        ascEnt.AssociatedPerson.Name = MakeNameNode("", "", Klient.Versicherungsdaten.SozVersMitversichertBei, "", "");
                    }

                    if (this.Krankenkasse.Rolle == cELGADB.eOrganistionRolle.Krankenkasse)
                    {
                        Organization scopOrg = new Organization();
                        scopOrg.Name = MakeOrganistionName(this.Krankenkasse.Bezeichnung);
                        scopOrg.Addr = NewAdress(PostalAddressUse.Public, this.Krankenkasse.Adresse.PLZ, this.Krankenkasse.Adresse.Ort, this.Krankenkasse.Adresse.Strasse, null, this.Krankenkasse.Adresse.Land, "Adresse der Krankenkasse " + this.Krankenkasse.Bezeichnung);
                        scopOrg.Telecom = MakeTel(this.Krankenkasse.Kontakt, TelecommunicationAddressUse.BadAddress);
                        ascEnt.ScopingOrganization = scopOrg; ;
                    }
                    else
                    {
                        rtfMeldungen.Text += "Fehler: Krankenkasse '" + Klient.Versicherungsdaten.KrankenKasse + " ist ungültig (entspricht keinem ELGA-konformen Eintrag)\r\n";
                        ReturnCode = eStatusResult.MissingData;
                    }
                }

                Krankenkasse.AssociatedEntity = ascEnt;
                ccda.Participant.Add(Krankenkasse);
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.InitKrankenkasse: " + ex.ToString());
            }
        }

        private void MakeCDAAufenthaltService()
        {
            try
            {
                DocumentationOf Service = new DocumentationOf(new ServiceEvent());
                Service.ServiceEvent.Code = new CE<string> { Code = "GDLPUB", DisplayName = "Gesundheitsdienstleistung im Rahmen eines stationären Aufenthalts", CodeSystem = "1.2.40.0.34.5.21", CodeSystemName = "ELGA_ServiceEventsEntlassbrief" };
                Service.ServiceEvent.EffectiveTime = new IVL<TS>(this.Aufenthalt.Aufnahmezeitpunkt, dNow);
                Service.ServiceEvent.EffectiveTime.Low.DateValuePrecision = DatePrecision.Second;
                Service.ServiceEvent.EffectiveTime.High.NullFlavor = NullFlavor.Unknown;
                ccda.DocumentationOf.Add(Service);
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.InitAufenthalt: " + ex.ToString());
            }
        }

        private void MakeCDAAufenthaltInfo()
        {
            try
            {
                Component1 componentOf = new Component1();
                EncompassingEncounter encEncounter = new EncompassingEncounter();

                encEncounter.Id = new SET<II> { new II(this.Aufenthalt.ID) };
                encEncounter.Id[0].AssigningAuthorityName = this.Klinik.Bezeichnung;
                encEncounter.Code = new CE<ActEncounterCode>(ActEncounterCode.InpatientNonacute, "2.16.840.1.113883.5.4", null, null, "inpatient encounter", null);
                encEncounter.Code.CodeSystemName = "HL7:ActCode";
                encEncounter.EffectiveTime = new IVL<TS>(this.Aufenthalt.Aufnahmezeitpunkt, dNow);
                encEncounter.EffectiveTime.Low.DateValuePrecision = DatePrecision.Day;               
                encEncounter.EffectiveTime.High.NullFlavor = NullFlavor.Unknown;

                ResponsibleParty resParty = new ResponsibleParty();
                AssignedEntity assEnt = new AssignedEntity();
                assEnt.Id = new SET<II> { new II(this.Klinik.ID) };
                assEnt.Id[0].AssigningAuthorityName = this.Klinik.Bezeichnung;
                assEnt.Telecom = MakeTel(this.Klient.Kontakt, TelecommunicationAddressUse.WorkPlace);

                Person pers = new Person();
                pers.Name = MakeNameNode(this.Klinik.Leitungsdaten.Titel, this.Klinik.Leitungsdaten.Vorname, this.Klinik.Leitungsdaten.Nachname, null, null);

                Location loc = new Location();
                HealthCareFacility facility = new HealthCareFacility();

                Organization facOrg = new Organization();

                facOrg.Id = new SET<II> { new II { Root = this.Klinik.ELGA_OID, AssigningAuthorityName = "GDA Index" } };
                facOrg.Name = MakeOrganistionName(this.Klinik.Bezeichnung);
                facOrg.Telecom = MakeTel(Klinik.Kontakt, TelecommunicationAddressUse.BadAddress);
                facOrg.Addr = NewAdress(PostalAddressUse.Public, this.Klinik.Adresse.PLZ, this.Klinik.Adresse.Ort, this.Klinik.Adresse.Strasse, null, this.Klinik.Adresse.Land, "Adresse der Einrichtung (Aufenthaltsinfo)");

                facility.ServiceProviderOrganization = facOrg;
                loc.HealthCareFacility = facility;
                assEnt.AssignedPerson = pers;
                resParty.AssignedEntity = assEnt;
                encEncounter.ResponsibleParty = resParty;
                encEncounter.Location = loc;
                componentOf.EncompassingEncounter = encEncounter;
                ccda.ComponentOf = componentOf;              
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.InitAufenthalt: " + ex.ToString());
            }
        }

        private SET<TEL> MakeTel(cELGADB.Kontakt Kontakt, TelecommunicationAddressUse use)
        {
            try
            {
                SET<TEL> retVal = new SET<TEL>();
                string tel = Regex.Replace(Kontakt.Telefon, "/[0-9-.()+]/g", "").Replace(" ", "").Replace("/", "");
                string mob = Regex.Replace(Kontakt.TelefonMobil, "/[0-9-.()+]/g", "").Replace(" ", "").Replace("/", "");

                if (!String.IsNullOrWhiteSpace(Kontakt.Telefon))
                {
                    if (use != TelecommunicationAddressUse.BadAddress)
                        retVal.Add(new TEL("tel:" + tel, use));
                    else
                        retVal.Add(new TEL("tel:" + tel));
                }

                if (!String.IsNullOrWhiteSpace(Kontakt.TelefonMobil))
                {
                    retVal.Add(new TEL("tel:" + mob));
                }

                if (!String.IsNullOrWhiteSpace(Kontakt.eMail))
                {
                    retVal.Add(new TEL("mailto:" + Kontakt.eMail));
                }

                if (retVal.Count > 0)
                    return retVal;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.InitAufenthalt: " + ex.ToString());
            }
        }


        private SET<ON> MakeOrganistionName(string Name)
        {
            try
            {
                ON on = new ON();
                on.Part.Add(new ENXP(Name));
                return new SET<ON> { (on) };
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.MakeOrganistionName: " + ex.ToString());
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
                rtfMeldungen.Tag = new RTFTag { Order = SektionOrder.None, Tag = "Meldungen", Typ = RTFTyp.None };
                rtfMeldungen2.Tag = new RTFTag { Order = SektionOrder.None, Tag = "Meldungen", Typ = RTFTyp.None };

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
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.3.2.2", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFDIAG", displayName = "Pflege- und Betreuungsdiagnosendiagnosen" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Mobilität,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Mobilität",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.3.2.3", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFMOB", displayName = "Mobilität" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.KörperpflegeUndKleiden,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Körperpflege und Kleiden",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.3.2.4", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFKLEI", displayName = "Körperpflege und Kleiden" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Ernährung,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Ernährung",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.3.2.5", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFERN", displayName = "Ernährung" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Ausscheidung,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Ausscheidung",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.3.2.6", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFAUS", displayName = "Ausscheidung" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Hautzustand,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Hautzustand",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.3.2.7", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFHAUT", displayName = "Hautzustand" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Atmung,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Atmung",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.3.2.8", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFATM", displayName = "Atmung" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Schlaf,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Schlaf",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.3.2.9", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFSCHL", displayName = "Schlaf" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Schmerz,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Schmerz",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.3.2.10", AssigningAuthorityName = "ELGA" },
                                                           new II { Root = "1.3.6.1.4.1.19376.1.5.3.1.1.20.2.4", AssigningAuthorityName = "IHE PCC" } },
                                            new ccode { code = "38212-7", displayName = "Pain Assessment Panel", codeSystem = "2.16.840.1.113883.6.1", codeSystemName = "LOINC" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.OrientierungUndBewusstseinslage,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Orientierung und Bewusstseinslage",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.3.2.11", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFORIE", displayName = "Orientierung und Bewusstseinslage" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.SozialeUmständeUndVerhalten,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Soziale Umstände und Verhalten",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.3.2.12", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFSOZV", displayName = "Soziale Umstände und Verhalten" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Kommunikation,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Kommunikation",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.3.2.13", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFKOMM", displayName = "Kommunikation" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.RollenwahnehmungUndSinnfindung,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Rollenwahrnehmung und Sinnfindung",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.3.2.14", AssigningAuthorityName = "ELGA" } },
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
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.3.2.18", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFMEDBEH", displayName = "Pflegerelevante Informationen zur medizinischen Behandlung" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Medikamentenverabreichung,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Medikamentenverabreichung",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.3.2.15", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "PFMED", displayName = "Medikamentenverabreichung" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Anmerkungen,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Anmerkungen",
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.1.2.5", AssigningAuthorityName = "ELGA" } },
                                            new ccode { code = "ANM", displayName = "Anmerkungen" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.PflegeUndBetreuungsumfang,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Pflege- und Betreuungsumfang",
                                            new List<II> { new II { Root = "1.2.40.0.34.11.12.2.2", AssigningAuthorityName = "ELGA" } },
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
                                            new LIST<II> { new II { Root = "1.2.40.0.34.11.1.2.2", AssigningAuthorityName = "ELGA" } },
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
                sect.Text.Data = System.Text.Encoding.UTF8.GetBytes(sektion.textHTML.Replace("\n", "|||"));
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
                            observation.EffectiveTime.Low.DateValuePrecision = DatePrecision.Day;
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
                            act.EffectiveTime.Low.DateValuePrecision = DatePrecision.Day;
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

                        CD<string> c = new CD<string>();
                        c.NullFlavor = MARC.Everest.DataTypes.NullFlavor.NotApplicable;
                        act.Code = c;

                        act.EntryRelationship = new List<EntryRelationship> { entryRelationship };

                        sect.Entry.Add(entry);
                    }
                }

                //Ressourcen und Hilfsmittel
                if (sektion.HilfsmittelUndRessourcen != null)
                {
                    Section sectRUM = new Section();
                    sectRUM.Title = "Hilfsmittel und Ressourcen";
                    sectRUM.TemplateId = sektion.HilfsmittelUndRessourcen.cdatemplateIDs;

                    sectRUM.Code = new CE<string>(sektion.HilfsmittelUndRessourcen.code.code,
                        sektion.HilfsmittelUndRessourcen.code.codeSystem,
                        sektion.HilfsmittelUndRessourcen.code.codeSystemName,
                        null,
                        sektion.HilfsmittelUndRessourcen.code.displayName,
                        null);
                    sectRUM.Text = sektion.HilfsmittelUndRessourcen.textHTML.Replace("\n", "|||");
                    sectRUM.Text.Language = null;
                    sectRUM.Text.MediaType = null;

                    Component5 comp5 = new Component5(null, null, sectRUM);
                    sect.Component.Add(comp5);
                }

                //Risiken
                if (sektion.Risiko != null)
                {
                    Section sectRisk = new Section();
                    sectRisk.Title = "Risiken";
                    sectRisk.TemplateId = sektion.Risiko.cdatemplateIDs;
                    sectRisk.Code = new CE<string>(sektion.Risiko.code.code,
                        sektion.Risiko.code.codeSystem,
                        sektion.Risiko.code.codeSystemName,
                        null,
                        sektion.Risiko.code.displayName,
                        null);
                    sectRisk.Text = sektion.Risiko.textHTML.Replace("\n", "|||");
                    sectRisk.Text.Language = null;
                    sectRisk.Text.MediaType = null;

                    Component5 comp5 = new Component5(null, null, sectRisk);
                    sect.Component.Add(comp5);
                }

                if (sektion.VitalparamterEntry != null)
                {

                    foreach (VitalparameterEntryComponent VZcomp in sektion.VitalparamterEntry.components)
                    {
                        Entry entry = new Entry();
                        entry.TypeCode = new CS<x_ActRelationshipEntry>(x_ActRelationshipEntry.DRIV);

                        Organizer organizer = new Organizer(new CS<x_ActClassDocumentEntryOrganizer>(x_ActClassDocumentEntryOrganizer.CLUSTER));
                        organizer.TemplateId = sektion.VitalparamterEntry.cdatemplateIDs;
                        organizer.Id = new SET<II>(new II { Root = "O"+ VZcomp.id_root });
                        organizer.Code = new CD<string> { Code = sektion.VitalparamterEntry.code.code, DisplayName = sektion.VitalparamterEntry.code.displayName, CodeSystem = sektion.VitalparamterEntry.code.codeSystem, CodeSystemName = sektion.VitalparamterEntry.code.codeSystemName }; 
                        organizer.StatusCode = new CS<ActStatus>(ActStatus.Completed);
                        organizer.EffectiveTime = new IVL<TS>(new TS(VZcomp.effectivetime, DatePrecision.Second));

                        Observation obs = new Observation();
                        obs.MoodCode = new CS<x_ActMoodDocumentObservation>(x_ActMoodDocumentObservation.Eventoccurrence);
                        obs.TemplateId = VZcomp.cdatemplateIDs;
                        obs.Id = new SET<II>(new II { Root = VZcomp.id_root });
                        obs.Code = new CD<string> { Code = VZcomp.code.code, DisplayName = VZcomp.code.displayName, CodeSystem = VZcomp.code.codeSystem, CodeSystemName = VZcomp.code.codeSystemName };
                        obs.Code.OriginalText = new ED();
                        obs.Code.OriginalText.Reference = "#" + VZcomp.originaltext_reference;
                        obs.Text = new ED();
                        obs.Text.Reference = "#" + VZcomp.text_reference;
                        obs.Value = new PQ { Value = Convert.ToDecimal(VZcomp.value_value), Unit = VZcomp.value_unit };
                        obs.StatusCode = new CS<ActStatus>(ActStatus.Completed);

                        Component4 comp = new Component4();
                        comp.ClinicalStatement = obs;
                        organizer.Component.Add(comp);
                        entry.ClinicalStatement = organizer;
                        sect.Entry.Add(entry);
                    }
                }

                //Beilagen
                if (sektion.BeilagenEntries != null)
                {
                    foreach (BeilagenEntry Beilage in sektion.BeilagenEntries)
                    {
                        ENV.ELGAObservationMedia obs = new ENV.ELGAObservationMedia();
                        obs.Value = new ED { };
                        obs.Value.Data = Beilage.value;
                        obs.Value.MediaType = Beilage.value_mediaType;
                        obs.Value.Representation = Beilage.value_representation;
                        obs.ID = new ST(Beilage.id);
                        obs.TemplateId = Beilage.cdatemplateIDs;
                        obs.LanguageCode = null;

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

        private void PreparePDx()
        {
            try
            {
                string PDxHTML = "<table>\r<thead>\r<tr><th>Diagnose</th><th>Lokalisierung</th><th>Zeitpunkt</th></tr></thead>\r";
                PDxHTML += "<tbody>\r";

                int i = 0;
                if (lPDX.Count() > 0)
                {
                    foreach (cELGADB.PDX pdx in lPDX)
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
                    rtfMeldungen2.Text += "Keine ELGA-konformen Pflegediagnosen gefunden.\r\n";
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

                    PDx.entryRelationship.observation.code.code = "282291009";
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
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadPDx: " + ex.ToString());
            }
        }

        private void PrepareRessourcenRisiken()
        {
            try
            {
                foreach (cELGADB.RessourceRisiko R in lRessourcenRisiken)
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
                                    Sektion.HilfsmittelUndRessourcen = new HilfsmittelRessourcen();
                                }
                                Sektion.HilfsmittelUndRessourcen.textHTML += R.Text + "\n";
                                SetRTFTextByTag(this.Controls, R.Code + "_RES", R.Text + "\n");
                            }

                            else if (R.Eintraggruppe == "A")
                            {
                                if (Sektion.Risiko == null)
                                {
                                    Sektion.Risiko = new Risiko();
                                }
                                Sektion.Risiko.textHTML += R.Text + "\n";
                                SetRTFTextByTag(this.Controls, R.Code + "_RISK", R.Text + "\n");
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

        private void PrepareVitalparameter()
        {
            try
            {
                string PDxHTML = "<table>\r<thead><tr><th>Name</th><th>Wert</th><th>Einheit</th><th>Zeitpunkt</th></tr></thead>";
                PDxHTML += "<tbody>";

                int i = 0;
                foreach (cELGADB.Vitalparameter zw in lVitalparameter)
                {
                    if (zw.ZEID != "ERF")       //Für Stuhlkontrolle gibt es keine LOINC-Klassifikation, daher muss dieser in Risiko Ausscheidung
                    {
                        i++;
                        if (Sektionen[(int)SektionOrder.Vitalparameter].VitalparamterEntry == null)
                            Sektionen[(int)SektionOrder.Vitalparameter].VitalparamterEntry = new VitalparameterEntry();

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
                        PDxHTML += "<td>" + zw.Zeitpunkt.ToString() + "</td></tr>";

                        VitalparameterEntryComponent VZ = new VitalparameterEntryComponent();
                        VZ.id_root = "VZ" + zw.ID.ToString("N");
                        VZ.code = new ccode { code = zw.ELGA_Code, displayName = zw.ELGA_DisplayName, codeSystem = zw.ELGA_CodeSystem, codeSystemName = "LOINC" };
                        VZ.text_reference = "vitsig" + i.ToString();
                        VZ.originaltext_reference = "vitsigtype" + i.ToString();
                        VZ.value_value = Wert;
                        VZ.value_unit = zw.ELGA_Unit;
                        VZ.effectivetime = (DateTime)zw.Zeitpunkt;

                        Sektionen[(int)SektionOrder.Vitalparameter].VitalparamterEntry.components.Add(VZ);
                        Sektionen[(int)SektionOrder.Vitalparameter].use = true;
                    }
                    else
                    {
                        //Stuhlkontrolle in Text Ausscheidung eintragen
                        if (Sektionen[(int)SektionOrder.Ausscheidung].Risiko == null)
                            Sektionen[(int)SektionOrder.Ausscheidung].Risiko = new Risiko();

                        string txtAUS = zw.Bezeichnung + ": " + zw.Wert + " am " + zw.Zeitpunkt.ToString() + "\n";
                        Sektionen[(int)SektionOrder.Ausscheidung].Risiko.textHTML += txtAUS;
                        SetRTFTextByTag(this.Controls, "PFAUS_RISK", txtAUS);
                        Sektionen[(int)SektionOrder.Ausscheidung].use = true;
                    }        
                }
                PDxHTML += "</tbody></table>";

                if (i > 1)
                {
                    Sektionen[(int)SektionOrder.Vitalparameter].use = true;
                    Sektionen[(int)SektionOrder.Vitalparameter].textHTML = PDxHTML;
                    wbVitalzeichen.DocumentText = PDxHTML;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadVitalparameter: " + ex.ToString());
            }
        }

        private void PrepareMedDaten()
        {
            try
            {              
                string mdText = "";
                foreach (cELGADB.MedizinischeDaten rMedDaten in lMedizinischeDaten)
                {
                    mdText += "- " + rMedDaten.MTBeschreibung + " :";

                    if (rMedDaten.Beschreibung != "")
                        mdText += " " + rMedDaten.Beschreibung;

                    mdText += (rMedDaten.Bis > new DateTime(1900, 1, 1) ? " von" : " seit");
                    mdText += " " + rMedDaten.Von.ToString("dd.MM.yyyy");
                    if (rMedDaten.Bis > new DateTime(1900, 1, 1))
                        mdText += " bis " + rMedDaten.Bis.ToString("dd.MM.yyyy");

                    if (rMedDaten.Typ != null && !String.IsNullOrWhiteSpace(rMedDaten.Typ))
                        mdText += ", " + rMedDaten.Typ;

                    if (rMedDaten.Modell != null && !String.IsNullOrWhiteSpace(rMedDaten.Modell))
                        mdText += ", Modell=" + rMedDaten.Modell;

                    if (rMedDaten.Groesse != null && !String.IsNullOrWhiteSpace(rMedDaten.Groesse))
                        mdText += ", Größe=" + rMedDaten.Groesse;

                    if (rMedDaten .LetzteVersorgung> new DateTime(1900, 1, 1))
                        mdText += "letzte Versorung " + rMedDaten.LetzteVersorgung.ToString("dd.MM.yyyy");

                    if (rMedDaten.NaechsteVersorgung > new DateTime(1900, 1, 1))
                        mdText += "nächste Versorung " + rMedDaten.NaechsteVersorgung.ToString("d.MM.yyyy");

                    if (rMedDaten.AntikoaguliertJN)
                        mdText += ", antikoaguliert!";

                    mdText += "\n";
                    rtfPFMEDBEH_Text.Text = mdText;
                    CheckSektionUsed(SektionOrder.Patientenverfügung);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadMedDaten: " + ex.ToString());
            }
        }

        private void PrepareRezepte()
        {
            try
            {
                string rez = "Verordnungen:\n";
                foreach (cELGADB.Rezept rRezept in lRezepte)
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
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadRezepte: " + ex.ToString());
            }
        }

        private void PreparePatientenverfügung()
        {
            try
            {
                //Patientenverfügung
                rtfPATVERF_Text.Text = "";
                if (Patientenverfügung.PatientenverfuegungJN == true)
                {
                    DateTime dt = Patientenverfügung.PatientverfuegungDatum;
                    rtfPATVERF_Text.Text += (Patientenverfügung.PatientenverfuegungBeachtlichJN == false ? "Beachtliche " : "Verbindliche ");
                    rtfPATVERF_Text.Text = "Patientenverfügung vom " + dt.ToString("dd.MM.yyyy") + ": " + Patientenverfügung.PatientverfuegungAnmerkung.ToString() + "\n";
                    Sektionen[(int)SektionOrder.Patientenverfügung].use = true;
                }

                //Freiheitsbeschr. Maßnahmen                
                string txtHAG = rtfPATVERF_Text.Text + "\nFreiheitsbeschränkende Maßnahmen gem. Heimaufenthaltsgesetz\n";
                foreach (cELGADB.Freiheitsbeschränkung rHAG in lFreiheitsbeschränkungen)
                {
                    txtHAG += "Beginn: " + rHAG.Beginn.ToString("dd.MM.yyyy");

                    string txtArt = "Grund der Freiheitsbeschränkung";
                    if (rHAG.PsychischekrankheitJN ||
                        rHAG.GeistigeBehinderungJN ||
                        rHAG.ErheblicheSelbstgefaehrdungJN ||
                        rHAG.ErheblicheFremdgefaehrdungJN
                        )
                    {
                        if (rHAG.KlientZustimmungJN)
                        {
                            txtHAG += "\nZustimmung des einsichts- und urteilsfähigen Kienten (Freiheitseinschränkung) liegt vor.";
                            txtArt = "Grund der Freiheitseinschränkung";
                        }

                        txtHAG += "\n" + txtArt;

                        if (rHAG.PsychischekrankheitJN && rHAG.GeistigeBehinderungJN)
                        {
                            txtHAG += ": Psychische Krankheit und geistige Behinderung,";
                        }

                        if (rHAG.PsychischekrankheitJN && !rHAG.GeistigeBehinderungJN)
                        {
                            txtHAG += ": Psychische Krankheit.";
                        }

                        if (!rHAG.PsychischekrankheitJN && rHAG.GeistigeBehinderungJN)
                        {
                            txtHAG += ": Geistige Behinderung.";
                        }

                        if ((rHAG.PsychischekrankheitJN || rHAG.GeistigeBehinderungJN) && !String.IsNullOrWhiteSpace(rHAG.MedizinischeDiagnose))
                            txtHAG += " Begründung: " + rHAG.MedizinischeDiagnose;

                        if (rHAG.ErheblicheSelbstgefaehrdungJN && rHAG.ErheblicheFremdgefaehrdungJN)
                            txtHAG += "\nErhebliche Selbst- und Fremdgfährdung.";

                        if (rHAG.ErheblicheSelbstgefaehrdungJN && !rHAG.ErheblicheFremdgefaehrdungJN)
                            txtHAG += "\nErhebliche Selbstgefährdung.";

                        if (!rHAG.ErheblicheSelbstgefaehrdungJN && rHAG.ErheblicheFremdgefaehrdungJN)
                            txtHAG += "\nErhebliche Fremdgefährdung.";


                        if ((rHAG.ErheblicheSelbstgefaehrdungJN || rHAG.ErheblicheFremdgefaehrdungJN) && !String.IsNullOrWhiteSpace(rHAG.AnmerkungVerhalten_2016))
                            txtHAG += " Gefährdungsgrund: " + rHAG.AnmerkungVerhalten_2016;
                    }

                    if (!String.IsNullOrWhiteSpace(rHAG.AnmerkungGutachten_2016))
                        txtHAG += "\n" + "Ärztliches Gutachten: " + rHAG.AnmerkungGutachten_2016;

                    if (rHAG.EinzelfallmedikationJN_2016 == true)
                    {
                        txtHAG += "\nEinzelfallmedikation";
                        txtHAG += (!String.IsNullOrWhiteSpace(rHAG.Einzelfallmedikation_2016) ? ": " + rHAG.Einzelfallmedikation_2016 : "");
                    }

                    if (rHAG.DauermedikationJN_2016 == true)
                    {
                        txtHAG += "\nDauermedikation";
                        txtHAG += (!String.IsNullOrWhiteSpace(rHAG.Dauermedikation_2016) ? ": " + rHAG.Dauermedikation_2016 : "");
                    }

                    if (rHAG.HindernVerlassenBettSeitenteilenJN ||
                        rHAG.HindernVerlassenBettBauchgurtJN_2016 ||
                        rHAG.HindernVerlassenBettElektronischJN_2016 ||
                        rHAG.HindernVerlassenBettAndereJN_2016)
                    {
                        txtHAG += "\nHindern am Verlassen des Bettes mittels ";
                        txtHAG += (rHAG.HindernVerlassenBettSeitenteilenJN ? "\n  - Seitenteilen " : "");
                        txtHAG += (rHAG.HindernVerlassenBettBauchgurtJN_2016 ? "\n  - Bauchgurt " : "");
                        txtHAG += (rHAG.HindernVerlassenBettElektronischJN_2016 ? "\n  - elektronischer Maßnahme " : "");
                        if (rHAG.HindernVerlassenBettAndereJN_2016)
                        {
                            txtHAG += "\n  - anderer Maßnahme";
                            if (!String.IsNullOrEmpty(rHAG.HindernBettVerlassen))
                                txtHAG += ": " + rHAG.HindernBettVerlassen;
                        }
                    }

                    if (rHAG.HindernSitzgelSitzhoseJN ||
                        rHAG.HindernSitzgelBauchgurtJN_2016 ||
                        rHAG.HindernSitzgelBrustgurtJN_2016 ||
                        rHAG.HindernSitzgelTischJN ||
                        rHAG.HindernSitzgelTherapietischJN ||
                        rHAG.HindernSitzgelAndereJN_2016)
                    {
                        txtHAG += "\nHindern am Verlassen von Sitzgelgenheit/Rollstuhl mittels ";
                        txtHAG += (rHAG.HindernSitzgelSitzhoseJN ? "\n  - Sitzhose " : "");
                        txtHAG += (rHAG.HindernSitzgelBauchgurtJN_2016 ? "\n  - Bauchgurt " : "");
                        txtHAG += (rHAG.HindernSitzgelBrustgurtJN_2016 ? "\n  - Brustgurt " : "");
                        txtHAG += (rHAG.HindernSitzgelTischJN ? "\n  -Tisch " : "");
                        txtHAG += (rHAG.HindernSitzgelTherapietischJN ? "\n  - Therapietisch " : "");
                        if (rHAG.HindernSitzgelAndereJN_2016)
                        {
                            txtHAG += "\n  - anderer Maßnahme";
                            if (!String.IsNullOrEmpty(rHAG.HindernSitzgelegenheit))
                                txtHAG += ": " + rHAG.HindernSitzgelegenheit;
                        }
                    }

                    if (rHAG.ZurueckhaltensandrohungJN ||
                        rHAG.HindernBereichFesthaltenJN_2016 ||
                        rHAG.HindernBereichVersperrterBereichJN_2016 ||
                        rHAG.HindernBereichBarriereJN_2016 ||
                        rHAG.ElektronischesUeberwachungJN ||
                        rHAG.HindernBereichVersperrtesZimmerJN_2016 ||
                        rHAG.HindernBereichHinderAmFortbewegenJN_2016 ||
                        rHAG.HindernBereichAndereJN_2016)
                    {
                        txtHAG += "\nHindern am Verlassen eines Bereichs mittels ";
                        txtHAG += (rHAG.ZurueckhaltensandrohungJN ? "\n  - Zurückhalten/Androhung des Zurückhaltens " : "");
                        txtHAG += (rHAG.HindernBereichFesthaltenJN_2016 ? "\n  - Körperlicher Zugriff/Festhalten " : "");
                        txtHAG += (rHAG.HindernBereichVersperrterBereichJN_2016 ? "\n  - versperrter Bereich " : "");
                        txtHAG += (rHAG.HindernBereichBarriereJN_2016 ? "\n  - Tür/Raumgestaltung, Barierre " : "");
                        txtHAG += (rHAG.ElektronischesUeberwachungJN ? "\n  - Desorientiertenfürsorgesystem/Sensor " : "");
                        txtHAG += (rHAG.HindernBereichVersperrtesZimmerJN_2016 ? "\n  - Versperrtes Zimmer " : "");
                        txtHAG += (rHAG.HindernBereichHinderAmFortbewegenJN_2016 ? "\n  - Hindern am Fortbewegen mit dem Rollstuhl (Bremsen, ..) " : "");
                        if (rHAG.HindernSitzgelAndereJN_2016)
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
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadPatientenverfügung: " + ex.ToString());
            }
        }

        private void PreparePflegeUndBetreuungsumfang()
        {
            try
            {
                //Pflegestufe
                if (Pflegestufe.eValid == cELGADB.eValid.yes)
                {
                    rtfPUBUMF_Text.Text += "Letzte genehmigte Pflegestufe: " + Pflegestufe.Bezeichnung;
                    if (Pflegestufe.GenehmigungDatum != null)
                    {
                        rtfPUBUMF_Text.Text += " mit Bescheiddatum vom " + Pflegestufe.GenehmigungDatum.ToString("dd.MM.yyyy") + "\n";
                    }
                    Sektionen[(int)SektionOrder.PflegeUndBetreuungsumfang].use = true;
                }

                //Rezeptgebührenbefreiung
                if (Rezeptgebührenbefreiung.RezeptgebuehrbefreiungJN)
                {
                    PMDS.Global.db.ERSystem.PMDSBusinessUI bUI = new PMDS.Global.db.ERSystem.PMDSBusinessUI();
                    string TitleRezeptgebührenbefreit = "";
                    string InfoRezeptgebührenbefreit = "";
                    bool bIsRezeptgebührenbefreit = bUI.showInfoRezeptgebührbefreiungInfo(
                        Rezeptgebührenbefreiung.RezeptgebuehrbefreiungJN,
                        Rezeptgebührenbefreiung.RezGebBef_RegoJN,
                        Rezeptgebührenbefreiung.RezGebBef_RegoAb,
                        Rezeptgebührenbefreiung.RezGebBef_RegoBis,
                        Rezeptgebührenbefreiung.RezGebBef_UnbefristetJN,
                        Rezeptgebührenbefreiung.RezGebBef_BefristetJN,
                        Rezeptgebührenbefreiung.RezGebBef_BefristetAb,
                        Rezeptgebührenbefreiung.RezGebBef_BefristetBis,
                        Rezeptgebührenbefreiung.RezGebBef_WiderrufJN,
                        Rezeptgebührenbefreiung.RezGebBef_WiderrufGrund,
                        Rezeptgebührenbefreiung.RezGebBef_SachwalterJN,
                        Rezeptgebührenbefreiung.RezGebBef_Anmerkung,
                        ref TitleRezeptgebührenbefreit, ref InfoRezeptgebührenbefreit, false);
                    rtfPUBUMF_Text.Text += InfoRezeptgebührenbefreit + "\r\n";
                    Sektionen[(int)SektionOrder.PflegeUndBetreuungsumfang].use = true;
                }                
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.LoadPatientenverfügung: " + ex.ToString());
            }
        }

        private void PrepareBeilagen() //alle pdf-Dokumente im Archivordner ELGAPflegesituationsbericht anhängen
        {
            try
            {
                if (lBeilagen.Count() > 0)
                {
                    int iCountBeilagen = 0;

                    foreach (cELGADB.Beilage rBeilage in lBeilagen)
                    {
                        string path = Path.Combine(ENV.ArchivPath, rBeilage.Archivordner, rBeilage.DateinameArchiv);
                        if (System.IO.File.Exists(path))
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

        public static MemoryStream CreateCDA(string sFileName)
        {
            try
            {
                using (MemoryStream msXML = new MemoryStream())
                {
                    using (MARC.Everest.Xml.XmlStateWriter xsw = new XmlStateWriter(XmlWriter.Create(msXML, new XmlWriterSettings() { Indent = true, ConformanceLevel = ConformanceLevel.Document })))
                    {
                        ENV.ELGAFormatter.Graph(xsw, ccda);
                        xsw.Flush();
                    }
                    msXML.Position = 0;

                    string xml = "";
                    using (StreamReader sr = new StreamReader(msXML))
                    {
                        xml = sr.ReadToEnd();
                    }

                    xml = xml.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?>\n<?xml-stylesheet type=\"text/xsl\" href=\"ELGA_Stylesheet_v1.0.xsl\"?>");
                    xml = xml.Replace("|||", "<br/>");
                    xml = xml.Replace(" representation=\"TXT\"", "");

                    MemoryStream msReturn = new MemoryStream();
                    using (MemoryStream msOut = new MemoryStream())
                    {
                        using (StreamWriter sw = new StreamWriter(msOut))
                        {
                            sw.NewLine = "\n";
                            sw.Write(xml);
                            sw.Flush();

                            msOut.Position = 0;
                            if (!String.IsNullOrWhiteSpace(sFileName))
                            {
                                using (FileStream fs = new FileStream(sFileName, FileMode.Create))
                                {
                                    msOut.CopyTo(fs);
                                    fs.Flush();
                                }
                            }
                            msOut.Position = 0;
                            msOut.CopyTo(msReturn);
                            msOut.Position = 0;
                            msOut.CopyTo(msPSB);
                            return msReturn;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.PrintCDA: " + ex.ToString());
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
                    Sektionen[(int)SektionOrder.Anmerkungen].use = !String.IsNullOrWhiteSpace(rtfANM_Text.Text);
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
                System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();

                foreach (UltraListViewItem rBeilage in lvSender.Items)
                {
                    if (rBeilage.CheckState == CheckState.Checked)
                    {
                        string path = Path.Combine(rBeilage.SubItems["Archivordner"].Value.ToString(), rBeilage.SubItems["DateinameArchiv"].Value.ToString());
                        if (System.IO.File.Exists(path))
                        {
                            List<BeilagenEntry> Beilagenliste = new List<BeilagenEntry>();
                            BeilagenEntry Beilage = new BeilagenEntry();

                            MemoryStream stream = new MemoryStream();

                            PdfLoadedDocument pdf = new PdfLoadedDocument(System.IO.File.ReadAllBytes(path), true);

                            if (pdf.Conformance == Syncfusion.Pdf.PdfConformanceLevel.Pdf_A1A ||
                                pdf.Conformance == Syncfusion.Pdf.PdfConformanceLevel.Pdf_A1B ||
                                pdf.Conformance == Syncfusion.Pdf.PdfConformanceLevel.Pdf_A2B ||
                                pdf.Conformance == Syncfusion.Pdf.PdfConformanceLevel.Pdf_A2A ||
                                pdf.Conformance == Syncfusion.Pdf.PdfConformanceLevel.Pdf_A2U ||
                                pdf.Conformance == Syncfusion.Pdf.PdfConformanceLevel.Pdf_A3A ||
                                pdf.Conformance == Syncfusion.Pdf.PdfConformanceLevel.Pdf_A3B ||
                                pdf.Conformance == Syncfusion.Pdf.PdfConformanceLevel.Pdf_A3U)
                            {
                                pdf.Save(stream);
                                pdf.Close();
                            }
                            else
                            {
                                DialogResult res = DialogResult.Yes;
                                if (rBeilage.SubItems["NoPDFA1aAccepted"].Value == null || !(bool)rBeilage.SubItems["NoPDFA1aAccepted"].Value)
                                {
                                    res = QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB("Typ " + pdf.Conformance.ToString() + " des PDF-Dokument ist nicht PDF/A (1A-3B).\nDas PDF-Dokument darf nicht verwendet werden.", MessageBoxButtons.OK, "Wichtiger Hinweis!");
                                    rBeilage.CheckState = CheckState.Unchecked;
                                    rBeilage.SubItems["NoPDFA1aAccepted"].Value = true;
                                }
                            }

                            Beilage.value = stream.ToArray();
                            //Beispiel für ein korrektes PDF/A-1A-Dokument
                            //Syncfusion.Pdf.PdfDocument document = new Syncfusion.Pdf.PdfDocument(Syncfusion.Pdf.PdfConformanceLevel.Pdf_A1A);
                            //Syncfusion.Pdf.PdfPage page = document.Pages.Add();
                            //Syncfusion.Pdf.Graphics.PdfGraphics graphics = page.Graphics;
                            //Syncfusion.Pdf.Graphics.PdfBrush brush = new Syncfusion.Pdf.Graphics.PdfSolidBrush(Color.Black);
                            //Font font = new Font("Arial", 20f, FontStyle.Regular);
                            //Syncfusion.Pdf.Graphics.PdfFont pdfFont = new Syncfusion.Pdf.Graphics.PdfTrueTypeFont(font, FontStyle.Regular, 12, false, true);
                            //graphics.DrawString("Hello world!", pdfFont, brush, new PointF(20, 20));
                            //document.Save("C:\\temp\\pdfA1Agen.pdf");
                            //document.Close(true);

                            //Nur zur Ermittlung der Länge im XML erforderlich
                            using (Chilkat.Crypt2 cr = new Chilkat.Crypt2())
                            {
                                cr.EncodingMode = "Base64";
                                var sb = new StringBuilder(cr.Encode(Beilage.value, "base64"));
                                iSizeTotal += sb.ToString().Length;

                                if (iSizeTotal < iMaxSize)
                                {
                                    iCountBeilagen++;
                                    string refObject = "Beilage_" + rBeilage.SubItems["DateinameArchiv"].Value.ToString();
                                    string txtObject = rBeilage.Text;
                                    BeilagenHiddenText += "<tr><td>" + txtObject + "</td><td><renderMultiMedia referencedObject = \"" + refObject + "\"/></td></tr>";
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
                    else
                    {
                        rBeilage.SubItems["NoPDFA1aAccepted"].Value = false;
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
                lblSize.Text = (Math.Round((float)iSizeTotal / 1000, 1)).ToString() + " kB von max. " + sMaxSize + " kB benutzt.";
            }

            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.lvBeilagen_ItemCheckStateChanged: " + ex.ToString());
            }
        }

        public MemoryStream GenerateCDA(bool CreateFile)
        {
            try
            {
                if (ReturnCode != eStatusResult.MissingData)
                {
                    //Header schreiben
                    rtfMeldungen2.Text = "";
                    InitCDA();
                    MakeCDAKlient();
                    MakeCDAAuthor();
                    MakeCDAVerwahrer();
                    MakeCDAEmpfaenger();
                    MakeCDARechtlicherUnterzeichner();
                    MakeCDAAnsprechperson();
                    MakeCDAHausarzt();
                    MakeCDAKontaktpersonen();
                    MakeCDAKrankenkasse();
                    MakeCDAAufenthaltService();
                    MakeCDAAufenthaltInfo();

                    //Fachliche Sektionen schreiben
                    CreateCDAFachlicheSektionen();

                    //CDA erzeugen
                    return CreateCDA(CreateFile ? sFileName : "");                    
                }
                else
                {                    
                    return new MemoryStream();
                }
            }
            catch(Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.GenerateCDA: " + ex.ToString());
            }
        }
        
        private void btnAddBeilageFrei_Click(object sender, EventArgs e)
        {
            int iCountBeilagen = lvBeilagen.Items.Count;
            System.Windows.Forms.OpenFileDialog fileDialog = new System.Windows.Forms.OpenFileDialog();
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

        private SET<AD> NewAdress(PostalAddressUse Adressart, string ZIP, string City, string Street, string State, string Country, string MsgText)
        {
            ccode cCountry = SearchELGACode(Country, "LND");
            if (cCountry.code != null)
                Country = cCountry.code;
            try
            {
                string sStreet = Street;
                string sCity = City;
                string sZIP = ZIP;
                string sCountry = Country;

                int iErr = 0;
                string sErr = "";
                if (String.IsNullOrWhiteSpace(sStreet))
                {
                    sStreet = "Unbekannt";
                    sErr += " - Straße ist leer";
                    iErr++;
                }

                if (String.IsNullOrWhiteSpace(sZIP))
                {
                    sZIP = "Unbekannt";
                    sErr +=  " - PLZ ist leer";
                    iErr++;
                }

                if (String.IsNullOrWhiteSpace(sCity))
                {
                    sCity = "Unbekannt";
                    sErr += " - Ort ist leer";
                    iErr++;
                }

                if (String.IsNullOrWhiteSpace(sCountry))
                {
                    sCountry = "Unbekannt";
                    sErr += " - Land ist leer";
                    iErr++;
                }

                if (iErr > 0)
                    rtfMeldungen2.Text += "Hinweis: " + MsgText + sErr + "\r\n";

                SET<AD> Addr = new SET<AD>(
                        new AD(Adressart,
                            new ADXP[]{
                            new ADXP(sStreet, AddressPartType.StreetAddressLine),
                            new ADXP(sCity, AddressPartType.City),
                            new ADXP(sZIP, AddressPartType.PostalCode),
                            new ADXP(sCountry, AddressPartType.Country)}));
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
                ccode c = ELGACodes.Where(x => x.Bezeichnung == sBezeichnung && x.IDAuswahllisteGruppe == sAuswahllisteGruppe).FirstOrDefault();
                if (c != null)
                    return c;
                else
                    return new ccode();
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.CDABAL.CDA.SearchELGACode: " + ex.ToString());
            }
        }

        private void btnCreateDev_Click(object sender, EventArgs e)
        {
            GenerateCDA(true);
        }
    }
}