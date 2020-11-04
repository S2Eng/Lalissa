 
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

    public class BereichDAL : IBereich
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public BereichDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        public async Task<ConcurrentBag<BereichDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<Bereich> t = await repoWrapper.Bereich.getAllAsync();
                ConcurrentBag<BereichDTO> tDto = Mapping.MergeListData2<BereichDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }

        public ConcurrentBag<BereichDTO> getAll()
        {
            var t = _repoWrapper.Bereich.FindAll().ToList();
            ConcurrentBag<BereichDTO> tDto = Mapping.MergeListData2<BereichDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
