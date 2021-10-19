using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tinder.Data.Entities;
using Tinder.Repository.Abstract;

namespace Tinder.Repository.Concrete
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        public async Task Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }
        public async Task<List<TEntity>> GetAll()
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().ToListAsync();
            }
        }
        public async ValueTask<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? await context.Set<TEntity>().ToListAsync()
                    : await context.Set<TEntity>().Where(filter).ToListAsync();
                /* filtre var mı diye kontrol ediyoruz
                ? context.Set<TEntity>().ToList() ==> null ise
                 : context.Set<TEntity>().Where(filter).ToList(); ==> null değil ise+
                 */
            }
        }
        public async Task<TEntity> GetById(string id1)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().FindAsync(id1);
            }
        }

        public async Task<TEntity> GetByMatchesId(int id)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().FindAsync(id);
            }
        }

        public async Task Remove(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }
        public async Task Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<TEntity>> Include(string table)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().Include(table).ToListAsync();
            }
        }
    }
}
