 
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

    public class MedizinischeDatenLayoutDAL : IMedizinischeDatenLayout
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public MedizinischeDatenLayoutDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<MedizinischeDatenLayoutDTO> getMedizinischeDatenLayoutAll()
        {
            var t = _repoWrapper.MedizinischeDatenLayout.FindAll().ToList();
            List<MedizinischeDatenLayoutDTO> tDto = Mapping.MergeListData<MedizinischeDatenLayoutDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
