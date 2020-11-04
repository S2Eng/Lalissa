 
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

    public class GruppeDAL : IGruppe
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public GruppeDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        public async Task<ConcurrentBag<GruppeDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<Gruppe> t = await repoWrapper.Gruppe.getAllAsync();
                ConcurrentBag<GruppeDTO> tDto = Mapping.MergeListData2<GruppeDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }

        public ConcurrentBag<GruppeDTO> getAll()
        {
            var t = _repoWrapper.Gruppe.FindAll().ToList();
            ConcurrentBag<GruppeDTO> tDto = Mapping.MergeListData2<GruppeDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
