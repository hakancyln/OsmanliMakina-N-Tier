using Microsoft.EntityFrameworkCore.Query;
using Osm.CommonTypesLayer.Model;
using System.Linq.Expressions;

namespace Osm.CommonTypesLayer.DataAccess.Interfaces
{
    public interface IBaseRepository<TEntity>
       where TEntity : class, IEntity///TEntity ye gelecek değerin class ve IEntity olabilir diye kısıtlama veriyoruz
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params string[] includeList);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params string[] includeList);
        Task<TEntity> InsertAsync(TEntity entitiy);
        Task UpdateAsync(TEntity entitiy);
        Task DeleteAsync(TEntity entitiy);
    }
}
