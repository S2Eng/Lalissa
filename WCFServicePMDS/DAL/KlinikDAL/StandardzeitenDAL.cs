 
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

    public class StandardzeitenDAL : IStandardzeiten
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public StandardzeitenDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        public async Task<ConcurrentBag<StandardzeitenDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<Standardzeiten> t = await repoWrapper.Standardzeiten.getAllAsync();
                ConcurrentBag<StandardzeitenDTO> tDto = Mapping.MergeListData2<StandardzeitenDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }

        public ConcurrentBag<StandardzeitenDTO> getAll()
        {
            var t = _repoWrapper.Standardzeiten.FindAll().ToList();
            ConcurrentBag<StandardzeitenDTO> tDto = Mapping.MergeListData2<StandardzeitenDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
