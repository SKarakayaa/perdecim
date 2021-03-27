using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Data.Repository
{
    public interface IRepositoryBase<T> where T : class, IEntity, new()
    {
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null, string[] children = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, string[] children = null);
        T Add(T model);
        T Update(T model);
        T Remove(T model);
    }
}