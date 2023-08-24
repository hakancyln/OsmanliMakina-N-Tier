using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Osm.DataAccessLayer.EF.Context;
using Osm.WebUI.Areas.Admin.Models;
using Osm.WebUI.Models;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace Osm.WebUI.Areas.Admin.Controllers
{
    public class AdminProductController : Controller
    {
        OsmanliMakinaContext _context = new OsmanliMakinaContext();

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AdminProductController(IHttpClientFactory httpClientFactory, IWebHostEnvironment hostingEnvironment)
        {
            _httpClientFactory = httpClientFactory;
            _hostingEnvironment = hostingEnvironment;

        }
        [HttpGet]
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

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductItem p)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(p);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5114/api/Product", stringContent);



            if (responseMessage.IsSuccessStatusCode)
            {
                RedirectToRoute("http://localhost:5274/adminekipmanlar");
            }


            return View();
        }

        public async Task<IActionResult> ProductDelete(int id, ProductUpdateItem p)
        {
            
            var client = _httpClientFactory.CreateClient();
            var responserMessage = await client.DeleteAsync($"http://localhost:5114/api/Product/{id}");
            if (responserMessage.IsSuccessStatusCode)
            {
                string responseMessage ="  Ekipman Silinmiştir.";
                return new JsonResult(new { success = true, responseText = responseMessage });
            }
            return new JsonResult(new { success = false, responseText = "Ekipman Silinemedi." });
        }
        [HttpGet]
        public async Task<IActionResult> ProductUpdate(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5114/api/Product/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(jsonData);
               
                return View(myDeserializedClass);
            }

            return Redirect("http://localhost:5274/adminekipmanlar");


        }
        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductUpdateItem p, AddImage y, int id, IFormFile imageFile)
        {
            id = p.data.id;
            var info = _context.Product.Where(k => k.ID == p.data.id).SingleOrDefault();

            var client = _httpClientFactory.CreateClient();
            if (imageFile != null && imageFile.Length > 0)
            {
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                var imagePath = Path.Combine(_hostingEnvironment.WebRootPath, "ProductsImage", uniqueFileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                p.data.image = "ProductsImage/" + uniqueFileName;


                var jsonData = JsonConvert.SerializeObject(p.data);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:5114/api/Product", stringContent);
                //int ProductID = id;
                y.Image = p.data.image;
                y.ProductID = p.data.id;
                var jsonData2 = JsonConvert.SerializeObject(y);
                StringContent stringContent2 = new StringContent(jsonData2, Encoding.UTF8, "application/json");
                var responseMessage2 = await client.PostAsync("http://localhost:5114/api/ProductImage", stringContent2);
                if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
                {

                    return Redirect($"http://localhost:5274/adminekipmanguncelle/{id}");
                }
                return View();
            }
            else
            {
                p.data.image = info.Image;

                var jsonData = JsonConvert.SerializeObject(p.data);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:5114/api/Product", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {

                    return Redirect("http://localhost:5274/adminekipmanlar");
                }
            }
            return View();
        }
        public async Task<bool> ProductImageDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responserMessage = await client.DeleteAsync($"http://localhost:5114/api/ProductImage/{id}");
            if (responserMessage.IsSuccessStatusCode)
            {
                return true;

            }
            return false;
        }
    }
}


