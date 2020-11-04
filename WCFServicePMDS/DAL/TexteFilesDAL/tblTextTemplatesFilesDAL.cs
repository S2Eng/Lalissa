 
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

    public class tblTextTemplatesFilesDAL : ItblTextTemplatesFiles
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public tblTextTemplatesFilesDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        public async Task<ConcurrentBag<tblTextTemplatesFilesDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<TblTextTemplatesFiles> t = await repoWrapper.TblTextTemplatesFiles.getAllAsync();
                ConcurrentBag<tblTextTemplatesFilesDTO> tDto = Mapping.MergeListData2<tblTextTemplatesFilesDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }



    }

}
