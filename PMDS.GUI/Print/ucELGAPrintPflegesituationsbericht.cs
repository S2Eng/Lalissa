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

using MARC.Everest.Attributes;
using MARC.Everest.DataTypes;
using MARC.Everest.DataTypes.Interfaces;
using MARC.Everest.Formatters.XML.Datatypes.R1;
using MARC.Everest.RMIM.UV.CDAr2.POCD_MT000040UV;
using MARC.Everest.RMIM.UV.CDAr2.Vocabulary;
using MARC.Everest.Xml;
using System.Xml;
using MARC.Everest.Formatters.XML.ITS1;
using PMDS.Klient;
using Patagames.Pdf.Enums;
using Syncfusion.Windows.Forms;

namespace PMDS.GUI.Print
{


    public partial class ucELGAPrintPflegesituationsbericht : UserControl
    {
        private System.Globalization.CultureInfo currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;

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

        private class RTFTag
        {
            public SektionOrder Order;
            public String Tag;
            public RTFTyp Typ;
        }

        private class templateID
        {
            public string root;
            public string assigningAuthorityName = "ELGA";
        }

        private class ccode
        {
            public string code;
            public string displayName;
            public string codeSystem = "1.2.40.0.34.5.40";
            public string codeSystemName = "ELGA";
            public string originalText;
        }

        private class PflegediagnosenObservation
        {
            public string observation_classCode = "OBS";
            public string observation_moodCode = "EVN";
            public string observation_negationInd = "false";
            public List<templateID> templateIDs = new List<templateID> { new templateID { root = "1.2.40.0.34.11.1.3.6" },
                                                                         new templateID { root="1.3.6.1.4.1.19376.1.5.3.1.4.5", assigningAuthorityName="IHE PCC" },
                                                                         new templateID { root="2.16.840.1.113883.10.20.1.28", assigningAuthorityName="HL7 CCD" },
                                                                      };
            public Guid id_root;
            public ccode code = new ccode { code = "282291009", displayName = "Diagnosis", codeSystem = "2.16.840.1.113883.6.96", codeSystemName = "SNOMED CT" };
            public string text_reference;
            public string statusCode_code = "completed";
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

        private class PflegediagnoseEntry
        {
            public string act_classCode = "ACT";
            public string act_moodeCode = "EVN";
            public List<templateID> templateIDs = new List<templateID> { new templateID { root = "1.2.40.0.34.11.3.3.1"},
                                                                         new templateID { root="1.2.40.0.34.11.1.3.5"},
                                                                         new templateID { root="1.3.6.1.4.1.19376.1.5.3.1.4.5.1", assigningAuthorityName="IHE PCC" },
                                                                         new templateID { root="1.3.6.1.4.1.19376.1.5.3.1.4.5.2", assigningAuthorityName="IHE PCC" },
                                                                         new templateID { root="2.16.840.1.113883.10.20.1.27", assigningAuthorityName="HL7 CCD" },
                                                                      };
            public Guid id_root;
            public string code_nullFlavor = "NA";
            public string statusCode_code = "active";
            public DateTime effectiveTime_low_value;
            public PflegediagnosenEntryRelationship entryRelationship = new PflegediagnosenEntryRelationship();
        }

        private class VitalparameterObservation
        {
            public string observation_classCode = "OBS";
            public string observation_moodCode = "EVN";
            public string observation_negationInd = "false";
            public List<templateID> templateIDs = new List<templateID> { new templateID { root = "1.2.40.0.34.11.1.3.4" },
                                                                         new templateID { root="1.3.6.1.4.1.19376.1.5.3.1.4.13", assigningAuthorityName="IHE PCC" },
                                                                         new templateID { root="1.3.6.1.4.1.19376.1.5.3.1.4.13.2", assigningAuthorityName="IHE PCC" },
                                                                         new templateID { root="2.16.840.1.113883.10.20.1.31", assigningAuthorityName="HL7 CCD" },
                                                                      };
            public string id_root;
            public ccode code = new ccode();
            public string text_reference;
            public string statusCode_code = "completed";
            public string value_xsi_type = "PQ";
            public string value_code;
            public string value_unit;
        }

