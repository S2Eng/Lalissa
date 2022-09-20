using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;
using WCFServicePMDS.Repository;
using Microsoft.EntityFrameworkCore;


namespace WCFServicePMDS.Repository
{

    public class Repository
    {

        public class BenutzerRepository : WCFServicePMDS.Repository.RepositoryBase<Benutzer>, Interfaces.IBenutzerRepository
        {
            public BenutzerRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }

        public class AbteilungRepository : RepositoryBase<Abteilung>, Interfaces.IAbteilungRepository
        {
            public AbteilungRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class AdresseRepository : RepositoryBase<Adresse>, Interfaces.IAdresseRepository
        {
            public AdresseRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class AerzteRepository : RepositoryBase<Aerzte>, Interfaces.IAerzteRepository
        {
            public AerzteRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class Anamnese_KrohwinkelRepository : RepositoryBase<AnamneseKrohwinkel>, Interfaces.IAnamnese_KrohwinkelRepository
        {
            public Anamnese_KrohwinkelRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class Anamnese_OremRepository : RepositoryBase<AnamneseOrem>, Interfaces.IAnamnese_OremRepository
        {
            public Anamnese_OremRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class Anamnese_POPRepository : RepositoryBase<AnamnesePop>, Interfaces.IAnamnese_POPRepository
        {
            public Anamnese_POPRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class AnmeldungeneRepository : RepositoryBase<Anmeldungen>, Interfaces.IAnmeldungenRepository
        {
            public AnmeldungeneRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class ArchDokuRepository : RepositoryBase<ArchDoku>, Interfaces.IArchDokuRepository
        {
            public ArchDokuRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class ArchDokuSchlagRepository : RepositoryBase<ArchDokuSchlag>, Interfaces.IArchDokuSchlagRepository
        {
            public ArchDokuSchlagRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class ArchObjectRepository : RepositoryBase<ArchObject>, Interfaces.IArchObjectRepository
        {
            public ArchObjectRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class ArchOrdnerRepository : RepositoryBase<ArchOrdner>, Interfaces.IArchOrdnerRepository
        {
            public ArchOrdnerRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class ArztabrechnungRepository : RepositoryBase<Arztabrechnung>, Interfaces.IArztabrechnungRepository
        {
            public ArztabrechnungRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class AufenthaltRepository : RepositoryBase<Aufenthalt>, Interfaces.IAufenthaltRepository
        {
            public AufenthaltRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class AufenthaltPDxRepository : RepositoryBase<AufenthaltPdx>, Interfaces.IAufenthaltPDxRepository
        {
            public AufenthaltPDxRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class AufenthaltVerlaufRepository : RepositoryBase<AufenthaltVerlauf>, Interfaces.IAufenthaltVerlaufRepository
        {
            public AufenthaltVerlaufRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class AufenthaltZusatzRepository : RepositoryBase<AufenthaltZusatz>, Interfaces.IAufenthaltZusatzRepository
        {
            public AufenthaltZusatzRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class AuswahlListeRepository : RepositoryBase<AuswahlListe>, Interfaces.IAuswahlListeRepository
        {
            public AuswahlListeRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class AuswahlListeGruppeRepository : RepositoryBase<AuswahlListeGruppe>, Interfaces.IAuswahlListeGruppeRepository
        {
            public AuswahlListeGruppeRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class BankRepository : RepositoryBase<Bank>, Interfaces.IBankRepository
        {
            public BankRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class BarcodeQRepository : RepositoryBase<BarcodeQ>, Interfaces.IBarcodeQRepository
        {
            public BarcodeQRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class BelegungRepository : RepositoryBase<Belegung>, Interfaces.IBelegungRepository
        {
            public BelegungRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class BenutzerQRepository : RepositoryBase<Benutzer>, Interfaces.IBenutzerRepository
        {
            public BenutzerQRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class BenutzerAbteilungRepository : RepositoryBase<BenutzerAbteilung>, Interfaces.IBenutzerAbteilungRepository
        {
            public BenutzerAbteilungRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class BenutzerBezugRepository : RepositoryBase<BenutzerBezug>, Interfaces.IBenutzerBezugRepository
        {
            public BenutzerBezugRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class BenutzerEinrichtungRepository : RepositoryBase<BenutzerEinrichtung>, Interfaces.IBenutzerEinrichtungRepository
        {
            public BenutzerEinrichtungRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class BenutzerGruppeRepository : RepositoryBase<BenutzerGruppe>, Interfaces.IBenutzerGruppeRepository
        {
            public BenutzerGruppeRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class BenutzerRechteRepository : RepositoryBase<BenutzerRechte>, Interfaces.IBenutzerRechteRepository
        {
            public BenutzerRechteRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class BereichRepository : RepositoryBase<Bereich>, Interfaces.IBereichRepository
        {
            public BereichRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class BereichBenutzerRepository : RepositoryBase<BereichBenutzer>, Interfaces.IBereichBenutzerRepository
        {
            public BereichBenutzerRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class BillHeaderRepository : RepositoryBase<BillHeader>, Interfaces.IBillHeaderRepository
        {
            public BillHeaderRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class BillsRepository : RepositoryBase<Bills>, Interfaces.IBillsRepository
        {
            public BillsRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class BookingsRepository : RepositoryBase<Bookings>, Interfaces.IBookingsRepository
        {
            public BookingsRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class DokumenteRepository : RepositoryBase<Dokumente>, Interfaces.IDokumenteRepository
        {
            public DokumenteRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class Dokumente2Repository : RepositoryBase<Dokumente2>, Interfaces.IDokumente2Repository
        {
            public Dokumente2Repository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class EinrichtungRepository : RepositoryBase<Einrichtung>, Interfaces.IEinrichtungRepository
        {
            public EinrichtungRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class EintragRepository : RepositoryBase<Eintrag>, Interfaces.IEintragRepository
        {
            public EintragRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class EintragStandardprozedurenRepository : RepositoryBase<EintragStandardprozeduren>, Interfaces.IEintragStandardprozedurenRepository
        {
            public EintragStandardprozedurenRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class EintragZusatzRepository : RepositoryBase<EintragZusatz>, Interfaces.IEintragZusatzRepository
        {
            public EintragZusatzRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class EssenRepository : RepositoryBase<Essen>, Interfaces.IEssenRepository
        {
            public EssenRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class FormularRepository : RepositoryBase<Formular>, Interfaces.IFormularRepository
        {
            public FormularRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class FormularDatenRepository : RepositoryBase<FormularDaten>, Interfaces.IFormularDatenRepository
        {
            public FormularDatenRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class FormularDatenFelderRepository : RepositoryBase<FormularDatenFelder>, Interfaces.IFormularDatenFelderRepository
        {
            public FormularDatenFelderRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class GegenstaendeRepository : RepositoryBase<Gegenstaende>, Interfaces.IGegenstaendeRepository
        {
            public GegenstaendeRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class GruppeRepository : RepositoryBase<Gruppe>, Interfaces.IGruppeRepository
        {
            public GruppeRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class GruppenRechtRepository : RepositoryBase<GruppenRecht>, Interfaces.IGruppenRechtRepository
        {
            public GruppenRechtRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class InfoRepository : RepositoryBase<Info>, Interfaces.IInfoRepository
        {
            public InfoRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class KlinikRepository : RepositoryBase<Klinik>, Interfaces.IKlinikRepository
        {
            public KlinikRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class KontaktRepository : RepositoryBase<Kontakt>, Interfaces.IKontaktRepository
        {
            public KontaktRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class KontaktpersonRepository : RepositoryBase<Kontaktperson>, Interfaces.IKontaktpersonRepository
        {
            public KontaktpersonRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class KontaktpersonStammdatenRepository : RepositoryBase<KontaktpersonStammdaten>, Interfaces.IKontaktpersonStammdatenRepository
        {
            public KontaktpersonStammdatenRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class KostentraegerRepository : RepositoryBase<Kostentraeger>, Interfaces.IKostentraegerRepository
        {
            public KostentraegerRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class LeistungskatalogRepository : RepositoryBase<Leistungskatalog>, Interfaces.ILeistungskatalogRepository
        {
            public LeistungskatalogRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class LeistungskatalogGueltigRepository : RepositoryBase<LeistungskatalogGueltig>, Interfaces.ILeistungskatalogGueltigRepository
        {
            public LeistungskatalogGueltigRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class LinkDokumenteRepository : RepositoryBase<LinkDokumente>, Interfaces.ILinkDokumenteRepository
        {
            public LinkDokumenteRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class ManBuchRepository : RepositoryBase<ManBuch>, Interfaces.IManBuchRepository
        {
            public ManBuchRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class MassnahmenserienRepository : RepositoryBase<Massnahmenserien>, Interfaces.IMassnahmenserienRepository
        {
            public MassnahmenserienRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class MedikamentRepository : RepositoryBase<Medikament>, Interfaces.IMedikamentRepository
        {
            public MedikamentRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class MedikationAbgabeRepository : RepositoryBase<MedikationAbgabe>, Interfaces.IMedikationAbgabeRepository
        {
            public MedikationAbgabeRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class MedizinischeDatenRepository : RepositoryBase<MedizinischeDaten>, Interfaces.IMedizinischeDatenRepository
        {
            public MedizinischeDatenRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class MedizinischeDatenLayoutRepository : RepositoryBase<MedizinischeDatenLayout>, Interfaces.IMedizinischeDatenLayoutRepository
        {
            public MedizinischeDatenLayoutRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class MedizinischeTypenRepository : RepositoryBase<MedizinischeTypen>, Interfaces.IMedizinischeTypenRepository
        {
            public MedizinischeTypenRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class MessagesRepository : RepositoryBase<Messages>, Interfaces.IMessagesRepository
        {
            public MessagesRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class MessagesToUsersRepository : RepositoryBase<MessagesToUsers>, Interfaces.IMessagesToUsersRepository
        {
            public MessagesToUsersRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PatientRepository : RepositoryBase<Patient>, Interfaces.IPatientRepository
        {
            public PatientRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PatientAbwesenheitRepository : RepositoryBase<PatientAbwesenheit>, Interfaces.IPatientAbwesenheitRepository
        {
            public PatientAbwesenheitRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PatientAerzteRepository : RepositoryBase<PatientAerzte>, Interfaces.IPatientAerzteRepository
        {
            public PatientAerzteRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PatientEinkommenRepository : RepositoryBase<PatientEinkommen>, Interfaces.IPatientEinkommenRepository
        {
            public PatientEinkommenRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PatientenBemerkungRepository : RepositoryBase<PatientenBemerkung>, Interfaces.IPatientenBemerkungRepository
        {
            public PatientenBemerkungRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PatientKostentraegerRepository : RepositoryBase<PatientKostentraeger>, Interfaces.IPatientKostentraegerRepository
        {
            public PatientKostentraegerRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PatientLeistungsplanRepository : RepositoryBase<PatientLeistungsplan>, Interfaces.IPatientLeistungsplanRepository
        {
            public PatientLeistungsplanRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PatientPflegestufeRepository : RepositoryBase<PatientPflegestufe>, Interfaces.IPatientPflegestufRepository
        {
            public PatientPflegestufeRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PatientSonderleistungRepository : RepositoryBase<PatientSonderleistung>, Interfaces.IPatientSonderleistungRepository
        {
            public PatientSonderleistungRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PatientTaschengeldKostentraegerRepository : RepositoryBase<PatientTaschengeldKostentraeger>, Interfaces.IPatientTaschengeldKostentraegerRepository
        {
            public PatientTaschengeldKostentraegerRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PDXRepository : RepositoryBase<Pdx>, Interfaces.IPDXRepository
        {
            public PDXRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PDXAnamneseRepository : RepositoryBase<Pdxanamnese>, Interfaces.IPDXAnamneseRepository
        {
            public PDXAnamneseRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PDXEintragRepository : RepositoryBase<Pdxeintrag>, Interfaces.IPDXEintragRepository
        {
            public PDXEintragRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PDXGruppeRepository : RepositoryBase<Pdxgruppe>, Interfaces.IPDXGruppeRepository
        {
            public PDXGruppeRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PDXGruppeEintragRepository : RepositoryBase<PdxgruppeEintrag>, Interfaces.IPDXGruppeEintragRepository
        {
            public PDXGruppeEintragRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PDXPflegemodelleRepository : RepositoryBase<Pdxpflegemodelle>, Interfaces.IPDXPflegemodelleRepository
        {
            public PDXPflegemodelleRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PflegeEintragRepository : RepositoryBase<PflegeEintrag>, Interfaces.IPflegeEintragRepository
        {
            public PflegeEintragRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PflegeEintragEntwurfRepository : RepositoryBase<PflegeEintragEntwurf>, Interfaces.IPflegeEintragEntwurfRepository
        {
            public PflegeEintragEntwurfRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PflegegeldstufeRepository : RepositoryBase<Pflegegeldstufe>, Interfaces.IPflegegeldstufeRepository
        {
            public PflegegeldstufeRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PflegegeldstufeGueltigRepository : RepositoryBase<PflegegeldstufeGueltig>, Interfaces.IPflegegeldstufeGueltigRepository
        {
            public PflegegeldstufeGueltigRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PflegemodelleRepository : RepositoryBase<Pflegemodelle>, Interfaces.IPflegemodelleRepository
        {
            public PflegemodelleRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PflegePlanRepository : RepositoryBase<PflegePlan>, Interfaces.IPflegePlanRepository
        {
            public PflegePlanRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PflegePlanHRepository : RepositoryBase<PflegePlanH>, Interfaces.IPflegePlanHRepository
        {
            public PflegePlanHRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PflegePlanPDxRepository : RepositoryBase<PflegePlanPdx>, Interfaces.IPflegePlanPDxRepository
        {
            public PflegePlanPDxRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PlanRepository : RepositoryBase<Plan>, Interfaces.IPlanRepository
        {
            public PlanRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PlanAnhangRepository : RepositoryBase<PlanAnhang>, Interfaces.IPlanAnhangRepository
        {
            public PlanAnhangRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PlanObjectRepository : RepositoryBase<PlanObject>, Interfaces.IPlanObjectRepository
        {
            public PlanObjectRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class PlanStatusRepository : RepositoryBase<PlanStatus>, Interfaces.IPlanStatusRepository
        {
            public PlanStatusRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class QuickFilterRepository : RepositoryBase<QuickFilter>, Interfaces.IQuickFilterRepository
        {
            public QuickFilterRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class QuickMeldungRepository : RepositoryBase<QuickMeldung>, Interfaces.IQuickMeldungRepository
        {
            public QuickMeldungRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class RechNrRepository : RepositoryBase<RechNr>, Interfaces.IRechNrRepository
        {
            public RechNrRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class RechtRepository : RepositoryBase<Recht>, Interfaces.IRechtRepository
        {
            public RechtRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class RehabilitationRepository : RepositoryBase<Rehabilitation>, Interfaces.IRehabilitationRepository
        {
            public RehabilitationRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class RezeptBestellungPosRepository : RepositoryBase<RezeptBestellungPos>, Interfaces.IRezeptBestellungPosRepository
        {
            public RezeptBestellungPosRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class RezeptEintragRepository : RepositoryBase<RezeptEintrag>, Interfaces.IRezeptEintragRepository
        {
            public RezeptEintragRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class RezeptEintragMedDatenRepository : RepositoryBase<RezeptEintragMedDaten>, Interfaces.IRezeptEintragMedDatenRepository
        {
            public RezeptEintragMedDatenRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class SachwalterRepository : RepositoryBase<Sachwalter>, Interfaces.ISachwalterRepository
        {
            public SachwalterRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class SonderleistungsKatalogRepository : RepositoryBase<SonderleistungsKatalog>, Interfaces.ISonderleistungsKatalogRepository
        {
            public SonderleistungsKatalogRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class SPRepository : RepositoryBase<Sp>, Interfaces.ISPRepository
        {
            public SPRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class SpdynRepRepository : RepositoryBase<SpdynRep>, Interfaces.ISPDynRepRepository
        {
            public SpdynRepRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class SPPERepository : RepositoryBase<Sppe>, Interfaces.ISPPERepository
        {
            public SPPERepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class SPPOSRepository : RepositoryBase<Sppos>, Interfaces.ISPPOSRepository
        {
            public SPPOSRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class StandardProzedurenRepository : RepositoryBase<StandardProzeduren>, Interfaces.IStandardProzedurenRepository
        {
            public StandardProzedurenRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class StandardzeitenRepository : RepositoryBase<Standardzeiten>, Interfaces.IStandardzeitenRepository
        {
            public StandardzeitenRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TaschengeldRepository : RepositoryBase<Taschengeld>, Interfaces.ITaschengeldRepository
        {
            public TaschengeldRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class Tbl_NachrichtRepository : RepositoryBase<TblNachricht>, Interfaces.ITbl_NachrichRepository
        {
            public Tbl_NachrichtRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblAutoDokuRepository : RepositoryBase<TblAutoDoku>, Interfaces.ITblAutoDokuRepository
        {
            public TblAutoDokuRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblDokumenteRepository : RepositoryBase<TblDokumente>, Interfaces.ITblDokumenteRepository
        {
            public TblDokumenteRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblDokumenteGelesenRepository : RepositoryBase<TblDokumenteGelesen>, Interfaces.ITblDokumenteGelesenRepository
        {
            public TblDokumenteGelesenRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblDokumenteintragRepository : RepositoryBase<TblDokumenteintrag>, Interfaces.ITblDokumenteintragRepository
        {
            public TblDokumenteintragRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblDokumenteneintragSchlagwörterRepository : RepositoryBase<TblDokumenteneintragSchlagwörter>, Interfaces.ITblDokumenteneintragSchlagwörterRepository
        {
            public TblDokumenteneintragSchlagwörterRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblFachRepository : RepositoryBase<TblFach>, Interfaces.ITblFachRepository
        {
            public TblFachRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblFortbildungBenutzerRepository : RepositoryBase<TblFortbildungBenutzer>, Interfaces.ITblFortbildungBenutzerRepository
        {
            public TblFortbildungBenutzerRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblFortbildungenRepository : RepositoryBase<TblFortbildungen>, Interfaces.ITblFortbildungenRepository
        {
            public TblFortbildungenRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblInteropRepository : RepositoryBase<TblInterop>, Interfaces.ITblInteropRepository
        {
            public TblInteropRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblObjektRepository : RepositoryBase<TblObjekt>, Interfaces.ITblObjektRepository
        {
            public TblObjektRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblParameterRepository : RepositoryBase<TblParameter>, Interfaces.ITblParameterRepository
        {
            public TblParameterRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblPfadRepository : RepositoryBase<TblPfad>, Interfaces.ITblPfadRepository
        {
            public TblPfadRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblProvKonfigRepository : RepositoryBase<TblProvKonfig>, Interfaces.ITblProvKonfigRepository
        {
            public TblProvKonfigRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblRechteOrdnerRepository : RepositoryBase<TblRechteOrdner>, Interfaces.ITblRechteOrdnerRepository
        {
            public TblRechteOrdnerRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblSchlagwörterRepository : RepositoryBase<TblSchlagwörter>, Interfaces.ITblSchlagwörterRepository
        {
            public TblSchlagwörterRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblSchrankRepository : RepositoryBase<TblSchrank>, Interfaces.ITblSchrankRepository
        {
            public TblSchrankRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblSturzprotokollRepository : RepositoryBase<TblSturzprotokoll>, Interfaces.ITblSturzprotokollRepository
        {
            public TblSturzprotokollRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblSuchtgiftschrankSchlüsselRepository : RepositoryBase<TblSuchtgiftschrankSchlüssel>, Interfaces.ITblSuchtgiftschrankSchlüsselRepository
        {
            public TblSuchtgiftschrankSchlüsselRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblTextTemplatesRepository : RepositoryBase<TblTextTemplates>, Interfaces.ITblTextTemplatesRepository
        {
            public TblTextTemplatesRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblTextTemplatesFilesRepository : RepositoryBase<TblTextTemplatesFiles>, Interfaces.ITblTextTemplatesFilesRepository
        {
            public TblTextTemplatesFilesRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblThemenRepository : RepositoryBase<TblThemen>, Interfaces.ITblThemenRepository
        {
            public TblThemenRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblUIDefinitionsRepository : RepositoryBase<TblUidefinitions>, Interfaces.ITblUIDefinitionsRepository
        {
            public TblUIDefinitionsRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblUserAccountsRepository : RepositoryBase<TblUserAccounts>, Interfaces.ITblUserAccountsRepository
        {
            public TblUserAccountsRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblVeranstalterRepository : RepositoryBase<TblVeranstalter>, Interfaces.ITblVeranstalterRepository
        {
            public TblVeranstalterRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TextbausteineRepository : RepositoryBase<Textbausteine>, Interfaces.ITextbausteineRepository
        {
            public TextbausteineRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class UnterbringungRepository : RepositoryBase<Unterbringung>, Interfaces.IUnterbringungRepository
        {
            public UnterbringungRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class UrlaubVerlaufRepository : RepositoryBase<UrlaubVerlauf>, Interfaces.IUrlaubVerlaufRepository
        {
            public UrlaubVerlaufRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class VoRepository : RepositoryBase<Vo>, Interfaces.IVORepository
        {
            public VoRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class VO_BestelldatenRepository : RepositoryBase<VoBestelldaten>, Interfaces.IVO_BestelldatenRepository
        {
            public VO_BestelldatenRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class VO_BestellpostitionenRepository : RepositoryBase<VoBestellpostitionen>, Interfaces.IVO_BestellpostitionenRepository
        {
            public VO_BestellpostitionenRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class VO_LagerRepository : RepositoryBase<VoLager>, Interfaces.IVO_LagerRepository
        {
            public VO_LagerRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {
                
            }
        }
        public class VoMedizinischeDatenRepository : RepositoryBase<VoMedizinischeDaten>, Interfaces.IVO_MedizinischeDatenRepository
        {
            public VoMedizinischeDatenRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {
                
            }
        }
        public class VO_PflegeplanPDXRepository : RepositoryBase<VoPflegeplanPdx>, Interfaces.IVO_PflegeplanPDXRepository
        {
            public VO_PflegeplanPDXRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class VO_WundeRepository : RepositoryBase<VoWunde>, Interfaces.IVO_WundeRepository
        {
            public VO_WundeRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class WundeKopfRepository : RepositoryBase<WundeKopf>, Interfaces.IWundeKopfRepository
        {
            public WundeKopfRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class WundePosRepository : RepositoryBase<WundePos>, Interfaces.IWundePosRepository
        {
            public WundePosRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class WundePosBilderRepository : RepositoryBase<WundePosBilder>, Interfaces.IWundePosBilderRepository
        {
            public WundePosBilderRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class WundeTherapieRepository : RepositoryBase<WundeTherapie>, Interfaces.IWundeTherapieRepository
        {
            public WundeTherapieRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class ZeitbereichRepository : RepositoryBase<Zeitbereich>, Interfaces.IZeitbereichRepository
        {
            public ZeitbereichRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class ZeitbereichSerienRepository : RepositoryBase<ZeitbereichSerien>, Interfaces.IZeitbereichSerienRepository
        {
            public ZeitbereichSerienRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class ZusatzEintragRepository : RepositoryBase<ZusatzEintrag>, Interfaces.IZusatzEintragRepository
        {
            public ZusatzEintragRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class ZusatzGruppeRepository : RepositoryBase<ZusatzGruppe>, Interfaces.IZusatzGruppeRepository
        {
            public ZusatzGruppeRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class ZusatzGruppeEintragRepository : RepositoryBase<ZusatzGruppeEintrag>, Interfaces.IZusatzGruppeEintragRepository
        {
            public ZusatzGruppeEintragRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class ZusatzWertRepository : RepositoryBase<ZusatzWert>, Interfaces.IZusatzWertRepository
        {
            public ZusatzWertRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class LayoutRepository : RepositoryBase<Layout>, Interfaces.ILayoutRepository
        {
            public LayoutRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class LayoutGridsRepository : RepositoryBase<LayoutGrids>, Interfaces.ILayoutGridsRepository
        {
            public LayoutGridsRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class ProtocolRepository : RepositoryBase<Protocol>, Interfaces.IProtocolRepository
        {
            public ProtocolRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class RessourcenRepository : RepositoryBase<Ressourcen>, Interfaces.IRessourcenRepository
        {
            public RessourcenRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class tblAdjustRepository : RepositoryBase<TblAdjust>, Interfaces.ItblAdjustRepository
        {
            public tblAdjustRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class tblAdressRepository : RepositoryBase<TblAdress>, Interfaces.ITblAdressRepository
        {
            public tblAdressRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblCriteriaRepository : RepositoryBase<TblCriteria>, Interfaces.ITblCriteriaRepository
        {
            public TblCriteriaRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblCriteriaOptRepository : RepositoryBase<TblCriteriaOpt>, Interfaces.ITblCriteriaOptRepository
        {
            public TblCriteriaOptRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblDBVersionRepository : RepositoryBase<TblDbversion>, Interfaces.ITblDBVersionRepository
        {
            public TblDBVersionRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class DBVersionRepository : RepositoryBase<Dbversion>, Interfaces.IDbversionRepository
        {
            public DBVersionRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblMedArchivRepository : RepositoryBase<TblMedArchiv>, Interfaces.ITblMedArchivRepository
        {
            public TblMedArchivRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblObjectRepository : RepositoryBase<TblObject>, Interfaces.ITblObjectRepository
        {
            public TblObjectRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblObjectApplicationsRepository : RepositoryBase<TblObjectApplications>, Interfaces.ITblObjectApplicationsRepository
        {
            public TblObjectApplicationsRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblObjectRelRepository : RepositoryBase<TblObjectRel>, Interfaces.ITblObjectRelRepository
        {
            public TblObjectRelRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblParticipantsRepository : RepositoryBase<TblParticipants>, Interfaces.ITblParticipantsRepository
        {
            public TblParticipantsRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblQueriesDefRepository : RepositoryBase<TblQueriesDef>, Interfaces.ITblQueriesDefRepository
        {
            public TblQueriesDefRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblQueryJoinsTempRepository : RepositoryBase<TblQueryJoinsTemp>, Interfaces.ITblQueryJoinsTempRepository
        {
            public TblQueryJoinsTempRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblRelationshipRepository : RepositoryBase<TblRelationship>, Interfaces.ITblRelationshipRepository
        {
            public TblRelationshipRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblSelListEntriesRepository : RepositoryBase<TblSelListEntries>, Interfaces.ITblSelListEntriesRepository
        {
            public TblSelListEntriesRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblSelListEntriesObjRepository : RepositoryBase<TblSelListEntriesObj>, Interfaces.ITblSelListEntriesObjRepository
        {
            public TblSelListEntriesObjRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblSelListEntriesSortRepository : RepositoryBase<TblSelListEntriesSort>, Interfaces.ITblSelListEntriesSortRepository
        {
            public TblSelListEntriesSortRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblSelListGroupRepository : RepositoryBase<TblSelListGroup>, Interfaces.ITblSelListGroupRepository
        {
            public TblSelListGroupRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblSideLogicRepository : RepositoryBase<TblSideLogic>, Interfaces.ITblSideLogicRepository
        {
            public TblSideLogicRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblStatisticsRepository : RepositoryBase<TblStatistics>, Interfaces.ITblStatisticsRepository
        {
            public TblStatisticsRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblStayRepository : RepositoryBase<TblStay>, Interfaces.ITblStayRepository
        {
            public TblStayRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblStayAdditionsRepository : RepositoryBase<TblStayAdditions>, Interfaces.ITblStayAdditionsRepository
        {
            public TblStayAdditionsRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblVersionsRepository : RepositoryBase<TblVersions>, Interfaces.ITblVersionsRepository
        {
            public TblVersionsRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class ElgaactivitiesRepository : RepositoryBase<Elgaactivities>, Interfaces.IElgaactivitiesRepository
        {
            public ElgaactivitiesRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class ElgadocumentsRepository : RepositoryBase<Elgadocuments>, Interfaces.IElgadocumentsRepository
        {
            public ElgadocumentsRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class ElgacontactsRepository : RepositoryBase<Elgacontacts>, Interfaces.IElgacontactsRepository
        {
            public ElgacontactsRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }   
        public class ElgaprotocollRepository : RepositoryBase<Elgaprotocoll>, Interfaces.IElgaprotocollRepository
        {
            public ElgaprotocollRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class TblRedistRepository : RepositoryBase<TblRedist>, Interfaces.ITblRedistRepository
        {
            public TblRedistRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class DblizenzRepository : RepositoryBase<Dblizenz>, Interfaces.IDBLizenzRepository
        {
            public DblizenzRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class DienstzeitenRepository : RepositoryBase<Dienstzeiten>, Interfaces.IDienstzeitenRepository
        {
            public DienstzeitenRepository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class vKlientenliste2Repository : RepositoryBase<vKlientenliste2>, Interfaces.IvKlientenliste2Repository
        {
            public vKlientenliste2Repository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class vInterventionen2Repository : RepositoryBase<vInterventionen2>, Interfaces.IvInterventionen2Repository
        {
            public vInterventionen2Repository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
        public class vÜbergabe2Repository : RepositoryBase<vÜbergabe2>, Interfaces.IvÜbergabe2Repository
        {
            public vÜbergabe2Repository(Models.DB.PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }
        }
    }

}
