using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Osm.WebUI.Areas.Admin.Models;
using Osm.WebUI.Models;
using System.Text;

namespace Osm.WebUI.Areas.Admin.Controllers
{
    public class AdminUserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminUserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> User()
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"http://localhost:5114/api/AdminLogin/1");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    UserRoot myDeserializedClass = JsonConvert.DeserializeObject<UserRoot>(jsonData);
                    return View(myDeserializedClass);
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> User(UserRoot model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model.data);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5114/api/AdminLogin", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {

                return Redirect("http://localhost:5274/adminkullanicibilgileri/1");
            }
            return View();
        }
    }

}
