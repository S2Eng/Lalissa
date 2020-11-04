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
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

namespace WCFServicePMDS.BAL.Main
{

    public class StammdatenBAL : IStammdatenBAL
    {

        private static StammdatenDTO stLast;



        public StammdatenBAL()
        {

        }

        public StammdatenDTO newInstanz()
        {
            StammdatenDTO st = new StammdatenDTO();

            st.lAbteilung = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<AbteilungDTO>>();
            st.lAuswahlliste = new System.Collections.Concurrent.ConcurrentDictionary< DateTime, ConcurrentBag<AuswahlListeDTO>>();
            st.lAuswahlListeGruppe = new System.Collections.Concurrent.ConcurrentDictionary< DateTime, ConcurrentBag<AuswahlListeGruppeDTO>>();
            st.lRessourcenDTO = new System.Collections.Concurrent.ConcurrentDictionary< DateTime, ConcurrentBag<RessourcenDTO>>();
            st.ltblSelListEntries = new System.Collections.Concurrent.ConcurrentDictionary< DateTime, ConcurrentBag<tblSelListEntriesDTO>>();
            st.ltblSelListGroup = new System.Collections.Concurrent.ConcurrentDictionary< DateTime, ConcurrentBag<tblSelListGroupDTO>>();
            st.lLayout = new System.Collections.Concurrent.ConcurrentDictionary< DateTime, ConcurrentBag<LayoutDTO>>();
            st.lLayoutGrids = new System.Collections.Concurrent.ConcurrentDictionary< DateTime, ConcurrentBag<LayoutGridsDTO>>();
            st.lFormular = new System.Collections.Concurrent.ConcurrentDictionary< DateTime, ConcurrentBag<FormularDTO>>();
            st.ltblTextTemplates = new System.Collections.Concurrent.ConcurrentDictionary< DateTime, ConcurrentBag<tblTextTemplatesDTO>>();
            st.ltblTextTemplatesFiles = new System.Collections.Concurrent.ConcurrentDictionary< DateTime, ConcurrentBag<tblTextTemplatesFilesDTO>>();
            st.lTextbausteine = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<TextbausteineDTO>>();
            st.lAbteilung = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<AbteilungDTO>>();
            st.larchOrdner = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<archOrdnerDTO>>();
            st.lBereichDTO = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<BereichDTO>>();
            st.lDBLizenzDTO = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<DBLizenzDTO>>();
            st.lDBVersion = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<DBVersionDTO>>();
            st.lDienstzeiten = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<DienstzeitenDTO>>();
            st.lEinrichtung = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<EinrichtungDTO>>();
            st.lGruppe = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<GruppeDTO>>();
            st.lGruppenRecht = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<GruppenRechtDTO>>();
            st.lLinkDokumente = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<LinkDokumenteDTO>>();
            st.lMassnahmenserien = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<MassnahmenserienDTO>>();
            st.lStandardProzeduren = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<StandardProzedurenDTO>>();
            st.lStandardzeiten = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<StandardzeitenDTO>>();
            st.ltblAutoDoku = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<tblAutoDokuDTO>>();
            st.ltblInterop = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<tblInteropDTO>>();
            st.ltblParameter = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<tblParameterDTO>>();
            st.ltblPfad = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<tblPfadDTO>>();
            st.ltblProvKonfig = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<tblProvKonfigDTO>>();
            st.ltblRechteOrdner = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<tblRechteOrdnerDTO>>();
            st.ltblRedis = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<tblRedistDTO>>();
            st.ltblUserAccounts = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<tblUserAccountsDTO>>();
            st.lZeitbereich = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<ZeitbereichDTO>>();
            st.lZeitbereichSerien = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<ZeitbereichSerienDTO>>();
            st.ltblQueriesDef = new System.Collections.Concurrent.ConcurrentDictionary<DateTime, ConcurrentBag<tblQueriesDefDTO>>();

            return st;
        }

