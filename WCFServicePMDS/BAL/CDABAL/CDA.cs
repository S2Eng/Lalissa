using MARC.Everest.Attributes;
using MARC.Everest.DataTypes;
using MARC.Everest.DataTypes.Interfaces;
using MARC.Everest.Formatters.XML.Datatypes.R1;
using MARC.Everest.RMIM.UV.CDAr2.POCD_MT000040UV;
using MARC.Everest.RMIM.UV.CDAr2.Vocabulary;
using MARC.Everest.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using WCFServicePMDS.BAL;
using WCFServicePMDS.DAL;
using WCFServicePMDS.DAL.DTO;
using WCFServicePMDS.DAL.Interfaces;
using WCFServicePMDS.GenericClasses;
using static WCFServicePMDS.BAL.Main.PatientMainDTO;
using WCFServicePMDS.BAL.Main;
using MARC.Everest.RMIM.UV.NE2010.Interactions;
using MARC.Everest.Formatters.XML.ITS1;

namespace WCFServicePMDS.CDABAL
{

    public class CDA
    {

        public Dictionary<string, string> StaticCCDAData = new Dictionary<string, string>();



        public enum eTypeCDA
        {
            Entlassungsbrief = 0,
            Pflegesituationsbericht = 1
        }
        private enum eParticipation
        {
            NotfallKontakt = 0,
            Angehörige = 1,
            FachlicherAnsprechpartner = 2,
            RechtlicherUnterzeichner = 5,
            Versicherung = 6
        }


        public class parCDA
        {
            public WCFServicePMDS.Repository.RepositoryWrapper _rep;

            public CDAIN varsIn;
            public IKlinik _klinik;
            public IBenutzerDAL _benDAL;
            public IAufenthalt _aufDAL;
            public IAbteilung _abtDAL;
            public IPatient _patDAL;
            public ISachwalter _patSachw;
            public IKontaktperson _kontPers;
            public IAdresse _adr;
            public IKontakt _kont;
            public IAerzte _aerzte;
            public IAuswahlliste _ausw;
            public IKontaktperson _KontaktPerson;
            public IEinrichtung _Versicherung;
            public IEinrichtung _Einrichtung;


            public KlinikDTO Klinik { get; set; }
            public AdresseDTO KlinikAdr { get; set; }
            public KontaktDTO KlinikKont { get; set; }


            public PatientELGA Patient { get; set; }

            public Guid IDBenutzer { get; set; }
            public BenutzerSTOS1 Benutzer { get; set; }

            public DateTime dNow { get; set; }
            public eTypeCDA TypeCDA { get; set; }
            public INT VersionsNr { get; set; }
            public Guid DocumentID { get; set; }
            public string setID { get; set; }


            public WCFServicePMDS.Repository.RepositoryWrapper repoWrapper { get; set; }

        }
        public class PatientELGA
        {
            public Guid IDAufenthalt { get; set; }
            public cValDisplay PatientGender { get; set; }
            public cValDisplay PatientMaritalStatus { get; set; }
            public cValDisplay PatientKonfession { get; set; }


            public AufenthaltDTO Aufenthalt { get; set; }
            public PatientS1DTO Patient { get; set; }
            public AdresseDTO Adress { get; set; }
            public KontaktDTO Kontakt { get; set; }
            public List<SachwalterS1DTO> Sachwalter { get; set; }
            public List<AerzteDTO> Aerzte { get; set; }
            public List<KontaktpersonS1DTO> KontakPersonen { get; set; }
            public EinrichtungDTO Versicherung { get; set; }
            public AdresseDTO VersicherungAdr { get; set; }
            public KontaktDTO VersicherungKont { get; set; }

            public EinrichtungDTO Einrichtung { get; set; }
            public AdresseDTO EinrichtungAdr { get; set; }
            public KontaktDTO EinrichtungKont { get; set; }

            public PatientDTO PatientDt { get; set; }
        }
        public class SachwalterELGA
        {
            public Guid ID { get; set; }
            public cAdress adress { get; set; }

            public SachwalterDTO Sachwalter { get; set; }
        }
        public class ArztELGA
        {
            public Guid ID { get; set; }
            public cAdress adress { get; set; }

            public AerzteDTO Aerzt { get; set; }
        }
        public class cValDisplay
        {
            public string val { get; set; }
            public string display { get; set; }
        }

        public class cAdress
        {
            public Guid ID { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string Street { get; set; }
            public string Zip { get; set; }
        }
        public class cKontakt
        {
            public Guid ID { get; set; }
            public string Tel { get; set; }
        }


        public static string Last_XMLExport = "";

        public class CDAIN
        {
            public Guid IDAufenthalt { get; set; }
            public Guid IDBenutzer { get; set; }
            public Nullable<Guid> IDEinrichtungEmpfänger { get; set; }
            public Guid IDBenutzerVidierung { get; set; }
            public eTypeCDA TypeCDA { get; set; }
            public string Stylesheet { get; set; }
            public int VersionsNr { get; set; }
            public Guid IDDocument { get; set; }
            public string Documentname { get; set; }
            public string IDSet { get; set; }

            public string IDEmpfänger { get; set; }

            public Guid IDClient { get; set; }

            public Nullable<Guid> IDDokumenteneintrag { get; set; }
        }

        public class CDABack
        {
            public byte[] docu { get; set; }
        }





        private static II NewII(string root, string AssigningAuthorityName = "ELGA")
        {
            return new II { Root = root, AssigningAuthorityName = AssigningAuthorityName };
        }




