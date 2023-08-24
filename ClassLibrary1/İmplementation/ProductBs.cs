using AutoMapper;
using Microsoft.AspNetCore.Http;
using Osm.BusinessLayer.CustomExceptions;
using Osm.BusinessLayer.Interface;
using Osm.CommonTypesLayer.Model;
using Osm.CommonTypesLayer.Utilities;
using Osm.DataAccessLayer.EF.Repositories;
using Osm.DataAccessLayer.Interfaces;
using Osm.ModelLayer.Dtos.ProductDto;
using Osm.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.BusinessLayer.İmplementation
{
    public class ProductBs : IProductBs
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductBs(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;

        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIDAsync(id);

            await _productRepository.DeleteAsync(product);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<ProductGetDto>>> GetAsync(params string[] includeList)
        {
            var products = await _productRepository.GetAllAsync(includeList: includeList);
            if (products.Count > 0)
            {
                var productList = _mapper.Map<List<ProductGetDto>>(products);
                var response = ApiResponse<List<ProductGetDto>>.Success(StatusCodes.Status200OK, productList);

                return response;
            }

            throw new NotFoundException("Aradığınız Ürün Bulunamadı.");
        }

        public async Task<ApiResponse<ProductGetDto>> GetByIDAsync(int productId, params string[] includeList)
        {
            
            var product = await _productRepository.GetByIDAsync(productId, includeList);

            if (product != null)
            {
                var dto = _mapper.Map<ProductGetDto>(product);
                return ApiResponse<ProductGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("Aradığınız Ürün Bulunamadı.");
        }

        public async Task<ApiResponse<List<ProductGetDto>>> GetByNameAsync(string name, params string[] includeList)
        {
            var products = await _productRepository.GetByNameAsync(name, includeList);

            if (products != null || products.Count > 0)
            {
                var returnList = _mapper.Map<List<ProductGetDto>>(products);
                return ApiResponse<List<ProductGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Ürün Yok");
        }

        public async Task<ApiResponse<Product>> InsertAsync(ProductPostDto p)
        {
            if (p == null)
                throw new BadRequestException("Kaydedecek Ürün yok");
            
            var product = _mapper.Map<Product>(p);
            var insertedProduct = await _productRepository.InsertAsync(product);
            return ApiResponse<Product>.Success(StatusCodes.Status200OK, insertedProduct);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(ProductPutDto p)
        {
            if (p == null)
                throw new BadRequestException("Kaydedecek Ürün yok");
            
            var product = _mapper.Map<Product>(p);
            await _productRepository.UpdateAsync(product);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
