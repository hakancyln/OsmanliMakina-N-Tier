using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Osm.WebUI.Models;
using System.Net.Http;

namespace Osm.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Product()
        {
            var client = _httpClientFactory.CreateClient();
            var responserMessage = await client.GetAsync("http://localhost:5114/api/Product");
            if (responserMessage.IsSuccessStatusCode)
            {
                var jsonData = await responserMessage.Content.ReadAsStringAsync();
                var container = JsonConvert.DeserializeObject<ResponseComing<ProductItem>>(jsonData);
                var value = container.data;

                return View(value);
            }
            return View();
        }
    }
}
