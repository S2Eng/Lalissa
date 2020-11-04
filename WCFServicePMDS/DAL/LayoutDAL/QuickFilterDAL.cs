 
using System;
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

    public class QuickFilterDAL : IQuickFilter
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public QuickFilterDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<QuickFilterDTO> getQuickFilterAll()
        {
            var t = _repoWrapper.QuickFilter.FindAll().ToList();
            List<QuickFilterDTO> tDto = Mapping.MergeListData<QuickFilterDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
