using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using chefsdishes.Models;

namespace chefsdishes.Controllers
{
    public class HomeController : Controller
    {
        private ProjectContext dbContext;

        public HomeController(ProjectContext context)
        {
            dbContext = context;
        }
        

        [HttpGet("")]
        [HttpGet("Chefs")]
        public IActionResult Chefs()
        {
            List<Chef> AllChefs = dbContext.Chefs.OrderByDescending(chef => chef.ChefId).ToList();
            foreach(var chef in AllChefs)
            {
                int total = dbContext.Dishes.Where(dish => dish.ChefId == chef.ChefId).Count();
                chef.Total = total; 
            }
            ViewBag.AllChefs = AllChefs;
            return View();
        }

        [HttpGet("Dishes")]
        public IActionResult Dishes()
        {
            List<Dish> AllDishes = dbContext.Dishes.OrderByDescending(dish => dish.DishId).Include(x => x.Chef).ToList();
            ViewBag.AllDishes = AllDishes;
            return View();
        }

        [HttpGet("New")]
        [HttpGet("New/Chefs")]
        public IActionResult NewChefs()
        {
            return View();
        }

        [HttpGet("New/Dishes")]
        public IActionResult NewDishes()
        {
            List<Chef> AllChefs = dbContext.Chefs.OrderByDescending(chef => chef.ChefId).ToList();
            ViewBag.AllChefs = AllChefs;
            return View();
        }

        [HttpPost("New/Chefs")]
        public IActionResult NewChefs(Chef chef)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(chef);
                dbContext.SaveChanges();
                return RedirectToAction("Chefs");
            }
            else
            {
                return View("NewChefs");
            }
        }

        [HttpPost("New/Dishes")]
        public IActionResult NewDishes(Dish dish)
        {
            if(ModelState.IsValid)
            {
                Chef RetrievedChef = dbContext.Chefs.SingleOrDefault(chef => chef.ChefId == dish.ChefId);
                dish.Chef = RetrievedChef;
                dbContext.Add(dish);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            else
            {
                List<Chef> AllChefs = dbContext.Chefs.OrderByDescending(chef => chef.ChefId).ToList();
                ViewBag.AllChefs = AllChefs;
                return View("NewDishes");
            }
        }
    }
}