using AutoMapper;
using Osm.ModelLayer.Dtos.ProductImageDto;
using Osm.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.BusinessLayer.Profiles
{
    public class ProductImageMapperProfile : Profile
    {
        public ProductImageMapperProfile()
        {
            CreateMap<ProductImage, ProductImageGetDto>();
            CreateMap<ProductImagePostDto, ProductImage>();
        }

    }
}
