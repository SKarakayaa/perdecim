using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Context;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class Repository<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
    {
        protected readonly MatmazelContext _context;
        public Repository(MatmazelContext context)
        {
            _context = context;
        }
        public TEntity Add(TEntity model)
        {
            _context.Entry(model).State = EntityState.Added;
            return model;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().AsNoTracking().Where(filter);
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            return await query.SingleOrDefaultAsync();
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = filter == null
                ? _context.Set<TEntity>().AsNoTracking()
                : _context.Set<TEntity>().AsNoTracking().Where(filter);

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return await query.ToListAsync();
        }
        public async Task<List<TEntity>> GetListAsyncTracked(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = filter == null
                ? _context.Set<TEntity>()
                : _context.Set<TEntity>().Where(filter);

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            return await query.ToListAsync();
        }

        public TEntity Remove(TEntity model)
        {
            _context.Entry(model).State = EntityState.Deleted;
            return model;
        }

        public TEntity Update(TEntity model)
        {
            _context.Entry(model).State = EntityState.Modified;
            return model;
        }
    }
}