        public CDABack gen(CDAIN vars)
        {
            try
            {
                using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(vars.IDClient))
                {
                    CDABack b = new CDABack();

                    StaticCCDAData = GetXMLValues();

                    //ENV.ENVWcf.OIDGDA = "2.16.840.1.113883.4.6";   //lth >> OIDGDA aus klinik lesen und Recipiant (Kommt aus ELGA Funktion) befüllen
                    parCDA pars = new parCDA()
                    {
                        varsIn = vars,
                        Patient = new PatientELGA() { IDAufenthalt = vars.IDAufenthalt },
                        IDBenutzer = vars.IDBenutzer,
                        dNow = DateTime.Now,
                        TypeCDA = vars.TypeCDA,
                        VersionsNr = vars.VersionsNr,
                        DocumentID = vars.IDDocument,
                        setID = vars.IDSet,
                        repoWrapper = repoWrapper
                    };

                    pars._rep = new WCFServicePMDS.Repository.RepositoryWrapper(vars.IDClient);
                    pars._klinik = new KlinikDAL(pars._rep);
                    pars._benDAL = new BenutzerDAL(pars._rep);
                    pars._aufDAL = new AufenthaltDAL(pars._rep);
                    pars._abtDAL = new AbteilungDAL(pars._rep);
                    pars._patDAL = new PatientDAL(pars._rep);
                    pars._patSachw = new SachwalterDAL(pars._rep);
                    pars._kontPers = new KontaktpersonDAL(pars._rep);
                    pars._adr = new AdresseDAL(pars._rep);
                    pars._kont = new KontaktDAL(pars._rep);
                    pars._aerzte = new AerzteDAL(pars._rep);
                    pars._ausw = new AuswahlListeDAL(pars._rep);
                    pars._KontaktPerson = new KontaktpersonDAL(pars._rep);
                    pars._Versicherung = new EinrichtungDAL(pars._rep);
                    pars._Einrichtung = new EinrichtungDAL(pars._rep);

                    pars.Benutzer = pars._benDAL.BenutzerS1(pars.IDBenutzer);
                    pars.Patient.Aufenthalt = pars._aufDAL.getAufenthalt(pars.Patient.IDAufenthalt);
                    pars.Patient.Patient = pars._patDAL.PatientS1(pars.Patient.Aufenthalt.Idpatient.Value);
                    pars.Patient.Adress = pars._adr.getAdress(pars.Patient.Patient.Idadresse.Value);
                    pars.Patient.Kontakt = pars._kont.getKontakt(pars.Patient.Patient.Idkontakt.Value);
                    pars.Patient.Sachwalter = pars._patSachw.SachwalterS1(pars.Patient.Aufenthalt.Idpatient.Value, pars.dNow);
                    pars.Patient.PatientDt = pars._patDAL.getPatientByID(pars.Patient.Patient.Id);                  //PatientMainBAL.getPatientByID(pars.Patient.Patient.Id);
                    pars.Patient.KontakPersonen = pars._KontaktPerson.KontaktpersonS1(pars.Patient.Aufenthalt.Idpatient.Value);

                    pars.Patient.Versicherung = pars._Einrichtung.getEinrichtungByBezeichnung(pars.Patient.Patient.KrankenKasse);
                    if (pars.Patient.Versicherung != null)
                    {
                        pars.Patient.VersicherungKont = pars._kont.getKontakt(pars.Patient.Versicherung.Idkontakt);
                        pars.Patient.VersicherungAdr = pars._adr.getAdress(pars.Patient.Versicherung.Idadresse);
                    }
                    
                    pars.Patient.Einrichtung = pars._Einrichtung.getEinrichtungByID(vars.IDEinrichtungEmpfänger.Value);
                    pars.Patient.EinrichtungKont = pars._kont.getKontakt(pars.Patient.Einrichtung.Idkontakt);
                    pars.Patient.EinrichtungAdr = pars._adr.getAdress(pars.Patient.Einrichtung.Idadresse);

                    pars.Klinik = pars._klinik.KlinikByIdAufenthalt(pars.Patient.Aufenthalt.Id);
                    pars.KlinikAdr = pars._adr.getAdress(pars.Klinik.Idadresse);
                    pars.KlinikKont = pars._kont.getKontakt(pars.Klinik.Idkontakt);

                    if (vars.IDDokumenteneintrag != null)
                    {
                        this.embeddDocuPflegebegleitschreiben(pars, vars);
                    }

                    ClinicalDocument ccda = new ClinicalDocument();
                    ccda.Participant = new List<Participant1>();
                    Guid IDCDA = System.Guid.NewGuid();

                    MakeCCDAHeader(ccda, vars.TypeCDA, pars);

                    string sXMLExport = ENV.ENVWcf.TempPathWin + "\\EntlassungsbriefTest_XML_" + IDCDA.ToString() + ".xml";

                    using (MARC.Everest.Xml.XmlStateWriter xsw = new XmlStateWriter(XmlWriter.Create(sXMLExport, new XmlWriterSettings() { Indent = true, ConformanceLevel = ConformanceLevel.Document })))
                    {
                        DateTime start = DateTime.Now;
                        XmlIts1Formatter fmtr = new MARC.Everest.Formatters.XML.ITS1.XmlIts1Formatter();
                        fmtr.ValidateConformance = false;
                        fmtr.GraphAides.Add(new DatatypeFormatter() { CompatibilityMode = DatatypeFormatterCompatibilityMode.ClinicalDocumentArchitecture });
                        fmtr.BuildCache(new Type[] {
                                                 typeof(PRPA_IN201305UV02),
                                                 typeof(PRPA_IN201309UV02)
                                             });
                        var result = fmtr.Graph(xsw, ccda);
                        xsw.Flush();
                    }

                    string sXMLExportChilKat = ENV.ENVWcf.TempPathWin + "\\EntlassungsbriefTest_Style_" + IDCDA.ToString() + ".xml";
                    Chilkat.Xml xml = new Chilkat.Xml();
                    xml.LoadXmlFile(sXMLExport);
                    if (vars.Stylesheet.Trim() == "")
                    {
                        throw new Exception("WCFServicePMDS.CDABAL.CDA.gen: vars.Stylesheet='' not allowed!");
                    }

                    xml.AddStyleSheet("<?xml-stylesheet href = \"" + vars.Stylesheet.Trim() + "\" type = \"text/xsl\"?>");
                    //xml.SaveXml(sXMLExportChilKat);

                    byte[] bXml = WCFServicePMDS.Repository.serialize.BinarySerialize<string>(xml.ToString());
                    //string sXmlDes = (string)WCFServicePMDS.Repository.serialize.BinaryDeserialize(bXml);
                    //System.IO.File.WriteAllText(sXMLExportChilKat, sXmlDes);
                    //byte[] bXml = System.Text.Encoding.UTF8.GetBytes(xml.ToString());
                    //System.Diagnostics.Process.Start(sXMLExportChilKat);

                    b.docu = bXml;
                    return b;

                    //System.IO.File.Delete(sXMLExport);
                    //System.GC.Collect();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.CDABAL.CDA.gen: " + ex.ToString());
            }
        }

        private void MakeCCDAHeader(ClinicalDocument ccda, eTypeCDA TypeCDA, parCDA pars)
        {
            MakeStaticSection(ccda, pars);
            MakeRecordTargetNode(ccda, pars);
            MakeAuthorNode(ccda, pars);
            //MakeDataEntererNode(ccda);
            MakeCustodianNode(ccda, pars);
            MakeInformationRecipientNode(ccda, pars);

            MakeLegalAuthenticatorNode(ccda, ref pars);

            MakeParticipantNode(ccda, pars, eParticipation.RechtlicherUnterzeichner);             //lth VALIDIERUNG >> Edit CDA Dokument - Funktion (Rechtl. Ansprechperson)
            MakeParticipantNode(ccda, pars, eParticipation.FachlicherAnsprechpartner);
            //MakeParticipantNode(ccda, pars, eParticipation.EinweisenderArzt);
            MakeParticipantNodeHausarzt(ccda, pars);
            MakeParticipantNodeNotfallKontakt(ccda, pars);
            MakeParticipantNodeAngehörige(ccda, pars);
            MakeParticipantNodeVersicherung(ccda, pars);

            MakeDocumentationOfNode(ccda, pars);
            MakeComponentOfNode(ccda, pars);
        }


