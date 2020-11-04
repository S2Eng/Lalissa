 
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

    public class BenutzerRechteDAL : IBenutzerRechte
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public BenutzerRechteDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        public async Task<ConcurrentBag<BenutzerRechteDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<BenutzerRechte> t = await repoWrapper.BenutzerRechte.getAllAsync();
                ConcurrentBag<BenutzerRechteDTO> tDto = Mapping.MergeListData2<BenutzerRechteDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }

        public List<BenutzerRechteDTO> getBenutzerRechteAll()
        {
            var t = _repoWrapper.BenutzerRechte.FindAll().ToList();
            List<BenutzerRechteDTO> tDto = Mapping.MergeListData<BenutzerRechteDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
