using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Osm.BusinessLayer.Interface;
using Osm.CommonTypesLayer.Utilities;
using Osm.ModelLayer.Dtos.ProductDto;
using Osm.ModelLayer.Entities;

namespace OsmanliMakina_N_Tier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IProductBs _productBs;
        public ProductController(IProductBs productBs)
        {
            _productBs = productBs;
        }
        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<ProductGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<ProductGetDto>))]
        //[HttpGet("getbyId")]//([FromQuery])getbyId?id=5
        //([FromRoute])..api/products/7
        #endregion

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            var response = await _productBs.GetByIDAsync(id, "Category", "Images");

            return SendResponse(response);
        }
        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _productBs.GetAsync("Category");
            return SendResponse(response);

        }
        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        #endregion
        [HttpGet("getbyname")]
        public async Task<IActionResult> GetByName(string name)
        {
            var response = await _productBs.GetByNameAsync(name, "Category");
            return SendResponse(response);
        }


        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<ProductPostDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<ProductPostDto>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> ProductAdd([FromBody] ProductPostDto p)
        {


            var response = await _productBs.InsertAsync(p);
            return CreatedAtAction(nameof(GetByID), new { id = response.Data.ID }, response.Data);
        }




        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        #endregion
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductPutDto p)
        {

            var response = await _productBs.UpdateAsync(p);
            return SendResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var response = await _productBs.DeleteAsync(id);
            return SendResponse(response);
        }
    }
}