        private void MakeStaticSection(ClinicalDocument ccda, parCDA pars)
        {
            ccda.RealmCode = new SET<CS<BindingRealm>>(new CS<BindingRealm>(BindingRealm.Austria));
            ccda.TypeId = new II { Root = "2.16.840.1.113883.1.3", Extension = "POCD_HD000040" };

            ccda.TemplateId = new LIST<II>();
            if (pars.TypeCDA == eTypeCDA.Entlassungsbrief)
            {
                ccda.TemplateId.Add(NewII("1.2.40.0.34.11.1"));
                ccda.TemplateId.Add(NewII("1.2.40.0.34.11.3"));
                ccda.TemplateId.Add(NewII("1.2.40.0.34.11.3.0.3"));
                ccda.Code = new CE<string>("34745-0", "2.16.840.1.113883.6.1", "LOINC", null, "Nurse Discharge Summery", null);
                ccda.Title = new ST("Entlassungsbrief (Pflege)"); 
            }
            else
            {
                ccda.TemplateId.Add(NewII("1.2.40.0.34.11.1"));
                ccda.TemplateId.Add(NewII("1.2.40.0.34.11.12"));
                ccda.TemplateId.Add(NewII("1.2.40.0.34.11.12.0.3"));
                ccda.Code = new CE<string>("28651-8", "2.16.840.1.113883.6.1", "LOINC", null, "Nurse Transfer Note", null);
                ccda.Title = new ST("Pflegesituationsbericht");                     
            }

            ccda.Id = new II(pars.DocumentID);
            ccda.Id.AssigningAuthorityName = pars.Klinik.Bezeichnung.Trim();
            ccda.SetId = new II(new Guid(pars.setID));      //lthDeactivatedTmp
            ccda.VersionNumber = pars.VersionsNr;
            ccda.EffectiveTime = pars.dNow;
            ccda.ConfidentialityCode = new CE<x_BasicConfidentialityKind>(x_BasicConfidentialityKind.Normal, "2.16.840.1.113883.5.25", "HL7:Confidentiality", null);
            ccda.ConfidentialityCode.DisplayName = "normal";
            ccda.LanguageCode = new CS<string>("de-AT");
        }

        private void MakeAuthorNode(ClinicalDocument ccda, parCDA pars)
        {
            Author a = new Author() { };
            a.Time = pars.dNow;

            AssignedAuthor aa = new AssignedAuthor() { };

            AbteilungDTO rAbt = pars._abtDAL.getAbteilungById(pars.Patient.Aufenthalt.Idabteilung.Value); 
            aa.Id = new SET<II>(new II(pars.Klinik.ElgaOid) { Extension = rAbt .Bezeichnung.TrimEnd()});

            //aa.Addr = NewAdress(PostalAddressUse.PostalAddress, pars.KlinikAdr.Plz, pars.KlinikAdr.Ort, pars.KlinikAdr.Strasse, pars.KlinikAdr.Region, pars.KlinikAdr.LandKz);
            aa.Telecom = NewTelefon(pars.KlinikKont.Tel, TelecommunicationAddressUse.WorkPlace);
            aa.SetAssignedAuthorChoice(NewPerson(pars.Benutzer.Nachname, pars.Benutzer.Vorname, "", true));
            aa.RepresentedOrganization = NewOrganisation(ref pars);

            a.AssignedAuthor = aa;
            ccda.Author.Add(a);
        }
        private void MakeCustodianNode(ClinicalDocument ccda, parCDA pars)
        {
            CustodianOrganization rco = new CustodianOrganization();

            rco.Id = new SET<II>(new II(pars.Klinik.ElgaOid));
            ON on = new ON();
            on.Part.Add(new ENXP(pars.Klinik.Bezeichnung));
            rco.Name = on;
            rco.Id[0].AssigningAuthorityName = "GDA Index";

            rco.Telecom = NewTelefon(pars.KlinikKont.Tel, TelecommunicationAddressUse.WorkPlace).First();
            rco.Addr = NewAdress(PostalAddressUse.PostalAddress, pars.KlinikAdr.Plz, pars.KlinikAdr.Ort, pars.KlinikAdr.Strasse, pars.KlinikAdr.Region, pars.KlinikAdr.LandKz).First();

            AssignedCustodian ac = new AssignedCustodian();
            ac.RepresentedCustodianOrganization = rco;

            Custodian custodian = new Custodian();
            custodian.AssignedCustodian = ac;
            ccda.Custodian = custodian;
        }
        private void MakeInformationRecipientNode(ClinicalDocument ccda, parCDA pars)
        {
            IntendedRecipient irc = new IntendedRecipient();
            if (!string.IsNullOrEmpty(pars.Patient.Einrichtung.ElgaOid))
                irc.Id = new SET<II>(new II(pars.Patient.Einrichtung.ElgaOid.Trim()));

            irc.ReceivedOrganization = NewReceipientOrganisation(ref pars);

            InformationRecipient infor = new InformationRecipient();
            infor.IntendedRecipient = irc;

            ccda.InformationRecipient = new List<InformationRecipient>();
            ccda.InformationRecipient.Add(infor);
        }

        private void MakeLegalAuthenticatorNode(ClinicalDocument ccda, ref parCDA pars)
        {
            //-------- Teilnehmende Parteien (ELGA 3.2) ---------

            LegalAuthenticator la = new LegalAuthenticator();
            la.Time = DateTime.Now;
            la.SignatureCode = new CS<string>("S");
            la.AssignedEntity = MakeLegalAuthenticatorNodePerson(ref pars);

            ccda.LegalAuthenticator = new LegalAuthenticator();
            ccda.LegalAuthenticator = la;
        }
        private AssignedEntity MakeLegalAuthenticatorNodePerson(ref parCDA pars)
        {
            // Rechtl. Ansprechperson
            AssignedEntity ae = new AssignedEntity();
            ae.Id = new SET<II>(new II(pars.Klinik.ElgaOid) { AssigningAuthorityName = pars.Klinik.Bezeichnung, Extension = "Leitung" });
            ae.Telecom = NewTelefon(pars.KlinikKont.Tel, TelecommunicationAddressUse.WorkPlace);
            ae.Addr = NewAdress(PostalAddressUse.PostalAddress, pars.KlinikAdr.Plz, pars.KlinikAdr.Ort, pars.KlinikAdr.Strasse, pars.KlinikAdr.Region, pars.KlinikAdr.LandKz);
            ae.AssignedPerson = NewPerson(pars.Klinik.Einrichtungsleiter, pars.Klinik.EinrichtungsleiterVorname, pars.Klinik.EinrichtungsleiterTitel, true);
            ae.RepresentedOrganization = NewOrganisation(ref pars);

            return ae;
        }


