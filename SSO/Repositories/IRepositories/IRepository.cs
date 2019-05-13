using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SSO.Repositories.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //Get
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //Add
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        //Remove
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
