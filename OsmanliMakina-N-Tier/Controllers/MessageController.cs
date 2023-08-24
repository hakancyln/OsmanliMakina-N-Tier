using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Osm.BusinessLayer.İmplementation;
using Osm.BusinessLayer.Interface;
using Osm.CommonTypesLayer.Utilities;
using Osm.ModelLayer.Dtos.MessageDto;
using Osm.ModelLayer.Dtos.ProductDto;

namespace OsmanliMakina_N_Tier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : BaseController
    {
        private readonly IMessageBs _messageBs;
        public MessageController(IMessageBs messageBs)
        {
            _messageBs = messageBs;
        }
        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<MessageGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<MessageGetDto>))]

        #endregion

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            var response = await _messageBs.GetByIDAsync(id);

            return SendResponse(response);
        }
        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<MessageGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<MessageGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _messageBs.GetAsync();
            return SendResponse(response);

        }

        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<MessagePostDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<MessagePostDto>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> MessageAdd([FromBody] MessagePostDto p)
        {


            var response = await _messageBs.InsertAsync(p);
            return CreatedAtAction(nameof(GetByID), new { id = response.Data.ID }, response.Data);
        }
    }
}