        private void MakeRecordTargetNode(ClinicalDocument ccda, parCDA pars)
        {

            RecordTarget rt = new RecordTarget();
            rt.ContextControlCode = ContextControl.OverridingPropagating;
            MakePatientRoleNode(rt, ccda, pars);

            ccda.RecordTarget.Add(rt);
        }

        private void MakePatientRoleNode(RecordTarget rt, ClinicalDocument ccda, parCDA pars)
        {
            PatientRole pr = new PatientRole();

            pr.Id = new SET<II> {
                new II { Root = pars.Patient.Patient.Id.ToString(), AssigningAuthorityName = pars.Klinik.Bezeichnung },
                new II { Root = "1.2.40.0.10.1.4.3.1", Extension = pars.Patient.Patient.VersicherungsNr, AssigningAuthorityName = "Österreichische Sozialversicherung" },
                new II { Root = "1.2.40.0.10.2.1.1.149", Extension = pars.Patient.Patient.BPk, AssigningAuthorityName = "Österreichische Stammzahlenregisterbehörde" }
            };

            if (pars.Patient.Patient.WohnungAbgemeldetJn.Value)
            {
                pr.Addr = NewAdress(PostalAddressUse.PrimaryHome, pars.KlinikAdr.Plz, pars.KlinikAdr.Ort, pars.KlinikAdr.Strasse, pars.KlinikAdr.Region, pars.KlinikAdr.LandKz);
                pr.Telecom = NewTelefon(pars.KlinikKont.Tel, TelecommunicationAddressUse.PrimaryHome);
                if (!String.IsNullOrEmpty(RegEx.StripCharacters(pars.Patient.Kontakt.Mobil)))
                    pr.Telecom = NewTelefon(RegEx.StripCharacters(pars.Patient.Kontakt.Mobil), TelecommunicationAddressUse.MobileContact);
            }
            else
            {
                pr.Addr = NewAdress(PostalAddressUse.PrimaryHome, pars.Patient.Adress.Plz, pars.Patient.Adress.Ort, pars.Patient.Adress.Strasse, pars.Patient.Adress.Region, pars.Patient.Adress.LandKz);
                if (!System.String.IsNullOrEmpty(RegEx.StripCharacters(pars.Patient.Kontakt.Tel)))
                    pr.Telecom = NewTelefon(RegEx.StripCharacters(pars.Patient.Kontakt.Tel), TelecommunicationAddressUse.PrimaryHome);
                if (!String.IsNullOrEmpty(RegEx.StripCharacters(pars.Patient.Kontakt.Mobil)))
                    pr.Telecom = NewTelefon(RegEx.StripCharacters(pars.Patient.Kontakt.Mobil), TelecommunicationAddressUse.MobileContact);
            }

            MakePatientNode(pr, ccda, pars);
            MakePatientNodeSachwalter(pr, ccda, pars);

            rt.PatientRole = pr;
        }

        private void MakePatientNode(PatientRole pr, ClinicalDocument ccda, parCDA pars)
        {
            Patient p = new Patient();
            //MyPatientMultipleRaceCodes p = new MyPatientMultipleRaceCodes();


            //hl: Titel nachgestellt ergänzen (wenn in DB verfügbar)
            if (!String.IsNullOrWhiteSpace(pars.Patient.Patient.Titel))
            {
                p.Name = new SET<PN>(
                    new PN(
                        new List<ENXP>{
                            new ENXP(pars.Patient.Patient.Titel),
                            new ENXP(pars.Patient.Patient.Vorname, EntityNamePartType.Given),
                            new ENXP(pars.Patient.Patient.Nachname, EntityNamePartType.Family)}));                
                p.Name[0].Part[0].Qualifier = new SET<CS<EntityNamePartQualifier>>() { EntityNamePartQualifier.Academic };
            }
            else
            {
                p.Name = new SET<PN>(
                    new PN(
                        new List<ENXP>{
                    new ENXP(pars.Patient.Patient.Vorname.Trim(), EntityNamePartType.Given),
                    new ENXP(pars.Patient.Patient.Nachname.Trim(), EntityNamePartType.Family)}));
            }

            AuswahlListeDAL auswDal = new AuswahlListeDAL(pars._rep);
            AuswahlListeDTO dtoAuswahl = auswDal.AuswahlListeBez("SEX", pars.Patient.Patient.Sexus, false);
            if (dtoAuswahl != null)
                p.AdministrativeGenderCode = new CE<string> { Code = dtoAuswahl.ElgaCode, CodeSystem = dtoAuswahl.ElgaCodeSystem, CodeSystemName = "HL7:AdministrativeGender", DisplayName = dtoAuswahl.ElgaDisplayName };
            else
                p.AdministrativeGenderCode.NullFlavor = MARC.Everest.DataTypes.NullFlavor.Unknown;

            p.BirthTime = new TS (pars.Patient.Patient.Geburtsdatum.Value.Date);
        
            dtoAuswahl = auswDal.AuswahlListeBez("FAM", pars.Patient.Patient.Familienstand, false);
            if (dtoAuswahl != null)
                p.AdministrativeGenderCode = new CE<string> { Code = dtoAuswahl.ElgaCode, CodeSystem = dtoAuswahl.ElgaCodeSystem, CodeSystemName = "HL7:MaritalStatus", DisplayName = dtoAuswahl.ElgaDisplayName };

            dtoAuswahl = auswDal.AuswahlListeBez("KON", pars.Patient.Patient.Konfision, false);
            if (dtoAuswahl != null)
                p.AdministrativeGenderCode = new CE<string> { Code = dtoAuswahl.ElgaCode, CodeSystem = dtoAuswahl.ElgaCodeSystem, CodeSystemName = "HL7.AT:ReligionAustria", DisplayName = dtoAuswahl.ElgaDisplayName };

            List<LanguageCommunication> lLang = new List<LanguageCommunication>();
            foreach (string sprache in pars.Patient.Patient.LstSprachen.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                dtoAuswahl = auswDal.AuswahlListeBez("SPA", sprache, false);
                if (dtoAuswahl != null)
                {
                    if (!string.IsNullOrEmpty(dtoAuswahl.ElgaCode))
                        lLang.Add(new LanguageCommunication(new CS<String>(dtoAuswahl.ElgaCode), null, null, null));
                }
            }
            if (lLang.Count() > 0)
            {
                p.LanguageCommunication.Add(new LanguageCommunication());
                p.LanguageCommunication = lLang;
            }

            pr.Patient = p;
        }

