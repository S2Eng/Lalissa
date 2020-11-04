 
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

    public class BelegungDAL : IBelegung
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public BelegungDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public async Task<ConcurrentBag<BelegungDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<Belegung> t = await repoWrapper.Belegung.getAllAsync();
                ConcurrentBag<BelegungDTO> tDto = Mapping.MergeListData2<BelegungDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }




    }

}
