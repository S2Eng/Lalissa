 
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

    public class tblProvKonfigDAL : ItblProvKonfig
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public tblProvKonfigDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public ConcurrentBag<tblProvKonfigDTO> getAll()
        {
            var t = _repoWrapper.TblProvKonfig.FindAll().ToList();
            ConcurrentBag<tblProvKonfigDTO> tDto = Mapping.MergeListData2<tblProvKonfigDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }


    }

}