        private class VitalparameterEntry
        {
            public string typeCode = "DRIV";
            public string organizer_classCode = "CLUSTER";
            public string organizer_moodeCode = "EVN";
            public List<templateID> templateIDs = new List<templateID> { new templateID { root = "1.2.40.0.34.11.1.3.3"},
                                                                         new templateID { root="1.3.6.1.4.1.19376.1.5.3.1.4.13.1", assigningAuthorityName="IHE PCC" },
                                                                         new templateID { root="2.16.840.1.113883.10.20.1.32", assigningAuthorityName="HL7 CCD" },
                                                                         new templateID { root="2.16.840.1.113883.10.20.1.35", assigningAuthorityName="HL7 CCD" },
                                                                      };
            public Guid root;
            public ccode code = new ccode { code = "46680005", codeSystem = "2.16.840.1.113883.6.96", codeSystemName = "SNOMED CT", displayName = "Vital signs" };
            public string statusCode_code = "completed";
            public string effectiveTime;
            public List<VitalparameterObservation> observations = new List<VitalparameterObservation>();
        }

        private class Risiko
        {
            public List<templateID> templateIDs = new List<templateID> { new templateID { root = "1.2.40.0.34.11.1.2.8" } };
            public string title = "Risiken";
            public ccode code = new ccode { code = "51898-5", displayName = "Risk factors", codeSystem = "LOINC", codeSystemName = "LOINC" };
            public string textHTML;
            public string list_listType = "unordered";
            public string list_styleCode = "Disc";
            public List<string> items;
        }

        private class HilfsmittelRessourcen
        {
            public List<templateID> templateIDs = new List<templateID> { new templateID { root = "1.2.40.0.34.11.1.2.9" } };
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
            public List<templateID> templateIDs;
            public ccode code = new ccode { code = "", displayName = "", codeSystem = "", codeSystemName = "" };
            public string textHTML;
            public List<PflegediagnoseEntry> PflegediagnosenEntrys;
            //public VitalparameterEntry VitalparamterEntry;
            public Risiko Risiko;
            public HilfsmittelRessourcen HilfsmittelUndRessourcen;
            public string Tag;
        }

        private List<Sektion> Sektionen = new List<Sektion>();

        ClinicalDocument ccda = new ClinicalDocument();
        Component2 compSektionen = new Component2();
        MARC.Everest.Formatters.XML.ITS1.XmlIts1Formatter fmtr = new MARC.Everest.Formatters.XML.ITS1.XmlIts1Formatter();
        StructuredBody structBody = new StructuredBody();

        public ucELGAPrintPflegesituationsbericht()
        {
            InitializeComponent();
        }

