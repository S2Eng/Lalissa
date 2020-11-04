 
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

    public class ELGAProtocollDAL : IELGAProtocoll
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public ELGAProtocollDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<ELGAProtocollDTO> getELGAProtocollAll()
        {
            var t = _repoWrapper.Elgaprotocoll.FindAll().ToList();
            List<ELGAProtocollDTO> tDto = Mapping.MergeListData<ELGAProtocollDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
