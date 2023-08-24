using AutoMapper;
using Microsoft.AspNetCore.Http;
using Osm.BusinessLayer.CustomExceptions;
using Osm.BusinessLayer.Interface;
using Osm.CommonTypesLayer.Utilities;
using Osm.DataAccessLayer.Interfaces;
using Osm.ModelLayer.Dtos.CategoryDto;
using Osm.ModelLayer.Dtos.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.BusinessLayer.İmplementation
{
    public class CategoryBs : ICategoryBs
    {
        private readonly ICategoryRespository _categoryRespository;
        private readonly IMapper _mapper;
        public CategoryBs(ICategoryRespository categoryRespository, IMapper mapper )
        {
            _categoryRespository = categoryRespository;
            _mapper = mapper;
        }
        public async Task<ApiResponse<List<CategoryGetDto>>> GetAsync()
        {
            var category = await _categoryRespository.GetAllAsync();
            if (category.Count > 0)
            {
                var categoryList = _mapper.Map<List<CategoryGetDto>>(category);
                var response = ApiResponse<List<CategoryGetDto>>.Success(StatusCodes.Status200OK, categoryList);

                return response;
            }

            throw new NotFoundException("Kategori Bulunamadı.");
        }
    }
}
