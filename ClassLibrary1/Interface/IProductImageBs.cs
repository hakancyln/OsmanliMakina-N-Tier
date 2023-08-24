using Osm.CommonTypesLayer.Utilities;
using Osm.ModelLayer.Dtos.AdminLoginDto;
using Osm.ModelLayer.Dtos.ProductDto;
using Osm.ModelLayer.Dtos.ProductImageDto;
using Osm.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.BusinessLayer.Interface
{
    public interface IProductImageBs
    {
        Task<ApiResponse<List<ProductImageGetDto>>> GetAsync();
        Task<ApiResponse<ProductImageGetDto>> GetByIDAsync(int productImageId);
        Task<ApiResponse<ProductImage>> InsertAsync(ProductImagePostDto p);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
