 
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

    public class RehabilitationDAL : IRehabilitation
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public RehabilitationDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public async Task<ConcurrentBag<RehabilitationDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<Rehabilitation> t = await repoWrapper.Rehabilitation.getAllAsync();
                ConcurrentBag<RehabilitationDTO> tDto = Mapping.MergeListData2<RehabilitationDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }

        public List<RehabilitationDTO> getRehabilitationAll()
        {
            var t = _repoWrapper.Rehabilitation.FindAll().ToList();
            List<RehabilitationDTO> tDto = Mapping.MergeListData<RehabilitationDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
