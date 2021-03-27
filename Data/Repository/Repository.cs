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

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, string[] children = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().Where(filter);
            if (children != null)
                foreach (var child in children)
                    query = query.Include(child);

            return await query.SingleOrDefaultAsync();
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, string[] children = null)
        {
            IQueryable<TEntity> query = filter == null
                ? _context.Set<TEntity>()
                : _context.Set<TEntity>().Where(filter);

            if (children != null)
                foreach (var item in children)
                    query = query.Include(item);
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