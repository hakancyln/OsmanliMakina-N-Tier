using AutoMapper;
using Microsoft.AspNetCore.Http;
using Osm.BusinessLayer.CustomExceptions;
using Osm.BusinessLayer.Interface;
using Osm.CommonTypesLayer.Utilities;
using Osm.DataAccessLayer.EF.Repositories;
using Osm.DataAccessLayer.Interfaces;
using Osm.ModelLayer.Dtos.AdminLoginDto;
using Osm.ModelLayer.Dtos.ProductDto;
using Osm.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.BusinessLayer.İmplementation
{
    public class AdminLoginBs : IAdminLoginBs
    {
        private readonly IAdminLoginRepository _adminLoginRepository;
        private readonly IMapper _mapper;
        public AdminLoginBs(IAdminLoginRepository adminLoginRepository, IMapper mapper)
        {
            _adminLoginRepository = adminLoginRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<AdminLoginGetDto>> GetByIDAsync(int adminLoginId)
        {
            adminLoginId = 1;
            var adminLogin = await _adminLoginRepository.GetByIDAsync(adminLoginId);

            if (adminLogin != null)
            {
                var dto = _mapper.Map<AdminLoginGetDto>(adminLogin);
                return ApiResponse<AdminLoginGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("Firma Bilgisi Bulunamadı.");
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(AdminLoginPutDto p)
        {
            if (p == null)
                throw new BadRequestException("Kaydedecek Firma Bilgisi yok");

            var adminLogin = _mapper.Map<AdminLogin>(p);
            await _adminLoginRepository.UpdateAsync(adminLogin);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
