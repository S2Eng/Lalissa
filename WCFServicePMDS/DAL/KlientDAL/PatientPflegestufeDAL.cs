 
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

    public class PatientPflegestufeDAL : IPatientPflegestufe
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public PatientPflegestufeDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        public async Task<ConcurrentBag<PatientPflegestufeDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<PatientPflegestufe> t = await repoWrapper.PatientPflegestufe.getAllAsync();
                ConcurrentBag<PatientPflegestufeDTO> tDto = Mapping.MergeListData2<PatientPflegestufeDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }
        public List<PatientPflegestufeDTO> getPatientPflegestufeAll()
        {
            var t = _repoWrapper.PatientPflegestufe.FindAll().ToList();
            List<PatientPflegestufeDTO> tDto = Mapping.MergeListData<PatientPflegestufeDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
