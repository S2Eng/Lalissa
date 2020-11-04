 
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

    public class tblSuchtgiftschrankSchlüsselDAL : ItblSuchtgiftschrankSchlüssel
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public tblSuchtgiftschrankSchlüsselDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public async Task<ConcurrentBag<tblSuchtgiftschrankSchlüsselDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<TblSuchtgiftschrankSchlüssel> t = await repoWrapper.TblSuchtgiftschrankSchlüssel.getAllAsync();
                ConcurrentBag<tblSuchtgiftschrankSchlüsselDTO> tDto = Mapping.MergeListData2<tblSuchtgiftschrankSchlüsselDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }

        public List<tblSuchtgiftschrankSchlüsselDTO> getTblSuchtgiftschrankSchlüsselAll()
        {
            var t = _repoWrapper.TblSuchtgiftschrankSchlüssel.FindAll().ToList();
            List<tblSuchtgiftschrankSchlüsselDTO> tDto = Mapping.MergeListData<tblSuchtgiftschrankSchlüsselDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
