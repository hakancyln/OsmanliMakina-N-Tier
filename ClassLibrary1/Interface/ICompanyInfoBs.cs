using Osm.CommonTypesLayer.Utilities;
using Osm.ModelLayer.Dtos.AdminLoginDto;
using Osm.ModelLayer.Dtos.CompanyInfoDto;
using Osm.ModelLayer.Dtos.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.BusinessLayer.Interface
{
    public interface ICompanyInfoBs
    {
        Task<ApiResponse<List<CompanyInfoGetDto>>> GetAsync();
        Task<ApiResponse<CompanyInfoGetDto>> GetByIDAsync(int companyInfoId);
        Task<ApiResponse<NoData>> UpdateAsync(CompanyInfoPutDto p);
    }
}
