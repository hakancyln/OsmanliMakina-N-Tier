using AutoMapper;
using Osm.ModelLayer.Dtos.ProductDto;
using Osm.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.BusinessLayer.Profiles
{
    public class ProductMapperProfile:Profile
    {
        public ProductMapperProfile()
        {
             CreateMap<Product, ProductGetDto>()
                    .ForMember(dst => dst.CategoryName, X => X.MapFrom(src => src.Category.Name));
                CreateMap<ProductPostDto, Product>();
                CreateMap<ProductPutDto, Product>();
            
        }
    }
}
