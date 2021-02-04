using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository
{
    public class Repository<TEntity, TContext> : IRepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task<TEntity> AddAsync(TEntity model)
        {
            using (var context = new TContext())
            {
                context.Entry(model).State = EntityState.Added;
                await context.SaveChangesAsync();
                return model;
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, string[] children = null)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();
                if (children != null)
                    foreach (var child in children)
                        query = query.Include(child);

                return await query.SingleOrDefaultAsync();
            }
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, string[] children = null)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> query = filter == null
                    ? context.Set<TEntity>()
                    : context.Set<TEntity>().Where(filter);

                if (children != null)
                    foreach (var item in children)
                        query = query.Include(item);
                return await query.ToListAsync();
            }
        }

        public async Task RemoveAsync(TEntity model)
        {
            using (var context = new TContext())
            {
                context.Entry(model).State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity model)
        {
            using (var context = new TContext())
            {
                context.Entry(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return model;
            }
        }
    }
}