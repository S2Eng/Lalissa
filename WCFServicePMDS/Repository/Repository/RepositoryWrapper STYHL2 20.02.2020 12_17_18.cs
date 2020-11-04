using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL;
using Microsoft.EntityFrameworkCore;

namespace WCFServicePMDS.Repository
{

    public class RepositoryWrapper : Interfaces , IDisposable
    {
        private Models.DB.PMDSDevContext _repoContext;


        private Interfaces.IBenutzerRepository _Benutzer;
        private Interfaces.IAbteilungRepository _Abteilung;
        private Interfaces.IAdresseRepository _Adresse;
        private Interfaces.IAerzteRepository _Aerzte;
        private Interfaces.IAnamnese_KrohwinkelRepository _Anamnese_Krohwinkel;
        private Interfaces.IAnamnese_OremRepository _Anamnese_Orem;
        private Interfaces.IAnamnese_POPRepository _Anamnese_POP;
        private Interfaces.IAnmeldungenRepository _Anmeldungen;
        private Interfaces.IArchDokuRepository _ArchDoku;
        private Interfaces.IArchDokuSchlagRepository _ArchDokuSchlag;
        private Interfaces.IArchObjectRepository _ArchObject;
        private Interfaces.IArchOrdnerRepository _ArchOrdner;
        private Interfaces.IArztabrechnungRepository _Arztabrechnung;
        private Interfaces.IAufenthaltRepository _Aufenthalt;
        private Interfaces.IAufenthaltPDxRepository _AufenthaltPDx;
        private Interfaces.IAufenthaltVerlaufRepository _AufenthaltVerlauf;
        private Interfaces.IAufenthaltZusatzRepository _AufenthaltZusatz;
        private Interfaces.IAuswahlListeRepository _AuswahlListe;
        private Interfaces.IAuswahlListeGruppeRepository _AuswahlListeGruppe;
        private Interfaces.IBankRepository _Bank;
        private Interfaces.IBarcodeQRepository _BarcodeQ;
        private Interfaces.IBelegungRepository _Belegung;
        private Interfaces.IBenutzerAbteilungRepository _BenutzerAbteilung;
        private Interfaces.IBenutzerBezugRepository _BenutzerBezug;
        private Interfaces.IBenutzerEinrichtungRepository _BenutzerEinrichtung;
        private Interfaces.IBenutzerGruppeRepository _BenutzerGruppe;
        private Interfaces.IBenutzerRechteRepository _BenutzerRechte;
        private Interfaces.IBereichRepository _Bereich;
        private Interfaces.IBereichBenutzerRepository _BereichBenutzer;
        private Interfaces.IBillHeaderRepository _BillHeader;
        private Interfaces.IBillsRepository _Bills;
        private Interfaces.IBookingsRepository _Bookings;
        private Interfaces.IDokumenteRepository _Dokumente;
        private Interfaces.IDokumente2Repository _Dokumente2;
        private Interfaces.IEinrichtungRepository _Einrichtung;
        private Interfaces.IEintragRepository _Eintrag;
        private Interfaces.IEintragStandardprozedurenRepository _EintragStandardprozeduren;
        private Interfaces.IEintragZusatzRepository _EintragZusatz;
        private Interfaces.IEssenRepository _Essen;
        private Interfaces.IFormularRepository _Formular;
        private Interfaces.IFormularDatenRepository _FormularDaten;
        private Interfaces.IFormularDatenFelderRepository _FormularDatenFelder;
        private Interfaces.IGegenstaendeRepository _Gegenstaende;
        private Interfaces.IGruppeRepository _Gruppe;
        private Interfaces.IGruppenRechtRepository _GruppenRecht;
        private Interfaces.IInfoRepository _Info;
        private Interfaces.IKlinikRepository _Klinik;
        private Interfaces.IKontaktRepository _Kontakt;
        private Interfaces.IKontaktpersonRepository _Kontaktperson;
        private Interfaces.IKontaktpersonStammdatenRepository _KontaktpersonStammdaten;
        private Interfaces.IKostentraegerRepository _Kostentraeger;
        private Interfaces.ILeistungskatalogRepository _Leistungskatalog;
        private Interfaces.ILeistungskatalogGueltigRepository _LeistungskatalogGueltig;
        private Interfaces.ILinkDokumenteRepository _LinkDokumente;
        private Interfaces.IManBuchRepository _manBuch;
        private Interfaces.IMassnahmenserienRepository _Massnahmenserien;
        private Interfaces.IMedikamentRepository _Medikament;
        private Interfaces.IMedikationAbgabeRepository _MedikationAbgabe;
        private Interfaces.IMedizinischeDatenRepository _MedizinischeDaten;
        private Interfaces.IMedizinischeDatenLayoutRepository _MedizinischeDatenLayout;
        private Interfaces.IMedizinischeTypenRepository _MedizinischeTypen;
        private Interfaces.IMessagesRepository _Messages;
        private Interfaces.IMessagesToUsersRepository _MessagesToUsers;
        private Interfaces.IPatientRepository _Patient;
        private Interfaces.IPatientAbwesenheitRepository _PatientAbwesenheit;
        private Interfaces.IPatientAerzteRepository _PatientAerzte;
        private Interfaces.IPatientEinkommenRepository _PatientEinkommen;
        private Interfaces.IPatientenBemerkungRepository _PatientenBemerkung;
        private Interfaces.IPatientKostentraegerRepository _PatientKostentraeger;
        private Interfaces.IPatientLeistungsplanRepository _PatientLeistungsplan;
        private Interfaces.IPatientPflegestufRepository _PatientPflegestufe;
        private Interfaces.IPatientSonderleistungRepository _PatientSonderleistung;
        private Interfaces.IPatientTaschengeldKostentraegerRepository _PatientTaschengeldKostentraeger;
        private Interfaces.IPDXRepository _PDX;
        private Interfaces.IPDXAnamneseRepository _PDXAnamnese;
        private Interfaces.IPDXEintragRepository _PDXEintrag;
        private Interfaces.IPDXGruppeRepository _PDXGruppe;
        private Interfaces.IPDXGruppeEintragRepository _PDXGruppeEintrag;
        private Interfaces.IPDXPflegemodelleRepository _PDXPflegemodelle;
        private Interfaces.IPflegeEintragRepository _PflegeEintrag;
        private Interfaces.IPflegeEintragEntwurfRepository _PflegeEintragEntwurf;
        private Interfaces.IPflegegeldstufeRepository _Pflegegeldstufe;
        private Interfaces.IPflegegeldstufeGueltigRepository _PflegegeldstufeGueltig;
        private Interfaces.IPflegemodelleRepository _Pflegemodelle;
        private Interfaces.IPflegePlanRepository _PflegePlan;
        private Interfaces.IPflegePlanHRepository _PflegePlanH;
        private Interfaces.IPflegePlanPDxRepository _PflegePlanPDx;
        private Interfaces.IPlanRepository _plan;
        private Interfaces.IPlanAnhangRepository _planAnhang;
        private Interfaces.IPlanObjectRepository _planObject;
        private Interfaces.IPlanStatusRepository _planStatus;
        private Interfaces.IQuickFilterRepository _QuickFilter;
        private Interfaces.IQuickMeldungRepository _QuickMeldung;
        private Interfaces.IRechNrRepository _rechNr;
        private Interfaces.IRechtRepository _Recht;
        private Interfaces.IRehabilitationRepository _Rehabilitation;
        private Interfaces.IRezeptBestellungPosRepository _RezeptBestellungPos;
        private Interfaces.IRezeptEintragRepository _RezeptEintrag;
        private Interfaces.IRezeptEintragMedDatenRepository _RezeptEintragMedDaten;
        private Interfaces.ISachwalterRepository _Sachwalter;
        private Interfaces.ISonderleistungsKatalogRepository _SonderleistungsKatalog;
        private Interfaces.ISPRepository _SP;
        private Interfaces.ISPDynRepRepository _SPDynRep;
        private Interfaces.ISPPERepository _SPPE;
        private Interfaces.ISPPOSRepository _SPPOS;
        private Interfaces.IStandardProzedurenRepository _StandardProzeduren;
        private Interfaces.IStandardzeitenRepository _Standardzeiten;
        private Interfaces.ITaschengeldRepository _Taschengeld;
        private Interfaces.ITbl_NachrichRepository _Tbl_Nachricht;
        private Interfaces.ITblAutoDokuRepository _TblAutoDoku;
        private Interfaces.ITblDokumenteRepository _TblDokumente;
        private Interfaces.ITblDokumenteGelesenRepository _TblDokumenteGelesen;
        private Interfaces.ITblDokumenteintragRepository _TblDokumenteintrag;
        private Interfaces.ITblDokumenteneintragSchlagwörterRepository _TblDokumenteneintragSchlagwörter;
        private Interfaces.ITblFachRepository _TblFach;
        private Interfaces.ITblFortbildungBenutzerRepository _TblFortbildungBenutzer;
        private Interfaces.ITblFortbildungenRepository _TblFortbildungen;
        private Interfaces.ITblInteropRepository _TblInterop;
        private Interfaces.ITblObjektRepository _TblObjekt;
        private Interfaces.ITblParameterRepository _TblParameter;
        private Interfaces.ITblPfadRepository _TblPfad;
        private Interfaces.ITblProvKonfigRepository _TblProvKonfig;
        private Interfaces.ITblRechteOrdnerRepository _TblRechteOrdner;
        private Interfaces.ITblSchlagwörterRepository _TblSchlagwörter;
        private Interfaces.ITblSchrankRepository _TblSchrank;
        private Interfaces.ITblSturzprotokollRepository _TblSturzprotokoll;
        private Interfaces.ITblSuchtgiftschrankSchlüsselRepository _TblSuchtgiftschrankSchlüssel;
        private Interfaces.ITblTextTemplatesRepository _TblTextTemplates;
        private Interfaces.ITblTextTemplatesFilesRepository _TblTextTemplatesFiles;
        private Interfaces.ITblThemenRepository _TblThemen;
        private Interfaces.ITblUIDefinitionsRepository _TblUIDefinitions;
        private Interfaces.ITblUserAccountsRepository _TblUserAccounts;
        private Interfaces.ITextbausteineRepository _Textbausteine;
        private Interfaces.ITblVeranstalterRepository _TblVeranstalter;
        private Interfaces.IUnterbringungRepository _Unterbringung;
        private Interfaces.IUrlaubVerlaufRepository _UrlaubVerlauf;
        private Interfaces.IVORepository _VO;
        private Interfaces.IVO_BestelldatenRepository _VO_Bestelldaten;
        private Interfaces.IVO_BestellpostitionenRepository _VO_Bestellpostitionen;
        private Interfaces.IVO_LagerRepository _VO_Lager;
        private Interfaces.IVO_MedizinischeDatenRepository _VO_MedizinischeDaten;
        private Interfaces.IVO_PflegeplanPDXRepository _VO_PflegeplanPDX;
        private Interfaces.IVO_WundeRepository _VO_Wunde;
        private Interfaces.IWundeKopfRepository _WundeKopf;
        private Interfaces.IWundePosRepository _WundePos;
        private Interfaces.IWundePosBilderRepository _WundePosBilder;
        private Interfaces.IWundeTherapieRepository _WundeTherapie;
        private Interfaces.IZeitbereichRepository _Zeitbereich;
        private Interfaces.IZeitbereichSerienRepository _ZeitbereichSerien;
        private Interfaces.IZusatzEintragRepository _ZusatzEintrag;
        private Interfaces.IZusatzGruppeRepository _ZusatzGruppe;
        private Interfaces.IZusatzGruppeEintragRepository _ZusatzGruppeEintrag;
        private Interfaces.IZusatzWertRepository _ZusatzWert;
        private Interfaces.IAddInsRepository _AddIns;
        private Interfaces.ILayoutRepository _Layout;
        private Interfaces.ILayoutGridsRepository _LayoutGrids;
        private Interfaces.IProtocolRepository _Protocol;
        private Interfaces.IRessourcenRepository _Ressourcen;
        private Interfaces.ItblAdjustRepository _TblAdjust;
        private Interfaces.ITblAdressRepository _TblAdress;
        private Interfaces.ITblCriteriaRepository _TblCriteria;
        private Interfaces.ITblCriteriaOptRepository _TblCriteriaOpt;
        private Interfaces.ITblDBVersionRepository _TblDBVersion;
        private Interfaces.IDbversionRepository _DBVersion;
        private Interfaces.ITblMedArchivRepository _TblMedArchiv;
        private Interfaces.ITblObjectRepository _TblObject;
        private Interfaces.ITblObjectApplicationsRepository _TblObjectApplications;
        private Interfaces.ITblObjectRelRepository _TblObjectRel;
        private Interfaces.ITblParticipantsRepository _TblParticipants;
        private Interfaces.ITblQueriesDefRepository _TblQueriesDef;
        private Interfaces.ITblQueryJoinsTempRepository _TblQueryJoinsTemp;
        private Interfaces.ITblRelationshipRepository _TblRelationship;
        private Interfaces.ITblSelListEntriesRepository _TblSelListEntries;
        private Interfaces.ITblSelListEntriesObjRepository _TblSelListEntriesObj;
        private Interfaces.ITblSelListEntriesSortRepository _TblSelListEntriesSort;
        private Interfaces.ITblSelListGroupRepository _TblSelListGroup;
        private Interfaces.ITblSideLogicRepository _TblSideLogic;
        private Interfaces.ITblStatisticsRepository _TblStatistics;
        private Interfaces.ITblStayRepository _TblStay;
        private Interfaces.ITblStayAdditionsRepository _TblStayAdditions;
        private Interfaces.ITblVersionsRepository _TblVersions;
        private Interfaces.IElgaactivitiesRepository _Elgaactivities;
        private Interfaces.IElgadocumentsRepository _Elgadocuments;
        private Interfaces.IElgacontactsRepository _Elgacontacts;
        private Interfaces.IElgaprotocollRepository _Elgaprotocoll;
        private Interfaces.ITblRedistRepository _TblRedist;
        private Interfaces.IDBLizenzRepository _DBLizenz;
        private Interfaces.IDienstzeitenRepository _Dienstzeiten;
        private Interfaces.IvKlientenliste2Repository _vKlientenliste2;
        private Interfaces.IvInterventionen2Repository _vInterventionen2;
        private Interfaces.IvÜbergabe2Repository _vÜbergabe2;




