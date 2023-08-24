using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.MSIdentity.Shared;
using Newtonsoft.Json;
using Osm.ModelLayer.Dtos.CompanyInfoDto;
using Osm.WebUI.Models;

namespace Osm.WebUI.Controllers
{
    public class ProductDetailController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public ProductDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //http://localhost:5114/api/Product
        public async Task<IActionResult> ProductDetail(int id)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"http://localhost:5114/api/Product/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(jsonData);
                    return View(myDeserializedClass);
                }
            }
            return View();
            //var client = _httpClientFactory.CreateClient();
            //var responserMessage = await client.GetAsync($"http://localhost:5114/api/Product/{id}");
            //if (responserMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responserMessage.Content.ReadAsStringAsync();
            //    var container = JsonConvert.DeserializeObject<ResponseComing<ProductDetailItem>>(jsonData);
            //    var value = container.data;

            //    return View(value);
            //}
            //return View();
        }
    }
}
