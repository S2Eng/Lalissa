using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS;


namespace WCFServicePMDS.Repository
{

    public abstract class RepositoryBase<T> : Interfaces.IRepositoryBase<T> where T : class
    {

        protected Models.DB.PMDSDevContext RepositoryContext { get; set; }



        public RepositoryBase(Models.DB.PMDSDevContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public IEnumerable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression);
        }
        public IEnumerable<T> FindAllTake(int Nr)
        {
            return this.RepositoryContext.Set<T>().Take(Nr);
        }

        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            this.RepositoryContext.SaveChanges();
        }
        public void Save2()
        {
            this.RepositoryContext.SaveChanges();
        }

        public async Task<List<T>> getAllAsync()
        {
            return await this.RepositoryContext.Set<T>().ToListAsync();
        }
        public async Task<List<T>> getWhereAsync(Expression<Func<T, bool>> expression)
        {
            return await this.RepositoryContext.Set<T>().Where(expression).ToListAsync();
        }


    }

}
