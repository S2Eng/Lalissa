 
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

    public class SachwalterDAL : ISachwalter
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public SachwalterDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        public async Task<ConcurrentBag<SachwalterDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<Sachwalter> t = await repoWrapper.Sachwalter.getAllAsync();
                ConcurrentBag<SachwalterDTO> tDto = Mapping.MergeListData2<SachwalterDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }
        public List<SachwalterDTO> getSachwalterAll()
        {
            var t = _repoWrapper.Sachwalter.FindAll().ToList();
            List<SachwalterDTO> tDto = Mapping.MergeListData<SachwalterDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

        public List<SachwalterS1DTO> SachwalterS1(Guid idpatient, DateTime d)
        {
            return (from o in this._repoWrapper.dbcontext.Patient
                                               join s in this._repoWrapper.dbcontext.Sachwalter on o.Id equals s.Idpatient
                                               where o.Id == idpatient && s.Von <= d.Date && (s.Bis >= d.Date || s.Bis == null) && s.SachwalterJn == true
                                               select new SachwalterS1DTO { Id = s.Id, Idpatient = s.Idpatient, Nachname = s.Nachname, Vorname = s.Vorname, Titel = s.Titel, Idadresse = s.Idadresse, Idkontakt = s.Idkontakt }).ToList();
            
        }


    }

}
