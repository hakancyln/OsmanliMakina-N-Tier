using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Osm.WebUI.Models;
using System.Reflection;
using System.Text;

namespace Osm.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]

        public async Task<IActionResult> Contact()
        {
            var client = _httpClientFactory.CreateClient();
            var responserMessage = await client.GetAsync("http://localhost:5114/api/CompanyInfo");
            if (responserMessage.IsSuccessStatusCode)
            {
                var jsonData = await responserMessage.Content.ReadAsStringAsync();
                var container = JsonConvert.DeserializeObject<ResponseComing<FooterItem>>(jsonData);
                var value = container.data;

                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(AddMessageItem p)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(p);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5114/api/Message", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return Redirect("http://localhost:5274/iletisim");
                }
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}
