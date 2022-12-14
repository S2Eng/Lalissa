 
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

    public class DBLizenzDAL : IDBLizenz
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public DBLizenzDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public ConcurrentBag<DBLizenzDTO> getAll()
        {
            var t = _repoWrapper.DBLizenz.FindAll().ToList();
            ConcurrentBag<DBLizenzDTO> tDto = Mapping.MergeListData2<DBLizenzDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
