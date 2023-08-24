using Microsoft.AspNetCore.Mvc;

namespace Osm.WebUI.ViewComponents.Default
{
    public class _ScriptPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
