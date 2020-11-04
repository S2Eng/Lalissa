 
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

    public class StandardProzedurenDAL : IStandardProzeduren
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public StandardProzedurenDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public ConcurrentBag<StandardProzedurenDTO> getAll()
        {
            var t = _repoWrapper.StandardProzeduren.FindAll().ToList();
            ConcurrentBag<StandardProzedurenDTO> tDto = Mapping.MergeListData2<StandardProzedurenDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }



    }

}
