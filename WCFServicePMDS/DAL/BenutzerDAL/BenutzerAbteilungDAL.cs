 
using System;
using System.Collections.Concurrent;
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

    public class BenutzerAbteilungDAL : IBenutzerAbteilung
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public BenutzerAbteilungDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        public async Task<ConcurrentBag<BenutzerAbteilungDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<BenutzerAbteilung> t = await repoWrapper.BenutzerAbteilung.getAllAsync();
                ConcurrentBag<BenutzerAbteilungDTO> tDto = Mapping.MergeListData2<BenutzerAbteilungDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }

        public List<BenutzerAbteilungDTO> getBenutzerAbteilungAll()
        {
            var t = _repoWrapper.BenutzerAbteilung.FindAll().ToList();
            List<BenutzerAbteilungDTO> tDto = Mapping.MergeListData<BenutzerAbteilungDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
