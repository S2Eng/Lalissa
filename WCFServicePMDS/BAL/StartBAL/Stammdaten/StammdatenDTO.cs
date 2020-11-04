using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL;
using WCFServicePMDS.DAL.Interfaces;
using WCFServicePMDS.BAL.Interfaces;
using WCFServicePMDS.DAL.DTO;
using System.Collections.Concurrent;


namespace WCFServicePMDS.BAL.Main
{

    public class StammdatenDTO 
    {

        public StammdatenDTO()
        {

        }

        public static string _lastSDSer = "";
        public static string lastSDSer
        {
            get => _lastSDSer;
            set => _lastSDSer = value;
        }

        public static byte[] _lastSDSerB = null;
        public static byte[] lastSDSerB
        {
            get => _lastSDSerB;
            set => _lastSDSerB = value;
        }

        private static StammdatenDTO _Stammdaten;

        public static StammdatenDTO Stammdaten
        {
            get
            {
                return _Stammdaten;
            }
            set
            {
                _Stammdaten = value;
            }
        }


        private ConcurrentDictionary<DateTime, ConcurrentBag<AuswahlListeDTO>> _lAuswahlliste;
        private ConcurrentDictionary<DateTime, ConcurrentBag<AuswahlListeGruppeDTO>> _lAuswahlListeGruppe;
        private ConcurrentDictionary<DateTime, ConcurrentBag<RessourcenDTO>> _lRessourcenDTO;
        private ConcurrentDictionary<DateTime, ConcurrentBag<tblSelListEntriesDTO>> _ltblSelListEntries;
        private ConcurrentDictionary<DateTime, ConcurrentBag<tblSelListGroupDTO>> _ltblSelListGroup;
        private ConcurrentDictionary<DateTime, ConcurrentBag<LayoutDTO>> _lLayout;
        private ConcurrentDictionary<DateTime, ConcurrentBag<LayoutGridsDTO>> _lLayoutGrids;
        private ConcurrentDictionary<DateTime, ConcurrentBag<FormularDTO>> _lFormular;
        private ConcurrentDictionary<DateTime, ConcurrentBag<tblTextTemplatesDTO>> _ltblTextTemplates;
        private ConcurrentDictionary<DateTime, ConcurrentBag<tblTextTemplatesFilesDTO>> _ltblTextTemplatesFiles;
        private ConcurrentDictionary<DateTime, ConcurrentBag<TextbausteineDTO>> _lTextbausteine;
        private ConcurrentDictionary<DateTime, ConcurrentBag<DBLizenzDTO>> _lDBLizenzDTO;
        private ConcurrentDictionary<DateTime, ConcurrentBag<DBVersionDTO>> _lDBVersion;
        private ConcurrentDictionary<DateTime, ConcurrentBag<DienstzeitenDTO>> _lDienstzeiten;
        private ConcurrentDictionary<DateTime, ConcurrentBag<EinrichtungDTO>> _lEinrichtung;
        private ConcurrentDictionary<DateTime, ConcurrentBag<GruppeDTO>> _lGruppe;
        private ConcurrentDictionary<DateTime, ConcurrentBag<GruppenRechtDTO>> _lGruppenRecht;
        private ConcurrentDictionary<DateTime, ConcurrentBag<LinkDokumenteDTO>> _lLinkDokumente;
        private ConcurrentDictionary<DateTime, ConcurrentBag<MassnahmenserienDTO>> _lMassnahmenserien;
        private ConcurrentDictionary<DateTime, ConcurrentBag<StandardProzedurenDTO>> _lStandardProzeduren;
        private ConcurrentDictionary<DateTime, ConcurrentBag<StandardzeitenDTO>> _lStandardzeiten;
        private ConcurrentDictionary<DateTime, ConcurrentBag<tblAutoDokuDTO>> _ltblAutoDoku;
        private ConcurrentDictionary<DateTime, ConcurrentBag<tblInteropDTO>> _ltblInterop;
        private ConcurrentDictionary<DateTime, ConcurrentBag<tblParameterDTO>> _ltblParameter;
        private ConcurrentDictionary<DateTime, ConcurrentBag<tblPfadDTO>> _ltblPfad;
        private ConcurrentDictionary<DateTime, ConcurrentBag<tblProvKonfigDTO>> _ltblProvKonfig;
        private ConcurrentDictionary<DateTime, ConcurrentBag<tblRechteOrdnerDTO>> _ltblRechteOrdner;
        private ConcurrentDictionary<DateTime, ConcurrentBag<tblRedistDTO>> _ltblRedis;
        private ConcurrentDictionary<DateTime, ConcurrentBag<tblUserAccountsDTO>> _ltblUserAccounts;
        private ConcurrentDictionary<DateTime, ConcurrentBag<ZeitbereichDTO>> _lZeitbereich;
        private ConcurrentDictionary<DateTime, ConcurrentBag<ZeitbereichSerienDTO>> _lZeitbereichSerien;
        private ConcurrentDictionary<DateTime, ConcurrentBag<tblQueriesDefDTO>> _ltblQueriesDef;
        private ConcurrentDictionary<DateTime, ConcurrentBag<AbteilungDTO>> _lAbteilung;
        private ConcurrentDictionary<DateTime, ConcurrentBag<archOrdnerDTO>> _larchOrdner;
        private ConcurrentDictionary<DateTime, ConcurrentBag<BereichDTO>> _lBereichDTO;


        