        private void MakePatientNodeSachwalter(PatientRole pr, ClinicalDocument ccda, parCDA pars)
        {
            foreach (SachwalterS1DTO sachwDto in pars.Patient.Sachwalter)
            {
                AdresseDTO a = pars._adr.getAdress(sachwDto.Idadresse);
                KontaktDTO k = pars._kont.getKontakt(sachwDto.Idkontakt);

                if (string.IsNullOrEmpty(sachwDto.Vorname))
                {
                    ON on = new ON();
                    on.Part.Add(new ENXP(!string.IsNullOrEmpty(sachwDto.Nachname) ? sachwDto.Nachname.Trim() : ""));

                    Organization org = new Organization(
                        null,
                        new SET<ON>(on),
                        new SET<TEL>(new TEL()),
                        new SET<AD>(new AD(new ADXP[] { })), new CE<string>(null, null, null, null, null, null),
                        null);

                    Guardian guardian = new Guardian() { Addr = NewAdress(PostalAddressUse.PostalAddress, a.Plz, a.Ort, a.Strasse, a.Region, a.LandKz), GuardianChoice = org };
                    pr.Patient.Guardian.Add(guardian);
                }
                else
                {
                    Person po = NewPerson(sachwDto.Nachname.Trim(), sachwDto.Vorname.Trim(), sachwDto.Titel, true);
                    Guardian guardian = new Guardian() { GuardianChoice = po };
                    pr.Patient.Guardian.Add(guardian);
                }
            }
        }

        private void MakeParticipantNodeNotfallKontakt(ClinicalDocument ccda, parCDA pars)
        {
            var t = pars.Patient.KontakPersonen.Where(o => o.VerstaendigenJn == true);
            foreach (var kp in t)
            {
                AdresseDTO a = pars._adr.getAdress(kp.Idadresse);
                KontaktDTO k = pars._kont.getKontakt(kp.Idkontakt);

                Participant1 participant = new Participant1();
                participant.TypeCode = new CS<ParticipationType>(ParticipationType.IND);
                participant.TemplateId = new LIST<II>();
                participant.TemplateId.Add(new II("1.2.40.0.34.11.1.1.4"));

                AuswahlListeS1DTO rAuswahl = (string.IsNullOrEmpty(kp.Verwandtschaft) ? null : pars._ausw.AuswahlListeS1(kp.Verwandtschaft, "VWV"));
                participant.AssociatedEntity = new AssociatedEntity();
                participant.AssociatedEntity.ClassCode = new CS<RoleClassAssociative>() { Code = new MARC.Everest.DataTypes.Primitives.CodeValue<RoleClassAssociative>(RoleClassAssociative.EmergencyContact) };
                participant.AssociatedEntity.Code = new CE<string>() { Code = (rAuswahl == null ? "" : rAuswahl.ElgaCode), DisplayName = (rAuswahl == null ? "" : rAuswahl.ElgaDisplayName), CodeSystem = "2.16.840.1.113883.5.111", CodeSystemName = "HL7:RoleCode" };
                participant.AssociatedEntity.Addr = NewAdress(PostalAddressUse.PostalAddress, a.Plz, a.Ort, a.Strasse, a.Region, a.LandKz);
                participant.AssociatedEntity.Telecom = NewTelefon(k.Tel, TelecommunicationAddressUse.Home);
                participant.AssociatedEntity.AssociatedPerson = NewPerson(kp.Nachname.Trim(), kp.Vorname.Trim(), "", true);

                ccda.Participant.Add(participant);
            }
        }
        private void MakeParticipantNodeAngehörige(ClinicalDocument ccda, parCDA pars)
        {
            var t = pars.Patient.KontakPersonen.Where(o => o.VerstaendigenJn == false);
            foreach (var kp in t)
            {
                AdresseDTO a = pars._adr.getAdress(kp.Idadresse);
                KontaktDTO k = pars._kont.getKontakt(kp.Idkontakt);

                Participant1 participant = new Participant1();
                participant.TypeCode = new CS<ParticipationType>(ParticipationType.IND);
                participant.TemplateId = new LIST<II>();
                participant.TemplateId.Add(new II("1.2.40.0.34.11.1.1.4"));

                AuswahlListeS1DTO rAuswahl = (string.IsNullOrEmpty(kp.Verwandtschaft) ? null : pars._ausw.AuswahlListeS1(kp.Verwandtschaft, "VWV"));
                participant.AssociatedEntity = new AssociatedEntity();
                participant.AssociatedEntity.ClassCode = new CS<RoleClassAssociative>() { Code = new MARC.Everest.DataTypes.Primitives.CodeValue<RoleClassAssociative>(RoleClassAssociative.PersonalRelationship) };
                participant.AssociatedEntity.Code = new CE<string>() { Code = (rAuswahl == null ? "" : rAuswahl.ElgaCode), DisplayName = (rAuswahl == null ? "" : rAuswahl.ElgaDisplayName), CodeSystem = "2.16.840.1.113883.5.111", CodeSystemName = "HL7:RoleCode" };
                participant.AssociatedEntity.Addr = NewAdress(PostalAddressUse.PostalAddress, a.Plz, a.Ort, a.Strasse, a.Region, a.LandKz);
                participant.AssociatedEntity.Telecom = NewTelefon(k.Tel, TelecommunicationAddressUse.Home);
                participant.AssociatedEntity.AssociatedPerson = NewPerson(kp.Nachname.Trim(), kp.Vorname.Trim(), "", true);

                ccda.Participant.Add(participant);
            }
        }
        private void MakeParticipantNodeVersicherung(ClinicalDocument ccda, parCDA pars)
        {
            try
            {
                Participant1 participant = new Participant1();
                participant.TypeCode = new CS<ParticipationType>(ParticipationType.Holder);
                participant.TemplateId = new LIST<II>();
                participant.TemplateId.Add(new II("1.2.40.0.34.11.1.1.6"));
                //participant.Time = new IVL<TS>(DateTime.Now, DateTime.Now);       //Versicherungszeitraum optional
                participant.AssociatedEntity = new AssociatedEntity();
                
                participant.AssociatedEntity.ClassCode = new CS<RoleClassAssociative>(RoleClassAssociative.PolicyHolder);
                participant.AssociatedEntity.Id = new SET<II>();

                participant.AssociatedEntity.Code = new CE<string>() { Code = "FAMDEP", DisplayName = "familiy dependent", CodeSystem = "2.16.840.1.113883.5.111", CodeSystemName = "HL7:RoleCode" };

                if (pars.Patient.Patient.SozVersStatus.Equals("selbstversichert", WCFString.ignore))
                {
                    if (string.IsNullOrEmpty(pars.Patient.Patient.VersicherungsNr))
                    {
                        if (pars.Patient.Patient.SozVersLeerGrund.Equals("Klient hat keine Sozialversicherungsnummer", WCFString.ignore))
                        {
                            //Patient ist nicht versichert (Ausländer) (Patient.SozVersLeerGrund = "Klient hat keine Sozialversicherungsnummer")
                            participant.AssociatedEntity.Id.NullFlavor = MARC.Everest.DataTypes.NullFlavor.NoInformation;
                        }
                        else
                        {
                            //Patient ist versichert, aber unbekannt wo (Patient.SozVersLeerGrund = "Sozialversicherungsnummer unbekannt")
                            participant.AssociatedEntity.Id.NullFlavor = MARC.Everest.DataTypes.NullFlavor.Unknown;
                        }
                    }
                    else
                    {
                        participant.AssociatedEntity.Id.Add(new II("1.2.40.0.10.1.4.3.1", pars.Patient.Patient.VersicherungsNr.Trim()));
                        participant.AssociatedEntity.Id[0].AssigningAuthorityName = "Österreichische Sozialversicherung";
                        participant.AssociatedEntity.Code = new CE<string>() { Code = "SELF", DisplayName = "self", CodeSystem = "2.16.840.1.113883.5.111", CodeSystemName = "HL7:RoleCode" };

                        if (pars.Patient.Versicherung != null)
                        {
                            Organization org = new Organization() { };
                            ON on = new ON();
                            on.Part.Add(new ENXP(pars.Patient.Versicherung.Text.Trim()));
                            org.Name = new SET<ON>(on);
                            org.Telecom = NewTelefon(pars.Patient.VersicherungKont.Tel, TelecommunicationAddressUse.WorkPlace);
                            org.Addr = NewAdress(PostalAddressUse.PostalAddress, pars.Patient.VersicherungAdr.Plz, pars.Patient.VersicherungAdr.Ort, pars.Patient.VersicherungAdr.Strasse, pars.Patient.VersicherungAdr.Region, pars.Patient.VersicherungAdr.LandKz);
                            participant.AssociatedEntity.ScopingOrganization = org;
                        }
                    }
                }
                else if (pars.Patient.Patient.SozVersStatus.Equals("mitversichert", WCFString.ignore))
                {
                    participant.AssociatedEntity.Id.NullFlavor = MARC.Everest.DataTypes.NullFlavor.Unknown;
                    participant.AssociatedEntity.Code = new CE<string>() { Code = "FAMDEP", DisplayName = "familiy dependent", CodeSystem = "2.16.840.1.113883.5.111", CodeSystemName = "HL7:RoleCode" };
                    participant.AssociatedEntity.AssociatedPerson = NewPerson(pars.Patient.Patient.SozVersMitversichertBei.Trim(), "", "", false);

                    if (pars.Patient.Versicherung != null)
                    {
                        Organization org = new Organization() { };
                        ON on = new ON();
                        on.Part.Add(new ENXP(pars.Patient.Versicherung.Text.Trim()));
                        org.Name = new SET<ON>(on);
                        org.Telecom = NewTelefon(pars.Patient.VersicherungKont.Tel, TelecommunicationAddressUse.WorkPlace);
                        org.Addr = NewAdress(PostalAddressUse.PostalAddress, pars.Patient.VersicherungAdr.Plz, pars.Patient.VersicherungAdr.Ort, pars.Patient.VersicherungAdr.Strasse, pars.Patient.VersicherungAdr.Region, pars.Patient.VersicherungAdr.LandKz);
                        participant.AssociatedEntity.ScopingOrganization = org;
                    }
                }

                participant.AssociatedEntity.Id.Add(new II("1.2.40.0.10.1.4.3.1", "SVNR des Patienten"));
                participant.AssociatedEntity.Code = new CE<string>() { Code = "SELF", DisplayName = "self", CodeSystem = "2.16.840.1.113883.5.111", CodeSystemName = "HL7:RoleCode" };
                if (pars.Patient.Patient.WohnungAbgemeldetJn.Value)
                {
                    participant.AssociatedEntity.Addr = NewAdress(PostalAddressUse.PostalAddress, pars.KlinikAdr.Plz, pars.KlinikAdr.Ort, pars.KlinikAdr.Strasse, pars.KlinikAdr.Region, pars.KlinikAdr.LandKz);
                    participant.AssociatedEntity.Telecom = NewTelefon(pars.KlinikKont.Tel, TelecommunicationAddressUse.WorkPlace);
                }
                else
                {
                    participant.AssociatedEntity.Addr = NewAdress(PostalAddressUse.PostalAddress, pars.Patient.Adress.Plz, pars.Patient.Adress.Ort, pars.Patient.Adress.Strasse, pars.Patient.Adress.Region, pars.Patient.Adress.LandKz);
                    participant.AssociatedEntity.Telecom = NewTelefon(pars.Patient.Kontakt.Tel, TelecommunicationAddressUse.WorkPlace);
                }

                ccda.Participant.Add(participant);
            }
            catch (Exception ex)
            {
                throw new Exception("MakeParticipantNodeVersicherung: " + ex.ToString());
            }
        }