        public RepositoryWrapper()
        {
            Models.DB.PMDSDevContext dbcontext = DAL.dbBase.CreateContextEFCorePMDS();
            _repoContext = dbcontext;
        }
        public RepositoryWrapper(Models.DB.PMDSDevContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Dispose()
        {
                
        }

        public Models.DB.PMDSDevContext dbcontext
        {
            get
            {
                return _repoContext;
            }
        }



        public Interfaces.IAbteilungRepository Abteilung
        {
            get
            {
                if (_Abteilung == null)
                {
                    _Abteilung  = new WCFServicePMDS.Repository.Repository.AbteilungRepository(_repoContext);
                }

                return _Abteilung;
            }
        }
        public Interfaces.IAdresseRepository Adresse
        {
            get
            {
                if (_Adresse == null)
                {
                    _Adresse  = new WCFServicePMDS.Repository.Repository.AdresseRepository(_repoContext);
                }

                return _Adresse;
            }
        }
        public Interfaces.IAerzteRepository Aerzte
        {
            get
            {
                if (_Aerzte == null)
                {
                    _Aerzte = new WCFServicePMDS.Repository.Repository.AerzteRepository(_repoContext);
                }

                return _Aerzte;
            }
        }
        public Interfaces.IAnamnese_KrohwinkelRepository Anamnese_Krohwinkel
        {
            get
            {
                if (Anamnese_Krohwinkel == null)
                {
                    _Anamnese_Krohwinkel  = new WCFServicePMDS.Repository.Repository.Anamnese_KrohwinkelRepository(_repoContext);
                }

                return _Anamnese_Krohwinkel;
            }
        }
        public Interfaces.IAnamnese_OremRepository Anamnese_Orem
        {
            get
            {
                if (_Anamnese_Orem == null)
                {
                    _Anamnese_Orem  = new WCFServicePMDS.Repository.Repository.Anamnese_OremRepository(_repoContext);
                }

                return _Anamnese_Orem;
            }
        }
        public Interfaces.IAnamnese_POPRepository Anamnese_POP
        {
            get
            {
                if (_Anamnese_POP == null)
                {
                    _Anamnese_POP  = new WCFServicePMDS.Repository.Repository.Anamnese_POPRepository(_repoContext);
                }

                return _Anamnese_POP;
            }
        }
        public Interfaces.IAnmeldungenRepository Anmeldungen
        {
            get
            {
                if (_Anmeldungen == null)
                {
                    _Anmeldungen  = new WCFServicePMDS.Repository.Repository.AnmeldungeneRepository(_repoContext);
                }

                return _Anmeldungen;
            }
        }
        public Interfaces.IArchDokuRepository archDoku
        {
            get
            {
                if (_ArchDoku == null)
                {
                    _ArchDoku  = new WCFServicePMDS.Repository.Repository.ArchDokuRepository(_repoContext);
                }

                return _ArchDoku;
            }
        }
        public Interfaces.IArchDokuSchlagRepository archDokuSchlag
        {
            get
            {
                if (_ArchDokuSchlag == null)
                {
                    _ArchDokuSchlag  = new WCFServicePMDS.Repository.Repository.ArchDokuSchlagRepository(_repoContext);
                }

                return _ArchDokuSchlag;
            }
        }
        public Interfaces.IArchObjectRepository archObject
        {
            get
            {
                if (_ArchObject == null)
                {
                    _ArchObject  = new WCFServicePMDS.Repository.Repository.ArchObjectRepository(_repoContext);
                }

                return _ArchObject;
            }
        }
        public Interfaces.IArchOrdnerRepository archOrdner
        {
            get
            {
                if (_ArchOrdner == null)
                {
                    _ArchOrdner  = new WCFServicePMDS.Repository.Repository.ArchOrdnerRepository(_repoContext);
                }

                return _ArchOrdner;
            }
        }
        public Interfaces.IArztabrechnungRepository Arztabrechnung
        {
            get
            {
                if (_Arztabrechnung == null)
                {
                    _Arztabrechnung  = new WCFServicePMDS.Repository.Repository.ArztabrechnungRepository(_repoContext);
                }

                return _Arztabrechnung;
            }
        }
        public Interfaces.IAufenthaltRepository Aufenthalt
        {
            get
            {
                if (_Aufenthalt == null)
                {
                    _Aufenthalt  = new WCFServicePMDS.Repository.Repository.AufenthaltRepository(_repoContext);
                }

                return _Aufenthalt;
            }
        }
        public Interfaces.IAufenthaltPDxRepository AufenthaltPDx
        {
            get
            {
                if (_AufenthaltPDx == null)
                {
                    _AufenthaltPDx  = new WCFServicePMDS.Repository.Repository.AufenthaltPDxRepository(_repoContext);
                }

                return _AufenthaltPDx;
            }
        }
        public Interfaces.IAufenthaltVerlaufRepository AufenthaltVerlauf
        {
            get
            {
                if (_AufenthaltVerlauf == null)
                {
                    _AufenthaltVerlauf  = new WCFServicePMDS.Repository.Repository.AufenthaltVerlaufRepository(_repoContext);
                }

                return _AufenthaltVerlauf;
            }
        }
        public Interfaces.IAufenthaltZusatzRepository AufenthaltZusatz
        {
            get
            {
                if (_AufenthaltZusatz == null)
                {
                    _AufenthaltZusatz  = new WCFServicePMDS.Repository.Repository.AufenthaltZusatzRepository(_repoContext);
                }

                return _AufenthaltZusatz;
            }
        }
        public Interfaces.IAuswahlListeRepository AuswahlListe
        {
            get
            {
                if (_AuswahlListe == null)
                {
                    _AuswahlListe  = new WCFServicePMDS.Repository.Repository.AuswahlListeRepository(_repoContext);
                }

                return _AuswahlListe;
            }
        }
        public Interfaces.IAuswahlListeGruppeRepository AuswahlListeGruppe
        {
            get
            {
                if (_AuswahlListeGruppe == null)
                {
                    _AuswahlListeGruppe  = new WCFServicePMDS.Repository.Repository.AuswahlListeGruppeRepository(_repoContext);
                }

                return _AuswahlListeGruppe;
            }
        }
        public Interfaces.IBankRepository Bank
        {
            get
            {
                if (_Bank == null)
                {
                    _Bank  = new WCFServicePMDS.Repository.Repository.BankRepository(_repoContext);
                }

                return _Bank;
            }
        }
        public Interfaces.IBarcodeQRepository BarcodeQ
        {
            get
            {
                if (_BarcodeQ == null)
                {
                    _BarcodeQ  = new WCFServicePMDS.Repository.Repository.BarcodeQRepository(_repoContext);
                }

                return _BarcodeQ;
            }
        }
        public Interfaces.IBelegungRepository Belegung
        {
            get
            {
                if (_Belegung == null)
                {
                    _Belegung  = new WCFServicePMDS.Repository.Repository.BelegungRepository(_repoContext);
                }

                return _Belegung;
            }
        }
        public Interfaces.IBenutzerRepository Benutzer
        {
            get
            {
                if (_Benutzer == null)
                {
                    _Benutzer  = new WCFServicePMDS.Repository.Repository.BenutzerRepository(_repoContext);
                }

                return _Benutzer;
            }
        }
        public Interfaces.IBenutzerAbteilungRepository BenutzerAbteilung
        {
            get
            {
                if (_BenutzerAbteilung == null)
                {
                    _BenutzerAbteilung  = new WCFServicePMDS.Repository.Repository.BenutzerAbteilungRepository(_repoContext);
                }

                return _BenutzerAbteilung;
            }
        }
        public Interfaces.IBenutzerBezugRepository BenutzerBezug
        {
            get
            {
                if (_BenutzerBezug == null)
                {
                    _BenutzerBezug  = new WCFServicePMDS.Repository.Repository.BenutzerBezugRepository(_repoContext);
                }

                return _BenutzerBezug;
            }
        }
        public Interfaces.IBenutzerEinrichtungRepository BenutzerEinrichtung
        {
            get
            {
                if (_BenutzerEinrichtung == null)
                {
                    _BenutzerEinrichtung  = new WCFServicePMDS.Repository.Repository.BenutzerEinrichtungRepository(_repoContext);
                }

                return _BenutzerEinrichtung;
            }
        }
        public Interfaces.IBenutzerGruppeRepository BenutzerGruppe
        {
            get
            {
                if (_BenutzerGruppe == null)
                {
                    _BenutzerGruppe  = new WCFServicePMDS.Repository.Repository.BenutzerGruppeRepository(_repoContext);
                }

                return _BenutzerGruppe;
            }
        }
        public Interfaces.IBenutzerRechteRepository BenutzerRechte
        {
            get
            {
                if (_BenutzerRechte == null)
                {
                    _BenutzerRechte  = new WCFServicePMDS.Repository.Repository.BenutzerRechteRepository(_repoContext);
                }

                return _BenutzerRechte;
            }
        }
        public Interfaces.IBereichRepository Bereich
        {
            get
            {
                if (_Bereich == null)
                {
                    _Bereich  = new WCFServicePMDS.Repository.Repository.BereichRepository(_repoContext);
                }

                return _Bereich;
            }
        }
        public Interfaces.IBereichBenutzerRepository BereichBenutzer
        {
            get
            {
                if (_BereichBenutzer == null)
                {
                    _BereichBenutzer  = new WCFServicePMDS.Repository.Repository.BereichBenutzerRepository(_repoContext);
                }

                return _BereichBenutzer;
            }
        }
        public Interfaces.IBillHeaderRepository BillHeader
        {
            get
            {
                if (_BillHeader == null)
                {
                    _BillHeader  = new WCFServicePMDS.Repository.Repository.BillHeaderRepository(_repoContext);
                }

                return _BillHeader;
            }
        }
        public Interfaces.IBillsRepository Bills
        {
            get
            {
                if (_Bills == null)
                {
                    _Bills  = new WCFServicePMDS.Repository.Repository.BillsRepository(_repoContext);
                }

                return _Bills;
            }
        }
        public Interfaces.IBookingsRepository Bookings
        {
            get
            {
                if (_Bookings == null)
                {
                    _Bookings  = new WCFServicePMDS.Repository.Repository.BookingsRepository(_repoContext);
                }

                return _Bookings;
            }
        }
        public Interfaces.IDokumenteRepository Dokumente
        {
            get
            {
                if (_Dokumente == null)
                {
                    _Dokumente  = new WCFServicePMDS.Repository.Repository.DokumenteRepository(_repoContext);
                }

                return _Dokumente;
            }
        }
        public Interfaces.IDokumente2Repository Dokumente2
        {
            get
            {
                if (_Dokumente2 == null)
                {
                    _Dokumente2  = new WCFServicePMDS.Repository.Repository.Dokumente2Repository(_repoContext);
                }

                return _Dokumente2;
            }
        }
        public Interfaces.IEinrichtungRepository Einrichtung
        {
            get
            {
                if (_Einrichtung == null)
                {
                    _Einrichtung  = new WCFServicePMDS.Repository.Repository.EinrichtungRepository(_repoContext);
                }

                return _Einrichtung;
            }
        }
        public Interfaces.IEintragRepository Eintrag
        {
            get
            {
                if (_Eintrag == null)
                {
                    _Eintrag  = new WCFServicePMDS.Repository.Repository.EintragRepository(_repoContext);
                }

                return _Eintrag;
            }
        }
        public Interfaces.IEintragStandardprozedurenRepository EintragStandardprozeduren
        {
            get
            {
                if (_EintragStandardprozeduren == null)
                {
                    _EintragStandardprozeduren  = new WCFServicePMDS.Repository.Repository.EintragStandardprozedurenRepository(_repoContext);
                }

                return _EintragStandardprozeduren;
            }
        }
        public Interfaces.IEintragZusatzRepository EintragZusatz
        {
            get
            {
                if (_EintragZusatz == null)
                {
                    _EintragZusatz  = new WCFServicePMDS.Repository.Repository.EintragZusatzRepository(_repoContext);
                }

                return _EintragZusatz;
            }
        }
        public Interfaces.IEssenRepository Essen
        {
            get
            {
                if (_Essen == null)
                {
                    _Essen  = new WCFServicePMDS.Repository.Repository.EssenRepository(_repoContext);
                }

                return _Essen;
            }
        }
        public Interfaces.IFormularRepository Formular
        {
            get
            {
                if (_Formular == null)
                {
                    _Formular  = new WCFServicePMDS.Repository.Repository.FormularRepository(_repoContext);
                }

                return _Formular;
            }
        }
        public Interfaces.IFormularDatenRepository FormularDaten
        {
            get
            {
                if (_FormularDaten == null)
                {
                    _FormularDaten  = new WCFServicePMDS.Repository.Repository.FormularDatenRepository(_repoContext);
                }

                return _FormularDaten;
            }
        }
        public Interfaces.IFormularDatenFelderRepository FormularDatenFelder
        {
            get
            {
                if (_FormularDatenFelder == null)
                {
                    _FormularDatenFelder  = new WCFServicePMDS.Repository.Repository.FormularDatenFelderRepository(_repoContext);
                }

                return _FormularDatenFelder;
            }
        }
        public Interfaces.IGegenstaendeRepository Gegenstaende
        {
            get
            {
                if (_Gegenstaende == null)
                {
                    _Gegenstaende  = new WCFServicePMDS.Repository.Repository.GegenstaendeRepository(_repoContext);
                }

                return _Gegenstaende;
            }
        }
        public Interfaces.IGruppeRepository Gruppe
        {
            get
            {
                if (_Gruppe == null)
                {
                    _Gruppe  = new WCFServicePMDS.Repository.Repository.GruppeRepository(_repoContext);
                }

                return _Gruppe;
            }
        }
        public Interfaces.IGruppenRechtRepository GruppenRecht
        {
            get
            {
                if (_GruppenRecht == null)
                {
                    _GruppenRecht  = new WCFServicePMDS.Repository.Repository.GruppenRechtRepository(_repoContext);
                }

                return _GruppenRecht;
            }
        }
        public Interfaces.IInfoRepository Info
        {
            get
            {
                if (_Info == null)
                {
                    _Info  = new WCFServicePMDS.Repository.Repository.InfoRepository(_repoContext);
                }

                return _Info;
            }
        }
        public Interfaces.IKlinikRepository Klinik
        {
            get
            {
                if (_Klinik == null)
                {
                    _Klinik  = new WCFServicePMDS.Repository.Repository.KlinikRepository(_repoContext);
                }

                return _Klinik;
            }
        }
        public Interfaces.IKontaktRepository Kontakt
        {
            get
            {
                if (_Kontakt == null)
                {
                    _Kontakt  = new WCFServicePMDS.Repository.Repository.KontaktRepository(_repoContext);
                }

                return _Kontakt;
            }
        }
        public Interfaces.IKontaktpersonRepository Kontaktperson
        {
            get
            {
                if (_Kontaktperson == null)
                {
                    _Kontaktperson  = new WCFServicePMDS.Repository.Repository.KontaktpersonRepository(_repoContext);
                }

                return _Kontaktperson;
            }
        }
        public Interfaces.IKontaktpersonStammdatenRepository KontaktpersonStammdaten
        {
            get
            {
                if (_KontaktpersonStammdaten == null)
                {
                    _KontaktpersonStammdaten  = new WCFServicePMDS.Repository.Repository.KontaktpersonStammdatenRepository(_repoContext);
                }

                return _KontaktpersonStammdaten;
            }
        }
        public Interfaces.IKostentraegerRepository Kostentraeger
        {
            get
            {
                if (_Kostentraeger == null)
                {
                    _Kostentraeger  = new WCFServicePMDS.Repository.Repository.KostentraegerRepository(_repoContext);
                }

                return _Kostentraeger;
            }
        }
        public Interfaces.ILeistungskatalogRepository Leistungskatalog
        {
            get
            {
                if (_Leistungskatalog == null)
                {
                    _Leistungskatalog  = new WCFServicePMDS.Repository.Repository.LeistungskatalogRepository(_repoContext);
                }

                return _Leistungskatalog;
            }
        }
        public Interfaces.ILeistungskatalogGueltigRepository LeistungskatalogGueltig
        {
            get
            {
                if (_LeistungskatalogGueltig == null)
                {
                    _LeistungskatalogGueltig  = new WCFServicePMDS.Repository.Repository.LeistungskatalogGueltigRepository(_repoContext);
                }

                return _LeistungskatalogGueltig;
            }
        }
        public Interfaces.ILinkDokumenteRepository LinkDokumente
        {
            get
            {
                if (_LinkDokumente == null)
                {
                    _LinkDokumente  = new WCFServicePMDS.Repository.Repository.LinkDokumenteRepository(_repoContext);
                }

                return _LinkDokumente;
            }
        }
        public Interfaces.IManBuchRepository ManBuch
        {
            get
            {
                if (_manBuch == null)
                {
                    _manBuch  = new WCFServicePMDS.Repository.Repository.ManBuchRepository(_repoContext);
                }

                return _manBuch;
            }
        }
        public Interfaces.IMassnahmenserienRepository Massnahmenserien
        {
            get
            {
                if (_Massnahmenserien == null)
                {
                    _Massnahmenserien  = new WCFServicePMDS.Repository.Repository.MassnahmenserienRepository(_repoContext);
                }

                return _Massnahmenserien;
            }
        }
        public Interfaces.IMedikamentRepository Medikament
        {
            get
            {
                if (_Medikament == null)
                {
                    _Medikament  = new WCFServicePMDS.Repository.Repository.MedikamentRepository(_repoContext);
                }

                return _Medikament;
            }
        }
        public Interfaces.IMedikationAbgabeRepository MedikationAbgabe
        {
            get
            {
                if (_MedikationAbgabe == null)
                {
                    _MedikationAbgabe  = new WCFServicePMDS.Repository.Repository.MedikationAbgabeRepository(_repoContext);
                }

                return _MedikationAbgabe;
            }
        }
        public Interfaces.IMedizinischeDatenRepository MedizinischeDaten
        {
            get
            {
                if (_MedizinischeDaten == null)
                {
                    _MedizinischeDaten  = new WCFServicePMDS.Repository.Repository.MedizinischeDatenRepository(_repoContext);
                }

                return _MedizinischeDaten;
            }
        }
        public Interfaces.IMedizinischeDatenLayoutRepository MedizinischeDatenLayout
        {
            get
            {
                if (_MedizinischeDatenLayout == null)
                {
                    _MedizinischeDatenLayout  = new WCFServicePMDS.Repository.Repository.MedizinischeDatenLayoutRepository(_repoContext);
                }

                return _MedizinischeDatenLayout;
            }
        }
        public Interfaces.IMedizinischeTypenRepository MedizinischeTypen
        {
            get
            {
                if (_MedizinischeTypen == null)
                {
                    _MedizinischeTypen  = new WCFServicePMDS.Repository.Repository.MedizinischeTypenRepository(_repoContext);
                }
    
                return _MedizinischeTypen;
            }
        }
        public Interfaces.IMessagesRepository Messages
        {
            get
            {
                if (_Messages == null)
                {
                    _Messages = new WCFServicePMDS.Repository.Repository.MessagesRepository(_repoContext);
                }

                return _Messages;
            }
        }
        public Interfaces.IMessagesToUsersRepository MessagesToUsers
        {
            get
            {
                if (_MessagesToUsers == null)
                {
                    _MessagesToUsers = new WCFServicePMDS.Repository.Repository.MessagesToUsersRepository(_repoContext);
                }

                return _MessagesToUsers;
            }
        }
        public Interfaces.IPatientRepository Patient
        {
            get
            {
                if (_Patient == null)
                {
                    _Patient  = new WCFServicePMDS.Repository.Repository.PatientRepository(_repoContext);
                }

                return _Patient;
            }
        }
        public Interfaces.IPatientAbwesenheitRepository PatientAbwesenheit
        {
            get
            {
                if (_PatientAbwesenheit == null)
                {
                    _PatientAbwesenheit  = new WCFServicePMDS.Repository.Repository.PatientAbwesenheitRepository(_repoContext);
                }

                return _PatientAbwesenheit;
            }
        }
        public Interfaces.IPatientAerzteRepository PatientAerzte
        {
            get
            {
                if (_PatientAerzte == null)
                {
                    _PatientAerzte  = new WCFServicePMDS.Repository.Repository.PatientAerzteRepository(_repoContext);
                }

                return _PatientAerzte;
            }
        }
        public Interfaces.IPatientEinkommenRepository PatientEinkommen
        {
            get
            {
                if (_PatientEinkommen == null)
                {
                    _PatientEinkommen  = new WCFServicePMDS.Repository.Repository.PatientEinkommenRepository(_repoContext);
                }

                return _PatientEinkommen;
            }
        }
        public Interfaces.IPatientenBemerkungRepository PatientenBemerkung
        {
            get
            {
                if (_PatientenBemerkung == null)
                {
                    _PatientenBemerkung  = new WCFServicePMDS.Repository.Repository.PatientenBemerkungRepository(_repoContext);
                }

                return _PatientenBemerkung;
            }
        }
        public Interfaces.IPatientKostentraegerRepository PatientKostentraeger
        {
            get
            {
                if (_PatientKostentraeger == null)
                {
                    _PatientKostentraeger  = new WCFServicePMDS.Repository.Repository.PatientKostentraegerRepository(_repoContext);
                }

                return _PatientKostentraeger;
            }
        }
        public Interfaces.IPatientLeistungsplanRepository PatientLeistungsplan
        {
            get
            {
                if (_PatientLeistungsplan == null)
                {
                    _PatientLeistungsplan  = new WCFServicePMDS.Repository.Repository.PatientLeistungsplanRepository(_repoContext);
                }

                return _PatientLeistungsplan;
            }
        }
        public Interfaces.IPatientPflegestufRepository PatientPflegestufe
        {
            get
            {
                if (_PatientPflegestufe == null)
                {
                    _PatientPflegestufe  = new WCFServicePMDS.Repository.Repository.PatientPflegestufeRepository(_repoContext);
                }

                return _PatientPflegestufe;
            }
        }
        public Interfaces.IPatientSonderleistungRepository PatientSonderleistung
        {
            get
            {
                if (_PatientSonderleistung == null)
                {
                    _PatientSonderleistung  = new WCFServicePMDS.Repository.Repository.PatientSonderleistungRepository(_repoContext);
                }

                return _PatientSonderleistung;
            }
        }
        public Interfaces.IPatientTaschengeldKostentraegerRepository PatientTaschengeldKostentraeger
        {
            get
            {
                if (_PatientTaschengeldKostentraeger == null)
                {
                    _PatientTaschengeldKostentraeger  = new WCFServicePMDS.Repository.Repository.PatientTaschengeldKostentraegerRepository(_repoContext);
                }

                return _PatientTaschengeldKostentraeger;
            }
        }
        public Interfaces.IPDXRepository PDX
        {
            get
            {
                if (_PDX == null)
                {
                    _PDX  = new WCFServicePMDS.Repository.Repository.PDXRepository(_repoContext);
                }

                return _PDX;
            }
        }
        public Interfaces.IPDXAnamneseRepository PDXAnamnese
        {
            get
            {
                if (_PDXAnamnese == null)
                {
                    _PDXAnamnese  = new WCFServicePMDS.Repository.Repository.PDXAnamneseRepository(_repoContext);
                }

                return _PDXAnamnese;
            }
        }
        public Interfaces.IPDXEintragRepository PDXEintrag
        {
            get
            {
                if (_PDXEintrag == null)
                {
                    _PDXEintrag  = new WCFServicePMDS.Repository.Repository.PDXEintragRepository(_repoContext);
                }

                return _PDXEintrag;
            }
        }
        public Interfaces.IPDXGruppeRepository PDXGruppe
        {
            get
            {
                if (_PDXGruppe == null)
                {
                    _PDXGruppe  = new WCFServicePMDS.Repository.Repository.PDXGruppeRepository(_repoContext);
                }

                return _PDXGruppe;
            }
        }
        public Interfaces.IPDXGruppeEintragRepository PDXGruppeEintrag
        {
            get
            {
                if (_PDXGruppeEintrag == null)
                {
                    _PDXGruppeEintrag  = new WCFServicePMDS.Repository.Repository.PDXGruppeEintragRepository(_repoContext);
                }

                return _PDXGruppeEintrag;
            }
        }
        public Interfaces.IPDXPflegemodelleRepository PDXPflegemodelle
        {
            get
            {
                if (_PDXPflegemodelle == null)
                {
                    _PDXPflegemodelle  = new WCFServicePMDS.Repository.Repository.PDXPflegemodelleRepository(_repoContext);
                }

                return _PDXPflegemodelle;
            }
        }
        public Interfaces.IPflegeEintragRepository PflegeEintrag
        {
            get
            {
                if (_PflegeEintrag == null)
                {
                    _PflegeEintrag  = new WCFServicePMDS.Repository.Repository.PflegeEintragRepository(_repoContext);
                }

                return _PflegeEintrag;
            }
        }
        public Interfaces.IPflegeEintragEntwurfRepository PflegeEintragEntwurf
        {
            get
            {
                if (_PflegeEintragEntwurf == null)
                {
                    _PflegeEintragEntwurf  = new WCFServicePMDS.Repository.Repository.PflegeEintragEntwurfRepository(_repoContext);
                }

                return _PflegeEintragEntwurf;
            }
        }
        public Interfaces.IPflegegeldstufeRepository Pflegegeldstufe
        {
            get
            {
                if (_Pflegegeldstufe == null)
                {
                    _Pflegegeldstufe  = new WCFServicePMDS.Repository.Repository.PflegegeldstufeRepository(_repoContext);
                }

                return _Pflegegeldstufe;
            }
        }
        public Interfaces.IPflegegeldstufeGueltigRepository PflegegeldstufeGueltig
        {
            get
            {
                if (_PflegegeldstufeGueltig == null)
                {
                    _PflegegeldstufeGueltig  = new WCFServicePMDS.Repository.Repository.PflegegeldstufeGueltigRepository(_repoContext);
                }

                return _PflegegeldstufeGueltig;
            }
        }
        public Interfaces.IPflegemodelleRepository Pflegemodelle
        {
            get
            {
                if (_Pflegemodelle == null)
                {
                    _Pflegemodelle  = new WCFServicePMDS.Repository.Repository.PflegemodelleRepository(_repoContext);
                }

                return _Pflegemodelle;
            }
        }
        public Interfaces.IPflegePlanRepository PflegePlan
        {
            get
            {
                if (_PflegePlan == null)
                {
                    _PflegePlan  = new WCFServicePMDS.Repository.Repository.PflegePlanRepository(_repoContext);
                }

                return _PflegePlan;
            }
        }
        public Interfaces.IPflegePlanHRepository PflegePlanH
        {
            get
            {
                if (_PflegePlanH == null)
                {
                    _PflegePlanH  = new WCFServicePMDS.Repository.Repository.PflegePlanHRepository(_repoContext);
                }

                return _PflegePlanH;
            }
        }
        public Interfaces.IPflegePlanPDxRepository PflegePlanPDx
        {
            get
            {
                if (_PflegePlanPDx == null)
                {
                    _PflegePlanPDx  = new WCFServicePMDS.Repository.Repository.PflegePlanPDxRepository(_repoContext);
                }

                return _PflegePlanPDx;
            }
        }
        public Interfaces.IPlanRepository Plan
        {
            get
            {
                if (_plan == null)
                {
                    _plan  = new WCFServicePMDS.Repository.Repository.PlanRepository(_repoContext);
                }

                return _plan;
            }
        }
        public Interfaces.IPlanAnhangRepository PlanAnhang
        {
            get
            {
                if (_planAnhang == null)
                {
                    _planAnhang  = new WCFServicePMDS.Repository.Repository.PlanAnhangRepository(_repoContext);
                }

                return _planAnhang;
            }
        }
        public Interfaces.IPlanObjectRepository PlanObject
        {
            get
            {
                if (_planObject == null)
                {
                    _planObject  = new WCFServicePMDS.Repository.Repository.PlanObjectRepository(_repoContext);
                }

                return _planObject;
            }
        }
        public Interfaces.IPlanStatusRepository PlanStatus
        {
            get
            {
                if (_planStatus == null)
                {
                    _planStatus  = new WCFServicePMDS.Repository.Repository.PlanStatusRepository(_repoContext);
                }

                return _planStatus;
            }
        }
        public Interfaces.IQuickFilterRepository QuickFilter
        {
            get
            {
                if (_QuickFilter == null)
                {
                    _QuickFilter  = new WCFServicePMDS.Repository.Repository.QuickFilterRepository(_repoContext);
                }

                return _QuickFilter;
            }
        }
        public Interfaces.IQuickMeldungRepository QuickMeldung
        {
            get
            {
                if (_QuickMeldung == null)
                {
                    _QuickMeldung  = new WCFServicePMDS.Repository.Repository.QuickMeldungRepository(_repoContext);
                }

                return _QuickMeldung;
            }
        }
        public Interfaces.IRechNrRepository RechNr
        {
            get
            {
                if (_rechNr == null)
                {
                    _rechNr  = new WCFServicePMDS.Repository.Repository.RechNrRepository(_repoContext);
                }

                return _rechNr;
            }
        }
        public Interfaces.IRechtRepository Recht
        {
            get
            {
                if (_Recht == null)
                {
                    _Recht  = new WCFServicePMDS.Repository.Repository.RechtRepository(_repoContext);
                }

                return _Recht;
            }
        }
        public Interfaces.IRehabilitationRepository Rehabilitation
        {
            get
            {
                if (_Rehabilitation == null)
                {
                    _Rehabilitation  = new WCFServicePMDS.Repository.Repository.RehabilitationRepository(_repoContext);
                }

                return _Rehabilitation;
            }
        }
        public Interfaces.IRezeptBestellungPosRepository RezeptBestellungPos
        {
            get
            {
                if (_RezeptBestellungPos == null)
                {
                    _RezeptBestellungPos  = new WCFServicePMDS.Repository.Repository.RezeptBestellungPosRepository(_repoContext);
                }

                return _RezeptBestellungPos;
            }
        }
        public Interfaces.IRezeptEintragRepository RezeptEintrag
        {
            get
            {
                if (_RezeptEintrag == null)
                {
                    _RezeptEintrag  = new WCFServicePMDS.Repository.Repository.RezeptEintragRepository(_repoContext);
                }

                return _RezeptEintrag;
            }
        }
        public Interfaces.IRezeptEintragMedDatenRepository RezeptEintragMedDaten
        {
            get
            {
                if (_RezeptEintragMedDaten == null)
                {
                    _RezeptEintragMedDaten  = new WCFServicePMDS.Repository.Repository.RezeptEintragMedDatenRepository(_repoContext);
                }

                return _RezeptEintragMedDaten;
            }
        }
        public Interfaces.ISachwalterRepository Sachwalter
        {
            get
            {
                if (_Sachwalter == null)
                {
                    _Sachwalter  = new WCFServicePMDS.Repository.Repository.SachwalterRepository(_repoContext);
                }

                return _Sachwalter;
            }
        }
        public Interfaces.ISonderleistungsKatalogRepository SonderleistungsKatalog
        {
            get
            {
                if (_SonderleistungsKatalog == null)
                {
                    _SonderleistungsKatalog  = new WCFServicePMDS.Repository.Repository.SonderleistungsKatalogRepository(_repoContext);
                }

                return _SonderleistungsKatalog;
            }
        }
        public Interfaces.ISPRepository SP
        {
            get
            {
                if (_SP == null)
                {
                    _SP  = new WCFServicePMDS.Repository.Repository.SPRepository(_repoContext);
                }

                return _SP;
            }
        }
        public Interfaces.ISPDynRepRepository SPDynRep
        {
            get
            {
                if (_SPDynRep == null)
                {
                    _SPDynRep  = new WCFServicePMDS.Repository.Repository.SpdynRepRepository(_repoContext);
                }

                return _SPDynRep;
            }
        }
        public Interfaces.ISPPERepository SPPE
        {
            get
            {
                if (_SPPE == null)
                {
                    _SPPE  = new WCFServicePMDS.Repository.Repository.SPPERepository(_repoContext);
                }

                return _SPPE;
            }
        }
        public Interfaces.ISPPOSRepository SPPOS
        {
            get
            {
                if (_SPPOS == null)
                {
                    _SPPOS  = new WCFServicePMDS.Repository.Repository.SPPOSRepository(_repoContext);
                }

                return _SPPOS;
            }
        }
        public Interfaces.IStandardProzedurenRepository StandardProzeduren
        {
            get
            {
                if (_StandardProzeduren == null)
                {
                    _StandardProzeduren  = new WCFServicePMDS.Repository.Repository.StandardProzedurenRepository(_repoContext);
                }

                return _StandardProzeduren;
            }
        }
        public Interfaces.IStandardzeitenRepository Standardzeiten
        {
            get
            {
                if (_Standardzeiten == null)
                {
                    _Standardzeiten  = new WCFServicePMDS.Repository.Repository.StandardzeitenRepository(_repoContext);
                }

                return _Standardzeiten;
            }
        }
        public Interfaces.ITaschengeldRepository Taschengeld
        {
            get
            {
                if (_Taschengeld == null)
                {
                    _Taschengeld  = new WCFServicePMDS.Repository.Repository.TaschengeldRepository(_repoContext);
                }

                return _Taschengeld;
            }
        }
        public Interfaces.ITbl_NachrichRepository tbl_Nachricht
        {
            get
            {
                if (_Tbl_Nachricht == null)
                {
                    _Tbl_Nachricht  = new WCFServicePMDS.Repository.Repository.Tbl_NachrichtRepository(_repoContext);
                }

                return _Tbl_Nachricht;
            }
        }
        public Interfaces.ITblAutoDokuRepository TblAutoDoku
        {
            get
            {
                if (_TblAutoDoku == null)
                {
                    _TblAutoDoku  = new WCFServicePMDS.Repository.Repository.TblAutoDokuRepository(_repoContext);
                }

                return _TblAutoDoku;
            }
        }
        public Interfaces.ITblDokumenteRepository TblDokumente
        {
            get
            {
                if (_TblDokumente == null)
                {
                    _TblDokumente  = new WCFServicePMDS.Repository.Repository.TblDokumenteRepository(_repoContext);
                }

                return _TblDokumente;
            }
        }
        public Interfaces.ITblDokumenteGelesenRepository TblDokumenteGelesen
        {
            get
            {
                if (TblDokumenteGelesen == null)
                {
                    _TblDokumenteGelesen  = new WCFServicePMDS.Repository.Repository.TblDokumenteGelesenRepository(_repoContext);
                }

                return _TblDokumenteGelesen;
            }
        }
        public Interfaces.ITblDokumenteintragRepository TblDokumenteintrag
        {
            get
            {
                if (_TblDokumenteintrag == null)
                {
                    _TblDokumenteintrag  = new WCFServicePMDS.Repository.Repository.TblDokumenteintragRepository(_repoContext);
                }

                return _TblDokumenteintrag;
            }
        }
        public Interfaces.ITblDokumenteneintragSchlagwörterRepository TblDokumenteneintragSchlagwörter
        {
            get
            {
                if (_TblDokumenteneintragSchlagwörter == null)
                {
                    _TblDokumenteneintragSchlagwörter  = new WCFServicePMDS.Repository.Repository.TblDokumenteneintragSchlagwörterRepository(_repoContext);
                }

                return _TblDokumenteneintragSchlagwörter;
            }
        }
        public Interfaces.ITblFachRepository TblFach
        {
            get
            {
                if (_TblFach == null)
                {
                    _TblFach  = new WCFServicePMDS.Repository.Repository.TblFachRepository(_repoContext);
                }

                return _TblFach;
            }
        }
        public Interfaces.ITblFortbildungBenutzerRepository TblFortbildungBenutzer
        {
            get
            {
                if (_TblFortbildungBenutzer == null)
                {
                    _TblFortbildungBenutzer  = new WCFServicePMDS.Repository.Repository.TblFortbildungBenutzerRepository(_repoContext);
                }

                return _TblFortbildungBenutzer;
            }
        }
        public Interfaces.ITblFortbildungenRepository TblFortbildungen
        {
            get
            {
                if (_TblFortbildungen == null)
                {
                    _TblFortbildungen  = new WCFServicePMDS.Repository.Repository.TblFortbildungenRepository(_repoContext);
                }

                return _TblFortbildungen;
            }
        }
        public Interfaces.ITblInteropRepository TblInterop
        {
            get
            {
                if (_TblInterop == null)
                {
                    _TblInterop  = new WCFServicePMDS.Repository.Repository.TblInteropRepository(_repoContext);
                }

                return _TblInterop;
            }
        }
        public Interfaces.ITblObjektRepository TblObjekt
        {
            get
            {
                if (_TblObjekt == null)
                {
                    _TblObjekt  = new WCFServicePMDS.Repository.Repository.TblObjektRepository(_repoContext);
                }

                return _TblObjekt;
            }
        }
        public Interfaces.ITblParameterRepository TblParameter
        {
            get
            {
                if (_TblParameter == null)
                {
                    _TblParameter  = new WCFServicePMDS.Repository.Repository.TblParameterRepository(_repoContext);
                }

                return _TblParameter;
            }
        }
        public Interfaces.ITblPfadRepository TblPfad
        {
            get
            {
                if (_TblPfad == null)
                {
                    _TblPfad  = new WCFServicePMDS.Repository.Repository.TblPfadRepository(_repoContext);
                }

                return _TblPfad;
            }
        }
        public Interfaces.ITblProvKonfigRepository TblProvKonfig
        {
            get
            {
                if (_TblProvKonfig == null)
                {
                    _TblProvKonfig  = new WCFServicePMDS.Repository.Repository.TblProvKonfigRepository(_repoContext);
                }

                return _TblProvKonfig;
            }
        }
        public Interfaces.ITblRechteOrdnerRepository TblRechteOrdner
        {
            get
            {
                if (_TblRechteOrdner == null)
                {
                    _TblRechteOrdner  = new WCFServicePMDS.Repository.Repository.TblRechteOrdnerRepository(_repoContext);
                }

                return _TblRechteOrdner;
            }
        }
        public Interfaces.ITblSchlagwörterRepository TblSchlagwörter
        {
            get
            {
                if (_TblSchlagwörter == null)
                {
                    _TblSchlagwörter  = new WCFServicePMDS.Repository.Repository.TblSchlagwörterRepository(_repoContext);
                }

                return _TblSchlagwörter;
            }
        }
        public Interfaces.ITblSchrankRepository TblSchrank
        {
            get
            {
                if (_TblSchrank == null)
                {
                    _TblSchrank  = new WCFServicePMDS.Repository.Repository.TblSchrankRepository(_repoContext);
                }

                return _TblSchrank;
            }
        }
        public Interfaces.ITblSturzprotokollRepository TblSturzprotokoll
        {
            get
            {
                if (_TblSturzprotokoll == null)
                {
                    _TblSturzprotokoll  = new WCFServicePMDS.Repository.Repository.TblSturzprotokollRepository(_repoContext);
                }

                return _TblSturzprotokoll;
            }
        }
        public Interfaces.ITblSuchtgiftschrankSchlüsselRepository TblSuchtgiftschrankSchlüssel
        {
            get
            {
                if (_TblSuchtgiftschrankSchlüssel == null)
                {
                    _TblSuchtgiftschrankSchlüssel  = new WCFServicePMDS.Repository.Repository.TblSuchtgiftschrankSchlüsselRepository(_repoContext);
                }

                return _TblSuchtgiftschrankSchlüssel;
            }
        }
        public Interfaces.ITblTextTemplatesRepository TblTextTemplates
        {
            get
            {
                if (_TblTextTemplates == null)
                {
                    _TblTextTemplates  = new WCFServicePMDS.Repository.Repository.TblTextTemplatesRepository(_repoContext);
                }

                return _TblTextTemplates;
            }
        }
        public Interfaces.ITblTextTemplatesFilesRepository TblTextTemplatesFiles
        {
            get
            {
                if (_TblTextTemplatesFiles == null)
                {
                    _TblTextTemplatesFiles  = new WCFServicePMDS.Repository.Repository.TblTextTemplatesFilesRepository(_repoContext);
                }

                return _TblTextTemplatesFiles;
            }
        }
        public Interfaces.ITblThemenRepository TblThemen
        {
            get
            {
                if (_TblThemen == null)
                {
                    _TblThemen  = new WCFServicePMDS.Repository.Repository.TblThemenRepository(_repoContext);
                }

                return _TblThemen;
            }
        }
        public Interfaces.ITblUIDefinitionsRepository TblUIDefinitions
        {
            get
            {
                if (_TblUIDefinitions == null)
                {
                    _TblUIDefinitions  = new WCFServicePMDS.Repository.Repository.TblUIDefinitionsRepository(_repoContext);
                }

                return _TblUIDefinitions;
            }
        }
        public Interfaces.ITblUserAccountsRepository TblUserAccounts
        {
            get
            {
                if (_TblUserAccounts == null)
                {
                    _TblUserAccounts  = new WCFServicePMDS.Repository.Repository.TblUserAccountsRepository(_repoContext);
                }

                return _TblUserAccounts;
            }
        }
        public Interfaces.ITblVeranstalterRepository TblVeranstalter
        {
            get
            {
                if (_TblVeranstalter == null)
                {
                    _TblVeranstalter  = new WCFServicePMDS.Repository.Repository.TblVeranstalterRepository(_repoContext);
                }

                return _TblVeranstalter;
            }
        }
        public Interfaces.ITextbausteineRepository Textbausteine
        {
            get
            {
                if (_Textbausteine == null)
                {
                    _Textbausteine  = new WCFServicePMDS.Repository.Repository.TextbausteineRepository(_repoContext);
                }

                return _Textbausteine;
            }
        }
        public Interfaces.IUnterbringungRepository Unterbringung
        {
            get
            {
                if (_Unterbringung == null)
                {
                    _Unterbringung  = new WCFServicePMDS.Repository.Repository.UnterbringungRepository(_repoContext);
                }

                return _Unterbringung;
            }
        }
        public Interfaces.IUrlaubVerlaufRepository UrlaubVerlauf
        {
            get
            {
                if (_UrlaubVerlauf == null)
                {
                    _UrlaubVerlauf  = new WCFServicePMDS.Repository.Repository.UrlaubVerlaufRepository(_repoContext);
                }

                return _UrlaubVerlauf;
            }
        }
        public Interfaces.IVORepository VO
        {
            get
            {
                if (_VO == null)
                {
                    _VO  = new WCFServicePMDS.Repository.Repository.VoRepository(_repoContext);
                }

                return _VO;
            }
        }
        public Interfaces.IVO_BestelldatenRepository VO_Bestelldaten
        {
            get
            {
                if (_VO_Bestelldaten == null)
                {
                    _VO_Bestelldaten  = new WCFServicePMDS.Repository.Repository.VO_BestelldatenRepository(_repoContext);
                }

                return _VO_Bestelldaten;
            }
        }
        public Interfaces.IVO_BestellpostitionenRepository VO_Bestellpostitionen
        {
            get
            {
                if (_VO_Bestellpostitionen == null)
                {
                    _VO_Bestellpostitionen  = new WCFServicePMDS.Repository.Repository.VO_BestellpostitionenRepository(_repoContext);
                }

                return _VO_Bestellpostitionen;
            }
        }
        public Interfaces.IVO_LagerRepository VO_Lager
        {
            get
            {
                if (_VO_Lager == null)
                {
                    _VO_Lager  = new WCFServicePMDS.Repository.Repository.VO_LagerRepository(_repoContext);
                }

                return _VO_Lager;
            }
        }
        public Interfaces.IVO_MedizinischeDatenRepository VO_MedizinischeDaten
        {
            get
            {
                if (_VO_MedizinischeDaten == null)
                {
                    _VO_MedizinischeDaten  = new WCFServicePMDS.Repository.Repository.VoMedizinischeDatenRepository(_repoContext);
                }

                return _VO_MedizinischeDaten;
            }
        }
        public Interfaces.IVO_PflegeplanPDXRepository VO_PflegeplanPDX
        {
            get
            {
                if (_VO_PflegeplanPDX == null)
                {
                    _VO_PflegeplanPDX  = new WCFServicePMDS.Repository.Repository.VO_PflegeplanPDXRepository(_repoContext);
                }

                return _VO_PflegeplanPDX;
            }
        }
        public Interfaces.IVO_WundeRepository VO_Wunde
        {
            get
            {
                if (_VO_Wunde == null)
                {
                    _VO_Wunde  = new WCFServicePMDS.Repository.Repository.VO_WundeRepository(_repoContext);
                }

                return _VO_Wunde;
            }
        }
        public Interfaces.IWundeKopfRepository WundeKopf
        {
            get
            {
                if (_WundeKopf == null)
                {
                    _WundeKopf  = new WCFServicePMDS.Repository.Repository.WundeKopfRepository(_repoContext);
                }

                return _WundeKopf;
            }
        }
        public Interfaces.IWundePosRepository WundePos
        {
            get
            {
                if (_WundePos == null)
                {
                    _WundePos  = new WCFServicePMDS.Repository.Repository.WundePosRepository(_repoContext);
                }

                return _WundePos;
            }
        }
        public Interfaces.IWundePosBilderRepository WundePosBilder
        {
            get
            {
                if (_WundePosBilder == null)
                {
                    _WundePosBilder  = new WCFServicePMDS.Repository.Repository.WundePosBilderRepository(_repoContext);
                }

                return _WundePosBilder;
            }
        }
        public Interfaces.IWundeTherapieRepository WundeTherapie
        {
            get
            {
                if (_WundeTherapie == null)
                {
                    _WundeTherapie = new WCFServicePMDS.Repository.Repository.WundeTherapieRepository(_repoContext);
                }

                return _WundeTherapie;
            }
        }
        public Interfaces.IZeitbereichRepository Zeitbereich
        {
            get
            {
                if (_Zeitbereich == null)
                {
                    _Zeitbereich = new WCFServicePMDS.Repository.Repository.ZeitbereichRepository(_repoContext);
                }

                return _Zeitbereich;
            }
        }
        public Interfaces.IZeitbereichSerienRepository ZeitbereichSerien
        {
            get
            {
                if (_ZeitbereichSerien == null)
                {
                    _ZeitbereichSerien = new WCFServicePMDS.Repository.Repository.ZeitbereichSerienRepository(_repoContext);
                }

                return _ZeitbereichSerien;
            }
        }
        public Interfaces.IZusatzEintragRepository ZusatzEintrag
        {
            get
            {
                if (_ZusatzEintrag == null)
                {
                    _ZusatzEintrag = new WCFServicePMDS.Repository.Repository.ZusatzEintragRepository(_repoContext);
                }

                return _ZusatzEintrag;
            }
        }
        public Interfaces.IZusatzGruppeRepository ZusatzGruppe
        {
            get
            {
                if (_ZusatzGruppe == null)
                {
                    _ZusatzGruppe  = new WCFServicePMDS.Repository.Repository.ZusatzGruppeRepository(_repoContext);
                }

                return _ZusatzGruppe;
            }
        }
        public Interfaces.IZusatzGruppeEintragRepository ZusatzGruppeEintrag
        {
            get
            {
                if (_ZusatzGruppeEintrag == null)
                {
                    _ZusatzGruppeEintrag  = new WCFServicePMDS.Repository.Repository.ZusatzGruppeEintragRepository(_repoContext);
                }

                return _ZusatzGruppeEintrag;
            }
        }
        public Interfaces.IZusatzWertRepository ZusatzWert
        {
            get
            {
                if (_ZusatzWert == null)
                {
                    _ZusatzWert  = new WCFServicePMDS.Repository.Repository.ZusatzWertRepository(_repoContext);
                }

                return _ZusatzWert;
            }
        }
        public Interfaces.IAddInsRepository AddIns
        {
            get
            {
                if (_AddIns == null)
                {
                    _AddIns  = new WCFServicePMDS.Repository.Repository.AddInsRepository(_repoContext);
                }

                return _AddIns;
            }
        }
        public Interfaces.ILayoutRepository Layout
        {
            get
            {
                if (_Layout == null)
                {
                    _Layout  = new WCFServicePMDS.Repository.Repository.LayoutRepository(_repoContext);
                }

                return _Layout;
            }
        }
        public Interfaces.ILayoutGridsRepository LayoutGrids
        {
            get
            {
                if (_LayoutGrids == null)
                {
                    _LayoutGrids  = new WCFServicePMDS.Repository.Repository.LayoutGridsRepository(_repoContext);
                }

                return _LayoutGrids;
            }
        }
        public Interfaces.IProtocolRepository Protocol
        {
            get
            {
                if (_Protocol == null)
                {
                    _Protocol  = new WCFServicePMDS.Repository.Repository.ProtocolRepository(_repoContext);
                }

                return _Protocol;
            }
        }
        public Interfaces.IRessourcenRepository Ressourcen
        {
            get
            {
                if (_Ressourcen == null)
                {
                    _Ressourcen  = new WCFServicePMDS.Repository.Repository.RessourcenRepository(_repoContext);
                }

                return _Ressourcen;
            }
        }
        public Interfaces.ItblAdjustRepository TblAdjust
        {
            get
            {
                if (_TblAdjust == null)
                {
                    _TblAdjust  = new WCFServicePMDS.Repository.Repository.tblAdjustRepository(_repoContext);
                }

                return _TblAdjust;
            }
        }
        public Interfaces.ITblAdressRepository TblAdress
        {
            get
            {
                if (_TblAdress == null)
                {
                    _TblAdress  = new WCFServicePMDS.Repository.Repository.tblAdressRepository(_repoContext);
                }

                return _TblAdress;
            }
        }
        public Interfaces.ITblCriteriaRepository TblCriteria
        {
            get
            {
                if (_TblCriteria == null)
                {
                    _TblCriteria  = new WCFServicePMDS.Repository.Repository.TblCriteriaRepository(_repoContext);
                }

                return _TblCriteria;
            }
        }
        public Interfaces.ITblCriteriaOptRepository TblCriteriaOpt
        {
            get
            {
                if (_TblCriteriaOpt == null)
                {
                    _TblCriteriaOpt  = new WCFServicePMDS.Repository.Repository.TblCriteriaOptRepository(_repoContext);
                }

                return _TblCriteriaOpt;
            }
        }
        public Interfaces.ITblDBVersionRepository TblDBVersion
        {
            get
            {
                if (_TblDBVersion == null)
                {
                    _TblDBVersion  = new WCFServicePMDS.Repository.Repository.TblDBVersionRepository(_repoContext);
                }

                return _TblDBVersion;
            }
        }
        public Interfaces.IDbversionRepository DBVersion
        {
            get
            {
                if (_DBVersion == null)
                {
                    _DBVersion = new WCFServicePMDS.Repository.Repository.DBVersionRepository(_repoContext);
                }

                return _DBVersion;
            }
        }
        public Interfaces.ITblMedArchivRepository TblMedArchiv
        {
            get
            {
                if (_TblMedArchiv == null)
                {
                    _TblMedArchiv  = new WCFServicePMDS.Repository.Repository.TblMedArchivRepository(_repoContext);
                }

                return _TblMedArchiv;
            }
        }
        public Interfaces.ITblObjectRepository TblObject
        {
            get
            {
                if (_TblObject == null)
                {
                    _TblObject  = new WCFServicePMDS.Repository.Repository.TblObjectRepository(_repoContext);
                }

                return _TblObject;
            }
        }
        public Interfaces.ITblObjectApplicationsRepository TblObjectApplications
        {
            get
            {
                if (_TblObjectApplications == null)
                {
                    _TblObjectApplications  = new WCFServicePMDS.Repository.Repository.TblObjectApplicationsRepository(_repoContext);
                }

                return _TblObjectApplications;
            }
        }
        public Interfaces.ITblObjectRelRepository TblObjectRel
        {
            get
            {
                if (_TblObjectRel == null)
                {
                    _TblObjectRel  = new WCFServicePMDS.Repository.Repository.TblObjectRelRepository(_repoContext);
                }

                return _TblObjectRel;
            }
        }
        public Interfaces.ITblParticipantsRepository TblParticipants
        {
            get
            {
                if (_TblParticipants == null)
                {
                    _TblParticipants  = new WCFServicePMDS.Repository.Repository.TblParticipantsRepository(_repoContext);
                }

                return _TblParticipants;
            }
        }
        public Interfaces.ITblQueriesDefRepository TblQueriesDef
        {
            get
            {
                if (_TblQueriesDef == null)
                {
                    _TblQueriesDef  = new WCFServicePMDS.Repository.Repository.TblQueriesDefRepository(_repoContext);
                }

                return _TblQueriesDef;
            }
        }
        public Interfaces.ITblQueryJoinsTempRepository TblQueryJoinsTemp
        {
            get
            {
                if (_TblQueryJoinsTemp == null)
                {
                    _TblQueryJoinsTemp  = new WCFServicePMDS.Repository.Repository.TblQueryJoinsTempRepository(_repoContext);
                }

                return _TblQueryJoinsTemp;
            }
        }
        public Interfaces.ITblRelationshipRepository TblRelationship
        {
            get
            {
                if (_TblRelationship == null)
                {
                    _TblRelationship  = new WCFServicePMDS.Repository.Repository.TblRelationshipRepository(_repoContext);
                }

                return _TblRelationship;
            }
        }
        public Interfaces.ITblSelListEntriesRepository TblSelListEntries
        {
            get
            {
                if (_TblSelListEntries == null)
                {
                    _TblSelListEntries  = new WCFServicePMDS.Repository.Repository.TblSelListEntriesRepository(_repoContext);
                }

                return _TblSelListEntries;
            }
        }
        public Interfaces.ITblSelListEntriesObjRepository TblSelListEntriesObj
        {
            get
            {
                if (_TblSelListEntriesObj == null)
                {
                    _TblSelListEntriesObj  = new WCFServicePMDS.Repository.Repository.TblSelListEntriesObjRepository(_repoContext);
                }

                return _TblSelListEntriesObj;
            }
        }
        public Interfaces.ITblSelListEntriesSortRepository TblSelListEntriesSort
        {
            get
            {
                if (_TblSelListEntriesSort == null)
                {
                    _TblSelListEntriesSort  = new WCFServicePMDS.Repository.Repository.TblSelListEntriesSortRepository(_repoContext);
                }

                return _TblSelListEntriesSort;
            }
        }
        public Interfaces.ITblSelListGroupRepository TblSelListGroup
        {
            get
            {
                if (_TblSelListGroup == null)
                {
                    _TblSelListGroup  = new WCFServicePMDS.Repository.Repository.TblSelListGroupRepository(_repoContext);
                }

                return _TblSelListGroup;
            }
        }
        public Interfaces.ITblSideLogicRepository TblSideLogic
        {
            get
            {
                if (_TblSideLogic == null)
                {
                    _TblSideLogic  = new WCFServicePMDS.Repository.Repository.TblSideLogicRepository(_repoContext);
                }

                return _TblSideLogic;
            }
        }
        public Interfaces.ITblStatisticsRepository TblStatistics
        {
            get
            {
                if (_TblStatistics == null)
                {
                    _TblStatistics  = new WCFServicePMDS.Repository.Repository.TblStatisticsRepository(_repoContext);
                }

                return _TblStatistics;
            }
        }
        public Interfaces.ITblStayRepository TblStay
        {
            get
            {
                if (_TblStay == null)
                {
                    _TblStay  = new WCFServicePMDS.Repository.Repository.TblStayRepository(_repoContext);
                }

                return _TblStay;
            }
        }
        public Interfaces.ITblStayAdditionsRepository TblStayAdditions
        {
            get
            {
                if (_TblStayAdditions == null)
                {
                    _TblStayAdditions  = new WCFServicePMDS.Repository.Repository.TblStayAdditionsRepository(_repoContext);
                }

                return _TblStayAdditions;
            }
        }
        public Interfaces.ITblVersionsRepository TblVersions
        {
            get
            {
                if (_TblVersions == null)
                {
                    _TblVersions  = new WCFServicePMDS.Repository.Repository.TblVersionsRepository(_repoContext);
                }

                return _TblVersions;
            }
        }

        public Interfaces.IElgaactivitiesRepository Elgaactivities
        {
            get
            {
                if (_Elgaactivities == null)
                {
                    _Elgaactivities = new WCFServicePMDS.Repository.Repository.ElgaactivitiesRepository(_repoContext);
                }

                return _Elgaactivities;
            }
        }
        public Interfaces.IElgadocumentsRepository Elgadocuments
        {
            get
            {
                if (_Elgadocuments == null)
                {
                    _Elgadocuments = new WCFServicePMDS.Repository.Repository.ElgadocumentsRepository(_repoContext);
                }

                return _Elgadocuments;
            }
        }
        public Interfaces.IElgacontactsRepository Elgacontacts
        {
            get
            {
                if (_Elgacontacts == null)
                {
                    _Elgacontacts = new WCFServicePMDS.Repository.Repository.ElgacontactsRepository(_repoContext);
                }

                return _Elgacontacts;
            }
        }   
        public Interfaces.IElgaprotocollRepository Elgaprotocoll
        {
            get
            {
                if (_Elgaprotocoll == null)
                {
                    _Elgaprotocoll = new WCFServicePMDS.Repository.Repository.ElgaprotocollRepository(_repoContext);
                }

                return _Elgaprotocoll;
            }
        }
        public Interfaces.ITblRedistRepository TblRedist
        {
            get
            {
                if (_TblRedist == null)
                {
                    _TblRedist = new WCFServicePMDS.Repository.Repository.TblRedistRepository(_repoContext);
                }

                return _TblRedist;
            }
        }
        public Interfaces.IDBLizenzRepository DBLizenz
        {
            get
            {
                if (_DBLizenz == null)
                {
                    _DBLizenz = new WCFServicePMDS.Repository.Repository.DblizenzRepository(_repoContext);
                }

                return _DBLizenz;
            }
        }
        public Interfaces.IDienstzeitenRepository Dienstzeiten
        {
            get
            {
                if (_Dienstzeiten == null)
                {
                    _Dienstzeiten = new WCFServicePMDS.Repository.Repository.DienstzeitenRepository(_repoContext);
                }

                return _Dienstzeiten;
            }
        }
        public Interfaces.IvKlientenliste2Repository vKlientenliste2
        {
            get
            {
                if (_vKlientenliste2 == null)
                {
                    _vKlientenliste2 = new WCFServicePMDS.Repository.Repository.vKlientenliste2Repository(_repoContext);
                }

                return _vKlientenliste2;
            }
        }
        public Interfaces.IvInterventionen2Repository vInterventionen2
        {
            get
            {
                if (_vInterventionen2 == null)
                {
                    _vInterventionen2 = new WCFServicePMDS.Repository.Repository.vInterventionen2Repository(_repoContext);
                }

                return _vInterventionen2;
            }
        }
        public Interfaces.IvÜbergabe2Repository vÜbergabe2
        {
            get
            {
                if (_vÜbergabe2 == null)
                {
                    _vÜbergabe2 = new WCFServicePMDS.Repository.Repository.vÜbergabe2Repository(_repoContext);
                }

                return _vÜbergabe2;
            }
        }
    }

}