        public ConcurrentDictionary<DateTime, ConcurrentBag<AuswahlListeDTO>> lAuswahlliste
        {
            get => _lAuswahlliste;
            set => _lAuswahlliste = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<AuswahlListeGruppeDTO>> lAuswahlListeGruppe
        {
            get => _lAuswahlListeGruppe;
            set => _lAuswahlListeGruppe = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<RessourcenDTO>> lRessourcenDTO
        {
            get => _lRessourcenDTO;
            set => _lRessourcenDTO = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<tblSelListEntriesDTO>> ltblSelListEntries
        {
            get => _ltblSelListEntries;
            set => _ltblSelListEntries = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<tblSelListGroupDTO>> ltblSelListGroup
        {
            get => _ltblSelListGroup;
            set => _ltblSelListGroup = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<LayoutDTO>> lLayout
        {
            get => _lLayout;
            set => _lLayout = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<LayoutGridsDTO>> lLayoutGrids
        {
            get => _lLayoutGrids;
            set => _lLayoutGrids = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<FormularDTO>> lFormular
        {
            get => _lFormular;
            set => _lFormular = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<tblTextTemplatesDTO>> ltblTextTemplates
        {
            get => _ltblTextTemplates;
            set => _ltblTextTemplates = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<tblTextTemplatesFilesDTO>> ltblTextTemplatesFiles
        {
            get => _ltblTextTemplatesFiles;
            set => _ltblTextTemplatesFiles = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<TextbausteineDTO>> lTextbausteine
        {
            get => _lTextbausteine;
            set => _lTextbausteine = value;
        }



        public System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<AbteilungDTO>> lAbteilung
        {
            get => _lAbteilung;
            set => _lAbteilung = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<archOrdnerDTO>> larchOrdner
        {
            get => _larchOrdner;
            set => _larchOrdner = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<BereichDTO>> lBereichDTO
        {
            get => _lBereichDTO;
            set => _lBereichDTO = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<DBLizenzDTO>> lDBLizenzDTO
        {
            get => _lDBLizenzDTO;
            set => _lDBLizenzDTO = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<DBVersionDTO>> lDBVersion
        {
            get => _lDBVersion;
            set => _lDBVersion = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<DienstzeitenDTO>> lDienstzeiten
        {
            get => _lDienstzeiten;
            set => _lDienstzeiten = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<EinrichtungDTO>> lEinrichtung
        {
            get => _lEinrichtung;
            set => _lEinrichtung = value;
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
        public ConcurrentDictionary<DateTime, ConcurrentBag<LinkDokumenteDTO>> lLinkDokumente
        {
            get => _lLinkDokumente;
            set => _lLinkDokumente = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<MassnahmenserienDTO>> lMassnahmenserien
        {
            get => _lMassnahmenserien;
            set => _lMassnahmenserien = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<StandardProzedurenDTO>> lStandardProzeduren
        {
            get => _lStandardProzeduren;
            set => _lStandardProzeduren = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<StandardzeitenDTO>> lStandardzeiten
        {
            get => _lStandardzeiten;
            set => _lStandardzeiten = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<tblAutoDokuDTO>> ltblAutoDoku
        {
            get => _ltblAutoDoku;
            set => _ltblAutoDoku = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<tblInteropDTO>> ltblInterop
        {
            get => _ltblInterop;
            set => _ltblInterop = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<tblParameterDTO>> ltblParameter
        {
            get => _ltblParameter;
            set => _ltblParameter = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<tblPfadDTO>> ltblPfad
        {
            get => _ltblPfad;
            set => _ltblPfad = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<tblProvKonfigDTO>> ltblProvKonfig
        {
            get => _ltblProvKonfig;
            set => _ltblProvKonfig = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<tblRechteOrdnerDTO>> ltblRechteOrdner
        {
            get => _ltblRechteOrdner;
            set => _ltblRechteOrdner = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<tblRedistDTO>> ltblRedis
        {
            get => _ltblRedis;
            set => _ltblRedis = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<tblUserAccountsDTO>> ltblUserAccounts
        {
            get => _ltblUserAccounts;
            set => _ltblUserAccounts = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<ZeitbereichDTO>> lZeitbereich
        {
            get => _lZeitbereich;
            set => _lZeitbereich = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<ZeitbereichSerienDTO>> lZeitbereichSerien
        {
            get => _lZeitbereichSerien;
            set => _lZeitbereichSerien = value;
        }
        public ConcurrentDictionary<DateTime, ConcurrentBag<tblQueriesDefDTO>> ltblQueriesDef
        {
            get => _ltblQueriesDef;
            set => _ltblQueriesDef = value;
        }




        [Serializable()]
        public class lastStammdaten
        {
            public List<AuswahlListeDTO> lAuswahlliste;
            public List<AuswahlListeGruppeDTO> lAuswahlListeGruppe;
            public List<RessourcenDTO> lRessourcenDTO;
            public List<tblSelListEntriesDTO> ltblSelListEntries;
            public List<tblSelListGroupDTO> ltblSelListGroup;
            public List<LayoutDTO> lLayout;
            public List<LayoutGridsDTO> lLayoutGrids;
            public List<FormularDTO> lFormular;
            public List<tblTextTemplatesDTO> ltblTextTemplates;
            public List<tblTextTemplatesFilesDTO> ltblTextTemplatesFiles;
            public List<TextbausteineDTO> lTextbausteine;
            public List<DBLizenzDTO> lDBLizenzDTO;
            public List<DBVersionDTO> lDBVersion;
            public List<DienstzeitenDTO> lDienstzeiten;
            public List<EinrichtungDTO> lEinrichtung;
            public List<GruppeDTO> lGruppe;
            public List<GruppenRechtDTO> lGruppenRecht;
            public List<LinkDokumenteDTO> lLinkDokumente;
            public List<MassnahmenserienDTO> lMassnahmenserien;
            public List<StandardProzedurenDTO> lStandardProzeduren;
            public List<StandardzeitenDTO> lStandardzeiten;
            public List<tblAutoDokuDTO> ltblAutoDoku;
            public List<tblInteropDTO> ltblInterop;
            public List<tblParameterDTO> ltblParameter;
            public List<tblPfadDTO> ltblPfad;
            public List<tblProvKonfigDTO> ltblProvKonfig;
            public List<tblRechteOrdnerDTO> ltblRechteOrdner;
            public List<tblRedistDTO> ltblRedis;
            public List<tblUserAccountsDTO> ltblUserAccounts;
            public List<ZeitbereichDTO> lZeitbereich;
            public List<ZeitbereichSerienDTO> lZeitbereichSerien;
            public List<tblQueriesDefDTO> ltblQueriesDef;
            public List<AbteilungDTO> lAbteilung;
            public List<archOrdnerDTO> larchOrdner;
            public List<BereichDTO> lBereichDTO;
        }

    }

}
