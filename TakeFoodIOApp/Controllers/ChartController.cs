using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeFoodIOApp.Data;
using TakeFoodIOApp.Data.Models;

namespace TakeFoodIOApp.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult ChartPieView()
        {
            return View();
        }

        public IActionResult ChartColumnView()
        {
            return View();
        }

        public IActionResult VisualizeProductResult()
        {

            return Json(ProList());
        }

        // static test object
        public List<Class1> ProList()
        {
            List<Class1> cs = new List<Class1>();

            cs.Add(new Class1()
            {
                proname = "Computer",
                stock = 150
            });

            cs.Add(new Class1()
            {
                proname = "Lcd",
                stock = 75
            });

            cs.Add(new Class1()
            {
                proname = "Usb Disk",
                stock = 220
            });

            return cs;
        }

        public IActionResult ChartPieDBView()
        {
            return View();
        }

        public IActionResult VisualizeFoodResult()
        {

            return Json(FoodList());
        }

        public List<Class2> FoodList()
        {
            List<Class2> cs2 = new List<Class2>();
            
            using(var c = new Context())
            {
                cs2 = c.Foods.Select(x => new Class2
                {
                    foodname = x.Name,
                    stock = x.Stock
                }).ToList();
            }

            return cs2;
        }

        public IActionResult Statistics()
        {
            Context c = new Context();
            
            // total food
            var value1 = c.Foods.Count();
            ViewBag.totalfood = value1;

            // total category
            var value2 = c.Categories.Count();
            ViewBag.totalcategory = value2;

            // fruit count (food with categorid = 1)
            var foid = c.Categories.Where(x => x.CategoryName == "Fruit").Select(y => y.CategoryId).FirstOrDefault();
            var value3 = c.Foods.Where(x => x.CategoryId == foid).Count();
            ViewBag.fruitcount = value3;

            // vegetable count
            var veid = c.Categories.Where(x => x.CategoryName == "Vegetables").Select(y => y.CategoryId).FirstOrDefault();
            var value4 = c.Foods.Where(x => x.CategoryId == veid).Count();
            ViewBag.vegetablecount = value4;

            // total food stock
            var value5 = c.Foods.Sum(x => x.Stock);
            ViewBag.sumoffood = value5;

            // lagumes count
            var laco = c.Categories.Where(x => x.CategoryName == "Lagumes").Select(y => y.CategoryId).FirstOrDefault();
            var value6 = c.Foods.Where(x => x.CategoryId == laco).Count();
            ViewBag.lagumescount = value6;

            // returned max stock name
            var value7 = c.Foods.OrderByDescending(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.foodmax = value7;

            // returned min stock name
            var value8 = c.Foods.OrderBy(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.foodmin = value8;

            // food price average
            var value9 = c.Foods.Average(x => x.Price).ToString("0.000");
            ViewBag.foodpriceavg = value9;

            return View();
        }
    }
}
