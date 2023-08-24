using Osm.CommonTypesLayer.Utilities;
using Osm.ModelLayer.Dtos.AdminLoginDto;
using Osm.ModelLayer.Dtos.CategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.BusinessLayer.Interface
{
    public interface ICategoryBs
    {
        Task<ApiResponse<List<CategoryGetDto>>> GetAsync();
    }
}
