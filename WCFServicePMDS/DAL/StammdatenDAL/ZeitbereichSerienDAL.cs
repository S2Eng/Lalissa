 
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

    public class ZeitbereichSerienDAL : IZeitbereichSerien
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public ZeitbereichSerienDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
    


        public ConcurrentBag<ZeitbereichSerienDTO> getAll()
        {
            var t = _repoWrapper.ZeitbereichSerien.FindAll().ToList();
            ConcurrentBag<ZeitbereichSerienDTO> tDto = Mapping.MergeListData2<ZeitbereichSerienDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
