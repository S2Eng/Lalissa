 
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

    public class LayoutDAL : ILayout
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public LayoutDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<LayoutDTO> getLayoutAll()
        {
            var t = _repoWrapper.Layout.FindAll().ToList();
            List<LayoutDTO> tDto = Mapping.MergeListData<LayoutDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }
        public async Task<ConcurrentBag<LayoutDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<Layout> t = await repoWrapper.Layout.getAllAsync();
                ConcurrentBag<LayoutDTO> tDto = Mapping.MergeListData2<LayoutDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }
    }

}
