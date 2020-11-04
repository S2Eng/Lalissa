 
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

    public class AufenthaltVerlaufDAL : IAufenthaltVerlauf
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public AufenthaltVerlaufDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<AufenthaltVerlaufDTO> getAufenthaltVerlaufAll()
        {
            var t = _repoWrapper.AufenthaltVerlauf.FindAll().ToList();
            List<AufenthaltVerlaufDTO> tDto = Mapping.MergeListData<AufenthaltVerlaufDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
