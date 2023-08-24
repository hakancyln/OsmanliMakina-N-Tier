using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Osm.WebUI.Areas.Admin.Models;
using System.Text;

namespace Osm.WebUI.Areas.Admin.Controllers
{
    public class CompanyInfoController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public CompanyInfoController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> CompanyInfo(int id)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"http://localhost:5114/api/CompanyInfo/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    CompanyInfoRoot myDeserializedClass = JsonConvert.DeserializeObject<CompanyInfoRoot>(jsonData);
                    return View(myDeserializedClass);
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CompanyInfo(CompanyInfoRoot model,int id)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model.data);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5114/api/CompanyInfo", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {

                return Redirect("http://localhost:5274/adminfirmabilgileriguncelle/1");
            }
            return View();
        }
    }
}
