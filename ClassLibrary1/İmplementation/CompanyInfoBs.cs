using AutoMapper;
using Microsoft.AspNetCore.Http;
using Osm.BusinessLayer.CustomExceptions;
using Osm.BusinessLayer.Interface;
using Osm.CommonTypesLayer.Utilities;
using Osm.DataAccessLayer.EF.Repositories;
using Osm.DataAccessLayer.Interfaces;
using Osm.ModelLayer.Dtos.CompanyInfoDto;
using Osm.ModelLayer.Dtos.ProductDto;
using Osm.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.BusinessLayer.İmplementation
{
    public class CompanyInfoBs : ICompanyInfoBs
    {
        private readonly ICompanyInfoRepository _companyInfoRepository;
        private readonly IMapper _mapper;
        public CompanyInfoBs(ICompanyInfoRepository companyInfoRepository, IMapper mapper)
        {
            _companyInfoRepository = companyInfoRepository;
            _mapper = mapper;

        }

        public async Task<ApiResponse<List<CompanyInfoGetDto>>> GetAsync()
        {
            var companyInfo= await _companyInfoRepository.GetAllAsync();
            if (companyInfo.Count > 0)
            {
                var companyInfoList = _mapper.Map<List<CompanyInfoGetDto>>(companyInfo);
                var response = ApiResponse<List<CompanyInfoGetDto>>.Success(StatusCodes.Status200OK, companyInfoList);

                return response;
            }

            throw new NotFoundException("Aradığınız Ürün Bulunamadı.");
        }

        public async Task<ApiResponse<CompanyInfoGetDto>> GetByIDAsync(int companyInfoId)
        {
            companyInfoId = 1;

            var companyInfo = await _companyInfoRepository.GetByIDAsync(companyInfoId);
            if (companyInfo != null)
            {
                var dto = _mapper.Map<CompanyInfoGetDto>(companyInfo);
                return ApiResponse<CompanyInfoGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("Firma Bilgisi Bulunamadı.");
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(CompanyInfoPutDto p)
        {
            if (p == null)
                throw new BadRequestException("Kaydedecek Ürün yok");

            var companyInfo = _mapper.Map<CompanyInfo>(p);
            await _companyInfoRepository.UpdateAsync(companyInfo);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}

