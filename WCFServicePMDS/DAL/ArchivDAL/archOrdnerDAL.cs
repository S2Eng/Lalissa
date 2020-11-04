 
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

    public class archOrdnerDAL : IarchOrdner
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public archOrdnerDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public ConcurrentBag<archOrdnerDTO> getAll()
        {
            var t = _repoWrapper.archOrdner.FindAll().ToList();
            ConcurrentBag<archOrdnerDTO> tDto = Mapping.MergeListData2<archOrdnerDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
