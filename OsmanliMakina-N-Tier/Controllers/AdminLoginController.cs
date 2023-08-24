using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Osm.BusinessLayer.İmplementation;
using Osm.BusinessLayer.Interface;
using Osm.CommonTypesLayer.Utilities;
using Osm.ModelLayer.Dtos.AdminLoginDto;
using Osm.ModelLayer.Dtos.ProductDto;

namespace OsmanliMakina_N_Tier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminLoginController : BaseController
    {
        private readonly IAdminLoginBs _adminLoginBs;
        public AdminLoginController(IAdminLoginBs adminLoginBs)
        {
            _adminLoginBs = adminLoginBs;
        }
        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<AdminLoginGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<AdminLoginGetDto>))]
        #endregion

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            var response = await _adminLoginBs.GetByIDAsync(id);

            return SendResponse(response);
        }
        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        #endregion
        [HttpPut]
        public async Task<IActionResult> UpdateAdminLogin([FromBody] AdminLoginPutDto p)
        {

            var response = await _adminLoginBs.UpdateAsync(p);
            return SendResponse(response);
        }
    }
}
