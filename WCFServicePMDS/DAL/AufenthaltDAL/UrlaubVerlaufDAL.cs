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

    public class UrlaubVerlaufDAL : IUrlaubVerlauf
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public UrlaubVerlaufDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<UrlaubVerlaufDTO> getUrlaubVerlaufAll()
        {
            var t = _repoWrapper.UrlaubVerlauf.FindAll().ToList();
            List<UrlaubVerlaufDTO> tDto = Mapping.MergeListData<UrlaubVerlaufDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
