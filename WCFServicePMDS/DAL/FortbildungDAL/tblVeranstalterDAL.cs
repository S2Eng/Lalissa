 
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

    public class tblVeranstalter : ItblVeranstalter
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public tblVeranstalter(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<ItblVeranstalterDTO> getTblVeranstalterAll()
        {
            var t = _repoWrapper.TblVeranstalter.FindAll().ToList();
            List<ItblVeranstalterDTO> tDto = Mapping.MergeListData<ItblVeranstalterDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
