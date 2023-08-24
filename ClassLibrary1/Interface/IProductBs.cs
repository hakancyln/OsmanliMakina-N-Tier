using Osm.CommonTypesLayer.Utilities;
using Osm.ModelLayer.Dtos.ProductDto;
using Osm.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.BusinessLayer.Interface
{
    public interface IProductBs
    {

        Task<ApiResponse<List<ProductGetDto>>> GetAsync(params string[] includeList);
        Task<ApiResponse<List<ProductGetDto>>> GetByNameAsync(string name, params string[] includeList);
        Task<ApiResponse<ProductGetDto>> GetByIDAsync(int productId, params string[] includeList);
        Task<ApiResponse<Product>> InsertAsync(ProductPostDto entity);
        Task<ApiResponse<NoData>> UpdateAsync(ProductPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
