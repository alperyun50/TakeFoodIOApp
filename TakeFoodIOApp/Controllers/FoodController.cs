using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeFoodIOApp.Data.Models;
using TakeFoodIOApp.Repositories;
using X.PagedList;

namespace TakeFoodIOApp.Controllers
{
    public class FoodController : Controller
    {
        Context c = new Context();
        FoodRepository foodRepository = new FoodRepository();

        public IActionResult FoodListPage(int page = 1)
        {
            // Category string added for relational database
            return View(foodRepository.TList("Category").ToPagedList(page, 3));
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

        [HttpDelete]
        public IActionResult DeleteFood(int id)
        {
            foodRepository.TDelete(new Food {FoodId = id });

            return RedirectToAction("FoodListPage");
        }

        [HttpGet]
        public IActionResult FoodGet(int id)
        {
            var x = foodRepository.TGet(id);

            // used SelectListItem for dropdown item collections
            List<SelectListItem> values = (from y in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryId.ToString()
                                           }
                                           ).ToList();
            ViewBag.v1 = values;

            Food f = new Food()
            {
                FoodId = x.FoodId,
                CategoryId = x.CategoryId,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,
                Description = x.Description,
                ImageURL = x.ImageURL
            };

            return View(f);
        }

        [HttpPost]
        public IActionResult FoodUpdate(Food p)
        {
            var x = foodRepository.TGet(p.FoodId);

            x.Name = p.Name;
            x.Stock = p.Stock;
            x.Price = p.Price;
            x.ImageURL = p.ImageURL;
            x.Description = p.Description;
            x.CategoryId = p.CategoryId;

            foodRepository.TUpdate(x);

            return RedirectToAction("FoodListPage");
        }
    }
}
