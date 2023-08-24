using Osm.CommonTypesLayer.Utilities;
using Osm.ModelLayer.Dtos.AdminLoginDto;
using Osm.ModelLayer.Dtos.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.BusinessLayer.Interface
{
    public interface IAdminLoginBs
    {
        Task<ApiResponse<NoData>> UpdateAsync(AdminLoginPutDto p);
        Task<ApiResponse<AdminLoginGetDto>> GetByIDAsync(int adminLoginId);
    }
}
