 
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

    public class AufenthaltZusatzDAL : IAufenthaltZusatz
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public AufenthaltZusatzDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<AufenthaltZusatzDTO> getAufenthaltZusatzAll()
        {
            var t = _repoWrapper.AufenthaltZusatz.FindAll().ToList();
            List<AufenthaltZusatzDTO> tDto = Mapping.MergeListData<AufenthaltZusatzDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
