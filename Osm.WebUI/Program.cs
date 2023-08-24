

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Osm.ModelLayer.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddLogging();
builder.Services.AddControllers();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "hakkimizda",
        pattern: "hakkimizda",
        defaults: new { controller = "About", action = "About" } // Örnek controller ve action adlarý
    );
    endpoints.MapControllerRoute(
        name: "anasayfa",
        pattern: "",
        defaults: new { controller = "Index", action = "Index" } // Örnek controller ve action adlarý
    );
    endpoints.MapControllerRoute(
        name: "iletisim",
        pattern: "iletisim",
        defaults: new { controller = "Contact", action = "Contact" } // Örnek controller ve action adlarý
    );
    endpoints.MapControllerRoute(
        name: "ekipmanlar",
        pattern: "ekipmanlar",
        defaults: new { controller = "Product", action = "Product" } // Örnek controller ve action adlarý
    );
    endpoints.MapControllerRoute(
        name: "ekipmandetay",
        pattern: "ekipmandetay/{id}",
        defaults: new { controller = "ProductDetail", action = "ProductDetail" } // Örnek controller ve action adlarý
    );
    endpoints.MapControllerRoute(
            name: "adminmesajlar",
            pattern: "adminmesajlar",
            defaults: new { area = "Admin", controller = "AdminMessage", action = "Message" }
          );
    endpoints.MapControllerRoute(
            name: "adminmesajdetay",
            pattern: "adminmesajdetay/{id}",
            defaults: new { area = "Admin", controller = "AdminMessageDetail", action = "MessageDetail" }
          );
    endpoints.MapControllerRoute(
            name: "ekipmansil",
            pattern: "ekipmansil/{id}",
            defaults: new { area = "Admin", controller = "AdminProduct", action = "ProductDelete" }
          );
    endpoints.MapControllerRoute(
            name: "adminekipmanlar",
            pattern: "adminekipmanlar",
            defaults: new { area = "Admin", controller = "AdminProduct", action = "Product" }
          );
    endpoints.MapControllerRoute(
            name: "adminekipmanekleme",
            pattern: "adminekipmanekleme",
            defaults: new { area = "Admin", controller = "AdminProduct", action = "AddProduct" }
          );
    endpoints.MapControllerRoute(
            name: "adminekipmanguncelle",
            pattern: "adminekipmanguncelle/{id}",
            defaults: new { area = "Admin", controller = "AdminProduct", action = "ProductUpdate" }
          );
    endpoints.MapControllerRoute(
            name: "adminfirmabilgileriguncelle",
            pattern: "adminfirmabilgileriguncelle/{id}",
            defaults: new { area = "Admin", controller = "CompanyInfo", action = "CompanyInfo" }
          );
    endpoints.MapControllerRoute(
            name: "osm19",
            pattern: "osm19",
            defaults: new { area = "Admin", controller = "Login", action = "Login" }
          );
    endpoints.MapControllerRoute(
            name: "LogOut",
            pattern: "LogOut",
            defaults: new { area = "Admin", controller = "Login", action = "LogOut" }
          );
    endpoints.MapControllerRoute(
            name: "adminkullanicibilgileri",
            pattern: "adminkullanicibilgileri/{id}",
            defaults: new { area = "Admin", controller = "AdminUser", action = "User" }
          );
    endpoints.MapControllerRoute(
            name: "ekipmanresimsil",
            pattern: "ekipmanresimsil/{id}",
            defaults: new { area = "Admin", controller = "AdminProduct", action = "ProductImageDelete" }
          );
});
app.Run();
//app.UseAuthorization();
//app.UseAuthentication();
