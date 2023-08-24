using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Osm.BusinessLayer.CustomExceptions;
using Osm.BusinessLayer.Interface;
using Osm.CommonTypesLayer.Utilities;
using Osm.DataAccessLayer.EF.Repositories;
using Osm.DataAccessLayer.Interfaces;
using Osm.ModelLayer.Dtos.ProductDto;
using Osm.ModelLayer.Dtos.ProductImageDto;
using Osm.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.BusinessLayer.İmplementation
{
    public class ProductImageBs : IProductImageBs
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IMapper _mapper;
        public ProductImageBs(IProductImageRepository productImageRepository,IMapper mapper)
        {
            _productImageRepository = productImageRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var productImage = await _productImageRepository.GetByIDAsync(id);

            await _productImageRepository.DeleteAsync(productImage);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<ProductImageGetDto>>> GetAsync()
        {
            var productImage = await _productImageRepository.GetAllAsync();
            if (productImage.Count > 0)
            {
                var productList = _mapper.Map<List<ProductImageGetDto>>(productImage);
                var response = ApiResponse<List<ProductImageGetDto>>.Success(StatusCodes.Status200OK, productList);

                return response;
            }
            throw new NotFoundException("Resim Bulunamadı.");
        }

        public async Task<ApiResponse<ProductImageGetDto>> GetByIDAsync(int productImageId)
        {
            var productImage = await _productImageRepository.GetByIDAsync(productImageId);

            if (productImage != null)
            {
                var dto = _mapper.Map<ProductImageGetDto>(productImage);
                return ApiResponse<ProductImageGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("Resim Bulunamadı.");
        }

        public async Task<ApiResponse<ProductImage>> InsertAsync(ProductImagePostDto p)
        {
            if (p == null)
                throw new BadRequestException("Kaydedecek Ürün yok");

            var productImage = _mapper.Map<ProductImage>(p);
            var insertedproductImage = await _productImageRepository.InsertAsync(productImage);
            return ApiResponse<ProductImage>.Success(StatusCodes.Status200OK, insertedproductImage);
        }
    }
}
