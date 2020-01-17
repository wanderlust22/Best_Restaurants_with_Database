using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BestRestaurants.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly BestRestaurantsContext _db;

        public RestaurantController(BestRestaurantsContext db)
        {
            _db = db;
        }

        public ActionResult Create(int id)
        {
            Cuisine theCuisine = _db.Cuisine.FirstOrDefault(cuisine => cuisine.CuisineId == id);
            ViewBag.CuisineId = id;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Restaurant restaurant)
        {
            _db.Restaurant.Add(restaurant);
            _db.SaveChanges();
            Cuisine theCuisine = _db.Cuisine.FirstOrDefault(cuisine => cuisine.CuisineId == restaurant.CuisineId);
            return RedirectToAction("Details", "Cuisine", new { id = theCuisine.CuisineId});
        }

        public ActionResult Details(int id)
        {
            Restaurant theRestaurant = _db.Restaurant.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
            return View(theRestaurant);
        }

        public ActionResult Edit(int id)
        {
            Restaurant theRestaurant = _db.Restaurant.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
            return View(theRestaurant);
        }
        

    }
    
}