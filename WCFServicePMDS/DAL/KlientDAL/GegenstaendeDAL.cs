 
using System;
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

    public class GegenstaendeDAL : IGegenstaende
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public GegenstaendeDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<GegenstaendeDTO> getGegenstaendeAll()
        {
            var t = _repoWrapper.Gegenstaende.FindAll().ToList();
            List<GegenstaendeDTO> tDto = Mapping.MergeListData<GegenstaendeDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
