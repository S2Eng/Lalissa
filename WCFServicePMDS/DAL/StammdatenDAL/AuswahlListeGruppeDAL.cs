 
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

    public class AuswahlListeGruppeDAL : IAuswahlListeGruppe
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public AuswahlListeGruppeDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<AuswahlListeGruppeDTO> getAuswahlGruppeAll()
        {
            var t = _repoWrapper.AuswahlListeGruppe.FindAll().ToList();
            List<AuswahlListeGruppeDTO> tDto = Mapping.MergeListData<AuswahlListeGruppeDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

        public async Task<ConcurrentBag<AuswahlListeGruppeDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<AuswahlListeGruppe> t = await repoWrapper.AuswahlListeGruppe.getAllAsync();
                ConcurrentBag<AuswahlListeGruppeDTO> tDto = Mapping.MergeListData2<AuswahlListeGruppeDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }

    }

}
