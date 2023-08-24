using Osm.CommonTypesLayer.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Osm.CommonTypesLayer.Model;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;

namespace Osm.CommonTypesLayer.DataAccess.Implementaitons.EF
{
    public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class, IEntity///TEntity ye gelecek değer class ve IEntity olabilir diye kısıtlıyoruz
        where TContext : DbContext, new()///Tcontex e gelecek değer db context olabilir diye kısıtlıyoruz
    {
        public async Task DeleteAsync(TEntity entitiy)
        {
            using var context = new TContext();
            context.Set<TEntity>().Remove(entitiy);
            await context.SaveChangesAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params string[] includeList)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> dbSet = context.Set<TEntity>();
                if (includeList.Length > 0)
                {
                    foreach (var include in includeList)
                    {
                        dbSet = dbSet.Include(include);
                    }
                }

                return await dbSet.SingleOrDefaultAsync(predicate);
            }
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params string[] includeList)
        {
            //delagate generic
            //func
            //act
            //pridicate
            //Expression<Func<Product>,bool>
            using (var context = new TContext())
            {
                IQueryable<TEntity> dbSet = context.Set<TEntity>();
                if (includeList.Length > 0)
                {
                    foreach (var item in includeList)
                    {
                        dbSet = dbSet.Include(item);
                    }
                }
                if (predicate == null)
                    return await dbSet.ToListAsync();
                else
                    return await dbSet.Where(predicate).ToListAsync();
            }

        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            using var context = new TContext();

            var entityT = context.Set<TEntity>().AddAsync(entity);

            await context.SaveChangesAsync();
            return entityT.Result.Entity;
        }

        public async Task UpdateAsync(TEntity entitiy)
        {
            using var context = new TContext();
            context.Set<TEntity>().Update(entitiy);
            await context.SaveChangesAsync();
        }
    }

}
