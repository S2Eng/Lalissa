 
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

    public class TextbausteineDAL : ITextbausteine
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public TextbausteineDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        public async Task<ConcurrentBag<TextbausteineDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<Textbausteine> t = await repoWrapper.Textbausteine.getAllAsync();
                ConcurrentBag<TextbausteineDTO> tDto = Mapping.MergeListData2<TextbausteineDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }


    }

}
