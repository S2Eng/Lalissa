 
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

    public class MedizinischeTypenDAL : IMedizinischeTypen
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public MedizinischeTypenDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<MedizinischeTypenDTO> getMedizinischeTypenAll()
        {
            var t = _repoWrapper.MedizinischeTypen.FindAll().ToList();
            List<MedizinischeTypenDTO> tDto = Mapping.MergeListData<MedizinischeTypenDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