        private void MakeParticipantNode(ClinicalDocument ccda, parCDA pars, eParticipation Participation)
        {
            ParticipationType ParticipationTyp = ParticipationType.Admitter;

            if (Participation == eParticipation.FachlicherAnsprechpartner)
            {
                ParticipationTyp = ParticipationType.CallbackContact;
            }
            else if (Participation == eParticipation.RechtlicherUnterzeichner)
            {
                ParticipationTyp = ParticipationType.LegalAuthenticator;
            }
            else
                throw new Exception("MakeParticipantNode: Participation '" + Participation.ToString() + "' not allowed!");

            Participant1 participant = new Participant1();
            participant.TypeCode = new CS<ParticipationType>(ParticipationTyp);
            participant.AssociatedEntity = new AssociatedEntity();
            participant.AssociatedEntity.ClassCode = new CS<RoleClassAssociative>(RoleClassAssociative.HealthcareProvider);
            participant.AssociatedEntity.Addr = NewAdress(PostalAddressUse.PostalAddress, pars.KlinikAdr.Plz, pars.KlinikAdr.Ort, pars.KlinikAdr.Strasse, pars.KlinikAdr.Region, pars.KlinikAdr.LandKz);
            participant.AssociatedEntity.Telecom = NewTelefon(pars.KlinikKont.Tel, TelecommunicationAddressUse.WorkPlace);
            participant.AssociatedEntity.AssociatedPerson = NewPerson(pars.Benutzer.Nachname.Trim(), pars.Benutzer.Vorname.Trim(), "", true);

            ccda.Participant.Add(participant);
        }

