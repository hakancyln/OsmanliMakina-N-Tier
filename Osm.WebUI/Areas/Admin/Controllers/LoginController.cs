using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Osm.DataAccessLayer.EF.Context;
using Osm.ModelLayer.Entities;
using Osm.WebUI.Areas.Admin.Models;

namespace Osm.WebUI.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        OsmanliMakinaContext db = new OsmanliMakinaContext();

        //private readonly SignInManager<AdminLogin> _signInManager;
        //private readonly UserManager<AdminLogin> _userManager;

        //public LoginController(SignInManager<AdminLogin> signInManager, UserManager<AdminLogin> userManager)
        //{
        //    _signInManager = signInManager;
        //    _userManager = userManager;
        //}
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginItem loginItem)
        {
            if (ModelState.IsValid)
            {
                var info = db.AdminLogin.Where(x => x.ID == 1).SingleOrDefault();
                var user = db.AdminLogin.FirstOrDefault(u => u.UserName == loginItem.UserName);

                if (user != null)
                {
                    bool isValidPasword = info.Password.Equals(loginItem.Password);
                    if (isValidPasword)
                    {
                        // Giriş başarılı
                        return Redirect("http://localhost:5274/adminmesajlar");
                    }
                }

                ModelState.AddModelError(string.Empty, "Giriş başarısız. Lütfen tekrar deneyin.");
            }

            return View(loginItem);
            //var info = db.AdminLogin.Where(x => x.ID == 1).SingleOrDefault();
            //var info1 = db.AdminLogin.FirstOrDefault(x => x.UserName == loginItem.UserName);
            //if (info1 != null)
            //{
            //    bool isValidPasword = info.Password.Equals(loginItem.Password);
            //    if (isValidPasword)
            //    {
            //        string userName = loginItem.UserName;
            //        ViewBag.UserName = userName;

            //        return Redirect("adminmesajlar");
            //    }
            //    else
            //    {
            //        return View();
            //    }

            //}
            //else
            //{

            //    return View();


            //}

        }

        public async Task<IActionResult> LogOut()
        {
            //await _signInManager.SignOutAsync();
            return Redirect("http://localhost:5274/osm19");
        }




    }
}

