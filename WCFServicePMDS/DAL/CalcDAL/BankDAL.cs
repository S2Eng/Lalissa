 
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

    public class BankDAL : IBank
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public BankDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



        public async Task<ConcurrentBag<BankDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<Bank> t = await repoWrapper.Bank.getAllAsync();
                ConcurrentBag<BankDTO> tDto = Mapping.MergeListData2<BankDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }


    }

}
