 
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

    public class PatientAbwesenheitDAL : IPatientAbwesenheit
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public PatientAbwesenheitDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public async Task<ConcurrentBag<PatientAbwesenheitDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<PatientAbwesenheit> t = await repoWrapper.PatientAbwesenheit.getAllAsync();
                ConcurrentBag<PatientAbwesenheitDTO> tDto = Mapping.MergeListData2<PatientAbwesenheitDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }



    }

}
