 
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

    public class tblInteropDAL : ItblInterop
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public tblInteropDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public ConcurrentBag<tblInteropDTO> getAll()
        {
            var t = _repoWrapper.TblInterop.FindAll().ToList();
            ConcurrentBag<tblInteropDTO> tDto = Mapping.MergeListData2<tblInteropDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
