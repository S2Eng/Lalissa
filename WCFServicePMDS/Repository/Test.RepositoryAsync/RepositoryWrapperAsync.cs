using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;

namespace TestRepAsync.WCFServicePMDS.DAL
{

    public class RepositoryWrapperAsync : InterfacesAsync.IRepositoryWrapperAsync
    {
        private PMDSDevContext _repoContext;
        private InterfacesAsync.IOwnerRepositoryAsync _owner;



        public InterfacesAsync.IOwnerRepositoryAsync Benutzer
        {
            get
            {
                if (_owner == null)
                {
                    _owner = new RepositoryAsync.OwnerRepository(_repoContext);
                }

                return _owner;
            }
        }


        public RepositoryWrapperAsync(PMDSDevContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

    }
}

