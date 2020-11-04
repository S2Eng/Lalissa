 
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

    public class BenutzerGruppeDAL : IBenutzerGruppe
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public BenutzerGruppeDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        public async Task<ConcurrentBag<BenutzerGruppeDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<BenutzerGruppe> t = await repoWrapper.BenutzerGruppe.getAllAsync();
                ConcurrentBag<BenutzerGruppeDTO> tDto = Mapping.MergeListData2<BenutzerGruppeDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }

        public List<BenutzerGruppeDTO> getBenutzerGruppeAll()
        {
            var t = _repoWrapper.BenutzerGruppe.FindAll().ToList();
            List<BenutzerGruppeDTO> tDto = Mapping.MergeListData<BenutzerGruppeDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
