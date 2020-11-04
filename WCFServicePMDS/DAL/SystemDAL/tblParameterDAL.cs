 
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

    public class tblParameterDAL : ItblParameter
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public tblParameterDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public ConcurrentBag<tblParameterDTO> getAll()
        {
            var t = _repoWrapper.TblParameter.FindAll().ToList();
            ConcurrentBag<tblParameterDTO> tDto = Mapping.MergeListData2<tblParameterDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
