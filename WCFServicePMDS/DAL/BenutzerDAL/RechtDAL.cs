 
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

    public class RechtDAL : IRecht
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public RechtDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        public async Task<ConcurrentBag<RechtDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<Recht> t = await repoWrapper.Recht.getAllAsync();
                ConcurrentBag<RechtDTO> tDto = Mapping.MergeListData2<RechtDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }

        public List<RechtDTO> getRechtAll()
        {
            var t = _repoWrapper.Recht.FindAll().ToList();
            List<RechtDTO> tDto = Mapping.MergeListData<RechtDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
