 
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

    public class vKlientenlisteDAL : IvKlientenliste
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public vKlientenlisteDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public List<vKlientenlisteDTO> getvKlientenlisteAll()
        {
            //

           var t = _repoWrapper.vKlientenliste2.FindAll().ToList();
            List<vKlientenlisteDTO> tDto = Mapping.MergeListData<vKlientenlisteDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

        public ConcurrentBag<vKlientenlisteDTO> getvKlientenlisteAll2()
        {
            var t = _repoWrapper.vKlientenliste2.FindAll().ToList();
            ConcurrentBag<vKlientenlisteDTO> tDto = Mapping.MergeListData2<vKlientenlisteDTO>(t.Select(x => x as object).ToList());
            return tDto;
        }

    }

}
