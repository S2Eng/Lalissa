 
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

    public class KontaktDAL : IKontakt
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public KontaktDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        public async Task<ConcurrentBag<KontaktDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<Kontakt> t = await repoWrapper.Kontakt.getAllAsync();
                ConcurrentBag<KontaktDTO> tDto = Mapping.MergeListData2<KontaktDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }
        public List<KontaktDTO> getKontaktAll()
        {
            var t = _repoWrapper.Kontakt.FindAll().ToList();
            List<KontaktDTO> tDto = Mapping.MergeListData<KontaktDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

        public KontaktDTO getKontakt(Nullable<Guid> id)
        {
            if (id == null)
                return new KontaktDTO() { Tel = "", Fax = "", Mobil = "", Andere = "", Email = "", Ansprechpartner = "", Zusatz1 = "", Zusatz2 = "", Zusatz3 = "" };
            else
            {
                return (from o in this._repoWrapper.dbcontext.Kontakt
                        where o.Id == id.Value
                        select new KontaktDTO {Id = o.Id, Tel = o.Tel, Fax = o.Fax, Mobil = o.Mobil, Andere = o.Andere, Email = o.Email, Ansprechpartner = o.Ansprechpartner, Zusatz1 = o.Zusatz1, Zusatz2 = o.Zusatz2, Zusatz3 = o.Zusatz3 }).ToList().First();
            }
        }
    }

}
