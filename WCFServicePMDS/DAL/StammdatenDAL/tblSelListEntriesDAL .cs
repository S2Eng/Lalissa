 
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

    public class tblSelListEntriesDAL: ItblSelListEntries
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public tblSelListEntriesDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<tblSelListEntriesDTO> getTblSelListEntriesAll()
        {
            var t = _repoWrapper.TblSelListEntries.FindAll().ToList();
            List<tblSelListEntriesDTO> tDto = Mapping.MergeListData<tblSelListEntriesDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

        public async Task<ConcurrentBag<tblSelListEntriesDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<TblSelListEntries> t = await repoWrapper.TblSelListEntries.getAllAsync();
                ConcurrentBag<tblSelListEntriesDTO> tDto = Mapping.MergeListData2<tblSelListEntriesDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }
    }

}
