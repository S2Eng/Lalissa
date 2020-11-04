 
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

    public class AdresseDAL : IAdresse
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public AdresseDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        public async Task<ConcurrentBag<AdresseDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<Adresse> t = await repoWrapper.Adresse.getAllAsync();
                ConcurrentBag<AdresseDTO> tDto = Mapping.MergeListData2<AdresseDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }
        public List<AdresseDTO> getAdresseAll()
        {
            var t = _repoWrapper.Adresse.FindAll().ToList();
            List<AdresseDTO> tDto = Mapping.MergeListData<AdresseDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

        public AdresseDTO getAdress(Nullable<Guid> id)
        {
            if (id == null)
                return new AdresseDTO() {  Ort = "", LandKz = "", Strasse = "", Plz = "", Region = "" };
            else
            {
                return (from o in this._repoWrapper.dbcontext.Adresse
                              where o.Id == id.Value
                              select new AdresseDTO { Id = o.Id, LandKz = o.LandKz, Plz = o.Plz, Ort = o.Ort, Strasse = o.Strasse, Region = o.Region }).ToList().First();
            }
        }

    }

}
