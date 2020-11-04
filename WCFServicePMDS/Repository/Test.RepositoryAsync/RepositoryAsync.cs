using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WCFServicePMDS.Models.DB;

namespace TestRepAsync.WCFServicePMDS.DAL
{

    public class RepositoryAsync
    {

        public class OwnerRepository : RepositoryBaseAsync<Benutzer>, InterfacesAsync.IOwnerRepositoryAsync
        {
            public OwnerRepository(PMDSDevContext repositoryContext) : base(repositoryContext)
            {

            }

            public async Task<IEnumerable<Benutzer>> GetAllOwnersAsync()
            {
                var owners = await FindAllAsync();
                return owners.OrderBy(x => x.Id);
            }

            public async Task<Benutzer> GetOwnerByIdAsync(Guid ownerId)
            {
                var owner = await FindByConditionAsync(o => o.Id.Equals(ownerId));
                return owner.DefaultIfEmpty(new Benutzer())
                        .FirstOrDefault();
            }

            //public async Task<OwnerExtended> GetOwnerWithDetailsAsync(Guid ownerId)
            //{
            //    var owner = await GetOwnerByIdAsync(ownerId);

            //    return new OwnerExtended(owner)
            //    {
            //        Accounts = await RepositoryContext.Accounts
            //            .Where(a = > a.OwnerId == ownerId).ToListAsync()
            //    };
            //}

            public async Task CreateOwnerAsync(Benutzer owner)
            {
                owner.Id = Guid.NewGuid();
                Create(owner);
                await SaveAsync();
            }

            public async Task UpdateOwnerAsync(Benutzer dbOwner, Benutzer owner)
            {
                //dbOwner.Map(owner);
                Update(dbOwner);
                await SaveAsync();
            }

            public async Task DeleteOwnerAsync(Benutzer owner)
            {
                Delete(owner);
                await SaveAsync();
            }


        }

    }

}
