 
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

    public class tblRechteOrdnerDAL : ItblRechteOrdner
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public tblRechteOrdnerDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        public ConcurrentBag<tblRechteOrdnerDTO> getAll()
        {
            var t = _repoWrapper.TblRechteOrdner.FindAll().ToList();
            ConcurrentBag<tblRechteOrdnerDTO> tDto = Mapping.MergeListData2<tblRechteOrdnerDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
