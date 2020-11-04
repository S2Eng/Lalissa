 
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

    public class KontaktpersonDAL : IKontaktperson
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public KontaktpersonDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        public async Task<ConcurrentBag<KontaktpersonDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<Kontaktperson> t = await repoWrapper.Kontaktperson.getAllAsync();
                ConcurrentBag<KontaktpersonDTO> tDto = Mapping.MergeListData2<KontaktpersonDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }

        public List<KontaktpersonDTO> getKontaktpersonAll()
        {
            var t = _repoWrapper.Kontaktperson.FindAll().ToList();
            List<KontaktpersonDTO> tDto = Mapping.MergeListData<KontaktpersonDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

        public List<KontaktpersonS1DTO> KontaktpersonS1(Guid idpatient)
        {
            return (from o in this._repoWrapper.dbcontext.Kontaktperson
                    where o.Idpatient == idpatient
                    orderby o.Nachname ascending, o.Vorname ascending
                    select new KontaktpersonS1DTO { Id = o.Id, Idpatient = o.Idpatient, Vorname = o.Vorname, Nachname = o.Nachname, Idadresse = o.Idadresse,
                        Idkontakt = o.Idkontakt, Verwandtschaft = o.Verwandtschaft , VerstaendigenJn = o.VerstaendigenJn}).ToList();

        }

    }

}
