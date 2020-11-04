using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;
using Microsoft.EntityFrameworkCore;


namespace WCFServicePMDS.Repository
{

    public class Interfaces
    {

        public interface IRepositoryBase<T>
        {
            IEnumerable<T> FindAll();
            IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
            IEnumerable<T> FindAllTake(int Nr);
            void Create(T entity);
            void Update(T entity);
            void Delete(T entity);
            void Save();
            void Save2();
            Task<List<T>> getAllAsync();
            Task<List<T>> getWhereAsync(Expression<Func<T, bool>> expression);
        }



        public interface IAbteilungRepository : IRepositoryBase<Abteilung>
        {

        }
        public interface IAdresseRepository : IRepositoryBase<Adresse>
        {

        }
        public interface IAerzteRepository : IRepositoryBase<Aerzte>
        {

        }
        public interface IAnamnese_KrohwinkelRepository : IRepositoryBase<AnamneseKrohwinkel>
        {

        }
        public interface IAnamnese_OremRepository : IRepositoryBase<AnamneseOrem>
        {

        }
        public interface IAnamnese_POPRepository : IRepositoryBase<AnamnesePop>
        {

        }
        public interface IAnmeldungenRepository : IRepositoryBase<Anmeldungen>
        {

        }
        public interface IArchDokuRepository : IRepositoryBase<ArchDoku>
        {

        }
        public interface IArchDokuSchlagRepository : IRepositoryBase<ArchDokuSchlag>
        {

        }
        public interface IArchObjectRepository : IRepositoryBase<ArchObject>
        {

        }
        public interface IArchOrdnerRepository : IRepositoryBase<ArchOrdner>
        {

        }
        public interface IArztabrechnungRepository : IRepositoryBase<Arztabrechnung>
        {

        }
        public interface IAufenthaltRepository : IRepositoryBase<Aufenthalt>
        {

        }
        public interface IAufenthaltPDxRepository : IRepositoryBase<AufenthaltPdx>
        {

        }
        public interface IAufenthaltVerlaufRepository : IRepositoryBase<AufenthaltVerlauf>
        {

        }
        public interface IAufenthaltZusatzRepository : IRepositoryBase<AufenthaltZusatz>
        {

        }
        public interface IAuswahlListeRepository : IRepositoryBase<AuswahlListe>
        {

        }
        public interface IAuswahlListeGruppeRepository : IRepositoryBase<AuswahlListeGruppe>
        {

        }
        public interface IBankRepository : IRepositoryBase<Bank>
        {

        }
        public interface IBarcodeQRepository : IRepositoryBase<BarcodeQ>
        {

        }
        public interface IBelegungRepository : IRepositoryBase<Belegung>
        {

        }
        public interface IBenutzerRepository : IRepositoryBase<Benutzer>
        {

        }
        public interface IBenutzerAbteilungRepository : IRepositoryBase<BenutzerAbteilung>
        {

        }
        public interface IBenutzerBezugRepository : IRepositoryBase<BenutzerBezug>
        {

        }
        public interface IBenutzerEinrichtungRepository : IRepositoryBase<BenutzerEinrichtung>
        {

        }
        public interface IBenutzerGruppeRepository : IRepositoryBase<BenutzerGruppe>
        {

        }
        public interface IBenutzerRechteRepository : IRepositoryBase<BenutzerRechte>
        {

        }
        public interface IBereichRepository : IRepositoryBase<Bereich>
        {

        }
        public interface IBereichBenutzerRepository : IRepositoryBase<BereichBenutzer>
        {

        }
        public interface IBillHeaderRepository : IRepositoryBase<BillHeader>
        {

        }
        public interface IBillsRepository : IRepositoryBase<Bills>
        {

        }
        public interface IBookingsRepository : IRepositoryBase<Bookings>
        {

        }

