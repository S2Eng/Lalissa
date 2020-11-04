using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;

namespace TestRepAsync.WCFServicePMDS
{

    public class InterfacesAsync
    {
 
        public interface IRepositoryBaseAsync<T>
        {
            Task<IEnumerable<T>> FindAllAsync();
            Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
            void Create(T entity);
            void Update(T entity);
            void Delete(T entity);
            Task SaveAsync();
        }

        public interface IOwnerRepositoryAsync : IRepositoryBaseAsync<Benutzer>
        {
            Task<IEnumerable<Benutzer>> GetAllOwnersAsync();
            Task<Benutzer> GetOwnerByIdAsync(Guid ownerId);
            //Task<OwnerExtended> GetOwnerWithDetailsAsync(Guid ownerId);
            Task CreateOwnerAsync(Benutzer owner);
            Task UpdateOwnerAsync(Benutzer dbOwner, Benutzer owner);
            Task DeleteOwnerAsync(Benutzer owner);
        }

        public interface IRepositoryWrapperAsync
        {
            WCFServicePMDS.InterfacesAsync.IOwnerRepositoryAsync Benutzer { get; }
        }
    }

}

