 
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL.DTO;
using WCFServicePMDS.DAL.Interfaces;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL
{

    public class AuswahlListeDAL : IAuswahlliste
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public AuswahlListeDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<AuswahlListeDTO> getAuswahlListeAll()
        {
            var t = _repoWrapper.AuswahlListe.FindAll().ToList();
            List<AuswahlListeDTO> tDto = Mapping.MergeListData<AuswahlListeDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

        public async Task<ConcurrentBag<AuswahlListeDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<AuswahlListe> t = await repoWrapper.AuswahlListe.getAllAsync();
                ConcurrentBag<AuswahlListeDTO> tDto = Mapping.MergeListData2<AuswahlListeDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }

        public AuswahlListeS1DTO AuswahlListeS1(string ElgaCode, string IdauswahlListeGruppe)
        {
            List<AuswahlListeS1DTO> tAuswahlListe = (from o in this._repoWrapper.dbcontext.AuswahlListe
                                           where o.IdauswahlListeGruppe == IdauswahlListeGruppe && o.ElgaCode == ElgaCode
                                              select new AuswahlListeS1DTO { Id = o.Id, IdauswahlListeGruppe = o.IdauswahlListeGruppe, Reihenfolge = o.Reihenfolge, Bezeichnung = o.Bezeichnung, Unterdruecken = o.Unterdruecken, ElgaId = o.ElgaId,
                                                  ElgaCode = o.ElgaCode, ElgaCodeSystem = o.ElgaCodeSystem, ElgaDisplayName = o.ElgaDisplayName
                                              }).ToList();
            return tAuswahlListe.FirstOrDefault(); ;
        }
        public AuswahlListeDTO AuswahlListeBez(string IDAuswahlListeGruppe, string Bezeichnung, bool doExeptIfNotExits = true)
        {
            List<AuswahlListe> t = (from o in this._repoWrapper.dbcontext.AuswahlListe
                                                     where o.IdauswahlListeGruppe == IDAuswahlListeGruppe && o.Bezeichnung == Bezeichnung.Trim()
                                                     select o).ToList();

            if (t.Count() == 1)
            {
                ConcurrentBag<AuswahlListeDTO> tDto = Mapping.MergeListData2<AuswahlListeDTO>(t.Select(x => x as object).ToList());
                var r = tDto.First();
                return r;
            }
            else
            {
                if (doExeptIfNotExits)
                    throw new Exception("AuswahlListeDAL.AuswahlListeBez: AuswahlListe not found for IDAuswahlListeGruppe='" + IDAuswahlListeGruppe.ToString() + "' and Bezeichnung='" + Bezeichnung.Trim() + "'!");
                else
                    return null;
            }
        }
        public AuswahlListeDTO auswahllisteBezOrEmpty(string IDAuswahlListeGruppe, string Bezeichnung, bool doExeptIfNotExits = true)
        {
            List<AuswahlListe> t = (from o in this._repoWrapper.dbcontext.AuswahlListe
                                    where o.IdauswahlListeGruppe == IDAuswahlListeGruppe && o.Bezeichnung == Bezeichnung.Trim()
                                    select o).ToList();

            if (t.Count() == 1)
            {
                ConcurrentBag<AuswahlListeDTO> tDto = Mapping.MergeListData2<AuswahlListeDTO>(t.Select(x => x as object).ToList());
                var r = tDto.First();
                return r;
            }
            else
            {
                if (doExeptIfNotExits)
                    throw new Exception("AuswahlListeDAL.AuswahlListeBez: AuswahlListe not found for IDAuswahlListeGruppe='" + IDAuswahlListeGruppe.ToString() + "' and Bezeichnung='" + Bezeichnung.Trim() + "'!");
                else
                    return null;
            }
        }
        public AuswahlListeDTO auswahlliste(string IDAuswahlListeGruppe, Guid Id)
        {
            List<AuswahlListe> t = (from o in this._repoWrapper.dbcontext.AuswahlListe
                                    where o.IdauswahlListeGruppe == IDAuswahlListeGruppe && o.Id == Id
                                    select o).ToList();

            List<AuswahlListeDTO> tDto = Mapping.MergeListData<AuswahlListeDTO>(t.Select(x => x as object).ToList());
            return tDto.First();
        }
        public AuswahlListeDTO auswahlliste2(string IDAuswahlListeGruppe, string ELGA_Code, string ELGA_CodeSystem)
        {
            List<AuswahlListe> t = (from o in this._repoWrapper.dbcontext.AuswahlListe
                                    where o.IdauswahlListeGruppe == IDAuswahlListeGruppe && o.ElgaCode == ELGA_Code && o.ElgaCodeSystem == ELGA_CodeSystem
                                    select o).ToList();

            List<AuswahlListeDTO> tDto = Mapping.MergeListData<AuswahlListeDTO>(t.Select(x => x as object).ToList());
            return tDto.First();
        }

    }

}
