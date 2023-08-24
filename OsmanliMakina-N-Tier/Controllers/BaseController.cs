using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Osm.CommonTypesLayer.Utilities;

namespace OsmanliMakina_N_Tier.Controllers
{
    public class BaseController : ControllerBase
    {
        [NonAction]
        public IActionResult SendResponse<T>(ApiResponse<T> response)
        {
            if (response.StatusCode == StatusCodes.Status204NoContent)
                return new ObjectResult(null) { StatusCode = response.StatusCode };

            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
