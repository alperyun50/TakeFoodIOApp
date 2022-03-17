using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TakeFoodIOApp.Controllers
{
    public class ShowcaseController : Controller
    {
        [AllowAnonymous]
        public IActionResult MainPage()
        {
            return View();
        }
    }
}