        public interface IDokumenteRepository : IRepositoryBase<Dokumente>
        {

        }
        public interface IDokumente2Repository : IRepositoryBase<Dokumente2>
        {

        }
        public interface IEinrichtungRepository : IRepositoryBase<Einrichtung>
        {

        }
        public interface IEintragRepository : IRepositoryBase<Eintrag>
        {

        }
        public interface IEintragStandardprozedurenRepository : IRepositoryBase<EintragStandardprozeduren>
        {

        }
        public interface IEintragZusatzRepository : IRepositoryBase<EintragZusatz>
        {

        }
        public interface IEssenRepository : IRepositoryBase<Essen>
        {

        }
        public interface IFormularRepository : IRepositoryBase<Formular>
        {

        }
        public interface IFormularDatenRepository : IRepositoryBase<FormularDaten>
        {

        }
        public interface IFormularDatenFelderRepository : IRepositoryBase<FormularDatenFelder>
        {

        }
        public interface IGegenstaendeRepository : IRepositoryBase<Gegenstaende>
        {

        }
        public interface IGruppeRepository : IRepositoryBase<Gruppe>
        {

        }
        public interface IGruppenRechtRepository : IRepositoryBase<GruppenRecht>
        {

        }
        public interface IInfoRepository : IRepositoryBase<Info>
        {

        }
        public interface IKlinikRepository : IRepositoryBase<Klinik>
        {

        }
        public interface IKontaktRepository : IRepositoryBase<Kontakt>
        {

        }
        public interface IKontaktpersonRepository : IRepositoryBase<Kontaktperson>
        {

        }
        public interface IKontaktpersonStammdatenRepository : IRepositoryBase<KontaktpersonStammdaten>
        {

        }
        public interface IKostentraegerRepository : IRepositoryBase<Kostentraeger>
        {

        }
        public interface ILeistungskatalogRepository : IRepositoryBase<Leistungskatalog>
        {

        }
        public interface ILeistungskatalogGueltigRepository : IRepositoryBase<LeistungskatalogGueltig>
        {

        }
        public interface ILinkDokumenteRepository : IRepositoryBase<LinkDokumente>
        {

        }
        public interface IManBuchRepository : IRepositoryBase<ManBuch>
        {

        }
        public interface IMassnahmenserienRepository : IRepositoryBase<Massnahmenserien>
        {

        }
        public interface IMedikamentRepository : IRepositoryBase<Medikament>
        {

        }
        public interface IMedikationAbgabeRepository : IRepositoryBase<MedikationAbgabe>
        {

        }
        public interface IMedizinischeDatenRepository : IRepositoryBase<MedizinischeDaten>
        {

        }
        public interface IMedizinischeDatenLayoutRepository : IRepositoryBase<MedizinischeDatenLayout>
        {

        }
        public interface IMedizinischeTypenRepository : IRepositoryBase<MedizinischeTypen>
        {

        }
        public interface IMessagesRepository : IRepositoryBase<Messages>
        {

        }
        public interface IMessagesToUsersRepository : IRepositoryBase<MessagesToUsers>
        {

        }

