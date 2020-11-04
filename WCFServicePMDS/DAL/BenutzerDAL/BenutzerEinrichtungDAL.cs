 
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

    public class BenutzerEinrichtungDAL : IBenutzerEinrichtung
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public BenutzerEinrichtungDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        public async Task<ConcurrentBag<BenutzerEinrichtungDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<BenutzerEinrichtung> t = await repoWrapper.BenutzerEinrichtung.getAllAsync();
                ConcurrentBag<BenutzerEinrichtungDTO> tDto = Mapping.MergeListData2<BenutzerEinrichtungDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }
        public List<BenutzerEinrichtungDTO> getBenutzerEinrichtungAll()
        {
            var t = _repoWrapper.BenutzerEinrichtung.FindAll().ToList();
            List<BenutzerEinrichtungDTO> tDto = Mapping.MergeListData<BenutzerEinrichtungDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