        public void Init()
        {            
            //fmtr.RegisterXSITypeName("POCD_MT000040UV.Sender", typeof(ELGAStructuredBody));
            //fmtr.RegisterXSITypeName("POCD_MT000040UV.Sender", typeof(MyObservationMedia));
            //fmtr.Settings |= SettingsType.AlwaysCheckForOverrides;
            //Struktur befüllen
            InitRTFTags();
            InitSektionen();
            LoadPDx();
            LoadRessourcenRisiken();
            LoadVitalparameter();
            LoadMedDaten();
            LoadRezepte();
            LoadPatientenverfügung();
            LoadPflegeUndBetreuungsumfang();
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
                                            new List<templateID> { new templateID { root = "1.2.40.0.34.11.1.2.1" } },
                                            new ccode { code = "BRIEFT", displayName = "Brieftext" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Pflegediagnosen,
                                            eELGATypeSektion.Pflegediagnosen,
                                            "Pflegediagnosen",
                                            new List<templateID> { new templateID { root = "1.2.40.0.34.11.1.2.2" } },
                                            new ccode { code = "PFDIAG", displayName = "Pflegediagnosen" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Mobilität,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Mobilität", new List<templateID> { new templateID { root = "1.2.40.0.34.11.1.2.3" } },
                                            new ccode { code = "PFMOB", displayName = "Mobilität" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.KörperpflegeUndKleiden,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Körperpflege und Kleiden",
                                            new List<templateID> { new templateID { root = "1.2.40.0.34.11.1.2.4" } },
                                            new ccode { code = "PFKLEI", displayName = "Körperpflege und Kleiden" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Ernährung,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Ernährung",
                                            new List<templateID> { new templateID { root = "1.2.40.0.34.11.1.2.5" } },
                                            new ccode { code = "PFERN", displayName = "Ernährung" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Ausscheidung,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Ausscheidung",
                                            new List<templateID> { new templateID { root = "1.2.40.0.34.11.1.2.6" } },
                                            new ccode { code = "PFAUS", displayName = "Ausscheidung" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Hautzustand,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Hautzustand",
                                            new List<templateID> { new templateID { root = "1.2.40.0.34.11.1.2.7" } },
                                            new ccode { code = "PFHAUT", displayName = "Hautzustand" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Atmung,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Atmung",
                                            new List<templateID> { new templateID { root = "1.2.40.0.34.11.1.2.8" } },
                                            new ccode { code = "PFATM", displayName = "Atmung" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Schlaf,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Schlaf",
                                            new List<templateID> { new templateID { root = "1.2.40.0.34.11.1.2.9" } },
                                            new ccode { code = "PFSCHL", displayName = "Schlaf" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Schmerz,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Schmerz", new List<templateID> { new templateID { root = "1.2.40.0.34.11.1.2.10" },
                                                                              new templateID { root = "1.3.6.1.4.1.19376.1.5.3.1.1.20.2.4", assigningAuthorityName = "IHE PCC" } },
                                            new ccode { code = "38212-7", displayName = "Pain Assessment Panel", codeSystem = "2.16.840.1.113883.6.1", codeSystemName = "LOINC" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.OrientierungUndBewusstseinslage,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Orientierung und Bewusstseinslage",
                                            new List<templateID> { new templateID { root = "1.2.40.0.34.11.1.2.11" } },
                                            new ccode { code = "PFORIE", displayName = "Orientierung und Bewusstseinslage" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.SozialeUmständeUndVerhalten,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Soziale Umstände und Verhalten",
                                            new List<templateID> { new templateID { root = "1.2.40.0.34.11.1.2.12" } },
                                            new ccode { code = "PFSOZV", displayName = "Soziale Umstände und Verhalten" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Kommunikation,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Kommunikation",
                                            new List<templateID> { new templateID { root = "1.2.40.0.34.11.1.2.13" } },
                                            new ccode { code = "PFKOMM", displayName = "Kommunikation" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.RollenwahnehmungUndSinnfindung,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Rollenwahrnehmung und Sinnfindung",
                                            new List<templateID> { new templateID { root = "1.2.40.0.34.11.1.2.14" } },
                                            new ccode { code = "PFROLL", displayName = "Rollenwahrnehmung und Sinnfindung" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Vitalparameter,
                                            eELGATypeSektion.Vitalparameter,
                                            "Vitalparameter",
                                            new List<templateID> { new templateID { root = "1.2.40.0.34.11.1.2.7" },
                                                                   new templateID { root = "1.3.6.1.4.1.19376.1.5.3.1.3.25", assigningAuthorityName = "IHE PCC" },
                                                                   new templateID { root = "1.3.6.1.4.1.19376.1.5.3.1.1.5.3.2", assigningAuthorityName = "IHE PCC" },
                                                                   new templateID { root = "2.16.840.1.113883.10.20.1.16", assigningAuthorityName = "HL7 CCD" }
                                                                 },
                                            new ccode { code = "8716-3", displayName = "Vital signs", codeSystem = "2.16.840.1.113883.6.1", codeSystemName = "LOINC" },
                                            "VITPAR"));

            Sektionen.Add(CreateSektion((int)SektionOrder.PflegerelvanteInforamtionenZurMedizinischenBehandlung,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Pflegerelevante Informationen zur medizinischen Behandlung",
                                            new List<templateID> { new templateID { root = "1.2.40.0.34.11.1.2.18" } },
                                            new ccode { code = "PFMEDBEH", displayName = "Pflegerelevante Informationen zur medizinischen Behandlung" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Medikamentenverabreichung,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Medikamentenverabreichung",
                                            new List<templateID> { new templateID { root = "1.2.40.0.34.11.1.2.15" } },
                                            new ccode { code = "PFMED", displayName = "Medikamentenverabreichung" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Anmerkungen,
                                eELGATypeSektion.FachlicheSektion,
                                "Anmerkungen",
                                new List<templateID> { new templateID { root = "1.2.40.0.34.11.1.2.5" } },
                                new ccode { code = "ANM", displayName = "Anmerkungen" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.PflegeUndBetreuungsumfang,
                                            eELGATypeSektion.FachlicheSektion,
                                            "Pflege- und Betreuungsumfang",
                                            new List<templateID> { new templateID { root = "1.2.40.0.34.11.1.2.22" } },
                                            new ccode { code = "PUBUMF", displayName = "Pflege- und Betreuungsumfang" }));

            Sektionen.Add(CreateSektion((int)SektionOrder.Entlassungsmanagment,
                                            eELGATypeSektion.Enlassungsmanagement,
                                            "Entlassungsmanagement",
                                            new List<templateID> { new templateID { root = "1.2.40.0.34.11.3.2.17" },
                                                                   new templateID { root = "1.3.6.1.4.1.19376.1.5.3.1.3.32", assigningAuthorityName = "IHE PCC" } },
                                            new ccode { code = "8650-4", displayName = "Hospital discharge disposition", codeSystem = "2.16.840.1.113883.6.1", codeSystemName = "LOINC" },
                                            "ENTL"));

            Sektionen.Add(CreateSektion((int)SektionOrder.Patientenverfügung,
                                eELGATypeSektion.Patientenverfügung,
                                "Patientenverfügungen und andere juridische Dokumente",
                                new List<templateID> { new templateID { root = "1.2.40.0.34.11.1.2.4" },
                                                       new templateID { root = "1.3.6.1.4.1.19376.1.5.3.1.3.34", assigningAuthorityName = "IHE PCC" },
                                                       new templateID { root = "2.16.840.1.113883.10.20.1.1", assigningAuthorityName = "HL7 CCD" },
                                                     },
                                new ccode { code = "42348-3", displayName = "Advance directives", codeSystem = "2.16.840.1.113883.6.1", codeSystemName = "LOINC" },
                                "PATVERF"));

            Sektionen.Add(CreateSektion((int)SektionOrder.AbschliessendeBemerkungen,
                                            eELGATypeSektion.AbschliessendeBemerkung,
                                            "Abschließende Bemerkungen",
                                            new List<templateID> { new templateID { root = "1.2.40.0.34.5.40" } },
                                            new ccode { code = "ABBEM", displayName = "Abschließende Bemerkungen" }));
        }

        private Sektion CreateSektion(int order, eELGATypeSektion typ, string title, List<templateID> templateIDs, ccode code, string Tag = "")
        {
            try
            {
                Sektion Sektion = new Sektion();
                Sektion.order = order;
                Sektion.typ = typ;
                Sektion.title = title;
                Sektion.templateIDs = templateIDs;
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
                sect.TemplateId = new LIST<II>();
                foreach (templateID ID in sektion.templateIDs)
                {
                    sect.TemplateId.Add(new II { Root = ID.root, AssigningAuthorityName = ID.assigningAuthorityName });
                }
                sect.Code = new CE<string>(sektion.code.code, sektion.code.codeSystem, sektion.code.codeSystemName, null, sektion.code.displayName, null);
                sect.Title = sektion.title;
                sect.Title.Language = null;

                sect.Text = new ED();
                if (sektion.textHTML == null)
                    sektion.textHTML = "Keine zusätzliche Information verfügbar.";
                sect.Text.Data = System.Text.Encoding.UTF8.GetBytes(sektion.textHTML);
                sect.Text.Representation = MARC.Everest.DataTypes.Interfaces.EncapsulatedDataRepresentation.TXT;
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

                        LIST<II> ERids = new LIST<II>();
                        foreach (templateID ID in pdEntry.entryRelationship.observation.templateIDs)
                        {
                            ERids.Add(new II { Root = ID.root, AssigningAuthorityName = ID.assigningAuthorityName });
                        }
                        observation.TemplateId = ERids;
                        observation.Code = new CD<string>(
                            pdEntry.entryRelationship.observation.code.code,
                            pdEntry.entryRelationship.observation.code.codeSystem,
                            pdEntry.entryRelationship.observation.code.codeSystemName,
                            null,
                            pdEntry.entryRelationship.observation.code.displayName,
                            null);

                        observation.StatusCode = new CS<ActStatus>(ActStatus.Completed);
                        observation.EffectiveTime = new IVL<TS>(pdEntry.entryRelationship.observation.effectivTime_low_value, pdEntry.entryRelationship.observation.effectivTime_low_value);
                        observation.EffectiveTime.High.NullFlavor = MARC.Everest.DataTypes.NullFlavor.Unknown;
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

                        LIST<II> ids = new LIST<II>();
                        foreach (templateID ID in pdEntry.templateIDs)
                        {
                            ids.Add(new II { Root = ID.root, AssigningAuthorityName = ID.assigningAuthorityName });
                        }
                        entry.GetClinicalStatementIfAct().TemplateId = ids;

                        Act act = entry.GetClinicalStatementIfAct();
                        act.EffectiveTime.Low = new TS(pdEntry.effectiveTime_low_value);
                        act.EffectiveTime.Low.UpdateMode = null;
                        act.LanguageCode = null;
                        act.EffectiveTime.Value = null;
                        act.EffectiveTime.High = null;

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
                    Section sectHUM = new Section();

                    LIST<II> HUMids = new LIST<II>();
                    foreach (templateID ID in sektion.HilfsmittelUndRessourcen.templateIDs)
                    {
                        HUMids.Add(new II { Root = ID.root, AssigningAuthorityName = ID.assigningAuthorityName });
                    }
                    sectHUM.TemplateId = HUMids;

                    sectHUM.Code = new CE<string>(sektion.HilfsmittelUndRessourcen.code.code,
                        sektion.HilfsmittelUndRessourcen.code.codeSystem,
                        sektion.HilfsmittelUndRessourcen.code.codeSystemName,
                        null,
                        sektion.HilfsmittelUndRessourcen.code.displayName,
                        null);
                    sectHUM.Text = sektion.HilfsmittelUndRessourcen.textHTML;
                    sectHUM.Text.Language = null;
                    sectHUM.Text.MediaType = null;

                    Component5 comp5 = new Component5(null, null, sectHUM);
                    sect.Component.Add(comp5);
                }

                //Risiken
                if (sektion.Risiko != null)
                {
                    Section sectRisk = new Section();

                    LIST<II> Riskids = new LIST<II>();
                    foreach (templateID ID in sektion.Risiko.templateIDs)
                    {
                        Riskids.Add(new II { Root = ID.root, AssigningAuthorityName = ID.assigningAuthorityName });
                    }
                    sectRisk.TemplateId = Riskids;

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
                    string PDxHTML = "<table>\n\r\t<thead>\n\r\t<tr>\n\r\t<th>Diagnose</th>\n\r<th>Lokalisierung</th><th>Zeitpunkt</th></tr></thead>";
                    PDxHTML += "<tbody>";

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
                    foreach (var pdx in tPDx)
                    {
                        DateTime Start = (DateTime)pdx.Startdatum;
                        Guid Id = (Guid)pdx.ID;

                        PDxHTML += "<tr ID=\"pfdiag" + i.ToString() + "\">";
                        PDxHTML += "<td ID=\"pfdiag_diagnosis" + i.ToString() + "\">" + pdx.Klartext + "</td>";
                        PDxHTML += "<td>" + pdx.Lokalisierung + " " + pdx.LokalisierungSeite + "</td>";
                        PDxHTML += "<td>" + Start.ToString("dd.MM.yyyy") + "</td>";
                        PDxHTML += "</tr>";

                        PflegediagnoseEntry PDx = new PflegediagnoseEntry();
                        PDx.effectiveTime_low_value = Start;
                        PDx.entryRelationship.observation.id_root = Id;
                        PDx.entryRelationship.observation.text_reference = "#pfdiag" + i.ToString();
                        PDx.entryRelationship.observation.effectivTime_low_value = Start;
                        PDx.entryRelationship.observation.value_code = pdx.Code;
                        PDx.entryRelationship.observation.value_displayName = pdx.Klartext;
                        PDx.entryRelationship.observation.value_originalText_reference_value = "#pfdiag" + i.ToString() + "_diagnosis";

                        if (Sektionen[(int)SektionOrder.Pflegediagnosen].PflegediagnosenEntrys == null)
                        {
                            Sektionen[(int)SektionOrder.Pflegediagnosen].PflegediagnosenEntrys = new List<PflegediagnoseEntry>();
                        }

                        Sektionen[(int)SektionOrder.Pflegediagnosen].PflegediagnosenEntrys.Add(PDx);
                        i++;
                    }
                    PDxHTML += "</tbody></table>";
                    Sektionen[(int)SektionOrder.Pflegediagnosen].textHTML = PDxHTML;
                    if (i > 0)
                    {
                        Sektionen[(int)SektionOrder.Pflegediagnosen].use = true;
                    }
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
                                    Sektion.HilfsmittelUndRessourcen.textHTML += R.Text + "<br\\>";
                                    SetRTFTextByTag(this.Controls, R.Code + "_RES", R.Text + "\n");
                                }

                                else if (R.Eintraggruppe == "A")
                                {
                                    if (Sektion.Risiko == null)
                                    {
                                        Risiko Ris = new Risiko();
                                        Sektion.Risiko = Ris;
                                    }
                                    Sektion.Risiko.textHTML += R.Text + "<br\\>";
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
                    string PDxHTML = "<table>\n\r\t<thead><tr><th>Name</th><th>Wert</th><th>Einheit</th><th>Zeitpunkt</th></tr></thead>";
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
                                     orderby(mt.MedizinischerTyp)
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

                        mdText += "- "  + rMedDaten.MTBeschreibung + ":";
                        mdText += " " + von.ToString("dd.MM.yyyy") + " -";
                        if (bis > new DateTime(1900, 1, 1))
                            mdText += " "  + bis.ToString("dd.MM.yyyy");

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
                        if (bis < new DateTime(3000,1,1,23,59,59))
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
                                        p.PatientverfuegungAnmerkung
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

                        bool HindernSitzgelSitzhoseJN = rHAG.HindernSitzgelSitzhoseJN != null && (bool)rHAG.HindernSitzgelSitzhoseJN;
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

                    if (!String.IsNullOrWhiteSpace(rPatInfo.Bezeichnung))
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

        //------------------------------------ Vorbereitete Struktur in CDA-component übertragen -----------------------------------------
        public void CreateCDA()
        {
            try
            {
                ccda = new ClinicalDocument();
                ccda.RealmCode = new SET<CS<BindingRealm>>(new CS<BindingRealm>(BindingRealm.Austria));
                ccda.LanguageCode = new CS<string>("de-AT");
                compSektionen = new Component2();
                structBody = new StructuredBody();
                //structBody.classCode = null;

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

                using (MARC.Everest.Xml.XmlStateWriter xsw = new XmlStateWriter(XmlWriter.Create("C:\\Temp\\EverestPoC.xml", new XmlWriterSettings() { Indent = true, ConformanceLevel = ConformanceLevel.Document })))
                {
                    DateTime start = DateTime.Now;
                    var result = fmtr.Graph(xsw, ccda);
                    xsw.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.CreateCDA: " + ex.ToString());
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
                            Sektionen[(int)(SektionOrder)cTag.Order].textHTML = cRtf.Text.Replace("\n\r", "<br\\>").Replace("\r\n", "<br\\>").Replace("\n", "<br\\>");
                        }
                        else if (cTag.Typ == RTFTyp.Res)
                        {
                            if (Sektionen[(int)(SektionOrder)cTag.Order].HilfsmittelUndRessourcen == null)
                                Sektionen[(int)(SektionOrder)cTag.Order].HilfsmittelUndRessourcen = new HilfsmittelRessourcen();

                            Sektionen[(int)(SektionOrder)cTag.Order].HilfsmittelUndRessourcen.textHTML = cRtf.Text.Replace("\n\r", "<br\\>").Replace("\r\n", "<br\\>").Replace("\n", "<br\\>");
                            
                            if (String.IsNullOrWhiteSpace(cRtf.Text))
                                Sektionen[(int)(SektionOrder)cTag.Order].HilfsmittelUndRessourcen = null;
                        }
                        else if (cTag.Typ == RTFTyp.Risk)
                        {
                            if (Sektionen[(int)(SektionOrder)cTag.Order].Risiko == null)
                                Sektionen[(int)(SektionOrder)cTag.Order].Risiko = new Risiko();
                            Sektionen[(int)(SektionOrder)cTag.Order].Risiko.textHTML = cRtf.Text.Replace("\n\r", "<br\\>").Replace("\r\n", "<br\\>").Replace("\n", "<br\\>");
                            
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

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            CreateCDA();
        }

        [Structure(Name = "StructuredBody", StructureType = StructureAttribute.StructureAttributeType.MessageType, IsEntryPoint = false, Model = "POCD_MT000040UV", Publisher = "Copyright (C)2011, Health Level Seven")]
        public class ELGAStructuredBody : StructuredBody
        {
            [Property(Name = "classCode", PropertyType = PropertyAttribute.AttributeAttributeType.Traversable, Conformance = PropertyAttribute.AttributeConformanceType.Optional, SortKey = 0, SupplierDomain = "2.16.840.1.113883.5.6")]
            public virtual CS<ActClassDocumentBody> classCode { get; set; }
        }

        [Structure(Name = "ObservationMedia", StructureType = StructureAttribute.StructureAttributeType.MessageType, IsEntryPoint = false, Model = "POCD_MT000040UV", Publisher = "Copyright (C)2011, Health Level Seven")]
        public class MyObservationMedia : ObservationMedia
        {
            [Property(Name = "ID", Conformance = PropertyAttribute.AttributeConformanceType.Populated, PropertyType = PropertyAttribute.AttributeAttributeType.Structural)]
            public ST ID { get; set; }
        }
    }
}