        public interface IPatientRepository : IRepositoryBase<Patient>
        {

        }
        public interface IPatientAbwesenheitRepository : IRepositoryBase<PatientAbwesenheit>
        {

        }
        public interface IPatientAerzteRepository : IRepositoryBase<PatientAerzte>
        {

        }
        public interface IPatientEinkommenRepository : IRepositoryBase<PatientEinkommen>
        {

        }
        public interface IPatientenBemerkungRepository : IRepositoryBase<PatientenBemerkung>
        {

        }
        public interface IPatientKostentraegerRepository : IRepositoryBase<PatientKostentraeger>
        {

        }
        public interface IPatientLeistungsplanRepository : IRepositoryBase<PatientLeistungsplan>
        {

        }
        public interface IPatientPflegestufRepository : IRepositoryBase<PatientPflegestufe>
        {

        }
        public interface IPatientSonderleistungRepository : IRepositoryBase<PatientSonderleistung>
        {

        }
        public interface IPatientTaschengeldKostentraegerRepository : IRepositoryBase<PatientTaschengeldKostentraeger>
        {

        }
        public interface IPDXRepository : IRepositoryBase<Pdx>
        {

        }
        public interface IPDXAnamneseRepository : IRepositoryBase<Pdxanamnese>
        {

        }
        public interface IPDXEintragRepository : IRepositoryBase<Pdxeintrag>
        {

        }
        public interface IPDXGruppeRepository : IRepositoryBase<Pdxgruppe>
        {

        }
        public interface IPDXGruppeEintragRepository : IRepositoryBase<PdxgruppeEintrag>
        {

        }
        public interface IPDXPflegemodelleRepository : IRepositoryBase<Pdxpflegemodelle>
        {

        }
        public interface IPflegeEintragRepository : IRepositoryBase<PflegeEintrag>
        {

        }
        public interface IPflegeEintragEntwurfRepository : IRepositoryBase<PflegeEintragEntwurf>
        {

        }
        public interface IPflegegeldstufeRepository : IRepositoryBase<Pflegegeldstufe>
        {

        }
        public interface IPflegegeldstufeGueltigRepository : IRepositoryBase<PflegegeldstufeGueltig>
        {

        }
        public interface IPflegemodelleRepository : IRepositoryBase<Pflegemodelle>
        {

        }
        public interface IPflegePlanRepository : IRepositoryBase<PflegePlan>
        {

        }
        public interface IPflegePlanHRepository : IRepositoryBase<PflegePlanH>
        {

        }
        public interface IPflegePlanPDxRepository : IRepositoryBase<PflegePlanPdx>
        {

        }
        public interface IPlanRepository : IRepositoryBase<Plan>
        {

        }
        public interface IPlanAnhangRepository : IRepositoryBase<PlanAnhang>
        {

        }
        public interface IPlanObjectRepository : IRepositoryBase<PlanObject>
        {

        }
        public interface IPlanStatusRepository : IRepositoryBase<PlanStatus>
        {

        }
        public interface IQuickFilterRepository : IRepositoryBase<QuickFilter>
        {

        }
        public interface IQuickMeldungRepository : IRepositoryBase<QuickMeldung>
        {

        }
        public interface IRechNrRepository : IRepositoryBase<RechNr>
        {

        }
        public interface IRechtRepository : IRepositoryBase<Recht>
        {

        }
        public interface IRehabilitationRepository : IRepositoryBase<Rehabilitation>
        {

        }
        public interface IRezeptBestellungPosRepository : IRepositoryBase<RezeptBestellungPos>
        {

        }
        public interface IRezeptEintragRepository : IRepositoryBase<RezeptEintrag>
        {

        }
        public interface IRezeptEintragMedDatenRepository : IRepositoryBase<RezeptEintragMedDaten>
        {

        }
        public interface ISachwalterRepository : IRepositoryBase<Sachwalter>
        {

        }
        public interface ISonderleistungsKatalogRepository : IRepositoryBase<SonderleistungsKatalog>
        {

        }
        public interface ISPRepository : IRepositoryBase<Sp>
        {

        }
        public interface ISPDynRepRepository : IRepositoryBase<SpdynRep>
        {

        }
        public interface ISPPERepository : IRepositoryBase<Sppe>
        {

        }
        public interface ISPPOSRepository : IRepositoryBase<Sppos>
        {

        }
        public interface IStandardProzedurenRepository : IRepositoryBase<StandardProzeduren>
        {

        }
        public interface IStandardzeitenRepository : IRepositoryBase<Standardzeiten>
        {

        }
        public interface ITaschengeldRepository : IRepositoryBase<Taschengeld>
        {

        }
        public interface ITbl_NachrichRepository : IRepositoryBase<TblNachricht>
        {

        }
        public interface ITblAutoDokuRepository : IRepositoryBase<TblAutoDoku>
        {

        }
        public interface ITblDokumenteRepository : IRepositoryBase<TblDokumente>
        {

        }
        public interface ITblDokumenteGelesenRepository : IRepositoryBase<TblDokumenteGelesen>
        {

        }
        public interface ITblDokumenteintragRepository : IRepositoryBase<TblDokumenteintrag>
        {

        }
        public interface ITblDokumenteneintragSchlagwörterRepository : IRepositoryBase<TblDokumenteneintragSchlagwörter>
        {

        }
        public interface ITblFachRepository : IRepositoryBase<TblFach>
        {

        }
        public interface ITblFortbildungBenutzerRepository : IRepositoryBase<TblFortbildungBenutzer>
        {

        }
        public interface ITblFortbildungenRepository : IRepositoryBase<TblFortbildungen>
        {

        }
        public interface ITblInteropRepository : IRepositoryBase<TblInterop>
        {

        }
        public interface ITblObjektRepository : IRepositoryBase<TblObjekt>
        {

        }
        public interface ITblParameterRepository : IRepositoryBase<TblParameter>
        {

        }
        public interface ITblPfadRepository : IRepositoryBase<TblPfad>
        {

        }
        public interface ITblProvKonfigRepository : IRepositoryBase<TblProvKonfig>
        {

        }
        public interface ITblRechteOrdnerRepository : IRepositoryBase<TblRechteOrdner>
        {

        }
        public interface ITblSchlagwörterRepository : IRepositoryBase<TblSchlagwörter>
        {

        }
        public interface ITblSchrankRepository : IRepositoryBase<TblSchrank>
        {

        }
        public interface ITblSturzprotokollRepository : IRepositoryBase<TblSturzprotokoll>
        {

        }
        public interface ITblSuchtgiftschrankSchlüsselRepository : IRepositoryBase<TblSuchtgiftschrankSchlüssel>
        {

        }
        public interface ITblTextTemplatesRepository : IRepositoryBase<TblTextTemplates>
        {

        }
        public interface ITblTextTemplatesFilesRepository : IRepositoryBase<TblTextTemplatesFiles>
        {

        }
        public interface ITblThemenRepository : IRepositoryBase<TblThemen>
        {

        }
        public interface ITblUIDefinitionsRepository : IRepositoryBase<TblUidefinitions>
        {

        }
        public interface ITblUserAccountsRepository : IRepositoryBase<TblUserAccounts>
        {

        }
        public interface ITblVeranstalterRepository : IRepositoryBase<TblVeranstalter>
        {

        }
        public interface ITextbausteineRepository : IRepositoryBase<Textbausteine>
        {

        }
        public interface IUnterbringungRepository : IRepositoryBase<Unterbringung>
        {

        }
        public interface IUrlaubVerlaufRepository : IRepositoryBase<UrlaubVerlauf>
        {

        }
        public interface IVORepository : IRepositoryBase<Vo>
        {

        }
        public interface IVO_BestelldatenRepository : IRepositoryBase<VoBestelldaten>
        {

        }
        public interface IVO_BestellpostitionenRepository : IRepositoryBase<VoBestellpostitionen>
        {

        }
        public interface IVO_LagerRepository : IRepositoryBase<VoLager>
        {

        }
        public interface IVO_MedizinischeDatenRepository : IRepositoryBase<VoMedizinischeDaten>
        {

        }
        public interface IVO_PflegeplanPDXRepository : IRepositoryBase<VoPflegeplanPdx>
        {

        }
        public interface IVO_WundeRepository : IRepositoryBase<VoWunde>
        {

        }
        public interface IWundeKopfRepository : IRepositoryBase<WundeKopf>
        {

        }
        public interface IWundePosRepository : IRepositoryBase<WundePos>
        {

        }
        public interface IWundePosBilderRepository : IRepositoryBase<WundePosBilder>
        {

        }
        public interface IWundeTherapieRepository : IRepositoryBase<WundeTherapie>
        {

        }
        public interface IZeitbereichRepository : IRepositoryBase<Zeitbereich>
        {

        }
        public interface IZeitbereichSerienRepository : IRepositoryBase<ZeitbereichSerien>
        {

        }
        public interface IZusatzEintragRepository : IRepositoryBase<ZusatzEintrag>
        {

        }
        public interface IZusatzGruppeRepository : IRepositoryBase<ZusatzGruppe>
        {

        }
        public interface IZusatzGruppeEintragRepository : IRepositoryBase<ZusatzGruppeEintrag>
        {

        }
        public interface IZusatzWertRepository : IRepositoryBase<ZusatzWert>
        {

        }
        public interface IAddInsRepository : IRepositoryBase<AddIns>
        {

        }
        public interface ILayoutRepository : IRepositoryBase<Layout>
        {

        }
        public interface ILayoutGridsRepository : IRepositoryBase<LayoutGrids>
        {

        }
        public interface IProtocolRepository : IRepositoryBase<Protocol>
        {

        }
        public interface IRessourcenRepository : IRepositoryBase<Ressourcen>
        {

        }
        public interface ItblAdjustRepository : IRepositoryBase<TblAdjust>
        {

        }
        public interface ITblAdressRepository : IRepositoryBase<TblAdress>
        {

        }
        public interface ITblCriteriaRepository : IRepositoryBase<TblCriteria>
        {

        }
        public interface ITblCriteriaOptRepository : IRepositoryBase<TblCriteriaOpt>
        {

        }
        public interface ITblDBVersionRepository : IRepositoryBase<TblDbversion>
        {

        }
        public interface IDbversionRepository : IRepositoryBase<Dbversion>
        {

        }
        public interface ITblMedArchivRepository : IRepositoryBase<TblMedArchiv>
        {

        }
        public interface ITblObjectRepository : IRepositoryBase<TblObject>
        {

        }
        public interface ITblObjectApplicationsRepository : IRepositoryBase<TblObjectApplications>
        {

        }
        public interface ITblObjectRelRepository : IRepositoryBase<TblObjectRel>
        {

        }
        public interface ITblParticipantsRepository : IRepositoryBase<TblParticipants>
        {

        }
        public interface ITblQueriesDefRepository : IRepositoryBase<TblQueriesDef>
        {

        }
        public interface ITblQueryJoinsTempRepository : IRepositoryBase<TblQueryJoinsTemp>
        {

        }
        public interface ITblRelationshipRepository : IRepositoryBase<TblRelationship>
        {

        }
        public interface ITblSelListEntriesRepository : IRepositoryBase<TblSelListEntries>
        {

        }
        public interface ITblSelListEntriesObjRepository : IRepositoryBase<TblSelListEntriesObj>
        {

        }
        public interface ITblSelListEntriesSortRepository : IRepositoryBase<TblSelListEntriesSort>
        {

        }
        public interface ITblSelListGroupRepository : IRepositoryBase<TblSelListGroup>
        {

        }
        public interface ITblSideLogicRepository : IRepositoryBase<TblSideLogic>
        {

        }
        public interface ITblStatisticsRepository : IRepositoryBase<TblStatistics>
        {

        }
        public interface ITblStayRepository : IRepositoryBase<TblStay>
        {

        }
        public interface ITblStayAdditionsRepository : IRepositoryBase<TblStayAdditions>
        {

        }
        public interface ITblVersionsRepository : IRepositoryBase<TblVersions>
        {

        }

        public interface IElgaactivitiesRepository : IRepositoryBase<Elgaactivities>
        {

        }
        public interface IElgadocumentsRepository : IRepositoryBase<Elgadocuments>
        {

        }
        public interface IElgacontactsRepository : IRepositoryBase<Elgacontacts>
        {

        }
        public interface IElgaprotocollRepository : IRepositoryBase<Elgaprotocoll>
        {

        }
        public interface ITblRedistRepository : IRepositoryBase<TblRedist>
        {

        }
        public interface IDBLizenzRepository : IRepositoryBase<Dblizenz>
        {

        }
        public interface IDienstzeitenRepository : IRepositoryBase<Dienstzeiten>
        {

        }
        public interface IvKlientenliste2Repository : IRepositoryBase<vKlientenliste2>
        {

        }
        public interface IvInterventionen2Repository : IRepositoryBase<vInterventionen2>
        {

        }
        public interface IvÜbergabe2Repository : IRepositoryBase<vÜbergabe2>
        {

        }
    }

}

