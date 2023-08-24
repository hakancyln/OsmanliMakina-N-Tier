using Microsoft.AspNetCore.Mvc;

namespace Osm.WebUI.ViewComponents.Default
{
    public class _HeadPartial: ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View(); 
        }
    }
}
