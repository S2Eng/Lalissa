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
using System.Runtime.Serialization;
using System.Collections;


namespace WCFServicePMDS.BAL.Main
{
    [Serializable()]
    public class BenutzerMainDTO
    {

        private static BenutzerMainDTO _Benutzer1;
        public static BenutzerMainDTO Benutzer1
        {
            get => _Benutzer1;
            set => _Benutzer1 = value;
        }

        private static BenutzerMainDTO.lastBenutzer _LastBenutzer;
        public static BenutzerMainDTO.lastBenutzer LastBenutzer
        {
            get => _LastBenutzer;
            set => _LastBenutzer = value;
        }

        public static ConcurrentBag<BenutzerDt>  lastBenList = null;

        private static ConcurrentDictionary<DateTime, List<BenutzerDt>> _lAll;
        public static ConcurrentDictionary<DateTime, List<BenutzerDt>> lAll
        {
            get => _lAll;
            set => _lAll = value;
        }

        public static string _lastBenListSer = "";
        public static string lastBenListSer
        {
            get => _lastBenListSer;
            set => _lastBenListSer = value;
        }

        public static byte[] _lastBenListSerB = null;
        public static byte[] lastBenListSerB
        {
            get => _lastBenListSerB;
            set => _lastBenListSerB = value;
        }
        public static byte[] _lastBenTablesSerB = null;
        public static byte[] lastBenTablesSerB
        {
            get => _lastBenTablesSerB;
            set => _lastBenTablesSerB = value;
        }


        [Serializable()]
        public class BenutzerDt 
        {
            public Guid IDBenutzer;
            public BenutzerDTO ben;
            public AdresseDTO adresse;
            public KontaktDTO kontakt;
            public AerztDt aerzt;
            public RechtDt recht;
            public List<BereichDt> lBereich;
            public List<AbteilungDt> lAbteilung;
            public List<KlinikDt> lKlinik;

            public DateTime DtoFrom { get; set; }
        }

        [Serializable()]
        public class AerztDt 
        {
            public AerzteDTO aerzt;
            public AdresseDTO adresse;
            public KontaktDTO kontakt;
            public DateTime DtoFrom { get; set; }
        }

        [Serializable()]
        public class RechtDt
        {
            public List<BenutzerRechteDTO> benutzerRechte;
            public List<RechtDTO> recht;
            public DateTime DtoFrom { get; set; }
        }

        [Serializable()]
        public class BereichDt 
        {
            public BereichDTO bereich2;
            public AbteilungDTO abteilung2;
            public DateTime DtoFrom { get; set; }
        }

        [Serializable()]
        public class AbteilungDt 
        {
            public AbteilungDTO abteilung;
            public DateTime DtoFrom { get; set; }
        }

        [Serializable()]
        public class KlinikDt
        {
            public KlinikDTO klinik;
            public DateTime DtoFrom { get; set; }
        }




        


        private ConcurrentDictionary<DateTime, ConcurrentBag<BenutzerDTO>> _lBenutzer;
        private ConcurrentDictionary<DateTime, ConcurrentBag<AdresseDTO>> _lAdresse;
        private ConcurrentDictionary<DateTime, ConcurrentBag<KontaktDTO>> _lKontakt;
        private ConcurrentDictionary<DateTime, ConcurrentBag<BenutzerEinrichtungDTO>> _lBenutzerEinrichtung;
        private ConcurrentDictionary<DateTime, ConcurrentBag<BenutzerRechteDTO>> _lBenutzerRechte;
        private ConcurrentDictionary<DateTime, ConcurrentBag<BenutzerAbteilungDTO>> _lBenutzerAbteilung;
        private ConcurrentDictionary<DateTime, ConcurrentBag<BenutzerBezugDTO>> _lBenutzerBezug;
        private ConcurrentDictionary<DateTime, ConcurrentBag<BenutzerGruppeDTO>> _lBenutzerGruppe;
        private ConcurrentDictionary<DateTime, ConcurrentBag<BereichBenutzerDTO>> _lBereichBenutzer;
        private ConcurrentDictionary<DateTime, ConcurrentBag<GruppeDTO>> _lGruppe;
        private ConcurrentDictionary<DateTime, ConcurrentBag<GruppenRechtDTO>> _lGruppenRecht;
        private ConcurrentDictionary<DateTime, ConcurrentBag<RechtDTO>> _lRecht;
        private ConcurrentDictionary<DateTime, ConcurrentBag<BereichDTO>> _lBereich;
        private ConcurrentDictionary<DateTime, ConcurrentBag<DienstzeitenDTO>> _lDienstzeiten;
        private ConcurrentDictionary<DateTime, ConcurrentBag<AbteilungDTO>> _lAbteilung;
        private ConcurrentDictionary<DateTime, ConcurrentBag<StandardzeitenDTO>> _lStandardzeiten;
        private ConcurrentDictionary<DateTime, ConcurrentBag<BankDTO>> _lBank;
        private ConcurrentDictionary<DateTime, ConcurrentBag<BelegungDTO>> _lBelegung;
        private ConcurrentDictionary<DateTime, ConcurrentBag<KlinikDTO>> _lKlinik;
        private ConcurrentDictionary<DateTime, ConcurrentBag<AerzteDTO>> _lAerzte;




