 
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

    public class tblSelListGroupDAL : ItblSelListGroup
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public tblSelListGroupDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<tblSelListGroupDTO> getTblSelListGroupAll()
        {
            var t = _repoWrapper.TblSelListGroup.FindAll().ToList();
            List<tblSelListGroupDTO> tDto = Mapping.MergeListData<tblSelListGroupDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

        public async Task<ConcurrentBag<tblSelListGroupDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<TblSelListGroup> t = await repoWrapper.TblSelListGroup.getAllAsync();
                ConcurrentBag<tblSelListGroupDTO> tDto = Mapping.MergeListData2<tblSelListGroupDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }

    }

}
