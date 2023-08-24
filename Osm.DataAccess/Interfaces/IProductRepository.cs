using Osm.CommonTypesLayer.DataAccess.Interfaces;
using Osm.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.DataAccessLayer.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<List<Product>> GetByNameAsync(string name, params string[] includeList);
        Task<Product> GetByIDAsync(int id, params string[] includeList);
    }
}