        private void MakeParticipantNodeHausarzt(ClinicalDocument ccda, parCDA pars)
        {
            pars.Patient.Aerzte = pars._aerzte.AerzteS1ByELGAHausarzt(pars.Patient.Aufenthalt.Idpatient.Value);
            if (pars.Patient.Aerzte.Count() == 1)
            {
                AdresseDTO a = pars._adr.getAdress(pars.Patient.Aerzte.First().Idadresse);
                KontaktDTO k = pars._kont.getKontakt(pars.Patient.Aerzte.First().Idkontakt);

                Participant1 participant = new Participant1();
                participant.TypeCode = new CS<ParticipationType>(ParticipationType.IND);
                participant.TemplateId = new LIST<II>();
                participant.TemplateId.Add(new II("1.2.40.0.34.11.1.1.3"));

                participant.FunctionCode = new MARC.Everest.DataTypes.CD<string>() { Code = "PCP", DisplayName = "primary care physican", CodeSystem = "2.16.840.1.113883.5.88", CodeSystemName = "HL7:ParticipationFunction" };
                participant.AssociatedEntity = new AssociatedEntity();
                participant.AssociatedEntity.ClassCode = new CS<RoleClassAssociative>() { Code = new MARC.Everest.DataTypes.Primitives.CodeValue<RoleClassAssociative>(RoleClassAssociative.HealthcareProvider) };

                participant.AssociatedEntity.Id = new SET<II>();
                if (String.IsNullOrEmpty(pars.Patient.Aerzte.First().ElgaOid))
                {
                    participant.AssociatedEntity.Id.Add(new II());
                    participant.AssociatedEntity.Id[0].NullFlavor = new CS<NullFlavor>(NullFlavor.Unknown);
                }
                else
                {
                    participant.AssociatedEntity.Id.Add(new II(pars.Patient.Aerzte.First().ElgaOid));
                }

                participant.AssociatedEntity.AssociatedPerson = NewPerson(pars.Patient.Aerzte.First().Nachname.Trim(), pars.Patient.Aerzte.First().Vorname.Trim(), pars.Patient.Aerzte.First().Titel.Trim(), true);

                SET<AD> adr;
                SET<TEL> tel = new SET<TEL>();
                ON on = new ON();
                Organization org = new Organization();
                if (string.IsNullOrEmpty(a.Plz) && string.IsNullOrEmpty(a.Ort) && string.IsNullOrEmpty(a.Strasse) && string.IsNullOrEmpty(a.LandKz))     //nicht angestellter arzt
                {
                    adr = NewAdress(PostalAddressUse.PostalAddress, a.Plz, a.Ort, a.Strasse, a.Region, a.LandKz);
                    if (!string.IsNullOrEmpty(k.Tel))
                        tel = NewTelefon(k.Tel, TelecommunicationAddressUse.WorkPlace);
                    if (!string.IsNullOrEmpty(k.Mobil))
                        tel = NewTelefon(k.Mobil, TelecommunicationAddressUse.MobileContact);

                    on.Part.Add(new ENXP((pars.Patient.Aerzte.First().Titel + " " + pars.Patient.Aerzte.First().Nachname + " " + pars.Patient.Aerzte.First().Vorname).Trim()));

                    org.Id = new SET<II>();
                    if (String.IsNullOrEmpty(pars.Patient.Aerzte.First().ElgaOid))
                    {
                        org.Id.Add(new II());
                        org.Id[0].NullFlavor = new CS<NullFlavor>(NullFlavor.Unknown);
                    }
                    else
                    {
                        org.Id.Add(new II(pars.Patient.Aerzte.First().ElgaOid));
                        org.Id[0].AssigningAuthorityName = "GDA Index";
                    }
                    participant.AssociatedEntity.ScopingOrganization = org;
                }
                else
                {
                    adr = NewAdress(PostalAddressUse.PostalAddress, pars.KlinikAdr.Plz, pars.KlinikAdr.Ort, pars.KlinikAdr.Strasse, pars.KlinikAdr.Ort, pars.KlinikAdr.LandKz);
                    if (!string.IsNullOrEmpty(pars.KlinikKont.Tel))
                        tel = NewTelefon(pars.KlinikKont.Tel, TelecommunicationAddressUse.WorkPlace);
                    if (!string.IsNullOrEmpty(pars.KlinikKont.Mobil))
                        tel = NewTelefon(pars.KlinikKont.Mobil, TelecommunicationAddressUse.MobileContact);

                    on.Part.Add(new ENXP(pars.Klinik.Bezeichnung));

                    org.Id = new SET<II>();
                    org.Id.Add(new II(pars.Klinik.ElgaOid));
                    org.Id[0].AssigningAuthorityName = "GDA Index";
                    participant.AssociatedEntity.ScopingOrganization = org;
                }

                if (tel.Count() == 0)
                    org = new Organization(null, new SET<ON>(on), null, adr, null, null);
                else
                    org = new Organization(null, new SET<ON>(on), tel, adr, null, null);

                ccda.Participant.Add(participant);
            }
        }

        private void MakeDocumentationOfNode(ClinicalDocument ccda, parCDA pars)
        {
            ServiceEvent se = new ServiceEvent();
            if (pars.Patient.Aufenthalt.Entlassungszeitpunkt != null)
                se.EffectiveTime = new IVL<TS>(new TS(pars.Patient.Aufenthalt.Aufnahmezeitpunkt.Value.Date), new TS(pars.Patient.Aufenthalt.Entlassungszeitpunkt.Value));
            else
                se.EffectiveTime = new IVL<TS>(new TS(pars.Patient.Aufenthalt.Aufnahmezeitpunkt.Value.Date));

            se.Code = new CE<string>("GDLSTATAUF", "1.2.40.0.34.5.21", "ELGA_ServiceEventsEntlassbrief", "", new ST("Gesundheitsdienstleistungen im Rahmen eines stationären Aufenthalts"), null);
            Performer1 performer = new Performer1();

            DocumentationOf docOf = new DocumentationOf();
            docOf.ServiceEvent = new ServiceEvent();
            docOf.ServiceEvent = se;

            ccda.DocumentationOf = new List<DocumentationOf>();
            ccda.DocumentationOf.Add(docOf);
        }
        private void MakeComponentOfNode(ClinicalDocument ccda, parCDA pars)
        {
            EncompassingEncounter ee = new EncompassingEncounter();
            ee.Id = new SET<II>(new II { Root = pars.Klinik.ElgaOid, Extension = pars.Patient.Aufenthalt.Id.ToString(), AssigningAuthorityName = pars.Klinik.Bezeichnung.Trim() }); 
            ee.Code = new CE<ActEncounterCode>(ActEncounterCode.InpatientNonacute, "2.16.840.1.113883.5.4", "HL7:ActCode", "", new ST("Inpatient encounter"), null);
            if (pars.Patient.Aufenthalt.Entlassungszeitpunkt != null)
                ee.EffectiveTime = new IVL<TS>(new TS(pars.Patient.Aufenthalt.Aufnahmezeitpunkt.Value.Date), new TS(pars.Patient.Aufenthalt.Entlassungszeitpunkt.Value.Date));
            else
            {
                ee.EffectiveTime = new IVL<TS>(new TS(pars.Patient.Aufenthalt.Aufnahmezeitpunkt.Value.Date), new TS (DateTime.Now));
                ee.EffectiveTime.High.NullFlavor = MARC.Everest.DataTypes.NullFlavor.Unknown;
            }

            ee.ResponsibleParty = new ResponsibleParty();

            AssignedEntity ae = new AssignedEntity();
            ae.AssignedPerson = NewPerson(pars.Benutzer.Nachname.Trim(), pars.Benutzer.Vorname.Trim(), "", false);
            ee.ResponsibleParty.AssignedEntity = ae;
            
            Location loc = new Location();
            loc.HealthCareFacility = new HealthCareFacility();
            Organization org = NewOrganisation(ref pars);
            org.Id = new SET<II>(new II("2.16.40.1.2.3", "GDA Index"));
            loc.HealthCareFacility.ServiceProviderOrganization = org;

            ee.Location = new Location();
            ee.Location = loc;

            Component1 componentOf = new Component1();
            componentOf.EncompassingEncounter = new EncompassingEncounter();
            componentOf.EncompassingEncounter = ee;

            ccda.ComponentOf = new Component1();
            ccda.ComponentOf = componentOf;
        }

