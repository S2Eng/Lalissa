 
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

    public class tblTextTemplatesDAL : ItblTextTemplates
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public tblTextTemplatesDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public async Task<ConcurrentBag<tblTextTemplatesDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<TblTextTemplates> t = await repoWrapper.TblTextTemplates.getAllAsync();
                ConcurrentBag<tblTextTemplatesDTO> tDto = Mapping.MergeListData2<tblTextTemplatesDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }



    }

}
