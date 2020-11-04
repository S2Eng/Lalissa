 
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

    public class UnterbringungDAL : IUnterbringung
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public UnterbringungDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<UnterbringungDTO> getUnterbringungAll()
        {
            var t = _repoWrapper.Unterbringung.FindAll().ToList();
            List<UnterbringungDTO> tDto = Mapping.MergeListData<UnterbringungDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
