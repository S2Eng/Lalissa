 
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

    public class tblAutoDokuDAL : ItblAutoDoku
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public tblAutoDokuDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public ConcurrentBag<tblAutoDokuDTO> getAll()
        {
            var t = _repoWrapper.TblAutoDoku.FindAll().ToList();
            ConcurrentBag<tblAutoDokuDTO> tDto = Mapping.MergeListData2<tblAutoDokuDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
