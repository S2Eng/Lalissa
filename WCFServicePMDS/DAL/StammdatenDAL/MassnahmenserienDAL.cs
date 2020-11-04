 
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

    public class MassnahmenserienDAL : IMassnahmenserien
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public MassnahmenserienDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public ConcurrentBag<MassnahmenserienDTO> getAll()
        {
            var t = _repoWrapper.Massnahmenserien.FindAll().ToList();
            ConcurrentBag<MassnahmenserienDTO> tDto = Mapping.MergeListData2<MassnahmenserienDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
