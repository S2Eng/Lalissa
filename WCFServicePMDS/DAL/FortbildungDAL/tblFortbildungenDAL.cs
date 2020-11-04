 
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

    public class tblFortbildungenDAL : ItblFortbildungen
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public tblFortbildungenDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<tblFortbildungenDTO> getTblFortbildungenAll()
        {
            var t = _repoWrapper.TblFortbildungen.FindAll().ToList();
            List<tblFortbildungenDTO> tDto = Mapping.MergeListData<tblFortbildungenDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
