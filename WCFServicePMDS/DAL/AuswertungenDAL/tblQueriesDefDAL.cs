 
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

    public class tblQueriesDefDAL : ItblQueriesDef
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public tblQueriesDefDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        public ConcurrentBag<tblQueriesDefDTO> getAll()
        {
            var t = _repoWrapper.TblQueriesDef.FindAll().ToList();
            ConcurrentBag<tblQueriesDefDTO> tDto = Mapping.MergeListData2<tblQueriesDefDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }


    }

}
