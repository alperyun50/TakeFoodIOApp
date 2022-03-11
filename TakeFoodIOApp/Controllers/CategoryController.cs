using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeFoodIOApp.Repositories;

namespace TakeFoodIOApp.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult CategoryListPage()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
           
            return View(categoryRepository.TList());
        }
    }
}
