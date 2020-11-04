 
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

    public class EinrichtungDAL : IEinrichtung
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public EinrichtungDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public ConcurrentBag<EinrichtungDTO> getAll()
        {
            var t = _repoWrapper.Einrichtung.FindAll().ToList();
            ConcurrentBag<EinrichtungDTO> tDto = Mapping.MergeListData2<EinrichtungDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

        public EinrichtungDTO getEinrichtungByBezeichnung(string Bezeichnung)
        {
            var t = _repoWrapper.Einrichtung.FindByCondition(o => o.Text == Bezeichnung).ToList();
            if (t.Count > 0)
            {
                List<EinrichtungDTO> tDto = Mapping.MergeListData<EinrichtungDTO>(t.Select(x => x as object).ToList());
                return tDto.First();
            }
            else
            {
                return null;
            }
        }
        public EinrichtungDTO getEinrichtungByID(Guid Id)
        {
            var t = _repoWrapper.Einrichtung.FindByCondition(o => o.Id == Id).ToList();
            List<EinrichtungDTO> tDto = Mapping.MergeListData<EinrichtungDTO>(t.Select(x => x as object).ToList());
            return tDto.FirstOrDefault();
        }
    }

}
