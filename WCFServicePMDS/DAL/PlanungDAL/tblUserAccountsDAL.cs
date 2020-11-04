 
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

    public class tblUserAccountsDAL : ItblUserAccounts
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public tblUserAccountsDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        public ConcurrentBag<tblUserAccountsDTO> getAll()
        {
            var t = _repoWrapper.TblUserAccounts.FindAll().ToList();
            ConcurrentBag<tblUserAccountsDTO> tDto = Mapping.MergeListData2<tblUserAccountsDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }
    }

}
