using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Osm.BusinessLayer.İmplementation;
using Osm.BusinessLayer.Interface;
using Osm.CommonTypesLayer.Utilities;
using Osm.ModelLayer.Dtos.ProductDto;
using Osm.ModelLayer.Dtos.ProductImageDto;

namespace OsmanliMakina_N_Tier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : BaseController
    {
        private readonly IProductImageBs _productImageBs;
        public ProductImageController(IProductImageBs productImageBs)
        {
            _productImageBs = productImageBs;
        }


        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<ProductImageGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<ProductImageGetDto>))]

        #endregion

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            var response = await _productImageBs.GetByIDAsync(id);

            return SendResponse(response);
        }
        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<ProductImageGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<ProductImageGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _productImageBs.GetAsync();
            return SendResponse(response);

        }
        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<ProductImagePostDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<ProductImagePostDto>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> ProductImageAdd([FromBody] ProductImagePostDto p)
        {


            var response = await _productImageBs.InsertAsync(p);
            return CreatedAtAction(nameof(GetByID), new { id = response.Data.ID }, response.Data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductImage([FromRoute] int id)
        {
            var response = await _productImageBs.DeleteAsync(id);
            return SendResponse(response);
        }
    }
}