        public StammdatenDTO load(ref DateTime dFrom, Guid IDClient)
        {
            Task t = new StammdatenBAL().loadAll(dFrom, IDClient);
            t.Wait();
            return StammdatenDTO.Stammdaten;
        }
        public async Task loadAll(DateTime dFrom, Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                if (StammdatenDTO.Stammdaten == null) StammdatenDTO.Stammdaten = newInstanz();

                Task<ConcurrentBag<AuswahlListeDTO>> taAuswahlliste = new AuswahlListeDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<AuswahlListeGruppeDTO>> taAuswahllisteGrp = new AuswahlListeGruppeDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<RessourcenDTO>> taRessourcen = new RessourcenDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<tblSelListEntriesDTO>> tatblSelListEntries = new tblSelListEntriesDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<tblSelListGroupDTO>> tatblSelListGroup = new tblSelListGroupDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<LayoutDTO>> taLayout = new LayoutDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<LayoutGridsDTO>> taLayoutGrids = new LayoutGridsDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<FormularDTO>> taFormular = new FormularDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<tblTextTemplatesDTO>> tatblTextTemplates = new tblTextTemplatesDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<tblTextTemplatesFilesDTO>> tatblTextTemplatesFiles = new tblTextTemplatesFilesDAL(repoWrapper).getAllAsync(IDClient);
                Task<ConcurrentBag<TextbausteineDTO>> taTextbausteine = new TextbausteineDAL(repoWrapper).getAllAsync(IDClient);

                IAbteilung dtoAbteilung = new AbteilungDAL(repoWrapper);
                StammdatenDTO.Stammdaten.lAbteilung.TryAdd(dFrom, dtoAbteilung.getAll());

                IarchOrdner dtoarchOrdner = new archOrdnerDAL(repoWrapper);
                StammdatenDTO.Stammdaten.larchOrdner.TryAdd(dFrom, dtoarchOrdner.getAll());

                IBereich dtoBereich = new BereichDAL(repoWrapper);
                StammdatenDTO.Stammdaten.lBereichDTO.TryAdd(dFrom, dtoBereich.getAll());

                IDBLizenz dtoDBLizenz = new DBLizenzDAL(repoWrapper);
                StammdatenDTO.Stammdaten.lDBLizenzDTO.TryAdd(dFrom, dtoDBLizenz.getAll());

                IDBVersion dtoDBVersion = new DBVersionDAL(repoWrapper);
                StammdatenDTO.Stammdaten.lDBVersion.TryAdd(dFrom, dtoDBVersion.getAll());

                IDienstzeiten dtoDienstzeiten = new DienstzeitenDAL(repoWrapper);
                StammdatenDTO.Stammdaten.lDienstzeiten.TryAdd(dFrom, dtoDienstzeiten.getAll());

                IEinrichtung dtoEinrichtung = new EinrichtungDAL(repoWrapper);
                StammdatenDTO.Stammdaten.lEinrichtung.TryAdd(dFrom, dtoEinrichtung.getAll());

                IGruppe dtoGruppe = new GruppeDAL(repoWrapper);
                StammdatenDTO.Stammdaten.lGruppe.TryAdd(dFrom, dtoGruppe.getAll());

                IGruppenRecht dtoGruppenRecht = new GruppenRechtDAL(repoWrapper);
                StammdatenDTO.Stammdaten.lGruppenRecht.TryAdd(dFrom, dtoGruppenRecht.getAll());

                ILinkDokumente dtoLinkDokumente = new LinkDokumenteDAL(repoWrapper);
                StammdatenDTO.Stammdaten.lLinkDokumente.TryAdd(dFrom, dtoLinkDokumente.getAll());

                IMassnahmenserien dtoMassnahmenserien = new MassnahmenserienDAL(repoWrapper);
                StammdatenDTO.Stammdaten.lMassnahmenserien.TryAdd(dFrom, dtoMassnahmenserien.getAll());

                IStandardProzeduren dtoStandardProzeduren = new StandardProzedurenDAL(repoWrapper);
                StammdatenDTO.Stammdaten.lStandardProzeduren.TryAdd(dFrom, dtoStandardProzeduren.getAll());

                IStandardzeiten dtoStandardzeiten = new StandardzeitenDAL(repoWrapper);
                StammdatenDTO.Stammdaten.lStandardzeiten.TryAdd(dFrom, dtoStandardzeiten.getAll());

                ItblAutoDoku dtotblAutoDoku = new tblAutoDokuDAL(repoWrapper);
                StammdatenDTO.Stammdaten.ltblAutoDoku.TryAdd(dFrom, dtotblAutoDoku.getAll());

                ItblInterop dtotblInterop = new tblInteropDAL(repoWrapper);
                StammdatenDTO.Stammdaten.ltblInterop.TryAdd(dFrom, dtotblInterop.getAll());

                ItblParameter dtotblParameter = new tblParameterDAL(repoWrapper);
                StammdatenDTO.Stammdaten.ltblParameter.TryAdd(dFrom, dtotblParameter.getAll());

                ItblPfad dtotblPfad = new ItblPfadDAL(repoWrapper);
                StammdatenDTO.Stammdaten.ltblPfad.TryAdd(dFrom, dtotblPfad.getAll());

                ItblProvKonfig dtotblProvKonfig = new tblProvKonfigDAL(repoWrapper);
                StammdatenDTO.Stammdaten.ltblProvKonfig.TryAdd(dFrom, dtotblProvKonfig.getAll());

                ItblRechteOrdner dtblRechteOrdner = new tblRechteOrdnerDAL(repoWrapper);
                StammdatenDTO.Stammdaten.ltblRechteOrdner.TryAdd(dFrom, dtblRechteOrdner.getAll());

                ItblRedist dtotblRedist = new tblRedistDAL(repoWrapper);
                StammdatenDTO.Stammdaten.ltblRedis.TryAdd(dFrom, dtotblRedist.getAll());

                //ITblSchlagwörter dtotblSchlagwörter = new ITblSchlagwörter(repoWrapper);
                //ltblRedist = dtotblSchlagwörter.getAll();

                //ITblSchrank dtotblSchrank = new ITblSchrank(repoWrapper);
                //ltblRedist = dtotblRedist.getAll();

                ItblUserAccounts dtotblUserAccounts = new tblUserAccountsDAL(repoWrapper);
                StammdatenDTO.Stammdaten.ltblUserAccounts.TryAdd(dFrom, dtotblUserAccounts.getAll());

                IZeitbereich dtoZeitbereich = new ZeitbereichDAL(repoWrapper);
                StammdatenDTO.Stammdaten.lZeitbereich.TryAdd(dFrom, dtoZeitbereich.getAll());

                IZeitbereichSerien dtoZeitbereichSerien = new ZeitbereichSerienDAL(repoWrapper);
                StammdatenDTO.Stammdaten.lZeitbereichSerien.TryAdd(dFrom, dtoZeitbereichSerien.getAll());

                ItblQueriesDef dtotblQueriesDef = new tblQueriesDefDAL(repoWrapper);
                StammdatenDTO.Stammdaten.ltblQueriesDef.TryAdd(dFrom, dtotblQueriesDef.getAll());


                Task.WaitAll(taAuswahlliste, taAuswahllisteGrp, taFormular, tatblTextTemplates, tatblTextTemplatesFiles, taTextbausteine, taLayout, taLayoutGrids, taRessourcen, tatblSelListEntries, tatblSelListGroup);


                StammdatenDTO.Stammdaten.lAuswahlliste.TryAdd(dFrom, taAuswahlliste.Result);
                StammdatenDTO.Stammdaten.lAuswahlListeGruppe.TryAdd(dFrom, taAuswahllisteGrp.Result);
                StammdatenDTO.Stammdaten.lRessourcenDTO.TryAdd(dFrom, taRessourcen.Result);
                StammdatenDTO.Stammdaten.ltblSelListEntries.TryAdd(dFrom, tatblSelListEntries.Result);
                StammdatenDTO.Stammdaten.ltblSelListGroup.TryAdd(dFrom, tatblSelListGroup.Result);
                StammdatenDTO.Stammdaten.lLayout.TryAdd(dFrom, taLayout.Result);
                StammdatenDTO.Stammdaten.lLayoutGrids.TryAdd(dFrom, taLayoutGrids.Result);
                StammdatenDTO.Stammdaten.lFormular.TryAdd(dFrom, taFormular.Result);
                StammdatenDTO.Stammdaten.ltblTextTemplates.TryAdd(dFrom, tatblTextTemplates.Result);
                StammdatenDTO.Stammdaten.ltblTextTemplatesFiles.TryAdd(dFrom, tatblTextTemplatesFiles.Result);
                StammdatenDTO.Stammdaten.lTextbausteine.TryAdd(dFrom, taTextbausteine.Result);

            }
        }


