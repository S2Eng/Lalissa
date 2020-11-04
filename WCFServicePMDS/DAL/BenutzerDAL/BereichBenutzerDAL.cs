 
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

    public class BereichBenutzerDAL : IBereichBenutzer
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public BereichBenutzerDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        public async Task<ConcurrentBag<BereichBenutzerDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<BereichBenutzer> t = await repoWrapper.BereichBenutzer.getAllAsync();
                ConcurrentBag<BereichBenutzerDTO> tDto = Mapping.MergeListData2<BereichBenutzerDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }

        public List<BereichBenutzerDTO> getBereichBenutzerAll()
        {
            var t = _repoWrapper.BereichBenutzer.FindAll().ToList();
            List<BereichBenutzerDTO> tDto = Mapping.MergeListData<BereichBenutzerDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
