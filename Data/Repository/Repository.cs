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
        public async Task<TEntity> AddAsync(TEntity model)
        {
            _context.Entry(model).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, string[] children = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
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

        public async Task RemoveAsync(TEntity model)
        {
            _context.Entry(model).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return model;
        }
    }
}