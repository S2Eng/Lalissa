 
using System;
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

    public class AnmeldungenDAL : IAnmeldungen
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public AnmeldungenDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<AnmeldungenDTO> getAnmeldungenAll()
        {
            var t = _repoWrapper.Anmeldungen.FindAll().ToList();
            List<AnmeldungenDTO> tDto = Mapping.MergeListData<AnmeldungenDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
