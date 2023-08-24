using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Osm.BusinessLayer.Interface;
using Osm.CommonTypesLayer.Utilities;
using Osm.DataAccessLayer.Interfaces;
using Osm.ModelLayer.Dtos.CategoryDto;
using Osm.ModelLayer.Dtos.ProductDto;

namespace OsmanliMakina_N_Tier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly ICategoryBs _categoryBs;
        public CategoryController(ICategoryBs categoryBs)
        {
            _categoryBs=categoryBs;
        }
        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<CategoryGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<CategoryGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _categoryBs.GetAsync();
            return SendResponse(response);

        }
    }
}
