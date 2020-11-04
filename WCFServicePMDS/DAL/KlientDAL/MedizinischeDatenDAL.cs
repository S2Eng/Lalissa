 
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

    public class MedizinischeDatenDAL : IMedizinischeDaten
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public MedizinischeDatenDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<MedizinischeDatenDTO> getMedizinischeDatenAll()
        {
            var t = _repoWrapper.MedizinischeDaten.FindAll().ToList();
            List<MedizinischeDatenDTO> tDto = Mapping.MergeListData<MedizinischeDatenDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
