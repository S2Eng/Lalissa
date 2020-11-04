 
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

    public class ELGAActivitiesDAL : IELGAActivities
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public ELGAActivitiesDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<ELGAActivitiesDTO> getELGAActivitiesAll()
        {
            var t = _repoWrapper.Elgaactivities.FindAll().ToList();
            List<ELGAActivitiesDTO> tDto = Mapping.MergeListData<ELGAActivitiesDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