        private Person NewPerson(string LastName, string Firstname, string Title, bool Prefix)
        {
            try
            {
                Person p = new Person(new SET<PN>(
                new PN(
                    new List<ENXP>{
                    new ENXP(LastName, EntityNamePartType.Given),
                    new ENXP(Firstname, EntityNamePartType.Family),
                    new ENXP(Title,  EntityNamePartType.Title)})));

                if (Title != "" && Prefix)
                    p.Name[0].Part[2].Qualifier = new SET<CS<EntityNamePartQualifier>>() { EntityNamePartQualifier.Prefix };
                else if (Title != "" && !Prefix)
                    p.Name[0].Part[2].Qualifier = new SET<CS<EntityNamePartQualifier>>() { EntityNamePartQualifier.Suffix };

                return p;
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.CDABAL.CDA.NewPerson: " + ex.ToString());
            }
        }

        public Organization NewOrganisation(ref parCDA pars)
        {
            Organization org = new Organization() { Id = new SET<II>(new II(pars.Klinik.ElgaOid)) };

            ON on = new ON();
            on.Part.Add(new ENXP(pars.Klinik.Bezeichnung));
            org.Name = new SET<ON>(on);
            org.Telecom = NewTelefon(pars.KlinikKont.Tel, TelecommunicationAddressUse.WorkPlace);
            org.Addr = NewAdress(PostalAddressUse.PostalAddress, pars.KlinikAdr.Plz, pars.KlinikAdr.Ort, pars.KlinikAdr.Strasse, pars.KlinikAdr.Region, pars.KlinikAdr.LandKz);

            org.Id[0].AssigningAuthorityName = "GDA Index";
            return org;
        }

        public Organization NewReceipientOrganisation(ref parCDA pars)
        {
            Organization org = new Organization();
            if (!string.IsNullOrEmpty(pars.Patient.Einrichtung.ElgaOid))
            {
                org.Id = new SET<II>(new II(pars.Patient.Einrichtung.ElgaOid));
                org.Id[0].AssigningAuthorityName = "GDA Index";
            }

            ON on = new ON();
            on.Part.Add(new ENXP(pars.Patient.Einrichtung.Text.Trim()));
            org.Name = new SET<ON>(on);
            org.Telecom = NewTelefon(pars.Patient.EinrichtungKont.Tel, TelecommunicationAddressUse.WorkPlace);
            org.Addr = NewAdress(PostalAddressUse.PostalAddress, pars.Patient.EinrichtungAdr.Plz, pars.Patient.EinrichtungAdr.Ort, pars.Patient.EinrichtungAdr.Strasse, pars.Patient.EinrichtungAdr.Region, pars.Patient.EinrichtungAdr.LandKz);

            return org;
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
                            new ADXP(State, AddressPartType.State),
                            new ADXP(ZIP, AddressPartType.PostalCode),
                            new ADXP(Country, AddressPartType.Country)}));

                return Addr;
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.CDABAL.CDA.NewAdress: " + ex.ToString());
            }
        }

        private SET<TEL> NewTelefon(string TelNr, TelecommunicationAddressUse Typ)
        {
            try
            {
                SET<TEL> tel = new SET<TEL>();
                tel.Add(new TEL(TelNr, Typ));
                return tel;
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.CDABAL.CDA.NewTelefon: " + ex.ToString());
            }
        }

        public Dictionary<string, string> GetXMLValues()
        {
            //TODO: Read from App_Data instead of bin\\debug
            string xmlFilePath = System.IO.Path.Combine(ENV.ENVWcf.ConfigPath, "StaticCCDAData.xml");
            Dictionary<string, string> dictionaryObject = new Dictionary<string, string>();

            XmlDocument ccdDocument = new XmlDocument();
            ccdDocument.Load(xmlFilePath);
            XmlNodeList xmlNodelist = ccdDocument.SelectNodes("section");
            foreach (XmlElement node in xmlNodelist[0].ChildNodes)
            {
                dictionaryObject.Add(node.Attributes[0].Value, node.Attributes[1].Value);
            }
            return dictionaryObject;
        }

        public void embeddDocuPflegebegleitschreiben(parCDA pars, CDAIN vars)
        {
            try
            {
                var rPfad = (from p in pars._rep.dbcontext.TblPfad
                             select new
                             {
                                 p.Archivpfad
                             }).First();

                var rDocu = (from d in pars._rep.dbcontext.TblDokumenteintrag
                             join d2 in pars._rep.dbcontext.TblDokumente on d.Id equals d2.Iddokumenteintrag
                             where d.Id == vars.IDDokumenteneintrag
                             select new
                             { d.Id, d2.Archivordner, d2.DateinameArchiv }).First();

                string FileArchive = Path.Combine(rPfad.Archivpfad.Trim(), rDocu.Archivordner.Trim(), rDocu.DateinameArchiv.Trim() + "");
                string sPdf = "";
                using (StreamReader sr = File.OpenText(FileArchive))
                {
                    sPdf = sr.ReadToEnd();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.CDABAL.CDA.embeddDocuPflegebegleitschreiben: " + ex.ToString());
            }
        }

    }

}

