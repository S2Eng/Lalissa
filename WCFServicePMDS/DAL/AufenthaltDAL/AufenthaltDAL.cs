 
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

    public class AufenthaltDAL : IAufenthalt
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;



        public async Task<ConcurrentBag<AufenthaltDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<Aufenthalt> t = await repoWrapper.Aufenthalt.getWhereAsync(o => o.Entlassungszeitpunkt == null);
                ConcurrentBag<AufenthaltDTO> tDto = Mapping.MergeListData2<AufenthaltDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }

        public AufenthaltDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public List<AufenthaltDTO> getAufenthaltAll()
        {
            var t = _repoWrapper.Aufenthalt.FindAll().ToList();
            List<AufenthaltDTO> tDto = Mapping.MergeListData<AufenthaltDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }
        public AufenthaltDTO getAufenthalt(Guid Id)
        {
            var t = _repoWrapper.Aufenthalt.FindByCondition(o => o.Id == Id).ToList();
            return Mapping.MergeListData<AufenthaltDTO>(t.Select(x => x as object).ToList()).First();
        }
    }

}
