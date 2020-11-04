 
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

    public class ItblPfadDAL : ItblPfad
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public ItblPfadDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public ConcurrentBag<tblPfadDTO> getAll()
        {
            var t = _repoWrapper.TblPfad.FindAll().ToList();
            ConcurrentBag<tblPfadDTO> tDto = Mapping.MergeListData2<tblPfadDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }



    }

}
