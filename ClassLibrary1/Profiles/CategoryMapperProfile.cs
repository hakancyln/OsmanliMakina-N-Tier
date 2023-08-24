using AutoMapper;
using Osm.ModelLayer.Dtos.CategoryDto;
using Osm.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.BusinessLayer.Profiles
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<Category, CategoryGetDto>();
        }

    }
}
