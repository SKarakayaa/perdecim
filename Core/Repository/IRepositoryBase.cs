using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Core.Repository
{
    public interface IRepositoryBase<T> where T : class, IEntity, new()
    {
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null, string[] children = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, string[] children = null);
        Task<T> AddAsync(T model);
        Task<T> UpdateAsync(T model);
        Task RemoveAsync(T model);
    }
}