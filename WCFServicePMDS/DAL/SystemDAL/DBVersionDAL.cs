 
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

    public class DBVersionDAL : IDBVersion
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public DBVersionDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public ConcurrentBag<DBVersionDTO> getAll()
        {
            var t = _repoWrapper.DBVersion.FindAll().ToList();
            ConcurrentBag<DBVersionDTO> tDto = Mapping.MergeListData2<DBVersionDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
