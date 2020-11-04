using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL;
using WCFServicePMDS.DAL.Interfaces;
using WCFServicePMDS.BAL.Interfaces;
using WCFServicePMDS.DAL.DTO;
using WCFServicePMDS.BAL.Main.Interfaces;
using System.Collections.Concurrent;
using WCFServicePMDS.Repository;


namespace WCFServicePMDS.BAL.Main
{

    [Serializable()]
    public class PatientMainDTO
    {
        public static ConcurrentBag<vKlientenlisteDTO> _vKlientenliste = null;
        public static ConcurrentBag<vKlientenlisteDTO> vKlientenliste
        {
            get => _vKlientenliste;
            set => _vKlientenliste = value;
        }

        public static byte[] _PatientB = null;
        public static byte[] PatientB
        {
            get => _PatientB;
            set => _PatientB = value;
        }

        public static byte[] _vKlientenlisteB = null;
        public static byte[] vKlientenlisteB
        {
            get => _vKlientenlisteB;
            set => _vKlientenlisteB = value;
        }


        public static byte[] _lastPatListSerB = null;
        public static byte[] lastPatListSerB
        {
            get => _lastPatListSerB;
            set => _lastPatListSerB = value;
        }

        public static byte[] _lastPatTablesSerB = null;
        public static byte[] lastPatTablesSerB
        {
            get => _lastPatTablesSerB;
            set => _lastPatTablesSerB = value;
        }

        private static PatientMainDTO _Patient;
        public static PatientMainDTO Patient
        {
            get => _Patient;
            set => _Patient = value;
        }

        private static PatientMainDTO.lastPatienten _LastPatient;
        public static PatientMainDTO.lastPatienten LastPatient
        {
            get => _LastPatient;
            set => _LastPatient = value;
        }

        public static ConcurrentBag<PatientDt> lPatList = null;

        private static ConcurrentDictionary<DateTime, List<PatientDt>> _lAllAct;
        private static ConcurrentDictionary<DateTime, List<PatientDt>> _lAllEntl;

        public static ConcurrentDictionary<DateTime, List<PatientDt>> lAllAct
        {
            get => _lAllAct;
            set => _lAllAct = value;
        }
        public static ConcurrentDictionary<DateTime, List<PatientDt>> lAllEntl
        {
            get => _lAllEntl;
            set => _lAllEntl = value;
        }

        [Serializable()]
        public class PatientDt 
        {
            public Guid IDPatient { get; set; }
            public PatientDTO patient { get; set; }
            public AufenthaltDt aufenthaltAct { get; set; }
            public AdresseDTO adresse { get; set; }
            public KontaktDTO kontakt { get; set; }

            public AbteilungDTO abteilung { get; set; }


            public DateTime DtoFrom { get; set; }
        }
        [Serializable()]
        public class AufenthaltDt 
        {
            public bool Urlaub = false;
            public UrlaubVerlaufDTO urlaubVerlauf;
            public AufenthaltDTO aufenthalt;

            public DateTime DtoFrom { get; set; }
        }




        private ConcurrentDictionary<DateTime, ConcurrentBag<PatientDTO>> _lPatient;
        private ConcurrentDictionary<DateTime, ConcurrentBag<AufenthaltDTO>> _lAufenthalt;
        private ConcurrentDictionary<DateTime, ConcurrentBag<KontaktpersonDTO>> _lKontaktperson;
        private ConcurrentDictionary<DateTime, ConcurrentBag<PatientAbwesenheitDTO>> _lPatientAbwesenheit;
        private ConcurrentDictionary<DateTime, ConcurrentBag<PatientAerzteDTO>> _lPatientAerzte;
        private ConcurrentDictionary<DateTime, ConcurrentBag<PatientEinkommenDTO>> _lPatientEinkommen;
        private ConcurrentDictionary<DateTime, ConcurrentBag<PatientenBemerkungDTO>> _lPatientenBemerkung;
        private ConcurrentDictionary<DateTime, ConcurrentBag<PatientPflegestufeDTO>> _lPatientPflegestufe;
        private ConcurrentDictionary<DateTime, ConcurrentBag<RehabilitationDTO>> _lRehabilitation;
        private ConcurrentDictionary<DateTime, ConcurrentBag<SachwalterDTO>> _lSachwalter;
        // Kontakt Adresse





        public ConcurrentDictionary<DateTime, ConcurrentBag<PatientDTO>> lPatient
        {
            get => _lPatient;
            set => _lPatient = value;
        }

        public ConcurrentDictionary<DateTime, ConcurrentBag<AufenthaltDTO>> lAufenthalt
        {
            get => _lAufenthalt;
            set => _lAufenthalt = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<KontaktpersonDTO>> lKontaktperson
        {
            get => _lKontaktperson;
            set => _lKontaktperson = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<PatientAbwesenheitDTO>> lPatientAbwesenheit
        {
            get => _lPatientAbwesenheit;
            set => _lPatientAbwesenheit = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<PatientAerzteDTO>> lPatientAerzte
        {
            get => _lPatientAerzte;
            set => _lPatientAerzte = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<PatientEinkommenDTO>> lPatientEinkommen
        {
            get => _lPatientEinkommen;
            set => _lPatientEinkommen = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<PatientenBemerkungDTO>> lPatientenBemerkung
        {
            get => _lPatientenBemerkung;
            set => _lPatientenBemerkung = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<PatientPflegestufeDTO>> lPatientPflegestufe
        {
            get => _lPatientPflegestufe;
            set => _lPatientPflegestufe = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<RehabilitationDTO>> lRehabilitation
        {
            get => _lRehabilitation;
            set => _lRehabilitation = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<SachwalterDTO>> lSachwalter
        {
            get => _lSachwalter;
            set => _lSachwalter = value;
        }

        [Serializable()]
        public class lastPatienten
        {
            public List<PatientDTO> lPatient { get; set; }
            public List<AufenthaltDTO> lAufenthalt { get; set; }
            public List<KontaktpersonDTO> lKontaktperson { get; set; }
            public List<PatientAbwesenheitDTO> lPatientAbwesenheit { get; set; }
            public List<PatientAerzteDTO> lPatientAerzte { get; set; }
            public List<PatientEinkommenDTO> lPatientEinkommen { get; set; }
            public List<PatientenBemerkungDTO> lPatientenBemerkung { get; set; }
            public List<PatientPflegestufeDTO> lPatientPflegestufe { get; set; }
            public List<RehabilitationDTO> lRehabilitation { get; set; }
            public List<SachwalterDTO> lSachwalter { get; set; }

        }

    }

}
