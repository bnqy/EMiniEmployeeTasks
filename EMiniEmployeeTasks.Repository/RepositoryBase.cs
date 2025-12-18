using Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMiniEmployeeTasks.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext repositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public void Create(T entity)
        {
            this.repositoryContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this.repositoryContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges ?
                this.repositoryContext.Set<T>()
                .AsNoTracking() :
                this.repositoryContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(System.Linq.Expressions.Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ?
                this.repositoryContext.Set<T>()
                .Where(expression)
                .AsNoTracking() :
                this.repositoryContext.Set<T>()
                .Where(expression);
        }

        public void Update(T entity)
        {
            this.repositoryContext.Set<T>().Update(entity);
        }
    }
}
