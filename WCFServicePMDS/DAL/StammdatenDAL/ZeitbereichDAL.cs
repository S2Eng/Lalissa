 
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

    public class ZeitbereichDAL : IZeitbereich
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public ZeitbereichDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public ConcurrentBag<ZeitbereichDTO> getAll()
        {
            var t = _repoWrapper.Zeitbereich.FindAll().ToList();
            ConcurrentBag<ZeitbereichDTO> tDto = Mapping.MergeListData2<ZeitbereichDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
