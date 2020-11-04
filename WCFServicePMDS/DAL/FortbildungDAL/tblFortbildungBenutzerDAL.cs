 
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

    public class tblFortbildungBenutzerDAL : ItblFortbildungBenutzer
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public tblFortbildungBenutzerDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<tblFortbildungBenutzerDTO> getTblFortbildungBenutzerAll()
        {
            var t = _repoWrapper.TblFortbildungBenutzer.FindAll().ToList();
            List<tblFortbildungBenutzerDTO> tDto = Mapping.MergeListData<tblFortbildungBenutzerDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
