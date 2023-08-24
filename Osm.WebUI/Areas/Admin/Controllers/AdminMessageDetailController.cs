using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Osm.WebUI.Areas.Admin.Models;
using Osm.WebUI.Models;

namespace Osm.WebUI.Areas.Admin.Controllers
{
    public class AdminMessageDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminMessageDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult>  MessageDetail(int id)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"http://localhost:5114/api/Message/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    MessageRoot myDeserializedClass = JsonConvert.DeserializeObject<MessageRoot>(jsonData);
                    return View(myDeserializedClass);
                }
            }
            return View();
        }
    }
    }
