 
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

    public class tblRedistDAL : ItblRedist
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public tblRedistDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public ConcurrentBag<tblRedistDTO> getAll()
        {
            var t = _repoWrapper.TblRedist.FindAll().ToList();
            ConcurrentBag<tblRedistDTO> tDto = Mapping.MergeListData2<tblRedistDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
