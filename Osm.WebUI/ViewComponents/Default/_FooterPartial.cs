using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Osm.WebUI.Models;
using System.Text.Json;

namespace Osm.WebUI.ViewComponents.Default
{
    public class _FooterPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FooterPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //http://localhost:5114/api/CompanyInfo
        public async Task<IViewComponentResult> InvokeAsync()
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
    }
}

