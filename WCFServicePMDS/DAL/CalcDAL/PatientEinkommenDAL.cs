 
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

    public class PatientEinkommenDAL : IPatientEinkommen
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public PatientEinkommenDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public async Task<ConcurrentBag<PatientEinkommenDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<PatientEinkommen> t = await repoWrapper.PatientEinkommen.getAllAsync();
                ConcurrentBag<PatientEinkommenDTO> tDto = Mapping.MergeListData2<PatientEinkommenDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }

    }

}
