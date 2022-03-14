using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeFoodIOApp.Data.Models;
using TakeFoodIOApp.Repositories;

namespace TakeFoodIOApp.Controllers
{
    public class FoodController : Controller
    {
        Context c = new Context();
        FoodRepository foodRepository = new FoodRepository();

        public IActionResult FoodListPage()
        {
            // Category string added for relational database
            return View(foodRepository.TList("Category"));
        }

        [HttpGet]
        public IActionResult AddFood()
        {
            // used SelectListItem for dropdown item collections
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }
                                           ).ToList();

            ViewBag.v1 = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddFood(Food p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddFood");
            }

            foodRepository.TAdd(p);

            return RedirectToAction("FoodListPage");
        }

        public IActionResult DeleteFood(int id)
        {
            foodRepository.TDelete(new Food {FoodId = id });

            return RedirectToAction("FoodListPage");
        }
    }
}
