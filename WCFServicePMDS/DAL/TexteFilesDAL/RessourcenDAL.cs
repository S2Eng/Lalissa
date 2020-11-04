 
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

    public class RessourcenDAL : IRessourcen
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public RessourcenDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        public async Task<ConcurrentBag<RessourcenDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<Ressourcen> t = await repoWrapper.Ressourcen.getAllAsync();
                ConcurrentBag<RessourcenDTO> tDto = Mapping.MergeListData2<RessourcenDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }


    }

}
