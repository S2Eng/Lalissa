 
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

    public class ProtocolDAL : IProtocol
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public ProtocolDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<ProtocolDTO> getProtocolAll()
        {
            var t = _repoWrapper.Protocol.FindAll().ToList();
            List<ProtocolDTO> tDto = Mapping.MergeListData<ProtocolDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
