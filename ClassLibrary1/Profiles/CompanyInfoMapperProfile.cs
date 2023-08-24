using AutoMapper;
using Osm.ModelLayer.Dtos.CompanyInfoDto;
using Osm.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.BusinessLayer.Profiles
{
    public class CompanyInfoMapperProfile : Profile
    {
        public CompanyInfoMapperProfile()
        {
            CreateMap<CompanyInfo, CompanyInfoGetDto>();
            CreateMap<CompanyInfoPutDto, CompanyInfo>();
        }

    }
}
