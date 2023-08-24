using Osm.CommonTypesLayer.DataAccess.Interfaces;
using Osm.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.DataAccessLayer.Interfaces
{
    public interface IProductImageRepository:IBaseRepository<ProductImage>
    {
        Task<ProductImage> GetByIDAsync(int ImageId);
    }
}
