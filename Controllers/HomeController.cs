using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private Context dbContext;
        public HomeController(Context context)
        {
            dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext.Chefs.Include(d => d.CreatedDishes).ToList();
            return View(AllChefs);
        }
        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> AllDishes = dbContext.Dishes.Include(c => c.Chef).ToList();
            return View(AllDishes);
        }
        [HttpGet("new")]
        public IActionResult AddChef()
        {
            return View();
        }
        [HttpPost("createchef")]
        public IActionResult CreateChef(Chef chef)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(chef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("AddChef");
            }
        }
        [HttpGet("dishes/new")]
        public IActionResult AddDish()
        {
            ChefDishesViewModel ThisView = new ChefDishesViewModel();
            List<Chef> AllChefs = dbContext.Chefs.ToList();
            ThisView.Cooks = AllChefs;
            return View(ThisView);
        }
        [HttpPost("createdish")]
        public IActionResult CreateDish(ChefDishesViewModel modeldata)
        {
            if(ModelState.IsValid)
            {
                dbContext.Dishes.Add(modeldata.Food);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            else
            {
                ChefDishesViewModel ThisView = new ChefDishesViewModel();
                List<Chef> AllChefs = dbContext.Chefs.ToList();
                ThisView.Cooks = AllChefs;
                return View("AddDish", ThisView);
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
