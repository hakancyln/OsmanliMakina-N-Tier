using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Osm.WebUI.Areas.Admin.Models;
using Osm.WebUI.Models;

namespace Osm.WebUI.Areas.Admin.Controllers
{
    public class AdminMessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminMessageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Message()
        {
            var client = _httpClientFactory.CreateClient();
            var responserMessage = await client.GetAsync("http://localhost:5114/api/Message");
            if (responserMessage.IsSuccessStatusCode)
            {
                var jsonData = await responserMessage.Content.ReadAsStringAsync();
                var container = JsonConvert.DeserializeObject<ResponseComing<MessageItem>>(jsonData);
                var value = container.data;

                return View(value);
            }
            return View();
        }
    }
}
