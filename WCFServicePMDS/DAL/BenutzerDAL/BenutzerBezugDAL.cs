 
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

    public class BenutzerBezugDAL : IBenutzerBezug
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public BenutzerBezugDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public async Task<ConcurrentBag<BenutzerBezugDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<BenutzerBezug> t = await repoWrapper.BenutzerBezug.getAllAsync();
                ConcurrentBag<BenutzerBezugDTO> tDto = Mapping.MergeListData2<BenutzerBezugDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }


        public List<BenutzerBezugDTO> getBenutzerBezugAll()
        {
            var t = _repoWrapper.BenutzerBezug.FindAll().ToList();
            List<BenutzerBezugDTO> tDto = Mapping.MergeListData<BenutzerBezugDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
