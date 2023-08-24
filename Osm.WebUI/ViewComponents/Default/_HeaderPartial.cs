using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Osm.WebUI.Models;

namespace Osm.WebUI.ViewComponents.Default
{

    public class _HeaderPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HeaderPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //http://localhost:5114/api/Product
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responserMessage = await client.GetAsync("http://localhost:5114/api/Product");
            if (responserMessage.IsSuccessStatusCode)
            {
                var jsonData = await responserMessage.Content.ReadAsStringAsync();
                var container = JsonConvert.DeserializeObject<ResponseComing<HeaderItem>>(jsonData);
                var value = container.data;

                return View(value);
            }
            return View();
        }
    }
}

