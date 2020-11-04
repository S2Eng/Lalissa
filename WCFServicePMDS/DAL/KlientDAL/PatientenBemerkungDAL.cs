 
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

    public class PatientenBemerkungDAL : IPatientenBemerkung
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public PatientenBemerkungDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        public async Task<ConcurrentBag<PatientenBemerkungDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<PatientenBemerkung> t = await repoWrapper.PatientenBemerkung.getAllAsync();
                ConcurrentBag<PatientenBemerkungDTO> tDto = Mapping.MergeListData2<PatientenBemerkungDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }

        public List<PatientenBemerkungDTO> getPatientenBemerkungAll()
        {
            var t = _repoWrapper.PatientenBemerkung.FindAll().ToList();
            List<PatientenBemerkungDTO> tDto = Mapping.MergeListData<PatientenBemerkungDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
