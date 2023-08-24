using Microsoft.AspNetCore.Mvc;

namespace Osm.WebUI.Controllers
{
    public class IndexController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
