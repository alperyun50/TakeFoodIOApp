using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TakeFoodIOApp.Data.Models;

namespace TakeFoodIOApp.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();

        // yuo can just reach LoginPage with this
        [AllowAnonymous]
        [HttpGet]
        public IActionResult LoginPage()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LoginPage(Admin p)
        {
            var uservalues = c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);

            if(uservalues != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, p.UserName),
                    //new Claim(ClaimTypes.Role, p.AdminRole)
                };

                var useridentity = new ClaimsIdentity(claims, "Login");

                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);

                await HttpContext.SignInAsync(principal);

                return RedirectToAction("CategoryListPage", "Category");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogoutPage()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("LoginPage", "Login");
        }
    }
}
