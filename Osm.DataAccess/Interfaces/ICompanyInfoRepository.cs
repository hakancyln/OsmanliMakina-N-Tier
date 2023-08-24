using Osm.CommonTypesLayer.DataAccess.Interfaces;
using Osm.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.DataAccessLayer.Interfaces
{
    public interface ICompanyInfoRepository : IBaseRepository<CompanyInfo>
    {
        Task<CompanyInfo> GetByIDAsync(int companyInfoId);

    }
}
