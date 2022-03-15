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

        [HttpGet]
        public IActionResult CategoryGet(int id)
        {
            var x = categoryRepository.TGet(id);

            Category ct = new Category()
            {
                CategoryName = x.CategoryName,
                CategoryDescription = x.CategoryDescription,
                CategoryId = x.CategoryId
            };

            return View(ct);
        }

        [HttpPost]
        public IActionResult CategoryUpdate(Category p)
        {
            var x = categoryRepository.TGet(p.CategoryId);

            x.CategoryName = p.CategoryName;
            x.CategoryDescription = p.CategoryDescription;
            x.Status = true;

            categoryRepository.TUpdate(x);

            return RedirectToAction("CategoryListPage");
        }

        public IActionResult CategoryDelete(int id)
        {
            var x = categoryRepository.TGet(id);
            x.Status = false;

            categoryRepository.TUpdate(x);

            return RedirectToAction("CategoryListPage");
        }
    }
}
