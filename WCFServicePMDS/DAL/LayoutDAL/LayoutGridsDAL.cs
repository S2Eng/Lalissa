 
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

    public class LayoutGridsDAL : ILayoutGrids
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public LayoutGridsDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<LayoutGridsDTO> getLayoutGridsAll()
        {
            var t = _repoWrapper.LayoutGrids.FindAll().ToList();
            List<LayoutGridsDTO> tDto = Mapping.MergeListData<LayoutGridsDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }
        public async Task<ConcurrentBag<LayoutGridsDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<LayoutGrids> t = await repoWrapper.LayoutGrids.getAllAsync();
                ConcurrentBag<LayoutGridsDTO> tDto = Mapping.MergeListData2<LayoutGridsDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }
    }

}
