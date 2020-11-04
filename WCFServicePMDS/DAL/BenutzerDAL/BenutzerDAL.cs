 
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

    public class BenutzerDAL: IBenutzerDAL
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public BenutzerDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<BenutzerDTO> getBenutzerAll()
        {
            var t = _repoWrapper.Benutzer.FindAll().ToList();
            List<BenutzerDTO> tDto = Mapping.MergeListData<BenutzerDTO>(t.Select(x => x as object).ToList());
            //benDto = varBen.Select(o => new BenutzerDTO() { Vorname = o.Vorname, Nachname = o.Nachname }).ToList();
            return tDto;
        }
        public async Task<ConcurrentBag<BenutzerDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<Benutzer> t = await repoWrapper.Benutzer.getAllAsync();
                ConcurrentBag<BenutzerDTO> tDto = Mapping.MergeListData2<BenutzerDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }

        public BenutzerSTOS1 BenutzerS1(Guid ID)
        {
            List<BenutzerSTOS1> tBenutzerCallback = (from o in this._repoWrapper.dbcontext.Benutzer
                                                   where o.Id == ID
                                                   orderby o.Nachname ascending, o.Vorname ascending
                                                   select new BenutzerSTOS1 { Id = o.Id, Vorname = o.Vorname, Nachname = o.Nachname, Benutzer1 = o.Benutzer1 }).ToList();
            return tBenutzerCallback.First();
        }

    }

}