        //[System.ComponentModel.DefaultValue(true)]
        public ConcurrentDictionary<DateTime, ConcurrentBag<BenutzerDTO>> lBenutzer
        {
            get => _lBenutzer;
            set => _lBenutzer = value;

        }

        public ConcurrentDictionary<DateTime, ConcurrentBag<AdresseDTO>> lAdresse
        {
            get => _lAdresse;
            set => _lAdresse = value;
        }

        public ConcurrentDictionary<DateTime, ConcurrentBag<KontaktDTO>> lKontakt
        {
            get => _lKontakt;
            set => _lKontakt = value;
        }

        public ConcurrentDictionary<DateTime, ConcurrentBag<BenutzerEinrichtungDTO>> lBenutzerEinrichtung
        {
            get => _lBenutzerEinrichtung;
            set => _lBenutzerEinrichtung = value;
        }

        public ConcurrentDictionary<DateTime, ConcurrentBag<BenutzerRechteDTO>> lBenutzerRechte
        {
            get => _lBenutzerRechte;
            set => _lBenutzerRechte = value;
        }

        public ConcurrentDictionary<DateTime, ConcurrentBag<BenutzerAbteilungDTO>> lBenutzerAbteilung
        {
            get => _lBenutzerAbteilung;
            set => _lBenutzerAbteilung = value;
        }

        public ConcurrentDictionary<DateTime, ConcurrentBag<BenutzerBezugDTO>> lBenutzerBezug
        {
            get => _lBenutzerBezug;
            set => _lBenutzerBezug = value;
        }

        public ConcurrentDictionary<DateTime, ConcurrentBag<BenutzerGruppeDTO>> lBenutzerGruppe
        {
            get => _lBenutzerGruppe;
            set => _lBenutzerGruppe = value;
        }

        public ConcurrentDictionary<DateTime, ConcurrentBag<BereichBenutzerDTO>> lBereichBenutzer
        {
            get => _lBereichBenutzer;
            set => _lBereichBenutzer = value;
        }

        public ConcurrentDictionary<DateTime, ConcurrentBag<GruppeDTO>> lGruppe
        {
            get => _lGruppe;
            set => _lGruppe = value;
        }

        public ConcurrentDictionary<DateTime, ConcurrentBag<GruppenRechtDTO>> lGruppenRecht
        {
            get => _lGruppenRecht;
            set => _lGruppenRecht = value;
        }

        public ConcurrentDictionary<DateTime, ConcurrentBag<RechtDTO>> lRecht
        {
            get => _lRecht;
            set => _lRecht = value;
        }

        public ConcurrentDictionary<DateTime, ConcurrentBag<BereichDTO>> lBereich
        {
            get => _lBereich;
            set => _lBereich = value;
        }

        public ConcurrentDictionary<DateTime, ConcurrentBag<DienstzeitenDTO>> lDienstzeiten
        {
            get => _lDienstzeiten;
            set => _lDienstzeiten = value;
        }

        public ConcurrentDictionary<DateTime, ConcurrentBag<AbteilungDTO>> lAbteilung
        {
            get => _lAbteilung;
            set => _lAbteilung = value;
        }

        public ConcurrentDictionary<DateTime, ConcurrentBag<StandardzeitenDTO>> lStandardzeiten
        {
            get => _lStandardzeiten;
            set => _lStandardzeiten = value;
        }

        public ConcurrentDictionary<DateTime, ConcurrentBag<BankDTO>> lBank
        {
            get => _lBank;
            set => _lBank = value;
        }

        public ConcurrentDictionary<DateTime, ConcurrentBag<BelegungDTO>> lBelegung
        {
            get => _lBelegung;
            set => _lBelegung = value;
        }

        public ConcurrentDictionary<DateTime, ConcurrentBag<KlinikDTO>> lKlinik
        {
            get => _lKlinik;
            set => _lKlinik = value;
        }

        public ConcurrentDictionary<DateTime, ConcurrentBag<AerzteDTO>> lAerzte
        {
            get => _lAerzte;
            set => _lAerzte = value;
        }


        [Serializable()]
        public class lastBenutzer
        {
            public List<BenutzerDTO> lBenutzer { get; set; }
            public List<AdresseDTO> lAdresse { get; set; }
            public List<BenutzerEinrichtungDTO> lBenutzerEinrichtung { get; set; }
            public List<BenutzerRechteDTO> lBenutzerRechte { get; set; }
            public List<BenutzerAbteilungDTO> lBenutzerAbteilung { get; set; }
            public List<BenutzerBezugDTO> lBenutzerBezug { get; set; }
            public List<BenutzerGruppeDTO> lBenutzerGruppe { get; set; }
            public List<BereichBenutzerDTO> lBereichBenutzer { get; set; }
            public List<GruppeDTO> lGruppe { get; set; }
            public List<GruppenRechtDTO> lGruppenRecht { get; set; }
            public List<RechtDTO> lRecht { get; set; }
            public List<BereichDTO> lBereich { get; set; }
            public List<DienstzeitenDTO> lDienstzeiten { get; set; }
            public List<StandardzeitenDTO> lStandardzeiten { get; set; }
            public List<AbteilungDTO> lAbteilung { get; set; }
            public List<BankDTO> lBank { get; set; }
            public List<BelegungDTO> lBelegung { get; set; }
            public List<KlinikDTO> lKlinik { get; set; }
            public List<AerzteDTO> lAerzte { get; set; }

        }
    }

}

