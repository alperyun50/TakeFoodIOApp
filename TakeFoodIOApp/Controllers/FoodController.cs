using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeFoodIOApp.Repositories;

namespace TakeFoodIOApp.Controllers
{
    public class FoodController : Controller
    {
        public IActionResult FoodListPage()
        {
            FoodRepository foodRepository = new FoodRepository();

            // Category string added for relational database
            return View(foodRepository.TList("Category"));
        }
    }
}
