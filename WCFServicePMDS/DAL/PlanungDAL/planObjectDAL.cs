 
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

    public class planObjectDAL : IplanObject
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public planObjectDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }



    }

}