        public StammdatenDTO getLastStammdaten()
        {
            Task<StammdatenDTO> t = new StammdatenBAL().loadLastStammdaten();
            t.Wait();
            return t.Result;
        }
        public async Task<StammdatenDTO> loadLastStammdaten()
        {
            if (stLast != null)
            {
                DateTime lastDateTime = Lists.getFirstFromDictKey<AbteilungDTO>(stLast.lAbteilung);
                DateTime dDateTime = Lists.getFirstFromDictKey<AbteilungDTO>(StammdatenDTO.Stammdaten.lAbteilung);
                if (dDateTime <= lastDateTime)
                {
                    return stLast;
                }
            }

            StammdatenDTO st = newInstanz();
            st.lAbteilung.TryAdd(Lists.getFirstFromDictKey<AbteilungDTO>(StammdatenDTO.Stammdaten.lAbteilung), Lists.getFirstFromDictConcBag<AbteilungDTO>(StammdatenDTO.Stammdaten.lAbteilung));
            st.lAuswahlliste.TryAdd(Lists.getFirstFromDictKey<AuswahlListeDTO>(StammdatenDTO.Stammdaten.lAuswahlliste), Lists.getFirstFromDictConcBag<AuswahlListeDTO>(StammdatenDTO.Stammdaten.lAuswahlliste));
            st.lAuswahlListeGruppe.TryAdd(Lists.getFirstFromDictKey<AuswahlListeGruppeDTO>(StammdatenDTO.Stammdaten.lAuswahlListeGruppe), Lists.getFirstFromDictConcBag<AuswahlListeGruppeDTO>(StammdatenDTO.Stammdaten.lAuswahlListeGruppe));
            st.lRessourcenDTO.TryAdd(Lists.getFirstFromDictKey<RessourcenDTO>(StammdatenDTO.Stammdaten.lRessourcenDTO), Lists.getFirstFromDictConcBag<RessourcenDTO>(StammdatenDTO.Stammdaten.lRessourcenDTO));
            st.ltblSelListEntries.TryAdd(Lists.getFirstFromDictKey<tblSelListEntriesDTO>(StammdatenDTO.Stammdaten.ltblSelListEntries), Lists.getFirstFromDictConcBag<tblSelListEntriesDTO>(StammdatenDTO.Stammdaten.ltblSelListEntries));
            st.ltblSelListGroup.TryAdd(Lists.getFirstFromDictKey<tblSelListGroupDTO>(StammdatenDTO.Stammdaten.ltblSelListGroup), Lists.getFirstFromDictConcBag<tblSelListGroupDTO>(StammdatenDTO.Stammdaten.ltblSelListGroup));
            st.lLayoutGrids.TryAdd(Lists.getFirstFromDictKey<LayoutGridsDTO>(StammdatenDTO.Stammdaten.lLayoutGrids), Lists.getFirstFromDictConcBag<LayoutGridsDTO>(StammdatenDTO.Stammdaten.lLayoutGrids));
            st.lFormular.TryAdd(Lists.getFirstFromDictKey<FormularDTO>(StammdatenDTO.Stammdaten.lFormular), Lists.getFirstFromDictConcBag<FormularDTO>(StammdatenDTO.Stammdaten.lFormular));
            st.ltblTextTemplates.TryAdd(Lists.getFirstFromDictKey<tblTextTemplatesDTO>(StammdatenDTO.Stammdaten.ltblTextTemplates), Lists.getFirstFromDictConcBag<tblTextTemplatesDTO>(StammdatenDTO.Stammdaten.ltblTextTemplates));
            st.ltblTextTemplatesFiles.TryAdd(Lists.getFirstFromDictKey<tblTextTemplatesFilesDTO>(StammdatenDTO.Stammdaten.ltblTextTemplatesFiles), Lists.getFirstFromDictConcBag<tblTextTemplatesFilesDTO>(StammdatenDTO.Stammdaten.ltblTextTemplatesFiles));
            st.lTextbausteine.TryAdd(Lists.getFirstFromDictKey<TextbausteineDTO>(StammdatenDTO.Stammdaten.lTextbausteine), Lists.getFirstFromDictConcBag<TextbausteineDTO>(StammdatenDTO.Stammdaten.lTextbausteine));
            st.larchOrdner.TryAdd(Lists.getFirstFromDictKey<archOrdnerDTO>(StammdatenDTO.Stammdaten.larchOrdner), Lists.getFirstFromDictConcBag<archOrdnerDTO>(StammdatenDTO.Stammdaten.larchOrdner));
            st.lBereichDTO.TryAdd(Lists.getFirstFromDictKey<BereichDTO>(StammdatenDTO.Stammdaten.lBereichDTO), Lists.getFirstFromDictConcBag<BereichDTO>(StammdatenDTO.Stammdaten.lBereichDTO));
            st.lDBLizenzDTO.TryAdd(Lists.getFirstFromDictKey<DBLizenzDTO>(StammdatenDTO.Stammdaten.lDBLizenzDTO), Lists.getFirstFromDictConcBag<DBLizenzDTO>(StammdatenDTO.Stammdaten.lDBLizenzDTO));
            st.lDBVersion.TryAdd(Lists.getFirstFromDictKey<DBVersionDTO>(StammdatenDTO.Stammdaten.lDBVersion), Lists.getFirstFromDictConcBag<DBVersionDTO>(StammdatenDTO.Stammdaten.lDBVersion));
            st.lDienstzeiten.TryAdd(Lists.getFirstFromDictKey<DienstzeitenDTO>(StammdatenDTO.Stammdaten.lDienstzeiten), Lists.getFirstFromDictConcBag<DienstzeitenDTO>(StammdatenDTO.Stammdaten.lDienstzeiten));
            st.lEinrichtung.TryAdd(Lists.getFirstFromDictKey<EinrichtungDTO>(StammdatenDTO.Stammdaten.lEinrichtung), Lists.getFirstFromDictConcBag<EinrichtungDTO>(StammdatenDTO.Stammdaten.lEinrichtung));
            st.lGruppe.TryAdd(Lists.getFirstFromDictKey<GruppeDTO>(StammdatenDTO.Stammdaten.lGruppe), Lists.getFirstFromDictConcBag<GruppeDTO>(StammdatenDTO.Stammdaten.lGruppe));
            st.lGruppenRecht.TryAdd(Lists.getFirstFromDictKey<GruppenRechtDTO>(StammdatenDTO.Stammdaten.lGruppenRecht), Lists.getFirstFromDictConcBag<GruppenRechtDTO>(StammdatenDTO.Stammdaten.lGruppenRecht));
            st.lLinkDokumente.TryAdd(Lists.getFirstFromDictKey<LinkDokumenteDTO>(StammdatenDTO.Stammdaten.lLinkDokumente), Lists.getFirstFromDictConcBag<LinkDokumenteDTO>(StammdatenDTO.Stammdaten.lLinkDokumente));
            st.lMassnahmenserien.TryAdd(Lists.getFirstFromDictKey<MassnahmenserienDTO>(StammdatenDTO.Stammdaten.lMassnahmenserien), Lists.getFirstFromDictConcBag<MassnahmenserienDTO>(StammdatenDTO.Stammdaten.lMassnahmenserien));
            st.lStandardProzeduren.TryAdd(Lists.getFirstFromDictKey<StandardProzedurenDTO>(StammdatenDTO.Stammdaten.lStandardProzeduren), Lists.getFirstFromDictConcBag<StandardProzedurenDTO>(StammdatenDTO.Stammdaten.lStandardProzeduren));
            st.lStandardzeiten.TryAdd(Lists.getFirstFromDictKey<StandardzeitenDTO>(StammdatenDTO.Stammdaten.lStandardzeiten), Lists.getFirstFromDictConcBag<StandardzeitenDTO>(StammdatenDTO.Stammdaten.lStandardzeiten));
            st.ltblAutoDoku.TryAdd(Lists.getFirstFromDictKey<tblAutoDokuDTO>(StammdatenDTO.Stammdaten.ltblAutoDoku), Lists.getFirstFromDictConcBag<tblAutoDokuDTO>(StammdatenDTO.Stammdaten.ltblAutoDoku));
            st.ltblInterop.TryAdd(Lists.getFirstFromDictKey<tblInteropDTO>(StammdatenDTO.Stammdaten.ltblInterop), Lists.getFirstFromDictConcBag<tblInteropDTO>(StammdatenDTO.Stammdaten.ltblInterop));
            st.ltblParameter.TryAdd(Lists.getFirstFromDictKey<tblParameterDTO>(StammdatenDTO.Stammdaten.ltblParameter), Lists.getFirstFromDictConcBag<tblParameterDTO>(StammdatenDTO.Stammdaten.ltblParameter));
            st.ltblPfad.TryAdd(Lists.getFirstFromDictKey<tblPfadDTO>(StammdatenDTO.Stammdaten.ltblPfad), Lists.getFirstFromDictConcBag<tblPfadDTO>(StammdatenDTO.Stammdaten.ltblPfad));
            st.ltblProvKonfig.TryAdd(Lists.getFirstFromDictKey<tblProvKonfigDTO>(StammdatenDTO.Stammdaten.ltblProvKonfig), Lists.getFirstFromDictConcBag<tblProvKonfigDTO>(StammdatenDTO.Stammdaten.ltblProvKonfig));
            st.ltblRechteOrdner.TryAdd(Lists.getFirstFromDictKey<tblRechteOrdnerDTO>(StammdatenDTO.Stammdaten.ltblRechteOrdner), Lists.getFirstFromDictConcBag<tblRechteOrdnerDTO>(StammdatenDTO.Stammdaten.ltblRechteOrdner));
            st.ltblRedis.TryAdd(Lists.getFirstFromDictKey<tblRedistDTO>(StammdatenDTO.Stammdaten.ltblRedis), Lists.getFirstFromDictConcBag<tblRedistDTO>(StammdatenDTO.Stammdaten.ltblRedis));
            st.ltblUserAccounts.TryAdd(Lists.getFirstFromDictKey<tblUserAccountsDTO>(StammdatenDTO.Stammdaten.ltblUserAccounts), Lists.getFirstFromDictConcBag<tblUserAccountsDTO>(StammdatenDTO.Stammdaten.ltblUserAccounts));
            st.lZeitbereich.TryAdd(Lists.getFirstFromDictKey<ZeitbereichDTO>(StammdatenDTO.Stammdaten.lZeitbereich), Lists.getFirstFromDictConcBag<ZeitbereichDTO>(StammdatenDTO.Stammdaten.lZeitbereich));
            st.lZeitbereichSerien.TryAdd(Lists.getFirstFromDictKey<ZeitbereichSerienDTO>(StammdatenDTO.Stammdaten.lZeitbereichSerien), Lists.getFirstFromDictConcBag<ZeitbereichSerienDTO>(StammdatenDTO.Stammdaten.lZeitbereichSerien));
            st.ltblQueriesDef.TryAdd(Lists.getFirstFromDictKey<tblQueriesDefDTO>(StammdatenDTO.Stammdaten.ltblQueriesDef), Lists.getFirstFromDictConcBag<tblQueriesDefDTO>(StammdatenDTO.Stammdaten.ltblQueriesDef));

            StammdatenDTO.lastStammdaten lSD = new StammdatenDTO.lastStammdaten();
            lSD.lAbteilung = Lists.getFirstFromDictConcBag<AbteilungDTO>(st.lAbteilung).ToList();
            lSD.lAuswahlliste = Lists.getFirstFromDictConcBag<AuswahlListeDTO>(st.lAuswahlliste).ToList();
            lSD.lAuswahlListeGruppe = Lists.getFirstFromDictConcBag<AuswahlListeGruppeDTO>(st.lAuswahlListeGruppe).ToList();
            lSD.lRessourcenDTO = Lists.getFirstFromDictConcBag<RessourcenDTO>(st.lRessourcenDTO).ToList();
            lSD.ltblSelListEntries = Lists.getFirstFromDictConcBag<tblSelListEntriesDTO>(st.ltblSelListEntries).ToList();
            lSD.ltblSelListGroup = Lists.getFirstFromDictConcBag<tblSelListGroupDTO>(st.ltblSelListGroup).ToList();
            lSD.lLayoutGrids = Lists.getFirstFromDictConcBag<LayoutGridsDTO>(st.lLayoutGrids).ToList();
            lSD.lFormular = Lists.getFirstFromDictConcBag<FormularDTO>(st.lFormular).ToList();
            lSD.ltblTextTemplates = Lists.getFirstFromDictConcBag<tblTextTemplatesDTO>(st.ltblTextTemplates).ToList();
            lSD.ltblTextTemplatesFiles = Lists.getFirstFromDictConcBag<tblTextTemplatesFilesDTO>(st.ltblTextTemplatesFiles).ToList();
            lSD.lTextbausteine = Lists.getFirstFromDictConcBag<TextbausteineDTO>(st.lTextbausteine).ToList();
            lSD.larchOrdner = Lists.getFirstFromDictConcBag<archOrdnerDTO>(st.larchOrdner).ToList();
            lSD.lBereichDTO = Lists.getFirstFromDictConcBag<BereichDTO>(st.lBereichDTO).ToList();
            lSD.lDBLizenzDTO = Lists.getFirstFromDictConcBag<DBLizenzDTO>(st.lDBLizenzDTO).ToList();
            lSD.lDBVersion = Lists.getFirstFromDictConcBag<DBVersionDTO>(st.lDBVersion).ToList();
            lSD.lDienstzeiten = Lists.getFirstFromDictConcBag<DienstzeitenDTO>(st.lDienstzeiten).ToList();
            lSD.lEinrichtung = Lists.getFirstFromDictConcBag<EinrichtungDTO>(st.lEinrichtung).ToList();
            lSD.lGruppe = Lists.getFirstFromDictConcBag<GruppeDTO>(st.lGruppe).ToList();
            lSD.lGruppenRecht = Lists.getFirstFromDictConcBag<GruppenRechtDTO>(st.lGruppenRecht).ToList();
            lSD.lLinkDokumente = Lists.getFirstFromDictConcBag<LinkDokumenteDTO>(st.lLinkDokumente).ToList();
            lSD.lMassnahmenserien = Lists.getFirstFromDictConcBag<MassnahmenserienDTO>(st.lMassnahmenserien).ToList();
            lSD.lStandardProzeduren = Lists.getFirstFromDictConcBag<StandardProzedurenDTO>(st.lStandardProzeduren).ToList();
            lSD.lStandardzeiten = Lists.getFirstFromDictConcBag<StandardzeitenDTO>(st.lStandardzeiten).ToList();
            lSD.ltblAutoDoku = Lists.getFirstFromDictConcBag<tblAutoDokuDTO>(st.ltblAutoDoku).ToList();
            lSD.ltblInterop = Lists.getFirstFromDictConcBag<tblInteropDTO>(st.ltblInterop).ToList();
            lSD.ltblParameter = Lists.getFirstFromDictConcBag<tblParameterDTO>(st.ltblParameter).ToList();
            lSD.ltblPfad = Lists.getFirstFromDictConcBag<tblPfadDTO>(st.ltblPfad).ToList();
            lSD.ltblProvKonfig = Lists.getFirstFromDictConcBag<tblProvKonfigDTO>(st.ltblProvKonfig).ToList();
            lSD.ltblRechteOrdner = Lists.getFirstFromDictConcBag<tblRechteOrdnerDTO>(st.ltblRechteOrdner).ToList();
            lSD.ltblRedis = Lists.getFirstFromDictConcBag<tblRedistDTO>(st.ltblRedis).ToList();
            lSD.ltblUserAccounts = Lists.getFirstFromDictConcBag<tblUserAccountsDTO>(st.ltblUserAccounts).ToList();
            lSD.lZeitbereich = Lists.getFirstFromDictConcBag<ZeitbereichDTO>(st.lZeitbereich).ToList();
            lSD.lZeitbereichSerien = Lists.getFirstFromDictConcBag<ZeitbereichSerienDTO>(st.lZeitbereichSerien).ToList();
            lSD.ltblQueriesDef = Lists.getFirstFromDictConcBag<tblQueriesDefDTO>(st.ltblQueriesDef).ToList();

            stLast = st;

            //StammdatenDTO.lastSDSer = WCFServicePMDS.Repository.serialize.Serialize<StammdatenDTO.lastStammdaten>(lSD);
            //StammdatenDTO.lastStammdaten sdDes = WCFServicePMDS.Repository.serialize.Deserialize<StammdatenDTO.lastStammdaten>(StammdatenDTO.lastSDSer);
            //int iSize = System.Text.ASCIIEncoding.Unicode.GetByteCount(StammdatenDTO.lastSDSer);

            StammdatenDTO.lastSDSerB = WCFServicePMDS.Repository.serialize.BinarySerialize<StammdatenDTO.lastStammdaten>(lSD);
            StammdatenDTO.lastStammdaten sdDes2 = (StammdatenDTO.lastStammdaten)WCFServicePMDS.Repository.serialize.BinaryDeserialize(StammdatenDTO.lastSDSerB);
            return st;



            //StammdatenDTO.lastSDSer = jsonWriteFromObject(lSD);
            //StammdatenDTO.lastStammdaten sdDes = jsonReadToObject(StammdatenDTO.lastSDSer);

            //MemoryStream stream1 = new MemoryStream();
            //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(StammdatenDTO.lastStammdaten));
            //ser.WriteObject(stream1, lSD);

            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //Response responseObject = serializer.Deserialize<Response>(jsonString);

            //stream1.Position = 0;
            //StreamReader sr = new StreamReader(stream1);
            //Console.Write("JSON form of Person object: ");
            //Console.WriteLine(sr.ReadToEnd());
        }


        public string jsonWriteFromObject(StammdatenDTO.lastStammdaten sd)
        {
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(StammdatenDTO.lastStammdaten));
            ser.WriteObject(ms, sd);
            byte[] json = ms.ToArray();
            ms.Close();
            string desStr = Encoding.UTF8.GetString(json, 0, json.Length);
            return desStr;
        }
        public StammdatenDTO.lastStammdaten jsonReadToObject(string json)
        {
            StammdatenDTO.lastStammdaten deserializedUser = new StammdatenDTO.lastStammdaten();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedUser.GetType());
            deserializedUser = ser.ReadObject(ms) as StammdatenDTO.lastStammdaten;
            ms.Close();
            return deserializedUser;
        }



    }

}
