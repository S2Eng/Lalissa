 
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

    public class DienstzeitenDAL : IDienstzeiten
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public DienstzeitenDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        public async Task<ConcurrentBag<DienstzeitenDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<Dienstzeiten> t = await repoWrapper.Dienstzeiten.getAllAsync();
                ConcurrentBag<DienstzeitenDTO> tDto = Mapping.MergeListData2<DienstzeitenDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }

        public ConcurrentBag<DienstzeitenDTO> getAll()
        {
            var t = _repoWrapper.Dienstzeiten.FindAll().ToList();
            ConcurrentBag<DienstzeitenDTO> tDto = Mapping.MergeListData2<DienstzeitenDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
