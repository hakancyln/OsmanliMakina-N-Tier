using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Osm.WebUI.Models;

namespace Osm.WebUI.Controllers
{
    public class AboutController : Controller
    {
        
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> About()
        {
            var client = _httpClientFactory.CreateClient();
            var responserMessage = await client.GetAsync("http://localhost:5114/api/CompanyInfo");
            if (responserMessage.IsSuccessStatusCode)
            {
                var jsonData = await responserMessage.Content.ReadAsStringAsync();
                var container = JsonConvert.DeserializeObject<ResponseComing<AboutItem>>(jsonData);
                var value = container.data;

                return View(value);
            }
            return View();
        }
    }
}
