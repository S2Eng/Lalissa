 
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

    public class PatientAerzteDAL : IPatientAerzte
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public PatientAerzteDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public async Task<ConcurrentBag<PatientAerzteDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<PatientAerzte> t = await repoWrapper.PatientAerzte.getAllAsync();
                ConcurrentBag<PatientAerzteDTO> tDto = Mapping.MergeListData2<PatientAerzteDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }

        public List<PatientAerzteDTO> getPatientAerzteAll()
        {
            var t = _repoWrapper.PatientAerzte.FindAll().ToList();
            List<PatientAerzteDTO> tDto = Mapping.MergeListData<PatientAerzteDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
