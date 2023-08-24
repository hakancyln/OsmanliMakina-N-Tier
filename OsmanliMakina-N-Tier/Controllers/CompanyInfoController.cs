using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Osm.BusinessLayer.İmplementation;
using Osm.BusinessLayer.Interface;
using Osm.CommonTypesLayer.Utilities;
using Osm.ModelLayer.Dtos.CompanyInfoDto;
using Osm.ModelLayer.Dtos.ProductDto;

namespace OsmanliMakina_N_Tier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyInfoController : BaseController
    {
        private readonly ICompanyInfoBs _companyInfoBs;
        public CompanyInfoController(ICompanyInfoBs companyInfoBs)
        {
            _companyInfoBs = companyInfoBs;
        }

        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<CompanyInfoGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<CompanyInfoGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _companyInfoBs.GetAsync();
            return SendResponse(response);

        }
        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<CompanyInfoGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<CompanyInfoGetDto>))]
        #endregion

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            var response = await _companyInfoBs.GetByIDAsync(id);

            return SendResponse(response);
        }
        #region Swagger
        //[Produces("application/json", "text/plain")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        #endregion
        [HttpPut]
        public async Task<IActionResult> UpdateCompanyInfo([FromBody] CompanyInfoPutDto p)
        {

            var response = await _companyInfoBs.UpdateAsync(p);
            return SendResponse(response);
        }
    }
}
