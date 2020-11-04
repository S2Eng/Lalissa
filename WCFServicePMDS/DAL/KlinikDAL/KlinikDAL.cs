 
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

    public class KlinikDAL : IKlinik
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public KlinikDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<KlinikDTO> getKlinikAll()
        {
            var t = _repoWrapper.Klinik.FindAll().ToList();
            List<KlinikDTO> tDto = Mapping.MergeListData<KlinikDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }
        public async Task<ConcurrentBag<KlinikDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<Klinik> t = await repoWrapper.Klinik.getAllAsync();
                ConcurrentBag<KlinikDTO> tDto = Mapping.MergeListData2<KlinikDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }

        public KlinikS1DTO KlinikS1(Guid ID)
        {
            return (from o in this._repoWrapper.dbcontext.Klinik
                                           where o.Id == ID
                                           select new KlinikS1DTO { Id = o.Id, Bezeichnung = o.Bezeichnung, Idadresse = o.Idadresse, Idkontakt = o.Idkontakt }).ToList().First();
        }

        public KlinikDTO KlinikByIdAufenthalt(Guid IDAufenthalt)
        {
            List<Klinik> t = (from a in this._repoWrapper.dbcontext.Aufenthalt
                    join abt in this._repoWrapper.dbcontext.Abteilung on a.Idabteilung equals abt.Id
                    join k in this._repoWrapper.dbcontext.Klinik on abt.Idklinik equals k.Id
                    where a.Id == IDAufenthalt
                    select k).ToList();
            return Mapping.MergeListData<KlinikDTO>(t.Select(x => x as object).ToList()).First();
        }


    }

}
