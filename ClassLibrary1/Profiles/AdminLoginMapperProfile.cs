using AutoMapper;
using Osm.ModelLayer.Dtos.AdminLoginDto;
using Osm.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Osm.BusinessLayer.Profiles
{
    public class AdminLoginMapperProfile : Profile
    {
        public AdminLoginMapperProfile()
        {
            CreateMap<AdminLogin, AdminLoginGetDto>();
            CreateMap<AdminLoginPutDto, AdminLogin>();
        }

    }
}
