using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeFoodIOApp.Data.Models;
using TakeFoodIOApp.Repositories;

namespace TakeFoodIOApp.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();

        public IActionResult CategoryListPage()
        {
            return View(categoryRepository.TList());
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {


            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            if(!ModelState.IsValid)
            {
                return View("CategoryAdd"); 
            }

            categoryRepository.TAdd(p);

            return RedirectToAction("CategoryListPage");


        }
    }
}
