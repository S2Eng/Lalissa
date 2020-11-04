 
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

    public class FormularDAL : IFormular
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public FormularDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public async Task<ConcurrentBag<FormularDTO>> getAllAsync(Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                List<Formular> t = await repoWrapper.Formular.getAllAsync();
                ConcurrentBag<FormularDTO> tDto = Mapping.MergeListData2<FormularDTO>(t.Select(x => x as object).ToList());
                return tDto;
            }
        }



    }

}
