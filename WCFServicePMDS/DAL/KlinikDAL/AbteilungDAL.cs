 
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

    public class AbteilungDAL : IAbteilung
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public AbteilungDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        public async Task<ConcurrentBag<AbteilungDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<Abteilung> t = await repoWrapper.Abteilung.getAllAsync();
                ConcurrentBag<AbteilungDTO> tDto = Mapping.MergeListData2<AbteilungDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }

        public ConcurrentBag<AbteilungDTO> getAll()
        {
            var t = _repoWrapper.Abteilung.FindAll().ToList();
            ConcurrentBag<AbteilungDTO> tDto = Mapping.MergeListData2<AbteilungDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

        public AbteilungDTO getAbteilungById(Guid Id)
        {
            var t = _repoWrapper.Abteilung.FindByCondition(o => o.Id == Id).ToList();
            return Mapping.MergeListData<AbteilungDTO>(t.Select(x => x as object).ToList()).First();
        }

    }

}
